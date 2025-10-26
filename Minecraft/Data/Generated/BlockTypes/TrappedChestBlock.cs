using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record TrappedChestBlock(Identifier Identifier, TrappedChestBlock.Type TypeValue, Direction Facing, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:trapped_chest";
    public int ProtocolId => 468;
    public double Hardness => 2.5;
    public double ExplosionResistance => 2.5;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "wood";
    public Identifier? BlockEntity => "minecraft:trapped_chest";
    public Identifier? Item => "minecraft:trapped_chest";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => true;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 13;
    public string TranslationKey => "block.minecraft.trapped_chest";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return TypeValue switch {
                Type.Single => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 11005,
                        false => 11006,
                    },
                    Direction.South => Waterlogged switch {
                        true => 11011,
                        false => 11012,
                    },
                    Direction.West => Waterlogged switch {
                        true => 11017,
                        false => 11018,
                    },
                    Direction.East => Waterlogged switch {
                        true => 11023,
                        false => 11024,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Left => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 11007,
                        false => 11008,
                    },
                    Direction.South => Waterlogged switch {
                        true => 11013,
                        false => 11014,
                    },
                    Direction.West => Waterlogged switch {
                        true => 11019,
                        false => 11020,
                    },
                    Direction.East => Waterlogged switch {
                        true => 11025,
                        false => 11026,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Right => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 11009,
                        false => 11010,
                    },
                    Direction.South => Waterlogged switch {
                        true => 11015,
                        false => 11016,
                    },
                    Direction.West => Waterlogged switch {
                        true => 11021,
                        false => 11022,
                    },
                    Direction.East => Waterlogged switch {
                        true => 11027,
                        false => 11028,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(TypeValue), TypeValue, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11005 => new TrappedChestBlock(Identifier, Type.Single, Direction.North, true),
            11006 => new TrappedChestBlock(Identifier, Type.Single, Direction.North, false),
            11007 => new TrappedChestBlock(Identifier, Type.Left, Direction.North, true),
            11008 => new TrappedChestBlock(Identifier, Type.Left, Direction.North, false),
            11009 => new TrappedChestBlock(Identifier, Type.Right, Direction.North, true),
            11010 => new TrappedChestBlock(Identifier, Type.Right, Direction.North, false),
            11011 => new TrappedChestBlock(Identifier, Type.Single, Direction.South, true),
            11012 => new TrappedChestBlock(Identifier, Type.Single, Direction.South, false),
            11013 => new TrappedChestBlock(Identifier, Type.Left, Direction.South, true),
            11014 => new TrappedChestBlock(Identifier, Type.Left, Direction.South, false),
            11015 => new TrappedChestBlock(Identifier, Type.Right, Direction.South, true),
            11016 => new TrappedChestBlock(Identifier, Type.Right, Direction.South, false),
            11017 => new TrappedChestBlock(Identifier, Type.Single, Direction.West, true),
            11018 => new TrappedChestBlock(Identifier, Type.Single, Direction.West, false),
            11019 => new TrappedChestBlock(Identifier, Type.Left, Direction.West, true),
            11020 => new TrappedChestBlock(Identifier, Type.Left, Direction.West, false),
            11021 => new TrappedChestBlock(Identifier, Type.Right, Direction.West, true),
            11022 => new TrappedChestBlock(Identifier, Type.Right, Direction.West, false),
            11023 => new TrappedChestBlock(Identifier, Type.Single, Direction.East, true),
            11024 => new TrappedChestBlock(Identifier, Type.Single, Direction.East, false),
            11025 => new TrappedChestBlock(Identifier, Type.Left, Direction.East, true),
            11026 => new TrappedChestBlock(Identifier, Type.Left, Direction.East, false),
            11027 => new TrappedChestBlock(Identifier, Type.Right, Direction.East, true),
            11028 => new TrappedChestBlock(Identifier, Type.Right, Direction.East, false),
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
