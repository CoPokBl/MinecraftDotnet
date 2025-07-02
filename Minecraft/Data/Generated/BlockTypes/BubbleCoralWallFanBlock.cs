using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record BubbleCoralWallFanBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 13932,
                    false => 13933,
                },
                Direction.South => Waterlogged switch {
                    true => 13934,
                    false => 13935,
                },
                Direction.West => Waterlogged switch {
                    true => 13936,
                    false => 13937,
                },
                Direction.East => Waterlogged switch {
                    true => 13938,
                    false => 13939,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            13932 => new BubbleCoralWallFanBlock(Identifier, Direction.North, true),
            13933 => new BubbleCoralWallFanBlock(Identifier, Direction.North, false),
            13934 => new BubbleCoralWallFanBlock(Identifier, Direction.South, true),
            13935 => new BubbleCoralWallFanBlock(Identifier, Direction.South, false),
            13936 => new BubbleCoralWallFanBlock(Identifier, Direction.West, true),
            13937 => new BubbleCoralWallFanBlock(Identifier, Direction.West, false),
            13938 => new BubbleCoralWallFanBlock(Identifier, Direction.East, true),
            13939 => new BubbleCoralWallFanBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
