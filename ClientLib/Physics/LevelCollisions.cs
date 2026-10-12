using ClientLib.Entities;
using ClientLib.Maths;
using ClientLib.World;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Data.Generated.BlockTypes;
using Minecraft.Physics;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ClientLib.Physics;

/// <summary>The <c>LivingEntity</c> methods <c>LiquidBlock.getCollisionShape</c> asks of the entity colliding.</summary>
public interface IFluidStandingEntity {
    /// <summary><c>LivingEntity.canStandOnFluid</c>.</summary>
    bool CanStandOnFluid(FluidKind fluid);

    /// <summary><c>LivingEntity.getLiquidCollisionShape</c>, in the block's own coordinates; empty for most.</summary>
    Box[] LiquidCollisionShape { get; }
}

/// <summary>What <c>EntityCollisionContext</c> asks of the entity colliding, past what it takes when it is made.</summary>
public interface ICollisionEntity {
    Vec3d Position { get; }

    double FallDistance { get; }

    /// <summary><c>PowderSnowBlock.canEntityWalkOnPowderSnow</c>.</summary>
    bool CanWalkOnPowderSnow { get; }
}

/// <summary>
/// <c>EntityCollisionContext</c>: the entity the shapes of liquids, powder snow and scaffolding read.
/// <c>default</c> is <c>CollisionContext.empty()</c>, whose shapes are the generated ones, and which
/// collides with no world border.
/// </summary>
public readonly struct EntityCollisionContext {
    private readonly ICollisionEntity? _entity;
    private readonly double _entityBottom;
    private readonly bool _descending;
    private readonly bool _alwaysCollideWithFluid;
    private readonly bool _placement;

    /// <param name="descending"><c>Entity.isDescending</c>, the shift key.</param>
    public EntityCollisionContext(ICollisionEntity entity, bool descending, bool alwaysCollideWithFluid = false) {
        _entity = entity;
        _entityBottom = entity.Position.Y;
        _descending = descending;
        _alwaysCollideWithFluid = alwaysCollideWithFluid;
    }

    private EntityCollisionContext(ICollisionEntity entity, bool descending, bool alwaysCollideWithFluid, bool placement)
        : this(entity, descending, alwaysCollideWithFluid) {
        _placement = placement;
    }

    /// <summary><c>CollisionContext.placementContext</c>: the player placing a block, which powder snow and scaffolding never obstruct.</summary>
    public static EntityCollisionContext Placement(ICollisionEntity player, bool descending) => new(player, descending, false, true);

    public ICollisionEntity? Entity => _entity;

    /// <summary><c>EntityCollisionContext.isAbove</c>, which unlike the empty context's ignores the default.</summary>
    public bool IsAbove(Box[] shape, int y) => IsAbove(MaxY(shape), y);

    private bool IsAbove(double shapeMaxY, int y) => _entityBottom > y + shapeMaxY - 1.0E-5F;

    private static double MaxY(Box[] shape) {
        double maxY = double.NegativeInfinity;
        foreach (Box box in shape) {
            maxY = Math.Max(maxY, box.MaxY);
        }
        return maxY;
    }

    /// <summary>
    /// <c>getCollisionShape</c> of a block whose shape reads the context, or null to keep the generated
    /// shape: the empty context's, which a non-empty one only ever changes for these three blocks.
    /// </summary>
    internal Box[]? ShapeOf(ClientLevel level, MinecraftRegistry registry, uint state, int x, int y, int z) {
        if (_entity == null) {
            return null;
        }
        LevelCollisions.ContextShape kind = LevelCollisions.ContextShapeOf(registry, state);
        switch (kind) {
            case LevelCollisions.ContextShape.Liquid:
                return _alwaysCollideWithFluid ? LevelCollisions.Block : null;
            case LevelCollisions.ContextShape.LiquidSource:
                return _alwaysCollideWithFluid ? LevelCollisions.Block : LiquidShape(level, registry, state, x, y, z);
            case LevelCollisions.ContextShape.PowderSnow:
                if (_placement) {
                    return [];
                }
                if (_entity.FallDistance > 2.5) {
                    return LevelCollisions.PowderSnowFalling;
                }
                return _entity is ClientFallingBlock || _entity.CanWalkOnPowderSnow && IsAbove(1.0, y) && !_descending
                    ? LevelCollisions.Block
                    : null;
            case LevelCollisions.ContextShape.Scaffolding:
            case LevelCollisions.ContextShape.ScaffoldingUnstable:
                if (_placement) {
                    return [];
                }
                if (IsAbove(1.0, y) && !_descending) {
                    return null;
                }
                return kind == LevelCollisions.ContextShape.ScaffoldingUnstable && IsAbove(0.0, y) ? LevelCollisions.ScaffoldingUnstableBottom : [];
            default:
                return null;
        }
    }

    /// <summary>
    /// <c>LiquidBlock.getCollisionShape</c> for a source block: the living entity's liquid shape when
    /// <c>isAbove</c> it and <c>canStandOnFluid</c>, which also needs the fluid above to be a different one.
    /// </summary>
    private Box[]? LiquidShape(ClientLevel level, MinecraftRegistry registry, uint state, int x, int y, int z) {
        if (_entity is not IFluidStandingEntity { LiquidCollisionShape: { Length: > 0 } shape } living) {
            return null;
        }
        MovementBlocks.Entry block = MovementBlocks.Get(registry, state);
        if (!IsAbove(shape, y) || !living.CanStandOnFluid(block.Fluid)) {
            return null;
        }
        return MovementBlocks.Get(registry, level.GetState(x, y + 1, z)).Fluid == block.Fluid ? null : shape;
    }
}

