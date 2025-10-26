using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CopperChestBlock(Identifier Identifier, CopperChestBlock.Type TypeValue, Direction Facing, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:weathering_copper_chest";
    public int ProtocolId => 1079;
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
    public Identifier? Item => "minecraft:copper_chest";
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
    public string TranslationKey => "block.minecraft.copper_chest";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return TypeValue switch {
                Type.Single => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 26893,
                        false => 26894,
                    },
                    Direction.South => Waterlogged switch {
                        true => 26899,
                        false => 26900,
                    },
                    Direction.West => Waterlogged switch {
                        true => 26905,
                        false => 26906,
                    },
                    Direction.East => Waterlogged switch {
                        true => 26911,
                        false => 26912,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Left => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 26895,
                        false => 26896,
                    },
                    Direction.South => Waterlogged switch {
                        true => 26901,
                        false => 26902,
                    },
                    Direction.West => Waterlogged switch {
                        true => 26907,
                        false => 26908,
                    },
                    Direction.East => Waterlogged switch {
                        true => 26913,
                        false => 26914,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Right => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 26897,
                        false => 26898,
                    },
                    Direction.South => Waterlogged switch {
                        true => 26903,
                        false => 26904,
                    },
                    Direction.West => Waterlogged switch {
                        true => 26909,
                        false => 26910,
                    },
                    Direction.East => Waterlogged switch {
                        true => 26915,
                        false => 26916,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(TypeValue), TypeValue, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            26893 => new CopperChestBlock(Identifier, Type.Single, Direction.North, true),
            26894 => new CopperChestBlock(Identifier, Type.Single, Direction.North, false),
            26895 => new CopperChestBlock(Identifier, Type.Left, Direction.North, true),
            26896 => new CopperChestBlock(Identifier, Type.Left, Direction.North, false),
            26897 => new CopperChestBlock(Identifier, Type.Right, Direction.North, true),
            26898 => new CopperChestBlock(Identifier, Type.Right, Direction.North, false),
            26899 => new CopperChestBlock(Identifier, Type.Single, Direction.South, true),
            26900 => new CopperChestBlock(Identifier, Type.Single, Direction.South, false),
            26901 => new CopperChestBlock(Identifier, Type.Left, Direction.South, true),
            26902 => new CopperChestBlock(Identifier, Type.Left, Direction.South, false),
            26903 => new CopperChestBlock(Identifier, Type.Right, Direction.South, true),
            26904 => new CopperChestBlock(Identifier, Type.Right, Direction.South, false),
            26905 => new CopperChestBlock(Identifier, Type.Single, Direction.West, true),
            26906 => new CopperChestBlock(Identifier, Type.Single, Direction.West, false),
            26907 => new CopperChestBlock(Identifier, Type.Left, Direction.West, true),
            26908 => new CopperChestBlock(Identifier, Type.Left, Direction.West, false),
            26909 => new CopperChestBlock(Identifier, Type.Right, Direction.West, true),
            26910 => new CopperChestBlock(Identifier, Type.Right, Direction.West, false),
            26911 => new CopperChestBlock(Identifier, Type.Single, Direction.East, true),
            26912 => new CopperChestBlock(Identifier, Type.Single, Direction.East, false),
            26913 => new CopperChestBlock(Identifier, Type.Left, Direction.East, true),
            26914 => new CopperChestBlock(Identifier, Type.Left, Direction.East, false),
            26915 => new CopperChestBlock(Identifier, Type.Right, Direction.East, true),
            26916 => new CopperChestBlock(Identifier, Type.Right, Direction.East, false),
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
