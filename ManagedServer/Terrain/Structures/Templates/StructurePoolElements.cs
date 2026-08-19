using ManagedServer.Terrain.Features;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Registry;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;
using NBT;
using NBT.Tags;

namespace ManagedServer.Terrain.Structures.Templates;

/// <summary>
/// <c>StructurePoolElement</c>: one thing a jigsaw connection may be filled with.
/// </summary>
/// <remarks>
/// The projection is <b>mutable and set by the pool</b>, as upstream: a pool file names one projection
/// per entry and writes it onto the element after building it, and a list element passes its own down
/// to every element inside it. That is why it is not a constructor argument on the interface.
/// </remarks>
public interface IStructurePoolElement {
    PoolProjection Projection { get; set; }

    Vec3<int> GetSize(StructureTemplateManager templates, BlockRotation rotation);

    /// <summary>
    /// The element's jigsaw blocks, shuffled and then ordered by selection priority.
    /// </summary>
    /// <remarks>
    /// The two steps together are what selection priority means: within one priority the order is the
    /// shuffle's, and a higher priority always comes first. A stable sort is required, so the shuffle
    /// survives inside each priority band.
    /// </remarks>
    List<JigsawBlockInfo> GetShuffledJigsawBlocks(StructureTemplateManager templates,
        Vec3<int> position, BlockRotation rotation, RandomSource random, MinecraftRegistry registry);

    BoundingBox GetBoundingBox(StructureTemplateManager templates, Vec3<int> position,
        BlockRotation rotation);

    bool Place(StructureTemplateManager templates, IFeatureLevel level, Vec3<int> position,
        Vec3<int> referencePos, BlockRotation rotation, BoundingBox chunkBox, RandomSource random,
        bool applyWaterlogging, PlacementContext? features);

    /// <summary>
    /// How far the element's own ground sits above the bottom of its box, which is what a rigid
    /// connection measures heights against. One for everything but a piece joined rigidly to another.
    /// </summary>
    int GroundLevelDelta => 1;
}

/// <summary>
/// <c>EmptyPoolElement</c>: the element a pool answers when it has nothing, and the terminator the
/// placer breaks on.
/// </summary>
/// <remarks>
/// The placer <b>stops walking a pool</b> the moment it reaches this rather than skipping it, so an
/// empty entry in a pool truncates everything after it in the shuffled order.
/// </remarks>
public sealed class EmptyPoolElement : IStructurePoolElement {
    public static readonly EmptyPoolElement Instance = new();

    private EmptyPoolElement() { }

    public PoolProjection Projection { get; set; } = PoolProjection.TerrainMatching;

    public Vec3<int> GetSize(StructureTemplateManager templates, BlockRotation rotation) {
        return new Vec3<int>(0, 0, 0);
    }

    public List<JigsawBlockInfo> GetShuffledJigsawBlocks(StructureTemplateManager templates,
        Vec3<int> position, BlockRotation rotation, RandomSource random, MinecraftRegistry registry) => [];

    public BoundingBox GetBoundingBox(StructureTemplateManager templates, Vec3<int> position,
        BlockRotation rotation) {

        throw new InvalidOperationException(
            "The empty pool element has no bounding box; a caller reached one without filtering it "
            + "out first.");
    }

    public bool Place(StructureTemplateManager templates, IFeatureLevel level, Vec3<int> position,
        Vec3<int> referencePos, BlockRotation rotation, BoundingBox chunkBox, RandomSource random,
        bool applyWaterlogging, PlacementContext? features) => true;
}

