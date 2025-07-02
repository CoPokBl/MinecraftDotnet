using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record PaleOakWallSignBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 4914,
                    false => 4915,
                },
                Direction.South => Waterlogged switch {
                    true => 4916,
                    false => 4917,
                },
                Direction.West => Waterlogged switch {
                    true => 4918,
                    false => 4919,
                },
                Direction.East => Waterlogged switch {
                    true => 4920,
                    false => 4921,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            4914 => new PaleOakWallSignBlock(Identifier, Direction.North, true),
            4915 => new PaleOakWallSignBlock(Identifier, Direction.North, false),
            4916 => new PaleOakWallSignBlock(Identifier, Direction.South, true),
            4917 => new PaleOakWallSignBlock(Identifier, Direction.South, false),
            4918 => new PaleOakWallSignBlock(Identifier, Direction.West, true),
            4919 => new PaleOakWallSignBlock(Identifier, Direction.West, false),
            4920 => new PaleOakWallSignBlock(Identifier, Direction.East, true),
            4921 => new PaleOakWallSignBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
