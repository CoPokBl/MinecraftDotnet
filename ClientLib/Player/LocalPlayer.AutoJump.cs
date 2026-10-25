using ClientLib.Maths;
using ClientLib.Physics;
using Minecraft.Data.Generated;
using Minecraft.Physics;
using Mth = Minecraft.Schemas.Mth;

namespace ClientLib.Player;

/// <summary><c>LocalPlayer.updateAutoJump</c>: a jump made for the player who walks into a step too tall to step up.</summary>
public sealed partial class LocalPlayer {
    private const float DegreesToRadians = (float)(Math.PI / 180.0);

    /// <summary><c>autoJumpEnabled</c>, which starts on and follows the option only from the end of each <c>sendPosition</c>.</summary>
    private bool _autoJumpEnabled = true;
    private int _autoJumpTime;
    private readonly List<Box> _autoJumpColliders = [];

    /// <summary>The <c>autoJump</c> option, which the host sets; the player reads it at the end of <c>sendPosition</c>.</summary>
    public bool AutoJumpOption { get; set; }

    /// <summary><c>LocalPlayer.updateAutoJump</c>, after a move of (<paramref name="xa"/>, <paramref name="za"/>).</summary>
    private void UpdateAutoJump(float xa, float za) {
        if (!CanAutoJump()) {
            return;
        }
        Vec3d moveBegin = Position;
        Vec3d moveEnd = moveBegin.Add(xa, 0.0, za);
        Vec3d moveDiff = new(xa, 0.0, za);
        float currentSpeed = Speed;
        float moveDistSq = (float)moveDiff.LengthSqr();
        if (moveDistSq <= 0.001F) {
            float inputXa = currentSpeed * _moveLeft;
            float inputZa = currentSpeed * _moveForward;
            float sin = Mth.Sin(YRot * DegreesToRadians);
            float cos = Mth.Cos(YRot * DegreesToRadians);
            moveDiff = new Vec3d(inputXa * cos - inputZa * sin, moveDiff.Y, inputZa * cos + inputXa * sin);
            moveDistSq = (float)moveDiff.LengthSqr();
            if (moveDistSq <= 0.001F) {
                return;
            }
        }

        // Mth.invSqrt(float), which JOML takes as 1 over the float square root.
        float moveDistInverted = 1.0F / (float)Math.Sqrt(moveDistSq);
        Vec3d moveDir = moveDiff * moveDistInverted;
        Vec3d facingDir3 = Forward();
        float facingVsMovingDotProduct2 = (float)(facingDir3.X * moveDir.X + facingDir3.Z * moveDir.Z);
        if (facingVsMovingDotProduct2 < -0.15F) {
            return;
        }

        EntityCollisionContext context = CollisionContext;
        (int X, int Y, int Z) ceilingPos = (BlockX, (int)Math.Floor(BoundingBox.MaxY), BlockZ);
        if (LevelCollisions.CollisionShapeAt(Level, ceilingPos.X, ceilingPos.Y, ceilingPos.Z, context).Length != 0) {
            return;
        }
        ceilingPos.Y++;
        if (LevelCollisions.CollisionShapeAt(Level, ceilingPos.X, ceilingPos.Y, ceilingPos.Z, context).Length != 0) {
            return;
        }

        float jumpHeight = 1.2F;
        if (GetEffect(PotionEffectType.JumpBoost) is { } jumpBoost) {
            jumpHeight += (jumpBoost.Amplifier + 1) * 0.75F;
        }
        float lookAheadDist = Math.Max(currentSpeed * 7.0F, 1.0F / moveDistInverted);
        Vec3d segEnd = moveEnd + moveDir * lookAheadDist;
        float playerWidth = BbWidth;
        float playerHeight = BbHeight;
        Vec3d boxEnd = segEnd.Add(0.0, playerHeight, 0.0);
        Box testBox = new Box(
            Math.Min(moveBegin.X, boxEnd.X), Math.Min(moveBegin.Y, boxEnd.Y), Math.Min(moveBegin.Z, boxEnd.Z),
            Math.Max(moveBegin.X, boxEnd.X), Math.Max(moveBegin.Y, boxEnd.Y), Math.Max(moveBegin.Z, boxEnd.Z)).Inflate(playerWidth, 0.0, playerWidth);
        Vec3d segBegin = moveBegin.Add(0.0, 0.51F, 0.0);
        segEnd = segEnd.Add(0.0, 0.51F, 0.0);
        Vec3d rightDir = Cross(moveDir, new Vec3d(0.0, 1.0, 0.0));
        Vec3d rightOffset = rightDir * (playerWidth * 0.5F);
        Vec3d leftSegBegin = segBegin - rightOffset;
        Vec3d leftSegEnd = segEnd - rightOffset;
        Vec3d rightSegBegin = segBegin + rightOffset;
        Vec3d rightSegEnd = segEnd + rightOffset;

        // Level.getCollisions: the entities' boxes, then the blocks', and no world border.
        List<Box> collisions = _autoJumpColliders;
        EntityCollisions.Collect(_client, this, testBox, collisions);
        LevelCollisions.BlockCollisionsInOrder(Level, testBox, collisions, context);
        float obstacleHeight = float.Epsilon;
        foreach (Box box in collisions) {
            if (!IntersectsSegment(box, leftSegBegin, leftSegEnd) && !IntersectsSegment(box, rightSegBegin, rightSegEnd)) {
                continue;
            }
            obstacleHeight = (float)box.MaxY;
            // BlockPos.containing(getCenter()), the centre as Mth.lerp(0.5, min, max).
            int obstacleX = (int)Math.Floor(box.MinX + 0.5 * (box.MaxX - box.MinX));
            int obstacleY = (int)Math.Floor(box.MinY + 0.5 * (box.MaxY - box.MinY));
            int obstacleZ = (int)Math.Floor(box.MinZ + 0.5 * (box.MaxZ - box.MinZ));
            for (int steps = 1; steps < jumpHeight; steps++) {
                int aboveY = obstacleY + steps;
                Box[] blockShape = LevelCollisions.CollisionShapeAt(Level, obstacleX, aboveY, obstacleZ, context);
                if (blockShape.Length != 0) {
                    obstacleHeight = (float)blockShape.Max(b => b.MaxY) + aboveY;
                    if (obstacleHeight - Position.Y > jumpHeight) {
                        return;
                    }
                }
                if (steps > 1) {
                    ceilingPos.Y++;
                    if (LevelCollisions.CollisionShapeAt(Level, ceilingPos.X, ceilingPos.Y, ceilingPos.Z, context).Length != 0) {
                        return;
                    }
                }
            }
            break;
        }

        // Float.MIN_VALUE, the smallest positive float, marks no obstacle found.
        if (obstacleHeight != float.Epsilon) {
            float ydelta = (float)(obstacleHeight - Position.Y);
            if (!(ydelta <= 0.5F) && !(ydelta > jumpHeight)) {
                _autoJumpTime = 1;
            }
        }
    }

