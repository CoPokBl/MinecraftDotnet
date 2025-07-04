using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record TrappedChestBlock(Identifier Identifier, TrappedChestBlock.Type TypeValue, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return TypeValue switch {
                Type.Single => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 9928,
                        false => 9929,
                    },
                    Direction.South => Waterlogged switch {
                        true => 9934,
                        false => 9935,
                    },
                    Direction.West => Waterlogged switch {
                        true => 9940,
                        false => 9941,
                    },
                    Direction.East => Waterlogged switch {
                        true => 9946,
                        false => 9947,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Left => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 9930,
                        false => 9931,
                    },
                    Direction.South => Waterlogged switch {
                        true => 9936,
                        false => 9937,
                    },
                    Direction.West => Waterlogged switch {
                        true => 9942,
                        false => 9943,
                    },
                    Direction.East => Waterlogged switch {
                        true => 9948,
                        false => 9949,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Right => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 9932,
                        false => 9933,
                    },
                    Direction.South => Waterlogged switch {
                        true => 9938,
                        false => 9939,
                    },
                    Direction.West => Waterlogged switch {
                        true => 9944,
                        false => 9945,
                    },
                    Direction.East => Waterlogged switch {
                        true => 9950,
                        false => 9951,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(TypeValue), TypeValue, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9928 => new TrappedChestBlock(Identifier, Type.Single, Direction.North, true),
            9929 => new TrappedChestBlock(Identifier, Type.Single, Direction.North, false),
            9930 => new TrappedChestBlock(Identifier, Type.Left, Direction.North, true),
            9931 => new TrappedChestBlock(Identifier, Type.Left, Direction.North, false),
            9932 => new TrappedChestBlock(Identifier, Type.Right, Direction.North, true),
            9933 => new TrappedChestBlock(Identifier, Type.Right, Direction.North, false),
            9934 => new TrappedChestBlock(Identifier, Type.Single, Direction.South, true),
            9935 => new TrappedChestBlock(Identifier, Type.Single, Direction.South, false),
            9936 => new TrappedChestBlock(Identifier, Type.Left, Direction.South, true),
            9937 => new TrappedChestBlock(Identifier, Type.Left, Direction.South, false),
            9938 => new TrappedChestBlock(Identifier, Type.Right, Direction.South, true),
            9939 => new TrappedChestBlock(Identifier, Type.Right, Direction.South, false),
            9940 => new TrappedChestBlock(Identifier, Type.Single, Direction.West, true),
            9941 => new TrappedChestBlock(Identifier, Type.Single, Direction.West, false),
            9942 => new TrappedChestBlock(Identifier, Type.Left, Direction.West, true),
            9943 => new TrappedChestBlock(Identifier, Type.Left, Direction.West, false),
            9944 => new TrappedChestBlock(Identifier, Type.Right, Direction.West, true),
            9945 => new TrappedChestBlock(Identifier, Type.Right, Direction.West, false),
            9946 => new TrappedChestBlock(Identifier, Type.Single, Direction.East, true),
            9947 => new TrappedChestBlock(Identifier, Type.Single, Direction.East, false),
            9948 => new TrappedChestBlock(Identifier, Type.Left, Direction.East, true),
            9949 => new TrappedChestBlock(Identifier, Type.Left, Direction.East, false),
            9950 => new TrappedChestBlock(Identifier, Type.Right, Direction.East, true),
            9951 => new TrappedChestBlock(Identifier, Type.Right, Direction.East, false),
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
