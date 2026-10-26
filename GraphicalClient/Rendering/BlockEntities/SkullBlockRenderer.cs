using System.Numerics;
using ClientLib.World.BlockEntities;
using GraphicalClient.Rendering.Entities;
using GraphicalClient.Rendering.Entities.Special;
using GraphicalClient.Rendering.Entities.Vanilla;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Mth = GraphicalClient.Rendering.Entities.Mth;
using PlayerSkin = GraphicalClient.Rendering.Entities.Vanilla.PlayerSkin;

namespace GraphicalClient.Rendering.BlockEntities;

/// <summary><c>SkullBlock.Types</c>.</summary>
public enum SkullKind { Skeleton, WitherSkeleton, Player, Zombie, Creeper, Piglin, Dragon }

/// <summary><c>DragonHeadModel</c>.</summary>
public sealed class DragonHeadModel : SkullModelBase {
    private readonly ModelPart _head, _jaw;

    public DragonHeadModel(ModelPart root) : base(root) {
        _head = root.GetChild("head");
        _jaw = _head.GetChild("jaw");
    }

    public static LayerDefinition CreateHeadLayer() {
        MeshDefinition mesh = new();
        PartDefinition head = mesh.Root.AddOrReplaceChild("head", CubeListBuilder.Create()
                .AddBox("upper_lip", -6.0F, -1.0F, -24.0F, 12, 5, 16, 176, 44)
                .AddBox("upper_head", -8.0F, -8.0F, -10.0F, 16, 16, 16, 112, 30)
                .Mirror()
                .AddBox("scale", -5.0F, -12.0F, -4.0F, 2, 4, 6, 0, 0)
                .AddBox("nostril", -5.0F, -3.0F, -22.0F, 2, 2, 4, 112, 0)
                .Mirror(false)
                .AddBox("scale", 3.0F, -12.0F, -4.0F, 2, 4, 6, 0, 0)
                .AddBox("nostril", 3.0F, -3.0F, -22.0F, 2, 2, 4, 112, 0),
            PartPose.Offset(0.0F, -7.986666F, 0.0F).Scaled(0.75F));
        head.AddOrReplaceChild("jaw", CubeListBuilder.Create().TexOffs(176, 65).AddBox("jaw", -6.0F, 0.0F, -16.0F, 12.0F, 4.0F, 16.0F), PartPose.Offset(0.0F, 4.0F, -8.0F));
        return LayerDefinition.Create(mesh, 256, 256);
    }

    public override void SetupAnim(State state) {
        ResetPose();
        _jaw.XRot = (float)(Math.Sin(state.AnimationPos * MathF.PI * 0.2F) + 1.0) * 0.2F;
        _head.YRot = state.YRot * (MathF.PI / 180.0F);
        _head.XRot = state.XRot * (MathF.PI / 180.0F);
    }
}

/// <summary><c>PiglinHeadModel</c>.</summary>
public sealed class PiglinHeadModel : SkullModelBase {
    private readonly ModelPart _head, _leftEar, _rightEar;

    public PiglinHeadModel(ModelPart root) : base(root) {
        _head = root.GetChild("head");
        _leftEar = _head.GetChild("left_ear");
        _rightEar = _head.GetChild("right_ear");
    }

    public static MeshDefinition CreateHeadModel() {
        MeshDefinition mesh = new();
        PiglinModel.AddHead(CubeDeformation.None, mesh);
        return mesh;
    }

    public override void SetupAnim(State state) {
        ResetPose();
        _head.YRot = state.YRot * (MathF.PI / 180.0F);
        _head.XRot = state.XRot * (MathF.PI / 180.0F);
        _leftEar.ZRot = (float)(-(Math.Cos(state.AnimationPos * MathF.PI * 0.2F * 1.2F) + 2.5)) * 0.2F;
        _rightEar.ZRot = (float)(Math.Cos(state.AnimationPos * MathF.PI * 0.2F) + 2.5) * 0.2F;
    }
}

