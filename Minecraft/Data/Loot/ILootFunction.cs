using Minecraft.Data.Components;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace Minecraft.Data.Loot;

/// <summary>
/// Vanilla's <c>LootItemFunction</c>. Every function upstream is a
/// <c>LootItemConditionalFunction</c>, so the condition lives on the base and a function whose
/// condition fails returns the stack untouched.
/// </summary>
public abstract record LootFunction(ILootCondition? Condition) {
    /// <summary><c>LootItemConditionalFunction.apply</c>: run unless the condition says no.</summary>
    public ItemStack Apply(ItemStack stack, LootContext context) {
        if (Condition != null && !Condition.Test(context)) {
            return stack;
        }

        return Run(stack, context);
    }

    protected abstract ItemStack Run(ItemStack stack, LootContext context);
}

/// <summary>
/// <c>SequenceFunction</c>: every function in order, each on what the last returned. A list where a
/// single modifier is expected is this with no condition, which is how a 26.3 table writes what used
/// to be a <c>functions</c> list.
/// </summary>
public sealed record SequenceFunction(ILootCondition? Condition, LootFunction[] Functions) : LootFunction(Condition) {
    protected override ItemStack Run(ItemStack stack, LootContext context) {
        foreach (LootFunction function in Functions) {
            stack = function.Apply(stack, context);
        }

        return stack;
    }
}

/// <summary><c>SetItemCountFunction</c>. <paramref name="Add"/> makes it relative to what is there.</summary>
public sealed record SetCountFunction(
    ILootCondition? Condition,
    IContextIntProvider Count,
    bool Add) : LootFunction(Condition) {

    protected override ItemStack Run(ItemStack stack, LootContext context) {
        int baseCount = Add ? stack.Count : 0;
        return stack.WithCount(baseCount + Count.GetInt(context));
    }
}

/// <summary>
/// <c>ApplyExplosionDecay</c>: each item of the stack survives with probability <c>1 / radius</c>.
/// With no explosion radius in the context this is a no-op, which is every use of it today.
/// </summary>
public sealed record ExplosionDecayFunction(ILootCondition? Condition) : LootFunction(Condition) {
    protected override ItemStack Run(ItemStack stack, LootContext context) {
        if (context.ExplosionRadius is not { } radius) {
            return stack;
        }

        float probability = 1.0f / radius;
        int survived = 0;
        for (int i = 0; i < stack.Count; i++) {
            if (context.Random.NextFloat() <= probability) {
                survived++;
            }
        }

        return stack.WithCount(survived);
    }
}

/// <summary>
/// <c>ApplyBonusCount</c>, the fortune scaling. The whole body is skipped when there is <b>no tool</b>
/// rather than when the level is zero, so a drop from something that was not held stays at its base
/// count instead of going through the formula with a level of zero.
/// </summary>
public sealed record ApplyBonusFunction(
    ILootCondition? Condition,
    Identifier Enchantment,
    IBonusFormula Formula) : LootFunction(Condition) {

    protected override ItemStack Run(ItemStack stack, LootContext context) {
        if (context.Tool is not { } tool) {
            return stack;
        }

        int level = tool.GetEnchantmentLevel(Enchantment);
        return stack.WithCount(Formula.CalculateNewCount(context.Random, stack.Count, level));
    }
}

/// <summary><c>ApplyBonusCount.Formula</c>, the three vanilla shapes.</summary>
public interface IBonusFormula {
    public int CalculateNewCount(RandomSource random, int count, int level);
}

/// <summary>
/// <c>ApplyBonusCount.OreDrops</c>: the multiplier is drawn from <c>[0, level + 2)</c> and then has
/// one taken off it, so Fortune I is as likely to give nothing extra as to double.
/// </summary>
public sealed record OreDropsFormula : IBonusFormula {
    public static readonly OreDropsFormula Instance = new();

    public int CalculateNewCount(RandomSource random, int count, int level) {
        if (level <= 0) {
            return count;
        }

        int bonus = random.NextInt(level + 2) - 1;
        if (bonus < 0) {
            bonus = 0;
        }

        return count * (bonus + 1);
    }
}

/// <summary><c>ApplyBonusCount.UniformBonusCount</c>.</summary>
public sealed record UniformBonusCountFormula(int BonusMultiplier) : IBonusFormula {
    public int CalculateNewCount(RandomSource random, int count, int level) {
        return count + random.NextInt(BonusMultiplier * level + 1);
    }
}

/// <summary>
/// <c>ApplyBonusCount.BinomialWithBonusCount</c>: <c>level + extra</c> trials at
/// <c>probability</c>, each adding one.
/// </summary>
public sealed record BinomialWithBonusCountFormula(int ExtraRounds, float Probability) : IBonusFormula {
    public int CalculateNewCount(RandomSource random, int count, int level) {
        for (int i = 0; i < level + ExtraRounds; i++) {
            if (random.NextFloat() < Probability) {
                count++;
            }
        }

        return count;
    }
}

/// <summary><c>LimitCount</c>: clamp the count into a range, either end of which may be absent.</summary>
public sealed record LimitCountFunction(ILootCondition? Condition, IntLimit Limit) : LootFunction(Condition) {
    protected override ItemStack Run(ItemStack stack, LootContext context) {
        return stack.WithCount(Limit.Clamp(context, stack.Count));
    }
}

/// <summary>
/// <c>CopyComponentsFunction</c> from a block entity, which is what keeps a shulker box's contents, a
/// beehive's bees and a decorated pot's sherds when it is broken.
/// <p/>
/// <b>Inert today.</b> <see cref="LootContext.BlockEntityData"/> is the raw NBT the world stores, and
/// there is no port of <c>BlockEntity.collectComponents</c> to turn that into data components. The
/// item itself is still correct; only what it was carrying is lost. Transcribed rather than omitted
/// so the table stays a faithful reading of the datapack and the gap is one method, named here.
/// </summary>
public sealed record CopyComponentsFunction(
    ILootCondition? Condition,
    Identifier[] Include) : LootFunction(Condition) {

    protected override ItemStack Run(ItemStack stack, LootContext context) {
        return stack;
    }
}

/// <summary>
/// <c>CopyBlockState</c>: copy the named properties of the broken state onto the item's
/// <c>minecraft:block_state</c> component, which is how a beehive keeps its honey level and a copper
/// golem statue its pose.
/// <p/>
/// <b>Inert today</b>, for a narrower reason than <see cref="CopyComponentsFunction"/>: the state is
/// right there in the context, but <c>minecraft:block_state</c> is one of the roughly ninety data
/// components with no implementation here, so there is nothing to write it into. Ten blocks are
/// affected and all ten still drop the right item.
/// </summary>
public sealed record CopyStateFunction(
    ILootCondition? Condition,
    Identifier Block,
    string[] Properties) : LootFunction(Condition) {

    protected override ItemStack Run(ItemStack stack, LootContext context) {
        return stack;
    }
}
