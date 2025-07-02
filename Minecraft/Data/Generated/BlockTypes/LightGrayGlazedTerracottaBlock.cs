using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record LightGrayGlazedTerracottaBlock(Identifier Identifier, Direction Facing) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => 13719,
                Direction.South => 13720,
                Direction.West => 13721,
                Direction.East => 13722,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            13719 => new LightGrayGlazedTerracottaBlock(Identifier, Direction.North),
            13720 => new LightGrayGlazedTerracottaBlock(Identifier, Direction.South),
            13721 => new LightGrayGlazedTerracottaBlock(Identifier, Direction.West),
            13722 => new LightGrayGlazedTerracottaBlock(Identifier, Direction.East),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
