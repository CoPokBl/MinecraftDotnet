using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record JungleShelfBlock(Identifier Identifier, Direction Facing, bool Powered, JungleShelfBlock.SideChain SideChainValue, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:shelf";
    public int ProtocolId => 185;
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
    public Identifier? Item => "minecraft:jungle_shelf";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 10;
    public string TranslationKey => "block.minecraft.jungle_shelf";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2783,
                            false => 2784,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2785,
                            false => 2786,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2787,
                            false => 2788,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2789,
                            false => 2790,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2791,
                            false => 2792,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2793,
                            false => 2794,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2795,
                            false => 2796,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2797,
                            false => 2798,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2799,
                            false => 2800,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2801,
                            false => 2802,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2803,
                            false => 2804,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2805,
                            false => 2806,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2807,
                            false => 2808,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2809,
                            false => 2810,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2811,
                            false => 2812,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2813,
                            false => 2814,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2815,
                            false => 2816,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2817,
                            false => 2818,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2819,
                            false => 2820,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2821,
                            false => 2822,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2823,
                            false => 2824,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2825,
                            false => 2826,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2827,
                            false => 2828,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2829,
                            false => 2830,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2831,
                            false => 2832,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2833,
                            false => 2834,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2835,
                            false => 2836,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2837,
                            false => 2838,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2839,
                            false => 2840,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2841,
                            false => 2842,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2843,
                            false => 2844,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2845,
                            false => 2846,
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
            2783 => new JungleShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            2784 => new JungleShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            2785 => new JungleShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            2786 => new JungleShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            2787 => new JungleShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            2788 => new JungleShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            2789 => new JungleShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            2790 => new JungleShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            2791 => new JungleShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            2792 => new JungleShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            2793 => new JungleShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            2794 => new JungleShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            2795 => new JungleShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            2796 => new JungleShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            2797 => new JungleShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            2798 => new JungleShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            2799 => new JungleShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            2800 => new JungleShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            2801 => new JungleShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            2802 => new JungleShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            2803 => new JungleShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            2804 => new JungleShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            2805 => new JungleShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            2806 => new JungleShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            2807 => new JungleShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            2808 => new JungleShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            2809 => new JungleShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            2810 => new JungleShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            2811 => new JungleShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            2812 => new JungleShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            2813 => new JungleShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            2814 => new JungleShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            2815 => new JungleShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            2816 => new JungleShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            2817 => new JungleShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            2818 => new JungleShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            2819 => new JungleShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            2820 => new JungleShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            2821 => new JungleShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            2822 => new JungleShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            2823 => new JungleShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            2824 => new JungleShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            2825 => new JungleShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            2826 => new JungleShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            2827 => new JungleShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            2828 => new JungleShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            2829 => new JungleShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            2830 => new JungleShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            2831 => new JungleShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            2832 => new JungleShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            2833 => new JungleShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            2834 => new JungleShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            2835 => new JungleShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            2836 => new JungleShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            2837 => new JungleShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            2838 => new JungleShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            2839 => new JungleShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            2840 => new JungleShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            2841 => new JungleShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            2842 => new JungleShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            2843 => new JungleShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            2844 => new JungleShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            2845 => new JungleShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            2846 => new JungleShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
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
