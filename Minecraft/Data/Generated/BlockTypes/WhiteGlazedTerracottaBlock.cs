using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record WhiteGlazedTerracottaBlock(Identifier Identifier, Direction Facing) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => 13687,
                Direction.South => 13688,
                Direction.West => 13689,
                Direction.East => 13690,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            13687 => new WhiteGlazedTerracottaBlock(Identifier, Direction.North),
            13688 => new WhiteGlazedTerracottaBlock(Identifier, Direction.South),
            13689 => new WhiteGlazedTerracottaBlock(Identifier, Direction.West),
            13690 => new WhiteGlazedTerracottaBlock(Identifier, Direction.East),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
