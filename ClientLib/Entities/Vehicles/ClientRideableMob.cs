using ClientLib.Maths;
using ClientLib.Physics;
using ClientLib.Player;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Data.Items;
using Minecraft.Physics;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Items;
using Attribute = Minecraft.Data.Generated.Attribute;
using Mth = Minecraft.Schemas.Mth;

namespace ClientLib.Entities.Vehicles;

/// <summary>
/// <c>PlayerRideableJumping</c>: a mount that jumps or dashes when the player lets go of the jump key,
/// as far as the rider's client calls it.
/// </summary>
public interface IPlayerRideableJumping {
    void OnPlayerJump(int jumpAmount);
    bool CanJump { get; }
    int JumpCooldown { get; }
}

/// <summary>
/// A mob a player can steer: the <c>LivingEntity</c> half of its movement, from <c>aiStep</c> through
/// <c>travelRidden</c> to <c>travel</c>, as it runs on the rider's client. The vehicle's own AI never
/// runs here, so <c>jumping</c> and the mob's own move input stay zero.
/// </summary>
public class ClientRideableMob(MinecraftClient client) : ClientVehicle(client), IFluidStandingEntity {
    private static readonly Identifier CanFloatWhileRidden = "minecraft:can_float_while_ridden";

    /// <summary><c>LivingEntity.speed</c>, which <c>travelRidden</c> sets from <c>getRiddenSpeed</c>.</summary>
    protected float Speed { get; private set; }

    private int _noJumpDelay;

    /// <summary><c>Mob.isSaddled</c>.</summary>
    public bool IsSaddled => HasValidEquippableItemForSlot(EquipmentSlot.Saddle, EquippableComponent.Slot.Saddle);

    /// <summary><c>Mob.isWearingBodyArmor</c>.</summary>
    public bool IsWearingBodyArmor => HasValidEquippableItemForSlot(EquipmentSlot.Body, EquippableComponent.Slot.Body);

    private bool HasValidEquippableItemForSlot(EquipmentSlot slot, EquippableComponent.Slot equippableSlot) =>
        Equipment.GetValueOrDefault(slot) is { } item && !item.IsAir() && IsEquippableInSlot(item, equippableSlot);

    /// <summary><c>LivingEntity.canUseSlot</c>.</summary>
    public virtual bool CanUseSlot(EquippableComponent.Slot slot) => true;

    /// <summary><c>LivingEntity.isEquippableInSlot</c>.</summary>
    public bool IsEquippableInSlot(ItemStack stack, EquippableComponent.Slot slot) {
        if (!stack.Has(DataComponent.Equippable)) {
            return slot == EquippableComponent.Slot.MainHand && CanUseSlot(EquippableComponent.Slot.MainHand);
        }
        EquippableComponent.Data equippable = stack.Get(DataComponent.Equippable);
        if (slot != equippable.Slot || !CanUseSlot(equippable.Slot)) {
            return false;
        }
        return equippable.AllowedEntities switch {
            null => true,
            Minecraft.Schemas.Tags.IdSet.Ids ids => Array.IndexOf(ids.Values, Client.Registry.EntityTypes.GetProtocolId(Type)) >= 0,
            Minecraft.Schemas.Tags.IdSet.Tag tag => Client.InEntityTypeTag(Type, tag.TagName),
            _ => false
        };
    }

    /// <summary>What <c>AbstractHorse</c> and <c>AbstractNautilus</c> ask before tack goes on: alive, grown and tamed.</summary>
    protected bool CanUseTackWhenTamed(bool tamed) => IsAlive && !IsBaby && tamed;

    public bool IsAlive => CurrentHealth > 0.0F;

    /// <summary>The rider in the first seat, if it is a player; what most mounts hand control to.</summary>
    protected ClientEntity? FirstPlayerPassenger => FirstPassenger is { } first && first.Is(EntityClass.Player) ? first : null;

    protected static bool IsHolding(ClientEntity entity, IItem item) =>
        entity.ItemInHand(Hand.MainHand).Type.Identifier.Equals(item.Identifier) || entity.ItemInHand(Hand.OffHand).Type.Identifier.Equals(item.Identifier);

    public override (float Width, float Height) Dimensions {
        get {
            float scale = AttachmentScale;
            return ((float)Width * scale, (float)Height * scale);
        }
    }

    protected override double EyeY => Position.Y + (float)EyeHeight * AttachmentScale;

    protected override double DefaultGravity => Attributes.Value(Attribute.Gravity);

    /// <summary><c>LivingEntity.getEffectiveGravity</c>.</summary>
    protected override double EffectiveGravity => DeltaMovement.Y <= 0.0 && HasEffect(PotionEffectType.SlowFalling) ? Math.Min(Gravity, 0.01) : Gravity;

