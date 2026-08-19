using ManagedServer.Terrain.Features;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Structures;

/// <summary>
/// How the roll that thins a structure set out is done, vanilla's
/// <c>StructurePlacement.FrequencyReductionMethod</c>.
/// </summary>
/// <remarks>
/// Three of the four exist only to keep old worlds generating the same structures they always did,
/// and each is a different way of seeding one roll. They are not interchangeable: a mineshaft uses
/// <see cref="LegacyType3"/>, which draws a double from a plain large feature seed, and a buried
/// treasure uses <see cref="LegacyType2"/>, whose salt is a constant that has nothing to do with the
/// set's own.
/// </remarks>
public enum FrequencyReductionMethod {
    Default,
    LegacyType1,
    LegacyType2,
    LegacyType3
}

/// <summary>How a random spread picks a position inside its cell.</summary>
public enum RandomSpreadType {
    Linear,
    Triangular
}

/// <summary>
/// A set whose chunks this one may not be placed near, vanilla's <c>ExclusionZone</c>.
/// </summary>
/// <remarks>
/// The only user is the pillager outposts set, which keeps out of ten chunks of any village. Testing
/// it means running the other set's placement over a square of chunks, so it is deliberately the last
/// of the three tests <see cref="StructurePlacement.IsStructureChunk"/> does.
/// </remarks>
public sealed record ExclusionZone(Identifier OtherSet, int ChunkCount);

/// <summary>
/// <c>StructurePlacement</c>: which chunks a structure set is allowed to start in.
/// </summary>
/// <remarks>
/// This is the cheap half of the structure pass and the reason it is affordable at all. Every chunk
/// generated replays the 289 source chunks around it against every set, and almost all of those are
/// rejected here by arithmetic rather than by building anything.
/// </remarks>
public abstract class StructurePlacement(Vec3<int> locateOffset, FrequencyReductionMethod reduction,
    float frequency, int salt, ExclusionZone? exclusionZone) {

    /// <summary>
    /// <c>HIGHLY_ARBITRARY_RANDOM_SALT</c>, which is exactly what its name says: a constant that
    /// <see cref="FrequencyReductionMethod.LegacyType2"/> uses in place of the set's own salt.
    /// </summary>
    private const int HighlyArbitraryRandomSalt = 10387320;

    public Vec3<int> LocateOffset => locateOffset;
    public FrequencyReductionMethod Reduction => reduction;
    public float Frequency => frequency;
    public int Salt => salt;
    public ExclusionZone? ExclusionZone => exclusionZone;

    /// <summary>
    /// Whether a structure of this set starts in the chunk: the spacing test, then the frequency
    /// roll, then the exclusion zone.
    /// </summary>
    /// <remarks>
    /// The order is vanilla's and it is also the cheap one, since the spacing test rejects almost
    /// everything and the exclusion zone is itself a loop over another set's placements.
    /// </remarks>
    public bool IsStructureChunk(IStructurePlacementState state, int sourceX, int sourceZ) {
        return IsPlacementChunk(state, sourceX, sourceZ)
            && PassesFrequency(sourceX, sourceZ, state.LevelSeed)
            && PassesExclusionZone(state, sourceX, sourceZ);
    }

    protected abstract bool IsPlacementChunk(IStructurePlacementState state, int sourceX, int sourceZ);

    /// <summary>The frequency roll, skipped entirely for a set that keeps every chunk it picks.</summary>
    private bool PassesFrequency(int sourceX, int sourceZ, long levelSeed) {
        return frequency >= 1.0f || ShouldGenerate(levelSeed, sourceX, sourceZ);
    }

    private bool PassesExclusionZone(IStructurePlacementState state, int sourceX, int sourceZ) {
        return exclusionZone is null
            || !state.HasStructureChunkInRange(exclusionZone.OtherSet, sourceX, sourceZ,
                exclusionZone.ChunkCount);
    }

    /// <summary>
    /// The four reducers. Each seeds one roll differently, and which one a set uses is part of what
    /// decides where its structures are.
    /// </summary>
    private bool ShouldGenerate(long seed, int sourceX, int sourceZ) {
        WorldgenRandom random = new(new LegacyRandomSource(0L));

        switch (reduction) {
            case FrequencyReductionMethod.Default:
                random.SetLargeFeatureWithSalt(seed, sourceX, sourceZ, salt);
                return random.NextFloat() < frequency;

            case FrequencyReductionMethod.LegacyType1:
                // The pillager outpost's, which reads the chunk position off a block position and
                // throws the first draw away.
                int chunkX = sourceX >> 4;
                int chunkZ = sourceZ >> 4;
                random.SetSeed(chunkX ^ (chunkZ << 4) ^ seed);
                random.NextInt();
                return random.NextInt((int)(1.0f / frequency)) == 0;

            case FrequencyReductionMethod.LegacyType2:
                random.SetLargeFeatureWithSalt(seed, sourceX, sourceZ, HighlyArbitraryRandomSalt);
                return random.NextFloat() < frequency;

            default:
                // A double rather than a float, which is the whole of what makes this one different.
                random.SetLargeFeatureSeed(seed, sourceX, sourceZ);
                return random.NextDouble() < frequency;
        }
    }
}

