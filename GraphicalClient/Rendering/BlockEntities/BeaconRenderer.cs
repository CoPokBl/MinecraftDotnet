using System.Numerics;
using ClientLib.Maths;
using ClientLib.World.BlockEntities;
using GraphicalClient.Rendering.Entities;
using GraphicalClient.Rendering.Entities.Special;
using Mth = GraphicalClient.Rendering.Entities.Mth;

namespace GraphicalClient.Rendering.BlockEntities;

public sealed class BeaconRenderState : BlockEntityRenderState {
    public float AnimationTime, BeamRadiusScale;
    public (uint Color, int Height)[] Sections = [];
}

/// <summary>
/// <c>BeaconRenderer</c>: the beam, a turning inner column and a faint outer glow, coloured section by
/// section by the glass it passes through. The texture repeats up the beam, which the entity atlas cannot
/// do, so each face is drawn from the texture tiled <see cref="TallRepeats"/> high and cut where that
/// runs out; the cut faces cover only the part of the beam in view, which draws the same picture.
/// </summary>
public sealed class BeaconRenderer(BlockEntityRendererContext context) : BlockEntityRenderer<BeaconBlockEntity, BeaconRenderState> {
    public static readonly SpriteId BeamLocation = Sheets.TextureSprite("minecraft:textures/entity/beacon/beacon_beam.png");

    private const int MaxRenderY = 2048;

    /// <summary>Repeats of a beam texture tiled down the atlas; the solid beam crosses two and a half a block.</summary>
    private const int TallRepeats = 16;

    public override bool ShouldRenderOffScreen => true;

    /// <summary><c>getViewDistance</c>: the render distance in blocks.</summary>
    public override int ViewDistance => context.RenderDistance() * 16;

    /// <summary><c>shouldRender</c>: horizontal distance only, as the beam reaches the sky.</summary>
    public override bool ShouldRender(ClientBlockEntity blockEntity, Vec3d camera) =>
        new Vec3d(blockEntity.X + 0.5 - camera.X, 0, blockEntity.Z + 0.5 - camera.Z).LengthSqr() < (double)ViewDistance * ViewDistance;

    public override void ExtractRenderState(BeaconBlockEntity blockEntity, BeaconRenderState state, float partialTick, EntityRenderContext render) {
        base.ExtractRenderState(blockEntity, state, partialTick, render);
        long gameTime = render.Level.GameTime;
        state.AnimationTime = (gameTime % 40 + 40) % 40 + partialTick;
        state.Sections = blockEntity.BeamSections.Select(section => (section.Color, section.Height)).ToArray();
        Vec3d camera = render.Camera.Position;
        float distanceToBeacon = (float)Math.Sqrt(new Vec3d(camera.X - (blockEntity.X + 0.5), 0, camera.Z - (blockEntity.Z + 0.5)).LengthSqr());
        state.BeamRadiusScale = render.Client.Player is { IsScoping: true } ? 1.0F : Math.Max(1.0F, distanceToBeacon / 96.0F);
    }

    public override void Submit(BeaconRenderState state, PoseStack pose, EntityRenderContext render) {
        if (VisibleSpan(render, state, 0.25F * state.BeamRadiusScale) is not (float visibleFrom, float visibleTo)) {
            return;
        }
        int beamStart = 0;
        for (int i = 0; i < state.Sections.Length; i++) {
            (uint color, int height) = state.Sections[i];
            int sectionHeight = i == state.Sections.Length - 1 ? MaxRenderY : height;
            SubmitBeaconBeam(pose, render, context.Sprites, BeamLocation, 1.0F, state.AnimationTime, beamStart, sectionHeight, color,
                0.2F * state.BeamRadiusScale, 0.25F * state.BeamRadiusScale, visibleFrom, visibleTo);
            beamStart += height;
        }
    }

    /// <summary>
    /// The part of a vertical beam up the middle of the block that the camera can see, in the beam's own y;
    /// null when none. <paramref name="radius"/> is the beam's half width before it turns.
    /// </summary>
    public static (float From, float To)? VisibleSpan(EntityRenderContext render, BlockEntityRenderState state, float radius) {
        Camera camera = render.Camera;
        Vec3d at = camera.Position;
        float x = (float)(state.X + 0.5 - at.X), z = (float)(state.Z + 0.5 - at.Z), baseY = (float)(state.Y - at.Y);
        Span<Vector4> planes = stackalloc Vector4[6];
        Frustum.FromMatrix(camera.View * camera.CullProjection).CopyPlanes(planes);
        float from = float.MinValue, to = float.MaxValue;
        // The square turns, so its corners reach the radius times root two.
        float reach = radius * MathF.Sqrt(2.0F);
        foreach (Vector4 plane in planes) {
            float rest = plane.X * x + plane.Z * z + (Math.Abs(plane.X) + Math.Abs(plane.Z)) * reach + plane.W;
            if (plane.Y > 0.0F) {
                from = Math.Max(from, -rest / plane.Y);
            }
            else if (plane.Y < 0.0F) {
                to = Math.Min(to, -rest / plane.Y);
            }
            else if (rest < 0.0F) {
                return null;
            }
        }
        return from < to ? (from - baseY, to - baseY) : null;
    }

