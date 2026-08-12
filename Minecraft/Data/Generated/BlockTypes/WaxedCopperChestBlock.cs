using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedCopperChestBlock(Identifier Identifier, WaxedCopperChestBlock.Type TypeValue, Direction Facing, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:copper_chest";
    public double Hardness => 3;
    public double ExplosionResistance => 6;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => true;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "copper";
    public Identifier? BlockEntity => "minecraft:chest";
    public Identifier? Item => "minecraft:waxed_copper_chest";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 15;
    public string TranslationKey => "block.minecraft.waxed_copper_chest";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return TypeValue switch {
                Type.Single => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29664,
                        false => 29665,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29670,
                        false => 29671,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29676,
                        false => 29677,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29682,
                        false => 29683,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Left => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29666,
                        false => 29667,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29672,
                        false => 29673,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29678,
                        false => 29679,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29684,
                        false => 29685,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Right => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29668,
                        false => 29669,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29674,
                        false => 29675,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29680,
                        false => 29681,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29686,
                        false => 29687,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(TypeValue), TypeValue, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            29664 => new WaxedCopperChestBlock(Identifier, Type.Single, Direction.North, true),
            29665 => new WaxedCopperChestBlock(Identifier, Type.Single, Direction.North, false),
            29666 => new WaxedCopperChestBlock(Identifier, Type.Left, Direction.North, true),
            29667 => new WaxedCopperChestBlock(Identifier, Type.Left, Direction.North, false),
            29668 => new WaxedCopperChestBlock(Identifier, Type.Right, Direction.North, true),
            29669 => new WaxedCopperChestBlock(Identifier, Type.Right, Direction.North, false),
            29670 => new WaxedCopperChestBlock(Identifier, Type.Single, Direction.South, true),
            29671 => new WaxedCopperChestBlock(Identifier, Type.Single, Direction.South, false),
            29672 => new WaxedCopperChestBlock(Identifier, Type.Left, Direction.South, true),
            29673 => new WaxedCopperChestBlock(Identifier, Type.Left, Direction.South, false),
            29674 => new WaxedCopperChestBlock(Identifier, Type.Right, Direction.South, true),
            29675 => new WaxedCopperChestBlock(Identifier, Type.Right, Direction.South, false),
            29676 => new WaxedCopperChestBlock(Identifier, Type.Single, Direction.West, true),
            29677 => new WaxedCopperChestBlock(Identifier, Type.Single, Direction.West, false),
            29678 => new WaxedCopperChestBlock(Identifier, Type.Left, Direction.West, true),
            29679 => new WaxedCopperChestBlock(Identifier, Type.Left, Direction.West, false),
            29680 => new WaxedCopperChestBlock(Identifier, Type.Right, Direction.West, true),
            29681 => new WaxedCopperChestBlock(Identifier, Type.Right, Direction.West, false),
            29682 => new WaxedCopperChestBlock(Identifier, Type.Single, Direction.East, true),
            29683 => new WaxedCopperChestBlock(Identifier, Type.Single, Direction.East, false),
            29684 => new WaxedCopperChestBlock(Identifier, Type.Left, Direction.East, true),
            29685 => new WaxedCopperChestBlock(Identifier, Type.Left, Direction.East, false),
            29686 => new WaxedCopperChestBlock(Identifier, Type.Right, Direction.East, true),
            29687 => new WaxedCopperChestBlock(Identifier, Type.Right, Direction.East, false),
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
