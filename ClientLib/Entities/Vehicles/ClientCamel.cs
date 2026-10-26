using ClientLib.Maths;
using ClientLib.Player;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Entities.Meta;
using Attribute = Minecraft.Data.Generated.Attribute;
using Pose = Minecraft.Schemas.Entities.EntityPose;

namespace ClientLib.Entities.Vehicles;

/// <summary><c>Camel</c>: a horse that dashes instead of jumping, and will not move while it sits.</summary>
public sealed class ClientCamel(MinecraftClient client) : ClientHorse(client) {
    private int _dashCooldown;

    /// <summary><c>Camel.ADULT_SITTING_DIMENSIONS</c>: the standing height less 1.43.</summary>
    public override (float Width, float Height) Dimensions {
        get {
            if (Get(EntityDataFields.Entity.Pose, Pose.Standing) != Pose.Sitting || IsBaby) {
                return base.Dimensions;
            }
            float scale = AttachmentScale;
            return ((float)Width * scale, ((float)Height - 1.43F) * scale);
        }
    }

    public override bool IsTamed => true;

    private long LastPoseChangeTick => Get(EntityDataFields.Camel.LastPoseChangeTick);

    /// <summary><c>Camel.isCamelSitting</c>.</summary>
    public bool IsCamelSitting => LastPoseChangeTick < 0L;

    private long PoseTime => (Client.Level?.GameTime ?? 0L) - Math.Abs(LastPoseChangeTick);

    /// <summary><c>Camel.isInPoseTransition</c>.</summary>
    public bool IsInPoseTransition => PoseTime < (IsCamelSitting ? 40 : 52);

    /// <summary><c>Camel.refuseToMove</c>.</summary>
    public bool RefuseToMove => IsCamelSitting || IsInPoseTransition;

    private bool IsDashing => Get(EntityDataFields.Camel.Dash);

    private void SetDashing(bool dashing) => Set(EntityDataFields.Camel.Dash, MetaFieldType.Boolean, dashing);

    public override int JumpCooldown => _dashCooldown;

    public override bool CanJump => !RefuseToMove && base.CanJump;

    /// <summary><c>Camel.onPlayerJump</c>: only from the ground, and not while the last dash recovers.</summary>
    public override void OnPlayerJump(int jumpAmount) {
        if (IsSaddled && _dashCooldown <= 0 && OnGround) {
            base.OnPlayerJump(jumpAmount);
        }
    }

    /// <summary><c>Camel.onSyncedDataUpdated</c>: a dash the server reports starts the cooldown here too.</summary>
    public override void OnSyncedDataUpdated(int index) {
        if (TickCount > 0 && index == EntityDataFields.Camel.Dash.Index) {
            _dashCooldown = _dashCooldown == 0 ? 55 : _dashCooldown;
        }
        base.OnSyncedDataUpdated(index);
    }

    /// <summary><c>Camel.tick</c> after <c>AbstractHorse.tick</c>: the dash ends on landing, and its cooldown runs down.</summary>
    protected override void CommonTick() {
        base.CommonTick();
        if (IsDashing && _dashCooldown < 50 && (OnGround || IsInWater || IsInLava || IsPassenger)) {
            SetDashing(false);
        }
        if (_dashCooldown > 0) {
            _dashCooldown--;
        }
    }

    /// <summary><c>Camel.travel</c>: a sitting camel on the ground only falls.</summary>
    protected override void Travel(Vec3d input) {
        if (RefuseToMove && OnGround) {
            DeltaMovement = DeltaMovement.Multiply(0.0, 1.0, 0.0);
            input = input.Multiply(0.0, 1.0, 0.0);
        }
        base.Travel(input);
    }

    /// <summary><c>Camel.tickRidden</c>: pressing forward on a sitting camel stands it up.</summary>
    protected override void TickRidden(LocalPlayer controller, Vec3d riddenInput) {
        base.TickRidden(controller, riddenInput);
        if (controller.Zza > 0.0F && IsCamelSitting && !IsInPoseTransition) {
            StandUp();
        }
    }

    /// <summary><c>Camel.standUp</c>, on the client's own copy of the synced data.</summary>
    private void StandUp() {
        if (!IsCamelSitting) {
            return;
        }
        Set(EntityDataFields.Entity.Pose, MetaFieldType.Pose, Pose.Standing);
        Set(EntityDataFields.Camel.LastPoseChangeTick, MetaFieldType.VarLong, Client.Level?.GameTime ?? 0L);
    }

