using ClientLib.Entities;
using ClientLib.Maths;
using ClientLib.Physics;
using ClientLib.World;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Physics;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities.Attributes;
using Minecraft.Schemas.Items;
using Attribute = Minecraft.Data.Generated.Attribute;

namespace ClientLib.Player;

/// <summary>Vanilla's <c>Pose</c>, in its declaration order.</summary>
public enum EntityPose {
    Standing,
    FallFlying,
    Sleeping,
    Swimming,
    SpinAttack,
    Crouching,
    LongJumping,
    Dying
}

/// <summary>
/// The movement half of <c>LocalPlayer</c> and <c>Player</c>: <c>tick</c>, <c>aiStep</c>, input,
/// sprinting and pose, transcribed so the server sees the positions a vanilla client would send. Auto jump
/// is not simulated.
/// </summary>
public sealed partial class LocalPlayer {
    private static readonly Identifier SprintingModifierId = "minecraft:sprinting";
    private static readonly AttributeModifier SprintingModifier = new(SprintingModifierId, 0.3F, AttributeOperation.AddMultipliedTotal);

    /// <summary>Vanilla's <c>sprintWindow</c> option default, in ticks.</summary>
    public int SprintWindow { get; set; } = 7;

    public EntityPose Pose { get; private set; } = EntityPose.Standing;
    public bool Crouching { get; private set; }
    /// <summary><c>Player.isSwimming</c>: shared flag 4, which the server can clear between ticks.</summary>
    public bool Swimming => !Flying && !IsSpectator && (SharedFlags & 1 << 4) != 0;
    public bool NoPhysics { get; private set; }
    public double FallDistance { get; private set; }
    public bool VerticalCollision { get; private set; }
    public bool VerticalCollisionBelow { get; private set; }
    public bool MinorHorizontalCollision { get; private set; }
    public bool Jumping { get; private set; }
    public bool IsInWater { get; private set; }
    public bool IsUnderWater { get; private set; }

    public FluidInteraction Fluids { get; } = new();

    /// <summary>What <c>aiStep</c> read the keys as this tick; the host's <see cref="Input"/> is copied in by <c>input.tick()</c>.</summary>
    public PlayerInput KeyPresses { get; private set; } = PlayerInput.None;

    private float _moveLeft, _moveForward;
    private float _xxa, _zza;
    private int _noJumpDelay;
    private int _jumpTriggerTime;
    private int _sprintTriggerTime;
    private bool _firstTick = true;
    private bool _onGroundNoBlocks;
    private (int X, int Y, int Z)? _mainSupportingBlock;
    private Vec3d _stuckSpeedMultiplier = Vec3d.Zero;
    private float _moveDist;
    private float _nextStep = 1.0F;

    /// <summary><c>Entity.walkingStepSound</c>: a step lands on the block at the position.</summary>
    public event Action<(int X, int Y, int Z), IBlock>? Stepped;

    /// <summary><c>Entity.waterSwimSound</c> from <c>applyMovementEmissionAndPlaySound</c>: a step taken in water that no block took.</summary>
    public event Action? SwimStroke;

    /// <summary><c>Entity.doWaterSplashEffect</c>: the first tick touching water.</summary>
    public event Action? SplashedIntoWater;

    /// <summary><c>Block.fallOn</c>: the player lands on the block at the position, having fallen the distance.</summary>
    public event Action<(int X, int Y, int Z), IBlock, double>? FellOn;

    public float BbWidth => 0.6F;

    public float BbHeight => DimensionsOf(Pose).Height;

    public override float CurrentEyeHeight => EyeHeightOf(Pose);

    internal static float EyeHeightOf(EntityPose pose) => pose switch {
        EntityPose.Crouching => 1.27F,
        EntityPose.Sleeping => 0.2F,
        EntityPose.Swimming or EntityPose.FallFlying or EntityPose.SpinAttack => 0.4F,
        _ => 1.62F
    };