    /// <summary><c>submitBeaconBeam</c>, drawn only between <paramref name="visibleFrom"/> and <paramref name="visibleTo"/> in the beam's own y.</summary>
    public static void SubmitBeaconBeam(PoseStack pose, EntityRenderContext render, ISpriteGetter sprites, SpriteId beamLocation, float scale,
        float animationTime, int beamStart, int height, uint color, float solidBeamRadius, float beamGlowRadius, float visibleFrom, float visibleTo) {
        EntityTexture? tall = TiledTextures.Get(sprites, render.Textures, beamLocation, 1, TallRepeats);
        EntityTexture texture = tall ?? sprites.Get(beamLocation);
        int repeats = tall == null ? 1 : TallRepeats;
        int beamEnd = beamStart + height;
        pose.Push();
        pose.Translate(0.5F, 0.0F, 0.5F);
        float scroll = height < 0 ? animationTime : -animationTime;
        float texVOff = Mth.Frac(scroll * 0.2F - Mth.Floor(scroll * 0.1F));
        pose.Push();
        pose.RotateYDegrees(animationTime * 2.25F - 45.0F);
        float vv2 = -1.0F + texVOff;
        float vv1 = height * scale * (0.5F / solidBeamRadius) + vv2;
        RenderPart(pose, render.Batch, new ModelDrawState(texture, 0xFF000000 | color, 15, 15, 0), repeats, beamStart, beamEnd, visibleFrom, visibleTo,
            0.0F, solidBeamRadius, solidBeamRadius, 0.0F, -solidBeamRadius, 0.0F, 0.0F, -solidBeamRadius, vv1, vv2);
        pose.Pop();
        vv1 = height * scale + vv2;
        RenderPart(pose, render.TranslucentBatch, new ModelDrawState(texture, 32u << 24 | (color & 0xFFFFFF), 15, 15, 0), repeats, beamStart, beamEnd,
            visibleFrom, visibleTo, -beamGlowRadius, -beamGlowRadius, beamGlowRadius, -beamGlowRadius, -beamGlowRadius, beamGlowRadius, beamGlowRadius,
            beamGlowRadius, vv1, vv2);
        pose.Pop();
    }

    private static void RenderPart(PoseStack pose, IModelSink sink, ModelDrawState draw, int repeats, int beamStart, int beamEnd, float visibleFrom,
        float visibleTo, float wnx, float wnz, float enx, float enz, float wsx, float wsz, float esx, float esz, float vv1, float vv2) {
        RenderQuad(pose, sink, draw, repeats, beamStart, beamEnd, visibleFrom, visibleTo, wnx, wnz, enx, enz, vv1, vv2);
        RenderQuad(pose, sink, draw, repeats, beamStart, beamEnd, visibleFrom, visibleTo, esx, esz, wsx, wsz, vv1, vv2);
        RenderQuad(pose, sink, draw, repeats, beamStart, beamEnd, visibleFrom, visibleTo, enx, enz, esx, esz, vv1, vv2);
        RenderQuad(pose, sink, draw, repeats, beamStart, beamEnd, visibleFrom, visibleTo, wsx, wsz, wnx, wnz, vv1, vv2);
    }

    /// <summary>
    /// <c>renderQuad</c>: from <paramref name="beamStart"/> at v <paramref name="vv2"/> up to
    /// <paramref name="beamEnd"/> at <paramref name="vv1"/>, u running 1 to 0 across, cut into pieces that
    /// each stay within one tile of a texture holding <paramref name="repeats"/> repeats down.
    /// </summary>
    private static void RenderQuad(PoseStack pose, IModelSink sink, ModelDrawState draw, int repeats, int beamStart, int beamEnd, float visibleFrom,
        float visibleTo, float wnx, float wnz, float enx, float enz, float vv1, float vv2) {
        float y0 = Math.Max(beamStart, visibleFrom), y1 = Math.Min(beamEnd, visibleTo);
        if (y0 >= y1) {
            return;
        }
        float VAt(float y) => (vv2 + (vv1 - vv2) * (y - beamStart) / (beamEnd - beamStart)) / repeats;
        float YAt(float v) => beamStart + (v * repeats - vv2) / (vv1 - vv2) * (beamEnd - beamStart);
        Matrix4x4 matrix = pose.Matrix;
        Vector3 normal = pose.TransformNormal(Vector3.UnitY);
        float vFrom = VAt(y0), vTo = VAt(y1);
        float vMin = Math.Min(vFrom, vTo), vMax = Math.Max(vFrom, vTo);
        // Walked by tile rather than by height: stepping y to each boundary in turn stalls where float
        // rounding puts the boundary back on the current y, and the rest of the beam then samples off its texture.
        for (float tile = MathF.Floor(vMin); tile < vMax; tile++) {
            float vLow = Math.Max(vMin, tile), vHigh = Math.Min(vMax, tile + 1);
            float yA = Math.Clamp(YAt(vLow), y0, y1), yB = Math.Clamp(YAt(vHigh), y0, y1);
            (float y, float next, float vBottom, float vTop) = yA < yB ? (yA, yB, vLow - tile, vHigh - tile) : (yB, yA, vHigh - tile, vLow - tile);
            if (next <= y) {
                continue;
            }
            ReadOnlySpan<Vector3> corners = [
                Vector3.Transform(new Vector3(wnx, next, wnz), matrix), Vector3.Transform(new Vector3(wnx, y, wnz), matrix),
                Vector3.Transform(new Vector3(enx, y, enz), matrix), Vector3.Transform(new Vector3(enx, next, enz), matrix)
            ];
            ReadOnlySpan<Vector2> uvs = [new(1, vTop), new(1, vBottom), new(0, vBottom), new(0, vTop)];
            sink.Quad(corners, uvs, normal, draw);
        }
    }
}
