using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record DeadHornCoralWallFanBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 13908,
                    false => 13909,
                },
                Direction.South => Waterlogged switch {
                    true => 13910,
                    false => 13911,
                },
                Direction.West => Waterlogged switch {
                    true => 13912,
                    false => 13913,
                },
                Direction.East => Waterlogged switch {
                    true => 13914,
                    false => 13915,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            13908 => new DeadHornCoralWallFanBlock(Identifier, Direction.North, true),
            13909 => new DeadHornCoralWallFanBlock(Identifier, Direction.North, false),
            13910 => new DeadHornCoralWallFanBlock(Identifier, Direction.South, true),
            13911 => new DeadHornCoralWallFanBlock(Identifier, Direction.South, false),
            13912 => new DeadHornCoralWallFanBlock(Identifier, Direction.West, true),
            13913 => new DeadHornCoralWallFanBlock(Identifier, Direction.West, false),
            13914 => new DeadHornCoralWallFanBlock(Identifier, Direction.East, true),
            13915 => new DeadHornCoralWallFanBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