public sealed class SkullBlockRenderState : BlockEntityRenderState {
    public float AnimationProgress;
    public Matrix4x4 Transformation = Matrix4x4.Identity;
    public SkullKind SkullType = SkullKind.Zombie;
    public SpriteId Texture;
    public bool Translucent;
}

/// <summary><c>SkullBlockRenderer</c>: mob heads, and player heads in the default skin their profile picks.</summary>
public sealed class SkullBlockRenderer : BlockEntityRenderer<SkullBlockEntity, SkullBlockRenderState> {
    private readonly ISpriteGetter _sprites;
    private readonly Dictionary<SkullKind, SkullModelBase> _models = new();

    public SkullBlockRenderer(BlockEntityRendererContext context) : this(context.Sprites) { }

    public SkullBlockRenderer(ISpriteGetter sprites) {
        _sprites = sprites;
    }

    /// <summary><c>SKIN_BY_TYPE</c>.</summary>
    public static SpriteId SkinByType(SkullKind kind) => Sheets.TextureSprite(kind switch {
        SkullKind.Skeleton => "minecraft:textures/entity/skeleton/skeleton.png",
        SkullKind.WitherSkeleton => "minecraft:textures/entity/skeleton/wither_skeleton.png",
        SkullKind.Zombie => "minecraft:textures/entity/zombie/zombie.png",
        SkullKind.Creeper => "minecraft:textures/entity/creeper/creeper.png",
        SkullKind.Dragon => "minecraft:textures/entity/enderdragon/dragon.png",
        SkullKind.Piglin => "minecraft:textures/entity/piglin/piglin.png",
        _ => DefaultPlayerSkin.GetDefaultSkin().Body
    });

    /// <summary><c>createModel</c>.</summary>
    public static SkullModelBase CreateModel(SkullKind kind) => kind switch {
        SkullKind.Player or SkullKind.Zombie => new SkullModel(CreateHumanoidHeadLayer().BakeRoot()),
        SkullKind.Dragon => new DragonHeadModel(DragonHeadModel.CreateHeadLayer().BakeRoot()),
        SkullKind.Piglin => new PiglinHeadModel(LayerDefinition.Create(PiglinHeadModel.CreateHeadModel(), 64, 64).BakeRoot()),
        _ => new SkullModel(CreateMobHeadLayer().BakeRoot())
    };