    /// <summary><c>Avatar.POSES</c>' sizes, before the scale attribute; a dying one's is fixed rather than scaled.</summary>
    internal static (float Width, float Height) DimensionsOf(EntityPose pose) => pose switch {
        EntityPose.Crouching => (0.6F, 1.5F),
        EntityPose.Swimming or EntityPose.FallFlying or EntityPose.SpinAttack => (0.6F, 0.6F),
        EntityPose.Dying or EntityPose.Sleeping => (0.2F, 0.2F),
        _ => (0.6F, 1.8F)
    };

    /// <summary><c>EntityDimensions.makeBoundingBox</c>: the half width is a float before it is widened.</summary>
    private static Box MakeBoundingBox(EntityPose pose, Vec3d position) {
        (float width, float height) = DimensionsOf(pose);
        float w = width / 2.0F;
        return new Box(position.X - w, position.Y, position.Z - w, position.X + w, position.Y + height, position.Z + w);
    }

    public override Box BoundingBox => MakeBoundingBox(Pose, Position);

    private ClientLevel Level => _client.Level!;

    public double AttributeValue(Minecraft.Data.Attributes.IAttribute attribute) => Attributes.Value(attribute);

    /// <summary><c>LivingEntity.setSprinting</c>.</summary>
    public void SetSprinting(bool sprinting) {
        SetSharedFlag(3, sprinting);
        AttributeMap.Instance speed = Attributes.GetOrCreate(Attribute.MovementSpeed);
        speed.RemoveModifier(SprintingModifierId);
        if (sprinting) {
            speed.AddModifier(SprintingModifier);
        }
    }

    /// <summary>
    /// <c>ClientLevel.tickNonPassenger</c> and <c>LocalPlayer.tick</c>: the old position is kept for
    /// rendering between ticks, then nothing moves until the level has loaded, as vanilla's
    /// <c>hasClientLoaded</c> check.
    /// </summary>
    public void ClientTick() {
        OldPosition = Position;
        YRotO = YRot;
        XRotO = XRot;
        YHeadRotO = YHeadRot;
        WalkDistO = WalkDist;
        // Entity.commonTick: only a teleport_entity naming the player starts one.
        Interpolation.Interpolate();
        if (!_client.ClientLoaded || _client.Level == null) {
            return;
        }

        PlayerTick();
        UpdateWalkAnimation();
        TickBodyRotation();
        SendInputIfChanged(KeyPresses.ToPacketFlags());
        if (IsPassenger) {
            SendRidingPosition();
        }
        else {
            SendPosition();
        }
    }

    /// <summary><c>Player.tick</c>, which wraps <c>LivingEntity.tick</c>.</summary>
    private void PlayerTick() {
        NoPhysics = IsSpectator;
        if (IsSpectator || VehicleId != null) {
            SetOnGround(false);
        }

        TickSleepCounter();
        IsUnderWater = Fluids.EyeInWater;

        BaseTick();
        UpdatingUsingItem();
        AiStep();
        // LivingEntity.tick, after aiStep.
        if (IsSleeping) {
            XRot = 0.0F;
        }

        double x = Math.Clamp(Position.X, -2.9999999E7, 2.9999999E7);
        double z = Math.Clamp(Position.Z, -2.9999999E7, 2.9999999E7);
        if (x != Position.X || z != Position.Z) {
            Position = new Vec3d(x, Position.Y, z);
        }

        AttackStrengthTicker++;
        ItemSwapTicker++;
        ItemStack mainHand = ItemInHand(Hand.MainHand);
        if (!mainHand.Equals(_lastItemInMainHand)) {
            if (mainHand.Type.Identifier != _lastItemInMainHand.Type.Identifier) {
                ResetAttackStrengthTicker();
            }
            _lastItemInMainHand = mainHand;
        }

        Cooldowns.Tick();
        UpdatePlayerPose();
    }

    /// <summary><c>Entity.baseTick</c>, as far as it concerns a client side player.</summary>
    private void BaseTick() {
        TickHurtAndDeath();
        _wasInPowderSnow = _isInPowderSnow;
        _isInPowderSnow = false;
        UpdateFluidInteraction();
        UpdateSwimming();
        ClearFire();
        if (IsInLava) {
            FallDistance *= 0.5;
        }
        _firstTick = false;
    }

