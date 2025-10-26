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
    public int ProtocolId => 1085;
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
                        true => 27037,
                        false => 27038,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27043,
                        false => 27044,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27049,
                        false => 27050,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27055,
                        false => 27056,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Left => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27039,
                        false => 27040,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27045,
                        false => 27046,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27051,
                        false => 27052,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27057,
                        false => 27058,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Right => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27041,
                        false => 27042,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27047,
                        false => 27048,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27053,
                        false => 27054,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27059,
                        false => 27060,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(TypeValue), TypeValue, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27037 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Single, Direction.North, true),
            27038 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Single, Direction.North, false),
            27039 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Left, Direction.North, true),
            27040 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Left, Direction.North, false),
            27041 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Right, Direction.North, true),
            27042 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Right, Direction.North, false),
            27043 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Single, Direction.South, true),
            27044 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Single, Direction.South, false),
            27045 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Left, Direction.South, true),
            27046 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Left, Direction.South, false),
            27047 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Right, Direction.South, true),
            27048 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Right, Direction.South, false),
            27049 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Single, Direction.West, true),
            27050 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Single, Direction.West, false),
            27051 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Left, Direction.West, true),
            27052 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Left, Direction.West, false),
            27053 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Right, Direction.West, true),
            27054 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Right, Direction.West, false),
            27055 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Single, Direction.East, true),
            27056 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Single, Direction.East, false),
            27057 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Left, Direction.East, true),
            27058 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Left, Direction.East, false),
            27059 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Right, Direction.East, true),
            27060 => new WaxedWeatheredCopperChestBlock(Identifier, Type.Right, Direction.East, false),
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