/// <summary>
/// Block collisions against what the client has loaded: <c>BlockCollisions</c>,
/// <c>Entity.collide</c> and <c>CollisionGetter.findSupportingBlock</c>.
/// <p/>
/// A chunk that is not loaded contributes nothing, as <c>getChunkForCollisions</c> returning null
/// does. Entity colliders (boats, shulkers) come from <see cref="EntityCollisions"/> and go first,
/// as vanilla lists them, then the world border for a context with an entity.
/// </summary>
public static class LevelCollisions {
    private const double Epsilon = 1.0E-7;

    internal static readonly Box[] Block = [new(0, 0, 0, 1, 1, 1)];

    /// <summary><c>PowderSnowBlock.FALLING_COLLISION_SHAPE</c>; 0.9F is off the voxel grid, so the box stays whole.</summary>
    internal static readonly Box[] PowderSnowFalling = [new(0, 0, 0, 1, 0.9F, 1)];

    /// <summary><c>ScaffoldingBlock.SHAPE_UNSTABLE_BOTTOM</c>.</summary>
    internal static readonly Box[] ScaffoldingUnstableBottom = [new(0, 0, 0, 1, 0.125, 1)];

    /// <summary>What a block's <c>getCollisionShape</c> reads off the context.</summary>
    internal enum ContextShape : byte {
        Unresolved,
        None,
        Liquid,
        LiquidSource,
        PowderSnow,
        Scaffolding,
        /// <summary>A scaffolding with a non-zero <c>distance</c> and <c>bottom</c>, which keeps a bottom slab under an entity not above it.</summary>
        ScaffoldingUnstable,
        /// <summary>
        /// <c>MovingPistonBlock</c>, whose shape is its block entity's whatever the context, and which as a
        /// <c>dynamicShape</c> block is large and alone collides from the shell's edges.
        /// </summary>
        MovingPiston
    }

    // EntityTypeTags.POWDER_SNOW_WALKABLE_MOBS. Entity type tags have no generated type; the server sends this one.
    private static readonly Identifier PowderSnowWalkableMobs = "minecraft:powder_snow_walkable_mobs";

