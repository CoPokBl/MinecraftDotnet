using System.Buffers.Binary;
using System.IO.Compression;
using ManagedServer.Terrain;
using ManagedServer.Terrain.Biomes;
using ManagedServer.Terrain.Density;
using Minecraft.Schemas;

namespace ManagedServer.Testing.Terrain;

/// <summary>
/// Replays what the real vanilla noise router said, from the fixture <c>Conformance/terrain.sh</c>
/// produced.
/// </summary>
/// <remarks>
/// This is the test that decides whether the density function port is right. Our own tests encode the
/// same reading of the jar the port does, so a wrong constant or a spline derivative read off by one
/// passes them all and produces a different world. Pinning the fifteen router entries pins the noise
/// primitives, the whole function tree, the JSON parsing, the per octave seeding and the climate
/// quantisation at once.
/// <p/>
/// The tolerance is <b>exact zero</b> on purpose. Every operation is a transcription of a double
/// expression in the same order, so the two sides should agree bit for bit; a tolerance would hide
/// exactly the reordering and premature widening it is there to catch. The one exception is spelled
/// out on <see cref="Tolerance"/>.
/// </remarks>
[TestFixture]
public class TerrainConformanceTest {
    /// <summary>
    /// The order the harness wrote the doubles in, which is <c>TerrainHarness.ROUTER_ENTRIES</c>.
    /// </summary>
    private static readonly string[] RouterEntries = [
        "barrier", "fluid_level_floodedness", "fluid_level_spread", "lava",
        "temperature", "vegetation", "continents", "erosion", "depth", "ridges",
        "preliminary_surface_level", "final_density", "vein_toggle", "vein_ridged", "vein_gap"
    ];

    /// <summary>
    /// Zero, because both sides run the same arithmetic in the same order on the same doubles. A
    /// failure here is a real difference in what the port computes, not floating point noise.
    /// </summary>
    private const double Tolerance = 0.0;

    private static string FixturePath =>
        Path.Combine(TestContext.CurrentContext.TestDirectory, "Terrain", "vanilla-terrain.bin.gz");

    private sealed record Fixture(
        long Seed,
        List<(int X, int Y, int Z, double[] Values)> Router,
        List<(int QuartX, int QuartY, int QuartZ, long[] Climate)> Climate,
        List<string> Biomes);

