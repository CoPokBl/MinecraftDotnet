using ClientLib.Maths;
using ClientLib.Physics;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Data.Generated.BlockTypes;
using Minecraft.Physics;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Entities.Meta;
using Minecraft.Schemas.Items;
using ClientLib.Interaction;
using Mth = Minecraft.Schemas.Mth;
using Attribute = Minecraft.Data.Generated.Attribute;

namespace ClientLib.Player;

/// <summary>
/// <c>Entity.move</c> and what it runs for the player: collisions, fall damage, step sounds, the
/// supporting block, and fire.
/// </summary>
public sealed partial class LocalPlayer : ICollisionEntity {
    private readonly List<Box> _entityColliders = [];

    /// <summary><c>Entity.isInPowderSnow</c>, set by the <c>FREEZE</c> effect, and the last tick's.</summary>
    private bool _isInPowderSnow, _wasInPowderSnow;

    /// <summary><c>CollisionContext.of(this)</c>.</summary>
    private EntityCollisionContext CollisionContext => new(this, KeyPresses.Shift);

    public bool CanWalkOnPowderSnow =>
        LevelCollisions.CanWalkOnPowderSnow(_client, this, _client.Inventory.Get(36) is { IsEmpty: false } feet && feet.Is(Item.LeatherBoots));

    /// <summary><c>LocalPlayer.move</c>: the walked distance view bobbing swings with.</summary>
    private void Move(Vec3d delta, MoverType moverType = MoverType.Self) {
        double prevX = Position.X, prevZ = Position.Z;
        EntityMove(delta, moverType);
        float deltaX = (float)(Position.X - prevX), deltaZ = (float)(Position.Z - prevZ);
        WalkDist += MathF.Sqrt(deltaX * deltaX + deltaZ * deltaZ) * 0.6F;
    }

    /// <summary><c>move(MoverType.SHULKER, delta)</c>: a shulker opening under or beside the player.</summary>
    internal void ShulkerMove(Vec3d delta) => Move(delta, MoverType.Shulker);

    /// <summary><c>Entity.move</c>.</summary>
    private void EntityMove(Vec3d delta, MoverType moverType) {
        if (NoPhysics) {
            Position += delta;
            HorizontalCollision = false;
            VerticalCollision = false;
            VerticalCollisionBelow = false;
            MinorHorizontalCollision = false;
            return;
        }

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

        if (moverType is MoverType.Self or MoverType.Player) {
            delta = MaybeBackOffFromEdge(delta);
        }
        Box box = BoundingBox;
        EntityCollisions.Collect(_client, this, box.ExpandTowards(delta.X, delta.Y, delta.Z), _entityColliders);
        Vec3d movement = LevelCollisions.Collide(Level, box, delta, OnGround, MaxUpStep, CollisionContext, _entityColliders);
        double movementLength = movement.LengthSqr();
        if (movementLength > 1.0E-7 || delta.LengthSqr() - movementLength < 1.0E-7) {
            if (FallDistance != 0.0 && movementLength >= 1.0) {
                double checkDistance = Math.Min(movement.Length(), 8.0);
                if (FallResetClip.Hits(Level, Position, Position + movement.Normalize() * checkDistance, true)) {
                    FallDistance = 0.0;
                }
            }
            _movements.Add(new EntityMovement(Position, Position + movement, delta));
            Position += movement;
        }

        bool xCollision = !MthEqual(delta.X, movement.X);
        bool zCollision = !MthEqual(delta.Z, movement.Z);
        HorizontalCollision = xCollision || zCollision;
        // A local player is always authoritative over itself, so the vertical state updates every move.
        VerticalCollision = delta.Y != movement.Y;
        VerticalCollisionBelow = VerticalCollision && delta.Y < 0.0;
        SetOnGround(VerticalCollisionBelow, movement);

        MinorHorizontalCollision = HorizontalCollision && IsHorizontalCollisionMinor(movement);

        (int X, int Y, int Z) effectPos = OnPos(0.2F);
        ushort effectState = Level.GetState(effectPos.X, effectPos.Y, effectPos.Z);
        CheckFallDamage(movement.Y, OnGround, effectPos, effectState);

        if (Math.Abs(delta.Y) > 0.0 && VerticalCollision || HorizontalCollision) {
            RestituteMovementAfterCollisions(xCollision, zCollision, movement);
        }

        // Player.getMovementEmission is NONE or ALL, so a step that emits anything emits sounds.
        if (!Flying && !(OnGround && KeyPresses.Shift) && VehicleId == null) {
            ApplyMovementEmissionAndPlaySound(movement, effectPos, effectState);
        }

        float blockSpeedFactor = BlockSpeedFactor();
        DeltaMovement = DeltaMovement.Multiply(blockSpeedFactor, 1.0, blockSpeedFactor);
    }

