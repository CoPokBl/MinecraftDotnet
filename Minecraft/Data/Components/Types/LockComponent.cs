using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;

namespace Minecraft.Data.Components.Types;

/// <summary>
/// The item predicate a container item demands be held before it opens. Vanilla has no network form
/// for it, so the value travels as the tag its datapack form would be.
/// </summary>
public record LockComponent() : IDataComponent<INbtTag> {
    public override Identifier Identifier => "minecraft:lock";

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
