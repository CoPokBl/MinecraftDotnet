using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedWeatheredCopperChestBlock(Identifier Identifier, WaxedWeatheredCopperChestBlock.Type TypeValue, Direction Facing, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:waxed_weathered_copper_chest";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 56;
    public string TranslationKey => "block.minecraft.waxed_weathered_copper_chest";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return TypeValue switch {
                Type.Single => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29712,
                        false => 29713,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29718,
                        false => 29719,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29724,
                        false => 29725,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29730,
                        false => 29731,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Left => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29714,
                        false => 29715,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29720,
                        false => 29721,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29726,
                        false => 29727,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29732,
                        false => 29733,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Right => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29716,
                        false => 29717,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29722,
                        false => 29723,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29728,
                        false => 29729,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29734,
                        false => 29735,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(TypeValue), TypeValue, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            29712 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Single, Direction.North, true),
            29713 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Single, Direction.North, false),
            29714 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Left, Direction.North, true),
            29715 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Left, Direction.North, false),
            29716 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Right, Direction.North, true),
            29717 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Right, Direction.North, false),
            29718 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Single, Direction.South, true),
            29719 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Single, Direction.South, false),
            29720 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Left, Direction.South, true),
            29721 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Left, Direction.South, false),
            29722 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Right, Direction.South, true),
            29723 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Right, Direction.South, false),
            29724 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Single, Direction.West, true),
            29725 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Single, Direction.West, false),
            29726 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Left, Direction.West, true),
            29727 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Left, Direction.West, false),
            29728 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Right, Direction.West, true),
            29729 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Right, Direction.West, false),
            29730 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Single, Direction.East, true),
            29731 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Single, Direction.East, false),
            29732 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Left, Direction.East, true),
            29733 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Left, Direction.East, false),
            29734 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Right, Direction.East, true),
            29735 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Right, Direction.East, false),
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
