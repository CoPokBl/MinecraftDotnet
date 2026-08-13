using ManagedServer.Entities.Types;
using ManagedServer.Fluids;
using ManagedServer.Physics;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Pathfinding;

/// <summary>
/// How a mob that walks sees the world, vanilla's <c>WalkNodeEvaluator</c>. The largest single class
/// in the pathfinder and the whole fidelity risk of it: everything about which routes exist is
/// decided here, and <see cref="PathFinder"/> merely searches whatever graph this describes.
/// <p/>
/// Three things about it are easy to read past and each one changes where mobs can go:
/// <list type="bullet">
/// <item>A candidate is rejected on its <b>malus being negative</b>, never on the block being solid.
/// That is why <c>Mob.SetPathfindingMalus</c> is enough to make a mob walk through fire, and why a
/// wrong sign in the malus table turns a wall into a door.</item>
/// <item>The classification is of the <b>whole space the mob occupies</b>
/// (<see cref="GetPathTypeWithinMobBB"/>), not of one block. A two block wide mob is refused a gap a
/// one block wide mob walks through, without either of them consulting a hitbox.</item>
/// <item>A node's height is the <b>top of the block below it</b> (<see cref="GetFloorLevel"/>), not
/// its own y. Everything about steps and jumps is a comparison of two of those.</item>
/// </list>
/// <b>The classification is pinned by <c>Conformance/pathtype.sh</c></b>, because a wrong rule here
/// is one our own tests would encode too. See <see cref="BlockPathData"/>.
/// </summary>
public class WalkNodeEvaluator : NodeEvaluator {
    /// <summary>
    /// How high a mob is assumed to be able to jump when its step height says less, vanilla's
    /// <c>DEFAULT_MOB_JUMP_HEIGHT</c>. Slightly over one block, which is what makes a full block step
    /// reachable when a 0.6 step height alone would not.
    /// </summary>
    private const double DefaultMobJumpHeight = 1.125;

    /// <summary>
    /// The classification of each position for this mob, for the length of one search. Distinct from
    /// the world's <see cref="PathTypeCache"/>, which holds the per block half: this one has the
    /// mob's own answers folded in, so it cannot be shared between mobs.
    /// </summary>
    private readonly Dictionary<long, PathType> _pathTypesByPos = [];

    private readonly Dictionary<Box, bool> _collisionCache = [];

    /// <summary>One slot per horizontal direction, reused so the diagonal pass can look them up.</summary>
    private readonly Node?[] _reusableNeighbors = new Node?[4];

    /// <summary>
    /// The four horizontal directions in vanilla's <c>Direction.get2DDataValue</c> order: south,
    /// west, north, east. That order is not cosmetic, it is what indexes
    /// <see cref="_reusableNeighbors"/> and what makes <see cref="ClockwiseOf"/> a plain increment.
    /// </summary>
    private static readonly (int X, int Z)[] Horizontal = [(0, 1), (-1, 0), (0, -1), (1, 0)];

    /// <summary>
    /// The order <c>Direction.Plane.HORIZONTAL</c> hands them out, as indices into
    /// <see cref="Horizontal"/>: north, south, west, east. Distinct from the 2D data order above and
    /// worth keeping, because it decides the order neighbours enter the open set and so which of two
    /// equally good routes a mob picks.
    /// </summary>
    private static readonly int[] HorizontalOrder = [2, 0, 1, 3];

    public override void Prepare(World world, Mob mob) {
        base.Prepare(world, mob);
        mob.OnPathfindingStart();
    }

    public override void Done() {
        Mob.OnPathfindingDone();
        _pathTypesByPos.Clear();
        _collisionCache.Clear();
        base.Done();
    }

    #region start and target

