using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record BubbleColumnBlock(Identifier Identifier, bool Drag) : IBlock {

    public uint StateId {
        get {
            return Drag switch {
                true => 13983,
                false => 13984,
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            13983 => new BubbleColumnBlock(Identifier, true),
            13984 => new BubbleColumnBlock(Identifier, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
