using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WarpedSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 19697,
                    false => 19698,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 19699,
                    false => 19700,
                },
                SlabType.Double => Waterlogged switch {
                    true => 19701,
                    false => 19702,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            19697 => new WarpedSlabBlock(Identifier, SlabType.Top, true),
            19698 => new WarpedSlabBlock(Identifier, SlabType.Top, false),
            19699 => new WarpedSlabBlock(Identifier, SlabType.Bottom, true),
            19700 => new WarpedSlabBlock(Identifier, SlabType.Bottom, false),
            19701 => new WarpedSlabBlock(Identifier, SlabType.Double, true),
            19702 => new WarpedSlabBlock(Identifier, SlabType.Double, false),
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
