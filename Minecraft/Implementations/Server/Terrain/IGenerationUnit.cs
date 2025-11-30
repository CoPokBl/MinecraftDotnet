using Minecraft.Schemas.Vec;

namespace Minecraft.Implementations.Server.Terrain;

/// <summary>
/// Represents a unit of terrain generation.
/// A GenerationUnit typically corresponds to a chunk or a region of chunks.
/// It provides methods to modify blocks within its boundaries and to create
/// forked units that can span across multiple chunk boundaries.
/// </summary>
public interface IGenerationUnit {
    /// <summary>
    /// Gets the absolute start position (minimum corner) of this generation unit.
    /// </summary>
    /// <returns>The absolute start position.</returns>
    Vec3<int> AbsoluteStart();

    /// <summary>
    /// Gets the absolute end position (maximum corner, exclusive) of this generation unit.
    /// </summary>
    /// <returns>The absolute end position.</returns>
    Vec3<int> AbsoluteEnd();

    /// <summary>
    /// Gets the modifier for this generation unit.
    /// Use this to place blocks within the unit's boundaries.
    /// </summary>
    /// <returns>The generation modifier for this unit.</returns>
    IGenerationModifier Modifier();

    /// <summary>
    /// Creates a forked generation unit that can span beyond the boundaries of this unit.
    /// Forked units are useful for placing structures that cross chunk boundaries.
    /// The modifications made to a forked unit will be applied when all relevant chunks are loaded.
    /// </summary>
    /// <param name="start">The absolute start position of the fork.</param>
    /// <param name="end">The absolute end position of the fork (exclusive).</param>
    /// <returns>A new generation unit representing the forked area.</returns>
    IGenerationUnit Fork(Vec3<int> start, Vec3<int> end);
}
