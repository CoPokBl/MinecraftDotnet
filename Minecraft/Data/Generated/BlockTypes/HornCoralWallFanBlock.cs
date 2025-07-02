using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record HornCoralWallFanBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 13948,
                    false => 13949,
                },
                Direction.South => Waterlogged switch {
                    true => 13950,
                    false => 13951,
                },
                Direction.West => Waterlogged switch {
                    true => 13952,
                    false => 13953,
                },
                Direction.East => Waterlogged switch {
                    true => 13954,
                    false => 13955,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            13948 => new HornCoralWallFanBlock(Identifier, Direction.North, true),
            13949 => new HornCoralWallFanBlock(Identifier, Direction.North, false),
            13950 => new HornCoralWallFanBlock(Identifier, Direction.South, true),
            13951 => new HornCoralWallFanBlock(Identifier, Direction.South, false),
            13952 => new HornCoralWallFanBlock(Identifier, Direction.West, true),
            13953 => new HornCoralWallFanBlock(Identifier, Direction.West, false),
            13954 => new HornCoralWallFanBlock(Identifier, Direction.East, true),
            13955 => new HornCoralWallFanBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
