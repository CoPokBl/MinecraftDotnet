using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetHeldItemPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:set_held_slot";
    
    public required int Slot;
    
    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(Slot)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSetHeldItemPacket {
        Slot = r.ReadVarInt()
    };
}