/// <summary>
/// <c>SinglePoolElement</c>: one template, with a processor list and an optional liquid override.
/// </summary>
public class SinglePoolElement(Identifier template, IReadOnlyList<IStructureProcessor> processors,
    PoolProjection projection, bool? overrideWaterlogging) : IStructurePoolElement {

    public PoolProjection Projection { get; set; } = projection;

    public Identifier Template => template;

    public Vec3<int> GetSize(StructureTemplateManager templates, BlockRotation rotation) {
        return templates.Get(template).SizeAfter(rotation);
    }

    public List<JigsawBlockInfo> GetShuffledJigsawBlocks(StructureTemplateManager templates,
        Vec3<int> position, BlockRotation rotation, RandomSource random, MinecraftRegistry registry) {

        List<JigsawBlockInfo> jigsaws = templates.Get(template).GetJigsaws(position, rotation, registry);

        StructurePiece.Shuffle(jigsaws, random);

        // Stable, so the shuffle decides the order inside one priority band.
        return jigsaws.OrderByDescending(jigsaw => jigsaw.SelectionPriority).ToList();
    }

    public BoundingBox GetBoundingBox(StructureTemplateManager templates, Vec3<int> position,
        BlockRotation rotation) {

        return templates.Get(template).GetBoundingBox(
            new StructurePlaceSettings { Rotation = rotation }, position);
    }

    public bool Place(StructureTemplateManager templates, IFeatureLevel level, Vec3<int> position,
        Vec3<int> referencePos, BlockRotation rotation, BoundingBox chunkBox, RandomSource random,
        bool applyWaterlogging, PlacementContext? features) {

        StructureTemplate structure = templates.Get(template);
        StructurePlaceSettings settings = Settings(rotation, chunkBox, applyWaterlogging);

        return structure.PlaceInWorld(level, position, referencePos, settings, random);
    }

    /// <summary>
    /// The settings a single element places with.
    /// </summary>
    /// <remarks>
    /// The jigsaw replacement processor is what turns each jigsaw block into its <c>final_state</c>,
    /// and the element's own processors run <b>after</b> it, then the projection's. So a rule keyed on
    /// a jigsaw block never matches, and a gravity processor from the projection moves what everything
    /// before it produced.
    /// <p/>
    /// <b>A pool element declares its shape known, so nothing it writes is settled against its
    /// neighbours.</b> A jigsaw piece is cut to fit its own connections, and a village is laid out one
    /// piece per chunk share, so settling would ask a fence at the chunk border what it joins while the
    /// half of the piece in the next chunk does not exist yet and take the connection away. The saved
    /// state is the answer; a template placed on its own account, like a shipwreck, is the case that
    /// has to settle.
    /// </remarks>
    protected virtual StructurePlaceSettings Settings(BlockRotation rotation, BoundingBox chunkBox,
        bool applyWaterlogging) {

        StructurePlaceSettings settings = new() {
            BoundingBox = chunkBox,
            Rotation = rotation,
            KnownShape = true,
            ApplyWaterlogging = overrideWaterlogging ?? applyWaterlogging
        };

        settings.AddProcessor(BlockIgnoreProcessor.StructureBlock);
        settings.AddProcessor(JigsawReplacementProcessor.Instance);
        settings.AddProcessors(processors);
        settings.AddProcessors(PoolProjections.ProcessorsFor(Projection));

        return settings;
    }
}

/// <summary>
/// <c>LegacySinglePoolElement</c>: a single element that also drops the template's air.
/// </summary>
/// <remarks>
/// The only difference is which ignore processor is used, and it is what keeps every village piece
/// generating as it did before the two kinds were split: a legacy piece sits into the terrain, while a
/// modern one carves its own air out.
/// </remarks>
public sealed class LegacySinglePoolElement(Identifier template,
    IReadOnlyList<IStructureProcessor> processors, PoolProjection projection,
    bool? overrideWaterlogging)
    : SinglePoolElement(template, processors, projection, overrideWaterlogging) {

    protected override StructurePlaceSettings Settings(BlockRotation rotation, BoundingBox chunkBox,
        bool applyWaterlogging) {

        StructurePlaceSettings settings = base.Settings(rotation, chunkBox, applyWaterlogging);

        settings.PopProcessor(BlockIgnoreProcessor.StructureBlock);
        settings.AddProcessor(BlockIgnoreProcessor.StructureAndAir);

        return settings;
    }
}

/// <summary>
/// <c>ListPoolElement</c>: several elements placed one over another at the same position.
/// </summary>
/// <remarks>
/// The connections come from the <b>first</b> element alone, so the rest are overlays: a piece plus
/// the decoration that goes on it. A list whose first element has no jigsaw blocks is a dead end
/// however many the others have.
/// </remarks>
public sealed class ListPoolElement : IStructurePoolElement {
    private readonly IStructurePoolElement[] _elements;
    private PoolProjection _projection;

    public ListPoolElement(IReadOnlyList<IStructurePoolElement> elements, PoolProjection projection) {
        if (elements.Count == 0) {
            throw new FormatException("A list pool element has no elements.");
        }

        _elements = [..elements];
        Projection = projection;
    }

    public PoolProjection Projection {
        get => _projection;

        set {
            _projection = value;

            foreach (IStructurePoolElement element in _elements) {
                element.Projection = value;
            }
        }
    }

    public Vec3<int> GetSize(StructureTemplateManager templates, BlockRotation rotation) {
        int x = 0;
        int y = 0;
        int z = 0;

        foreach (IStructurePoolElement element in _elements) {
            Vec3<int> size = element.GetSize(templates, rotation);
            x = Math.Max(x, size.X);
            y = Math.Max(y, size.Y);
            z = Math.Max(z, size.Z);
        }

        return new Vec3<int>(x, y, z);
    }

