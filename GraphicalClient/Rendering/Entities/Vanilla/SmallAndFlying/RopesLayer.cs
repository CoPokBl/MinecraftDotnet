using ClientLib.Inventory;
using Minecraft.Schemas;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class RopesLayer : RenderLayer<HappyGhastRenderState, HappyGhastModel> {
    /// <summary><c>ItemTags.HARNESSES</c>. Item tags have no generated type, so the tag is named here.</summary>
    private static readonly Identifier HarnessesTag = "minecraft:harnesses";

    private readonly string _ropesTexture;
    private readonly HappyGhastModel _adultModel, _babyModel;

    public RopesLayer(LivingEntityRenderer<HappyGhastRenderState, HappyGhastModel> parent, string ropesTexture) : base(parent) {
        _ropesTexture = ropesTexture;
        _adultModel = new HappyGhastModel(HappyGhastModel.CreateBodyLayer(false, new CubeDeformation(0.2F)).BakeRoot());
        _babyModel = new HappyGhastModel(HappyGhastModel.CreateBodyLayer(true, new CubeDeformation(0.2F)).Apply(HappyGhastModel.BabyTransformer).BakeRoot());
    }

    public override void Submit(PoseStack pose, EntityRenderContext context, HappyGhastRenderState state) {
        if (state.IsLeashHolder && !state.BodyItem.IsAir() && context.Client.Inventory.Data.InTag(Stack.Of(state.BodyItem), HarnessesTag)) {
            HappyGhastModel model = state.IsBaby ? _babyModel : _adultModel;
            EntityTexture? texture = context.Textures.Get(_ropesTexture);
            if (texture == null) {
                return;
            }
            model.SetupAnim(state);
            model.RenderToBuffer(pose, context.Batch, new ModelDrawState(texture, 0xFFFFFFFF, state.SkyLight, state.BlockLight, 0));
        }
    }
}