    protected override float RiddenSpeed(LocalPlayer controller) {
        float movementBonus = controller.Sprinting && JumpCooldown == 0 ? 0.1F : 0.0F;
        return (float)Attributes.Value(Attribute.MovementSpeed) + movementBonus;
    }

    protected override (float XRot, float YRot) RiddenRotation(LocalPlayer controller) => RefuseToMove ? (XRot, YRot) : base.RiddenRotation(controller);

    protected override Vec3d RiddenInput(LocalPlayer controller, Vec3d selfInput) => RefuseToMove ? Vec3d.Zero : base.RiddenInput(controller, selfInput);

    /// <summary><c>Camel.executeRidersJump</c>: a dash along the look, scaled by speed and the ground.</summary>
    protected override void ExecuteRidersJump(float amount, Vec3d input) {
        double jumpMomentum = JumpPower();
        Vec3d look = ViewVector(XRot, YRot).Multiply(1.0, 0.0, 1.0).Normalize()
                     * (22.2222F * amount * Attributes.Value(Attribute.MovementSpeed) * BlockSpeedFactor());
        DeltaMovement += look.Add(0.0, 1.4285F * amount * jumpMomentum, 0.0);
        _dashCooldown = 55;
        SetDashing(true);
    }

    /// <summary>
    /// <c>Camel.getPassengerAttachmentPoint</c>: two seats along the hump, riding the sit and stand
    /// animation's body anchor.
    /// </summary>
    protected override Vec3d PassengerAttachmentPoint(ClientEntity passenger, float scale) {
        int index = Math.Max(PassengerIndex(passenger), 0);
        bool driver = index == 0;
        float offset = 0.5F;
        float height = (float)(IsRemoved ? 0.01F : BodyAnchorAnimationYOffset(driver, 0.0F, Dimensions.Height, scale));
        if (PassengerList.Count > 1) {
            if (!driver) {
                offset = -0.7F;
            }
            if (passenger.Is(EntityClass.Animal)) {
                offset += 0.2F;
            }
        }
        return YRotate(new Vec3d(0.0, height, offset * scale), -YRot * (MathF.PI / 180.0F));
    }

    /// <summary><c>Camel.getLeashOffset(partialTicks)</c>.</summary>
    public Vec3d LeashOffset(float partialTick) {
        (float width, float height) = Dimensions;
        float scale = IsBaby ? 0.5F : 1.0F;
        return new Vec3d(0.0, BodyAnchorAnimationYOffset(true, partialTick, height, scale) - 0.2F * scale, width * 0.56F);
    }

    /// <summary><c>Camel.getBodyAnchorAnimationYOffset</c>.</summary>
    private double BodyAnchorAnimationYOffset(bool isFront, float partialTicks, float dimensionsHeight, float scale) {
        double ageSitYOffset = IsBaby ? 0.09375 : 0.375;
        double baseSitOffset = dimensionsHeight - ageSitYOffset;
        float sittingHeightDifference = scale * 1.43F;
        float verticalDrop = sittingHeightDifference - scale * 0.2F;
        float bottomPoint = sittingHeightDifference - verticalDrop;
        bool isInTransition = IsInPoseTransition;
        bool isSitting = IsCamelSitting;
        if (isInTransition) {
            int animationDuration = isSitting ? 40 : 52;
            int halfPoint;
            float flexPointOffset;
            if (isSitting) {
                halfPoint = 28;
                flexPointOffset = isFront ? 0.5F : 0.1F;
            }
            else {
                halfPoint = isFront ? 24 : 32;
                flexPointOffset = isFront ? 0.6F : 0.35F;
            }
            float poseTime = Math.Clamp(PoseTime + partialTicks, 0.0F, animationDuration);
            bool isFirstPart = poseTime < halfPoint;
            float part = isFirstPart ? poseTime / halfPoint : (poseTime - halfPoint) / (animationDuration - halfPoint);
            float flexPoint = sittingHeightDifference - flexPointOffset * verticalDrop;
            baseSitOffset += isSitting
                ? Lerp(part, isFirstPart ? sittingHeightDifference : flexPoint, isFirstPart ? flexPoint : bottomPoint)
                : Lerp(part, isFirstPart ? bottomPoint - sittingHeightDifference : bottomPoint - flexPoint, isFirstPart ? bottomPoint - flexPoint : 0.0F);
        }
        if (isSitting && !isInTransition) {
            baseSitOffset += bottomPoint;
        }
        return baseSitOffset;
    }

    private static float Lerp(float alpha, float from, float to) => from + alpha * (to - from);
}
