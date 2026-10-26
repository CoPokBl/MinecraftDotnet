using ManagedServer.Terrain;
using ManagedServer.Terrain.Density;
using ManagedServer.Terrain.Features;
using ManagedServer.Terrain.Features.Values;
using ManagedServer.Terrain.Structures;
using ManagedServer.Terrain.Structures.Templates;
using ManagedServer.Terrain.Structures.Types;
using Minecraft.Data.Biomes;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Implementations.Server.Terrain.Generation;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Testing.Terrain;

/// <summary>
/// The structure pass's properties.
/// </summary>
/// <remarks>
/// There is deliberately no conformance harness, on the feature and carver passes' reasoning: a
/// structure is a piece tree built by a recursive layout drawing from one shared random, so a fixture
/// would pin the whole pass or nothing. What is worth pinning is the placement arithmetic, which is
/// exact and cheap, and the property that a chunk generates the same whichever neighbour was asked
/// for first.
/// </remarks>
[TestFixture]
public class StructurePassTest {
    private const long Seed = 90210L;

    [Test]
    public void TheDatapackParses() {
        VanillaStructureData data = VanillaStructureData.Load(VanillaPack.Source,
            VanillaFeatureData.Load(VanillaPack.Source, VanillaRegistry.Data), VanillaRegistry.Data);

        Assert.That(data.Structures, Is.Not.Empty);
        Assert.That(data.Sets, Is.Not.Empty);
    }

    /// <summary>
    /// Every structure's biome list resolved to something, and to the right something.
    /// </summary>
    /// <remarks>
    /// A biome tag that resolved to nothing is the quietest way this pass can fail: the placement
    /// still rolls, the start is still built, and the biome test at the end drops every one of them,
    /// so the world generates and simply has no structures in it.
    /// </remarks>
    [Test]
    public void EveryStructureAllowsSomeBiome() {
        VanillaStructureData data = VanillaStructureData.Load(VanillaPack.Source,
            VanillaFeatureData.Load(VanillaPack.Source, VanillaRegistry.Data), VanillaRegistry.Data);

        foreach ((Identifier id, Structure structure) in data.Structures) {
            Assert.That(structure.Settings.Biomes, Is.Not.Empty,
                $"{id} resolved to an empty biome list, so it can never generate");
        }

        Assert.That(data.Structures["minecraft:swamp_hut"].AllowsBiome("minecraft:swamp"), Is.True);
        Assert.That(data.Structures["minecraft:swamp_hut"].AllowsBiome("minecraft:desert"), Is.False);
    }

    /// <summary>
    /// Every structure the datapack names is either transcribed or on one of the two skip lists, so a
    /// new structure upstream fails the load rather than vanishing.
    /// </summary>
    [Test]
    public void EverySkippedStructureHasAReason() {
        VanillaStructureData data = VanillaStructureData.Load(VanillaPack.Source,
            VanillaFeatureData.Load(VanillaPack.Source, VanillaRegistry.Data), VanillaRegistry.Data);

        foreach (string skipped in data.Skipped) {
            Assert.That(skipped, Does.Contain("("), $"{skipped} was skipped without a reason");
            Assert.That(skipped, Does.Not.Contain("()"), $"{skipped} was skipped with an empty reason");
        }
    }

    /// <summary>
    /// A set that keeps every chunk it picks places exactly one structure per cell, at the position
    /// its own arithmetic names.
    /// </summary>
    [Test]
    public void ARandomSpreadPlacesOneStructurePerCell() {
        RandomSpreadStructurePlacement placement = new(new Vec3<int>(0, 0, 0),
            FrequencyReductionMethod.Default, 1.0f, 14357617, null, 32, 8, RandomSpreadType.Linear);

        for (int cellX = -3; cellX <= 3; cellX++) {
            for (int cellZ = -3; cellZ <= 3; cellZ++) {
                Vec2<int> chosen = placement.PotentialStructureChunk(Seed, cellX * 32, cellZ * 32);

                Assert.That(chosen.X, Is.InRange(cellX * 32, cellX * 32 + 23));
                Assert.That(chosen.Y, Is.InRange(cellZ * 32, cellZ * 32 + 23));

                // Every chunk of the cell has to agree on where the cell's structure is, since that
                // is what makes a neighbour place the other half of it.
                Vec2<int> fromElsewhere = placement.PotentialStructureChunk(Seed,
                    cellX * 32 + 17, cellZ * 32 + 5);

                Assert.That(fromElsewhere, Is.EqualTo(chosen));
            }
        }
    }

    /// <summary>
    /// The frequency reducers are not interchangeable: a mineshaft's draws a double and a buried
    /// treasure's uses a constant salt, and swapping them moves every structure in the world.
    /// </summary>
    [Test]
    public void TheFrequencyReducersDisagreeWithEachOther() {
        Dictionary<FrequencyReductionMethod, int> accepted = [];

        foreach (FrequencyReductionMethod method in Enum.GetValues<FrequencyReductionMethod>()) {
            RandomSpreadStructurePlacement placement = new(new Vec3<int>(0, 0, 0), method, 0.25f, 0,
                null, 1, 0, RandomSpreadType.Linear);

            int count = 0;

            for (int x = 0; x < 40; x++) {
                for (int z = 0; z < 40; z++) {
                    if (placement.IsStructureChunk(new NoOtherSets(Seed), x, z)) {
                        count++;
                    }
                }
            }

            accepted[method] = count;
        }

        Assert.That(accepted.Values.Distinct().Count(), Is.GreaterThan(1),
            "every reducer accepted the same chunks, so they are not really different rules");
    }

