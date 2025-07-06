using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record QuartzSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 12177,
                    false => 12178,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 12179,
                    false => 12180,
                },
                SlabType.Double => Waterlogged switch {
                    true => 12181,
                    false => 12182,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12177 => new QuartzSlabBlock(Identifier, SlabType.Top, true),
            12178 => new QuartzSlabBlock(Identifier, SlabType.Top, false),
            12179 => new QuartzSlabBlock(Identifier, SlabType.Bottom, true),
            12180 => new QuartzSlabBlock(Identifier, SlabType.Bottom, false),
            12181 => new QuartzSlabBlock(Identifier, SlabType.Double, true),
            12182 => new QuartzSlabBlock(Identifier, SlabType.Double, false),
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
