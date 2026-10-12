using System.Numerics;
using ClientLib.Maths;
using ClientLib.World;
using ClientLib.World.BlockEntities;
using GraphicalClient.Rendering.Entities;
using GraphicalClient.Rendering.Entities.Special;
using Minecraft.Data.Blocks;

namespace GraphicalClient.Rendering.BlockEntities;

/// <summary><c>BlockEntityRendererProvider.Context</c>: what a renderer is built with.</summary>
public sealed class BlockEntityRendererContext {
    public required ISpriteGetter Sprites { get; init; }
    public required ItemRenderer Items { get; init; }
    public required BlockModelRenderer Blocks { get; init; }
    public required EntityRenderDispatcher Entities { get; init; }
    public required WorldText Font { get; init; }

    /// <summary><c>Options.getEffectiveRenderDistance</c>, in chunks.</summary>
    public required Func<int> RenderDistance { get; init; }
}

/// <summary><c>BlockEntityRenderState</c>: where the block is, its state, and the light it is drawn in.</summary>
public class BlockEntityRenderState {
    public int X, Y, Z;
    public IBlock State = null!;
    public float SkyLight, BlockLight;
}

/// <summary>The untyped face of a renderer, which the dispatcher holds.</summary>
public abstract class BlockEntityRenderer {
    /// <summary><c>getViewDistance</c>.</summary>
    public virtual int ViewDistance => 64;

    /// <summary><c>shouldRenderOffScreen</c>: drawn whether or not its block is in view, as a beacon's beam is.</summary>
    public virtual bool ShouldRenderOffScreen => false;

    /// <summary><c>shouldRender</c>: the block's centre closer than the view distance.</summary>
    public virtual bool ShouldRender(ClientBlockEntity blockEntity, Vec3d camera) =>
        new Vec3d(blockEntity.X + 0.5, blockEntity.Y + 0.5, blockEntity.Z + 0.5).DistanceToSqr(camera) < (double)ViewDistance * ViewDistance;

    /// <summary>Extracts and submits at once, translated to the block's corner relative to the camera.</summary>
    public abstract void Render(ClientBlockEntity blockEntity, EntityRenderContext context);

    /// <summary>
    /// <c>LightCoordsUtil.getLightCoords(level, pos)</c>: the sky and block light at the position, the
    /// block light raised to what the state itself gives off.
    /// </summary>
    public static (float Sky, float Block) LightAt(ClientLevel level, int x, int y, int z, IBlock state) =>
        (level.GetSkyLight(x, y, z), Math.Max(level.GetBlockLight(x, y, z), state.LightEmission));
}

/// <summary><c>BlockEntityRenderer</c>.</summary>
public abstract class BlockEntityRenderer<E, S> : BlockEntityRenderer where E : ClientBlockEntity where S : BlockEntityRenderState, new() {
    public sealed override void Render(ClientBlockEntity blockEntity, EntityRenderContext context) {
        S state = new();
        ExtractRenderState((E)blockEntity, state, context.PartialTick, context);
        Vec3d camera = context.Camera.Position;
        PoseStack pose = new();
        pose.Translate((float)(state.X - camera.X), (float)(state.Y - camera.Y), (float)(state.Z - camera.Z));
        Submit(state, pose, context);
    }

    /// <summary><c>extractRenderState</c>; the base is <c>BlockEntityRenderState.extractBase</c>.</summary>
    public virtual void ExtractRenderState(E blockEntity, S state, float partialTick, EntityRenderContext context) {
        state.X = blockEntity.X;
        state.Y = blockEntity.Y;
        state.Z = blockEntity.Z;
        state.State = blockEntity.State;
        (state.SkyLight, state.BlockLight) = LightAt(context.Level, blockEntity.X, blockEntity.Y, blockEntity.Z, blockEntity.State);
    }

    public abstract void Submit(S state, PoseStack pose, EntityRenderContext context);

    protected static ModelDrawState Draw(EntityTexture texture, BlockEntityRenderState state, uint argb = 0xFFFFFFFF) =>
        new(texture, argb, state.SkyLight, state.BlockLight, 0);
}

/// <summary>The transforms vanilla builds with JOML and the <c>Transformation</c> record, in this client's row vector order.</summary>
public static class BlockEntityTransforms {
    /// <summary><c>new Transformation(translation, leftRotation, scale, null)</c>.</summary>
    public static Matrix4x4 Transformation(Vector3 translation, Matrix4x4 leftRotation, Vector3 scale) =>
        Matrix4x4.CreateScale(scale) * leftRotation * Matrix4x4.CreateTranslation(translation);

    /// <summary><c>Axis.YP.rotationDegrees</c>.</summary>
    public static Matrix4x4 RotationYDegrees(float degrees) => Matrix4x4.CreateRotationY(degrees * Mth.DegToRad);

    /// <summary><c>Matrix4f.rotationAround(rotation, x, y, z)</c>: the turn about a point rather than the origin.</summary>
    public static Matrix4x4 RotationAround(Matrix4x4 rotation, float x, float y, float z) =>
        Matrix4x4.CreateTranslation(-x, -y, -z) * rotation * Matrix4x4.CreateTranslation(x, y, z);

    /// <summary><c>RotationSegment.convertToDegrees</c> for the sixteen standing rotations, wrapped into -180 to 180.</summary>
    public static float SegmentToDegrees(int segment) {
        float degrees = (segment & 15) * 22.5F;
        return degrees >= 180.0F ? degrees - 360.0F : degrees;
    }
}
