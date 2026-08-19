using ManagedServer.Terrain.Features.Blocks;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Features.Trees;

/// <summary>
/// <c>TreeFeature</c>: grows one tree.
/// </summary>
/// <remarks>
/// The order is fixed and each step feeds the next: the trunk placer decides the height and hands back
/// attachment points, the foliage placer grows leaves from those, the decorators read both sets, and a
/// final pass numbers the leaves by their distance from the nearest log so the client draws and decays
/// them correctly.
/// <p/>
/// The space check happens before anything is written, and a tree that does not fit is <b>not</b>
/// truncated unless its feature size says it may be.
/// </remarks>
public sealed record TreeFeature(TreeConfiguration Config) : ConfiguredFeature {
    public static readonly Identifier LogsTag = "minecraft:logs";
    public static readonly Identifier LeavesTag = "minecraft:leaves";
    public static readonly Identifier ReplaceableByTreesTag = "minecraft:replaceable_by_trees";

    /// <summary>How far a leaf may be from a log before it decays, and so the highest distance stored.</summary>
    private const int MaxLeafDistance = 7;

    /// <summary><c>TreeFeature.validTreePos</c>: somewhere a tree may write.</summary>
    public static bool ValidTreePos(IFeatureLevel level, Vec3<int> pos) {
        uint state = level.GetState(pos.X, pos.Y, pos.Z);
        return level.Blocks.IsAir(state) || level.Blocks.IsIn(ReplaceableByTreesTag, state);
    }

    /// <summary><c>TreeFeature.isAirOrLeaves</c>, which is a wider test than the one above.</summary>
    public static bool IsAirOrLeaves(IFeatureLevel level, Vec3<int> pos) {
        uint state = level.GetState(pos.X, pos.Y, pos.Z);
        return level.Blocks.IsAir(state) || level.Blocks.IsIn(LeavesTag, state);
    }

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;

        TreeWriter writer = new(level);

        if (!DoPlace(level, writer, random, context.Origin)) {
            return false;
        }

        if (writer.Trunks.Count == 0 && writer.Foliage.Count == 0) {
            return false;
        }

        if (Config.Decorators.Count > 0) {
            TreeDecoratorContext decorators = new(context.Placement, writer, random,
                SortedByY(writer.Trunks), SortedByY(writer.Foliage), SortedByY(writer.Roots));

            foreach (TreeDecorator decorator in Config.Decorators) {
                decorator.Place(decorators);
            }
        }

