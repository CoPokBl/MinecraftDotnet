using ManagedServer.Terrain.Features;
using ManagedServer.Terrain.Structures.Templates;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;
using Minecraft.Placement;

namespace ManagedServer.Terrain.Structures.Types;

/// <summary>
/// <c>WoodlandMansionStructure</c>: the mansion, laid out on an eleven by eleven grid of eight block
/// cells and then built out of about a hundred templates.
/// </summary>
/// <remarks>
/// The only structure whose layout is a <b>grid algorithm rather than a piece tree</b>: corridors are
/// grown recursively into a grid, the leftover cells are grouped into rooms of three sizes, and only
/// then is each cell turned into templates. That is why nothing here uses
/// <see cref="StructurePiece.AddChildren"/>.
/// </remarks>
public sealed class WoodlandMansionStructure(Structure.StructureSettings settings,
    StructureTemplateManager templates) : Structure(settings) {

    protected override GenerationStub? FindGenerationPoint(StructureGenerationContext context) {
        BlockRotation rotation = (BlockRotation)context.Random.NextInt(4);
        Vec3<int> start = LowestIn5By5BoxOffset7Blocks(context, rotation);

        if (start.Y < 60) {
            return null;
        }

        return new GenerationStub(start, builder => {
            List<WoodlandMansionPiece> pieces = [];
            MansionPiecePlacer placer = new(templates, context.Random);

            placer.CreateMansion(start, rotation, pieces, new MansionGrid(context.Random));

            foreach (WoodlandMansionPiece piece in pieces) {
                builder.AddPiece(piece);
            }
        });
    }

    /// <summary>
    /// <c>getLowestYIn5by5BoxOffset7Blocks</c>: the ground under a five by five box, offset the way
    /// the mansion will be turned.
    /// </summary>
    /// <remarks>
    /// The offset flips sign with the rotation so that the box covers the ground the mansion will
    /// actually stand on rather than the ground behind it, which is what stops a turned mansion
    /// sitting in a hillside.
    /// </remarks>
    private static Vec3<int> LowestIn5By5BoxOffset7Blocks(StructureGenerationContext context,
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

    /// <summary>
    /// Fills the ground under the mansion with cobblestone so that it does not stand on stilts.
    /// </summary>
    /// <remarks>
    /// Runs per chunk over the part of the footprint that chunk holds, which is why it is an after
    /// place rather than a piece: no single piece knows the whole footprint, and the column under a
    /// piece may belong to a chunk that piece does not reach.
    /// </remarks>
    public override void AfterPlace(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, PiecesContainer pieces) {

        BoundingBox box = pieces.CalculateBoundingBox();
        int floor = box.MinY;

        for (int x = chunkBox.MinX; x <= chunkBox.MaxX; x++) {
            for (int z = chunkBox.MinZ; z <= chunkBox.MaxZ; z++) {
                if (level.Blocks.IsAir(level.GetState(x, floor, z))
                    || !box.IsInside(x, floor, z)
                    || !pieces.IsInsidePiece(x, floor, z)) {

                    continue;
                }

                for (int y = floor - 1; y > level.MinY; y--) {
                    uint state = level.GetState(x, y, z);

                    if (!level.Blocks.IsAir(state) && !level.Blocks.IsLiquid(state)) {
                        break;
                    }

                    level.SetState(x, y, z, Block.Cobblestone.StateId);
                }
            }
        }
    }

    /// <summary>One template of the mansion.</summary>
    /// <remarks>
    /// Every piece is one of about a hundred templates under <c>woodland_mansion/</c>, placed with a
    /// rotation and sometimes a mirror. The name is a bare string upstream, so the id is built here.
    /// </remarks>
    public sealed class WoodlandMansionPiece(StructureTemplateManager templates, string templateName,
        Vec3<int> position, BlockRotation rotation, BlockMirror mirror = BlockMirror.None)
        : TemplateStructurePiece(0, templates, Location(templateName), MakeSettings(mirror, rotation),
            position) {

        private static Identifier Location(string templateName) {
            return $"minecraft:woodland_mansion/{templateName}";
        }

        private static StructurePlaceSettings MakeSettings(BlockMirror mirror,
            BlockRotation rotation) {

            return new StructurePlaceSettings {
                Rotation = rotation,
                Mirror = mirror
            }.AddProcessor(BlockIgnoreProcessor.StructureBlock);
        }

        /// <summary>
        /// The chest markers, and the mob markers that leave nothing.
        /// </summary>
        /// <remarks>
        /// A chest marker names the direction the chest faces, which is then turned by the piece's own
        /// rotation. The three mob markers place an evoker, a vindicator or a group of allays; there is
        /// no entity to place during generation, so those cells are left as the template wrote them
        /// rather than being cleared, which is what vanilla does only <b>after</b> the mob exists.
        /// </remarks>
        protected override void HandleDataMarker(string marker, Vec3<int> position,
            IFeatureLevel level, RandomSource random, BoundingBox chunkBox) {

            if (!marker.StartsWith("Chest", StringComparison.Ordinal)) {
                return;
            }

            Direction? facing = marker switch {
                "ChestWest" => Direction.West,
                "ChestEast" => Direction.East,
                "ChestSouth" => Direction.South,
                "ChestNorth" => Direction.North,
                _ => null
            };

            uint state = Block.Chest.StateId;

            if (facing is { } direction) {
                BlockFace turned = BlockStateTransform.RotateFace(direction.ToFace(),
                    PlaceSettings.Rotation);

                state = ((IHorizontalFacing)Block.Chest).WithFacing(turned.ToDirection()).StateId;
            }

            CreateChestAt(level, chunkBox, random, position, state);
        }
    }
}
