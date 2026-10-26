using ManagedServer.Terrain.Features;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Structures;

/// <summary>
/// <c>TerrainAdjustment</c>: what the noise pass does to the ground around a structure.
/// </summary>
/// <remarks>
/// Read by <see cref="Beardifier"/>, which is a term added to the terrain density. Everything except
/// <see cref="None"/> also inflates the structure's bounding box by twelve, so a chunk that only the
/// adjustment reaches still counts the structure as present.
/// </remarks>
public enum TerrainAdjustment {
    None,

    /// <summary>Fills the terrain in around the structure, which is what buries a stronghold.</summary>
    Bury,

    /// <summary>Grows a skirt of ground under the structure so it does not stand on air.</summary>
    BeardThin,

    /// <summary>The same skirt, measured from the whole box rather than from its floor.</summary>
    BeardBox,

    /// <summary>Fills in around the box on every axis, which is what seals a trial chamber.</summary>
    Encapsulate
}

/// <summary>How far into the decoration a structure is placed, vanilla's <c>GenerationStep.Decoration</c>.</summary>
public enum DecorationStep {
    RawGeneration,
    Lakes,
    LocalModifications,
    UndergroundStructures,
    SurfaceStructures,
    Strongholds,
    UndergroundOres,
    UndergroundDecoration,
    FluidSprings,
    VegetalDecoration,
    TopLayerModification
}

/// <summary>The terrain height at a column, before anything is decorated onto it.</summary>
public delegate int BaseHeightAt(int blockX, int blockZ, HeightmapType type);

/// <summary>The biome at a quart position, as an uncached point sample of the climate.</summary>
/// <remarks>
/// Divergence: vanilla samples a structure's biome checks through one caching context per chunk, and
/// 26.3 adds column pre-checks (<c>couldStructureExistInColumn</c>, <c>couldValidBiomeExistInTerrainColumn</c>)
/// that sample the column as a volume through that same context. Both only differ from an uncached
/// point sample where the volume path rounds a climate value across a region boundary differently
/// from the point path, so a structure there may start on one side and not the other.
/// <c>Conformance/structurelayout.sh</c> against a real save is what would show it.
/// </remarks>
public delegate Identifier BiomeAtQuart(int quartX, int quartY, int quartZ);

/// <summary>
/// A whole column of terrain states from the world's bottom upward, for a structure that has to look
/// at what a column is made of rather than only how high it is.
/// </summary>
public delegate uint[] BaseColumnAt(int blockX, int blockZ);

/// <summary>
/// What a structure gets to look at while deciding whether and where it exists.
/// </summary>
/// <remarks>
/// <see cref="Random"/> is already seeded from the world seed and the source chunk, as vanilla's
/// <c>GenerationContext</c> constructor does, so a structure that draws from it gets the same numbers
/// however many chunks are replaying it.
/// </remarks>
public sealed record StructureGenerationContext(
    MinecraftRegistry Registry,
    BaseHeightAt Heights,
    BaseColumnAt Columns,
    BiomeAtQuart Biomes,
    WorldgenRandom Random,
    long Seed,
    int ChunkX,
    int ChunkZ,
    int MinY,
    int Height,
    int SeaLevel) {

    public int MaxY => MinY + Height;

    /// <summary>
    /// Builds a context for a source chunk. The pass hands one of these round rather than a built
    /// context, because a context carries a random seeded from the source chunk it is for.
    /// </summary>
    public delegate StructureGenerationContext Factory(int sourceChunkX, int sourceChunkZ);

    /// <summary>
    /// <c>getFirstOccupiedHeight</c>: the highest block matching the heightmap, which is one below
    /// where a structure standing on the ground has its floor.
    /// </summary>
    public int FirstOccupiedHeight(int blockX, int blockZ, HeightmapType type) {
        return Heights(blockX, blockZ, type) - 1;
    }
}

/// <summary>
/// Where a structure decided to be, and what it puts there.
/// </summary>
/// <remarks>
/// Split from the pieces themselves because the biome test happens between the two: a structure works
/// out its position first, that position is checked against the structure's biome list, and only then
/// is the piece tree built. Building it first would run a mineshaft's whole layout for a position that
/// is then thrown away.
/// </remarks>
public sealed class GenerationStub {
    private readonly Action<StructurePiecesBuilder>? _generator;
    private readonly StructurePiecesBuilder? _built;

    /// <summary>A structure that knows where it goes before it decides what it is.</summary>
    public GenerationStub(Vec3<int> position, Action<StructurePiecesBuilder> generator) {
        Position = position;
        _generator = generator;
    }

    /// <summary>
    /// A structure whose pieces were laid out before it knew where it was, vanilla's
    /// <c>Either.right</c> half of the same field.
    /// </summary>
    /// <remarks>
    /// The mineshaft is the one that needs this: it builds its whole tunnel network at a fixed height
    /// and then drops the lot, so the height it ends up at is an <b>answer</b> from the layout rather
    /// than an input to it, and the position here is that answer.
    /// </remarks>
    public GenerationStub(Vec3<int> position, StructurePiecesBuilder built) {
        Position = position;
        _built = built;
    }

    public Vec3<int> Position { get; }

    public StructurePiecesBuilder Build() {
        if (_built is not null) {
            return _built;
        }

        StructurePiecesBuilder builder = new();
        _generator!(builder);
        return builder;
    }
}

