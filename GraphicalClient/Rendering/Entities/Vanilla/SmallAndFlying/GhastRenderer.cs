using ClientLib.Entities;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class GhastRenderState : LivingEntityRenderState {
    public bool IsCharging;
}

public sealed class GhastRenderer : MobRenderer<GhastRenderState, GhastModel> {
    public GhastRenderer(EntityRendererContext context) : base(new GhastModel(GhastModel.CreateBodyLayer().BakeRoot()), 1.5F) { }

    public override string GetTextureLocation(GhastRenderState state) =>
        state.IsCharging ? "minecraft:textures/entity/ghast/ghast_shooting.png" : "minecraft:textures/entity/ghast/ghast.png";

    public override void ExtractRenderState(ClientEntity entity, GhastRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        state.IsCharging = entity.Get(EntityDataFields.Ghast.IsCharging);
    }
}
