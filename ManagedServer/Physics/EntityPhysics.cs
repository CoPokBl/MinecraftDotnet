using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Fluids;
using ManagedServer.Worlds;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas;
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

    /// <summary>The one <c>getOnPosLegacy</c> uses, which is what a landing is judged against.</summary>
    private const double LegacyOnPosOffset = 0.2f;

    /// <summary>Movement packets quantise to 1/4096 of a block, so anything smaller is not worth sending.</summary>
    private const double PositionQuantum = 1.0 / 4096.0;

    /// <summary><c>Entity.MIN_MOVEMENT_DISTANCE</c>: velocity below this on an axis is thrown away.</summary>
    private const double MinMovementDistance = 0.003;

    private static readonly uint AirStateId = Block.Air.StateId;

    // Physics runs on the tick thread, but one scratch buffer per thread costs nothing and keeps
    // this safe if a caller ever drives an entity from elsewhere.
    [ThreadStatic] private static List<Box>? _colliders;
    [ThreadStatic] private static List<Box>? _queryColliders;
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

        // Vanilla's setOldPosAndRot, which ServerLevel.tickNonPassenger runs before anything else.
        // The body rotation control is what reads it, to tell walking from standing still.
        entity.LastTickPosition = entity.Position;

        if (entity is LivingEntity living) {
            AiStep(world, living);
        }
        else {
            TickGeneric(world, entity);
        }

        // Mob.tickHeadTurn, which vanilla runs from LivingEntity.tick after aiStep rather than inside
        // it, because the body follows how far the mob actually got rather than where it aimed.
        if (entity is Mob headTurner) {
            headTurner.TickHeadTurn();
        }

        // Whatever turned the entity this tick wrote Yaw, Pitch or HeadYaw and sent nothing. The move
        // above carries a rotation with it when there was one, so this only has anything to do for an
        // entity that turned on the spot, which is most of what a mob watching something does.
        entity.Manager?.SyncRotation(entity);
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

        // Vanilla multiplies the two in float and only widens the result, so this has to as well:
        // 0.98f is 0.98000001907 as a double, and the difference compounds every tick.
        float airDrag = entity.Type.AirDrag;
        float friction = entity.OnGround
            ? airDrag * BlockBelowMovement(world, entity).Friction
            : airDrag;

        // Vanilla halves and flips whatever downward velocity survives a landing here. It cannot
        // fire: being on the ground means the last move ended in a vertical collision, which either
        // zeroed Y or, on a block with a bounce, sent it upwards.
        Vec3<double> velocity = entity.Velocity;
        entity.Velocity = new Vec3<double>(velocity.X * friction, velocity.Y * airDrag, velocity.Z * friction);
    }

    /// <summary>
    /// <c>LivingEntity.travelInAir</c>. Living entities carry their drag and gravity on attributes
    /// rather than the entity type, take horizontal drag before vertical, and have gravity applied
    /// after the move rather than before it.
    /// <p/>
    /// The movement input (<see cref="LivingEntity.Xxa"/> and friends) is accelerated first, the way
    /// vanilla does. An entity nothing writes those on leaves them at zero, which contributes nothing
    /// and leaves it moving on whatever velocity something else gave it.
    /// </summary>
    private static void TickLiving(World world, LivingEntity entity) {
        // Every friction term here is a float in vanilla, and they are multiplied together before
        // they widen, so keeping them doubles would drift from what the client works out.
        float frictionModifier = (float)entity.GetAttributeValue(Attribute.FrictionModifier);
        float blockFriction = entity.OnGround
            ? ModifyFriction(BlockBelowMovement(world, entity).Friction, frictionModifier)
            : 1.0f;

        // Vanilla's handleRelativeFrictionAndCalculateMovement: accelerate from the input, then move.
        MoveRelative(entity, FrictionInfluencedSpeed(entity, blockFriction),
            new Vec3<double>(entity.Xxa, entity.Yya, entity.Zza));

        Move(world, entity, entity.Velocity);

        Vec3<double> velocity = entity.Velocity;
        double y = velocity.Y - Gravity(entity);

        float airDragModifier = (float)entity.GetAttributeValue(Attribute.AirDragModifier);
        float airDrag = ModifyFriction(0.91f, airDragModifier);
        float horizontal = blockFriction * airDrag;
        float vertical = ModifyFriction(0.98f, airDragModifier);

        entity.Velocity = new Vec3<double>(velocity.X * horizontal, y * vertical, velocity.Z * horizontal);
    }

    #region movement_input

    /// <summary>
    /// <c>LivingEntity.aiStep</c>, the tick a living entity runs around <see cref="TickLiving"/>.
    /// It is where the movement input is trimmed, where a jump is spent, and where vanilla calls
    /// <c>serverAiStep</c>, so anything driving a mob has to go through here rather than calling
    /// <see cref="Tick"/> directly.
    /// <p/>
    /// Called by <see cref="Tick"/> for every living entity, mob or not, because vanilla runs it for
    /// every living entity: the input damping and the tiny velocity clamp apply either way.
    /// </summary>
    private static void AiStep(World world, LivingEntity entity) {
        if (entity.NoJumpDelay > 0) {
            entity.NoJumpDelay--;
        }

        ClampTinyVelocity(entity);

        // applyInput: the input decays rather than being cleared, so a control that stops writing
        // leaves the entity coasting to a stop instead of stopping dead.
        entity.Xxa *= 0.98f;
        entity.Zza *= 0.98f;

        if (entity.IsImmobile) {
            entity.Jumping = false;
            entity.Xxa = 0.0f;
            entity.Zza = 0.0f;
        }

        // The AI system's only call site, at vanilla's position. Everything a goal decides is written
        // into Xxa/Zza/Speed/Yaw here and spent by TickLiving below, on this same tick.
        if (entity is Mob { NoAi: false } mob) {
            mob.ServerAiStep(world);
        }

        if (entity.Jumping) {
            // Vanilla checks for a fluid jump first. Neither swimming nor lava jumping is modelled
            // here yet, so this is the ground branch alone; see ManagedServer/Fluids for what exists.
            if (entity.OnGround && entity.NoJumpDelay == 0) {
                entity.JumpFromGround(BlockJumpFactor(world, entity));
                entity.NoJumpDelay = 10;
            }
        }
        else {
            entity.NoJumpDelay = 0;
        }

        TickLiving(world, entity);
    }

    /// <summary>
    /// The <c>Entity.MIN_MOVEMENT_DISTANCE</c> clamp at the top of <c>aiStep</c>: velocity smaller
    /// than 0.003 on an axis is thrown away rather than decayed forever. Without it an entity that
    /// stopped being pushed slides for hundreds of ticks on a number too small to see.
    /// <p/>
    /// A player is judged on horizontal distance as a whole rather than per axis, which is a slightly
    /// larger threshold on a diagonal.
    /// </summary>
    private static void ClampTinyVelocity(LivingEntity entity) {
        Vec3<double> velocity = entity.Velocity;
        double x = velocity.X;
        double y = velocity.Y;
        double z = velocity.Z;

        if (entity is Player) {
            if (HorizontalLengthSquared(velocity) < 9.0E-6) {
                x = 0.0;
                z = 0.0;
            }
        }
        else {
            if (Math.Abs(x) < MinMovementDistance) {
                x = 0.0;
            }

            if (Math.Abs(z) < MinMovementDistance) {
                z = 0.0;
            }
        }

        if (Math.Abs(y) < MinMovementDistance) {
            y = 0.0;
        }

        entity.Velocity = new Vec3<double>(x, y, z);
    }

    /// <summary>
    /// <c>Entity.moveRelative</c>: turn a movement input into velocity, pointed by the entity's yaw
    /// and scaled by <paramref name="amount"/>. Adds to the velocity rather than replacing it, so
    /// gravity and knockback survive a walking mob.
    /// </summary>
    public static void MoveRelative(Entity entity, float amount, Vec3<double> input) {
        Vec3<double> movement = InputVector(input, amount, entity.Yaw.DegreesF);
        if (movement == Vec3<double>.Zero) {
            return;
        }

        entity.Velocity += movement;
    }

    /// <summary>
    /// <c>Entity.getInputVector</c>. The short circuit below one part in ten million is vanilla's and
    /// is what keeps a zero input from normalising to a NaN.
    /// </summary>
    private static Vec3<double> InputVector(Vec3<double> input, float scale, float yawDegrees) {
        double lengthSquared = LengthSquared(input);
        if (lengthSquared < 1.0E-7) {
            return Vec3<double>.Zero;
        }

        Vec3<double> scaled = (lengthSquared > 1.0 ? Normalise(input) : input) * scale;

        // The table, not Math: this is the same rotation the client applies to its own input.
        float sin = Mth.Sin(yawDegrees * ((float)Math.PI / 180f));
        float cos = Mth.Cos(yawDegrees * ((float)Math.PI / 180f));

        return new Vec3<double>(
            scaled.X * cos - scaled.Z * sin,
            scaled.Y,
            scaled.Z * cos + scaled.X * sin);
    }

    private static Vec3<double> Normalise(Vec3<double> v) {
        double length = Math.Sqrt(LengthSquared(v));
        return length < 1.0E-4 ? Vec3<double>.Zero : v / length;
    }

    /// <summary>
    /// <c>LivingEntity.getFrictionInfluencedSpeed</c>. Note the shape: since 26.2 the friction
    /// division only applies on a block slipperier than 0.6, so ordinary ground returns the speed
    /// untouched. A port that divides unconditionally is right on stone by accident and wrong on ice.
    /// <p/>
    /// The comparison against 0.6 is done in double upstream and the arithmetic in float, so both are
    /// kept as they are.
    /// </summary>
    private static float FrictionInfluencedSpeed(LivingEntity entity, float friction) {
        if (!entity.OnGround) {
            return entity.FlyingSpeed;
        }

        return (double)friction > 0.6
            ? entity.Speed * (0.21600002f / (friction * friction * friction))
            : entity.Speed;
    }

    /// <summary>
    /// <c>Entity.getBlockJumpFactor</c>: the block the entity stands in, falling back to the one that
    /// governs its movement when that block has nothing to say. Honey is the one that is not one.
    /// </summary>
    private static float BlockJumpFactor(World world, Entity entity) {
        MinecraftRegistry registry = world.Server.Registry;
        Vec3<double> position = entity.Position;

        float here = StateAt(world, registry,
            (int)Math.Floor(position.X), (int)Math.Floor(position.Y), (int)Math.Floor(position.Z)).JumpFactor;

        return (double)here == 1.0 ? BlockBelowMovement(world, entity).JumpFactor : here;
    }

    #endregion

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

        CheckFallDamage(world, entity, movement.Y, entity.OnGround);

        if ((Math.Abs(delta.Y) > 0.0 && verticalCollision) || entity.HorizontalCollision) {
            RestituteMovementAfterCollisions(world, entity, xCollision, zCollision, movement);
        }

        float speedFactor = BlockSpeedFactor(world, entity);
        if (speedFactor != 1.0f) {
            entity.Velocity = new Vec3<double>(
                entity.Velocity.X * speedFactor, entity.Velocity.Y, entity.Velocity.Z * speedFactor);
        }
    }

    /// <summary>
    /// <c>Entity.restituteMovementAfterCollisions</c>: what the collided axes do with the velocity
    /// they had. Without a bounce that is stop, which is every block but slime and beds.
    /// <p/>
    /// The vertical case is the interesting one. Vanilla works out how much of the tick was spent
    /// falling before the landing and gives back that much of the gravity and drag already taken, so
    /// a slime block returns an entity to the height it fell from rather than a little below it.
    /// </summary>
    private static void RestituteMovementAfterCollisions(World world, Entity entity, bool xCollision,
        bool zCollision, Vec3<double> movement) {
        bool suppressing = entity.Crouching;
        double restitution = suppressing ? 0.0 : EntityBounciness(entity);

        Vec3<double> velocity = entity.Velocity;
        Vec3<double> bounced = velocity;
        if (xCollision) {
            bounced = bounced.WithX(-velocity.X * restitution);
        }
        if (zCollision) {
            bounced = bounced.WithZ(-velocity.Z * restitution);
        }

        if (!entity.VerticalCollision) {
            entity.Velocity = bounced;
            return;
        }

        if (entity.VerticalCollisionBelow) {
            BlockPhysicsData.Entry landedOn = BlockLandedOn(world, entity);
            double gravity = Gravity(entity);

            restitution = -velocity.Y >= gravity && !suppressing && !landedOn.SuppressesBounce
                ? Math.Max(restitution, BlockBounciness(entity, landedOn))
                : 0.0;
        }

        double gravityCompensation = 0.0;
        double drag = 1.0;
        if (restitution > 0.0) {
            double portionWithMovement = movement.Y / velocity.Y;
            gravityCompensation = portionWithMovement * Gravity(entity);
            drag = Lerp(portionWithMovement, 1.0, entity.Type.AirDrag);
        }

        entity.Velocity = bounced.WithY((gravityCompensation - velocity.Y) * drag * restitution);
    }

    /// <summary><c>Entity.getBlockBounciness</c>: everything that is not alive keeps less of it.</summary>
    private static double BlockBounciness(Entity entity, BlockPhysicsData.Entry block) {
        float bounciness = block.BounceRestitution;
        if (entity is not LivingEntity) {
            bounciness *= 0.8f;
        }

        return bounciness;
    }

    /// <summary>
    /// <c>Entity.getEntityBounciness</c>. Living entities carry it on an attribute so that a
    /// modifier can make one bouncy; nothing else bounces on its own.
    /// </summary>
    private static double EntityBounciness(Entity entity) {
        return entity is LivingEntity ? entity.GetAttributeValue(Attribute.Bounciness) : 0.0;
    }

    /// <summary><c>Mth.lerp</c>.</summary>
    private static double Lerp(double delta, double from, double to) {
        return from + delta * (to - from);
    }

    /// <summary>
    /// <c>Entity.checkFallDamage</c> without the damage: it keeps <see cref="Entity.FallDistance"/> as
    /// the entity moves and hands a finished fall to <see cref="EntityLandEvent"/>, which is what
    /// <c>FallDamageFeature</c> listens to. A server with no fall damage still gets the distance,
    /// which is what vanilla does with it too.
    /// <p/>
    /// <paramref name="ya"/> is the movement that actually happened rather than the one that was asked
    /// for, so a fall that ends against a block only counts as far as the block.
    /// <p/>
    /// Water and lava are asked of the whole bounding box, as <c>isInWater</c> and <c>isInLava</c> are:
    /// landing with only part of the box in a pool still lands in water.
    /// <p/>
    /// Two simplifications remain. Vanilla clips the movement against the fall damage resetting blocks
    /// it passed through; that is answered here from the block the entity's feet ended in, which agrees
    /// for anything that ends up standing in one. And lava halves the distance here rather than in
    /// <c>baseTick</c>, so an entity that stops moving in lava stops halving it.
    /// </summary>
    public static void CheckFallDamage(World world, Entity entity, double ya, bool onGround) {
        // Neither branch below can change a fall of zero that is not still falling, so the box scan is
        // worth skipping for everything standing still, which is most entities most of the time.
        if (entity.FallDistance > 0.0 || ya < 0.0) {
            MinecraftRegistry registry = world.Server.Registry;
            Vec3<int> feet = entity.Position.ToBlockPos();
            uint feetState = world.GetBlockStateIdOr(feet.X, feet.Y, feet.Z, AirStateId);

            if (EntityFluids.IsIn(world, entity, FluidKind.Water)
                || BlockPhysicsData.Get(registry, feetState).FallDamageResetting) {
                // Water ends the fall outright, and so does a ladder or a cobweb; nothing accumulates
                // while the entity is still in one.
                entity.FallDistance = 0.0;
            }
            else {
                if (EntityFluids.IsIn(world, entity, FluidKind.Lava)) {
                    entity.FallDistance *= 0.5;
                }

                if (ya < 0.0) {
                    entity.FallDistance -= ya;
                }
            }
        }

        if (!onGround) {
            return;
        }

        if (entity.FallDistance > 0.0) {
            entity.Events.CallEvent(new EntityLandEvent {
                Entity = entity,
                World = world,
                FallDistance = entity.FallDistance,
                LandedOn = OnPos(world, entity, LegacyOnPosOffset).Pos
            });
        }

        entity.FallDistance = 0.0;
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
    /// Whether any block collision box overlaps <paramref name="query"/>, vanilla's
    /// <c>CollisionGetter.noCollision</c> inverted.
    /// <p/>
    /// Entities are not considered, matching the <c>noBlockCollision</c> half that the pathfinder
    /// asks for: a route is planned through terrain, not around whoever happens to be standing in
    /// the way.
    /// </summary>
    public static bool HasBlockCollision(World world, Box query) {
        // Its own list rather than the one the sweep uses, since the pathfinder asks this while a
        // move is not in progress but nothing in the type's shape says so.
        List<Box> colliders = _queryColliders ??= [];
        CollectColliders(world, query, colliders);

        foreach (Box collider in colliders) {
            if (collider.Intersects(query)) {
                return true;
            }
        }

        return false;
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
            Box[]? boxes = CollidingBoxesAt(world, registry, walk.X, walk.Y, walk.Z, query, walk.Shell, out Vec3<double> offset);
            if (boxes == null) {
                continue;
            }

            foreach (Box local in boxes) {
                into.Add(local.Translate(walk.X + offset.X, walk.Y + offset.Y, walk.Z + offset.Z));
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
    /// <p/>
    /// <paramref name="offset"/> is how far the block's shape is moved by the position it sits at,
    /// which is what puts a stalk of bamboo off centre.
    /// </summary>
    private static Box[]? CollidingBoxesAt(World world, MinecraftRegistry registry, int x, int y, int z,
        Box query, bool shell, out Vec3<double> offset) {
        offset = Vec3<double>.Zero;

        uint state = world.GetBlockStateIdOr(x, y, z, AirStateId);
        if (state == AirStateId) {
            return null;
        }

        BlockPhysicsData.Entry data = BlockPhysicsData.Get(registry, state);
        if (data.Collision.Length == 0 || (shell && !data.LargeCollisionShape)) {
            return null;
        }

        if (data.Offsets != null) {
            offset = data.Offsets.ShapeOffset(new Vec3<int>(x, y, z));
        }

        foreach (Box local in data.Collision) {
            if (query.Intersects(local.Translate(x + offset.X, y + offset.Y, z + offset.Z))) {
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
            if (CollidingBoxesAt(world, registry, walk.X, walk.Y, walk.Z, feet, walk.Shell, out _) == null) {
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
        return OnPos(world, entity, BelowMovementOffset).Data;
    }

    /// <summary>
    /// <c>Entity.getOnPosLegacy</c>: the block an entity is treated as standing on for the things
    /// that care about which block it is rather than how far down it is, landing included.
    /// </summary>
    private static BlockPhysicsData.Entry BlockLandedOn(World world, Entity entity) {
        return OnPos(world, entity, LegacyOnPosOffset).Data;
    }

    /// <summary>
    /// <c>Entity.getOnPos</c>: the block the given distance under the entity, taken from where its
    /// feet actually rest rather than from under its centre. Both halves come back because a landing
    /// needs the position and everything else needs the block.
    /// </summary>
    private static (Vec3<int> Pos, BlockPhysicsData.Entry Data) OnPos(World world, Entity entity, double offset) {
        MinecraftRegistry registry = world.Server.Registry;
        Vec3<double> position = entity.Position;
        int belowY = (int)Math.Floor(position.Y - offset);

        Vec3<int>? supporting = entity.SupportingBlockPos;
        if (supporting == null) {
            Vec3<int> under = new((int)Math.Floor(position.X), belowY, (int)Math.Floor(position.Z));
            return (under, StateAt(world, registry, under.X, under.Y, under.Z));
        }

        Vec3<int> below = supporting.Value;
        BlockPhysicsData.Entry supportingData = StateAt(world, registry, below.X, below.Y, below.Z);

        // Walls and fence gates stand taller than their own block, so dropping down from the entity
        // would look past them. Fences only count when the drop is small enough to stay inside one.
        bool tallerThanTheDrop = supportingData.WallLike || (offset <= 0.5 && supportingData.FenceLike);
        if (tallerThanTheDrop) {
            return (below, supportingData);
        }

        Vec3<int> dropped = below.WithY(belowY);
        return (dropped, StateAt(world, registry, dropped.X, dropped.Y, dropped.Z));
    }

    /// <summary><c>Entity.getBlockSpeedFactor</c>: the block the entity is in, falling back to the one below.</summary>
    private static float BlockSpeedFactor(World world, Entity entity) {
        MinecraftRegistry registry = world.Server.Registry;
        Vec3<double> position = entity.Position;

        BlockPhysicsData.Entry here = StateAt(world, registry,
            (int)Math.Floor(position.X), (int)Math.Floor(position.Y), (int)Math.Floor(position.Z));

        if (here.WaterLike || here.SpeedFactor != 1.0f) {
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
    private static float ModifyFriction(float friction, float modifier) {
        return Math.Clamp(1.0f - (1.0f - friction) * modifier, 0.0f, 1.0f);
    }

    private static List<Box> Colliders => _colliders ??= new List<Box>(32);

    private static bool Equal(double a, double b) => Math.Abs(b - a) < MoveEpsilon;

    private static double LengthSquared(Vec3<double> v) => v.X * v.X + v.Y * v.Y + v.Z * v.Z;

    private static double HorizontalLengthSquared(Vec3<double> v) => v.X * v.X + v.Z * v.Z;

    #endregion
}