    /// <summary>
    /// The load bearing one: a source chunk's starts do not depend on which chunk is asking, so the
    /// two halves of a structure spanning a border agree about what it is.
    /// </summary>
    /// <remarks>
    /// Checked against two <b>separate</b> systems, so the answer comes from the arithmetic rather
    /// than from the shared start cache. The terrain is stubbed flat, which takes the noise out of
    /// the comparison and leaves exactly the placement and layout logic in it.
    /// </remarks>
    [Test]
    public void AStartIsTheSameWhicheverChunkAsksForIt() {
        VanillaStructureData data = VanillaStructureData.Load(VanillaPack.Source,
            VanillaFeatureData.Load(VanillaPack.Source, VanillaRegistry.Data), VanillaRegistry.Data);

        StructureSystem first = new(data, VanillaRegistry.Data, Seed, PlainsEverywhere);
        StructureSystem second = new(data, VanillaRegistry.Data, Seed, PlainsEverywhere);

        int compared = 0;

        for (int sourceX = -40; sourceX <= 40; sourceX++) {
            for (int sourceZ = -40; sourceZ <= 40; sourceZ++) {
                IReadOnlyList<StructureStart> a = first.StartsAt(sourceX, sourceZ, FlatContext);
                IReadOnlyList<StructureStart> b = second.StartsAt(sourceX, sourceZ, FlatContext);

                Assert.That(Describe(b), Is.EqualTo(Describe(a)),
                    $"source chunk {sourceX}, {sourceZ} built two different structures");

                compared += a.Count;
            }
        }

        Assert.That(compared, Is.GreaterThan(0),
            "no structure started anywhere in 6561 chunks, so this compared nothing");
    }

    /// <summary>
    /// Each transcribed structure really builds something, and builds it where its own footprint says.
    /// </summary>
    /// <remarks>
    /// The pass is arranged so that a structure that declines and a structure that is not registered
    /// look identical from outside: both are simply absent from the world. So the determinism tests
    /// above pass just as happily over a build in which nothing generates at all, and this is the one
    /// that says a temple exists.
    /// </remarks>
    // The jungle temple's registry id is jungle_pyramid where its type is jungle_temple. A structure
    // is looked up by id and skipped by type, so the two are not interchangeable.
    [TestCase("minecraft:desert_pyramid", 21, 21)]
    [TestCase("minecraft:jungle_pyramid", 12, 15)]
    [TestCase("minecraft:swamp_hut", 7, 9)]
    public void ATranscribedStructureBuildsItsPiece(string id, int width, int depth) {
        VanillaStructureData data = VanillaStructureData.Load(VanillaPack.Source,
            VanillaFeatureData.Load(VanillaPack.Source, VanillaRegistry.Data), VanillaRegistry.Data);
        Structure structure = data.Structures[Identifier.Parse(id)];

        StructureStart start = FindStart(data, structure)
            ?? throw new AssertionException($"{id} started nowhere in the searched region");

        Assert.That(start.Pieces, Is.Not.Empty);

        BoundingBox box = start.Pieces[0].BoundingBox;

        // The footprint is the piece's own, and the two spans swap over on the x facings, so either
        // way round is right and neither is any other size.
        Assert.That((box.XSpan, box.ZSpan), Is.EqualTo((width, depth)).Or.EqualTo((depth, width)));

        FlatLevel level = new();
        BoundingBox chunkBox = new(box.MinX, level.MinY, box.MinZ, box.MinX + 15, level.MaxY,
            box.MinZ + 15);

        start.PlaceInChunk(level, FlatFeatures(level), new LegacyRandomSource(Seed),
            () => new LegacyRandomSource(Seed), chunkBox,
            box.MinX >> 4, box.MinZ >> 4);

        Assert.That(level.Written, Is.Not.Empty, $"{id} placed no blocks at all");
    }

