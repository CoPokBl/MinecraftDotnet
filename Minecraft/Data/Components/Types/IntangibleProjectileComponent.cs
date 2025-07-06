using Minecraft.Registry;
using Minecraft.Schemas;
using NBT.Tags;

namespace Minecraft.Data.Components.Types;

public record IntangibleProjectileComponent : IDataComponent<None> {
    public Identifier Identifier => "minecraft:intangible_projectile";
    public static IntangibleProjectileComponent Default => new();
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteNbt(new EmptyTag());
    }

    public IDataComponent ReadData(DataReader reader, MinecraftRegistry registry) {
        reader.ReadNbt();
        return this;
    }

    public None Value => None.Value;
}