    /// <summary><c>PowderSnowBlock.canEntityWalkOnPowderSnow</c>, given whether the entity's feet slot holds leather boots.</summary>
    internal static bool CanWalkOnPowderSnow(MinecraftClient client, ClientEntity entity, bool leatherBoots) =>
        client.InEntityTypeTag(entity.Type, PowderSnowWalkableMobs) || entity.IsLiving && leatherBoots;

    private static ContextShape[] _contextShapes = [];

    internal static ContextShape ContextShapeOf(MinecraftRegistry registry, uint state) {
        ContextShape[] shapes = _contextShapes;
        if (state < shapes.Length && shapes[state] != ContextShape.Unresolved) {
            return shapes[state];
        }
        if (state >= shapes.Length) {
            shapes = new ContextShape[Math.Max(registry.Blocks.StatesCount, (int)state + 1)];
            _contextShapes = shapes;
        }
        IBlock block = registry.Blocks.GetByStateId(state);
        ContextShape shape = block switch {
            WaterBlock { Level: 0 } or LavaBlock { Level: 0 } => ContextShape.LiquidSource,
            WaterBlock or LavaBlock => ContextShape.Liquid,
            ScaffoldingBlock { Distance: not 0, Bottom: true } => ContextShape.ScaffoldingUnstable,
            ScaffoldingBlock => ContextShape.Scaffolding,
            _ when BlockClasses.Is(block.Identifier, BlockClass.PowderSnowBlock) => ContextShape.PowderSnow,
            MovingPistonBlock => ContextShape.MovingPiston,
            _ => ContextShape.None
        };
        shapes[state] = shape;
        return shape;
    }

    [ThreadStatic] private static List<Box>? _colliders;
    [ThreadStatic] private static List<Box>? _queryColliders;
    [ThreadStatic] private static List<float>? _stepHeights;

    /// <summary><c>Entity.collide</c>: clip against the world, then try stepping up over what was hit.</summary>
    /// <param name="entityColliders">
    /// The boxes <see cref="EntityCollisions.Collect"/> found around the box expanded by the movement,
    /// which the step up pass reuses as vanilla does.
    /// </param>
    public static Vec3d Collide(ClientLevel level, Box box, Vec3d movement, bool onGround, float maxUpStep,
        EntityCollisionContext context = default, List<Box>? entityColliders = null) {
        List<Box> colliders = _colliders ??= new List<Box>(32);

        Vec3d step;
        if (movement.LengthSqr() == 0.0) {
            step = movement;
        }
        else {
            CollectColliders(level, box.ExpandTowards(movement.X, movement.Y, movement.Z), colliders, context, entityColliders);
            step = CollideWithShapes(movement, box, colliders);
        }

        bool xCollision = movement.X != step.X;
        bool yCollision = movement.Y != step.Y;
        bool zCollision = movement.Z != step.Z;
        bool landed = yCollision && movement.Y < 0.0;
        if (!(maxUpStep > 0.0F) || !(landed || onGround) || !(xCollision || zCollision)) {
            return step;
        }

        Box grounded = landed ? box.Translate(0, step.Y, 0) : box;
        Box stepUp = grounded.ExpandTowards(movement.X, maxUpStep, movement.Z);
        if (!landed) {
            stepUp = stepUp.ExpandTowards(0, -1.0E-5F, 0);
        }

        CollectColliders(level, stepUp, colliders, context, entityColliders);
        List<float> heights = CandidateStepUpHeights(grounded, colliders, maxUpStep, (float)step.Y);
        double stepHorizontal = step.HorizontalDistanceSqr();
        foreach (float height in heights) {
            Vec3d stepped = CollideWithShapes(new Vec3d(movement.X, height, movement.Z), grounded, colliders);
            if (stepped.HorizontalDistanceSqr() > stepHorizontal) {
                double distanceToGround = box.MinY - grounded.MinY;
                return stepped.Add(0.0, -distanceToGround, 0.0);
            }
        }
        return step;
    }

