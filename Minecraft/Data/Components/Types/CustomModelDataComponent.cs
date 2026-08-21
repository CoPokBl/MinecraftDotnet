using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Components.Types;

public record CustomModelDataComponent() : IDataComponent<CustomModelData> {
    public override Identifier Identifier => "minecraft:custom_model_data";

    /// <summary>
    /// Four lists rather than the four length prefixed arrays the wire form is, each left off when
    /// it is empty.
    /// </summary>
    public override NbtCodec<CustomModelData>? Codec => Persistent;
    private static readonly NbtCodec<CustomModelData> Persistent = new(
        (val, _) => new CompoundBuilder()
            .ListOrOmit("floats", val.Floats, f => new FloatTag(f))
            .ListOrOmit("flags", val.Flags, flag => new BooleanTag(flag))
            .ListOrOmit("strings", val.Strings, text => new StringTag(text))
            .ListOrOmit("colors", val.Colors, colour => new IntegerTag(colour))
            .Build(),
        (tag, _) => {
            NbtNode node = NbtNode.Of(tag, "minecraft:custom_model_data");
            CustomModelData data = new(
                node.List("floats", value => value.GetFloat()),
                node.List("flags", value => value.GetBoolean()),
                node.List("strings", value => value.GetString()),
                node.List("colors", value => value.GetInteger()));
            node.AssertRead();
            return data;
        });
    
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

    public override bool ValuesEqual(CustomModelData val1, CustomModelData val2) {
        return val1.Equals(val2);
    }
}
