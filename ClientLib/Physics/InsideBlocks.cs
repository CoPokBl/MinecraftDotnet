using ClientLib.Maths;
using ClientLib.World;
using Minecraft.Data.Generated;
using Minecraft.Data.Generated.BlockTypes;
using Minecraft.Physics;
using Minecraft.Schemas.Vec;

namespace ClientLib.Physics;

/// <summary>Vanilla's <c>MoverType</c>, in its declaration order.</summary>
public enum MoverType {
    Self,
    Player,
    Piston,
    ShulkerBox,
    Shulker
}

/// <summary><c>Entity.Movement</c>: one move of a tick, with the delta <c>move</c> was asked for when it came from there.</summary>
public readonly record struct EntityMovement(Vec3d From, Vec3d To, Vec3d? AxisDependentOriginalMovement = null);

/// <summary><c>Entity.movementThisTick</c> and <c>finalMovementsThisTick</c>: the moves the blocks of a tick are looked for along.</summary>
public sealed class TickMovements {
    private readonly List<EntityMovement> _thisTick = [];

    /// <summary>The moves the last <see cref="TakeFinal"/> handed out, which <c>applyEffectsFromBlocksForLastMovements</c> reuses.</summary>
    public List<EntityMovement> Final { get; } = [];

    /// <summary><c>Entity.addMovementThisTick</c>.</summary>
    public void Add(EntityMovement movement) {
        if (_thisTick.Count >= 100) {
            EntityMovement first = _thisTick[0];
            EntityMovement second = _thisTick[1];
            _thisTick.RemoveRange(0, 2);
            _thisTick.Insert(0, new EntityMovement(first.From, second.To));
        }
        _thisTick.Add(movement);
    }

    /// <summary><c>Entity.removeLatestMovementRecording</c>.</summary>
    public void RemoveLatest() {
        if (_thisTick.Count > 0) {
            _thisTick.RemoveAt(_thisTick.Count - 1);
        }
    }

    /// <summary><c>Entity.applyEffectsFromBlocks</c>'s list: the tick's moves, and on to wherever the entity is now.</summary>
    public List<EntityMovement> TakeFinal(Vec3d oldPosition, Vec3d position) {
        Final.Clear();
        Final.AddRange(_thisTick);
        _thisTick.Clear();
        if (Final.Count == 0) {
            Final.Add(new EntityMovement(oldPosition, position));
        }
        else if (Final[^1].To.DistanceToSqr(position) > 9.9999994E-11F) {
            Final.Add(new EntityMovement(Final[^1].To, position));
        }
        return Final;
    }
}

/// <summary><c>Entity.limitPistonMovement</c>: pistons move an entity at most 0.51 along each axis in a game tick.</summary>
public sealed class PistonMovementLimit {
    private readonly double[] _pistonDeltas = new double[3];
    private long _pistonDeltasGameTime;

    public Vec3d Limit(Vec3d vec, long currentGameTime) {
        if (vec.LengthSqr() <= 1.0E-7) {
            return vec;
        }
        if (currentGameTime != _pistonDeltasGameTime) {
            Array.Clear(_pistonDeltas);
            _pistonDeltasGameTime = currentGameTime;
        }
        if (vec.X != 0.0) {
            double xa = ApplyPistonMovementRestriction(0, vec.X);
            return Math.Abs(xa) <= 1.0E-5F ? Vec3d.Zero : new Vec3d(xa, 0.0, 0.0);
        }
        if (vec.Y != 0.0) {
            double ya = ApplyPistonMovementRestriction(1, vec.Y);
            return Math.Abs(ya) <= 1.0E-5F ? Vec3d.Zero : new Vec3d(0.0, ya, 0.0);
        }
        if (vec.Z != 0.0) {
            double za = ApplyPistonMovementRestriction(2, vec.Z);
            return Math.Abs(za) <= 1.0E-5F ? Vec3d.Zero : new Vec3d(0.0, 0.0, za);
        }
        return Vec3d.Zero;
    }

    private double ApplyPistonMovementRestriction(int axis, double amount) {
        double min = Math.Clamp(amount + _pistonDeltas[axis], -0.51, 0.51);
        amount = min - _pistonDeltas[axis];
        _pistonDeltas[axis] = min;
        return amount;
    }
}

