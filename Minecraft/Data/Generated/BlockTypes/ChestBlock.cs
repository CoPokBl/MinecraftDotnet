using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ChestBlock(Identifier Identifier, ChestBlock.Type TypeValue, Direction Facing, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:chest";
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
    public Identifier? BlockEntity => "minecraft:chest";
    public Identifier? Item => "minecraft:chest";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 13;
    public string TranslationKey => "block.minecraft.chest";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return TypeValue switch {
                Type.Single => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 3987,
                        false => 3988,
                    },
                    Direction.South => Waterlogged switch {
                        true => 3993,
                        false => 3994,
                    },
                    Direction.West => Waterlogged switch {
                        true => 3999,
                        false => 4000,
                    },
                    Direction.East => Waterlogged switch {
                        true => 4005,
                        false => 4006,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Left => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 3989,
                        false => 3990,
                    },
                    Direction.South => Waterlogged switch {
                        true => 3995,
                        false => 3996,
                    },
                    Direction.West => Waterlogged switch {
                        true => 4001,
                        false => 4002,
                    },
                    Direction.East => Waterlogged switch {
                        true => 4007,
                        false => 4008,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Right => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 3991,
                        false => 3992,
                    },
                    Direction.South => Waterlogged switch {
                        true => 3997,
                        false => 3998,
                    },
                    Direction.West => Waterlogged switch {
                        true => 4003,
                        false => 4004,
                    },
                    Direction.East => Waterlogged switch {
                        true => 4009,
                        false => 4010,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(TypeValue), TypeValue, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            3987 => new ChestBlock(Identifier, Type.Single, Direction.North, true),
            3988 => new ChestBlock(Identifier, Type.Single, Direction.North, false),
            3989 => new ChestBlock(Identifier, Type.Left, Direction.North, true),
            3990 => new ChestBlock(Identifier, Type.Left, Direction.North, false),
            3991 => new ChestBlock(Identifier, Type.Right, Direction.North, true),
            3992 => new ChestBlock(Identifier, Type.Right, Direction.North, false),
            3993 => new ChestBlock(Identifier, Type.Single, Direction.South, true),
            3994 => new ChestBlock(Identifier, Type.Single, Direction.South, false),
            3995 => new ChestBlock(Identifier, Type.Left, Direction.South, true),
            3996 => new ChestBlock(Identifier, Type.Left, Direction.South, false),
            3997 => new ChestBlock(Identifier, Type.Right, Direction.South, true),
            3998 => new ChestBlock(Identifier, Type.Right, Direction.South, false),
            3999 => new ChestBlock(Identifier, Type.Single, Direction.West, true),
            4000 => new ChestBlock(Identifier, Type.Single, Direction.West, false),
            4001 => new ChestBlock(Identifier, Type.Left, Direction.West, true),
            4002 => new ChestBlock(Identifier, Type.Left, Direction.West, false),
            4003 => new ChestBlock(Identifier, Type.Right, Direction.West, true),
            4004 => new ChestBlock(Identifier, Type.Right, Direction.West, false),
            4005 => new ChestBlock(Identifier, Type.Single, Direction.East, true),
            4006 => new ChestBlock(Identifier, Type.Single, Direction.East, false),
            4007 => new ChestBlock(Identifier, Type.Left, Direction.East, true),
            4008 => new ChestBlock(Identifier, Type.Left, Direction.East, false),
            4009 => new ChestBlock(Identifier, Type.Right, Direction.East, true),
            4010 => new ChestBlock(Identifier, Type.Right, Direction.East, false),
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
