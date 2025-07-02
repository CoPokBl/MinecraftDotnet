using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record MovingPistonBlock(Identifier Identifier, MovingPistonBlock.Type TypeValue, Cardinal Facing) : IBlock {

    public uint StateId {
        get {
            return TypeValue switch {
                Type.Normal => Facing switch {
                    Cardinal.North => 2109,
                    Cardinal.East => 2111,
                    Cardinal.South => 2113,
                    Cardinal.West => 2115,
                    Cardinal.Up => 2117,
                    Cardinal.Down => 2119,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Sticky => Facing switch {
                    Cardinal.North => 2110,
                    Cardinal.East => 2112,
                    Cardinal.South => 2114,
                    Cardinal.West => 2116,
                    Cardinal.Up => 2118,
                    Cardinal.Down => 2120,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(TypeValue), TypeValue, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            2109 => new MovingPistonBlock(Identifier, Type.Normal, Cardinal.North),
            2110 => new MovingPistonBlock(Identifier, Type.Sticky, Cardinal.North),
            2111 => new MovingPistonBlock(Identifier, Type.Normal, Cardinal.East),
            2112 => new MovingPistonBlock(Identifier, Type.Sticky, Cardinal.East),
            2113 => new MovingPistonBlock(Identifier, Type.Normal, Cardinal.South),
            2114 => new MovingPistonBlock(Identifier, Type.Sticky, Cardinal.South),
            2115 => new MovingPistonBlock(Identifier, Type.Normal, Cardinal.West),
            2116 => new MovingPistonBlock(Identifier, Type.Sticky, Cardinal.West),
            2117 => new MovingPistonBlock(Identifier, Type.Normal, Cardinal.Up),
            2118 => new MovingPistonBlock(Identifier, Type.Sticky, Cardinal.Up),
            2119 => new MovingPistonBlock(Identifier, Type.Normal, Cardinal.Down),
            2120 => new MovingPistonBlock(Identifier, Type.Sticky, Cardinal.Down),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public enum Type {
        Normal,
        Sticky,
    }
}
