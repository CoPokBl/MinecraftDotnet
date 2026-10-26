using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>
/// Gives the client the path a minecart takes over the next few ticks so it can interpolate
/// along the rails rather than between two positions.
/// </summary>
public class ClientBoundMoveMinecartAlongTrackPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:move_minecart_along_track";

    public required int EntityId { get; init; }
    public required MinecartStep[] Steps { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(EntityId)
            .WritePrefixedArray(Steps, (step, writer) => step.Write(writer));
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundMoveMinecartAlongTrackPacket {
        EntityId = r.ReadVarInt(),
        Steps = r.ReadPrefixedArray(MinecartStep.Read)
    };
}