    private static bool MthEqual(double a, double b) => Math.Abs(b - a) < 1.0E-5F;

    private float MaxUpStep => (float)AttributeValue(Attribute.StepHeight);

    /// <summary><c>LivingEntity.checkFallDamage</c> then <c>Entity.checkFallDamage</c>, client side.</summary>
    private void CheckFallDamage(double ya, bool onGround, (int X, int Y, int Z) pos, ushort onState) {
        if (!IsInWater) {
            UpdateFluidInteraction();
        }
        if (!IsInWater && ya < 0.0) {
            FallDistance -= (float)ya;
        }
        if (onGround) {
            if (FallDistance > 0.0) {
                FellOn?.Invoke(pos, Level.Registry.Blocks.GetByStateId(onState), FallDistance);
            }
            FallDistance = 0.0;
        }
    }

    /// <summary><c>Entity.applyMovementEmissionAndPlaySound</c>. The game events it also emits do nothing on a client.</summary>
    private void ApplyMovementEmissionAndPlaySound(Vec3d clippedMovement, (int X, int Y, int Z) effectPos, ushort effectState) {
        float movedDistance = (float)(clippedMovement.Length() * 0.6F);
        float horizontalMovedDistance = (float)(Math.Sqrt(clippedMovement.HorizontalDistanceSqr()) * 0.6F);
        (int X, int Y, int Z) supportingPos = OnPos(1.0E-5F);
        ushort supportingState = Level.GetState(supportingPos.X, supportingPos.Y, supportingPos.Z);
        bool climbing = IsStateClimbable(supportingState);
        _moveDist += climbing ? movedDistance : horizontalMovedDistance;
        if (_moveDist > _nextStep && !Level.IsAir(supportingState)) {
            bool onlyEffectStateEmittions = supportingPos == effectPos;
            bool producedSideEffects = VibrationAndSoundEffectsFromBlock(effectPos, effectState, true, clippedMovement);
            if (!onlyEffectStateEmittions) {
                producedSideEffects |= VibrationAndSoundEffectsFromBlock(supportingPos, supportingState, false, clippedMovement);
            }

            if (producedSideEffects) {
                _nextStep = NextStep();
            }
            else if (IsInWater) {
                _nextStep = NextStep();
                SwimStroke?.Invoke();
            }
        }
    }

    private float NextStep() => (int)_moveDist + 1;

    /// <summary><c>Entity.isStateClimbable</c>.</summary>
    private bool IsStateClimbable(ushort state) => MovementBlocks.Get(Level.Registry, state).Climbable || IsBlock(state, Block.PowderSnow);

    private bool IsBlock(uint state, IBlock block) => Level.Registry.Blocks.GetByStateId(state).Identifier.Equals(block.Identifier);