/// <summary>
/// <c>Entity.checkInsideBlocks</c> and the <c>BlockGetter.forEachBlockIntersectedBetween</c> walk under it:
/// every block the box passed through during the tick's moves, in the order it reached them.
/// </summary>
public static class InsideBlocks {
    /// <summary>A block the box went into, once per check.</summary>
    /// <param name="step">The step along the move, which <c>InsideBlockEffectApplier.StepBasedCollector</c> orders effects by.</param>
    /// <param name="insideBlock">The box crossed the block's <c>getEntityInsideCollisionShape</c>.</param>
    /// <param name="insideFluid"><c>collidedWithFluid</c>: the box crossed the block's fluid.</param>
    public delegate void Visitor(int x, int y, int z, uint state, int step, bool insideBlock, bool insideFluid, bool isPrecise);

    /// <summary>
    /// <c>getEntityInsideCollisionShape</c> in the block's own coordinates, or null for the full block every
    /// block but cauldrons, tripwire, end portals and powder snow has.
    /// </summary>
    public delegate Box[]? InsideShape(int x, int y, int z, uint state);

    /// <summary>
    /// <c>getEntityInsideCollisionShape</c> of a cauldron, its walls and its contents up to their surface, or null
    /// for any other block.
    /// </summary>
    public static Box[]? CauldronShape(Minecraft.Data.Blocks.IBlock block) {
        double contentTop;
        if (BlockClasses.Is(block.Identifier, BlockClass.LavaCauldronBlock)) {
            contentTop = 15.0;
        }
        else if (BlockClasses.Is(block.Identifier, BlockClass.LayeredCauldronBlock)) {
            int level = block switch {
                WaterCauldronBlock water => water.Level,
                PowderSnowCauldronBlock snow => snow.Level,
                _ => 3
            };
            // LayeredCauldronBlock.getPixelContentHeight.
            contentTop = 6.0 + level * 3.0;
        }
        else {
            return null;
        }
        Box[] walls = BlockPhysicsData.ShapeBoxesOf(block.CollisionShape);
        return [..walls, new Box(2.0 / 16.0, 4.0 / 16.0, 2.0 / 16.0, 14.0 / 16.0, contentTop / 16.0, 14.0 / 16.0)];
    }

    [ThreadStatic] private static HashSet<(int, int, int)>? _visited;
    [ThreadStatic] private static HashSet<(int, int, int)>? _walked;

    /// <summary><c>Entity.checkInsideBlocks</c>.</summary>
    public static void Check(ClientLevel level, IReadOnlyList<EntityMovement> movements, Func<Vec3d, Box> makeBoundingBox, InsideShape insideShape,
        Visitor visitor) {
        HashSet<(int, int, int)> visited = _visited ??= [];
        visited.Clear();
        foreach (EntityMovement movement in movements) {
            Vec3d pos = movement.From;
            Vec3d delta = movement.To - movement.From;
            int maxMovementIterations = 16;
            if (movement.AxisDependentOriginalMovement is { } original && delta.LengthSqr() > 0.0) {
                // Direction.axisStepOrder: Y first, then the smaller of X and Z.
                bool zFirst = Math.Abs(original.X) < Math.Abs(original.Z);
                foreach (int axis in zFirst ? YZX : YXZ) {
                    double axisMove = axis == 0 ? delta.X : axis == 1 ? delta.Y : delta.Z;
                    if (axisMove != 0.0) {
                        Vec3d to = axis == 0 ? pos.Add(axisMove, 0.0, 0.0) : axis == 1 ? pos.Add(0.0, axisMove, 0.0) : pos.Add(0.0, 0.0, axisMove);
                        maxMovementIterations -= CheckBetween(level, pos, to, makeBoundingBox, insideShape, visitor, visited, maxMovementIterations);
                        pos = to;
                    }
                }
            }
            else {
                maxMovementIterations -= CheckBetween(level, movement.From, movement.To, makeBoundingBox, insideShape, visitor, visited, 16);
            }

            if (maxMovementIterations <= 0) {
                CheckBetween(level, movement.To, movement.To, makeBoundingBox, insideShape, visitor, visited, 1);
            }
        }
        visited.Clear();
    }

    private static readonly int[] YZX = [1, 2, 0];
    private static readonly int[] YXZ = [1, 0, 2];

