using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record DispenserBlock(Identifier Identifier, Cardinal Facing, bool Triggered) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => Triggered switch {
                    true => 566,
                    false => 567,
                },
                Cardinal.East => Triggered switch {
                    true => 568,
                    false => 569,
                },
                Cardinal.South => Triggered switch {
                    true => 570,
                    false => 571,
                },
                Cardinal.West => Triggered switch {
                    true => 572,
                    false => 573,
                },
                Cardinal.Up => Triggered switch {
                    true => 574,
                    false => 575,
                },
                Cardinal.Down => Triggered switch {
                    true => 576,
                    false => 577,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            566 => new DispenserBlock(Identifier, Cardinal.North, true),
            567 => new DispenserBlock(Identifier, Cardinal.North, false),
            568 => new DispenserBlock(Identifier, Cardinal.East, true),
            569 => new DispenserBlock(Identifier, Cardinal.East, false),
            570 => new DispenserBlock(Identifier, Cardinal.South, true),
            571 => new DispenserBlock(Identifier, Cardinal.South, false),
            572 => new DispenserBlock(Identifier, Cardinal.West, true),
            573 => new DispenserBlock(Identifier, Cardinal.West, false),
            574 => new DispenserBlock(Identifier, Cardinal.Up, true),
            575 => new DispenserBlock(Identifier, Cardinal.Up, false),
            576 => new DispenserBlock(Identifier, Cardinal.Down, true),
            577 => new DispenserBlock(Identifier, Cardinal.Down, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
