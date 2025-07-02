using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record StickyPistonBlock(Identifier Identifier, bool Extended, Cardinal Facing) : IBlock {

    public uint StateId {
        get {
            return Extended switch {
                true => Facing switch {
                    Cardinal.North => 2035,
                    Cardinal.East => 2036,
                    Cardinal.South => 2037,
                    Cardinal.West => 2038,
                    Cardinal.Up => 2039,
                    Cardinal.Down => 2040,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                false => Facing switch {
                    Cardinal.North => 2041,
                    Cardinal.East => 2042,
                    Cardinal.South => 2043,
                    Cardinal.West => 2044,
                    Cardinal.Up => 2045,
                    Cardinal.Down => 2046,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            2035 => new StickyPistonBlock(Identifier, true, Cardinal.North),
            2036 => new StickyPistonBlock(Identifier, true, Cardinal.East),
            2037 => new StickyPistonBlock(Identifier, true, Cardinal.South),
            2038 => new StickyPistonBlock(Identifier, true, Cardinal.West),
            2039 => new StickyPistonBlock(Identifier, true, Cardinal.Up),
            2040 => new StickyPistonBlock(Identifier, true, Cardinal.Down),
            2041 => new StickyPistonBlock(Identifier, false, Cardinal.North),
            2042 => new StickyPistonBlock(Identifier, false, Cardinal.East),
            2043 => new StickyPistonBlock(Identifier, false, Cardinal.South),
            2044 => new StickyPistonBlock(Identifier, false, Cardinal.West),
            2045 => new StickyPistonBlock(Identifier, false, Cardinal.Up),
            2046 => new StickyPistonBlock(Identifier, false, Cardinal.Down),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
