using Minecraft.Data.Inventories;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Text;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundOpenScreenPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:open_screen";

    public required int WindowId { get; init; }
    public required IInventoryType Type { get; init; }
    public required TextComponent Title { get; init; }
    
    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry registry) {
        return w
            .WriteVarInt(WindowId)
            .WriteVarInt(Type.ProtocolId)
            .WriteNbt(Title);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (reader, registry) => new ClientBoundOpenScreenPacket {
        WindowId = reader.ReadVarInt(),
        Type = registry.InventoryTypes[reader.ReadVarInt()],
        Title = reader.ReadText()
    };
}