    /// <summary>
    /// A piece that settles its own height lands at the same height whichever chunk places it.
    /// </summary>
    /// <remarks>
    /// A shipwreck, an ocean ruin and an igloo move themselves inside <c>PostProcess</c>, and a start
    /// is replayed by every chunk it reaches, so each of those chunks settles the piece again. The two
    /// halves of a wreck only line up while every one of those answers agrees.
    /// <p/>
    /// <b>What decides that is which heightmap the settle reads.</b> The two <c>_WG</c> maps stop being
    /// maintained at the carvers step, so they answer the terrain and nothing a feature or an earlier
    /// piece wrote; the four live ones answer the column as it stands. So a settle reading a live map
    /// moves once anything has been written under the piece, which is exactly what the chunk placed
    /// first does to the chunk placed second. <see cref="SettlingLevel"/> is the difference: its
    /// frozen maps are the sloped ground alone and its live ones count what has been written.
    /// <p/>
    /// The ground is sloped rather than flat because a flat one gives every column the same answer,
    /// which a broken settle passes just as happily.
    /// </remarks>
    [TestCase("minecraft:shipwreck")]
    [TestCase("minecraft:shipwreck_beached")]
    [TestCase("minecraft:ocean_ruin_cold")]
    [TestCase("minecraft:ocean_ruin_warm")]
    [TestCase("minecraft:igloo")]
    public void ASelfSettlingPieceLandsAtOneHeightWhicheverChunkPlacesIt(string id) {
        VanillaStructureData data = VanillaStructureData.Load(VanillaPack.Source,
            VanillaFeatureData.Load(VanillaPack.Source, VanillaRegistry.Data), VanillaRegistry.Data);

        Structure structure = data.Structures[Identifier.Parse(id)];

        StructureStart start = FindStart(data, structure)
            ?? throw new AssertionException($"{id} started nowhere in the searched region");

        SettlingLevel level = new();
        BoundingBox box = start.BoundingBox;

        // Every chunk the start reaches, and then the first of them again. A start whose box sits
        // inside one chunk still has to settle the same way the second time, and that is the same
        // question: whether what the last placement wrote moved the ground the settle reads.
        List<Vec2<int>> chunks = [];

        for (int chunkX = box.MinX >> 4; chunkX <= box.MaxX >> 4; chunkX++) {
            for (int chunkZ = box.MinZ >> 4; chunkZ <= box.MaxZ >> 4; chunkZ++) {
                chunks.Add(new Vec2<int>(chunkX, chunkZ));
            }
        }

        chunks.Add(chunks[0]);

        List<Dictionary<int, int>> heights = [];

        foreach (Vec2<int> chunk in chunks) {
            BoundingBox chunkBox = new(chunk.X << 4, level.MinY, chunk.Y << 4,
                (chunk.X << 4) + 15, level.MaxY, (chunk.Y << 4) + 15);

            start.PlaceInChunk(level, FlatFeatures(level), new LegacyRandomSource(Seed),
                () => new LegacyRandomSource(Seed), chunkBox,
                chunk.X, chunk.Y);

            heights.Add(start.Pieces
                .Select((piece, index) => (index, piece.BoundingBox.MinY))
                .ToDictionary(entry => entry.index, entry => entry.MinY));
        }

        Assert.That(level.Written, Is.Not.Empty, $"{id} placed no blocks at all");

        for (int i = 1; i < heights.Count; i++) {
            Assert.That(heights[i], Is.EqualTo(heights[0]),
                $"{id} settled to a different height on placement {i + 1}, so what one chunk wrote "
                + "moved the ground the next one settled against");
        }
    }

    /// <summary>
    /// Sloped ground, whose live heightmaps count what has been written and whose frozen ones do not.
    /// </summary>
    /// <remarks>
    /// The split is <c>ChunkFeatureLevel</c>'s, and it is the whole point of this level: see
    /// <see cref="ASelfSettlingPieceLandsAtOneHeightWhicheverChunkPlacesIt"/>.
    /// </remarks>
    private sealed class SettlingLevel : IFeatureLevel {
        public readonly Dictionary<long, uint> Written = [];

        private readonly Dictionary<long, int> _tops = [];

        public MinecraftRegistry Registry => VanillaRegistry.Data;
        public int MinY => -64;
        public int MaxY => 320;
        public int SeaLevel => 63;
        public long Seed => StructurePassTest.Seed;
        public RandomSource LevelRandom { get; } = new LegacyRandomSource(StructurePassTest.Seed);
        public FeatureBlockData Blocks => FeatureBlockData.For(VanillaRegistry.Data);

        public bool IsLoaded(int x, int z) => true;

        public uint GetState(int x, int y, int z) {
            return Written.TryGetValue(Key(x, y, z), out uint written)
                ? written
                : y < Ground(x, z) ? Block.Stone.StateId : Block.Air.StateId;
        }

        public void SetState(int x, int y, int z, uint stateId) {
            Written[Key(x, y, z)] = stateId;

            long column = Key(x, 0, z);
            _tops[column] = Math.Max(_tops.TryGetValue(column, out int top) ? top : MinY, y + 1);
        }

        public int GetHeight(HeightmapType type, int x, int z) {
            if (type is HeightmapType.WorldSurfaceWorldgen or HeightmapType.OceanFloorWorldgen) {
                return Ground(x, z);
            }

            return Math.Max(Ground(x, z),
                _tops.TryGetValue(Key(x, 0, z), out int top) ? top : MinY);
        }

        public IBiome GetBiome(int x, int y, int z) => VanillaRegistry.Data.Biomes["minecraft:plains"];

        /// <summary>A slope with no period a footprint can sit inside, so no two columns agree.</summary>
        private static int Ground(int x, int z) => 64 + ((x * 3 + z * 5) & 7);

        private static long Key(int x, int y, int z) {
            return ((long)(x & 0x3FFFFFF) << 38) | ((long)(z & 0x3FFFFFF) << 12) | (uint)(y & 0xFFF);
        }
    }

