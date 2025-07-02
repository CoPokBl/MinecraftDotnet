using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record HeavyWeightedPressurePlateBlock(Identifier Identifier, int Power) : IBlock {

    public uint StateId {
        get {
            return Power switch {
                0 => 9968,
                1 => 9969,
                2 => 9970,
                3 => 9971,
                4 => 9972,
                5 => 9973,
                6 => 9974,
                7 => 9975,
                8 => 9976,
                9 => 9977,
                10 => 9978,
                11 => 9979,
                12 => 9980,
                13 => 9981,
                14 => 9982,
                15 => 9983,
                _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            9968 => new HeavyWeightedPressurePlateBlock(Identifier, 0),
            9969 => new HeavyWeightedPressurePlateBlock(Identifier, 1),
            9970 => new HeavyWeightedPressurePlateBlock(Identifier, 2),
            9971 => new HeavyWeightedPressurePlateBlock(Identifier, 3),
            9972 => new HeavyWeightedPressurePlateBlock(Identifier, 4),
            9973 => new HeavyWeightedPressurePlateBlock(Identifier, 5),
            9974 => new HeavyWeightedPressurePlateBlock(Identifier, 6),
            9975 => new HeavyWeightedPressurePlateBlock(Identifier, 7),
            9976 => new HeavyWeightedPressurePlateBlock(Identifier, 8),
            9977 => new HeavyWeightedPressurePlateBlock(Identifier, 9),
            9978 => new HeavyWeightedPressurePlateBlock(Identifier, 10),
            9979 => new HeavyWeightedPressurePlateBlock(Identifier, 11),
            9980 => new HeavyWeightedPressurePlateBlock(Identifier, 12),
            9981 => new HeavyWeightedPressurePlateBlock(Identifier, 13),
            9982 => new HeavyWeightedPressurePlateBlock(Identifier, 14),
            9983 => new HeavyWeightedPressurePlateBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
