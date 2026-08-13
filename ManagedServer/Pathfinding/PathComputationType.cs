namespace ManagedServer.Pathfinding;

/// <summary>
/// Which way of getting about a block is being asked about, vanilla's <c>PathComputationType</c>.
/// <p/>
/// A block answers <c>isPathfindable</c> differently for each: a lily pad is walkable and not
/// swimmable, water is swimmable and not walkable. The answers are per block state and come out of
/// the dump, see <c>BlockStateInfo.PathfindableLand</c>.
/// </summary>
public enum PathComputationType {
    Land,
    Water,
    Air
}
