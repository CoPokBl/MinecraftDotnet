using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record OrangeGlazedTerracottaBlock(Identifier Identifier, Direction Facing) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => 13691,
                Direction.South => 13692,
                Direction.West => 13693,
                Direction.East => 13694,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            13691 => new OrangeGlazedTerracottaBlock(Identifier, Direction.North),
            13692 => new OrangeGlazedTerracottaBlock(Identifier, Direction.South),
            13693 => new OrangeGlazedTerracottaBlock(Identifier, Direction.West),
            13694 => new OrangeGlazedTerracottaBlock(Identifier, Direction.East),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
