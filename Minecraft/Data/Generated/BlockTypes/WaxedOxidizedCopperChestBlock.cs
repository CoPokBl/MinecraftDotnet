using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedOxidizedCopperChestBlock(Identifier Identifier, WaxedOxidizedCopperChestBlock.Type TypeValue, Direction Facing, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:copper_chest";
    public int ProtocolId => 1086;
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
    public Identifier? Item => "minecraft:waxed_oxidized_copper_chest";
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
    public string TranslationKey => "block.minecraft.waxed_oxidized_copper_chest";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return TypeValue switch {
                Type.Single => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27061,
                        false => 27062,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27067,
                        false => 27068,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27073,
                        false => 27074,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27079,
                        false => 27080,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Left => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27063,
                        false => 27064,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27069,
                        false => 27070,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27075,
                        false => 27076,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27081,
                        false => 27082,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Right => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27065,
                        false => 27066,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27071,
                        false => 27072,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27077,
                        false => 27078,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27083,
                        false => 27084,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(TypeValue), TypeValue, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27061 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Single, Direction.North, true),
            27062 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Single, Direction.North, false),
            27063 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Left, Direction.North, true),
            27064 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Left, Direction.North, false),
            27065 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Right, Direction.North, true),
            27066 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Right, Direction.North, false),
            27067 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Single, Direction.South, true),
            27068 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Single, Direction.South, false),
            27069 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Left, Direction.South, true),
            27070 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Left, Direction.South, false),
            27071 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Right, Direction.South, true),
            27072 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Right, Direction.South, false),
            27073 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Single, Direction.West, true),
            27074 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Single, Direction.West, false),
            27075 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Left, Direction.West, true),
            27076 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Left, Direction.West, false),
            27077 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Right, Direction.West, true),
            27078 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Right, Direction.West, false),
            27079 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Single, Direction.East, true),
            27080 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Single, Direction.East, false),
            27081 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Left, Direction.East, true),
            27082 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Left, Direction.East, false),
            27083 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Right, Direction.East, true),
            27084 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Right, Direction.East, false),
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
