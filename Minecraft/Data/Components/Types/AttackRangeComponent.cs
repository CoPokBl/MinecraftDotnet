using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

/// <summary>
/// How far the item reaches when it attacks, vanilla's <c>AttackRange</c>. Creative mode has its own
/// pair of bounds, and a mob's are the survival pair scaled by <see cref="Data.MobFactor"/>.
/// </summary>
public record AttackRangeComponent() : IDataComponent<AttackRangeComponent.Data> {
    public override Identifier Identifier => "minecraft:attack_range";

    public override NbtCodec<Data>? Codec => Persistent;
    private static readonly NbtCodec<Data> Persistent = new(
        (val, _) => new CompoundBuilder()
            .Float("min_reach", val.MinReach, 0f)
            .Float("max_reach", val.MaxReach, 3f)
            .Float("min_creative_reach", val.MinCreativeReach, 0f)
            .Float("max_creative_reach", val.MaxCreativeReach, 5f)
            .Float("hitbox_margin", val.HitboxMargin, 0.3f)
            .Float("mob_factor", val.MobFactor, 1f)
            .Build(),
        (tag, _) => {
            NbtNode node = NbtNode.Of(tag, "minecraft:attack_range");
            Data data = new(
                node.Float("min_reach", 0f),
                node.Float("max_reach", 3f),
                node.Float("min_creative_reach", 0f),
                node.Float("max_creative_reach", 5f),
                node.Float("hitbox_margin", 0.3f),
                node.Float("mob_factor", 1f));
            node.AssertRead();
            return data;
        });

    public override DataWriter WriteData(Data val, DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WriteFloat(val.MinReach)
            .WriteFloat(val.MaxReach)
            .WriteFloat(val.MinCreativeReach)
            .WriteFloat(val.MaxCreativeReach)
            .WriteFloat(val.HitboxMargin)
            .WriteFloat(val.MobFactor);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return new Data(reader.ReadFloat(), reader.ReadFloat(), reader.ReadFloat(), reader.ReadFloat(),
            reader.ReadFloat(), reader.ReadFloat());
    }

    public override bool ValuesEqual(Data val1, Data val2) {
        return val1 == val2;
    }

    /// <param name="HitboxMargin">Slack added to both ends before a hit is called out of range.</param>
    public record Data(
        float MinReach = 0f,
        float MaxReach = 3f,
        float MinCreativeReach = 0f,
        float MaxCreativeReach = 5f,
        float HitboxMargin = 0.3f,
        float MobFactor = 1f);
}
