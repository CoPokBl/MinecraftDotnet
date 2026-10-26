using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;

namespace Minecraft.Data.Components.Types;

public record CustomDataComponent() : IDataComponent<INbtTag> {
    public override Identifier Identifier => "minecraft:custom_data";

    public override NbtCodec<INbtTag>? Codec => Persistent;
    private static readonly NbtCodec<INbtTag> Persistent = NbtCodecs.Raw();
    
    public override DataWriter WriteData(INbtTag val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteNbt(val);
    }

    public override INbtTag ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.ReadNbt();
    }

    public override bool ValuesEqual(INbtTag val1, INbtTag val2) {
        // Slow but simple way to compare NBT tags
        return val1.ToJsonString() == val2.ToJsonString();
    }
}
