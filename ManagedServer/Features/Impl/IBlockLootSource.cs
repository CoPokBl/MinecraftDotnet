using Minecraft.Data.Blocks;
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
