using ManagedServer.Entities.Types;
using ManagedServer.Worlds;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Pathfinding;

/// <summary>
/// The graph the search walks, vanilla's <c>NodeEvaluator</c>: what counts as a node, which nodes
/// neighbour which, and what each costs.
/// <p/>
/// This is the whole of what makes a ground mob path differently from a swimming or flying one, so
/// it is the seam to subclass rather than <see cref="PathFinder"/>, which is a plain A* and knows
/// nothing about blocks.
/// <p/>
/// One instance is reused across searches and holds a per search node table, so
/// <see cref="Prepare"/> and <see cref="Done"/> bracket every use.
/// </summary>
public abstract class NodeEvaluator {
    protected PathfindingContext Context = null!;
    protected Mob Mob = null!;

    /// <summary>
    /// One node per position for the length of a search. Keyed by <see cref="Node.CreateHash"/>,
    /// which is lossy, so two positions far enough apart share an entry; the search never spans that
    /// far.
    /// </summary>
    private readonly Dictionary<int, Node> _nodes = [];

    /// <summary>
    /// How many blocks of space the mob needs, <b>rounded up past its actual size</b>:
    /// <c>floor(width + 1)</c>, so a 0.6 wide mob wants one column and a 1.4 wide one wants two.
    /// Used as a loop bound over the blocks the mob would occupy.
    /// </summary>
    protected int EntityWidth;
    protected int EntityHeight;
    protected int EntityDepth;

    public bool CanPassDoors { get; set; } = true;
    public bool CanOpenDoors { get; set; }
    public bool CanFloat { get; set; }
    public bool CanWalkOverFences { get; set; }

    public virtual void Prepare(World world, Mob mob) {
        Context = new PathfindingContext(world, mob);
        Mob = mob;
        _nodes.Clear();
        EntityWidth = Mth.Floor(mob.BbWidth + 1.0f);
        EntityHeight = Mth.Floor(mob.BbHeight + 1.0f);
        EntityDepth = Mth.Floor(mob.BbWidth + 1.0f);
    }

    public virtual void Done() {
        Context = null!;
        Mob = null!;
    }

    protected Node GetNode(int x, int y, int z) {
        int hash = Node.CreateHash(x, y, z);
        if (_nodes.TryGetValue(hash, out Node? existing)) {
            return existing;
        }

        Node created = new(x, y, z);
        _nodes[hash] = created;
        return created;
    }

    protected Node GetNode(Vec3<int> pos) {
        return GetNode(pos.X, pos.Y, pos.Z);
    }

    /// <summary>Where the mob is standing, as a node.</summary>
    public abstract Node? GetStart();

    /// <summary>Somewhere to aim for, as a target node.</summary>
    public abstract PathTarget GetTarget(double x, double y, double z);

    protected PathTarget GetTargetNodeAt(double x, double y, double z) {
        return new PathTarget(GetNode(Mth.Floor(x), Mth.Floor(y), Mth.Floor(z)));
    }

    /// <summary>
    /// Fills <paramref name="neighbors"/> with what can be reached from <paramref name="from"/> and
    /// returns how many. The array is reused across calls, so only the first return-value entries
    /// are meaningful.
    /// </summary>
    public abstract int GetNeighbors(Node[] neighbors, Node from);

    /// <summary>What the block at a position means to this particular mob.</summary>
    public abstract PathType GetPathTypeOfMob(PathfindingContext context, int x, int y, int z, Mob mob);

    /// <summary>What the block at a position means, before anything about the mob.</summary>
    public abstract PathType GetPathType(PathfindingContext context, int x, int y, int z);
}
