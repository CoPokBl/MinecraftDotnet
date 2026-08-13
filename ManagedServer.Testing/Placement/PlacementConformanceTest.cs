using System.Buffers.Binary;
using System.IO.Compression;
using System.Text;
using ManagedServer.Placement;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Testing.Placement;

/// <summary>
/// Holds the placement rules against the game's own <c>canSurvive</c> and <c>updateShape</c>.
/// <para>
/// Placement is client predicted, so the client runs these same methods and a rule that disagrees is
/// a block that visibly appears and then changes. But that is not the reason this exists. The reason
/// is that all 134 rules are transcriptions of a decompile, and every hand written test for one was
/// written from the same reading: if the reading was wrong the rule and its test agree with each
/// other and with nothing else. Only vanilla's own answer settles it.
/// </para>
/// <para>
/// These two hooks are also the ones that keep running. <c>getStateForPlacement</c> is asked once,
/// when a player clicks; these are asked again on every neighbouring change for as long as the block
/// exists, driven by the cascade in <see cref="World.SetBlock(Vec3{int},IBlock,IBlockEntityType?,NBT.Tags.INbtTag?,int,int)"/>,
/// so a wrong answer here is not a flicker, it is a world that settles into the wrong arrangement.
/// </para>
/// <para>
/// <c>getStateForPlacement</c> is <b>not</b> covered, and that is a real gap rather than an
/// oversight: it needs a <c>BlockPlaceContext</c>, which needs a live <c>Level</c>, which is what
/// CLAUDE.md lists as out of reach for a harness. These two take only a <c>LevelReader</c> and a
/// <c>ScheduledTickAccess</c>, both interfaces, so a stub reaches them.
/// </para>
/// <para>
/// The fixture is the real methods run out of the server jar. Regenerate it on a version bump, see
/// Conformance/placement.sh.
/// </para>
/// </summary>
[TestFixture]
public class PlacementConformanceTest {
    private const string Fixture = "Placement/vanilla-placement.bin.gz";

    /// <summary>
    /// Write the state that was asked for and nothing else. The fixture names the exact states
    /// vanilla was asked about, so the scene is built verbatim and the shape cascade must not get an
    /// opinion about it on the way in.
    /// </summary>
    private const int Verbatim = BlockUpdateFlags.KnownShape;

    /// <summary>How many differing blocks to name before a failure message stops being useful.</summary>
    private const int Reported = 25;

    /// <summary>
    /// Differences gathered per block and per rule rather than per state.
    /// <para>
    /// A single wrong rule is thousands of differing states, and the states of one block are
    /// consecutive, so a flat list of the first few is always the first block and never says which
    /// rule to go and read. Grouping is what turns the failure into a list of rules to fix.
    /// </para>
    /// </summary>
    private sealed class Differences {
        private readonly Dictionary<string, (int Count, string First)> _byBlock = [];

        /// <summary>Every block that differed, whether or not it was expected to.</summary>
        public HashSet<string> Blocks { get; } = [];

        public int Total { get; private set; }

        public void Add(Identifier block, string? rule, string detail) {
            Total++;
            Blocks.Add(block.ToString());
            string key = $"{block} ({rule ?? "no rule"})";
            _byBlock[key] = _byBlock.TryGetValue(key, out (int Count, string First) seen)
                ? (seen.Count + 1, seen.First)
                : (1, detail);
        }

        /// <summary>
        /// The blocks that differ and are not in <see cref="Known"/>, which is what a run is allowed
        /// to have none of.
        /// </summary>
        public string Unexpected() {
            List<string> lines = _byBlock
                .Where(entry => KnownFor(entry.Key[..entry.Key.IndexOf(" (", StringComparison.Ordinal)]) is null)
                .OrderByDescending(entry => entry.Value.Count)
                .Take(Reported)
                .Select(entry => $"  {entry.Key} x{entry.Value.Count}: {entry.Value.First}")
                .ToList();

            return lines.Count == 0 ? "" : Environment.NewLine + string.Join(Environment.NewLine, lines);
        }
    }

