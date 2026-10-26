using ClientLib.Interaction;
using ClientLib.Maths;
using ClientLib.Physics;
using ClientLib.Player;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Data.Items;
using Minecraft.Physics;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Entities.Attributes;
using Minecraft.Schemas.Entities.Meta;
using Attribute = Minecraft.Data.Generated.Attribute;
using Mth = Minecraft.Schemas.Mth;

namespace ClientLib.Entities.Vehicles;

/// <summary>
/// <c>ItemBasedSteering</c>: the boost a carrot or fungus on a stick gives. The client only learns the
/// boost's length from the synced boost time, and times the boost itself.
/// </summary>
public sealed class ItemBasedSteering(ClientEntity entity, EntityDataField<int> boostTimeField) {
    private bool _boosting;
    private int _boostTime;

    public void OnSynced() {
        _boosting = true;
        _boostTime = 0;
    }

    public void TickBoost() {
        if (_boosting && _boostTime++ > BoostTimeTotal) {
            _boosting = false;
        }
    }

    public float BoostFactor => _boosting ? 1.0F + 1.15F * Mth.Sin((float)_boostTime / BoostTimeTotal * MathF.PI) : 1.0F;

    private int BoostTimeTotal => entity.Get(boostTimeField);
}

/// <summary><c>ItemSteerable</c>: a saddled mob steered by whoever holds the item, always walking forward.</summary>
public abstract class ClientItemSteeredMob : ClientRideableMob {
    private readonly IItem _steeringItem;
    private readonly EntityDataField<int> _boostTimeField;
    protected ItemBasedSteering Steering { get; }

    protected ClientItemSteeredMob(MinecraftClient client, IItem steeringItem, EntityDataField<int> boostTimeField) : base(client) {
        _steeringItem = steeringItem;
        _boostTimeField = boostTimeField;
        Steering = new ItemBasedSteering(this, boostTimeField);
    }

    public override ClientEntity? ControllingPassenger =>
        IsSaddled && FirstPlayerPassenger is { } player && IsHolding(player, _steeringItem) ? player : null;

    public override void OnSyncedDataUpdated(int index) {
        if (index == _boostTimeField.Index) {
            Steering.OnSynced();
        }
        base.OnSyncedDataUpdated(index);
    }

    /// <summary><c>Pig.tickRidden</c> and <c>Strider.tickRidden</c>.</summary>
    protected override void TickRidden(LocalPlayer controller, Vec3d riddenInput) {
        SetRot(controller.YRot, controller.XRot * 0.5F);
        YRotO = YBodyRot = YHeadRot = YRot;
        Steering.TickBoost();
    }

    protected override Vec3d RiddenInput(LocalPlayer controller, Vec3d selfInput) => new(0.0, 0.0, 1.0);
}

public sealed class ClientPig(MinecraftClient client) : ClientItemSteeredMob(client, Item.CarrotOnAStick, EntityDataFields.Pig.BoostTime) {
    protected override float RiddenSpeed(LocalPlayer controller) => (float)(Attributes.Value(Attribute.MovementSpeed) * 0.225 * Steering.BoostFactor);
}

/// <summary><c>Strider</c>: steered by a warped fungus on a stick, and walking on lava.</summary>
public sealed class ClientStrider : ClientItemSteeredMob {
    private static readonly Identifier StriderWarmBlocks = "minecraft:strider_warm_blocks";
    private static readonly AttributeModifier SuffocatingModifier = new("minecraft:suffocating", -0.34F, AttributeOperation.AddMultipliedBase);

    /// <summary><c>Block.column(16.0, 0.0, 8.0)</c>.</summary>
    private static readonly Box[] LiquidShape = [new Box(0.0, 0.0, 0.0, 1.0, 0.5, 1.0)];

    private readonly BlockTags _blockTags;

    public ClientStrider(MinecraftClient client) : base(client, Item.WarpedFungusOnAStick, EntityDataFields.Strider.BoostTime) {
        _blockTags = new BlockTags(client);
    }

    public bool IsSuffocating => Get(EntityDataFields.Strider.Suffocating);

    private bool IsNoAi => (Get(EntityDataFields.Mob.MobFlags) & 1) != 0;

    /// <summary><c>Strider.canUseSlot</c>: a saddle needs a grown strider.</summary>
    public override bool CanUseSlot(EquippableComponent.Slot slot) => slot != EquippableComponent.Slot.Saddle || IsAlive && !IsBaby;

