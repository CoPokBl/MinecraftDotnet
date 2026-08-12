using System.Collections;
using System.IO.Compression;
using System.Text;
using ManagedServer.Worlds.Lighting;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Testing.Lighting;

/// <summary>
/// Holds the lighting provider against the vanilla light engine, block by block.
/// <para>
/// The fixture is worlds lit by the game's own engine: Conformance/lighting.sh builds a three by
/// three of chunks, runs <c>LevelLightEngine</c> over them and writes down every level it decided
/// on for the middle chunk. Everything light does is a rule of the game rather than of the wire
/// format, so this is the only test here that can tell right from merely self consistent.
/// </para>
/// <para>
/// Regenerate it on a version bump, or when a scenario is added. See Conformance/lighting.sh.
/// </para>
/// </summary>
public class CalculatedLightingProviderConformanceTest {
    private const string Fixture = "Lighting/vanilla-light.bin.gz";

    private static readonly Vec2<int> Centre = new(0, 0);

    [TestCaseSource(nameof(Scenarios))]
    public void MatchesVanilla(Scenario scenario) {
        LightData light = Light(scenario, packed: true);

        int mismatches = 0;
        string first = "";

        for (int y = 0; y < scenario.Height; y++) {
            for (int z = 0; z < 16; z++) {
                for (int x = 0; x < 16; x++) {
                    int index = (y << 8) | (z << 4) | x;
                    int sky = ReadLevel(light.SkyLightMask, light.SkyLight, y, index);
                    int block = ReadLevel(light.BlockLightMask, light.BlockLight, y, index);

                    if (sky != scenario.Sky[index] || block != scenario.Block[index]) {
                        mismatches++;
                        if (first.Length == 0) {
                            first = $"first at ({x}, {y}, {z}) state {scenario.BlockAt(4, index)}: " +
                                    $"sky {sky} wanted {scenario.Sky[index]}, " +
                                    $"block {block} wanted {scenario.Block[index]}";
                        }
                    }
                }
            }
        }

        Assert.That(mismatches, Is.Zero,
            $"{scenario.Name}: {mismatches} of {scenario.Height * 256} blocks differ from vanilla, {first}");
    }

    /// <summary>
    /// The same scenario through the path taken when a chunk's sections haven't been packed into
    /// palettes yet, which reads the blocks one at a time instead of resolving a palette once.
    /// </summary>
    [Test]
    public void UnpackedSectionsMatchPacked() {
        Scenario scenario = Load().First(s => s.Name == "structures");

        LightData packed = Light(scenario, packed: true);
        LightData loose = Light(scenario, packed: false);

        for (int y = 0; y < scenario.Height; y++) {
            for (int z = 0; z < 16; z++) {
                for (int x = 0; x < 16; x++) {
                    int index = (y << 8) | (z << 4) | x;
                    Assert.That(ReadLevel(loose.SkyLightMask, loose.SkyLight, y, index),
                        Is.EqualTo(ReadLevel(packed.SkyLightMask, packed.SkyLight, y, index)),
                        $"sky at ({x}, {y}, {z})");
                    Assert.That(ReadLevel(loose.BlockLightMask, loose.BlockLight, y, index),
                        Is.EqualTo(ReadLevel(packed.BlockLightMask, packed.BlockLight, y, index)),
                        $"block at ({x}, {y}, {z})");
                }
            }
        }
    }

    private static LightData Light(Scenario scenario, bool packed) {
        ChunkData[] chunks = new ChunkData[9];
        for (int slot = 0; slot < 9; slot++) {
            ChunkData chunk = new(scenario.Height);
            for (int index = 0; index < scenario.Height * 256; index++) {
                chunk.SetBlock(index & 15, index >> 8, (index >> 4) & 15, scenario.BlockAt(slot, index));
            }

            if (packed) {
                chunk.PackData();
            }
            chunks[slot] = chunk;
        }

        ChunkData? Lookup(Vec2<int> pos) {
            if (pos.X < -1 || pos.X > 1 || pos.Y < -1 || pos.Y > 1) {
                return null;
            }
            return chunks[(pos.Y + 1) * 3 + pos.X + 1];
        }

        // A fresh provider per call: the cache is keyed by position, and every scenario uses the
        // same one.
        return new CalculatedLightingProvider().GetLighting(Centre, chunks[4], Lookup,
            VanillaRegistry.Data, scenario.HasSkyLight);
    }

