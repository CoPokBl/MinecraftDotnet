using ManagedServer.Entities.Types;
using ManagedServer.Worlds;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas.Vec;
using Attribute = Minecraft.Data.Generated.Attribute;

namespace ManagedServer.Physics;

/// <summary>
/// Vanilla's entity movement, ported one for one from <c>Entity.move</c> and
/// <c>LivingEntity.travelInAir</c> so that a client simulating an entity locally lands on the same
/// position we do.
/// <p/>
/// Everything here is per tick, matching vanilla's fixed 20 tick per second clock. Nothing scales by
/// frame delta on purpose: a server running long ticks falls behind rather than moving further, which
/// is what the client assumes.
/// </summary>
public static class EntityPhysics {
    /// <summary>Vanilla's shape lookup slack (<c>Shapes.collide</c>, <c>BlockCollisions</c>).</summary>
    private const double Epsilon = 1.0E-7;

    /// <summary>
    /// Vanilla compares horizontal movement with <c>Mth.equal</c>, whose tolerance is a float
    /// literal; keeping it a float keeps the widened value identical.
    /// </summary>
    private const double MoveEpsilon = 1.0E-5f;

    /// <summary>The offset <c>getBlockPosBelowThatAffectsMyMovement</c> looks down by.</summary>
    private const double BelowMovementOffset = 0.500001f;

    /// <summary>Movement packets quantise to 1/4096 of a block, so anything smaller is not worth sending.</summary>
    private const double PositionQuantum = 1.0 / 4096.0;

    private static readonly uint AirStateId = Block.Air.StateId;

    // Physics runs on the tick thread, but one scratch buffer per thread costs nothing and keeps
    // this safe if a caller ever drives an entity from elsewhere.
    [ThreadStatic] private static List<Box>? _colliders;
    [ThreadStatic] private static List<float>? _stepHeights;

    /// <summary>
    /// Advances one entity by a tick: gravity, then the move, then drag. Players are excluded by the
    /// caller since their client owns their movement.
    /// </summary>
    public static void Tick(World world, Entity entity) {
        // Vanilla does not tick entities whose chunk is not loaded either.
        if (!world.IsChunkLoaded(World.GetChunkPos(entity.Position))) {
            return;
        }

        if (entity is LivingEntity living) {
            TickLiving(world, living);
        }
        else {
            TickGeneric(world, entity);
        }
    }

    /// <summary>
    /// The loop non-living entities run, taken from <c>ItemEntity.tick</c>: gravity, move, then drag
    /// scaled by the friction of whatever is underneath. Thrown entities share this shape.
    /// </summary>
    private static void TickGeneric(World world, Entity entity) {
        double gravity = Gravity(entity);
        if (gravity != 0.0) {
            entity.Velocity = entity.Velocity.SubtractY(gravity);
        }

        Move(world, entity, entity.Velocity);

        // The entity data stores drag as the amount lost per tick, the multiplier is what is left.
        double airDrag = 1.0 - entity.Type.Drag;
        double friction = entity.OnGround
            ? airDrag * BlockBelowMovement(world, entity).Friction
            : airDrag;

        // Vanilla halves and flips whatever downward velocity survives a landing here. It cannot fire
        // without block bounciness, which no block in the generated data carries: landing means a
        // vertical collision, and that has already zeroed Y.
        Vec3<double> velocity = entity.Velocity;
        entity.Velocity = new Vec3<double>(velocity.X * friction, velocity.Y * airDrag, velocity.Z * friction);
    }

    /// <summary>
    /// <c>LivingEntity.travelInAir</c>. Living entities carry their drag and gravity on attributes
    /// rather than the entity type, take horizontal drag before vertical, and have gravity applied
    /// after the move rather than before it.
    /// <p/>
    /// Vanilla accelerates from the entity's movement input first; a server driven entity has no
    /// input, so its velocity is whatever a feature or AI put there.
    /// </summary>
    private static void TickLiving(World world, LivingEntity entity) {
        double frictionModifier = entity.GetAttributeValue(Attribute.FrictionModifier);
        double blockFriction = entity.OnGround
            ? ModifyFriction(BlockBelowMovement(world, entity).Friction, frictionModifier)
            : 1.0;

        Move(world, entity, entity.Velocity);

        Vec3<double> velocity = entity.Velocity;
        double y = velocity.Y - Gravity(entity);

        double airDragModifier = entity.GetAttributeValue(Attribute.AirDragModifier);
        double airDrag = ModifyFriction(0.91, airDragModifier);
        double horizontal = blockFriction * airDrag;
        double vertical = ModifyFriction(0.98, airDragModifier);

        entity.Velocity = new Vec3<double>(velocity.X * horizontal, y * vertical, velocity.Z * horizontal);
    }