    public override Node? GetStart() {
        int startY = Mth.Floor(Mob.Position.Y);
        IBlock block = Context.GetBlock(Mth.Floor(Mob.Position.X), startY, Mth.Floor(Mob.Position.Z));

        if (Mob.CanStandOnFluid(FluidKindOf(block))) {
            // Standing on top of a fluid: climb out of it and take the block below the surface.
            while (Mob.CanStandOnFluid(FluidKindOf(block))) {
                block = Context.GetBlock(Mth.Floor(Mob.Position.X), ++startY, Mth.Floor(Mob.Position.Z));
            }

            startY--;
        }
        else if (CanFloat && IsInWater()) {
            // Floating: rise to the surface, then take the block under it.
            while (IsWaterSurface(block)) {
                block = Context.GetBlock(Mth.Floor(Mob.Position.X), ++startY, Mth.Floor(Mob.Position.Z));
            }

            startY--;
        }
        else if (Mob.OnGround) {
            // The half block bias matters: a mob whose feet are a hair below a block boundary starts
            // from the block it is standing on rather than the one its toes are in.
            startY = Mth.Floor(Mob.Position.Y + 0.5);
        }
        else {
            // Airborne, so fall to whatever is under it and start there.
            int y = Mth.Floor(Mob.Position.Y + 1.0);
            while (y > Context.World.MinY) {
                startY = y;
                y--;

                uint below = Context.GetBlockStateId(Mth.Floor(Mob.Position.X), y, Mth.Floor(Mob.Position.Z));
                IBlock belowBlock = BlockAt(below);
                if (!belowBlock.Air && !belowBlock.PathfindableLand) {
                    break;
                }
            }
        }

        Vec3<int> startPos = Mob.Position.ToBlockPos();

        if (!CanStartAt(startPos.X, startY, startPos.Z)) {
            // The block under the mob's centre is no good, so try the four corners of its box: a mob
            // shoved half into a wall still has somewhere to start from.
            Box box = new Box(Mob.BoundingBox).Translate(Mob.Position);

            foreach ((double x, double z) in new[] {
                         (box.MinX, box.MinZ), (box.MinX, box.MaxZ),
                         (box.MaxX, box.MinZ), (box.MaxX, box.MaxZ)
                     }) {
                if (CanStartAt(Mth.Floor(x), startY, Mth.Floor(z))) {
                    return GetStartNode(Mth.Floor(x), startY, Mth.Floor(z));
                }
            }
        }

        return GetStartNode(startPos.X, startY, startPos.Z);
    }

    protected Node GetStartNode(int x, int y, int z) {
        Node node = GetNode(x, y, z);
        node.Type = GetCachedPathType(node.X, node.Y, node.Z);
        node.CostMalus = Mob.GetPathfindingMalus(node.Type);
        return node;
    }

    /// <summary>
    /// Whether a position is somewhere a search can begin. Open air is refused even though it costs
    /// nothing, because starting in mid air means the fall handling above did not find ground.
    /// </summary>
    protected bool CanStartAt(int x, int y, int z) {
        PathType type = GetCachedPathType(x, y, z);
        return type != PathType.Open && Mob.GetPathfindingMalus(type) >= 0.0f;
    }

    public override PathTarget GetTarget(double x, double y, double z) {
        return GetTargetNodeAt(x, y, z);
    }

    #endregion

    #region neighbours

    public override int GetNeighbors(Node[] neighbors, Node from) {
        int found = 0;
        int jumpSize = 0;

        PathType above = GetCachedPathType(from.X, from.Y + 1, from.Z);
        PathType current = GetCachedPathType(from.X, from.Y, from.Z);

        // Honey is the exception: a mob standing in it cannot jump at all, whatever its step height.
        if (Mob.GetPathfindingMalus(above) >= 0.0f && current != PathType.StickyHoney) {
            jumpSize = Mth.Floor(Math.Max(1.0f, Mob.MaxUpStep));
        }

        double floor = GetFloorLevel(from.X, from.Y, from.Z);

        foreach (int direction in HorizontalOrder) {
            (int stepX, int stepZ) = Horizontal[direction];
            Node? node = FindAcceptedNode(from.X + stepX, from.Y, from.Z + stepZ, jumpSize, floor,
                stepX, stepZ, current);

            _reusableNeighbors[direction] = node;

            if (IsNeighborValid(node, from)) {
                neighbors[found++] = node!;
            }
        }

        // Diagonals come second and only where both of their cardinal halves worked out, which is
        // what stops a mob cutting the corner of a wall.
        foreach (int direction in HorizontalOrder) {
            int clockwise = ClockwiseOf(direction);
            if (!IsDiagonalValid(from, _reusableNeighbors[direction], _reusableNeighbors[clockwise])) {
                continue;
            }

            (int stepX, int stepZ) = Horizontal[direction];
            (int nextX, int nextZ) = Horizontal[clockwise];

            Node? diagonal = FindAcceptedNode(from.X + stepX + nextX, from.Y, from.Z + stepZ + nextZ,
                jumpSize, floor, stepX, stepZ, current);

            if (IsDiagonalValid(diagonal)) {
                neighbors[found++] = diagonal!;
            }
        }

        return found;
    }

