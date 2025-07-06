using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record CustomModelDataComponent(CustomModelData Value) : IDataComponent<CustomModelData> {
    public Identifier Identifier => "minecraft:custom_model_data";
    public static CustomModelDataComponent Default => new(new CustomModelData([], [], [], []));
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WritePrefixedArray(Value.Floats, (f, w) => w.WriteFloat(f))
            .WritePrefixedArray(Value.Flags, (b, w) => w.WriteBoolean(b))
            .WritePrefixedArray(Value.Strings, (s, w) => w.WriteString(s))
            .WritePrefixedArray(Value.Colors, (i, w) => w.WriteInteger(i));
    }

    public IDataComponent ReadData(DataReader reader, MinecraftRegistry registry) {
        CustomModelData customModelData = new(
            reader.ReadPrefixedArray(r => r.ReadFloat()),
            reader.ReadPrefixedArray(r => r.ReadBoolean()),
            reader.ReadPrefixedArray(r => r.ReadString()),
            reader.ReadPrefixedArray(r => r.ReadInteger())
        );
        return new CustomModelDataComponent(customModelData);
    }
}
