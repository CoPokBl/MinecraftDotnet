using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BirchShelfBlock(Identifier Identifier, Direction Facing, bool Powered, BirchShelfBlock.SideChain SideChainValue, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:shelf";
    public int ProtocolId => 181;
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
    public Identifier? Item => "minecraft:birch_shelf";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 2;
    public string TranslationKey => "block.minecraft.birch_shelf";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2527,
                            false => 2528,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2529,
                            false => 2530,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2531,
                            false => 2532,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2533,
                            false => 2534,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2535,
                            false => 2536,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2537,
                            false => 2538,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2539,
                            false => 2540,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2541,
                            false => 2542,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2543,
                            false => 2544,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2545,
                            false => 2546,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2547,
                            false => 2548,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2549,
                            false => 2550,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2551,
                            false => 2552,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2553,
                            false => 2554,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2555,
                            false => 2556,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2557,
                            false => 2558,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2559,
                            false => 2560,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2561,
                            false => 2562,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2563,
                            false => 2564,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2565,
                            false => 2566,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2567,
                            false => 2568,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2569,
                            false => 2570,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2571,
                            false => 2572,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2573,
                            false => 2574,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2575,
                            false => 2576,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2577,
                            false => 2578,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2579,
                            false => 2580,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2581,
                            false => 2582,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2583,
                            false => 2584,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2585,
                            false => 2586,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2587,
                            false => 2588,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2589,
                            false => 2590,
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
            2527 => new BirchShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            2528 => new BirchShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            2529 => new BirchShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            2530 => new BirchShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            2531 => new BirchShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            2532 => new BirchShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            2533 => new BirchShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            2534 => new BirchShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            2535 => new BirchShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            2536 => new BirchShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            2537 => new BirchShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            2538 => new BirchShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            2539 => new BirchShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            2540 => new BirchShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            2541 => new BirchShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            2542 => new BirchShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            2543 => new BirchShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            2544 => new BirchShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            2545 => new BirchShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            2546 => new BirchShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            2547 => new BirchShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            2548 => new BirchShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            2549 => new BirchShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            2550 => new BirchShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            2551 => new BirchShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            2552 => new BirchShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            2553 => new BirchShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            2554 => new BirchShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            2555 => new BirchShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            2556 => new BirchShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            2557 => new BirchShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            2558 => new BirchShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            2559 => new BirchShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            2560 => new BirchShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            2561 => new BirchShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            2562 => new BirchShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            2563 => new BirchShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            2564 => new BirchShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            2565 => new BirchShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            2566 => new BirchShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            2567 => new BirchShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            2568 => new BirchShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            2569 => new BirchShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            2570 => new BirchShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            2571 => new BirchShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            2572 => new BirchShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            2573 => new BirchShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            2574 => new BirchShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            2575 => new BirchShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            2576 => new BirchShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            2577 => new BirchShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            2578 => new BirchShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            2579 => new BirchShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            2580 => new BirchShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            2581 => new BirchShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            2582 => new BirchShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            2583 => new BirchShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            2584 => new BirchShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            2585 => new BirchShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            2586 => new BirchShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            2587 => new BirchShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            2588 => new BirchShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            2589 => new BirchShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            2590 => new BirchShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
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
