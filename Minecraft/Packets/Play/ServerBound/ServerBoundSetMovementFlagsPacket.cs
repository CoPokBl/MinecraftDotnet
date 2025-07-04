using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundSetMovementFlagsPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:move_player_status_only";
    
    public required Flags SetFlags;
    
    [Flags]
    public enum Flags {
        OnGround = 0x01,
        AgainstWall = 0x02,
        
        None = 0x00,
        All = OnGround | AgainstWall
    }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteUnsignedByte((byte)SetFlags);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundSetMovementFlagsPacket {
        SetFlags = (Flags)r.Read()
    };
}
