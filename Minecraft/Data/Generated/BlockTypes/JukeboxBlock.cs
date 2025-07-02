using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record JukeboxBlock(Identifier Identifier, bool HasRecord) : IBlock {

    public uint StateId {
        get {
            return HasRecord switch {
                true => 5994,
                false => 5995,
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            5994 => new JukeboxBlock(Identifier, true),
            5995 => new JukeboxBlock(Identifier, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
