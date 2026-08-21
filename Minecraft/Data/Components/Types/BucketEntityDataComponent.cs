using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;

namespace Minecraft.Data.Components.Types;

/// <summary>
/// The fish in a bucket. Unlike <see cref="EntityDataComponent"/> this is the tag alone, since the
/// bucket item already says what it is holding.
/// </summary>
public record BucketEntityDataComponent() : IDataComponent<INbtTag> {
    public override Identifier Identifier => "minecraft:bucket_entity_data";

    public override NbtCodec<INbtTag>? Codec => Persistent;
    private static readonly NbtCodec<INbtTag> Persistent = NbtCodecs.Raw();

    public override DataWriter WriteData(INbtTag val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteNbt(val);
    }

    public override INbtTag ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.ReadNbt();
    }

    public override bool ValuesEqual(INbtTag val1, INbtTag val2) {
        return val1.ToJsonString() == val2.ToJsonString();
    }
}
