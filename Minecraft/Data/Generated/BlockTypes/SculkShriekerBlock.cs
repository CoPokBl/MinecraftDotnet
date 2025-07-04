using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SculkShriekerBlock(Identifier Identifier, bool CanSummon, bool Shrieking, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return CanSummon switch {
                true => Shrieking switch {
                    true => Waterlogged switch {
                        true => 23958,
                        false => 23959,
                    },
                    false => Waterlogged switch {
                        true => 23960,
                        false => 23961,
                    },
                },
                false => Shrieking switch {
                    true => Waterlogged switch {
                        true => 23962,
                        false => 23963,
                    },
                    false => Waterlogged switch {
                        true => 23964,
                        false => 23965,
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23958 => new SculkShriekerBlock(Identifier, true, true, true),
            23959 => new SculkShriekerBlock(Identifier, true, true, false),
            23960 => new SculkShriekerBlock(Identifier, true, false, true),
            23961 => new SculkShriekerBlock(Identifier, true, false, false),
            23962 => new SculkShriekerBlock(Identifier, false, true, true),
            23963 => new SculkShriekerBlock(Identifier, false, true, false),
            23964 => new SculkShriekerBlock(Identifier, false, false, true),
            23965 => new SculkShriekerBlock(Identifier, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            CanSummon = properties["can_summon"].GetString() == "true",
            Shrieking = properties["shrieking"].GetString() == "true",
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
}
