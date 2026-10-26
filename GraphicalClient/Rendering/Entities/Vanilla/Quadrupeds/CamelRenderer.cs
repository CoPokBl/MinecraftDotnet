using ClientLib.Entities;
using ClientLib.World;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class CamelRenderState : LivingEntityRenderState {
    public ItemStack Saddle = ItemStack.Air;
    public bool IsRidden;
    public float JumpCooldown;
    public AnimationState SitAnimationState = new();
    public AnimationState SitPoseAnimationState = new();
    public AnimationState SitUpAnimationState = new();
    public AnimationState IdleAnimationState = new();
    public AnimationState DashAnimationState = new();
}

public sealed class CamelRenderer : AgeableMobRenderer<CamelRenderState, CamelModel> {
    public CamelRenderer(EntityRendererContext context)
        : base(new AdultCamelModel(AdultCamelModel.CreateBodyLayer().BakeRoot()), new BabyCamelModel(BabyCamelModel.CreateBodyLayer().BakeRoot()), 0.7F) {
        AddLayer(CreateCamelSaddleLayer(context, this, EquipmentClientInfo.LayerType.CamelSaddle));
    }

    /// <summary>The camel husk's saddle layer is baked from the same layer definition as the camel's.</summary>
    internal static SimpleEquipmentLayer<CamelRenderState, CamelModel, CamelRenderState> CreateCamelSaddleLayer(EntityRendererContext context,
        LivingEntityRenderer<CamelRenderState, CamelModel> renderer, EquipmentClientInfo.LayerType saddleLayerType) =>
        new(renderer, EquipmentLayerRenderer.For(context), saddleLayerType, state => state.Saddle,
            new CamelSaddleModel(CamelSaddleModel.CreateSaddleLayer().BakeRoot()), null);

    public override string GetTextureLocation(CamelRenderState state) =>
        state.IsBaby ? "minecraft:textures/entity/camel/camel_baby.png" : "minecraft:textures/entity/camel/camel.png";

    public override void Tick(ClientEntity entity, ClientLevel level) => CamelClientState.Tick(entity, level);

    public override void ExtractRenderState(ClientEntity entity, CamelRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        ExtractAdditionalState(entity, state, partialTick);
    }

    internal static void ExtractAdditionalState(ClientEntity entity, CamelRenderState state, float partialTick) {
        state.Saddle = entity.GetItemBySlot(EquipmentSlot.Saddle);
        state.IsRidden = entity.Passengers.Length > 0;
        if (entity.RendererData is not CamelClientState camel) {
            return;
        }
        state.JumpCooldown = Math.Max(camel.DashCooldown - partialTick, 0.0F);
        state.SitAnimationState = camel.Sit;
        state.SitPoseAnimationState = camel.SitPose;
        state.SitUpAnimationState = camel.SitUp;
        state.IdleAnimationState = camel.Idle;
        state.DashAnimationState = camel.Dash;
        // Camel.updateWalkAnimation replaces the walk the client entity keeps, so the state reads this one instead.
        if (entity.VehicleId == null && entity.CurrentHealth > 0) {
            state.WalkAnimationPos = camel.WalkPosition(partialTick);
            state.WalkAnimationSpeed = Math.Min(Mth.Lerp(partialTick, camel.WalkSpeedOld, camel.WalkSpeed), 1.0F);
        }
    }
}

/// <summary>What a <c>Camel</c> keeps on the client: its animation states, idle timer, dash cooldown and walk animation.</summary>
internal sealed class CamelClientState {
    public readonly AnimationState Sit = new(), SitPose = new(), SitUp = new(), Idle = new(), Dash = new();
    public int IdleAnimationTimeout;
    public int DashCooldown;
    public bool? LastDash;
    public float WalkPositionUnscaled, WalkSpeed, WalkSpeedOld, WalkPositionScale = 1.0F;

