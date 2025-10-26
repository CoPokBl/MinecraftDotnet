using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BambooShelfBlock(Identifier Identifier, Direction Facing, bool Powered, BambooShelfBlock.SideChain SideChainValue, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:shelf";
    public int ProtocolId => 180;
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
    public Identifier? Item => "minecraft:bamboo_shelf";
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
    public string TranslationKey => "block.minecraft.bamboo_shelf";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2463,
                            false => 2464,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2465,
                            false => 2466,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2467,
                            false => 2468,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2469,
                            false => 2470,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2471,
                            false => 2472,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2473,
                            false => 2474,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2475,
                            false => 2476,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2477,
                            false => 2478,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2479,
                            false => 2480,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2481,
                            false => 2482,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2483,
                            false => 2484,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2485,
                            false => 2486,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2487,
                            false => 2488,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2489,
                            false => 2490,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2491,
                            false => 2492,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2493,
                            false => 2494,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2495,
                            false => 2496,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2497,
                            false => 2498,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2499,
                            false => 2500,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2501,
                            false => 2502,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2503,
                            false => 2504,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2505,
                            false => 2506,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2507,
                            false => 2508,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2509,
                            false => 2510,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2511,
                            false => 2512,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2513,
                            false => 2514,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2515,
                            false => 2516,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2517,
                            false => 2518,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2519,
                            false => 2520,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2521,
                            false => 2522,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2523,
                            false => 2524,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2525,
                            false => 2526,
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
            2463 => new BambooShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            2464 => new BambooShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            2465 => new BambooShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            2466 => new BambooShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            2467 => new BambooShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            2468 => new BambooShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            2469 => new BambooShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            2470 => new BambooShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            2471 => new BambooShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            2472 => new BambooShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            2473 => new BambooShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            2474 => new BambooShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            2475 => new BambooShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            2476 => new BambooShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            2477 => new BambooShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            2478 => new BambooShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            2479 => new BambooShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            2480 => new BambooShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            2481 => new BambooShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            2482 => new BambooShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            2483 => new BambooShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            2484 => new BambooShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            2485 => new BambooShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            2486 => new BambooShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            2487 => new BambooShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            2488 => new BambooShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            2489 => new BambooShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            2490 => new BambooShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            2491 => new BambooShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            2492 => new BambooShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            2493 => new BambooShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            2494 => new BambooShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            2495 => new BambooShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            2496 => new BambooShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            2497 => new BambooShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            2498 => new BambooShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            2499 => new BambooShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            2500 => new BambooShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            2501 => new BambooShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            2502 => new BambooShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            2503 => new BambooShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            2504 => new BambooShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            2505 => new BambooShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            2506 => new BambooShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            2507 => new BambooShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            2508 => new BambooShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            2509 => new BambooShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            2510 => new BambooShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            2511 => new BambooShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            2512 => new BambooShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            2513 => new BambooShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            2514 => new BambooShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            2515 => new BambooShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            2516 => new BambooShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            2517 => new BambooShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            2518 => new BambooShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            2519 => new BambooShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            2520 => new BambooShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            2521 => new BambooShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            2522 => new BambooShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            2523 => new BambooShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            2524 => new BambooShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            2525 => new BambooShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            2526 => new BambooShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
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