    private static int CheckBetween(ClientLevel level, Vec3d from, Vec3d to, Func<Vec3d, Box> makeBoundingBox, InsideShape insideShape,
        Visitor visitor, HashSet<(int, int, int)> visited, int maxMovementIterations) {
        Box target = makeBoundingBox(to).Inflate(-1.0E-5F);
        bool movedFar = from.DistanceToSqr(to) > 0.9999900000002526 * 0.9999900000002526;
        int iterations = 0;
        ForEachBlockIntersectedBetween(from, to, target, (x, y, z, iteration) => {
            if (iteration >= maxMovementIterations) {
                return false;
            }
            iterations = iteration;
            uint state = level.GetState(x, y, z);
            if (level.IsAir(state)) {
                return true;
            }
            Box boxAtFrom = makeBoundingBox(from);
            bool insideBlock = insideShape(x, y, z, state) is not { } shape || CollidedWithShape(boxAtFrom, to - from, shape, x, y, z);
            bool insideFluid = CollidedWithFluid(level, state, x, y, z, boxAtFrom, to - from);
            if ((insideBlock || insideFluid) && visited.Add((x, y, z))) {
                bool isPrecise = movedFar || target.Intersects(new Box(x, y, z, x + 1.0, y + 1.0, z + 1.0));
                visitor(x, y, z, state, iteration, insideBlock, insideFluid, isPrecise);
            }
            return true;
        });
        return iterations + 1;
    }

    /// <summary><c>Entity.collidedWithShapeMovingFrom</c>.</summary>
    private static bool CollidedWithShape(Box boxAtFrom, Vec3d travel, Box[] shape, int x, int y, int z) {
        foreach (Box part in shape) {
            if (CollidedAlongVector(boxAtFrom, travel, part.Translate(x, y, z))) {
                return true;
            }
        }
        return false;
    }

    /// <summary><c>Entity.collidedWithFluid</c>: the box moving along the travel meets <c>FluidState.getAABB</c>.</summary>
    private static bool CollidedWithFluid(ClientLevel level, uint state, int x, int y, int z, Box boxAtFrom, Vec3d travel) {
        MovementBlocks.Entry entry = MovementBlocks.Get(level.Registry, state);
        if (entry.Fluid == FluidKind.Empty) {
            return false;
        }
        Box fluid = new(x, y, z, x + 1.0, y + FluidInteraction.FluidHeight(level, x, y, z, entry), z + 1.0);
        return CollidedAlongVector(boxAtFrom, travel, fluid);
    }

    /// <summary><c>AABB.collidedAlongVector</c> for one box.</summary>
    private static bool CollidedAlongVector(Box box, Vec3d vector, Box shapePart) {
        Vec3d from = new(Lerp(0.5, box.MinX, box.MaxX), Lerp(0.5, box.MinY, box.MaxY), Lerp(0.5, box.MinZ, box.MaxZ));
        Vec3d to = from + vector;
        Box inflated = shapePart.Inflate((box.MaxX - box.MinX) * 0.5 - 1.0E-7, (box.MaxY - box.MinY) * 0.5 - 1.0E-7, (box.MaxZ - box.MinZ) * 0.5 - 1.0E-7);
        if (Contains(inflated, to) || Contains(inflated, from)) {
            return true;
        }
        return BlockClip.ClipAabb(inflated, new Vec3<double>(from.X, from.Y, from.Z), new Vec3<double>(to.X, to.Y, to.Z)) != null;
    }

    private static bool Contains(Box box, Vec3d point) =>
        point.X >= box.MinX && point.X < box.MaxX && point.Y >= box.MinY && point.Y < box.MaxY && point.Z >= box.MinZ && point.Z < box.MaxZ;

    private static double Lerp(double alpha, double from, double to) => from + alpha * (to - from);

    private delegate bool StepVisitor(int x, int y, int z, int iteration);