    public bool IsInLava => !_firstTick && Fluids.InLava;

    public bool IsAffectedByFluids => !Flying;

    private bool IsPushedByFluid => !Flying;

    /// <summary><c>Entity.updateFluidInteraction</c>.</summary>
    private void UpdateFluidInteraction() {
        Box box = BoundingBox;
        double eyeY = Position.Y + CurrentEyeHeight;
        Box? interactionBox = Vehicle is Entities.Vehicles.ClientBoat boat ? boat.ModifyPassengerFluidInteractionBox(box.Inflate(-0.001)) : box.Inflate(-0.001);
        Fluids.Update(Level, box, interactionBox, BlockX, eyeY, BlockZ, !IsPushedByFluid);
        bool inWater = Fluids.InWater;
        bool inLava = Fluids.InLava;
        if (inWater) {
            FallDistance = 0.0;
            if (!IsInWater && !_firstTick) {
                SplashedIntoWater?.Invoke();
            }
        }
        IsInWater = inWater;
        if (IsPushedByFluid) {
            if (inWater) {
                DeltaMovement += Fluids.CurrentImpulse(FluidKind.Water, DeltaMovement, 0.014);
            }
            if (inLava) {
                // The fast_lava environment attribute is the nether's; the client does not read
                // environment attributes, so the overworld's rate is used everywhere.
                DeltaMovement += Fluids.CurrentImpulse(FluidKind.Lava, DeltaMovement, 0.0023333333333333335);
            }
        }
    }

    /// <summary><c>Player.updateSwimming</c> and <c>Entity.updateSwimming</c>.</summary>
    private void UpdateSwimming() {
        if (Flying) {
            SetSharedFlag(4, false);
            return;
        }
        if (Swimming) {
            SetSharedFlag(4, Sprinting && IsInWater && VehicleId == null);
        }
        else {
            SetSharedFlag(4, Sprinting && IsUnderWater && VehicleId == null && FluidAt(BlockX, BlockY, BlockZ) == FluidKind.Water);
        }
    }

    private int BlockX => (int)Math.Floor(Position.X);
    private int BlockY => (int)Math.Floor(Position.Y);
    private int BlockZ => (int)Math.Floor(Position.Z);

    private MovementBlocks.Entry BlockAt(int x, int y, int z) => MovementBlocks.Get(Level.Registry, Level.GetState(x, y, z));

    private FluidKind FluidAt(int x, int y, int z) => BlockAt(x, y, z).Fluid;

    private int _waterVisionTime;

    /// <summary>
    /// <c>LocalPlayer.getWaterVision</c>: how far the eyes have adjusted under water, rising over the first hundred ticks
    /// to 0.6 and the next five hundred to one, and falling ten times as fast once out.
    /// </summary>
    public float WaterVision {
        get {
            if (!Fluids.EyeInWater) {
                return 0.0F;
            }
            if (_waterVisionTime >= 600.0F) {
                return 1.0F;
            }
            float a = Math.Clamp(_waterVisionTime / 100.0F, 0.0F, 1.0F);
            float b = _waterVisionTime < 100.0F ? 0.0F : Math.Clamp((_waterVisionTime - 100.0F) / 500.0F, 0.0F, 1.0F);
            return a * 0.6F + b * 0.39999998F;
        }
    }