    private static Fixture Read() {
        using FileStream file = File.OpenRead(FixturePath);
        using GZipStream gzip = new(file, CompressionMode.Decompress);
        using BinaryReader reader = new(gzip);

        long seed = ReadInt64(reader);

        int routerCount = ReadInt32(reader);
        List<(int, int, int, double[])> router = new(routerCount);
        for (int i = 0; i < routerCount; i++) {
            int x = ReadInt32(reader);
            int y = ReadInt32(reader);
            int z = ReadInt32(reader);

            double[] values = new double[RouterEntries.Length];
            for (int v = 0; v < values.Length; v++) {
                values[v] = BitConverter.Int64BitsToDouble(ReadInt64(reader));
            }

            router.Add((x, y, z, values));
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

        int biomeCount = ReadInt32(reader);
        List<string> biomes = new(biomeCount);
        for (int i = 0; i < biomeCount; i++) {
            biomes.Add(ReadJavaUtf(reader));
        }

        return new Fixture(seed, router, climate, biomes);
    }

    // Java's DataOutputStream is big endian throughout; BinaryReader is little endian.
    private static int ReadInt32(BinaryReader reader) =>
        BinaryPrimitives.ReadInt32BigEndian(reader.ReadBytes(4));

    private static long ReadInt64(BinaryReader reader) =>
        BinaryPrimitives.ReadInt64BigEndian(reader.ReadBytes(8));

    private static string ReadJavaUtf(BinaryReader reader) {
        int length = BinaryPrimitives.ReadUInt16BigEndian(reader.ReadBytes(2));
        return System.Text.Encoding.UTF8.GetString(reader.ReadBytes(length));
    }

    private static RandomState BuildRandomState(long seed) {
        VanillaWorldgenData data = VanillaWorldgenData.Load(VanillaPack.Source);
        return new RandomState(data.GetNoiseSettings("minecraft:overworld"), data.NoiseParameters, seed);
    }

    private static IDensityFunction EntryOf(NoiseRouter router, string name) {
        return name switch {
            "barrier" => router.Barrier,
            "fluid_level_floodedness" => router.FluidLevelFloodedness,
            "fluid_level_spread" => router.FluidLevelSpread,
            "lava" => router.Lava,
            "temperature" => router.Temperature,
            "vegetation" => router.Vegetation,
            "continents" => router.Continents,
            "erosion" => router.Erosion,
            "depth" => router.Depth,
            "ridges" => router.Ridges,
            "preliminary_surface_level" => router.PreliminarySurfaceLevel,
            "final_density" => router.FinalDensity,
            "vein_toggle" => router.VeinToggle,
            "vein_ridged" => router.VeinRidged,
            "vein_gap" => router.VeinGap,
            _ => throw new ArgumentException($"Unknown router entry {name}")
        };
    }

    [Test]
    public void TestRouterMatchesVanilla() {
        Fixture fixture = Read();
        RandomState randomState = BuildRandomState(fixture.Seed);

        // Markers stripped, as the harness samples: a cache only means something inside a chunk's walk
        // and computes exactly what it wraps outside one.
        NoiseRouter router = randomState.Router.MapAll(new StripMarkers());

        List<string> failures = [];

        foreach ((int x, int y, int z, double[] expected) in fixture.Router) {
            SinglePointContext context = new(x, y, z);

            for (int i = 0; i < RouterEntries.Length; i++) {
                double actual = EntryOf(router, RouterEntries[i]).Compute(context);
                if (Math.Abs(actual - expected[i]) <= Tolerance) {
                    continue;
                }

                failures.Add($"{RouterEntries[i]} at ({x},{y},{z}): vanilla {expected[i]:R}, ours {actual:R}");

                // One line per entry is enough to identify which part of the tree is wrong; a full
                // list would be thousands of lines of the same failure.
                if (failures.Count > 40) {
                    goto done;
                }
            }
        }

        done:
        Assert.That(failures, Is.Empty,
            $"{failures.Count} router samples differ from vanilla:\n  " + string.Join("\n  ", failures));
    }

    [Test]
    public void TestClimateMatchesVanilla() {
        Fixture fixture = Read();
        RandomState randomState = BuildRandomState(fixture.Seed);
        ClimateSampler sampler = randomState.Sampler;

        List<string> failures = [];

        foreach ((int quartX, int quartY, int quartZ, long[] expected) in fixture.Climate) {
            ClimateTargetPoint actual = sampler.Sample(quartX, quartY, quartZ);
            long[] values = [
                actual.Temperature, actual.Humidity, actual.Continentalness,
                actual.Erosion, actual.Depth, actual.Weirdness
            ];

            for (int i = 0; i < values.Length; i++) {
                if (values[i] == expected[i]) {
                    continue;
                }

                failures.Add($"climate {i} at quart ({quartX},{quartY},{quartZ}): " +
                    $"vanilla {expected[i]}, ours {values[i]}");

                if (failures.Count > 40) {
                    goto done;
                }
            }
        }

        done:
        Assert.That(failures, Is.Empty,
            $"{failures.Count} climate samples differ from vanilla:\n  " + string.Join("\n  ", failures));
    }

    [Test]
    public void TestBiomeSearchMatchesVanilla() {
        Fixture fixture = Read();
        RandomState randomState = BuildRandomState(fixture.Seed);
        ClimateSampler sampler = randomState.Sampler;

        ClimateParameterList<Identifier> parameters =
            VanillaWorldgenData.Load(VanillaPack.Source).GetBiomeParameters("minecraft:overworld");

        List<string> failures = [];

        for (int i = 0; i < fixture.Climate.Count; i++) {
            (int quartX, int quartY, int quartZ, _) = fixture.Climate[i];
            string actual = parameters.FindValue(sampler.Sample(quartX, quartY, quartZ)).ToString();

            if (actual == fixture.Biomes[i]) {
                continue;
            }

            failures.Add($"biome at quart ({quartX},{quartY},{quartZ}): " +
                $"vanilla {fixture.Biomes[i]}, ours {actual}");

            if (failures.Count > 40) {
                break;
            }
        }

        Assert.That(failures, Is.Empty,
            $"{failures.Count} biome lookups differ from vanilla:\n  " + string.Join("\n  ", failures));
    }

    [Test]
    public void TestSearchTreeAgreesWithBruteForce() {
        // The R-tree is a shape rather than an ordering, so it does not have to match vanilla's node
        // for node. What it does have to do is give the same answer as a scan of all 7599 regions,
        // which is the thing a wrong bounding box or a wrong sort would break.
        RandomState randomState = BuildRandomState(1234567890L);
        ClimateSampler sampler = randomState.Sampler;

        ClimateParameterList<Identifier> parameters =
            VanillaWorldgenData.Load(VanillaPack.Source).GetBiomeParameters("minecraft:overworld");

        for (int x = -2000; x <= 2000; x += 137) {
            for (int z = -2000; z <= 2000; z += 149) {
                ClimateTargetPoint target = sampler.Sample(x >> 2, 16, z >> 2);
                Assert.That(parameters.FindValue(target), Is.EqualTo(parameters.FindValueBruteForce(target)),
                    $"Tree and scan disagree at ({x},{z}).");
            }
        }
    }

    private sealed class StripMarkers : IDensityFunctionVisitor {
        public IDensityFunction Apply(IDensityFunction input) {
            return input is IMarkerOrMarked marker ? marker.Wrapped : input;
        }
    }
}
