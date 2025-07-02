using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record DropperBlock(Identifier Identifier, Cardinal Facing, bool Triggered) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => Triggered switch {
                    true => 10153,
                    false => 10154,
                },
                Cardinal.East => Triggered switch {
                    true => 10155,
                    false => 10156,
                },
                Cardinal.South => Triggered switch {
                    true => 10157,
                    false => 10158,
                },
                Cardinal.West => Triggered switch {
                    true => 10159,
                    false => 10160,
                },
                Cardinal.Up => Triggered switch {
                    true => 10161,
                    false => 10162,
                },
                Cardinal.Down => Triggered switch {
                    true => 10163,
                    false => 10164,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            10153 => new DropperBlock(Identifier, Cardinal.North, true),
            10154 => new DropperBlock(Identifier, Cardinal.North, false),
            10155 => new DropperBlock(Identifier, Cardinal.East, true),
            10156 => new DropperBlock(Identifier, Cardinal.East, false),
            10157 => new DropperBlock(Identifier, Cardinal.South, true),
            10158 => new DropperBlock(Identifier, Cardinal.South, false),
            10159 => new DropperBlock(Identifier, Cardinal.West, true),
            10160 => new DropperBlock(Identifier, Cardinal.West, false),
            10161 => new DropperBlock(Identifier, Cardinal.Up, true),
            10162 => new DropperBlock(Identifier, Cardinal.Up, false),
            10163 => new DropperBlock(Identifier, Cardinal.Down, true),
            10164 => new DropperBlock(Identifier, Cardinal.Down, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
