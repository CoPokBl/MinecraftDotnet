using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record AndesiteSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 15159,
                    false => 15160,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 15161,
                    false => 15162,
                },
                SlabType.Double => Waterlogged switch {
                    true => 15163,
                    false => 15164,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            15159 => new AndesiteSlabBlock(Identifier, SlabType.Top, true),
            15160 => new AndesiteSlabBlock(Identifier, SlabType.Top, false),
            15161 => new AndesiteSlabBlock(Identifier, SlabType.Bottom, true),
            15162 => new AndesiteSlabBlock(Identifier, SlabType.Bottom, false),
            15163 => new AndesiteSlabBlock(Identifier, SlabType.Double, true),
            15164 => new AndesiteSlabBlock(Identifier, SlabType.Double, false),
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
