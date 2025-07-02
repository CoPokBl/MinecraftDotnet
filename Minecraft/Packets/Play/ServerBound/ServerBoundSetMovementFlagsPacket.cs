namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundSetMovementFlagsPacket : ServerBoundPacket {
    public required Flags SetFlags;
    
    [Flags]
    public enum Flags {
        OnGround = 0x01,
        AgainstWall = 0x02,
        
        None = 0x00,
        All = OnGround | AgainstWall
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteUnsignedByte((byte)SetFlags)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundSetMovementFlagsPacket {
        SetFlags = (Flags)r.Read()
    };
}
