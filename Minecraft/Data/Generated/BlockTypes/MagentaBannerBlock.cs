using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record MagentaBannerBlock(Identifier Identifier, int Rotation) : IBlock {

    public uint StateId {
        get {
            return Rotation switch {
                0 => 11680,
                1 => 11681,
                2 => 11682,
                3 => 11683,
                4 => 11684,
                5 => 11685,
                6 => 11686,
                7 => 11687,
                8 => 11688,
                9 => 11689,
                10 => 11690,
                11 => 11691,
                12 => 11692,
                13 => 11693,
                14 => 11694,
                15 => 11695,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            11680 => new MagentaBannerBlock(Identifier, 0),
            11681 => new MagentaBannerBlock(Identifier, 1),
            11682 => new MagentaBannerBlock(Identifier, 2),
            11683 => new MagentaBannerBlock(Identifier, 3),
            11684 => new MagentaBannerBlock(Identifier, 4),
            11685 => new MagentaBannerBlock(Identifier, 5),
            11686 => new MagentaBannerBlock(Identifier, 6),
            11687 => new MagentaBannerBlock(Identifier, 7),
            11688 => new MagentaBannerBlock(Identifier, 8),
            11689 => new MagentaBannerBlock(Identifier, 9),
            11690 => new MagentaBannerBlock(Identifier, 10),
            11691 => new MagentaBannerBlock(Identifier, 11),
            11692 => new MagentaBannerBlock(Identifier, 12),
            11693 => new MagentaBannerBlock(Identifier, 13),
            11694 => new MagentaBannerBlock(Identifier, 14),
            11695 => new MagentaBannerBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
