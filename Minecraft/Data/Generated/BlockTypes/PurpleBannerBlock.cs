using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PurpleBannerBlock(Identifier Identifier, int Rotation) : IBlock {

    public uint StateId {
        get {
            return Rotation switch {
                0 => 11808,
                1 => 11809,
                2 => 11810,
                3 => 11811,
                4 => 11812,
                5 => 11813,
                6 => 11814,
                7 => 11815,
                8 => 11816,
                9 => 11817,
                10 => 11818,
                11 => 11819,
                12 => 11820,
                13 => 11821,
                14 => 11822,
                15 => 11823,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11808 => new PurpleBannerBlock(Identifier, 0),
            11809 => new PurpleBannerBlock(Identifier, 1),
            11810 => new PurpleBannerBlock(Identifier, 2),
            11811 => new PurpleBannerBlock(Identifier, 3),
            11812 => new PurpleBannerBlock(Identifier, 4),
            11813 => new PurpleBannerBlock(Identifier, 5),
            11814 => new PurpleBannerBlock(Identifier, 6),
            11815 => new PurpleBannerBlock(Identifier, 7),
            11816 => new PurpleBannerBlock(Identifier, 8),
            11817 => new PurpleBannerBlock(Identifier, 9),
            11818 => new PurpleBannerBlock(Identifier, 10),
            11819 => new PurpleBannerBlock(Identifier, 11),
            11820 => new PurpleBannerBlock(Identifier, 12),
            11821 => new PurpleBannerBlock(Identifier, 13),
            11822 => new PurpleBannerBlock(Identifier, 14),
            11823 => new PurpleBannerBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Rotation = int.Parse(properties["rotation"].GetString()),
        };
    }
    
}
