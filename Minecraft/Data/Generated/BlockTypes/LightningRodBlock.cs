using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LightningRodBlock(Identifier Identifier, Cardinal Facing, bool Powered, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => Powered switch {
                    true => Waterlogged switch {
                        true => 25752,
                        false => 25753,
                    },
                    false => Waterlogged switch {
                        true => 25754,
                        false => 25755,
                    },
                },
                Cardinal.East => Powered switch {
                    true => Waterlogged switch {
                        true => 25756,
                        false => 25757,
                    },
                    false => Waterlogged switch {
                        true => 25758,
                        false => 25759,
                    },
                },
                Cardinal.South => Powered switch {
                    true => Waterlogged switch {
                        true => 25760,
                        false => 25761,
                    },
                    false => Waterlogged switch {
                        true => 25762,
                        false => 25763,
                    },
                },
                Cardinal.West => Powered switch {
                    true => Waterlogged switch {
                        true => 25764,
                        false => 25765,
                    },
                    false => Waterlogged switch {
                        true => 25766,
                        false => 25767,
                    },
                },
                Cardinal.Up => Powered switch {
                    true => Waterlogged switch {
                        true => 25768,
                        false => 25769,
                    },
                    false => Waterlogged switch {
                        true => 25770,
                        false => 25771,
                    },
                },
                Cardinal.Down => Powered switch {
                    true => Waterlogged switch {
                        true => 25772,
                        false => 25773,
                    },
                    false => Waterlogged switch {
                        true => 25774,
                        false => 25775,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            25752 => new LightningRodBlock(Identifier, Cardinal.North, true, true),
            25753 => new LightningRodBlock(Identifier, Cardinal.North, true, false),
            25754 => new LightningRodBlock(Identifier, Cardinal.North, false, true),
            25755 => new LightningRodBlock(Identifier, Cardinal.North, false, false),
            25756 => new LightningRodBlock(Identifier, Cardinal.East, true, true),
            25757 => new LightningRodBlock(Identifier, Cardinal.East, true, false),
            25758 => new LightningRodBlock(Identifier, Cardinal.East, false, true),
            25759 => new LightningRodBlock(Identifier, Cardinal.East, false, false),
            25760 => new LightningRodBlock(Identifier, Cardinal.South, true, true),
            25761 => new LightningRodBlock(Identifier, Cardinal.South, true, false),
            25762 => new LightningRodBlock(Identifier, Cardinal.South, false, true),
            25763 => new LightningRodBlock(Identifier, Cardinal.South, false, false),
            25764 => new LightningRodBlock(Identifier, Cardinal.West, true, true),
            25765 => new LightningRodBlock(Identifier, Cardinal.West, true, false),
            25766 => new LightningRodBlock(Identifier, Cardinal.West, false, true),
            25767 => new LightningRodBlock(Identifier, Cardinal.West, false, false),
            25768 => new LightningRodBlock(Identifier, Cardinal.Up, true, true),
            25769 => new LightningRodBlock(Identifier, Cardinal.Up, true, false),
            25770 => new LightningRodBlock(Identifier, Cardinal.Up, false, true),
            25771 => new LightningRodBlock(Identifier, Cardinal.Up, false, false),
            25772 => new LightningRodBlock(Identifier, Cardinal.Down, true, true),
            25773 => new LightningRodBlock(Identifier, Cardinal.Down, true, false),
            25774 => new LightningRodBlock(Identifier, Cardinal.Down, false, true),
            25775 => new LightningRodBlock(Identifier, Cardinal.Down, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = CardinalExtensions.FromString(properties["facing"].GetString()),
            Powered = properties["powered"].GetString() == "true",
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
}