    /// <summary><c>LivingEntity.getAirDrag</c>.</summary>
    protected override float AirDrag => ComputeModifiedFriction(OmnidirectionalAirMover ? 0.91F : 0.98F, (float)Attributes.Value(Attribute.AirDragModifier));

    /// <summary><c>LivingEntity.maxUpStep</c>: a player's mount climbs at least a block.</summary>
    protected override float MaxUpStep {
        get {
            float step = (float)Attributes.Value(Attribute.StepHeight);
            return ControllingPassenger is { } controller && controller.Is(EntityClass.Player) ? Math.Max(step, 1.0F) : step;
        }
    }

    protected override double EntityBounciness => Attributes.Value(Attribute.Bounciness);

    protected virtual bool OmnidirectionalAirMover => false;

    protected bool IsSprinting => (SharedFlags & 0x08) != 0;

    /// <summary><c>LivingEntity.onBelowWorld</c>: the hurt is <c>hurtClient</c> on a client, which does nothing.</summary>
    protected override void OnBelowWorld() {
    }

    /// <summary><c>LivingEntity.tick</c> on the rider's client.</summary>
    protected override void ControlledTick() {
        BeforeControlledTick();
        BaseTick();
        TickHurtAndDeath();
        AiStep();
        TickBodyRotation();
        AfterControlledTick();
    }

    /// <summary>What the class's own <c>tick</c> does before <c>LivingEntity.tick</c>.</summary>
    protected virtual void BeforeControlledTick() {
    }

    /// <summary>What the class's own <c>tick</c> does after <c>LivingEntity.tick</c>.</summary>
    protected virtual void AfterControlledTick() {
    }

    /// <summary><c>LivingEntity.aiStep</c>, client side, for a mob a player rides.</summary>
    private void AiStep() {
        if (_noJumpDelay > 0) {
            _noJumpDelay--;
        }

        Vec3d movement = DeltaMovement;
        double dx = Math.Abs(movement.X) < 0.003 ? 0.0 : movement.X;
        double dy = Math.Abs(movement.Y) < 0.003 ? 0.0 : movement.Y;
        double dz = Math.Abs(movement.Z) < 0.003 ? 0.0 : movement.Z;
        DeltaMovement = new Vec3d(dx, dy, dz);

        _noJumpDelay = 0;
        if (HasEffect(PotionEffectType.SlowFalling) || HasEffect(PotionEffectType.Levitation)) {
            FallDistance = 0.0;
        }
        if (ControllingPassenger is LocalPlayer controller && IsAlive) {
            TravelRidden(controller, Vec3d.Zero);
        }
        ApplyEffectsFromBlocks();
        UpdateWalkAnimation();
    }

    /// <summary><c>LivingEntity.travelRidden</c>.</summary>
    private void TravelRidden(LocalPlayer controller, Vec3d selfInput) {
        Vec3d riddenInput = RiddenInput(controller, selfInput);
        TickRidden(controller, riddenInput);
        Speed = RiddenSpeed(controller);
        Travel(riddenInput);
    }

    /// <summary><c>LivingEntity.tickRidden</c>.</summary>
    protected virtual void TickRidden(LocalPlayer controller, Vec3d riddenInput) {
    }

    /// <summary><c>LivingEntity.getRiddenInput</c>.</summary>
    protected virtual Vec3d RiddenInput(LocalPlayer controller, Vec3d selfInput) => selfInput;

    /// <summary><c>LivingEntity.getRiddenSpeed</c>.</summary>
    protected virtual float RiddenSpeed(LocalPlayer controller) => Speed;

    /// <summary><c>LivingEntity.travel</c>.</summary>
    protected virtual void Travel(Vec3d input) {
        if (ShouldTravelInFluid()) {
            TravelInFluid(input);
        }
        else {
            TravelInAir(input);
        }
    }

    /// <summary><c>LivingEntity.canStandOnFluid</c>.</summary>
    public virtual bool CanStandOnFluid(FluidKind fluid) => false;

    /// <summary><c>LivingEntity.getLiquidCollisionShape</c>.</summary>
    public virtual Box[] LiquidCollisionShape => [];

    /// <summary><c>LivingEntity.shouldTravelInFluid</c>; <c>isAffectedByFluids</c> only differs for a flying player.</summary>
    private bool ShouldTravelInFluid() => (IsInWater || IsInLava) && !CanStandOnFluid(BlockAt(BlockX, BlockY, BlockZ).Fluid);

    /// <summary><c>LivingEntity.travelFlying</c>.</summary>
    protected void TravelFlying(Vec3d input, float waterSpeed, float lavaSpeed, float airSpeed) {
        if (IsInWater) {
            MoveRelative(waterSpeed, input);
            Move(DeltaMovement);
            DeltaMovement *= 0.8F;
        }
        else if (IsInLava) {
            MoveRelative(lavaSpeed, input);
            Move(DeltaMovement);
            DeltaMovement *= 0.5;
        }
        else {
            MoveRelative(airSpeed, input);
            Move(DeltaMovement);
            DeltaMovement *= 0.91F;
        }
    }

