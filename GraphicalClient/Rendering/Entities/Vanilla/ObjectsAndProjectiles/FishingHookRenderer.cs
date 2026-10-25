using System.Numerics;
using ClientLib.Entities;
using ClientLib.Maths;
using Minecraft.Data.Generated;
using Minecraft.Schemas;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>FishingHookRenderState</c>.</summary>
public class FishingHookRenderState : EntityRenderState {
    public bool HasPlayerOwner;
    public Vec3d LineOriginOffset = Vec3d.Zero;
}

/// <summary><c>FishingHookRenderer</c>.</summary>
public sealed class FishingHookRenderer : EntityRenderer<FishingHookRenderState> {
    private const string TextureLocation = "minecraft:textures/entity/fishing/fishing_hook.png";
    private const double ViewBobbingScale = 960.0;

    /// <summary><c>FishingHook.shouldRenderAtSqrDistance</c>.</summary>
    public override bool? ShouldRenderAtSqrDistance(ClientEntity entity, double distanceSqr) => distanceSqr < 4096.0;

    public override bool AffectedByCulling(ClientEntity entity) => false;

    public override void ExtractRenderState(ClientEntity entity, FishingHookRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        // getPlayerOwner: the spawn data names the owner's entity id.
        ClientEntity? owner = context.Client.Entities.TryGetValue(entity.SpawnData, out ClientEntity? found) && found.Is(EntityClass.Player) ? found : null;
        state.HasPlayerOwner = owner != null;
        if (owner == null) {
            state.LineOriginOffset = Vec3d.Zero;
            return;
        }
        float swing = owner.GetAttackAnim(partialTick);
        float swing2 = Mth.Sin(Mth.Sqrt(swing) * (float)Math.PI);
        Vec3d playerPos = GetPlayerHandPos(owner, swing2, partialTick, context);
        Vec3d hookPos = Leashes.Position(entity, partialTick) + new Vec3d(0.0, 0.25, 0.0);
        state.LineOriginOffset = playerPos - hookPos;
    }

    /// <summary><c>getHoldingArm</c>: the main arm while the main hand holds the rod, the other otherwise.</summary>
    private static HumanoidArm GetHoldingArm(ClientEntity owner) {
        HumanoidArm mainArm = owner.Get(EntityDataFields.Avatar.PlayerMainHand, HumanoidArm.Right);
        return owner.ItemInHand(Hand.MainHand).Is(Item.FishingRod) ? mainArm
            : mainArm == HumanoidArm.Right ? HumanoidArm.Left : HumanoidArm.Right;
    }

    /// <summary><c>getPlayerHandPos</c>: in first person, a point on the camera's near plane scaled out by the field of view.</summary>
    private static Vec3d GetPlayerHandPos(ClientEntity owner, float swing, float partialTicks, EntityRenderContext context) {
        int invert = GetHoldingArm(owner) == HumanoidArm.Right ? 1 : -1;
        Vec3d eye = Leashes.Position(owner, partialTicks) + new Vec3d(0.0, owner.CurrentEyeHeight, 0.0);
        if (context.FirstPerson && owner == context.Client.Player) {
            Camera camera = context.Camera;
            float fov = (int)camera.CullFovDegrees;
            double viewBobbingScale = ViewBobbingScale / fov;
            // Camera.getNearPlane(fov).getPointOnPlane(invert * 0.525F, -0.1F).
            double planeHeight = Math.Tan(fov * (float)(Math.PI / 180.0) / 2.0) * Camera.NearPlane;
            double planeWidth = planeHeight * camera.Aspect;
            Vector3 forwards = camera.Forward, up = camera.Up;
            Vector3 left = Vector3.Normalize(Vector3.Cross(up, forwards));
            Vec3d forward = new Vec3d(forwards.X, forwards.Y, forwards.Z) * Camera.NearPlane;
            Vec3d upScaled = new Vec3d(up.X, up.Y, up.Z) * planeHeight;
            Vec3d leftScaled = new Vec3d(left.X, left.Y, left.Z) * planeWidth;
            Vec3d point = forward + upScaled * -0.1F - leftScaled * (invert * 0.525F);
            Vec3d viewVec = ClientEntity.XRotate(ClientEntity.YRotate(point * viewBobbingScale, swing * 0.5F), -swing * 0.7F);
            return eye + viewVec;
        }
        float ownerYRot = Mth.Lerp(partialTicks, owner.YBodyRotO, owner.YBodyRot) * (float)(Math.PI / 180.0);
        double sin = Mth.Sin(ownerYRot);
        double cos = Mth.Cos(ownerYRot);
        float playerScale = (float)owner.Attributes.Value(Minecraft.Data.Generated.Attribute.Scale);
        double rightOffset = invert * 0.35 * playerScale;
        double forwardOffset = 0.8 * playerScale;
        float yOffset = owner.Get(EntityDataFields.Entity.Pose, Minecraft.Schemas.Entities.EntityPose.Standing) == Minecraft.Schemas.Entities.EntityPose.Sneaking
            ? -0.1875F : 0.0F;
        return eye + new Vec3d(-cos * rightOffset - sin * forwardOffset, yOffset - 0.45 * playerScale, -sin * rightOffset + cos * forwardOffset);
    }

    public override void Submit(FishingHookRenderState state, PoseStack pose, EntityRenderContext context) {
        // shouldRender: nothing without a player holding the rod.
        if (!state.HasPlayerOwner) {
            return;
        }
        pose.Push();
        pose.Push();
        pose.Scale(0.5F, 0.5F, 0.5F);
        CameraOrientation.Apply(pose, context.Camera);
        // vertex: (x - 0.5, y - 0.5, 0) for each corner.
        context.Batch.FlatQuad(pose, 0.0F - 0.5F, 0 - 0.5F, 1.0F - 0.5F, 1 - 0.5F, 0, 0, 1, 1, new ModelDrawState(context.Texture(TextureLocation), state) { NoOutline = true });
        pose.Pop();
        if (context.Lines is { } lines) {
            float xa = (float)state.LineOriginOffset.X, ya = (float)state.LineOriginOffset.Y, za = (float)state.LineOriginOffset.Z;
            Matrix4x4 matrix = pose.Matrix;
            for (int i = 0; i < 16; i++) {
                float a0 = Fraction(i, 16);
                float a1 = Fraction(i + 1, 16);
                (Vector3 p0, Vector3 n0) = StringVertex(xa, ya, za, matrix, a0, a1);
                (Vector3 p1, Vector3 n1) = StringVertex(xa, ya, za, matrix, a1, a0);
                lines.Line(p0, n0, p1, n1, 0xFF000000);
            }
        }
        pose.Pop();
    }

    private static float Fraction(int i, int steps) => (float)i / steps;

    /// <summary><c>stringVertex</c>: a point along the sagging line, and its normal toward the next.</summary>
    private static (Vector3 Position, Vector3 Normal) StringVertex(float xa, float ya, float za, Matrix4x4 pose, float aa, float nexta) {
        float x = xa * aa;
        float y = ya * (aa * aa + aa) * 0.5F + 0.25F;
        float z = za * aa;
        float nx = xa * nexta - x;
        float ny = ya * (nexta * nexta + nexta) * 0.5F + 0.25F - y;
        float nz = za * nexta - z;
        float length = Mth.Sqrt(nx * nx + ny * ny + nz * nz);
        nx /= length;
        ny /= length;
        nz /= length;
        return (Vector3.Transform(new Vector3(x, y, z), pose), Vector3.TransformNormal(new Vector3(nx, ny, nz), pose));
    }
}
