using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SpruceShelfBlock(Identifier Identifier, Direction Facing, bool Powered, SpruceShelfBlock.SideChain SideChainValue, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:shelf";
    public int ProtocolId => 189;
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
    public Identifier? Item => "minecraft:spruce_shelf";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 13;
    public string TranslationKey => "block.minecraft.spruce_shelf";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3039,
                            false => 3040,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3041,
                            false => 3042,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3043,
                            false => 3044,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3045,
                            false => 3046,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3047,
                            false => 3048,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3049,
                            false => 3050,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3051,
                            false => 3052,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3053,
                            false => 3054,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3055,
                            false => 3056,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3057,
                            false => 3058,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3059,
                            false => 3060,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3061,
                            false => 3062,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3063,
                            false => 3064,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3065,
                            false => 3066,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3067,
                            false => 3068,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3069,
                            false => 3070,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3071,
                            false => 3072,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3073,
                            false => 3074,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3075,
                            false => 3076,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3077,
                            false => 3078,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3079,
                            false => 3080,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3081,
                            false => 3082,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3083,
                            false => 3084,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3085,
                            false => 3086,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3087,
                            false => 3088,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3089,
                            false => 3090,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3091,
                            false => 3092,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3093,
                            false => 3094,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3095,
                            false => 3096,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3097,
                            false => 3098,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3099,
                            false => 3100,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3101,
                            false => 3102,
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
            3039 => new SpruceShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            3040 => new SpruceShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            3041 => new SpruceShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            3042 => new SpruceShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            3043 => new SpruceShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            3044 => new SpruceShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            3045 => new SpruceShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            3046 => new SpruceShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            3047 => new SpruceShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            3048 => new SpruceShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            3049 => new SpruceShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            3050 => new SpruceShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            3051 => new SpruceShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            3052 => new SpruceShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            3053 => new SpruceShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            3054 => new SpruceShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            3055 => new SpruceShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            3056 => new SpruceShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            3057 => new SpruceShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            3058 => new SpruceShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            3059 => new SpruceShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            3060 => new SpruceShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            3061 => new SpruceShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            3062 => new SpruceShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            3063 => new SpruceShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            3064 => new SpruceShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            3065 => new SpruceShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            3066 => new SpruceShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            3067 => new SpruceShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            3068 => new SpruceShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            3069 => new SpruceShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            3070 => new SpruceShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            3071 => new SpruceShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            3072 => new SpruceShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            3073 => new SpruceShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            3074 => new SpruceShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            3075 => new SpruceShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            3076 => new SpruceShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            3077 => new SpruceShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            3078 => new SpruceShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            3079 => new SpruceShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            3080 => new SpruceShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            3081 => new SpruceShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            3082 => new SpruceShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            3083 => new SpruceShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            3084 => new SpruceShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            3085 => new SpruceShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            3086 => new SpruceShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            3087 => new SpruceShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            3088 => new SpruceShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            3089 => new SpruceShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            3090 => new SpruceShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            3091 => new SpruceShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            3092 => new SpruceShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            3093 => new SpruceShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            3094 => new SpruceShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            3095 => new SpruceShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            3096 => new SpruceShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            3097 => new SpruceShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            3098 => new SpruceShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            3099 => new SpruceShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            3100 => new SpruceShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            3101 => new SpruceShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            3102 => new SpruceShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Powered = properties.ChildrenMap.ContainsKey("powered") ? properties["powered"].GetString() == "true" : Powered,
            SideChainValue = properties.ChildrenMap.ContainsKey("side_chain") ? SideChainFromString(properties["side_chain"].GetString()) : SideChainValue,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("facing", Facing.ToName()),
            new StringTag("powered", Powered.ToString().ToLower()),
            new StringTag("side_chain", SideChainToName(SideChainValue)),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
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