    /// <summary><c>Entity.collideWithShapes</c>: Y first, then the smaller horizontal component.</summary>
    public static Vec3d CollideWithShapes(Vec3d movement, Box box, List<Box> shapes) {
        if (shapes.Count == 0) {
            return movement;
        }

        bool zBeforeX = Math.Abs(movement.X) < Math.Abs(movement.Z);
        double x = 0, y = 0, z = 0;
        if (movement.Y != 0.0) {
            y = CollideAxis(1, box, shapes, movement.Y);
        }
        if (zBeforeX) {
            if (movement.Z != 0.0) {
                z = CollideAxis(2, box.Translate(x, y, z), shapes, movement.Z);
            }
            if (movement.X != 0.0) {
                x = CollideAxis(0, box.Translate(x, y, z), shapes, movement.X);
            }
        }
        else {
            if (movement.X != 0.0) {
                x = CollideAxis(0, box.Translate(x, y, z), shapes, movement.X);
            }
            if (movement.Z != 0.0) {
                z = CollideAxis(2, box.Translate(x, y, z), shapes, movement.Z);
            }
        }
        return new Vec3d(x, y, z);
    }

    /// <summary><c>Shapes.collide</c> over boxes that each move by at most the epsilon <c>VoxelShape.collideX</c> allows.</summary>
    private static double CollideAxis(int axis, Box moving, List<Box> shapes, double distance) {
        for (int i = 0; i < shapes.Count; i++) {
            if (Math.Abs(distance) < Epsilon) {
                return 0.0;
            }
            distance = CollideAgainst(shapes[i], axis, moving, distance);
        }
        return distance;
    }

    private static double CollideAgainst(Box box, int axis, Box moving, double distance) {
        if (Math.Abs(distance) < Epsilon) {
            return 0.0;
        }

        int b = axis == 2 ? 0 : axis + 1;
        int c = b == 2 ? 0 : b + 1;
        if (!OverlapsOn(moving, box, b) || !OverlapsOn(moving, box, c)) {
            return distance;
        }

        if (distance > 0.0) {
            double movingMax = moving.Max(axis);
            if (movingMax - Epsilon < box.Min(axis)) {
                double gap = box.Min(axis) - movingMax;
                if (gap >= -Epsilon) {
                    distance = Math.Min(distance, gap);
                }
            }
        }
        else if (distance < 0.0) {
            double movingMin = moving.Min(axis);
            if (movingMin + Epsilon >= box.Max(axis)) {
                double gap = box.Max(axis) - movingMin;
                if (gap <= Epsilon) {
                    distance = Math.Max(distance, gap);
                }
            }
        }
        return distance;
    }

    private static bool OverlapsOn(Box moving, Box box, int axis) {
        return moving.Min(axis) + Epsilon < box.Max(axis) && moving.Max(axis) - Epsilon >= box.Min(axis);
    }

    /// <summary>
    /// <c>Entity.collectCandidateStepUpHeights</c>. Vanilla walks each shape's Y grid; a split box's
    /// faces are that grid, so walking every box's two faces visits the same heights.
    /// </summary>
    private static List<float> CandidateStepUpHeights(Box box, List<Box> colliders, float maxStepHeight, float heightToSkip) {
        List<float> heights = _stepHeights ??= new List<float>(4);
        heights.Clear();
        foreach (Box collider in colliders) {
            AddCandidate(heights, (float)(collider.MinY - box.MinY), maxStepHeight, heightToSkip);
            AddCandidate(heights, (float)(collider.MaxY - box.MinY), maxStepHeight, heightToSkip);
        }
        heights.Sort();
        return heights;
    }

    private static void AddCandidate(List<float> heights, float height, float maxStepHeight, float heightToSkip) {
        if (height < 0.0F || height > maxStepHeight || height == heightToSkip || heights.Contains(height)) {
            return;
        }
        heights.Add(height);
    }

