using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record PinkBannerBlock(Identifier Identifier, int Rotation) : IBlock {

    public uint StateId {
        get {
            return Rotation switch {
                0 => 11744,
                1 => 11745,
                2 => 11746,
                3 => 11747,
                4 => 11748,
                5 => 11749,
                6 => 11750,
                7 => 11751,
                8 => 11752,
                9 => 11753,
                10 => 11754,
                11 => 11755,
                12 => 11756,
                13 => 11757,
                14 => 11758,
                15 => 11759,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            11744 => new PinkBannerBlock(Identifier, 0),
            11745 => new PinkBannerBlock(Identifier, 1),
            11746 => new PinkBannerBlock(Identifier, 2),
            11747 => new PinkBannerBlock(Identifier, 3),
            11748 => new PinkBannerBlock(Identifier, 4),
            11749 => new PinkBannerBlock(Identifier, 5),
            11750 => new PinkBannerBlock(Identifier, 6),
            11751 => new PinkBannerBlock(Identifier, 7),
            11752 => new PinkBannerBlock(Identifier, 8),
            11753 => new PinkBannerBlock(Identifier, 9),
            11754 => new PinkBannerBlock(Identifier, 10),
            11755 => new PinkBannerBlock(Identifier, 11),
            11756 => new PinkBannerBlock(Identifier, 12),
            11757 => new PinkBannerBlock(Identifier, 13),
            11758 => new PinkBannerBlock(Identifier, 14),
            11759 => new PinkBannerBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
