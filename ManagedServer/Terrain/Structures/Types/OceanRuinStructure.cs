using ManagedServer.Terrain.Features;
using ManagedServer.Terrain.Features.Blocks;
using ManagedServer.Terrain.Features.Values;
using ManagedServer.Terrain.Structures.Templates;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Structures.Types;

/// <summary>Which of the two ocean ruins a structure file names.</summary>
public enum OceanRuinType {
    Warm,
    Cold
}

/// <summary>
/// <c>OceanRuinStructure</c>: a sunken building, and often a scatter of smaller ones around it.
/// </summary>
/// <remarks>
/// The cold ruin is <b>three pieces at the same position</b>, not one: a brick shell, a cracked
/// overlay and a mossy one, each with its own integrity so the rot processor eats a different share
/// of each. They share a template index, so the three always match. The warm ruin is a single piece.
/// </remarks>
public sealed class OceanRuinStructure(Structure.StructureSettings settings,
    StructureTemplateManager templates, OceanRuinType biomeType, float largeProbability,
    float clusterProbability) : Structure(settings) {

    private const int GenerationHeight = 90;

    private static readonly Identifier Ice = "minecraft:ice";

    private static readonly Identifier[] WarmRuins = Numbered("warm", 1, 8);
    private static readonly Identifier[] BrickRuins = Numbered("brick", 1, 8);
    private static readonly Identifier[] CrackedRuins = Numbered("cracked", 1, 8);
    private static readonly Identifier[] MossyRuins = Numbered("mossy", 1, 8);

    private static readonly Identifier[] BigWarmRuins = Named("big_warm", 4, 5, 6, 7);
    private static readonly Identifier[] BigBrickRuins = Named("big_brick", 1, 2, 3, 8);
    private static readonly Identifier[] BigCrackedRuins = Named("big_cracked", 1, 2, 3, 8);
    private static readonly Identifier[] BigMossyRuins = Named("big_mossy", 1, 2, 3, 8);

    private static Identifier[] Numbered(string prefix, int from, int to) {
        return Enumerable.Range(from, to - from + 1)
            .Select(i => (Identifier)$"minecraft:underwater_ruin/{prefix}_{i}")
            .ToArray();
    }

    private static Identifier[] Named(string prefix, params int[] numbers) {
        return numbers.Select(i => (Identifier)$"minecraft:underwater_ruin/{prefix}_{i}").ToArray();
    }

    protected override GenerationStub? FindGenerationPoint(StructureGenerationContext context) {
        return OnTopOfChunkCenter(context, HeightmapType.OceanFloorWorldgen,
            builder => Generate(builder, context));
    }

    private void Generate(StructurePiecesBuilder builder, StructureGenerationContext context) {
        WorldgenRandom random = context.Random;
        Vec3<int> position = new(context.ChunkX << 4, GenerationHeight, context.ChunkZ << 4);
        BlockRotation rotation = (BlockRotation)random.NextInt(4);

        bool isLarge = random.NextFloat() <= largeProbability;
        float integrity = isLarge ? 0.9f : 0.8f;

        AddPiece(builder, position, rotation, random, isLarge, integrity);

        if (isLarge && random.NextFloat() <= clusterProbability) {
            AddClusterRuins(builder, random, rotation, position);
        }
    }

    /// <summary>
    /// The smaller ruins scattered around a large one.
    /// </summary>
    /// <remarks>
    /// Eight candidate positions are built in a fixed order and then <b>drawn from and removed</b>, so
    /// the same position never gets two ruins and the draw narrows as it goes. A candidate whose box
    /// meets the parent's is skipped rather than redrawn, so a cluster usually has fewer than the
    /// number rolled for.
    /// </remarks>
    private void AddClusterRuins(StructurePiecesBuilder builder, WorldgenRandom random,
        BlockRotation rotation, Vec3<int> position) {

        Vec3<int> parent = new(position.X, GenerationHeight, position.Z);

        Vec3<int> parentCorner = StructureTemplate.Transform(new Vec3<int>(15, 0, 15),
            BlockMirror.None, rotation, new Vec3<int>(0, 0, 0));

        parentCorner = new Vec3<int>(parentCorner.X + parent.X, parentCorner.Y + parent.Y,
            parentCorner.Z + parent.Z);

        BoundingBox parentBox = FromCorners(parent, parentCorner);

        Vec3<int> bottomLeft = new(Math.Min(parent.X, parentCorner.X), parent.Y,
            Math.Min(parent.Z, parentCorner.Z));

        List<Vec3<int>> candidates = AllPositions(random, bottomLeft);
        int count = random.NextIntBetweenInclusive(4, 8);

        for (int i = 0; i < count; i++) {
            if (candidates.Count == 0) {
                continue;
            }

            int index = random.NextInt(candidates.Count);
            Vec3<int> chosen = candidates[index];
            candidates.RemoveAt(index);

            BlockRotation nextRotation = (BlockRotation)random.NextInt(4);

            Vec3<int> corner = StructureTemplate.Transform(new Vec3<int>(5, 0, 6), BlockMirror.None,
                nextRotation, new Vec3<int>(0, 0, 0));

            corner = new Vec3<int>(corner.X + chosen.X, corner.Y + chosen.Y, corner.Z + chosen.Z);

            if (FromCorners(chosen, corner).Intersects(parentBox)) {
                continue;
            }

            AddPiece(builder, chosen, nextRotation, random, false, 0.8f);
        }
    }

    private static List<Vec3<int>> AllPositions(RandomSource random, Vec3<int> origin) {
        return [
            Offset(origin, -16 + random.NextIntBetweenInclusive(1, 8), 16 + random.NextIntBetweenInclusive(1, 7)),
            Offset(origin, -16 + random.NextIntBetweenInclusive(1, 8), random.NextIntBetweenInclusive(1, 7)),
            Offset(origin, -16 + random.NextIntBetweenInclusive(1, 8), -16 + random.NextIntBetweenInclusive(4, 8)),
            Offset(origin, random.NextIntBetweenInclusive(1, 7), 16 + random.NextIntBetweenInclusive(1, 7)),
            Offset(origin, random.NextIntBetweenInclusive(1, 7), -16 + random.NextIntBetweenInclusive(4, 6)),
            Offset(origin, 16 + random.NextIntBetweenInclusive(1, 7), 16 + random.NextIntBetweenInclusive(3, 8)),
            Offset(origin, 16 + random.NextIntBetweenInclusive(1, 7), random.NextIntBetweenInclusive(1, 7)),
            Offset(origin, 16 + random.NextIntBetweenInclusive(1, 7), -16 + random.NextIntBetweenInclusive(4, 8))
        ];
    }

    private static Vec3<int> Offset(Vec3<int> origin, int dx, int dz) {
        return new Vec3<int>(origin.X + dx, origin.Y, origin.Z + dz);
    }

    private static BoundingBox FromCorners(Vec3<int> a, Vec3<int> b) {
        return new BoundingBox(
            Math.Min(a.X, b.X), Math.Min(a.Y, b.Y), Math.Min(a.Z, b.Z),
            Math.Max(a.X, b.X), Math.Max(a.Y, b.Y), Math.Max(a.Z, b.Z));
    }

    private void AddPiece(StructurePiecesBuilder builder, Vec3<int> position, BlockRotation rotation,
        RandomSource random, bool isLarge, float integrity) {

        if (biomeType == OceanRuinType.Warm) {
            Identifier[] warm = isLarge ? BigWarmRuins : WarmRuins;

            builder.AddPiece(new OceanRuinPiece(templates, warm[random.NextInt(warm.Length)],
                position, rotation, integrity, biomeType, isLarge));

            return;
        }

        Identifier[] bricks = isLarge ? BigBrickRuins : BrickRuins;
        Identifier[] cracked = isLarge ? BigCrackedRuins : CrackedRuins;
        Identifier[] mossy = isLarge ? BigMossyRuins : MossyRuins;

        int index = random.NextInt(bricks.Length);

        builder.AddPiece(new OceanRuinPiece(templates, bricks[index], position, rotation,
            integrity, biomeType, isLarge));

        builder.AddPiece(new OceanRuinPiece(templates, cracked[index], position, rotation,
            0.7f, biomeType, isLarge));

        builder.AddPiece(new OceanRuinPiece(templates, mossy[index], position, rotation,
            0.5f, biomeType, isLarge));
    }

    /// <summary>One ruin template.</summary>
    public sealed class OceanRuinPiece : TemplateStructurePiece {
        private readonly bool _isLarge;

        public OceanRuinPiece(StructureTemplateManager templates, Identifier template,
            Vec3<int> position, BlockRotation rotation, float integrity, OceanRuinType biomeType,
            bool isLarge)
            : base(0, templates, template, MakeSettings(rotation, integrity, biomeType), position) {

            _isLarge = isLarge;
        }

        /// <summary>
        /// Drops the ruin to the sea floor, and further where most of the floor under it is lower.
        /// </summary>
        /// <remarks>
        /// Two steps. The first puts it on the floor of its <b>own corner column</b>; the second walks
        /// every column of the footprint down through air, water and ice and drops the ruin to the
        /// lowest of them, but <b>only if</b> the drop is more than two blocks and most of the
        /// footprint is that far down. That is what stops a ruin bridging a trench while leaving one
        /// standing on a slightly uneven floor where it is.
        /// </remarks>
        protected override Vec3<int> SettleAgainstTerrain(IFeatureLevel level) {
            int floor = level.GetHeight(HeightmapType.OceanFloorWorldgen, TemplatePosition.X,
                TemplatePosition.Z);

            Vec3<int> origin = new(TemplatePosition.X, floor, TemplatePosition.Z);

            Vec3<int> corner = StructureTemplate.Transform(
                new Vec3<int>(Template.Size.X - 1, 0, Template.Size.Z - 1), BlockMirror.None,
                PlaceSettings.Rotation, new Vec3<int>(0, 0, 0));

            corner = new Vec3<int>(corner.X + origin.X, corner.Y + origin.Y, corner.Z + origin.Z);

            return new Vec3<int>(origin.X, LoweredFloor(level, origin, corner), origin.Z);
        }

        /// <summary>
        /// How far the ruin drops below the floor its own column gave it.
        /// </summary>
        /// <remarks>
        /// Every column walks down from the <b>origin column's</b> floor rather than from its own, so
        /// a column whose floor is higher contributes that shared start. The walk reads the level
        /// rather than a heightmap, which is what makes ice count as something to fall through.
        /// </remarks>
        private static int LoweredFloor(IFeatureLevel level, Vec3<int> position, Vec3<int> corner) {
            int lowest = 512;
            int top = position.Y - 1;
            int deepColumns = 0;

            int minX = Math.Min(position.X, corner.X);
            int maxX = Math.Max(position.X, corner.X);
            int minZ = Math.Min(position.Z, corner.Z);
            int maxZ = Math.Max(position.Z, corner.Z);

            for (int x = minX; x <= maxX; x++) {
                for (int z = minZ; z <= maxZ; z++) {
                    int columnFloor = top;
                    uint state = level.GetState(x, columnFloor, z);

                    while (IsFallenThrough(level, state) && columnFloor > level.MinY + 1) {
                        state = level.GetState(x, --columnFloor, z);
                    }

                    lowest = Math.Min(lowest, columnFloor);

                    if (columnFloor < top - 2) {
                        deepColumns++;
                    }
                }
            }

            int width = Math.Abs(position.X - corner.X);

            return top - lowest > 2 && deepColumns > width - 2 ? lowest + 1 : position.Y;
        }

        private static bool IsFallenThrough(IFeatureLevel level, uint state) {
            return level.Blocks.IsAir(state) || FeatureFluids.IsWater(level, state)
                || level.Blocks.IsIn(Ice, state);
        }

        private static StructurePlaceSettings MakeSettings(BlockRotation rotation, float integrity,
            OceanRuinType biomeType) {

            return new StructurePlaceSettings {
                Rotation = rotation,
                Mirror = BlockMirror.None
            }
                .AddProcessor(new BlockRotProcessor(null, integrity))
                .AddProcessor(BlockIgnoreProcessor.StructureAndAir)
                .AddProcessor(SuspiciousBlocks(biomeType));
        }

        /// <summary>
        /// The five suspicious blocks a ruin scatters through its floor.
        /// </summary>
        /// <remarks>
        /// Built here rather than read from a processor list, because it is one of the processors
        /// vanilla assembles in code. The loot table it names is what a brush would have found; there
        /// is no block entity to hold one, so the block goes down and is empty.
        /// </remarks>
        private static IStructureProcessor SuspiciousBlocks(OceanRuinType biomeType) {
            (Identifier candidate, uint replacement, Identifier loot) = biomeType == OceanRuinType.Cold
                ? (Block.Gravel.Identifier, Block.SuspiciousGravel.StateId,
                    (Identifier)"minecraft:archaeology/ocean_ruin_cold")
                : (Block.Sand.Identifier, Block.SuspiciousSand.StateId,
                    (Identifier)"minecraft:archaeology/ocean_ruin_warm");

            return new CappedProcessor(
                new RuleProcessor([
                    new ProcessorRule(
                        new IRuleTest.BlockMatch(candidate),
                        IRuleTest.AlwaysTrue.Instance,
                        IPosRuleTest.AlwaysTrue.Instance,
                        replacement,
                        new IRuleBlockEntityModifier.AppendLoot(loot))
                ]),
                new IntProviders.Constant(5));
        }

        /// <summary>
        /// The chest and drowned markers.
        /// </summary>
        /// <remarks>
        /// The chest is written <b>at</b> the marker rather than below it, unlike a shipwreck's, and
        /// it is waterlogged where the marker's cell held water. The drowned marker leaves water or
        /// air depending on whether it is under the sea, which is what the mob would have displaced;
        /// the mob itself needs an entity the generator cannot place.
        /// </remarks>
        protected override void HandleDataMarker(string marker, Vec3<int> position,
            IFeatureLevel level, RandomSource random, BoundingBox chunkBox) {

            if (marker.Equals("chest", StringComparison.Ordinal)) {
                bool water = level.Blocks.HasFluidAt(
                    level.GetState(position.X, position.Y, position.Z));

                level.SetState(position.X, position.Y, position.Z,
                    ((IWaterlogged)Block.Chest).WithWaterlogged(water).StateId);

                return;
            }

            if (marker.Equals("drowned", StringComparison.Ordinal)) {
                level.SetState(position.X, position.Y, position.Z,
                    position.Y > level.SeaLevel ? Block.Air.StateId : Block.Water.StateId);
            }
        }
    }
}
