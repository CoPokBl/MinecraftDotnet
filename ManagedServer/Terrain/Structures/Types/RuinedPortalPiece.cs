using ManagedServer.Placement;
using ManagedServer.Terrain.Features;
using ManagedServer.Terrain.Structures.Templates;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Structures.Types;

/// <summary>
/// <c>RuinedPortalPiece</c>: the portal frame, plus the netherrack that leaked out around it.
/// </summary>
/// <remarks>
/// Almost all of this runs <b>after</b> the template is placed: the skirt of netherrack, the columns
/// dripping off its underside, and the vines and leaves that grow over it. The template itself is only
/// the obsidian frame.
/// </remarks>
public sealed class RuinedPortalPiece : TemplateStructurePiece {
    private const float GoldGoneProbability = 0.3f;
    private const float MagmaInsteadOfNetherrackProbability = 0.07f;
    private const float MagmaInsteadOfLavaProbability = 0.2f;

    private static readonly Identifier FeaturesCannotReplace = "minecraft:features_cannot_replace";

    /// <summary>
    /// How likely a netherrack skirt is at each Manhattan distance from the portal's centre.
    /// </summary>
    private static readonly float[] NetherrackByDistance =
        [1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 0.9f, 0.9f, 0.8f, 0.7f, 0.6f, 0.4f, 0.2f];

    private readonly RuinedPortalPlacement _placement;
    private readonly RuinedPortalProperties _properties;

    public RuinedPortalPiece(StructureTemplateManager templates, Vec3<int> position,
        RuinedPortalPlacement placement, RuinedPortalProperties properties,
        Identifier templateLocation, BlockRotation rotation, BlockMirror mirror, Vec3<int> pivot)
        : base(0, templates, templateLocation,
            MakeSettings(mirror, rotation, placement, pivot, properties), position) {

        _placement = placement;
        _properties = properties;
    }

    /// <summary>
    /// The five or six processors that turn a portal template into a ruin.
    /// </summary>
    /// <remarks>
    /// The order is not free: the rules strip gold and turn lava before the age processor mosses what
    /// is left, and the lava processor runs last so that a slab written into a lava lake still becomes
    /// lava. The <b>air pocket</b> setting swaps which ignore processor is used, which is what decides
    /// whether the template's own air is written as a bubble or lets the terrain through.
    /// </remarks>
    private static StructurePlaceSettings MakeSettings(BlockMirror mirror, BlockRotation rotation,
        RuinedPortalPlacement placement, Vec3<int> pivot, RuinedPortalProperties properties) {

        BlockIgnoreProcessor ignore = properties.AirPocket
            ? BlockIgnoreProcessor.StructureBlock
            : BlockIgnoreProcessor.StructureAndAir;

        List<ProcessorRule> rules = [
            Replace(Block.GoldBlock.Identifier, GoldGoneProbability, Block.Air.StateId),
            LavaRule(placement, properties)
        ];

        if (!properties.Cold) {
            rules.Add(Replace(Block.Netherrack.Identifier, MagmaInsteadOfNetherrackProbability,
                Block.MagmaBlock.StateId));
        }

        StructurePlaceSettings settings = new StructurePlaceSettings {
            Rotation = rotation,
            Mirror = mirror,
            RotationPivot = pivot
        }
            .AddProcessor(ignore)
            .AddProcessor(new RuleProcessor(rules))
            .AddProcessor(new BlockAgeProcessor(properties.Mossiness))
            .AddProcessor(new ProtectedBlockProcessor(FeaturesCannotReplace))
            .AddProcessor(LavaSubmergedBlockProcessor.Instance);

        if (properties.ReplaceWithBlackstone) {
            settings.AddProcessor(BlackstoneReplaceProcessor.Instance);
        }

        return settings;
    }

    /// <summary>
    /// What the template's lava becomes, which is the one rule that depends on where the portal is.
    /// </summary>
    private static ProcessorRule LavaRule(RuinedPortalPlacement placement,
        RuinedPortalProperties properties) {

        if (placement == RuinedPortalPlacement.OnOceanFloor) {
            return Replace(Block.Lava.Identifier, Block.MagmaBlock.StateId);
        }

        return properties.Cold
            ? Replace(Block.Lava.Identifier, Block.Netherrack.StateId)
            : Replace(Block.Lava.Identifier, MagmaInsteadOfLavaProbability, Block.MagmaBlock.StateId);
    }

    private static ProcessorRule Replace(Identifier source, float probability, uint target) {
        return new ProcessorRule(new IRuleTest.RandomBlockMatch(source, probability),
            IRuleTest.AlwaysTrue.Instance, IPosRuleTest.AlwaysTrue.Instance, target,
            IRuleBlockEntityModifier.Passthrough.Instance);
    }

