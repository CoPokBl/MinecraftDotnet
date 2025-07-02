using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record DeadTubeCoralWallFanBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 13876,
                    false => 13877,
                },
                Direction.South => Waterlogged switch {
                    true => 13878,
                    false => 13879,
                },
                Direction.West => Waterlogged switch {
                    true => 13880,
                    false => 13881,
                },
                Direction.East => Waterlogged switch {
                    true => 13882,
                    false => 13883,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            13876 => new DeadTubeCoralWallFanBlock(Identifier, Direction.North, true),
            13877 => new DeadTubeCoralWallFanBlock(Identifier, Direction.North, false),
            13878 => new DeadTubeCoralWallFanBlock(Identifier, Direction.South, true),
            13879 => new DeadTubeCoralWallFanBlock(Identifier, Direction.South, false),
            13880 => new DeadTubeCoralWallFanBlock(Identifier, Direction.West, true),
            13881 => new DeadTubeCoralWallFanBlock(Identifier, Direction.West, false),
            13882 => new DeadTubeCoralWallFanBlock(Identifier, Direction.East, true),
            13883 => new DeadTubeCoralWallFanBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
