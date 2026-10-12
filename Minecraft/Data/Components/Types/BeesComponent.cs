using Minecraft.Data.Components.Codecs;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Components.Types;

/// <summary>The bees inside a hive item.</summary>
public record BeesComponent() : IDataComponent<BeesComponent.Occupant[]> {
    public override Identifier Identifier => "minecraft:bees";

    public override NbtCodec<Occupant[]>? Codec => Persistent;
    private static readonly NbtCodec<Occupant[]> Persistent = new(
        (val, registry) => new ListTag(val
            .Select(bee => (INbtTag)new CompoundBuilder()
                .Tag("entity_data", DataComponent.EntityData.ToNbt(bee.EntityData, registry))
                .Int("ticks_in_hive", bee.TicksInHive)
                .Int("min_ticks_in_hive", bee.MinTicksInHive)
                .Build())
            .ToArray()),
        (tag, registry) => tag.AsList()
            .Select(entry => {
                NbtNode node = NbtNode.Of(entry, "minecraft:bees");
                Occupant bee = new(
                    (EntityData)DataComponent.EntityData.FromNbt(node.Require("entity_data"), registry),
                    node.Int("ticks_in_hive"),
                    node.Int("min_ticks_in_hive"));
                node.AssertRead();
                return bee;
            })
            .ToArray());

    public override DataWriter WriteData(Occupant[] val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WritePrefixedArray(val, (occupant, w) => w
            .Write(occupant.EntityData, registry)
            .WriteVarInt(occupant.TicksInHive)
            .WriteVarInt(occupant.MinTicksInHive));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.ReadPrefixedArray(r =>
            new Occupant(r.Read<EntityData>(registry), r.ReadVarInt(), r.ReadVarInt()));
    }

    public override bool ValuesEqual(Occupant[] val1, Occupant[] val2) {
        return val1.SequenceEqual(val2);
    }

    /// <param name="MinTicksInHive">
    /// How long the bee has to stay before it may leave. Six hundred normally and two thousand four
    /// hundred while it is carrying nectar.
    /// </param>
    public record Occupant(EntityData EntityData, int TicksInHive, int MinTicksInHive);
}
