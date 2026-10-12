using ClientLib.Entities;
using ClientLib.Maths;
using ClientLib.Player;
using ClientLib.World;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class GuardianRenderState : LivingEntityRenderState {
    public float SpikesAnimation, TailAnimation;
    public Vec3d EyePosition = Vec3d.Zero;
    public Vec3d? LookDirection, LookAtPosition, AttackTargetPosition;
    public float AttackTime, AttackScale;
}

/// <summary>
/// <c>GuardianRenderer</c>, with the client half of <c>Guardian.aiStep</c> that animates it. The attack
/// beam is not drawn: its texture scrolls and repeats along the beam, which an entity pass sampling an
/// atlas cannot express. <c>shouldRender</c>'s extension to a guardian whose beam is on screen goes with it.
/// </summary>
public class GuardianRenderer : MobRenderer<GuardianRenderState, GuardianModel> {
    private static readonly Random Random = new();

    public GuardianRenderer(EntityRendererContext context) : this(context, 0.5F, GuardianModel.CreateBodyLayer()) { }

    protected GuardianRenderer(EntityRendererContext context, float shadow, LayerDefinition model) : base(new GuardianModel(model.BakeRoot()), shadow) { }

    /// <summary>The client side fields <c>Guardian</c> keeps.</summary>
    private sealed class Guardian {
        public float TailAnimation, TailAnimationO, TailAnimationSpeed, SpikesAnimation, SpikesAnimationO;
        public int AttackTime, AttackTarget;

        public Guardian() {
            TailAnimation = Random.NextSingle();
            TailAnimationO = TailAnimation;
        }
    }

    private static Guardian DataOf(ClientEntity entity) => (Guardian)(entity.RendererData ??= new Guardian());

    /// <summary><c>Guardian.getAttackDuration</c>, which <c>ElderGuardian</c> shortens.</summary>
    private static int AttackDuration(ClientEntity entity) => entity.Is(EntityClass.ElderGuardian) ? 60 : 80;

    /// <summary>
    /// <c>Guardian.aiStep</c> on the client. The flop sound and the bubble particles are not produced, and
    /// the look control turning the head toward an attack target is left to the head rotation the server
    /// sends.
    /// </summary>
    public override void Tick(ClientEntity entity, ClientLevel level) {
        Guardian guardian = DataOf(entity);
        // onSyncedDataUpdated restarts the attack timer whenever the target id arrives.
        int attackTarget = entity.Get(EntityDataFields.Guardian.IdAttackTarget);
        if (attackTarget != guardian.AttackTarget) {
            guardian.AttackTarget = attackTarget;
            guardian.AttackTime = 0;
        }
        if (entity.CurrentHealth <= 0) {
            return;
        }
        bool inWater = EntityWater.IsInWater(level, entity);
        bool moving = entity.Get(EntityDataFields.Guardian.IdMoving);
        guardian.TailAnimationO = guardian.TailAnimation;
        if (!inWater) {
            guardian.TailAnimationSpeed = 2.0F;
        }
        else if (moving) {
            if (guardian.TailAnimationSpeed < 0.5F) {
                guardian.TailAnimationSpeed = 4.0F;
            }
            else {
                guardian.TailAnimationSpeed = guardian.TailAnimationSpeed + (0.5F - guardian.TailAnimationSpeed) * 0.1F;
            }
        }
        else {
            guardian.TailAnimationSpeed = guardian.TailAnimationSpeed + (0.125F - guardian.TailAnimationSpeed) * 0.2F;
        }
        guardian.TailAnimation = guardian.TailAnimation + guardian.TailAnimationSpeed;
        guardian.SpikesAnimationO = guardian.SpikesAnimation;
        if (!inWater) {
            guardian.SpikesAnimation = Random.NextSingle();
        }
        else if (moving) {
            guardian.SpikesAnimation = guardian.SpikesAnimation + (0.0F - guardian.SpikesAnimation) * 0.25F;
        }
        else {
            guardian.SpikesAnimation = guardian.SpikesAnimation + (1.0F - guardian.SpikesAnimation) * 0.06F;
        }
        if (attackTarget != 0 && guardian.AttackTime < AttackDuration(entity)) {
            guardian.AttackTime++;
        }
    }

