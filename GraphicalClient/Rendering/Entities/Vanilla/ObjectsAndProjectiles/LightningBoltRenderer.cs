using System.Numerics;
using ClientLib.Entities;
using GraphicalClient.Assets.ResourcePacks;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>LightningBoltRenderState</c>.</summary>
public class LightningBoltRenderState : EntityRenderState {
    public long Seed;
}

/// <summary><c>LightningBoltRenderer</c>.</summary>
public sealed class LightningBoltRenderer : EntityRenderer<LightningBoltRenderState> {
    /// <summary><c>LightningBolt.seed</c>, drawn from the client entity's own random as it is created.</summary>
    private sealed class Seed {
        public readonly long Value = Random.Shared.NextInt64();
    }

    /// <summary><c>LightningBolt.shouldRenderAtSqrDistance</c>.</summary>
    public override bool? ShouldRenderAtSqrDistance(ClientEntity entity, double distanceSqr) {
        double size = 64.0 * ViewScale;
        return distanceSqr < size * size;
    }

    public override bool AffectedByCulling(ClientEntity entity) => false;

    public override void ExtractRenderState(ClientEntity entity, LightningBoltRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        state.Seed = ((Seed)(entity.RendererData ??= new Seed())).Value;
    }

    public override void Submit(LightningBoltRenderState state, PoseStack pose, EntityRenderContext context) {
        float[] xOffs = new float[8];
        float[] zOffs = new float[8];
        float xOff = 0.0F;
        float zOff = 0.0F;
        JavaRandom random = new(state.Seed);
        for (int h = 7; h >= 0; h--) {
            xOffs[h] = xOff;
            zOffs[h] = zOff;
            xOff += random.NextInt(11) - 5;
            zOff += random.NextInt(11) - 5;
        }
        float finalXOff = xOff;
        float finalZOff = zOff;
        if (context.AdditiveBatch is not { } sink) {
            return;
        }
        Matrix4x4 poseMatrix = pose.Matrix;
        ModelDrawState draw = new(context.Textures.White, 0x4C72727F, 15, 15, 0) { NoOutline = true };
        for (int r = 0; r < 4; r++) {
            JavaRandom randomx = new(state.Seed);
            for (int p = 0; p < 3; p++) {
                int hs = 7;
                int ht = 0;
                if (p > 0) {
                    hs = 7 - p;
                }
                if (p > 0) {
                    ht = hs - 2;
                }
                float xo0 = xOffs[hs] - finalXOff;
                float zo0 = zOffs[hs] - finalZOff;
                for (int h = hs; h >= ht; h--) {
                    float xo1 = xo0;
                    float zo1 = zo0;
                    if (p == 0) {
                        xo0 += randomx.NextInt(11) - 5;
                        zo0 += randomx.NextInt(11) - 5;
                    }
                    else {
                        xo0 += randomx.NextInt(31) - 15;
                        zo0 += randomx.NextInt(31) - 15;
                    }
                    float rr1 = 0.1F + r * 0.2F;
                    if (p == 0) {
                        rr1 *= h * 0.1F + 1.0F;
                    }
                    float rr2 = 0.1F + r * 0.2F;
                    if (p == 0) {
                        rr2 *= (h - 1.0F) * 0.1F + 1.0F;
                    }
                    Quad(poseMatrix, sink, draw, xo0, zo0, h, xo1, zo1, rr1, rr2, false, false, true, false);
                    Quad(poseMatrix, sink, draw, xo0, zo0, h, xo1, zo1, rr1, rr2, true, false, true, true);
                    Quad(poseMatrix, sink, draw, xo0, zo0, h, xo1, zo1, rr1, rr2, true, true, false, true);
                    Quad(poseMatrix, sink, draw, xo0, zo0, h, xo1, zo1, rr1, rr2, false, true, false, false);
                }
            }
        }
    }

    /// <summary><c>quad</c>, its colour (0.45, 0.45, 0.5, 0.3) floored to bytes in <c>draw</c>.</summary>
    private static void Quad(Matrix4x4 pose, IModelSink sink, ModelDrawState draw, float xo0, float zo0, int h, float xo1, float zo1, float rr1, float rr2,
        bool px1, bool pz1, bool px2, bool pz2) {
        ReadOnlySpan<Vector3> corners = [
            Vector3.Transform(new Vector3(xo0 + (px1 ? rr2 : -rr2), h * 16, zo0 + (pz1 ? rr2 : -rr2)), pose),
            Vector3.Transform(new Vector3(xo1 + (px1 ? rr1 : -rr1), (h + 1) * 16, zo1 + (pz1 ? rr1 : -rr1)), pose),
            Vector3.Transform(new Vector3(xo1 + (px2 ? rr1 : -rr1), (h + 1) * 16, zo1 + (pz2 ? rr1 : -rr1)), pose),
            Vector3.Transform(new Vector3(xo0 + (px2 ? rr2 : -rr2), h * 16, zo0 + (pz2 ? rr2 : -rr2)), pose)
        ];
        ReadOnlySpan<Vector2> uvs = [Vector2.Zero, Vector2.Zero, Vector2.Zero, Vector2.Zero];
        sink.Quad(corners, uvs, Vector3.UnitY, draw);
    }
}
