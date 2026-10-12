using ClientLib.Entities;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class GlowSquidRenderer : SquidRenderer {
    public GlowSquidRenderer(EntityRendererContext context) : base(context) { }

    public override string GetTextureLocation(SquidRenderState state) =>
        state.IsBaby ? "minecraft:textures/entity/squid/glow_squid_baby.png" : "minecraft:textures/entity/squid/glow_squid.png";

    public override void ExtractRenderState(ClientEntity entity, SquidRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        // getBlockLightLevel: the world's light while a hurt's dark ticks run, brightening back to full over the last ten.
        int glowLightLevel = (int)Mth.ClampedLerp(1.0F - entity.Get(EntityDataFields.GlowSquid.DarkTicksRemaining) / 10.0F, 0.0F, 15.0F);
        state.BlockLight = glowLightLevel == 15 ? 15 : Math.Max(glowLightLevel, state.BlockLight);
    }
}
