using ClientLib.Maths;
using Minecraft.Data.Entities;
using Minecraft.Physics;

namespace ClientLib.World.BlockEntities;

/// <summary>A player as the block entity tickers search for one: where it is and whether it is alive. Spectators are left out.</summary>
public readonly record struct TickingPlayer(Vec3d Position, bool Alive);

/// <summary>
/// What a client ticker reads besides its own block entity: the level, the players in it, the entities whose
/// movement this client runs, and the client, whose particles and entities the tickers that spawn particles use.
/// </summary>
public sealed class BlockEntityTickContext(ClientLevel level, IReadOnlyList<TickingPlayer> players, IReadOnlyList<IBlockEntityMovable>? movable = null,
    MinecraftClient? client = null) {
    public ClientLevel Level => level;

    /// <summary>Null for a level ticked without a client, which shows no particles.</summary>
    public MinecraftClient? Client => client;

    /// <summary>The particles, when they are being drawn: a ticker skips its particle work otherwise.</summary>
    public Particles.ParticleEngine? Particles => client?.Particles is { Enabled: true } particles ? particles : null;

    /// <summary>
    /// The entities a ticker's <c>getEntities</c> could find and move here: vanilla moves every entity, and one the
    /// server positions would only be put back by its interpolation.
    /// </summary>
    public IReadOnlyList<IBlockEntityMovable> Movable => movable ?? [];

    /// <summary><c>EntityGetter.getNearestPlayer(x, y, z, maxDist, false)</c>: <c>NO_SPECTATORS</c>, so the dead count.</summary>
    public Vec3d? NearestPlayer(double x, double y, double z, double maxDist) {
        double best = -1.0;
        Vec3d? result = null;
        foreach (TickingPlayer player in players) {
            double distance = player.Position.DistanceToSqr(new Vec3d(x, y, z));
            if ((maxDist < 0.0 || distance < maxDist * maxDist) && (best == -1.0 || distance < best)) {
                best = distance;
                result = player.Position;
            }
        }
        return result;
    }

    /// <summary><c>EntityGetter.hasNearbyAlivePlayer</c>.</summary>
    public bool HasNearbyAlivePlayer(double x, double y, double z, double range) {
        foreach (TickingPlayer player in players) {
            if (player.Alive && (range < 0.0 || player.Position.DistanceToSqr(new Vec3d(x, y, z)) < range * range)) {
                return true;
            }
        }
        return false;
    }
}

/// <summary>An entity whose movement this client runs itself, as the block entity tickers move one.</summary>
public interface IBlockEntityMovable {
    Box BoundingBox { get; }
    Vec3d Position { get; }
    Vec3d DeltaMovement { get; set; }
    bool OnGround { get; }
    IEntityType Type { get; }
    bool IsPassenger { get; }

    /// <summary><c>Entity.canSimulateMovement</c> on a client.</summary>
    bool IsLocalInstanceAuthoritative { get; }

    /// <summary><c>EntitySelector.NO_SPECTATORS.and(ENTITY_STILL_ALIVE)</c>.</summary>
    bool IsAliveAndNotSpectator { get; }

    /// <summary><c>Entity.isSupportedBy</c>.</summary>
    bool IsSupportedBy(int x, int y, int z);

    /// <summary>
    /// What <c>PistonMovingBlockEntity.moveEntityByPiston</c> calls on the entity: <c>move(MoverType.PISTON)</c>,
    /// then <c>applyEffectsFromBlocks</c> from where it was, then <c>removeLatestMovementRecording</c>.
    /// </summary>
    void MoveByPiston(Vec3d delta);

    /// <summary><c>move(MoverType.SHULKER_BOX, delta)</c>.</summary>
    void MoveByShulkerBox(Vec3d delta);

    /// <summary><c>Entity.checkFallDistanceAccumulation</c>.</summary>
    void CheckFallDistanceAccumulation();
}
