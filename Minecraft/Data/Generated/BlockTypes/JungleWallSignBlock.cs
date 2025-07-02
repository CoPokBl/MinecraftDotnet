using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record JungleWallSignBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 4898,
                    false => 4899,
                },
                Direction.South => Waterlogged switch {
                    true => 4900,
                    false => 4901,
                },
                Direction.West => Waterlogged switch {
                    true => 4902,
                    false => 4903,
                },
                Direction.East => Waterlogged switch {
                    true => 4904,
                    false => 4905,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            4898 => new JungleWallSignBlock(Identifier, Direction.North, true),
            4899 => new JungleWallSignBlock(Identifier, Direction.North, false),
            4900 => new JungleWallSignBlock(Identifier, Direction.South, true),
            4901 => new JungleWallSignBlock(Identifier, Direction.South, false),
            4902 => new JungleWallSignBlock(Identifier, Direction.West, true),
            4903 => new JungleWallSignBlock(Identifier, Direction.West, false),
            4904 => new JungleWallSignBlock(Identifier, Direction.East, true),
            4905 => new JungleWallSignBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
