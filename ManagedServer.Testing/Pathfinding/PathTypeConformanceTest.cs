using System.IO.Compression;
using System.Text;
using ManagedServer.Entities.Types;
using ManagedServer.Pathfinding;
using ManagedServer.Worlds;
using ManagedServer.Worlds.Lighting;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Implementations.Server.Terrain.Providers;
using Minecraft.Schemas.Vec;
using Minecraft.Placement;

namespace ManagedServer.Testing.Pathfinding;

/// <summary>
/// Holds the block classification against the game's own <c>WalkNodeEvaluator</c>.
/// <para>
/// Nothing here reaches a client, so there is no desync to catch; the problem is that every rule in
/// <see cref="BlockPathData"/> is one a hand written test would encode from the same reading of the
/// jar, and would then agree with. A mob that treats a closed wooden door as a wall, a lily pad as
/// open air, or a square beside lava as safe passes any test written from the same misreading.
/// </para>
/// <para>
/// Two halves, because they fail differently. <see cref="EveryBlockStateAgreesWithVanilla"/> covers
/// the per state classification exhaustively, all thirty thousand of them.
/// <see cref="EverySceneAgreesWithVanilla"/> covers the two rules above it that read blocks other
/// than the one being asked about: what standing <b>on</b> something means, and the neighbour scan
/// that makes a mob refuse a square beside a fire.
/// </para>
/// <para>
/// The fixture is the real evaluator run out of the server jar. Regenerate it on a version bump, see
/// Conformance/pathtype.sh.
/// </para>
/// </summary>
[TestFixture]
public class PathTypeConformanceTest {
    private const string Fixture = "Pathfinding/vanilla-pathtype.bin.gz";

    /// <summary>Write the state that was asked for and nothing else: no shape cascade, no clients.</summary>
    private const int Verbatim = BlockUpdateFlags.KnownShape;

    private readonly record struct Placed(Vec3<int> Pos, uint StateId);

    private readonly record struct Scene(Placed[] Blocks, PathType Expected);

    private sealed record Loaded(string[] TypeNames, float[] Malus, PathType[] ByState, Scene[] Scenes);

    /// <summary>
    /// The names travel with the fixture and are matched on rather than the ordinals, because these
    /// are enum positions: an insertion upstream shifts every one after it, and a shifted ordinal is
    /// still a perfectly valid type that would compare equal to the wrong thing.
    /// </summary>
    [Test]
    public void TheTypeTableMatchesVanilla() {
        Loaded fixture = Load();
        string[] ours = Enum.GetNames<PathType>();

        Assert.That(ours.Length, Is.EqualTo(fixture.TypeNames.Length), "PathType has a different number of members");

        for (int i = 0; i < ours.Length; i++) {
            // The generator writes vanilla's SCREAMING_CASE as PascalCase, so the comparison drops
            // the underscores rather than assuming a mapping.
            string expected = fixture.TypeNames[i].Replace("_", "");
            Assert.That(ours[i], Is.EqualTo(expected).IgnoreCase, $"PathType member {i} differs");
            Assert.That(PathTypeMalus.Of((PathType)i), Is.EqualTo(fixture.Malus[i]),
                $"malus of {ours[i]} differs");
        }
    }

    [Test]
    public void EveryBlockStateAgreesWithVanilla() {
        Loaded fixture = Load();
        MinecraftRegistry registry = VanillaRegistry.Data;

        Assert.That(fixture.ByState.Length, Is.EqualTo(registry.Blocks.StatesByStateId.Count),
            "the fixture was built for a different number of block states");

        int mismatches = 0;
        string first = "";

        for (uint state = 0; state < fixture.ByState.Length; state++) {
            PathType got = BlockPathData.Of(registry, state);
            PathType wanted = fixture.ByState[state];

            if (got == wanted) {
                continue;
            }

            mismatches++;
            if (first.Length == 0) {
                IBlock block = registry.Blocks.StatesByStateId[state].WithState(state);
                first = $"first at {block.Identifier}[{state}]: got {got}, vanilla says {wanted}";
            }
        }

        Assert.That(mismatches, Is.Zero,
            $"{mismatches} of {fixture.ByState.Length} block states differ from vanilla, {first}");
    }

