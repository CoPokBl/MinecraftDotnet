using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record LimeBannerBlock(Identifier Identifier, int Rotation) : IBlock {

    public uint StateId {
        get {
            return Rotation switch {
                0 => 11728,
                1 => 11729,
                2 => 11730,
                3 => 11731,
                4 => 11732,
                5 => 11733,
                6 => 11734,
                7 => 11735,
                8 => 11736,
                9 => 11737,
                10 => 11738,
                11 => 11739,
                12 => 11740,
                13 => 11741,
                14 => 11742,
                15 => 11743,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            11728 => new LimeBannerBlock(Identifier, 0),
            11729 => new LimeBannerBlock(Identifier, 1),
            11730 => new LimeBannerBlock(Identifier, 2),
            11731 => new LimeBannerBlock(Identifier, 3),
            11732 => new LimeBannerBlock(Identifier, 4),
            11733 => new LimeBannerBlock(Identifier, 5),
            11734 => new LimeBannerBlock(Identifier, 6),
            11735 => new LimeBannerBlock(Identifier, 7),
            11736 => new LimeBannerBlock(Identifier, 8),
            11737 => new LimeBannerBlock(Identifier, 9),
            11738 => new LimeBannerBlock(Identifier, 10),
            11739 => new LimeBannerBlock(Identifier, 11),
            11740 => new LimeBannerBlock(Identifier, 12),
            11741 => new LimeBannerBlock(Identifier, 13),
            11742 => new LimeBannerBlock(Identifier, 14),
            11743 => new LimeBannerBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
