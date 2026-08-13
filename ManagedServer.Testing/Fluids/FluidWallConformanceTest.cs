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
/// Holds <see cref="FluidBlockData.CanPassThroughWall"/> against the game's own answer, for every pair
/// of collision shapes in it.
/// <para>
/// Everything else in the fluid port is a transcription of a vanilla method, and reads closely enough
/// to one that a careful eye can check it. This is the exception. Vanilla decides whether a boundary
/// stops a fluid by merging two voxel shapes and asking whether the union covers the face; there is no
/// voxel shape on this side to merge, so the same question is answered from the collision boxes. A
/// rule derived from the boxes can be perfectly self consistent and still not be the game's rule,
/// which is exactly what our own tests cannot see.
/// </para>
/// <para>
/// The fixture is <c>Shapes.mergedFaceOccludes</c> run out of the server jar over one state per
/// distinct shape. Regenerate it on a version bump, see Conformance/fluid-wall.sh.
/// </para>
/// </summary>
[TestFixture]
public class FluidWallConformanceTest {
    private const string Fixture = "Fluids/vanilla-fluid-wall.bin.gz";

    private static readonly BlockFace[] Faces = [
        BlockFace.NegY, BlockFace.PosY, BlockFace.NegZ, BlockFace.PosZ, BlockFace.NegX, BlockFace.PosX
    ];

    [Test]
    public void EveryPairOfShapesAgreesWithVanilla() {
        (Vec3<int>[] origins, uint[] states, bool[] answers) = Load();

        MinecraftRegistry registry = VanillaRegistry.Data;
        FluidBlockData.Entry[] entries = states.Select(state => FluidBlockData.Get(registry, state)).ToArray();

        int mismatches = 0;
        string first = "";
        int index = 0;

        foreach (Vec3<int> origin in origins) {
            foreach (FluidBlockData.Entry source in entries) {
                foreach (FluidBlockData.Entry target in entries) {
                    foreach (BlockFace face in Faces) {
                        Vec3<int> targetPos = FluidDirections.Relative(origin, face);
                        bool wanted = answers[index++];
                        bool got = FluidBlockData.CanPassThroughWall(source, origin, target, targetPos, face);
                        if (got == wanted) {
                            continue;
                        }

                        mismatches++;
                        if (first.Length == 0) {
                            first = $"first at {origin}, {Describe(source.Block)} to {Describe(target.Block)} " +
                                    $"{face}: got {got}, vanilla says {wanted}";
                        }
                    }
                }
            }
        }

        Assert.That(mismatches, Is.Zero,
            $"{mismatches} of {answers.Length} boundaries differ from vanilla, {first}");
    }

    private static string Describe(IBlock block) => $"{block.Identifier}[{block.StateId}]";

    private static (Vec3<int>[] Origins, uint[] States, bool[] Answers) Load() {
        string path = Path.Combine(TestContext.CurrentContext.TestDirectory, Fixture);
        Assert.That(File.Exists(path), Is.True,
            $"{Fixture} is missing. Regenerate it with Conformance/fluid-wall.sh.");

        using FileStream file = File.OpenRead(path);
        using GZipStream unzipped = new(file, CompressionMode.Decompress);
        using BinaryReader reader = new(unzipped);

        string magic = Encoding.ASCII.GetString(reader.ReadBytes(12));
        Assert.That(magic, Is.EqualTo("MCFLUIDWALL2"), "unexpected fixture format");

        Vec3<int>[] origins = new Vec3<int>[ReadInt(reader)];
        for (int i = 0; i < origins.Length; i++) {
            origins[i] = new Vec3<int>(ReadInt(reader), ReadInt(reader), ReadInt(reader));
        }

        uint[] states = new uint[ReadInt(reader)];
        for (int i = 0; i < states.Length; i++) {
            states[i] = (uint)ReadInt(reader);
        }

        bool[] answers = new bool[ReadInt(reader)];
        int bits = 0;
        for (int i = 0; i < answers.Length; i++) {
            if (i % 8 == 0) {
                bits = reader.ReadByte();
            }

            answers[i] = (bits >> (i % 8) & 1) != 0;
        }

        return (origins, states, answers);
    }

    /// <summary>Java writes big endian, <see cref="BinaryReader"/> reads little.</summary>
    private static int ReadInt(BinaryReader reader) {
        byte[] bytes = reader.ReadBytes(4);
        return bytes[0] << 24 | bytes[1] << 16 | bytes[2] << 8 | bytes[3];
    }
}