    /// <summary>
    /// Both halves of the baseline, for one test's results.
    /// <para>
    /// A block differing that is not on the list is a regression. A block on the list that no longer
    /// differs is a fix that nobody deleted the entry for, and it fails too: a baseline that is only
    /// ever added to stops describing anything.
    /// </para>
    /// </summary>
    private static void AssertOnlyKnownDiffer(Differences differences, IEnumerable<string> covered,
        string what) {
        string unexpected = differences.Unexpected();
        Assert.That(unexpected, Is.Empty,
            $"{what}: blocks disagree with vanilla that are not in the known list.{unexpected}");

        List<string> stale = covered
            .Where(block => !differences.Blocks.Contains(block))
            .ToList();

        Assert.That(stale, Is.Empty,
            $"{what}: these are listed as known to differ but now agree with vanilla. "
            + $"Delete their entries.{Environment.NewLine}  {string.Join($"{Environment.NewLine}  ", stale)}");
    }

    /// <summary>
    /// Why a block is allowed to disagree with vanilla. The two are not the same kind of thing and
    /// are kept apart on purpose.
    /// </summary>
    private enum Why {
        /// <summary>
        /// Something the port cannot answer because a whole subsystem is missing. Reaching parity
        /// means building that subsystem, not editing a rule.
        /// </summary>
        Divergence,

        /// <summary>
        /// A rule that is simply wrong and has not been fixed. Every one of these is a defect with
        /// its cause already named, and the entry comes out of the list when it is fixed.
        /// </summary>
        Bug
    }

    /// <summary>
    /// The blocks known to differ, and why.
    /// <para>
    /// A baseline rather than a mute: the tests assert both directions, so a block that starts
    /// differing fails as an unexpected difference, and a block that stops differing fails as a stale
    /// entry. Neither the debt nor a fix can go unnoticed.
    /// </para>
    /// </summary>
    private static readonly Dictionary<string, (Why Why, string Reason)> Known = new() {
        // No rule at all, by design, and every one of them is named in the "deliberately not
        // transcribed" list on VanillaPlacementRules with the same reason.
        ["minecraft:redstone_wire"] = (Why.Divergence, "needs the redstone engine"),
        ["minecraft:fire"] = (Why.Divergence, "needs the flammability table, which is bootstrap code"),
        ["minecraft:soul_fire"] = (Why.Divergence, "as fire"),
        ["minecraft:piston_head"] = (Why.Divergence, "needs pistons"),
        ["minecraft:bubble_column"] = (Why.Divergence, "no item places it, and it needs the fluid tick"),
        ["minecraft:nether_portal"] = (Why.Divergence, "needs PortalShape, and there are no portals"),

        // The two rules that want getRawBrightness. Lighting here is computed per chunk for sending
        // rather than queryable per position, so both err permissive and say so where they are.
        ["minecraft:brown_mushroom"] = (Why.Divergence, "no per position light query"),
        ["minecraft:red_mushroom"] = (Why.Divergence, "no per position light query"),
        ["minecraft:wheat"] = (Why.Divergence, "no per position light query"),
        ["minecraft:carrots"] = (Why.Divergence, "no per position light query"),
        ["minecraft:potatoes"] = (Why.Divergence, "no per position light query"),
        ["minecraft:beetroots"] = (Why.Divergence, "no per position light query"),
        ["minecraft:torchflower_crop"] = (Why.Divergence, "no per position light query"),
        ["minecraft:pitcher_crop"] = (Why.Bug, "the upper half is not destroyed with the lower, and "
                                               + "sufficientLight wants a per position light query"),

        // Defects the fixture found and nobody has fixed yet.
        ["minecraft:redstone_wall_torch"] = (Why.Bug,
            "RedstoneWallTorchBlock declares its own canSurvive and its class chain does not include "
            + "WallTorchBlock, so it falls through to BaseTorchBlock's rule and asks below instead of "
            + "behind. It needs its own rule"),
        ["minecraft:vine"] = (Why.Bug, "canSurvive is missing the up face clause"),
        ["minecraft:scaffolding"] = (Why.Bug, "the distance recompute disagrees below the source"),
        ["minecraft:repeater"] = (Why.Bug, "the locked property is not recomputed"),
        ["minecraft:small_dripleaf"] = (Why.Bug, "the two halves do not destroy each other"),
        ["minecraft:tall_seagrass"] = (Why.Bug, "the two halves do not destroy each other"),
        ["minecraft:campfire"] = (Why.Bug, "signal_fire is not read off the block below"),
        ["minecraft:soul_campfire"] = (Why.Bug, "signal_fire is not read off the block below"),
        ["minecraft:attached_melon_stem"] = (Why.Bug, "does not revert to its unattached stem"),
        ["minecraft:attached_pumpkin_stem"] = (Why.Bug, "does not revert to its unattached stem"),
        ["minecraft:cave_vines"] = (Why.Bug, "head and body do not convert into each other"),
        ["minecraft:cave_vines_plant"] = (Why.Bug, "head and body do not convert into each other"),
        ["minecraft:kelp_plant"] = (Why.Bug, "head and body do not convert into each other"),
        ["minecraft:twisting_vines_plant"] = (Why.Bug, "head and body do not convert into each other"),
        ["minecraft:weeping_vines_plant"] = (Why.Bug, "head and body do not convert into each other")
    };

