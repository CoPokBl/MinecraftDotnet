using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SweetBerryBushBlock(Identifier Identifier, int Age) : IBlock {

    public uint StateId {
        get {
            return Age switch {
                0 => 19598,
                1 => 19599,
                2 => 19600,
                3 => 19601,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            19598 => new SweetBerryBushBlock(Identifier, 0),
            19599 => new SweetBerryBushBlock(Identifier, 1),
            19600 => new SweetBerryBushBlock(Identifier, 2),
            19601 => new SweetBerryBushBlock(Identifier, 3),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Age = int.Parse(properties["age"].GetString()),
        };
    }
    
}
