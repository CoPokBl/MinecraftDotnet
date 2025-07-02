using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record PlayerWallHeadBlock(Identifier Identifier, Direction Facing, bool Powered) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Powered switch {
                    true => 9788,
                    false => 9789,
                },
                Direction.South => Powered switch {
                    true => 9790,
                    false => 9791,
                },
                Direction.West => Powered switch {
                    true => 9792,
                    false => 9793,
                },
                Direction.East => Powered switch {
                    true => 9794,
                    false => 9795,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            9788 => new PlayerWallHeadBlock(Identifier, Direction.North, true),
            9789 => new PlayerWallHeadBlock(Identifier, Direction.North, false),
            9790 => new PlayerWallHeadBlock(Identifier, Direction.South, true),
            9791 => new PlayerWallHeadBlock(Identifier, Direction.South, false),
            9792 => new PlayerWallHeadBlock(Identifier, Direction.West, true),
            9793 => new PlayerWallHeadBlock(Identifier, Direction.West, false),
            9794 => new PlayerWallHeadBlock(Identifier, Direction.East, true),
            9795 => new PlayerWallHeadBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
