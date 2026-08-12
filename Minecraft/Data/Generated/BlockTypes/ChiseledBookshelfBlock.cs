using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ChiseledBookshelfBlock(Identifier Identifier, Direction Facing, bool Slot0Occupied, bool Slot1Occupied, bool Slot2Occupied, bool Slot3Occupied, bool Slot4Occupied, bool Slot5Occupied) : IBlock {
    public Identifier Category => "minecraft:chiseled_book_shelf";
    public double Hardness => 1.5;
    public double ExplosionResistance => 1.5;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "chiseled_bookshelf";
    public Identifier? BlockEntity => "minecraft:chiseled_bookshelf";
    public Identifier? Item => "minecraft:chiseled_bookshelf";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => true;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 13;
    public string TranslationKey => "block.minecraft.chiseled_bookshelf";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Slot0Occupied switch {
                    true => Slot1Occupied switch {
                        true => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2344,
                                        false => 2345,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2346,
                                        false => 2347,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2348,
                                        false => 2349,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2350,
                                        false => 2351,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2352,
                                        false => 2353,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2354,
                                        false => 2355,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2356,
                                        false => 2357,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2358,
                                        false => 2359,
                                    },
                                },
                            },
                        },
                        false => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2360,
                                        false => 2361,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2362,
                                        false => 2363,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2364,
                                        false => 2365,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2366,
                                        false => 2367,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2368,
                                        false => 2369,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2370,
                                        false => 2371,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2372,
                                        false => 2373,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2374,
                                        false => 2375,
                                    },
                                },
                            },
                        },
                    },
                    false => Slot1Occupied switch {
                        true => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2376,
                                        false => 2377,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2378,
                                        false => 2379,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2380,
                                        false => 2381,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2382,
                                        false => 2383,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2384,
                                        false => 2385,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2386,
                                        false => 2387,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2388,
                                        false => 2389,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2390,
                                        false => 2391,
                                    },
                                },
                            },
                        },
                        false => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2392,
                                        false => 2393,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2394,
                                        false => 2395,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2396,
                                        false => 2397,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2398,
                                        false => 2399,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2400,
                                        false => 2401,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2402,
                                        false => 2403,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2404,
                                        false => 2405,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2406,
                                        false => 2407,
                                    },
                                },
                            },
                        },
                    },
                },
                Direction.South => Slot0Occupied switch {
                    true => Slot1Occupied switch {
                        true => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2408,
                                        false => 2409,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2410,
                                        false => 2411,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2412,
                                        false => 2413,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2414,
                                        false => 2415,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2416,
                                        false => 2417,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2418,
                                        false => 2419,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2420,
                                        false => 2421,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2422,
                                        false => 2423,
                                    },
                                },
                            },
                        },
                        false => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2424,
                                        false => 2425,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2426,
                                        false => 2427,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2428,
                                        false => 2429,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2430,
                                        false => 2431,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2432,
                                        false => 2433,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2434,
                                        false => 2435,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2436,
                                        false => 2437,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2438,
                                        false => 2439,
                                    },
                                },
                            },
                        },
                    },
                    false => Slot1Occupied switch {
                        true => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2440,
                                        false => 2441,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2442,
                                        false => 2443,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2444,
                                        false => 2445,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2446,
                                        false => 2447,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2448,
                                        false => 2449,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2450,
                                        false => 2451,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2452,
                                        false => 2453,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2454,
                                        false => 2455,
                                    },
                                },
                            },
                        },
                        false => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2456,
                                        false => 2457,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2458,
                                        false => 2459,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2460,
                                        false => 2461,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2462,
                                        false => 2463,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2464,
                                        false => 2465,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2466,
                                        false => 2467,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2468,
                                        false => 2469,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2470,
                                        false => 2471,
                                    },
                                },
                            },
                        },
                    },
                },
                Direction.West => Slot0Occupied switch {
                    true => Slot1Occupied switch {
                        true => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2472,
                                        false => 2473,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2474,
                                        false => 2475,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2476,
                                        false => 2477,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2478,
                                        false => 2479,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2480,
                                        false => 2481,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2482,
                                        false => 2483,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2484,
                                        false => 2485,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2486,
                                        false => 2487,
                                    },
                                },
                            },
                        },
                        false => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2488,
                                        false => 2489,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2490,
                                        false => 2491,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2492,
                                        false => 2493,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2494,
                                        false => 2495,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2496,
                                        false => 2497,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2498,
                                        false => 2499,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2500,
                                        false => 2501,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2502,
                                        false => 2503,
                                    },
                                },
                            },
                        },
                    },
                    false => Slot1Occupied switch {
                        true => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2504,
                                        false => 2505,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2506,
                                        false => 2507,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2508,
                                        false => 2509,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2510,
                                        false => 2511,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2512,
                                        false => 2513,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2514,
                                        false => 2515,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2516,
                                        false => 2517,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2518,
                                        false => 2519,
                                    },
                                },
                            },
                        },
                        false => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2520,
                                        false => 2521,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2522,
                                        false => 2523,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2524,
                                        false => 2525,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2526,
                                        false => 2527,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2528,
                                        false => 2529,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2530,
                                        false => 2531,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2532,
                                        false => 2533,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2534,
                                        false => 2535,
                                    },
                                },
                            },
                        },
                    },
                },
                Direction.East => Slot0Occupied switch {
                    true => Slot1Occupied switch {
                        true => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2536,
                                        false => 2537,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2538,
                                        false => 2539,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2540,
                                        false => 2541,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2542,
                                        false => 2543,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2544,
                                        false => 2545,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2546,
                                        false => 2547,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2548,
                                        false => 2549,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2550,
                                        false => 2551,
                                    },
                                },
                            },
                        },
                        false => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2552,
                                        false => 2553,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2554,
                                        false => 2555,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2556,
                                        false => 2557,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2558,
                                        false => 2559,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2560,
                                        false => 2561,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2562,
                                        false => 2563,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2564,
                                        false => 2565,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2566,
                                        false => 2567,
                                    },
                                },
                            },
                        },
                    },
                    false => Slot1Occupied switch {
                        true => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2568,
                                        false => 2569,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2570,
                                        false => 2571,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2572,
                                        false => 2573,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2574,
                                        false => 2575,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2576,
                                        false => 2577,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2578,
                                        false => 2579,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2580,
                                        false => 2581,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2582,
                                        false => 2583,
                                    },
                                },
                            },
                        },
                        false => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2584,
                                        false => 2585,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2586,
                                        false => 2587,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2588,
                                        false => 2589,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2590,
                                        false => 2591,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2592,
                                        false => 2593,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2594,
                                        false => 2595,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2596,
                                        false => 2597,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2598,
                                        false => 2599,
                                    },
                                },
                            },
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            2344 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, true, true, true, true),
            2345 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, true, true, true, false),
            2346 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, true, true, false, true),
            2347 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, true, true, false, false),
            2348 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, true, false, true, true),
            2349 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, true, false, true, false),
            2350 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, true, false, false, true),
            2351 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, true, false, false, false),
            2352 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, false, true, true, true),
            2353 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, false, true, true, false),
            2354 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, false, true, false, true),
            2355 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, false, true, false, false),
            2356 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, false, false, true, true),
            2357 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, false, false, true, false),
            2358 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, false, false, false, true),
            2359 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, false, false, false, false),
            2360 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, true, true, true, true),
            2361 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, true, true, true, false),
            2362 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, true, true, false, true),
            2363 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, true, true, false, false),
            2364 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, true, false, true, true),
            2365 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, true, false, true, false),
            2366 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, true, false, false, true),
            2367 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, true, false, false, false),
            2368 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, false, true, true, true),
            2369 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, false, true, true, false),
            2370 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, false, true, false, true),
            2371 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, false, true, false, false),
            2372 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, false, false, true, true),
            2373 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, false, false, true, false),
            2374 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, false, false, false, true),
            2375 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, false, false, false, false),
            2376 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, true, true, true, true),
            2377 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, true, true, true, false),
            2378 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, true, true, false, true),
            2379 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, true, true, false, false),
            2380 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, true, false, true, true),
            2381 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, true, false, true, false),
            2382 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, true, false, false, true),
            2383 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, true, false, false, false),
            2384 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, false, true, true, true),
            2385 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, false, true, true, false),
            2386 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, false, true, false, true),
            2387 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, false, true, false, false),
            2388 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, false, false, true, true),
            2389 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, false, false, true, false),
            2390 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, false, false, false, true),
            2391 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, false, false, false, false),
            2392 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, true, true, true, true),
            2393 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, true, true, true, false),
            2394 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, true, true, false, true),
            2395 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, true, true, false, false),
            2396 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, true, false, true, true),
            2397 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, true, false, true, false),
            2398 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, true, false, false, true),
            2399 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, true, false, false, false),
            2400 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, false, true, true, true),
            2401 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, false, true, true, false),
            2402 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, false, true, false, true),
            2403 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, false, true, false, false),
            2404 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, false, false, true, true),
            2405 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, false, false, true, false),
            2406 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, false, false, false, true),
            2407 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, false, false, false, false),
            2408 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, true, true, true, true),
            2409 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, true, true, true, false),
            2410 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, true, true, false, true),
            2411 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, true, true, false, false),
            2412 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, true, false, true, true),
            2413 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, true, false, true, false),
            2414 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, true, false, false, true),
            2415 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, true, false, false, false),
            2416 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, false, true, true, true),
            2417 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, false, true, true, false),
            2418 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, false, true, false, true),
            2419 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, false, true, false, false),
            2420 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, false, false, true, true),
            2421 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, false, false, true, false),
            2422 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, false, false, false, true),
            2423 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, false, false, false, false),
            2424 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, true, true, true, true),
            2425 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, true, true, true, false),
            2426 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, true, true, false, true),
            2427 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, true, true, false, false),
            2428 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, true, false, true, true),
            2429 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, true, false, true, false),
            2430 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, true, false, false, true),
            2431 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, true, false, false, false),
            2432 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, false, true, true, true),
            2433 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, false, true, true, false),
            2434 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, false, true, false, true),
            2435 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, false, true, false, false),
            2436 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, false, false, true, true),
            2437 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, false, false, true, false),
            2438 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, false, false, false, true),
            2439 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, false, false, false, false),
            2440 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, true, true, true, true),
            2441 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, true, true, true, false),
            2442 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, true, true, false, true),
            2443 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, true, true, false, false),
            2444 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, true, false, true, true),
            2445 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, true, false, true, false),
            2446 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, true, false, false, true),
            2447 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, true, false, false, false),
            2448 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, false, true, true, true),
            2449 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, false, true, true, false),
            2450 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, false, true, false, true),
            2451 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, false, true, false, false),
            2452 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, false, false, true, true),
            2453 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, false, false, true, false),
            2454 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, false, false, false, true),
            2455 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, false, false, false, false),
            2456 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, true, true, true, true),
            2457 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, true, true, true, false),
            2458 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, true, true, false, true),
            2459 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, true, true, false, false),
            2460 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, true, false, true, true),
            2461 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, true, false, true, false),
            2462 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, true, false, false, true),
            2463 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, true, false, false, false),
            2464 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, false, true, true, true),
            2465 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, false, true, true, false),
            2466 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, false, true, false, true),
            2467 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, false, true, false, false),
            2468 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, false, false, true, true),
            2469 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, false, false, true, false),
            2470 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, false, false, false, true),
            2471 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, false, false, false, false),
            2472 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, true, true, true, true),
            2473 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, true, true, true, false),
            2474 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, true, true, false, true),
            2475 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, true, true, false, false),
            2476 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, true, false, true, true),
            2477 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, true, false, true, false),
            2478 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, true, false, false, true),
            2479 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, true, false, false, false),
            2480 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, false, true, true, true),
            2481 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, false, true, true, false),
            2482 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, false, true, false, true),
            2483 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, false, true, false, false),
            2484 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, false, false, true, true),
            2485 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, false, false, true, false),
            2486 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, false, false, false, true),
            2487 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, false, false, false, false),
            2488 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, true, true, true, true),
            2489 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, true, true, true, false),
            2490 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, true, true, false, true),
            2491 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, true, true, false, false),
            2492 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, true, false, true, true),
            2493 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, true, false, true, false),
            2494 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, true, false, false, true),
            2495 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, true, false, false, false),
            2496 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, false, true, true, true),
            2497 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, false, true, true, false),
            2498 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, false, true, false, true),
            2499 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, false, true, false, false),
            2500 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, false, false, true, true),
            2501 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, false, false, true, false),
            2502 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, false, false, false, true),
            2503 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, false, false, false, false),
            2504 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, true, true, true, true),
            2505 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, true, true, true, false),
            2506 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, true, true, false, true),
            2507 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, true, true, false, false),
            2508 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, true, false, true, true),
            2509 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, true, false, true, false),
            2510 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, true, false, false, true),
            2511 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, true, false, false, false),
            2512 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, false, true, true, true),
            2513 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, false, true, true, false),
            2514 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, false, true, false, true),
            2515 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, false, true, false, false),
            2516 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, false, false, true, true),
            2517 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, false, false, true, false),
            2518 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, false, false, false, true),
            2519 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, false, false, false, false),
            2520 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, true, true, true, true),
            2521 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, true, true, true, false),
            2522 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, true, true, false, true),
            2523 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, true, true, false, false),
            2524 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, true, false, true, true),
            2525 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, true, false, true, false),
            2526 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, true, false, false, true),
            2527 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, true, false, false, false),
            2528 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, false, true, true, true),
            2529 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, false, true, true, false),
            2530 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, false, true, false, true),
            2531 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, false, true, false, false),
            2532 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, false, false, true, true),
            2533 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, false, false, true, false),
            2534 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, false, false, false, true),
            2535 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, false, false, false, false),
            2536 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, true, true, true, true),
            2537 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, true, true, true, false),
            2538 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, true, true, false, true),
            2539 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, true, true, false, false),
            2540 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, true, false, true, true),
            2541 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, true, false, true, false),
            2542 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, true, false, false, true),
            2543 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, true, false, false, false),
            2544 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, false, true, true, true),
            2545 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, false, true, true, false),
            2546 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, false, true, false, true),
            2547 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, false, true, false, false),
            2548 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, false, false, true, true),
            2549 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, false, false, true, false),
            2550 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, false, false, false, true),
            2551 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, false, false, false, false),
            2552 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, true, true, true, true),
            2553 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, true, true, true, false),
            2554 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, true, true, false, true),
            2555 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, true, true, false, false),
            2556 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, true, false, true, true),
            2557 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, true, false, true, false),
            2558 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, true, false, false, true),
            2559 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, true, false, false, false),
            2560 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, false, true, true, true),
            2561 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, false, true, true, false),
            2562 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, false, true, false, true),
            2563 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, false, true, false, false),
            2564 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, false, false, true, true),
            2565 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, false, false, true, false),
            2566 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, false, false, false, true),
            2567 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, false, false, false, false),
            2568 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, true, true, true, true),
            2569 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, true, true, true, false),
            2570 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, true, true, false, true),
            2571 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, true, true, false, false),
            2572 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, true, false, true, true),
            2573 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, true, false, true, false),
            2574 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, true, false, false, true),
            2575 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, true, false, false, false),
            2576 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, false, true, true, true),
            2577 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, false, true, true, false),
            2578 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, false, true, false, true),
            2579 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, false, true, false, false),
            2580 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, false, false, true, true),
            2581 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, false, false, true, false),
            2582 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, false, false, false, true),
            2583 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, false, false, false, false),
            2584 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, true, true, true, true),
            2585 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, true, true, true, false),
            2586 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, true, true, false, true),
            2587 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, true, true, false, false),
            2588 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, true, false, true, true),
            2589 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, true, false, true, false),
            2590 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, true, false, false, true),
            2591 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, true, false, false, false),
            2592 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, false, true, true, true),
            2593 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, false, true, true, false),
            2594 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, false, true, false, true),
            2595 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, false, true, false, false),
            2596 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, false, false, true, true),
            2597 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, false, false, true, false),
            2598 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, false, false, false, true),
            2599 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Slot0Occupied = properties.Contains("slot_0_occupied") ? properties["slot_0_occupied"].GetString() == "true" : Slot0Occupied,
            Slot1Occupied = properties.Contains("slot_1_occupied") ? properties["slot_1_occupied"].GetString() == "true" : Slot1Occupied,
            Slot2Occupied = properties.Contains("slot_2_occupied") ? properties["slot_2_occupied"].GetString() == "true" : Slot2Occupied,
            Slot3Occupied = properties.Contains("slot_3_occupied") ? properties["slot_3_occupied"].GetString() == "true" : Slot3Occupied,
            Slot4Occupied = properties.Contains("slot_4_occupied") ? properties["slot_4_occupied"].GetString() == "true" : Slot4Occupied,
            Slot5Occupied = properties.Contains("slot_5_occupied") ? properties["slot_5_occupied"].GetString() == "true" : Slot5Occupied,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("slot_0_occupied", new StringTag(Slot0Occupied.ToString().ToLower())),
            ("slot_1_occupied", new StringTag(Slot1Occupied.ToString().ToLower())),
            ("slot_2_occupied", new StringTag(Slot2Occupied.ToString().ToLower())),
            ("slot_3_occupied", new StringTag(Slot3Occupied.ToString().ToLower())),
            ("slot_4_occupied", new StringTag(Slot4Occupied.ToString().ToLower())),
            ("slot_5_occupied", new StringTag(Slot5Occupied.ToString().ToLower()))
        );
    }
    
}
