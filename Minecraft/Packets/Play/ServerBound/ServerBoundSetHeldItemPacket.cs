using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundSetHeldItemPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:set_carried_item";
    
    public required short Slot;

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteUShort((ushort)Slot);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundSetHeldItemPacket {
        Slot = (short)r.ReadUShort()
    };
}
