using ClientLib.Maths;
using ClientLib.Physics;
using Minecraft.Data.Generated;
using Minecraft.Physics;
using Minecraft.Schemas;
using Mth = Minecraft.Schemas.Mth;
using Attribute = Minecraft.Data.Generated.Attribute;

namespace ClientLib.Player;

/// <summary><c>LivingEntity.aiStep</c>'s jump and the <c>travel</c> family, with <c>Player</c>'s overrides.</summary>
public sealed partial class LocalPlayer {
    /// <summary><c>LivingEntity.aiStep</c>.</summary>
    private void LivingAiStep() {
        if (_noJumpDelay > 0) {
            _noJumpDelay--;
        }

        Vec3d movement = DeltaMovement;
        double dx = movement.X;
        double dy = movement.Y;
        double dz = movement.Z;
        if (movement.HorizontalDistanceSqr() < 9.0E-6) {
            dx = 0.0;
            dz = 0.0;
        }
        if (Math.Abs(movement.Y) < 0.003) {
            dy = 0.0;
        }
        DeltaMovement = new Vec3d(dx, dy, dz);

        ApplyInput();
        // Player.isImmobile.
        if (IsDead || IsSleeping) {
            Jumping = false;
            _xxa = 0.0F;
            _zza = 0.0F;
        }

        if (Jumping && IsAffectedByFluids) {
            double fluidHeight = IsInLava ? Fluids.LavaHeight : Fluids.WaterHeight;
            bool inWaterAndHasFluidHeight = IsInWater && fluidHeight > 0.0;
            double fluidJumpThreshold = CurrentEyeHeight < 0.4 ? 0.0 : 0.4;
            if (!inWaterAndHasFluidHeight || OnGround && !(fluidHeight > fluidJumpThreshold)) {
                if (!IsInLava || OnGround && Fluids.LavaHeight <= fluidJumpThreshold) {
                    if ((OnGround || inWaterAndHasFluidHeight && fluidHeight <= fluidJumpThreshold) && _noJumpDelay == 0) {
                        JumpFromGround();
                        _noJumpDelay = 10;
                    }
                }
                else {
                    DeltaMovement = DeltaMovement.Add(0.0, 0.04F, 0.0);
                }
            }
            else {
                DeltaMovement = DeltaMovement.Add(0.0, 0.04F, 0.0);
            }
        }
        else {
            _noJumpDelay = 0;
        }

        if (IsFallFlying) {
            UpdateFallFlying();
        }
        Box beforeTravelBox = BoundingBox;
        Vec3d input = new(_xxa, 0.0, _zza);
        if (HasEffect(PotionEffectType.SlowFalling) || HasEffect(PotionEffectType.Levitation)) {
            FallDistance = 0.0;
        }

        Travel(input);
        ApplyEffectsFromBlocks();
        TickAutoSpinAttack(beforeTravelBox);
    }

    /// <summary><c>LivingEntity.jumpFromGround</c>.</summary>
    private void JumpFromGround() {
        float jumpPower = JumpPower();
        if (jumpPower <= 1.0E-5F) {
            return;
        }
        Vec3d movement = DeltaMovement;
        DeltaMovement = new Vec3d(movement.X, Math.Max(jumpPower, movement.Y), movement.Z);
        if (Sprinting) {
            float angle = YRot * ((float)Math.PI / 180.0F);
            DeltaMovement = DeltaMovement.Add(-Mth.Sin(angle) * 0.2, 0.0, Mth.Cos(angle) * 0.2);
        }
    }

    /// <summary><c>LivingEntity.getJumpPower</c>.</summary>
    private float JumpPower() {
        return (float)AttributeValue(Attribute.JumpStrength) * 1.0F * BlockJumpFactor() + JumpBoostPower();
    }

    private float JumpBoostPower() {
        return GetEffect(PotionEffectType.JumpBoost) is { } boost ? 0.1F * (boost.Amplifier + 1.0F) : 0.0F;
    }

    /// <summary><c>Player.travel</c>.</summary>
    private void Travel(Vec3d input) {
        if (Swimming) {
            double lookAngleY = LookAngleY();
            double multiplier = lookAngleY < -0.2 ? 0.085 : 0.06;
            if (lookAngleY <= 0.0 || Jumping || FluidAt(BlockX, (int)Math.Floor(Position.Y + 1.0 - 0.1), BlockZ) != FluidKind.Empty) {
                Vec3d movement = DeltaMovement;
                DeltaMovement = movement.Add(0.0, (lookAngleY - movement.Y) * multiplier, 0.0);
            }
        }

        if (Flying) {
            double originalMovementY = DeltaMovement.Y;
            LivingTravel(input);
            DeltaMovement = DeltaMovement.WithY(originalMovementY * 0.6);
        }
        else {
            LivingTravel(input);
        }
    }

