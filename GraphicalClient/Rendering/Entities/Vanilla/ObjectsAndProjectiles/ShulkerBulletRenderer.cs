using ClientLib.Entities;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>ShulkerBulletRenderState</c>.</summary>
public class ShulkerBulletRenderState : EntityRenderState {
    public float XRot;
    public float YRot;
}

/// <summary><c>ShulkerBulletRenderer</c>: the solid bullet, then a larger faint copy in <c>entityTranslucent</c>.</summary>
public sealed class ShulkerBulletRenderer : EntityRenderer<ShulkerBulletRenderState> {
    /// <summary><c>ShulkerBullet.shouldRenderAtSqrDistance</c>.</summary>
    public override bool? ShouldRenderAtSqrDistance(ClientEntity entity, double distanceSqr) => distanceSqr < 16384.0;

    private const string TextureLocation = "minecraft:textures/entity/shulker/spark.png";

    private readonly ShulkerBulletModel _model = new(ShulkerBulletModel.CreateBodyLayer().BakeRoot());

    public override void Submit(ShulkerBulletRenderState state, PoseStack pose, EntityRenderContext context) {
        pose.Push();
        float tc = state.AgeInTicks;
        pose.Translate(0.0F, 0.15F, 0.0F);
        pose.RotateYDegrees(Mth.Sin(tc * 0.1F) * 180.0F);
        pose.RotateXDegrees(Mth.Cos(tc * 0.1F) * 180.0F);
        pose.RotateZDegrees(Mth.Sin(tc * 0.15F) * 360.0F);
        pose.Scale(-0.5F, -0.5F, 0.5F);
        _model.SetupAnim(state);
        EntityTexture texture = context.Texture(TextureLocation);
        _model.RenderToBuffer(pose, context.Batch, new ModelDrawState(texture, state));
        pose.Scale(1.5F, 1.5F, 1.5F);
        // 654311423: white at an alpha of 0x26.
        _model.RenderToBuffer(pose, context.TranslucentBatch, new ModelDrawState(texture, state, 0x26FFFFFF));
        pose.Pop();
    }

    public override void ExtractRenderState(ClientEntity entity, ShulkerBulletRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        // getBlockLightLevel.
        state.BlockLight = 15;
        state.YRot = GetYRot(entity, partialTick);
        state.XRot = GetXRot(entity, partialTick);
    }
}

/// <summary><c>ShulkerBulletModel</c>.</summary>
public sealed class ShulkerBulletModel : EntityModel<ShulkerBulletRenderState> {
    private readonly ModelPart _main;

    public ShulkerBulletModel(ModelPart root) : base(root) {
        _main = root.GetChild("main");
    }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild(
            "main",
            CubeListBuilder.Create()
                .TexOffs(0, 0)
                .AddBox(-4.0F, -4.0F, -1.0F, 8.0F, 8.0F, 2.0F)
                .TexOffs(0, 10)
                .AddBox(-1.0F, -4.0F, -4.0F, 2.0F, 8.0F, 8.0F)
                .TexOffs(20, 0)
                .AddBox(-4.0F, -1.0F, -4.0F, 8.0F, 2.0F, 8.0F),
            PartPose.Zero);
        return LayerDefinition.Create(mesh, 64, 32);
    }

    public override void SetupAnim(ShulkerBulletRenderState state) {
        base.SetupAnim(state);
        _main.YRot = state.YRot * (float)(Math.PI / 180.0);
        _main.XRot = state.XRot * (float)(Math.PI / 180.0);
    }
}