    /// <summary><c>LocalPlayer.aiStep</c>.</summary>
    private void AiStep() {
        if (_sprintTriggerTime > 0) {
            _sprintTriggerTime--;
        }

        // Vanilla skips these behind the level loading screen, where this player is not ticked at all.
        HandlePortalTransitionEffect(ActivePortalLocalTransition == PortalTransition.Confusion);
        ProcessPortalCooldown();

        bool wasJumping = KeyPresses.Jump;
        bool wasShiftKeyDown = KeyPresses.Shift;
        bool hadForwardImpulse = HasForwardImpulse;
        Crouching = !Flying
                    && !Swimming
                    && VehicleId == null
                    && CanFitWhen(EntityPose.Crouching)
                    && (KeyPresses.Shift || !IsSleeping && !CanFitWhen(EntityPose.Standing));

        InputTick();
        bool wasAutoJump = false;
        if (_autoJumpTime > 0) {
            _autoJumpTime--;
            wasAutoJump = true;
            KeyPresses = KeyPresses with { Jump = true };
        }

        if (!NoPhysics) {
            double half = BbWidth * 0.35;
            MoveTowardsClosestSpace(Position.X - half, Position.Z + half);
            MoveTowardsClosestSpace(Position.X - half, Position.Z - half);
            MoveTowardsClosestSpace(Position.X + half, Position.Z - half);
            MoveTowardsClosestSpace(Position.X + half, Position.Z + half);
        }

        if (wasShiftKeyDown || IsSlowDueToUsingItem && VehicleId == null || KeyPresses.Backward) {
            _sprintTriggerTime = 0;
        }

        if (CanStartSprinting()) {
            if (!hadForwardImpulse) {
                if (_sprintTriggerTime > 0) {
                    SetSprinting(true);
                }
                else {
                    _sprintTriggerTime = SprintWindow;
                }
            }
            if (KeyPresses.Sprint) {
                SetSprinting(true);
            }
        }

        if (Sprinting) {
            if (Swimming) {
                if (ShouldStopSwimSprinting()) {
                    SetSprinting(false);
                }
            }
            else if (ShouldStopRunSprinting()) {
                SetSprinting(false);
            }
        }

        bool justToggledCreativeFlight = false;
        if (MayFly) {
            if (IsSpectator) {
                if (!Flying) {
                    Flying = true;
                    justToggledCreativeFlight = true;
                    OnUpdateAbilities();
                }
            }
            else if (!wasJumping && KeyPresses.Jump && !wasAutoJump) {
                if (_jumpTriggerTime == 0) {
                    _jumpTriggerTime = 7;
                }
                else if (!Swimming && (VehicleId == null || JumpableVehicle != null)) {
                    Flying = !Flying;
                    if (Flying && OnGround) {
                        JumpFromGround();
                    }
                    justToggledCreativeFlight = true;
                    OnUpdateAbilities();
                    _jumpTriggerTime = 0;
                }
            }
        }

        MaybeStartFallFlying(wasJumping, justToggledCreativeFlight);

        if (IsInWater && KeyPresses.Shift && IsAffectedByFluids) {
            DeltaMovement = DeltaMovement.Add(0.0, -0.04F, 0.0);
        }

        if (Fluids.EyeInWater) {
            int speed = IsSpectator ? 10 : 1;
            _waterVisionTime = Math.Clamp(_waterVisionTime + speed, 0, 600);
        }
        else if (_waterVisionTime > 0) {
            _waterVisionTime = Math.Clamp(_waterVisionTime - 10, 0, 600);
        }

        if (Flying && IsControlledCamera) {
            int inputYa = 0;
            if (KeyPresses.Shift) {
                inputYa--;
            }
            if (KeyPresses.Jump) {
                inputYa++;
            }
            if (inputYa != 0) {
                DeltaMovement = DeltaMovement.Add(0.0, inputYa * FlyingSpeed * 3.0F, 0.0);
            }
        }

        TickRidingJump(wasJumping);
        UpdateBob();
        PlayerAiStep();

        if (OnGround && Flying && !IsSpectator) {
            Flying = false;
            OnUpdateAbilities();
        }
    }

    /// <summary><c>KeyboardInput.tick</c>: the held keys become this tick's presses and move vector.</summary>
    private void InputTick() {
        KeyPresses = Input;
        float forward = Impulse(KeyPresses.Forward, KeyPresses.Backward);
        float left = Impulse(KeyPresses.Left, KeyPresses.Right);
        // Vec2.normalized
        float length = MathF.Sqrt(left * left + forward * forward);
        if (length < 1.0E-4F) {
            _moveLeft = 0.0F;
            _moveForward = 0.0F;
        }
        else {
            _moveLeft = left / length;
            _moveForward = forward / length;
        }
    }