    /// <summary><c>LocalPlayer.canAutoJump</c>.</summary>
    private bool CanAutoJump() =>
        _autoJumpEnabled
        && _autoJumpTime <= 0
        && OnGround
        && !KeyPresses.Shift
        && VehicleId == null
        && _moveLeft * _moveLeft + _moveForward * _moveForward > 0.0F
        && BlockJumpFactor() >= 1.0;

    /// <summary><c>Entity.getForward</c>: <c>Vec3.directionFromRotation</c> of the pitch and yaw.</summary>
    private Vec3d Forward() {
        float yCos = Mth.Cos(-YRot * DegreesToRadians - (float)Math.PI);
        float ySin = Mth.Sin(-YRot * DegreesToRadians - (float)Math.PI);
        float xCos = -Mth.Cos(-XRot * DegreesToRadians);
        float xSin = Mth.Sin(-XRot * DegreesToRadians);
        return new Vec3d(ySin * xCos, xSin, yCos * xCos);
    }

    private static Vec3d Cross(Vec3d a, Vec3d b) => new(a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z, a.X * b.Y - a.Y * b.X);

    /// <summary><c>AABB.intersects(Vec3, Vec3)</c>: against the box the two points span, not the segment between them.</summary>
    private static bool IntersectsSegment(Box box, Vec3d min, Vec3d max) =>
        box.Intersects(new Box(Math.Min(min.X, max.X), Math.Min(min.Y, max.Y), Math.Min(min.Z, max.Z),
            Math.Max(min.X, max.X), Math.Max(min.Y, max.Y), Math.Max(min.Z, max.Z)));
}