    public override bool CanStandOnFluid(FluidKind fluid) => fluid == FluidKind.Lava;

    public override Box[] LiquidCollisionShape => LiquidShape;

    /// <summary><c>Strider.setSuffocating</c>.</summary>
    private void SetSuffocating(bool flag) {
        Set(EntityDataFields.Strider.Suffocating, MetaFieldType.Boolean, flag);
        AttributeMap.Instance speed = Attributes.GetOrCreate(Attribute.MovementSpeed);
        if (flag) {
            speed.AddModifier(SuffocatingModifier);
        }
        else {
            speed.RemoveModifier(SuffocatingModifier.Id);
        }
    }

    /// <summary><c>Strider.getPassengerAttachmentPoint</c>: on a client the seat bobs with the stride.</summary>
    protected override Vec3d PassengerAttachmentPoint(ClientEntity passenger, float scale) {
        float animSpeed = Math.Min(0.25F, WalkSpeed);
        float animPos = WalkPosition;
        float offset = 0.12F * Mth.Cos(animPos * 1.5F) * 2.0F * animSpeed;
        return base.PassengerAttachmentPoint(passenger, scale).Add(0.0, offset * scale, 0.0);
    }

    protected override float RiddenSpeed(LocalPlayer controller) =>
        (float)(Attributes.Value(Attribute.MovementSpeed) * (IsSuffocating ? 0.35F : 0.55F) * Steering.BoostFactor);

    /// <summary><c>Strider.checkFallDamage</c>.</summary>
    protected override void CheckFallDamage(double ya, bool onGround) {
        if (IsInLava) {
            FallDistance = 0.0;
        }
        else {
            base.CheckFallDamage(ya, onGround);
        }
    }

    /// <summary><c>Strider.tick</c> before <c>super.tick</c>; its sounds wait on goals only the server runs.</summary>
    protected override void BeforeControlledTick() {
        if (IsNoAi) {
            return;
        }
        Minecraft.Data.Blocks.IBlock stateInside = Level.GetBlock(BlockX, BlockY, BlockZ);
        (int X, int Y, int Z) on = OnPos(0.2F);
        Minecraft.Data.Blocks.IBlock stateOn = Level.GetBlock(on.X, on.Y, on.Z);
        bool inWarmBlocks = _blockTags.Contains(StriderWarmBlocks, stateInside)
                            || _blockTags.Contains(StriderWarmBlocks, stateOn)
                            || Fluids.LavaHeight > 0.0;
        bool onWarmStrider = Vehicle is ClientStrider strider && !strider.IsSuffocating;
        SetSuffocating(!inWarmBlocks && !onWarmStrider);
    }

    /// <summary><c>Strider.floatStrider</c>.</summary>
    protected override void AfterControlledTick() {
        if (!IsInLava) {
            return;
        }
        if (CollisionContext.IsAbove(LiquidShape, BlockY) && BlockAt(BlockX, BlockY + 1, BlockZ).Fluid != FluidKind.Lava) {
            SetOnGround(true);
        }
        else {
            DeltaMovement = (DeltaMovement * 0.5).Add(0.0, 0.05, 0.0);
        }
    }
}

/// <summary><c>HappyGhast</c>: flown with a harness, climbing and diving along the rider's look.</summary>
public sealed class ClientHappyGhast(MinecraftClient client) : ClientRideableMob(client) {
    /// <summary><c>HappyGhast.isOnStillTimeout</c>; the server's own timeout reaches the client as <c>STAYS_STILL</c>.</summary>
    private bool IsOnStillTimeout => Get(EntityDataFields.HappyGhast.StaysStill);

    public override ClientEntity? ControllingPassenger => IsWearingBodyArmor && !IsOnStillTimeout ? FirstPlayerPassenger : null;

    protected override bool OnClimbable() => false;

    /// <summary><c>HappyGhast.travel</c>.</summary>
    protected override void Travel(Vec3d input) {
        float speed = (float)Attributes.Value(Attribute.FlyingSpeed) * 5.0F / 3.0F;
        TravelFlying(input, speed, speed, speed);
    }