    /// <summary>
    /// Vanilla's <c>Direction.getClockWise</c> over the 2D data order. North, east, south, west is
    /// already clockwise, so this is the next index round.
    /// </summary>
    private static int ClockwiseOf(int direction) {
        return (direction + 1) & 3;
    }

    /// <summary>
    /// Whether a neighbour is usable. The second half of the cost test is the odd one: a neighbour
    /// with a negative malus is still accepted when the node being expanded also has one, so a mob
    /// that starts inside something impassable can walk its way out rather than being stuck.
    /// </summary>
    protected bool IsNeighborValid(Node? neighbor, Node current) {
        return neighbor != null && !neighbor.Closed &&
               (neighbor.CostMalus >= 0.0f || current.CostMalus < 0.0f);
    }

    /// <summary>
    /// Whether the two cardinal neighbours a diagonal sits between allow it. Both must be no higher
    /// than the node being expanded, so a diagonal never climbs; a wide mob is refused one whenever
    /// either half costs anything at all; and a mob under half a block wide is allowed to slip
    /// between two fence posts, which is the one case where an impassable pair still permits the
    /// diagonal.
    /// </summary>
    protected bool IsDiagonalValid(Node from, Node? ew, Node? ns) {
        if (ns == null || ew == null || ns.Y > from.Y || ew.Y > from.Y) {
            return false;
        }

        if (ew.Type == PathType.WalkableDoor || ns.Type == PathType.WalkableDoor) {
            return false;
        }

        if (Mob.BbWidth > 1.0f && (ew.CostMalus > 0.0f || ns.CostMalus > 0.0f)) {
            return false;
        }

        bool canPassBetweenPosts = ns.Type == PathType.Fence && ew.Type == PathType.Fence &&
                                   Mob.BbWidth < 0.5;

        return (ns.Y < from.Y || ns.CostMalus >= 0.0f || canPassBetweenPosts) &&
               (ew.Y < from.Y || ew.CostMalus >= 0.0f || canPassBetweenPosts);
    }

    protected bool IsDiagonalValid(Node? diagonal) {
        if (diagonal == null || diagonal.Closed) {
            return false;
        }

        return diagonal.Type != PathType.WalkableDoor && diagonal.CostMalus >= 0.0f;
    }

    #endregion

    #region candidate resolution

    /// <summary>
    /// The types whose shape only partly fills their block, so a mob can be refused by geometry even
    /// when the classification allows the move.
    /// </summary>
    private static bool DoesBlockHavePartialCollision(PathType type) {
        return type is PathType.Fence or PathType.DoorWoodClosed or PathType.DoorIronClosed;
    }

    /// <summary>
    /// What the mob can actually reach by stepping to a position, or null for nothing. This is the
    /// method that turns a classification into a route: the walkable case falls straight through,
    /// and everything else is one of four recoveries, tried in vanilla's order.
    /// </summary>
    protected Node? FindAcceptedNode(int x, int y, int z, int jumpSize, double nodeHeight,
        int travelX, int travelZ, PathType currentType) {
        Node? best = null;

        // Too high to get onto, before anything else is considered.
        double floorAtTarget = GetFloorLevel(x, y, z);
        if (floorAtTarget - nodeHeight > MobJumpHeight()) {
            return null;
        }

        PathType type = GetCachedPathType(x, y, z);
        float cost = Mob.GetPathfindingMalus(type);

        if (cost >= 0.0f) {
            best = GetNodeAndUpdateCostToMax(x, y, z, type, cost);
        }

        // Leaving a fence or a closed door is a squeeze, so the move is checked against real
        // collision rather than against the classification alone.
        if (DoesBlockHavePartialCollision(currentType) && best is { CostMalus: >= 0.0f } &&
            !CanReachWithoutCollision(best)) {
            best = null;
        }

        // Walkable is the whole point and needs no recovery. Water is the same for an amphibious
        // mob, which swims through it rather than looking for a way round.
        if (type == PathType.Walkable || (IsAmphibious && type == PathType.Water)) {
            return best;
        }

        if ((best == null || best.CostMalus < 0.0f) && jumpSize > 0 &&
            (type != PathType.Fence || CanWalkOverFences) &&
            type != PathType.UnpassableRail && type != PathType.Trapdoor && type != PathType.PowderSnow) {
            best = TryJumpOn(x, y, z, jumpSize, nodeHeight, travelX, travelZ, currentType);
        }
        else if (!IsAmphibious && type == PathType.Water && !CanFloat) {
            best = TryFindFirstNonWaterBelow(x, y, z, best);
        }
        else if (type == PathType.Open) {
            best = TryFindFirstGroundNodeBelow(x, y, z);
        }
        else if (DoesBlockHavePartialCollision(type) && best == null) {
            // A closed node still exists, so the diagonal test can see the fence that is there. It
            // is never walked through, because it is created already closed.
            best = GetClosedNode(x, y, z, type);
        }

        return best;
    }

