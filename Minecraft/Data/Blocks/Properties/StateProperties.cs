namespace Minecraft.Data.Blocks.Properties;

/// <summary>
/// A block that can hold water in the same cell, vanilla's <c>SimpleWaterloggedBlock</c> property.
/// 429 blocks, the largest family there is.
/// <p/>
/// Vanilla's interface of that name carries <b>no</b> placement logic. The line that waterlogs on
/// placement, <c>setValue(WATERLOGGED, level.getFluidState(pos).is(WATER))</c>, is copy pasted into
/// each block's own <c>getStateForPlacement</c>, so this interface is what a state has, not a
/// promise about how it is placed. 46 block classes register the property and 44 of them waterlog
/// at placement; <c>LightBlock</c> and <c>BigDripleafStemBlock</c> do not, which is why the
/// placement helper is called from the rules that want it rather than applied to everything that
/// implements this.
/// </summary>
public interface IWaterlogged : IBlock {
    public bool Waterlogged { get; }

    public IBlock WithWaterlogged(bool waterlogged);
}

/// <summary>
/// A block with a redstone <c>powered</c> flag. 136 blocks.
/// <p/>
/// Placement matters for it: doors, trapdoors and fence gates read
/// <c>level.hasNeighborSignal(pos)</c> when they are placed and come out already open next to a
/// live wire, rather than waiting for an update that never comes.
/// </summary>
public interface IPowered : IBlock {
    public bool Powered { get; }

    public IBlock WithPowered(bool powered);
}

/// <summary>
/// A block that opens, vanilla's <c>open</c>. 55 blocks: doors, trapdoors, fence gates and barrels.
/// Set alongside <see cref="IPowered"/> at placement for the same reason.
/// </summary>
public interface IOpenable : IBlock {
    public bool Open { get; }

    public IBlock WithOpen(bool open);
}

/// <summary>
/// A block with a <c>lit</c> flag. 52 blocks: furnaces, campfires, redstone lamps and ore.
/// </summary>
public interface ILit : IBlock {
    public bool Lit { get; }

    public IBlock WithLit(bool lit);
}

/// <summary>
/// A block that stacks in place: placing another of the same item on it adds one rather than putting
/// a second block down. Six properties, all counting from one:
/// <c>candles</c> (17 blocks, to 4), <c>layers</c> (snow, to 8), <c>pickles</c> (to 4),
/// <c>eggs</c> (turtle eggs, to 4), <c>flower_amount</c> (2 blocks, to 4) and
/// <c>segment_amount</c> (leaf litter, to 4).
/// <p/>
/// Grouping them is a small departure from vanilla, which keeps six separate properties and repeats
/// the increment in six <c>getStateForPlacement</c> bodies. They are grouped because the property is
/// the only thing that differs between those bodies, and because the rule that reads it has to pair
/// with a <c>canBeReplaced</c> override that reads the same one. Splitting them would be six copies
/// of two methods with a different identifier in each.
/// <p/>
/// The count is what vanilla calls the property, not an index: a single candle is 1, not 0.
/// </summary>
public interface IStackable : IBlock {
    public int Count { get; }

    /// <summary>The most this block stacks to, vanilla's property maximum.</summary>
    public int MaxCount { get; }

    public IBlock WithCount(int count);
}
