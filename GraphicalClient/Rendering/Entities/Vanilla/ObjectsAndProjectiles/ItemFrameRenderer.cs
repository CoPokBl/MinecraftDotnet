using ClientLib.Entities;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>ItemFrameRenderState</c>, without the map, which this client has no data for.</summary>
public class ItemFrameRenderState : EntityRenderState {
    public Cardinal Direction = Cardinal.North;
    public bool HasFrameModel;
    public ItemStack? Item;
    public int Rotation;
    public bool IsGlowFrame;
}

/// <summary>
/// <c>ItemFrameRenderer</c>. A framed map's contents are not drawn: the client keeps no map data, which
/// vanilla treats as no map at all, so the frame takes its <c>map=false</c> model and holds the map as an
/// item. <c>getRenderOffset</c> is left out with the translation that undoes it, as nothing else here is
/// drawn at the offset.
/// </summary>
public sealed class ItemFrameRenderer : EntityRenderer<ItemFrameRenderState> {
    public const int GlowFrameBrightness = 5;

    private static readonly Identifier ItemFrameLocation = "minecraft:item_frame";
    private static readonly Identifier GlowItemFrameLocation = "minecraft:glow_item_frame";
    private static readonly IReadOnlyDictionary<string, string> NoMap = new Dictionary<string, string> { ["map"] = "false" };

    private readonly BlockModelRenderer _blocks;
    private readonly ItemRenderer _items;

    public ItemFrameRenderer(EntityRendererContext context) {
        _blocks = context.Blocks;
        _items = context.Items;
    }

    /// <summary><c>ItemFrame.shouldRenderAtSqrDistance</c>.</summary>
    public override bool? ShouldRenderAtSqrDistance(ClientEntity entity, double distanceSqr) {
        double size = 16.0;
        size *= 64.0 * ViewScale;
        return distanceSqr < size * size;
    }

    public override void Submit(ItemFrameRenderState state, PoseStack pose, EntityRenderContext context) {
        pose.Push();
        Cardinal direction = state.Direction;
        (int stepX, int stepY, int stepZ) = Step(direction);
        pose.Translate(stepX * 0.46875F, stepY * 0.46875F, stepZ * 0.46875F);
        float xRot;
        float yRot;
        if (direction is not (Cardinal.Up or Cardinal.Down)) {
            xRot = 0.0F;
            yRot = 180.0F - ToYRot(direction);
        }
        else {
            xRot = -90 * (direction == Cardinal.Up ? 1 : -1);
            yRot = 180.0F;
        }
        pose.RotateXDegrees(xRot);
        pose.RotateYDegrees(yRot);
        if (state.HasFrameModel) {
            pose.Push();
            pose.Translate(-0.5F, -0.5F, -0.5F);
            _blocks.Render(state.IsGlowFrame ? GlowItemFrameLocation : ItemFrameLocation, NoMap, pose, context.Batch, state.SkyLight, state.BlockLight);
            pose.Pop();
        }
        if (state.IsInvisible) {
            pose.Translate(0.0F, 0.0F, 0.5F);
        }
        else {
            pose.Translate(0.0F, 0.0F, 0.4375F);
        }
        if (state.Item is { } item && !item.IsAir()) {
            pose.RotateZDegrees(state.Rotation * 360.0F / 8.0F);
            // getLightCoords: a glow frame's item is drawn at full brightness.
            float sky = state.IsGlowFrame ? 15 : state.SkyLight, block = state.IsGlowFrame ? 15 : state.BlockLight;
            pose.Scale(0.5F, 0.5F, 0.5F);
            _items.Render(item, ItemDisplayContext.Fixed, pose, context.Batch, sky, block, state.Entity);
        }
        pose.Pop();
    }

    internal static (int X, int Y, int Z) Step(Cardinal direction) => direction switch {
        Cardinal.Down => (0, -1, 0),
        Cardinal.Up => (0, 1, 0),
        Cardinal.North => (0, 0, -1),
        Cardinal.South => (0, 0, 1),
        Cardinal.West => (-1, 0, 0),
        _ => (1, 0, 0)
    };

    /// <summary><c>Direction.toYRot</c>: the horizontal data value times 90.</summary>
    internal static float ToYRot(Cardinal direction) => Get2DDataValue(direction) * 90;

    /// <summary><c>Direction.get2DDataValue</c>.</summary>
    internal static int Get2DDataValue(Cardinal direction) => direction switch {
        Cardinal.South => 0,
        Cardinal.West => 1,
        Cardinal.North => 2,
        Cardinal.East => 3,
        _ => -1
    };

    public override void ExtractRenderState(ClientEntity entity, ItemFrameRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        state.IsGlowFrame = entity.Type.Equals(EntityType.GlowItemFrame);
        if (state.IsGlowFrame) {
            // getBlockLightLevel.
            state.BlockLight = Math.Max(GlowFrameBrightness, state.BlockLight);
        }
        state.Direction = entity.Get(EntityDataFields.HangingEntity.Direction, Cardinal.South);
        state.Item = entity.Get(EntityDataFields.ItemFrame.Item);
        state.Rotation = entity.Get(EntityDataFields.ItemFrame.Rotation);
        state.HasFrameModel = !state.IsInvisible;
    }
}
