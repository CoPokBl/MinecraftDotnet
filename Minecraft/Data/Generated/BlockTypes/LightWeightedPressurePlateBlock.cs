using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LightWeightedPressurePlateBlock(Identifier Identifier, int Power) : IBlock {

    public uint StateId {
        get {
            return Power switch {
                0 => 9952,
                1 => 9953,
                2 => 9954,
                3 => 9955,
                4 => 9956,
                5 => 9957,
                6 => 9958,
                7 => 9959,
                8 => 9960,
                9 => 9961,
                10 => 9962,
                11 => 9963,
                12 => 9964,
                13 => 9965,
                14 => 9966,
                15 => 9967,
                _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9952 => new LightWeightedPressurePlateBlock(Identifier, 0),
            9953 => new LightWeightedPressurePlateBlock(Identifier, 1),
            9954 => new LightWeightedPressurePlateBlock(Identifier, 2),
            9955 => new LightWeightedPressurePlateBlock(Identifier, 3),
            9956 => new LightWeightedPressurePlateBlock(Identifier, 4),
            9957 => new LightWeightedPressurePlateBlock(Identifier, 5),
            9958 => new LightWeightedPressurePlateBlock(Identifier, 6),
            9959 => new LightWeightedPressurePlateBlock(Identifier, 7),
            9960 => new LightWeightedPressurePlateBlock(Identifier, 8),
            9961 => new LightWeightedPressurePlateBlock(Identifier, 9),
            9962 => new LightWeightedPressurePlateBlock(Identifier, 10),
            9963 => new LightWeightedPressurePlateBlock(Identifier, 11),
            9964 => new LightWeightedPressurePlateBlock(Identifier, 12),
            9965 => new LightWeightedPressurePlateBlock(Identifier, 13),
            9966 => new LightWeightedPressurePlateBlock(Identifier, 14),
            9967 => new LightWeightedPressurePlateBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Power = int.Parse(properties["power"].GetString()),
        };
    }
    
}
