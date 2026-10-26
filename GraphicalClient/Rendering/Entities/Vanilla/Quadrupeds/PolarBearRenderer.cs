using ClientLib.Entities;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class PolarBearRenderState : LivingEntityRenderState {
    public float StandScale;
}

public sealed class PolarBearRenderer() : AgeableMobRenderer<PolarBearRenderState, PolarBearModel>(
    new PolarBearModel(PolarBearModel.CreateBodyLayer().BakeRoot()), new PolarBearModel(BabyPolarBearModel.CreateBodyLayer().BakeRoot()), 0.9F) {
    /// <summary><c>PolarBear.clientSideStandAnimation</c> and its previous value.</summary>
    private sealed class StandAnimation {
        public float Current, Old;
    }

    /// <summary><c>PolarBear.tick</c>'s client side stand count.</summary>
    public override void Tick(ClientEntity entity) {
        StandAnimation stand = (StandAnimation)(entity.RendererData ??= new StandAnimation());
        stand.Old = stand.Current;
        stand.Current = entity.Get(EntityDataFields.PolarBear.Standing)
            ? Mth.Clamp(stand.Current + 1.0F, 0.0F, 6.0F)
            : Mth.Clamp(stand.Current - 1.0F, 0.0F, 6.0F);
    }

    public override string GetTextureLocation(PolarBearRenderState state) =>
        state.IsBaby ? "minecraft:textures/entity/bear/polarbear_baby.png" : "minecraft:textures/entity/bear/polarbear.png";

    public override void ExtractRenderState(ClientEntity entity, PolarBearRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        // PolarBear.getStandingAnimationScale.
        state.StandScale = entity.RendererData is StandAnimation stand ? Mth.Lerp(partialTick, stand.Old, stand.Current) / 6.0F : 0.0F;
    }
}
