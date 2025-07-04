using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundUpdateEntityPositionPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:move_entity_pos";
    
    public required int EntityId;
    public required FVec3 Delta;
    public required bool OnGround;

    protected override DataWriter WriteData(DataWriter w) {
        SVec3 deltaPos = new(
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
        Delta = new FVec3(
            (float)r.ReadShort() / 4096, 
            (float)r.ReadShort() / 4096, 
            (float)r.ReadShort() / 4096),
        OnGround = r.ReadBoolean()
    };
}
