using ManagedServer.Entities.Types;
using ManagedServer.Viewables;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Sound;
using Minecraft.Schemas.Vec;
using Minecraft.Placement;

namespace ManagedServer.Interaction.Rules;

/// <summary>
/// <c>CandleBlock.useItemOn</c>, which is only the <b>extinguishing</b> half. Lighting a candle is
/// <c>FlintAndSteelItem</c> and <c>FireChargeItem</c>, not the block, so it is not this rule's to
/// transcribe and a candle here can be put out but not relit.
/// </summary>
public sealed class CandleInteractionRule : IBlockInteractionRule {
    public BlockClass VanillaClass => BlockClass.CandleBlock;

    public InteractionResult UseItemOn(IBlock block, World world, Vec3<int> pos, Player player,
        Hand hand, ItemStack stack, BlockHit hit) {
        // Bare hand, allowed to build, and currently lit. Vanilla's mayBuild is an Abilities flag
        // that is not modelled; it is true in survival and creative and false in the other two, so
        // the game mode answers it exactly.
        bool mayBuild = player.GameMode is GameMode.Survival or GameMode.Creative;
        if (!stack.IsAir() || !mayBuild || block is not ILit { Lit: true } candle) {
            return InteractionResult.TryWithEmptyHand;
        }

        // AbstractCandleBlock.extinguish -> setLit(false), which is setBlock with vanilla's literal
        // 11. The smoke particles it also emits are client side in vanilla and are skipped.
        world.SetBlock(pos, candle.WithLit(false),
            flags: BlockUpdateFlags.NeighborUpdates | BlockUpdateFlags.Clients | BlockUpdateFlags.Immediate);

        // Unlike the door family this sound is a constant, so it can be transcribed. Vanilla passes a
        // null player, meaning everyone hears it, the one who clicked included.
        Vec3<double> at = new(pos.X + 0.5, pos.Y + 0.5, pos.Z + 0.5);
        world.PlaySound(SoundType.CandleExtinguish, at, SoundCategory.Blocks);
        return InteractionResult.Success;
    }
}

/// <summary>
/// <c>DragonEggBlock</c>: clicking it makes it jump somewhere else nearby.
/// </summary>
public sealed class DragonEggInteractionRule : IBlockInteractionRule {
    public BlockClass VanillaClass => BlockClass.DragonEggBlock;

    public InteractionResult UseWithoutItem(IBlock block, World world, Vec3<int> pos, Player player,
        BlockHit hit) {
        Teleport(block, world, pos);

        // SUCCESS whether or not a spot was found, which is vanilla: teleport() returns void and the
        // caller cannot tell that a thousand tries all missed.
        return InteractionResult.Success;
    }

    /// <summary>
    /// <c>DragonEggBlock.teleport</c>. A thousand tries at a nearby cell, taking the first that is
    /// air with something solid under it.
    /// </summary>
    private static void Teleport(IBlock block, World world, Vec3<int> pos) {
        RandomSource random = world.Random;

        for (int i = 0; i < 1000; i++) {
            // Two independent rolls subtracted, not one roll over a symmetric range: that is a
            // triangular distribution centred on the egg, so it usually moves a short way.
            Vec3<int> testPos = new(
                pos.X + random.NextInt(16) - random.NextInt(16),
                pos.Y + random.NextInt(8) - random.NextInt(8),
                pos.Z + random.NextInt(16) - random.NextInt(16));

            // The world border is not modelled, so only the build height half of vanilla's bounds
            // check is here. Both cells have to be in bounds to be read at all.
            if (!world.IsInBounds(testPos) || !world.IsInBounds(testPos.GetBlockTowards(BlockFace.NegY))) {
                continue;
            }

            if (!world.GetBlock(testPos).Air || world.GetBlock(testPos.GetBlockTowards(BlockFace.NegY)).Air) {
                continue;
            }

            // setBlock 2 then removeBlock: the egg appears before it disappears, and neither write
            // runs the neighbour change pass.
            world.SetBlock(testPos, block, flags: BlockUpdateFlags.Clients);
            world.SetBlock(pos, Block.Air, flags: BlockUpdateFlags.Clients);
            return;
        }
    }
}