    public List<JigsawBlockInfo> GetShuffledJigsawBlocks(StructureTemplateManager templates,
        Vec3<int> position, BlockRotation rotation, RandomSource random, MinecraftRegistry registry) {

        return _elements[0].GetShuffledJigsawBlocks(templates, position, rotation, random, registry);
    }

    public BoundingBox GetBoundingBox(StructureTemplateManager templates, Vec3<int> position,
        BlockRotation rotation) {

        BoundingBox? box = BoundingBox.Encapsulating(_elements
            .Where(element => !ReferenceEquals(element, EmptyPoolElement.Instance))
            .Select(element => element.GetBoundingBox(templates, position, rotation)));

        return box ?? throw new InvalidOperationException(
            "A list pool element holds nothing but empty elements, so it has no bounding box.");
    }

    public bool Place(StructureTemplateManager templates, IFeatureLevel level, Vec3<int> position,
        Vec3<int> referencePos, BlockRotation rotation, BoundingBox chunkBox, RandomSource random,
        bool applyWaterlogging, PlacementContext? features) {

        foreach (IStructurePoolElement element in _elements) {
            if (!element.Place(templates, level, position, referencePos, rotation, chunkBox, random,
                applyWaterlogging, features)) {

                return false;
            }
        }

        return true;
    }
}

/// <summary>
/// <c>FeaturePoolElement</c>: a placed feature hung off a jigsaw connection rather than a template.
/// </summary>
/// <remarks>
/// It has <b>no size and no template</b>: what it contributes to the layout is a single jigsaw block
/// facing down, built here rather than read from a file, so the placer can join it like anything else
/// and it then occupies nothing. That is how a village grows a tree or a pile of hay off a decoration
/// point.
/// </remarks>
public sealed class FeaturePoolElement(Identifier featureId, PlacedFeature feature,
    PoolProjection projection) : IStructurePoolElement {

    /// <summary>What a jigsaw block on a feature element is named, <c>DEFAULT_JIGSAW_NAME</c>.</summary>
    /// <remarks>
    /// <b>Load bearing, and the whole of what lets a feature element attach to anything.</b>
    /// <c>canAttach</c> asks that the source's <c>target</c> equal the candidate's <c>name</c>, and
    /// every decoration connection in the game targets <c>bottom</c>. Named anything else, a feature
    /// element matches no connection, and a village comes out with no trees or hay beside its roads.
    /// </remarks>
    private static readonly Identifier DefaultJigsawName = "minecraft:bottom";

    /// <summary>
    /// The jigsaw block entity every feature element pretends to have, <c>fillDefaultJigsawNBT</c>.
    /// </summary>
    private static readonly CompoundTag DefaultJigsawNbt = new(
        ("name", new StringTag(DefaultJigsawName)),
        ("final_state", new StringTag("minecraft:air")),
        ("pool", new StringTag(TemplatePools.Empty)),
        ("target", new StringTag(JigsawBlockInfo.Empty)),
        ("joint", new StringTag("rollable")));

    public PoolProjection Projection { get; set; } = projection;

    public Identifier FeatureId => featureId;

    public Vec3<int> GetSize(StructureTemplateManager templates, BlockRotation rotation) {
        return new Vec3<int>(0, 0, 0);
    }

    public List<JigsawBlockInfo> GetShuffledJigsawBlocks(StructureTemplateManager templates,
        Vec3<int> position, BlockRotation rotation, RandomSource random, MinecraftRegistry registry) {

        uint jigsaw = ((IOriented)Block.Jigsaw)
            .WithOrientation(Orientations.Join(BlockFace.NegY, BlockFace.PosZ)).StateId;

        return [JigsawBlockInfo.Of(new TemplateBlockInfo(position, jigsaw, DefaultJigsawNbt), registry)];
    }

    public BoundingBox GetBoundingBox(StructureTemplateManager templates, Vec3<int> position,
        BlockRotation rotation) {

        Vec3<int> size = GetSize(templates, rotation);

        return new BoundingBox(position.X, position.Y, position.Z, position.X + size.X,
            position.Y + size.Y, position.Z + size.Z);
    }

    /// <summary>
    /// Runs the feature.
    /// </summary>
    /// <remarks>
    /// Answers true without doing anything when the structure pass was not given a feature context,
    /// which is a caller that turned the feature pass off. A jigsaw structure needs the feature pass
    /// to run at all, so that is a configuration the pass rejects rather than something reachable.
    /// </remarks>
    public bool Place(StructureTemplateManager templates, IFeatureLevel level, Vec3<int> position,
        Vec3<int> referencePos, BlockRotation rotation, BoundingBox chunkBox, RandomSource random,
        bool applyWaterlogging, PlacementContext? features) {

        return features is null || feature.Place(features, random, position);
    }
}
