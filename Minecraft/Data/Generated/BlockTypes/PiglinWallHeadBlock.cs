using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record PiglinWallHeadBlock(Identifier Identifier, Direction Facing, bool Powered) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Powered switch {
                    true => 9908,
                    false => 9909,
                },
                Direction.South => Powered switch {
                    true => 9910,
                    false => 9911,
                },
                Direction.West => Powered switch {
                    true => 9912,
                    false => 9913,
                },
                Direction.East => Powered switch {
                    true => 9914,
                    false => 9915,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            9908 => new PiglinWallHeadBlock(Identifier, Direction.North, true),
            9909 => new PiglinWallHeadBlock(Identifier, Direction.North, false),
            9910 => new PiglinWallHeadBlock(Identifier, Direction.South, true),
            9911 => new PiglinWallHeadBlock(Identifier, Direction.South, false),
            9912 => new PiglinWallHeadBlock(Identifier, Direction.West, true),
            9913 => new PiglinWallHeadBlock(Identifier, Direction.West, false),
            9914 => new PiglinWallHeadBlock(Identifier, Direction.East, true),
            9915 => new PiglinWallHeadBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
