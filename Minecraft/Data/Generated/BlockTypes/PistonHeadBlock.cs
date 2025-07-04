using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PistonHeadBlock(Identifier Identifier, PistonHeadBlock.Type TypeValue, Cardinal Facing, bool Short) : IBlock {

    public uint StateId {
        get {
            return TypeValue switch {
                Type.Normal => Facing switch {
                    Cardinal.North => Short switch {
                        true => 2069,
                        false => 2071,
                    },
                    Cardinal.East => Short switch {
                        true => 2073,
                        false => 2075,
                    },
                    Cardinal.South => Short switch {
                        true => 2077,
                        false => 2079,
                    },
                    Cardinal.West => Short switch {
                        true => 2081,
                        false => 2083,
                    },
                    Cardinal.Up => Short switch {
                        true => 2085,
                        false => 2087,
                    },
                    Cardinal.Down => Short switch {
                        true => 2089,
                        false => 2091,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Sticky => Facing switch {
                    Cardinal.North => Short switch {
                        true => 2070,
                        false => 2072,
                    },
                    Cardinal.East => Short switch {
                        true => 2074,
                        false => 2076,
                    },
                    Cardinal.South => Short switch {
                        true => 2078,
                        false => 2080,
                    },
                    Cardinal.West => Short switch {
                        true => 2082,
                        false => 2084,
                    },
                    Cardinal.Up => Short switch {
                        true => 2086,
                        false => 2088,
                    },
                    Cardinal.Down => Short switch {
                        true => 2090,
                        false => 2092,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(TypeValue), TypeValue, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            2069 => new PistonHeadBlock(Identifier, Type.Normal, Cardinal.North, true),
            2070 => new PistonHeadBlock(Identifier, Type.Sticky, Cardinal.North, true),
            2071 => new PistonHeadBlock(Identifier, Type.Normal, Cardinal.North, false),
            2072 => new PistonHeadBlock(Identifier, Type.Sticky, Cardinal.North, false),
            2073 => new PistonHeadBlock(Identifier, Type.Normal, Cardinal.East, true),
            2074 => new PistonHeadBlock(Identifier, Type.Sticky, Cardinal.East, true),
            2075 => new PistonHeadBlock(Identifier, Type.Normal, Cardinal.East, false),
            2076 => new PistonHeadBlock(Identifier, Type.Sticky, Cardinal.East, false),
            2077 => new PistonHeadBlock(Identifier, Type.Normal, Cardinal.South, true),
            2078 => new PistonHeadBlock(Identifier, Type.Sticky, Cardinal.South, true),
            2079 => new PistonHeadBlock(Identifier, Type.Normal, Cardinal.South, false),
            2080 => new PistonHeadBlock(Identifier, Type.Sticky, Cardinal.South, false),
            2081 => new PistonHeadBlock(Identifier, Type.Normal, Cardinal.West, true),
            2082 => new PistonHeadBlock(Identifier, Type.Sticky, Cardinal.West, true),
            2083 => new PistonHeadBlock(Identifier, Type.Normal, Cardinal.West, false),
            2084 => new PistonHeadBlock(Identifier, Type.Sticky, Cardinal.West, false),
            2085 => new PistonHeadBlock(Identifier, Type.Normal, Cardinal.Up, true),
            2086 => new PistonHeadBlock(Identifier, Type.Sticky, Cardinal.Up, true),
            2087 => new PistonHeadBlock(Identifier, Type.Normal, Cardinal.Up, false),
            2088 => new PistonHeadBlock(Identifier, Type.Sticky, Cardinal.Up, false),
            2089 => new PistonHeadBlock(Identifier, Type.Normal, Cardinal.Down, true),
            2090 => new PistonHeadBlock(Identifier, Type.Sticky, Cardinal.Down, true),
            2091 => new PistonHeadBlock(Identifier, Type.Normal, Cardinal.Down, false),
            2092 => new PistonHeadBlock(Identifier, Type.Sticky, Cardinal.Down, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            TypeValue = TypeFromString(properties["type"].GetString()),
            Facing = CardinalExtensions.FromString(properties["facing"].GetString()),
            Short = properties["short"].GetString() == "true",
        };
    }
    
    public enum Type {
        Normal,
        Sticky,
    }

    public static Type TypeFromString(string value) {
        return value switch {
            "normal" => Type.Normal,
            "sticky" => Type.Sticky,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Type.")
        };
    }
}
