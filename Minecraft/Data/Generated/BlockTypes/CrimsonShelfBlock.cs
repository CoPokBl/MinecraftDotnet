using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CrimsonShelfBlock(Identifier Identifier, Direction Facing, bool Powered, CrimsonShelfBlock.SideChain SideChainValue, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:shelf";
    public int ProtocolId => 183;
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
    public Identifier? Item => "minecraft:crimson_shelf";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 13;
    public string TranslationKey => "block.minecraft.crimson_shelf";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2655,
                            false => 2656,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2657,
                            false => 2658,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2659,
                            false => 2660,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2661,
                            false => 2662,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2663,
                            false => 2664,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2665,
                            false => 2666,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2667,
                            false => 2668,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2669,
                            false => 2670,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2671,
                            false => 2672,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2673,
                            false => 2674,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2675,
                            false => 2676,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2677,
                            false => 2678,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2679,
                            false => 2680,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2681,
                            false => 2682,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2683,
                            false => 2684,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2685,
                            false => 2686,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2687,
                            false => 2688,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2689,
                            false => 2690,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2691,
                            false => 2692,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2693,
                            false => 2694,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2695,
                            false => 2696,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2697,
                            false => 2698,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2699,
                            false => 2700,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2701,
                            false => 2702,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2703,
                            false => 2704,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2705,
                            false => 2706,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2707,
                            false => 2708,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2709,
                            false => 2710,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2711,
                            false => 2712,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2713,
                            false => 2714,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2715,
                            false => 2716,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2717,
                            false => 2718,
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
            2655 => new CrimsonShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            2656 => new CrimsonShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            2657 => new CrimsonShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            2658 => new CrimsonShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            2659 => new CrimsonShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            2660 => new CrimsonShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            2661 => new CrimsonShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            2662 => new CrimsonShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            2663 => new CrimsonShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            2664 => new CrimsonShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            2665 => new CrimsonShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            2666 => new CrimsonShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            2667 => new CrimsonShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            2668 => new CrimsonShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            2669 => new CrimsonShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            2670 => new CrimsonShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            2671 => new CrimsonShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            2672 => new CrimsonShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            2673 => new CrimsonShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            2674 => new CrimsonShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            2675 => new CrimsonShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            2676 => new CrimsonShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            2677 => new CrimsonShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            2678 => new CrimsonShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            2679 => new CrimsonShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            2680 => new CrimsonShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            2681 => new CrimsonShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            2682 => new CrimsonShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            2683 => new CrimsonShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            2684 => new CrimsonShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            2685 => new CrimsonShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            2686 => new CrimsonShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            2687 => new CrimsonShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            2688 => new CrimsonShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            2689 => new CrimsonShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            2690 => new CrimsonShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            2691 => new CrimsonShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            2692 => new CrimsonShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            2693 => new CrimsonShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            2694 => new CrimsonShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            2695 => new CrimsonShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            2696 => new CrimsonShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            2697 => new CrimsonShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            2698 => new CrimsonShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            2699 => new CrimsonShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            2700 => new CrimsonShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            2701 => new CrimsonShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            2702 => new CrimsonShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            2703 => new CrimsonShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            2704 => new CrimsonShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            2705 => new CrimsonShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            2706 => new CrimsonShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            2707 => new CrimsonShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            2708 => new CrimsonShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            2709 => new CrimsonShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            2710 => new CrimsonShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            2711 => new CrimsonShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            2712 => new CrimsonShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            2713 => new CrimsonShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            2714 => new CrimsonShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            2715 => new CrimsonShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            2716 => new CrimsonShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            2717 => new CrimsonShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            2718 => new CrimsonShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
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
