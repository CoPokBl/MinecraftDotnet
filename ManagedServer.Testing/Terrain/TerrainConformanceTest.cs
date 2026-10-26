using System.Buffers.Binary;
using System.IO.Compression;
using ManagedServer.Terrain;
using ManagedServer.Terrain.Biomes;
using ManagedServer.Terrain.Density;
using Minecraft.Data.Generated;
using Minecraft.Schemas;

namespace ManagedServer.Testing.Terrain;

/// <summary>
/// Replays what the real vanilla density functions said, from the fixture <c>Conformance/terrain.sh</c>
/// produced.
/// </summary>
/// <remarks>
/// This is the test that decides whether the density function port is right. Our own tests encode the
/// same reading of the jar the port does, so a wrong constant or a spline derivative read off by one
/// passes them all and produces a different world.
/// <p/>
/// The tolerance is <b>exact</b>. Both sides run the same float arithmetic in the same order, so they
/// agree bit for bit or the port is wrong. The point path and the volume path are pinned separately
/// because they round differently, and the fill reads the volume one.
/// </remarks>
[TestFixture]
public class TerrainConformanceTest {
    /// <summary>The order the harness wrote the floats in, <c>TerrainHarness.ENTRIES</c>.</summary>
    private static readonly string[] Entries = [
        "temperature", "vegetation", "continents", "erosion", "depth", "ridges", "chunk_surface_level", "final_density",
        "aquifer_barrier", "aquifer_fluid_level_floodedness", "aquifer_fluid_level_spread", "aquifer_lava",
        "aquifer_exclusion", "aquifer_surface_level",
        "overworld/ore_vein/toggle", "overworld/ore_vein/mask", "overworld/ore_vein/gap",
        "overworld/ore_vein/richness", "overworld/ore_vein/copper_density", "overworld/ore_vein/iron_density"
    ];

    private static string FixturePath =>
        Path.Combine(TestContext.CurrentContext.TestDirectory, "Terrain", "vanilla-terrain.bin.gz");

    private sealed record ChunkVolumes(int ChunkX, int ChunkZ, float[] FinalDensity, float[][] Climate, float[] SurfaceLevel);

    private sealed record Fixture(
        long Seed,
        List<(int X, int Y, int Z, float[] Values)> Points,
        List<(int QuartX, int QuartY, int QuartZ, long[] Climate)> Climate,
        List<string> Biomes,
        List<ChunkVolumes> Volumes);

    private const int MinY = -64;
    private const int Height = 384;

    private static Fixture Read() {
        using FileStream file = File.OpenRead(FixturePath);
        using GZipStream gzip = new(file, CompressionMode.Decompress);
        using BinaryReader reader = new(gzip);

        long seed = ReadInt64(reader);

        int pointCount = ReadInt32(reader);
        List<(int, int, int, float[])> points = new(pointCount);
        for (int i = 0; i < pointCount; i++) {
            int x = ReadInt32(reader);
            int y = ReadInt32(reader);
            int z = ReadInt32(reader);
            points.Add((x, y, z, ReadFloats(reader, Entries.Length)));
        }

        int climateCount = ReadInt32(reader);
        List<(int, int, int, long[])> climate = new(climateCount);
        for (int i = 0; i < climateCount; i++) {
            int quartX = ReadInt32(reader);
            int quartY = ReadInt32(reader);
            int quartZ = ReadInt32(reader);
            long[] values = new long[6];
            for (int v = 0; v < values.Length; v++) {
                values[v] = ReadInt64(reader);
            }

            climate.Add((quartX, quartY, quartZ, values));
        }

        List<string> biomes = new(climateCount);
        for (int i = 0; i < climateCount; i++) {
            biomes.Add(ReadJavaUtf(reader));
        }

        int chunkCount = ReadInt32(reader);
        List<ChunkVolumes> volumes = new(chunkCount);
        for (int i = 0; i < chunkCount; i++) {
            int chunkX = ReadInt32(reader);
            int chunkZ = ReadInt32(reader);
            float[] finalDensity = ReadFloats(reader, 16 * Height * 16);
            float[][] climateVolumes = new float[6][];
            for (int c = 0; c < 6; c++) {
                climateVolumes[c] = ReadFloats(reader, 4 * (Height >> 2) * 4);
            }

            volumes.Add(new ChunkVolumes(chunkX, chunkZ, finalDensity, climateVolumes, ReadFloats(reader, 16 * 16)));
        }

        return new Fixture(seed, points, climate, biomes, volumes);
    }

