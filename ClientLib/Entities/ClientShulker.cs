using ClientLib.Maths;
using ClientLib.Physics;
using Minecraft.Data.Generated;
using Minecraft.Physics;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Entities.Meta;

namespace ClientLib.Entities;

/// <summary>
/// The client half of <c>Shulker</c>: the block centre it sits at, the peek it eases toward, the box
/// both make, which entities stand on, and the shove its lid gives the player as it opens.
/// </summary>
public sealed class ClientShulker : ClientEntity {
    private readonly MinecraftClient _client;
    private bool _placed;

    public float CurrentPeekAmount { get; private set; }
    public float CurrentPeekAmountO { get; private set; }
    public (int X, int Y, int Z)? ClientOldAttachPosition { get; private set; }
    public int ClientSideTeleportInterpolation { get; private set; }
    public (int X, int Y, int Z) BlockPosition { get; private set; }

    public ClientShulker(MinecraftClient client) {
        _client = client;
    }

    /// <summary><c>Shulker.setPos</c>: the centre of its block, unless it rides something.</summary>
    public Vec3d SnappedPosition => IsPassenger ? Position : new Vec3d(Math.Floor(Position.X) + 0.5, Math.Floor(Position.Y + 0.5), Math.Floor(Position.Z) + 0.5);

    public Cardinal AttachFace => Get(EntityDataFields.Shulker.AttachFace, Cardinal.Down);

    private float Scale => (float)Attributes.Value(Minecraft.Data.Generated.Attribute.Scale);

    /// <summary><c>Shulker.makeBoundingBox</c>.</summary>
    public override Box BoundingBox => ProgressDeltaAabb(Scale, Opposite(AttachFace), -1.0F, PhysicalPeek(CurrentPeekAmount), SnappedPosition);

    /// <summary><c>Shulker.getClientPeekAmount</c>.</summary>
    public float ClientPeekAmount(float a) => Mth.Lerp(a, CurrentPeekAmountO, CurrentPeekAmount);

    /// <summary><c>Shulker.getRenderPosition</c>: the slide from the old attach position after a teleport.</summary>
    public Vec3d? RenderPosition(float a) {
        if (ClientOldAttachPosition is not { } old || ClientSideTeleportInterpolation <= 0) {
            return null;
        }
        double scale = (ClientSideTeleportInterpolation - a) / 6.0;
        scale *= scale;
        scale *= Scale;
        return new Vec3d(-(BlockPosition.X - old.X) * scale, -(BlockPosition.Y - old.Y) * scale, -(BlockPosition.Z - old.Z) * scale);
    }

    /// <summary>
    /// <c>Shulker.tick</c>'s client half, after <c>setPos</c>'s teleport bookkeeping. Vanilla does that
    /// bookkeeping as each position arrives; here it runs on the position the tick starts at, which with
    /// no interpolation lands on the same blocks in the same ticks.
    /// </summary>
    public override void Tick() {
        Vec3d snapped = SnappedPosition;
        (int X, int Y, int Z) pos = ((int)Math.Floor(snapped.X), (int)Math.Floor(snapped.Y), (int)Math.Floor(snapped.Z));
        if (_placed && pos != BlockPosition) {
            Set(EntityDataFields.Shulker.Peek, MetaFieldType.Byte, (sbyte)0);
            if (!IsPassenger && pos != ClientOldAttachPosition) {
                ClientOldAttachPosition = BlockPosition;
                ClientSideTeleportInterpolation = 6;
            }
        }
        BlockPosition = pos;
        _placed = true;

        base.Tick();
        if (UpdatePeekAmount()) {
            OnPeekAmountChange();
        }
        if (ClientSideTeleportInterpolation > 0) {
            ClientSideTeleportInterpolation--;
        }
        else {
            ClientOldAttachPosition = null;
        }
    }