    /// <summary>
    /// How high the mob is treated as able to get, <c>getMobJumpHeight</c>. Never less than
    /// <see cref="DefaultMobJumpHeight"/>, so a mob with a small step height can still be routed onto
    /// a full block.
    /// </summary>
    private double MobJumpHeight() {
        return Math.Max(DefaultMobJumpHeight, Mob.MaxUpStep);
    }

    /// <summary>
    /// A node with the higher of its existing malus and this one. The max matters because one
    /// position can be reached as several candidates in a single expansion, and vanilla keeps the
    /// worst of them.
    /// </summary>
    private Node GetNodeAndUpdateCostToMax(int x, int y, int z, PathType type, float cost) {
        Node node = GetNode(x, y, z);
        node.Type = type;
        node.CostMalus = Math.Max(node.CostMalus, cost);
        return node;
    }

    private Node GetBlockedNode(int x, int y, int z) {
        Node node = GetNode(x, y, z);
        node.Type = PathType.Blocked;
        node.CostMalus = -1.0f;
        return node;
    }

    private Node GetClosedNode(int x, int y, int z, PathType type) {
        Node node = GetNode(x, y, z);
        node.Closed = true;
        node.Type = type;
        node.CostMalus = PathTypeMalus.Of(type);
        return node;
    }

    /// <summary>
    /// Climbing, <c>tryJumpOn</c>. Recurses upwards one block at a time, spending a jump each time,
    /// then checks that the mob would actually fit through the gap it is jumping into.
    /// <p/>
    /// The box it checks is not around the destination: it spans from the floor above the block the
    /// mob came <b>from</b> up to the mob's height above the destination floor, which is the column
    /// the mob's head passes through on the way. The two epsilons keep it off the surfaces at either
    /// end.
    /// </summary>
    private Node? TryJumpOn(int x, int y, int z, int jumpSize, double nodeHeight,
        int travelX, int travelZ, PathType currentType) {
        Node? above = FindAcceptedNode(x, y + 1, z, jumpSize - 1, nodeHeight, travelX, travelZ, currentType);

        if (above == null) {
            return null;
        }

        // A mob a block wide or more is not squeezed through anything, so the geometry check is
        // skipped entirely for it.
        if (Mob.BbWidth >= 1.0f) {
            return above;
        }

        if (above.Type != PathType.Open && above.Type != PathType.Walkable) {
            return above;
        }

        double centerX = x - travelX + 0.5;
        double centerZ = z - travelZ + 0.5;
        double halfWidth = Mob.BbWidth / 2.0;

        Box gap = new(
            centerX - halfWidth,
            GetFloorLevel(Mth.Floor(centerX), y + 1, Mth.Floor(centerZ)) + 0.001,
            centerZ - halfWidth,
            centerX + halfWidth,
            Mob.BbHeight + GetFloorLevel(above.X, above.Y, above.Z) - 0.002,
            centerZ + halfWidth);

        return HasCollisions(gap) ? null : above;
    }

    /// <summary>
    /// Sinking, for a mob that cannot swim: follow the water down and take the last watery node, so
    /// the search plans a walk along the bottom rather than refusing the pool.
    /// </summary>
    private Node? TryFindFirstNonWaterBelow(int x, int y, int z, Node? best) {
        y--;

        while (y > Context.World.MinY) {
            PathType type = GetCachedPathType(x, y, z);
            if (type != PathType.Water) {
                return best;
            }

            best = GetNodeAndUpdateCostToMax(x, y, z, type, Mob.GetPathfindingMalus(type));
            y--;
        }

        return best;
    }

