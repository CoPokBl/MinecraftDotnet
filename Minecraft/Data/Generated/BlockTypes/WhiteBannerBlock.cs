using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WhiteBannerBlock(Identifier Identifier, int Rotation) : IBlock {

    public uint StateId {
        get {
            return Rotation switch {
                0 => 11648,
                1 => 11649,
                2 => 11650,
                3 => 11651,
                4 => 11652,
                5 => 11653,
                6 => 11654,
                7 => 11655,
                8 => 11656,
                9 => 11657,
                10 => 11658,
                11 => 11659,
                12 => 11660,
                13 => 11661,
                14 => 11662,
                15 => 11663,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11648 => new WhiteBannerBlock(Identifier, 0),
            11649 => new WhiteBannerBlock(Identifier, 1),
            11650 => new WhiteBannerBlock(Identifier, 2),
            11651 => new WhiteBannerBlock(Identifier, 3),
            11652 => new WhiteBannerBlock(Identifier, 4),
            11653 => new WhiteBannerBlock(Identifier, 5),
            11654 => new WhiteBannerBlock(Identifier, 6),
            11655 => new WhiteBannerBlock(Identifier, 7),
            11656 => new WhiteBannerBlock(Identifier, 8),
            11657 => new WhiteBannerBlock(Identifier, 9),
            11658 => new WhiteBannerBlock(Identifier, 10),
            11659 => new WhiteBannerBlock(Identifier, 11),
            11660 => new WhiteBannerBlock(Identifier, 12),
            11661 => new WhiteBannerBlock(Identifier, 13),
            11662 => new WhiteBannerBlock(Identifier, 14),
            11663 => new WhiteBannerBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Rotation = int.Parse(properties["rotation"].GetString()),
        };
    }
    
}
