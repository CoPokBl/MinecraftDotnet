using Minecraft.Placement.Helpers;
using ManagedServer.Terrain.Features;
using ManagedServer.Terrain.Features.Values;
using ManagedServer.Terrain.Structures.Templates;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Structures.Types;

/// <summary>
/// <c>NetherFossilStructure</c>: a bone skeleton half buried in the soul sand valleys.
/// </summary>
/// <remarks>
/// The one structure that picks its own column rather than the chunk's centre, and the only one that
/// reads a whole terrain column: it starts from a drawn height and walks <b>down</b> for air resting
/// on soul sand or on anything with a sturdy top face, which is a question no heightmap answers.
/// </remarks>
public sealed class NetherFossilStructure(Structure.StructureSettings settings,
    StructureTemplateManager templates, HeightProvider height) : Structure(settings) {

    private static readonly Identifier[] Fossils = [
        "minecraft:nether_fossils/fossil_1", "minecraft:nether_fossils/fossil_2",
        "minecraft:nether_fossils/fossil_3", "minecraft:nether_fossils/fossil_4",
        "minecraft:nether_fossils/fossil_5", "minecraft:nether_fossils/fossil_6",
        "minecraft:nether_fossils/fossil_7", "minecraft:nether_fossils/fossil_8",
        "minecraft:nether_fossils/fossil_9", "minecraft:nether_fossils/fossil_10",
        "minecraft:nether_fossils/fossil_11", "minecraft:nether_fossils/fossil_12",
        "minecraft:nether_fossils/fossil_13", "minecraft:nether_fossils/fossil_14"
    ];

    protected override GenerationStub? FindGenerationPoint(StructureGenerationContext context) {
        WorldgenRandom random = context.Random;

        int blockX = (context.ChunkX << 4) + random.NextInt(16);
        int blockZ = (context.ChunkZ << 4) + random.NextInt(16);

        int y = height.Sample(random, context.WorldGeneration);

        uint[] column = context.Columns(blockX, blockZ);

        // Down from the drawn height for the first air sitting on something a skeleton can lie on.
        // The decrement is inside the condition upstream, so the y that comes out is one below the
        // air that matched.
        while (y > context.SeaLevel) {
            uint current = At(column, context, y);
            uint below = At(column, context, --y);

            if (IsAir(context, current) && CanRestOn(context, below)) {
                break;
            }
        }

        if (y <= context.SeaLevel) {
            return null;
        }

        Vec3<int> position = new(blockX, y, blockZ);

        return new GenerationStub(position, builder => {
            BlockRotation rotation = (BlockRotation)random.NextInt(4);

            builder.AddPiece(new NetherFossilPiece(templates,
                Fossils[random.NextInt(Fossils.Length)], position, rotation, context.Seed));
        });
    }

    private static uint At(uint[] column, StructureGenerationContext context, int y) {
        int index = y - context.MinY;
        return index >= 0 && index < column.Length ? column[index] : Block.Air.StateId;
    }

    private static bool IsAir(StructureGenerationContext context, uint stateId) {
        return context.Registry.Blocks.GetByStateId(stateId).Air;
    }

    /// <summary>
    /// <c>isFaceSturdy(UP)</c>, or soul sand, which is deliberately named as well.
    /// </summary>
    /// <remarks>
    /// Soul sand does not have a sturdy top face, since its collision shape stops short of the
    /// boundary, so without the first half of the test a fossil would never lie on the block the
    /// biome is mostly made of.
    /// </remarks>
    private static bool CanRestOn(StructureGenerationContext context, uint stateId) {
        IBlock block = context.Registry.Blocks.GetByStateId(stateId);

        return block.Identifier.Equals(Block.SoulSand.Identifier)
            || ShapeSupport.IsFaceSturdy(block, BlockFace.PosY);
    }

    /// <summary>One bone pile.</summary>
    public sealed class NetherFossilPiece(StructureTemplateManager templates, Identifier template,
        Vec3<int> position, BlockRotation rotation, long seed)
        : TemplateStructurePiece(0, templates, template, MakeSettings(rotation), position) {

        private static StructurePlaceSettings MakeSettings(BlockRotation rotation) {
            return new StructurePlaceSettings {
                Rotation = rotation,
                Mirror = BlockMirror.None
            }.AddProcessor(BlockIgnoreProcessor.StructureAndAir);
        }

        protected override void HandleDataMarker(string marker, Vec3<int> position,
            IFeatureLevel level, RandomSource random, BoundingBox chunkBox) { }

        /// <summary>
        /// Places the bones, then rolls for a dried ghast among them.
        /// </summary>
        /// <remarks>
        /// The writable area is <b>grown to hold the whole fossil</b> before the template is placed,
        /// which is upstream's own <c>chunkBB.encapsulate</c>. That is what lets a fossil straddling a
        /// border write its far half, and it works here because the level forks a write outside the
        /// chunk rather than dropping it.
        /// <p/>
        /// The ghast draws from a random seeded on the fossil's <b>centre</b> rather than from the
        /// piece's own, so both halves of a fossil across a border agree about it, and the position
        /// test then keeps only the half that owns it.
        /// </remarks>
        public override void PostProcess(IFeatureLevel level, RandomSource random,
            BoundingBox chunkBox, int chunkX, int chunkZ, Vec3<int> referencePos) {

            BoundingBox fossil = Template.GetBoundingBox(PlaceSettings, TemplatePosition);
            chunkBox.Encapsulate(fossil);

            base.PostProcess(level, random, chunkBox, chunkX, chunkZ, referencePos);

            PlaceDriedGhast(level, fossil, chunkBox);
        }

        private void PlaceDriedGhast(IFeatureLevel level, BoundingBox fossil, BoundingBox chunkBox) {
            Vec3<int> centre = fossil.Center;

            RandomSource positional = new LegacyRandomSource(seed).ForkPositional()
                .At(centre.X, centre.Y, centre.Z);

            if (positional.NextFloat() >= 0.5f) {
                return;
            }

            int x = fossil.MinX + positional.NextInt(fossil.XSpan);
            int y = fossil.MinY;
            int z = fossil.MinZ + positional.NextInt(fossil.ZSpan);

            if (!chunkBox.IsInside(x, y, z) || !level.Blocks.IsAir(level.GetState(x, y, z))) {
                return;
            }

            IBlock ghast = BlockStateTransform.Rotate(Block.DriedGhast,
                (BlockRotation)positional.NextInt(4));

            level.SetState(x, y, z, ghast.StateId);
        }
    }
}