    /// <summary>
    /// Every structure in the pack builds a piece tree and writes blocks from it.
    /// </summary>
    /// <remarks>
    /// The one property that says the pass does anything at all. Every other test here holds just as
    /// well over a build where nothing generates: a structure that declined and a structure that was
    /// never registered are the same from outside the pass, so a whole family quietly failing to build
    /// would go unnoticed.
    /// <p/>
    /// The context is flat ground well above a low sea, and the biome is one the structure itself
    /// accepts, so what is measured is the structure rather than whether this seed happens to have a
    /// desert in it.
    /// </remarks>
    [Test]
    public void EveryStructureBuildsAndWritesSomething() {
        VanillaStructureData data = VanillaStructureData.Load(VanillaPack.Source,
            VanillaFeatureData.Load(VanillaPack.Source, VanillaRegistry.Data), VanillaRegistry.Data);

        Assert.That(data.Structures, Is.Not.Empty);

        foreach ((Identifier id, Structure structure) in data.Structures) {
            StructureStart start = FindStart(data, structure)
                ?? throw new AssertionException($"{id} started nowhere in the searched region");

            Assert.That(start.Pieces, Is.Not.Empty, $"{id} built no pieces");

            BoundingBox box = start.BoundingBox;
            FlatLevel level = new();

            // Every chunk the structure spans, since a piece may write into only one of them.
            for (int chunkX = box.MinX >> 4; chunkX <= box.MaxX >> 4; chunkX++) {
                for (int chunkZ = box.MinZ >> 4; chunkZ <= box.MaxZ >> 4; chunkZ++) {
                    BoundingBox chunkBox = new(chunkX << 4, level.MinY, chunkZ << 4,
                        (chunkX << 4) + 15, level.MaxY, (chunkZ << 4) + 15);

                    start.PlaceInChunk(level, FlatFeatures(level), new LegacyRandomSource(Seed),
                        () => new LegacyRandomSource(Seed),
                        chunkBox, chunkX, chunkZ);
                }
            }

            Assert.That(level.Written, Is.Not.Empty, $"{id} placed no blocks at all");
        }
    }

    /// <summary>
    /// A village grows the two kinds of piece that hang off its roads: houses, and features.
    /// </summary>
    /// <remarks>
    /// <b>Both halves are invisible to every other test here</b>, which is the reason for this one. A
    /// village whose roads are laid and whose every building slot fell through to the terminator pool
    /// builds a hundred pieces and writes thousands of blocks, so it passes
    /// <see cref="EveryStructureBuildsAndWritesSomething"/> and looks from outside like a village.
    /// <p/>
    /// Each half pins one thing the layout depends on. A house is reached only if the expansion hack
    /// inflated the street's box by the <b>houses</b> pool's height, which it does by counting the
    /// connections pointing back into the street rather than the ones pointing out of it. A feature
    /// element is reached only if the jigsaw block it invents is named <c>bottom</c>, since a
    /// decoration connection attaches on the candidate's name.
    /// </remarks>
    [TestCase("minecraft:village_plains", "village/plains/houses/",
        TestName = "APlainsVillageGrowsHousesAndDecoration")]
    [TestCase("minecraft:village_taiga", "village/taiga/houses/",
        TestName = "ATaigaVillageGrowsHousesAndDecoration")]
    public void AVillageGrowsHousesAndDecoration(string id, string housePrefix) {
        VanillaStructureData data = VanillaStructureData.Load(VanillaPack.Source,
            VanillaFeatureData.Load(VanillaPack.Source, VanillaRegistry.Data), VanillaRegistry.Data);

        Structure structure = data.Structures[Identifier.Parse(id)];

        StructureStart start = FindStart(data, structure)
            ?? throw new AssertionException($"{id} started nowhere in the searched region");

        List<IStructurePoolElement> elements = start.Pieces
            .OfType<PoolElementStructurePiece>()
            .Select(piece => piece.Element)
            .ToList();

        Assert.That(elements.OfType<SinglePoolElement>()
                .Count(element => element.Template.ToString().Contains(housePrefix)),
            Is.GreaterThan(0),
            $"{id} laid its roads out and put no building on any of them, so every building "
            + "connection fell through to the terminator pool");

        Assert.That(elements.OfType<FeaturePoolElement>().Count(), Is.GreaterThan(0),
            $"{id} attached no feature element, so nothing a village grows rather than places "
            + "reached it");
    }

