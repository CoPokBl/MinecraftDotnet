namespace Minecraft.Data.Generated;

// Generated using the CodeGen project. Do not edit manually.

/// <summary>
/// What a mob's pathfinder makes of a block, vanilla's <c>PathType</c>. Declared in vanilla's own
/// order, which is the order these travel in the debug path packet.
/// </summary>
public enum PathType {
    Blocked,
    Open,
    Walkable,
    WalkableDoor,
    Trapdoor,
    PowderSnow,
    OnTopOfPowderSnow,
    Fence,
    Lava,
    Water,
    WaterBorder,
    Rail,
    UnpassableRail,
    FireInNeighbor,
    Fire,
    DamagingInNeighbor,
    Damaging,
    DoorOpen,
    DoorWoodClosed,
    DoorIronClosed,
    Breach,
    Leaves,
    StickyHoney,
    Cocoa,
    DamageCautious,
    OnTopOfTrapdoor,
    BigMobsCloseToDanger,
}

/// <summary>
/// What each <see cref="PathType"/> costs to path through before a mob's own overrides, vanilla's
/// <c>PathType.getMalus</c>.
/// <p/>
/// A negative value means impassable, which is the single most load bearing fact in the table: the
/// node evaluator rejects a candidate on <c>malus &lt; 0</c> rather than on any property of the
/// block. Read it through a mob's <c>PathfindingMalus</c>, which layers its own answers on top.
/// </summary>
public static class PathTypeMalus {
    private static readonly float[] Defaults = [
        -1f,
        0f,
        0f,
        0f,
        0f,
        -1f,
        0f,
        -1f,
        -1f,
        8f,
        8f,
        0f,
        -1f,
        8f,
        16f,
        8f,
        -1f,
        0f,
        -1f,
        -1f,
        4f,
        -1f,
        8f,
        0f,
        0f,
        0f,
        4f,
    ];

    public static float Of(PathType type) {
        return Defaults[(int)type];
    }
}
