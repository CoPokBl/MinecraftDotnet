using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedBlackstoneBrickSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 20903,
                    false => 20904,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 20905,
                    false => 20906,
                },
                SlabType.Double => Waterlogged switch {
                    true => 20907,
                    false => 20908,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20903 => new PolishedBlackstoneBrickSlabBlock(Identifier, SlabType.Top, true),
            20904 => new PolishedBlackstoneBrickSlabBlock(Identifier, SlabType.Top, false),
            20905 => new PolishedBlackstoneBrickSlabBlock(Identifier, SlabType.Bottom, true),
            20906 => new PolishedBlackstoneBrickSlabBlock(Identifier, SlabType.Bottom, false),
            20907 => new PolishedBlackstoneBrickSlabBlock(Identifier, SlabType.Double, true),
            20908 => new PolishedBlackstoneBrickSlabBlock(Identifier, SlabType.Double, false),
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
