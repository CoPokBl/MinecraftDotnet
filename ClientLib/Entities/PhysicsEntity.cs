using ClientLib.Maths;
using ClientLib.Physics;
using ClientLib.World;
using ClientLib.World.BlockEntities;
using Minecraft.Data.Generated;
using Minecraft.Physics;
using Minecraft.Schemas.Entities;

namespace ClientLib.Entities;

/// <summary>
/// The parts of <c>Entity</c> a client runs for an entity whose movement it simulates itself: fluids,
/// gravity, <c>move</c>, the blocks under and inside it, and pistons. Not simulated: portals, and sounds,
/// which <c>ClientLevel.playSeededSound</c> drops for anything but the player.
/// </summary>
public abstract class PhysicsEntity(MinecraftClient client) : ClientEntity, ICollisionEntity, IBlockEntityMovable {
    protected readonly MinecraftClient Client = client;

    private (int X, int Y, int Z)? _mainSupportingBlock;
    private bool _onGroundNoBlocks;
    private Vec3d _stuckSpeedMultiplier = Vec3d.Zero;
    private readonly List<Box> _entityColliders = [];
    private readonly TickMovements _movements = new();
    private readonly PistonMovementLimit _pistonLimit = new();

    public bool HorizontalCollision { get; private set; }
    public bool VerticalCollision { get; private set; }
    public bool VerticalCollisionBelow { get; private set; }

    /// <summary><c>Entity.wasTouchingWater</c>, which <c>isInWater</c> reads.</summary>
    public bool IsInWater { get; private set; }

    public bool IsInLava => !FirstTick && Fluids.InLava;
    protected bool FirstTick { get; set; } = true;
    public FluidInteraction Fluids { get; } = new();
    public double FallDistance { get; protected set; }

    internal ClientLevel Level => Client.Level!;

    protected int BlockX => (int)Math.Floor(Position.X);
    protected int BlockY => (int)Math.Floor(Position.Y);
    protected int BlockZ => (int)Math.Floor(Position.Z);

    /// <summary><c>Entity.getDimensions(getPose())</c>.</summary>
    public override (float Width, float Height) Dimensions => ((float)Width, (float)Height);

    /// <summary><c>EntityDimensions.makeBoundingBox</c>: the half width is a float before it is widened.</summary>
    public Box MakeBoundingBox(Vec3d position) {
        (float width, float height) = Dimensions;
        float w = width / 2.0F;
        return new Box(position.X - w, position.Y, position.Z - w, position.X + w, position.Y + height, position.Z + w);
    }

    public override Box BoundingBox => MakeBoundingBox(Position);

    protected virtual double DefaultGravity => Type.Acceleration;

    /// <summary><c>Entity.getGravity</c>.</summary>
    public double Gravity => Get(EntityDataFields.Entity.NoGravity) ? 0.0 : DefaultGravity;

    protected virtual double EffectiveGravity => Gravity;

    protected virtual float AirDrag => Type.AirDrag;

    protected virtual float MaxUpStep => 0.0F;

    /// <summary><c>Entity.getEntityBounciness</c>.</summary>
    protected virtual double EntityBounciness => 0.0;

    protected virtual bool IsPushedByFluid => true;

    /// <summary><c>getEyeY</c>: vanilla keeps the eye height as a float.</summary>
    protected virtual double EyeY => Position.Y + (float)EyeHeight;

    /// <summary>The offset <c>getBlockPosBelowThatAffectsMyMovement</c> passes to <c>getOnPos</c>.</summary>
    protected virtual float BelowThatAffectsMovementOffset => 0.500001F;

    /// <summary><c>CollisionContext.of(this)</c>.</summary>
    protected EntityCollisionContext CollisionContext => new(this, IsCrouching);

    public bool CanWalkOnPowderSnow =>
        LevelCollisions.CanWalkOnPowderSnow(Client, this, GetItemBySlot(EquipmentSlot.Boots).Type.Identifier == Item.LeatherBoots.Identifier);