    /// <summary><c>LivingEntity.travelInAir</c>.</summary>
    private void TravelInAir(Vec3d input) {
        (int X, int Y, int Z) posBelow = OnPos(0.500001F);
        float blockFriction = OnGround
            ? ComputeModifiedFriction(BlockPhysicsAt(posBelow.X, posBelow.Y, posBelow.Z).Friction, (float)Attributes.Value(Attribute.FrictionModifier))
            : 1.0F;
        Vec3d movement = HandleRelativeFrictionAndCalculateMovement(input, blockFriction);
        double movementY = movement.Y;
        if (GetEffect(PotionEffectType.Levitation) is { } levitation) {
            movementY += (0.05 * (levitation.Amplifier + 1) - movement.Y) * 0.2;
        }
        else if (Level.HasChunk(posBelow.X >> 4, posBelow.Z >> 4)) {
            movementY -= EffectiveGravity;
        }
        else if (Position.Y > Level.MinY) {
            movementY = -0.1;
        }
        else {
            movementY = 0.0;
        }

        float airDragModifier = (float)Attributes.Value(Attribute.AirDragModifier);
        float airDrag = ComputeModifiedFriction(0.91F, airDragModifier);
        float friction = blockFriction * airDrag;
        float verticalFriction = OmnidirectionalAirMover ? airDrag : ComputeModifiedFriction(0.98F, airDragModifier);
        DeltaMovement = new Vec3d(movement.X * friction, movementY * verticalFriction, movement.Z * friction);
    }

    protected static float ComputeModifiedFriction(float friction, float modifier) => Math.Clamp(1.0F - (1.0F - friction) * modifier, 0.0F, 1.0F);

    /// <summary><c>LivingEntity.travelInFluid</c>.</summary>
    private void TravelInFluid(Vec3d input) {
        bool isFalling = DeltaMovement.Y <= 0.0;
        double oldY = Position.Y;
        double baseGravity = EffectiveGravity;
        if (IsInWater) {
            TravelInWater(input, baseGravity, isFalling, oldY);
            FloatInWaterWhileRidden();
        }
        else {
            TravelInLava(input, baseGravity, isFalling, oldY);
        }
    }

    /// <summary><c>LivingEntity.getWaterSlowDown</c>.</summary>
    protected virtual float WaterSlowDown => 0.8F;