    // Java's DataOutputStream is big endian throughout; BinaryReader is little endian.
    private static int ReadInt32(BinaryReader reader) => BinaryPrimitives.ReadInt32BigEndian(reader.ReadBytes(4));

    private static long ReadInt64(BinaryReader reader) => BinaryPrimitives.ReadInt64BigEndian(reader.ReadBytes(8));

    private static float[] ReadFloats(BinaryReader reader, int count) {
        float[] values = new float[count];
        for (int i = 0; i < count; i++) {
            values[i] = BitConverter.Int32BitsToSingle(ReadInt32(reader));
        }

        return values;
    }

    private static string ReadJavaUtf(BinaryReader reader) {
        int length = BinaryPrimitives.ReadUInt16BigEndian(reader.ReadBytes(2));
        return System.Text.Encoding.UTF8.GetString(reader.ReadBytes(length));
    }

    private static VanillaWorldgenData Data => VanillaWorldgenData.Load(VanillaPack.Source);

    private static NoiseGeneratorSettings Settings => Data.GetNoiseSettings("minecraft:overworld");

    private static RandomState BuildRandomState(long seed) {
        return new RandomState(VanillaRegistry.Data, Settings, Data.ResolveNoise, seed);
    }

    private static IDensityFunction EntryOf(NoiseGeneratorSettings settings, string name) {
        NoiseRouter router = settings.NoiseRouter;
        AquiferConfig aquifers = settings.Aquifers!;
        return name switch {
            "temperature" => router.Temperature,
            "vegetation" => router.Vegetation,
            "continents" => router.Continents,
            "erosion" => router.Erosion,
            "depth" => router.Depth,
            "ridges" => router.Ridges,
            "chunk_surface_level" => router.ChunkSurfaceLevel,
            "final_density" => router.FinalDensity,
            "aquifer_barrier" => aquifers.Barrier,
            "aquifer_fluid_level_floodedness" => aquifers.FluidLevelFloodedness,
            "aquifer_fluid_level_spread" => aquifers.FluidLevelSpread,
            "aquifer_lava" => aquifers.Lava,
            "aquifer_exclusion" => aquifers.Exclusion,
            "aquifer_surface_level" => aquifers.SurfaceLevel,
            _ => Data.Resolve(Identifier.Parse("minecraft:" + name))
        };
    }

    private static bool Same(float a, float b) => BitConverter.SingleToInt32Bits(a) == BitConverter.SingleToInt32Bits(b) || a == b;

    [Test]
    public void TestPointSamplesMatchVanilla() {
        Fixture fixture = Read();
        RandomState randomState = BuildRandomState(fixture.Seed);
        IDensitySampler[] samplers = Entries.Select(entry => randomState.GetSampler(EntryOf(Settings, entry))).ToArray();
        List<string> failures = [];

        foreach ((int x, int y, int z, float[] expected) in fixture.Points) {
            for (int i = 0; i < Entries.Length; i++) {
                float actual = samplers[i].SampleValue(SamplerContext.EmptyUncached, x, y, z);
                if (Same(actual, expected[i])) {
                    continue;
                }

                failures.Add($"{Entries[i]} at ({x},{y},{z}): vanilla {expected[i]:R}, ours {actual:R}");
                if (failures.Count > 40) {
                    goto done;
                }
            }
        }

        done:
        Assert.That(failures, Is.Empty, $"{failures.Count} point samples differ from vanilla:\n  " + string.Join("\n  ", failures));
    }

    [Test]
    public void TestVolumeSamplesMatchVanilla() {
        Fixture fixture = Read();
        RandomState randomState = BuildRandomState(fixture.Seed);
        NoiseRouter router = Settings.NoiseRouter;
        IDensityFunction[] climate = [router.Temperature, router.Vegetation, router.Continents, router.Erosion, router.Depth, router.Ridges];
        List<string> failures = [];

        foreach (ChunkVolumes chunk in fixture.Volumes) {
            SamplerContext fill = SamplerContext.CreateBuilder().EnableCaches().Build();
            DensityVolume volume = new(16, Height, 16, chunk.ChunkX << 4, MinY, chunk.ChunkZ << 4);
            Compare($"final_density of chunk {chunk.ChunkX},{chunk.ChunkZ}", Sample(randomState, fill, router.FinalDensity, volume),
                chunk.FinalDensity, failures);

            SamplerContext biomes = SamplerContext.CreateBuilder().EnableCaches().Build();
            DensityVolume quarts = new(4, Height >> 2, 4, chunk.ChunkX << 4, MinY, chunk.ChunkZ << 4, 4, 4, 4);
            for (int c = 0; c < climate.Length; c++) {
                Compare($"climate {c} of chunk {chunk.ChunkX},{chunk.ChunkZ}", Sample(randomState, biomes, climate[c], quarts),
                    chunk.Climate[c], failures);
            }

            DensityVolume surface = new(16, 1, 16, chunk.ChunkX << 4, 0, chunk.ChunkZ << 4);
            Compare($"chunk_surface_level of chunk {chunk.ChunkX},{chunk.ChunkZ}", Sample(randomState, fill, router.ChunkSurfaceLevel, surface),
                chunk.SurfaceLevel, failures);
        }

        Assert.That(failures, Is.Empty, $"{failures.Count} volumes differ from vanilla:\n  " + string.Join("\n  ", failures));
    }