    /// <summary>
    /// The double plants and the fence gates, which differ as whole families for one reason each and
    /// would otherwise be thirty near identical rows above.
    /// </summary>
    private static readonly Dictionary<string, (Why Why, string Reason)> KnownFamilies = new() {
        ["_fence_gate"] = (Why.Bug, "in_wall is not recomputed from the walls beside it"),
        ["#double_plant"] = (Why.Bug, "the two halves do not destroy each other")
    };

    private static readonly string[] DoublePlants = [
        "minecraft:sunflower", "minecraft:lilac", "minecraft:rose_bush", "minecraft:peony",
        "minecraft:tall_grass", "minecraft:large_fern", "minecraft:pitcher_plant"
    ];

    private static readonly string[] FenceGates = [
        "minecraft:oak_fence_gate", "minecraft:spruce_fence_gate", "minecraft:birch_fence_gate",
        "minecraft:jungle_fence_gate", "minecraft:acacia_fence_gate", "minecraft:cherry_fence_gate",
        "minecraft:dark_oak_fence_gate", "minecraft:pale_oak_fence_gate",
        "minecraft:mangrove_fence_gate", "minecraft:bamboo_fence_gate",
        "minecraft:crimson_fence_gate", "minecraft:warped_fence_gate"
    ];

    private static (Why Why, string Reason)? KnownFor(string block) {
        if (Known.TryGetValue(block, out (Why Why, string Reason) found)) {
            return found;
        }

        if (block.EndsWith("_fence_gate", StringComparison.Ordinal)) {
            return KnownFamilies["_fence_gate"];
        }

        return DoublePlants.Contains(block) ? KnownFamilies["#double_plant"] : null;
    }

    private readonly record struct Placed(Vec3<int> Offset, uint StateId);

    private readonly record struct Scene(string Name, int Brightness, Placed[] Blocks);

    private sealed record Loaded(
        int StateCount, Scene[] Scenes, bool[] CanSurvive, int[] Palette, BlockFace[] Directions,
        Dictionary<uint, ShapeGrid> Shapes, bool[] SchedulesTick);

    /// <summary>
    /// One state's <c>updateShape</c> answers: the one it gives nearly everywhere, and the cells that
    /// disagree with it. A state the fixture does not mention answered with itself everywhere.
    /// </summary>
    private readonly record struct ShapeGrid(uint Mode, Dictionary<int, uint> Exceptions) {
        public uint At(int cell) => Exceptions.GetValueOrDefault(cell, Mode);
    }

