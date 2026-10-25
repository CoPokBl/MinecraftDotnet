using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using ClientLib.Chat;
using Minecraft.Data.Generated;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas.Chat;
using Newtonsoft.Json.Linq;
using PlayerData = Minecraft.Packets.Play.ClientBound.ClientBoundPlayerInfoUpdatePacket.PlayerData;

namespace ClientLib.Testing.Chat;

/// <summary>
/// Messages vanilla signed, read from vanilla-signed-chat.json, which <c>Conformance/chatsigning.sh fixture</c>
/// printed: a profile key signed by a stand in services key, then three chained messages, each seeing the
/// ones before. Our own signing could only ever agree with our own checking; these signatures came out of the jar.
/// </summary>
public class IncomingChatTest {
    private static JObject Fixture([CallerFilePath] string path = "") =>
        JObject.Parse(File.ReadAllText(Path.Combine(Path.GetDirectoryName(path)!, "vanilla-signed-chat.json")));

    private static RSAParameters ServicesKey(JObject fixture) {
        using RSA rsa = RSA.Create();
        rsa.ImportSubjectPublicKeyInfo(Convert.FromBase64String(fixture.Value<string>("servicesKey")!), out _);
        return rsa.ExportParameters(false);
    }

    private static ProfilePublicKey.KeyData KeyData(JObject fixture, long? expiresAt = null) => new(
        DateTimeOffset.FromUnixTimeMilliseconds(expiresAt ?? fixture.Value<long>("expiresAt")),
        Convert.FromBase64String(fixture.Value<string>("publicKey")!),
        Convert.FromBase64String(fixture.Value<string>("keySignature")!));

    private static Guid ProfileId(JObject fixture) => Guid.Parse(fixture.Value<string>("profileId")!);

    private static Guid SessionId(JObject fixture) => Guid.Parse(fixture.Value<string>("sessionId")!);

    private static MessageSignature Signature(string base64) => new(Convert.FromBase64String(base64));

    private static PlayerChatMessage Message(JObject fixture, JToken message) => new(
        new SignedMessageLink(message.Value<int>("index"), ProfileId(fixture), SessionId(fixture)),
        Signature(message.Value<string>("signature")!),
        new SignedMessageBody(message.Value<string>("content")!, DateTimeOffset.FromUnixTimeMilliseconds(message.Value<long>("timeStamp")),
            message.Value<long>("salt"), new LastSeenMessages(message["lastSeen"]!.Select(s => Signature(s.Value<string>()!)).ToList())),
        null, ChatFilterMask.PassThrough);

    [Test]
    public void TheServicesSignatureOverTheProfileKeyVerifies() {
        JObject fixture = Fixture();
        Assert.Multiple(() => {
            Assert.That(ProfilePublicKey.CreateValidated([ServicesKey(fixture)], ProfileId(fixture), KeyData(fixture)), Is.Not.Null);
            // The expiry and the profile are both in what the services signed.
            Assert.That(ProfilePublicKey.CreateValidated([ServicesKey(fixture)], ProfileId(fixture), KeyData(fixture, fixture.Value<long>("expiresAt") + 1)),
                Is.Null);
            Assert.That(ProfilePublicKey.CreateValidated([ServicesKey(fixture)], Guid.NewGuid(), KeyData(fixture)), Is.Null);
        });
    }

    [Test]
    public void VanillaSignedMessagesVerifyInOrder() {
        JObject fixture = Fixture();
        RemoteChatSession session = new(SessionId(fixture), new ProfilePublicKey(KeyData(fixture)));
        SignedMessageValidator validator = session.CreateMessageValidator(ProfilePublicKey.ExpiryGracePeriod);
        foreach (JToken message in fixture["messages"]!) {
            Assert.That(validator.UpdateAndValidate(Message(fixture, message)), Is.Not.Null, message.Value<string>("content"));
        }
    }

    [Test]
    public void TheLastSeenChecksumMatchesVanillas() {
        JObject fixture = Fixture();
        foreach (JToken message in fixture["messages"]!) {
            Assert.That((sbyte)Message(fixture, message).SignedBody.LastSeen.ComputeChecksum(), Is.EqualTo(message.Value<int>("checksum")));
        }
    }