    /// <summary>
    /// The mineshaft grows a network rather than placing a piece, and puts it underground.
    /// </summary>
    /// <remarks>
    /// Its own test because it is the one structure whose first piece has no fixed footprint: the room
    /// is three draws wide, and everything else is recursion off it. What is worth pinning instead is
    /// that the recursion happened at all and that the whole network was then dropped, since a
    /// mineshaft left at <c>MagicStartY</c> would sit in the open air across half the world.
    /// </remarks>
    [TestCase("minecraft:mineshaft", TestName = "AMineshaftBuildsItsNetwork")]
    [TestCase("minecraft:mineshaft_mesa", TestName = "AMesaMineshaftBuildsItsNetwork")]
    public void AMineshaftBuildsANetwork(string id) {
        VanillaStructureData data = VanillaStructureData.Load(VanillaPack.Source,
            VanillaFeatureData.Load(VanillaPack.Source, VanillaRegistry.Data), VanillaRegistry.Data);
        Structure structure = data.Structures[Identifier.Parse(id)];

        StructureStart start = FindStart(data, structure)
            ?? throw new AssertionException($"{id} started nowhere in the searched region");

        Assert.That(start.Pieces, Has.Count.GreaterThan(1),
            "the room grew no tunnels, so the piece recursion never ran");

        BoundingBox box = start.BoundingBox;

        Assert.That(box.MinY, Is.GreaterThanOrEqualTo(-64),
            "the network was pushed through the floor of the world");

        // The room is laid out at MagicStartY and the network is dropped afterwards, so a network
        // still sitting at that height is one that was never moved.
        Assert.That(box.MinY, Is.Not.EqualTo(MineshaftStructure.MagicStartY));

        // The chunk is the room's, not the network's. A network's own box has its extremes on
        // different pieces, so a chunk taken from its minimum corner holds none of them.
        BoundingBox room = start.Pieces[0].BoundingBox;
        FlatLevel level = new();
        BoundingBox chunkBox = new(room.MinX, level.MinY, room.MinZ, room.MinX + 15, level.MaxY,
            room.MinZ + 15);

        start.PlaceInChunk(level, FlatFeatures(level), new LegacyRandomSource(Seed),
            () => new LegacyRandomSource(Seed), chunkBox,
            room.MinX >> 4, room.MinZ >> 4);

        Assert.That(level.Written, Is.Not.Empty, $"{id} placed no blocks at all");
    }

    /// <summary>
    /// The stronghold ring positions are the same every time, over the real climate.
    /// </summary>
    /// <remarks>
    /// The 128 searches run in <b>parallel</b>, which is what makes them affordable, so this is the
    /// test that says the parallelism changed no answer. Each search draws from a random forked before
    /// it and reads the flattened sampler, and the sampler holds its region tree cursor per thread; if
    /// either of those stopped being true the positions would wander between runs and every stronghold
    /// in the world would move.
    /// </remarks>
    [Test]
    public void TheStrongholdRingsAreTheSameEveryTime() {
        VanillaStructureData data = VanillaStructureData.Load(VanillaPack.Source,
            VanillaFeatureData.Load(VanillaPack.Source, VanillaRegistry.Data), VanillaRegistry.Data);

        ConcentricRingsStructurePlacement placement =
            (ConcentricRingsStructurePlacement)data.Sets["minecraft:strongholds"].Placement;

        IReadOnlyList<Vec2<int>> first = Rings(data, placement);
        IReadOnlyList<Vec2<int>> second = Rings(data, placement);

        Assert.That(first, Has.Count.EqualTo(placement.Count));
        Assert.That(second, Is.EqualTo(first).AsCollection);

        // A ring that never found a preferred biome sits at its own unsearched candidate, so an
        // answer of all zeroes would mean the search never ran at all.
        Assert.That(first.Distinct().Count(), Is.GreaterThan(1));
    }

    private static IReadOnlyList<Vec2<int>> Rings(VanillaStructureData data,
        ConcentricRingsStructurePlacement placement) {

        VanillaTerrainGenerator generator = VanillaTerrainGenerator.Overworld(VanillaPack.Source, Seed);
        StructureSystem system = new(data, VanillaRegistry.Data, Seed, generator.BiomeAt);
        return system.RingPositionsFor(placement);
    }

    /// <summary>
    /// The beardifier is zero where nothing adjusts terrain and not zero where something does.
    /// </summary>
    /// <remarks>
    /// The whole pass is arranged so a chunk no adjusted structure reaches gets the empty beardifier
    /// and the noise runs exactly as it does with no structures at all. That half is what
    /// <c>TerrainConformanceTest</c> is really checking, since every position it samples is one no
    /// structure reaches; this is the other half, which nothing else would notice the absence of.
    /// </remarks>
    [Test]
    public void TheBeardifierAdjustsTerrainOnlyAroundAnAdjustedStructure() {
        Assert.That(Beardifier.Empty.SampleValue(SamplerContext.EmptyUncached, 0, 60, 0), Is.Zero);

        VanillaStructureData data = VanillaStructureData.Load(VanillaPack.Source,
            VanillaFeatureData.Load(VanillaPack.Source, VanillaRegistry.Data), VanillaRegistry.Data);
        Structure stronghold = data.Structures["minecraft:stronghold"];

        Assert.That(stronghold.TerrainAdaptation, Is.EqualTo(TerrainAdjustment.Bury),
            "the stronghold is the only transcribed structure that adjusts terrain");

        // A start built by hand rather than searched for. The real ones are 128 chunks out on the
        // stronghold rings, and what is being measured is the beardifier rather than the placement.
        StrongholdStartPiece piece = new(new LegacyRandomSource(Seed), 2, 2);
        StructureStart start = new(stronghold, 0, 0, new PiecesContainer([piece]));

        BoundingBox box = piece.BoundingBox;
        int chunkX = box.MinX >> 4;
        int chunkZ = box.MinZ >> 4;

        Beardifier beardifier = Beardifier.ForStructuresInChunk([start], chunkX, chunkZ);

        Assert.That(beardifier, Is.Not.SameAs(Beardifier.Empty),
            "a chunk the stronghold is standing in got the empty beardifier");

        // Inside a burying piece the term is positive, which is what fills the terrain in around it.
        Assert.That(beardifier.SampleValue(SamplerContext.EmptyUncached, box.MinX + 1, box.MinY + 1, box.MinZ + 1),
            Is.GreaterThan(0.0F));

        // Far enough away and it is exactly zero rather than merely small, because the affected box
        // short circuits it.
        Assert.That(beardifier.SampleValue(SamplerContext.EmptyUncached, box.MinX + 4096, box.MinY, box.MinZ), Is.Zero);
    }

