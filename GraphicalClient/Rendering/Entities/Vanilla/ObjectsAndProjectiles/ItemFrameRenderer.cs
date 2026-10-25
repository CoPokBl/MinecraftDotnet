using ClientLib.Entities;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>ItemFrameRenderState</c>.</summary>
public class ItemFrameRenderState : EntityRenderState {
    public Cardinal Direction = Cardinal.North;
    public bool HasFrameModel;
    public ItemStack? Item;
    public int Rotation;
    public bool IsGlowFrame;
    public int? MapId;
    public ClientLib.World.ClientMapData? MapData;
}

/// <summary>
/// <c>ItemFrameRenderer</c>. <c>getRenderOffset</c> is left out with the translation that undoes it, as
/// nothing else here is drawn at the offset.
/// </summary>
public sealed class ItemFrameRenderer : EntityRenderer<ItemFrameRenderState> {
    public const int GlowFrameBrightness = 5;

    private static readonly Identifier ItemFrameLocation = "minecraft:item_frame";
    private static readonly Identifier GlowItemFrameLocation = "minecraft:glow_item_frame";
    private static readonly IReadOnlyDictionary<string, string> NoMap = new Dictionary<string, string> { ["map"] = "false" };
    private static readonly IReadOnlyDictionary<string, string> WithMap = new Dictionary<string, string> { ["map"] = "true" };

    /// <summary><c>BRIGHT_MAP_LIGHT_ADJUSTMENT</c> below full block light, in light levels: a glow frame's map.</summary>
    private const float GlowMapBlockLight = (240 - 30) / 16.0F;

    private readonly BlockModelRenderer _blocks;
    private readonly ItemRenderer _items;
    private readonly MapRenderer _maps;

    public ItemFrameRenderer(EntityRendererContext context) {
        _blocks = context.Blocks;
        _items = context.Items;
        _maps = context.Maps;
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
            _blocks.Render(state.IsGlowFrame ? GlowItemFrameLocation : ItemFrameLocation, state.MapId != null ? WithMap : NoMap, pose, context.Batch,
                state.SkyLight, state.BlockLight);
            pose.Pop();
        }
        if (state.IsInvisible) {
            pose.Translate(0.0F, 0.0F, 0.5F);
        }
        else {
            pose.Translate(0.0F, 0.0F, 0.4375F);
        }
        if (state.MapId is { } mapId && state.MapData is { } mapData) {
            int rotation = state.Rotation % 4 * 2;
            pose.RotateZDegrees(rotation * 360.0F / 8.0F);
            pose.RotateZDegrees(180.0F);
            pose.Scale(0.0078125F, 0.0078125F, 0.0078125F);
            pose.Translate(-64.0F, -64.0F, 0.0F);
            pose.Translate(0.0F, 0.0F, -1.0F);
            float sky = state.IsGlowFrame ? 15 : state.SkyLight, block = state.IsGlowFrame ? GlowMapBlockLight : state.BlockLight;
            _maps.Render(mapId, mapData, pose, context.Batch, context.TranslucentBatch, true, sky, block);
        }
        else if (state.Item is { } item && !item.IsAir()) {
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
        // getFramedMapId, and a map the server has sent nothing of is no map at all.
        state.MapId = null;
        state.MapData = null;
        if (state.Item is { } framed && framed.Has(DataComponent.MapId) && context.Client.MapData(framed.Get(DataComponent.MapId)) is { } mapData) {
            state.MapId = framed.Get(DataComponent.MapId);
            state.MapData = mapData;
        }
        state.HasFrameModel = !state.IsInvisible;
    }
}
