using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record BirchWallHangingSignBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 5722,
                    false => 5723,
                },
                Direction.South => Waterlogged switch {
                    true => 5724,
                    false => 5725,
                },
                Direction.West => Waterlogged switch {
                    true => 5726,
                    false => 5727,
                },
                Direction.East => Waterlogged switch {
                    true => 5728,
                    false => 5729,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            5722 => new BirchWallHangingSignBlock(Identifier, Direction.North, true),
            5723 => new BirchWallHangingSignBlock(Identifier, Direction.North, false),
            5724 => new BirchWallHangingSignBlock(Identifier, Direction.South, true),
            5725 => new BirchWallHangingSignBlock(Identifier, Direction.South, false),
            5726 => new BirchWallHangingSignBlock(Identifier, Direction.West, true),
            5727 => new BirchWallHangingSignBlock(Identifier, Direction.West, false),
            5728 => new BirchWallHangingSignBlock(Identifier, Direction.East, true),
            5729 => new BirchWallHangingSignBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
