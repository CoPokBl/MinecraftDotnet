using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record BrainCoralWallFanBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 13924,
                    false => 13925,
                },
                Direction.South => Waterlogged switch {
                    true => 13926,
                    false => 13927,
                },
                Direction.West => Waterlogged switch {
                    true => 13928,
                    false => 13929,
                },
                Direction.East => Waterlogged switch {
                    true => 13930,
                    false => 13931,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            13924 => new BrainCoralWallFanBlock(Identifier, Direction.North, true),
            13925 => new BrainCoralWallFanBlock(Identifier, Direction.North, false),
            13926 => new BrainCoralWallFanBlock(Identifier, Direction.South, true),
            13927 => new BrainCoralWallFanBlock(Identifier, Direction.South, false),
            13928 => new BrainCoralWallFanBlock(Identifier, Direction.West, true),
            13929 => new BrainCoralWallFanBlock(Identifier, Direction.West, false),
            13930 => new BrainCoralWallFanBlock(Identifier, Direction.East, true),
            13931 => new BrainCoralWallFanBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
