using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record WarpedWallHangingSignBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 5786,
                    false => 5787,
                },
                Direction.South => Waterlogged switch {
                    true => 5788,
                    false => 5789,
                },
                Direction.West => Waterlogged switch {
                    true => 5790,
                    false => 5791,
                },
                Direction.East => Waterlogged switch {
                    true => 5792,
                    false => 5793,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            5786 => new WarpedWallHangingSignBlock(Identifier, Direction.North, true),
            5787 => new WarpedWallHangingSignBlock(Identifier, Direction.North, false),
            5788 => new WarpedWallHangingSignBlock(Identifier, Direction.South, true),
            5789 => new WarpedWallHangingSignBlock(Identifier, Direction.South, false),
            5790 => new WarpedWallHangingSignBlock(Identifier, Direction.West, true),
            5791 => new WarpedWallHangingSignBlock(Identifier, Direction.West, false),
            5792 => new WarpedWallHangingSignBlock(Identifier, Direction.East, true),
            5793 => new WarpedWallHangingSignBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
