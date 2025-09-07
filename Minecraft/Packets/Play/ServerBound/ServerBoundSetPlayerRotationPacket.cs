using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundSetPlayerRotationPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:move_player_rot";
    
    public required float Pitch { get; init; }
    public required float Yaw { get; init; }
    public required MovePlayerFlags Flags { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteFloat(Yaw)
            .WriteFloat(Pitch)
            .WriteByte((byte)Flags);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundSetPlayerRotationPacket {
        Yaw = r.ReadFloat(),
        Pitch = r.ReadFloat(),
        Flags = (MovePlayerFlags)r.ReadByte()
    };
}
