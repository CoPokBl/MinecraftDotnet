using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record SuspiciousGravelBlock(Identifier Identifier, int Dusted) : IBlock {

    public uint StateId {
        get {
            return Dusted switch {
                0 => 125,
                1 => 126,
                2 => 127,
                3 => 128,
                _ => throw new ArgumentOutOfRangeException(nameof(Dusted), Dusted, "Unknown value for property dusted.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            125 => new SuspiciousGravelBlock(Identifier, 0),
            126 => new SuspiciousGravelBlock(Identifier, 1),
            127 => new SuspiciousGravelBlock(Identifier, 2),
            128 => new SuspiciousGravelBlock(Identifier, 3),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
