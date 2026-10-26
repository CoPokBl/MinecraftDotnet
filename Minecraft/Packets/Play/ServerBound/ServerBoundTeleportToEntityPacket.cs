using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

/// <summary>Sent when a spectator picks a player from the spectator menu to teleport to.</summary>
public class ServerBoundTeleportToEntityPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:teleport_to_entity";

    public required Guid TargetPlayer { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w.WriteUuid(TargetPlayer);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundTeleportToEntityPacket {
        TargetPlayer = r.ReadUuid()
    };
}
