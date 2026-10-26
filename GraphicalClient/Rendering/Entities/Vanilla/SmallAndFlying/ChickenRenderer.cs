using ClientLib.Entities;
using ClientLib.World;
using Minecraft.Data.ChickenVariant;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class ChickenRenderState : LivingEntityRenderState {
    public float Flap, FlapSpeed;
    public IChickenVariant? Variant;
}

public sealed class ChickenRenderer : MobRenderer<ChickenRenderState, ChickenModel> {
    private const string MissingTexture = "minecraft:missingno";

    private readonly Dictionary<ChickenVariantModel, (ChickenModel Adult, ChickenModel Baby)> _models;

    public ChickenRenderer(EntityRendererContext context)
        : base(new AdultChickenModel(AdultChickenModel.CreateBodyLayer().BakeRoot()), 0.3F) {
        _models = BakeModels();
    }

    private static Dictionary<ChickenVariantModel, (ChickenModel Adult, ChickenModel Baby)> BakeModels() => new() {
        [ChickenVariantModel.Normal] = (new AdultChickenModel(AdultChickenModel.CreateBodyLayer().BakeRoot()), new BabyChickenModel(BabyChickenModel.CreateBodyLayer().BakeRoot())),
        [ChickenVariantModel.Cold] = (new ColdChickenModel(ColdChickenModel.CreateBodyLayer().BakeRoot()), new BabyChickenModel(BabyChickenModel.CreateBodyLayer().BakeRoot()))
    };

    /// <summary><c>Chicken.flap</c>, <c>flapSpeed</c> and the rest of what <c>aiStep</c> moves the wings with.</summary>
    private sealed class Wings {
        public float Flap, FlapSpeed, OFlapSpeed, OFlap;
        public float Flapping = 1.0F;
    }

    /// <summary><c>Chicken.aiStep</c>'s wing bookkeeping.</summary>
    public override void Tick(ClientEntity entity, ClientLevel level) {
        Wings f = (Wings)(entity.RendererData ??= new Wings());
        f.OFlap = f.Flap;
        f.OFlapSpeed = f.FlapSpeed;
        f.FlapSpeed = f.FlapSpeed + (entity.OnGround ? -1.0F : 4.0F) * 0.3F;
        f.FlapSpeed = Mth.Clamp(f.FlapSpeed, 0.0F, 1.0F);
        if (!entity.OnGround && f.Flapping < 1.0F) {
            f.Flapping = 1.0F;
        }
        f.Flapping *= 0.9F;
        f.Flap = f.Flap + f.Flapping * 2.0F;
    }

    public override void Submit(ChickenRenderState state, PoseStack pose, EntityRenderContext context) {
        if (state.Variant != null) {
            (ChickenModel adult, ChickenModel baby) = _models[state.Variant.Model];
            Model = state.IsBaby ? baby : adult;
            base.Submit(state, pose, context);
        }
    }

    public override string GetTextureLocation(ChickenRenderState state) =>
        state.Variant == null
            ? MissingTexture
            : SyncedVariants.TexturePath(state.IsBaby ? state.Variant.BabyAssetId : state.Variant.AssetId);

    public override void ExtractRenderState(ClientEntity entity, ChickenRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        if (entity.RendererData is Wings f) {
            state.Flap = Mth.Lerp(partialTick, f.OFlap, f.Flap);
            state.FlapSpeed = Mth.Lerp(partialTick, f.OFlapSpeed, f.FlapSpeed);
        }
        state.Variant = SyncedVariants.Resolve(context.Client.Registry.ChickenVariants, entity, EntityDataFields.Chicken.Variant, ChickenVariant.Temperate.Identifier);
    }
}
