using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OakShelfBlock(Identifier Identifier, Direction Facing, bool Powered, OakShelfBlock.SideChain SideChainValue, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:shelf";
    public int ProtocolId => 187;
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
    public Identifier? Item => "minecraft:oak_shelf";
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
    public string TranslationKey => "block.minecraft.oak_shelf";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2911,
                            false => 2912,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2913,
                            false => 2914,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2915,
                            false => 2916,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2917,
                            false => 2918,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2919,
                            false => 2920,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2921,
                            false => 2922,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2923,
                            false => 2924,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2925,
                            false => 2926,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2927,
                            false => 2928,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2929,
                            false => 2930,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2931,
                            false => 2932,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2933,
                            false => 2934,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2935,
                            false => 2936,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2937,
                            false => 2938,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2939,
                            false => 2940,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2941,
                            false => 2942,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2943,
                            false => 2944,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2945,
                            false => 2946,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2947,
                            false => 2948,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2949,
                            false => 2950,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2951,
                            false => 2952,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2953,
                            false => 2954,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2955,
                            false => 2956,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2957,
                            false => 2958,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2959,
                            false => 2960,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2961,
                            false => 2962,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2963,
                            false => 2964,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2965,
                            false => 2966,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2967,
                            false => 2968,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2969,
                            false => 2970,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2971,
                            false => 2972,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2973,
                            false => 2974,
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
            2911 => new OakShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            2912 => new OakShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            2913 => new OakShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            2914 => new OakShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            2915 => new OakShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            2916 => new OakShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            2917 => new OakShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            2918 => new OakShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            2919 => new OakShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            2920 => new OakShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            2921 => new OakShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            2922 => new OakShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            2923 => new OakShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            2924 => new OakShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            2925 => new OakShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            2926 => new OakShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            2927 => new OakShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            2928 => new OakShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            2929 => new OakShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            2930 => new OakShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            2931 => new OakShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            2932 => new OakShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            2933 => new OakShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            2934 => new OakShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            2935 => new OakShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            2936 => new OakShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            2937 => new OakShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            2938 => new OakShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            2939 => new OakShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            2940 => new OakShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            2941 => new OakShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            2942 => new OakShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            2943 => new OakShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            2944 => new OakShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            2945 => new OakShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            2946 => new OakShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            2947 => new OakShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            2948 => new OakShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            2949 => new OakShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            2950 => new OakShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            2951 => new OakShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            2952 => new OakShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            2953 => new OakShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            2954 => new OakShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            2955 => new OakShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            2956 => new OakShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            2957 => new OakShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            2958 => new OakShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            2959 => new OakShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            2960 => new OakShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            2961 => new OakShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            2962 => new OakShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            2963 => new OakShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            2964 => new OakShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            2965 => new OakShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            2966 => new OakShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            2967 => new OakShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            2968 => new OakShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            2969 => new OakShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            2970 => new OakShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            2971 => new OakShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            2972 => new OakShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            2973 => new OakShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            2974 => new OakShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
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
