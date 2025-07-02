using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record StrippedDarkOakWoodBlock(Identifier Identifier, Axis Axis) : IBlock {

    public uint StateId {
        get {
            return Axis switch {
                Axis.X => 243,
                Axis.Y => 244,
                Axis.Z => 245,
                _ => throw new ArgumentOutOfRangeException(nameof(Axis), Axis, "Unknown value for property axis.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            243 => new StrippedDarkOakWoodBlock(Identifier, Axis.X),
            244 => new StrippedDarkOakWoodBlock(Identifier, Axis.Y),
            245 => new StrippedDarkOakWoodBlock(Identifier, Axis.Z),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
