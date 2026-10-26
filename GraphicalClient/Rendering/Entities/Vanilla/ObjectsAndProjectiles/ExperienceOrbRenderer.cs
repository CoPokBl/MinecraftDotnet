using ClientLib.Entities;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>ExperienceOrbRenderState</c>.</summary>
public class ExperienceOrbRenderState : EntityRenderState {
    public int Icon;
}

/// <summary><c>ExperienceOrbRenderer</c>. Its <c>entityTranslucentCullItemTarget</c> type goes to the translucent batch.</summary>
public sealed class ExperienceOrbRenderer : EntityRenderer<ExperienceOrbRenderState> {
    private const string ExperienceOrbLocation = "minecraft:textures/entity/experience/experience_orb.png";

    public ExperienceOrbRenderer() {
        ShadowRadius = 0.15F;
        ShadowStrength = 0.75F;
    }

    public override void Submit(ExperienceOrbRenderState state, PoseStack pose, EntityRenderContext context) {
        pose.Push();
        int icon = state.Icon;
        float u0 = (icon % 4 * 16 + 0) / 64.0F;
        float u1 = (icon % 4 * 16 + 16) / 64.0F;
        float v0 = (icon / 4 * 16 + 0) / 64.0F;
        float v1 = (icon / 4 * 16 + 16) / 64.0F;
        float rr = state.AgeInTicks / 2.0F;
        int rc = (int)((Mth.Sin(rr + 0.0F) + 1.0F) * 0.5F * 255.0F);
        int bc = (int)((Mth.Sin(rr + (float)(Math.PI * 4.0 / 3.0)) + 1.0F) * 0.1F * 255.0F);
        pose.Translate(0.0F, 0.1F, 0.0F);
        CameraOrientation.Apply(pose, context.Camera);
        pose.Scale(0.3F, 0.3F, 0.3F);
        uint colour = 128u << 24 | (uint)rc << 16 | 255u << 8 | (uint)bc;
        context.TranslucentBatch.FlatQuad(pose, -0.5F, -0.25F, 0.5F, 0.75F, u0, v0, u1, v1, new ModelDrawState(context.Texture(ExperienceOrbLocation), state, colour) { NoOutline = true });
        pose.Pop();
    }

    public override void ExtractRenderState(ClientEntity entity, ExperienceOrbRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        // getBlockLightLevel: seven brighter than the block it is in.
        state.BlockLight = Math.Clamp(state.BlockLight + 7, 0, 15);
        state.Icon = GetIcon(entity.Get(EntityDataFields.ExperienceOrb.Value));
    }

    /// <summary><c>ExperienceOrb.getIcon</c>.</summary>
    private static int GetIcon(int value) => value switch {
        >= 2477 => 10,
        >= 1237 => 9,
        >= 617 => 8,
        >= 307 => 7,
        >= 149 => 6,
        >= 73 => 5,
        >= 37 => 4,
        >= 17 => 3,
        >= 7 => 2,
        >= 3 => 1,
        _ => 0
    };
}
