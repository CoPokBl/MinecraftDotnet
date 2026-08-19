using ManagedServer.Terrain.Features;
using ManagedServer.Terrain.Features.Values;
using ManagedServer.Terrain.Structures.Templates;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Structures.Types;

/// <summary>
/// <c>JigsawStructure</c>: everything assembled out of template pools, which is most of what a modern
/// world has in it.
/// </summary>
/// <remarks>
/// Villages, bastions, ancient cities, pillager outposts, trail ruins and trial chambers are all this
/// one type with different pools. What tells them apart is entirely the datapack: a start pool, a
/// depth, where the start is put, and how far from its centre it may reach.
/// <p/>
/// <b>The layout reads only the registry</b>, never a chunk, which is what keeps a start a pure
/// function of the seed and its source chunk: a pool element's jigsaw blocks come off its template
/// through the block table, and the feature a feature element runs is not touched until placement.
/// </remarks>
public sealed class JigsawStructure(Structure.StructureSettings settings,
    StructureTemplateManager templates, TemplatePools pools, HeightProvider startHeight,
    IReadOnlyList<IPoolAliasBinding> poolAliases, JigsawPlacement.Settings placement)
    : Structure(settings) {

    /// <summary>The most a jigsaw structure may span, which the datapack is checked against.</summary>
    public const int MaxTotalStructureRange = 128;

    protected override GenerationStub? FindGenerationPoint(StructureGenerationContext context) {
        int height = startHeight.Sample(context.Random,
            new GenerationHeightContext(context.MinY, context.Height));

        Vec3<int> start = new(context.ChunkX << 4, height, context.ChunkZ << 4);

        JigsawPlacement.Context placer = new(templates, pools, context.Registry, context.Heights,
            context.MinY, context.MaxY);

        return JigsawPlacement.AddPieces(context, placer, placement, start,
            PoolAliasLookup.Create(poolAliases, start, context.Seed));
    }
}