    /// <summary>
    /// <c>Entity.move(MoverType.SELF, delta)</c>: resolve the movement against the world, commit it,
    /// then record what was hit and zero the velocity on those axes.
    /// </summary>
    public static void Move(World world, Entity entity, Vec3<double> delta) {
        Box box = BoundingBoxOf(entity);
        Vec3<double> movement = Collide(world, entity, box, delta);

        double movedSqr = LengthSquared(movement);
        if (movedSqr > Epsilon || LengthSquared(delta) - movedSqr < Epsilon) {
            SetPosition(entity, entity.Position + movement);
        }

        bool xCollision = !Equal(delta.X, movement.X);
        bool zCollision = !Equal(delta.Z, movement.Z);
        bool verticalCollision = delta.Y != movement.Y;

        entity.HorizontalCollision = xCollision || zCollision;
        entity.VerticalCollision = verticalCollision;
        entity.VerticalCollisionBelow = verticalCollision && delta.Y < 0.0;
        entity.OnGround = entity.VerticalCollisionBelow;
        UpdateSupportingBlock(world, entity, movement);

        if ((Math.Abs(delta.Y) > 0.0 && verticalCollision) || entity.HorizontalCollision) {
            // Vanilla restitutes a bounce here. No block in the generated data carries a bounce
            // restitution, so this is always the zero restitution case: the collided axes stop.
            Vec3<double> velocity = entity.Velocity;
            if (xCollision) velocity = velocity.WithX(0);
            if (zCollision) velocity = velocity.WithZ(0);
            if (verticalCollision) velocity = velocity.WithY(0);
            entity.Velocity = velocity;
        }

        double speedFactor = BlockSpeedFactor(world, entity);
        if (speedFactor != 1.0) {
            entity.Velocity = new Vec3<double>(
                entity.Velocity.X * speedFactor, entity.Velocity.Y, entity.Velocity.Z * speedFactor);
        }
    }

    /// <summary>
    /// Commits a resolved movement. A step that does not cross a 1/4096 grid line is below what the
    /// movement packets can express, so it only updates our own position: that keeps a slowly decaying
    /// slide exact without broadcasting a packet a tick for every item lying on the floor. Comparing
    /// grid cells rather than the step size means the small steps still accumulate into a send, so the
    /// broadcast position can never drift further than one quantum behind.
    /// </summary>
    private static void SetPosition(Entity entity, Vec3<double> newPos) {
        Vec3<double> old = entity.Position;
        bool visible = Quantise(newPos.X) != Quantise(old.X) ||
                       Quantise(newPos.Y) != Quantise(old.Y) ||
                       Quantise(newPos.Z) != Quantise(old.Z);

        if (visible) {
            entity.Move(newPos);
        }
        else {
            entity.Position = newPos;
        }
    }

    private static long Quantise(double coordinate) => (long)Math.Round(coordinate / PositionQuantum);

    #region collision

    /// <summary>
    /// <c>Entity.collide</c>: clip the movement against the world, then see whether stepping up over
    /// what was hit gets the entity further.
    /// </summary>
    private static Vec3<double> Collide(World world, Entity entity, Box box, Vec3<double> movement) {
        List<Box> colliders = Colliders;

        Vec3<double> step;
        if (LengthSquared(movement) == 0.0) {
            step = movement;
        }
        else {
            CollectColliders(world, box.ExpandTowards(movement), colliders);
            step = CollideWithShapes(movement, box, colliders);
        }

        float maxUpStep = MaxUpStep(entity);
        if (maxUpStep <= 0.0f) {
            return step;
        }

        bool xCollision = movement.X != step.X;
        bool zCollision = movement.Z != step.Z;
        bool landed = movement.Y != step.Y && movement.Y < 0.0;

        if (!(landed || entity.OnGround) || !(xCollision || zCollision)) {
            return step;
        }

        Box grounded = landed ? box.Translate(0, step.Y, 0) : box;
        Box stepUp = grounded.ExpandTowards(movement.X, maxUpStep, movement.Z);
        if (!landed) {
            stepUp = stepUp.ExpandTowards(0, -1.0E-5f, 0);
        }

        CollectColliders(world, stepUp, colliders);
        List<float> heights = CandidateStepUpHeights(grounded, colliders, maxUpStep, (float)step.Y);

        double bestHorizontal = HorizontalLengthSquared(step);
        foreach (float height in heights) {
            Vec3<double> stepped = CollideWithShapes(new Vec3<double>(movement.X, height, movement.Z), grounded, colliders);
            if (HorizontalLengthSquared(stepped) > bestHorizontal) {
                return stepped.SubtractY(box.MinY - grounded.MinY);
            }
        }

        return step;
    }

