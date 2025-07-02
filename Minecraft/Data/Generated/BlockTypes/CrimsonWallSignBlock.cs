using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record CrimsonWallSignBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 20363,
                    false => 20364,
                },
                Direction.South => Waterlogged switch {
                    true => 20365,
                    false => 20366,
                },
                Direction.West => Waterlogged switch {
                    true => 20367,
                    false => 20368,
                },
                Direction.East => Waterlogged switch {
                    true => 20369,
                    false => 20370,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            20363 => new CrimsonWallSignBlock(Identifier, Direction.North, true),
            20364 => new CrimsonWallSignBlock(Identifier, Direction.North, false),
            20365 => new CrimsonWallSignBlock(Identifier, Direction.South, true),
            20366 => new CrimsonWallSignBlock(Identifier, Direction.South, false),
            20367 => new CrimsonWallSignBlock(Identifier, Direction.West, true),
            20368 => new CrimsonWallSignBlock(Identifier, Direction.West, false),
            20369 => new CrimsonWallSignBlock(Identifier, Direction.East, true),
            20370 => new CrimsonWallSignBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
