using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record RepeatingCommandBlockBlock(Identifier Identifier, bool Conditional, Cardinal Facing) : IBlock {

    public uint StateId {
        get {
            return Conditional switch {
                true => Facing switch {
                    Cardinal.North => 13538,
                    Cardinal.East => 13539,
                    Cardinal.South => 13540,
                    Cardinal.West => 13541,
                    Cardinal.Up => 13542,
                    Cardinal.Down => 13543,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                false => Facing switch {
                    Cardinal.North => 13544,
                    Cardinal.East => 13545,
                    Cardinal.South => 13546,
                    Cardinal.West => 13547,
                    Cardinal.Up => 13548,
                    Cardinal.Down => 13549,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            13538 => new RepeatingCommandBlockBlock(Identifier, true, Cardinal.North),
            13539 => new RepeatingCommandBlockBlock(Identifier, true, Cardinal.East),
            13540 => new RepeatingCommandBlockBlock(Identifier, true, Cardinal.South),
            13541 => new RepeatingCommandBlockBlock(Identifier, true, Cardinal.West),
            13542 => new RepeatingCommandBlockBlock(Identifier, true, Cardinal.Up),
            13543 => new RepeatingCommandBlockBlock(Identifier, true, Cardinal.Down),
            13544 => new RepeatingCommandBlockBlock(Identifier, false, Cardinal.North),
            13545 => new RepeatingCommandBlockBlock(Identifier, false, Cardinal.East),
            13546 => new RepeatingCommandBlockBlock(Identifier, false, Cardinal.South),
            13547 => new RepeatingCommandBlockBlock(Identifier, false, Cardinal.West),
            13548 => new RepeatingCommandBlockBlock(Identifier, false, Cardinal.Up),
            13549 => new RepeatingCommandBlockBlock(Identifier, false, Cardinal.Down),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