    /// <summary><c>CollisionGetter.noCollision</c> over blocks and the world border.</summary>
    public static bool NoCollision(ClientLevel level, Box query, EntityCollisionContext context = default) {
        List<Box> colliders = _queryColliders ??= [];
        CollectColliders(level, query, colliders, context, null);
        foreach (Box collider in colliders) {
            if (collider.Intersects(query)) {
                return false;
            }
        }
        return true;
    }

    /// <summary>Whether the collision shape of the block at the position overlaps <paramref name="query"/>.</summary>
    public static bool CollidesAt(ClientLevel level, int x, int y, int z, Box query) =>
        CollidingBoxesAt(level, level.Registry, x, y, z, query, default, default, out _) != null;

    /// <summary><c>CollisionGetter.collidesWithSuffocatingBlock</c>: the same walk, counting only suffocating blocks.</summary>
    public static bool CollidesWithSuffocatingBlock(ClientLevel level, Box query) {
        MinecraftRegistry registry = level.Registry;
        BlockWalk walk = new(query);
        while (walk.MoveNext()) {
            uint state = level.GetState(walk.X, walk.Y, walk.Z);
            if (!MovementBlocks.Get(registry, state).Suffocating) {
                continue;
            }
            Box[]? boxes = CollidingBoxesAt(level, registry, walk.X, walk.Y, walk.Z, query, walk, default, out Vec3d offset);
            if (boxes == null) {
                continue;
            }
            foreach (Box local in boxes) {
                if (local.Translate(walk.X + offset.X, walk.Y + offset.Y, walk.Z + offset.Z).Intersects(query)) {
                    return true;
                }
            }
        }
        return false;
    }

    /// <summary><c>Entity.collectCollidersIgnoringWorldBorder</c>, which despite its name adds the border.</summary>
    private static void CollectColliders(ClientLevel level, Box query, List<Box> into, in EntityCollisionContext context,
        List<Box>? entityColliders) {
        into.Clear();
        if (entityColliders != null) {
            into.AddRange(entityColliders);
        }
        if (context.Entity is { } entity && level.WorldBorder.IsInsideCloseToBorder(entity.Position, query)) {
            into.AddRange(level.WorldBorder.CollisionShape);
        }
        MinecraftRegistry registry = level.Registry;
        BlockWalk walk = new(query);
        while (walk.MoveNext()) {
            Box[]? boxes = CollidingBoxesAt(level, registry, walk.X, walk.Y, walk.Z, query, walk, context, out Vec3d offset);
            if (boxes == null) {
                continue;
            }
            foreach (Box local in boxes) {
                into.Add(local.Translate(walk.X + offset.X, walk.Y + offset.Y, walk.Z + offset.Z));
            }
        }
    }

    /// <summary>
    /// The positions <c>BlockCollisions</c> visits: every block the box touches, and a one block shell
    /// from which only shapes leaving their own cube (fences, walls) can collide, and from whose edges
    /// only moving pistons can.
    /// </summary>
    public struct BlockWalk {
        private readonly int _x0, _y0, _z0, _x1, _y1, _z1;
        private int _x, _y, _z;

        public int X, Y, Z;
        public bool Shell, Edge;

        public BlockWalk(Box query) {
            _x0 = (int)Math.Floor(query.MinX - Epsilon);
            _x1 = (int)Math.Floor(query.MaxX + Epsilon);
            _y0 = (int)Math.Floor(query.MinY - Epsilon);
            _y1 = (int)Math.Floor(query.MaxY + Epsilon);
            _z0 = (int)Math.Floor(query.MinZ - Epsilon);
            _z1 = (int)Math.Floor(query.MaxZ + Epsilon);
            _x = _x0 - 1;
            _y = _y0 - 1;
            _z = _z0 - 2;
        }

