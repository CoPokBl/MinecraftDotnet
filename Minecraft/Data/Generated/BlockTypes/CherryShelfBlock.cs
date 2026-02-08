using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CherryShelfBlock(Identifier Identifier, Direction Facing, bool Powered, CherryShelfBlock.SideChain SideChainValue, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:shelf";
    public int ProtocolId => 182;
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
    public Identifier? Item => "minecraft:cherry_shelf";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 36;
    public string TranslationKey => "block.minecraft.cherry_shelf";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2591,
                            false => 2592,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2593,
                            false => 2594,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2595,
                            false => 2596,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2597,
                            false => 2598,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2599,
                            false => 2600,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2601,
                            false => 2602,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2603,
                            false => 2604,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2605,
                            false => 2606,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2607,
                            false => 2608,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2609,
                            false => 2610,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2611,
                            false => 2612,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2613,
                            false => 2614,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2615,
                            false => 2616,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2617,
                            false => 2618,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2619,
                            false => 2620,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2621,
                            false => 2622,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2623,
                            false => 2624,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2625,
                            false => 2626,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2627,
                            false => 2628,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2629,
                            false => 2630,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2631,
                            false => 2632,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2633,
                            false => 2634,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2635,
                            false => 2636,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2637,
                            false => 2638,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2639,
                            false => 2640,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2641,
                            false => 2642,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2643,
                            false => 2644,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2645,
                            false => 2646,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2647,
                            false => 2648,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2649,
                            false => 2650,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2651,
                            false => 2652,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2653,
                            false => 2654,
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
            2591 => new CherryShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            2592 => new CherryShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            2593 => new CherryShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            2594 => new CherryShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            2595 => new CherryShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            2596 => new CherryShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            2597 => new CherryShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            2598 => new CherryShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            2599 => new CherryShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            2600 => new CherryShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            2601 => new CherryShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            2602 => new CherryShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            2603 => new CherryShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            2604 => new CherryShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            2605 => new CherryShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            2606 => new CherryShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            2607 => new CherryShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            2608 => new CherryShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            2609 => new CherryShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            2610 => new CherryShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            2611 => new CherryShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            2612 => new CherryShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            2613 => new CherryShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            2614 => new CherryShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            2615 => new CherryShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            2616 => new CherryShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            2617 => new CherryShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            2618 => new CherryShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            2619 => new CherryShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            2620 => new CherryShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            2621 => new CherryShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            2622 => new CherryShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            2623 => new CherryShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            2624 => new CherryShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            2625 => new CherryShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            2626 => new CherryShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            2627 => new CherryShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            2628 => new CherryShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            2629 => new CherryShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            2630 => new CherryShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            2631 => new CherryShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            2632 => new CherryShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            2633 => new CherryShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            2634 => new CherryShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            2635 => new CherryShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            2636 => new CherryShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            2637 => new CherryShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            2638 => new CherryShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            2639 => new CherryShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            2640 => new CherryShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            2641 => new CherryShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            2642 => new CherryShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            2643 => new CherryShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            2644 => new CherryShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            2645 => new CherryShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            2646 => new CherryShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            2647 => new CherryShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            2648 => new CherryShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            2649 => new CherryShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            2650 => new CherryShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            2651 => new CherryShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            2652 => new CherryShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            2653 => new CherryShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            2654 => new CherryShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
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
