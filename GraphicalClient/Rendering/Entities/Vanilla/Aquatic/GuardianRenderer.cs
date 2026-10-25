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

/// <summary><c>GuardianRenderer</c>, with the client half of <c>Guardian.aiStep</c> that animates it.</summary>
public class GuardianRenderer : MobRenderer<GuardianRenderState, GuardianModel> {
    private static readonly Random Random = new();
    private const string BeamLocation = "minecraft:textures/entity/guardian/guardian_beam.png";
    private const int TallRepeats = 16;

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
    /// <c>Guardian.aiStep</c> on the client. The flop sound is not produced, the bubbles are
    /// <see cref="ClientLib.Particles.EntityParticles"/>', and the look control turning the head toward an
    /// attack target is left to the head rotation the server sends.
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

    /// <summary><c>shouldRender</c>: a guardian out of view whose beam is not.</summary>
    public override bool ShouldRenderOutOfView(ClientEntity entity, Frustum frustum, EntityRenderContext context) {
        if (entity.Get(EntityDataFields.Guardian.IdAttackTarget) == 0 || ActiveAttackTarget(entity, context) is not { } lookAtEntity) {
            return false;
        }
        Vec3d camera = context.Camera.Position;
        Vec3d targetPos = Position(lookAtEntity, lookAtEntity.Height * 0.5, 1.0F) - camera;
        Vec3d startPos = Position(entity, entity.EyeHeight, 1.0F) - camera;
        System.Numerics.Vector3 a = new((float)startPos.X, (float)startPos.Y, (float)startPos.Z), b = new((float)targetPos.X, (float)targetPos.Y, (float)targetPos.Z);
        return frustum.Intersects(System.Numerics.Vector3.Min(a, b), System.Numerics.Vector3.Max(a, b));
    }

    public override void Submit(GuardianRenderState state, PoseStack pose, EntityRenderContext context) {
        base.Submit(state, pose, context);
        if (state.AttackTargetPosition is { } targetPosition) {
            float texVOff = state.AttackTime * 0.5F % 1.0F;
            pose.Push();
            pose.Translate(0.0F, state.EyeHeight, 0.0F);
            RenderBeam(pose, context, targetPosition - state.EyePosition, state.AttackTime, state.AttackScale, texVOff);
            pose.Pop();
        }
    }

    /// <summary><c>renderBeam</c>: two crossed planes along the beam, their texture scrolling down it, and a cap at the target.</summary>
    private static void RenderBeam(PoseStack pose, EntityRenderContext context, Vec3d beamVector, float timeInTicks, float scale, float texVOff) {
        if (context.Textures.Get(BeamLocation) is not { } texture) {
            return;
        }
        float length = (float)(Math.Sqrt(beamVector.X * beamVector.X + beamVector.Y * beamVector.Y + beamVector.Z * beamVector.Z) + 1.0);
        beamVector = beamVector.Normalize();
        float xRot = (float)Math.Acos(beamVector.Y);
        float yRot = (float)(Math.PI / 2) - (float)Math.Atan2(beamVector.Z, beamVector.X);
        pose.RotateYDegrees(yRot * (180.0F / (float)Math.PI));
        pose.RotateXDegrees(xRot * (180.0F / (float)Math.PI));
        float rot = timeInTicks * 0.05F * -1.5F;
        float colorScale = scale * scale;
        int red = 64 + (int)(colorScale * 191.0F);
        int green = 32 + (int)(colorScale * 191.0F);
        int blue = 128 - (int)(colorScale * 64.0F);
        float wnx = Mth.Cos(rot + (float)(Math.PI * 3.0 / 4.0)) * 0.282F;
        float wnz = Mth.Sin(rot + (float)(Math.PI * 3.0 / 4.0)) * 0.282F;
        float enx = Mth.Cos(rot + (float)(Math.PI / 4)) * 0.282F;
        float enz = Mth.Sin(rot + (float)(Math.PI / 4)) * 0.282F;
        float wsx = Mth.Cos(rot + (float)Math.PI * 5.0F / 4.0F) * 0.282F;
        float wsz = Mth.Sin(rot + (float)Math.PI * 5.0F / 4.0F) * 0.282F;
        float esx = Mth.Cos(rot + (float)Math.PI * 7.0F / 4.0F) * 0.282F;
        float esz = Mth.Sin(rot + (float)Math.PI * 7.0F / 4.0F) * 0.282F;
        float wx = Mth.Cos(rot + (float)Math.PI) * 0.2F;
        float wz = Mth.Sin(rot + (float)Math.PI) * 0.2F;
        float ex = Mth.Cos(rot + 0.0F) * 0.2F;
        float ez = Mth.Sin(rot + 0.0F) * 0.2F;
        float nx = Mth.Cos(rot + (float)(Math.PI / 2)) * 0.2F;
        float nz = Mth.Sin(rot + (float)(Math.PI / 2)) * 0.2F;
        float sx = Mth.Cos(rot + (float)(Math.PI * 3.0 / 2.0)) * 0.2F;
        float sz = Mth.Sin(rot + (float)(Math.PI * 3.0 / 2.0)) * 0.2F;
        float minV = -1.0F + texVOff;
        float maxV = minV + length * 2.5F;
        // entityCutout at full light, untouched by the overlay.
        ModelDrawState draw = new(texture, 0xFF000000 | (uint)red << 16 | (uint)green << 8 | (uint)blue, 15, 15, 0) { NoOutline = true };
        System.Numerics.Matrix4x4 m = pose.Matrix;
        System.Numerics.Vector3 normal = pose.TransformNormal(System.Numerics.Vector3.UnitY);
        System.Numerics.Vector3 V(float x, float y, float z) => System.Numerics.Vector3.Transform(new System.Numerics.Vector3(x, y, z), m);
        // The sides repeat two and a half times a block, drawn from the texture tiled down once it is ready.
        EntityTexture? tall = TiledTextures.Get(context.Textures, BeamLocation, 1, TallRepeats);
        ModelDrawState sides = tall == null ? draw : draw with { Texture = tall };
        float repeats = tall == null ? 1.0F : TallRepeats;
        ReadOnlySpan<System.Numerics.Vector2> sideUvs = [new(0.4999F, maxV / repeats), new(0.4999F, minV / repeats), new(0.0F, minV / repeats), new(0.0F, maxV / repeats)];
        context.Batch.RepeatingQuad([V(wx, length, wz), V(wx, 0.0F, wz), V(ex, 0.0F, ez), V(ex, length, ez)], sideUvs, normal, sides);
        context.Batch.RepeatingQuad([V(nx, length, nz), V(nx, 0.0F, nz), V(sx, 0.0F, sz), V(sx, length, sz)], sideUvs, normal, sides);
        float vBase = Mth.Floor(timeInTicks) % 2 == 0 ? 0.5F : 0.0F;
        context.Batch.Quad([V(wnx, length, wnz), V(enx, length, enz), V(esx, length, esz), V(wsx, length, wsz)],
            [new(0.5F, vBase + 0.5F), new(1.0F, vBase + 0.5F), new(1.0F, vBase), new(0.5F, vBase)], normal, draw);
    }
}
