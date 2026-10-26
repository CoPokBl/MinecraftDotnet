using ClientLib.Entities;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>WindChargeRenderer</c>.</summary>
/// <param name="hiddenWhileClose">A player's wind charge, whose <c>WindCharge.shouldRenderAtSqrDistance</c> hides it at first; a breeze's does not.</param>
public sealed class WindChargeRenderer(bool hiddenWhileClose) : EntityRenderer<EntityRenderState> {
    private const string TextureLocation = "minecraft:textures/entity/projectiles/wind_charge.png";

    private readonly WindChargeModel _model = new(WindChargeModel.CreateBodyLayer().BakeRoot());

    public override bool? ShouldRenderAtSqrDistance(ClientEntity entity, double distanceSqr) => hiddenWhileClose
        ? ThrownItemRenderer.HiddenWhileCloseThenHurtingProjectile(entity, distanceSqr)
        : ThrownItemRenderer.HurtingProjectileShouldRenderAtSqrDistance(entity, distanceSqr);

    public override void Submit(EntityRenderState state, PoseStack pose, EntityRenderContext context) {
        _model.SetupAnim(state);
        System.Numerics.Vector2 offset = new(state.AgeInTicks * 0.03F % 1.0F, 0.0F);
        EntityTexture? tiled = TiledTextures.Get(context.Textures, TextureLocation, ScrollingSink.Tiles, ScrollingSink.Tiles);
        _model.RenderToBuffer(pose, new ScrollingSink(context.TranslucentBatch, offset, tiled), new ModelDrawState(context.Texture(TextureLocation), state) { NoOutline = true });
    }
}

/// <summary><c>WindChargeModel</c>.</summary>
public sealed class WindChargeModel : EntityModel<EntityRenderState> {
    private const int RotationSpeed = 16;

    private readonly ModelPart _bone;
    private readonly ModelPart _windCharge;
    private readonly ModelPart _wind;

    public WindChargeModel(ModelPart root) : base(root) {
        _bone = root.GetChild("bone");
        _wind = _bone.GetChild("wind");
        _windCharge = _bone.GetChild("wind_charge");
    }

    public override bool Translucent => true;

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition meshdefinition = new();
        PartDefinition partdefinition = meshdefinition.Root;
        PartDefinition bone = partdefinition.AddOrReplaceChild("bone", CubeListBuilder.Create(), PartPose.Offset(0.0F, 0.0F, 0.0F));
        bone.AddOrReplaceChild(
            "wind",
            CubeListBuilder.Create()
                .TexOffs(15, 20)
                .AddBox(-4.0F, -1.0F, -4.0F, 8.0F, 2.0F, 8.0F, new CubeDeformation(0.0F))
                .TexOffs(0, 9)
                .AddBox(-3.0F, -2.0F, -3.0F, 6.0F, 4.0F, 6.0F, new CubeDeformation(0.0F)),
            PartPose.OffsetAndRotation(0.0F, 0.0F, 0.0F, 0.0F, -0.7854F, 0.0F));
        bone.AddOrReplaceChild(
            "wind_charge",
            CubeListBuilder.Create().TexOffs(0, 0).AddBox(-2.0F, -2.0F, -2.0F, 4.0F, 4.0F, 4.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.0F, 0.0F, 0.0F));
        return LayerDefinition.Create(meshdefinition, 64, 32);
    }

    public override void SetupAnim(EntityRenderState state) {
        base.SetupAnim(state);
        _windCharge.YRot = -state.AgeInTicks * RotationSpeed * (float)(Math.PI / 180.0);
        _wind.YRot = state.AgeInTicks * RotationSpeed * (float)(Math.PI / 180.0);
    }
}
