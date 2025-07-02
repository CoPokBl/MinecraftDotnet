using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record StructureBlockBlock(Identifier Identifier, StructureBlockBlock.Mode ModeValue) : IBlock {

    public uint StateId {
        get {
            return ModeValue switch {
                Mode.Save => 20379,
                Mode.Load => 20380,
                Mode.Corner => 20381,
                Mode.Data => 20382,
                _ => throw new ArgumentOutOfRangeException(nameof(ModeValue), ModeValue, "Unknown value for property mode.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            20379 => new StructureBlockBlock(Identifier, Mode.Save),
            20380 => new StructureBlockBlock(Identifier, Mode.Load),
            20381 => new StructureBlockBlock(Identifier, Mode.Corner),
            20382 => new StructureBlockBlock(Identifier, Mode.Data),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public enum Mode {
        Save,
        Load,
        Corner,
        Data,
    }
}