    private static ProcessorRule Replace(Identifier source, uint target) {
        return new ProcessorRule(new IRuleTest.BlockMatch(source), IRuleTest.AlwaysTrue.Instance,
            IPosRuleTest.AlwaysTrue.Instance, target, IRuleBlockEntityModifier.Passthrough.Instance);
    }

    protected override void HandleDataMarker(string marker, Vec3<int> position, IFeatureLevel level,
        RandomSource random, BoundingBox chunkBox) { }

    /// <summary>
    /// Places the frame and everything that grew on it.
    /// </summary>
    /// <remarks>
    /// <b>Only the chunk holding the portal's centre does any of this</b>, and it then grows the
    /// writable area to the whole piece so the rest reaches through the generation API's forks. That
    /// is upstream's own guard, and it is what makes the skirt and the drip columns one decision
    /// rather than a different one per chunk.
    /// </remarks>
    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        BoundingBox box = Template.GetBoundingBox(PlaceSettings, TemplatePosition);
        Vec3<int> centre = box.Center;

        if (!chunkBox.IsInside(centre.X, centre.Y, centre.Z)) {
            return;
        }

        chunkBox.Encapsulate(box);

        base.PostProcess(level, random, chunkBox, chunkX, chunkZ, referencePos);

        SpreadNetherrack(random, level);
        AddNetherrackDripColumnsBelowPortal(random, level);

        if (!_properties.Vines && !_properties.Overgrown) {
            return;
        }

