using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Tags;

namespace Minecraft.Data.Components.Types;

/// <summary>How visible the wearer is to the listed mobs, as a mob head makes its own kind see less.</summary>
public record MobVisibilityComponent() : IDataComponent<MobVisibilityComponent.Data> {
    public override Identifier Identifier => "minecraft:mob_visibility";

    public override NbtCodec<Data>? Codec => Persistent;
    private static readonly NbtCodec<Data> Persistent = new(
        (val, registry) => new CompoundBuilder()
            .IdSet("targeting_entity_types", val.TargetingEntityTypes, registry.EntityTypes)
            .Float("visibility", val.Visibility)
            .Build(),
        (tag, registry) => {
            NbtNode node = NbtNode.Of(tag, "minecraft:mob_visibility");
            Data data = new(node.IdSet("targeting_entity_types", registry.EntityTypes), node.Float("visibility"));
            node.AssertRead();
            return data;
        });

    public override DataWriter WriteData(Data val, DataWriter writer, MinecraftRegistry registry) {
        return writer.Write(val.TargetingEntityTypes, registry).WriteFloat(val.Visibility);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return new Data(reader.Read<IdSet>(registry), reader.ReadFloat());
    }

    public override bool ValuesEqual(Data val1, Data val2) {
        return val1.TargetingEntityTypes.Equals(val2.TargetingEntityTypes) && val1.Visibility.Equals(val2.Visibility);
    }

    /// <param name="Visibility">The multiplier on the wearer's visibility, from 0 to 10.</param>
    public record Data(IdSet TargetingEntityTypes, float Visibility);
}
