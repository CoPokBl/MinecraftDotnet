using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record HopperBlock(Identifier Identifier, bool Enabled, HopperBlock.Facing FacingValue) : IBlock {

    public uint StateId {
        get {
            return Enabled switch {
                true => FacingValue switch {
                    Facing.Down => 10034,
                    Facing.North => 10035,
                    Facing.South => 10036,
                    Facing.West => 10037,
                    Facing.East => 10038,
                    _ => throw new ArgumentOutOfRangeException(nameof(FacingValue), FacingValue, "Unknown value for property facing.")
                },
                false => FacingValue switch {
                    Facing.Down => 10039,
                    Facing.North => 10040,
                    Facing.South => 10041,
                    Facing.West => 10042,
                    Facing.East => 10043,
                    _ => throw new ArgumentOutOfRangeException(nameof(FacingValue), FacingValue, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            10034 => new HopperBlock(Identifier, true, Facing.Down),
            10035 => new HopperBlock(Identifier, true, Facing.North),
            10036 => new HopperBlock(Identifier, true, Facing.South),
            10037 => new HopperBlock(Identifier, true, Facing.West),
            10038 => new HopperBlock(Identifier, true, Facing.East),
            10039 => new HopperBlock(Identifier, false, Facing.Down),
            10040 => new HopperBlock(Identifier, false, Facing.North),
            10041 => new HopperBlock(Identifier, false, Facing.South),
            10042 => new HopperBlock(Identifier, false, Facing.West),
            10043 => new HopperBlock(Identifier, false, Facing.East),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public enum Facing {
        Down,
        North,
        South,
        West,
        East,
    }
}
