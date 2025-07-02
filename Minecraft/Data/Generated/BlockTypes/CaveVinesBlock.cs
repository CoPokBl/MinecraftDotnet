using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record CaveVinesBlock(Identifier Identifier, int Age, bool Berries) : IBlock {

    public uint StateId {
        get {
            return Age switch {
                0 => Berries switch {
                    true => 25797,
                    false => 25798,
                },
                1 => Berries switch {
                    true => 25799,
                    false => 25800,
                },
                2 => Berries switch {
                    true => 25801,
                    false => 25802,
                },
                3 => Berries switch {
                    true => 25803,
                    false => 25804,
                },
                4 => Berries switch {
                    true => 25805,
                    false => 25806,
                },
                5 => Berries switch {
                    true => 25807,
                    false => 25808,
                },
                6 => Berries switch {
                    true => 25809,
                    false => 25810,
                },
                7 => Berries switch {
                    true => 25811,
                    false => 25812,
                },
                8 => Berries switch {
                    true => 25813,
                    false => 25814,
                },
                9 => Berries switch {
                    true => 25815,
                    false => 25816,
                },
                10 => Berries switch {
                    true => 25817,
                    false => 25818,
                },
                11 => Berries switch {
                    true => 25819,
                    false => 25820,
                },
                12 => Berries switch {
                    true => 25821,
                    false => 25822,
                },
                13 => Berries switch {
                    true => 25823,
                    false => 25824,
                },
                14 => Berries switch {
                    true => 25825,
                    false => 25826,
                },
                15 => Berries switch {
                    true => 25827,
                    false => 25828,
                },
                16 => Berries switch {
                    true => 25829,
                    false => 25830,
                },
                17 => Berries switch {
                    true => 25831,
                    false => 25832,
                },
                18 => Berries switch {
                    true => 25833,
                    false => 25834,
                },
                19 => Berries switch {
                    true => 25835,
                    false => 25836,
                },
                20 => Berries switch {
                    true => 25837,
                    false => 25838,
                },
                21 => Berries switch {
                    true => 25839,
                    false => 25840,
                },
                22 => Berries switch {
                    true => 25841,
                    false => 25842,
                },
                23 => Berries switch {
                    true => 25843,
                    false => 25844,
                },
                24 => Berries switch {
                    true => 25845,
                    false => 25846,
                },
                25 => Berries switch {
                    true => 25847,
                    false => 25848,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            25797 => new CaveVinesBlock(Identifier, 0, true),
            25798 => new CaveVinesBlock(Identifier, 0, false),
            25799 => new CaveVinesBlock(Identifier, 1, true),
            25800 => new CaveVinesBlock(Identifier, 1, false),
            25801 => new CaveVinesBlock(Identifier, 2, true),
            25802 => new CaveVinesBlock(Identifier, 2, false),
            25803 => new CaveVinesBlock(Identifier, 3, true),
            25804 => new CaveVinesBlock(Identifier, 3, false),
            25805 => new CaveVinesBlock(Identifier, 4, true),
            25806 => new CaveVinesBlock(Identifier, 4, false),
            25807 => new CaveVinesBlock(Identifier, 5, true),
            25808 => new CaveVinesBlock(Identifier, 5, false),
            25809 => new CaveVinesBlock(Identifier, 6, true),
            25810 => new CaveVinesBlock(Identifier, 6, false),
            25811 => new CaveVinesBlock(Identifier, 7, true),
            25812 => new CaveVinesBlock(Identifier, 7, false),
            25813 => new CaveVinesBlock(Identifier, 8, true),
            25814 => new CaveVinesBlock(Identifier, 8, false),
            25815 => new CaveVinesBlock(Identifier, 9, true),
            25816 => new CaveVinesBlock(Identifier, 9, false),
            25817 => new CaveVinesBlock(Identifier, 10, true),
            25818 => new CaveVinesBlock(Identifier, 10, false),
            25819 => new CaveVinesBlock(Identifier, 11, true),
            25820 => new CaveVinesBlock(Identifier, 11, false),
            25821 => new CaveVinesBlock(Identifier, 12, true),
            25822 => new CaveVinesBlock(Identifier, 12, false),
            25823 => new CaveVinesBlock(Identifier, 13, true),
            25824 => new CaveVinesBlock(Identifier, 13, false),
            25825 => new CaveVinesBlock(Identifier, 14, true),
            25826 => new CaveVinesBlock(Identifier, 14, false),
            25827 => new CaveVinesBlock(Identifier, 15, true),
            25828 => new CaveVinesBlock(Identifier, 15, false),
            25829 => new CaveVinesBlock(Identifier, 16, true),
            25830 => new CaveVinesBlock(Identifier, 16, false),
            25831 => new CaveVinesBlock(Identifier, 17, true),
            25832 => new CaveVinesBlock(Identifier, 17, false),
            25833 => new CaveVinesBlock(Identifier, 18, true),
            25834 => new CaveVinesBlock(Identifier, 18, false),
            25835 => new CaveVinesBlock(Identifier, 19, true),
            25836 => new CaveVinesBlock(Identifier, 19, false),
            25837 => new CaveVinesBlock(Identifier, 20, true),
            25838 => new CaveVinesBlock(Identifier, 20, false),
            25839 => new CaveVinesBlock(Identifier, 21, true),
            25840 => new CaveVinesBlock(Identifier, 21, false),
            25841 => new CaveVinesBlock(Identifier, 22, true),
            25842 => new CaveVinesBlock(Identifier, 22, false),
            25843 => new CaveVinesBlock(Identifier, 23, true),
            25844 => new CaveVinesBlock(Identifier, 23, false),
            25845 => new CaveVinesBlock(Identifier, 24, true),
            25846 => new CaveVinesBlock(Identifier, 24, false),
            25847 => new CaveVinesBlock(Identifier, 25, true),
            25848 => new CaveVinesBlock(Identifier, 25, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
