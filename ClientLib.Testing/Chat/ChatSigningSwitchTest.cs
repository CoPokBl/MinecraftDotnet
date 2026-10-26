using System.Security.Cryptography;
using ClientLib.Chat;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Client.Tools;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;

namespace ClientLib.Testing.Chat;

/// <summary>
/// The chat signing option. Off must be vanilla without a chat session: no key asked for, no session sent, chat
/// unsigned but still salted and acknowledged. The wire format of that state is the session-less corpus in
/// <c>Conformance/chatsigning.sh</c>; this pins when keys are asked for and sessions sent.
/// </summary>
public class ChatSigningSwitchTest {
    /// <summary>Hands out one key pair per request and counts them, standing in for <c>/player/certificates</c>.</summary>
    private sealed class CountingManager : ProfileKeyPairManager {
        public int Requests { get; private set; }

        public override Task<ProfileKeyPair?> PrepareKeyPair() {
            Requests++;
            RSA key = RSA.Create(2048);
            DateTimeOffset expires = DateTimeOffset.UtcNow.AddDays(2);
            ProfilePublicKey.KeyData data = new(expires, key.ExportSubjectPublicKeyInfo(), new byte[512]);
            return Task.FromResult<ProfileKeyPair?>(new ProfileKeyPair(key, new ProfilePublicKey(data), expires.AddDays(-1)));
        }

        public override bool ShouldRefreshKeyPair() => false;
    }

    private static (MinecraftClient Client, CountingManager Keys, List<MinecraftPacket> Sent) Client(bool signing) {
        MinecraftClient client = new(new ClientOptions {
            Account = new MicrosoftAuthenticator.MinecraftProfile("token", "Signer", Guid.NewGuid().ToString()),
            ChatSigning = signing
        });
        CountingManager keys = new();
        client.AccountKeyPairManager = keys;
        client.StartOffline(new World.ClientLevel(VanillaRegistry.Data, "minecraft:overworld",
            VanillaRegistry.Data.DimensionTypes["minecraft:overworld"], 63, true, 0));
        List<MinecraftPacket> sent = [];
        client.PacketSent += sent.Add;
        return (client, keys, sent);
    }

    private static void LogIn(MinecraftClient client) => client.Dispatch(new ClientBoundLoginPacket {
        EntityId = 1, IsHardcore = false, Dimensions = ["minecraft:overworld"], MaxPlayers = 20, ViewDistance = 8, SimulationDistance = 8,
        ReducedDebugInfo = false, EnableRespawnScreen = true, DoLimitedCrafting = false,
        DimensionType = VanillaRegistry.Data.DimensionTypes.GetProtocolId("minecraft:overworld"), DimensionName = "minecraft:overworld",
        HashedSeed = 0, GameMode = GameMode.Survival, PreviousGameMode = GameMode.Undefined, IsDebug = false, IsFlat = true,
        PortalCooldown = 0, SeaLevel = 63, OnlineMode = true, EnforcesSecureChat = false
    });

    [Test]
    public void SigningOnSendsASessionAndSignsChat() {
        (MinecraftClient client, CountingManager keys, List<MinecraftPacket> sent) = Client(true);
        LogIn(client);
        client.TickChatSession();
        client.SendChatMessage("signed");
        Assert.Multiple(() => {
            Assert.That(keys.Requests, Is.EqualTo(1));
            Assert.That(sent.OfType<ServerBoundPlayerSessionPacket>(), Has.Exactly(1).Items);
            Assert.That(sent.OfType<ServerBoundChatMessagePacket>().Single().Signature, Is.Not.Null);
        });
    }

    [Test]
    public void SigningOffAsksForNoKeyAndSendsNoSession() {
        (MinecraftClient client, CountingManager keys, List<MinecraftPacket> sent) = Client(false);
        LogIn(client);
        client.TickChatSession();
        client.SendChatMessage("unsigned");
        ServerBoundChatMessagePacket chat = sent.OfType<ServerBoundChatMessagePacket>().Single();
        Assert.Multiple(() => {
            Assert.That(keys.Requests, Is.Zero);
            Assert.That(sent.OfType<ServerBoundPlayerSessionPacket>(), Is.Empty);
            Assert.That(chat.Signature, Is.Null);
            Assert.That(chat.Salt, Is.Not.Zero);
            Assert.That(chat.Checksum, Is.EqualTo(1));
        });
    }

    [Test]
    public void TurnedOffBeforeTheKeyArrivesNoSessionGoesOut() {
        (MinecraftClient client, _, List<MinecraftPacket> sent) = Client(true);
        LogIn(client);
        client.SetChatSigning(false);
        client.TickChatSession();
        Assert.That(sent.OfType<ServerBoundPlayerSessionPacket>(), Is.Empty);
    }

    [Test]
    public void TurnedOffAfterTheSessionWentOutItKeepsSigningThatConnection() {
        (MinecraftClient client, CountingManager keys, List<MinecraftPacket> sent) = Client(true);
        LogIn(client);
        client.TickChatSession();
        client.SetChatSigning(false);
        client.TickChatSession();
        client.SendChatMessage("still signed");
        Assert.Multiple(() => {
            Assert.That(keys.Requests, Is.EqualTo(1));
            Assert.That(sent.OfType<ServerBoundPlayerSessionPacket>(), Has.Exactly(1).Items);
            Assert.That(sent.OfType<ServerBoundChatMessagePacket>().Single().Signature, Is.Not.Null);
        });
    }

    [Test]
    public void TurnedOnMidConnectionTheSessionFollowsOnALaterTick() {
        (MinecraftClient client, CountingManager keys, List<MinecraftPacket> sent) = Client(false);
        LogIn(client);
        client.SetChatSigning(true);
        Assert.That(sent.OfType<ServerBoundPlayerSessionPacket>(), Is.Empty);
        client.TickChatSession();
        Assert.Multiple(() => {
            Assert.That(keys.Requests, Is.EqualTo(1));
            Assert.That(sent.OfType<ServerBoundPlayerSessionPacket>(), Has.Exactly(1).Items);
        });
    }
}