    /// <summary>
    /// Dropping, <c>tryFindFirstGroundNodeBelow</c>. Falls through open air to the first thing that
    /// is not, and refuses the whole move if the drop is further than the mob is willing to fall.
    /// <p/>
    /// The fall limit is checked <b>before</b> the block is classified, so a safe landing further
    /// down than the limit is still refused.
    /// </summary>
    private Node TryFindFirstGroundNodeBelow(int x, int y, int z) {
        for (int currentY = y - 1; currentY >= Context.World.MinY; currentY--) {
            if (y - currentY > Mob.MaxFallDistance) {
                return GetBlockedNode(x, currentY, z);
            }

            PathType type = GetCachedPathType(x, currentY, z);
            float cost = Mob.GetPathfindingMalus(type);

            if (type == PathType.Open) {
                continue;
            }

            return cost >= 0.0f
                ? GetNodeAndUpdateCostToMax(x, currentY, z, type, cost)
                : GetBlockedNode(x, currentY, z);
        }

        return GetBlockedNode(x, y, z);
    }

    #endregion

    #region geometry

    /// <summary>
    /// How high the surface at a position is, <c>getFloorLevel</c>: the top of the block
    /// <b>below</b> it, or that block's own y when it has no collision shape. This is the number
    /// every step and jump comparison is made on, and it is why a slab is a step and a full block is
    /// a jump.
    /// </summary>
    protected double GetFloorLevel(int x, int y, int z) {
        if (CanFloat || IsAmphibious) {
            IBlock here = Context.GetBlock(x, y, z);
            if (IsWater(here)) {
                return y + 0.5;
            }
        }

        return GetFloorLevel(Context, x, y, z);
    }

    /// <summary>The static half, which the navigation also uses to place a waypoint.</summary>
    public static double GetFloorLevel(PathfindingContext context, int x, int y, int z) {
        int belowY = y - 1;
        Box[] boxes = BlockPhysicsData.ShapeBoxesOf(context.GetBlock(x, belowY, z).CollisionShape);

        if (boxes.Length == 0) {
            return belowY;
        }

        double max = 0.0;
        foreach (Box box in boxes) {
            max = Math.Max(max, box.MaxY);
        }

        return belowY + max;
    }

    protected virtual bool IsAmphibious => false;

    /// <summary>
    /// Whether the mob could walk from where it is to a node without hitting anything, stepping its
    /// own box along the line. Used only for leaving a fence or closed door, which is the one place
    /// the classification is not enough.
    /// </summary>
    private bool CanReachWithoutCollision(Node to) {
        Box box = new Box(Mob.BoundingBox).Translate(Mob.Position);

        double sizeX = box.MaxX - box.MinX;
        double sizeY = box.MaxY - box.MinY;
        double sizeZ = box.MaxZ - box.MinZ;

        Vec3<double> delta = new(
            to.X - Mob.Position.X + sizeX / 2.0,
            to.Y - Mob.Position.Y + sizeY / 2.0,
            to.Z - Mob.Position.Z + sizeZ / 2.0);

        // Stepped by the box's largest dimension, so no step can jump over an obstacle thinner than
        // the mob.
        double size = Math.Max(sizeX, Math.Max(sizeY, sizeZ));
        double length = Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y + delta.Z * delta.Z);
        int steps = Mth.Ceil(length / size);

        if (steps <= 0) {
            return true;
        }

        delta = new Vec3<double>(delta.X / steps, delta.Y / steps, delta.Z / steps);

        for (int i = 1; i <= steps; i++) {
            box = box.Translate(delta);
            if (HasCollisions(box)) {
                return false;
            }
        }

