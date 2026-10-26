using ClientLib.Entities;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Entities;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class SnifferRenderState : LivingEntityRenderState {
    public bool IsSearching;
    public AnimationState DiggingAnimationState = new();
    public AnimationState SniffingAnimationState = new();
    public AnimationState RisingAnimationState = new();
    public AnimationState FeelingHappyAnimationState = new();
    public AnimationState ScentingAnimationState = new();
}

public sealed class SnifferRenderer() : AgeableMobRenderer<SnifferRenderState, SnifferModel>(
    new SnifferModel(SnifferModel.CreateBodyLayer().BakeRoot()), new SnifferModel(SniffletModel.CreateBodyLayer().BakeRoot()), 1.1F) {
    /// <summary>The <c>Sniffer</c>'s animation states and the state they were last started for.</summary>
    private sealed class SnifferAnimations {
        public SnifferState? LastState;
        public readonly AnimationState FeelingHappy = new(), Scenting = new(), Sniffing = new(), Digging = new(), Rising = new();
    }

    /// <summary>
    /// <c>Sniffer.onSyncedDataUpdated</c> for <c>DATA_STATE</c>, run on the tick after the change arrives.
    /// Vanilla runs it as the packet lands, before the entity's tick count advances, so the start is
    /// taken one tick back.
    /// </summary>
    public override void Tick(ClientEntity entity) {
        SnifferAnimations animations = (SnifferAnimations)(entity.RendererData ??= new SnifferAnimations());
        SnifferState state = entity.Get(EntityDataFields.Sniffer.State, SnifferState.Idling);
        if (animations.LastState == state) {
            return;
        }
        animations.LastState = state;
        int tickCount = entity.TickCount - 1;
        animations.Digging.Stop();
        animations.Sniffing.Stop();
        animations.Rising.Stop();
        animations.FeelingHappy.Stop();
        animations.Scenting.Stop();
        AnimationState? started = state switch {
            SnifferState.FeelingHappy => animations.FeelingHappy,
            SnifferState.Scenting => animations.Scenting,
            SnifferState.Sniffing => animations.Sniffing,
            SnifferState.Digging => animations.Digging,
            SnifferState.Rising => animations.Rising,
            _ => null
        };
        started?.StartIfStopped(tickCount);
    }

    public override string GetTextureLocation(SnifferRenderState state) =>
        state.IsBaby ? "minecraft:textures/entity/sniffer/snifflet.png" : "minecraft:textures/entity/sniffer/sniffer.png";

    public override void ExtractRenderState(ClientEntity entity, SnifferRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        state.IsSearching = entity.Get(EntityDataFields.Sniffer.State, SnifferState.Idling) == SnifferState.Searching;
        if (entity.RendererData is SnifferAnimations animations) {
            state.DiggingAnimationState = animations.Digging;
            state.SniffingAnimationState = animations.Sniffing;
            state.RisingAnimationState = animations.Rising;
            state.FeelingHappyAnimationState = animations.FeelingHappy;
            state.ScentingAnimationState = animations.Scenting;
        }
    }
}
