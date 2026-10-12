using System.Numerics;
using ClientLib.World.BlockEntities;
using GraphicalClient.Rendering.Entities;
using GraphicalClient.Rendering.Entities.Special;
using Minecraft.Data.Generated;
using Minecraft.Data.Items;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Mth = GraphicalClient.Rendering.Entities.Mth;

namespace GraphicalClient.Rendering.BlockEntities;

public sealed class DecoratedPotRenderState : BlockEntityRenderState {
    public DecoratedPotBlockEntity.WobbleStyle? WobbleStyle;
    public float WobbleProgress;
    public IItem?[] Decorations = new IItem?[4];
    public Direction Direction = Direction.North;
}

/// <summary><c>DecoratedPotRenderer</c>.</summary>
public sealed class DecoratedPotRenderer : BlockEntityRenderer<DecoratedPotBlockEntity, DecoratedPotRenderState> {
    /// <summary><c>DECORATED_POT_SPRITES</c>: <c>DecoratedPotPatterns.itemToPatternMappings</c> with each pattern's asset id.</summary>
    private static readonly Dictionary<Identifier, SpriteId> DecoratedPotSprites = new IItem[] {
        Item.AnglerPotterySherd, Item.ArcherPotterySherd, Item.ArmsUpPotterySherd, Item.BladePotterySherd, Item.BrewerPotterySherd,
        Item.BurnPotterySherd, Item.DangerPotterySherd, Item.ExplorerPotterySherd, Item.FlowPotterySherd, Item.FriendPotterySherd,
        Item.GusterPotterySherd, Item.HeartPotterySherd, Item.HeartbreakPotterySherd, Item.HowlPotterySherd, Item.MinerPotterySherd,
        Item.MournerPotterySherd, Item.PlentyPotterySherd, Item.PrizePotterySherd, Item.ScrapePotterySherd, Item.SheafPotterySherd,
        Item.ShelterPotterySherd, Item.SkullPotterySherd, Item.SnortPotterySherd
    }.ToDictionary(item => item.Identifier, item => Sheets.DecoratedPotSprite(new Identifier("minecraft", item.Identifier.Key.Replace("_sherd", "_pattern"))));

    private readonly ISpriteGetter _sprites;
    private readonly ModelPart _neck, _frontSide, _backSide, _leftSide, _rightSide, _top, _bottom;

    public DecoratedPotRenderer(BlockEntityRendererContext context) : this(context.Sprites) { }

    public DecoratedPotRenderer(ISpriteGetter sprites) {
        _sprites = sprites;
        ModelPart baseRoot = CreateBaseLayer().BakeRoot();
        _neck = baseRoot.GetChild("neck");
        _top = baseRoot.GetChild("top");
        _bottom = baseRoot.GetChild("bottom");
        ModelPart sidesRoot = CreateSidesLayer().BakeRoot();
        _frontSide = sidesRoot.GetChild("front");
        _backSide = sidesRoot.GetChild("back");
        _leftSide = sidesRoot.GetChild("left");
        _rightSide = sidesRoot.GetChild("right");
    }

