using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CarrotsBlock(Identifier Identifier, int Age) : IBlock {

    public uint StateId {
        get {
            return Age switch {
                0 => 9380,
                1 => 9381,
                2 => 9382,
                3 => 9383,
                4 => 9384,
                5 => 9385,
                6 => 9386,
                7 => 9387,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9380 => new CarrotsBlock(Identifier, 0),
            9381 => new CarrotsBlock(Identifier, 1),
            9382 => new CarrotsBlock(Identifier, 2),
            9383 => new CarrotsBlock(Identifier, 3),
            9384 => new CarrotsBlock(Identifier, 4),
            9385 => new CarrotsBlock(Identifier, 5),
            9386 => new CarrotsBlock(Identifier, 6),
            9387 => new CarrotsBlock(Identifier, 7),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Age = int.Parse(properties["age"].GetString()),
        };
    }
    
}
