using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record AcaciaShelfBlock(Identifier Identifier, Direction Facing, bool Powered, AcaciaShelfBlock.SideChain SideChainValue, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:shelf";
    public int ProtocolId => 179;
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
    public Identifier? Item => "minecraft:acacia_shelf";
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
    public string TranslationKey => "block.minecraft.acacia_shelf";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2399,
                            false => 2400,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2401,
                            false => 2402,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2403,
                            false => 2404,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2405,
                            false => 2406,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2407,
                            false => 2408,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2409,
                            false => 2410,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2411,
                            false => 2412,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2413,
                            false => 2414,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2415,
                            false => 2416,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2417,
                            false => 2418,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2419,
                            false => 2420,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2421,
                            false => 2422,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2423,
                            false => 2424,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2425,
                            false => 2426,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2427,
                            false => 2428,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2429,
                            false => 2430,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2431,
                            false => 2432,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2433,
                            false => 2434,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2435,
                            false => 2436,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2437,
                            false => 2438,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2439,
                            false => 2440,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2441,
                            false => 2442,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2443,
                            false => 2444,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2445,
                            false => 2446,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2447,
                            false => 2448,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2449,
                            false => 2450,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2451,
                            false => 2452,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2453,
                            false => 2454,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2455,
                            false => 2456,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2457,
                            false => 2458,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2459,
                            false => 2460,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2461,
                            false => 2462,
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
            2399 => new AcaciaShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            2400 => new AcaciaShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            2401 => new AcaciaShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            2402 => new AcaciaShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            2403 => new AcaciaShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            2404 => new AcaciaShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            2405 => new AcaciaShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            2406 => new AcaciaShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            2407 => new AcaciaShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            2408 => new AcaciaShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            2409 => new AcaciaShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            2410 => new AcaciaShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            2411 => new AcaciaShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            2412 => new AcaciaShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            2413 => new AcaciaShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            2414 => new AcaciaShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            2415 => new AcaciaShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            2416 => new AcaciaShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            2417 => new AcaciaShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            2418 => new AcaciaShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            2419 => new AcaciaShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            2420 => new AcaciaShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            2421 => new AcaciaShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            2422 => new AcaciaShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            2423 => new AcaciaShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            2424 => new AcaciaShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            2425 => new AcaciaShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            2426 => new AcaciaShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            2427 => new AcaciaShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            2428 => new AcaciaShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            2429 => new AcaciaShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            2430 => new AcaciaShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            2431 => new AcaciaShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            2432 => new AcaciaShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            2433 => new AcaciaShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            2434 => new AcaciaShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            2435 => new AcaciaShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            2436 => new AcaciaShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            2437 => new AcaciaShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            2438 => new AcaciaShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            2439 => new AcaciaShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            2440 => new AcaciaShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            2441 => new AcaciaShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            2442 => new AcaciaShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            2443 => new AcaciaShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            2444 => new AcaciaShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            2445 => new AcaciaShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            2446 => new AcaciaShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            2447 => new AcaciaShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            2448 => new AcaciaShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            2449 => new AcaciaShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            2450 => new AcaciaShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            2451 => new AcaciaShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            2452 => new AcaciaShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            2453 => new AcaciaShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            2454 => new AcaciaShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            2455 => new AcaciaShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            2456 => new AcaciaShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            2457 => new AcaciaShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            2458 => new AcaciaShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            2459 => new AcaciaShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            2460 => new AcaciaShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            2461 => new AcaciaShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            2462 => new AcaciaShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
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
