using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WeatheredCopperChestBlock(Identifier Identifier, WeatheredCopperChestBlock.Type TypeValue, Direction Facing, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:weathering_copper_chest";
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
    public Identifier? Item => "minecraft:weathered_copper_chest";
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
    public string TranslationKey => "block.minecraft.weathered_copper_chest";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return TypeValue switch {
                Type.Single => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29616,
                        false => 29617,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29622,
                        false => 29623,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29628,
                        false => 29629,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29634,
                        false => 29635,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Left => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29618,
                        false => 29619,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29624,
                        false => 29625,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29630,
                        false => 29631,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29636,
                        false => 29637,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Right => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29620,
                        false => 29621,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29626,
                        false => 29627,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29632,
                        false => 29633,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29638,
                        false => 29639,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(TypeValue), TypeValue, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            29616 => new WeatheredCopperChestBlock(Identifier, Type.Single, Direction.North, true),
            29617 => new WeatheredCopperChestBlock(Identifier, Type.Single, Direction.North, false),
            29618 => new WeatheredCopperChestBlock(Identifier, Type.Left, Direction.North, true),
            29619 => new WeatheredCopperChestBlock(Identifier, Type.Left, Direction.North, false),
            29620 => new WeatheredCopperChestBlock(Identifier, Type.Right, Direction.North, true),
            29621 => new WeatheredCopperChestBlock(Identifier, Type.Right, Direction.North, false),
            29622 => new WeatheredCopperChestBlock(Identifier, Type.Single, Direction.South, true),
            29623 => new WeatheredCopperChestBlock(Identifier, Type.Single, Direction.South, false),
            29624 => new WeatheredCopperChestBlock(Identifier, Type.Left, Direction.South, true),
            29625 => new WeatheredCopperChestBlock(Identifier, Type.Left, Direction.South, false),
            29626 => new WeatheredCopperChestBlock(Identifier, Type.Right, Direction.South, true),
            29627 => new WeatheredCopperChestBlock(Identifier, Type.Right, Direction.South, false),
            29628 => new WeatheredCopperChestBlock(Identifier, Type.Single, Direction.West, true),
            29629 => new WeatheredCopperChestBlock(Identifier, Type.Single, Direction.West, false),
            29630 => new WeatheredCopperChestBlock(Identifier, Type.Left, Direction.West, true),
            29631 => new WeatheredCopperChestBlock(Identifier, Type.Left, Direction.West, false),
            29632 => new WeatheredCopperChestBlock(Identifier, Type.Right, Direction.West, true),
            29633 => new WeatheredCopperChestBlock(Identifier, Type.Right, Direction.West, false),
            29634 => new WeatheredCopperChestBlock(Identifier, Type.Single, Direction.East, true),
            29635 => new WeatheredCopperChestBlock(Identifier, Type.Single, Direction.East, false),
            29636 => new WeatheredCopperChestBlock(Identifier, Type.Left, Direction.East, true),
            29637 => new WeatheredCopperChestBlock(Identifier, Type.Left, Direction.East, false),
            29638 => new WeatheredCopperChestBlock(Identifier, Type.Right, Direction.East, true),
            29639 => new WeatheredCopperChestBlock(Identifier, Type.Right, Direction.East, false),
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
