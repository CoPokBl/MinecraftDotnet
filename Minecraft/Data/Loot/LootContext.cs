using Minecraft.Data.Blocks;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using NBT.Tags;

namespace Minecraft.Data.Loot;

/// <summary>
/// Everything a loot table is allowed to ask about the thing being looted, vanilla's
/// <c>LootContext</c> and the <c>LootContextParams</c> it carries.
/// <p/>
/// This lives in the protocol layer, which cannot see a world or an entity, so the two conditions
/// that need one take a delegate instead of the object. That is the whole of the coupling: everything
/// else a block table asks for is a block state, a tool and a random source.
/// <p/>
/// A parameter vanilla treats as optional is null here, and the difference between null and a default
/// is load bearing in both directions. <see cref="Tool"/> is <see cref="ItemStack.Air"/> for a bare
/// hand and null only when nothing did the breaking, because <c>ApplyBonusCount</c> skips its whole
/// body on a null tool rather than computing a level of zero.
/// </summary>
public sealed record LootContext(
    IBlock State,
    Vec3<int> Position,
    RandomSource Random,
    MinecraftRegistry Registry) {

    /// <summary>
    /// <c>LootContextParams.TOOL</c>. <see cref="ItemStack.Air"/> for a bare hand, null when there was
    /// no breaker at all, as <c>Block.dropResources</c> without a tool passes.
    /// </summary>
    public ItemStack? Tool { get; init; } = ItemStack.Air;

    /// <summary>
    /// <c>LootContextParams.EXPLOSION_RADIUS</c>, and always null today because there is no explosion
    /// system. Null is what makes <c>survives_explosion</c> pass and <c>explosion_decay</c> a no-op,
    /// which is 859 and 153 of the block tables' condition and function uses respectively: they are
    /// correct rather than skipped.
    /// </summary>
    public float? ExplosionRadius { get; init; }

    /// <summary><c>LootContextParams.BLOCK_ENTITY</c>, for <c>copy_components</c>.</summary>
    public CompoundTag? BlockEntityData { get; init; }

    /// <summary>
    /// The world, for <c>location_check</c> (<c>tall_grass</c> and <c>large_fern</c>, which check what
    /// they are standing on). Null answers the check false.
    /// </summary>
    public Func<Vec3<int>, IBlock>? BlockAt { get; init; }

    /// <summary>
    /// Whether <c>LootContextParams.THIS_ENTITY</c> is set, for <c>entity_properties</c>
    /// (<c>chorus_flower</c> and <c>snow</c>). Both use an empty predicate, so the only question they
    /// ask is whether anything did the breaking; false is vanilla's answer for an absent entity.
    /// </summary>
    public bool HasBreaker { get; init; }


    /// <summary>
    /// <c>LootContext.getLuck</c>. Always zero for a block break: luck is the fishing rod's, and no
    /// block table carries a <c>quality</c> for it to act on.
    /// </summary>
    public float Luck { get; init; }
}
