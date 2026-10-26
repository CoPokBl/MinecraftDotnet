using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Components.Types;

/// <summary>
/// Recipes a knowledge book unlocks. Vanilla has no network form for it, so the value travels as the
/// tag its datapack form would be.
/// </summary>
public record RecipesComponent() : IDataComponent<Identifier[]> {
    public override Identifier Identifier => "minecraft:recipes";

    public override NbtCodec<Identifier[]>? Codec => Persistent;
    private static readonly NbtCodec<Identifier[]> Persistent = NbtCodecs.Ids();

    public override DataWriter WriteData(Identifier[] val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteNbt(new ListTag<StringTag>(val.Select(r => new StringTag(r.ToString())).ToArray()));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.ReadNbt() is ListTag list
            ? list.Tags.ToArray().Select(t => (Identifier)t.GetString()).ToArray()
            : [];
    }

    public override bool ValuesEqual(Identifier[] val1, Identifier[] val2) {
        return val1.SequenceEqual(val2);
    }
}
