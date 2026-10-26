using Minecraft.Schemas;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>ElytraModel</c>.</summary>
public sealed class ElytraModel : EntityModel<HumanoidRenderState> {
    public static readonly MeshTransformer BabyTransformer = MeshTransformers.Scaling(0.5F);
    private readonly ModelPart _rightWing;
    private readonly ModelPart _leftWing;

    public ElytraModel(ModelPart root) : base(root) {
        _leftWing = root.GetChild("left_wing");
        _rightWing = root.GetChild("right_wing");
    }

    public static LayerDefinition CreateLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        CubeDeformation windDeformation = new(1.0F);
        root.AddOrReplaceChild("left_wing", CubeListBuilder.Create().TexOffs(22, 0).AddBox(-10.0F, 0.0F, 0.0F, 10.0F, 20.0F, 2.0F, windDeformation),
            PartPose.OffsetAndRotation(5.0F, 0.0F, 0.0F, (float)(Math.PI / 12), 0.0F, (float)(-Math.PI / 12)));
        root.AddOrReplaceChild("right_wing", CubeListBuilder.Create().TexOffs(22, 0).Mirror().AddBox(0.0F, 0.0F, 0.0F, 10.0F, 20.0F, 2.0F, windDeformation),
            PartPose.OffsetAndRotation(-5.0F, 0.0F, 0.0F, (float)(Math.PI / 12), 0.0F, (float)(Math.PI / 12)));
        return LayerDefinition.Create(mesh, 64, 32);
    }

    public override void SetupAnim(HumanoidRenderState state) {
        base.SetupAnim(state);
        _leftWing.Y = state.IsCrouching ? 3.0F : 0.0F;
        _leftWing.XRot = state.ElytraRotX;
        _leftWing.ZRot = state.ElytraRotZ;
        _leftWing.YRot = state.ElytraRotY;
        _rightWing.YRot = -_leftWing.YRot;
        _rightWing.Y = _leftWing.Y;
        _rightWing.XRot = _leftWing.XRot;
        _rightWing.ZRot = -_leftWing.ZRot;
    }
}

/// <summary><c>WingsLayer</c>.</summary>
public sealed class WingsLayer<S, M> : RenderLayer<S, M> where S : HumanoidRenderState, new() where M : EntityModel<S> {
    private readonly ElytraModel _elytraModel;
    private readonly ElytraModel _elytraBabyModel;
    private readonly EquipmentLayerRenderer _equipmentRenderer;

    public WingsLayer(LivingEntityRenderer<S, M> renderer, EquipmentLayerRenderer equipmentRenderer) : base(renderer) {
        _elytraModel = new ElytraModel(ElytraModel.CreateLayer().BakeRoot());
        _elytraBabyModel = new ElytraModel(ElytraModel.CreateLayer().Apply(ElytraModel.BabyTransformer).BakeRoot());
        _equipmentRenderer = equipmentRenderer;
    }

    public override void Submit(PoseStack pose, EntityRenderContext context, S state) {
        if (EquipmentLayerRenderer.EquippableAssetId(state.ChestEquipment) is not Identifier assetId) {
            return;
        }
        ElytraModel model = state.IsBaby ? _elytraBabyModel : _elytraModel;
        pose.Push();
        pose.Translate(0.0F, 0.0F, 0.125F);
        _equipmentRenderer.RenderLayers<HumanoidRenderState>(EquipmentClientInfo.LayerType.Wings, assetId, model, state, state.ChestEquipment, pose, context,
            GetPlayerElytraTexture(state));
        pose.Pop();
    }

    /// <summary><c>getPlayerElytraTexture</c>: the skin's elytra, else its cape while that is shown.</summary>
    private static string? GetPlayerElytraTexture(HumanoidRenderState state) =>
        state is AvatarRenderState player ? player.Skin.Elytra ?? (player.ShowCape ? player.Skin.Cape : null) : null;
}
