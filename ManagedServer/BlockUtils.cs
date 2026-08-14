using ManagedServer.Entities.Types;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Attribute = Minecraft.Data.Generated.Attribute;

namespace ManagedServer;

public static class BlockUtils {

    /// <summary>
    /// Gets the time it takes a player to break a block in ticks.
    /// </summary>
    /// <param name="player">The player breaking the block.</param>
    /// <param name="block">The block being broken.</param>
    /// <param name="eyeInWater">Whether the player's eyes are inside water.</param>
    /// <param name="digSpeedAmplifier">Highest haste/conduit power amplifier, or -1 for neither.</param>
    /// <param name="miningFatigueAmplifier">Mining fatigue amplifier, or -1 for no mining fatigue.</param>
    /// <returns>0 for an instant break, -1 if the block can't be broken, otherwise the time in ticks.</returns>
    public static int GetBreakSpeed(Player player, IBlock block, bool eyeInWater = false,
        int digSpeedAmplifier = -1, int miningFatigueAmplifier = -1) {
        return GetBreakSpeed(player.Server.Registry, player.GameMode, block, player.HeldItem, eyeInWater,
            player.OnGround, (float)player.GetAttributeValue(Attribute.MiningEfficiency),
            (float)player.GetAttributeValue(Attribute.BlockBreakSpeed),
            (float)player.GetAttributeValue(Attribute.SubmergedMiningSpeed),
            digSpeedAmplifier, miningFatigueAmplifier);
    }

    /// <summary>
    /// Gets the time it takes to break a block in ticks. Mirrors vanilla's
    /// BlockBehaviour.getDestroyProgress and Player.getDestroySpeed.
    /// </summary>
    /// <param name="registry">Registry used to resolve the tool's block sets.</param>
    /// <param name="gameMode">The player's gamemode.</param>
    /// <param name="block">The block being broken.</param>
    /// <param name="tool">The item held in the main hand.</param>
    /// <param name="eyeInWater">Whether the player's eyes are inside water.</param>
    /// <param name="onGround">Whether the player is on the ground.</param>
    /// <param name="miningEfficiency">Value of the mining efficiency attribute.</param>
    /// <param name="blockBreakSpeed">Value of the block break speed attribute.</param>
    /// <param name="submergedMiningSpeed">Value of the submerged mining speed attribute.</param>
    /// <param name="digSpeedAmplifier">Highest haste/conduit power amplifier, or -1 for neither.</param>
    /// <param name="miningFatigueAmplifier">Mining fatigue amplifier, or -1 for no mining fatigue.</param>
    /// <returns>0 for an instant break, -1 if the block can't be broken, otherwise the time in ticks.</returns>
    public static int GetBreakSpeed(MinecraftRegistry registry, GameMode gameMode, IBlock block, ItemStack tool,
        bool eyeInWater, bool onGround, float miningEfficiency = 0f, float blockBreakSpeed = 1f,
        float submergedMiningSpeed = 0.2f, int digSpeedAmplifier = -1, int miningFatigueAmplifier = -1) {

        Tool? toolData = tool.GetOrNull(DataComponent.Tool);

        // Creative ignores hardness, but tools that opt out of it (swords, tridents) break nothing at all.
        if (gameMode == GameMode.Creative) {
            return toolData is { CanMineInCreative: false } ? -1 : 0;
        }

        float hardness = block.Hardness;
        if (Math.Abs(hardness + 1) < 0.0001f) {  // Good way of doing: hardness == -1
            return -1;  // unbreakable blocks
        }

        // The tool's speed applies whether or not it's the correct tool for the block.
        float speed = toolData?.GetMiningSpeed(block, registry) ?? 1f;
        if (speed > 1f) {
            speed += miningEfficiency;
        }

        if (digSpeedAmplifier >= 0) {
            speed *= 1f + (digSpeedAmplifier + 1) * 0.2f;
        }

        if (miningFatigueAmplifier >= 0) {
            // Vanilla's table, note that level 3 is a tenth of 0.3^3.
            speed *= miningFatigueAmplifier switch {
                0 => 0.3f,
                1 => 0.09f,
                2 => 0.0027f,
                _ => 0.00081f
            };
        }

        speed *= blockBreakSpeed;

        if (eyeInWater) {
            speed *= submergedMiningSpeed;
        }

        if (!onGround) {
            speed /= 5f;
        }

        float progress = speed / hardness / (CanBreakBlock(toolData, block, registry) ? 30f : 100f);

        if (progress >= 1f) {
            return 0;  // instant break
        }

        if (progress <= 0f) {
            return -1;  // no progress is ever made, so it can't be broken
        }

        // Vanilla breaks the block on the first tick where progress * ticks >= 1, so match that
        // multiplication rather than trusting the reciprocal to round the same way.
        int ticks = Math.Max(1, (int)MathF.Ceiling(1f / progress));
        while (ticks > 1 && progress * (ticks - 1) >= 1f) {
            ticks--;
        }
        while (progress * ticks < 1f) {
            ticks++;
        }

        return ticks;
    }

    /// <summary>
    /// <c>BlockState.canHarvestBlock</c>, which is both the thirty versus a hundred divisor in the
    /// break speed above and the gate on whether the block drops anything at all.
    /// </summary>
    public static bool CanHarvest(ItemStack tool, IBlock block, MinecraftRegistry registry) {
        return CanBreakBlock(tool.GetOrNull(DataComponent.Tool), block, registry);
    }

    private static bool CanBreakBlock(Tool? tool, IBlock block, MinecraftRegistry registry) {
        return !block.RequiresTool || (tool != null && tool.IsCorrectForDrops(block, registry));
    }
}
