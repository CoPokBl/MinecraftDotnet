using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record WarpedWallSignBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 20371,
                    false => 20372,
                },
                Direction.South => Waterlogged switch {
                    true => 20373,
                    false => 20374,
                },
                Direction.West => Waterlogged switch {
                    true => 20375,
                    false => 20376,
                },
                Direction.East => Waterlogged switch {
                    true => 20377,
                    false => 20378,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            20371 => new WarpedWallSignBlock(Identifier, Direction.North, true),
            20372 => new WarpedWallSignBlock(Identifier, Direction.North, false),
            20373 => new WarpedWallSignBlock(Identifier, Direction.South, true),
            20374 => new WarpedWallSignBlock(Identifier, Direction.South, false),
            20375 => new WarpedWallSignBlock(Identifier, Direction.West, true),
            20376 => new WarpedWallSignBlock(Identifier, Direction.West, false),
            20377 => new WarpedWallSignBlock(Identifier, Direction.East, true),
            20378 => new WarpedWallSignBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
