using System.Text.Json;
using ManagedServer.Terrain.Features;
using ManagedServer.Terrain.Structures;
using ManagedServer.Terrain.Structures.Templates;
using Minecraft.Data.Biomes;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Placement;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Testing.Terrain;

/// <summary>
/// The structure side's reading of the datapack and the jigsaw and placement rules that come with it,
/// each against the vanilla method it transcribes.
/// </summary>
[TestFixture]
public class StructureFormatTest {
    private static readonly MinecraftRegistry Registry = VanillaRegistry.Data;

    [Test]
    public void AFeatureElementAttachesWhateverTheConnectionTargets() {
        FeaturePoolElement element = new("minecraft:test", new PlacedFeature(NoOp.Instance, []),
            PoolProjection.Rigid);
        JigsawBlockInfo feature = element.GetShuffledJigsawBlocks(null!, new Vec3<int>(0, 0, 0),
            BlockRotation.None, new LegacyRandomSource(0), Registry).Single();

        Assert.That(feature.Name, Is.Null);

        foreach (string target in new[] { "minecraft:bottom", "minecraft:empty", "minecraft:camp_decoration" }) {
            Assert.That(JigsawBlockInfo.CanAttach(Registry, UpwardJigsaw(target), feature), Is.True, target);
        }
    }

    [Test]
    public void ANamedJigsawStillNeedsItsTargetToMatch() {
        JigsawBlockInfo named = DownwardJigsaw("minecraft:bottom");

        Assert.Multiple(() => {
            Assert.That(JigsawBlockInfo.CanAttach(Registry, UpwardJigsaw("minecraft:bottom"), named), Is.True);
            Assert.That(JigsawBlockInfo.CanAttach(Registry, UpwardJigsaw("minecraft:other"), named), Is.False);
        });
    }

    private static JigsawBlockInfo UpwardJigsaw(string target) {
        uint state = ((IOriented)Block.Jigsaw).WithOrientation(Orientations.Join(BlockFace.PosY, BlockFace.PosZ)).StateId;
        return new JigsawBlockInfo(new TemplateBlockInfo(new Vec3<int>(0, 0, 0), state, null), JointType.Rollable,
            "minecraft:empty", TemplatePools.Empty, Identifier.Parse(target), 0, 0);
    }

    private static JigsawBlockInfo DownwardJigsaw(string name) {
        uint state = ((IOriented)Block.Jigsaw).WithOrientation(Orientations.Join(BlockFace.NegY, BlockFace.PosZ)).StateId;
        return new JigsawBlockInfo(new TemplateBlockInfo(new Vec3<int>(0, 0, 0), state, null), JointType.Rollable,
            Identifier.Parse(name), TemplatePools.Empty, JigsawBlockInfo.Empty, 0, 0);
    }

    [Test]
    public void ADimensionOriginPlacementPicksOnlyTheOriginChunk() {
        DimensionOriginStructurePlacement placement = new();
        OriginAt state = new(new Vec2<int>(3, -7));

        Assert.Multiple(() => {
            Assert.That(placement.IsStructureChunk(state, 3, -7), Is.True);
            Assert.That(placement.IsStructureChunk(state, 0, 0), Is.False);
            Assert.That(placement.IsStructureChunk(state, 3, 7), Is.False);
        });
    }

    [Test]
    public void ARuleReadsTheNewStateCodecAndTheHeightRuleTests() {
        List<IStructureProcessor> processors = new ProcessorParser(Registry).ParseList(JsonDocument.Parse(
            """
            {"processors": [{"processor_type": "minecraft:rule", "rules": [{
                "input_predicate": {"predicate_type": "minecraft:all_of", "rules": [
                    {"predicate_type": "minecraft:block_match", "block": "minecraft:stone"},
                    {"predicate_type": "minecraft:not", "rule":
                        {"predicate_type": "minecraft:height_match", "min_inclusive": 10, "max_inclusive": 20}}]},
                "location_predicate": {"predicate_type": "minecraft:always_true"},
                "output_state": "minecraft:mossy_cobblestone"}]}]}
            """).RootElement);

        IStructureProcessor rule = processors.Single();

        Assert.Multiple(() => {
            Assert.That(Processed(rule, 5), Is.EqualTo(Block.MossyCobblestone.StateId));
            Assert.That(Processed(rule, 15), Is.EqualTo(Block.Stone.StateId), "inside the excluded heights");
            Assert.That(Processed(rule, 21), Is.EqualTo(Block.MossyCobblestone.StateId));
        });
    }

    private static uint Processed(IStructureProcessor processor, int y) {
        TemplateBlockInfo block = new(new Vec3<int>(0, y, 0), Block.Stone.StateId, null);
        return processor.ProcessBlock(new AirLevel(), new Vec3<int>(0, 0, 0), new Vec3<int>(0, 0, 0),
            new Vec3<int>(0, 0, 0), block, new StructurePlaceSettings())!.Value.StateId;
    }

    private sealed record NoOp : ConfiguredFeature {
        public static readonly NoOp Instance = new();

        public override bool Place(FeaturePlaceContext context) => true;
    }

    private sealed class OriginAt(Vec2<int> origin) : IStructurePlacementState {
        public long LevelSeed => 0;

        public bool HasStructureChunkInRange(Identifier otherSet, int sourceX, int sourceZ, int range) => false;

        public IReadOnlyList<Vec2<int>> RingPositionsFor(ConcentricRingsStructurePlacement placement) => [];

        public Vec2<int> DimensionOrigin => origin;
    }

    private sealed class AirLevel : IFeatureLevel {
        public MinecraftRegistry Registry => VanillaRegistry.Data;
        public int MinY => -64;
        public int MaxY => 320;
        public int SeaLevel => 63;
        public long Seed => 0;
        public RandomSource LevelRandom { get; } = new LegacyRandomSource(0);
        public FeatureBlockData Blocks => FeatureBlockData.For(VanillaRegistry.Data);

        public bool IsLoaded(int x, int z) => true;

        public uint GetState(int x, int y, int z) => Block.Air.StateId;

        public void SetState(int x, int y, int z, uint stateId) { }

        public int GetHeight(HeightmapType type, int x, int z) => MinY;

        public IBiome GetBiome(int x, int y, int z) => VanillaRegistry.Data.Biomes["minecraft:plains"];
    }
}