        // Walked as BlockPos.betweenClosedStream walks a box, x fastest and z slowest. Both passes
        // below draw per position, so any other nesting spends the same numbers on different blocks.
        for (int z = BoundingBox.MinZ; z <= BoundingBox.MaxZ; z++) {
            for (int y = BoundingBox.MinY; y <= BoundingBox.MaxY; y++) {
                for (int x = BoundingBox.MinX; x <= BoundingBox.MaxX; x++) {
                    Vec3<int> pos = new(x, y, z);

                    if (_properties.Vines) {
                        MaybeAddVines(random, level, pos);
                    }

                    if (_properties.Overgrown) {
                        MaybeAddLeavesAbove(random, level, pos);
                    }
                }
            }
        }
    }

    /// <summary>
    /// A vine on the air beside any solid face of the ruin.
    /// </summary>
    /// <remarks>
    /// The vine goes on the <b>neighbour</b> cell and faces back at the block it grew from, which is
    /// why the property written is the opposite direction's.
    /// </remarks>
    private void MaybeAddVines(RandomSource random, IFeatureLevel level, Vec3<int> pos) {
        uint stateId = level.GetState(pos.X, pos.Y, pos.Z);

        if (level.Blocks.IsAir(stateId)
            || level.Registry.Blocks.GetByStateId(stateId).Identifier.Equals(Block.Vine.Identifier)) {

            return;
        }

        BlockFace face = Directions.Horizontal[random.NextInt(Directions.Horizontal.Length)];
        Vec3<int> neighbour = pos.GetBlockTowards(face);

        if (!level.Blocks.IsAir(level.GetState(neighbour.X, neighbour.Y, neighbour.Z))) {
            return;
        }

        IBlock block = level.Registry.Blocks.GetByStateId(stateId);

        if (!Placement.Helpers.ShapeSupport.IsFaceFull(block.CollisionShape, face)) {
            return;
        }

        IBlock vine = (IBlock)((IFaceConnected)Block.Vine).WithConnection(face.Opposite(), true);

        level.SetState(neighbour.X, neighbour.Y, neighbour.Z, vine.StateId);
    }

    private void MaybeAddLeavesAbove(RandomSource random, IFeatureLevel level, Vec3<int> pos) {
        if (random.NextFloat() >= 0.5f) {
            return;
        }

        uint here = level.GetState(pos.X, pos.Y, pos.Z);

        if (!level.Registry.Blocks.GetByStateId(here).Identifier.Equals(Block.Netherrack.Identifier)
            || !level.Blocks.IsAir(level.GetState(pos.X, pos.Y + 1, pos.Z))) {

            return;
        }

        level.SetState(pos.X, pos.Y + 1, pos.Z,
            ((IPersistent)Block.JungleLeaves).WithPersistent(true).StateId);
    }

    private void AddNetherrackDripColumnsBelowPortal(RandomSource random, IFeatureLevel level) {
        for (int x = BoundingBox.MinX + 1; x < BoundingBox.MaxX; x++) {
            for (int z = BoundingBox.MinZ + 1; z < BoundingBox.MaxZ; z++) {
                uint state = level.GetState(x, BoundingBox.MinY, z);

                if (level.Registry.Blocks.GetByStateId(state).Identifier
                    .Equals(Block.Netherrack.Identifier)) {

                    AddNetherrackDripColumn(random, level,
                        new Vec3<int>(x, BoundingBox.MinY - 1, z));
                }
            }
        }
    }

    /// <summary>
    /// A stalactite of netherrack hanging from a position, up to eight blocks long.
    /// </summary>
    /// <remarks>
    /// The first block is unconditional and each further one is a fresh half chance, so the length is
    /// geometric rather than uniform and most columns are one or two blocks.
    /// </remarks>
    private void AddNetherrackDripColumn(RandomSource random, IFeatureLevel level, Vec3<int> pos) {
        Vec3<int> current = pos;
        PlaceNetherrackOrMagma(random, level, current);

        int remaining = 8;

        while (remaining > 0 && random.NextFloat() < 0.5f) {
            current = new Vec3<int>(current.X, current.Y - 1, current.Z);
            remaining--;
            PlaceNetherrackOrMagma(random, level, current);
        }
    }

    /// <summary>
    /// The skirt of netherrack the portal burned into the ground around it.
    /// </summary>
    /// <remarks>
    /// The distance adjustment is drawn once and <b>added to</b> every distance, so a wide portal gets
    /// a narrower skirt than a small one: it is the only thing that makes the fixed probability table
    /// depend on the template.
    /// <p/>
    /// <b>The surface height is the level's frozen heightmap, not the noise column.</b> Those are
    /// different answers: <c>getBaseHeight</c> walks the density function and knows nothing about the
    /// surface rules or the carvers, so a skirt laid against it sits a block or more off wherever they
    /// moved the ground. The piece is placed only by the chunk holding its centre and the skirt
    /// reaches fourteen blocks, so every column it asks about is inside the level's three by three.
    /// </remarks>
    private void SpreadNetherrack(RandomSource random, IFeatureLevel level) {
        bool followGroundSurface = _placement is RuinedPortalPlacement.OnLandSurface
            or RuinedPortalPlacement.OnOceanFloor;

        Vec3<int> centre = BoundingBox.Center;
        int maxDistance = NetherrackByDistance.Length;

        int averageWidth = (BoundingBox.XSpan + BoundingBox.ZSpan) / 2;
        int distanceAdjustment = random.NextInt(Math.Max(1, 8 - averageWidth / 2));

        for (int x = centre.X - maxDistance; x <= centre.X + maxDistance; x++) {
            for (int z = centre.Z - maxDistance; z <= centre.Z + maxDistance; z++) {
                int distance = Math.Abs(x - centre.X) + Math.Abs(z - centre.Z);
                int adjusted = Math.Max(0, distance + distanceAdjustment);

                if (adjusted >= maxDistance) {
                    continue;
                }

                if (random.NextDouble() >= NetherrackByDistance[adjusted]) {
                    continue;
                }

                int surfaceY = level.GetHeight(RuinedPortalStructure.HeightmapFor(_placement), x, z) - 1;
                int y = followGroundSurface ? surfaceY : Math.Min(BoundingBox.MinY, surfaceY);

                Vec3<int> pos = new(x, y, z);

                if (Math.Abs(y - BoundingBox.MinY) > 3 || !CanBeReplaced(level, pos)) {
                    continue;
                }

                PlaceNetherrackOrMagma(random, level, pos);

                if (_properties.Overgrown) {
                    MaybeAddLeavesAbove(random, level, pos);
                }

                AddNetherrackDripColumn(random, level, new Vec3<int>(x, y - 1, z));
            }
        }
    }

    private bool CanBeReplaced(IFeatureLevel level, Vec3<int> pos) {
        if (!level.IsLoaded(pos.X, pos.Z)) {
            return true;
        }

        uint stateId = level.GetState(pos.X, pos.Y, pos.Z);
        Identifier id = level.Registry.Blocks.GetByStateId(stateId).Identifier;

        return !level.Blocks.IsAir(stateId)
            && !id.Equals(Block.Obsidian.Identifier)
            && !level.Blocks.IsIn(FeaturesCannotReplace, stateId)
            && (_placement == RuinedPortalPlacement.InNether || !id.Equals(Block.Lava.Identifier));
    }

    private void PlaceNetherrackOrMagma(RandomSource random, IFeatureLevel level, Vec3<int> pos) {
        bool magma = !_properties.Cold && random.NextFloat() < MagmaInsteadOfNetherrackProbability;

        level.SetState(pos.X, pos.Y, pos.Z,
            magma ? Block.MagmaBlock.StateId : Block.Netherrack.StateId);
    }
}