    private static float Impulse(bool positive, bool negative) => positive == negative ? 0.0F : positive ? 1.0F : -1.0F;

    private bool HasForwardImpulse => _moveForward > 1.0E-5F;

    private void OnUpdateAbilities() {
        _client.Send(new ServerBoundPlayerAbilitiesPacket { Flying = Flying });
    }

    /// <summary><c>LocalPlayer.canStartSprinting</c>.</summary>
    private bool CanStartSprinting() {
        return !Sprinting
               && HasForwardImpulse
               && IsSprintingPossible(Flying)
               && !IsSlowDueToUsingItem
               && (!IsFallFlying || IsUnderWater)
               && (!IsMovingSlowly || IsUnderWater);
    }

    private bool IsSprintingPossible(bool allowedInShallowWater) {
        return !HasEffect(PotionEffectType.Blindness)
               && (IsPassenger ? VehicleCanSprint(Vehicle!) : Food > 6 || MayFly)
               && (allowedInShallowWater || !IsInShallowWater);
    }

    private bool IsInShallowWater => IsInWater && !IsUnderWater;

    private bool ShouldStopRunSprinting() {
        return !IsSprintingPossible(Flying) || !HasForwardImpulse || HorizontalCollision && !MinorHorizontalCollision;
    }

    private bool ShouldStopSwimSprinting() {
        return !IsSprintingPossible(true) || !IsInWater || !HasForwardImpulse && !OnGround && !KeyPresses.Shift;
    }

    public bool IsMovingSlowly => Crouching || IsVisuallyCrawling;

    /// <summary><c>Entity.isVisuallyCrawling</c>, through <c>LivingEntity.isVisuallySwimming</c>.</summary>
    private bool IsVisuallyCrawling => (Pose == EntityPose.Swimming || !IsFallFlying && Pose == EntityPose.FallFlying) && !IsInWater;

    private static readonly Face[] HorizontalFaces = [Face.West, Face.East, Face.North, Face.South];

    /// <summary><c>LocalPlayer.moveTowardsClosestSpace</c>: nudge out of a block the player is stuck in.</summary>
    private void MoveTowardsClosestSpace(double x, double z) {
        int px = (int)Math.Floor(x);
        int pz = (int)Math.Floor(z);
        if (!SuffocatesAt(px, pz)) {
            return;
        }

        double xd = x - px;
        double zd = z - pz;
        Face? best = null;
        double closest = double.MaxValue;
        foreach (Face direction in HorizontalFaces) {
            double axisDistance = Faces.Axis(direction) == 0 ? xd : zd;
            double distanceToEdge = Faces.Positive(direction) ? 1.0 - axisDistance : axisDistance;
            if (distanceToEdge < closest && !SuffocatesAt(px + Faces.StepX(direction), pz + Faces.StepZ(direction))) {
                closest = distanceToEdge;
                best = direction;
            }
        }

        if (best is { } dir) {
            Vec3d old = DeltaMovement;
            DeltaMovement = Faces.Axis(dir) == 0
                ? new Vec3d(0.1 * Faces.StepX(dir), old.Y, old.Z)
                : new Vec3d(old.X, old.Y, 0.1 * Faces.StepZ(dir));
        }
    }

    private bool SuffocatesAt(int x, int z) {
        Box box = BoundingBox;
        Box test = new Box(x, box.MinY, z, x + 1.0, box.MaxY, z + 1.0).Inflate(-1.0E-7);
        return LevelCollisions.CollidesWithSuffocatingBlock(Level, test);
    }

    /// <summary><c>Player.canPlayerFitWithinBlocksAndEntitiesWhen</c>.</summary>
    private bool CanFitWhen(EntityPose pose) {
        Box box = MakeBoundingBox(pose, Position).Inflate(-1.0E-7);
        return LevelCollisions.NoCollision(Level, box, CollisionContext) && EntityCollisions.None(_client, this, box);
    }

