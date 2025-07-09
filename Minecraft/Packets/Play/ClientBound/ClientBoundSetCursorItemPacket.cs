using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetCursorItemPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:set_cursor_item";

    public required ItemStack Item;
    
    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry reg) {
        return w.Write(wr => Item.Write(wr, reg));
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ClientBoundSetCursorItemPacket {
        Item = ItemStack.Read(r, reg)
    };
}
