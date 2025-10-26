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
    public int ProtocolId => 186;
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
    public int MapColorId => 13;
    public string TranslationKey => "block.minecraft.mangrove_shelf";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2847,
                            false => 2848,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2849,
                            false => 2850,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2851,
                            false => 2852,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2853,
                            false => 2854,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2855,
                            false => 2856,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2857,
                            false => 2858,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2859,
                            false => 2860,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2861,
                            false => 2862,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2863,
                            false => 2864,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2865,
                            false => 2866,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2867,
                            false => 2868,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2869,
                            false => 2870,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2871,
                            false => 2872,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2873,
                            false => 2874,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2875,
                            false => 2876,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2877,
                            false => 2878,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2879,
                            false => 2880,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2881,
                            false => 2882,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2883,
                            false => 2884,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2885,
                            false => 2886,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2887,
                            false => 2888,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2889,
                            false => 2890,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2891,
                            false => 2892,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2893,
                            false => 2894,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2895,
                            false => 2896,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2897,
                            false => 2898,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2899,
                            false => 2900,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2901,
                            false => 2902,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2903,
                            false => 2904,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2905,
                            false => 2906,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2907,
                            false => 2908,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2909,
                            false => 2910,
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
            2847 => new MangroveShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            2848 => new MangroveShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            2849 => new MangroveShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            2850 => new MangroveShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            2851 => new MangroveShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            2852 => new MangroveShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            2853 => new MangroveShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            2854 => new MangroveShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            2855 => new MangroveShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            2856 => new MangroveShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            2857 => new MangroveShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            2858 => new MangroveShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            2859 => new MangroveShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            2860 => new MangroveShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            2861 => new MangroveShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            2862 => new MangroveShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            2863 => new MangroveShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            2864 => new MangroveShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            2865 => new MangroveShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            2866 => new MangroveShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            2867 => new MangroveShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            2868 => new MangroveShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            2869 => new MangroveShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            2870 => new MangroveShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            2871 => new MangroveShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            2872 => new MangroveShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            2873 => new MangroveShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            2874 => new MangroveShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            2875 => new MangroveShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            2876 => new MangroveShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            2877 => new MangroveShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            2878 => new MangroveShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            2879 => new MangroveShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            2880 => new MangroveShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            2881 => new MangroveShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            2882 => new MangroveShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            2883 => new MangroveShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            2884 => new MangroveShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            2885 => new MangroveShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            2886 => new MangroveShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            2887 => new MangroveShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            2888 => new MangroveShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            2889 => new MangroveShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            2890 => new MangroveShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            2891 => new MangroveShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            2892 => new MangroveShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            2893 => new MangroveShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            2894 => new MangroveShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            2895 => new MangroveShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            2896 => new MangroveShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            2897 => new MangroveShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            2898 => new MangroveShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            2899 => new MangroveShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            2900 => new MangroveShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            2901 => new MangroveShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            2902 => new MangroveShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            2903 => new MangroveShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            2904 => new MangroveShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            2905 => new MangroveShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            2906 => new MangroveShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            2907 => new MangroveShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            2908 => new MangroveShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            2909 => new MangroveShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            2910 => new MangroveShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
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