    public static LayerDefinition CreateBaseLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        CubeDeformation inflate = new(0.2F), deflate = new(-0.1F);
        root.AddOrReplaceChild("neck", CubeListBuilder.Create()
                .TexOffs(0, 0).AddBox(4.0F, 17.0F, 4.0F, 8.0F, 3.0F, 8.0F, deflate)
                .TexOffs(0, 5).AddBox(5.0F, 20.0F, 5.0F, 6.0F, 1.0F, 6.0F, inflate),
            PartPose.OffsetAndRotation(0.0F, 37.0F, 16.0F, MathF.PI, 0.0F, 0.0F));
        CubeListBuilder topBottomPlane = CubeListBuilder.Create().TexOffs(-14, 13).AddBox(0.0F, 0.0F, 0.0F, 14.0F, 0.0F, 14.0F);
        root.AddOrReplaceChild("top", topBottomPlane, PartPose.OffsetAndRotation(1.0F, 16.0F, 1.0F, 0.0F, 0.0F, 0.0F));
        root.AddOrReplaceChild("bottom", topBottomPlane, PartPose.OffsetAndRotation(1.0F, 0.0F, 1.0F, 0.0F, 0.0F, 0.0F));
        return LayerDefinition.Create(mesh, 32, 32);
    }

    public static LayerDefinition CreateSidesLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        CubeListBuilder sidePlane = CubeListBuilder.Create().TexOffs(1, 0).AddBox(0.0F, 0.0F, 0.0F, 14.0F, 16.0F, 0.0F, CubeFaces.North);
        root.AddOrReplaceChild("back", sidePlane, PartPose.OffsetAndRotation(15.0F, 16.0F, 1.0F, 0.0F, 0.0F, MathF.PI));
        root.AddOrReplaceChild("left", sidePlane, PartPose.OffsetAndRotation(1.0F, 16.0F, 1.0F, 0.0F, -MathF.PI / 2, MathF.PI));
        root.AddOrReplaceChild("right", sidePlane, PartPose.OffsetAndRotation(15.0F, 16.0F, 15.0F, 0.0F, MathF.PI / 2, MathF.PI));
        root.AddOrReplaceChild("front", sidePlane, PartPose.OffsetAndRotation(1.0F, 16.0F, 15.0F, MathF.PI, 0.0F, 0.0F));
        return LayerDefinition.Create(mesh, 16, 16);
    }

    private static SpriteId GetSideSprite(IItem? item) =>
        item != null && DecoratedPotSprites.TryGetValue(item.Identifier, out SpriteId sprite) ? sprite : Sheets.DecoratedPotSide;

    public override void ExtractRenderState(DecoratedPotBlockEntity blockEntity, DecoratedPotRenderState state, float partialTick, EntityRenderContext render) {
        base.ExtractRenderState(blockEntity, state, partialTick, render);
        state.Decorations = blockEntity.Sherds;
        state.Direction = blockEntity.Direction;
        // Vanilla never copies the wobble's style into the state, so every wobble draws as the negative
        // one's turn; the progress still runs over the style that started it.
        state.WobbleProgress = blockEntity.LastWobbleStyle is { } style
            ? (render.Level.GameTime - blockEntity.WobbleStartedAtTick + partialTick) / DecoratedPotBlockEntity.Duration(style)
            : 0.0F;
    }

    public override void Submit(DecoratedPotRenderState state, PoseStack pose, EntityRenderContext render) {
        pose.Push();
        pose.MulPose(ModelTransformation(state.Direction));
        if (state.WobbleProgress >= 0.0F && state.WobbleProgress <= 1.0F) {
            if (state.WobbleStyle == DecoratedPotBlockEntity.WobbleStyle.Positive) {
                float deltaTime = state.WobbleProgress * (MathF.PI * 2);
                float tiltX = -1.5F * (Mth.Cos(deltaTime) + 0.5F) * Mth.Sin(deltaTime / 2.0F);
                pose.MulPose(BlockEntityTransforms.RotationAround(Matrix4x4.CreateRotationX(tiltX * 0.015625F), 0.5F, 0.0F, 0.5F));
                float tiltZ = Mth.Sin(deltaTime);
                pose.MulPose(BlockEntityTransforms.RotationAround(Matrix4x4.CreateRotationZ(tiltZ * 0.015625F), 0.5F, 0.0F, 0.5F));
            }
            else {
                float turnAngle = Mth.Sin(-state.WobbleProgress * 3.0F * MathF.PI) * 0.125F;
                float linearDecayFactor = 1.0F - state.WobbleProgress;
                pose.MulPose(BlockEntityTransforms.RotationAround(Matrix4x4.CreateRotationY(turnAngle * linearDecayFactor), 0.5F, 0.0F, 0.5F));
            }
        }
        Submit(pose, render.Batch, state.SkyLight, state.BlockLight, state.Decorations);
        pose.Pop();
    }

    /// <summary><c>createModelTransformation</c>.</summary>
    public static Matrix4x4 ModelTransformation(Direction facing) =>
        BlockEntityTransforms.RotationAround(BlockEntityTransforms.RotationYDegrees(180.0F - DirectionUtil.ToYRot(facing)), 0.5F, 0.5F, 0.5F);

    /// <summary>The pot in back, left, right, front order of <paramref name="decorations"/>.</summary>
    public void Submit(PoseStack pose, IModelSink sink, float skyLight, float blockLight, IItem?[] decorations) {
        ModelDrawState Draw(SpriteId sprite) => new(_sprites.Get(sprite), 0xFFFFFFFF, skyLight, blockLight, 0);
        ModelDrawState baseState = Draw(Sheets.DecoratedPotBase);
        _neck.Render(pose, sink, baseState);
        _top.Render(pose, sink, baseState);
        _bottom.Render(pose, sink, baseState);
        _frontSide.Render(pose, sink, Draw(GetSideSprite(decorations[3])));
        _backSide.Render(pose, sink, Draw(GetSideSprite(decorations[0])));
        _leftSide.Render(pose, sink, Draw(GetSideSprite(decorations[1])));
        _rightSide.Render(pose, sink, Draw(GetSideSprite(decorations[2])));
    }

    public void GetExtents(Action<Vector3> output) {
        PoseStack pose = new();
        _neck.GetExtentsForGui(pose, output);
        _top.GetExtentsForGui(pose, output);
        _bottom.GetExtentsForGui(pose, output);
    }
}
