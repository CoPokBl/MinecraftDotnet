using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ExposedCopperChestBlock(Identifier Identifier, ExposedCopperChestBlock.Type TypeValue, Direction Facing, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:exposed_copper_chest";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 44;
    public string TranslationKey => "block.minecraft.exposed_copper_chest";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return TypeValue switch {
                Type.Single => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29592,
                        false => 29593,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29598,
                        false => 29599,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29604,
                        false => 29605,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29610,
                        false => 29611,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Left => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29594,
                        false => 29595,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29600,
                        false => 29601,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29606,
                        false => 29607,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29612,
                        false => 29613,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Right => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29596,
                        false => 29597,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29602,
                        false => 29603,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29608,
                        false => 29609,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29614,
                        false => 29615,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(TypeValue), TypeValue, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            29592 => new ExposedCopperChestBlock(Identifier, Type.Single, Direction.North, true),
            29593 => new ExposedCopperChestBlock(Identifier, Type.Single, Direction.North, false),
            29594 => new ExposedCopperChestBlock(Identifier, Type.Left, Direction.North, true),
            29595 => new ExposedCopperChestBlock(Identifier, Type.Left, Direction.North, false),
            29596 => new ExposedCopperChestBlock(Identifier, Type.Right, Direction.North, true),
            29597 => new ExposedCopperChestBlock(Identifier, Type.Right, Direction.North, false),
            29598 => new ExposedCopperChestBlock(Identifier, Type.Single, Direction.South, true),
            29599 => new ExposedCopperChestBlock(Identifier, Type.Single, Direction.South, false),
            29600 => new ExposedCopperChestBlock(Identifier, Type.Left, Direction.South, true),
            29601 => new ExposedCopperChestBlock(Identifier, Type.Left, Direction.South, false),
            29602 => new ExposedCopperChestBlock(Identifier, Type.Right, Direction.South, true),
            29603 => new ExposedCopperChestBlock(Identifier, Type.Right, Direction.South, false),
            29604 => new ExposedCopperChestBlock(Identifier, Type.Single, Direction.West, true),
            29605 => new ExposedCopperChestBlock(Identifier, Type.Single, Direction.West, false),
            29606 => new ExposedCopperChestBlock(Identifier, Type.Left, Direction.West, true),
            29607 => new ExposedCopperChestBlock(Identifier, Type.Left, Direction.West, false),
            29608 => new ExposedCopperChestBlock(Identifier, Type.Right, Direction.West, true),
            29609 => new ExposedCopperChestBlock(Identifier, Type.Right, Direction.West, false),
            29610 => new ExposedCopperChestBlock(Identifier, Type.Single, Direction.East, true),
            29611 => new ExposedCopperChestBlock(Identifier, Type.Single, Direction.East, false),
            29612 => new ExposedCopperChestBlock(Identifier, Type.Left, Direction.East, true),
            29613 => new ExposedCopperChestBlock(Identifier, Type.Left, Direction.East, false),
            29614 => new ExposedCopperChestBlock(Identifier, Type.Right, Direction.East, true),
            29615 => new ExposedCopperChestBlock(Identifier, Type.Right, Direction.East, false),
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
