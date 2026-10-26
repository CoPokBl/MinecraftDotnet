using ManagedServer.Entities.Types;
using ManagedServer.Pathfinding;
using ManagedServer.Worlds;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Ai.Util;

/// <summary>
/// Where a wandering mob decides to go, vanilla's <c>RandomPos</c> and <c>DefaultRandomPos</c>.
/// </summary>
public static class RandomPos {
    /// <summary>How many candidates a choice draws from, <c>RandomPos.generateRandomPos</c>.</summary>
    private const int Attempts = 10;

    /// <summary>
    /// <c>RandomPos.generateRandomDirection</c>: a uniform offset in a box, exactly as upstream. Note
    /// the range is inclusive on both sides, hence the <c>2 * radius + 1</c>, and the three draws
    /// happen in x, y, z order, which is what makes a seeded mob wander the same way vanilla's does.
    /// </summary>
    public static Vec3<int> GenerateRandomDirection(RandomSource random, int horizontal, int vertical) {
        int x = random.NextInt(2 * horizontal + 1) - horizontal;
        int y = random.NextInt(2 * vertical + 1) - vertical;
        int z = random.NextInt(2 * horizontal + 1) - horizontal;
        return new Vec3<int>(x, y, z);
    }

    /// <summary>
    /// Somewhere to stroll to, <c>DefaultRandomPos.getPos</c>.
    /// <p/>
    /// Ten candidates are drawn and the best scoring one wins, so this is a preference rather than a
    /// filter: a mob offered nothing but bad ground still picks the least bad. The draw always
    /// happens ten times whatever the answers are, which matters for anything replaying a seeded
    /// random.
    /// <p/>
    /// A candidate is rejected outright when it is outside the world, is not somewhere a mob could
    /// be left standing, or <b>costs anything at all</b>. That last test is
    /// <c>getPathfindingMalus(...) != 0</c>, not <c>&lt; 0</c>: water costs 8 and is refused as a
    /// destination even though a mob will happily path through it on the way to somewhere else.
    /// </summary>
    public static Vec3<double>? GetPos(Mob mob, int horizontal, int vertical) {
        World? world = mob.World;
        if (world == null) {
            return null;
        }

        PathfindingContext context = new(world, mob);

        double bestWeight = double.NegativeInfinity;
        Vec3<int>? best = null;

        for (int i = 0; i < Attempts; i++) {
            Vec3<int> direction = GenerateRandomDirection(mob.Random, horizontal, vertical);
            Vec3<int> pos = new(
                Mth.Floor(direction.X + mob.Position.X),
                Mth.Floor(direction.Y + mob.Position.Y),
                Mth.Floor(direction.Z + mob.Position.Z));

            if (IsOutsideLimits(world, pos) || IsNotStable(mob, pos) || HasMalus(mob, context, pos)) {
                continue;
            }

            // Vanilla scores with PathfinderMob.getWalkTargetValue, which is zero for every mob that
            // does not override it. The comparison is strictly greater, so with a flat score the
            // first acceptable candidate wins and the rest are drawn and discarded; that is the
            // behaviour reproduced here rather than an early return, because the discarded draws
            // still advance the random.
            const double walkTargetValue = 0.0;
            if (walkTargetValue > bestWeight) {
                bestWeight = walkTargetValue;
                best = pos;
            }
        }

        // Vec3.atBottomCenterOf: the middle of the block's floor.
        return best is { } chosen ? new Vec3<double>(chosen.X + 0.5, chosen.Y, chosen.Z + 0.5) : null;
    }

    private static bool IsOutsideLimits(World world, Vec3<int> pos) {
        return pos.Y < world.MinY || pos.Y >= world.MaxY;
    }

    /// <summary><c>GoalUtils.isNotStable</c>: nothing solid to stand on.</summary>
    private static bool IsNotStable(Mob mob, Vec3<int> pos) {
        return !mob.Navigation.IsStableDestination(pos);
    }

    /// <summary>
    /// <c>GoalUtils.hasMalus</c>. Compared against zero rather than against a sign, so anything the
    /// mob would rather not be in is refused as a place to stop.
    /// </summary>
    private static bool HasMalus(Mob mob, PathfindingContext context, Vec3<int> pos) {
        PathType type = WalkNodeEvaluator.GetPathTypeStatic(context, pos.X, pos.Y, pos.Z);
        return mob.GetPathfindingMalus(type) != 0.0f;
    }
}
