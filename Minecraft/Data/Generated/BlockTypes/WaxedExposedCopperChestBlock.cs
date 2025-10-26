using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedExposedCopperChestBlock(Identifier Identifier, WaxedExposedCopperChestBlock.Type TypeValue, Direction Facing, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:copper_chest";
    public int ProtocolId => 1084;
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
    public Identifier? Item => "minecraft:waxed_exposed_copper_chest";
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
    public string TranslationKey => "block.minecraft.waxed_exposed_copper_chest";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return TypeValue switch {
                Type.Single => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27013,
                        false => 27014,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27019,
                        false => 27020,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27025,
                        false => 27026,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27031,
                        false => 27032,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Left => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27015,
                        false => 27016,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27021,
                        false => 27022,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27027,
                        false => 27028,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27033,
                        false => 27034,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Right => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27017,
                        false => 27018,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27023,
                        false => 27024,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27029,
                        false => 27030,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27035,
                        false => 27036,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(TypeValue), TypeValue, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27013 => new WaxedExposedCopperChestBlock(Identifier, Type.Single, Direction.North, true),
            27014 => new WaxedExposedCopperChestBlock(Identifier, Type.Single, Direction.North, false),
            27015 => new WaxedExposedCopperChestBlock(Identifier, Type.Left, Direction.North, true),
            27016 => new WaxedExposedCopperChestBlock(Identifier, Type.Left, Direction.North, false),
            27017 => new WaxedExposedCopperChestBlock(Identifier, Type.Right, Direction.North, true),
            27018 => new WaxedExposedCopperChestBlock(Identifier, Type.Right, Direction.North, false),
            27019 => new WaxedExposedCopperChestBlock(Identifier, Type.Single, Direction.South, true),
            27020 => new WaxedExposedCopperChestBlock(Identifier, Type.Single, Direction.South, false),
            27021 => new WaxedExposedCopperChestBlock(Identifier, Type.Left, Direction.South, true),
            27022 => new WaxedExposedCopperChestBlock(Identifier, Type.Left, Direction.South, false),
            27023 => new WaxedExposedCopperChestBlock(Identifier, Type.Right, Direction.South, true),
            27024 => new WaxedExposedCopperChestBlock(Identifier, Type.Right, Direction.South, false),
            27025 => new WaxedExposedCopperChestBlock(Identifier, Type.Single, Direction.West, true),
            27026 => new WaxedExposedCopperChestBlock(Identifier, Type.Single, Direction.West, false),
            27027 => new WaxedExposedCopperChestBlock(Identifier, Type.Left, Direction.West, true),
            27028 => new WaxedExposedCopperChestBlock(Identifier, Type.Left, Direction.West, false),
            27029 => new WaxedExposedCopperChestBlock(Identifier, Type.Right, Direction.West, true),
            27030 => new WaxedExposedCopperChestBlock(Identifier, Type.Right, Direction.West, false),
            27031 => new WaxedExposedCopperChestBlock(Identifier, Type.Single, Direction.East, true),
            27032 => new WaxedExposedCopperChestBlock(Identifier, Type.Single, Direction.East, false),
            27033 => new WaxedExposedCopperChestBlock(Identifier, Type.Left, Direction.East, true),
            27034 => new WaxedExposedCopperChestBlock(Identifier, Type.Left, Direction.East, false),
            27035 => new WaxedExposedCopperChestBlock(Identifier, Type.Right, Direction.East, true),
            27036 => new WaxedExposedCopperChestBlock(Identifier, Type.Right, Direction.East, false),
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