    /// <summary><c>CollisionGetter.noCollision(this, box)</c>: no block and no entity this collides with.</summary>
    internal bool NoCollision(Box box) => LevelCollisions.NoCollision(Level, box, CollisionContext) && EntityCollisions.None(Client, this, box);

    /// <summary><c>Entity.baseTick</c>, as far as it moves anything on a client.</summary>
    protected void BaseTick() {
        UpdateFluidInteraction();
        if (IsInLava) {
            FallDistance *= 0.5;
        }
        CheckBelowWorld();
        FirstTick = false;
    }

    /// <summary><c>Entity.checkBelowWorld</c>.</summary>
    private void CheckBelowWorld() {
        if (Position.Y < Level.MinY - 64) {
            OnBelowWorld();
        }
    }

    /// <summary><c>Entity.onBelowWorld</c>, which discards on a client as on the server.</summary>
    protected virtual void OnBelowWorld() => Client.Discard(this);

    /// <summary>
    /// <c>Entity.updateFluidInteraction</c>. The splash it runs is a sound the client drops and particles, which
    /// <see cref="Particles.EntityParticles"/> makes when it sees <see cref="IsInWater"/> turn on.
    /// </summary>
    protected bool UpdateFluidInteraction() {
        Fluids.Update(Level, BoundingBox, BlockX, EyeY, BlockZ, !IsPushedByFluid);
        bool inWater = Fluids.InWater;
        bool inLava = Fluids.InLava;
        if (inWater) {
            FallDistance = 0.0;
        }
        IsInWater = inWater;
        if (IsPushedByFluid) {
            if (inWater) {
                DeltaMovement += Fluids.CurrentImpulse(FluidKind.Water, DeltaMovement, 0.014, player: false);
            }
            if (inLava) {
                // The fast_lava environment attribute is the nether's; the client does not read
                // environment attributes, so the overworld's rate is used everywhere.
                DeltaMovement += Fluids.CurrentImpulse(FluidKind.Lava, DeltaMovement, 0.0023333333333333335, player: false);
            }
        }
        return inWater || inLava;
    }

    /// <summary><c>Entity.applyGravity</c>.</summary>
    protected void ApplyGravity() {
        double gravity = Gravity;
        if (gravity != 0.0) {
            DeltaMovement = DeltaMovement.Add(0.0, -gravity, 0.0);
        }
    }

    /// <summary>
    /// <c>Entity.move</c>. Unless this client is authoritative the vertical state only updates on a move
    /// with a vertical part, and a collision never bounces it.
    /// </summary>
    protected void Move(Vec3d delta, MoverType moverType = MoverType.Self) {
        if (moverType == MoverType.Piston) {
            delta = _pistonLimit.Limit(delta, Level.GameTime);
            if (delta == Vec3d.Zero) {
                return;
            }
        }

        if (_stuckSpeedMultiplier.LengthSqr() > 1.0E-7) {
            if (moverType != MoverType.Piston) {
                delta = delta.Multiply(_stuckSpeedMultiplier.X, _stuckSpeedMultiplier.Y, _stuckSpeedMultiplier.Z);
            }
            _stuckSpeedMultiplier = Vec3d.Zero;
            DeltaMovement = Vec3d.Zero;
        }

        Box box = BoundingBox;
        EntityCollisions.Collect(Client, this, box.ExpandTowards(delta.X, delta.Y, delta.Z), _entityColliders);
        Vec3d movement = LevelCollisions.Collide(Level, box, delta, OnGround, MaxUpStep, CollisionContext, _entityColliders);
        double movementLength = movement.LengthSqr();
        if (movementLength > 1.0E-7 || delta.LengthSqr() - movementLength < 1.0E-7) {
            if (FallDistance != 0.0 && movementLength >= 1.0) {
                double checkDistance = Math.Min(movement.Length(), 8.0);
                if (FallResetClip.Hits(Level, Position, Position + movement.Normalize() * checkDistance, false)) {
                    FallDistance = 0.0;
                }
            }
            _movements.Add(new EntityMovement(Position, Position + movement, delta));
            Position += movement;
        }

        bool xCollision = !MthEqual(delta.X, movement.X);
        bool zCollision = !MthEqual(delta.Z, movement.Z);
        HorizontalCollision = xCollision || zCollision;
        bool movedVertically = Math.Abs(delta.Y) > 0.0;
        bool authoritative = IsLocalInstanceAuthoritative;
        if (movedVertically || authoritative) {
            VerticalCollision = delta.Y != movement.Y;
            VerticalCollisionBelow = VerticalCollision && delta.Y < 0.0;
            OnGround = VerticalCollisionBelow;
            CheckSupportingBlock(VerticalCollisionBelow, movement);
        }

        if (authoritative) {
            (int X, int Y, int Z) effectPos = OnPos(0.2F);
            CheckFallDamage(movement.Y, OnGround);
            if (movedVertically && VerticalCollision || HorizontalCollision) {
                RestituteMovementAfterCollisions(effectPos, xCollision, zCollision, movement);
            }
        }

        float blockSpeedFactor = BlockSpeedFactor();
        DeltaMovement = DeltaMovement.Multiply(blockSpeedFactor, 1.0, blockSpeedFactor);
    }