    private static float[] Sample(RandomState randomState, SamplerContext context, IDensityFunction function, DensityVolume volume) {
        DensityBuffer buffer = DensityBuffer.CreateUnpooled(volume.Size);
        randomState.GetSampler(function).SampleVolume(context, buffer, volume);
        float[] values = new float[volume.Size];
        for (int i = 0; i < values.Length; i++) {
            values[i] = buffer[i];
        }

        return values;
    }

    /// <summary>One line per volume, naming the first differing index and how many differ.</summary>
    private static void Compare(string what, float[] actual, float[] expected, List<string> failures) {
        int differing = 0;
        int first = -1;
        for (int i = 0; i < expected.Length; i++) {
            if (!Same(actual[i], expected[i])) {
                differing++;
                if (first < 0) {
                    first = i;
                }
            }
        }

        if (differing > 0) {
            failures.Add($"{what}: {differing} of {expected.Length} differ, first at {first}: vanilla {expected[first]:R}, ours {actual[first]:R}");
        }
    }

    [Test]
    public void TestClimateMatchesVanilla() {
        Fixture fixture = Read();
        ClimateSampler sampler = BuildRandomState(fixture.Seed).UncachedClimateSampler();
        List<string> failures = [];

        foreach ((int quartX, int quartY, int quartZ, long[] expected) in fixture.Climate) {
            ClimateTargetPoint actual = sampler.Sample(quartX, quartY, quartZ);
            long[] values = [actual.Temperature, actual.Humidity, actual.Continentalness, actual.Erosion, actual.Depth, actual.Weirdness];
            for (int i = 0; i < values.Length; i++) {
                if (values[i] == expected[i]) {
                    continue;
                }

                failures.Add($"climate {i} at quart ({quartX},{quartY},{quartZ}): vanilla {expected[i]}, ours {values[i]}");
                if (failures.Count > 40) {
                    goto done;
                }
            }
        }

        done:
        Assert.That(failures, Is.Empty, $"{failures.Count} climate samples differ from vanilla:\n  " + string.Join("\n  ", failures));
    }

    [Test]
    public void TestBiomeSearchMatchesVanilla() {
        Fixture fixture = Read();
        ClimateSampler sampler = BuildRandomState(fixture.Seed).UncachedClimateSampler();
        ClimateParameterList<Identifier> parameters = Data.GetBiomeParameters("minecraft:overworld");
        List<string> failures = [];

        for (int i = 0; i < fixture.Climate.Count; i++) {
            (int quartX, int quartY, int quartZ, _) = fixture.Climate[i];
            string actual = parameters.FindValue(sampler.Sample(quartX, quartY, quartZ)).ToString();
            if (actual == fixture.Biomes[i]) {
                continue;
            }

            failures.Add($"biome at quart ({quartX},{quartY},{quartZ}): vanilla {fixture.Biomes[i]}, ours {actual}");
            if (failures.Count > 40) {
                break;
            }
        }

        Assert.That(failures, Is.Empty, $"{failures.Count} biome lookups differ from vanilla:\n  " + string.Join("\n  ", failures));
    }

    [Test]
    public void TestSearchTreeAgreesWithBruteForce() {
        // Whatever the tree's shape, it has to give the same answer as a scan of every region, which is
        // the thing a wrong bounding box or a wrong sort would break.
        ClimateSampler sampler = BuildRandomState(1234567890L).UncachedClimateSampler();
        ClimateParameterList<Identifier> parameters = Data.GetBiomeParameters("minecraft:overworld");

        for (int x = -2000; x <= 2000; x += 137) {
            for (int z = -2000; z <= 2000; z += 149) {
                ClimateTargetPoint target = sampler.Sample(x >> 2, 16, z >> 2);
                Assert.That(parameters.FindValue(target), Is.EqualTo(parameters.FindValueBruteForce(target)),
                    $"Tree and scan disagree at ({x},{z}).");
            }
        }
    }
}
