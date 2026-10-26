using System.Numerics;
using ClientLib.World.BlockEntities;
using GraphicalClient.Rendering.Entities;
using GraphicalClient.Rendering.Entities.Special;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Blocks.BlockEnums;

namespace GraphicalClient.Rendering.BlockEntities;

/// <summary><c>ChestModel</c>, a <c>Model&lt;Float&gt;</c> posed by how far the lid is open.</summary>
public sealed class ChestModel : EntityModel<EntityRenderState> {
    private readonly ModelPart _lid, _lock;

    public ChestModel(ModelPart root) : base(root) {
        _lid = root.GetChild("lid");
        _lock = root.GetChild("lock");
    }

    public static LayerDefinition CreateSingleBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("bottom", CubeListBuilder.Create().TexOffs(0, 19).AddBox(1.0F, 0.0F, 1.0F, 14.0F, 10.0F, 14.0F), PartPose.Zero);
        root.AddOrReplaceChild("lid", CubeListBuilder.Create().TexOffs(0, 0).AddBox(1.0F, 0.0F, 0.0F, 14.0F, 5.0F, 14.0F), PartPose.Offset(0.0F, 9.0F, 1.0F));
        root.AddOrReplaceChild("lock", CubeListBuilder.Create().TexOffs(0, 0).AddBox(7.0F, -2.0F, 14.0F, 2.0F, 4.0F, 1.0F), PartPose.Offset(0.0F, 9.0F, 1.0F));
        return LayerDefinition.Create(mesh, 64, 64);
    }

    public static LayerDefinition CreateDoubleBodyRightLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        const CubeFaces visibleFaces = CubeFaces.All & ~CubeFaces.East;
        root.AddOrReplaceChild("bottom", CubeListBuilder.Create().TexOffs(0, 19).AddBox(1.0F, 0.0F, 1.0F, 15.0F, 10.0F, 14.0F, visibleFaces), PartPose.Zero);
        root.AddOrReplaceChild("lid", CubeListBuilder.Create().TexOffs(0, 0).AddBox(1.0F, 0.0F, 0.0F, 15.0F, 5.0F, 14.0F, visibleFaces), PartPose.Offset(0.0F, 9.0F, 1.0F));
        root.AddOrReplaceChild("lock", CubeListBuilder.Create().TexOffs(0, 0).AddBox(15.0F, -2.0F, 14.0F, 1.0F, 4.0F, 1.0F, visibleFaces), PartPose.Offset(0.0F, 9.0F, 1.0F));
        return LayerDefinition.Create(mesh, 64, 64);
    }

    public static LayerDefinition CreateDoubleBodyLeftLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        const CubeFaces visibleFaces = CubeFaces.All & ~CubeFaces.West;
        root.AddOrReplaceChild("bottom", CubeListBuilder.Create().TexOffs(0, 19).AddBox(0.0F, 0.0F, 1.0F, 15.0F, 10.0F, 14.0F, visibleFaces), PartPose.Zero);
        root.AddOrReplaceChild("lid", CubeListBuilder.Create().TexOffs(0, 0).AddBox(0.0F, 0.0F, 0.0F, 15.0F, 5.0F, 14.0F, visibleFaces), PartPose.Offset(0.0F, 9.0F, 1.0F));
        root.AddOrReplaceChild("lock", CubeListBuilder.Create().TexOffs(0, 0).AddBox(0.0F, -2.0F, 14.0F, 1.0F, 4.0F, 1.0F, visibleFaces), PartPose.Offset(0.0F, 9.0F, 1.0F));
        return LayerDefinition.Create(mesh, 64, 64);
    }

    /// <summary><c>ChestRenderer.LAYERS</c>, baked.</summary>
    public static MultiblockChestResources<ChestModel> BakeAll() => new(
        new ChestModel(CreateSingleBodyLayer().BakeRoot()), new ChestModel(CreateDoubleBodyLeftLayer().BakeRoot()),
        new ChestModel(CreateDoubleBodyRightLayer().BakeRoot()));

    public void SetupAnim(float open) {
        ResetPose();
        _lid.XRot = -(open * (MathF.PI / 2));
        _lock.XRot = _lid.XRot;
    }
}

public sealed class ChestRenderState : BlockEntityRenderState {
    public ChestType Type = ChestType.Single;
    public float Open;
    public Direction Facing = Direction.South;
    public ChestMaterialType Material = ChestMaterialType.Regular;
}

