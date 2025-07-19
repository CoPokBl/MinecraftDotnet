using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record EnchantmentGlintOverrideComponent(int ProtocolId) : IDataComponent<bool> {
    public override Identifier Identifier => "minecraft:enchantment_glint_override";
    
    public override DataWriter WriteData(bool val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteBoolean(val);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.ReadBoolean();
    }
}
