using System.Numerics;
using ClientLib.World.BlockEntities;
using GraphicalClient.Rendering.Entities;
using GraphicalClient.Rendering.Entities.Special;
using GraphicalClient.Rendering.Entities.Vanilla;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Mth = GraphicalClient.Rendering.Entities.Mth;

namespace GraphicalClient.Rendering.BlockEntities;

/// <summary><c>ShulkerBoxRenderer.ShulkerBoxModel</c>.</summary>
public sealed class ShulkerBoxModel : EntityModel<EntityRenderState> {
    private readonly ModelPart _lid;

    public ShulkerBoxModel(ModelPart root) : base(root) {
        _lid = root.GetChild("lid");
    }

    public void SetupAnim(float progress) {
        ResetPose();
        _lid.SetPos(0.0F, 24.0F - progress * 0.5F * 16.0F, 0.0F);
        _lid.YRot = 270.0F * progress * (MathF.PI / 180.0F);
    }
}

public sealed class ShulkerBoxRenderState : BlockEntityRenderState {
    public Cardinal Direction = Cardinal.North;
    public DyeColor? Color;
    public float Progress;
}

/// <summary><c>ShulkerBoxRenderer</c>.</summary>
public sealed class ShulkerBoxRenderer(ISpriteGetter sprites) : BlockEntityRenderer<ShulkerBoxBlockEntity, ShulkerBoxRenderState> {
    private readonly ShulkerBoxModel _model = new(ShulkerModel.CreateBoxLayer().BakeRoot());

    public ShulkerBoxRenderer(BlockEntityRendererContext context) : this(context.Sprites) { }

    public override void ExtractRenderState(ShulkerBoxBlockEntity blockEntity, ShulkerBoxRenderState state, float partialTick, EntityRenderContext render) {
        base.ExtractRenderState(blockEntity, state, partialTick, render);
        state.Direction = blockEntity.State is IDirectional directional ? directional.Facing : Cardinal.Up;
        state.Color = blockEntity.Color;
        state.Progress = blockEntity.GetProgress(partialTick);
    }

    public override void Submit(ShulkerBoxRenderState state, PoseStack pose, EntityRenderContext render) {
        SpriteId sprite = state.Color is { } color ? Sheets.GetShulkerBoxSprite(color) : Sheets.DefaultShulkerTextureLocation;
        pose.Push();
        pose.MulPose(ModelTransform(state.Direction));
        Submit(pose, render.Batch, state.SkyLight, state.BlockLight, state.Progress, sprite);
        pose.Pop();
    }

    public void Submit(PoseStack pose, IModelSink sink, float skyLight, float blockLight, float progress, SpriteId sprite) {
        _model.SetupAnim(progress);
        _model.RenderToBuffer(pose, sink, new ModelDrawState(sprites.Get(sprite), 0xFFFFFFFF, skyLight, blockLight, 0));
    }

    public void GetExtents(float progress, Action<Vector3> output) {
        _model.SetupAnim(progress);
        _model.RootPart.GetExtentsForGui(new PoseStack(), output);
    }

    /// <summary>
    /// <c>createModelTransform</c>: <c>translation(0.5, 0.5, 0.5).scale(0.9995).rotate(direction.getRotation())
    /// .scale(1, -1, -1).translate(0, -1, 0)</c>.
    /// </summary>
    public static Matrix4x4 ModelTransform(Cardinal direction) =>
        Matrix4x4.CreateTranslation(0.0F, -1.0F, 0.0F) * Matrix4x4.CreateScale(1.0F, -1.0F, -1.0F) * Rotation(direction)
        * Matrix4x4.CreateScale(0.9995F) * Matrix4x4.CreateTranslation(0.5F, 0.5F, 0.5F);

    /// <summary><c>Direction.getRotation</c>: up is the identity, every other face turns up onto it.</summary>
    public static Matrix4x4 Rotation(Cardinal direction) => direction switch {
        Cardinal.Down => Matrix4x4.CreateRotationX(MathF.PI),
        Cardinal.North => RotationXYZ(MathF.PI / 2, 0.0F, MathF.PI),
        Cardinal.South => Matrix4x4.CreateRotationX(MathF.PI / 2),
        Cardinal.West => RotationXYZ(MathF.PI / 2, 0.0F, MathF.PI / 2),
        Cardinal.East => RotationXYZ(MathF.PI / 2, 0.0F, -MathF.PI / 2),
        _ => Matrix4x4.Identity
    };