/// <summary>
/// What a placement needs to know about the world it is placing into.
/// </summary>
/// <remarks>
/// Narrower than vanilla's <c>ChunkGeneratorStructureState</c> on purpose: a placement only ever asks
/// for the seed, another set's chunks, and the stronghold ring positions.
/// </remarks>
public interface IStructurePlacementState {
    long LevelSeed { get; }

    /// <summary>Whether the named set places a structure within range of a chunk.</summary>
    bool HasStructureChunkInRange(Identifier otherSet, int sourceX, int sourceZ, int range);

    /// <summary>The ring positions worked out for a concentric rings placement.</summary>
    IReadOnlyList<Vec2<int>> RingPositionsFor(ConcentricRingsStructurePlacement placement);
}

/// <summary>
/// <c>RandomSpreadStructurePlacement</c>: a grid of cells with one structure somewhere in each, which
/// is how all but one vanilla set is spaced.
/// </summary>
/// <remarks>
/// <c>spacing</c> is the cell size in chunks and <c>separation</c> is how much of it is kept clear, so
/// the structure lands in the first <c>spacing - separation</c> chunks of its cell. That is what makes
/// two of them always at least <c>separation</c> apart while still looking scattered.
/// </remarks>
public sealed class RandomSpreadStructurePlacement(Vec3<int> locateOffset,
    FrequencyReductionMethod reduction, float frequency, int salt, ExclusionZone? exclusionZone,
    int spacing, int separation, RandomSpreadType spreadType)
    : StructurePlacement(locateOffset, reduction, frequency, salt, exclusionZone) {

    public int Spacing => spacing;
    public int Separation => separation;
    public RandomSpreadType SpreadType => spreadType;

    /// <summary>The one chunk of the cell containing the given chunk that a structure may start in.</summary>
    public Vec2<int> PotentialStructureChunk(long seed, int sourceX, int sourceZ) {
        int cellX = Mth.FloorDiv(sourceX, spacing);
        int cellZ = Mth.FloorDiv(sourceZ, spacing);

        WorldgenRandom random = new(new LegacyRandomSource(0L));
        random.SetLargeFeatureWithSalt(seed, cellX, cellZ, Salt);

        int limit = spacing - separation;
        int spreadX = Evaluate(random, limit, spreadType);
        int spreadZ = Evaluate(random, limit, spreadType);

        return new Vec2<int>(cellX * spacing + spreadX, cellZ * spacing + spreadZ);
    }

    protected override bool IsPlacementChunk(IStructurePlacementState state, int sourceX, int sourceZ) {
        Vec2<int> chunk = PotentialStructureChunk(state.LevelSeed, sourceX, sourceZ);
        return chunk.X == sourceX && chunk.Y == sourceZ;
    }

    /// <summary>
    /// Where in the cell. Triangular is the mean of two draws, which clusters towards the middle and
    /// is what the nether complexes use.
    /// </summary>
    private static int Evaluate(RandomSource random, int limit, RandomSpreadType spread) {
        return spread == RandomSpreadType.Triangular
            ? (random.NextInt(limit) + random.NextInt(limit)) / 2
            : random.NextInt(limit);
    }
}

/// <summary>
/// <c>ConcentricRingsStructurePlacement</c>: the strongholds, which are laid out in rings around the
/// origin rather than on a grid.
/// </summary>
/// <remarks>
/// The positions are worked out once for the whole world rather than per chunk, because each one is a
/// biome search, and the placement test is then a lookup in that list.
/// </remarks>
public sealed class ConcentricRingsStructurePlacement(Vec3<int> locateOffset,
    FrequencyReductionMethod reduction, float frequency, int salt, ExclusionZone? exclusionZone,
    int distance, int spread, int count, IReadOnlySet<Identifier> preferredBiomes)
    : StructurePlacement(locateOffset, reduction, frequency, salt, exclusionZone) {

    public int Distance => distance;
    public int Spread => spread;
    public int Count => count;
    public IReadOnlySet<Identifier> PreferredBiomes => preferredBiomes;

    protected override bool IsPlacementChunk(IStructurePlacementState state, int sourceX, int sourceZ) {
        foreach (Vec2<int> position in state.RingPositionsFor(this)) {
            if (position.X == sourceX && position.Y == sourceZ) {
                return true;
            }
        }

        return false;
    }
}

/// <summary>
/// <c>StructureSet</c>: the structures that share one placement, and their weights.
/// </summary>
/// <remarks>
/// A set with more than one entry picks between them by weight and falls back to the next when one
/// declines, which is how a nether complex is a fortress or a bastion and how a shipwreck is beached
/// or not.
/// </remarks>
public sealed record StructureSet(IReadOnlyList<StructureSet.Entry> Structures,
    StructurePlacement Placement) {

    public sealed record Entry(Identifier Structure, int Weight);
}
