using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Data.Loot;
using Minecraft.Schemas;

namespace ManagedServer.Features.Impl;

/// <summary>
/// Where <see cref="BlockDropsFeature"/> gets a block's loot table from.
/// <p/>
/// This is the seam instead of a registry on the server. A loot table is pure data with no consumer
/// inside core, unlike <c>DamagePipeline</c>, which <c>LivingEntity.Damage</c> has to consult, so
/// there is nothing for a server wide registry to serve: whoever wants drops registers the feature
/// and hands it the tables it should read.
/// </summary>
public interface IBlockLootSource {
    /// <summary>
    /// The table this block loots from, or null for a block that drops nothing. Null and an empty
    /// table are different answers and both are legitimate: bedrock has no table, and a table can
    /// exist and roll nothing.
    /// </summary>
    public LootTable? TableFor(IBlock block);
}

/// <summary>
/// Every vanilla table, straight out of the generated <see cref="BlockLootTables"/>.
/// <p/>
/// A singleton because the tables are immutable and shared process wide anyway. Note this is the one
/// place in the framework where a shared instance is right: <c>ManagedServerBundles</c> hands out
/// fresh features per access precisely because a feature holds state, and this holds none.
/// </summary>
public sealed class VanillaBlockLoot : IBlockLootSource {
    public static readonly VanillaBlockLoot Instance = new();

    private VanillaBlockLoot() { }

    public LootTable? TableFor(IBlock block) {
        return BlockLootTables.Of(block);
    }

    /// <summary>
    /// This source with one block's table replaced, which is how a minigame changes what a single
    /// block drops without touching the rest. Passing null makes the block drop nothing.
    /// </summary>
    public static IBlockLootSource With(IBlockLootSource inner, IBlock block, LootTable? table) {
        return new OverriddenBlockLoot(inner, new Dictionary<Identifier, LootTable?> {
            [block.Identifier] = table
        });
    }
}

/// <summary>An <see cref="IBlockLootSource"/> with some blocks answered from a table of its own.</summary>
public sealed class OverriddenBlockLoot(
    IBlockLootSource inner,
    IReadOnlyDictionary<Identifier, LootTable?> overrides) : IBlockLootSource {

    public LootTable? TableFor(IBlock block) {
        return overrides.TryGetValue(block.Identifier, out LootTable? table)
            ? table
            : inner.TableFor(block);
    }
}
