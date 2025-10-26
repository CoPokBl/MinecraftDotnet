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
    public int ProtocolId => 1083;
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
                        true => 26989,
                        false => 26990,
                    },
                    Direction.South => Waterlogged switch {
                        true => 26995,
                        false => 26996,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27001,
                        false => 27002,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27007,
                        false => 27008,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Left => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 26991,
                        false => 26992,
                    },
                    Direction.South => Waterlogged switch {
                        true => 26997,
                        false => 26998,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27003,
                        false => 27004,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27009,
                        false => 27010,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Right => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 26993,
                        false => 26994,
                    },
                    Direction.South => Waterlogged switch {
                        true => 26999,
                        false => 27000,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27005,
                        false => 27006,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27011,
                        false => 27012,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(TypeValue), TypeValue, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            26989 => new WaxedCopperChestBlock(Identifier, Type.Single, Direction.North, true),
            26990 => new WaxedCopperChestBlock(Identifier, Type.Single, Direction.North, false),
            26991 => new WaxedCopperChestBlock(Identifier, Type.Left, Direction.North, true),
            26992 => new WaxedCopperChestBlock(Identifier, Type.Left, Direction.North, false),
            26993 => new WaxedCopperChestBlock(Identifier, Type.Right, Direction.North, true),
            26994 => new WaxedCopperChestBlock(Identifier, Type.Right, Direction.North, false),
            26995 => new WaxedCopperChestBlock(Identifier, Type.Single, Direction.South, true),
            26996 => new WaxedCopperChestBlock(Identifier, Type.Single, Direction.South, false),
            26997 => new WaxedCopperChestBlock(Identifier, Type.Left, Direction.South, true),
            26998 => new WaxedCopperChestBlock(Identifier, Type.Left, Direction.South, false),
            26999 => new WaxedCopperChestBlock(Identifier, Type.Right, Direction.South, true),
            27000 => new WaxedCopperChestBlock(Identifier, Type.Right, Direction.South, false),
            27001 => new WaxedCopperChestBlock(Identifier, Type.Single, Direction.West, true),
            27002 => new WaxedCopperChestBlock(Identifier, Type.Single, Direction.West, false),
            27003 => new WaxedCopperChestBlock(Identifier, Type.Left, Direction.West, true),
            27004 => new WaxedCopperChestBlock(Identifier, Type.Left, Direction.West, false),
            27005 => new WaxedCopperChestBlock(Identifier, Type.Right, Direction.West, true),
            27006 => new WaxedCopperChestBlock(Identifier, Type.Right, Direction.West, false),
            27007 => new WaxedCopperChestBlock(Identifier, Type.Single, Direction.East, true),
            27008 => new WaxedCopperChestBlock(Identifier, Type.Single, Direction.East, false),
            27009 => new WaxedCopperChestBlock(Identifier, Type.Left, Direction.East, true),
            27010 => new WaxedCopperChestBlock(Identifier, Type.Left, Direction.East, false),
            27011 => new WaxedCopperChestBlock(Identifier, Type.Right, Direction.East, true),
            27012 => new WaxedCopperChestBlock(Identifier, Type.Right, Direction.East, false),
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
