using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record AcaciaWallSignBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 4882,
                    false => 4883,
                },
                Direction.South => Waterlogged switch {
                    true => 4884,
                    false => 4885,
                },
                Direction.West => Waterlogged switch {
                    true => 4886,
                    false => 4887,
                },
                Direction.East => Waterlogged switch {
                    true => 4888,
                    false => 4889,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            4882 => new AcaciaWallSignBlock(Identifier, Direction.North, true),
            4883 => new AcaciaWallSignBlock(Identifier, Direction.North, false),
            4884 => new AcaciaWallSignBlock(Identifier, Direction.South, true),
            4885 => new AcaciaWallSignBlock(Identifier, Direction.South, false),
            4886 => new AcaciaWallSignBlock(Identifier, Direction.West, true),
            4887 => new AcaciaWallSignBlock(Identifier, Direction.West, false),
            4888 => new AcaciaWallSignBlock(Identifier, Direction.East, true),
            4889 => new AcaciaWallSignBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
