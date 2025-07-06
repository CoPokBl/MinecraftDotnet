using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DarkPrismarineSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 11607,
                    false => 11608,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 11609,
                    false => 11610,
                },
                SlabType.Double => Waterlogged switch {
                    true => 11611,
                    false => 11612,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11607 => new DarkPrismarineSlabBlock(Identifier, SlabType.Top, true),
            11608 => new DarkPrismarineSlabBlock(Identifier, SlabType.Top, false),
            11609 => new DarkPrismarineSlabBlock(Identifier, SlabType.Bottom, true),
            11610 => new DarkPrismarineSlabBlock(Identifier, SlabType.Bottom, false),
            11611 => new DarkPrismarineSlabBlock(Identifier, SlabType.Double, true),
            11612 => new DarkPrismarineSlabBlock(Identifier, SlabType.Double, false),
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
