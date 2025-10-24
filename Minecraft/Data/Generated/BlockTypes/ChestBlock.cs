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
    public int ProtocolId => 200;
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
                        true => 3786,
                        false => 3787,
                    },
                    Direction.South => Waterlogged switch {
                        true => 3792,
                        false => 3793,
                    },
                    Direction.West => Waterlogged switch {
                        true => 3798,
                        false => 3799,
                    },
                    Direction.East => Waterlogged switch {
                        true => 3804,
                        false => 3805,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Left => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 3788,
                        false => 3789,
                    },
                    Direction.South => Waterlogged switch {
                        true => 3794,
                        false => 3795,
                    },
                    Direction.West => Waterlogged switch {
                        true => 3800,
                        false => 3801,
                    },
                    Direction.East => Waterlogged switch {
                        true => 3806,
                        false => 3807,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Right => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 3790,
                        false => 3791,
                    },
                    Direction.South => Waterlogged switch {
                        true => 3796,
                        false => 3797,
                    },
                    Direction.West => Waterlogged switch {
                        true => 3802,
                        false => 3803,
                    },
                    Direction.East => Waterlogged switch {
                        true => 3808,
                        false => 3809,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(TypeValue), TypeValue, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            3786 => new ChestBlock(Identifier, Type.Single, Direction.North, true),
            3787 => new ChestBlock(Identifier, Type.Single, Direction.North, false),
            3788 => new ChestBlock(Identifier, Type.Left, Direction.North, true),
            3789 => new ChestBlock(Identifier, Type.Left, Direction.North, false),
            3790 => new ChestBlock(Identifier, Type.Right, Direction.North, true),
            3791 => new ChestBlock(Identifier, Type.Right, Direction.North, false),
            3792 => new ChestBlock(Identifier, Type.Single, Direction.South, true),
            3793 => new ChestBlock(Identifier, Type.Single, Direction.South, false),
            3794 => new ChestBlock(Identifier, Type.Left, Direction.South, true),
            3795 => new ChestBlock(Identifier, Type.Left, Direction.South, false),
            3796 => new ChestBlock(Identifier, Type.Right, Direction.South, true),
            3797 => new ChestBlock(Identifier, Type.Right, Direction.South, false),
            3798 => new ChestBlock(Identifier, Type.Single, Direction.West, true),
            3799 => new ChestBlock(Identifier, Type.Single, Direction.West, false),
            3800 => new ChestBlock(Identifier, Type.Left, Direction.West, true),
            3801 => new ChestBlock(Identifier, Type.Left, Direction.West, false),
            3802 => new ChestBlock(Identifier, Type.Right, Direction.West, true),
            3803 => new ChestBlock(Identifier, Type.Right, Direction.West, false),
            3804 => new ChestBlock(Identifier, Type.Single, Direction.East, true),
            3805 => new ChestBlock(Identifier, Type.Single, Direction.East, false),
            3806 => new ChestBlock(Identifier, Type.Left, Direction.East, true),
            3807 => new ChestBlock(Identifier, Type.Left, Direction.East, false),
            3808 => new ChestBlock(Identifier, Type.Right, Direction.East, true),
            3809 => new ChestBlock(Identifier, Type.Right, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            TypeValue = properties.ChildrenMap.ContainsKey("type") ? TypeFromString(properties["type"].GetString()) : TypeValue,
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("type", TypeToName(TypeValue)),
            new StringTag("facing", Facing.ToName()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
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
