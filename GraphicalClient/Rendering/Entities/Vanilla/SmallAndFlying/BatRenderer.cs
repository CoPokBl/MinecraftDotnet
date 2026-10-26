using ClientLib.Entities;
using ClientLib.World;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class BatRenderState : LivingEntityRenderState {
    public bool IsResting;
    public AnimationState FlyAnimationState = new();
    public AnimationState RestAnimationState = new();
}

public sealed class BatRenderer : MobRenderer<BatRenderState, BatModel> {
    public BatRenderer(EntityRendererContext context) : base(new BatModel(BatModel.CreateBodyLayer().BakeRoot()), 0.25F) { }

    /// <summary><c>Bat.flyAnimationState</c> and <c>restAnimationState</c>.</summary>
    private sealed class Animations {
        public readonly AnimationState Fly = new(), Rest = new();
    }

    /// <summary><c>Bat.isResting</c>: bit 1 of <c>DATA_ID_FLAGS</c>.</summary>
    private static bool IsResting(ClientEntity entity) => (entity.Get(EntityDataFields.Bat.IdFlags) & 1) != 0;

    /// <summary><c>Bat.setupAnimationStates</c>, from <c>tick</c>.</summary>
    public override void Tick(ClientEntity entity, ClientLevel level) {
        Animations animations = (Animations)(entity.RendererData ??= new Animations());
        if (IsResting(entity)) {
            animations.Fly.Stop();
            animations.Rest.StartIfStopped(entity.TickCount);
        }
        else {
            animations.Rest.Stop();
            animations.Fly.StartIfStopped(entity.TickCount);
        }
    }

    public override string GetTextureLocation(BatRenderState state) => "minecraft:textures/entity/bat/bat.png";

    public override void ExtractRenderState(ClientEntity entity, BatRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        state.IsResting = IsResting(entity);
        if (entity.RendererData is Animations animations) {
            state.FlyAnimationState = animations.Fly;
            state.RestAnimationState = animations.Rest;
        }
    }
}
