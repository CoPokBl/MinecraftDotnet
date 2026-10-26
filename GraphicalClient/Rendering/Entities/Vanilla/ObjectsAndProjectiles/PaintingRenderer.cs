using System.Numerics;
using ClientLib.Entities;
using Minecraft.Data.Generated;
using Minecraft.Data.PaintingVariant;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>PaintingRenderState</c>, with each segment's packed light split into sky and block.</summary>
public class PaintingRenderState : EntityRenderState {
    public Cardinal Direction = Cardinal.North;
    public IPaintingVariant? Variant;
    public (float Sky, float Block)[] LightPerBlock = [];
}

/// <summary>
/// <c>PaintingRenderer</c>. The paintings atlas is the <c>painting</c> texture directory, so a variant's
/// asset id names <c>textures/painting/&lt;path&gt;.png</c> and the back is <c>textures/painting/back.png</c>.
/// </summary>
public sealed class PaintingRenderer : EntityRenderer<PaintingRenderState> {
    private const string BackSpriteLocation = "minecraft:textures/painting/back.png";

    /// <summary>The variant the server sent, as a holder into the synced registry or inline.</summary>
    private static IPaintingVariant? Variant(ClientEntity entity, Minecraft.Registry.MinecraftRegistry registry) {
        Or<int, IPaintingVariant>? variant = entity.Get(EntityDataFields.Painting.PaintingVariant);
        if (variant == null) {
            return null;
        }
        if (variant.IsValue2) {
            return variant.Value2;
        }
        return registry.PaintingVariants.Contains(variant.Value1) ? registry.PaintingVariants.Get(variant.Value1) : null;
    }

    public override void Submit(PaintingRenderState state, PoseStack pose, EntityRenderContext context) {
        if (state.Variant is not { } variant) {
            return;
        }
        pose.Push();
        pose.RotateYDegrees(180 - ItemFrameRenderer.Get2DDataValue(state.Direction) * 90);
        Identifier asset = variant.AssetId;
        RenderPainting(pose, context.Batch, state.LightPerBlock, variant.Width, variant.Height, context.Texture($"{asset.Namespace}:textures/painting/{asset.Key}.png"),
            context.Texture(BackSpriteLocation));
        pose.Pop();
    }

    public override void ExtractRenderState(ClientEntity entity, PaintingRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        Cardinal direction = entity.Get(EntityDataFields.HangingEntity.Direction, Cardinal.South);
        IPaintingVariant? variant = Variant(entity, context.Level.Registry);
        entity.RendererData = variant;
        state.Direction = direction;
        state.Variant = variant;
        if (variant == null) {
            return;
        }
        int width = variant.Width;
        int height = variant.Height;
        if (state.LightPerBlock.Length != width * height) {
            state.LightPerBlock = new (float, float)[width * height];
        }
        float offsetX = -width / 2.0F;
        float offsetY = -height / 2.0F;
        int blockX = (int)Math.Floor(entity.Position.X), blockZ = (int)Math.Floor(entity.Position.Z);
        for (int segmentY = 0; segmentY < height; segmentY++) {
            for (int segmentX = 0; segmentX < width; segmentX++) {
                float segmentOffsetX = segmentX + offsetX + 0.5F;
                float segmentOffsetY = segmentY + offsetY + 0.5F;
                int x = blockX;
                int y = (int)Math.Floor(entity.Position.Y + segmentOffsetY);
                int z = blockZ;
                switch (direction) {
                    case Cardinal.North:
                        x = (int)Math.Floor(entity.Position.X + segmentOffsetX);
                        break;
                    case Cardinal.West:
                        z = (int)Math.Floor(entity.Position.Z - segmentOffsetX);
                        break;
                    case Cardinal.South:
                        x = (int)Math.Floor(entity.Position.X - segmentOffsetX);
                        break;
                    case Cardinal.East:
                        z = (int)Math.Floor(entity.Position.Z + segmentOffsetX);
                        break;
                }
                state.LightPerBlock[segmentX + segmentY * width] = (context.Level.GetSkyLight(x, y, z), context.Level.GetBlockLight(x, y, z));
            }
        }
    }

    /// <summary>
    /// <c>Entity.shouldRenderAtSqrDistance</c> on the painting's own box, which <c>calculateBoundingBox</c>
    /// sizes by the variant: its mean side is the same whichever way it faces.
    /// </summary>
    public override bool? ShouldRenderAtSqrDistance(ClientEntity entity, double distanceSqr) {
        if (entity.RendererData is not IPaintingVariant variant) {
            return null;
        }
        double size = (variant.Width + variant.Height + 0.0625) / 3.0 * 64.0 * ViewScale;
        return distanceSqr < size * size;
    }

    public override (Vector3 Min, Vector3 Max)? BoundingBoxForCulling(ClientEntity entity) {
        if (entity.RendererData is not IPaintingVariant variant) {
            return null;
        }
        Cardinal direction = entity.Get(EntityDataFields.HangingEntity.Direction, Cardinal.South);
        bool alongX = direction is Cardinal.North or Cardinal.South;
        float halfAcross = variant.Width / 2.0F, halfDepth = 0.03125F, halfHeight = variant.Height / 2.0F;
        Vector3 half = alongX ? new Vector3(halfAcross, halfHeight, halfDepth) : new Vector3(halfDepth, halfHeight, halfAcross);
        return (-half, half);
    }

