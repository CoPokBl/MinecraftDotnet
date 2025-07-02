using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record StrippedPaleOakWoodBlock(Identifier Identifier, Axis Axis) : IBlock {

    public uint StateId {
        get {
            return Axis switch {
                Axis.X => 246,
                Axis.Y => 247,
                Axis.Z => 248,
                _ => throw new ArgumentOutOfRangeException(nameof(Axis), Axis, "Unknown value for property axis.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            246 => new StrippedPaleOakWoodBlock(Identifier, Axis.X),
            247 => new StrippedPaleOakWoodBlock(Identifier, Axis.Y),
            248 => new StrippedPaleOakWoodBlock(Identifier, Axis.Z),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