    private static bool MthEqual(double a, double b) => Math.Abs(b - a) < 1.0E-5F;

    /// <summary><c>Entity.checkFallDamage</c>; <c>Block.fallOn</c> is left to the server.</summary>
    protected virtual void CheckFallDamage(double ya, bool onGround) {
        if (onGround) {
            FallDistance = 0.0;
        }
        else if (ya < 0.0) {
            FallDistance -= ya;
        }
    }

    /// <summary><c>Entity.restituteMovementAfterCollisions</c>.</summary>
    private void RestituteMovementAfterCollisions((int X, int Y, int Z) effectPos, bool xCollision, bool zCollision, Vec3d movement) {
        bool suppressing = IsCrouching;
        double restitution = suppressing ? 0.0 : EntityBounciness;
        Vec3d current = DeltaMovement;
        Vec3d after = current;
        if (xCollision) {
            after = after.WithX(-current.X * restitution);
        }
        if (zCollision) {
            after = after.WithZ(-current.Z * restitution);
        }

        if (VerticalCollision) {
            if (VerticalCollisionBelow) {
                BlockPhysicsData.Entry landed = BlockPhysicsAt(effectPos.X, effectPos.Y, effectPos.Z);
                // Entity.getBlockBounciness: anything not living keeps only 0.8 of the block's bounce.
                double blockBounciness = IsLiving ? landed.BounceRestitution : landed.BounceRestitution * 0.8F;
                restitution = !(-current.Y < EffectiveGravity) && !suppressing && !landed.SuppressesBounce
                    ? Math.Max(restitution, blockBounciness)
                    : 0.0;
            }

            double gravityCompensation = 0.0;
            double effectiveDrag = 1.0;
            if (restitution > 0.0) {
                double portionWithMovement = movement.Y / current.Y;
                gravityCompensation = portionWithMovement * EffectiveGravity;
                effectiveDrag = 1.0 + portionWithMovement * (AirDrag - 1.0);
            }
            after = after.WithY((gravityCompensation - current.Y) * effectiveDrag * restitution);
        }
        DeltaMovement = after;
    }

    public override void SetOnGroundFromServer(bool onGround) => SetOnGround(onGround);

    /// <summary><c>Entity.setOnGround</c>.</summary>
    protected void SetOnGround(bool onGround) {
        OnGround = onGround;
        if (Client.Level != null) {
            CheckSupportingBlock(onGround, null);
        }
    }

    /// <summary><c>Entity.checkSupportingBlock</c>.</summary>
    private void CheckSupportingBlock(bool onGround, Vec3d? movement) {
        if (!onGround) {
            _onGroundNoBlocks = false;
            _mainSupportingBlock = null;
            return;
        }

        Box box = BoundingBox;
        Box testArea = new(box.MinX, box.MinY - 1.0E-6, box.MinZ, box.MaxX, box.MinY, box.MaxZ);
        (int X, int Y, int Z)? supporting = LevelCollisions.FindSupportingBlock(Level, Position, testArea, CollisionContext);
        if (supporting != null || _onGroundNoBlocks) {
            _mainSupportingBlock = supporting;
        }
        else if (movement is { } m) {
            supporting = LevelCollisions.FindSupportingBlock(Level, Position, testArea.Translate(-m.X, 0.0, -m.Z), CollisionContext);
            _mainSupportingBlock = supporting;
        }
        _onGroundNoBlocks = supporting == null;
    }

