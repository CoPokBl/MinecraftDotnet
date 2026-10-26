using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using NBT.Tags;

namespace Minecraft.Data.Components.Types;

public record ToolComponent() : IDataComponent<Tool> {
    public override Identifier Identifier => "minecraft:tool";

    public override NbtCodec<Tool>? Codec => Persistent;
    private static readonly NbtCodec<Tool> Persistent = new(
        (val, registry) => new CompoundBuilder()
            .List("rules", val.Rules, rule => new CompoundBuilder()
                .IdSet("blocks", rule.Blocks, registry.Blocks)
                .Maybe("speed", rule.Speed, speed => new FloatTag(speed))
                .Maybe("correct_for_drops", rule.CorrectDropForBlocks, correct => new BooleanTag(correct))
                .Build())
            .Float("default_mining_speed", val.DefaultMiningSpeed, 1f)
            .Int("damage_per_block", val.DamagePerBlock, 1)
            .Bool("can_destroy_blocks_in_creative", val.CanMineInCreative, true)
            .Build(),
        (tag, registry) => {
            NbtNode node = NbtNode.Of(tag, "minecraft:tool");

            ToolRule[] rules = node.Objects("rules", rule => {
                ToolRule read = new(
                    rule.IdSet("blocks", registry.Blocks),
                    rule.Has("speed") ? rule.Float("speed") : null,
                    rule.Has("correct_for_drops") ? rule.Bool("correct_for_drops") : null);
                rule.AssertRead();
                return read;
            });

            Tool tool = new(rules,
                node.Float("default_mining_speed", 1f),
                node.Int("damage_per_block", 1),
                node.Bool("can_destroy_blocks_in_creative", true));

            node.AssertRead();
            return tool;
        });
    
    public override DataWriter WriteData(Tool val, DataWriter writer, MinecraftRegistry registry) {
        return writer.Write(val, registry);
    }

    public override Tool ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.Read<Tool>(registry);
    }

    public override bool ValuesEqual(Tool val1, Tool val2) {
        return val1.Equals(val2);
    }
}
