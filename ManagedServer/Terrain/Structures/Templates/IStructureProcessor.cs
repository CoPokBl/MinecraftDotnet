using ManagedServer.Terrain.Features;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Structures.Templates;

/// <summary>
/// <c>StructureProcessor</c>: a rule applied to every block of a template on its way into the world.
/// </summary>
/// <remarks>
/// Processors are what turn one saved template into the many things it looks like in play: a ruined
/// portal is one portal frame put through gravity, ageing and rot, and a village house is one house
/// with its planks swapped for the biome's. They run in the order the settings list them, and the
/// <b>first one to answer null drops the block</b>, so a rot processor placed after a replacement sees
/// what the replacement produced.
/// </remarks>
public interface IStructureProcessor {
    /// <summary>
    /// The block as this processor leaves it, or null to drop it.
    /// </summary>
    /// <param name="targetPosition">Where the template's own origin was placed.</param>
    /// <param name="referencePos">
    /// The structure's reference position, which is the middle of its first piece. Only the position
    /// rule tests read it, and they measure a distance from it.
    /// </param>
    /// <param name="templateRelativePos">
    /// Where the block sits inside the template, before any turning. A rule keyed on a block's place
    /// in its own piece needs this rather than the world position beside it.
    /// </param>
    TemplateBlockInfo? ProcessBlock(IFeatureLevel level, Vec3<int> targetPosition,
        Vec3<int> referencePos, Vec3<int> templateRelativePos, TemplateBlockInfo block,
        StructurePlaceSettings settings) => block;

    /// <summary>
    /// Runs once the whole piece has been through <see cref="ProcessBlock"/>, which is what a
    /// processor counting its own replacements needs.
    /// </summary>
    /// <remarks>
    /// The two lists are the same length and in the same order: entry n of the processed list is what
    /// entry n of the original became. <c>capped</c> depends on that pairing to find the template
    /// position of a block it is about to alter.
    /// </remarks>
    List<TemplateBlockInfo> FinalizeProcessing(IFeatureLevel level, Vec3<int> position,
        Vec3<int> referencePos, IReadOnlyList<TemplateBlockInfo> original,
        List<TemplateBlockInfo> processed, StructurePlaceSettings settings) => processed;

    /// <summary>
    /// Whether this processor has to see the blocks that fall outside the chunk being written.
    /// </summary>
    /// <remarks>
    /// True turns off the filter that would otherwise skip them, because a processor choosing n blocks
    /// out of a piece cannot choose consistently from a different subset in each chunk the piece spans.
    /// <c>capped</c> is the only one, and its cost is that every block of the piece is processed once
    /// per chunk the piece touches.
    /// </remarks>
    bool EvaluatesEntirePieceState => false;
}
