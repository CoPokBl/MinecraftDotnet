using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ChestBlock(Identifier Identifier, ChestBlock.Type TypeValue, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return TypeValue switch {
                Type.Single => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 3018,
                        false => 3019,
                    },
                    Direction.South => Waterlogged switch {
                        true => 3024,
                        false => 3025,
                    },
                    Direction.West => Waterlogged switch {
                        true => 3030,
                        false => 3031,
                    },
                    Direction.East => Waterlogged switch {
                        true => 3036,
                        false => 3037,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Left => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 3020,
                        false => 3021,
                    },
                    Direction.South => Waterlogged switch {
                        true => 3026,
                        false => 3027,
                    },
                    Direction.West => Waterlogged switch {
                        true => 3032,
                        false => 3033,
                    },
                    Direction.East => Waterlogged switch {
                        true => 3038,
                        false => 3039,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Right => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 3022,
                        false => 3023,
                    },
                    Direction.South => Waterlogged switch {
                        true => 3028,
                        false => 3029,
                    },
                    Direction.West => Waterlogged switch {
                        true => 3034,
                        false => 3035,
                    },
                    Direction.East => Waterlogged switch {
                        true => 3040,
                        false => 3041,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(TypeValue), TypeValue, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            3018 => new ChestBlock(Identifier, Type.Single, Direction.North, true),
            3019 => new ChestBlock(Identifier, Type.Single, Direction.North, false),
            3020 => new ChestBlock(Identifier, Type.Left, Direction.North, true),
            3021 => new ChestBlock(Identifier, Type.Left, Direction.North, false),
            3022 => new ChestBlock(Identifier, Type.Right, Direction.North, true),
            3023 => new ChestBlock(Identifier, Type.Right, Direction.North, false),
            3024 => new ChestBlock(Identifier, Type.Single, Direction.South, true),
            3025 => new ChestBlock(Identifier, Type.Single, Direction.South, false),
            3026 => new ChestBlock(Identifier, Type.Left, Direction.South, true),
            3027 => new ChestBlock(Identifier, Type.Left, Direction.South, false),
            3028 => new ChestBlock(Identifier, Type.Right, Direction.South, true),
            3029 => new ChestBlock(Identifier, Type.Right, Direction.South, false),
            3030 => new ChestBlock(Identifier, Type.Single, Direction.West, true),
            3031 => new ChestBlock(Identifier, Type.Single, Direction.West, false),
            3032 => new ChestBlock(Identifier, Type.Left, Direction.West, true),
            3033 => new ChestBlock(Identifier, Type.Left, Direction.West, false),
            3034 => new ChestBlock(Identifier, Type.Right, Direction.West, true),
            3035 => new ChestBlock(Identifier, Type.Right, Direction.West, false),
            3036 => new ChestBlock(Identifier, Type.Single, Direction.East, true),
            3037 => new ChestBlock(Identifier, Type.Single, Direction.East, false),
            3038 => new ChestBlock(Identifier, Type.Left, Direction.East, true),
            3039 => new ChestBlock(Identifier, Type.Left, Direction.East, false),
            3040 => new ChestBlock(Identifier, Type.Right, Direction.East, true),
            3041 => new ChestBlock(Identifier, Type.Right, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            TypeValue = TypeFromString(properties["type"].GetString()),
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
    public enum Type {
        Single,
        Left,
        Right,
    }

    public static Type TypeFromString(string value) {
        return value switch {
            "single" => Type.Single,
            "left" => Type.Left,
            "right" => Type.Right,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Type.")
        };
    }
}