    public override string GetTextureLocation(GuardianRenderState state) => "minecraft:textures/entity/guardian/guardian.png";

    public override void ExtractRenderState(ClientEntity entity, GuardianRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        Guardian guardian = DataOf(entity);
        state.SpikesAnimation = Mth.Lerp(partialTick, guardian.SpikesAnimationO, guardian.SpikesAnimation);
        state.TailAnimation = Mth.Lerp(partialTick, guardian.TailAnimationO, guardian.TailAnimation);
        state.EyePosition = EyePosition(entity, partialTick);
        ClientEntity? targetEntity = ActiveAttackTarget(entity, context);
        // getEntityToLookAt: the attack target while there is one, otherwise the camera's entity.
        ClientEntity? lookAtEntity = entity.Get(EntityDataFields.Guardian.IdAttackTarget) != 0 ? targetEntity : context.Client.Player;
        if (lookAtEntity != null) {
            state.LookDirection = ViewVector(entity, partialTick);
            state.LookAtPosition = EyePosition(lookAtEntity, partialTick);
        }
        else {
            state.LookDirection = null;
            state.LookAtPosition = null;
        }
        if (targetEntity != null) {
            state.AttackScale = (guardian.AttackTime + partialTick) / AttackDuration(entity);
            state.AttackTime = guardian.AttackTime + partialTick;
            state.AttackTargetPosition = Position(targetEntity, targetEntity.Height * 0.5, partialTick);
        }
        else {
            state.AttackTargetPosition = null;
        }
    }

    /// <summary><c>Guardian.getActiveAttackTarget</c> on the client: the living entity the synced id names, if loaded.</summary>
    private static ClientEntity? ActiveAttackTarget(ClientEntity entity, EntityRenderContext context) {
        int id = entity.Get(EntityDataFields.Guardian.IdAttackTarget);
        return id != 0 && context.Client.Entities.TryGetValue(id, out ClientEntity? target) && target.IsLiving ? target : null;
    }

    private static Vec3d Position(ClientEntity entity, double yOffset, float partialTick) => new(
        ClientEntity.Lerp(partialTick, entity.OldPosition.X, entity.Position.X),
        ClientEntity.Lerp(partialTick, entity.OldPosition.Y, entity.Position.Y) + yOffset,
        ClientEntity.Lerp(partialTick, entity.OldPosition.Z, entity.Position.Z));

    /// <summary><c>Entity.getEyePosition</c>. The local player's eye height follows its pose; any other entity's is its type's.</summary>
    private static Vec3d EyePosition(ClientEntity entity, float partialTick) =>
        Position(entity, entity is LocalPlayer player ? player.CurrentEyeHeight : entity.EyeHeight, partialTick);

    /// <summary><c>Entity.getViewVector</c> through <c>LivingEntity.getViewYRot</c>, which reads the head's yaw.</summary>
    private static Vec3d ViewVector(ClientEntity entity, float partialTick) {
        float xRot = partialTick == 1.0F ? entity.XRot : Mth.Lerp(partialTick, entity.XRotO, entity.XRot);
        float yRot = partialTick == 1.0F ? entity.YHeadRot : Mth.RotLerp(partialTick, entity.YHeadRotO, entity.YHeadRot);
        // calculateViewVector.
        float realXRot = xRot * (float)(Math.PI / 180.0);
        float realYRot = -yRot * (float)(Math.PI / 180.0);
        float yCos = Mth.Cos(realYRot);
        float ySin = Mth.Sin(realYRot);
        float xCos = Mth.Cos(realXRot);
        float xSin = Mth.Sin(realXRot);
        return new Vec3d(ySin * xCos, -xSin, yCos * xCos);
    }

    public override void Submit(GuardianRenderState state, PoseStack pose, EntityRenderContext context) {
        base.Submit(state, pose, context);
        // renderBeam would draw here, toward state.AttackTargetPosition; see the class comment.
    }
}
