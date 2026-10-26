using ClientLib.Entities;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class HoglinRenderState : LivingEntityRenderState {
    public int AttackAnimationRemainingTicks;
    public bool IsConverting;
}

public abstract class AbstractHoglinRenderer(string texture, string babyTexture)
    : AgeableMobRenderer<HoglinRenderState, HoglinModel>(new HoglinModel(HoglinModel.CreateBodyLayer().BakeRoot()),
        new BabyHoglinModel(BabyHoglinModel.CreateBodyLayer().BakeRoot()), 0.7F) {
    /// <summary><c>attackAnimationRemainingTicks</c>, which entity event 4 starts.</summary>
    private sealed class Headbutt {
        public int RemainingTicks;
    }

    public override void HandleEntityEvent(ClientEntity entity, byte eventId) {
        if (eventId == 4) {
            ((Headbutt)(entity.RendererData ??= new Headbutt())).RemainingTicks = 10;
        }
    }

    /// <summary>The <c>aiStep</c> countdown.</summary>
    public override void Tick(ClientEntity entity) {
        if (entity.RendererData is Headbutt { RemainingTicks: > 0 } headbutt) {
            headbutt.RemainingTicks--;
        }
    }

    public override string GetTextureLocation(HoglinRenderState state) => state.IsBaby ? babyTexture : texture;

    public override void ExtractRenderState(ClientEntity entity, HoglinRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        state.AttackAnimationRemainingTicks = entity.RendererData is Headbutt headbutt ? headbutt.RemainingTicks : 0;
    }
}
