using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record LanternBlock(Identifier Identifier, bool Hanging, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Hanging switch {
                true => Waterlogged switch {
                    true => 19526,
                    false => 19527,
                },
                false => Waterlogged switch {
                    true => 19528,
                    false => 19529,
                },
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            19526 => new LanternBlock(Identifier, true, true),
            19527 => new LanternBlock(Identifier, true, false),
            19528 => new LanternBlock(Identifier, false, true),
            19529 => new LanternBlock(Identifier, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