    /// <summary>
    /// <c>Entity.collideWithShapes</c>: resolve one axis at a time, vertically first so that landing
    /// on a surface happens before sliding along it, then the smaller horizontal component.
    /// <p/>
    /// Public because it is the whole of the collision maths with none of the world lookups around it,
    /// which is what a caller wanting to move something against a known set of boxes needs.
    /// </summary>
    public static Vec3<double> CollideWithShapes(Vec3<double> movement, Box box, List<Box> shapes) {
        if (shapes.Count == 0) {
            return movement;
        }

        // Direction.axisStepOrder: Y, then the smaller horizontal component, then the larger.
        bool zBeforeX = Math.Abs(movement.X) < Math.Abs(movement.Z);

        Vec3<double> resolved = Vec3<double>.Zero;
        resolved = ResolveAxis(1, movement, box, shapes, resolved);
        resolved = ResolveAxis(zBeforeX ? 2 : 0, movement, box, shapes, resolved);
        resolved = ResolveAxis(zBeforeX ? 0 : 2, movement, box, shapes, resolved);
        return resolved;
    }

    private static Vec3<double> ResolveAxis(int axis, Vec3<double> movement, Box box, List<Box> shapes, Vec3<double> resolved) {
        double axisMovement = movement[axis];
        return axisMovement == 0.0
            ? resolved
            : resolved.With(axis, CollideAxis(axis, box.Translate(resolved), shapes, axisMovement));
    }

    /// <summary>
    /// <c>Shapes.collide</c>: shrink the requested distance down to whatever the shapes leave free.
    /// </summary>
    private static double CollideAxis(int axis, Box moving, List<Box> shapes, double distance) {
        for (int i = 0; i < shapes.Count; i++) {
            if (Math.Abs(distance) < Epsilon) {
                return 0.0;
            }

            distance = CollideAgainst(shapes[i], axis, moving, distance);
        }

        return distance;
    }

    /// <summary>
    /// <c>VoxelShape.collideX</c> reduced to a single box, which is what every shape here is made of.
    /// A box already overlapping the mover does not push it out, matching vanilla.
    /// </summary>
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

    /// <summary>
    /// The overlap test vanilla gets out of its shape index lookups: the mover is shrunk by an
    /// epsilon, so boxes it only grazes on the perpendicular axes do not block it.
    /// </summary>
    private static bool OverlapsOn(Box moving, Box box, int axis) {
        return moving.Min(axis) + Epsilon < box.Max(axis) && moving.Max(axis) - Epsilon >= box.Min(axis);
    }

    /// <summary>
    /// <c>Entity.collectCandidateStepUpHeights</c>: the heights of every collider edge the entity
    /// could come to rest on, ascending, so the lowest workable step wins.
    /// </summary>
    private static List<float> CandidateStepUpHeights(Box box, List<Box> colliders, float maxStepHeight, float heightToSkip) {
        List<float> heights = _stepHeights ??= new List<float>(4);
        heights.Clear();

        foreach (Box collider in colliders) {
            // Vanilla walks a shape's Y coordinates in order and stops at the first one out of reach.
            AddCandidate(heights, (float)(collider.MinY - box.MinY), maxStepHeight, heightToSkip);
            AddCandidate(heights, (float)(collider.MaxY - box.MinY), maxStepHeight, heightToSkip);
        }

        heights.Sort();
        return heights;
    }

    private static void AddCandidate(List<float> heights, float height, float maxStepHeight, float heightToSkip) {
        if (height < 0.0f || height > maxStepHeight || height == heightToSkip || heights.Contains(height)) {
            return;
        }

        heights.Add(height);
    }