    [Test]
    public void EverySceneAgreesWithVanilla() {
        Loaded fixture = Load();

        ManagedMinecraftServer server = new() { LogAction = _ => { } };
        World world = server.CreateWorld(new VoidProvider(), "minecraft:overworld", new FullBrightLightingProvider());
        world.LoadChunk(new Vec2<int>(0, 0)).Wait();
        world.LoadChunk(new Vec2<int>(-1, 0)).Wait();
        world.LoadChunk(new Vec2<int>(0, -1)).Wait();
        world.LoadChunk(new Vec2<int>(-1, -1)).Wait();

        Mob mob = new(EntityType.Zombie) { Position = Vec3<double>.Zero };
        mob.SetWorld(world);

        int mismatches = 0;
        string first = "";
        List<Vec3<int>> placed = [];

        foreach (Scene scene in fixture.Scenes) {
            // Only what the last scene put down is cleared. Scenes overlap on the origin, so leaving
            // a block behind would silently make the next one a different scene.
            // UPDATE_KNOWN_SHAPE throughout: the fixture names the exact states vanilla asked about,
            // so the scene is built verbatim and the shape cascade must not get an opinion. Without it
            // the cocoa scenes lose their cocoa to its own survival rule before anything is measured.
            foreach (Vec3<int> pos in placed) {
                world.SetBlock(pos, Block.Air, flags: Verbatim);
            }

            placed.Clear();

            foreach (Placed block in scene.Blocks) {
                world.SetBlock(block.Pos, world.Server.Registry.Blocks.StatesByStateId[block.StateId]
                    .WithState(block.StateId), flags: Verbatim);
                placed.Add(block.Pos);
            }

            PathfindingContext context = new(world, mob);
            PathType got = WalkNodeEvaluator.GetPathTypeStatic(context, 0, 0, 0);

            if (got == scene.Expected) {
                continue;
            }

            mismatches++;
            if (first.Length == 0) {
                first = "first at [" + string.Join(", ", scene.Blocks.Select(b =>
                    $"{b.Pos}={world.Server.Registry.Blocks.StatesByStateId[b.StateId].Identifier}")) +
                    $"]: got {got}, vanilla says {scene.Expected}";
            }
        }

        server.Stop();

        Assert.That(mismatches, Is.Zero,
            $"{mismatches} of {fixture.Scenes.Length} scenes differ from vanilla, {first}");
    }

    private static Loaded Load() {
        string path = System.IO.Path.Combine(TestContext.CurrentContext.TestDirectory, Fixture);
        Assert.That(File.Exists(path), Is.True, $"{Fixture} is missing. Regenerate it with Conformance/pathtype.sh.");

        using FileStream file = File.OpenRead(path);
        using GZipStream unzipped = new(file, CompressionMode.Decompress);
        using BinaryReader reader = new(unzipped);

        string magic = Encoding.ASCII.GetString(reader.ReadBytes(7));
        Assert.That(magic, Is.EqualTo("MCPATH1"), "unexpected fixture format");

        int typeCount = ReadInt(reader);
        string[] names = new string[typeCount];
        float[] malus = new float[typeCount];
        for (int i = 0; i < typeCount; i++) {
            names[i] = ReadJavaUtf(reader);
            malus[i] = ReadFloat(reader);
        }

        PathType[] byState = new PathType[ReadInt(reader)];
        for (int i = 0; i < byState.Length; i++) {
            byState[i] = (PathType)reader.ReadByte();
        }

        Scene[] scenes = new Scene[ReadInt(reader)];
        for (int i = 0; i < scenes.Length; i++) {
            Placed[] blocks = new Placed[ReadInt(reader)];
            for (int b = 0; b < blocks.Length; b++) {
                blocks[b] = new Placed(
                    new Vec3<int>(ReadInt(reader), ReadInt(reader), ReadInt(reader)),
                    (uint)ReadInt(reader));
            }

            scenes[i] = new Scene(blocks, (PathType)reader.ReadByte());
        }

        return new Loaded(names, malus, byState, scenes);
    }

    /// <summary>
    /// Java's <c>DataOutputStream.writeUTF</c>: a big endian two byte length, then the bytes.
    /// <c>BinaryReader.ReadString</c> reads a 7 bit encoded length instead and would silently
    /// desynchronise the whole stream.
    /// </summary>
    private static string ReadJavaUtf(BinaryReader reader) {
        int length = System.Buffers.Binary.BinaryPrimitives.ReadUInt16BigEndian(reader.ReadBytes(2));
        return Encoding.UTF8.GetString(reader.ReadBytes(length));
    }

    /// <summary>The fixture is big endian, as everything Java writes is.</summary>
    private static int ReadInt(BinaryReader reader) {
        return System.Buffers.Binary.BinaryPrimitives.ReadInt32BigEndian(reader.ReadBytes(4));
    }

    private static float ReadFloat(BinaryReader reader) {
        return BitConverter.Int32BitsToSingle(ReadInt(reader));
    }
}
