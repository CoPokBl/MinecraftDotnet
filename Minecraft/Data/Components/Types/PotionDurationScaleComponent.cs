using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record PotionDurationScaleComponent() : IDataComponent<float> {
    public override Identifier Identifier => "minecraft:potion_duration_scale";

    public override NbtCodec<float>? Codec => Persistent;
    private static readonly NbtCodec<float> Persistent = NbtCodecs.Float();

    public override DataWriter WriteData(float val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteFloat(val);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.ReadFloat();
    }

    public override bool ValuesEqual(float val1, float val2) {
        return val1 == val2;
    }
}
