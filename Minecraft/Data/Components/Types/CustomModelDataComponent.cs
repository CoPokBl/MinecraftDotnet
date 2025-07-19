using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record CustomModelDataComponent(int ProtocolId) : IDataComponent<CustomModelData> {
    public override Identifier Identifier => "minecraft:custom_model_data";
    
    public override DataWriter WriteData(CustomModelData val, DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WritePrefixedArray(val.Floats, (f, w) => w.WriteFloat(f))
            .WritePrefixedArray(val.Flags, (b, w) => w.WriteBoolean(b))
            .WritePrefixedArray(val.Strings, (s, w) => w.WriteString(s))
            .WritePrefixedArray(val.Colors, (i, w) => w.WriteInteger(i));
    }

    public override CustomModelData ReadData(DataReader reader, MinecraftRegistry registry) {
        CustomModelData customModelData = new(
            reader.ReadPrefixedArray(r => r.ReadFloat()),
            reader.ReadPrefixedArray(r => r.ReadBoolean()),
            reader.ReadPrefixedArray(r => r.ReadString()),
            reader.ReadPrefixedArray(r => r.ReadInteger())
        );
        return customModelData;
    }
}
