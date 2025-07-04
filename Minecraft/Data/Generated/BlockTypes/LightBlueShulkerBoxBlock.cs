using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LightBlueShulkerBoxBlock(Identifier Identifier, Cardinal Facing) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => 13609,
                Cardinal.East => 13610,
                Cardinal.South => 13611,
                Cardinal.West => 13612,
                Cardinal.Up => 13613,
                Cardinal.Down => 13614,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13609 => new LightBlueShulkerBoxBlock(Identifier, Cardinal.North),
            13610 => new LightBlueShulkerBoxBlock(Identifier, Cardinal.East),
            13611 => new LightBlueShulkerBoxBlock(Identifier, Cardinal.South),
            13612 => new LightBlueShulkerBoxBlock(Identifier, Cardinal.West),
            13613 => new LightBlueShulkerBoxBlock(Identifier, Cardinal.Up),
            13614 => new LightBlueShulkerBoxBlock(Identifier, Cardinal.Down),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = CardinalExtensions.FromString(properties["facing"].GetString()),
        };
    }
    
}
