using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundSetPlayerPosAndRotPacket : ServerBoundPacket {
    public required MovePlayerFlags Flags;
    public required float Pitch;
    public required float Yaw;
    public required Vec3 Position;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVec3(Position)
            .WriteFloat(Yaw)
            .WriteFloat(Pitch)
            .WriteByte((int)Flags)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = r => new ServerBoundSetPlayerPosAndRotPacket {
        Position = r.ReadVec3(),
        Yaw = r.ReadFloat(),
        Pitch = r.ReadFloat(),
        Flags = (MovePlayerFlags)r.Read()
    };
}
