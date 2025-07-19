using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace Minecraft.Data.Components.Types;

public record RarityComponent(int ProtocolId) : IDataComponent<ItemRarity> {
    public override Identifier Identifier => "minecraft:rarity";

    public override DataWriter WriteData(ItemRarity val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt((int)val);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return (ItemRarity)reader.ReadVarInt();
    }
}
