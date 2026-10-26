using ClientLib.Entities;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Entities;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class ArmadilloRenderState : LivingEntityRenderState {
    public bool IsHidingInShell;
    public AnimationState RollOutAnimationState = new();
    public AnimationState RollUpAnimationState = new();
    public AnimationState PeekAnimationState = new();
}

public sealed class ArmadilloRenderer() : AgeableMobRenderer<ArmadilloRenderState, ArmadilloModel>(
    new AdultArmadilloModel(AdultArmadilloModel.CreateBodyLayer().BakeRoot()), new BabyArmadilloModel(BabyArmadilloModel.CreateBodyLayer().BakeRoot()), 0.4F) {
    /// <summary><c>Armadillo.ArmadilloState.SCARED.animationDuration</c>.</summary>
    private const int ScaredAnimationDuration = 50;

    /// <summary>What <c>Armadillo</c> keeps on the client: its animation states, how long it has been in its state, and the peek event.</summary>
    private sealed class ArmadilloAnimations {
        public ArmadilloState? LastState;
        public long InStateTicks;
        public bool PeekReceivedClient;
        public readonly AnimationState RollOut = new(), RollUp = new(), Peek = new();
    }

    public override void HandleEntityEvent(ClientEntity entity, byte eventId) {
        if (eventId == 64) {
            ((ArmadilloAnimations)(entity.RendererData ??= new ArmadilloAnimations())).PeekReceivedClient = true;
        }
    }

    /// <summary>
    /// <c>Armadillo.tick</c> on the client: <c>setupAnimationStates</c>, then the state tick count, which
    /// <c>onSyncedDataUpdated</c> zeroes when a new state arrives.
    /// </summary>
    public override void Tick(ClientEntity entity) {
        ArmadilloAnimations animations = (ArmadilloAnimations)(entity.RendererData ??= new ArmadilloAnimations());
        ArmadilloState state = GetState(entity);
        if (animations.LastState != state) {
            animations.LastState = state;
            animations.InStateTicks = 0L;
        }
        int tickCount = entity.TickCount;
        switch (state) {
            case ArmadilloState.Idle:
                animations.RollOut.Stop();
                animations.RollUp.Stop();
                animations.Peek.Stop();
                break;
            case ArmadilloState.Rolling:
                animations.RollOut.Stop();
                animations.RollUp.StartIfStopped(tickCount);
                animations.Peek.Stop();
                break;
            case ArmadilloState.Scared:
                animations.RollOut.Stop();
                animations.RollUp.Stop();
                if (animations.PeekReceivedClient) {
                    animations.Peek.Stop();
                    animations.PeekReceivedClient = false;
                }
                if (animations.InStateTicks == 0L) {
                    // start, then fastForward(SCARED.animationDuration, 1.0F).
                    animations.Peek.Start(tickCount - (int)(ScaredAnimationDuration * 1.0F));
                }
                else {
                    animations.Peek.StartIfStopped(tickCount);
                }
                break;
            case ArmadilloState.Unrolling:
                animations.RollOut.StartIfStopped(tickCount);
                animations.RollUp.Stop();
                animations.Peek.Stop();
                break;
        }
        animations.InStateTicks++;
    }

    private static ArmadilloState GetState(ClientEntity entity) => entity.Get(EntityDataFields.Armadillo.ArmadilloState, ArmadilloState.Idle);

    /// <summary><c>Armadillo.ArmadilloState.shouldHideInShell</c>.</summary>
    private static bool ShouldHideInShell(ArmadilloState state, long ticksInState) => state switch {
        ArmadilloState.Rolling => ticksInState > 5L,
        ArmadilloState.Scared => true,
        ArmadilloState.Unrolling => ticksInState < 26L,
        _ => false
    };

    public override string GetTextureLocation(ArmadilloRenderState state) =>
        state.IsBaby ? "minecraft:textures/entity/armadillo/armadillo_baby.png" : "minecraft:textures/entity/armadillo/armadillo.png";

    public override void ExtractRenderState(ClientEntity entity, ArmadilloRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        ArmadilloAnimations? animations = entity.RendererData as ArmadilloAnimations;
        state.IsHidingInShell = ShouldHideInShell(GetState(entity), animations?.InStateTicks ?? 0L);
        if (animations != null) {
            state.PeekAnimationState = animations.Peek;
            state.RollOutAnimationState = animations.RollOut;
            state.RollUpAnimationState = animations.RollUp;
        }
    }
}
