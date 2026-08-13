using ManagedServer.Entities.Types;
using ManagedServer.Fluids;
using ManagedServer.Pathfinding;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;
using Path = ManagedServer.Pathfinding.Path;

namespace ManagedServer.Ai.Navigation;

/// <summary>
/// The navigation almost every mob uses, vanilla's <c>GroundPathNavigation</c>: A* over
/// <see cref="WalkNodeEvaluator"/>.
/// <p/>
/// What it adds on top of <see cref="PathNavigation"/> is mostly about destinations rather than
/// routes. A target in mid air or buried inside rock is moved to the surface first
/// (<see cref="FindSurfacePosition"/>), because the search would otherwise be asked for somewhere no
/// ground mob can be and would return the best it could do from a long way off.
/// </summary>
public class GroundPathNavigation(Mob mob, World world) : PathNavigation(mob, world) {
    /// <summary>
    /// Whether the mob refuses to path into daylight. Set by the burning undead, and it works by
    /// truncating a finished route at its first sunlit node rather than by costing sunlight.
    /// </summary>
    public bool AvoidSun { get; set; }

    /// <summary>
    /// Whether a destination below the surface is taken at face value. Off by default, which is what
    /// makes <see cref="FindSurfacePosition"/> run.
    /// </summary>
    public bool CanPathToTargetsBelowSurface { get; set; }

    public bool CanWalkOverFences {
        get => NodeEvaluator.CanWalkOverFences;
        set => NodeEvaluator.CanWalkOverFences = value;
    }

    protected override PathFinder CreatePathFinder(int maxVisitedNodes) {
        NodeEvaluator = new WalkNodeEvaluator();
        return new PathFinder(NodeEvaluator, maxVisitedNodes);
    }

    /// <summary>
    /// A search is only worth doing from somewhere the mob is settled. Mid air is excluded because
    /// the start node would be wherever it happens to be falling past.
    /// </summary>
    protected override bool CanUpdatePath() {
        return Mob.OnGround || IsInLiquid();
    }

    private bool IsInLiquid() {
        return EntityFluids.IsIn(World, Mob, FluidKind.Water) || EntityFluids.IsIn(World, Mob, FluidKind.Lava);
    }

    protected override Vec3<double> GetTempMobPos() {
        return new Vec3<double>(Mob.Position.X, SurfaceY(), Mob.Position.Z);
    }

    public override bool CanNavigateGround => true;

    /// <summary>
    /// Where the mob counts as being vertically. Floating in water it is the surface, so distances
    /// to nodes are measured from where the mob will actually be; on land it is the same half block
    /// bias the start node uses.
    /// </summary>
    private int SurfaceY() {
        if (!EntityFluids.IsIn(World, Mob, FluidKind.Water) || !CanFloat) {
            return Mth.Floor(Mob.Position.Y + 0.5);
        }

        int surface = Mth.Floor(Mob.Position.Y);
        int steps = 0;

        while (IsWater(BlockAt(surface))) {
            surface++;

            // Vanilla's own guard against a very deep column, which would otherwise be a scan to the
            // top of the world every tick.
            if (++steps > 16) {
                return Mth.Floor(Mob.Position.Y);
            }
        }

        return surface;
    }

    private IBlock BlockAt(int y) {
        return World.GetBlockOr(new Vec3<int>(Mth.Floor(Mob.Position.X), y, Mth.Floor(Mob.Position.Z)), Block.Air);
    }

    private static bool IsWater(IBlock block) {
        return block.Identifier.Equals("minecraft:water");
    }

    public override Path? CreatePath(Vec3<int> pos, int reachRange) {
        // Vanilla asks the chunk source for a loaded chunk and gives up without one, since a
        // search through terrain that has not arrived would plan around air.
        if (!World.IsInBounds(pos) || !World.IsBlockLoaded(pos)) {
            return null;
        }

        return base.CreatePath(CanPathToTargetsBelowSurface ? pos : FindSurfacePosition(pos, reachRange), reachRange);
    }

    public override Path? CreatePath(Entity target, int reachRange) {
        return CreatePath(target.Position.ToBlockPos(), reachRange);
    }

    /// <summary>
    /// Moves a destination onto something a ground mob could stand on.
    /// <p/>
    /// Air falls to the first block below it, and if the column is empty all the way down it rises
    /// instead. A destination inside solid rock rises until it is out of it. Both are one dimensional
    /// scans in the target's own column, so a target inside a wall lands on top of the wall rather
    /// than beside it.
    /// </summary>
    private Vec3<int> FindSurfacePosition(Vec3<int> pos, int reachRange) {
        if (World.GetBlockOr(pos, Block.Air).Air) {
            int y = pos.Y - 1;

            while (y >= World.MinY && World.GetBlockOr(new Vec3<int>(pos.X, y, pos.Z), Block.Air).Air) {
                y--;
            }

            if (y >= World.MinY) {
                return new Vec3<int>(pos.X, y + 1, pos.Z);
            }

            y = pos.Y + 1;
            while (y < World.MaxY && World.GetBlockOr(new Vec3<int>(pos.X, y, pos.Z), Block.Air).Air) {
                y++;
            }

            pos = new Vec3<int>(pos.X, y, pos.Z);
        }

        if (!World.GetBlockOr(pos, Block.Air).Solid) {
            return pos;
        }

        int above = pos.Y + 1;
        while (above < World.MaxY && World.GetBlockOr(new Vec3<int>(pos.X, above, pos.Z), Block.Air).Solid) {
            above++;
        }

        return new Vec3<int>(pos.X, above, pos.Z);
    }

    protected override void TrimPath() {
        base.TrimPath();

        if (!AvoidSun || CurrentPath == null) {
            return;
        }

        // A mob already standing in the sun has nothing to gain from truncating, so the whole route
        // is left alone rather than being cut at its first node.
        if (World.CanSeeSky(new Vec3<double>(Mob.Position.X, Mob.Position.Y + 0.5, Mob.Position.Z).ToBlockPos())) {
            return;
        }

        for (int i = 0; i < CurrentPath.NodeCount; i++) {
            Node node = CurrentPath.GetNode(i);

            if (World.CanSeeSky(new Vec3<int>(node.X, node.Y, node.Z))) {
                CurrentPath.TruncateNodes(i);
                return;
            }
        }
    }
}
