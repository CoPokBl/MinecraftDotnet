using ClientLib.Brigadier;
using ClientLib.Commands.Arguments;
using Minecraft.Data.ArgumentParsers;
using Wire = Minecraft.Data.ArgumentParsers.Types;

namespace ClientLib.Commands;

/// <summary>
/// The <c>ArgumentTypeInfo.Template.instantiate</c> of every type in vanilla's
/// <c>ArgumentTypeInfos.bootstrap</c>, from the template the commands packet decoded.
/// </summary>
public static class ArgumentTypeInfos {
    public static IArgumentType Instantiate(IArgumentParser template, CommandBuildContext context) {
        return template switch {
            Wire.BooleanArgumentType => BoolArgumentType.Bool(),
            Wire.FloatArgumentType f => new FloatArgumentType(f.Min ?? -float.MaxValue, f.Max ?? float.MaxValue),
            Wire.DoubleArgumentType d => new DoubleArgumentType(d.Min ?? -double.MaxValue, d.Max ?? double.MaxValue),
            Wire.IntegerArgumentType i => new IntegerArgumentType(i.Min ?? int.MinValue, i.Max ?? int.MaxValue),
            Wire.LongArgumentType l => new LongArgumentType(l.Min ?? long.MinValue, l.Max ?? long.MaxValue),
            Wire.StringArgumentType s => s.ValueBehaviour switch {
                Wire.StringArgumentType.Behaviour.SingleWord => StringArgumentType.Word(),
                Wire.StringArgumentType.Behaviour.QuotablePhrase => StringArgumentType.String(),
                _ => StringArgumentType.GreedyString()
            },
            Wire.EntityArgumentType e => new EntityArgument(e.Single, e.PlayersOnly),
            Wire.GameProfileArgumentType => new GameProfileArgument(),
            Wire.BlockPosArgumentType => new BlockPosArgument(),
            Wire.ChunkPosArgumentType => new ColumnPosArgument(),
            Wire.Vec3ArgumentType => new Vec3Argument(true),
            Wire.Vec2ArgumentType => new Vec2Argument(true),
            Wire.BlockStateArgumentType => new BlockStateArgument(context),
            Wire.BlockPredicateArgumentType => new BlockPredicateArgument(context),
            Wire.ItemStackArgumentType => new ItemArgument(context),
            Wire.ItemPredicateArgumentType => new ItemPredicateArgument(context),
            Wire.TeamColorArgumentType => new TeamColorArgument(),
            Wire.HexColourArgumentType => new HexColorArgument(),
            Wire.ComponentArgumentType => new ComponentArgument(context),
            Wire.StyleArgumentType => new StyleArgument(context),
            Wire.MessageArgumentType => new MessageArgument(),
            Wire.CompoundTagArgumentType => new CompoundTagArgument(),
            Wire.NbtTagArgumentType => new NbtTagArgument(),
            Wire.NbtPathArgumentType => new NbtPathArgument(),
            Wire.ObjectiveArgumentType => new ObjectiveArgument(),
            Wire.ObjectiveCriteriaArgumentType => new ObjectiveCriteriaArgument(),
            Wire.OperationArgumentType => new OperationArgument(),
            Wire.ParticleArgumentType => new ParticleArgument(context),
            Wire.AngleArgumentType => new AngleArgument(),
            Wire.RotationArgumentType => new RotationArgument(),
            Wire.ScoreboardSlotArgumentType => new ScoreboardSlotArgument(),
            Wire.ScoreHolderArgumentType h => new ScoreHolderArgument(h.Multiple),
            Wire.SwizzleArgumentType => new SwizzleArgument(),
            Wire.TeamArgumentType => new TeamArgument(),
            Wire.ItemSlotArgumentType => new SlotArgument(),
            Wire.ItemSlotsArgumentType => new SlotsArgument(),
            Wire.ResourceLocationArgumentType => new IdentifierArgument(),
            Wire.FunctionArgumentType => new FunctionArgument(),
            Wire.EntityAnchorArgumentType => new EntityAnchorArgument(),
            Wire.IntRangeArgumentType => new RangeArgument.Ints(),
            Wire.FloatRangeArgumentType => new RangeArgument.Floats(),
            Wire.DimensionArgumentType => new DimensionArgument(),
            Wire.GameModeArgumentType => new GameModeArgument(),
            Wire.TimeArgumentType t => new TimeArgument(t.Min),
            Wire.ResourceOrTagArgumentType r => new ResourceOrTagArgument(context, r.Registry),
            Wire.ResourceOrTagKeyArgumentType r => new ResourceOrTagKeyArgument(r.Registry),
            Wire.ResourceArgumentType r => new ResourceArgument(context, r.Registry),
            Wire.ResourceKeyArgumentType r => new ResourceKeyArgument(r.Registry),
            Wire.ResourceSelectorArgumentType r => new ResourceSelectorArgument(context, r.Registry),
            Wire.TemplateMirrorArgumentType => new TemplateMirrorArgument(),
            Wire.TemplateRotationArgumentType => new TemplateRotationArgument(),
            Wire.HeightmapArgumentType => new HeightmapTypeArgument(),
            Wire.LootTableArgumentType => ResourceOrIdArgument.LootTable(context),
            Wire.LootPredicateArgumentType => ResourceOrIdArgument.LootPredicate(context),
            Wire.LootModifierArgumentType => ResourceOrIdArgument.LootModifier(context),
            Wire.ContextFloatProviderArgumentType => ResourceOrIdArgument.FloatProvider(context),
            Wire.ContextIntProviderArgumentType => ResourceOrIdArgument.IntProvider(context),
            Wire.SlotSourceArgumentType => new SlotSourceArgument(context),
            Wire.DialogArgumentType => ResourceOrIdArgument.Dialog(context),
            Wire.FeatureArgumentType => ResourceOrIdArgument.Feature(context),
            Wire.SwingAnimationArgumentType => new SwingAnimationArgument(),
            Wire.UuidArgumentType => new UuidArgument(),
            _ => throw new NotSupportedException($"No client argument type for {template.Identifier}")
        };
    }
}
