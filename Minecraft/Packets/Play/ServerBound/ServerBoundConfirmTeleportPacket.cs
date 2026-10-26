using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ServerBound;

/// <summary>The client applied a teleport, and is where this says, which is its move for the tick.</summary>
public class ServerBoundConfirmTeleportPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:accept_teleportation";
    
    public required int TeleportId { get; init; }
    public required Vec3<double> Position { get; init; }
    public required float Yaw { get; init; }
    public required float Pitch { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w.WriteVarInt(TeleportId)
            .WriteVec3(Position)
            .WriteFloat(Yaw)
            .WriteFloat(Pitch);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundConfirmTeleportPacket {
        TeleportId = r.ReadVarInt(),
        Position = r.ReadVec3(),
        Yaw = r.ReadFloat(),
        Pitch = r.ReadFloat()
    };
}
