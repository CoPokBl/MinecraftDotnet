using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BrownBannerBlock(Identifier Identifier, int Rotation) : IBlock {

    public uint StateId {
        get {
            return Rotation switch {
                0 => 11840,
                1 => 11841,
                2 => 11842,
                3 => 11843,
                4 => 11844,
                5 => 11845,
                6 => 11846,
                7 => 11847,
                8 => 11848,
                9 => 11849,
                10 => 11850,
                11 => 11851,
                12 => 11852,
                13 => 11853,
                14 => 11854,
                15 => 11855,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11840 => new BrownBannerBlock(Identifier, 0),
            11841 => new BrownBannerBlock(Identifier, 1),
            11842 => new BrownBannerBlock(Identifier, 2),
            11843 => new BrownBannerBlock(Identifier, 3),
            11844 => new BrownBannerBlock(Identifier, 4),
            11845 => new BrownBannerBlock(Identifier, 5),
            11846 => new BrownBannerBlock(Identifier, 6),
            11847 => new BrownBannerBlock(Identifier, 7),
            11848 => new BrownBannerBlock(Identifier, 8),
            11849 => new BrownBannerBlock(Identifier, 9),
            11850 => new BrownBannerBlock(Identifier, 10),
            11851 => new BrownBannerBlock(Identifier, 11),
            11852 => new BrownBannerBlock(Identifier, 12),
            11853 => new BrownBannerBlock(Identifier, 13),
            11854 => new BrownBannerBlock(Identifier, 14),
            11855 => new BrownBannerBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Rotation = int.Parse(properties["rotation"].GetString()),
        };
    }
    
}
