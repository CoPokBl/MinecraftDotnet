using ClientLib.Entities;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>Salmon.Variant</c>, by its synced id.</summary>
public enum SalmonVariant {
    Small = 0,
    Medium = 1,
    Large = 2
}

public class SalmonRenderState : LivingEntityRenderState {
    public SalmonVariant Variant = SalmonVariant.Medium;
}

public sealed class SalmonRenderer : MobRenderer<SalmonRenderState, SalmonModel> {
    private readonly SalmonModel _smallSalmonModel, _mediumSalmonModel, _largeSalmonModel;

    public SalmonRenderer(EntityRendererContext context) : base(new SalmonModel(SalmonModel.CreateBodyLayer().BakeRoot()), 0.4F) {
        _smallSalmonModel = new SalmonModel(SalmonModel.CreateBodyLayer().Apply(SalmonModel.SmallTransformer).BakeRoot());
        _mediumSalmonModel = new SalmonModel(SalmonModel.CreateBodyLayer().BakeRoot());
        _largeSalmonModel = new SalmonModel(SalmonModel.CreateBodyLayer().Apply(SalmonModel.LargeTransformer).BakeRoot());
    }

    public override void ExtractRenderState(ClientEntity entity, SalmonRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        state.IsInWater = EntityWater.IsInWater(context.Level, entity);
        // Salmon.Variant.BY_ID clamps an id out of range; the default is MEDIUM.
        state.Variant = (SalmonVariant)Math.Clamp(entity.Get(EntityDataFields.Salmon.Type, (int)SalmonVariant.Medium), 0, 2);
    }

    public override string GetTextureLocation(SalmonRenderState state) => "minecraft:textures/entity/fish/salmon.png";

    protected override void SetupRotations(SalmonRenderState state, PoseStack pose, float bodyRot, float entityScale) {
        base.SetupRotations(state, pose, bodyRot, entityScale);
        float amplitudeMultiplier = 1.0F;
        float angleMultiplier = 1.0F;
        if (!state.IsInWater) {
            amplitudeMultiplier = 1.3F;
            angleMultiplier = 1.7F;
        }
        float bodyZRot = amplitudeMultiplier * 4.3F * Mth.Sin(angleMultiplier * 0.6F * state.AgeInTicks);
        pose.RotateYDegrees(bodyZRot);
        if (!state.IsInWater) {
            pose.Translate(0.2F, 0.1F, 0.0F);
            pose.RotateZDegrees(90.0F);
        }
    }

    public override void Submit(SalmonRenderState state, PoseStack pose, EntityRenderContext context) {
        Model = state.Variant switch {
            SalmonVariant.Small => _smallSalmonModel,
            SalmonVariant.Large => _largeSalmonModel,
            _ => _mediumSalmonModel
        };
        base.Submit(state, pose, context);
    }
}
