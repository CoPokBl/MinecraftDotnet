using ClientLib.Brigadier;
using ClientLib.Chat;
using ClientLib.Commands;
using ClientLib.Commands.Arguments;
using Minecraft.Packets;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas.Chat;
using Minecraft.Text;

namespace ClientLib.Testing.Chat;

/// <summary>
/// What goes out with a chat line. The signatures themselves and the server's view of the last seen updates
/// are checked against the jar by <c>Conformance/chatsigning.sh</c>; these pin the arithmetic by hand.
/// </summary>
public class OutgoingChatTest {
    private static (MinecraftClient Client, List<MinecraftPacket> Sent) Client() {
        MinecraftClient client = new(new ClientOptions { Username = "Writer" });
        CommandDispatcher<ClientSuggestionProvider> dispatcher = new();
        dispatcher.Root.AddChild(LiteralArgumentBuilder<ClientSuggestionProvider>.LiteralOf("say")
            .Then(RequiredArgumentBuilder<ClientSuggestionProvider>.Argument("message", new MessageArgument()).Executes(_ => 1).Build()).Build());
        dispatcher.Root.AddChild(LiteralArgumentBuilder<ClientSuggestionProvider>.LiteralOf("list").Executes(_ => 1).Build());
        client.Commands = dispatcher;
        List<MinecraftPacket> sent = [];
        client.PacketSent += sent.Add;
        return (client, sent);
    }

    private static MessageSignature Filled(byte value) => new(Enumerable.Repeat(value, MessageSignature.Bytes).ToArray());

    [Test]
    public void TheChecksumIsJavasArrayHash() {
        // Arrays.hashCode of 256 zero bytes is 31^256, wrapped to an int; the list's is 31 + that, low byte 32.
        Assert.Multiple(() => {
            Assert.That(Filled(0).Checksum(), Is.EqualTo(-394403839));
            Assert.That(new LastSeenMessages([Filled(0)]).ComputeChecksum(), Is.EqualTo(32));
            // An empty list hashes to 1, which is also what a zero byte is replaced with.
            Assert.That(LastSeenMessages.Empty.ComputeChecksum(), Is.EqualTo(1));
        });
    }

    [Test]
    public void WithoutASessionAChatLineStillCarriesASaltAndTheLastSeenUpdate() {
        (MinecraftClient client, List<MinecraftPacket> sent) = Client();
        client.MarkMessageAsProcessed(Filled(1), true);
        client.MarkMessageAsProcessed(Filled(2), false);
        client.SendChat("hi");
        ServerBoundChatMessagePacket packet = sent.OfType<ServerBoundChatMessagePacket>().Single();
        Assert.Multiple(() => {
            Assert.That(packet.Signature, Is.Null);
            Assert.That(packet.Salt, Is.Not.Zero);
            Assert.That(packet.MessageCount, Is.EqualTo(2));
            // Slots 0 and 1 hold the two, which with the tail at 2 are the last two of the window; only the shown one counts.
            Assert.That(packet.Acknowledged, Is.EqualTo(new byte[] { 0x00, 0x00, 0b0000_0100 }));
            Assert.That(packet.Checksum, Is.EqualTo(new LastSeenMessages([Filled(1)]).ComputeChecksum()));
        });
    }

    [Test]
    public void TheSameSignatureTwiceIsTrackedOnce() {
        LastSeenMessagesTracker tracker = new(20);
        Assert.Multiple(() => {
            Assert.That(tracker.AddPending(Filled(1), true), Is.True);
            Assert.That(tracker.AddPending(Filled(1), true), Is.False);
            Assert.That(tracker.Offset, Is.EqualTo(1));
        });
    }

    [Test]
    public void ADeletedPendingMessageLeavesTheWindow() {
        LastSeenMessagesTracker tracker = new(20);
        tracker.AddPending(Filled(1), true);
        tracker.AddPending(Filled(2), true);
        tracker.IgnorePending(Filled(1));
        (LastSeenMessages lastSeen, LastSeenMessages.Update update) = tracker.GenerateAndApplyUpdate();
        Assert.Multiple(() => {
            Assert.That(lastSeen.Entries, Is.EqualTo(new[] { Filled(2) }));
            Assert.That(update.Offset, Is.EqualTo(2));
            Assert.That(update.Acknowledged, Is.EqualTo(new byte[] { 0x00, 0x00, 0b0000_1000 }));
        });
    }

    [Test]
    public void AnAcknowledgementGoesOutPastSixtyFourUnreported() {
        (MinecraftClient client, List<MinecraftPacket> sent) = Client();
        for (int i = 0; i < 65; i++) {
            Assert.That(sent, Is.Empty);
            client.MarkMessageAsProcessed(Filled((byte)i), i % 2 == 0);
        }
        Assert.That(sent.OfType<ServerBoundAcknowledgeMessagePacket>().Single().MessageCount, Is.EqualTo(65));
    }

    [Test]
    public void ACommandWithAMessageArgumentGoesAsASignedCommand() {
        (MinecraftClient client, List<MinecraftPacket> sent) = Client();
        client.SendChat("/say hello there");
        client.SendChat("/list");
        Assert.Multiple(() => {
            ServerBoundSignedChatCommandPacket signed = sent.OfType<ServerBoundSignedChatCommandPacket>().Single();
            Assert.That(signed.Command, Is.EqualTo("say hello there"));
            Assert.That(signed.ArgumentSignatures, Is.Empty);
            Assert.That(signed.Checksum, Is.EqualTo(1));
            Assert.That(sent.OfType<ServerBoundChatCommandPacket>().Single().Command, Is.EqualTo("list"));
        });
    }

    [Test]
    public void SignableCommandTakesTheArgumentsText() {
        (MinecraftClient client, _) = Client();
        SignableCommand<ClientSuggestionProvider> command = SignableCommand<ClientSuggestionProvider>.Of(client.Commands.Parse("say  two  spaces ", client.SuggestionsProvider));
        Assert.That(command.Arguments, Is.EqualTo(new[] { ("message", " two  spaces ") }));
    }

    [Test]
    public void APartlyFilteredMessageHashesItsFilteredRuns() {
        System.Collections.BitArray mask = new(8);
        mask[1] = mask[2] = mask[5] = true;
        TextComponent filtered = ChatListener.ApplyWithFormatting(ChatFilterMask.PartiallyFiltered(mask), "abcdefg")!;
        Assert.Multiple(() => {
            Assert.That(TextFlattener.Plain(filtered), Is.EqualTo("a##de#g"));
            Assert.That(filtered.Children.Select(c => c.Color), Is.EqualTo(new TextColor?[] { null, TextColor.DarkGray, null, TextColor.DarkGray, null }));
        });
    }
}
