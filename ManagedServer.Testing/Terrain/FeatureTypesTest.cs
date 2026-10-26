using System.Text.Json;
using ManagedServer.Terrain.Features;
using ManagedServer.Terrain.Features.Blocks;
using ManagedServer.Terrain.Features.Placement;
using ManagedServer.Terrain.Features.Types;
using ManagedServer.Terrain.Features.Values;
using Minecraft.Data.Biomes;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Testing.Terrain;

/// <summary>
/// The feature, placement and provider types that are built from data rather than run as part of a
/// whole pass, each against the arithmetic of the vanilla method it transcribes.
/// </summary>
[TestFixture]
public class FeatureTypesTest {
    private static readonly BlockParser Blocks = new(VanillaRegistry.Data);

    [Test]
    public void ACuboidEmitsWhatItsFiltersKeep() {
        Assert.Multiple(() => {
            Assert.That(Cuboid(true, true), Has.Count.EqualTo(64));
            Assert.That(Cuboid(true, false), Has.Count.EqualTo(56));
            // Edges out takes the corners with them, leaving the four inner positions of each face.
            Assert.That(Cuboid(false, false), Has.Count.EqualTo(24));
            Assert.That(Cuboid(false, true), Has.Count.EqualTo(32));
        });

        IReadOnlyList<Vec3<int>> all = Cuboid(true, true);
        Assert.That(all[0], Is.EqualTo(new Vec3<int>(10, 20, 30)));
        Assert.That(all[1], Is.EqualTo(new Vec3<int>(10, 20, 31)), "z is the innermost walk");
        Assert.That(all[4], Is.EqualTo(new Vec3<int>(10, 21, 30)), "then y");
    }

    private static IReadOnlyList<Vec3<int>> Cuboid(bool edges, bool interior) {
        PlacementModifier.Cuboid cuboid = new(new IntProviders.Constant(3), new IntProviders.Constant(3), edges, interior);
        return cuboid.GetPositions(Context(new SparseLevel()), new LegacyRandomSource(1), new Vec3<int>(10, 20, 30));
    }

    [Test]
    public void ACuboidDrawsHeightBeforeWidthAndLength() {
        PlacementModifier.Cuboid cuboid = new(new IntProviders.Uniform(1, 16), new IntProviders.Uniform(1, 16), true, true);
        IReadOnlyList<Vec3<int>> positions = cuboid.GetPositions(Context(new SparseLevel()), new LegacyRandomSource(7),
            new Vec3<int>(0, 0, 0));

        LegacyRandomSource expected = new(7);
        int height = expected.NextIntBetweenInclusive(1, 16);
        int width = expected.NextIntBetweenInclusive(1, 16);
        int length = expected.NextIntBetweenInclusive(1, 16);

        Assert.That(positions[^1], Is.EqualTo(new Vec3<int>(width, height, length)));
    }

    [Test]
    public void AnOffsetDrawsXThenYThenZ() {
        PlacementModifier.Offset offset = new(new IntProviders.Uniform(-16, 16), new IntProviders.Uniform(-16, 16),
            new IntProviders.Uniform(-16, 16));

        Vec3<int> moved = offset.GetPositions(Context(new SparseLevel()), new LegacyRandomSource(3),
            new Vec3<int>(100, 50, -20)).Single();

        LegacyRandomSource expected = new(3);
        int x = expected.NextIntBetweenInclusive(-16, 16);
        int y = expected.NextIntBetweenInclusive(-16, 16);
        int z = expected.NextIntBetweenInclusive(-16, 16);

        Assert.That(moved, Is.EqualTo(new Vec3<int>(100 + x, 50 + y, -20 + z)));
    }

    [Test]
    public void RandomlySelectedRunsOnlyTheDrawnModifier() {
        PlacementModifier.RandomlySelected selected = new([
            new PlacementModifier.Offset(new IntProviders.Constant(1), new IntProviders.Constant(0), new IntProviders.Constant(0)),
            new PlacementModifier.Offset(new IntProviders.Constant(2), new IntProviders.Constant(0), new IntProviders.Constant(0)),
            new PlacementModifier.Offset(new IntProviders.Constant(3), new IntProviders.Constant(0), new IntProviders.Constant(0))
        ]);

        for (long seed = 0; seed < 20; seed++) {
            int index = new LegacyRandomSource(seed).NextInt(3);
            Vec3<int> moved = selected.GetPositions(Context(new SparseLevel()), new LegacyRandomSource(seed),
                new Vec3<int>(0, 0, 0)).Single();
            Assert.That(moved.X, Is.EqualTo(index + 1));
        }
    }

