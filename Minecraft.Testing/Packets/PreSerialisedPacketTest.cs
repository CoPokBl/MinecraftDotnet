using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;

namespace Minecraft.Testing.Packets;

/// <summary>
/// A pre-serialised packet has to be indistinguishable on the wire from the one it wraps, whatever
/// connection it is handed to. The point of it is that a broadcast serialises once; the risk is that
/// it hands a frame to a connection the frame was never built for.
/// </summary>
public class PreSerialisedPacketTest {
    private static ClientBoundSystemChatMessagePacket Message() {
        return new ClientBoundSystemChatMessagePacket { Content = "hello", ActionBar = false };
    }

    [Test]
    public void TheFrameIsTheSameBytesTheSourceWouldHaveWritten() {
        ClientBoundSystemChatMessagePacket source = Message();
        PreSerialisedPacket wrapped = new(source, ConnectionState.Play);

        Assert.That(wrapped.Serialise(ConnectionState.Play),
            Is.EqualTo(source.Serialise(ConnectionState.Play)));
    }

    [Test]
    public void TheSameFrameIsHandedOutEveryTime() {
        PreSerialisedPacket wrapped = new(Message(), ConnectionState.Play);

        Assert.That(wrapped.Serialise(ConnectionState.Play),
            Is.SameAs(wrapped.Serialise(ConnectionState.Play)));
    }

    /// <summary>
    /// A frame is only valid for the compression threshold it was built at, and a connection that
    /// negotiated a different one is not a case the wrapper may get wrong.
    /// </summary>
    [Test]
    public void ADifferentCompressionThresholdReSerialises() {
        ClientBoundSystemChatMessagePacket source = Message();
        PreSerialisedPacket wrapped = new(source, ConnectionState.Play);

        byte[] compressed = wrapped.Serialise(ConnectionState.Play, 1);
        Assert.That(compressed, Is.EqualTo(source.Serialise(ConnectionState.Play, 1)));
        Assert.That(compressed, Is.Not.EqualTo(wrapped.Serialise(ConnectionState.Play)));
    }

    [Test]
    public void ItStillAnswersAsThePacketItWraps() {
        ClientBoundSystemChatMessagePacket source = Message();
        PreSerialisedPacket wrapped = new(source, ConnectionState.Play);

        Assert.That(wrapped.Identifier, Is.EqualTo(source.Identifier));
        Assert.That(wrapped.Source, Is.SameAs(source));
    }
}