    private static Matrix4x4 RotationXYZ(float x, float y, float z) =>
        Matrix4x4.CreateRotationZ(z) * Matrix4x4.CreateRotationY(y) * Matrix4x4.CreateRotationX(x);
}

/// <summary><c>BellModel</c>.</summary>
public sealed class BellModel : EntityModel<EntityRenderState> {
    private readonly ModelPart _bellBody;

    public BellModel(ModelPart root) : base(root) {
        _bellBody = root.GetChild("bell_body");
    }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition bellBody = root.AddOrReplaceChild("bell_body", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-3.0F, -6.0F, -3.0F, 6.0F, 7.0F, 6.0F),
            PartPose.Offset(8.0F, 12.0F, 8.0F));
        bellBody.AddOrReplaceChild("bell_base", CubeListBuilder.Create().TexOffs(0, 13).AddBox(4.0F, 4.0F, 4.0F, 8.0F, 2.0F, 8.0F), PartPose.Offset(-8.0F, -12.0F, -8.0F));
        return LayerDefinition.Create(mesh, 32, 32);
    }

    public void SetupAnim(float ticks, Cardinal? shakeDirection) {
        ResetPose();
        float xRot = 0.0F, zRot = 0.0F;
        if (shakeDirection is { } direction) {
            float baseRot = Mth.Sin(ticks / MathF.PI) / (4.0F + ticks / 3.0F);
            switch (direction) {
                case Cardinal.North:
                    xRot = -baseRot;
                    break;
                case Cardinal.South:
                    xRot = baseRot;
                    break;
                case Cardinal.East:
                    zRot = -baseRot;
                    break;
                case Cardinal.West:
                    zRot = baseRot;
                    break;
            }
        }
        _bellBody.XRot = xRot;
        _bellBody.ZRot = zRot;
    }
}

public sealed class BellRenderState : BlockEntityRenderState {
    public Cardinal? ShakeDirection;
    public float Ticks;
}

/// <summary><c>BellRenderer</c>.</summary>
public sealed class BellRenderer(BlockEntityRendererContext context) : BlockEntityRenderer<BellBlockEntity, BellRenderState> {
    public static readonly SpriteId BellTexture = Sheets.BlockEntitySprite("bell/bell_body");

    private readonly BellModel _model = new(BellModel.CreateBodyLayer().BakeRoot());

    public override void ExtractRenderState(BellBlockEntity blockEntity, BellRenderState state, float partialTick, EntityRenderContext render) {
        base.ExtractRenderState(blockEntity, state, partialTick, render);
        state.Ticks = blockEntity.Ticks + partialTick;
        state.ShakeDirection = blockEntity.Shaking ? blockEntity.ClickDirection : null;
    }

    public override void Submit(BellRenderState state, PoseStack pose, EntityRenderContext render) {
        _model.SetupAnim(state.Ticks, state.ShakeDirection);
        _model.RenderToBuffer(pose, render.Batch, Draw(context.Sprites.Get(BellTexture), state));
    }
}

public sealed class ConduitRenderState : BlockEntityRenderState {
    public bool IsActive, IsHunting;
    public float ActiveRotation, AnimTime;
    public int AnimationPhase;
}

/// <summary><c>ConduitRenderer</c>: the shell at rest; the cage, the wind and the eye once it is active.</summary>
public sealed class ConduitRenderer(BlockEntityRendererContext context) : BlockEntityRenderer<ConduitBlockEntity, ConduitRenderState> {
    public static readonly SpriteId ShellTexture = Sheets.BlockEntitySprite("conduit/base");
    public static readonly SpriteId ActiveShellTexture = Sheets.BlockEntitySprite("conduit/cage");
    public static readonly SpriteId WindTexture = Sheets.BlockEntitySprite("conduit/wind");
    public static readonly SpriteId VerticalWindTexture = Sheets.BlockEntitySprite("conduit/wind_vertical");
    public static readonly SpriteId OpenEyeTexture = Sheets.BlockEntitySprite("conduit/open_eye");
    public static readonly SpriteId ClosedEyeTexture = Sheets.BlockEntitySprite("conduit/closed_eye");

    private readonly ModelPart _eye = CreateEyeLayer().BakeRoot();
    private readonly ModelPart _wind = CreateWindLayer().BakeRoot();
    private readonly ModelPart _shell = CreateShellLayer().BakeRoot();
    private readonly ModelPart _cage = CreateCageLayer().BakeRoot();