    /// <summary><c>Entity.vibrationAndSoundEffectsFromBlock</c>. A player is never on rails.</summary>
    private bool VibrationAndSoundEffectsFromBlock((int X, int Y, int Z) pos, ushort blockState, bool shouldSound, Vec3d clippedMovement) {
        if (Level.IsAir(blockState)) {
            return false;
        }
        bool isClimbable = IsStateClimbable(blockState);
        if ((OnGround || isClimbable || Crouching && clippedMovement.Y == 0.0) && !Swimming) {
            if (shouldSound) {
                Stepped?.Invoke(pos, Level.Registry.Blocks.GetByStateId(blockState));
            }
            return true;
        }
        return false;
    }

    /// <summary>
    /// <c>Entity.restituteMovementAfterCollisions</c>. A player is living, so its bounce comes from
    /// the bounciness attribute and a block's restitution is taken whole.
    /// </summary>
    private void RestituteMovementAfterCollisions(bool xCollision, bool zCollision, Vec3d movement) {
        bool suppressing = KeyPresses.Shift;
        double restitution = suppressing ? 0.0 : AttributeValue(Attribute.Bounciness);
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
                (int X, int Y, int Z) on = OnPos(0.2F);
                BlockPhysicsData.Entry landed = BlockPhysicsAt(on.X, on.Y, on.Z);
                restitution = !(-current.Y < EffectiveGravity()) && !suppressing && !landed.SuppressesBounce
                    ? Math.Max(restitution, landed.BounceRestitution)
                    : 0.0;
            }