    /// <summary>
    /// Every block collision box reaching into <paramref name="query"/>.
    /// <p/>
    /// Vanilla walks one block further out than the query box on each side and only lets blocks whose
    /// shape leaves its own cube, fences and walls, collide from out there. The two-sided shell it
    /// keeps for moving pistons is skipped: ManagedServer has no piston simulation to feed it.
    /// </summary>
    private static void CollectColliders(World world, Box query, List<Box> into) {
        into.Clear();

        MinecraftRegistry registry = world.Server.Registry;
        BlockWalk walk = new(query);

        while (walk.MoveNext()) {
            Box[]? boxes = CollidingBoxesAt(world, registry, walk.X, walk.Y, walk.Z, query, walk.Shell);
            if (boxes == null) {
                continue;
            }

            foreach (Box local in boxes) {
                into.Add(local.Translate(walk.X, walk.Y, walk.Z));
            }
        }
    }

    /// <summary>
    /// The block positions vanilla's <c>BlockCollisions</c> visits for a query box: every block the box
    /// touches, plus a one block shell that only blocks with an oversized shape can collide from.
    /// </summary>
    private struct BlockWalk {
        private readonly int _x0, _y0, _z0, _x1, _y1, _z1;
        private int _x, _y, _z;

        public int X, Y, Z;

        /// <summary>Whether the current position is on the outer shell.</summary>
        public bool Shell;

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

                // Vanilla keeps the two-sided shell for moving pistons and skips the corners; there is
                // no piston simulation here to feed it.
                if (outside > 1) {
                    continue;
                }

