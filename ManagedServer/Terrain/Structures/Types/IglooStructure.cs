using ManagedServer.Terrain.Features;
using ManagedServer.Terrain.Structures.Templates;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Structures.Types;

/// <summary>
/// <c>IglooStructure</c>: a snow hut, and half the time a ladder down to a basement.
/// </summary>
/// <remarks>
/// The basement is <b>three templates stacked</b> rather than one: a laboratory at the bottom and a
/// run of one block ladder shafts above it, each three tall. That is why the depth is drawn in shafts
/// and multiplied by three everywhere it is used.
/// </remarks>
public sealed class IglooStructure(Structure.StructureSettings settings,
    StructureTemplateManager templates) : Structure(settings) {

    /// <summary>
    /// The height every igloo template is laid out at before being dropped onto the terrain.
    /// </summary>
    /// <remarks>
    /// An arbitrary constant upstream too. What matters is only that the pieces agree, since the whole
    /// stack is shifted by the difference between this and the real surface.
    /// </remarks>
    public const int GenerationHeight = 90;

    private static readonly Identifier Top = "minecraft:igloo/top";
    private static readonly Identifier Middle = "minecraft:igloo/middle";
    private static readonly Identifier Bottom = "minecraft:igloo/bottom";

    private static readonly Dictionary<Identifier, Vec3<int>> Pivots = new() {
        [Top] = new Vec3<int>(3, 5, 5),
        [Middle] = new Vec3<int>(1, 3, 1),
        [Bottom] = new Vec3<int>(3, 6, 7)
    };

    private static readonly Dictionary<Identifier, Vec3<int>> Offsets = new() {
        [Top] = new Vec3<int>(0, 0, 0),
        [Middle] = new Vec3<int>(2, -3, 4),
        [Bottom] = new Vec3<int>(0, -3, -2)
    };

    protected override GenerationStub? FindGenerationPoint(StructureGenerationContext context) {
        return OnTopOfChunkCenter(context, HeightmapType.WorldSurfaceWorldgen,
            builder => Generate(builder, context));
    }

    private void Generate(StructurePiecesBuilder builder, StructureGenerationContext context) {
        WorldgenRandom random = context.Random;
        Vec3<int> start = new(context.ChunkX << 4, GenerationHeight, context.ChunkZ << 4);
        BlockRotation rotation = (BlockRotation)random.NextInt(4);

        if (random.NextDouble() < 0.5) {
            int shafts = random.NextInt(8) + 4;

            builder.AddPiece(new IglooPiece(templates, Bottom, start, rotation, shafts * 3));

            for (int i = 0; i < shafts - 1; i++) {
                builder.AddPiece(new IglooPiece(templates, Middle, start, rotation, i * 3));
            }
        }

        builder.AddPiece(new IglooPiece(templates, Top, start, rotation, 0));
    }

    private static StructurePlaceSettings MakeSettings(BlockRotation rotation, Identifier template) {
        return new StructurePlaceSettings {
            Rotation = rotation,
            Mirror = BlockMirror.None,
            RotationPivot = Pivots[template],

            // An igloo stands in snow, and its basement is dug out of stone. Waterlogging every block
            // written into a flooded cell would fill the shaft.
            ApplyWaterlogging = false
        }.AddProcessor(BlockIgnoreProcessor.StructureBlock);
    }

    /// <summary>One template of the stack.</summary>
    public sealed class IglooPiece : TemplateStructurePiece {
        private readonly bool _isTop;

        public IglooPiece(StructureTemplateManager templates, Identifier template, Vec3<int> position,
            BlockRotation rotation, int depth)
            : base(0, templates, template, MakeSettings(rotation, template),
                MakePosition(template, position, depth)) {

            _isTop = template.Equals(Top);
        }

        private static Vec3<int> MakePosition(Identifier template, Vec3<int> position, int depth) {
            Vec3<int> offset = Offsets[template];

            return new Vec3<int>(position.X + offset.X, position.Y + offset.Y - depth,
                position.Z + offset.Z);
        }

        /// <summary>
        /// Drops the piece by the ground under the hut's doorway, one column.
        /// </summary>
        /// <remarks>
        /// <b>Every piece of the stack measures its own column, not the hut's</b>, and they are
        /// different columns: the offset subtracted here is the piece's own, so a basement shaft is
        /// settled against whatever the ground does four blocks away from the door. So a stack on a
        /// slope really does come apart slightly upstream.
        /// </remarks>
        protected override Vec3<int> SettleAgainstTerrain(IFeatureLevel level) {
            Vec3<int> offset = Offsets[TemplateName];

            Vec3<int> door = StructureTemplate.CalculateRelativePosition(PlaceSettings,
                new Vec3<int>(3 - offset.X, 0, -offset.Z));

            int surface = level.GetHeight(HeightmapType.WorldSurfaceWorldgen,
                TemplatePosition.X + door.X, TemplatePosition.Z + door.Z);

            return new Vec3<int>(TemplatePosition.X,
                TemplatePosition.Y + surface - GenerationHeight - 1, TemplatePosition.Z);
        }

        /// <summary>
        /// The hut's floor is closed where the shaft below it was not built.
        /// </summary>
        /// <remarks>
        /// The trapdoor cell is left as the template wrote it when a ladder is under it, and filled
        /// with snow otherwise. The test is on what is <b>below</b> the cell rather than in it, which
        /// is what tells an igloo with a basement from one without.
        /// </remarks>
        public override void PostProcess(IFeatureLevel level, RandomSource random,
            BoundingBox chunkBox, int chunkX, int chunkZ, Vec3<int> referencePos) {

            base.PostProcess(level, random, chunkBox, chunkX, chunkZ, referencePos);

            if (!_isTop) {
                return;
            }

            Vec3<int> relative = StructureTemplate.CalculateRelativePosition(PlaceSettings,
                new Vec3<int>(3, 0, 5));

            // The settled position, as upstream: the template has already been written against it,
            // so the cell this fills is the one the hut's floor left.
            Vec3<int> settled = SettleAgainstTerrain(level);

            Vec3<int> trapdoor = new(settled.X + relative.X, settled.Y + relative.Y,
                settled.Z + relative.Z);

            if (!chunkBox.IsInside(trapdoor.X, trapdoor.Y, trapdoor.Z)) {
                return;
            }

            uint below = level.GetState(trapdoor.X, trapdoor.Y - 1, trapdoor.Z);

            if (level.Blocks.IsAir(below)
                || level.Registry.Blocks.GetByStateId(below).Identifier
                    .Equals(Block.Ladder.Identifier)) {

                return;
            }

            level.SetState(trapdoor.X, trapdoor.Y, trapdoor.Z, Block.SnowBlock.StateId);
        }

        /// <summary>
        /// The basement's chest marker, which leaves air where vanilla leaves an empty chest below it.
        /// </summary>
        /// <remarks>
        /// The marker's own cell is cleared, as upstream: the chest is the block <b>under</b> the
        /// marker and the template already wrote it. All this hook adds upstream is the loot table,
        /// which lives on a block entity there is no port of.
        /// </remarks>
        protected override void HandleDataMarker(string marker, Vec3<int> position,
            IFeatureLevel level, RandomSource random, BoundingBox chunkBox) {

            if (marker.Equals("chest", StringComparison.Ordinal)) {
                level.SetState(position.X, position.Y, position.Z, Block.Air.StateId);
            }
        }
    }
}
