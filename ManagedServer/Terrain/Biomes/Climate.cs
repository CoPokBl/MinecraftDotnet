using ManagedServer.Terrain.Density;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Biomes;

/// <summary>
/// A climate range, vanilla's <c>Climate.Parameter</c>. Both ends are <b>quantised</b>: a value of
/// 0.35 is stored as 3500.
/// </summary>
/// <remarks>
/// Quantised because the search compares squared distances and sums seven of them, and doing that in
/// floats loses the difference between two adjacent biome regions. So this is a long throughout, and
/// converting to a float anywhere in the search is how a biome boundary moves.
/// </remarks>
public readonly record struct ClimateParameter(long Min, long Max) {
    public const float QuantizationFactor = 10000.0f;

    public static long Quantize(float value) => (long)(value * QuantizationFactor);

    public static float Unquantize(long value) => value / QuantizationFactor;

    public static ClimateParameter Point(float value) => Span(value, value);

    public static ClimateParameter Span(float min, float max) {
        if (min > max) {
            throw new ArgumentException($"min > max: {min} {max}");
        }

        return new ClimateParameter(Quantize(min), Quantize(max));
    }

    /// <summary>How far a value is outside this range, or zero if it is inside.</summary>
    public long Distance(long target) {
        long above = target - Max;
        long below = Min - target;
        return above > 0L ? above : Math.Max(below, 0L);
    }

    /// <summary>The smallest range covering both, which is how a search tree's bounds are built.</summary>
    public ClimateParameter Span(ClimateParameter? other) {
        return other == null ? this : new ClimateParameter(Math.Min(Min, other.Value.Min), Math.Max(Max, other.Value.Max));
    }
}

/// <summary>
/// The climate a position has, vanilla's <c>Climate.TargetPoint</c>: six quantised noise values.
/// </summary>
public readonly record struct ClimateTargetPoint(long Temperature, long Humidity, long Continentalness,
    long Erosion, long Depth, long Weirdness);

/// <summary>
/// One region of climate space and the biome in it, vanilla's <c>Climate.ParameterPoint</c>.
/// </summary>
/// <remarks>
/// <see cref="Offset"/> is not a range: it is a fixed cost added to every distance, so a region with a
/// non zero offset only wins where nothing else is close. That is how the rare variants are kept rare
/// without carving them out of the other regions' ranges.
/// </remarks>
public sealed record ClimateParameterPoint(ClimateParameter Temperature, ClimateParameter Humidity,
    ClimateParameter Continentalness, ClimateParameter Erosion, ClimateParameter Depth,
    ClimateParameter Weirdness, long Offset) {

    public ClimateParameter[] ParameterSpace => [
        Temperature, Humidity, Continentalness, Erosion, Depth, Weirdness, new ClimateParameter(Offset, Offset)
    ];

    /// <summary>The squared distance from a position's climate to this region, lower being better.</summary>
    public long Fitness(ClimateTargetPoint target) {
        return Square(Temperature.Distance(target.Temperature))
            + Square(Humidity.Distance(target.Humidity))
            + Square(Continentalness.Distance(target.Continentalness))
            + Square(Erosion.Distance(target.Erosion))
            + Square(Depth.Distance(target.Depth))
            + Square(Weirdness.Distance(target.Weirdness))
            + Square(Offset);
    }

    private static long Square(long value) => value * value;
}

/// <summary>
/// The six climate functions bound to one sampler context, vanilla's <c>Climate.Sampler</c>.
/// </summary>
/// <remarks>
/// Takes <b>quart</b> coordinates, not block ones: biomes are stored one per 4x4x4 cell.
/// </remarks>
public sealed record ClimateSampler(BoundSampler Temperature, BoundSampler Humidity, BoundSampler Continentalness,
    BoundSampler Erosion, BoundSampler Depth, BoundSampler Weirdness) {

    public ClimateTargetPoint Sample(int quartX, int quartY, int quartZ) {
        int blockX = quartX << 2;
        int blockY = quartY << 2;
        int blockZ = quartZ << 2;
        return Target(
            Temperature.SampleValue(blockX, blockY, blockZ),
            Humidity.SampleValue(blockX, blockY, blockZ),
            Continentalness.SampleValue(blockX, blockY, blockZ),
            Erosion.SampleValue(blockX, blockY, blockZ),
            Depth.SampleValue(blockX, blockY, blockZ),
            Weirdness.SampleValue(blockX, blockY, blockZ));
    }

    /// <summary><c>Climate.target</c>.</summary>
    public static ClimateTargetPoint Target(float temperature, float humidity, float continentalness, float erosion,
        float depth, float weirdness) {

        return new ClimateTargetPoint(
            ClimateParameter.Quantize(temperature),
            ClimateParameter.Quantize(humidity),
            ClimateParameter.Quantize(continentalness),
            ClimateParameter.Quantize(erosion),
            ClimateParameter.Quantize(depth),
            ClimateParameter.Quantize(weirdness));
    }
}

