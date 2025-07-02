using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record ZombieWallHeadBlock(Identifier Identifier, Direction Facing, bool Powered) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Powered switch {
                    true => 9748,
                    false => 9749,
                },
                Direction.South => Powered switch {
                    true => 9750,
                    false => 9751,
                },
                Direction.West => Powered switch {
                    true => 9752,
                    false => 9753,
                },
                Direction.East => Powered switch {
                    true => 9754,
                    false => 9755,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            9748 => new ZombieWallHeadBlock(Identifier, Direction.North, true),
            9749 => new ZombieWallHeadBlock(Identifier, Direction.North, false),
            9750 => new ZombieWallHeadBlock(Identifier, Direction.South, true),
            9751 => new ZombieWallHeadBlock(Identifier, Direction.South, false),
            9752 => new ZombieWallHeadBlock(Identifier, Direction.West, true),
            9753 => new ZombieWallHeadBlock(Identifier, Direction.West, false),
            9754 => new ZombieWallHeadBlock(Identifier, Direction.East, true),
            9755 => new ZombieWallHeadBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