    /// <summary>
    /// The neighbour palette entry meaning "the same state as the block being asked about". Fences,
    /// walls, panes, chorus plants and chests only join their own kind, so a palette of fixed states
    /// would never reach the branch that matters for them.
    /// </summary>
    private const int Self = -1;

    [Test]
    public void EveryBlockStateSurvivesWhereVanillaSaysItDoes() {
        Loaded fixture = Load();
        PlacementScene scene = new();
        World world = scene.World;
        MinecraftRegistry registry = world.Server.Registry;

        Assert.That(fixture.StateCount, Is.EqualTo(registry.Blocks.StatesByStateId.Count),
            "the fixture was built for a different number of block states");

        Vec3<int> origin = new(0, scene.FloorY + 4, 0);
        List<Vec3<int>> dressed = [];
        Differences differences = new();

        for (int s = 0; s < fixture.Scenes.Length; s++) {
            Scene built = fixture.Scenes[s];

            foreach (Vec3<int> pos in dressed) {
                world.SetBlock(pos, Block.Air, flags: Verbatim);
            }

            dressed.Clear();

            foreach (Placed placed in built.Blocks) {
                Vec3<int> pos = origin + placed.Offset;
                world.SetBlock(pos, StateOf(registry, placed.StateId), flags: Verbatim);
                dressed.Add(pos);
            }

            for (uint id = 0; id < fixture.StateCount; id++) {
                IBlock block = StateOf(registry, id);
                world.SetBlock(origin, block, flags: Verbatim);

                bool wanted = fixture.CanSurvive[s * fixture.StateCount + id];
                IBlockPlacementRule? rule = world.Server.BlockPlacementRules.For(block, world);
                bool got = rule?.CanSurvive(block, world, origin) ?? true;

                if (got == wanted) {
                    continue;
                }

                differences.Add(block.Identifier, rule?.GetType().Name,
                    $"[{id}] in scene '{built.Name}' we say {got}, vanilla says {wanted}");
            }
        }

        AssertOnlyKnownDiffer(differences, SurvivalBaseline, "canSurvive");
    }

    /// <summary>Which of <see cref="Known"/> differ in their survival answer.</summary>
    private static readonly string[] SurvivalBaseline = [
        "minecraft:redstone_wire", "minecraft:fire", "minecraft:soul_fire", "minecraft:piston_head",
        "minecraft:bubble_column", "minecraft:brown_mushroom", "minecraft:red_mushroom",
        "minecraft:wheat", "minecraft:carrots", "minecraft:potatoes", "minecraft:beetroots",
        "minecraft:torchflower_crop", "minecraft:pitcher_crop", "minecraft:redstone_wall_torch",
        "minecraft:vine"
    ];

    [Test]
    public void EveryShapeUpdateAgreesWithVanilla() {
        Loaded fixture = Load();
        PlacementScene scene = new();
        World world = scene.World;
        MinecraftRegistry registry = world.Server.Registry;
        BlockPlacementRules rules = world.Server.BlockPlacementRules;

        Vec3<int> origin = new(0, scene.FloorY + 4, 0);
        Differences differences = new();
        long compared = 0;

        for (uint id = 0; id < fixture.StateCount; id++) {
            IBlock block = StateOf(registry, id);
            world.SetBlock(origin, block, flags: Verbatim);

            ShapeGrid grid = fixture.Shapes.TryGetValue(id, out ShapeGrid found)
                ? found
                : new ShapeGrid(id, []);

            IBlockPlacementRule? rule = rules.For(block, world);

            for (int d = 0; d < fixture.Directions.Length; d++) {
                BlockFace face = fixture.Directions[d];
                Vec3<int> neighbourPos = origin.GetBlockTowards(face);

                for (int p = 0; p < fixture.Palette.Length; p++) {
                    IBlock neighbour = fixture.Palette[p] == Self
                        ? block
                        : StateOf(registry, (uint)fixture.Palette[p]);

                    world.SetBlock(neighbourPos, neighbour, flags: Verbatim);

                    uint wanted = grid.At(d * fixture.Palette.Length + p);
                    IBlock got = rule?.UpdateShape(block, world, origin, face, neighbourPos, neighbour)
                                 ?? block;
                    compared++;

                    if (got.StateId == wanted) {
                        continue;
                    }

                    differences.Add(block.Identifier, rule?.GetType().Name,
                        Describe(registry, fixture, face, neighbour, got, wanted, id));
                }

                world.SetBlock(neighbourPos, Block.Air, flags: Verbatim);
            }
        }

        AssertOnlyKnownDiffer(differences, ShapeBaseline, $"updateShape (of {compared} answers)");
    }