    /// <summary><c>WalkAnimationState.position(partialTicks)</c>.</summary>
    public float WalkPosition(float partialTick) => (WalkPositionUnscaled - WalkSpeed * (1.0F - partialTick)) * WalkPositionScale;

    /// <summary>
    /// <c>Camel.tick</c> on the client, after <c>LivingEntity.tick</c>'s walk animation. The client side
    /// clearing of a finished dash is left to the server's next update.
    /// </summary>
    public static void Tick(ClientEntity entity, ClientLevel level) {
        CamelClientState camel = (CamelClientState)(entity.RendererData ??= new CamelClientState());
        bool dash = entity.Get(EntityDataFields.Camel.Dash);
        // onSyncedDataUpdated for DASH, which the first tick's data does not count for.
        if (camel.LastDash != null && camel.LastDash != dash) {
            camel.DashCooldown = camel.DashCooldown == 0 ? 55 : camel.DashCooldown;
        }
        camel.LastDash = dash;

        camel.CalculateEntityAnimation(entity);
        if (camel.DashCooldown > 0) {
            camel.DashCooldown--;
        }
        camel.SetupAnimationStates(entity, level);
    }

    /// <summary><c>LivingEntity.calculateEntityAnimation</c> with <c>Camel.updateWalkAnimation</c>.</summary>
    private void CalculateEntityAnimation(ClientEntity entity) {
        double dx = entity.Position.X - entity.OldPosition.X, dz = entity.Position.Z - entity.OldPosition.Z;
        float distance = (float)Math.Sqrt(dx * dx + dz * dz);
        if (entity.VehicleId == null && entity.CurrentHealth > 0) {
            float targetSpeed = entity.Get(EntityDataFields.Entity.Pose, EntityPose.Standing) == EntityPose.Standing && !Dash.IsStarted
                ? Math.Min(distance * 6.0F, 1.0F)
                : 0.0F;
            // WalkAnimationState.update(targetSpeed, 0.2F, isBaby ? 3.0F : 1.0F).
            WalkSpeedOld = WalkSpeed;
            WalkSpeed += (targetSpeed - WalkSpeed) * 0.2F;
            WalkPositionUnscaled += WalkSpeed;
            WalkPositionScale = entity.IsBaby ? 3.0F : 1.0F;
        }
        else {
            WalkSpeedOld = 0.0F;
            WalkSpeed = 0.0F;
        }
    }

    /// <summary><c>Camel.setupAnimationStates</c>.</summary>
    private void SetupAnimationStates(ClientEntity entity, ClientLevel level) {
        int tickCount = entity.TickCount;
        if (IdleAnimationTimeout <= 0) {
            IdleAnimationTimeout = Random.Shared.Next(40) + 80;
            Idle.Start(tickCount);
        }
        else {
            IdleAnimationTimeout--;
        }
        long lastPoseChangeTick = entity.Get(EntityDataFields.Camel.LastPoseChangeTick);
        bool isCamelSitting = lastPoseChangeTick < 0L;
        long poseTime = level.GameTime - Math.Abs(lastPoseChangeTick);
        bool isInPoseTransition = poseTime < (isCamelSitting ? 40 : 52);
        bool isCamelVisuallySitting = poseTime < 0L != isCamelSitting;
        if (isCamelVisuallySitting) {
            SitUp.Stop();
            Dash.Stop();
            // isVisuallySittingDown.
            if (isCamelSitting && poseTime < 40L && poseTime >= 0L) {
                Sit.StartIfStopped(tickCount);
                SitPose.Stop();
            }
            else {
                Sit.Stop();
                SitPose.StartIfStopped(tickCount);
            }
        }
        else {
            Sit.Stop();
            SitPose.Stop();
            Dash.AnimateWhen(entity.Get(EntityDataFields.Camel.Dash), tickCount);
            SitUp.AnimateWhen(isInPoseTransition && poseTime >= 0L, tickCount);
        }
    }
}