    /// <summary><c>Entity.calculateViewVector(getXRot(), getYRot()).y</c>.</summary>
    private double LookAngleY() {
        float realXRot = XRot * ((float)Math.PI / 180.0F);
        return -Mth.Sin(realXRot);
    }

    /// <summary><c>LivingEntity.travel</c>. A player never stands on a fluid.</summary>
    private void LivingTravel(Vec3d input) {
        if ((IsInWater || IsInLava) && IsAffectedByFluids) {
            TravelInFluid(input);
        }
        else if (IsFallFlying) {
            TravelFallFlying(input);
        }
        else {
            TravelInAir(input);
        }
    }

    private void TravelInAir(Vec3d input) {
        (int X, int Y, int Z) posBelow = OnPos(0.500001F);
        float blockFriction = OnGround
            ? ComputeModifiedFriction(BlockPhysicsAt(posBelow.X, posBelow.Y, posBelow.Z).Friction, (float)AttributeValue(Attribute.FrictionModifier))
            : 1.0F;
        Vec3d movement = HandleRelativeFrictionAndCalculateMovement(input, blockFriction);
        double movementY = movement.Y;
        if (GetEffect(PotionEffectType.Levitation) is { } levitation) {
            movementY += (0.05 * (levitation.Amplifier + 1) - movement.Y) * 0.2;
        }
        else if (Level.HasChunk(posBelow.X >> 4, posBelow.Z >> 4)) {
            movementY -= EffectiveGravity();
        }
        else if (Position.Y > Level.MinY) {
            movementY = -0.1;
        }
        else {
            movementY = 0.0;
        }

        float airDragModifier = (float)AttributeValue(Attribute.AirDragModifier);
        float airDrag = ComputeModifiedFriction(0.91F, airDragModifier);
        float friction = blockFriction * airDrag;
        float verticalFriction = ComputeModifiedFriction(0.98F, airDragModifier);
        DeltaMovement = new Vec3d(movement.X * friction, movementY * verticalFriction, movement.Z * friction);
    }

    private static float ComputeModifiedFriction(float friction, float modifier) {
        return Math.Clamp(1.0F - (1.0F - friction) * modifier, 0.0F, 1.0F);
    }

    private void TravelInFluid(Vec3d input) {
        bool isFalling = DeltaMovement.Y <= 0.0;
        double oldY = Position.Y;
        double baseGravity = EffectiveGravity();
        if (IsInWater) {
            TravelInWater(input, baseGravity, isFalling, oldY);
        }
        else {
            TravelInLava(input, baseGravity, isFalling, oldY);
        }
    }

    private void TravelInWater(Vec3d input, double baseGravity, bool isFalling, double oldY) {
        float slowDown = Sprinting ? 0.9F : 0.8F;
        float speed = 0.02F;
        float waterWalker = (float)AttributeValue(Attribute.WaterMovementEfficiency);
        if (!OnGround) {
            waterWalker *= 0.5F;
        }
        if (waterWalker > 0.0F) {
            slowDown += (0.54600006F - slowDown) * waterWalker;
            speed += (Speed - speed) * waterWalker;
        }
        if (HasEffect(PotionEffectType.DolphinsGrace)) {
            slowDown = 0.96F;
        }

        MoveRelative(speed, input);
        Move(DeltaMovement);
        Vec3d movement = DeltaMovement;
        if (HorizontalCollision && OnClimbable()) {
            movement = new Vec3d(movement.X, 0.2, movement.Z);
        }
        movement = movement.Multiply(slowDown, 0.8F, slowDown);
        DeltaMovement = FluidFallingAdjustedMovement(baseGravity, isFalling, movement);
        JumpOutOfFluid(oldY);
    }

    private void TravelInLava(Vec3d input, double baseGravity, bool isFalling, double oldY) {
        MoveRelative(0.02F, input);
        Move(DeltaMovement);
        double threshold = CurrentEyeHeight < 0.4 ? 0.0 : 0.4;
        if (Fluids.LavaHeight <= threshold) {
            DeltaMovement = DeltaMovement.Multiply(0.5, 0.8F, 0.5);
            DeltaMovement = FluidFallingAdjustedMovement(baseGravity, isFalling, DeltaMovement);
        }
        else {
            DeltaMovement *= 0.5;
        }
        if (baseGravity != 0.0) {
            DeltaMovement = DeltaMovement.Add(0.0, -baseGravity / 4.0, 0.0);
        }
        JumpOutOfFluid(oldY);
    }

    private void JumpOutOfFluid(double oldY) {
        Vec3d movement = DeltaMovement;
        if (HorizontalCollision && IsFree(movement.X, movement.Y + 0.6F - Position.Y + oldY, movement.Z)) {
            DeltaMovement = new Vec3d(movement.X, 0.3F, movement.Z);
        }
    }