    [Test]
    public void VeryBiasedToBottomNestsThreeDraws() {
        IIntProvider provider = ValueParser.ParseInt(JsonDocument.Parse(
            """{"type": "minecraft:very_biased_to_bottom", "min_inclusive": 4, "max_inclusive": 40}""").RootElement);

        for (long seed = 0; seed < 50; seed++) {
            LegacyRandomSource expected = new(seed);
            int value = 4 + expected.NextInt(expected.NextInt(expected.NextInt(37) + 1) + 1);
            Assert.That(provider.Sample(new LegacyRandomSource(seed)), Is.EqualTo(value));
        }
    }

    [Test]
    public void ASeaLevelAnchorResolvesAgainstTheLevel() {
        BlockPredicate predicate = Blocks.ParsePredicate(JsonDocument.Parse(
            """
            {"type": "minecraft:height_range", "min_inclusive": {"above_bottom": 0},
             "max_inclusive": {"relative_to_sea_level": -1}}
            """).RootElement);

        SparseLevel level = new();
        Assert.Multiple(() => {
            Assert.That(predicate.Test(level, 0, level.SeaLevel - 1, 0), Is.True);
            Assert.That(predicate.Test(level, 0, level.SeaLevel, 0), Is.False);
            Assert.That(predicate.Test(level, 0, level.MinY, 0), Is.True);
            Assert.That(predicate.Test(level, 0, level.MinY - 1, 0), Is.False);
        });
    }

    [Test]
    public void AnUnrotatedRotationDrawsFromAllSixDirections() {
        BlockStateProvider provider = Blocks.ParseProvider(JsonDocument.Parse(
            """{"type": "minecraft:rotated", "state": {"id": "minecraft:oak_log"}}""").RootElement);

        // Direction.values() is down, up, north, south, west, east, so its axes are y y z z x x.
        Axis[] axes = [Axis.Y, Axis.Y, Axis.Z, Axis.Z, Axis.X, Axis.X];

        for (long seed = 0; seed < 30; seed++) {
            IBlock state = provider.GetState(new SparseLevel(), new LegacyRandomSource(seed), 0, 0, 0);
            Assert.That(((IAxisAligned)state).Axis, Is.EqualTo(axes[new LegacyRandomSource(seed).NextInt(6)]));
        }
    }

    [Test]
    public void ABareStringProviderIsARegistryReference() {
        VanillaFeatureData data = VanillaFeatureData.Load(VanillaPack.Source);
        Assert.That(data.Provider("minecraft:soil_beneath_tree"), Is.InstanceOf<BlockStateProvider.RuleBased>());

        Assert.Throws<FormatException>(() => Blocks.ParseProvider(JsonDocument.Parse("\"minecraft:dirt\"").RootElement),
            "a parser without the registry cannot read a reference as a state");
    }

    [Test]
    public void AnOreReadsTheHeightSplitRuleTests() {
        VanillaFeatureData data = VanillaFeatureData.Load(VanillaPack.Source);
        OreFeature ore = (OreFeature)data.Feature("minecraft:ore_iron")!;

        SparseLevel level = new();
        level.SetState(0, 10, 0, Block.Stone.StateId);
        level.SetState(0, -10, 0, Block.Deepslate.StateId);

        // Stone takes the stone ore and deepslate the deepslate ore whatever the height, and nothing
        // else takes either.
        Assert.Multiple(() => {
            Assert.That(Replacement(ore, level, 0, 10, 0), Is.EqualTo(Block.IronOre.Identifier));
            Assert.That(Replacement(ore, level, 0, -10, 0), Is.EqualTo(Block.DeepslateIronOre.Identifier));
            Assert.That(Replacement(ore, level, 0, 100, 0), Is.Null);
        });
    }

    private static Identifier? Replacement(OreFeature ore, IFeatureLevel level, int x, int y, int z) {
        return ore.Targets.FirstOrDefault(target => target.Target.Test(level, x, y, z))?.State.Identifier;
    }

    [Test]
    public void ADoublePlantPlacesUnderSomethingReplaceableWithTheSameFluid() {
        SparseLevel level = new();
        for (int x = 0; x < 3; x++) {
            level.SetState(x, 63, 0, Block.GrassBlock.StateId);
        }

        level.SetState(0, 65, 0, Block.ShortGrass.StateId);
        level.SetState(1, 65, 0, Block.Water.StateId);
        level.SetState(2, 65, 0, Block.Stone.StateId);

        SimpleBlockFeature feature = new(new BlockStateProvider.Simple(Block.TallGrass));

        Assert.Multiple(() => {
            Assert.That(Place(feature, level, 0, 64, 0), Is.True, "under short grass");
            Assert.That(Place(feature, level, 1, 64, 0), Is.False, "under water, which holds another fluid");
            Assert.That(Place(feature, level, 2, 64, 0), Is.False, "under stone, which is not replaceable");
        });

        Assert.That(((IDoubleHalved)VanillaRegistry.Data.Blocks.GetByStateId(level.GetState(0, 65, 0))).Half,
            Is.EqualTo(BlockHalf.Upper));
    }