    /// <summary><c>LivingEntity.travelInWater</c>.</summary>
    protected virtual void TravelInWater(Vec3d input, double baseGravity, bool isFalling, double oldY) {
        float slowDown = IsSprinting ? 0.9F : WaterSlowDown;
        float speed = 0.02F;
        float waterWalker = (float)Attributes.Value(Attribute.WaterMovementEfficiency);
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

    private double FluidJumpThreshold => EyeHeight * AttachmentScale < 0.4 ? 0.0 : 0.4;

    private void TravelInLava(Vec3d input, double baseGravity, bool isFalling, double oldY) {
        MoveRelative(0.02F, input);
        Move(DeltaMovement);
        if (Fluids.LavaHeight <= FluidJumpThreshold) {
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

    /// <summary><c>LivingEntity.floatInWaterWhileRidden</c>.</summary>
    private void FloatInWaterWhileRidden() {
        if (Client.InEntityTypeTag(Type, CanFloatWhileRidden) && IsVehicle && Fluids.WaterHeight > FluidJumpThreshold) {
            DeltaMovement = DeltaMovement.Add(0.0, 0.04F, 0.0);
        }
    }

    /// <summary><c>Entity.isFree</c>: no collision and no liquid in the moved box.</summary>
    private bool IsFree(double xa, double ya, double za) {
        Box box = BoundingBox.Translate(xa, ya, za);
        if (!NoCollision(box)) {
            return false;
        }
        int x0 = (int)Math.Floor(box.MinX), x1 = (int)Math.Ceiling(box.MaxX);
        int y0 = (int)Math.Floor(box.MinY), y1 = (int)Math.Ceiling(box.MaxY);
        int z0 = (int)Math.Floor(box.MinZ), z1 = (int)Math.Ceiling(box.MaxZ);
        for (int x = x0; x < x1; x++) {
            for (int y = y0; y < y1; y++) {
                for (int z = z0; z < z1; z++) {
                    if (BlockAt(x, y, z).Fluid != FluidKind.Empty) {
                        return false;
                    }
                }
            }
        }
        return true;
    }

    /// <summary><c>LivingEntity.getFluidFallingAdjustedMovement</c>.</summary>
    private Vec3d FluidFallingAdjustedMovement(double baseGravity, bool isFalling, Vec3d movement) {
        if (baseGravity == 0.0 || IsSprinting) {
            return movement;
        }
        double yd = isFalling && Math.Abs(movement.Y - 0.005) >= 0.003 && Math.Abs(movement.Y - baseGravity / 16.0) < 0.003
            ? -0.003
            : movement.Y - baseGravity / 16.0;
        return new Vec3d(movement.X, yd, movement.Z);
    }

    /// <summary><c>LivingEntity.handleRelativeFrictionAndCalculateMovement</c>; a mount is never <c>jumping</c> here.</summary>
    private Vec3d HandleRelativeFrictionAndCalculateMovement(Vec3d input, float friction) {
        MoveRelative(FrictionInfluencedSpeed(friction), input);
        DeltaMovement = HandleOnClimbable(DeltaMovement);
        Move(DeltaMovement);
        Vec3d movement = DeltaMovement;
        if (HorizontalCollision && OnClimbable()) {
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
        return new Vec3d(xd, yd, zd);
    }

    /// <summary><c>LivingEntity.getFrictionInfluencedSpeed</c>.</summary>
    private float FrictionInfluencedSpeed(float blockFriction) {
        if (OnGround) {
            return blockFriction > 0.6 ? Speed * (0.21600002F / (blockFriction * blockFriction * blockFriction)) : Speed;
        }
        return FlyingSpeed;
    }

    /// <summary><c>LivingEntity.getFlyingSpeed</c>.</summary>
    private float FlyingSpeed => ControllingPassenger is { } controller && controller.Is(EntityClass.Player) ? Speed * 0.1F : 0.02F;

    /// <summary><c>LivingEntity.onClimbable</c>.</summary>
    protected virtual bool OnClimbable() => MovementBlocks.OnClimbable(Level, BlockX, BlockY, BlockZ);

    /// <summary><c>LivingEntity.getJumpPower(multiplier)</c>.</summary>
    protected float JumpPower(float multiplier = 1.0F) {
        float boost = GetEffect(PotionEffectType.JumpBoost) is { } jumpBoost ? 0.1F * (jumpBoost.Amplifier + 1.0F) : 0.0F;
        return (float)Attributes.Value(Attribute.JumpStrength) * multiplier * BlockJumpFactor() + boost;
    }

    /// <summary><c>LivingEntity.checkFallDamage</c>: a mob out of the water first looks for it again.</summary>
    protected override void CheckFallDamage(double ya, bool onGround) {
        if (!IsInWater) {
            UpdateFluidInteraction();
        }
        base.CheckFallDamage(ya, onGround);
    }

    /// <summary><c>Entity.getLookAngle</c>.</summary>
    protected static Vec3d ViewVector(float xRot, float yRot) {
        float radX = xRot * (MathF.PI / 180.0F);
        float radY = -yRot * (MathF.PI / 180.0F);
        float cosY = Mth.Cos(radY);
        float sinY = Mth.Sin(radY);
        float cosX = Mth.Cos(radX);
        float sinX = Mth.Sin(radX);
        return new Vec3d(sinY * cosX, -sinX, cosY * cosX);
    }

    /// <summary><c>PlayerRideableJumping.getPlayerJumpPendingScale</c>.</summary>
    protected static float PlayerJumpPendingScale(int jumpAmount) => jumpAmount >= 90 ? 1.0F : 0.4F + 0.4F * jumpAmount / 90.0F;

    /// <summary>
    /// The pitch following forward input <c>HappyGhast</c> and <c>AbstractNautilus</c> both build in
    /// <c>getRiddenInput</c>: forward climbs or dives along the rider's look, backward at half strength.
    /// </summary>
    protected static (float Up, float Forward) LookInput(LocalPlayer controller) {
        if (controller.Zza == 0.0F) {
            return (0.0F, 0.0F);
        }
        float forwardLook = Mth.Cos(controller.XRot * (MathF.PI / 180.0F));
        float upLook = -Mth.Sin(controller.XRot * (MathF.PI / 180.0F));
        if (controller.Zza < 0.0F) {
            forwardLook *= -0.5F;
            upLook *= -0.5F;
        }
        return (upLook, forwardLook);
    }

    /// <summary>The <c>tickRidden</c> of <c>HappyGhast</c> and <c>AbstractNautilus</c>: a turn part way to the rider's facing.</summary>
    protected void TurnTowardsRider(LocalPlayer controller, float factor) {
        float yRot = YRot;
        float diff = Wrap(controller.YRot - yRot);
        yRot += diff * factor;
        SetRot(yRot, controller.XRot * 0.5F);
        YRotO = YBodyRot = YHeadRot = yRot;
    }
}
