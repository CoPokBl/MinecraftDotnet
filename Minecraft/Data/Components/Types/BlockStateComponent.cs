using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Components.Types;

/// <summary>
/// Block state properties a block item forces onto what it places, by property name and value.
/// A property the placed block does not have is ignored rather than an error.
/// </summary>
public record BlockStateComponent() : IDataComponent<Dictionary<string, string>> {
    public override Identifier Identifier => "minecraft:block_state";

    /// <summary>
    /// Every value is a string, whatever the property's type is: <c>{"honey_level": "0"}</c> and not
    /// a number, because a block property is named by its string form everywhere it is written.
    /// </summary>
    public override NbtCodec<Dictionary<string, string>>? Codec => Persistent;
    private static readonly NbtCodec<Dictionary<string, string>> Persistent = new(
        (val, _) => new CompoundTag(val
            .Select(property => (property.Key, (INbtTag)new StringTag(property.Value)))
            .ToArray()),
        (tag, _) => tag.GetCompound().Children
            .ToDictionary(property => property.key, property => property.child.GetString()));

    public override DataWriter WriteData(Dictionary<string, string> val, DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WriteVarInt(val.Count)
            .WriteArray(val, (property, w) => w.WriteString(property.Key).WriteString(property.Value));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader
            .ReadPrefixedArray(r => new KeyValuePair<string, string>(r.ReadString(), r.ReadString()))
            .ToDictionary();
    }

    public override bool ValuesEqual(Dictionary<string, string> val1, Dictionary<string, string> val2) {
        return val1.Count == val2.Count &&
               val1.All(property => val2.TryGetValue(property.Key, out string? other) && other == property.Value);
    }
}
