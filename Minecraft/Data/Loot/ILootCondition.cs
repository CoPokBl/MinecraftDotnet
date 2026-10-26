using Minecraft.Data.Blocks;
using Minecraft.Data.Enchantments;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Loot;

/// <summary>
/// Vanilla's <c>LootItemCondition</c>. Only the nine the block tables use exist; anything else fails
/// the parser rather than being dropped, because a condition that silently reads as true turns a
/// silk touch check into an unconditional drop.
/// </summary>
public interface ILootCondition {
    public bool Test(LootContext context);
}

/// <summary>
/// <c>ExplosionCondition</c>, the 859 use majority. With no explosion radius in the context it is
/// unconditionally true, which is exactly what vanilla does for a block broken by hand.
/// </summary>
public sealed record SurvivesExplosionCondition : ILootCondition {
    public static readonly SurvivesExplosionCondition Instance = new();

    public bool Test(LootContext context) {
        if (context.ExplosionRadius is not { } radius) {
            return true;
        }

        return context.Random.NextFloat() <= 1.0f / radius;
    }
}

/// <summary>
/// <c>MatchBlock</c>: the looted state matches a <see cref="BlockPredicate"/>. False without a state
/// in the context, which a block table always has.
/// </summary>
public sealed record MatchBlockCondition(BlockPredicate Predicate) : ILootCondition {
    public bool Test(LootContext context) {
        return Predicate.MatchesState(context.State, context.Registry);
    }
}

/// <summary>
/// <c>MatchTool</c>. False without a tool in the context at all, which is not the same as a bare
/// hand: a bare hand is <see cref="ItemStack.Air"/> and gets as far as the predicate.
/// </summary>
public sealed record MatchToolCondition(ItemPredicate? Predicate) : ILootCondition {
    public bool Test(LootContext context) {
        return context.Tool != null && (Predicate == null || Predicate.Test(context.Tool, context.Registry));
    }
}

/// <summary><c>AnyOfCondition</c>: true when any term is, false for no terms.</summary>
public sealed record AnyOfCondition(ILootCondition[] Terms) : ILootCondition {
    public bool Test(LootContext context) {
        foreach (ILootCondition term in Terms) {
            if (term.Test(context)) {
                return true;
            }
        }

        return false;
    }
}

/// <summary><c>AllOfCondition</c>: true when every term is, true for no terms.</summary>
public sealed record AllOfCondition(ILootCondition[] Terms) : ILootCondition {
    public bool Test(LootContext context) {
        foreach (ILootCondition term in Terms) {
            if (!term.Test(context)) {
                return false;
            }
        }

        return true;
    }
}

/// <summary><c>InvertedLootItemCondition</c>.</summary>
public sealed record InvertedCondition(ILootCondition Term) : ILootCondition {
    public bool Test(LootContext context) {
        return !Term.Test(context);
    }
}

/// <summary>
/// <c>BonusLevelTableCondition</c>: a chance per enchantment level, indexed by the level itself, so
/// entry zero is the unenchanted chance. A level past the end of the table clamps to the last entry,
/// which is what makes Fortune IV on leaves behave like Fortune III.
/// </summary>
public sealed record TableBonusCondition(Identifier Enchantment, float[] Chances) : ILootCondition {
    public bool Test(LootContext context) {
        int level = context.Tool?.GetEnchantmentLevel(Enchantment) ?? 0;
        float chance = Chances[Math.Min(level, Chances.Length - 1)];
        return context.Random.NextFloat() < chance;
    }
}

/// <summary>
/// <c>LootItemRandomChanceCondition</c>. The chance is asked before the draw, which matters for a
/// chance that draws itself.
/// </summary>
public sealed record RandomChanceCondition(IContextFloatProvider Chance) : ILootCondition {
    public bool Test(LootContext context) {
        float probability = Chance.GetFloat(context);
        return context.Random.NextFloat() < probability;
    }
}

