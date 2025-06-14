namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundSetMovementFlagsPacket(ServerBoundSetMovementFlagsPacket.Flags flags) : MinecraftPacket {
    public Flags SetFlags = flags;

    public ServerBoundSetMovementFlagsPacket() : this(Flags.None) { }
    
    [Flags]
    public enum Flags {
        OnGround = 0x01,
        AgainstWall = 0x02,
        
        None = 0x00,
        All = OnGround | AgainstWall
    }

    public override int GetPacketId() {
        return 0x1F;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteUnsignedByte((byte)SetFlags)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        SetFlags = (Flags)r.Read();
        return this;
    }
}