        UpdateLeaves(level, writer);
        return true;
    }

    /// <summary>
    /// <c>doPlace</c>: work out the shape, check the space, then write roots, trunk and foliage.
    /// </summary>
    /// <remarks>
    /// The four draws at the top happen before the space check, so a tree that does not fit still
    /// consumes the same randomness as one that does.
    /// </remarks>
    private bool DoPlace(IFeatureLevel level, TreeWriter writer, RandomSource random, Vec3<int> origin) {
        int treeHeight = Config.TrunkPlacer.GetTreeHeight(random);
        int foliageHeight = Config.FoliagePlacer.FoliageHeight(random, treeHeight, Config);
        int trunkHeight = treeHeight - foliageHeight;
        int leafRadius = Config.FoliagePlacer.FoliageRadius(random, trunkHeight);

        Vec3<int> trunkOrigin = Config.RootPlacer is { } roots
            ? roots.GetTrunkOrigin(origin, random)
            : origin;

        int minY = Math.Min(origin.Y, trunkOrigin.Y);
        int maxY = Math.Max(origin.Y, trunkOrigin.Y) + treeHeight + 1;

        if (minY < level.MinY + 1 || maxY > level.MaxY + 1) {
            return false;
        }

        int clippedHeight = GetMaxFreeTreeHeight(level, treeHeight, trunkOrigin);
        if (clippedHeight < treeHeight
            && (Config.MinimumSize.MinClippedHeight is not { } minClipped || clippedHeight < minClipped)) {

            return false;
        }

        if (Config.RootPlacer is { } rootPlacer
            && !rootPlacer.PlaceRoots(level, writer, random, origin, trunkOrigin, Config)) {

            return false;
        }

        IReadOnlyList<FoliageAttachment> attachments = Config.TrunkPlacer.PlaceTrunk(level, writer, random,
            clippedHeight, trunkOrigin, Config);

        foreach (FoliageAttachment attachment in attachments) {
            Config.FoliagePlacer.CreateFoliage(level, writer, random, Config, clippedHeight, attachment,
                foliageHeight, leafRadius);
        }

        return true;
    }

    /// <summary>
    /// How tall the tree can be here: a scan up the column of the width its feature size asks for,
    /// stopping two blocks below whatever is in the way.
    /// </summary>
    /// <remarks>
    /// The <c>- 2</c> is vanilla's and is not an off by one: one for the block that blocked it and one
    /// so the canopy is not pressed against the ceiling.
    /// </remarks>
    private int GetMaxFreeTreeHeight(IFeatureLevel level, int maxTreeHeight, Vec3<int> treePos) {
        for (int y = 0; y <= maxTreeHeight + 1; y++) {
            int radius = Config.MinimumSize.GetSizeAtHeight(maxTreeHeight, y);

            for (int x = -radius; x <= radius; x++) {
                for (int z = -radius; z <= radius; z++) {
                    Vec3<int> pos = treePos + new Vec3<int>(x, y, z);

                    if (!Config.TrunkPlacer.IsFree(level, pos)
                        || (!Config.IgnoreVines && IsVine(level, pos))) {

                        return y - 2;
                    }
                }
            }
        }

        return maxTreeHeight;
    }

    private static bool IsVine(IFeatureLevel level, Vec3<int> pos) {
        return level.Registry.Blocks.GetByStateId(level.GetState(pos.X, pos.Y, pos.Z)).Identifier
            .Equals(Minecraft.Data.Generated.Block.Vine.Identifier);
    }

    /// <summary>
    /// Numbers every leaf by how far it is from the nearest log, which is what
    /// <c>LeavesBlock.DISTANCE</c> holds and what makes an orphaned canopy decay.
    /// </summary>
    /// <remarks>
    /// A breadth first walk out of the logs, bucketed by distance, so a leaf reachable two ways gets
    /// the smaller number. Roots and decorations are pre-filled into the visited set rather than being
    /// walked from, because they are not logs and must not seed a distance of zero.
    /// <p/>
    /// Bounded by the tree's own box, so the walk cannot wander into a neighbouring tree. Vanilla then
    /// calls <c>StructureTemplate.updateShapeAtEdge</c>, which reconciles the surface of that box with
    /// what is around it. It is not ported and does not need to be: what it does for a leaf is schedule
    /// a tick, and the tick's answer is the minimum this walk already takes.
    /// </remarks>
    private static void UpdateLeaves(IFeatureLevel level, TreeWriter writer) {
        if (!BoundsOf(writer, out Vec3<int> min, out Vec3<int> max)) {
            return;
        }

        // Roots and decorations count as already visited rather than as sources: they are not logs, so
        // a leaf beside one must not come out at distance one.
        FeatureShape shape = new(min, max);

        // Plain sets rather than JavaHashSet, and that is a consequence of taking the minimum below.
        // Upstream the bucket a position is pulled out of decides what it is numbered, so the set's
        // order is part of the answer; here every position is settled to its true distance from the
        // trunk however the buckets are walked, so nothing reads an order.
        HashSet<Vec3<int>> visited = [];
        foreach (Vec3<int> pos in writer.Roots) {
            if (Inside(pos, min, max)) {
                visited.Add(pos);
                shape.Fill(pos);
            }
        }

        foreach (Vec3<int> pos in writer.Decorations) {
            if (Inside(pos, min, max)) {
                visited.Add(pos);
                shape.Fill(pos);
            }
        }

        List<HashSet<Vec3<int>>> byDistance = [];
        for (int i = 0; i < MaxLeafDistance; i++) {
            byDistance.Add([]);
        }

        foreach (Vec3<int> trunk in writer.Trunks) {
            byDistance[0].Add(trunk);
        }

        int smallest = 0;

        while (true) {
            while (smallest >= MaxLeafDistance || byDistance[smallest].Count > 0) {
                if (smallest >= MaxLeafDistance) {
                    shape.UpdateShapeAtEdge(level);
                    return;
                }

                Vec3<int> pos = byDistance[smallest].First();
                byDistance[smallest].Remove(pos);

                if (!Inside(pos, min, max)) {
                    continue;
                }

                if (smallest != 0) {
                    IBlock state = level.Registry.Blocks.GetByStateId(level.GetState(pos.X, pos.Y, pos.Z));

                    // The smaller of the two, where vanilla writes this walk's number over whatever is
                    // there. A position reached at one distance is reachable again at a larger one,
                    // because a sibling in the same bucket scans it before it has been given its own
                    // number, so upstream really does leave leaves further from the trunk than they
                    // are. What repairs it there is the tick: updateShapeAtEdge schedules one over the
                    // whole surface, LeavesBlock.updateShape schedules one wherever a leaf disagrees
                    // with a neighbour, and LeavesBlock.tick settles each to min(neighbour) + 1.
                    // Taking the minimum here lands on that fixed point in the one pass, which is the
                    // state the client is sent and the state a saved chunk holds.
                    if (state is IDistanced distanced) {
                        level.SetState(pos.X, pos.Y, pos.Z,
                            distanced.WithDistance(Math.Min(distanced.Distance, smallest)).StateId);
                    }
                }

                visited.Add(pos);
                shape.Fill(pos);

                foreach (Vec3<int> step in Neighbours) {
                    Vec3<int> neighbour = pos + step;
                    if (!Inside(neighbour, min, max) || visited.Contains(neighbour)) {
                        continue;
                    }

                    IBlock neighbourState = level.Registry.Blocks
                        .GetByStateId(level.GetState(neighbour.X, neighbour.Y, neighbour.Z));

                    if (neighbourState is not IDistanced existing) {
                        continue;
                    }

                    int newDistance = Math.Min(existing.Distance, smallest + 1);
                    if (newDistance < MaxLeafDistance) {
                        byDistance[newDistance].Add(neighbour);

                        // A shorter route found part way through the neighbour scan takes effect for
                        // the rest of that scan too, which is why this is not a break.
                        smallest = Math.Min(smallest, newDistance);
                    }
                }
            }

            smallest++;
        }
    }

    /// <summary>
    /// The box encapsulating everything the tree wrote, which is what bounds the leaf distance walk so
    /// it cannot wander into a neighbouring tree.
    /// </summary>
    private static bool BoundsOf(TreeWriter writer, out Vec3<int> min, out Vec3<int> max) {
        min = default;
        max = default;
        bool any = false;

        foreach (JavaHashSet<Vec3<int>> set in (JavaHashSet<Vec3<int>>[])
            [writer.Roots, writer.Trunks, writer.Foliage, writer.Decorations]) {

            foreach (Vec3<int> pos in set) {
                if (!any) {
                    min = pos;
                    max = pos;
                    any = true;
                    continue;
                }

                min = new Vec3<int>(Math.Min(min.X, pos.X), Math.Min(min.Y, pos.Y), Math.Min(min.Z, pos.Z));
                max = new Vec3<int>(Math.Max(max.X, pos.X), Math.Max(max.Y, pos.Y), Math.Max(max.Z, pos.Z));
            }
        }

        return any;
    }

    private static bool Inside(Vec3<int> pos, Vec3<int> min, Vec3<int> max) {
        return pos.X >= min.X && pos.X <= max.X && pos.Y >= min.Y && pos.Y <= max.Y
            && pos.Z >= min.Z && pos.Z <= max.Z;
    }

    private static readonly Vec3<int>[] Neighbours = [
        new(0, -1, 0), new(0, 1, 0), new(0, 0, -1), new(0, 0, 1), new(-1, 0, 0), new(1, 0, 0)
    ];

    /// <summary>
    /// The list a decorator walks: <c>new ObjectArrayList&lt;&gt;(set)</c> sorted by y alone.
    /// </summary>
    /// <remarks>
    /// <b>Stable, and over a set that iterates in Java's order.</b> Sorting on y alone leaves every
    /// position sharing a y in the order the set gave them, and a decorator draws a fixed number of
    /// values per entry, so which block each draw lands on is decided entirely here.
    /// <c>List.Sort</c> is an introsort and reorders equal elements, so it cannot be used.
    /// </remarks>
    private static List<Vec3<int>> SortedByY(IEnumerable<Vec3<int>> positions) {
        return positions.OrderBy(pos => pos.Y).ToList();
    }

    /// <summary>
    /// Keeps the four sets of positions the decorators and the leaf distance pass need, and writes
    /// through to the level as it goes.
    /// </summary>
    private sealed class TreeWriter(IFeatureLevel level) : ITreeWriter {
        public readonly JavaHashSet<Vec3<int>> Roots = FeatureUtil.PositionSet();
        public readonly JavaHashSet<Vec3<int>> Trunks = FeatureUtil.PositionSet();
        public readonly JavaHashSet<Vec3<int>> Foliage = FeatureUtil.PositionSet();
        public readonly JavaHashSet<Vec3<int>> Decorations = FeatureUtil.PositionSet();

        public void SetRoot(Vec3<int> pos, IBlock state) {
            Roots.Add(pos);
            Write(pos, state);
        }

        public void SetTrunk(Vec3<int> pos, IBlock state) {
            Trunks.Add(pos);
            Write(pos, state);
        }

        public void SetFoliage(Vec3<int> pos, IBlock state) {
            Foliage.Add(pos);
            Write(pos, state);
        }

        public void SetDecoration(Vec3<int> pos, IBlock state) {
            Decorations.Add(pos);
            Write(pos, state);
        }

        public bool IsFoliageSet(Vec3<int> pos) => Foliage.Contains(pos);

        private void Write(Vec3<int> pos, IBlock state) {
            level.SetState(pos.X, pos.Y, pos.Z, state.StateId);
        }
    }
}
