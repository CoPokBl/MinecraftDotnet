using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record CyanBannerBlock(Identifier Identifier, int Rotation) : IBlock {

    public uint StateId {
        get {
            return Rotation switch {
                0 => 11792,
                1 => 11793,
                2 => 11794,
                3 => 11795,
                4 => 11796,
                5 => 11797,
                6 => 11798,
                7 => 11799,
                8 => 11800,
                9 => 11801,
                10 => 11802,
                11 => 11803,
                12 => 11804,
                13 => 11805,
                14 => 11806,
                15 => 11807,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            11792 => new CyanBannerBlock(Identifier, 0),
            11793 => new CyanBannerBlock(Identifier, 1),
            11794 => new CyanBannerBlock(Identifier, 2),
            11795 => new CyanBannerBlock(Identifier, 3),
            11796 => new CyanBannerBlock(Identifier, 4),
            11797 => new CyanBannerBlock(Identifier, 5),
            11798 => new CyanBannerBlock(Identifier, 6),
            11799 => new CyanBannerBlock(Identifier, 7),
            11800 => new CyanBannerBlock(Identifier, 8),
            11801 => new CyanBannerBlock(Identifier, 9),
            11802 => new CyanBannerBlock(Identifier, 10),
            11803 => new CyanBannerBlock(Identifier, 11),
            11804 => new CyanBannerBlock(Identifier, 12),
            11805 => new CyanBannerBlock(Identifier, 13),
            11806 => new CyanBannerBlock(Identifier, 14),
            11807 => new CyanBannerBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
