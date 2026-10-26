using ManagedServer.Terrain.Features;
using ManagedServer.Terrain.Structures.Templates;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Structures.Types;

/// <summary>
/// <c>EndCityStructure</c>: a tower of end city sections, growing bridges and further towers off
/// itself.
/// </summary>
/// <remarks>
/// <c>couldValidBiomeExistInTerrainColumn</c> is not asked first. The end's biome source reads no y,
/// so it answers the column the same as the start position <see cref="Structure.FindValidGenerationPoint"/>
/// tests, and declining before or after the rotation draw leaves no start either way.
/// </remarks>
public sealed class EndCityStructure(Structure.StructureSettings settings,
    StructureTemplateManager templates) : Structure(settings) {

    protected override GenerationStub? FindGenerationPoint(StructureGenerationContext context) {
        BlockRotation rotation = (BlockRotation)context.Random.NextInt(4);
        Vec3<int> start = LowestIn5By5BoxOffset7Blocks(context, rotation);

        if (start.Y < 60) {
            return null;
        }

        return new GenerationStub(start, builder => {
            List<StructurePiece> pieces = [];

            new EndCityLayout(templates, context.Random).StartHouseTower(start, rotation, pieces);

            foreach (StructurePiece piece in pieces) {
                builder.AddPiece(piece);
            }
        });
    }

    /// <summary>
    /// The same footprint test the mansion uses, with the same offsets.
    /// </summary>
    /// <remarks>
    /// Shared by the two structures that are large enough to need a whole box tested rather than a
    /// column, and identical upstream, where it is a method on <c>Structure</c>.
    /// </remarks>
    internal static Vec3<int> LowestIn5By5BoxOffset7Blocks(StructureGenerationContext context,
        BlockRotation rotation) {

        int offsetX = 5;
        int offsetZ = 5;

        switch (rotation) {
            case BlockRotation.Clockwise90:
                offsetX = -5;
                break;

            case BlockRotation.Clockwise180:
                offsetX = -5;
                offsetZ = -5;
                break;

            case BlockRotation.CounterClockwise90:
                offsetZ = -5;
                break;
        }

        int blockX = (context.ChunkX << 4) + 7;
        int blockZ = (context.ChunkZ << 4) + 7;

        return new Vec3<int>(blockX, LowestY(context, blockX, blockZ, offsetX, offsetZ), blockZ);
    }

    /// <summary>One end city template.</summary>
    /// <remarks>
    /// <c>overwrite</c> chooses between the two ignore processors, which is what decides whether a
    /// section cuts a hole through what is already there or fits around it. Every roof and tower piece
    /// overwrites; the floors that stack inside a tower do not.
    /// </remarks>
    public sealed class EndCityPiece(StructureTemplateManager templates, string templateName,
        Vec3<int> position, BlockRotation rotation, bool overwrite)
        : TemplateStructurePiece(0, templates, $"minecraft:end_city/{templateName}",
            MakeSettings(overwrite, rotation), position) {

        private static StructurePlaceSettings MakeSettings(bool overwrite, BlockRotation rotation) {
            return new StructurePlaceSettings { Rotation = rotation }.AddProcessor(
                overwrite ? BlockIgnoreProcessor.StructureBlock : BlockIgnoreProcessor.StructureAndAir);
        }

        /// <summary>
        /// The chest, sentry and elytra markers.
        /// </summary>
        /// <remarks>
        /// The chest under a chest marker is the template's, and this only seeds its loot table, which
        /// is a draw where the chest is really there. The other two are a shulker and an item frame
        /// holding an elytra, both entities the generator cannot place, and neither draws.
        /// </remarks>
        protected override void HandleDataMarker(string marker, Vec3<int> position,
            IFeatureLevel level, RandomSource random, BoundingBox chunkBox) {

            if (!marker.StartsWith("Chest", StringComparison.Ordinal)) {
                return;
            }

            int chestY = position.Y - 1;
            if (chunkBox.IsInside(position.X, chestY, position.Z)
                && StructureTemplate.IsRandomisableContainer(level, level.GetState(position.X, chestY, position.Z))) {

                random.NextLong();
            }
        }
    }
}