    /// <summary>
    /// A biome lookup for a system driven without a generator behind it.
    /// </summary>
    /// <remarks>
    /// Only the stronghold's ring placement asks, and it wants a preferred biome to aim at rather than
    /// a correct world. Plains is not one of those, so every ring falls back to its unsearched
    /// position, which is exactly as deterministic and is all these tests measure.
    /// </remarks>
    private static Identifier PlainsEverywhere(int quartX, int quartY, int quartZ) {
        return Plains;
    }

    private static readonly Identifier Plains = "minecraft:plains";

    /// <summary>
    /// The first start of one structure anywhere in the sampled region, or null.
    /// </summary>
    /// <remarks>
    /// The region is wide because the rarest structure decides how wide it has to be. A pillager
    /// outpost passes one candidate chunk in five and is then excluded within ten chunks of a village
    /// candidate, so a search that would reliably find a temple finds no outpost at all.
    /// </remarks>
    private const int SearchRadius = 90;

    private static StructureStart? FindStart(VanillaStructureData data, Structure structure) {
        StructureSystem system = new(data, VanillaRegistry.Data, Seed, PlainsEverywhere);

        // A ring placed structure is asked about its own ring positions rather than searched for: the
        // innermost ring is about 128 chunks out, so a square that found one would be sixteen times
        // the area and would spend all of it on the other structures.
        foreach (Vec2<int> ring in RingChunks(data, system, structure)) {
            foreach (StructureStart start in system.StartsAt(ring.X, ring.Y,
                ContextAllowing(structure))) {

                if (ReferenceEquals(start.Structure, structure)) {
                    return start;
                }
            }
        }

        for (int sourceX = -SearchRadius; sourceX <= SearchRadius; sourceX++) {
            for (int sourceZ = -SearchRadius; sourceZ <= SearchRadius; sourceZ++) {
                foreach (StructureStart start in system.StartsAt(sourceX, sourceZ,
                    ContextAllowing(structure))) {

                    if (ReferenceEquals(start.Structure, structure)) {
                        return start;
                    }
                }
            }
        }

        return null;
    }

    /// <summary>
    /// The chunks a ring placed structure may start in, or nothing for one placed by spread.
    /// </summary>
    private static IEnumerable<Vec2<int>> RingChunks(VanillaStructureData data,
        StructureSystem system, Structure structure) {

        foreach (StructureSet set in data.Sets.Values) {
            if (set.Placement is not ConcentricRingsStructurePlacement rings) {
                continue;
            }

            foreach (StructureSet.Entry entry in set.Structures) {
                if (data.Structures.TryGetValue(entry.Structure, out Structure? candidate)
                    && ReferenceEquals(candidate, structure)) {

                    return system.RingPositionsFor(rings);
                }
            }
        }

        return [];
    }

    /// <summary>
    /// A flat context at sea level whose biome is one the structure accepts, so the biome test at the
    /// end of <c>FindValidGenerationPoint</c> is not what is being measured.
    /// </summary>
    private static StructureGenerationContext.Factory ContextAllowing(Structure structure) {
        Identifier biome = structure.Settings.Biomes.First();

        return (sourceChunkX, sourceChunkZ) => {
            WorldgenRandom random = new(new LegacyRandomSource(0L));
            random.SetLargeFeatureSeed(Seed, sourceChunkX, sourceChunkZ);

            return new StructureGenerationContext(VanillaRegistry.Data,
                (_, _, _) => 64,
                FlatColumn,
                (_, _, _) => biome,
                random, Seed, sourceChunkX, sourceChunkZ, -64, 384, 32);
        };
    }

    /// <summary>Flat stone to y 64 and air above it, which is enough for a piece to sit on.</summary>
    private sealed class FlatLevel : IFeatureLevel {
        private const int Ground = 64;

        public readonly Dictionary<long, uint> Written = [];

        public MinecraftRegistry Registry => VanillaRegistry.Data;
        public int MinY => -64;
        public int MaxY => 320;
        public int SeaLevel => 63;
        public long Seed => StructurePassTest.Seed;
        public RandomSource LevelRandom { get; } = new LegacyRandomSource(StructurePassTest.Seed);
        public FeatureBlockData Blocks => FeatureBlockData.For(VanillaRegistry.Data);

        public bool IsLoaded(int x, int z) => true;

        public uint GetState(int x, int y, int z) {
            return Written.TryGetValue(Key(x, y, z), out uint written)
                ? written
                : y < Ground ? Block.Stone.StateId : Block.Air.StateId;
        }

        public void SetState(int x, int y, int z, uint stateId) => Written[Key(x, y, z)] = stateId;

        public int GetHeight(HeightmapType type, int x, int z) => Ground;

        public IBiome GetBiome(int x, int y, int z) => VanillaRegistry.Data.Biomes["minecraft:plains"];

