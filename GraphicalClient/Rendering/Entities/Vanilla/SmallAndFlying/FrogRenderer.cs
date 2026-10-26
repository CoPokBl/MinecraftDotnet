using ClientLib.Entities;
using ClientLib.World;
using Minecraft.Data.FrogVariant;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Entities;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class FrogRenderState : LivingEntityRenderState {
    private const string DefaultTexture = "minecraft:textures/entity/frog/frog_temperate.png";
    public bool IsSwimming;
    public AnimationState JumpAnimationState = new();
    public AnimationState CroakAnimationState = new();
    public AnimationState TongueAnimationState = new();
    public AnimationState SwimIdleAnimationState = new();
    public string Texture = DefaultTexture;
}

public sealed class FrogRenderer : MobRenderer<FrogRenderState, FrogModel> {
    public FrogRenderer(EntityRendererContext context) : base(new FrogModel(FrogModel.CreateBodyLayer().BakeRoot()), 0.3F) { }

    /// <summary>The animation states <c>Frog</c> keeps, and the pose it last saw.</summary>
    private sealed class Animations {
        public readonly AnimationState Jump = new(), Croak = new(), Tongue = new(), SwimIdle = new();
        public EntityPose? Pose;

        /// <summary>
        /// <c>Frog.walkAnimation</c>, kept here because <c>Frog.updateWalkAnimation</c> strides 25 times
        /// as far per block as the client's shared walk state and stands still while jumping.
        /// </summary>
        public float WalkSpeedOld, WalkSpeed, WalkPosition;
    }

    public override void Tick(ClientEntity entity, ClientLevel level) {
        Animations animations = (Animations)(entity.RendererData ??= new Animations());
        EntityPose pose = entity.Get(EntityDataFields.Entity.Pose, EntityPose.Standing);
        if (animations.Pose != pose) {
            // Frog.onSyncedDataUpdated for DATA_POSE. The value arrived between the last tick and this
            // one, while vanilla's tickCount was one lower.
            int tickCount = entity.TickCount - 1;
            StartOrStop(animations.Jump, pose == EntityPose.LongJumping, tickCount);
            StartOrStop(animations.Croak, pose == EntityPose.Croaking, tickCount);
            StartOrStop(animations.Tongue, pose == EntityPose.UsingTongue, tickCount);
            animations.Pose = pose;
        }
        // Frog.tick, before super.tick has moved the walk animation.
        animations.SwimIdle.AnimateWhen(EntityWater.IsInWater(level, entity) && !(animations.WalkSpeed > 1.0E-5F), entity.TickCount);
        // LivingEntity.calculateEntityAnimation, then Frog.updateWalkAnimation.
        if (entity.VehicleId == null && entity.CurrentHealth > 0) {
            double dx = entity.Position.X - entity.OldPosition.X, dz = entity.Position.Z - entity.OldPosition.Z;
            float distance = (float)Math.Sqrt(dx * dx + dz * dz);
            float targetSpeed = animations.Jump.IsStarted ? 0.0F : Math.Min(distance * 25.0F, 1.0F);
            animations.WalkSpeedOld = animations.WalkSpeed;
            animations.WalkSpeed = animations.WalkSpeed + (targetSpeed - animations.WalkSpeed) * 0.4F;
            animations.WalkPosition = animations.WalkPosition + animations.WalkSpeed;
        }
        else {
            animations.WalkSpeedOld = 0.0F;
            animations.WalkSpeed = 0.0F;
            animations.WalkPosition = 0.0F;
        }
    }

    private static void StartOrStop(AnimationState animation, bool start, int tickCount) {
        if (start) {
            animation.Start(tickCount);
        }
        else {
            animation.Stop();
        }
    }

    public override string GetTextureLocation(FrogRenderState state) => state.Texture;

    public override void ExtractRenderState(ClientEntity entity, FrogRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        state.IsSwimming = EntityWater.IsInWater(context.Level, entity);
        state.IsInWater = state.IsSwimming;
        if (entity.RendererData is Animations animations) {
            state.JumpAnimationState = animations.Jump;
            state.CroakAnimationState = animations.Croak;
            state.TongueAnimationState = animations.Tongue;
            state.SwimIdleAnimationState = animations.SwimIdle;
            state.WalkAnimationPos = animations.WalkPosition - animations.WalkSpeed * (1.0F - partialTick);
            state.WalkAnimationSpeed = Math.Min(Mth.Lerp(partialTick, animations.WalkSpeedOld, animations.WalkSpeed), 1.0F);
        }
        IFrogVariant? variant = SyncedVariants.Resolve(context.Client.Registry.FrogVariants, entity, EntityDataFields.Frog.Variant, FrogVariant.Temperate.Identifier);
        if (variant != null) {
            state.Texture = SyncedVariants.TexturePath(variant.AssetId);
        }
    }
}
