using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundUpdateEntityPositionPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:move_entity_pos";
    
    public required int EntityId { get; init; }
    public required Vec3<float> Delta { get; init; }
    public required bool OnGround { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        Vec3<short> deltaPos = new(
            (short)(Delta.X*4096), 
            (short)(Delta.Y*4096), 
            (short)(Delta.Z*4096));
        
        return w
            .WriteVarInt(EntityId)
            .WriteVec3(deltaPos)
            .WriteBoolean(OnGround);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundUpdateEntityPositionPacket {
        EntityId = r.ReadVarInt(),
        Delta = new Vec3<float>(
            (float)r.ReadShort() / 4096, 
            (float)r.ReadShort() / 4096, 
            (float)r.ReadShort() / 4096),
        OnGround = r.ReadBoolean()
    };
}