        private static long Key(int x, int y, int z) {
            return ((long)(x & 0x3FFFFFF) << 38) | ((long)(z & 0x3FFFFFF) << 12) | (uint)(y & 0xFFF);
        }
    }

    /// <summary>
    /// A structure really reaches generated terrain, through the whole pass rather than a stub level.
    /// </summary>
    /// <remarks>
    /// The chunks are named rather than searched for because <b>a structure is rare</b>: of the 150
    /// chunks the desert pyramid's own placement picks out of a 401 by 401 chunk region on this seed,
    /// one is in a desert. So a test that generated an area and expected a temple somewhere in it
    /// would have to generate tens of thousands of chunks to be reliable, and would fail as a flake
    /// rather than as a regression.
    /// <p/>
    /// What this covers that <see cref="ATranscribedStructureBuildsItsPiece"/> does not is the wiring:
    /// the step hook into the feature pass, the base height a start is placed at, and the biome test
    /// against the real climate. Each of those is silent when it is wrong, because a structure that
    /// declined and a structure that was never asked for look the same from outside.
    /// <p/>
    /// Each marker is a block <b>only that structure places</b>, which is what makes a hit mean
    /// something. The two mineshafts are told apart by their planks rather than by their logs: dark
    /// oak logs are also what the feature pass grows dark oak trees out of, so a mesa mineshaft
    /// measured by its logs would pass over any dark forest.
    /// </remarks>
    [TestCase(-61, -43, "minecraft:chiseled_sandstone", TestName = "ADesertPyramidReachesTheWorld")]
    [TestCase(-88, -12, "minecraft:mossy_cobblestone", TestName = "AJungleTempleReachesTheWorld")]
    [TestCase(-23, 17, "minecraft:oak_planks", TestName = "AMineshaftReachesTheWorld")]
    [TestCase(-85, -127, "minecraft:dark_oak_planks", TestName = "AMesaMineshaftReachesTheWorld")]
    [TestCase(-22, -165, "minecraft:infested_stone_bricks", TestName = "AStrongholdReachesTheWorld")]
    [TestCase(1, -47, "minecraft:sea_lantern", TestName = "AnOceanMonumentReachesTheWorld")]
    public void AStructureReachesGeneratedTerrain(int chunkX, int chunkZ, string marker) {
        ITerrainProvider provider = VanillaTerrainGenerator.Overworld(VanillaPack.Source, Seed)
            .WithFeatures()
            .WithStructures()
            .AsProvider();

        // The feature pass forks across chunk borders, and a provider driven by hand rather than by a
        // world has to be given somewhere for those to go.
        provider.Attach(new DiscardingHost());

        ChunkData chunk = new(384) { ChunkX = chunkX, ChunkZ = chunkZ, MinY = -64 };
        provider.GetChunk(ref chunk);

        uint expected = VanillaRegistry.Data.Blocks[Identifier.Parse(marker)].StateId;
        int found = 0;

        for (int x = 0; x < 16; x++) {
            for (int z = 0; z < 16; z++) {
                for (int y = 0; y < 384; y++) {
                    if (chunk.GetBlock(x, y, z) == expected) {
                        found++;
                    }
                }
            }
        }

        Assert.That(found, Is.GreaterThan(0),
            $"chunk {chunkX}, {chunkZ} generated no {marker}, so the structure pass placed nothing");
    }

    /// <summary>
    /// The nether's two structures reach generated nether terrain.
    /// </summary>
    /// <remarks>
    /// Their own test because the nether needs its own generator, its shorter world and its own biome
    /// source. Everything else about the pass is the same, which is the point: a fortress is placed by
    /// the same loop as a jungle temple.
    /// <p/>
    /// The two share a structure set and are drawn between, so a chunk holds one or the other and
    /// never both. That is what makes a bastion worth its own case rather than a variant of the
    /// fortress's: it is also the only jigsaw structure this file reaches through the whole pass.
    /// </remarks>
    [TestCase(-17, 4, "minecraft:nether_bricks", TestName = "ANetherFortressReachesGeneratedTerrain")]
    [TestCase(3, 8, "minecraft:gilded_blackstone", TestName = "ABastionReachesGeneratedTerrain")]
    public void ANetherStructureReachesGeneratedTerrain(int chunkX, int chunkZ, string marker) {
        const int netherHeight = 128;

        ITerrainProvider provider = VanillaTerrainGenerator.Nether(VanillaPack.Source, Seed)
            .WithFeatures()
            .WithStructures()
            .AsProvider();

        provider.Attach(new DiscardingHost());

        ChunkData chunk = new(netherHeight) { ChunkX = chunkX, ChunkZ = chunkZ, MinY = 0 };
        provider.GetChunk(ref chunk);

        uint expected = VanillaRegistry.Data.Blocks[Identifier.Parse(marker)].StateId;
        int found = 0;

        for (int x = 0; x < 16; x++) {
            for (int z = 0; z < 16; z++) {
                for (int y = 0; y < netherHeight; y++) {
                    if (chunk.GetBlock(x, y, z) == expected) {
                        found++;
                    }
                }
            }
        }

        Assert.That(found, Is.GreaterThan(0),
            $"chunk {chunkX}, {chunkZ} of the nether generated no {marker}, so the structure pass "
            + "placed nothing");
    }

