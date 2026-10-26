using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Components.Types;

/// <summary>
/// Which property the debug stick is currently on for each block it has been used on, keyed by block
/// id. Vanilla has no network form for it, so the value travels as the tag its datapack form would be.
/// </summary>
public record DebugStickStateComponent() : IDataComponent<Dictionary<Identifier, string>> {
    public override Identifier Identifier => "minecraft:debug_stick_state";

    public override NbtCodec<Dictionary<Identifier, string>>? Codec => Persistent;
    private static readonly NbtCodec<Dictionary<Identifier, string>> Persistent = new(
        (val, _) => new CompoundTag(val
            .Select(state => (state.Key.ToString(), (INbtTag)new StringTag(state.Value)))
            .ToArray()),
        (tag, _) => tag.GetCompound().Children
            .ToDictionary(state => (Identifier)state.key, state => state.child.GetString()));

    public override DataWriter WriteData(Dictionary<Identifier, string> val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteNbt(new CompoundTag(val
            .Select(s => (s.Key.ToString(), (INbtTag)new StringTag(s.Value)))
            .ToArray()));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        CompoundTag tag = (CompoundTag)reader.ReadNbt();
        return tag.Children.ToDictionary(s => (Identifier)s.key, s => s.child.GetString());
    }

    public override bool ValuesEqual(Dictionary<Identifier, string> val1, Dictionary<Identifier, string> val2) {
        return val1.Count == val2.Count &&
               val1.All(s => val2.TryGetValue(s.Key, out string? other) && other == s.Value);
    }
}
