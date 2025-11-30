using Minecraft.Data.Blocks;
using Minecraft.Schemas.Vec;

namespace Minecraft.Implementations.Server.Terrain;

/// <summary>
/// Interface for modifying blocks during terrain generation.
/// Provides methods to set blocks, fill areas, and perform other block modifications.
/// </summary>
public interface IGenerationModifier {
    /// <summary>
    /// Sets a single block at the specified position.
    /// </summary>
    /// <param name="position">The absolute position of the block.</param>
    /// <param name="block">The block to set.</param>
    void SetBlock(Vec3<int> position, IBlock block);

    /// <summary>
    /// Fills a rectangular area with the specified block.
    /// </summary>
    /// <param name="start">The starting corner of the area (inclusive).</param>
    /// <param name="end">The ending corner of the area (exclusive).</param>
    /// <param name="block">The block to fill with.</param>
    void Fill(Vec3<int> start, Vec3<int> end, IBlock block);

    /// <summary>
    /// Fills blocks at the specified Y-height range with the given block.
    /// This fills all X/Z coordinates within the generation unit's bounds.
    /// </summary>
    /// <param name="minY">The minimum Y coordinate (inclusive).</param>
    /// <param name="maxY">The maximum Y coordinate (exclusive).</param>
    /// <param name="block">The block to fill with.</param>
    void FillHeight(int minY, int maxY, IBlock block);
}
