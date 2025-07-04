using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record GrayShulkerBoxBlock(Identifier Identifier, Cardinal Facing) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => 13633,
                Cardinal.East => 13634,
                Cardinal.South => 13635,
                Cardinal.West => 13636,
                Cardinal.Up => 13637,
                Cardinal.Down => 13638,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13633 => new GrayShulkerBoxBlock(Identifier, Cardinal.North),
            13634 => new GrayShulkerBoxBlock(Identifier, Cardinal.East),
            13635 => new GrayShulkerBoxBlock(Identifier, Cardinal.South),
            13636 => new GrayShulkerBoxBlock(Identifier, Cardinal.West),
            13637 => new GrayShulkerBoxBlock(Identifier, Cardinal.Up),
            13638 => new GrayShulkerBoxBlock(Identifier, Cardinal.Down),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = CardinalExtensions.FromString(properties["facing"].GetString()),
        };
    }
    
}