    /// <summary>A host that keeps nothing, for a provider driven without a world behind it.</summary>
    internal sealed class DiscardingHost : ITerrainHost {
        public int MinY => -64;
        public int MaxY => 320;
        public MinecraftRegistry Registry => VanillaRegistry.Data;

        public event Action<Vec2<int>>? ChunkAvailable { add { } remove { } }

        public bool TryApplyToLoadedChunk(Vec2<int> chunk, Action<ChunkData> apply) => true;
    }

    /// <summary>The whole pass is deterministic: two fresh providers agree on a chunk.</summary>
    [Test]
    public void TheSameChunkGeneratesIdenticallyFromAFreshProvider() {
        uint[] first = GenerateAlone();
        uint[] second = GenerateAlone();

        Assert.That(second, Is.EqualTo(first));
    }

    /// <summary>Every piece box of every start, which is what a start is for comparison.</summary>
    private static string Describe(IReadOnlyList<StructureStart> starts) {
        return string.Join("; ", starts.Select(start =>
            $"{start.Structure.GetType().Name}@{start.ChunkX},{start.ChunkZ}["
            + string.Join(",", start.Pieces.Select(piece => piece.BoundingBox.ToString())) + "]"));
    }

    /// <summary>
    /// A context over flat terrain at sea level, so a structure's own layout is the only thing that
    /// varies between two runs.
    /// </summary>
    private static StructureGenerationContext FlatContext(int sourceChunkX, int sourceChunkZ) {
        WorldgenRandom random = new(new LegacyRandomSource(0L));
        random.SetLargeFeatureSeed(Seed, sourceChunkX, sourceChunkZ);

        return new StructureGenerationContext(VanillaRegistry.Data,
            (_, _, _) => 64,
            FlatColumn,
            (_, _, _) => new Identifier("minecraft", "swamp"),
            random, Seed, sourceChunkX, sourceChunkZ, -64, 384, 63);
    }

    /// <summary>
    /// The feature context a placement needs, over a level that has no feature table.
    /// </summary>
    /// <remarks>
    /// Only a jigsaw structure's feature pool elements ever reach it, and those name features the
    /// pass would run. Answering that a biome has no feature is enough for every other piece.
    /// </remarks>
    private static PlacementContext FlatFeatures(IFeatureLevel level) {
        return new PlacementContext(level, new GenerationHeightContext(level.MinY,
            level.MaxY - level.MinY), (_, _) => false, null);
    }

    /// <summary>
    /// The terrain column the flat contexts describe: stone up to y 64 and air above it, which is what
    /// the two heights beside them already say.
    /// </summary>
    private static uint[] FlatColumn(int blockX, int blockZ) {
        uint[] column = new uint[384];

        for (int i = 0; i < 128; i++) {
            column[i] = Block.Stone.StateId;
        }

        for (int i = 128; i < column.Length; i++) {
            column[i] = Block.Air.StateId;
        }

        return column;
    }

    /// <summary>
    /// Structures have to be off unless asked for, on the framework's own rule, and asking for them
    /// without the feature pass is a mistake rather than a configuration.
    /// </summary>
    [Test]
    public void StructuresAreOptIn() {
        Assert.That(VanillaTerrainGenerator.Overworld(VanillaPack.Source, Seed).HasStructures, Is.False);
        Assert.That(VanillaTerrainGenerator.Overworld(VanillaPack.Source, Seed).WithFeatures().WithStructures()
            .HasStructures, Is.True);

        Assert.Throws<InvalidOperationException>(
            () => VanillaTerrainGenerator.Overworld(VanillaPack.Source, Seed).WithStructures());
    }

    /// <summary>Generates one chunk from a provider of its own and answers its blocks.</summary>
    private static uint[] GenerateAlone() {
        GeneratorTerrainProvider provider = VanillaTerrainGenerator.Overworld(VanillaPack.Source, Seed)
            .WithFeatures()
            .WithStructures()
            .AsProvider();

        // A decorated chunk forks into its neighbours, and a provider with nowhere to send one throws
        // rather than dropping it. What this measures is the chunk's own content, so the neighbours
        // are discarded.
        provider.Attach(new DiscardingHost());

        ChunkData chunk = new(384) { ChunkX = 0, ChunkZ = 0, MinY = -64 };
        provider.GetChunk(ref chunk);

        List<uint> states = [];

        for (int x = 0; x < 16; x++) {
            for (int z = 0; z < 16; z++) {
                for (int y = 0; y < 384; y++) {
                    states.Add(chunk.GetBlock(x, y, z));
                }
            }
        }

        return [..states];
    }

    /// <summary>A placement state with no other sets, for testing one placement on its own.</summary>
    private sealed class NoOtherSets(long seed) : IStructurePlacementState {
        public long LevelSeed => seed;

        public bool HasStructureChunkInRange(Identifier otherSet, int sourceX, int sourceZ, int range) {
            return false;
        }

        /// <summary>No rings, since nothing here uses a concentric rings placement.</summary>
        public IReadOnlyList<Vec2<int>> RingPositionsFor(ConcentricRingsStructurePlacement placement) {
            return [];
        }

        public Vec2<int> DimensionOrigin => new(0, 0);
    }
}
