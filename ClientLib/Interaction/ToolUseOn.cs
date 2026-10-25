using ClientLib.World;
using ClientLib.World.BlockEntities;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;

namespace ClientLib.Interaction;

/// <summary>Which of its block changes an axe's or a honeycomb's <c>useOn</c> made.</summary>
public enum ToolBlockChange : byte {
    None,

    /// <summary><c>AxeItem.getStripped</c>.</summary>
    Strip,

    /// <summary><c>WeatheringCopper.getPrevious</c>: level event 3005.</summary>
    Scrape,

    /// <summary><c>HoneycombItem.WAX_OFF_BY_BLOCK</c>: level event 3004.</summary>
    WaxOff,

    /// <summary><c>HoneycombItem.getWaxed</c>: level event 3003.</summary>
    WaxOn
}

/// <summary>
/// <c>AxeItem.useOn</c> and <c>HoneycombItem.useOn</c> as their own player sees them, told from what an
/// acknowledged use changed rather than predicted: the level events they raise with the player as the
/// source, which the server sends to everyone else.
/// </summary>
public static class ToolUseOn {
    /// <summary>What the use changed the clicked block by, in <c>AxeItem.evaluateNewBlockState</c>'s order for an axe.</summary>
    public static ToolBlockChange Classify(Identifier item, IBlock before, IBlock after) {
        if (before.StateId == after.StateId) {
            return ToolBlockChange.None;
        }
        if (item.Equals(Item.Honeycomb.Identifier)) {
            return Turns(BlockConversions.Waxables, before, after) ? ToolBlockChange.WaxOn : ToolBlockChange.None;
        }
        if (!UsePrediction.Axes.Contains(item)) {
            return ToolBlockChange.None;
        }
        if (BlockConversions.Strippables.ContainsKey(before.Identifier)) {
            return Turns(BlockConversions.Strippables, before, after) ? ToolBlockChange.Strip : ToolBlockChange.None;
        }
        if (BlockConversions.WeatheringPrevious.ContainsKey(before.Identifier)) {
            return Turns(BlockConversions.WeatheringPrevious, before, after) ? ToolBlockChange.Scrape : ToolBlockChange.None;
        }
        return Turns(BlockConversions.WaxOff, before, after) ? ToolBlockChange.WaxOff : ToolBlockChange.None;
    }

    private static bool Turns(IReadOnlyDictionary<Identifier, IBlock> table, IBlock before, IBlock after) =>
        table.TryGetValue(before.Identifier, out IBlock? to) && to.Identifier == after.Identifier;

    /// <summary>
    /// The level event the use raised at the clicked block, and at the other half of a double chest
    /// (<c>ChestBlock.getConnectedBlockPos</c>) as the copper chests have.
    /// </summary>
    public static void RaiseLevelEvents(ClientLevel level, UseOnOutcome use) {
        IBlock before = level.Registry.Blocks.GetByStateId(use.ClickedBefore);
        int type = Classify(use.Item.Type.Identifier, before, level.Registry.Blocks.GetByStateId(use.ClickedAfter)) switch {
            ToolBlockChange.Scrape => 3005,
            ToolBlockChange.WaxOff => 3004,
            ToolBlockChange.WaxOn => 3003,
            _ => 0
        };
        if (type == 0) {
            return;
        }
        (int x, int y, int z) = use.Clicked;
        level.RaiseLevelEvent(type, x, y, z, 0);
        if (before is IChestTyped { Type: not ChestType.Single } chest and IHorizontalFacing facing) {
            Direction connected = chest.Type == ChestType.Left ? DirectionUtil.ClockWise(facing.Facing) : DirectionUtil.CounterClockWise(facing.Facing);
            (int stepX, int stepZ) = DirectionUtil.Step(connected);
            level.RaiseLevelEvent(type, x + stepX, y, z + stepZ, 0);
        }
    }
}
