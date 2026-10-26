using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Pathfinding;

/// <summary>
/// One block the pathfinder is willing to stand in, vanilla's <c>Node</c>.
/// <p/>
/// A node is both a graph vertex and the A* bookkeeping for it, which is why the search can be
/// written without a side table: <see cref="G"/>, <see cref="H"/>, <see cref="F"/> and
/// <see cref="CameFrom"/> live on the node, and <see cref="HeapIndex"/> is how
/// <see cref="BinaryHeap"/> finds it again to change its cost. The evaluator hands out one instance
/// per position for the length of a single search, so identity is meaningful within one.
/// </summary>
public class Node(int x, int y, int z) {
    public readonly int X = x;
    public readonly int Y = y;
    public readonly int Z = z;

    private readonly int _hash = CreateHash(x, y, z);

    /// <summary>Where the node sits in the open set, or -1 when it is not in it.</summary>
    public int HeapIndex = -1;

    /// <summary>Cost from the start, A*'s g.</summary>
    public float G;

    /// <summary>Estimate to the target, A*'s h.</summary>
    public float H;

    /// <summary>The sum the heap orders on, A*'s f.</summary>
    public float F;

    public Node? CameFrom;

    public bool Closed;

    /// <summary>
    /// How far the path has walked to get here. Distinct from <see cref="G"/>, which also carries the
    /// malus, and it is this rather than g that <c>PathFinder</c> checks against the length limit.
    /// </summary>
    public float WalkedDistance;

    /// <summary>
    /// What this node costs on top of the distance. <b>Negative means impassable</b>, which is how
    /// the evaluator says no; every rejection in <c>WalkNodeEvaluator</c> is a test of this sign
    /// rather than of anything about the block.
    /// </summary>
    public float CostMalus;

    public PathType Type = PathType.Blocked;

    /// <summary>
    /// <c>Node.createHash</c>. Packs a position into an int, which is what lets the evaluator's node
    /// table be keyed by int rather than by a long or a tuple.
    /// <p/>
    /// It is lossy on purpose: eight bits of y and fifteen of each horizontal, so two positions
    /// 32768 blocks apart collide. Vanilla lives with that because a search is bounded to a few
    /// hundred nodes around the mob. Transcribed with vanilla's arithmetic, sign bits included.
    /// </summary>
    public static int CreateHash(int x, int y, int z) {
        return (y & 0xFF) | ((x & 32767) << 8) | ((z & 32767) << 24)
               | (x < 0 ? int.MinValue : 0) | (z < 0 ? 32768 : 0);
    }

    public float DistanceTo(Node to) {
        float xd = to.X - X;
        float yd = to.Y - Y;
        float zd = to.Z - Z;
        return Mth.Sqrt(xd * xd + yd * yd + zd * zd);
    }

    public float DistanceTo(Vec3<int> pos) {
        float xd = pos.X - X;
        float yd = pos.Y - Y;
        float zd = pos.Z - Z;
        return Mth.Sqrt(xd * xd + yd * yd + zd * zd);
    }

    public float DistanceToXZ(Node to) {
        float xd = to.X - X;
        float zd = to.Z - Z;
        return Mth.Sqrt(xd * xd + zd * zd);
    }

    public float DistanceToSqr(Node to) {
        float xd = to.X - X;
        float yd = to.Y - Y;
        float zd = to.Z - Z;
        return xd * xd + yd * yd + zd * zd;
    }

    public float DistanceManhattan(Node to) {
        return Math.Abs(to.X - X) + Math.Abs(to.Y - Y) + Math.Abs(to.Z - Z);
    }

    public float DistanceManhattan(Vec3<int> pos) {
        return Math.Abs(pos.X - X) + Math.Abs(pos.Y - Y) + Math.Abs(pos.Z - Z);
    }

    public Vec3<int> AsBlockPos() {
        return new Vec3<int>(X, Y, Z);
    }

    /// <summary>Whether the node is in the open set, <c>Node.inOpenSet</c>.</summary>
    public bool InOpenSet => HeapIndex >= 0;

    /// <summary>
    /// The same node somewhere else, carrying its search state. Used by the navigation's path
    /// trimming, which lifts a node out of a cauldron without restarting the search.
    /// </summary>
    public Node CloneAndMove(int x, int y, int z) {
        return new Node(x, y, z) {
            HeapIndex = HeapIndex,
            G = G,
            H = H,
            F = F,
            CameFrom = CameFrom,
            Closed = Closed,
            WalkedDistance = WalkedDistance,
            CostMalus = CostMalus,
            Type = Type
        };
    }

    public override bool Equals(object? obj) {
        return obj is Node other && _hash == other._hash && X == other.X && Y == other.Y && Z == other.Z;
    }

    public override int GetHashCode() {
        return _hash;
    }

    public override string ToString() {
        return $"Node{{x={X}, y={Y}, z={Z}}}";
    }
}
