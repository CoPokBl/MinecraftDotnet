using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record FarmlandBlock(Identifier Identifier, int Moisture) : IBlock {

    public uint StateId {
        get {
            return Moisture switch {
                0 => 4350,
                1 => 4351,
                2 => 4352,
                3 => 4353,
                4 => 4354,
                5 => 4355,
                6 => 4356,
                7 => 4357,
                _ => throw new ArgumentOutOfRangeException(nameof(Moisture), Moisture, "Unknown value for property moisture.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            4350 => new FarmlandBlock(Identifier, 0),
            4351 => new FarmlandBlock(Identifier, 1),
            4352 => new FarmlandBlock(Identifier, 2),
            4353 => new FarmlandBlock(Identifier, 3),
            4354 => new FarmlandBlock(Identifier, 4),
            4355 => new FarmlandBlock(Identifier, 5),
            4356 => new FarmlandBlock(Identifier, 6),
            4357 => new FarmlandBlock(Identifier, 7),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Moisture = int.Parse(properties["moisture"].GetString()),
        };
    }
    
}
