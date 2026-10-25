using System.Numerics;
using ClientLib;
using ClientLib.Entities;
using ClientLib.Maths;
using ClientLib.World;

namespace GraphicalClient.Rendering.Entities;

/// <summary><c>EntityRenderState.LeashState</c>: one lead, from where it ties on to the holder's end.</summary>
public sealed class LeashState {
    public Vec3d Offset = Vec3d.Zero, Start = Vec3d.Zero, End = Vec3d.Zero;
    public int StartBlockLight, EndBlockLight, StartSkyLight = 15, EndSkyLight = 15;
    public bool Slack = true;
}

/// <summary><c>LeashFeatureRenderer</c>, and the leash half of <c>EntityRenderer.extractRenderState</c>.</summary>
public static class LeashFeatureRenderer {
    private const int LeashRenderSteps = 24;
    private const float LeashWidth = 0.05F;

    /// <summary>The leash states of <c>extractRenderState</c>: one lead, or four when both ends support a quad leash; null for none.</summary>
    public static List<LeashState>? Extract(ClientEntity entity, float partialTick, MinecraftClient client, ClientLevel level, List<LeashState>? states) {
        if (!Leashes.IsLeashable(entity) || Leashes.Holder(entity, client) is not { } roper) {
            return null;
        }
        float entityYRot = Leashes.PreciseBodyRotation(entity, partialTick) * (float)(Math.PI / 180.0);
        Vec3d attachOffset = Leashes.LeashOffset(entity, partialTick);
        (int ex, int ey, int ez) = Containing(EyePosition(entity, partialTick));
        (int rx, int ry, int rz) = Containing(EyePosition(roper, partialTick));
        int startBlockLight = entity.IsOnFire ? 15 : level.GetBlockLight(ex, ey, ez);
        int endBlockLight = roper.IsOnFire ? 15 : level.GetBlockLight(rx, ry, rz);
        int startSkyLight = level.GetSkyLight(ex, ey, ez);
        int endSkyLight = level.GetSkyLight(rx, ry, rz);
        bool quadConnection = Leashes.SupportQuadLeashAsHolder(roper) && Leashes.SupportQuadLeash(entity);
        int leashCount = quadConnection ? 4 : 1;
        if (states == null || states.Count != leashCount) {
            states = new List<LeashState>(leashCount);
            for (int i = 0; i < leashCount; i++) {
                states.Add(new LeashState());
            }
        }
        Vec3d position = Leashes.Position(entity, partialTick);
        if (quadConnection) {
            float roperYRot = Leashes.PreciseBodyRotation(roper, partialTick) * (float)(Math.PI / 180.0);
            Vec3d holderPos = Leashes.Position(roper, partialTick);
            Vec3d[] leashableAttachmentPoints = Leashes.QuadLeashOffsets(entity);
            Vec3d[] roperAttachmentPoints = Leashes.QuadLeashHolderOffsets(roper);
            for (int i = 0; i < leashCount; i++) {
                LeashState state = states[i];
                state.Offset = ClientEntity.YRotate(leashableAttachmentPoints[i], -entityYRot);
                state.Start = position + state.Offset;
                state.End = holderPos + ClientEntity.YRotate(roperAttachmentPoints[i], -roperYRot);
                (state.StartBlockLight, state.EndBlockLight, state.StartSkyLight, state.EndSkyLight) = (startBlockLight, endBlockLight, startSkyLight, endSkyLight);
                state.Slack = false;
            }
        }
        else {
            Vec3d rotatedAttachOffset = ClientEntity.YRotate(attachOffset, -entityYRot);
            LeashState state = states[0];
            state.Offset = rotatedAttachOffset;
            state.Start = position + rotatedAttachOffset;
            state.End = Leashes.RopeHoldPosition(roper, partialTick);
            (state.StartBlockLight, state.EndBlockLight, state.StartSkyLight, state.EndSkyLight) = (startBlockLight, endBlockLight, startSkyLight, endSkyLight);
        }
        return states;
    }

    private static Vec3d EyePosition(ClientEntity entity, float partialTick) => Leashes.Position(entity, partialTick) + new Vec3d(0, entity.CurrentEyeHeight, 0);

