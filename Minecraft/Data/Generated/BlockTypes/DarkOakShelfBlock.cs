using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DarkOakShelfBlock(Identifier Identifier, Direction Facing, bool Powered, DarkOakShelfBlock.SideChain SideChainValue, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:shelf";
    public int ProtocolId => 184;
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
    public Identifier? Item => "minecraft:dark_oak_shelf";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 26;
    public string TranslationKey => "block.minecraft.dark_oak_shelf";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2719,
                            false => 2720,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2721,
                            false => 2722,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2723,
                            false => 2724,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2725,
                            false => 2726,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2727,
                            false => 2728,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2729,
                            false => 2730,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2731,
                            false => 2732,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2733,
                            false => 2734,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2735,
                            false => 2736,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2737,
                            false => 2738,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2739,
                            false => 2740,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2741,
                            false => 2742,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2743,
                            false => 2744,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2745,
                            false => 2746,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2747,
                            false => 2748,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2749,
                            false => 2750,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2751,
                            false => 2752,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2753,
                            false => 2754,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2755,
                            false => 2756,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2757,
                            false => 2758,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2759,
                            false => 2760,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2761,
                            false => 2762,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2763,
                            false => 2764,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2765,
                            false => 2766,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2767,
                            false => 2768,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2769,
                            false => 2770,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2771,
                            false => 2772,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2773,
                            false => 2774,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2775,
                            false => 2776,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2777,
                            false => 2778,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2779,
                            false => 2780,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2781,
                            false => 2782,
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
            2719 => new DarkOakShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            2720 => new DarkOakShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            2721 => new DarkOakShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            2722 => new DarkOakShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            2723 => new DarkOakShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            2724 => new DarkOakShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            2725 => new DarkOakShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            2726 => new DarkOakShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            2727 => new DarkOakShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            2728 => new DarkOakShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            2729 => new DarkOakShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            2730 => new DarkOakShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            2731 => new DarkOakShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            2732 => new DarkOakShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            2733 => new DarkOakShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            2734 => new DarkOakShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            2735 => new DarkOakShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            2736 => new DarkOakShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            2737 => new DarkOakShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            2738 => new DarkOakShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            2739 => new DarkOakShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            2740 => new DarkOakShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            2741 => new DarkOakShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            2742 => new DarkOakShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            2743 => new DarkOakShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            2744 => new DarkOakShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            2745 => new DarkOakShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            2746 => new DarkOakShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            2747 => new DarkOakShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            2748 => new DarkOakShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            2749 => new DarkOakShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            2750 => new DarkOakShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            2751 => new DarkOakShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            2752 => new DarkOakShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            2753 => new DarkOakShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            2754 => new DarkOakShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            2755 => new DarkOakShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            2756 => new DarkOakShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            2757 => new DarkOakShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            2758 => new DarkOakShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            2759 => new DarkOakShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            2760 => new DarkOakShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            2761 => new DarkOakShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            2762 => new DarkOakShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            2763 => new DarkOakShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            2764 => new DarkOakShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            2765 => new DarkOakShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            2766 => new DarkOakShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            2767 => new DarkOakShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            2768 => new DarkOakShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            2769 => new DarkOakShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            2770 => new DarkOakShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            2771 => new DarkOakShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            2772 => new DarkOakShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            2773 => new DarkOakShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            2774 => new DarkOakShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            2775 => new DarkOakShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            2776 => new DarkOakShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            2777 => new DarkOakShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            2778 => new DarkOakShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            2779 => new DarkOakShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            2780 => new DarkOakShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            2781 => new DarkOakShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            2782 => new DarkOakShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
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
