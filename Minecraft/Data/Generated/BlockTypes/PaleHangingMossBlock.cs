using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record PaleHangingMossBlock(Identifier Identifier, bool Tip) : IBlock {

    public uint StateId {
        get {
            return Tip switch {
                true => 27907,
                false => 27908,
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            27907 => new PaleHangingMossBlock(Identifier, true),
            27908 => new PaleHangingMossBlock(Identifier, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