/// <summary><c>ChestRenderer</c>, for chests, trapped chests, copper chests and ender chests.</summary>
public sealed class ChestRenderer(BlockEntityRendererContext context) : BlockEntityRenderer<ChestBlockEntity, ChestRenderState> {
    private readonly MultiblockChestResources<ChestModel> _models = ChestModel.BakeAll();
    private readonly bool _xmasTextures = XmasTextures();

    /// <summary><c>SpecialDates.isExtendedChristmas</c>, read once when the renderer is built, as vanilla does.</summary>
    public static bool XmasTextures() {
        DateTime now = DateTime.Now;
        return now.Month == 12 && now.Day is >= 24 and <= 26;
    }

    public override void ExtractRenderState(ChestBlockEntity blockEntity, ChestRenderState state, float partialTick, EntityRenderContext render) {
        base.ExtractRenderState(blockEntity, state, partialTick, render);
        state.Type = blockEntity.State is IChestTyped chest ? chest.Type : ChestType.Single;
        state.Facing = blockEntity.State is IHorizontalFacing facing ? facing.Facing : Direction.South;
        state.Material = GetChestMaterial(blockEntity, _xmasTextures);
        ChestBlockEntity? neighbour = blockEntity.Neighbour(render.Level);
        state.Open = blockEntity.CombinedOpenness(render.Level, partialTick);
        if (state.Type != ChestType.Single && neighbour != null) {
            // BrightnessCombiner: the brighter of the two halves' light, per channel.
            (float sky, float block) = LightAt(render.Level, neighbour.X, neighbour.Y, neighbour.Z, neighbour.State);
            (float ownSky, float ownBlock) = LightAt(render.Level, blockEntity.X, blockEntity.Y, blockEntity.Z, blockEntity.State);
            state.SkyLight = Math.Max(sky, ownSky);
            state.BlockLight = Math.Max(block, ownBlock);
        }
    }

    public override void Submit(ChestRenderState state, PoseStack pose, EntityRenderContext render) {
        pose.Push();
        pose.MulPose(ModelTransformation(state.Facing));
        float open = state.Open;
        open = 1.0F - open;
        open = 1.0F - open * open * open;
        SpriteId sprite = Sheets.ChooseSprite(state.Material, state.Type);
        ChestModel model = _models.Select(state.Type);
        model.SetupAnim(open);
        model.RenderToBuffer(pose, render.Batch, Draw(context.Sprites.Get(sprite), state));
        pose.Pop();
    }

    private static ChestMaterialType GetChestMaterial(ChestBlockEntity entity, bool xmasTextures) {
        if (BlockClasses.Is(entity.State.Identifier, BlockClass.CopperChestBlock)) {
            return CopperState(entity) switch {
                1 => ChestMaterialType.CopperExposed,
                2 => ChestMaterialType.CopperWeathered,
                3 => ChestMaterialType.CopperOxidized,
                _ => ChestMaterialType.CopperUnaffected
            };
        }
        if (entity.IsEnderChest) {
            return ChestMaterialType.EnderChest;
        }
        if (xmasTextures) {
            return ChestMaterialType.Christmas;
        }
        return entity.Is(BlockEntityType.TrappedChest) ? ChestMaterialType.Trapped : ChestMaterialType.Regular;
    }

    /// <summary><c>CopperChestBlock.getState</c>: the weathering stage the block was made for, waxed or not.</summary>
    private static int CopperState(ChestBlockEntity entity) {
        bool Is(params Minecraft.Data.Blocks.IBlock[] blocks) => blocks.Any(b => b.Identifier.Equals(entity.State.Identifier));
        return Is(Block.ExposedCopperChest, Block.WaxedExposedCopperChest) ? 1
            : Is(Block.WeatheredCopperChest, Block.WaxedWeatheredCopperChest) ? 2
            : Is(Block.OxidizedCopperChest, Block.WaxedOxidizedCopperChest) ? 3
            : 0;
    }

    /// <summary><c>createModelTransformation</c>: the facing's turn about the block's bottom centre.</summary>
    public static Matrix4x4 ModelTransformation(Direction facing) =>
        BlockEntityTransforms.RotationAround(BlockEntityTransforms.RotationYDegrees(-DirectionUtil.ToYRot(facing)), 0.5F, 0.0F, 0.5F);
}
