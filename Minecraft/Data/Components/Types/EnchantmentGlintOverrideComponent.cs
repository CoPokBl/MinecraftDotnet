using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record EnchantmentGlintOverrideComponent(bool Value) : IDataComponent<bool> {
    public Identifier Identifier => "minecraft:enchantment_glint_override";
    public static EnchantmentGlintOverrideComponent Default => new(false);
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteBoolean(Value);
    }

    public IDataComponent ReadData(DataReader reader, MinecraftRegistry registry) {
        return new EnchantmentGlintOverrideComponent(reader.ReadBoolean());
    }
}
