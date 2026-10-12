namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>PlayerCapeModel</c>: the player model emptied but for a cape hung off the back of the body.</summary>
public sealed class PlayerCapeModel : PlayerModel {
    private readonly ModelPart _cape;

    public PlayerCapeModel(ModelPart root) : base(root, false) {
        _cape = Body.GetChild("cape");
    }

    public static LayerDefinition CreateCapeLayer() {
        MeshDefinition mesh = CreateMesh(CubeDeformation.None, false);
        PartDefinition root = mesh.Root.ClearRecursively();
        PartDefinition body = root.GetChild("body");
        body.AddOrReplaceChild("cape", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-5.0F, 0.0F, -1.0F, 10.0F, 16.0F, 1.0F, CubeDeformation.None, 1.0F, 0.5F),
            PartPose.OffsetAndRotation(0.0F, 0.0F, 2.0F, 0.0F, (float)Math.PI, 0.0F));
        return LayerDefinition.Create(mesh, 64, 64);
    }

    /// <summary>The cape's own model is opaque, <c>entitySolid</c>, unlike the player's.</summary>
    public override bool Translucent => false;

    public override void SetupAnim(AvatarRenderState state) {
        base.SetupAnim(state);
        _cape.RotateBy(ModelPartRotateBy.Quat.Identity
            .RotateY((float)-Math.PI)
            .RotateX((6.0F + state.CapeLean / 2.0F + state.CapeFlap) * (float)(Math.PI / 180.0))
            .RotateZ(state.CapeLean2 / 2.0F * (float)(Math.PI / 180.0))
            .RotateY((180.0F - state.CapeLean2 / 2.0F) * (float)(Math.PI / 180.0)));
    }
}

/// <summary><c>CapeLayer</c>: a skin's cape, left off under an elytra and pushed out over a chestplate.</summary>
public sealed class CapeLayer(LivingEntityRenderer<AvatarRenderState, PlayerModel> renderer, EquipmentLayerRenderer equipment)
    : RenderLayer<AvatarRenderState, PlayerModel>(renderer) {
    private readonly PlayerCapeModel _model = new(PlayerCapeModel.CreateCapeLayer().BakeRoot());

    private bool HasLayer(Minecraft.Schemas.Items.ItemStack itemStack, EquipmentClientInfo.LayerType layerType) =>
        EquipmentLayerRenderer.EquippableAssetId(itemStack) is { } assetId && equipment.HasLayers(assetId, layerType);

    public override void Submit(PoseStack pose, EntityRenderContext context, AvatarRenderState state) {
        if (state.IsInvisible || !state.ShowCape || state.Skin.Cape is not { } cape || HasLayer(state.ChestEquipment, EquipmentClientInfo.LayerType.Wings)) {
            return;
        }
        pose.Push();
        if (HasLayer(state.ChestEquipment, EquipmentClientInfo.LayerType.Humanoid)) {
            pose.Translate(0.0F, -0.053125F, 0.06875F);
        }
        _model.SetupAnim(state);
        _model.RenderToBuffer(pose, context.Batch, new ModelDrawState(context.Texture(cape), 0xFFFFFFFF, state.SkyLight, state.BlockLight, 0));
        pose.Pop();
    }
}
