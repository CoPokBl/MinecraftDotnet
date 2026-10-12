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
/// do, so each face is cut where its texture coordinate crosses a whole number; the cut faces cover only
/// the part of the beam within the far plane of the camera, which draws the same picture.
/// </summary>
public sealed class BeaconRenderer(BlockEntityRendererContext context) : BlockEntityRenderer<BeaconBlockEntity, BeaconRenderState> {
    public static readonly SpriteId BeamLocation = Sheets.TextureSprite("minecraft:textures/entity/beacon/beacon_beam.png");

    private const int MaxRenderY = 2048;

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
        // Looking through a spyglass keeps it thin; this client has no spyglass zoom.
        state.BeamRadiusScale = Math.Max(1.0F, distanceToBeacon / 96.0F);
    }

    public override void Submit(BeaconRenderState state, PoseStack pose, EntityRenderContext render) {
        // The part of the beam the camera can see, in the beam's own y.
        float far = render.Camera.FarPlane;
        float cameraY = (float)(render.Camera.Position.Y - state.Y);
        int beamStart = 0;
        for (int i = 0; i < state.Sections.Length; i++) {
            (uint color, int height) = state.Sections[i];
            int sectionHeight = i == state.Sections.Length - 1 ? MaxRenderY : height;
            SubmitBeaconBeam(pose, render, state.AnimationTime, beamStart, sectionHeight, color, 0.2F * state.BeamRadiusScale, 0.25F * state.BeamRadiusScale,
                cameraY - far, cameraY + far);
            beamStart += height;
        }
    }

    /// <summary><c>submitBeaconBeam</c>.</summary>
    private void SubmitBeaconBeam(PoseStack pose, EntityRenderContext render, float animationTime, int beamStart, int height, uint color,
        float solidBeamRadius, float beamGlowRadius, float visibleFrom, float visibleTo) {
        const float scale = 1.0F;
        int beamEnd = beamStart + height;
        EntityTexture texture = context.Sprites.Get(BeamLocation);
        pose.Push();
        pose.Translate(0.5F, 0.0F, 0.5F);
        float scroll = height < 0 ? animationTime : -animationTime;
        float texVOff = Mth.Frac(scroll * 0.2F - Mth.Floor(scroll * 0.1F));
        pose.Push();
        pose.RotateYDegrees(animationTime * 2.25F - 45.0F);
        float vv2 = -1.0F + texVOff;
        float vv1 = height * scale * (0.5F / solidBeamRadius) + vv2;
        RenderPart(pose, render.Batch, new ModelDrawState(texture, 0xFF000000 | color, 15, 15, 0), beamStart, beamEnd, visibleFrom, visibleTo,
            0.0F, solidBeamRadius, solidBeamRadius, 0.0F, -solidBeamRadius, 0.0F, 0.0F, -solidBeamRadius, vv1, vv2);
        pose.Pop();
        vv1 = height * scale + vv2;
        RenderPart(pose, render.TranslucentBatch, new ModelDrawState(texture, 32u << 24 | (color & 0xFFFFFF), 15, 15, 0), beamStart, beamEnd, visibleFrom,
            visibleTo, -beamGlowRadius, -beamGlowRadius, beamGlowRadius, -beamGlowRadius, -beamGlowRadius, beamGlowRadius, beamGlowRadius, beamGlowRadius, vv1, vv2);
        pose.Pop();
    }

    private static void RenderPart(PoseStack pose, IModelSink sink, ModelDrawState draw, int beamStart, int beamEnd, float visibleFrom, float visibleTo,
        float wnx, float wnz, float enx, float enz, float wsx, float wsz, float esx, float esz, float vv1, float vv2) {
        RenderQuad(pose, sink, draw, beamStart, beamEnd, visibleFrom, visibleTo, wnx, wnz, enx, enz, vv1, vv2);
        RenderQuad(pose, sink, draw, beamStart, beamEnd, visibleFrom, visibleTo, esx, esz, wsx, wsz, vv1, vv2);
        RenderQuad(pose, sink, draw, beamStart, beamEnd, visibleFrom, visibleTo, enx, enz, esx, esz, vv1, vv2);
        RenderQuad(pose, sink, draw, beamStart, beamEnd, visibleFrom, visibleTo, wsx, wsz, wnx, wnz, vv1, vv2);
    }

    /// <summary>
    /// <c>renderQuad</c>: from <paramref name="beamStart"/> at v <paramref name="vv2"/> up to
    /// <paramref name="beamEnd"/> at <paramref name="vv1"/>, u running 1 to 0 across, cut into pieces that
    /// each stay within one repeat of the texture.
    /// </summary>
    private static void RenderQuad(PoseStack pose, IModelSink sink, ModelDrawState draw, int beamStart, int beamEnd, float visibleFrom, float visibleTo,
        float wnx, float wnz, float enx, float enz, float vv1, float vv2) {
        float y0 = Math.Max(beamStart, visibleFrom), y1 = Math.Min(beamEnd, visibleTo);
        if (y0 >= y1) {
            return;
        }
        float VAt(float y) => vv2 + (vv1 - vv2) * (y - beamStart) / (beamEnd - beamStart);
        Matrix4x4 matrix = pose.Matrix;
        Vector3 normal = pose.TransformNormal(Vector3.UnitY);
        float y = y0;
        while (y < y1) {
            float v = VAt(y);
            float vStep = vv1 > vv2 ? MathF.Floor(v) + 1 : MathF.Ceiling(v) - 1;
            float next = Math.Min(y1, beamStart + (vStep - vv2) / (vv1 - vv2) * (beamEnd - beamStart));
            if (next <= y) {
                next = y1;
            }
            float tile = MathF.Floor(Math.Min(v, VAt(next)) + 1e-4F);
            float vBottom = VAt(y) - tile, vTop = VAt(next) - tile;
            ReadOnlySpan<Vector3> corners = [
                Vector3.Transform(new Vector3(wnx, next, wnz), matrix), Vector3.Transform(new Vector3(wnx, y, wnz), matrix),
                Vector3.Transform(new Vector3(enx, y, enz), matrix), Vector3.Transform(new Vector3(enx, next, enz), matrix)
            ];
            ReadOnlySpan<Vector2> uvs = [new(1, vTop), new(1, vBottom), new(0, vBottom), new(0, vTop)];
            sink.Quad(corners, uvs, normal, draw);
            y = next;
        }
    }
}
