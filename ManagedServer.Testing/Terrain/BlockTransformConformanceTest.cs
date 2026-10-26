using System.Buffers.Binary;
using System.IO.Compression;
using ManagedServer.Terrain.Structures;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace ManagedServer.Testing.Terrain;

/// <summary>
/// Puts every block state through <see cref="BlockStateTransform"/> and compares against what the
/// vanilla blocks answered.
/// </summary>
/// <remarks>
/// This is the only thing holding that class up. It is written per block property where vanilla
/// writes 65 <c>rotate</c> and 60 <c>mirror</c> overrides per block class, so a class whose rule is
/// not one of the ones implemented comes back unturned, which is indistinguishable from a block that
/// genuinely has no rule. Our own tests would encode the same reading of the same decompile.
/// <p/>
/// The fixture carries only the states that <b>move</b> under some transform. Everything else is
/// asserted to be unchanged rather than skipped, so a rule applied to a block vanilla leaves alone
/// fails here too.
/// </remarks>
[TestFixture]
public class BlockTransformConformanceTest {
    private const string Fixture = "Terrain/vanilla-blocktransform.bin.gz";

    /// <summary>The order <c>BlockTransformHarness</c> writes them in.</summary>
    private static readonly BlockRotation[] Rotations = [
        BlockRotation.Clockwise90, BlockRotation.Clockwise180, BlockRotation.CounterClockwise90
    ];

    private static readonly BlockMirror[] Mirrors = [BlockMirror.LeftRight, BlockMirror.FrontBack];

    [Test]
    public void EveryBlockStateTurnsTheWayVanillaTurnsIt() {
        MinecraftRegistry registry = VanillaRegistry.Data;
        Dictionary<uint, uint[]> expected = Load();

        List<string> wrong = [];

        foreach (uint stateId in AllStateIds(registry)) {
            IBlock block = registry.Blocks.GetByStateId(stateId);

            if (IsBaselined(block)) {
                continue;
            }

            expected.TryGetValue(stateId, out uint[]? wanted);

            for (int i = 0; i < Rotations.Length; i++) {
                uint got = BlockStateTransform.Rotate(block, Rotations[i]).StateId;
                uint want = wanted?[i] ?? stateId;

                if (got != want) {
                    Report(wrong, registry, stateId, Rotations[i].ToString(), got, want);
                }
            }

            for (int i = 0; i < Mirrors.Length; i++) {
                uint got = BlockStateTransform.Mirror(block, Mirrors[i]).StateId;
                uint want = wanted?[Rotations.Length + i] ?? stateId;

                if (got != want) {
                    Report(wrong, registry, stateId, Mirrors[i].ToString(), got, want);
                }
            }
        }

        // Grouped by block, because a rule that is wrong is wrong for every state of its class and a
        // flat list of the first thirty is thirty states of whichever block sorts first.
        string blocks = string.Join(", ", wrong
            .Select(entry => entry[..entry.IndexOf('[')])
            .GroupBy(name => name)
            .OrderByDescending(group => group.Count())
            .Select(group => $"{group.Key} x{group.Count()}"));

        Assert.That(wrong, Is.Empty,
            $"{wrong.Count} disagreements with vanilla across {blocks}\n\nfirst few:\n"
            + string.Join("\n", wrong.Take(10)));
    }

    /// <summary>
    /// The fixture is the transforms that do something, so a build where nothing turns would pass
    /// the comparison above by agreeing with an empty file.
    /// </summary>
    [Test]
    public void TheFixtureCoversTheBlocksThatTurn() {
        Assert.That(Load(), Has.Count.GreaterThan(20000));
    }

    /// <summary>
    /// Every baselined class really does differ from vanilla, so an entry that has been fixed fails
    /// here instead of quietly excusing a block that no longer needs it.
    /// </summary>
    [Test]
    public void EveryBaselinedClassStillNeedsToBe() {
        MinecraftRegistry registry = VanillaRegistry.Data;
        Dictionary<uint, uint[]> expected = Load();

        HashSet<BlockClass> stillWrong = [];

        foreach (uint stateId in AllStateIds(registry)) {
            IBlock block = registry.Blocks.GetByStateId(stateId);

            if (!IsBaselined(block) || !expected.TryGetValue(stateId, out uint[]? wanted)) {
                continue;
            }

            bool agrees = true;

            for (int i = 0; i < Rotations.Length; i++) {
                agrees &= BlockStateTransform.Rotate(block, Rotations[i]).StateId == wanted[i];
            }

            for (int i = 0; i < Mirrors.Length; i++) {
                agrees &= BlockStateTransform.Mirror(block, Mirrors[i]).StateId
                    == wanted[Rotations.Length + i];
            }

            if (!agrees) {
                stillWrong.Add(BaselinedClassOf(block)!.Value);
            }
        }

        Assert.That(stillWrong,
            Is.EquivalentTo(BlockStateTransform.ClassesWithoutAPropertyInterface),
            "a baselined class now agrees with vanilla, so its entry in "
            + "BlockStateTransform.ClassesWithoutAPropertyInterface is stale");
    }

    private static bool IsBaselined(IBlock block) => BaselinedClassOf(block) is not null;

    private static BlockClass? BaselinedClassOf(IBlock block) {
        foreach (BlockClass name in BlockClasses.Of(block.Identifier)) {
            if (BlockStateTransform.ClassesWithoutAPropertyInterface.Contains(name)) {
                return name;
            }
        }

        return null;
    }

    private static void Report(List<string> into, MinecraftRegistry registry, uint stateId,
        string transform, uint got, uint want) {

        into.Add($"{Name(registry, stateId)} under {transform}: got {Name(registry, got)}, "
            + $"vanilla says {Name(registry, want)}");
    }

    private static string Name(MinecraftRegistry registry, uint stateId) {
        IBlock block = registry.Blocks.GetByStateId(stateId);
        return $"{block.Identifier}[{stateId}]";
    }

    private static IEnumerable<uint> AllStateIds(MinecraftRegistry registry) {
        for (uint stateId = 0; stateId < registry.Blocks.StatesCount; stateId++) {
            yield return stateId;
        }
    }

    private static Dictionary<uint, uint[]> Load() {
        string path = Path.Combine(TestContext.CurrentContext.TestDirectory, Fixture);
        Assert.That(File.Exists(path), Is.True,
            $"{Fixture} is missing. Regenerate it with Conformance/blocktransform.sh.");

        using FileStream file = File.OpenRead(path);
        using GZipStream unzipped = new(file, CompressionMode.Decompress);
        using MemoryStream whole = new();
        unzipped.CopyTo(whole);

        ReadOnlySpan<byte> bytes = whole.GetBuffer().AsSpan(0, (int)whole.Length);
        int entryLength = (1 + Rotations.Length + Mirrors.Length) * sizeof(int);

        Assert.That(bytes.Length % entryLength, Is.Zero, "truncated fixture");

        Dictionary<uint, uint[]> results = new(bytes.Length / entryLength);

        for (int at = 0; at < bytes.Length; at += entryLength) {
            uint stateId = BinaryPrimitives.ReadUInt32BigEndian(bytes[at..]);
            uint[] transformed = new uint[Rotations.Length + Mirrors.Length];

            for (int i = 0; i < transformed.Length; i++) {
                transformed[i] = BinaryPrimitives.ReadUInt32BigEndian(bytes[(at + (i + 1) * 4)..]);
            }

            results[stateId] = transformed;
        }

        return results;
    }
}
