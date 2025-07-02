using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record PaleOakWallHangingSignBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 5762,
                    false => 5763,
                },
                Direction.South => Waterlogged switch {
                    true => 5764,
                    false => 5765,
                },
                Direction.West => Waterlogged switch {
                    true => 5766,
                    false => 5767,
                },
                Direction.East => Waterlogged switch {
                    true => 5768,
                    false => 5769,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            5762 => new PaleOakWallHangingSignBlock(Identifier, Direction.North, true),
            5763 => new PaleOakWallHangingSignBlock(Identifier, Direction.North, false),
            5764 => new PaleOakWallHangingSignBlock(Identifier, Direction.South, true),
            5765 => new PaleOakWallHangingSignBlock(Identifier, Direction.South, false),
            5766 => new PaleOakWallHangingSignBlock(Identifier, Direction.West, true),
            5767 => new PaleOakWallHangingSignBlock(Identifier, Direction.West, false),
            5768 => new PaleOakWallHangingSignBlock(Identifier, Direction.East, true),
            5769 => new PaleOakWallHangingSignBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