/// <summary>
/// <c>Structure</c>: one kind of structure, which is the rule for where it goes and what it is made
/// of.
/// </summary>
/// <remarks>
/// A structure is asked <see cref="FindGenerationPoint"/> once per source chunk that its placement
/// picked out, and answers either nothing or a position plus the piece tree to build there.
/// </remarks>
public abstract class Structure(Structure.StructureSettings settings) {
    /// <summary>The biome list, step and terrain adaptation every structure carries.</summary>
    public sealed record StructureSettings(
        IReadOnlySet<Identifier> Biomes,
        DecorationStep Step,
        TerrainAdjustment TerrainAdaptation);

    public StructureSettings Settings => settings;

    public DecorationStep Step => settings.Step;

    public TerrainAdjustment TerrainAdaptation => settings.TerrainAdaptation;

    /// <summary>Whether a biome is one this structure is allowed to start in.</summary>
    public bool AllowsBiome(Identifier biome) => settings.Biomes.Contains(biome);

    /// <summary>
    /// The box a chunk has to overlap to count as holding this structure, which is bigger than the
    /// pieces wherever the terrain around them is adjusted.
    /// </summary>
    public BoundingBox AdjustBoundingBox(BoundingBox box) {
        return TerrainAdaptation == TerrainAdjustment.None ? box : box.InflatedBy(12);
    }

    /// <summary>Where this structure would go in the given source chunk, or null for nowhere.</summary>
    protected abstract GenerationStub? FindGenerationPoint(StructureGenerationContext context);

    /// <summary>
    /// The same, with the biome at the chosen position checked against the structure's list.
    /// </summary>
    /// <remarks>
    /// The test is at the position the structure picked rather than at the source chunk, so a
    /// structure that walked itself somewhere else is judged by where it ended up.
    /// </remarks>
    public GenerationStub? FindValidGenerationPoint(StructureGenerationContext context) {
        GenerationStub? stub = FindGenerationPoint(context);

        if (stub is null) {
            return null;
        }

        Identifier biome = context.Biomes(stub.Position.X >> 2, stub.Position.Y >> 2,
            stub.Position.Z >> 2);

        return AllowsBiome(biome) ? stub : null;
    }

    /// <summary>
    /// Builds the whole start for a source chunk, or null where the structure declined or came out
    /// with no pieces.
    /// </summary>
    public StructureStart? Generate(StructureGenerationContext context) {
        GenerationStub? stub = FindValidGenerationPoint(context);

        if (stub is null) {
            return null;
        }

        PiecesContainer pieces = stub.Build().Build();

        return pieces.IsEmpty ? null : new StructureStart(this, context.ChunkX, context.ChunkZ, pieces);
    }

    /// <summary>
    /// Runs after every piece of the structure has been placed in a chunk.
    /// </summary>
    /// <remarks>
    /// The desert pyramid is the only transcribed structure that uses it, for the suspicious sand it
    /// scatters through its cellar: that has to be chosen from the pyramid's <b>whole</b> set of
    /// candidate positions, which no single piece knows.
    /// </remarks>
    public virtual void AfterPlace(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, PiecesContainer pieces) { }

    // ------------------------------------------------------------ shared helpers

    /// <summary>
    /// <c>onTopOfChunkCenter</c>: the commonest generation point there is, the middle of the source
    /// chunk at whatever height the terrain reaches there.
    /// </summary>
    protected static GenerationStub OnTopOfChunkCenter(StructureGenerationContext context,
        HeightmapType heightmap, Action<StructurePiecesBuilder> generator) {

        int blockX = (context.ChunkX << 4) + 8;
        int blockZ = (context.ChunkZ << 4) + 8;
        int blockY = context.FirstOccupiedHeight(blockX, blockZ, heightmap);

        return new GenerationStub(new Vec3<int>(blockX, blockY, blockZ), generator);
    }

    /// <summary>The four corner heights of a footprint, which the two below average and minimise.</summary>
    private static int[] CornerHeights(StructureGenerationContext context, int minX, int sizeX,
        int minZ, int sizeZ) {

        return [
            context.FirstOccupiedHeight(minX, minZ, HeightmapType.WorldSurfaceWorldgen),
            context.FirstOccupiedHeight(minX, minZ + sizeZ, HeightmapType.WorldSurfaceWorldgen),
            context.FirstOccupiedHeight(minX + sizeX, minZ, HeightmapType.WorldSurfaceWorldgen),
            context.FirstOccupiedHeight(minX + sizeX, minZ + sizeZ, HeightmapType.WorldSurfaceWorldgen)
        ];
    }

    /// <summary>
    /// The mean of the four corner heights, which is how a structure sitting on a slope picks its
    /// floor.
    /// </summary>
    public static int MeanFirstOccupiedHeight(StructureGenerationContext context, int minX, int sizeX,
        int minZ, int sizeZ) {

        int[] corners = CornerHeights(context, minX, sizeX, minZ, sizeZ);
        return (corners[0] + corners[1] + corners[2] + corners[3]) / 4;
    }

    /// <summary>The lowest of the four, for a structure that must not have a corner in the air.</summary>
    protected static int LowestY(StructureGenerationContext context, int sizeX, int sizeZ) {
        return LowestY(context, context.ChunkX << 4, context.ChunkZ << 4, sizeX, sizeZ);
    }

    protected static int LowestY(StructureGenerationContext context, int minX, int minZ, int sizeX,
        int sizeZ) {

        int[] corners = CornerHeights(context, minX, sizeX, minZ, sizeZ);
        return Math.Min(Math.Min(corners[0], corners[1]), Math.Min(corners[2], corners[3]));
    }
}