    /// <summary><c>Entity.getOnPos(offset)</c>.</summary>
    protected (int X, int Y, int Z) OnPos(float offset) {
        if (_mainSupportingBlock is { } pos) {
            if (!(offset > 1.0E-5F)) {
                return pos;
            }
            BlockPhysicsData.Entry below = BlockPhysicsAt(pos.X, pos.Y, pos.Z);
            bool keep = (offset <= 0.5 && below.FenceLike) || below.WallLike;
            return keep ? pos : (pos.X, (int)Math.Floor(Position.Y - offset), pos.Z);
        }
        return (BlockX, (int)Math.Floor(Position.Y - offset), BlockZ);
    }

    protected BlockPhysicsData.Entry BlockPhysicsAt(int x, int y, int z) => BlockPhysicsData.Get(Level.Registry, Level.GetState(x, y, z));

    protected MovementBlocks.Entry BlockAt(int x, int y, int z) => MovementBlocks.Get(Level.Registry, Level.GetState(x, y, z));

    /// <summary><c>getBlock().getFriction()</c> at <c>getBlockPosBelowThatAffectsMyMovement</c>.</summary>
    protected float FrictionBelow() {
        (int X, int Y, int Z) below = OnPos(BelowThatAffectsMovementOffset);
        return BlockPhysicsAt(below.X, below.Y, below.Z).Friction;
    }

    /// <summary><c>Entity.getBlockSpeedFactor</c>.</summary>
    protected float BlockSpeedFactor() {
        BlockPhysicsData.Entry here = BlockPhysicsAt(BlockX, BlockY, BlockZ);
        if (here.WaterLike || here.SpeedFactor != 1.0) {
            return here.SpeedFactor;
        }
        (int X, int Y, int Z) below = OnPos(BelowThatAffectsMovementOffset);
        return BlockPhysicsAt(below.X, below.Y, below.Z).SpeedFactor;
    }

    /// <summary><c>Entity.getBlockJumpFactor</c>.</summary>
    protected float BlockJumpFactor() {
        float here = BlockPhysicsAt(BlockX, BlockY, BlockZ).JumpFactor;
        (int X, int Y, int Z) below = OnPos(BelowThatAffectsMovementOffset);
        float belowFactor = BlockPhysicsAt(below.X, below.Y, below.Z).JumpFactor;
        return here == 1.0 ? belowFactor : here;
    }

    /// <summary><c>Entity.applyEffectsFromBlocks</c>.</summary>
    protected void ApplyEffectsFromBlocks() => ApplyEffectsFromBlocks(_movements.TakeFinal(OldPosition, Position));

    /// <summary><c>Entity.applyEffectsFromBlocksForLastMovements</c>: last tick's moves again.</summary>
    protected void ApplyEffectsFromBlocksForLastMovements() => ApplyEffectsFromBlocks(_movements.Final);

    private void ApplyEffectsFromBlocks(IReadOnlyList<EntityMovement> movements) {
        // The slime block's stepOn.
        if (OnGround) {
            (int X, int Y, int Z) effectPos = OnPos(0.2F);
            if (BlockClasses.Is(Level.GetBlock(effectPos.X, effectPos.Y, effectPos.Z).Identifier, BlockClass.SlimeBlock)) {
                double absDeltaY = Math.Abs(DeltaMovement.Y);
                if (absDeltaY < 0.1 && !IsCrouching) {
                    double scale = 0.4 + absDeltaY * 0.2;
                    DeltaMovement = DeltaMovement.Multiply(scale, 1.0, scale);
                }
            }
        }
        if (!IsLiving || CurrentHealth > 0.0F) {
            InsideBlocks.Check(Level, movements, MakeBoundingBox, InsideShape, EntityInside);
        }
    }

