using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record GreenShulkerBoxBlock(Identifier Identifier, Cardinal Facing) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => 13669,
                Cardinal.East => 13670,
                Cardinal.South => 13671,
                Cardinal.West => 13672,
                Cardinal.Up => 13673,
                Cardinal.Down => 13674,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13669 => new GreenShulkerBoxBlock(Identifier, Cardinal.North),
            13670 => new GreenShulkerBoxBlock(Identifier, Cardinal.East),
            13671 => new GreenShulkerBoxBlock(Identifier, Cardinal.South),
            13672 => new GreenShulkerBoxBlock(Identifier, Cardinal.West),
            13673 => new GreenShulkerBoxBlock(Identifier, Cardinal.Up),
            13674 => new GreenShulkerBoxBlock(Identifier, Cardinal.Down),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = CardinalExtensions.FromString(properties["facing"].GetString()),
        };
    }
    
}