    /// <summary>Resolved each tick as well, so the culling hooks, which run before a frame extracts, know the size.</summary>
    public override void Tick(ClientEntity entity, ClientLib.World.ClientLevel level) => entity.RendererData = Variant(entity, level.Registry);

    private static void RenderPainting(PoseStack pose, IModelSink sink, (float Sky, float Block)[] lightMap, int width, int height, EntityTexture front, EntityTexture back) {
        float offsetX = -width / 2.0F;
        float offsetY = -height / 2.0F;
        const float backU0 = 0, backU1 = 1, backV0 = 0, backV1 = 1;
        const float topBottomU0 = 0, topBottomU1 = 1, topBottomV0 = 0, topBottomV1 = 0.0625F;
        const float leftRightU0 = 0, leftRightU1 = 0.0625F, leftRightV0 = 0, leftRightV1 = 1;
        double deltaU = 1.0 / width;
        double deltaV = 1.0 / height;
        for (int segmentX = 0; segmentX < width; segmentX++) {
            for (int segmentY = 0; segmentY < height; segmentY++) {
                float x0 = offsetX + (segmentX + 1);
                float x1 = offsetX + segmentX;
                float y0 = offsetY + (segmentY + 1);
                float y1 = offsetY + segmentY;
                (float sky, float block) = lightMap[segmentX + segmentY * width];
                float frontU0 = (float)(deltaU * (width - segmentX));
                float frontU1 = (float)(deltaU * (width - (segmentX + 1)));
                float frontV0 = (float)(deltaV * (height - segmentY));
                float frontV1 = (float)(deltaV * (height - (segmentY + 1)));
                ModelDrawState frontDraw = new(front, 0xFFFFFFFF, sky, block, 0) { NoOutline = true };
                ModelDrawState backDraw = new(back, 0xFFFFFFFF, sky, block, 0) { NoOutline = true };
                Quad(pose, sink, frontDraw, 0, 0, -1,
                    (x0, y1, frontU1, frontV0, -0.03125F), (x1, y1, frontU0, frontV0, -0.03125F),
                    (x1, y0, frontU0, frontV1, -0.03125F), (x0, y0, frontU1, frontV1, -0.03125F));
                Quad(pose, sink, backDraw, 0, 0, 1,
                    (x0, y0, backU1, backV0, 0.03125F), (x1, y0, backU0, backV0, 0.03125F),
                    (x1, y1, backU0, backV1, 0.03125F), (x0, y1, backU1, backV1, 0.03125F));
                if (segmentY == height - 1) {
                    Quad(pose, sink, backDraw, 0, 1, 0,
                        (x0, y0, topBottomU0, topBottomV0, -0.03125F), (x1, y0, topBottomU1, topBottomV0, -0.03125F),
                        (x1, y0, topBottomU1, topBottomV1, 0.03125F), (x0, y0, topBottomU0, topBottomV1, 0.03125F));
                }
                if (segmentY == 0) {
                    Quad(pose, sink, backDraw, 0, -1, 0,
                        (x0, y1, topBottomU0, topBottomV0, 0.03125F), (x1, y1, topBottomU1, topBottomV0, 0.03125F),
                        (x1, y1, topBottomU1, topBottomV1, -0.03125F), (x0, y1, topBottomU0, topBottomV1, -0.03125F));
                }
                if (segmentX == width - 1) {
                    Quad(pose, sink, backDraw, -1, 0, 0,
                        (x0, y0, leftRightU1, leftRightV0, 0.03125F), (x0, y1, leftRightU1, leftRightV1, 0.03125F),
                        (x0, y1, leftRightU0, leftRightV1, -0.03125F), (x0, y0, leftRightU0, leftRightV0, -0.03125F));
                }
                if (segmentX == 0) {
                    Quad(pose, sink, backDraw, 1, 0, 0,
                        (x1, y0, leftRightU1, leftRightV0, -0.03125F), (x1, y1, leftRightU1, leftRightV1, -0.03125F),
                        (x1, y1, leftRightU0, leftRightV1, 0.03125F), (x1, y0, leftRightU0, leftRightV0, 0.03125F));
                }
            }
        }
    }

    /// <summary>Four of <c>PaintingRenderer.vertex</c>'s calls: (x, y, u, v, z) each.</summary>
    private static void Quad(PoseStack pose, IModelSink sink, ModelDrawState draw, float nx, float ny, float nz,
        (float X, float Y, float U, float V, float Z) a, (float X, float Y, float U, float V, float Z) b,
        (float X, float Y, float U, float V, float Z) c, (float X, float Y, float U, float V, float Z) d) {
        Matrix4x4 matrix = pose.Matrix;
        ReadOnlySpan<Vector3> corners = [
            Vector3.Transform(new Vector3(a.X, a.Y, a.Z), matrix), Vector3.Transform(new Vector3(b.X, b.Y, b.Z), matrix),
            Vector3.Transform(new Vector3(c.X, c.Y, c.Z), matrix), Vector3.Transform(new Vector3(d.X, d.Y, d.Z), matrix)
        ];
        ReadOnlySpan<Vector2> uvs = [new(a.U, a.V), new(b.U, b.V), new(c.U, c.V), new(d.U, d.V)];
        sink.Quad(corners, uvs, pose.TransformNormal(new Vector3(nx, ny, nz)), draw);
    }
}