    /// <summary><c>Shulker.updatePeekAmount</c>.</summary>
    private bool UpdatePeekAmount() {
        CurrentPeekAmountO = CurrentPeekAmount;
        float targetPeekAmount = Get(EntityDataFields.Shulker.Peek) * 0.01F;
        if (CurrentPeekAmount == targetPeekAmount) {
            return false;
        }
        CurrentPeekAmount = CurrentPeekAmount > targetPeekAmount
            ? Mth.Clamp(CurrentPeekAmount - 0.05F, targetPeekAmount, 1.0F)
            : Mth.Clamp(CurrentPeekAmount + 0.05F, 0.0F, targetPeekAmount);
        return true;
    }

    /// <summary>
    /// <c>Shulker.onPeekAmountChange</c>. Of the entities it moves, only the local player is simulated
    /// here; everything else follows the server.
    /// </summary>
    private void OnPeekAmountChange() {
        float physicalPeek = PhysicalPeek(CurrentPeekAmount);
        float physicalPeekOld = PhysicalPeek(CurrentPeekAmountO);
        Cardinal direction = Opposite(AttachFace);
        float push = (physicalPeek - physicalPeekOld) * Scale;
        if (push <= 0.0F || _client.Player is not { NoPhysics: false, IsSpectator: false } player
            || EntityCollisions.IsPassengerOfSameVehicle(player, this)) {
            return;
        }
        if (ProgressDeltaAabb(Scale, direction, physicalPeekOld, physicalPeek, SnappedPosition).Intersects(player.BoundingBox)) {
            (int x, int y, int z) = Step(direction);
            player.ShulkerMove(new Vec3d(push * x, push * y, push * z));
        }
    }

    /// <summary><c>Shulker.getPhysicalPeek</c>.</summary>
    private static float PhysicalPeek(float amount) => 0.5F - Mth.Sin((0.5F + amount) * MathF.PI) * 0.5F;

    /// <summary><c>Shulker.getProgressDeltaAabb</c>.</summary>
    public static Box ProgressDeltaAabb(float size, Cardinal direction, float progressFrom, float progressTo, Vec3d position) {
        (int dx, int dy, int dz) = Step(direction);
        double maxMovement = Math.Max(progressFrom, progressTo);
        double minMovement = Math.Min(progressFrom, progressTo);
        Box box = new Box(-size * 0.5, 0.0, -size * 0.5, size * 0.5, size, size * 0.5)
            .ExpandTowards(dx * maxMovement * size, dy * maxMovement * size, dz * maxMovement * size);
        box = Contract(box, -dx * (1.0 + minMovement) * size, -dy * (1.0 + minMovement) * size, -dz * (1.0 + minMovement) * size);
        return box.Translate(position.X, position.Y, position.Z);
    }

    /// <summary><c>AABB.contract</c>.</summary>
    private static Box Contract(Box box, double xa, double ya, double za) {
        double minX = box.MinX, minY = box.MinY, minZ = box.MinZ, maxX = box.MaxX, maxY = box.MaxY, maxZ = box.MaxZ;
        if (xa < 0.0) minX -= xa; else if (xa > 0.0) maxX -= xa;
        if (ya < 0.0) minY -= ya; else if (ya > 0.0) maxY -= ya;
        if (za < 0.0) minZ -= za; else if (za > 0.0) maxZ -= za;
        return new Box(minX, minY, minZ, maxX, maxY, maxZ);
    }

    private static (int X, int Y, int Z) Step(Cardinal direction) => direction switch {
        Cardinal.Down => (0, -1, 0),
        Cardinal.Up => (0, 1, 0),
        Cardinal.North => (0, 0, -1),
        Cardinal.South => (0, 0, 1),
        Cardinal.West => (-1, 0, 0),
        _ => (1, 0, 0)
    };

    public static Cardinal Opposite(Cardinal face) => face switch {
        Cardinal.Down => Cardinal.Up,
        Cardinal.Up => Cardinal.Down,
        Cardinal.North => Cardinal.South,
        Cardinal.South => Cardinal.North,
        Cardinal.West => Cardinal.East,
        _ => Cardinal.West
    };
}
