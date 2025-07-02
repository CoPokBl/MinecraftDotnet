using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record GreenGlazedTerracottaBlock(Identifier Identifier, Direction Facing) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => 13739,
                Direction.South => 13740,
                Direction.West => 13741,
                Direction.East => 13742,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            13739 => new GreenGlazedTerracottaBlock(Identifier, Direction.North),
            13740 => new GreenGlazedTerracottaBlock(Identifier, Direction.South),
            13741 => new GreenGlazedTerracottaBlock(Identifier, Direction.West),
            13742 => new GreenGlazedTerracottaBlock(Identifier, Direction.East),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
