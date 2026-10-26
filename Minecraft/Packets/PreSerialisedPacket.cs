using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Packets;

/// <summary>
/// A packet that turns itself into bytes once and hands the same bytes to every recipient after that,
/// so a broadcast to a hundred connections is one serialisation and a hundred socket writes.
/// </summary>
/// <remarks>
/// For a message going to many connections at once: an entity's movement to everyone tracking it, a
/// tab list update, a chat line. It is <b>not</b> a general wrapper to put in front of every send,
/// because a listener on the send path sees this type rather than the packet inside it. Where that
/// matters, <see cref="Source"/> is the way back.
/// <p/>
/// A frame is only valid for the <see cref="ConnectionState"/> and compression threshold it was built
/// at, so this carries the packet it came from and re-serialises through it for a connection whose
/// settings differ. That is what makes it safe to hand to anyone: it is an optimisation for the
/// expected case rather than a promise about who is on the other end.
/// <p/>
/// Built on the first send rather than in the constructor, so wrapping a packet that ends up going
/// nowhere costs nothing, and so a packet that cannot be serialised for a connection's state fails
/// where it would have anyway.
/// <p/>
/// Deciding what is worth pre-serialising, and for how long a frame stays valid, is not this type's
/// business. It expires nothing; whoever builds one owns both questions.
/// <p/>
/// <see cref="Serialise"/> hands out the frame by reference rather than copying it, since avoiding the
/// copy is the point. <b>The caller must not write to it.</b>
/// </remarks>
public sealed class PreSerialisedPacket(
    MinecraftPacket source,
    ConnectionState state,
    int compressionThreshold = -1,
    MinecraftRegistry? registry = null) : MinecraftPacket {

    private byte[]? _frame;

    /// <summary>The packet this was built from, so a listener can still tell what it is.</summary>
    public MinecraftPacket Source => source;

    public override Identifier Identifier => source.Identifier;

    public override byte[] Serialise(ConnectionState connectionState, int threshold = -1,
        MinecraftRegistry? reg = null) {

        if (connectionState != state || threshold != compressionThreshold) {
            return source.Serialise(connectionState, threshold, reg);
        }

        // Two senders racing here both build a frame and one of them keeps it, which costs a
        // serialisation and cannot produce a wrong one.
        return _frame ??= source.Serialise(state, compressionThreshold, reg ?? registry);
    }
}
