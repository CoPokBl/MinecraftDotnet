using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SmallAmethystBudBlock(Identifier Identifier, Cardinal Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => Waterlogged switch {
                    true => 22097,
                    false => 22098,
                },
                Cardinal.East => Waterlogged switch {
                    true => 22099,
                    false => 22100,
                },
                Cardinal.South => Waterlogged switch {
                    true => 22101,
                    false => 22102,
                },
                Cardinal.West => Waterlogged switch {
                    true => 22103,
                    false => 22104,
                },
                Cardinal.Up => Waterlogged switch {
                    true => 22105,
                    false => 22106,
                },
                Cardinal.Down => Waterlogged switch {
                    true => 22107,
                    false => 22108,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            22097 => new SmallAmethystBudBlock(Identifier, Cardinal.North, true),
            22098 => new SmallAmethystBudBlock(Identifier, Cardinal.North, false),
            22099 => new SmallAmethystBudBlock(Identifier, Cardinal.East, true),
            22100 => new SmallAmethystBudBlock(Identifier, Cardinal.East, false),
            22101 => new SmallAmethystBudBlock(Identifier, Cardinal.South, true),
            22102 => new SmallAmethystBudBlock(Identifier, Cardinal.South, false),
            22103 => new SmallAmethystBudBlock(Identifier, Cardinal.West, true),
            22104 => new SmallAmethystBudBlock(Identifier, Cardinal.West, false),
            22105 => new SmallAmethystBudBlock(Identifier, Cardinal.Up, true),
            22106 => new SmallAmethystBudBlock(Identifier, Cardinal.Up, false),
            22107 => new SmallAmethystBudBlock(Identifier, Cardinal.Down, true),
            22108 => new SmallAmethystBudBlock(Identifier, Cardinal.Down, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = CardinalExtensions.FromString(properties["facing"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
}
