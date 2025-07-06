using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MelonStemBlock(Identifier Identifier, int Age) : IBlock {

    public uint StateId {
        get {
            return Age switch {
                0 => 7072,
                1 => 7073,
                2 => 7074,
                3 => 7075,
                4 => 7076,
                5 => 7077,
                6 => 7078,
                7 => 7079,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7072 => new MelonStemBlock(Identifier, 0),
            7073 => new MelonStemBlock(Identifier, 1),
            7074 => new MelonStemBlock(Identifier, 2),
            7075 => new MelonStemBlock(Identifier, 3),
            7076 => new MelonStemBlock(Identifier, 4),
            7077 => new MelonStemBlock(Identifier, 5),
            7078 => new MelonStemBlock(Identifier, 6),
            7079 => new MelonStemBlock(Identifier, 7),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Age = int.Parse(properties["age"].GetString()),
        };
    }
    
}
