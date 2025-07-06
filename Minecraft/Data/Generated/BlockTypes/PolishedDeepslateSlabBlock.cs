using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedDeepslateSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 26459,
                    false => 26460,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 26461,
                    false => 26462,
                },
                SlabType.Double => Waterlogged switch {
                    true => 26463,
                    false => 26464,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            26459 => new PolishedDeepslateSlabBlock(Identifier, SlabType.Top, true),
            26460 => new PolishedDeepslateSlabBlock(Identifier, SlabType.Top, false),
            26461 => new PolishedDeepslateSlabBlock(Identifier, SlabType.Bottom, true),
            26462 => new PolishedDeepslateSlabBlock(Identifier, SlabType.Bottom, false),
            26463 => new PolishedDeepslateSlabBlock(Identifier, SlabType.Double, true),
            26464 => new PolishedDeepslateSlabBlock(Identifier, SlabType.Double, false),
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