    private static MeshDefinition CreateHeadModel() {
        MeshDefinition mesh = new();
        mesh.Root.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-4.0F, -8.0F, -4.0F, 8.0F, 8.0F, 8.0F), PartPose.Zero);
        return mesh;
    }

    /// <summary><c>SkullModel.createHumanoidHeadLayer</c>.</summary>
    public static LayerDefinition CreateHumanoidHeadLayer() {
        MeshDefinition mesh = CreateHeadModel();
        mesh.Root.GetChild("head").AddOrReplaceChild("hat", CubeListBuilder.Create().TexOffs(32, 0).AddBox(-4.0F, -8.0F, -4.0F, 8.0F, 8.0F, 8.0F, new CubeDeformation(0.25F)),
            PartPose.Zero);
        return LayerDefinition.Create(mesh, 64, 64);
    }

    /// <summary><c>SkullModel.createMobHeadLayer</c>.</summary>
    public static LayerDefinition CreateMobHeadLayer() => LayerDefinition.Create(CreateHeadModel(), 64, 32);

    /// <summary><c>AbstractSkullBlock.getType</c>, and whether the block hangs on a wall.</summary>
    public static (SkullKind Kind, bool Wall)? KindOf(IBlock state) {
        bool Is(IBlock block) => block.Identifier.Equals(state.Identifier);
        if (Is(Block.SkeletonSkull) || Is(Block.SkeletonWallSkull)) return (SkullKind.Skeleton, Is(Block.SkeletonWallSkull));
        if (Is(Block.WitherSkeletonSkull) || Is(Block.WitherSkeletonWallSkull)) return (SkullKind.WitherSkeleton, Is(Block.WitherSkeletonWallSkull));
        if (Is(Block.ZombieHead) || Is(Block.ZombieWallHead)) return (SkullKind.Zombie, Is(Block.ZombieWallHead));
        if (Is(Block.CreeperHead) || Is(Block.CreeperWallHead)) return (SkullKind.Creeper, Is(Block.CreeperWallHead));
        if (Is(Block.DragonHead) || Is(Block.DragonWallHead)) return (SkullKind.Dragon, Is(Block.DragonWallHead));
        if (Is(Block.PiglinHead) || Is(Block.PiglinWallHead)) return (SkullKind.Piglin, Is(Block.PiglinWallHead));
        if (Is(Block.PlayerHead) || Is(Block.PlayerWallHead)) return (SkullKind.Player, Is(Block.PlayerWallHead));
        return null;
    }

    public SkullModelBase Model(SkullKind kind) {
        if (!_models.TryGetValue(kind, out SkullModelBase? model)) {
            model = CreateModel(kind);
            _models[kind] = model;
        }
        return model;
    }

    public override void ExtractRenderState(SkullBlockEntity blockEntity, SkullBlockRenderState state, float partialTick, EntityRenderContext render) {
        base.ExtractRenderState(blockEntity, state, partialTick, render);
        state.AnimationProgress = blockEntity.GetAnimation(partialTick);
        (SkullKind kind, bool wall) = KindOf(blockEntity.State) ?? (SkullKind.Skeleton, false);
        state.Transformation = wall
            ? CreateWallTransformation(blockEntity.State is IHorizontalFacing facing ? facing.Facing : Direction.North)
            : CreateGroundTransformation(blockEntity.State is IRotated rotated ? rotated.Rotation : 0);
        state.SkullType = kind;
        state.Texture = SkinByType(kind);
        if (kind == SkullKind.Player && ProfileSkin(blockEntity.Profile) is { } skin) {
            state.Texture = skin;
            state.Translucent = true;
        }
    }

    /// <summary><c>resolveSkullRenderType</c>'s player skin, <c>PlayerSkinRenderCache.getOrDefault</c>'s for the profile.</summary>
    public static SpriteId? ProfileSkin(ProfileComponent.Data? profile) =>
        profile == null ? null : Sheets.TextureSprite(Assets.Skins.SkinManager.GetOrDefault(profile).Body);

    public override void Submit(SkullBlockRenderState state, PoseStack pose, EntityRenderContext render) {
        pose.Push();
        pose.MulPose(state.Transformation);
        SubmitSkull(state.AnimationProgress, pose, state.Translucent ? render.TranslucentBatch : render.Batch, state.SkyLight, state.BlockLight, Model(state.SkullType),
            _sprites.Get(state.Texture));
        pose.Pop();
    }

    /// <summary><c>submitSkull</c>.</summary>
    public static void SubmitSkull(float animationValue, PoseStack pose, IModelSink sink, float skyLight, float blockLight, SkullModelBase model, EntityTexture texture) {
        SkullModelBase.State modelState = new() { AnimationPos = animationValue };
        model.SetupAnim(modelState);
        model.RenderToBuffer(pose, sink, new ModelDrawState(texture, 0xFFFFFFFF, skyLight, blockLight, 0));
    }

    private static Matrix4x4 CreateWallTransformation(Direction wallDirection) {
        (int stepX, int stepZ) = DirectionUtil.Step(wallDirection);
        return BlockEntityTransforms.Transformation(new Vector3(0.5F - stepX * 0.25F, 0.25F, 0.5F - stepZ * 0.25F),
            BlockEntityTransforms.RotationYDegrees(-DirectionUtil.ToYRot(DirectionUtil.Opposite(wallDirection))), new Vector3(-1.0F, -1.0F, 1.0F));
    }

    private static Matrix4x4 CreateGroundTransformation(int segment) =>
        BlockEntityTransforms.Transformation(new Vector3(0.5F, 0.0F, 0.5F), BlockEntityTransforms.RotationYDegrees(-BlockEntityTransforms.SegmentToDegrees(segment)),
            new Vector3(-1.0F, -1.0F, 1.0F));
}
