using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record PistonBlock(Identifier Identifier, bool Extended, Cardinal Facing) : IBlock {

    public uint StateId {
        get {
            return Extended switch {
                true => Facing switch {
                    Cardinal.North => 2057,
                    Cardinal.East => 2058,
                    Cardinal.South => 2059,
                    Cardinal.West => 2060,
                    Cardinal.Up => 2061,
                    Cardinal.Down => 2062,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                false => Facing switch {
                    Cardinal.North => 2063,
                    Cardinal.East => 2064,
                    Cardinal.South => 2065,
                    Cardinal.West => 2066,
                    Cardinal.Up => 2067,
                    Cardinal.Down => 2068,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            2057 => new PistonBlock(Identifier, true, Cardinal.North),
            2058 => new PistonBlock(Identifier, true, Cardinal.East),
            2059 => new PistonBlock(Identifier, true, Cardinal.South),
            2060 => new PistonBlock(Identifier, true, Cardinal.West),
            2061 => new PistonBlock(Identifier, true, Cardinal.Up),
            2062 => new PistonBlock(Identifier, true, Cardinal.Down),
            2063 => new PistonBlock(Identifier, false, Cardinal.North),
            2064 => new PistonBlock(Identifier, false, Cardinal.East),
            2065 => new PistonBlock(Identifier, false, Cardinal.South),
            2066 => new PistonBlock(Identifier, false, Cardinal.West),
            2067 => new PistonBlock(Identifier, false, Cardinal.Up),
            2068 => new PistonBlock(Identifier, false, Cardinal.Down),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
