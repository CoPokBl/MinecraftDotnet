using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record CherryWallSignBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 4890,
                    false => 4891,
                },
                Direction.South => Waterlogged switch {
                    true => 4892,
                    false => 4893,
                },
                Direction.West => Waterlogged switch {
                    true => 4894,
                    false => 4895,
                },
                Direction.East => Waterlogged switch {
                    true => 4896,
                    false => 4897,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            4890 => new CherryWallSignBlock(Identifier, Direction.North, true),
            4891 => new CherryWallSignBlock(Identifier, Direction.North, false),
            4892 => new CherryWallSignBlock(Identifier, Direction.South, true),
            4893 => new CherryWallSignBlock(Identifier, Direction.South, false),
            4894 => new CherryWallSignBlock(Identifier, Direction.West, true),
            4895 => new CherryWallSignBlock(Identifier, Direction.West, false),
            4896 => new CherryWallSignBlock(Identifier, Direction.East, true),
            4897 => new CherryWallSignBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
