using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace ManagedServer;

public static class BlockUtils {

    /// <summary>
    /// Gets the time it takes to break a block in ticks.
    /// </summary>
    /// <param name="gameMode">The player's gamemode.</param>
    /// <param name="block">The block being broken.</param>
    /// <param name="tool">The tool being used.</param>
    /// <param name="isInWater">Whether the player is in water.</param>
    /// <param name="onGround">Whether the player is on the ground.</param>
    /// <returns>The time it takes to break the block in ticks.</returns>
    public static int GetBreakSpeed(GameMode gameMode, IBlock block, ItemStack tool, bool isInWater, bool onGround) {
        if (gameMode == GameMode.Creative) {
            return 0;
        }
        
        double hardness = block.Hardness;
        if (Math.Abs(hardness + 1) < 0.0001) {  // Good way of doing: hardness == -1
            return -1;  // unbreakable blocks
        }

        // This is hardcoded into the vanilla client.
        if (IBlock.SimilarTo(block, Block.Bamboo) || IBlock.SimilarTo(block, Block.BambooSapling)) {
            if (VanillaTags.ItemSwords.Contains(tool.Type.Identifier)) {
                return 0;  // swords break bamboo instantly
            }
        }

        Tool? toolData = tool.GetOrNull(DataComponent.Tool);
        
        bool isBestTool = CanBreakBlock(toolData, block);
        float speedMultiplier;
        
        if (isBestTool) {
            speedMultiplier = toolData?.GetMiningSpeed(block) ?? 1;

            // Minestom says this is a thing, apparently the wiki is wrong.
            if (speedMultiplier > 1) {
                // TODO: Add the attribute value of the player's mining efficiency to the speed mult.
            }
        }
        else {
            speedMultiplier = 1;
        }
        
        // TODO: If player has haste or conduit power then multiply by this:
        // float level = Math.max(player.getEffectLevel(PotionEffect.HASTE), player.getEffectLevel(PotionEffect.CONDUIT_POWER)) + 1;
        // return (1F + 0.2F * level);
        
        // TODO: If player has mining fatigue then multiply by this:
        // int level = player.getEffectLevel(PotionEffect.MINING_FATIGUE) + 1;
        // // Use switch to avoid expensive Math.pow
        // return switch (level) { // 0.3 ^ min(level, 4)
        //     case 0 -> 0;
        //     case 1 -> 0.3F; // 0.3 ^ 1
        //     case 2 -> 0.09F; // 0.3 ^ 2
        //     case 3 -> 0.027F; // 0.3 ^ 3
        //     default -> 0.0081F; // 0.3 ^ 4
        // };
        
        // TODO: Multiply by player attribute value: BLOCK_BREAK_SPEED

        if (isInWater) {
            speedMultiplier *= 1;  // TODO: Get val from attribute: SUBMERGED_MINING_SPEED
        }

        if (!onGround) {
            speedMultiplier /= 5;
        }

        double damage = speedMultiplier / hardness;

        if (isBestTool) {
            damage /= 30;
        }
        else {
            damage /= 100;
        }

        if (damage >= 1) {
            return 0;  // instant break
        }
        
        return (int)Math.Ceiling(1 / damage);
    }

    private static bool CanBreakBlock(Tool? tool, IBlock block) {
        return !block.RequiresTool || (tool != null && tool.IsCorrectForDrops(block));
    }
}
