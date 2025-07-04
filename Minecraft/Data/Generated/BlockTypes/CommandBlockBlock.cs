using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CommandBlockBlock(Identifier Identifier, bool Conditional, Cardinal Facing) : IBlock {

    public uint StateId {
        get {
            return Conditional switch {
                true => Facing switch {
                    Cardinal.North => 8690,
                    Cardinal.East => 8691,
                    Cardinal.South => 8692,
                    Cardinal.West => 8693,
                    Cardinal.Up => 8694,
                    Cardinal.Down => 8695,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                false => Facing switch {
                    Cardinal.North => 8696,
                    Cardinal.East => 8697,
                    Cardinal.South => 8698,
                    Cardinal.West => 8699,
                    Cardinal.Up => 8700,
                    Cardinal.Down => 8701,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8690 => new CommandBlockBlock(Identifier, true, Cardinal.North),
            8691 => new CommandBlockBlock(Identifier, true, Cardinal.East),
            8692 => new CommandBlockBlock(Identifier, true, Cardinal.South),
            8693 => new CommandBlockBlock(Identifier, true, Cardinal.West),
            8694 => new CommandBlockBlock(Identifier, true, Cardinal.Up),
            8695 => new CommandBlockBlock(Identifier, true, Cardinal.Down),
            8696 => new CommandBlockBlock(Identifier, false, Cardinal.North),
            8697 => new CommandBlockBlock(Identifier, false, Cardinal.East),
            8698 => new CommandBlockBlock(Identifier, false, Cardinal.South),
            8699 => new CommandBlockBlock(Identifier, false, Cardinal.West),
            8700 => new CommandBlockBlock(Identifier, false, Cardinal.Up),
            8701 => new CommandBlockBlock(Identifier, false, Cardinal.Down),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Conditional = properties["conditional"].GetString() == "true",
            Facing = CardinalExtensions.FromString(properties["facing"].GetString()),
        };
    }
    
}
