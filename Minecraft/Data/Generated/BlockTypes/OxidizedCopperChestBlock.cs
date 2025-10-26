using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OxidizedCopperChestBlock(Identifier Identifier, OxidizedCopperChestBlock.Type TypeValue, Direction Facing, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:weathering_copper_chest";
    public int ProtocolId => 1082;
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
    public Identifier? Item => "minecraft:oxidized_copper_chest";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 55;
    public string TranslationKey => "block.minecraft.oxidized_copper_chest";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return TypeValue switch {
                Type.Single => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 26965,
                        false => 26966,
                    },
                    Direction.South => Waterlogged switch {
                        true => 26971,
                        false => 26972,
                    },
                    Direction.West => Waterlogged switch {
                        true => 26977,
                        false => 26978,
                    },
                    Direction.East => Waterlogged switch {
                        true => 26983,
                        false => 26984,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Left => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 26967,
                        false => 26968,
                    },
                    Direction.South => Waterlogged switch {
                        true => 26973,
                        false => 26974,
                    },
                    Direction.West => Waterlogged switch {
                        true => 26979,
                        false => 26980,
                    },
                    Direction.East => Waterlogged switch {
                        true => 26985,
                        false => 26986,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Right => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 26969,
                        false => 26970,
                    },
                    Direction.South => Waterlogged switch {
                        true => 26975,
                        false => 26976,
                    },
                    Direction.West => Waterlogged switch {
                        true => 26981,
                        false => 26982,
                    },
                    Direction.East => Waterlogged switch {
                        true => 26987,
                        false => 26988,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(TypeValue), TypeValue, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            26965 => new OxidizedCopperChestBlock(Identifier, Type.Single, Direction.North, true),
            26966 => new OxidizedCopperChestBlock(Identifier, Type.Single, Direction.North, false),
            26967 => new OxidizedCopperChestBlock(Identifier, Type.Left, Direction.North, true),
            26968 => new OxidizedCopperChestBlock(Identifier, Type.Left, Direction.North, false),
            26969 => new OxidizedCopperChestBlock(Identifier, Type.Right, Direction.North, true),
            26970 => new OxidizedCopperChestBlock(Identifier, Type.Right, Direction.North, false),
            26971 => new OxidizedCopperChestBlock(Identifier, Type.Single, Direction.South, true),
            26972 => new OxidizedCopperChestBlock(Identifier, Type.Single, Direction.South, false),
            26973 => new OxidizedCopperChestBlock(Identifier, Type.Left, Direction.South, true),
            26974 => new OxidizedCopperChestBlock(Identifier, Type.Left, Direction.South, false),
            26975 => new OxidizedCopperChestBlock(Identifier, Type.Right, Direction.South, true),
            26976 => new OxidizedCopperChestBlock(Identifier, Type.Right, Direction.South, false),
            26977 => new OxidizedCopperChestBlock(Identifier, Type.Single, Direction.West, true),
            26978 => new OxidizedCopperChestBlock(Identifier, Type.Single, Direction.West, false),
            26979 => new OxidizedCopperChestBlock(Identifier, Type.Left, Direction.West, true),
            26980 => new OxidizedCopperChestBlock(Identifier, Type.Left, Direction.West, false),
            26981 => new OxidizedCopperChestBlock(Identifier, Type.Right, Direction.West, true),
            26982 => new OxidizedCopperChestBlock(Identifier, Type.Right, Direction.West, false),
            26983 => new OxidizedCopperChestBlock(Identifier, Type.Single, Direction.East, true),
            26984 => new OxidizedCopperChestBlock(Identifier, Type.Single, Direction.East, false),
            26985 => new OxidizedCopperChestBlock(Identifier, Type.Left, Direction.East, true),
            26986 => new OxidizedCopperChestBlock(Identifier, Type.Left, Direction.East, false),
            26987 => new OxidizedCopperChestBlock(Identifier, Type.Right, Direction.East, true),
            26988 => new OxidizedCopperChestBlock(Identifier, Type.Right, Direction.East, false),
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