    /// <summary><c>Player.aiStep</c>.</summary>
    private void PlayerAiStep() {
        if (_jumpTriggerTime > 0) {
            _jumpTriggerTime--;
        }
        if (Flying && VehicleId == null) {
            FallDistance = 0.0;
        }

        LivingAiStep();
        YHeadRot = YRot;
    }

    /// <summary><c>LocalPlayer.applyInput</c>; spectating something else, the keys only reach the server.</summary>
    private void ApplyInput() {
        if (!IsControlledCamera) {
            _xxa *= 0.98F;
            _zza *= 0.98F;
            return;
        }
        float? itemUseSpeedMultiplier = IsUsingItem && VehicleId == null ? ItemUseSpeedMultiplier : null;
        (float x, float y) = ModifyInput(_moveLeft, _moveForward, itemUseSpeedMultiplier, IsMovingSlowly, (float)AttributeValue(Attribute.SneakingSpeed));
        _xxa = x;
        _zza = y;
        Jumping = KeyPresses.Jump;
    }

    /// <summary><c>LocalPlayer.modifyInput</c>; the item use multiplier is null when no item is in use or the player rides.</summary>
    public static (float X, float Y) ModifyInput(float x, float y, float? itemUseSpeedMultiplier, bool movingSlowly, float sneakingSpeed) {
        if (x * x + y * y == 0.0F) {
            return (x, y);
        }
        x *= 0.98F;
        y *= 0.98F;
        if (itemUseSpeedMultiplier is { } multiplier) {
            x *= multiplier;
            y *= multiplier;
        }
        if (movingSlowly) {
            x *= sneakingSpeed;
            y *= sneakingSpeed;
        }
        return ModifyInputSpeedForSquareMovement(x, y);
    }

    /// <summary><c>LocalPlayer.modifyInputSpeedForSquareMovement</c>: diagonals reach the corners of the unit square.</summary>
    public static (float X, float Y) ModifyInputSpeedForSquareMovement(float x, float y) {
        float length = MathF.Sqrt(x * x + y * y);
        if (length <= 0.0F) {
            return (x, y);
        }
        float dx = x * (1.0F / length);
        float dy = y * (1.0F / length);
        float distanceToUnitSquare = DistanceToUnitSquare(dx, dy);
        float modifiedLength = Math.Min(length * distanceToUnitSquare, 1.0F);
        return (dx * modifiedLength, dy * modifiedLength);
    }

    private static float DistanceToUnitSquare(float x, float y) {
        float ax = Math.Abs(x);
        float ay = Math.Abs(y);
        float tan = ay > ax ? ax / ay : ay / ax;
        return MathF.Sqrt(1.0F + tan * tan);
    }

    /// <summary><c>AbstractClientPlayer.updateBob</c>.</summary>
    private void UpdateBob() {
        float tBob = OnGround && CurrentHealth > 0 && !Swimming
            ? Math.Min(0.1F, (float)Math.Sqrt(DeltaMovement.X * DeltaMovement.X + DeltaMovement.Z * DeltaMovement.Z))
            : 0.0F;
        BobO = Bob;
        Bob += (tBob - Bob) * 0.4F;
    }

    /// <summary><c>Player.updatePlayerPose</c>.</summary>
    private void UpdatePlayerPose() {
        if (!CanFitWhen(EntityPose.Swimming)) {
            return;
        }

        EntityPose desired = IsSleeping ? EntityPose.Sleeping
            : Swimming ? EntityPose.Swimming
            : IsFallFlying ? EntityPose.FallFlying
            : IsAutoSpinAttack ? EntityPose.SpinAttack
            : KeyPresses.Shift && !Flying ? EntityPose.Crouching
            : EntityPose.Standing;
        EntityPose actual;
        if (IsSpectator || VehicleId != null || CanFitWhen(desired)) {
            actual = desired;
        }
        else if (CanFitWhen(EntityPose.Crouching)) {
            actual = EntityPose.Crouching;
        }
        else {
            actual = EntityPose.Swimming;
        }
        Pose = actual;
    }
}