    /// <summary><c>getEntityInsideCollisionShape</c> of powder snow, the one block whose shape moves anything here.</summary>
    private Box[]? InsideShape(int x, int y, int z, uint stateId) {
        if (!Level.Registry.Blocks.GetByStateId(stateId).Identifier.Equals(Block.PowderSnow.Identifier)) {
            return null;
        }
        return CollisionContext.ShapeOf(Level, Level.Registry, stateId, x, y, z) is { Length: > 0 } shape && shape != LevelCollisions.Block ? shape : null;
    }

    /// <summary>The <c>entityInside</c> of the blocks that move what is inside them.</summary>
    private void EntityInside(int x, int y, int z, uint stateId, int step, bool insideBlock, bool insideFluid, bool isPrecise) {
        if (!insideBlock) {
            return;
        }
        Minecraft.Data.Blocks.IBlock block = Level.Registry.Blocks.GetByStateId(stateId);
        if (block is Minecraft.Data.Generated.BlockTypes.BubbleColumnBlock column) {
            if (isPrecise) {
                if (InsideBlockMovement.NothingAboveBubbleColumn(Level, x, y, z)) {
                    OnAboveBubbleColumn(column.Drag);
                }
                else {
                    DeltaMovement = InsideBlockMovement.InsideBubbleColumn(DeltaMovement, column.Drag);
                    FallDistance = 0.0;
                }
            }
            return;
        }
        if (BlockClasses.Is(block.Identifier, BlockClass.HoneyBlock)) {
            if (InsideBlockMovement.IsSlidingDown(x, y, z, OnGround, Position, DeltaMovement, Dimensions.Width)) {
                DeltaMovement = InsideBlockMovement.SlideMovement(DeltaMovement);
                FallDistance = 0.0;
            }
            return;
        }
        if (MovementBlocks.Get(Level.Registry, stateId).StuckMultiplier is not { } multiplier) {
            return;
        }
        // SweetBerryBushBlock.entityInside only catches a living entity, and powder snow catches a living
        // one only from the block it stands in.
        if (BlockClasses.Is(block.Identifier, BlockClass.SweetBerryBushBlock) && !IsLiving) {
            return;
        }
        if (block.Identifier.Equals(Block.PowderSnow.Identifier) && IsLiving
            && !Level.GetBlock(BlockX, BlockY, BlockZ).Identifier.Equals(Block.PowderSnow.Identifier)) {
            return;
        }
        if (block.Identifier.Equals(Block.Cobweb.Identifier) && HasEffect(PotionEffectType.Weaving)) {
            multiplier = new Vec3d(0.5, 0.25, 0.5);
        }
        FallDistance = 0.0;
        _stuckSpeedMultiplier = multiplier;
    }

    /// <summary><c>Entity.onAboveBubbleColumn</c>; the particles it sends are the server's.</summary>
    protected virtual void OnAboveBubbleColumn(bool dragDown) {
        DeltaMovement = InsideBlockMovement.AboveBubbleColumn(DeltaMovement, dragDown);
    }

    public bool IsSupportedBy(int x, int y, int z) => _mainSupportingBlock == (x, y, z);

    public void MoveByPiston(Vec3d delta) {
        Vec3d previousPos = Position;
        Move(delta, MoverType.Piston);
        ApplyEffectsFromBlocks([new EntityMovement(previousPos, Position)]);
        _movements.RemoveLatest();
    }

    public void MoveByShulkerBox(Vec3d delta) => Move(delta, MoverType.ShulkerBox);

    /// <summary>Only a player is ever a spectator.</summary>
    public bool IsAliveAndNotSpectator => !IsRemoved && (!IsLiving || CurrentHealth > 0.0F);

    public void CheckFallDistanceAccumulation() {
        if (DeltaMovement.Y > -0.5 && FallDistance > 1.0) {
            FallDistance = 1.0;
        }
    }
}
