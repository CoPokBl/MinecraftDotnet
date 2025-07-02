using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record OakWallHangingSignBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 5706,
                    false => 5707,
                },
                Direction.South => Waterlogged switch {
                    true => 5708,
                    false => 5709,
                },
                Direction.West => Waterlogged switch {
                    true => 5710,
                    false => 5711,
                },
                Direction.East => Waterlogged switch {
                    true => 5712,
                    false => 5713,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            5706 => new OakWallHangingSignBlock(Identifier, Direction.North, true),
            5707 => new OakWallHangingSignBlock(Identifier, Direction.North, false),
            5708 => new OakWallHangingSignBlock(Identifier, Direction.South, true),
            5709 => new OakWallHangingSignBlock(Identifier, Direction.South, false),
            5710 => new OakWallHangingSignBlock(Identifier, Direction.West, true),
            5711 => new OakWallHangingSignBlock(Identifier, Direction.West, false),
            5712 => new OakWallHangingSignBlock(Identifier, Direction.East, true),
            5713 => new OakWallHangingSignBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