        return true;
    }

    private bool HasCollisions(Box box) {
        if (_collisionCache.TryGetValue(box, out bool cached)) {
            return cached;
        }

        bool collides = EntityPhysics.HasBlockCollision(Context.World, box);
        _collisionCache[box] = collides;
        return collides;
    }

    #endregion

    #region classification

    protected PathType GetCachedPathType(int x, int y, int z) {
        long key = ((long)x & 0x3FFFFFF) << 38 | ((long)z & 0x3FFFFFF) << 12 | ((long)y & 0xFFF);

        if (_pathTypesByPos.TryGetValue(key, out PathType cached)) {
            return cached;
        }

        PathType computed = GetPathTypeOfMob(Context, x, y, z, Mob);
        _pathTypesByPos[key] = computed;
        return computed;
    }

    /// <summary>
    /// What a position means to this mob, given the whole space it would occupy. The arbitration is
    /// the interesting part: a fence anywhere in the box wins outright, then an unpassable rail,
    /// then the <b>first impassable</b> type found (not the worst), and only after that the most
    /// expensive passable one.
    /// </summary>
    public override PathType GetPathTypeOfMob(PathfindingContext context, int x, int y, int z, Mob mob) {
        PathTypeSet types = GetPathTypeWithinMobBB(context, x, y, z);

        if (types.Count == 1) {
            return types.Single;
        }

        if (types.Contains(PathType.Fence)) {
            return PathType.Fence;
        }

        if (types.Contains(PathType.UnpassableRail)) {
            return PathType.UnpassableRail;
        }

        PathType highestMalusType = PathType.Blocked;
        float highestMalus = mob.GetPathfindingMalus(highestMalusType);

        foreach (PathType type in types) {
            float malus = mob.GetPathfindingMalus(type);

            if (malus < 0.0f) {
                return type;
            }

            if (malus >= highestMalus) {
                highestMalus = malus;
                highestMalusType = type;
            }
        }

        PathType currentNodeType = GetPathType(context, x, y, z);

        if (EntityWidth > 1) {
            // A big mob near something dangerous gets a type of its own, so the danger is priced in
            // without the whole square being refused.
            bool currentIsCheaper = mob.GetPathfindingMalus(currentNodeType) < highestMalus;
            bool capMalus = currentIsCheaper &&
                            mob.GetPathfindingMalus(PathType.BigMobsCloseToDanger) < highestMalus;
            return capMalus ? PathType.BigMobsCloseToDanger : highestMalusType;
        }

        // A free square whose box also contains something free stays open, which is what stops a
        // small mob being told it is standing on whatever happens to be beside its feet.
        return currentNodeType == PathType.Open && highestMalusType != PathType.Open && highestMalus == 0.0f
            ? PathType.Open
            : highestMalusType;
    }

    /// <summary>
    /// Every kind of block inside the space the mob would occupy, with the three per mob rewrites
    /// vanilla applies as it goes: a closed wooden door becomes walkable for a mob that can open
    /// doors, an open door becomes blocked for one that cannot pass them, and a rail becomes
    /// unpassable unless the mob is already on one.
    /// <p/>
    /// The set iterates in declaration order rather than insertion order, which the arbitration
    /// above depends on: see <see cref="PathTypeSet"/>.
    /// </summary>
    public PathTypeSet GetPathTypeWithinMobBB(PathfindingContext context, int x, int y, int z) {
        PathTypeSet types = new();

        for (int dx = 0; dx < EntityWidth; dx++) {
            for (int dy = 0; dy < EntityHeight; dy++) {
                for (int dz = 0; dz < EntityDepth; dz++) {
                    PathType type = GetPathType(context, dx + x, dy + y, dz + z);
                    Vec3<int> mobPos = context.MobPosition;

                    if (type == PathType.DoorWoodClosed && CanOpenDoors && CanPassDoors) {
                        type = PathType.WalkableDoor;
                    }

                    if (type == PathType.DoorOpen && !CanPassDoors) {
                        type = PathType.Blocked;
                    }

                    if (type == PathType.Rail &&
                        GetPathType(context, mobPos.X, mobPos.Y, mobPos.Z) != PathType.Rail &&
                        GetPathType(context, mobPos.X, mobPos.Y - 1, mobPos.Z) != PathType.Rail) {
                        type = PathType.UnpassableRail;
                    }

                    types.Add(type);
                }
            }
        }

        return types;
    }

    public override PathType GetPathType(PathfindingContext context, int x, int y, int z) {
        return GetPathTypeStatic(context, x, y, z);
    }

    /// <summary>
    /// What a square means with what is under it taken into account, <c>getPathTypeStatic</c>.
    /// <p/>
    /// Open air is not walkable by itself: the answer for an open square is decided by the block
    /// below. Standing on lava reads as open, standing on fire reads as fire, and standing on
    /// anything solid falls through to <see cref="CheckNeighbourBlocks"/>.
    /// </summary>
    public static PathType GetPathTypeStatic(PathfindingContext context, int x, int y, int z) {
        PathType type = context.GetPathTypeFromState(x, y, z);

        if (type != PathType.Open || y < context.World.MinY + 1) {
            return type;
        }

        return context.GetPathTypeFromState(x, y - 1, z) switch {
            PathType.Open or PathType.Water or PathType.Lava or PathType.Walkable => PathType.Open,
            PathType.Fire => PathType.Fire,
            PathType.Damaging => PathType.Damaging,
            PathType.StickyHoney => PathType.StickyHoney,
            PathType.PowderSnow => PathType.OnTopOfPowderSnow,
            PathType.DamageCautious => PathType.DamageCautious,
            PathType.Trapdoor => PathType.OnTopOfTrapdoor,
            _ => CheckNeighbourBlocks(context, x, y, z, PathType.Walkable)
        };
    }

    /// <summary>
    /// Whether anything unpleasant is next to a square, <c>checkNeighbourBlocks</c>.
    /// <p/>
    /// The loop deliberately skips the two positions with <c>dx == 0 &amp;&amp; dz == 0</c>, so the
    /// block directly above and directly below are <b>not</b> neighbours: 24 positions, not 26. A
    /// port that scans the full cube makes mobs refuse to stand on a fire they are already safely
    /// above.
    /// </summary>
    public static PathType CheckNeighbourBlocks(PathfindingContext context, int x, int y, int z, PathType fallback) {
        for (int dx = -1; dx <= 1; dx++) {
            for (int dy = -1; dy <= 1; dy++) {
                for (int dz = -1; dz <= 1; dz++) {
                    if (dx == 0 && dz == 0) {
                        continue;
                    }

                    switch (context.GetPathTypeFromState(x + dx, y + dy, z + dz)) {
                        case PathType.Damaging:
                            return PathType.DamagingInNeighbor;
                        case PathType.Fire:
                        case PathType.Lava:
                            return PathType.FireInNeighbor;
                        case PathType.Water:
                            return PathType.WaterBorder;
                        case PathType.DamageCautious:
                            return PathType.DamageCautious;
                    }
                }
            }
        }

        return fallback;
    }

    #endregion

    #region fluids

    private bool IsInWater() {
        return EntityFluids.IsIn(Context.World, Mob, FluidKind.Water);
    }

    private static bool IsWater(IBlock block) {
        return block.Fluid is { } fluid &&
               (fluid.Equals("minecraft:water") || fluid.Equals("minecraft:flowing_water"));
    }

    /// <summary>
    /// What the surface climb in <see cref="GetStart"/> keeps rising through. Vanilla's test is two
    /// clauses: the block <b>is</b> water, whatever its level, <b>or</b> its fluid is a water source,
    /// which is what carries a waterlogged block. Flowing water in a waterlogged block ends the
    /// climb; a full source in one does not.
    /// <p/>
    /// A source reads as <c>minecraft:water</c> and a flowing one as <c>minecraft:flowing_water</c>,
    /// which is the distinction vanilla's <c>Fluids.WATER.getSource(false)</c> comparison makes.
    /// </summary>
    private static bool IsWaterSurface(IBlock block) {
        return block.Identifier.Equals("minecraft:water") ||
               (block.Fluid is { } fluid && fluid.Equals("minecraft:water"));
    }

    private static FluidKind FluidKindOf(IBlock block) {
        if (block.Fluid is not { } fluid) {
            return FluidKind.Empty;
        }

        if (fluid.Equals("minecraft:water") || fluid.Equals("minecraft:flowing_water")) {
            return FluidKind.Water;
        }

        return fluid.Equals("minecraft:lava") || fluid.Equals("minecraft:flowing_lava")
            ? FluidKind.Lava
            : FluidKind.Empty;
    }

    private IBlock BlockAt(uint stateId) {
        return Context.World.Server.Registry.Blocks.StatesByStateId.TryGetValue(stateId, out IBlock? block)
            ? block.WithState(stateId)
            : Block.Air;
    }

    #endregion
}