        public bool MoveNext() {
            while (true) {
                if (++_z > _z1 + 1) {
                    _z = _z0 - 1;
                    if (++_y > _y1 + 1) {
                        _y = _y0 - 1;
                        if (++_x > _x1 + 1) {
                            return false;
                        }
                    }
                }

                int outside = (_x < _x0 || _x > _x1 ? 1 : 0) +
                              (_y < _y0 || _y > _y1 ? 1 : 0) +
                              (_z < _z0 || _z > _z1 ? 1 : 0);
                if (outside > 2) {
                    continue;
                }

                X = _x;
                Y = _y;
                Z = _z;
                Shell = outside >= 1;
                Edge = outside == 2;
                return true;
            }
        }
    }

    /// <summary>A block's collision boxes when any of them reaches <paramref name="query"/>; vanilla takes a shape whole or not at all.</summary>
    private static Box[]? CollidingBoxesAt(ClientLevel level, MinecraftRegistry registry, int x, int y, int z,
        Box query, BlockWalk walk, in EntityCollisionContext context, out Vec3d offset) {
        offset = Vec3d.Zero;
        uint state = level.GetState(x, y, z);
        if (state == 0) {
            return null;
        }
        if (ContextShapeOf(registry, state) == ContextShape.MovingPiston) {
            return level.GetBlockEntity(x, y, z) is World.BlockEntities.PistonMovingBlockEntity piston
                ? Reaching(piston.CollisionShape(registry), x, y, z, query)
                : null;
        }
        if (walk.Edge) {
            return null;
        }
        bool shell = walk.Shell;

        BlockPhysicsData.Entry data = BlockPhysicsData.Get(registry, state);
        // hasLargeCollisionShape is cached from the context free shape, which leaves none of the context's shapes large.
        if (shell && !data.LargeCollisionShape) {
            return null;
        }
        Box[] shape = context.ShapeOf(level, registry, state, x, y, z) ?? data.Collision;
        if (shape.Length == 0) {
            return null;
        }

        if (data.Offsets != null) {
            Vec3<double> o = data.Offsets.ShapeOffset(new Vec3<int>(x, y, z));
            offset = new Vec3d(o.X, o.Y, o.Z);
        }

        foreach (Box local in shape) {
            if (query.Intersects(local.Translate(x + offset.X, y + offset.Y, z + offset.Z))) {
                return shape;
            }
        }
        return null;
    }

    private static Box[]? Reaching(Box[] shape, int x, int y, int z, Box query) {
        foreach (Box local in shape) {
            if (query.Intersects(local.Translate(x, y, z))) {
                return shape;
            }
        }
        return null;
    }

    /// <summary><c>CollisionGetter.findSupportingBlock</c>: the collider nearest the entity's position.</summary>
    public static (int X, int Y, int Z)? FindSupportingBlock(ClientLevel level, Vec3d position, Box feet,
        EntityCollisionContext context = default) {
        MinecraftRegistry registry = level.Registry;
        BlockWalk walk = new(feet);
        (int X, int Y, int Z)? best = null;
        double bestDistance = double.MaxValue;
        while (walk.MoveNext()) {
            if (CollidingBoxesAt(level, registry, walk.X, walk.Y, walk.Z, feet, walk, context, out _) == null) {
                continue;
            }
            double dx = walk.X + 0.5 - position.X;
            double dy = walk.Y + 0.5 - position.Y;
            double dz = walk.Z + 0.5 - position.Z;
            double distance = dx * dx + dy * dy + dz * dz;
            (int, int, int) pos = (walk.X, walk.Y, walk.Z);
            if (distance < bestDistance || (distance == bestDistance && best != null && Compare(best.Value, pos) < 0)) {
                best = pos;
                bestDistance = distance;
            }
        }
        return best;
    }

    private static int Compare((int X, int Y, int Z) a, (int X, int Y, int Z) b) {
        if (a.Y != b.Y) return a.Y - b.Y;
        if (a.Z != b.Z) return a.Z - b.Z;
        return a.X - b.X;
    }
}