/// <summary>
/// A set of climate regions and the search that picks one, vanilla's <c>Climate.ParameterList</c>.
/// </summary>
/// <remarks>
/// The overworld's list is 7599 regions, so the search is an R-tree over seven dimensional boxes
/// rather than a scan. <see cref="FindValueBruteForce"/> is the same answer the slow way, which is what
/// makes the tree testable.
/// </remarks>
public sealed class ClimateParameterList<T> {
    private readonly (ClimateParameterPoint Point, T Value)[] _values;
    private readonly RTreeNode _root;

    public ClimateParameterList(IReadOnlyList<(ClimateParameterPoint Point, T Value)> values) {
        if (values.Count == 0) {
            throw new ArgumentException("Need at least one value to build the search tree.", nameof(values));
        }

        _values = values.ToArray();
        _root = BuildTree(_values);
    }

    public IReadOnlyList<(ClimateParameterPoint Point, T Value)> Values => _values;

    /// <summary>
    /// The previous answer on this thread, which is what the next search starts from.
    /// </summary>
    /// <remarks>
    /// A search skips any node whose bounding box cannot beat the running best, so what it starts
    /// with decides how much of the tree it walks. Starting from nothing means the first few children
    /// are all descended into; starting from the last answer usually means starting inside the right
    /// region already, because consecutive queries are adjacent positions with almost the same
    /// climate. Vanilla holds it in a <c>ThreadLocal</c> for the same reason, and it is the answer's
    /// starting point rather than the answer, so it changes no result.
    /// </remarks>
    private readonly ThreadLocal<RTreeLeaf?> _lastResult = new();

    public T FindValue(ClimateTargetPoint target) {
        // The six values plus a zero, since a region also carries a seventh offset parameter that a
        // position never has. That asymmetry is what makes offset a pure penalty on a region.
        Span<long> parameters =
        [
            target.Temperature, target.Humidity, target.Continentalness,
            target.Erosion, target.Depth, target.Weirdness, 0L
        ];

        RTreeLeaf leaf = _root.Search(parameters, _lastResult.Value);
        _lastResult.Value = leaf;
        return leaf.Value;
    }

    /// <summary>The nearest region by a linear scan, which is what the tree has to agree with.</summary>
    public T FindValueBruteForce(ClimateTargetPoint target) {
        long bestFitness = _values[0].Point.Fitness(target);
        T best = _values[0].Value;

        for (int i = 1; i < _values.Length; i++) {
            long fitness = _values[i].Point.Fitness(target);
            if (fitness < bestFitness) {
                bestFitness = fitness;
                best = _values[i].Value;
            }
        }

        return best;
    }

    private const int Dimensions = 7;
    private const int ChildrenPerNode = 19;

    private abstract class RTreeNode(ClimateParameter[] parameterSpace) {
        public readonly ClimateParameter[] ParameterSpace = parameterSpace;

        /// <summary>The squared distance from a target to this node's bounding box.</summary>
        public long Distance(ReadOnlySpan<long> target) {
            long distance = 0L;
            for (int i = 0; i < Dimensions; i++) {
                long d = ParameterSpace[i].Distance(target[i]);
                distance += d * d;
            }

            return distance;
        }

        public abstract RTreeLeaf Search(ReadOnlySpan<long> target, RTreeLeaf? candidate);
    }

    private sealed class RTreeLeaf(ClimateParameterPoint point, T value) : RTreeNode(point.ParameterSpace) {
        public readonly T Value = value;

        public override RTreeLeaf Search(ReadOnlySpan<long> target, RTreeLeaf? candidate) => this;
    }

    private sealed class RTreeSubTree(ClimateParameter[] parameterSpace, RTreeNode[] children)
        : RTreeNode(parameterSpace) {

        public readonly RTreeNode[] Children = children;

        public override RTreeLeaf Search(ReadOnlySpan<long> target, RTreeLeaf? candidate) {
            long minDistance = candidate == null ? long.MaxValue : candidate.Distance(target);
            RTreeLeaf? closest = candidate;

            foreach (RTreeNode child in Children) {
                long childDistance = child.Distance(target);
                if (minDistance <= childDistance) {
                    continue;
                }

                RTreeLeaf leaf = child.Search(target, closest);

                // A child that is itself a leaf has already had its distance measured, so it is not
                // measured again.
                long leafDistance = ReferenceEquals(child, leaf) ? childDistance : leaf.Distance(target);
                if (minDistance > leafDistance) {
                    minDistance = leafDistance;
                    closest = leaf;
                }
            }

            // Never null: the root always has at least one child and every leaf answers itself.
            return closest!;
        }
    }

