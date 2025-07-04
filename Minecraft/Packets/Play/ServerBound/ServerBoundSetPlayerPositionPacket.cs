using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundSetPlayerPositionPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:move_player_pos";
    
    public required MovePlayerFlags Flags;
    public required Vec3 Position;

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVec3(Position)
            .WriteByte((int)Flags);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundSetPlayerPositionPacket {
        Position = r.ReadVec3(),
        Flags = (MovePlayerFlags)r.ReadByte()
    };
}
