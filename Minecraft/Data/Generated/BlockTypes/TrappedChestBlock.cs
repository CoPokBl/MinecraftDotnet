using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record TrappedChestBlock(Identifier Identifier, TrappedChestBlock.Type TypeValue, Direction Facing, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:trapped_chest";
    public double Hardness => 2.5;
    public double ExplosionResistance => 2.5;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "wood";
    public Identifier? BlockEntity => "minecraft:trapped_chest";
    public Identifier? Item => "minecraft:trapped_chest";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => true;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 13;
    public string TranslationKey => "block.minecraft.trapped_chest";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return TypeValue switch {
                Type.Single => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 11207,
                        false => 11208,
                    },
                    Direction.South => Waterlogged switch {
                        true => 11213,
                        false => 11214,
                    },
                    Direction.West => Waterlogged switch {
                        true => 11219,
                        false => 11220,
                    },
                    Direction.East => Waterlogged switch {
                        true => 11225,
                        false => 11226,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Left => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 11209,
                        false => 11210,
                    },
                    Direction.South => Waterlogged switch {
                        true => 11215,
                        false => 11216,
                    },
                    Direction.West => Waterlogged switch {
                        true => 11221,
                        false => 11222,
                    },
                    Direction.East => Waterlogged switch {
                        true => 11227,
                        false => 11228,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Right => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 11211,
                        false => 11212,
                    },
                    Direction.South => Waterlogged switch {
                        true => 11217,
                        false => 11218,
                    },
                    Direction.West => Waterlogged switch {
                        true => 11223,
                        false => 11224,
                    },
                    Direction.East => Waterlogged switch {
                        true => 11229,
                        false => 11230,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(TypeValue), TypeValue, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11207 => new TrappedChestBlock(Identifier, Type.Single, Direction.North, true),
            11208 => new TrappedChestBlock(Identifier, Type.Single, Direction.North, false),
            11209 => new TrappedChestBlock(Identifier, Type.Left, Direction.North, true),
            11210 => new TrappedChestBlock(Identifier, Type.Left, Direction.North, false),
            11211 => new TrappedChestBlock(Identifier, Type.Right, Direction.North, true),
            11212 => new TrappedChestBlock(Identifier, Type.Right, Direction.North, false),
            11213 => new TrappedChestBlock(Identifier, Type.Single, Direction.South, true),
            11214 => new TrappedChestBlock(Identifier, Type.Single, Direction.South, false),
            11215 => new TrappedChestBlock(Identifier, Type.Left, Direction.South, true),
            11216 => new TrappedChestBlock(Identifier, Type.Left, Direction.South, false),
            11217 => new TrappedChestBlock(Identifier, Type.Right, Direction.South, true),
            11218 => new TrappedChestBlock(Identifier, Type.Right, Direction.South, false),
            11219 => new TrappedChestBlock(Identifier, Type.Single, Direction.West, true),
            11220 => new TrappedChestBlock(Identifier, Type.Single, Direction.West, false),
            11221 => new TrappedChestBlock(Identifier, Type.Left, Direction.West, true),
            11222 => new TrappedChestBlock(Identifier, Type.Left, Direction.West, false),
            11223 => new TrappedChestBlock(Identifier, Type.Right, Direction.West, true),
            11224 => new TrappedChestBlock(Identifier, Type.Right, Direction.West, false),
            11225 => new TrappedChestBlock(Identifier, Type.Single, Direction.East, true),
            11226 => new TrappedChestBlock(Identifier, Type.Single, Direction.East, false),
            11227 => new TrappedChestBlock(Identifier, Type.Left, Direction.East, true),
            11228 => new TrappedChestBlock(Identifier, Type.Left, Direction.East, false),
            11229 => new TrappedChestBlock(Identifier, Type.Right, Direction.East, true),
            11230 => new TrappedChestBlock(Identifier, Type.Right, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            TypeValue = properties.Contains("type") ? TypeFromString(properties["type"].GetString()) : TypeValue,
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("type", new StringTag(TypeToName(TypeValue))),
            ("facing", new StringTag(Facing.ToName())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
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

    public static string TypeToName(Type value) {
        return value switch {
            Type.Single => "single",
            Type.Left => "left",
            Type.Right => "right",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Type value.")
        };
    }
}
