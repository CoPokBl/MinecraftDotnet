using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundUpdateEntityPosAndRotPacket(int entityId, FVec3 delta, Angle yaw, Angle pitch, bool onGround) : MinecraftPacket {
    public int EntityId = entityId;
    public FVec3 Delta = delta;
    public Angle Yaw = yaw;
    public Angle Pitch = pitch;
    public bool OnGround = onGround;
    
    public ClientBoundUpdateEntityPosAndRotPacket() : this(0, FVec3.Zero, Angle.Zero, Angle.Zero, false) { }

    public override int GetPacketId() {
        return 0x2F;
    }

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

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        EntityId = r.ReadVarInt();
        SVec3 eDelta = r.ReadSVec3();
        Delta = new FVec3((float)eDelta.X / 4096, (float)eDelta.Y / 4096, (float)eDelta.Z / 4096);
        OnGround = r.ReadBoolean();
        return this;
    }
}