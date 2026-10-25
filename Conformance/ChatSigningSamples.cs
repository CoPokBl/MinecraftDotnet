using System.Security.Cryptography;
using ClientLib;
using ClientLib.Brigadier;
using ClientLib.Chat;
using ClientLib.Commands;
using ClientLib.Commands.Arguments;
using Minecraft;
using Minecraft.Packets;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Newtonsoft.Json.Linq;

namespace Conformance;

/// <summary>
/// What the client sends for <c>Conformance/chatsigning.sh</c>, which plays the server's part with vanilla's
/// own <c>LastSeenMessagesValidator</c> and <c>SignedMessageChain.Decoder</c>: a signature or a last seen
/// update our own tests accepted would be checked against our own reading of the format, which proves nothing.
/// </summary>
/// <remarks>
/// Each event is either a packet the client sent, as its body without the id, or the signature of a player
/// chat message the server sent and the client then processed. The second is where the server's validator
/// learns of a message, so the order of the two kinds is the whole test of the last seen tracking.
/// </remarks>
public static class ChatSigningSamples {
    /// <summary>The command tree both sides parse with, built the same way in ChatSigningHarness.java.</summary>
    private static CommandDispatcher<ClientSuggestionProvider> Dispatcher() {
        CommandDispatcher<ClientSuggestionProvider> dispatcher = new();
        static int Run(CommandContext<ClientSuggestionProvider> _) => 1;
        CommandNode<ClientSuggestionProvider> Message() =>
            RequiredArgumentBuilder<ClientSuggestionProvider>.Argument("message", new MessageArgument()).Executes(Run).Build();
        CommandNode<ClientSuggestionProvider> msg = LiteralArgumentBuilder<ClientSuggestionProvider>.LiteralOf("msg")
            .Then(RequiredArgumentBuilder<ClientSuggestionProvider>.Argument("targets", new EntityArgument(false, true)).Then(Message()).Build())
            .Build();
        dispatcher.Root.AddChild(msg);
        dispatcher.Root.AddChild(LiteralArgumentBuilder<ClientSuggestionProvider>.LiteralOf("tell").Redirect(msg).Build());
        dispatcher.Root.AddChild(LiteralArgumentBuilder<ClientSuggestionProvider>.LiteralOf("say").Then(Message()).Build());
        dispatcher.Root.AddChild(LiteralArgumentBuilder<ClientSuggestionProvider>.LiteralOf("me")
            .Then(RequiredArgumentBuilder<ClientSuggestionProvider>.Argument("action", new MessageArgument()).Executes(Run).Build()).Build());
        dispatcher.Root.AddChild(LiteralArgumentBuilder<ClientSuggestionProvider>.LiteralOf("execute")
            .Then(LiteralArgumentBuilder<ClientSuggestionProvider>.LiteralOf("run").Redirect(dispatcher.Root).Build()).Build());
        dispatcher.Root.AddChild(LiteralArgumentBuilder<ClientSuggestionProvider>.LiteralOf("tp")
            .Then(RequiredArgumentBuilder<ClientSuggestionProvider>.Argument("target", new EntityArgument(true, false)).Executes(Run).Build()).Build());
        return dispatcher;
    }

    public static string BuildJson() {
        JArray sessions = [Session(true), Session(false)];
        return sessions.ToString();
    }

    private static JObject Session(bool signed) {
        MinecraftClient client = new(new ClientOptions { Username = signed ? "Signer" : "Plain" });
        client.Commands = Dispatcher();
        JArray events = [];
        client.PacketSent += packet => events.Add(new JObject {
            ["sent"] = packet switch {
                ServerBoundChatMessagePacket => "chat",
                ServerBoundSignedChatCommandPacket => "chat_command_signed",
                ServerBoundChatCommandPacket => "chat_command",
                ServerBoundAcknowledgeMessagePacket => "chat_ack",
                _ => packet.GetType().Name
            },
            ["body"] = Convert.ToBase64String(Body(packet))
        });
        JObject session = new() { ["profileId"] = client.Profile.Uuid.ToString(), ["events"] = events };

        if (signed) {
            RSA key = RSA.Create(2048);
            // Whole milliseconds, which is all the wire carries.
            DateTimeOffset expires = DateTimeOffset.FromUnixTimeMilliseconds(DateTimeOffset.UtcNow.AddDays(2).ToUnixTimeMilliseconds());
            ProfilePublicKey.KeyData data = new(expires, key.ExportSubjectPublicKeyInfo(), RandomNumberGenerator.GetBytes(512));
            LocalChatSession chatSession = LocalChatSession.Create(new ProfileKeyPair(key, new ProfilePublicKey(data), expires));
            client.UseChatSession(chatSession);
            events.Add(new JObject {
                ["sent"] = "chat_session_update",
                ["body"] = Convert.ToBase64String(Body(MinecraftClient.SessionPacket(chatSession))),
                ["keySignature"] = Convert.ToBase64String(data.KeySignature)
            });
            session["sessionId"] = chatSession.SessionId.ToString();
            session["publicKey"] = Convert.ToBase64String(data.Key);
            session["expiresAt"] = expires.ToUnixTimeMilliseconds();
        }

        void Receive(bool shown) {
            MessageSignature signature = new(RandomNumberGenerator.GetBytes(MessageSignature.Bytes));
            events.Add(new JObject { ["received"] = Convert.ToBase64String(signature.Data) });
            client.MarkMessageAsProcessed(signature, shown);
        }

        client.SendChat("hello");
        Receive(true);
        Receive(true);
        Receive(true);
        client.SendChat("Unicode survives the length prefix: \u00fc\u00f1\u00ed\u00e7\u00f8d\u00e9 \u2603");
        Receive(true);
        Receive(false);
        Receive(true);
        client.SendChat("/say hello world");
        client.SendChat("/msg Bob hi there @a");
        Receive(true);
        client.SendChat("/tell Bob through a redirect");
        client.SendChat("/execute run say past a root redirect, so unsigned");
        client.SendChat("/me waves");
        client.SendChat("/tp Bob");
        client.SendChat("/msg Bob");
        // Enough to wrap the twenty slot window and pass the 64 that sends an acknowledgement unprompted.
        for (int i = 0; i < 70; i++) {
            Receive(i % 7 != 3);
        }
        client.SendChat("after the window wrapped");
        client.SendChat("/say and a command after it");
        return session;
    }

    private static byte[] Body(MinecraftPacket packet) {
        DataReader reader = new(packet.Serialise(ConnectionState.Play));
        // The frame's length, then the packet id.
        reader.ReadVarInt();
        reader.ReadVarInt();
        return reader.Read((int)(reader.Length - reader.Position));
    }
}
