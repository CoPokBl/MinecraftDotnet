using Minecraft.Data.Blocks;
using Minecraft.Schemas.Vec;

namespace Minecraft.Implementations.Server.Terrain;

/// <summary>
/// Interface for setting blocks during terrain generation.
/// Used with the auto-expanding fork method where the fork bounds
/// are automatically determined based on the blocks set.
/// </summary>
public interface IBlockSetter {
    /// <summary>
    /// Sets a block at the specified position.
    /// </summary>
    /// <param name="position">The absolute position of the block.</param>
    /// <param name="block">The block to set.</param>
    void SetBlock(Vec3<int> position, IBlock block);
}