    /// <summary><c>BlockGetter.forEachBlockIntersectedBetween</c>.</summary>
    private static bool ForEachBlockIntersectedBetween(Vec3d from, Vec3d to, Box aabbAtTarget, StepVisitor visitor) {
        Vec3d travel = to - from;
        if (travel.LengthSqr() < 1.0E-5F * 1.0E-5F) {
            // BlockPos.betweenClosed: X fastest, then Y, then Z.
            int x0 = Floor(aabbAtTarget.MinX), y0 = Floor(aabbAtTarget.MinY), z0 = Floor(aabbAtTarget.MinZ);
            int x1 = Floor(aabbAtTarget.MaxX), y1 = Floor(aabbAtTarget.MaxY), z1 = Floor(aabbAtTarget.MaxZ);
            for (int z = z0; z <= z1; z++) {
                for (int y = y0; y <= y1; y++) {
                    for (int x = x0; x <= x1; x++) {
                        if (!visitor(x, y, z, 0)) {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        HashSet<(int, int, int)> visitedBlocks = _walked ??= [];
        visitedBlocks.Clear();
        Box atStart = aabbAtTarget.Translate(-travel.X, -travel.Y, -travel.Z);
        bool completed = BetweenCornersInDirection(Floor(atStart.MinX), Floor(atStart.MinY), Floor(atStart.MinZ),
            Floor(atStart.MaxX), Floor(atStart.MaxY), Floor(atStart.MaxZ), travel, (x, y, z) => {
                if (!visitor(x, y, z, 0)) {
                    return false;
                }
                visitedBlocks.Add((x, y, z));
                return true;
            });
        if (!completed) {
            return false;
        }

        int iterations = AddCollisionsAlongTravel(visitedBlocks, travel, aabbAtTarget, visitor);
        if (iterations < 0) {
            return false;
        }

        return BetweenCornersInDirection(Floor(aabbAtTarget.MinX), Floor(aabbAtTarget.MinY), Floor(aabbAtTarget.MinZ),
            Floor(aabbAtTarget.MaxX), Floor(aabbAtTarget.MaxY), Floor(aabbAtTarget.MaxZ), travel,
            (x, y, z) => !visitedBlocks.Add((x, y, z)) || visitor(x, y, z, iterations + 1));
    }

    private static int AddCollisionsAlongTravel(HashSet<(int, int, int)> visitedBlocks, Vec3d deltaMove, Box aabbAtTarget, StepVisitor visitor) {
        double boxSizeX = aabbAtTarget.MaxX - aabbAtTarget.MinX;
        double boxSizeY = aabbAtTarget.MaxY - aabbAtTarget.MinY;
        double boxSizeZ = aabbAtTarget.MaxZ - aabbAtTarget.MinZ;
        (int cornerX, int cornerY, int cornerZ) = FurthestCorner(deltaMove);
        Vec3d toCenter = new(Lerp(0.5, aabbAtTarget.MinX, aabbAtTarget.MaxX), Lerp(0.5, aabbAtTarget.MinY, aabbAtTarget.MaxY),
            Lerp(0.5, aabbAtTarget.MinZ, aabbAtTarget.MaxZ));
        Vec3d toCorner = new(toCenter.X + boxSizeX * 0.5 * cornerX, toCenter.Y + boxSizeY * 0.5 * cornerY, toCenter.Z + boxSizeZ * 0.5 * cornerZ);
        Vec3d fromCorner = toCorner - deltaMove;
        int blockX = Floor(fromCorner.X);
        int blockY = Floor(fromCorner.Y);
        int blockZ = Floor(fromCorner.Z);
        int signX = Math.Sign(deltaMove.X);
        int signY = Math.Sign(deltaMove.Y);
        int signZ = Math.Sign(deltaMove.Z);
        double tDeltaX = signX == 0 ? double.MaxValue : signX / deltaMove.X;
        double tDeltaY = signY == 0 ? double.MaxValue : signY / deltaMove.Y;
        double tDeltaZ = signZ == 0 ? double.MaxValue : signZ / deltaMove.Z;
        double tX = tDeltaX * (signX > 0 ? 1.0 - Frac(fromCorner.X) : Frac(fromCorner.X));
        double tY = tDeltaY * (signY > 0 ? 1.0 - Frac(fromCorner.Y) : Frac(fromCorner.Y));
        double tZ = tDeltaZ * (signZ > 0 ? 1.0 - Frac(fromCorner.Z) : Frac(fromCorner.Z));
        int iterations = 0;
        Vec3<double> clipFrom = new(fromCorner.X, fromCorner.Y, fromCorner.Z);
        Vec3<double> clipTo = new(toCorner.X, toCorner.Y, toCorner.Z);

        while (tX <= 1.0 || tY <= 1.0 || tZ <= 1.0) {
            if (tX < tY) {
                if (tX < tZ) {
                    blockX += signX;
                    tX += tDeltaX;
                }
                else {
                    blockZ += signZ;
                    tZ += tDeltaZ;
                }
            }
            else if (tY < tZ) {
                blockY += signY;
                tY += tDeltaY;
            }
            else {
                blockZ += signZ;
                tZ += tDeltaZ;
            }

            if (BlockClip.ClipAabb(new Box(blockX, blockY, blockZ, blockX + 1, blockY + 1, blockZ + 1), clipFrom, clipTo) is not { } hit) {
                continue;
            }
            iterations++;
            double hitX = fromCorner.X + hit.Scale * (toCorner.X - fromCorner.X);
            double hitY = fromCorner.Y + hit.Scale * (toCorner.Y - fromCorner.Y);
            double hitZ = fromCorner.Z + hit.Scale * (toCorner.Z - fromCorner.Z);
            double cornerHitX = Math.Clamp(hitX, blockX + 1.0E-5F, blockX + 1.0 - 1.0E-5F);
            double cornerHitY = Math.Clamp(hitY, blockY + 1.0E-5F, blockY + 1.0 - 1.0E-5F);
            double cornerHitZ = Math.Clamp(hitZ, blockZ + 1.0E-5F, blockZ + 1.0 - 1.0E-5F);
            int oppositeX = Floor(cornerHitX - boxSizeX * cornerX);
            int oppositeY = Floor(cornerHitY - boxSizeY * cornerY);
            int oppositeZ = Floor(cornerHitZ - boxSizeZ * cornerZ);
            int currentIteration = iterations;
            if (!BetweenCornersInDirection(blockX, blockY, blockZ, oppositeX, oppositeY, oppositeZ, deltaMove,
                    (x, y, z) => !visitedBlocks.Add((x, y, z)) || visitor(x, y, z, currentIteration))) {
                return -1;
            }
        }
        return iterations;
    }

    /// <summary><c>BlockGetter.getFurthestCorner</c>.</summary>
    private static (int, int, int) FurthestCorner(Vec3d direction) {
        double xDot = Math.Abs(direction.X);
        double yDot = Math.Abs(direction.Y);
        double zDot = Math.Abs(direction.Z);
        int xSign = direction.X >= 0.0 ? 1 : -1;
        int ySign = direction.Y >= 0.0 ? 1 : -1;
        int zSign = direction.Z >= 0.0 ? 1 : -1;
        if (xDot <= yDot && xDot <= zDot) {
            return (-xSign, -zSign, ySign);
        }
        return yDot <= zDot ? (zSign, -ySign, -xSign) : (-ySign, xSign, -zSign);
    }

    /// <summary>
    /// <c>BlockPos.betweenCornersInDirection</c>: the box of positions walked from the corner the
    /// direction leaves, the axis <c>Direction.axisStepOrder</c> puts last varying fastest.
    /// </summary>
    private static bool BetweenCornersInDirection(int firstX, int firstY, int firstZ, int secondX, int secondY, int secondZ, Vec3d direction,
        Func<int, int, int, bool> visit) {
        int minX = Math.Min(firstX, secondX), minY = Math.Min(firstY, secondY), minZ = Math.Min(firstZ, secondZ);
        int maxX = Math.Max(firstX, secondX), maxY = Math.Max(firstY, secondY), maxZ = Math.Max(firstZ, secondZ);
        int[] diff = [maxX - minX, maxY - minY, maxZ - minZ];
        int[] start = [direction.X >= 0.0 ? minX : maxX, direction.Y >= 0.0 ? minY : maxY, direction.Z >= 0.0 ? minZ : maxZ];
        int[] step = [direction.X >= 0.0 ? 1 : -1, direction.Y >= 0.0 ? 1 : -1, direction.Z >= 0.0 ? 1 : -1];
        int[] axes = Math.Abs(direction.X) < Math.Abs(direction.Z) ? YZX : YXZ;
        int first = axes[0], second = axes[1], third = axes[2];
        int[] pos = new int[3];
        for (int i = 0; i <= diff[first]; i++) {
            for (int j = 0; j <= diff[second]; j++) {
                for (int k = 0; k <= diff[third]; k++) {
                    pos[first] = start[first] + step[first] * i;
                    pos[second] = start[second] + step[second] * j;
                    pos[third] = start[third] + step[third] * k;
                    if (!visit(pos[0], pos[1], pos[2])) {
                        return false;
                    }
                }
            }
        }
        return true;
    }

    private static int Floor(double value) => (int)Math.Floor(value);

    private static double Frac(double value) => value - Math.Floor(value);
}

/// <summary>The movement half of the <c>entityInside</c> of the blocks that move what is inside them.</summary>
public static class InsideBlockMovement {
    /// <summary><c>BubbleColumnBlock.entityInside</c>'s test for the top of a column: no collision and no fluid above.</summary>
    public static bool NothingAboveBubbleColumn(ClientLevel level, int x, int y, int z) {
        uint above = level.GetState(x, y + 1, z);
        return BlockPhysicsData.Get(level.Registry, above).Collision.Length == 0 && MovementBlocks.Get(level.Registry, above).Fluid == FluidKind.Empty;
    }

    /// <summary><c>Entity.handleOnAboveBubbleColumn</c>.</summary>
    public static Vec3d AboveBubbleColumn(Vec3d movement, bool dragDown) =>
        movement.WithY(dragDown ? Math.Max(-0.9, movement.Y - 0.03) : Math.Min(1.8, movement.Y + 0.1));

    /// <summary><c>Entity.handleOnInsideBubbleColumn</c>, which also resets the fall.</summary>
    public static Vec3d InsideBubbleColumn(Vec3d movement, bool dragDown) =>
        movement.WithY(dragDown ? Math.Max(-0.3, movement.Y - 0.03) : Math.Min(0.7, movement.Y + 0.06));

    /// <summary><c>HoneyBlock.isSlidingDown</c>: falling against the side of the block, below its top.</summary>
    public static bool IsSlidingDown(int x, int y, int z, bool onGround, Vec3d position, Vec3d movement, float width) {
        if (onGround || position.Y > y + 0.9375 - 1.0E-7 || OldDeltaY(movement.Y) >= -0.08) {
            return false;
        }
        double dx = Math.Abs(x + 0.5 - position.X);
        double dz = Math.Abs(z + 0.5 - position.Z);
        double overlapDistance = 0.4375 + width / 2.0F;
        return dx + 1.0E-7 > overlapDistance || dz + 1.0E-7 > overlapDistance;
    }

    /// <summary><c>HoneyBlock.doSlideMovement</c>, which also resets the fall.</summary>
    public static Vec3d SlideMovement(Vec3d movement) {
        if (OldDeltaY(movement.Y) < -0.13) {
            double horizontalReductionFactor = -0.05 / OldDeltaY(movement.Y);
            return new Vec3d(movement.X * horizontalReductionFactor, NewDeltaY(-0.05), movement.Z * horizontalReductionFactor);
        }
        return movement.WithY(NewDeltaY(-0.05));
    }

    private static double OldDeltaY(double deltaY) => deltaY / 0.98F + 0.08;

    private static double NewDeltaY(double deltaY) => (deltaY - 0.08) * 0.98F;
}

/// <summary><c>Entity.move</c>'s clip through what ends a fall.</summary>
public static class FallResetClip {
    private static readonly Box[] FullBlock = [new(0, 0, 0, 1, 1, 1)];

    /// <summary>
    /// <c>BlockGetter.clip</c> with <c>ClipContext.Block.FALLDAMAGE_RESETTING</c> and <c>ClipContext.Fluid.WATER</c>,
    /// as far as whether it hits. A player also stops at end portals and gateways. Water's shape is its height at
    /// the position, where vanilla's <c>FlowingFluid.getShape</c> caches one per fluid state from the first position asked.
    /// </summary>
    public static bool Hits(ClientLevel level, Vec3d from, Vec3d to, bool player) {
        Vec3<double> f = new(from.X, from.Y, from.Z), t = new(to.X, to.Y, to.Z);
        bool? hit = BlockClip.TraverseBlocks<bool>(f, t, pos => {
            uint state = level.GetState(pos.X, pos.Y, pos.Z);
            bool resetting = BlockPhysicsData.Get(level.Registry, state).FallDamageResetting;
            if (!resetting && player) {
                Minecraft.Data.Blocks.IBlock block = level.Registry.Blocks.GetByStateId(state);
                resetting = block.Identifier.Equals(Minecraft.Data.Generated.Block.EndGateway.Identifier)
                            || block.Identifier.Equals(Minecraft.Data.Generated.Block.EndPortal.Identifier);
            }
            if (resetting && BlockClip.ClipShape(FullBlock, pos, f, t) != null) {
                return true;
            }
            MovementBlocks.Entry fluid = MovementBlocks.Get(level.Registry, state);
            if (fluid.Fluid == FluidKind.Water) {
                Box[] shape = [new Box(0, 0, 0, 1, FluidInteraction.FluidHeight(level, pos.X, pos.Y, pos.Z, fluid), 1)];
                if (BlockClip.ClipShape(shape, pos, f, t) != null) {
                    return true;
                }
            }
            return null;
        });
        return hit == true;
    }
}
