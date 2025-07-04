using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BlueBannerBlock(Identifier Identifier, int Rotation) : IBlock {

    public uint StateId {
        get {
            return Rotation switch {
                0 => 11824,
                1 => 11825,
                2 => 11826,
                3 => 11827,
                4 => 11828,
                5 => 11829,
                6 => 11830,
                7 => 11831,
                8 => 11832,
                9 => 11833,
                10 => 11834,
                11 => 11835,
                12 => 11836,
                13 => 11837,
                14 => 11838,
                15 => 11839,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11824 => new BlueBannerBlock(Identifier, 0),
            11825 => new BlueBannerBlock(Identifier, 1),
            11826 => new BlueBannerBlock(Identifier, 2),
            11827 => new BlueBannerBlock(Identifier, 3),
            11828 => new BlueBannerBlock(Identifier, 4),
            11829 => new BlueBannerBlock(Identifier, 5),
            11830 => new BlueBannerBlock(Identifier, 6),
            11831 => new BlueBannerBlock(Identifier, 7),
            11832 => new BlueBannerBlock(Identifier, 8),
            11833 => new BlueBannerBlock(Identifier, 9),
            11834 => new BlueBannerBlock(Identifier, 10),
            11835 => new BlueBannerBlock(Identifier, 11),
            11836 => new BlueBannerBlock(Identifier, 12),
            11837 => new BlueBannerBlock(Identifier, 13),
            11838 => new BlueBannerBlock(Identifier, 14),
            11839 => new BlueBannerBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Rotation = int.Parse(properties["rotation"].GetString()),
        };
    }
    
}