    private static RTreeNode BuildTree(IReadOnlyList<(ClimateParameterPoint Point, T Value)> values) {
        List<RTreeNode> leaves = [];
        foreach ((ClimateParameterPoint point, T value) in values) {
            leaves.Add(new RTreeLeaf(point, value));
        }

        return Build(leaves);
    }

    /// <summary>
    /// Groups nodes into a tree by the dimension that splits them most tightly.
    /// </summary>
    /// <remarks>
    /// Every dimension is tried, the children sorted along it and bucketed, and the split with the
    /// smallest total bounding box wins. The result is a shape, not an ordering, so this only has to
    /// produce a tree whose boxes contain their children; it does not have to match vanilla's node for
    /// node for the search to give the same answer.
    /// </remarks>
    private static RTreeNode Build(List<RTreeNode> children) {
        if (children.Count == 0) {
            throw new InvalidOperationException("Need at least one child to build a node");
        }

        if (children.Count == 1) {
            return children[0];
        }

        if (children.Count <= ChildrenPerNode) {
            children.Sort((a, b) => TotalMagnitude(a).CompareTo(TotalMagnitude(b)));
            return new RTreeSubTree(BuildParameterSpace(children), children.ToArray());
        }

        long minCost = long.MaxValue;
        int minDimension = -1;
        List<RTreeSubTree>? minBuckets = null;

        for (int d = 0; d < Dimensions; d++) {
            Sort(children, d, absolute: false);
            List<RTreeSubTree> buckets = Bucketize(children);

            long totalCost = 0L;
            foreach (RTreeSubTree bucket in buckets) {
                totalCost += Cost(bucket.ParameterSpace);
            }

            if (minCost > totalCost) {
                minCost = totalCost;
                minDimension = d;
                minBuckets = buckets;
            }
        }

        List<RTreeNode> bucketNodes = minBuckets!.Cast<RTreeNode>().ToList();
        Sort(bucketNodes, minDimension, absolute: true);

        List<RTreeNode> built = [];
        foreach (RTreeNode bucket in bucketNodes) {
            built.Add(Build([..((RTreeSubTree)bucket).Children]));
        }

        return new RTreeSubTree(BuildParameterSpace(built), built.ToArray());
    }

    private static long TotalMagnitude(RTreeNode node) {
        long total = 0L;
        for (int d = 0; d < Dimensions; d++) {
            ClimateParameter parameter = node.ParameterSpace[d];
            total += Math.Abs((parameter.Min + parameter.Max) / 2L);
        }

        return total;
    }

    /// <summary>
    /// Sorts by the centre along one dimension, then by every other dimension in turn as a tie break.
    /// The wrap around order of those tie breaks is vanilla's.
    /// </summary>
    private static void Sort(List<RTreeNode> children, int dimension, bool absolute) {
        children.Sort((a, b) => {
            for (int d = 0; d < Dimensions; d++) {
                int index = (dimension + d) % Dimensions;
                int comparison = Centre(a, index, absolute).CompareTo(Centre(b, index, absolute));
                if (comparison != 0) {
                    return comparison;
                }
            }

            return 0;
        });
    }

    private static long Centre(RTreeNode node, int dimension, bool absolute) {
        ClimateParameter parameter = node.ParameterSpace[dimension];
        long centre = (parameter.Min + parameter.Max) / 2L;
        return absolute ? Math.Abs(centre) : centre;
    }

    /// <summary>
    /// Splits a sorted list into buckets of the largest power of <see cref="ChildrenPerNode"/> that
    /// fits, which is what keeps the tree balanced.
    /// </summary>
    private static List<RTreeSubTree> Bucketize(List<RTreeNode> nodes) {
        List<RTreeSubTree> buckets = [];
        List<RTreeNode> children = [];

        int expectedChildrenCount = (int)Math.Pow(ChildrenPerNode,
            Math.Floor(Math.Log(nodes.Count - 0.01) / Math.Log(ChildrenPerNode)));

        foreach (RTreeNode child in nodes) {
            children.Add(child);
            if (children.Count >= expectedChildrenCount) {
                buckets.Add(new RTreeSubTree(BuildParameterSpace(children), children.ToArray()));
                children = [];
            }
        }

        if (children.Count > 0) {
            buckets.Add(new RTreeSubTree(BuildParameterSpace(children), children.ToArray()));
        }

        return buckets;
    }

