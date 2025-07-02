using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record PinkGlazedTerracottaBlock(Identifier Identifier, Direction Facing) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => 13711,
                Direction.South => 13712,
                Direction.West => 13713,
                Direction.East => 13714,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            13711 => new PinkGlazedTerracottaBlock(Identifier, Direction.North),
            13712 => new PinkGlazedTerracottaBlock(Identifier, Direction.South),
            13713 => new PinkGlazedTerracottaBlock(Identifier, Direction.West),
            13714 => new PinkGlazedTerracottaBlock(Identifier, Direction.East),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
