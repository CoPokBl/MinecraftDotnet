using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Text;
using NBT;

namespace Minecraft.Data.Components.Types;

public record LoreComponent(int ProtocolId) : IDataComponent<TextComponent[]> {
    public override Identifier Identifier => "minecraft:lore";
    
    public override DataWriter WriteData(TextComponent[] val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WritePrefixedArray(val, (t, w) => w.WriteNbt(t));
    }

    public override TextComponent[] ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.ReadPrefixedArray(r => r.ReadText());
    }

    public override bool ValuesEqual(TextComponent[] val1, TextComponent[] val2) {
        if (val1.Length != val2.Length) return false;
        for (int i = 0; i < val1.Length; i++) {
            if (val1[i].ToJsonString() != val2[i].ToJsonString()) {
                return false;
            }
        }
        return true;
    }
}
