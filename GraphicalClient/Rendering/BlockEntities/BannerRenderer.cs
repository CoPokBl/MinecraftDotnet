using System.Numerics;
using ClientLib.World.BlockEntities;
using GraphicalClient.Rendering.Entities;
using GraphicalClient.Rendering.Entities.Special;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Components.Types;
using Minecraft.Schemas;
using Mth = GraphicalClient.Rendering.Entities.Mth;

namespace GraphicalClient.Rendering.BlockEntities;

/// <summary><c>BannerModel</c>: the pole and the bar, which never move.</summary>
public sealed class BannerModel(ModelPart root) : EntityModel<EntityRenderState>(root) {
    public static LayerDefinition CreateBodyLayer(bool standing) {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        if (standing) {
            root.AddOrReplaceChild("pole", CubeListBuilder.Create().TexOffs(44, 0).AddBox(-1.0F, -42.0F, -1.0F, 2.0F, 42.0F, 2.0F), PartPose.Zero);
        }
        root.AddOrReplaceChild("bar", CubeListBuilder.Create().TexOffs(0, 42).AddBox(-10.0F, standing ? -44.0F : -20.5F, standing ? -1.0F : 9.5F, 20.0F, 2.0F, 2.0F),
            PartPose.Zero);
        return LayerDefinition.Create(mesh, 64, 64);
    }
}

/// <summary><c>BannerFlagModel</c>: the cloth, swaying with its phase.</summary>
public sealed class BannerFlagModel : EntityModel<EntityRenderState> {
    private readonly ModelPart _flag;

    public BannerFlagModel(ModelPart root) : base(root) {
        _flag = root.GetChild("flag");
    }

    public static LayerDefinition CreateFlagLayer(bool standing) {
        MeshDefinition mesh = new();
        mesh.Root.AddOrReplaceChild("flag", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-10.0F, 0.0F, -2.0F, 20.0F, 40.0F, 1.0F),
            PartPose.Offset(0.0F, standing ? -44.0F : -20.5F, standing ? 0.0F : 10.5F));
        return LayerDefinition.Create(mesh, 64, 64);
    }

    public void SetupAnim(float phase) {
        ResetPose();
        _flag.XRot = (-0.0125F + 0.01F * Mth.Cos(MathF.PI * 2 * phase)) * MathF.PI;
    }
}

public sealed class BannerRenderState : BlockEntityRenderState {
    public DyeColor BaseColor;
    public BannerPatternsComponent.Layer[] Patterns = [];
    public float Phase;
    public Matrix4x4 Transformation = Matrix4x4.Identity;
    public bool Wall;
}

/// <summary><c>BannerRenderer</c>.</summary>
public sealed class BannerRenderer : BlockEntityRenderer<BannerBlockEntity, BannerRenderState> {
    private static readonly Vector3 ModelScale = new(0.6666667F, -0.6666667F, -0.6666667F);
    private static readonly Vector3 ModelTranslation = new(0.5F, 0.0F, 0.5F);

    private readonly ISpriteGetter _sprites;
    private readonly BannerModel _standingModel = new(BannerModel.CreateBodyLayer(true).BakeRoot());
    private readonly BannerModel _wallModel = new(BannerModel.CreateBodyLayer(false).BakeRoot());
    private readonly BannerFlagModel _standingFlagModel = new(BannerFlagModel.CreateFlagLayer(true).BakeRoot());
    private readonly BannerFlagModel _wallFlagModel = new(BannerFlagModel.CreateFlagLayer(false).BakeRoot());

    public BannerRenderer(BlockEntityRendererContext context) : this(context.Sprites) { }

    public BannerRenderer(ISpriteGetter sprites) {
        _sprites = sprites;
    }

    public override void ExtractRenderState(BannerBlockEntity blockEntity, BannerRenderState state, float partialTick, EntityRenderContext render) {
        base.ExtractRenderState(blockEntity, state, partialTick, render);
        state.BaseColor = blockEntity.BaseColor;
        state.Patterns = blockEntity.Patterns;
        state.Wall = DyedBlocks.BannerColor(blockEntity.State)?.Wall ?? false;
        state.Transformation = state.Wall
            ? ModelTransformation(DirectionUtil.ToYRot(blockEntity.State is IHorizontalFacing facing ? facing.Facing : Minecraft.Schemas.Blocks.BlockEnums.Direction.North))
            : ModelTransformation(BlockEntityTransforms.SegmentToDegrees(blockEntity.State is IRotated rotated ? rotated.Rotation : 0));
        long gameTime = render.Level.GameTime;
        long phase = (blockEntity.X * 7 + blockEntity.Y * 9 + blockEntity.Z * 13 + gameTime) % 100L;
        state.Phase = ((phase < 0 ? phase + 100 : phase) + partialTick) / 100.0F;
    }

    public override void Submit(BannerRenderState state, PoseStack pose, EntityRenderContext render) {
        pose.Push();
        pose.MulPose(state.Transformation);
        SubmitBanner(pose, render.Batch, state.SkyLight, state.BlockLight, state.Wall, state.Phase, state.BaseColor, state.Patterns);
        pose.Pop();
    }

    /// <summary><c>submitSpecial</c> and <c>submitBanner</c>: the base and its flag, the flag patterned.</summary>
    public void SubmitBanner(PoseStack pose, IModelSink sink, float skyLight, float blockLight, bool wall, float phase, DyeColor baseColor,
        IReadOnlyList<BannerPatternsComponent.Layer> patterns) {
        BannerModel model = wall ? _wallModel : _standingModel;
        BannerFlagModel flagModel = wall ? _wallFlagModel : _standingFlagModel;
        model.RenderToBuffer(pose, sink, new ModelDrawState(_sprites.Get(Sheets.BannerBase), 0xFFFFFFFF, skyLight, blockLight, 0));
        flagModel.SetupAnim(phase);
        EntityTexture flag = BannerPatternTextures.Patterned(_sprites, Sheets.BannerBase, true, baseColor, patterns);
        flagModel.RenderToBuffer(pose, sink, new ModelDrawState(flag, 0xFFFFFFFF, skyLight, blockLight, 0));
    }

    public void GetExtents(Action<Vector3> output) {
        PoseStack pose = new();
        _standingModel.RootPart.GetExtentsForGui(pose, output);
        _standingFlagModel.SetupAnim(0.0F);
        _standingFlagModel.RootPart.GetExtentsForGui(pose, output);
    }

    private static Matrix4x4 ModelTransformation(float angle) =>
        BlockEntityTransforms.Transformation(ModelTranslation, BlockEntityTransforms.RotationYDegrees(-angle), ModelScale);
}
