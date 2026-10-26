using System.IO.Compression;
using System.Numerics;
using ClientLib.Sky;
using ClientLib.World;

namespace ClientLib.Testing.Sky;

/// <summary>
/// Holds <see cref="SkyMeshes"/> to the vertex bytes the client's own <c>SkyRenderer</c> builds: every star's four
/// corners, both sky discs, the sunrise fan and the end sky box, position, texture coordinate and colour, bit for bit;
/// and <see cref="EndFlashState"/> to the client's own, tick by tick.
/// <para>The fixture is the client jar's; regenerate it on a version bump with Conformance/skymesh.sh.</para>
/// </summary>
public class SkyMeshConformanceTest {
    private const string Fixture = "Sky/vanilla-sky.bin.gz";

    private static Dictionary<string, byte[]> ReadFixture() {
        string path = Path.Combine(TestContext.CurrentContext.TestDirectory, Fixture);
        Assert.That(File.Exists(path), Is.True, $"{Fixture} is missing. Regenerate it with Conformance/skymesh.sh.");
        using BinaryReader reader = new(new GZipStream(File.OpenRead(path), CompressionMode.Decompress));
        Dictionary<string, byte[]> buffers = new();
        while (true) {
            string name = ReadUtf(reader);
            int length = ReadBigEndianInt(reader);
            if (name == "starIndexCount") {
                buffers[name] = BitConverter.GetBytes(length);
                return buffers;
            }
            buffers[name] = reader.ReadBytes(length);
        }
    }

    private static string ReadUtf(BinaryReader reader) {
        int length = reader.ReadByte() << 8 | reader.ReadByte();
        return System.Text.Encoding.UTF8.GetString(reader.ReadBytes(length));
    }

    private static int ReadBigEndianInt(BinaryReader reader) {
        byte[] b = reader.ReadBytes(4);
        return b[0] << 24 | b[1] << 16 | b[2] << 8 | b[3];
    }

    /// <summary>The bytes vanilla's vertex formats lay a vertex out as: floats, then the colour's red, green, blue and alpha bytes.</summary>
    private static byte[] Bytes(IEnumerable<SkyVertex> vertices, bool uv, bool colour) {
        List<byte> bytes = [];
        foreach (SkyVertex vertex in vertices) {
            bytes.AddRange(BitConverter.GetBytes(vertex.Position.X));
            bytes.AddRange(BitConverter.GetBytes(vertex.Position.Y));
            bytes.AddRange(BitConverter.GetBytes(vertex.Position.Z));
            if (uv) {
                bytes.AddRange(BitConverter.GetBytes(vertex.Uv.X));
                bytes.AddRange(BitConverter.GetBytes(vertex.Uv.Y));
            }
            if (colour) {
                uint c = vertex.Colour;
                bytes.AddRange([(byte)(c >> 16), (byte)(c >> 8), (byte)c, (byte)(c >> 24)]);
            }
        }
        return bytes.ToArray();
    }

    private static byte[] Positions(Vector3[] positions) => Bytes(positions.Select(p => new SkyVertex(p, Vector2.Zero, 0)), false, false);

    [Test]
    public void EveryMeshMatchesVanillaBitForBit() {
        Dictionary<string, byte[]> vanilla = ReadFixture();
        Vector3[] stars = SkyMeshes.Stars();
        Assert.Multiple(() => {
            Assert.That(Positions(stars), Is.EqualTo(vanilla["Stars vertex buffer"]), "stars");
            Assert.That(stars.Length / 4 * 6, Is.EqualTo(BitConverter.ToInt32(vanilla["starIndexCount"])), "star index count");
            Assert.That(Positions(SkyMeshes.SkyDisc(16.0F)), Is.EqualTo(vanilla["Top sky vertex buffer"]), "sky disc");
            Assert.That(Positions(SkyMeshes.SkyDisc(-16.0F)), Is.EqualTo(vanilla["Bottom sky vertex buffer"]), "dark disc");
            Assert.That(Bytes(SkyMeshes.SunriseFan(), false, true), Is.EqualTo(vanilla["Sunrise/Sunset fan"]), "sunrise fan");
            Assert.That(Bytes(SkyMeshes.EndSky(), true, true), Is.EqualTo(vanilla["End sky vertex buffer"]), "end sky");
        });
    }

    [Test]
    public void EndFlashesMatchVanillaTickForTick() {
        byte[] vanilla = ReadFixture()["End flash"];
        long[] ticks = [..Enumerable.Range(0, 3000).Select(t => (long)t), ..Enumerable.Range(0, 3000).Select(t => 123_456_000L + t)];
        Assert.That(vanilla.Length, Is.EqualTo(ticks.Length * 12));
        EndFlashState flash = new();
        for (int i = 0; i < ticks.Length; i++) {
            flash.Tick(ticks[i]);
            float[] expected = [BitConverter.ToSingle(vanilla, i * 12), BitConverter.ToSingle(vanilla, i * 12 + 4), BitConverter.ToSingle(vanilla, i * 12 + 8)];
            float[] actual = [flash.GetIntensity(1.0F), flash.XAngle, flash.YAngle];
            Assert.That(actual, Is.EqualTo(expected), $"clock time {ticks[i]}");
        }
    }
}