            double gravityCompensation = 0.0;
            double effectiveDrag = 1.0;
            if (restitution > 0.0) {
                double portionWithMovement = movement.Y / current.Y;
                gravityCompensation = portionWithMovement * EffectiveGravity();
                float airDrag = ComputeModifiedFriction(0.98F, (float)AttributeValue(Attribute.AirDragModifier));
                effectiveDrag = 1.0 + portionWithMovement * (airDrag - 1.0);
            }
            after = after.WithY((gravityCompensation - current.Y) * effectiveDrag * restitution);
        }
        DeltaMovement = after;
    }

    /// <summary><c>LocalPlayer.isHorizontalCollisionMinor</c>: the wall was hit at a glancing angle.</summary>
    private bool IsHorizontalCollisionMinor(Vec3d movement) {
        float yRotInRadians = YRot * ((float)Math.PI / 180.0F);
        double yRotSin = Mth.Sin(yRotInRadians);
        double yRotCos = Mth.Cos(yRotInRadians);
        double globalXA = _xxa * yRotCos - _zza * yRotSin;
        double globalZA = _zza * yRotCos + _xxa * yRotSin;
        double aLengthSquared = globalXA * globalXA + globalZA * globalZA;
        double movementLengthSquared = movement.X * movement.X + movement.Z * movement.Z;
        if (aLengthSquared < 1.0E-5F || movementLengthSquared < 1.0E-5F) {
            return false;
        }
        double dot = globalXA * movement.X + globalZA * movement.Z;
        double angle = Math.Acos(dot / Math.Sqrt(aLengthSquared * movementLengthSquared));
        return angle < 0.13962634F;
    }

    /// <summary><c>Player.maybeBackOffFromEdge</c>: sneaking does not walk off an edge.</summary>
    private Vec3d MaybeBackOffFromEdge(Vec3d delta) {
        float maxDownStep = MaxUpStep;
        if (Flying || delta.Y > 0.0 || !KeyPresses.Shift || !IsAboveGround(maxDownStep)) {
            return delta;
        }

        double deltaX = delta.X;
        double deltaZ = delta.Z;
        double stepX = Math.Sign(deltaX) * 0.05;
        double stepZ = Math.Sign(deltaZ) * 0.05;

        while (deltaX != 0.0 && CanFallAtLeast(deltaX, 0.0, maxDownStep)) {
            if (Math.Abs(deltaX) <= 0.05) {
                deltaX = 0.0;
                break;
            }
            deltaX -= stepX;
        }

        while (deltaZ != 0.0 && CanFallAtLeast(0.0, deltaZ, maxDownStep)) {
            if (Math.Abs(deltaZ) <= 0.05) {
                deltaZ = 0.0;
                break;
            }
            deltaZ -= stepZ;
        }

        while (deltaX != 0.0 && deltaZ != 0.0 && CanFallAtLeast(deltaX, deltaZ, maxDownStep)) {
            if (Math.Abs(deltaX) <= 0.05) {
                deltaX = 0.0;
            }
            else {
                deltaX -= stepX;
            }
            if (Math.Abs(deltaZ) <= 0.05) {
                deltaZ = 0.0;
            }
            else {
                deltaZ -= stepZ;
            }
        }

        return new Vec3d(deltaX, delta.Y, deltaZ);
    }

    private bool IsAboveGround(float maxDownStep) {
        return OnGround || FallDistance < maxDownStep && !CanFallAtLeast(0.0, 0.0, maxDownStep - FallDistance);
    }

    private bool CanFallAtLeast(double deltaX, double deltaZ, double minHeight) {
        Box box = BoundingBox;
        Box below = new(
            box.MinX + 1.0E-7 + deltaX,
            box.MinY - minHeight - 1.0E-7,
            box.MinZ + 1.0E-7 + deltaZ,
            box.MaxX - 1.0E-7 + deltaX,
            box.MinY,
            box.MaxZ - 1.0E-7 + deltaZ);
        return LevelCollisions.NoCollision(Level, below, CollisionContext) && EntityCollisions.None(_client, this, below);
    }

    /// <summary><c>Entity.setOnGroundWithMovement</c> and its <c>checkSupportingBlock</c>.</summary>
    private void SetOnGround(bool onGround, Vec3d? movement = null) {
        OnGround = onGround;
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
    private (int X, int Y, int Z) OnPos(float offset) {
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

    private BlockPhysicsData.Entry BlockPhysicsAt(int x, int y, int z) => BlockPhysicsData.Get(Level.Registry, Level.GetState(x, y, z));

    /// <summary><c>Entity.getBlockJumpFactor</c>.</summary>
    private float BlockJumpFactor() {
        float here = BlockPhysicsAt(BlockX, BlockY, BlockZ).JumpFactor;
        (int X, int Y, int Z) below = OnPos(0.500001F);
        float belowFactor = BlockPhysicsAt(below.X, below.Y, below.Z).JumpFactor;
        return here == 1.0 ? belowFactor : here;
    }

    /// <summary><c>Player.getBlockSpeedFactor</c> over <c>Entity.getBlockSpeedFactor</c>.</summary>
    private float BlockSpeedFactor() {
        if (Flying) {
            return 1.0F;
        }
        BlockPhysicsData.Entry here = BlockPhysicsAt(BlockX, BlockY, BlockZ);
        if (here.WaterLike) {
            return here.SpeedFactor;
        }
        if (here.SpeedFactor != 1.0) {
            return here.SpeedFactor;
        }
        (int X, int Y, int Z) below = OnPos(0.500001F);
        return BlockPhysicsAt(below.X, below.Y, below.Z).SpeedFactor;
    }

    /// <summary>The <c>InsideBlockEffectType</c>s a block or fluid can apply, as flags in their apply order.</summary>
    [Flags]
    private enum InsideEffect { None = 0, Freeze = 1, ClearFreeze = 2, FireIgnite = 4, LavaIgnite = 8, Extinguish = 16 }

    /// <summary>The effects of a block the player is inside, from its <c>entityInside</c>.</summary>
    private static InsideEffect InsideEffectOf(IBlock block) {
        if (BlockClasses.Is(block.Identifier, BlockClass.BaseFireBlock)) {
            return InsideEffect.ClearFreeze | InsideEffect.FireIgnite;
        }
        if (BlockClasses.Is(block.Identifier, BlockClass.LavaCauldronBlock)) {
            return InsideEffect.ClearFreeze | InsideEffect.LavaIgnite;
        }
        if (BlockClasses.Is(block.Identifier, BlockClass.PowderSnowBlock)) {
            return InsideEffect.Freeze | InsideEffect.Extinguish;
        }
        if (BlockClasses.Is(block.Identifier, BlockClass.LayeredCauldronBlock)) {
            return InsideEffect.Extinguish;
        }
        return InsideEffect.None;
    }

    /// <summary>
    /// The effects in <c>InsideBlockEffectType</c> order, so water wins over fire. The client's own fire
    /// ticks are cleared every <c>baseTick</c> and kept lit only by these, so the player burns here ahead
    /// of the server's flag; its frozen ticks only ever climb here, and the server's updates bring them
    /// back down. <c>isInRain</c> clearing the fire is left out: the client keeps no rain heightmap.
    /// </summary>
    private void ApplyInsideEffects(InsideEffect effects) {
        if (IsDead) {
            return;
        }
        if ((effects & InsideEffect.Freeze) != 0) {
            _isInPowderSnow = true;
            if (CanFreeze) {
                SetTicksFrozen(Math.Min(TicksRequiredToFreeze, TicksFrozen + 1));
            }
        }
        if ((effects & InsideEffect.ClearFreeze) != 0) {
            SetTicksFrozen(0);
        }
        if ((effects & InsideEffect.FireIgnite) != 0 && !FireImmune) {
            // BaseFireBlock.fireIgnite: the random extra ticks are a ServerPlayer's alone.
            if (RemainingFireTicks < 0) {
                SetRemainingFireTicks(RemainingFireTicks + 1);
            }
            if (RemainingFireTicks >= 0) {
                IgniteForTicks(160);
            }
        }
        if ((effects & InsideEffect.LavaIgnite) != 0 && !FireImmune) {
            IgniteForTicks(300);
        }
        if ((effects & InsideEffect.Extinguish) != 0) {
            ClearFire();
        }
    }

    private static readonly Identifier FreezeImmuneWearablesTag = "minecraft:freeze_immune_wearables";

    /// <summary>
    /// <c>LivingEntity.canFreeze</c>: not a spectator and wearing nothing tagged <c>freeze_immune_wearables</c>.
    /// Item tags have no generated type, so the tag is named here.
    /// </summary>
    private bool CanFreeze {
        get {
            if (IsSpectator) {
                return false;
            }
            if (!Level.Registry.Items.Tags.Contains(FreezeImmuneWearablesTag)) {
                return true;
            }
            Identifier[] immune = Level.Registry.Items.Tags[FreezeImmuneWearablesTag].GetValueIds(Level.Registry).ToArray();
            foreach (EquipmentSlot slot in (ReadOnlySpan<EquipmentSlot>)[EquipmentSlot.Boots, EquipmentSlot.Leggings, EquipmentSlot.Chestplate, EquipmentSlot.Helmet]) {
                ItemStack worn = EquippedItem(slot);
                if (!ItemComponents.IsEmpty(worn) && immune.Contains(worn.Type.Identifier)) {
                    return false;
                }
            }
            return true;
        }
    }

    /// <summary><c>Entity.setTicksFrozen</c>, on the client's copy, which the server's next update overwrites.</summary>
    private void SetTicksFrozen(int ticks) => Set(EntityDataFields.Entity.TicksFrozen, MetaFieldType.VarInt, ticks);

    /// <summary><c>Entity.clearFire</c>.</summary>
    private void ClearFire() => SetRemainingFireTicks(Math.Min(0, RemainingFireTicks));

    /// <summary><c>Player.setRemainingFireTicks</c>.</summary>
    private void SetRemainingFireTicks(int remainingTicks) => RemainingFireTicks = Invulnerable ? Math.Min(remainingTicks, 1) : remainingTicks;

    /// <summary><c>Entity.igniteForTicks</c>.</summary>
    private void IgniteForTicks(int numberOfTicks) {
        if (RemainingFireTicks < numberOfTicks) {
            SetRemainingFireTicks(numberOfTicks);
        }
        SetTicksFrozen(0);
    }
}
