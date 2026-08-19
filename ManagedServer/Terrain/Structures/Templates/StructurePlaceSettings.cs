using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Structures.Templates;

/// <summary>
/// <c>StructurePlaceSettings</c>: everything about one placement of a template, which is the half a
/// <see cref="StructureTemplate"/> deliberately does not hold.
/// </summary>
/// <remarks>
/// <b>Mutable and copied, as vanilla's is.</b> <see cref="Copy"/> is how a piece hands its own settings
/// to a nested placement without the nested one's box escaping back, and
/// <c>TemplateStructurePiece.PostProcess</c> writes <see cref="BoundingBox"/> on its own settings once
/// per chunk it is placed into. Making this a record would leave that caller updating a copy.
/// </remarks>
public sealed class StructurePlaceSettings {
    private readonly List<IStructureProcessor> _processors = [];

    public BlockMirror Mirror { get; set; } = BlockMirror.None;

    public BlockRotation Rotation { get; set; } = BlockRotation.None;

    /// <summary>What the mirror and rotation turn about, in the template's own coordinates.</summary>
    public Vec3<int> RotationPivot { get; set; } = new(0, 0, 0);

    /// <summary>
    /// The writable area, which the structure pass sets to the chunk being generated. Null writes
    /// everywhere, which only a caller placing into a level of its own ever wants.
    /// </summary>
    public BoundingBox? BoundingBox { get; set; }

    /// <summary>
    /// Whether a block written into water keeps the water, vanilla's <c>LiquidSettings</c>.
    /// </summary>
    /// <remarks>
    /// On by default, and turned off by the pieces that must not flood: an ocean ruin's air pockets and
    /// a shipwreck's hull are the two that care.
    /// </remarks>
    public bool ApplyWaterlogging { get; set; } = true;

    /// <summary>
    /// Whether the caller is writing an exact scene and wants the states it gave left alone.
    /// </summary>
    /// <remarks>
    /// Off by default, so a template settles its stairs, fences and panes against what it landed on: a
    /// saved build carries whatever connections it had where it was cut from, and a wreck's stairs
    /// really do arrive as <c>outer_right</c>.
    /// <p/>
    /// <b>A jigsaw pool element turns it on</b>, which is the split rather than an optimisation there:
    /// a piece is cut to fit its own connections and is written one chunk's share at a time, so asking
    /// a fence at the border what it joins answers against a half of the piece that does not exist yet.
    /// </remarks>
    public bool KnownShape { get; set; }

    /// <summary>
    /// Which of a multi palette template's palettes to use, and the source of the choice.
    /// </summary>
    /// <remarks>
    /// Null falls back to a random seeded from the position being placed at, which is
    /// <c>StructurePlaceSettings.getRandom</c>'s own fallback and is what makes a template with several
    /// palettes pick the same one every time a chunk is regenerated.
    /// </remarks>
    public RandomSource? Random { get; set; }

    public IReadOnlyList<IStructureProcessor> Processors => _processors;

    public StructurePlaceSettings AddProcessor(IStructureProcessor processor) {
        _processors.Add(processor);
        return this;
    }

    public StructurePlaceSettings AddProcessors(IEnumerable<IStructureProcessor> processors) {
        _processors.AddRange(processors);
        return this;
    }

    public StructurePlaceSettings ClearProcessors() {
        _processors.Clear();
        return this;
    }

    public StructurePlaceSettings PopProcessor(IStructureProcessor processor) {
        _processors.Remove(processor);
        return this;
    }

    public StructurePlaceSettings Copy() {
        StructurePlaceSettings copy = new() {
            Mirror = Mirror,
            Rotation = Rotation,
            RotationPivot = RotationPivot,
            BoundingBox = BoundingBox,
            ApplyWaterlogging = ApplyWaterlogging,
            KnownShape = KnownShape,
            Random = Random
        };

        copy._processors.AddRange(_processors);
        return copy;
    }

    /// <summary>The random for a placement, seeded from the position where none was given.</summary>
    public RandomSource RandomFor(Vec3<int> pos) {
        return Random ?? new LegacyRandomSource(Mth.GetSeed(pos.X, pos.Y, pos.Z));
    }

    /// <summary>Which palette this placement uses, drawn where the template has more than one.</summary>
    public TemplatePalette RandomPalette(IReadOnlyList<TemplatePalette> palettes, Vec3<int> pos) {
        if (palettes.Count == 0) {
            throw new InvalidOperationException("A template was placed with no palettes.");
        }

        return palettes[RandomFor(pos).NextInt(palettes.Count)];
    }
}
