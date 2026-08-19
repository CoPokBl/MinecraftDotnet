using ManagedServer.Terrain.Features;
using ManagedServer.Terrain.Structures.Templates;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Structures.Types;

/// <summary>
/// <c>ShipwreckStructure</c>: one wreck template, dropped onto the sea floor or run aground.
/// </summary>
/// <remarks>
/// <c>is_beached</c> is the whole difference between the two registered shipwrecks, and it decides
/// three things at once: which heightmap the position is chosen against, which list of templates is
/// drawn from, and whether the wreck is buried to half its height or laid on the floor.
/// </remarks>
public sealed class ShipwreckStructure(Structure.StructureSettings settings,
    StructureTemplateManager templates, bool isBeached) : Structure(settings) {

    private const int GenerationHeight = 90;

    private static readonly Vec3<int> Pivot = new(4, 0, 15);

    /// <summary>The wrecks that end up on a beach, which are the ones that are not upside down.</summary>
    private static readonly Identifier[] Beached = [
        "minecraft:shipwreck/with_mast",
        "minecraft:shipwreck/sideways_full",
        "minecraft:shipwreck/sideways_fronthalf",
        "minecraft:shipwreck/sideways_backhalf",
        "minecraft:shipwreck/rightsideup_full",
        "minecraft:shipwreck/rightsideup_fronthalf",
        "minecraft:shipwreck/rightsideup_backhalf",
        "minecraft:shipwreck/with_mast_degraded",
        "minecraft:shipwreck/rightsideup_full_degraded",
        "minecraft:shipwreck/rightsideup_fronthalf_degraded",
        "minecraft:shipwreck/rightsideup_backhalf_degraded"
    ];

    private static readonly Identifier[] Ocean = [
        "minecraft:shipwreck/with_mast",
        "minecraft:shipwreck/upsidedown_full",
        "minecraft:shipwreck/upsidedown_fronthalf",
        "minecraft:shipwreck/upsidedown_backhalf",
        "minecraft:shipwreck/sideways_full",
        "minecraft:shipwreck/sideways_fronthalf",
        "minecraft:shipwreck/sideways_backhalf",
        "minecraft:shipwreck/rightsideup_full",
        "minecraft:shipwreck/rightsideup_fronthalf",
        "minecraft:shipwreck/rightsideup_backhalf",
        "minecraft:shipwreck/with_mast_degraded",
        "minecraft:shipwreck/upsidedown_full_degraded",
        "minecraft:shipwreck/upsidedown_fronthalf_degraded",
        "minecraft:shipwreck/upsidedown_backhalf_degraded",
        "minecraft:shipwreck/sideways_full_degraded",
        "minecraft:shipwreck/sideways_fronthalf_degraded",
        "minecraft:shipwreck/sideways_backhalf_degraded",
        "minecraft:shipwreck/rightsideup_full_degraded",
        "minecraft:shipwreck/rightsideup_fronthalf_degraded",
        "minecraft:shipwreck/rightsideup_backhalf_degraded"
    ];

    protected override GenerationStub? FindGenerationPoint(StructureGenerationContext context) {
        HeightmapType heightmap = isBeached
            ? HeightmapType.WorldSurfaceWorldgen
            : HeightmapType.OceanFloorWorldgen;

        return OnTopOfChunkCenter(context, heightmap, builder => Generate(builder, context));
    }

    private void Generate(StructurePiecesBuilder builder, StructureGenerationContext context) {
        WorldgenRandom random = context.Random;
        BlockRotation rotation = (BlockRotation)random.NextInt(4);

        Vec3<int> position = new(context.ChunkX << 4, GenerationHeight, context.ChunkZ << 4);

        Identifier[] options = isBeached ? Beached : Ocean;
        Identifier chosen = options[random.NextInt(options.Length)];

        // How much further than half its height a beached wreck is buried. Vanilla draws this from
        // the decoration random of whichever chunk settles the wreck, inside postProcess; a start
        // here is replayed by every chunk it reaches, so it is drawn once, from the start's own
        // sequence, and every one of those chunks buries the wreck by the same amount.
        int buried = isBeached ? random.NextInt(3) : 0;

        builder.AddPiece(new ShipwreckPiece(templates, chosen, position, rotation, isBeached, buried));
    }

    /// <summary>One wreck.</summary>
    public sealed class ShipwreckPiece(StructureTemplateManager templates, Identifier template,
        Vec3<int> position, BlockRotation rotation, bool isBeached, int buried)
        : TemplateStructurePiece(0, templates, template, MakeSettings(rotation), position) {

        public bool IsBeached => isBeached;

        private static StructurePlaceSettings MakeSettings(BlockRotation rotation) {
            return new StructurePlaceSettings {
                Rotation = rotation,
                Mirror = BlockMirror.None,
                RotationPivot = Pivot
            }.AddProcessor(BlockIgnoreProcessor.StructureAndAir);
        }

        /// <summary>
        /// Drops the wreck onto the mean height under it, or buries a beached one to half its depth.
        /// </summary>
        /// <remarks>
        /// The footprint walked is the template's <b>own</b> size laid out from the template position,
        /// not the rotated bounding box, so a turned wreck measures a rectangle it does not sit over.
        /// That is upstream's, and it is why the two are written apart here.
        /// <p/>
        /// A beached wreck measures the <b>lowest</b> column rather than the mean, which is what stops
        /// the end of one on a slope hanging in the air.
        /// <p/>
        /// A template over 32 blocks wide or tall is left where it was laid out. That is the only
        /// thing standing between the walk and a footprint reaching outside the level's three by
        /// three, so it is transcribed rather than dropped for being unreachable: no vanilla wreck is
        /// bigger than nine by twenty-eight, and a pack shipping one would otherwise read the columns
        /// past the region as the bottom of the world.
        /// </remarks>
        protected override Vec3<int> SettleAgainstTerrain(IFeatureLevel level) {
            if (Template.Size.X > 32 || Template.Size.Y > 32) {
                return TemplatePosition;
            }

            HeightmapType heightmap = isBeached
                ? HeightmapType.WorldSurfaceWorldgen
                : HeightmapType.OceanFloorWorldgen;

            int columns = Template.Size.X * Template.Size.Z;

            if (columns == 0) {
                return WithHeight(level.GetHeight(heightmap, TemplatePosition.X, TemplatePosition.Z));
            }

            int lowest = level.MaxY;
            int total = 0;

            for (int x = TemplatePosition.X; x < TemplatePosition.X + Template.Size.X; x++) {
                for (int z = TemplatePosition.Z; z < TemplatePosition.Z + Template.Size.Z; z++) {
                    int height = level.GetHeight(heightmap, x, z);

                    total += height;
                    lowest = Math.Min(lowest, height);
                }
            }

            return WithHeight(isBeached
                ? lowest - Template.Size.Y / 2 - buried
                : total / columns);
        }

        private Vec3<int> WithHeight(int y) {
            return new Vec3<int>(TemplatePosition.X, y, TemplatePosition.Z);
        }

        /// <summary>
        /// The three chest markers, which leave the template's own chest where it is.
        /// </summary>
        /// <remarks>
        /// All three do the same thing upstream, on a chest one below the marker, and the only thing
        /// that differs is which loot table is attached. There is no block entity to attach one to, so
        /// the three collapse to nothing and the chests are placed empty.
        /// </remarks>
        protected override void HandleDataMarker(string marker, Vec3<int> position,
            IFeatureLevel level, RandomSource random, BoundingBox chunkBox) { }
    }
}
