using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LightBlueBannerBlock(Identifier Identifier, int Rotation) : IBlock {

    public uint StateId {
        get {
            return Rotation switch {
                0 => 11696,
                1 => 11697,
                2 => 11698,
                3 => 11699,
                4 => 11700,
                5 => 11701,
                6 => 11702,
                7 => 11703,
                8 => 11704,
                9 => 11705,
                10 => 11706,
                11 => 11707,
                12 => 11708,
                13 => 11709,
                14 => 11710,
                15 => 11711,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11696 => new LightBlueBannerBlock(Identifier, 0),
            11697 => new LightBlueBannerBlock(Identifier, 1),
            11698 => new LightBlueBannerBlock(Identifier, 2),
            11699 => new LightBlueBannerBlock(Identifier, 3),
            11700 => new LightBlueBannerBlock(Identifier, 4),
            11701 => new LightBlueBannerBlock(Identifier, 5),
            11702 => new LightBlueBannerBlock(Identifier, 6),
            11703 => new LightBlueBannerBlock(Identifier, 7),
            11704 => new LightBlueBannerBlock(Identifier, 8),
            11705 => new LightBlueBannerBlock(Identifier, 9),
            11706 => new LightBlueBannerBlock(Identifier, 10),
            11707 => new LightBlueBannerBlock(Identifier, 11),
            11708 => new LightBlueBannerBlock(Identifier, 12),
            11709 => new LightBlueBannerBlock(Identifier, 13),
            11710 => new LightBlueBannerBlock(Identifier, 14),
            11711 => new LightBlueBannerBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Rotation = int.Parse(properties["rotation"].GetString()),
        };
    }
    
}
