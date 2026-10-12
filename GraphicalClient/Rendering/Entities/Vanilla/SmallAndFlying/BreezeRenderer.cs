using ClientLib.Entities;
using ClientLib.World;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Entities;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class BreezeRenderState : LivingEntityRenderState {
    public AnimationState Idle = new();
    public AnimationState Shoot = new();
    public AnimationState Slide = new();
    public AnimationState SlideBack = new();
    public AnimationState Inhale = new();
    public AnimationState LongJump = new();
}

/// <summary>
/// <c>BreezeRenderer</c>. <c>BreezeWindLayer</c> is not drawn: its render type scrolls the texture with
/// the entity's age, which the entity batches have no way to express.
/// </summary>
public sealed class BreezeRenderer : MobRenderer<BreezeRenderState, BreezeModel> {
    public BreezeRenderer(EntityRendererContext context) : base(new BreezeModel(BreezeModel.CreateBodyLayer().BakeRoot()), 0.5F) {
        AddLayer(new BreezeEyesLayer(this));
    }

    /// <summary>The animation states <c>Breeze</c> keeps, and the pose it last saw.</summary>
    private sealed class Animations {
        public readonly AnimationState Idle = new(), Slide = new(), SlideBack = new(), LongJump = new(), Shoot = new(), Inhale = new();
        public EntityPose? Pose;
    }

    public override void Tick(ClientEntity entity, ClientLevel level) {
        Animations a = (Animations)(entity.RendererData ??= new Animations());
        EntityPose pose = entity.Get(EntityDataFields.Entity.Pose, EntityPose.Standing);
        if (a.Pose != pose) {
            // Breeze.onSyncedDataUpdated for DATA_POSE. The value arrived between the last tick and this
            // one, while vanilla's tickCount was one lower.
            int tickCount = entity.TickCount - 1;
            a.Shoot.Stop();
            a.Idle.Stop();
            a.Inhale.Stop();
            a.LongJump.Stop();
            switch (pose) {
                case EntityPose.Shooting:
                    a.Shoot.StartIfStopped(tickCount);
                    break;
                case EntityPose.Inhaling:
                    a.Inhale.StartIfStopped(tickCount);
                    break;
                case EntityPose.Sliding:
                    a.Slide.StartIfStopped(tickCount);
                    break;
            }
            a.Pose = pose;
        }
        // Breeze.tick.
        if (pose == EntityPose.LongJumping) {
            a.LongJump.StartIfStopped(entity.TickCount);
        }
        a.Idle.StartIfStopped(entity.TickCount);
        if (pose != EntityPose.Sliding && a.Slide.IsStarted) {
            a.SlideBack.Start(entity.TickCount);
            a.Slide.Stop();
        }
    }

    public override string GetTextureLocation(BreezeRenderState state) => "minecraft:textures/entity/breeze/breeze.png";

    public override void ExtractRenderState(ClientEntity entity, BreezeRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        if (entity.RendererData is Animations a) {
            state.Idle = a.Idle;
            state.Shoot = a.Shoot;
            state.Slide = a.Slide;
            state.SlideBack = a.SlideBack;
            state.Inhale = a.Inhale;
            state.LongJump = a.LongJump;
        }
    }
}
