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
    public int ProtocolId => 1080;
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
                        true => 26917,
                        false => 26918,
                    },
                    Direction.South => Waterlogged switch {
                        true => 26923,
                        false => 26924,
                    },
                    Direction.West => Waterlogged switch {
                        true => 26929,
                        false => 26930,
                    },
                    Direction.East => Waterlogged switch {
                        true => 26935,
                        false => 26936,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Left => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 26919,
                        false => 26920,
                    },
                    Direction.South => Waterlogged switch {
                        true => 26925,
                        false => 26926,
                    },
                    Direction.West => Waterlogged switch {
                        true => 26931,
                        false => 26932,
                    },
                    Direction.East => Waterlogged switch {
                        true => 26937,
                        false => 26938,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Right => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 26921,
                        false => 26922,
                    },
                    Direction.South => Waterlogged switch {
                        true => 26927,
                        false => 26928,
                    },
                    Direction.West => Waterlogged switch {
                        true => 26933,
                        false => 26934,
                    },
                    Direction.East => Waterlogged switch {
                        true => 26939,
                        false => 26940,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(TypeValue), TypeValue, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            26917 => new ExposedCopperChestBlock(Identifier, Type.Single, Direction.North, true),
            26918 => new ExposedCopperChestBlock(Identifier, Type.Single, Direction.North, false),
            26919 => new ExposedCopperChestBlock(Identifier, Type.Left, Direction.North, true),
            26920 => new ExposedCopperChestBlock(Identifier, Type.Left, Direction.North, false),
            26921 => new ExposedCopperChestBlock(Identifier, Type.Right, Direction.North, true),
            26922 => new ExposedCopperChestBlock(Identifier, Type.Right, Direction.North, false),
            26923 => new ExposedCopperChestBlock(Identifier, Type.Single, Direction.South, true),
            26924 => new ExposedCopperChestBlock(Identifier, Type.Single, Direction.South, false),
            26925 => new ExposedCopperChestBlock(Identifier, Type.Left, Direction.South, true),
            26926 => new ExposedCopperChestBlock(Identifier, Type.Left, Direction.South, false),
            26927 => new ExposedCopperChestBlock(Identifier, Type.Right, Direction.South, true),
            26928 => new ExposedCopperChestBlock(Identifier, Type.Right, Direction.South, false),
            26929 => new ExposedCopperChestBlock(Identifier, Type.Single, Direction.West, true),
            26930 => new ExposedCopperChestBlock(Identifier, Type.Single, Direction.West, false),
            26931 => new ExposedCopperChestBlock(Identifier, Type.Left, Direction.West, true),
            26932 => new ExposedCopperChestBlock(Identifier, Type.Left, Direction.West, false),
            26933 => new ExposedCopperChestBlock(Identifier, Type.Right, Direction.West, true),
            26934 => new ExposedCopperChestBlock(Identifier, Type.Right, Direction.West, false),
            26935 => new ExposedCopperChestBlock(Identifier, Type.Single, Direction.East, true),
            26936 => new ExposedCopperChestBlock(Identifier, Type.Single, Direction.East, false),
            26937 => new ExposedCopperChestBlock(Identifier, Type.Left, Direction.East, true),
            26938 => new ExposedCopperChestBlock(Identifier, Type.Left, Direction.East, false),
            26939 => new ExposedCopperChestBlock(Identifier, Type.Right, Direction.East, true),
            26940 => new ExposedCopperChestBlock(Identifier, Type.Right, Direction.East, false),
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