    [Test]
    public void AChangedMessageOrAnOldLinkBreaksTheChain() {
        JObject fixture = Fixture();
        RemoteChatSession session = new(SessionId(fixture), new ProfilePublicKey(KeyData(fixture)));
        JToken[] messages = fixture["messages"]!.ToArray();

        SignedMessageValidator tampered = session.CreateMessageValidator(ProfilePublicKey.ExpiryGracePeriod);
        PlayerChatMessage first = Message(fixture, messages[0]);
        Assert.That(tampered.UpdateAndValidate(first with { SignedBody = first.SignedBody with { Content = "hellO" } }), Is.Null);
        // A chain once broken stays broken, however good what follows is.
        Assert.That(tampered.UpdateAndValidate(Message(fixture, messages[1])), Is.Null);

        SignedMessageValidator replayed = session.CreateMessageValidator(ProfilePublicKey.ExpiryGracePeriod);
        Assert.That(replayed.UpdateAndValidate(Message(fixture, messages[1])), Is.Not.Null);
        Assert.That(replayed.UpdateAndValidate(Message(fixture, messages[0])), Is.Null);
    }

    /// <summary>
    /// The whole <c>handlePlayerChat</c> path: the session from player info checked against the services key, each
    /// message's last seen list unpacked from the signature cache, then shown and acknowledged on the next send.
    /// </summary>
    [Test]
    public void PlayerChatPacketsAreCheckedShownAndAcknowledged() {
        JObject fixture = Fixture();
        RSAParameters servicesKey = ServicesKey(fixture);
        MinecraftClient client = new(new ClientOptions { Username = "Reader" }) { ProfileKeySignatureKeys = () => [servicesKey] };
        client.StartOffline(new World.ClientLevel(VanillaRegistry.Data, "minecraft:overworld",
            VanillaRegistry.Data.DimensionTypes["minecraft:overworld"], 63, true, 0));
        List<MinecraftPacket> sent = [];
        client.PacketSent += sent.Add;
        List<GuiMessage> shown = [];
        client.ChatMessages.Added += shown.Add;

        Guid sender = ProfileId(fixture);
        ProfilePublicKey.KeyData key = KeyData(fixture);
        client.Dispatch(new ClientBoundPlayerInfoUpdatePacket {
            Data = new PlayerData(ClientBoundPlayerInfoUpdatePacket.PlayerActions.AddPlayer, ClientBoundPlayerInfoUpdatePacket.PlayerActions.InitializeChat)
                .WithPlayer(sender, new PlayerData.AddPlayer { Name = "Signer" }, new PlayerData.InitializeChat {
                    HasData = true, ChatSessionId = SessionId(fixture), PublicKeyExpiryTime = key.ExpiresAt.ToUnixTimeMilliseconds(),
                    EncodedPublicKey = key.Key, PublicKeySignature = key.KeySignature
                })
        });
        Assert.That(client.PlayerList[sender].ChatSession, Is.Not.Null);

        MessageSignatureCache serverCache = MessageSignatureCache.CreateDefault();
        int globalIndex = 0;
        foreach (JToken json in fixture["messages"]!) {
            PlayerChatMessage message = Message(fixture, json);
            client.Dispatch(new ClientBoundPlayerChatMessagePacket {
                GlobalIndex = globalIndex++,
                Sender = sender,
                Index = message.Link.Index,
                Signature = message.Signature!.Data,
                Content = message.SignedContent,
                Timestamp = message.SignedBody.TimeStamp,
                Salt = message.SignedBody.Salt,
                // The server packs against its own copy of the cache, which mirrors the client's.
                LastSeen = message.SignedBody.LastSeen.Pack(serverCache),
                FilterMask = ChatFilterMask.PassThrough,
                ChatType = BoundChatType.Reference("minecraft:chat", Minecraft.Text.TextComponent.Text("Signer"))
            });
            serverCache.Push(message.SignedBody, message.Signature);
        }

        Assert.Multiple(() => {
            Assert.That(shown.Select(m => m.Signature?.ToString()), Is.EqualTo(fixture["messages"]!.Select(m => m.Value<string>("signature"))));
            // Signed long ago, so past the client's seven minutes: shown, but not as secure.
            Assert.That(shown.Select(m => m.Tag), Is.All.EqualTo(GuiMessageTag.ChatNotSecure));
        });

        client.SendChatMessage("seen them");
        ServerBoundChatMessagePacket reply = sent.OfType<ServerBoundChatMessagePacket>().Single();
        Assert.Multiple(() => {
            Assert.That(reply.MessageCount, Is.EqualTo(3));
            // The ring starts at the tail, so the three newest are its last three slots.
            Assert.That(reply.Acknowledged, Is.EqualTo(new byte[] { 0x00, 0x00, 0b0000_1110 }));
            Assert.That(reply.Signature, Is.Null);
        });
    }
}
