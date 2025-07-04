using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ShulkerBoxBlock(Identifier Identifier, Cardinal Facing) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => 13585,
                Cardinal.East => 13586,
                Cardinal.South => 13587,
                Cardinal.West => 13588,
                Cardinal.Up => 13589,
                Cardinal.Down => 13590,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13585 => new ShulkerBoxBlock(Identifier, Cardinal.North),
            13586 => new ShulkerBoxBlock(Identifier, Cardinal.East),
            13587 => new ShulkerBoxBlock(Identifier, Cardinal.South),
            13588 => new ShulkerBoxBlock(Identifier, Cardinal.West),
            13589 => new ShulkerBoxBlock(Identifier, Cardinal.Up),
            13590 => new ShulkerBoxBlock(Identifier, Cardinal.Down),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = CardinalExtensions.FromString(properties["facing"].GetString()),
        };
    }
    
}
