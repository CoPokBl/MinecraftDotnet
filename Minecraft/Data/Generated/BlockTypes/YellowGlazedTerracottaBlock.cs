using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record YellowGlazedTerracottaBlock(Identifier Identifier, Direction Facing) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => 13703,
                Direction.South => 13704,
                Direction.West => 13705,
                Direction.East => 13706,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            13703 => new YellowGlazedTerracottaBlock(Identifier, Direction.North),
            13704 => new YellowGlazedTerracottaBlock(Identifier, Direction.South),
            13705 => new YellowGlazedTerracottaBlock(Identifier, Direction.West),
            13706 => new YellowGlazedTerracottaBlock(Identifier, Direction.East),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
