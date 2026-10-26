using ClientLib.World;
using ClientLib.World.BlockEntities;
using Minecraft.Data.BlockTransformer;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Data.Sounds;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;

namespace ClientLib.Interaction;

/// <summary>
/// What an acknowledged tool use did to the clicked block as its own player hears and sees it: the
/// transform entry's sound and particle, or a honeycomb's waxing.
/// </summary>
/// <param name="LevelEvent">The level event raised at the clicked block, or 0 for none.</param>
/// <param name="Sound">Played at the clicked block, or null for none.</param>
/// <param name="ChestPartner">Whether the other half of a double chest gets the level event too.</param>
/// <param name="PartnerRepeatsSound">
/// Whether that half plays the sound a second time, at the clicked block, as <c>HoneycombItem.useOn</c> does.
/// </param>
public sealed record ToolUse(int LevelEvent, ISoundType? Sound, bool ChestPartner, bool PartnerRepeatsSound);

/// <summary>
/// <c>BlockTransformer.transformBlock</c> and <c>HoneycombItem.useOn</c> as their own player sees them,
/// told from what an acknowledged use changed rather than predicted: the sounds and level events they
/// play with the player as the source, which the server sends to everyone else.
/// </summary>
public static class ToolUseOn {
    /// <summary>
    /// The tool use that made the change, if one did: the transform entry that, asked about the block
    /// as it was, answers the block it became.
    /// </summary>
    public static ToolUse? Classify(BlockTransforms transforms, ClientLevel level, UseOnOutcome use) {
        if (use.ClickedBefore == use.ClickedAfter) {
            return null;
        }
        MinecraftRegistry registry = level.Registry;
        IBlock before = registry.Blocks.GetByStateId(use.ClickedBefore), after = registry.Blocks.GetByStateId(use.ClickedAfter);
        if (use.Item.Type.Identifier.Equals(Item.Honeycomb.Identifier)) {
            return BlockConversions.Waxables.TryGetValue(before.Identifier, out IBlock? waxed) && waxed.Identifier == after.Identifier
                ? new ToolUse(3003, SoundType.HoneycombWaxOn, IsDoubleChest(before), IsDoubleChest(before))
                : null;
        }
        (int cx, int cy, int cz) = use.Clicked;
        BlockTransforms.Match? match = transforms.Find(use.Item, cx, cy, cz, use.Face,
            (x, y, z) => x == cx && y == cy && z == cz ? use.ClickedBefore : level.GetState(x, y, z));
        if (match == null || match.Result.Identifier != after.Identifier) {
            return null;
        }
        BlockTransformData data = match.Data;
        ISoundType? sound = data.Sound switch {
            null => null,
            { IsValue1: true } named => named.Value1!.Identifier == BlockTransformData.EmptySound ? null : named.Value1,
            { } inline => inline.Value2!.Type
        };
        int levelEvent = data.Particle switch {
            TransformParticle.Scrape => 3005,
            TransformParticle.WaxOn => 3003,
            TransformParticle.WaxOff => 3004,
            _ => 0
        };
        return new ToolUse(levelEvent, sound, data.TransformType == TransformType.CopperChest && IsDoubleChest(before), false);
    }

    private static bool IsDoubleChest(IBlock block) =>
        BlockClasses.Is(block.Identifier, BlockClass.ChestBlock) && block is IChestTyped { Type: not ChestType.Single };

    /// <summary>The level event at the clicked block, and at the other half of a double chest (<c>ChestBlock.getConnectedBlockPos</c>).</summary>
    public static void RaiseLevelEvents(ClientLevel level, UseOnOutcome use) {
        if (use.Tool is not { LevelEvent: not 0 } tool) {
            return;
        }
        (int x, int y, int z) = use.Clicked;
        level.RaiseLevelEvent(tool.LevelEvent, x, y, z, 0);
        IBlock before = level.Registry.Blocks.GetByStateId(use.ClickedBefore);
        if (tool.ChestPartner && before is IChestTyped chest and IHorizontalFacing facing) {
            Direction connected = chest.Type == ChestType.Left ? DirectionUtil.ClockWise(facing.Facing) : DirectionUtil.CounterClockWise(facing.Facing);
            (int stepX, int stepZ) = DirectionUtil.Step(connected);
            level.RaiseLevelEvent(tool.LevelEvent, x + stepX, y, z + stepZ, 0);
        }
    }
}
