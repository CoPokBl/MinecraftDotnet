using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record RedBannerBlock(Identifier Identifier, int Rotation) : IBlock {

    public uint StateId {
        get {
            return Rotation switch {
                0 => 11872,
                1 => 11873,
                2 => 11874,
                3 => 11875,
                4 => 11876,
                5 => 11877,
                6 => 11878,
                7 => 11879,
                8 => 11880,
                9 => 11881,
                10 => 11882,
                11 => 11883,
                12 => 11884,
                13 => 11885,
                14 => 11886,
                15 => 11887,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11872 => new RedBannerBlock(Identifier, 0),
            11873 => new RedBannerBlock(Identifier, 1),
            11874 => new RedBannerBlock(Identifier, 2),
            11875 => new RedBannerBlock(Identifier, 3),
            11876 => new RedBannerBlock(Identifier, 4),
            11877 => new RedBannerBlock(Identifier, 5),
            11878 => new RedBannerBlock(Identifier, 6),
            11879 => new RedBannerBlock(Identifier, 7),
            11880 => new RedBannerBlock(Identifier, 8),
            11881 => new RedBannerBlock(Identifier, 9),
            11882 => new RedBannerBlock(Identifier, 10),
            11883 => new RedBannerBlock(Identifier, 11),
            11884 => new RedBannerBlock(Identifier, 12),
            11885 => new RedBannerBlock(Identifier, 13),
            11886 => new RedBannerBlock(Identifier, 14),
            11887 => new RedBannerBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Rotation = int.Parse(properties["rotation"].GetString()),
        };
    }
    
}