                X = _x;
                Y = _y;
                Z = _z;
                Shell = outside == 1;
                return true;
            }
        }
    }

    /// <summary>
    /// The block local collision boxes at a position when the block collides with
    /// <paramref name="query"/> at all, otherwise null. Vanilla takes a shape whole or not at all,
    /// so a shape with one box in range contributes all of them.
    /// </summary>
    private static Box[]? CollidingBoxesAt(World world, MinecraftRegistry registry, int x, int y, int z, Box query, bool shell) {
        uint state = world.GetBlockStateIdOr(x, y, z, AirStateId);
        if (state == AirStateId) {
            return null;
        }

        BlockPhysicsData.Entry data = BlockPhysicsData.Get(registry, state);
        if (data.Collision.Length == 0 || (shell && !data.LargeCollisionShape)) {
            return null;
        }

        foreach (Box local in data.Collision) {
            if (query.Intersects(local.Translate(x, y, z))) {
                return data.Collision;
            }
        }

        return null;
    }

    #endregion

    #region supporting block

    /// <summary>
    /// <c>Entity.checkSupportingBlock</c>. The block an entity stands on is not always the one under
    /// its centre, so vanilla records the nearest block its feet actually rest on; that is what makes
    /// standing on the edge of an ice block still slide.
    /// </summary>
    private static void UpdateSupportingBlock(World world, Entity entity, Vec3<double> movement) {
        if (!entity.OnGround) {
            entity.OnGroundNoBlocks = false;
            entity.SupportingBlockPos = null;
            return;
        }

        Box box = BoundingBoxOf(entity);
        Box feet = new(box.MinX, box.MinY - 1.0E-6, box.MinZ, box.MaxX, box.MinY, box.MaxZ);

        Vec3<int>? supporting = FindSupportingBlock(world, entity.Position, feet);
        if (supporting == null && !entity.OnGroundNoBlocks) {
            // Nothing under the feet where they ended up; the entity was pushed off an edge by the
            // collision response, so look where it came from.
            supporting = FindSupportingBlock(world, entity.Position, feet.Translate(-movement.X, 0, -movement.Z));
        }

        entity.SupportingBlockPos = supporting;
        entity.OnGroundNoBlocks = supporting == null;
    }

    /// <summary><c>CollisionGetter.findSupportingBlock</c>: the collider nearest the entity's feet.</summary>
    private static Vec3<int>? FindSupportingBlock(World world, Vec3<double> position, Box feet) {
        MinecraftRegistry registry = world.Server.Registry;
        BlockWalk walk = new(feet);

        Vec3<int>? best = null;
        double bestDistance = double.MaxValue;

        while (walk.MoveNext()) {
            if (CollidingBoxesAt(world, registry, walk.X, walk.Y, walk.Z, feet, walk.Shell) == null) {
                continue;
            }

            double dx = walk.X + 0.5 - position.X;
            double dy = walk.Y + 0.5 - position.Y;
            double dz = walk.Z + 0.5 - position.Z;
            double distance = dx * dx + dy * dy + dz * dz;

            Vec3<int> pos = new(walk.X, walk.Y, walk.Z);
            // Vanilla breaks ties by block position order, comparing Y then Z then X.
            if (distance < bestDistance || (distance == bestDistance && best != null && ComparePos(best.Value, pos) < 0)) {
                best = pos;
                bestDistance = distance;
            }
        }

        return best;
    }

    private static int ComparePos(Vec3<int> a, Vec3<int> b) {
        if (a.Y != b.Y) return a.Y - b.Y;
        if (a.Z != b.Z) return a.Z - b.Z;
        return a.X - b.X;
    }

    /// <summary>
    /// <c>Entity.getBlockPosBelowThatAffectsMyMovement</c>: the block whose friction and speed factor
    /// the entity inherits.
    /// </summary>
    private static BlockPhysicsData.Entry BlockBelowMovement(World world, Entity entity) {
        MinecraftRegistry registry = world.Server.Registry;
        Vec3<double> position = entity.Position;
        int belowY = (int)Math.Floor(position.Y - BelowMovementOffset);

        Vec3<int>? supporting = entity.SupportingBlockPos;
        if (supporting == null) {
            return StateAt(world, registry, (int)Math.Floor(position.X), belowY, (int)Math.Floor(position.Z));
        }

        Vec3<int> below = supporting.Value;
        BlockPhysicsData.Entry supportingData = StateAt(world, registry, below.X, below.Y, below.Z);

        // Walls and fence gates stand taller than their own block, so dropping half a block from the
        // entity would look past them.
        return supportingData.WallLike ? supportingData : StateAt(world, registry, below.X, belowY, below.Z);
    }

    /// <summary><c>Entity.getBlockSpeedFactor</c>: the block the entity is in, falling back to the one below.</summary>
    private static double BlockSpeedFactor(World world, Entity entity) {
        MinecraftRegistry registry = world.Server.Registry;
        Vec3<double> position = entity.Position;

        BlockPhysicsData.Entry here = StateAt(world, registry,
            (int)Math.Floor(position.X), (int)Math.Floor(position.Y), (int)Math.Floor(position.Z));

        if (here.WaterLike || here.SpeedFactor != 1.0) {
            return here.SpeedFactor;
        }

        return BlockBelowMovement(world, entity).SpeedFactor;
    }

    private static BlockPhysicsData.Entry StateAt(World world, MinecraftRegistry registry, int x, int y, int z) {
        return BlockPhysicsData.Get(registry, world.GetBlockStateIdOr(x, y, z, AirStateId));
    }

    #endregion

    #region helpers

    private static Box BoundingBoxOf(Entity entity) {
        return new Box(entity.BoundingBox).Translate(entity.Position);
    }

    private static double Gravity(Entity entity) {
        if (entity.Meta.NoGravity ?? false) {
            return 0.0;
        }

        // Living entities take gravity from the attribute so that modifiers work; everything else has
        // it baked into the entity type.
        return entity is LivingEntity ? entity.GetAttributeValue(Attribute.Gravity) : entity.Type.Acceleration;
    }

    private static float MaxUpStep(Entity entity) {
        return entity is LivingEntity ? (float)entity.GetAttributeValue(Attribute.StepHeight) : 0.0f;
    }

    /// <summary><c>LivingEntity.computeModifiedFriction</c>.</summary>
    private static double ModifyFriction(double friction, double modifier) {
        return Math.Clamp(1.0 - (1.0 - friction) * modifier, 0.0, 1.0);
    }

    private static List<Box> Colliders => _colliders ??= new List<Box>(32);

    private static bool Equal(double a, double b) => Math.Abs(b - a) < MoveEpsilon;

    private static double LengthSquared(Vec3<double> v) => v.X * v.X + v.Y * v.Y + v.Z * v.Z;

    private static double HorizontalLengthSquared(Vec3<double> v) => v.X * v.X + v.Z * v.Z;

    #endregion
}
