using System.IO.Compression;
using System.Text.Json;
using ManagedServer.Terrain.Biomes;
using Minecraft.Schemas;

namespace ManagedServer.Testing.Terrain;

/// <summary>
/// Pins <see cref="OverworldBiomeBuilder"/> against the table dumped out of the jar.
/// </summary>
/// <remarks>
/// The overworld's climate table is not in the datapack: the file names a preset and the preset is a
/// thousand lines of parameter ranges compiled into the jar. So it is one of the few pieces of
/// worldgen content transcribed rather than read from a source, and this is what makes that safe.
/// <c>Conformance/biome-parameters.sh</c> writes the fixture.
/// <p/>
/// <b>Compared in order and at exact equality.</b> Both are the reason the test is worth anything: the
/// ranges are quantised longs on both sides so there is nothing to tolerate, and
/// <c>Climate.ParameterList</c> breaks a tie on whichever region was added first, so two builds with
/// the same regions in a different order are two different worlds.
/// </remarks>
public class OverworldBiomeBuilderTest {
    private const string Fixture = "Terrain/vanilla-biome-parameters.json.gz";

    [Test]
    public void EveryOverworldRegionIsTheOneVanillaBuilt() {
        List<(ClimateParameterPoint Point, Identifier Biome)> built = OverworldBiomeBuilder.Build();
        List<(ClimateParameterPoint Point, Identifier Biome)> expected = Load("minecraft:overworld");

        Assert.That(built, Has.Count.EqualTo(expected.Count),
            "the transcription produced a different number of climate regions");

        for (int i = 0; i < expected.Count; i++) {
            Assert.That(built[i].Biome, Is.EqualTo(expected[i].Biome),
                $"region {i} is a different biome");

            Assert.That(built[i].Point, Is.EqualTo(expected[i].Point),
                $"region {i} ({built[i].Biome}) has different parameters");
        }
    }

    [Test]
    public void EveryNetherRegionIsTheOneVanillaBuilt() {
        List<(ClimateParameterPoint Point, Identifier Biome)> built = NetherBiomePreset.Build();
        List<(ClimateParameterPoint Point, Identifier Biome)> expected = Load("minecraft:nether");

        Assert.That(built, Has.Count.EqualTo(expected.Count));

        for (int i = 0; i < expected.Count; i++) {
            Assert.That(built[i].Biome, Is.EqualTo(expected[i].Biome));
            Assert.That(built[i].Point, Is.EqualTo(expected[i].Point));
        }
    }

    /// <summary>
    /// The regions the fixture holds for a preset, in the order the jar produced them.
    /// </summary>
    private static List<(ClimateParameterPoint, Identifier)> Load(string preset) {
        string path = Path.Combine(TestContext.CurrentContext.TestDirectory, Fixture);

        Assert.That(File.Exists(path), $"{Fixture} is missing; run Conformance/biome-parameters.sh.");

        using FileStream raw = File.OpenRead(path);
        using GZipStream decompressed = new(raw, CompressionMode.Decompress);
        using JsonDocument document = JsonDocument.Parse(decompressed);

        List<(ClimateParameterPoint, Identifier)> regions = [];

        foreach (JsonElement entry in document.RootElement.GetProperty(preset).EnumerateArray()) {
            JsonElement ranges = entry.GetProperty("p");

            regions.Add((new ClimateParameterPoint(
                Range(ranges[0]), Range(ranges[1]), Range(ranges[2]), Range(ranges[3]),
                Range(ranges[4]), Range(ranges[5]), entry.GetProperty("offset").GetInt64()),
                Identifier.Parse(entry.GetProperty("biome").GetString()!)));
        }

        return regions;
    }

    /// <summary>Already quantised in the dump, so these are longs rather than floats to convert.</summary>
    private static ClimateParameter Range(JsonElement element) {
        return new ClimateParameter(element[0].GetInt64(), element[1].GetInt64());
    }
}
