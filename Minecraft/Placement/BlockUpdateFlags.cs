namespace Minecraft.Placement;

/// <summary>
/// Vanilla's <c>Block.UpdateFlags</c>, the bit set every <c>Level.setBlock</c> takes.
/// <p/>
/// Transcribed whole rather than trimmed to the bits that currently do something, because the callers
/// are transcriptions too: <c>BlockItem.placeBlock</c> passes 11, <c>BedItem</c> 26 and
/// <c>DoubleHighBlockItem</c> 27, and those numbers only mean anything against the full set. The bits
/// with nothing behind them yet are marked as such.
/// </summary>
public static class BlockUpdateFlags {
    /// <summary>Run the neighbour <b>change</b> pass, which is redstone. No engine yet, so inert.</summary>
    public const int NeighborUpdates = 1;

    /// <summary>Tell the clients. Without it a write is server side only.</summary>
    public const int Clients = 2;

    /// <summary>Client only, suppresses the render update. Nothing here reads it.</summary>
    public const int Invisible = 4;

    /// <summary>Client only, forces an immediate re-render. Nothing here reads it.</summary>
    public const int Immediate = 8;

    /// <summary>
    /// Skip the shape update pass. Set by a caller that has already worked out what the neighbours
    /// should be, which is how the two halves of a door go down without fighting each other.
    /// </summary>
    public const int KnownShape = 16;

    /// <summary>A block destroyed by this write drops nothing.</summary>
    public const int SuppressDrops = 32;

    /// <summary>The write is a piston moving something. No pistons yet, so inert.</summary>
    public const int MoveByPiston = 64;

    /// <summary>Redstone wire ignores this shape update. No redstone wire behaviour yet.</summary>
    public const int SkipShapeUpdateOnWire = 128;

    /// <summary>Skip the block entity side effects. No block entity behaviour yet.</summary>
    public const int SkipBlockEntitySideEffects = 256;

    /// <summary>Skip <c>onPlace</c>. Nothing here reads it.</summary>
    public const int SkipOnPlace = 512;

    /// <summary>
    /// <c>Level.setBlockAndUpdate</c>'s flags, and the default for <see cref="IPlacementLevel.SetBlock"/>:
    /// tell the clients and run both neighbour passes. What a caller that just wants a block put
    /// somewhere means.
    /// </summary>
    public const int Default = NeighborUpdates | Clients;

    /// <summary>
    /// <c>Level.setBlock</c>'s own default depth cap, and vanilla's re-entrancy guard: every step of a
    /// shape cascade passes one less, and at zero the pass stops. There is no separate visited set,
    /// so this is the only thing standing between two blocks that each react to the other and a stack
    /// overflow.
    /// </summary>
    public const int UpdateLimit = 512;
}
