using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
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
    
    public IBlock WithState(uint state) {
        return state switch {
            20379 => new StructureBlockBlock(Identifier, Mode.Save),
            20380 => new StructureBlockBlock(Identifier, Mode.Load),
            20381 => new StructureBlockBlock(Identifier, Mode.Corner),
            20382 => new StructureBlockBlock(Identifier, Mode.Data),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            ModeValue = ModeFromString(properties["mode"].GetString()),
        };
    }
    
    public enum Mode {
        Save,
        Load,
        Corner,
        Data,
    }

    public static Mode ModeFromString(string value) {
        return value switch {
            "save" => Mode.Save,
            "load" => Mode.Load,
            "corner" => Mode.Corner,
            "data" => Mode.Data,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Mode.")
        };
    }
}
