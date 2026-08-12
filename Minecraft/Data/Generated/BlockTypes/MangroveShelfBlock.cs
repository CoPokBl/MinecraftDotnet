using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MangroveShelfBlock(Identifier Identifier, Direction Facing, bool Powered, MangroveShelfBlock.SideChain SideChainValue, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:shelf";
    public double Hardness => 2;
    public double ExplosionResistance => 3;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "shelf";
    public Identifier? BlockEntity => "minecraft:shelf";
    public Identifier? Item => "minecraft:mangrove_shelf";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 28;
    public string TranslationKey => "block.minecraft.mangrove_shelf";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3048,
                            false => 3049,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3050,
                            false => 3051,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3052,
                            false => 3053,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3054,
                            false => 3055,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3056,
                            false => 3057,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3058,
                            false => 3059,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3060,
                            false => 3061,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3062,
                            false => 3063,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3064,
                            false => 3065,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3066,
                            false => 3067,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3068,
                            false => 3069,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3070,
                            false => 3071,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3072,
                            false => 3073,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3074,
                            false => 3075,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3076,
                            false => 3077,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3078,
                            false => 3079,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3080,
                            false => 3081,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3082,
                            false => 3083,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3084,
                            false => 3085,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3086,
                            false => 3087,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3088,
                            false => 3089,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3090,
                            false => 3091,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3092,
                            false => 3093,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3094,
                            false => 3095,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3096,
                            false => 3097,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3098,
                            false => 3099,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3100,
                            false => 3101,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3102,
                            false => 3103,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3104,
                            false => 3105,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3106,
                            false => 3107,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3108,
                            false => 3109,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3110,
                            false => 3111,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            3048 => new MangroveShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            3049 => new MangroveShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            3050 => new MangroveShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            3051 => new MangroveShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            3052 => new MangroveShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            3053 => new MangroveShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            3054 => new MangroveShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            3055 => new MangroveShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            3056 => new MangroveShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            3057 => new MangroveShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            3058 => new MangroveShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            3059 => new MangroveShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            3060 => new MangroveShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            3061 => new MangroveShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            3062 => new MangroveShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            3063 => new MangroveShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            3064 => new MangroveShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            3065 => new MangroveShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            3066 => new MangroveShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            3067 => new MangroveShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            3068 => new MangroveShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            3069 => new MangroveShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            3070 => new MangroveShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            3071 => new MangroveShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            3072 => new MangroveShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            3073 => new MangroveShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            3074 => new MangroveShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            3075 => new MangroveShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            3076 => new MangroveShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            3077 => new MangroveShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            3078 => new MangroveShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            3079 => new MangroveShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            3080 => new MangroveShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            3081 => new MangroveShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            3082 => new MangroveShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            3083 => new MangroveShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            3084 => new MangroveShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            3085 => new MangroveShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            3086 => new MangroveShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            3087 => new MangroveShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            3088 => new MangroveShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            3089 => new MangroveShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            3090 => new MangroveShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            3091 => new MangroveShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            3092 => new MangroveShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            3093 => new MangroveShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            3094 => new MangroveShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            3095 => new MangroveShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            3096 => new MangroveShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            3097 => new MangroveShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            3098 => new MangroveShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            3099 => new MangroveShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            3100 => new MangroveShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            3101 => new MangroveShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            3102 => new MangroveShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            3103 => new MangroveShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            3104 => new MangroveShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            3105 => new MangroveShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            3106 => new MangroveShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            3107 => new MangroveShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            3108 => new MangroveShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            3109 => new MangroveShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            3110 => new MangroveShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            3111 => new MangroveShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
            SideChainValue = properties.Contains("side_chain") ? SideChainFromString(properties["side_chain"].GetString()) : SideChainValue,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("powered", new StringTag(Powered.ToString().ToLower())),
            ("side_chain", new StringTag(SideChainToName(SideChainValue))),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
    public enum SideChain {
        Unconnected,
        Right,
        Center,
        Left,
    }

    public static SideChain SideChainFromString(string value) {
        return value switch {
            "unconnected" => SideChain.Unconnected,
            "right" => SideChain.Right,
            "center" => SideChain.Center,
            "left" => SideChain.Left,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for SideChain.")
        };
    }

    public static string SideChainToName(SideChain value) {
        return value switch {
            SideChain.Unconnected => "unconnected",
            SideChain.Right => "right",
            SideChain.Center => "center",
            SideChain.Left => "left",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown SideChain value.")
        };
    }
}