    // ── Fixture ─────────────────────────────────────────────────────────────

    public sealed class Scenario {
        public required string Name { get; init; }
        public required int Height { get; init; }
        public required bool HasSkyLight { get; init; }
        public required uint[] Palette { get; init; }
        public required ushort[] Blocks { get; init; }
        public required byte[] Sky { get; init; }
        public required byte[] Block { get; init; }

        public uint BlockAt(int slot, int index) {
            return Palette[Blocks[slot * Height * 256 + index]];
        }

        public override string ToString() {
            return Name;
        }
    }

    private static IEnumerable<Scenario> Scenarios() {
        return Load();
    }

    private static Scenario[] Load() {
        string path = Path.Combine(TestContext.CurrentContext.TestDirectory, Fixture);
        Assert.That(File.Exists(path), Is.True,
            $"{Fixture} is missing. Regenerate it with Conformance/lighting.sh.");

        using FileStream file = File.OpenRead(path);
        using GZipStream unzipped = new(file, CompressionMode.Decompress);
        using BinaryReader reader = new(unzipped);

        string magic = Encoding.ASCII.GetString(reader.ReadBytes(8));
        Assert.That(magic, Is.EqualTo("MCLIGHT1"), "unexpected fixture format");

        Scenario[] scenarios = new Scenario[ReadInt(reader)];
        for (int i = 0; i < scenarios.Length; i++) {
            string name = ReadUtf(reader);
            int height = ReadInt(reader);
            bool hasSkyLight = reader.ReadByte() != 0;

            uint[] palette = new uint[ReadInt(reader)];
            for (int p = 0; p < palette.Length; p++) {
                palette[p] = (uint)ReadInt(reader);
            }

            int blocksPerChunk = height * 256;
            ushort[] blocks = new ushort[9 * blocksPerChunk];
            for (int b = 0; b < blocks.Length; b++) {
                blocks[b] = (ushort)((reader.ReadByte() << 8) | reader.ReadByte());
            }

            scenarios[i] = new Scenario {
                Name = name,
                Height = height,
                HasSkyLight = hasSkyLight,
                Palette = palette,
                Blocks = blocks,
                Sky = reader.ReadBytes(blocksPerChunk),
                Block = reader.ReadBytes(blocksPerChunk)
            };
        }

        return scenarios;
    }

    // The fixture comes out of a Java DataOutputStream, which is big endian and writes a string as
    // a two byte length and its UTF-8.
    private static int ReadInt(BinaryReader reader) {
        return (reader.ReadByte() << 24) | (reader.ReadByte() << 16)
            | (reader.ReadByte() << 8) | reader.ReadByte();
    }

    private static string ReadUtf(BinaryReader reader) {
        int length = (reader.ReadByte() << 8) | reader.ReadByte();
        return Encoding.UTF8.GetString(reader.ReadBytes(length));
    }

    /// <summary>Reads one block's level back out of the packet's per section nibble arrays.</summary>
    private static int ReadLevel(BitArray mask, byte[][] arrays, int y, int index) {
        int bit = y / 16 + 1;
        if (!mask.Get(bit)) {
            return 0;
        }

        int array = 0;
        for (int i = 0; i < bit; i++) {
            if (mask.Get(i)) {
                array++;
            }
        }

        int at = (index & 0xFF) | ((y % 16) << 8);
        return (arrays[array][at >> 1] >> ((at & 1) << 2)) & 0xF;
    }
}
