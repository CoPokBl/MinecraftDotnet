using ClientLib.Maths;
using ClientLib.Player;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Attribute = Minecraft.Data.Generated.Attribute;
using Mth = Minecraft.Schemas.Mth;

namespace ClientLib.Entities.Vehicles;

/// <summary><c>AbstractHorse</c>: horses, donkeys, mules, llamas, the undead horses and, through <see cref="ClientCamel"/>, camels.</summary>
public class ClientHorse(MinecraftClient client) : ClientRideableMob(client), IPlayerRideableJumping {
    private const int FlagStanding = 32;

    /// <summary><c>AbstractHorse.playerJumpPendingScale</c>.</summary>
    protected float PlayerJumpPendingScaleValue;

    private bool _allowStandSliding;
    private float _standAnim, _standAnimO;

    public bool IsStanding => (Get(EntityDataFields.AbstractHorse.IdFlags) & FlagStanding) != 0;

    /// <summary><c>AbstractHorse.isTamed</c>; a camel always is.</summary>
    public virtual bool IsTamed => (Get(EntityDataFields.AbstractHorse.IdFlags) & 2) != 0;

    /// <summary>
    /// <c>AbstractHorse.canUseSlot</c>: a saddle needs a grown, tamed horse, except on the horses and
    /// llamas whose own override allows every slot.
    /// </summary>
    public override bool CanUseSlot(EquippableComponent.Slot slot) {
        if (Is(EntityClass.Horse) || Is(EntityClass.SkeletonHorse) || Is(EntityClass.ZombieHorse) || Is(EntityClass.Llama)) {
            return true;
        }
        return slot != EquippableComponent.Slot.Saddle || CanUseTackWhenTamed(IsTamed);
    }

    /// <summary><c>AbstractHorse.getControllingPassenger</c>.</summary>
    public override ClientEntity? ControllingPassenger => IsSaddled ? FirstPlayerPassenger : null;

    protected override float WaterSlowDown => Is(EntityClass.SkeletonHorse) ? 0.96F : 0.8F;

    /// <summary><c>AbstractHorse.onClimbable</c>.</summary>
    protected override bool OnClimbable() => false;

    public virtual bool CanJump => IsSaddled;

    public virtual int JumpCooldown => 0;

    /// <summary><c>AbstractHorse.onPlayerJump</c>.</summary>
    public virtual void OnPlayerJump(int jumpAmount) {
        if (!IsSaddled) {
            return;
        }
        if (jumpAmount < 0) {
            jumpAmount = 0;
        }
        else {
            _allowStandSliding = true;
            // standIfPossible only sets the standing flag on the server, which syncs it back.
        }
        PlayerJumpPendingScaleValue = PlayerJumpPendingScale(jumpAmount);
    }

    /// <summary><c>AbstractHorse.addPassenger</c>: a new rider faces where the horse faces.</summary>
    protected override void AddPassenger(ClientEntity passenger) {
        base.AddPassenger(passenger);
        passenger.AbsSnapRotationTo(YRot, XRot);
    }

    /// <summary><c>AbstractHorse.positionRider</c>: a living rider's body turns with the horse.</summary>
    protected override void PositionRiderAt(ClientEntity passenger) {
        base.PositionRiderAt(passenger);
        if (passenger.IsLiving) {
            passenger.YBodyRot = YBodyRot;
        }
    }

    /// <summary><c>AbstractHorse.getPassengerAttachmentPoint</c>: a rearing horse lifts its rider and tips it back.</summary>
    protected override Vec3d PassengerAttachmentPoint(ClientEntity passenger, float scale) {
        return base.PassengerAttachmentPoint(passenger, scale)
               + YRotate(new Vec3d(0.0, 0.15 * _standAnimO * scale, -0.7 * _standAnimO * scale), -YRot * (MathF.PI / 180.0F));
    }

    /// <summary>The stand easing of <c>AbstractHorse.tick</c>, kept on the entity because the seat moves with it.</summary>
    protected override void CommonTick() {
        _standAnimO = _standAnim;
        if (IsStanding) {
            _standAnim += (1.0F - _standAnim) * 0.4F + 0.05F;
            if (_standAnim > 1.0F) {
                _standAnim = 1.0F;
            }
        }
        else {
            _allowStandSliding = false;
            _standAnim += (0.8F * _standAnim * _standAnim * _standAnim - _standAnim) * 0.6F - 0.05F;
            if (_standAnim < 0.0F) {
                _standAnim = 0.0F;
            }
        }
    }

    /// <summary><c>AbstractHorse.tickRidden</c>.</summary>
    protected override void TickRidden(LocalPlayer controller, Vec3d riddenInput) {
        (float xRot, float yRot) = RiddenRotation(controller);
        SetRot(yRot, xRot);
        YRotO = YBodyRot = YHeadRot = YRot;
        if (OnGround) {
            if (PlayerJumpPendingScaleValue > 0.0F) {
                ExecuteRidersJump(PlayerJumpPendingScaleValue, riddenInput);
            }
            PlayerJumpPendingScaleValue = 0.0F;
        }
    }

    /// <summary><c>AbstractHorse.getRiddenRotation</c>, as (x, y).</summary>
    protected virtual (float XRot, float YRot) RiddenRotation(LocalPlayer controller) => (controller.XRot * 0.5F, controller.YRot);

    /// <summary><c>AbstractHorse.getRiddenInput</c>: half speed sideways, a quarter backwards.</summary>
    protected override Vec3d RiddenInput(LocalPlayer controller, Vec3d selfInput) {
        if (OnGround && PlayerJumpPendingScaleValue == 0.0F && IsStanding && !_allowStandSliding) {
            return Vec3d.Zero;
        }
        float sideways = controller.Xxa * 0.5F;
        float forward = controller.Zza;
        if (forward <= 0.0F) {
            forward *= 0.25F;
        }
        return new Vec3d(sideways, 0.0, forward);
    }

    /// <summary><c>AbstractHorse.getRiddenSpeed</c>.</summary>
    protected override float RiddenSpeed(LocalPlayer controller) => (float)Attributes.Value(Attribute.MovementSpeed);

    /// <summary><c>AbstractHorse.executeRidersJump</c>.</summary>
    protected virtual void ExecuteRidersJump(float amount, Vec3d input) {
        double impulse = JumpPower(amount);
        Vec3d movement = DeltaMovement;
        DeltaMovement = new Vec3d(movement.X, impulse, movement.Z);
        if (input.Z > 0.0) {
            float sin = Mth.Sin(YRot * (MathF.PI / 180.0F));
            float cos = Mth.Cos(YRot * (MathF.PI / 180.0F));
            DeltaMovement = DeltaMovement.Add(-0.4F * sin * amount, 0.0, 0.4F * cos * amount);
        }
    }
}
