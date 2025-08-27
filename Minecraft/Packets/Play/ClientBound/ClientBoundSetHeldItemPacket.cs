using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetHeldItemPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:set_held_slot";
    
    public required int Slot { get; init; }
    
    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(Slot);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSetHeldItemPacket {
        Slot = r.ReadVarInt()
    };
}
