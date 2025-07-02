using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record InfestedDeepslateBlock(Identifier Identifier, Axis Axis) : IBlock {

    public uint StateId {
        get {
            return Axis switch {
                Axis.X => 27614,
                Axis.Y => 27615,
                Axis.Z => 27616,
                _ => throw new ArgumentOutOfRangeException(nameof(Axis), Axis, "Unknown value for property axis.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            27614 => new InfestedDeepslateBlock(Identifier, Axis.X),
            27615 => new InfestedDeepslateBlock(Identifier, Axis.Y),
            27616 => new InfestedDeepslateBlock(Identifier, Axis.Z),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