    /// <summary><c>HappyGhast.getRiddenInput</c>.</summary>
    protected override Vec3d RiddenInput(LocalPlayer controller, Vec3d selfInput) {
        (float up, float forward) = LookInput(controller);
        if (controller.Jumping) {
            up += 0.5F;
        }
        return new Vec3d(controller.Xxa, up, forward) * (3.9F * Attributes.Value(Attribute.FlyingSpeed));
    }

    protected override void TickRidden(LocalPlayer controller, Vec3d riddenInput) => TurnTowardsRider(controller, 0.08F);
}

/// <summary><c>AbstractNautilus</c>: the nautilus and the zombie nautilus, ridden underwater and dashing on a jump.</summary>
public sealed class ClientNautilus(MinecraftClient client) : ClientRideableMob(client), IPlayerRideableJumping {
    private int _dashCooldown;
    private float _playerJumpPendingScale;

    public override ClientEntity? ControllingPassenger => IsSaddled ? FirstPlayerPassenger : null;

    public bool IsTame => (Get(EntityDataFields.TamableAnimal.Flags) & 4) != 0;

    /// <summary><c>AbstractNautilus.canUseSlot</c>: saddle and armour need a grown, tamed nautilus.</summary>
    public override bool CanUseSlot(EquippableComponent.Slot slot) =>
        slot is not (EquippableComponent.Slot.Saddle or EquippableComponent.Slot.Body) || CanUseTackWhenTamed(IsTame);

    protected override bool IsPushedByFluid => false;

    private bool IsDashing => Get(EntityDataFields.AbstractNautilus.Dash);

    public bool CanJump => IsSaddled;

    public int JumpCooldown => _dashCooldown;

    public void OnPlayerJump(int jumpAmount) {
        if (IsSaddled && _dashCooldown <= 0) {
            _playerJumpPendingScale = PlayerJumpPendingScale(jumpAmount);
        }
    }

    public override void OnSyncedDataUpdated(int index) {
        if (TickCount > 0 && index == EntityDataFields.AbstractNautilus.Dash.Index) {
            _dashCooldown = _dashCooldown == 0 ? 40 : _dashCooldown;
        }
        base.OnSyncedDataUpdated(index);
    }

    /// <summary><c>AbstractNautilus.tick</c>'s dash bookkeeping.</summary>
    protected override void CommonTick() {
        if (IsDashing && _dashCooldown < 35) {
            Set(EntityDataFields.AbstractNautilus.Dash, MetaFieldType.Boolean, false);
        }
        if (_dashCooldown > 0) {
            _dashCooldown--;
        }
    }

    /// <summary><c>AbstractNautilus.getRiddenInput</c>: forward goes where the rider looks.</summary>
    protected override Vec3d RiddenInput(LocalPlayer controller, Vec3d selfInput) {
        (float up, float forward) = LookInput(controller);
        return new Vec3d(controller.Xxa, up, forward);
    }

    /// <summary><c>AbstractNautilus.tickRidden</c>: it turns halfway to the rider's facing each tick.</summary>
    protected override void TickRidden(LocalPlayer controller, Vec3d riddenInput) {
        TurnTowardsRider(controller, 0.5F);
        if (_playerJumpPendingScale > 0.0F) {
            ExecuteRidersJump(_playerJumpPendingScale, controller);
        }
        _playerJumpPendingScale = 0.0F;
    }

    /// <summary><c>AbstractNautilus.travelInWater</c>.</summary>
    protected override void TravelInWater(Vec3d input, double baseGravity, bool isFalling, double oldY) {
        MoveRelative(Speed, input);
        Move(DeltaMovement);
        DeltaMovement *= 0.9;
    }

    protected override float RiddenSpeed(LocalPlayer controller) =>
        IsInWater ? 0.0325F * (float)Attributes.Value(Attribute.MovementSpeed) : 0.02F * (float)Attributes.Value(Attribute.MovementSpeed);

    /// <summary><c>AbstractNautilus.executeRidersJump</c>: a dash along the rider's look.</summary>
    private void ExecuteRidersJump(float amount, LocalPlayer controller) {
        DeltaMovement += ViewVector(controller.XRot, controller.YRot)
                         * ((IsInWater ? 1.2F : 0.5F) * amount * Attributes.Value(Attribute.MovementSpeed) * BlockSpeedFactor());
        _dashCooldown = 40;
        Set(EntityDataFields.AbstractNautilus.Dash, MetaFieldType.Boolean, true);
    }
}
