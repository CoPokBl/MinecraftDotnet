using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Structures.Templates;

/// <summary>
/// <c>StructureTemplatePool.Projection</c>: whether a piece keeps the height it was joined at or is
/// dropped onto the terrain.
/// </summary>
/// <remarks>
/// The difference is one processor. <see cref="TerrainMatching"/> carries a gravity processor at an
/// offset of minus one, which is what makes a village path follow a hillside while the houses it joins
/// stay level.
/// </remarks>
public enum PoolProjection {
    TerrainMatching,
    Rigid
}

public static class PoolProjections {
    private static readonly IStructureProcessor[] Matching =
        [new GravityProcessor(HeightmapType.WorldSurfaceWorldgen, -1)];

    private static readonly IStructureProcessor[] None = [];

    public static IReadOnlyList<IStructureProcessor> ProcessorsFor(PoolProjection projection) {
        return projection == PoolProjection.TerrainMatching ? Matching : None;
    }
}

/// <summary>
/// <c>StructureTemplatePool</c>: the pieces a jigsaw connection may be filled with, and what to fall
/// back to when none of them fits.
/// </summary>
/// <remarks>
/// The weights are expanded into a <b>flat list with repeats</b> rather than being drawn from as a
/// distribution, because the placer shuffles the whole list and walks it in order: an element of
/// weight fifty appears fifty times and so is fifty times as likely to come up early.
/// <p/>
/// The fallback is held as an id and resolved on use, since a pool's fallback chain reaches
/// <c>minecraft:empty</c>, whose fallback is itself.
/// </remarks>
public sealed class StructureTemplatePool {
    private readonly IStructurePoolElement[] _templates;
    private readonly (IStructurePoolElement Element, int Weight)[] _raw;
    private int _maxSize = int.MinValue;

    public StructureTemplatePool(Identifier fallbackId,
        IReadOnlyList<(IStructurePoolElement Element, int Weight)> templates) {

        FallbackId = fallbackId;
        _raw = [..templates];

        List<IStructurePoolElement> expanded = [];

        foreach ((IStructurePoolElement element, int weight) in templates) {
            for (int i = 0; i < weight; i++) {
                expanded.Add(element);
            }
        }

        _templates = expanded.ToArray();
    }

    public Identifier FallbackId { get; }

    public int Size => _templates.Length;

    public IReadOnlyList<(IStructurePoolElement Element, int Weight)> Templates => _raw;

    public IStructurePoolElement RandomTemplate(RandomSource random) {
        return _templates.Length == 0
            ? EmptyPoolElement.Instance
            : _templates[random.NextInt(_templates.Length)];
    }

    public List<IStructurePoolElement> ShuffledTemplates(RandomSource random) {
        List<IStructurePoolElement> copy = [.._templates];
        StructurePiece.Shuffle(copy, random);
        return copy;
    }

    /// <summary>
    /// The tallest piece in the pool, which the expansion hack uses to guess how much room a
    /// connection will need.
    /// </summary>
    /// <remarks>
    /// Memoised because the hack asks it per candidate jigsaw of a piece and it walks every element.
    /// The empty element is excluded rather than measured, since asking it for a box throws.
    /// </remarks>
    public int MaxSize(StructureTemplateManager templates) {
        if (_maxSize != int.MinValue) {
            return _maxSize;
        }

        int max = 0;

        foreach (IStructurePoolElement element in _templates) {
            if (ReferenceEquals(element, EmptyPoolElement.Instance)) {
                continue;
            }

            max = Math.Max(max, element.GetBoundingBox(templates, new Vec3<int>(0, 0, 0),
                BlockRotation.None).YSpan);
        }

        _maxSize = max;
        return max;
    }
}