    /// <summary><c>Entity.isFree</c>: no collision and no liquid in the moved box.</summary>
    private bool IsFree(double xa, double ya, double za) {
        Box box = BoundingBox.Translate(xa, ya, za);
        return LevelCollisions.NoCollision(Level, box, CollisionContext) && EntityCollisions.None(_client, this, box) && !ContainsAnyLiquid(box);
    }

    private bool ContainsAnyLiquid(Box box) {
        int x0 = (int)Math.Floor(box.MinX), x1 = (int)Math.Ceiling(box.MaxX);
        int y0 = (int)Math.Floor(box.MinY), y1 = (int)Math.Ceiling(box.MaxY);
        int z0 = (int)Math.Floor(box.MinZ), z1 = (int)Math.Ceiling(box.MaxZ);
        for (int x = x0; x < x1; x++) {
            for (int y = y0; y < y1; y++) {
                for (int z = z0; z < z1; z++) {
                    if (FluidAt(x, y, z) != FluidKind.Empty) {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private Vec3d FluidFallingAdjustedMovement(double baseGravity, bool isFalling, Vec3d movement) {
        if (baseGravity == 0.0 || Sprinting) {
            return movement;
        }
        double yd = isFalling && Math.Abs(movement.Y - 0.005) >= 0.003 && Math.Abs(movement.Y - baseGravity / 16.0) < 0.003
            ? -0.003
            : movement.Y - baseGravity / 16.0;
        return new Vec3d(movement.X, yd, movement.Z);
    }

    /// <summary><c>LivingEntity.getEffectiveGravity</c>.</summary>
    private double EffectiveGravity() {
        double gravity = AttributeValue(Attribute.Gravity);
        return DeltaMovement.Y <= 0.0 && HasEffect(PotionEffectType.SlowFalling) ? Math.Min(gravity, 0.01) : gravity;
    }

    /// <summary><c>Player.getSpeed</c>: the movement speed attribute, sprinting modifier included.</summary>
    private float Speed => (float)AttributeValue(Attribute.MovementSpeed);

    private Vec3d HandleRelativeFrictionAndCalculateMovement(Vec3d input, float friction) {
        MoveRelative(FrictionInfluencedSpeed(friction), input);
        DeltaMovement = HandleOnClimbable(DeltaMovement);
        Move(DeltaMovement);
        Vec3d movement = DeltaMovement;
        if ((HorizontalCollision || Jumping) && (OnClimbable() || _wasInPowderSnow && CanWalkOnPowderSnow)) {
            movement = new Vec3d(movement.X, 0.2, movement.Z);
        }
        return movement;
    }

    private Vec3d HandleOnClimbable(Vec3d delta) {
        if (!OnClimbable()) {
            return delta;
        }
        FallDistance = 0.0;
        double xd = Math.Clamp(delta.X, -0.15F, 0.15F);
        double zd = Math.Clamp(delta.Z, -0.15F, 0.15F);
        double yd = Math.Max(delta.Y, -0.15F);
        if (yd < 0.0 && !BlockAt(BlockX, BlockY, BlockZ).Scaffolding && !Flying && KeyPresses.Shift) {
            yd = 0.0;
        }
        return new Vec3d(xd, yd, zd);
    }

    private float FrictionInfluencedSpeed(float blockFriction) {
        if (OnGround) {
            return blockFriction > 0.6 ? Speed * (0.21600002F / (blockFriction * blockFriction * blockFriction)) : Speed;
        }
        return FlyingSpeedNow();
    }

    /// <summary><c>Player.getFlyingSpeed</c>.</summary>
    private float FlyingSpeedNow() {
        if (Flying && VehicleId == null) {
            return Sprinting ? FlyingSpeed * 2.0F : FlyingSpeed;
        }
        return Sprinting ? 0.025999999F : 0.02F;
    }

    /// <summary><c>LivingEntity.onClimbable</c>.</summary>
    public bool OnClimbable() {
        return !IsSpectator && !GlidesThrough() && MovementBlocks.OnClimbable(Level, BlockX, BlockY, BlockZ);
    }

    /// <summary><c>Entity.moveRelative</c> through <c>getInputVector</c>.</summary>
    private void MoveRelative(float speed, Vec3d input) {
        DeltaMovement += InputVector(input, speed, YRot);
    }

    public static Vec3d InputVector(Vec3d input, float speed, float yRot) {
        double length = input.LengthSqr();
        if (length < 1.0E-7) {
            return Vec3d.Zero;
        }
        Vec3d movement = (length > 1.0 ? input.Normalize() : input) * speed;
        float sin = Mth.Sin(yRot * ((float)Math.PI / 180.0F));
        float cos = Mth.Cos(yRot * ((float)Math.PI / 180.0F));
        return new Vec3d(movement.X * cos - movement.Z * sin, movement.Y, movement.Z * cos + movement.X * sin);
    }
}
