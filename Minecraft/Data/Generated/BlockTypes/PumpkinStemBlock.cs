using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PumpkinStemBlock(Identifier Identifier, int Age) : IBlock {

    public uint StateId {
        get {
            return Age switch {
                0 => 7064,
                1 => 7065,
                2 => 7066,
                3 => 7067,
                4 => 7068,
                5 => 7069,
                6 => 7070,
                7 => 7071,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7064 => new PumpkinStemBlock(Identifier, 0),
            7065 => new PumpkinStemBlock(Identifier, 1),
            7066 => new PumpkinStemBlock(Identifier, 2),
            7067 => new PumpkinStemBlock(Identifier, 3),
            7068 => new PumpkinStemBlock(Identifier, 4),
            7069 => new PumpkinStemBlock(Identifier, 5),
            7070 => new PumpkinStemBlock(Identifier, 6),
            7071 => new PumpkinStemBlock(Identifier, 7),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Age = int.Parse(properties["age"].GetString()),
        };
    }
    
}
