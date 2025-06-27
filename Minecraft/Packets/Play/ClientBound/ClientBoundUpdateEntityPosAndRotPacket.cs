using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundUpdateEntityPosAndRotPacket : ClientBoundPacket {
    public required int EntityId;
    public required FVec3 Delta;
    public required Angle Yaw;
    public required Angle Pitch;
    public required bool OnGround;

    protected override byte[] GetData() {
        SVec3 deltaPos = new(
            (short)(Delta.X*4096), 
            (short)(Delta.Y*4096), 
            (short)(Delta.Z*4096));
        
        return new DataWriter()
            .WriteVarInt(EntityId)
            .WriteVec3(deltaPos)
            .WriteAngle(Yaw)
            .WriteAngle(Pitch)
            .WriteBoolean(OnGround)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = r => new ClientBoundUpdateEntityPosAndRotPacket {
        EntityId = r.ReadVarInt(),
        Delta = new FVec3(
            (float)r.ReadShort() / 4096, 
            (float)r.ReadShort() / 4096, 
            (float)r.ReadShort() / 4096),
        Yaw = r.ReadAngle(),
        Pitch = r.ReadAngle(),
        OnGround = r.ReadBoolean()
    };
}
