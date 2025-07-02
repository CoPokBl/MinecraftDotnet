using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record BlackBannerBlock(Identifier Identifier, int Rotation) : IBlock {

    public uint StateId {
        get {
            return Rotation switch {
                0 => 11888,
                1 => 11889,
                2 => 11890,
                3 => 11891,
                4 => 11892,
                5 => 11893,
                6 => 11894,
                7 => 11895,
                8 => 11896,
                9 => 11897,
                10 => 11898,
                11 => 11899,
                12 => 11900,
                13 => 11901,
                14 => 11902,
                15 => 11903,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            11888 => new BlackBannerBlock(Identifier, 0),
            11889 => new BlackBannerBlock(Identifier, 1),
            11890 => new BlackBannerBlock(Identifier, 2),
            11891 => new BlackBannerBlock(Identifier, 3),
            11892 => new BlackBannerBlock(Identifier, 4),
            11893 => new BlackBannerBlock(Identifier, 5),
            11894 => new BlackBannerBlock(Identifier, 6),
            11895 => new BlackBannerBlock(Identifier, 7),
            11896 => new BlackBannerBlock(Identifier, 8),
            11897 => new BlackBannerBlock(Identifier, 9),
            11898 => new BlackBannerBlock(Identifier, 10),
            11899 => new BlackBannerBlock(Identifier, 11),
            11900 => new BlackBannerBlock(Identifier, 12),
            11901 => new BlackBannerBlock(Identifier, 13),
            11902 => new BlackBannerBlock(Identifier, 14),
            11903 => new BlackBannerBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