    public static LayerDefinition CreateEyeLayer() {
        MeshDefinition mesh = new();
        mesh.Root.AddOrReplaceChild("eye", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-4.0F, -4.0F, 0.0F, 8.0F, 8.0F, 0.0F, new CubeDeformation(0.01F)), PartPose.Zero);
        return LayerDefinition.Create(mesh, 16, 16);
    }

    public static LayerDefinition CreateWindLayer() {
        MeshDefinition mesh = new();
        mesh.Root.AddOrReplaceChild("wind", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-8.0F, -8.0F, -8.0F, 16.0F, 16.0F, 16.0F), PartPose.Zero);
        return LayerDefinition.Create(mesh, 64, 32);
    }

    public static LayerDefinition CreateShellLayer() {
        MeshDefinition mesh = new();
        mesh.Root.AddOrReplaceChild("shell", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-3.0F, -3.0F, -3.0F, 6.0F, 6.0F, 6.0F), PartPose.Zero);
        return LayerDefinition.Create(mesh, 32, 16);
    }

    public static LayerDefinition CreateCageLayer() {
        MeshDefinition mesh = new();
        mesh.Root.AddOrReplaceChild("shell", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-4.0F, -4.0F, -4.0F, 8.0F, 8.0F, 8.0F), PartPose.Zero);
        return LayerDefinition.Create(mesh, 32, 16);
    }

    public override void ExtractRenderState(ConduitBlockEntity blockEntity, ConduitRenderState state, float partialTick, EntityRenderContext render) {
        base.ExtractRenderState(blockEntity, state, partialTick, render);
        state.IsActive = blockEntity.IsActive;
        state.ActiveRotation = blockEntity.GetActiveRotation(blockEntity.IsActive ? partialTick : 0.0F);
        state.AnimTime = blockEntity.TickCount + partialTick;
        state.AnimationPhase = blockEntity.TickCount / 66 % 3;
        state.IsHunting = blockEntity.IsHunting;
    }

    public override void Submit(ConduitRenderState state, PoseStack pose, EntityRenderContext render) {
        ISpriteGetter sprites = context.Sprites;
        if (!state.IsActive) {
            pose.Push();
            pose.Translate(0.5F, 0.5F, 0.5F);
            pose.RotateY(state.ActiveRotation * (MathF.PI / 180.0F));
            _shell.Render(pose, render.Batch, Draw(sprites.Get(ShellTexture), state));
            pose.Pop();
            return;
        }
        float rotation = state.ActiveRotation * (180.0F / MathF.PI);
        float hh = Mth.Sin(state.AnimTime * 0.1F) / 2.0F + 0.5F;
        hh = hh * hh + hh;
        pose.Push();
        pose.Translate(0.5F, 0.3F + hh * 0.2F, 0.5F);
        pose.Rotate(Matrix4x4.CreateFromAxisAngle(Vector3.Normalize(new Vector3(0.5F, 1.0F, 0.5F)), rotation * (MathF.PI / 180.0F)));
        _cage.Render(pose, render.Batch, Draw(sprites.Get(ActiveShellTexture), state));
        pose.Pop();

        pose.Push();
        pose.Translate(0.5F, 0.5F, 0.5F);
        if (state.AnimationPhase == 1) {
            pose.RotateX(MathF.PI / 2);
        }
        else if (state.AnimationPhase == 2) {
            pose.RotateZ(MathF.PI / 2);
        }
        EntityTexture wind = sprites.Get(state.AnimationPhase == 1 ? VerticalWindTexture : WindTexture);
        _wind.Render(pose, render.Batch, Draw(wind, state));
        pose.Pop();

        pose.Push();
        pose.Translate(0.5F, 0.5F, 0.5F);
        pose.Scale(0.875F, 0.875F, 0.875F);
        pose.RotateXYZ(MathF.PI, 0.0F, MathF.PI);
        _wind.Render(pose, render.Batch, Draw(wind, state));
        pose.Pop();

        pose.Push();
        pose.Translate(0.5F, 0.3F + hh * 0.2F, 0.5F);
        pose.Scale(0.5F, 0.5F, 0.5F);
        CameraOrientation.Apply(pose, render.Camera);
        pose.RotateZ(MathF.PI);
        pose.RotateY(MathF.PI);
        pose.Scale(1.3333334F, 1.3333334F, 1.3333334F);
        _eye.Render(pose, render.Batch, Draw(sprites.Get(state.IsHunting ? OpenEyeTexture : ClosedEyeTexture), state));
        pose.Pop();
    }

    /// <summary><c>ConduitSpecialRenderer</c>'s model: the shell alone.</summary>
    public static ModelPart BakeShell() => CreateShellLayer().BakeRoot();
}