    [Test]
    public void TallSeagrassPlacesUnderWater() {
        SparseLevel level = new();
        level.SetState(0, 63, 0, Block.Sand.StateId);
        level.SetState(0, 64, 0, Block.Water.StateId);
        level.SetState(0, 65, 0, Block.Water.StateId);

        SimpleBlockFeature feature = new(new BlockStateProvider.Simple(Block.TallSeagrass));
        Assert.That(Place(feature, level, 0, 64, 0), Is.True);
        Assert.That(VanillaRegistry.Data.Blocks.GetByStateId(level.GetState(0, 65, 0)).Identifier,
            Is.EqualTo(Block.TallSeagrass.Identifier));
    }

    [Test]
    public void APillarTestsBeforeItRollsAndCapsItsLastBlock() {
        SparseLevel level = new();
        level.SetState(0, 60, 0, Block.Stone.StateId);

        RecordingFeature cap = new();
        SingleBlockPillarFeature pillar = new(new BlockStateProvider.Simple(Block.Basalt),
            new BlockPredicate.MatchingBlockTag(new Vec3<int>(0, 0, 0), "minecraft:air"), BlockFace.NegY, 1.0f,
            new PlacedFeature(cap, []));

        LegacyRandomSource random = new(5);
        Assert.That(Place(pillar, level, 0, 64, 0, random), Is.True);

        for (int y = 61; y <= 64; y++) {
            Assert.That(level.GetState(0, y, 0), Is.EqualTo(Block.Basalt.StateId), $"y {y}");
        }

        Assert.That(cap.Origins, Is.EqualTo(new[] { new Vec3<int>(0, 61, 0) }));

        // Four blocks, four rolls: the fifth test failed on the stone and drew nothing.
        LegacyRandomSource expected = new(5);
        expected.ConsumeCount(4);
        Assert.That(random.NextInt(), Is.EqualTo(expected.NextInt()));
    }

    [Test]
    public void AnOverlayPlacesEveryEntryEvenAfterOneFails() {
        RecordingFeature first = new() { Result = false };
        RecordingFeature second = new();
        OverlayFeature overlay = new([new PlacedFeature(first, []), new PlacedFeature(second, [])]);

        Assert.That(Place(overlay, new SparseLevel(), 1, 2, 3), Is.True);
        Assert.That(second.Origins, Has.Count.EqualTo(1));
    }

    private static bool Place(ConfiguredFeature feature, IFeatureLevel level, int x, int y, int z,
        RandomSource? random = null) {

        return feature.Place(new FeaturePlaceContext(Context(level), random ?? new LegacyRandomSource(0),
            new Vec3<int>(x, y, z)));
    }

    private static PlacementContext Context(IFeatureLevel level) {
        return new PlacementContext(level, new GenerationHeightContext(level.MinY, level.MaxY - level.MinY,
            level.SeaLevel), (_, _) => false, null);
    }

    private sealed record RecordingFeature : ConfiguredFeature {
        public List<Vec3<int>> Origins { get; } = [];
        public bool Result { get; init; } = true;

        public override bool Place(FeaturePlaceContext context) {
            Origins.Add(context.Origin);
            return Result;
        }
    }

    /// <summary>Air everywhere but where a test wrote something.</summary>
    private sealed class SparseLevel : IFeatureLevel {
        private readonly Dictionary<(int, int, int), uint> _written = [];

        public MinecraftRegistry Registry => VanillaRegistry.Data;
        public int MinY => -64;
        public int MaxY => 320;
        public int SeaLevel => 63;
        public long Seed => 0;
        public RandomSource LevelRandom { get; } = new LegacyRandomSource(0);
        public FeatureBlockData Blocks => FeatureBlockData.For(VanillaRegistry.Data);

        public bool IsLoaded(int x, int z) => true;

        public uint GetState(int x, int y, int z) {
            return _written.TryGetValue((x, y, z), out uint state) ? state : Block.Air.StateId;
        }

        public void SetState(int x, int y, int z, uint stateId) => _written[(x, y, z)] = stateId;

        public int GetHeight(HeightmapType type, int x, int z) => MinY;

        public IBiome GetBiome(int x, int y, int z) => VanillaRegistry.Data.Biomes["minecraft:plains"];
    }
}
