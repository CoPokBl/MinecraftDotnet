using System.Buffers.Binary;
using System.IO.Compression;
using System.Text;
using ManagedServer.Terrain;
using ManagedServer.Terrain.Features;
using Minecraft.Schemas;

namespace ManagedServer.Testing.Terrain;

/// <summary>
/// Holds the global feature order against vanilla's own, from the fixture
/// <c>Conformance/featureorder.sh</c> produced.
/// </summary>
/// <remarks>
/// A feature's <b>index in this list</b> is what seeds it, so this decides where every tree, patch and
/// ore blob in the world lands. Nothing about a feature says what its index should be: it comes out of
/// a topological sort over every biome's list, and where that sort has no opinion the tie goes to
/// whichever biome mentioned the feature first. So the answer depends on which biomes are fed in and
/// in what order, and both are easy to get plausibly wrong. Nothing fails when they are: the world
/// generates, with everything in it somewhere else.
/// <p/>
/// The biome list is compared as well as the order, because it is the input the order is a function of
/// and a difference there is the thing worth reading.
/// </remarks>
[TestFixture]
public class FeatureOrderConformanceTest {
    private const string Fixture = "Terrain/vanilla-feature-order.bin.gz";

    private sealed record Dimension(string Name, string[] Biomes, string[][] Steps);

    private static Dimension[] Read() {
        string path = Path.Combine(TestContext.CurrentContext.TestDirectory, Fixture);

        using FileStream file = File.OpenRead(path);
        using GZipStream gzip = new(file, CompressionMode.Decompress);
        using BinaryReader reader = new(gzip);

        Dimension[] dimensions = new Dimension[ReadInt32(reader)];

        for (int i = 0; i < dimensions.Length; i++) {
            string name = ReadJavaUtf(reader);

            string[] biomes = new string[ReadInt32(reader)];
            for (int biome = 0; biome < biomes.Length; biome++) {
                biomes[biome] = ReadJavaUtf(reader);
            }

            string[][] steps = new string[ReadInt32(reader)][];
            for (int step = 0; step < steps.Length; step++) {
                steps[step] = new string[ReadInt32(reader)];
                for (int feature = 0; feature < steps[step].Length; feature++) {
                    steps[step][feature] = ReadJavaUtf(reader);
                }
            }

            dimensions[i] = new Dimension(name, biomes, steps);
        }

        return dimensions;
    }

    // Java's DataOutputStream is big endian throughout; BinaryReader is little endian.
    private static int ReadInt32(BinaryReader reader) =>
        BinaryPrimitives.ReadInt32BigEndian(reader.ReadBytes(4));

    private static string ReadJavaUtf(BinaryReader reader) {
        int length = BinaryPrimitives.ReadUInt16BigEndian(reader.ReadBytes(2));
        return Encoding.UTF8.GetString(reader.ReadBytes(length));
    }

    private static VanillaTerrainGenerator GeneratorFor(string dimension) {
        return dimension switch {
            "minecraft:overworld" => VanillaTerrainGenerator.Overworld(VanillaPack.Source, 0L),
            "minecraft:nether" => VanillaTerrainGenerator.Nether(VanillaPack.Source, 0L),
            _ => throw new ArgumentException($"The fixture names a dimension {dimension} nothing builds.")
        };
    }

    [Test]
    public void EachBiomeSourceOffersTheBiomesVanillaSays() {
        foreach (Dimension dimension in Read()) {
            IReadOnlyList<Identifier> ours = GeneratorFor(dimension.Name).PossibleBiomes;

            Assert.That(ours.Select(id => id.ToString()).ToArray(), Is.EqualTo(dimension.Biomes),
                $"{dimension.Name}: the biomes the source can produce, in order. That order is what "
                + "the feature sorter breaks its ties by.");
        }
    }

    [Test]
    public void TheGlobalFeatureOrderMatchesVanilla() {
        VanillaFeatureData data = VanillaFeatureData.Load(VanillaPack.Source);

        foreach (Dimension dimension in Read()) {
            BiomeFeatureTable table =
                data.TableFor(GeneratorFor(dimension.Name).PossibleBiomes);

            // Vanilla drops a step nothing reaches off the end of its list; ours keeps as many steps as
            // the biomes have. Comparing the steps vanilla has is the whole of what seeds anything.
            Assert.That(table.StepCount, Is.GreaterThanOrEqualTo(dimension.Steps.Length),
                $"{dimension.Name}: fewer decoration steps than vanilla has features for.");

            for (int step = 0; step < dimension.Steps.Length; step++) {
                // The whole list, untranscribed slots included. A feature's index in it is what seeds
                // it, so a slot dropped rather than left empty renumbers everything after it and puts
                // it somewhere else; comparing only the features that were built cannot see that.
                string[] ours = table.GlobalStep(step)
                    .Select(feature => feature?.Id?.ToString() ?? "<not transcribed>")
                    .ToArray();

                string[] theirs = dimension.Steps[step]
                    .Select(id => table.GlobalStep(step).Any(feature => feature?.Id?.ToString() == id)
                        ? id
                        : "<not transcribed>")
                    .ToArray();

                Assert.That(ours, Is.EqualTo(theirs),
                    $"{dimension.Name} step {step}: the global feature order differs from vanilla's, so "
                    + "every feature after the first difference is seeded wrongly.");
            }
        }
    }
}
