using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record RailBlock(Identifier Identifier, RailBlock.Shape ShapeValue, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return ShapeValue switch {
                Shape.NorthSouth => Waterlogged switch {
                    true => 4758,
                    false => 4759,
                },
                Shape.EastWest => Waterlogged switch {
                    true => 4760,
                    false => 4761,
                },
                Shape.AscendingEast => Waterlogged switch {
                    true => 4762,
                    false => 4763,
                },
                Shape.AscendingWest => Waterlogged switch {
                    true => 4764,
                    false => 4765,
                },
                Shape.AscendingNorth => Waterlogged switch {
                    true => 4766,
                    false => 4767,
                },
                Shape.AscendingSouth => Waterlogged switch {
                    true => 4768,
                    false => 4769,
                },
                Shape.SouthEast => Waterlogged switch {
                    true => 4770,
                    false => 4771,
                },
                Shape.SouthWest => Waterlogged switch {
                    true => 4772,
                    false => 4773,
                },
                Shape.NorthWest => Waterlogged switch {
                    true => 4774,
                    false => 4775,
                },
                Shape.NorthEast => Waterlogged switch {
                    true => 4776,
                    false => 4777,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(ShapeValue), ShapeValue, "Unknown value for property shape.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            4758 => new RailBlock(Identifier, Shape.NorthSouth, true),
            4759 => new RailBlock(Identifier, Shape.NorthSouth, false),
            4760 => new RailBlock(Identifier, Shape.EastWest, true),
            4761 => new RailBlock(Identifier, Shape.EastWest, false),
            4762 => new RailBlock(Identifier, Shape.AscendingEast, true),
            4763 => new RailBlock(Identifier, Shape.AscendingEast, false),
            4764 => new RailBlock(Identifier, Shape.AscendingWest, true),
            4765 => new RailBlock(Identifier, Shape.AscendingWest, false),
            4766 => new RailBlock(Identifier, Shape.AscendingNorth, true),
            4767 => new RailBlock(Identifier, Shape.AscendingNorth, false),
            4768 => new RailBlock(Identifier, Shape.AscendingSouth, true),
            4769 => new RailBlock(Identifier, Shape.AscendingSouth, false),
            4770 => new RailBlock(Identifier, Shape.SouthEast, true),
            4771 => new RailBlock(Identifier, Shape.SouthEast, false),
            4772 => new RailBlock(Identifier, Shape.SouthWest, true),
            4773 => new RailBlock(Identifier, Shape.SouthWest, false),
            4774 => new RailBlock(Identifier, Shape.NorthWest, true),
            4775 => new RailBlock(Identifier, Shape.NorthWest, false),
            4776 => new RailBlock(Identifier, Shape.NorthEast, true),
            4777 => new RailBlock(Identifier, Shape.NorthEast, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            ShapeValue = ShapeFromString(properties["shape"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
    public enum Shape {
        NorthSouth,
        EastWest,
        AscendingEast,
        AscendingWest,
        AscendingNorth,
        AscendingSouth,
        SouthEast,
        SouthWest,
        NorthWest,
        NorthEast,
    }

    public static Shape ShapeFromString(string value) {
        return value switch {
            "north_south" => Shape.NorthSouth,
            "east_west" => Shape.EastWest,
            "ascending_east" => Shape.AscendingEast,
            "ascending_west" => Shape.AscendingWest,
            "ascending_north" => Shape.AscendingNorth,
            "ascending_south" => Shape.AscendingSouth,
            "south_east" => Shape.SouthEast,
            "south_west" => Shape.SouthWest,
            "north_west" => Shape.NorthWest,
            "north_east" => Shape.NorthEast,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Shape.")
        };
    }
}