/// <summary>
/// <c>LocationCheck</c>, cut down to the one thing the block tables ask it: whether the block at an
/// offset from the looted position matches a block predicate. Both uses are the two halves of a tall
/// plant checking that the other half is still there.
/// <p/>
/// A context with no <see cref="LootContext.BlockAt"/> answers false, which loses those two drops
/// rather than inventing them.
/// </summary>
public sealed record LocationCheckCondition(Vec3<int> Offset, BlockPredicate Predicate) : ILootCondition {
    public bool Test(LootContext context) {
        if (context.BlockAt == null) {
            return false;
        }

        return Predicate.MatchesState(context.BlockAt(context.Position + Offset), context.Registry);
    }
}

/// <summary>
/// <c>BlockPredicate</c> cut to the block set and the state properties, the only parts a block table
/// uses; <c>nbt</c> and component matches are refused by the parser. <paramref name="Blocks"/> and
/// <paramref name="Tag"/> are both null when the predicate names no block, which matches any.
/// <p/>
/// The state is compared over <see cref="IBlock.ToStateNbt"/>, every property as the string vanilla
/// writes it, because that is the form the datapack states them in.
/// </summary>
public sealed record BlockPredicate(
    Identifier[]? Blocks,
    Identifier? Tag,
    (string Key, string Value)[] State) {

    /// <summary><c>BlockPredicate.matchesState</c>.</summary>
    public bool MatchesState(IBlock block, Registry.MinecraftRegistry registry) {
        if (Blocks != null && !Blocks.Contains(block.Identifier)) {
            return false;
        }

        if (Tag is { } tag && !registry.Blocks.Tags.Contains(registry, tag, block.Identifier)) {
            return false;
        }

        if (State.Length == 0) {
            return true;
        }

        CompoundTag state = block.ToStateNbt();
        foreach ((string key, string value) in State) {
            if (!state.Contains(key) || state[key].GetString() != value) {
                return false;
            }
        }

        return true;
    }
}

/// <summary>
/// <c>LootItemEntityPropertyCondition</c> against <c>this</c> with an <b>empty</b> predicate, which is
/// the only form the block tables use: it asks whether anything did the breaking at all, not what.
/// <c>chorus_flower</c> and <c>snow</c> use it so that a block broken by the world drops nothing.
/// <p/>
/// The parser rejects a non-empty predicate rather than ignoring it, since a predicate read as
/// empty is a condition that passes when it should not.
/// </summary>
public sealed record EntityPresentCondition : ILootCondition {
    public static readonly EntityPresentCondition Instance = new();

    public bool Test(LootContext context) {
        return context.HasBreaker;
    }
}

/// <summary>
/// Vanilla's <c>ItemPredicate</c>, cut to the two shapes <c>match_tool</c> uses in block tables: an
/// item or item tag, and a minimum enchantment level. Anything else fails the parser.
/// <p/>
/// <paramref name="Item"/> and <paramref name="ItemTag"/> are separate rather than one field with a
/// <c>#</c> prefix: an <see cref="Identifier"/> splits on the colon, so <c>#minecraft:shears</c>
/// parses to a namespace of <c>#minecraft</c> and the hash never comes back off cleanly.
/// </summary>
public sealed record ItemPredicate(
    Identifier? Item,
    Identifier? ItemTag,
    (Identifier Enchantment, int MinLevel)[] Enchantments) {

    /// <summary>The silk touch test that 156 of the 203 <c>match_tool</c> uses are.</summary>
    public static ItemPredicate WithEnchantment(IEnchantment enchantment, int minLevel) {
        return new ItemPredicate(null, null, [(enchantment.Identifier, minLevel)]);
    }

    /// <summary>The shears test that the other 47 are.</summary>
    public static ItemPredicate WithItem(Identifier item) {
        return new ItemPredicate(item, null, []);
    }

    public bool Test(ItemStack tool, Registry.MinecraftRegistry registry) {
        if (Item is { } item && tool.Type.Identifier != item) {
            return false;
        }

        if (ItemTag is { } tag && !registry.Items.Tags.Contains(registry, tag, tool.Type.Identifier)) {
            return false;
        }

        foreach ((Identifier enchantment, int minLevel) in Enchantments) {
            if (tool.GetEnchantmentLevel(enchantment) < minLevel) {
                return false;
            }
        }

        return true;
    }
}
