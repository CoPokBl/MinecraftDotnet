using ClientLib.Entities;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class TropicalFishRenderState : LivingEntityRenderState {
    public TropicalFish.Pattern Pattern = TropicalFish.Pattern.Flopper;
    public uint BaseColor = 0xFFFFFFFF;
    public uint PatternColor = 0xFFFFFFFF;
}

/// <summary>The tail swish both tropical fish models' <c>setupAnim</c>s share.</summary>
public abstract class TropicalFishModel(ModelPart root) : EntityModel<TropicalFishRenderState>(root) {
    private readonly ModelPart _tail = root.GetChild("tail");

    public override void SetupAnim(TropicalFishRenderState state) {
        base.SetupAnim(state);
        float amplitudeMultiplier = state.IsInWater ? 1.0F : 1.5F;
        _tail.YRot = -amplitudeMultiplier * 0.45F * Mth.Sin(0.6F * state.AgeInTicks);
    }
}

public sealed class TropicalFishRenderer : MobRenderer<TropicalFishRenderState, EntityModel<TropicalFishRenderState>> {
    private const string SmallTexture = "minecraft:textures/entity/fish/tropical_a.png";
    private const string LargeTexture = "minecraft:textures/entity/fish/tropical_b.png";
    private readonly EntityModel<TropicalFishRenderState> _smallModel, _largeModel;

    public TropicalFishRenderer(EntityRendererContext context)
        : base(new TropicalFishSmallModel(TropicalFishSmallModel.CreateBodyLayer(CubeDeformation.None).BakeRoot()), 0.15F) {
        _smallModel = Model;
        _largeModel = new TropicalFishLargeModel(TropicalFishLargeModel.CreateBodyLayer(CubeDeformation.None).BakeRoot());
        AddLayer(new TropicalFishPatternLayer(this));
    }

    public override string GetTextureLocation(TropicalFishRenderState state) =>
        TropicalFish.BaseOf(state.Pattern) == TropicalFish.Base.Small ? SmallTexture : LargeTexture;

    public override void ExtractRenderState(ClientEntity entity, TropicalFishRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        state.IsInWater = EntityWater.IsInWater(context.Level, entity);
        int packedVariant = entity.Get(EntityDataFields.TropicalFish.IdTypeVariant, TropicalFish.DefaultPackedVariant);
        state.Pattern = TropicalFish.GetPattern(packedVariant);
        state.BaseColor = TropicalFish.TextureDiffuseColor(TropicalFish.GetBaseColor(packedVariant));
        state.PatternColor = TropicalFish.TextureDiffuseColor(TropicalFish.GetPatternColor(packedVariant));
    }

    public override void Submit(TropicalFishRenderState state, PoseStack pose, EntityRenderContext context) {
        Model = TropicalFish.BaseOf(state.Pattern) == TropicalFish.Base.Small ? _smallModel : _largeModel;
        base.Submit(state, pose, context);
    }

    protected override uint GetModelTint(TropicalFishRenderState state) => state.BaseColor;

    protected override void SetupRotations(TropicalFishRenderState state, PoseStack pose, float bodyRot, float entityScale) {
        base.SetupRotations(state, pose, bodyRot, entityScale);
        float bodyZRot = 4.3F * Mth.Sin(0.6F * state.AgeInTicks);
        pose.RotateYDegrees(bodyZRot);
        if (!state.IsInWater) {
            pose.Translate(0.2F, 0.1F, 0.0F);
            pose.RotateZDegrees(90.0F);
        }
    }
}
