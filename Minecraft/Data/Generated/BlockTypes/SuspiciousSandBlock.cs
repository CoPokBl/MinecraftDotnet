using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SuspiciousSandBlock(Identifier Identifier, int Dusted) : IBlock {

    public uint StateId {
        get {
            return Dusted switch {
                0 => 119,
                1 => 120,
                2 => 121,
                3 => 122,
                _ => throw new ArgumentOutOfRangeException(nameof(Dusted), Dusted, "Unknown value for property dusted.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            119 => new SuspiciousSandBlock(Identifier, 0),
            120 => new SuspiciousSandBlock(Identifier, 1),
            121 => new SuspiciousSandBlock(Identifier, 2),
            122 => new SuspiciousSandBlock(Identifier, 3),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Dusted = int.Parse(properties["dusted"].GetString()),
        };
    }
    
}
