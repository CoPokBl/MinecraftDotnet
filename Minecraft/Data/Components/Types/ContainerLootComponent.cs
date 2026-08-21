using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Components.Types;

/// <summary>
/// A loot table a container item fills itself from the first time it is opened. Vanilla has no
/// network form for it, so the value travels as the tag its datapack form would be.
/// </summary>
public record ContainerLootComponent() : IDataComponent<ContainerLootComponent.Data> {
    public override Identifier Identifier => "minecraft:container_loot";

    /// <summary>
    /// A zero seed is left off, as vanilla leaves it off, so a stack written here reads back as the
    /// same one a datapack would.
    /// </summary>
    public override NbtCodec<Data>? Codec => Persistent;
    private static readonly NbtCodec<Data> Persistent = new(
        (val, _) => new CompoundBuilder()
            .Id("loot_table", val.LootTable)
            .Long("seed", val.Seed, 0L)
            .Build(),
        (tag, _) => {
            NbtNode node = NbtNode.Of(tag, "minecraft:container_loot");
            Data data = new(node.Id("loot_table"), node.Long("seed", 0L));
            node.AssertRead();
            return data;
        });

    public override DataWriter WriteData(Data val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteNbt(new CompoundTag(
            ("loot_table", new StringTag(val.LootTable.ToString())),
            ("seed", new LongTag(val.Seed))));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        CompoundTag tag = (CompoundTag)reader.ReadNbt();
        return new Data(
            tag["loot_table"]!.GetString(),
            tag.Contains("seed") ? tag["seed"]!.GetLong() : 0L);
    }

    public override bool ValuesEqual(Data val1, Data val2) {
        return val1 == val2;
    }

    /// <param name="Seed">Zero means a fresh roll each time rather than a fixed one.</param>
    public record Data(Identifier LootTable, long Seed = 0L);
}
