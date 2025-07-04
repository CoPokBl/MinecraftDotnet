using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundSetPlayerRotationPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:move_player_rot";
    
    public required float Pitch;
    public required float Yaw;
    public required MovePlayerFlags Flags;

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteFloat(Pitch)
            .WriteFloat(Yaw)
            .WriteByte((byte)Flags);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundSetPlayerRotationPacket {
        Pitch = r.ReadFloat(),
        Yaw = r.ReadFloat(),
        Flags = (MovePlayerFlags)r.ReadByte()
    };
}
