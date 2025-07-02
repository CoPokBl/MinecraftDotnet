using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record GrayBannerBlock(Identifier Identifier, int Rotation) : IBlock {

    public uint StateId {
        get {
            return Rotation switch {
                0 => 11760,
                1 => 11761,
                2 => 11762,
                3 => 11763,
                4 => 11764,
                5 => 11765,
                6 => 11766,
                7 => 11767,
                8 => 11768,
                9 => 11769,
                10 => 11770,
                11 => 11771,
                12 => 11772,
                13 => 11773,
                14 => 11774,
                15 => 11775,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            11760 => new GrayBannerBlock(Identifier, 0),
            11761 => new GrayBannerBlock(Identifier, 1),
            11762 => new GrayBannerBlock(Identifier, 2),
            11763 => new GrayBannerBlock(Identifier, 3),
            11764 => new GrayBannerBlock(Identifier, 4),
            11765 => new GrayBannerBlock(Identifier, 5),
            11766 => new GrayBannerBlock(Identifier, 6),
            11767 => new GrayBannerBlock(Identifier, 7),
            11768 => new GrayBannerBlock(Identifier, 8),
            11769 => new GrayBannerBlock(Identifier, 9),
            11770 => new GrayBannerBlock(Identifier, 10),
            11771 => new GrayBannerBlock(Identifier, 11),
            11772 => new GrayBannerBlock(Identifier, 12),
            11773 => new GrayBannerBlock(Identifier, 13),
            11774 => new GrayBannerBlock(Identifier, 14),
            11775 => new GrayBannerBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
