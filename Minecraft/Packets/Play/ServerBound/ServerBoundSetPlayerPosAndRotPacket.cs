using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundSetPlayerPosAndRotPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:move_player_pos_rot";
    
    public required MovePlayerFlags Flags;
    public required float Pitch;
    public required float Yaw;
    public required Vec3 Position;

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVec3(Position)
            .WriteFloat(Yaw)
            .WriteFloat(Pitch)
            .WriteByte((int)Flags);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundSetPlayerPosAndRotPacket {
        Position = r.ReadVec3(),
        Yaw = r.ReadFloat(),
        Pitch = r.ReadFloat(),
        Flags = (MovePlayerFlags)r.Read()
    };
}