    /// <summary>Which of <see cref="Known"/> differ in their shape update.</summary>
    private static readonly string[] ShapeBaseline = [
        "minecraft:redstone_wire", "minecraft:fire", "minecraft:piston_head",
        "minecraft:nether_portal",
        "minecraft:brown_mushroom", "minecraft:red_mushroom", "minecraft:pitcher_crop",
        "minecraft:redstone_wall_torch", "minecraft:vine", "minecraft:scaffolding",
        "minecraft:repeater", "minecraft:small_dripleaf", "minecraft:tall_seagrass",
        "minecraft:campfire", "minecraft:soul_campfire",
        "minecraft:attached_melon_stem", "minecraft:attached_pumpkin_stem",
        "minecraft:cave_vines", "minecraft:cave_vines_plant", "minecraft:kelp_plant",
        "minecraft:twisting_vines_plant", "minecraft:weeping_vines_plant",
        .. DoublePlants,
        .. FenceGates
    ];

    /// <summary>
    /// A difference, with the one piece of context that most often explains it: whether vanilla also
    /// scheduled a tick for this state. There is no block tick scheduler here, so a rule whose whole
    /// vanilla body is a scheduled recompute is deliberately absent, and a difference on such a state
    /// is the known gap rather than a wrong transcription.
    /// </summary>
    private static string Describe(MinecraftRegistry registry, Loaded fixture, BlockFace face,
        IBlock neighbour, IBlock got, uint wanted, uint id) {
        string note = fixture.SchedulesTick[id] ? ", vanilla also schedules a tick" : "";
        return $"[{id}] told {face} is {neighbour.Identifier}, we say "
               + $"{got.Identifier}[{got.StateId}], vanilla says "
               + $"{StateOf(registry, wanted).Identifier}[{wanted}]{note}";
    }

    private static IBlock StateOf(MinecraftRegistry registry, uint stateId) {
        return registry.Blocks.StatesByStateId[stateId].WithState(stateId);
    }

    // ---------------------------------------------------------------- reading

    private static Loaded Load() {
        string path = System.IO.Path.Combine(TestContext.CurrentContext.TestDirectory, Fixture);
        Assert.That(File.Exists(path), Is.True,
            $"{Fixture} is missing. Regenerate it with Conformance/placement.sh.");

        using FileStream file = File.OpenRead(path);
        using GZipStream unzipped = new(file, CompressionMode.Decompress);
        using BinaryReader reader = new(unzipped);

        string magic = Encoding.ASCII.GetString(reader.ReadBytes(8));
        Assert.That(magic, Is.EqualTo("MCPLACE1"), "unexpected fixture format");

        int stateCount = ReadInt(reader);

        Scene[] scenes = new Scene[ReadInt(reader)];
        for (int i = 0; i < scenes.Length; i++) {
            string name = ReadJavaUtf(reader);
            int brightness = reader.ReadByte();
            Placed[] blocks = new Placed[ReadInt(reader)];
            for (int b = 0; b < blocks.Length; b++) {
                blocks[b] = new Placed(
                    new Vec3<int>(reader.ReadSByte(), reader.ReadSByte(), reader.ReadSByte()),
                    (uint)ReadInt(reader));
            }

            scenes[i] = new Scene(name, brightness, blocks);
        }

        bool[] canSurvive = new bool[scenes.Length * stateCount];
        for (int i = 0; i < canSurvive.Length; i++) {
            canSurvive[i] = reader.ReadByte() != 0;
        }

        int[] palette = new int[ReadInt(reader)];
        for (int i = 0; i < palette.Length; i++) {
            palette[i] = ReadInt(reader);
        }

        BlockFace[] directions = new BlockFace[ReadInt(reader)];
        for (int i = 0; i < directions.Length; i++) {
            directions[i] = FaceOf(ReadJavaUtf(reader));
        }

        Dictionary<uint, ShapeGrid> shapes = ReadShapes(reader, palette.Length);

        bool[] schedules = new bool[stateCount];
        for (int i = 0; i < stateCount; i += 8) {
            int packed = reader.ReadByte();
            for (int bit = 0; bit < 8 && i + bit < stateCount; bit++) {
                schedules[i + bit] = (packed & (1 << bit)) != 0;
            }
        }

        return new Loaded(stateCount, scenes, canSurvive, palette, directions, shapes, schedules);
    }

