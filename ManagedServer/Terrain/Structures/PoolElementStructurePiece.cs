using ManagedServer.Terrain.Features;
using ManagedServer.Terrain.Structures.Templates;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Structures;

/// <summary>
/// <c>JigsawJunction</c>: where two jigsaw pieces meet, which the beardifier reads.
/// </summary>
/// <remarks>
/// A junction exists on <b>both</b> pieces, each recording the other's jigsaw position and the height
/// difference from its own side, so the terrain adjustment sees the join from whichever piece the
/// chunk holds.
/// </remarks>
public readonly record struct JigsawJunction(int SourceX, int SourceGroundY, int SourceZ, int DeltaY,
    PoolProjection DestProjection);

/// <summary>
/// <c>PoolElementStructurePiece</c>: one piece of a jigsaw structure.
/// </summary>
/// <remarks>
/// Unlike a <see cref="TemplateStructurePiece"/> this does not hold a template: what it holds is a
/// <see cref="IStructurePoolElement"/>, which may be a template, several of them, or a feature. The
/// element is what knows how to place itself.
/// </remarks>
public sealed class PoolElementStructurePiece : StructurePiece {
    private readonly StructureTemplateManager _templates;
    private readonly List<JigsawJunction> _junctions = [];

    public PoolElementStructurePiece(StructureTemplateManager templates,
        IStructurePoolElement element, Vec3<int> position, int groundLevelDelta,
        BlockRotation rotation, BoundingBox boundingBox, bool applyWaterlogging)
        : base(0, boundingBox) {

        _templates = templates;
        Element = element;
        Position = position;
        GroundLevelDelta = groundLevelDelta;
        Rotation = rotation;
        ApplyWaterlogging = applyWaterlogging;
    }

    public IStructurePoolElement Element { get; }

    /// <summary>Where the element's own origin sits in the world.</summary>
    public Vec3<int> Position { get; private set; }

    /// <summary>How far this piece's ground sits above the bottom of its box.</summary>
    public int GroundLevelDelta { get; }

    public BlockRotation Rotation { get; }

    public bool ApplyWaterlogging { get; }

    public IReadOnlyList<JigsawJunction> Junctions => _junctions;

    public void AddJunction(JigsawJunction junction) {
        _junctions.Add(junction);
    }

    public override void Move(int dx, int dy, int dz) {
        base.Move(dx, dy, dz);
        Position = new Vec3<int>(Position.X + dx, Position.Y + dy, Position.Z + dz);
    }

    /// <summary>Places the piece without a feature context, so a feature element does nothing.</summary>
    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        PostProcess(level, null, random, chunkBox, chunkX, chunkZ, referencePos);
    }

    /// <param name="features">The context a feature pool element runs its feature in.</param>
    public void PostProcess(IFeatureLevel level, PlacementContext? features, RandomSource random,
        BoundingBox chunkBox, int chunkX, int chunkZ, Vec3<int> referencePos) {

        Element.Place(_templates, level, Position, referencePos, Rotation, chunkBox, random,
            ApplyWaterlogging, features);
    }
}
