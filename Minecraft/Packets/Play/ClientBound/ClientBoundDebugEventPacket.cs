using Minecraft.Data.DebugSubscriptions;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>
/// Reports a one-off occurrence on a debug channel, such as a neighbour update firing, rather
/// than the current value of something.
/// </summary>
public class ClientBoundDebugEventPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:debug/event";

    public required IDebugSubscription Subscription { get; init; }

    /// <summary>
    /// The event's payload, in the shape the subscription defines. Kept raw because each channel
    /// carries a different structure, none of which the client uses outside a development build.
    /// </summary>
    public required byte[] Value { get; init; }

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry reg) {
        return w
            .WriteVarInt(reg.DebugSubscriptions.GetProtocolId(Subscription))
            .Write(Value);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ClientBoundDebugEventPacket {
        Subscription = reg.DebugSubscriptions[r.ReadVarInt()],
        Value = r.ReadRemaining()
    };
}
