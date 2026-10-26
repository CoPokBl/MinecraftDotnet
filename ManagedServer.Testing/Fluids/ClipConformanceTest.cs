using System.IO.Compression;
using System.Text;
using ManagedServer.Fluids;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Testing.Fluids;

/// <summary>
/// Holds <see cref="FluidRaycast.Clip"/> against the game's own <c>Level.clip</c>, over one state per
/// distinct pickable shape and a fan of rays at each.
/// <para>
/// The clip decides which block a bucket fills, and three things about it are invisible to a test
/// written on this side alone. It reads the <b>outline</b> shape, not the collision shape, so a torch
/// stops a ray that nothing collides with. The face of a hit comes from the box that was struck, not
/// from the block boundary the ray last crossed, which is a different answer for every shape that does
/// not reach its own boundary. And the interaction shape can replace that face without moving the hit.
/// A port can get all three wrong and still agree with itself.
/// </para>
/// <para>
/// The fixture is <c>BlockGetter.clip</c> run out of the server jar. Regenerate it on a version bump,
/// see Conformance/clip.sh.
/// </para>
/// </summary>
[TestFixture]
public class ClipConformanceTest {
    private const string Fixture = "Fluids/vanilla-clip.bin.gz";

    /// <summary><c>Direction</c> in declaration order, which is what the fixture stores.</summary>
    private static readonly BlockFace[] Faces = [
        BlockFace.NegY, BlockFace.PosY, BlockFace.NegZ, BlockFace.PosZ, BlockFace.NegX, BlockFace.PosX
    ];

    /// <summary>The fixture covers a filled bucket's clip and then an empty one's, for every ray.</summary>
    private static readonly bool[] FluidModes = [false, true];

    private readonly record struct Ray(Vec3<double> From, Vec3<double> To);

    private readonly record struct Result(bool Hit, Vec3<int> Pos, BlockFace Face);

    [Test]
    public void EveryRayAgreesWithVanilla() {
        (Vec3<int>[] origins, uint[] states, Ray[] rays, Result[] expected) = Load();

        MinecraftRegistry registry = VanillaRegistry.Data;
        FluidBlockData.Entry air = FluidBlockData.Get(registry, Block.Air.StateId);

        int mismatches = 0;
        string first = "";
        int index = 0;

        foreach (Vec3<int> origin in origins) {
            foreach (uint stateId in states) {
                FluidBlockData.Entry entry = FluidBlockData.Get(registry, stateId);

                // The scene the harness clipped against: the one block, and air everywhere else.
                Func<Vec3<int>, FluidBlockData.Entry> scene = pos => pos == origin ? entry : air;

                foreach (Ray ray in rays) {
                    Vec3<double> from = Offset(ray.From, origin);
                    Vec3<double> to = Offset(ray.To, origin);

                    foreach (bool sourceOnly in FluidModes) {
                        Result wanted = expected[index++];
                        FluidRaycast.Hit? got = FluidRaycast.Clip(scene, from, to, sourceOnly);

                        if (Matches(got, wanted)) {
                            continue;
                        }

                        mismatches++;
                        if (first.Length == 0) {
                            first = $"first at {origin}, {Describe(entry.Block)}, " +
                                    $"{(sourceOnly ? "source_only" : "none")}, ray {from} -> {to}: " +
                                    $"got {Describe(got)}, vanilla says {Describe(wanted)}";
                        }
                    }
                }
            }
        }

        Assert.That(mismatches, Is.Zero, $"{mismatches} of {expected.Length} rays differ from vanilla, {first}");
    }

    private static bool Matches(FluidRaycast.Hit? got, Result wanted) {
        if (got == null) {
            return !wanted.Hit;
        }

        return wanted.Hit && got.Value.Pos == wanted.Pos && got.Value.Face == wanted.Face;
    }

    private static Vec3<double> Offset(Vec3<double> local, Vec3<int> origin) {
        return new Vec3<double>(local.X + origin.X, local.Y + origin.Y, local.Z + origin.Z);
    }

    private static string Describe(IBlock block) => $"{block.Identifier}[{block.StateId}]";

    private static string Describe(FluidRaycast.Hit? hit) => hit == null ? "miss" : $"{hit.Value.Pos} {hit.Value.Face}";

    private static string Describe(Result result) => result.Hit ? $"{result.Pos} {result.Face}" : "miss";

    private static (Vec3<int>[] Origins, uint[] States, Ray[] Rays, Result[] Expected) Load() {
        string path = Path.Combine(TestContext.CurrentContext.TestDirectory, Fixture);
        Assert.That(File.Exists(path), Is.True, $"{Fixture} is missing. Regenerate it with Conformance/clip.sh.");

        using FileStream file = File.OpenRead(path);
        using GZipStream unzipped = new(file, CompressionMode.Decompress);
        using BinaryReader reader = new(unzipped);

        string magic = Encoding.ASCII.GetString(reader.ReadBytes(7));
        Assert.That(magic, Is.EqualTo("MCCLIP1"), "unexpected fixture format");

        Vec3<int>[] origins = new Vec3<int>[ReadInt(reader)];
        for (int i = 0; i < origins.Length; i++) {
            origins[i] = new Vec3<int>(ReadInt(reader), ReadInt(reader), ReadInt(reader));
        }

        uint[] states = new uint[ReadInt(reader)];
        for (int i = 0; i < states.Length; i++) {
            states[i] = (uint)ReadInt(reader);
        }

        Ray[] rays = new Ray[ReadInt(reader)];
        for (int i = 0; i < rays.Length; i++) {
            rays[i] = new Ray(
                new Vec3<double>(ReadDouble(reader), ReadDouble(reader), ReadDouble(reader)),
                new Vec3<double>(ReadDouble(reader), ReadDouble(reader), ReadDouble(reader)));
        }

        Result[] expected = new Result[origins.Length * states.Length * rays.Length * FluidModes.Length];
        for (int i = 0; i < expected.Length; i++) {
            if (reader.ReadByte() == 0) {
                continue;
            }

            expected[i] = new Result(true,
                new Vec3<int>(ReadInt(reader), ReadInt(reader), ReadInt(reader)),
                Faces[reader.ReadByte()]);
        }

        return (origins, states, rays, expected);
    }

    /// <summary>Java writes big endian, <see cref="BinaryReader"/> reads little.</summary>
    private static int ReadInt(BinaryReader reader) {
        byte[] bytes = reader.ReadBytes(4);
        return bytes[0] << 24 | bytes[1] << 16 | bytes[2] << 8 | bytes[3];
    }

    private static double ReadDouble(BinaryReader reader) {
        byte[] bytes = reader.ReadBytes(8);
        Array.Reverse(bytes);
        return BitConverter.ToDouble(bytes);
    }
}