    private static long Cost(ClimateParameter[] parameterSpace) {
        long result = 0L;
        foreach (ClimateParameter parameter in parameterSpace) {
            result += Math.Abs(parameter.Max - parameter.Min);
        }

        return result;
    }

    private static ClimateParameter[] BuildParameterSpace(List<RTreeNode> children) {
        if (children.Count == 0) {
            throw new ArgumentException("A subtree needs at least one child", nameof(children));
        }

        ClimateParameter?[] bounds = new ClimateParameter?[Dimensions];
        foreach (RTreeNode child in children) {
            for (int d = 0; d < Dimensions; d++) {
                bounds[d] = child.ParameterSpace[d].Span(bounds[d]);
            }
        }

        ClimateParameter[] result = new ClimateParameter[Dimensions];
        for (int d = 0; d < Dimensions; d++) {
            result[d] = bounds[d]!.Value;
        }

        return result;
    }
}

/// <summary>
/// A biome per position, from a climate sample and a region list. Vanilla's
/// <c>MultiNoiseBiomeSource</c>.
/// </summary>
public sealed class MultiNoiseBiomeSource(ClimateParameterList<Identifier> parameters) : IBiomeSource {
    private IReadOnlyList<Identifier>? _possible;

    public ClimateParameterList<Identifier> Parameters => parameters;

    /// <summary>
    /// Every biome this source can produce, vanilla's <c>possibleBiomes</c>.
    /// </summary>
    /// <remarks>
    /// First mention wins, because vanilla collects the parameter list into an <c>ImmutableSet</c> and
    /// that keeps insertion order. The order is not decoration: it is what the feature sorter breaks
    /// its ties by, so it decides where every feature of the dimension is placed. See
    /// <c>VanillaFeatureData.TableFor</c>.
    /// </remarks>
    public IReadOnlyList<Identifier> PossibleBiomes {
        get {
            if (_possible is not null) {
                return _possible;
            }

            List<Identifier> possible = [];
            HashSet<Identifier> seen = [];

            foreach ((ClimateParameterPoint _, Identifier biome) in parameters.Values) {
                if (seen.Add(biome)) {
                    possible.Add(biome);
                }
            }

            return _possible = possible;
        }
    }

    /// <summary>Quart coordinates, as <see cref="ClimateSampler.Sample"/> takes.</summary>
    public Identifier GetBiome(int quartX, int quartY, int quartZ, ClimateSampler sampler) {
        return parameters.FindValue(sampler.Sample(quartX, quartY, quartZ));
    }

    /// <summary>
    /// <c>createResolverForChunk</c>: the six climate functions sampled as volumes over a chunk's quart
    /// grid, then answered from the buffers. The volume path rounds differently from the point path,
    /// so a chunk's stored biomes are not always what <see cref="GetBiome"/> says for the same cells.
    /// </summary>
    public Func<int, int, int, Identifier> ResolverForChunk(ClimateSampler sampler, int minQuartX, int minQuartY, int minQuartZ,
        int quartSizeX, int quartSizeY, int quartSizeZ) {

        DensityVolume volume = new(quartSizeX, quartSizeY, quartSizeZ, minQuartX << 2, minQuartY << 2, minQuartZ << 2, 4, 4, 4);
        DensityBuffer temperature = DensityBuffer.CreateUnpooled(volume.Size);
        DensityBuffer vegetation = DensityBuffer.CreateUnpooled(volume.Size);
        DensityBuffer continents = DensityBuffer.CreateUnpooled(volume.Size);
        DensityBuffer erosion = DensityBuffer.CreateUnpooled(volume.Size);
        DensityBuffer depth = DensityBuffer.CreateUnpooled(volume.Size);
        DensityBuffer ridges = DensityBuffer.CreateUnpooled(volume.Size);
        sampler.Temperature.SampleVolume(temperature, volume);
        sampler.Humidity.SampleVolume(vegetation, volume);
        sampler.Continentalness.SampleVolume(continents, volume);
        sampler.Erosion.SampleVolume(erosion, volume);
        sampler.Depth.SampleVolume(depth, volume);
        sampler.Weirdness.SampleVolume(ridges, volume);

        return (quartX, quartY, quartZ) => {
            int index = volume.IndexUnchecked(quartX - minQuartX, quartY - minQuartY, quartZ - minQuartZ);
            return parameters.FindValue(ClimateSampler.Target(temperature[index], vegetation[index], continents[index],
                erosion[index], depth[index], ridges[index]));
        };
    }
}