    private static (int, int, int) Containing(Vec3d v) => ((int)Math.Floor(v.X), (int)Math.Floor(v.Y), (int)Math.Floor(v.Z));

    /// <summary>
    /// <c>prepare</c>: a strip of quads forward and another back, crossed, that the leash pipeline shades
    /// flat, each quad in the colour and light of its far end, alternately darker.
    /// </summary>
    public static void Submit(PoseStack pose, LeashState leash, EntityBatch batch) {
        float dx = (float)(leash.End.X - leash.Start.X);
        float dy = (float)(leash.End.Y - leash.Start.Y);
        float dz = (float)(leash.End.Z - leash.Start.Z);
        float offsetFactor = (float)Minecraft.Schemas.Mth.InvSqrt(dx * dx + dz * dz) * LeashWidth / 2.0F;
        float dxOff = dz * offsetFactor;
        float dzOff = dx * offsetFactor;
        pose.Push();
        pose.Translate((float)leash.Offset.X, (float)leash.Offset.Y, (float)leash.Offset.Z);
        Matrix4x4 matrix = pose.Matrix;
        Span<Vector3> strip = stackalloc Vector3[(LeashRenderSteps + 1) * 4];
        Span<(uint Argb, int Block, int Sky)> looks = stackalloc (uint, int, int)[(LeashRenderSteps + 1) * 2];
        int pair = 0;
        for (int k = 0; k <= LeashRenderSteps; k++) {
            AddVertexPair(strip, looks, pair++, matrix, dx, dy, dz, LeashWidth, dxOff, dzOff, k, false, leash);
        }
        for (int k = LeashRenderSteps; k >= 0; k--) {
            AddVertexPair(strip, looks, pair++, matrix, dx, dy, dz, 0.0F, dxOff, dzOff, k, true, leash);
        }
        // The strip's triangles in pairs; GL's flat shading takes the last vertex's colour, the next pair's.
        ReadOnlySpan<Vector2> uvs = [new(0.5F, 0.5F), new(0.5F, 0.5F), new(0.5F, 0.5F), new(0.5F, 0.5F)];
        for (int p = 0; p + 1 < pair; p++) {
            (uint argb, int block, int sky) = looks[p + 1];
            ModelDrawState draw = new(batch.Textures.White, argb, sky, block, 0) { NoOutline = true };
            batch.Quad([strip[p * 2], strip[p * 2 + 1], strip[p * 2 + 3], strip[p * 2 + 2]], uvs, Vector3.UnitY, draw);
        }
        pose.Pop();
    }

    /// <summary><c>addVertexPair</c>.</summary>
    private static void AddVertexPair(Span<Vector3> strip, Span<(uint, int, int)> looks, int pair, Matrix4x4 pose, float dx, float dy, float dz, float fudge,
        float dxOff, float dzOff, int k, bool backwards, LeashState state) {
        float progress = k / 24.0F;
        int block = (int)Mth.Lerp(progress, state.StartBlockLight, state.EndBlockLight);
        int sky = (int)Mth.Lerp(progress, state.StartSkyLight, state.EndSkyLight);
        float colorModifier = k % 2 == (backwards ? 1 : 0) ? 0.7F : 1.0F;
        float r = 0.5F * colorModifier;
        float g = 0.4F * colorModifier;
        float b = 0.3F * colorModifier;
        float x = dx * progress;
        float y = state.Slack
            ? dy > 0.0F ? dy * progress * progress : dy - dy * (1.0F - progress) * (1.0F - progress)
            : dy * progress;
        float z = dz * progress;
        strip[pair * 2] = Vector3.Transform(new Vector3(x - dxOff, y + fudge, z + dzOff), pose);
        strip[pair * 2 + 1] = Vector3.Transform(new Vector3(x + dxOff, y + 0.05F - fudge, z - dzOff), pose);
        looks[pair] = (0xFF000000 | Channel(r) << 16 | Channel(g) << 8 | Channel(b), block, sky);
    }

    /// <summary><c>ARGB.colorFromFloat</c>'s channel: the float times 255, rounded down.</summary>
    private static uint Channel(float value) => (uint)(int)(value * 255.0F);
}
