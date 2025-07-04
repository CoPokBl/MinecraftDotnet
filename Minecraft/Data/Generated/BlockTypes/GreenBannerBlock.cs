using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record GreenBannerBlock(Identifier Identifier, int Rotation) : IBlock {

    public uint StateId {
        get {
            return Rotation switch {
                0 => 11856,
                1 => 11857,
                2 => 11858,
                3 => 11859,
                4 => 11860,
                5 => 11861,
                6 => 11862,
                7 => 11863,
                8 => 11864,
                9 => 11865,
                10 => 11866,
                11 => 11867,
                12 => 11868,
                13 => 11869,
                14 => 11870,
                15 => 11871,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11856 => new GreenBannerBlock(Identifier, 0),
            11857 => new GreenBannerBlock(Identifier, 1),
            11858 => new GreenBannerBlock(Identifier, 2),
            11859 => new GreenBannerBlock(Identifier, 3),
            11860 => new GreenBannerBlock(Identifier, 4),
            11861 => new GreenBannerBlock(Identifier, 5),
            11862 => new GreenBannerBlock(Identifier, 6),
            11863 => new GreenBannerBlock(Identifier, 7),
            11864 => new GreenBannerBlock(Identifier, 8),
            11865 => new GreenBannerBlock(Identifier, 9),
            11866 => new GreenBannerBlock(Identifier, 10),
            11867 => new GreenBannerBlock(Identifier, 11),
            11868 => new GreenBannerBlock(Identifier, 12),
            11869 => new GreenBannerBlock(Identifier, 13),
            11870 => new GreenBannerBlock(Identifier, 14),
            11871 => new GreenBannerBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Rotation = int.Parse(properties["rotation"].GetString()),
        };
    }
    
}