    /// <summary>
    /// The compressed grid. State ids are deltas from the previous state written and results are
    /// zig zagged deltas from the state being described, because a block's states are consecutive in
    /// the registry and a fence losing a connection lands a few ids from where it started.
    /// </summary>
    private static Dictionary<uint, ShapeGrid> ReadShapes(BinaryReader reader, int paletteSize) {
        int count = ReadInt(reader);
        Dictionary<uint, ShapeGrid> shapes = new(count);
        int previous = 0;

        for (int i = 0; i < count; i++) {
            int state = previous + ReadVarInt(reader);
            previous = state;

            uint mode = (uint)(state + ZigZag(ReadVarInt(reader)));
            int exceptions = ReadVarInt(reader);
            Dictionary<int, uint> cells = new(exceptions);

            for (int e = 0; e < exceptions; e++) {
                int packed = reader.ReadByte();
                int cell = (packed >> 5) * paletteSize + (packed & 0x1F);
                cells[cell] = (uint)(state + ZigZag(ReadVarInt(reader)));
            }

            shapes[(uint)state] = new ShapeGrid(mode, cells);
        }

        return shapes;
    }

    /// <summary>
    /// Vanilla's <c>Direction</c> by name, never by ordinal. These happen to line up with
    /// <see cref="BlockFace"/> today, and an insertion upstream would shift them into something that
    /// still decodes perfectly while meaning a different face.
    /// </summary>
    private static BlockFace FaceOf(string name) => name switch {
        "DOWN" => BlockFace.NegY,
        "UP" => BlockFace.PosY,
        "NORTH" => BlockFace.NegZ,
        "SOUTH" => BlockFace.PosZ,
        "WEST" => BlockFace.NegX,
        "EAST" => BlockFace.PosX,
        _ => throw new InvalidDataException($"vanilla grew a direction called {name}")
    };

    private static int ZigZag(int value) => (int)((uint)value >> 1) ^ -(value & 1);

    private static int ReadVarInt(BinaryReader reader) {
        int value = 0;
        int shift = 0;
        while (true) {
            byte read = reader.ReadByte();
            value |= (read & 0x7F) << shift;
            if ((read & 0x80) == 0) {
                return value;
            }

            shift += 7;
        }
    }

    /// <summary>
    /// Java's <c>DataOutputStream.writeUTF</c>: a big endian two byte length, then the bytes.
    /// <c>BinaryReader.ReadString</c> reads a 7 bit encoded length instead and would silently
    /// desynchronise the whole stream.
    /// </summary>
    private static string ReadJavaUtf(BinaryReader reader) {
        int length = BinaryPrimitives.ReadUInt16BigEndian(reader.ReadBytes(2));
        return Encoding.UTF8.GetString(reader.ReadBytes(length));
    }

    /// <summary>The fixture is big endian, as everything Java writes is.</summary>
    private static int ReadInt(BinaryReader reader) {
        return BinaryPrimitives.ReadInt32BigEndian(reader.ReadBytes(4));
    }
}
