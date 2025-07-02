using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record JungleWallHangingSignBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 5746,
                    false => 5747,
                },
                Direction.South => Waterlogged switch {
                    true => 5748,
                    false => 5749,
                },
                Direction.West => Waterlogged switch {
                    true => 5750,
                    false => 5751,
                },
                Direction.East => Waterlogged switch {
                    true => 5752,
                    false => 5753,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            5746 => new JungleWallHangingSignBlock(Identifier, Direction.North, true),
            5747 => new JungleWallHangingSignBlock(Identifier, Direction.North, false),
            5748 => new JungleWallHangingSignBlock(Identifier, Direction.South, true),
            5749 => new JungleWallHangingSignBlock(Identifier, Direction.South, false),
            5750 => new JungleWallHangingSignBlock(Identifier, Direction.West, true),
            5751 => new JungleWallHangingSignBlock(Identifier, Direction.West, false),
            5752 => new JungleWallHangingSignBlock(Identifier, Direction.East, true),
            5753 => new JungleWallHangingSignBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
