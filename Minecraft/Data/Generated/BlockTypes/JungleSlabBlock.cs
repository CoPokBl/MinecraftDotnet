using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record JungleSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 12069,
                    false => 12070,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 12071,
                    false => 12072,
                },
                SlabType.Double => Waterlogged switch {
                    true => 12073,
                    false => 12074,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12069 => new JungleSlabBlock(Identifier, SlabType.Top, true),
            12070 => new JungleSlabBlock(Identifier, SlabType.Top, false),
            12071 => new JungleSlabBlock(Identifier, SlabType.Bottom, true),
            12072 => new JungleSlabBlock(Identifier, SlabType.Bottom, false),
            12073 => new JungleSlabBlock(Identifier, SlabType.Double, true),
            12074 => new JungleSlabBlock(Identifier, SlabType.Double, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Type = SlabTypeExtensions.FromString(properties["type"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
}
