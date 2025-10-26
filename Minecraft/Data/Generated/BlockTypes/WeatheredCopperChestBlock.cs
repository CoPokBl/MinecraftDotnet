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
    public int ProtocolId => 1081;
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
                        true => 26941,
                        false => 26942,
                    },
                    Direction.South => Waterlogged switch {
                        true => 26947,
                        false => 26948,
                    },
                    Direction.West => Waterlogged switch {
                        true => 26953,
                        false => 26954,
                    },
                    Direction.East => Waterlogged switch {
                        true => 26959,
                        false => 26960,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Left => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 26943,
                        false => 26944,
                    },
                    Direction.South => Waterlogged switch {
                        true => 26949,
                        false => 26950,
                    },
                    Direction.West => Waterlogged switch {
                        true => 26955,
                        false => 26956,
                    },
                    Direction.East => Waterlogged switch {
                        true => 26961,
                        false => 26962,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Right => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 26945,
                        false => 26946,
                    },
                    Direction.South => Waterlogged switch {
                        true => 26951,
                        false => 26952,
                    },
                    Direction.West => Waterlogged switch {
                        true => 26957,
                        false => 26958,
                    },
                    Direction.East => Waterlogged switch {
                        true => 26963,
                        false => 26964,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(TypeValue), TypeValue, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            26941 => new WeatheredCopperChestBlock(Identifier, Type.Single, Direction.North, true),
            26942 => new WeatheredCopperChestBlock(Identifier, Type.Single, Direction.North, false),
            26943 => new WeatheredCopperChestBlock(Identifier, Type.Left, Direction.North, true),
            26944 => new WeatheredCopperChestBlock(Identifier, Type.Left, Direction.North, false),
            26945 => new WeatheredCopperChestBlock(Identifier, Type.Right, Direction.North, true),
            26946 => new WeatheredCopperChestBlock(Identifier, Type.Right, Direction.North, false),
            26947 => new WeatheredCopperChestBlock(Identifier, Type.Single, Direction.South, true),
            26948 => new WeatheredCopperChestBlock(Identifier, Type.Single, Direction.South, false),
            26949 => new WeatheredCopperChestBlock(Identifier, Type.Left, Direction.South, true),
            26950 => new WeatheredCopperChestBlock(Identifier, Type.Left, Direction.South, false),
            26951 => new WeatheredCopperChestBlock(Identifier, Type.Right, Direction.South, true),
            26952 => new WeatheredCopperChestBlock(Identifier, Type.Right, Direction.South, false),
            26953 => new WeatheredCopperChestBlock(Identifier, Type.Single, Direction.West, true),
            26954 => new WeatheredCopperChestBlock(Identifier, Type.Single, Direction.West, false),
            26955 => new WeatheredCopperChestBlock(Identifier, Type.Left, Direction.West, true),
            26956 => new WeatheredCopperChestBlock(Identifier, Type.Left, Direction.West, false),
            26957 => new WeatheredCopperChestBlock(Identifier, Type.Right, Direction.West, true),
            26958 => new WeatheredCopperChestBlock(Identifier, Type.Right, Direction.West, false),
            26959 => new WeatheredCopperChestBlock(Identifier, Type.Single, Direction.East, true),
            26960 => new WeatheredCopperChestBlock(Identifier, Type.Single, Direction.East, false),
            26961 => new WeatheredCopperChestBlock(Identifier, Type.Left, Direction.East, true),
            26962 => new WeatheredCopperChestBlock(Identifier, Type.Left, Direction.East, false),
            26963 => new WeatheredCopperChestBlock(Identifier, Type.Right, Direction.East, true),
            26964 => new WeatheredCopperChestBlock(Identifier, Type.Right, Direction.East, false),
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
