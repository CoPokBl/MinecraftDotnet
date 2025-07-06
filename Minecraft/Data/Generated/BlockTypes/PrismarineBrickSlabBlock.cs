using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PrismarineBrickSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 11601,
                    false => 11602,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 11603,
                    false => 11604,
                },
                SlabType.Double => Waterlogged switch {
                    true => 11605,
                    false => 11606,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11601 => new PrismarineBrickSlabBlock(Identifier, SlabType.Top, true),
            11602 => new PrismarineBrickSlabBlock(Identifier, SlabType.Top, false),
            11603 => new PrismarineBrickSlabBlock(Identifier, SlabType.Bottom, true),
            11604 => new PrismarineBrickSlabBlock(Identifier, SlabType.Bottom, false),
            11605 => new PrismarineBrickSlabBlock(Identifier, SlabType.Double, true),
            11606 => new PrismarineBrickSlabBlock(Identifier, SlabType.Double, false),
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
