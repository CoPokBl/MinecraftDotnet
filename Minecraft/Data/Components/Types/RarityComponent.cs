using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace Minecraft.Data.Components.Types;

public record RarityComponent(ItemRarity Value) : IDataComponent<ItemRarity> {
    public static RarityComponent Default => new(ItemRarity.Common);
    public Identifier Identifier => "minecraft:rarity";

    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt((int)Value);
    }

    public IDataComponent ReadData(DataReader reader, MinecraftRegistry registry) {
        return new RarityComponent((ItemRarity)reader.ReadVarInt());
    }
}
