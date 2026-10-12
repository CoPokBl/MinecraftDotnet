using ClientLib.Maths;

namespace ClientLib.World.BlockEntities;

/// <summary>A player as the block entity tickers search for one: where it is and whether it is alive. Spectators are left out.</summary>
public readonly record struct TickingPlayer(Vec3d Position, bool Alive);

/// <summary>What a client ticker reads besides its own block entity: the level, the players in it, and what a piston can push.</summary>
public sealed class BlockEntityTickContext(ClientLevel level, IReadOnlyList<TickingPlayer> players, IReadOnlyList<IPistonPushable>? pistonPushable = null) {
    public ClientLevel Level => level;

    public IReadOnlyList<IPistonPushable> PistonPushable => pistonPushable ?? [];

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
