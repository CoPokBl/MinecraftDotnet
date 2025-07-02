using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record BlueGlazedTerracottaBlock(Identifier Identifier, Direction Facing) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => 13731,
                Direction.South => 13732,
                Direction.West => 13733,
                Direction.East => 13734,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            13731 => new BlueGlazedTerracottaBlock(Identifier, Direction.North),
            13732 => new BlueGlazedTerracottaBlock(Identifier, Direction.South),
            13733 => new BlueGlazedTerracottaBlock(Identifier, Direction.West),
            13734 => new BlueGlazedTerracottaBlock(Identifier, Direction.East),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
