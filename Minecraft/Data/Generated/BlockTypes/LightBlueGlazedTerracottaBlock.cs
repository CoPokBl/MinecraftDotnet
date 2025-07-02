using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record LightBlueGlazedTerracottaBlock(Identifier Identifier, Direction Facing) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => 13699,
                Direction.South => 13700,
                Direction.West => 13701,
                Direction.East => 13702,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            13699 => new LightBlueGlazedTerracottaBlock(Identifier, Direction.North),
            13700 => new LightBlueGlazedTerracottaBlock(Identifier, Direction.South),
            13701 => new LightBlueGlazedTerracottaBlock(Identifier, Direction.West),
            13702 => new LightBlueGlazedTerracottaBlock(Identifier, Direction.East),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
