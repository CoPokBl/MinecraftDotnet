using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record FireBlock(Identifier Identifier, int Age, bool East, bool North, bool South, bool Up, bool West) : IBlock {

    public Identifier Category => "minecraft:fire";
    public int ProtocolId => 183;
    public double Hardness => 0;
    public double ExplosionResistance => 0;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 15;
    public bool Replaceable => true;
    public string SoundType => "wool";
    public Identifier? BlockEntity => null;
    public Identifier? Item => null;
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.0625, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 4;
    public string TranslationKey => "block.minecraft.fire";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Age switch {
                0 => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2406,
                                    false => 2407,
                                },
                                false => West switch {
                                    true => 2408,
                                    false => 2409,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2410,
                                    false => 2411,
                                },
                                false => West switch {
                                    true => 2412,
                                    false => 2413,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2414,
                                    false => 2415,
                                },
                                false => West switch {
                                    true => 2416,
                                    false => 2417,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2418,
                                    false => 2419,
                                },
                                false => West switch {
                                    true => 2420,
                                    false => 2421,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2422,
                                    false => 2423,
                                },
                                false => West switch {
                                    true => 2424,
                                    false => 2425,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2426,
                                    false => 2427,
                                },
                                false => West switch {
                                    true => 2428,
                                    false => 2429,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2430,
                                    false => 2431,
                                },
                                false => West switch {
                                    true => 2432,
                                    false => 2433,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2434,
                                    false => 2435,
                                },
                                false => West switch {
                                    true => 2436,
                                    false => 2437,
                                },
                            },
                        },
                    },
                },
                1 => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2438,
                                    false => 2439,
                                },
                                false => West switch {
                                    true => 2440,
                                    false => 2441,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2442,
                                    false => 2443,
                                },
                                false => West switch {
                                    true => 2444,
                                    false => 2445,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2446,
                                    false => 2447,
                                },
                                false => West switch {
                                    true => 2448,
                                    false => 2449,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2450,
                                    false => 2451,
                                },
                                false => West switch {
                                    true => 2452,
                                    false => 2453,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2454,
                                    false => 2455,
                                },
                                false => West switch {
                                    true => 2456,
                                    false => 2457,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2458,
                                    false => 2459,
                                },
                                false => West switch {
                                    true => 2460,
                                    false => 2461,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2462,
                                    false => 2463,
                                },
                                false => West switch {
                                    true => 2464,
                                    false => 2465,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2466,
                                    false => 2467,
                                },
                                false => West switch {
                                    true => 2468,
                                    false => 2469,
                                },
                            },
                        },
                    },
                },
                2 => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2470,
                                    false => 2471,
                                },
                                false => West switch {
                                    true => 2472,
                                    false => 2473,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2474,
                                    false => 2475,
                                },
                                false => West switch {
                                    true => 2476,
                                    false => 2477,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2478,
                                    false => 2479,
                                },
                                false => West switch {
                                    true => 2480,
                                    false => 2481,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2482,
                                    false => 2483,
                                },
                                false => West switch {
                                    true => 2484,
                                    false => 2485,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2486,
                                    false => 2487,
                                },
                                false => West switch {
                                    true => 2488,
                                    false => 2489,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2490,
                                    false => 2491,
                                },
                                false => West switch {
                                    true => 2492,
                                    false => 2493,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2494,
                                    false => 2495,
                                },
                                false => West switch {
                                    true => 2496,
                                    false => 2497,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2498,
                                    false => 2499,
                                },
                                false => West switch {
                                    true => 2500,
                                    false => 2501,
                                },
                            },
                        },
                    },
                },
                3 => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2502,
                                    false => 2503,
                                },
                                false => West switch {
                                    true => 2504,
                                    false => 2505,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2506,
                                    false => 2507,
                                },
                                false => West switch {
                                    true => 2508,
                                    false => 2509,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2510,
                                    false => 2511,
                                },
                                false => West switch {
                                    true => 2512,
                                    false => 2513,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2514,
                                    false => 2515,
                                },
                                false => West switch {
                                    true => 2516,
                                    false => 2517,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2518,
                                    false => 2519,
                                },
                                false => West switch {
                                    true => 2520,
                                    false => 2521,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2522,
                                    false => 2523,
                                },
                                false => West switch {
                                    true => 2524,
                                    false => 2525,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2526,
                                    false => 2527,
                                },
                                false => West switch {
                                    true => 2528,
                                    false => 2529,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2530,
                                    false => 2531,
                                },
                                false => West switch {
                                    true => 2532,
                                    false => 2533,
                                },
                            },
                        },
                    },
                },
                4 => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2534,
                                    false => 2535,
                                },
                                false => West switch {
                                    true => 2536,
                                    false => 2537,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2538,
                                    false => 2539,
                                },
                                false => West switch {
                                    true => 2540,
                                    false => 2541,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2542,
                                    false => 2543,
                                },
                                false => West switch {
                                    true => 2544,
                                    false => 2545,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2546,
                                    false => 2547,
                                },
                                false => West switch {
                                    true => 2548,
                                    false => 2549,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2550,
                                    false => 2551,
                                },
                                false => West switch {
                                    true => 2552,
                                    false => 2553,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2554,
                                    false => 2555,
                                },
                                false => West switch {
                                    true => 2556,
                                    false => 2557,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2558,
                                    false => 2559,
                                },
                                false => West switch {
                                    true => 2560,
                                    false => 2561,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2562,
                                    false => 2563,
                                },
                                false => West switch {
                                    true => 2564,
                                    false => 2565,
                                },
                            },
                        },
                    },
                },
                5 => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2566,
                                    false => 2567,
                                },
                                false => West switch {
                                    true => 2568,
                                    false => 2569,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2570,
                                    false => 2571,
                                },
                                false => West switch {
                                    true => 2572,
                                    false => 2573,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2574,
                                    false => 2575,
                                },
                                false => West switch {
                                    true => 2576,
                                    false => 2577,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2578,
                                    false => 2579,
                                },
                                false => West switch {
                                    true => 2580,
                                    false => 2581,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2582,
                                    false => 2583,
                                },
                                false => West switch {
                                    true => 2584,
                                    false => 2585,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2586,
                                    false => 2587,
                                },
                                false => West switch {
                                    true => 2588,
                                    false => 2589,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2590,
                                    false => 2591,
                                },
                                false => West switch {
                                    true => 2592,
                                    false => 2593,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2594,
                                    false => 2595,
                                },
                                false => West switch {
                                    true => 2596,
                                    false => 2597,
                                },
                            },
                        },
                    },
                },
                6 => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2598,
                                    false => 2599,
                                },
                                false => West switch {
                                    true => 2600,
                                    false => 2601,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2602,
                                    false => 2603,
                                },
                                false => West switch {
                                    true => 2604,
                                    false => 2605,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2606,
                                    false => 2607,
                                },
                                false => West switch {
                                    true => 2608,
                                    false => 2609,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2610,
                                    false => 2611,
                                },
                                false => West switch {
                                    true => 2612,
                                    false => 2613,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2614,
                                    false => 2615,
                                },
                                false => West switch {
                                    true => 2616,
                                    false => 2617,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2618,
                                    false => 2619,
                                },
                                false => West switch {
                                    true => 2620,
                                    false => 2621,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2622,
                                    false => 2623,
                                },
                                false => West switch {
                                    true => 2624,
                                    false => 2625,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2626,
                                    false => 2627,
                                },
                                false => West switch {
                                    true => 2628,
                                    false => 2629,
                                },
                            },
                        },
                    },
                },
                7 => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2630,
                                    false => 2631,
                                },
                                false => West switch {
                                    true => 2632,
                                    false => 2633,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2634,
                                    false => 2635,
                                },
                                false => West switch {
                                    true => 2636,
                                    false => 2637,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2638,
                                    false => 2639,
                                },
                                false => West switch {
                                    true => 2640,
                                    false => 2641,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2642,
                                    false => 2643,
                                },
                                false => West switch {
                                    true => 2644,
                                    false => 2645,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2646,
                                    false => 2647,
                                },
                                false => West switch {
                                    true => 2648,
                                    false => 2649,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2650,
                                    false => 2651,
                                },
                                false => West switch {
                                    true => 2652,
                                    false => 2653,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2654,
                                    false => 2655,
                                },
                                false => West switch {
                                    true => 2656,
                                    false => 2657,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2658,
                                    false => 2659,
                                },
                                false => West switch {
                                    true => 2660,
                                    false => 2661,
                                },
                            },
                        },
                    },
                },
                8 => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2662,
                                    false => 2663,
                                },
                                false => West switch {
                                    true => 2664,
                                    false => 2665,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2666,
                                    false => 2667,
                                },
                                false => West switch {
                                    true => 2668,
                                    false => 2669,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2670,
                                    false => 2671,
                                },
                                false => West switch {
                                    true => 2672,
                                    false => 2673,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2674,
                                    false => 2675,
                                },
                                false => West switch {
                                    true => 2676,
                                    false => 2677,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2678,
                                    false => 2679,
                                },
                                false => West switch {
                                    true => 2680,
                                    false => 2681,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2682,
                                    false => 2683,
                                },
                                false => West switch {
                                    true => 2684,
                                    false => 2685,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2686,
                                    false => 2687,
                                },
                                false => West switch {
                                    true => 2688,
                                    false => 2689,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2690,
                                    false => 2691,
                                },
                                false => West switch {
                                    true => 2692,
                                    false => 2693,
                                },
                            },
                        },
                    },
                },
                9 => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2694,
                                    false => 2695,
                                },
                                false => West switch {
                                    true => 2696,
                                    false => 2697,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2698,
                                    false => 2699,
                                },
                                false => West switch {
                                    true => 2700,
                                    false => 2701,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2702,
                                    false => 2703,
                                },
                                false => West switch {
                                    true => 2704,
                                    false => 2705,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2706,
                                    false => 2707,
                                },
                                false => West switch {
                                    true => 2708,
                                    false => 2709,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2710,
                                    false => 2711,
                                },
                                false => West switch {
                                    true => 2712,
                                    false => 2713,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2714,
                                    false => 2715,
                                },
                                false => West switch {
                                    true => 2716,
                                    false => 2717,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2718,
                                    false => 2719,
                                },
                                false => West switch {
                                    true => 2720,
                                    false => 2721,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2722,
                                    false => 2723,
                                },
                                false => West switch {
                                    true => 2724,
                                    false => 2725,
                                },
                            },
                        },
                    },
                },
                10 => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2726,
                                    false => 2727,
                                },
                                false => West switch {
                                    true => 2728,
                                    false => 2729,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2730,
                                    false => 2731,
                                },
                                false => West switch {
                                    true => 2732,
                                    false => 2733,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2734,
                                    false => 2735,
                                },
                                false => West switch {
                                    true => 2736,
                                    false => 2737,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2738,
                                    false => 2739,
                                },
                                false => West switch {
                                    true => 2740,
                                    false => 2741,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2742,
                                    false => 2743,
                                },
                                false => West switch {
                                    true => 2744,
                                    false => 2745,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2746,
                                    false => 2747,
                                },
                                false => West switch {
                                    true => 2748,
                                    false => 2749,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2750,
                                    false => 2751,
                                },
                                false => West switch {
                                    true => 2752,
                                    false => 2753,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2754,
                                    false => 2755,
                                },
                                false => West switch {
                                    true => 2756,
                                    false => 2757,
                                },
                            },
                        },
                    },
                },
                11 => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2758,
                                    false => 2759,
                                },
                                false => West switch {
                                    true => 2760,
                                    false => 2761,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2762,
                                    false => 2763,
                                },
                                false => West switch {
                                    true => 2764,
                                    false => 2765,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2766,
                                    false => 2767,
                                },
                                false => West switch {
                                    true => 2768,
                                    false => 2769,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2770,
                                    false => 2771,
                                },
                                false => West switch {
                                    true => 2772,
                                    false => 2773,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2774,
                                    false => 2775,
                                },
                                false => West switch {
                                    true => 2776,
                                    false => 2777,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2778,
                                    false => 2779,
                                },
                                false => West switch {
                                    true => 2780,
                                    false => 2781,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2782,
                                    false => 2783,
                                },
                                false => West switch {
                                    true => 2784,
                                    false => 2785,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2786,
                                    false => 2787,
                                },
                                false => West switch {
                                    true => 2788,
                                    false => 2789,
                                },
                            },
                        },
                    },
                },
                12 => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2790,
                                    false => 2791,
                                },
                                false => West switch {
                                    true => 2792,
                                    false => 2793,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2794,
                                    false => 2795,
                                },
                                false => West switch {
                                    true => 2796,
                                    false => 2797,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2798,
                                    false => 2799,
                                },
                                false => West switch {
                                    true => 2800,
                                    false => 2801,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2802,
                                    false => 2803,
                                },
                                false => West switch {
                                    true => 2804,
                                    false => 2805,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2806,
                                    false => 2807,
                                },
                                false => West switch {
                                    true => 2808,
                                    false => 2809,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2810,
                                    false => 2811,
                                },
                                false => West switch {
                                    true => 2812,
                                    false => 2813,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2814,
                                    false => 2815,
                                },
                                false => West switch {
                                    true => 2816,
                                    false => 2817,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2818,
                                    false => 2819,
                                },
                                false => West switch {
                                    true => 2820,
                                    false => 2821,
                                },
                            },
                        },
                    },
                },
                13 => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2822,
                                    false => 2823,
                                },
                                false => West switch {
                                    true => 2824,
                                    false => 2825,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2826,
                                    false => 2827,
                                },
                                false => West switch {
                                    true => 2828,
                                    false => 2829,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2830,
                                    false => 2831,
                                },
                                false => West switch {
                                    true => 2832,
                                    false => 2833,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2834,
                                    false => 2835,
                                },
                                false => West switch {
                                    true => 2836,
                                    false => 2837,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2838,
                                    false => 2839,
                                },
                                false => West switch {
                                    true => 2840,
                                    false => 2841,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2842,
                                    false => 2843,
                                },
                                false => West switch {
                                    true => 2844,
                                    false => 2845,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2846,
                                    false => 2847,
                                },
                                false => West switch {
                                    true => 2848,
                                    false => 2849,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2850,
                                    false => 2851,
                                },
                                false => West switch {
                                    true => 2852,
                                    false => 2853,
                                },
                            },
                        },
                    },
                },
                14 => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2854,
                                    false => 2855,
                                },
                                false => West switch {
                                    true => 2856,
                                    false => 2857,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2858,
                                    false => 2859,
                                },
                                false => West switch {
                                    true => 2860,
                                    false => 2861,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2862,
                                    false => 2863,
                                },
                                false => West switch {
                                    true => 2864,
                                    false => 2865,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2866,
                                    false => 2867,
                                },
                                false => West switch {
                                    true => 2868,
                                    false => 2869,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2870,
                                    false => 2871,
                                },
                                false => West switch {
                                    true => 2872,
                                    false => 2873,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2874,
                                    false => 2875,
                                },
                                false => West switch {
                                    true => 2876,
                                    false => 2877,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2878,
                                    false => 2879,
                                },
                                false => West switch {
                                    true => 2880,
                                    false => 2881,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2882,
                                    false => 2883,
                                },
                                false => West switch {
                                    true => 2884,
                                    false => 2885,
                                },
                            },
                        },
                    },
                },
                15 => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2886,
                                    false => 2887,
                                },
                                false => West switch {
                                    true => 2888,
                                    false => 2889,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2890,
                                    false => 2891,
                                },
                                false => West switch {
                                    true => 2892,
                                    false => 2893,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2894,
                                    false => 2895,
                                },
                                false => West switch {
                                    true => 2896,
                                    false => 2897,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2898,
                                    false => 2899,
                                },
                                false => West switch {
                                    true => 2900,
                                    false => 2901,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2902,
                                    false => 2903,
                                },
                                false => West switch {
                                    true => 2904,
                                    false => 2905,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2906,
                                    false => 2907,
                                },
                                false => West switch {
                                    true => 2908,
                                    false => 2909,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 2910,
                                    false => 2911,
                                },
                                false => West switch {
                                    true => 2912,
                                    false => 2913,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 2914,
                                    false => 2915,
                                },
                                false => West switch {
                                    true => 2916,
                                    false => 2917,
                                },
                            },
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            2406 => new FireBlock(Identifier, 0, true, true, true, true, true),
            2407 => new FireBlock(Identifier, 0, true, true, true, true, false),
            2408 => new FireBlock(Identifier, 0, true, true, true, false, true),
            2409 => new FireBlock(Identifier, 0, true, true, true, false, false),
            2410 => new FireBlock(Identifier, 0, true, true, false, true, true),
            2411 => new FireBlock(Identifier, 0, true, true, false, true, false),
            2412 => new FireBlock(Identifier, 0, true, true, false, false, true),
            2413 => new FireBlock(Identifier, 0, true, true, false, false, false),
            2414 => new FireBlock(Identifier, 0, true, false, true, true, true),
            2415 => new FireBlock(Identifier, 0, true, false, true, true, false),
            2416 => new FireBlock(Identifier, 0, true, false, true, false, true),
            2417 => new FireBlock(Identifier, 0, true, false, true, false, false),
            2418 => new FireBlock(Identifier, 0, true, false, false, true, true),
            2419 => new FireBlock(Identifier, 0, true, false, false, true, false),
            2420 => new FireBlock(Identifier, 0, true, false, false, false, true),
            2421 => new FireBlock(Identifier, 0, true, false, false, false, false),
            2422 => new FireBlock(Identifier, 0, false, true, true, true, true),
            2423 => new FireBlock(Identifier, 0, false, true, true, true, false),
            2424 => new FireBlock(Identifier, 0, false, true, true, false, true),
            2425 => new FireBlock(Identifier, 0, false, true, true, false, false),
            2426 => new FireBlock(Identifier, 0, false, true, false, true, true),
            2427 => new FireBlock(Identifier, 0, false, true, false, true, false),
            2428 => new FireBlock(Identifier, 0, false, true, false, false, true),
            2429 => new FireBlock(Identifier, 0, false, true, false, false, false),
            2430 => new FireBlock(Identifier, 0, false, false, true, true, true),
            2431 => new FireBlock(Identifier, 0, false, false, true, true, false),
            2432 => new FireBlock(Identifier, 0, false, false, true, false, true),
            2433 => new FireBlock(Identifier, 0, false, false, true, false, false),
            2434 => new FireBlock(Identifier, 0, false, false, false, true, true),
            2435 => new FireBlock(Identifier, 0, false, false, false, true, false),
            2436 => new FireBlock(Identifier, 0, false, false, false, false, true),
            2437 => new FireBlock(Identifier, 0, false, false, false, false, false),
            2438 => new FireBlock(Identifier, 1, true, true, true, true, true),
            2439 => new FireBlock(Identifier, 1, true, true, true, true, false),
            2440 => new FireBlock(Identifier, 1, true, true, true, false, true),
            2441 => new FireBlock(Identifier, 1, true, true, true, false, false),
            2442 => new FireBlock(Identifier, 1, true, true, false, true, true),
            2443 => new FireBlock(Identifier, 1, true, true, false, true, false),
            2444 => new FireBlock(Identifier, 1, true, true, false, false, true),
            2445 => new FireBlock(Identifier, 1, true, true, false, false, false),
            2446 => new FireBlock(Identifier, 1, true, false, true, true, true),
            2447 => new FireBlock(Identifier, 1, true, false, true, true, false),
            2448 => new FireBlock(Identifier, 1, true, false, true, false, true),
            2449 => new FireBlock(Identifier, 1, true, false, true, false, false),
            2450 => new FireBlock(Identifier, 1, true, false, false, true, true),
            2451 => new FireBlock(Identifier, 1, true, false, false, true, false),
            2452 => new FireBlock(Identifier, 1, true, false, false, false, true),
            2453 => new FireBlock(Identifier, 1, true, false, false, false, false),
            2454 => new FireBlock(Identifier, 1, false, true, true, true, true),
            2455 => new FireBlock(Identifier, 1, false, true, true, true, false),
            2456 => new FireBlock(Identifier, 1, false, true, true, false, true),
            2457 => new FireBlock(Identifier, 1, false, true, true, false, false),
            2458 => new FireBlock(Identifier, 1, false, true, false, true, true),
            2459 => new FireBlock(Identifier, 1, false, true, false, true, false),
            2460 => new FireBlock(Identifier, 1, false, true, false, false, true),
            2461 => new FireBlock(Identifier, 1, false, true, false, false, false),
            2462 => new FireBlock(Identifier, 1, false, false, true, true, true),
            2463 => new FireBlock(Identifier, 1, false, false, true, true, false),
            2464 => new FireBlock(Identifier, 1, false, false, true, false, true),
            2465 => new FireBlock(Identifier, 1, false, false, true, false, false),
            2466 => new FireBlock(Identifier, 1, false, false, false, true, true),
            2467 => new FireBlock(Identifier, 1, false, false, false, true, false),
            2468 => new FireBlock(Identifier, 1, false, false, false, false, true),
            2469 => new FireBlock(Identifier, 1, false, false, false, false, false),
            2470 => new FireBlock(Identifier, 2, true, true, true, true, true),
            2471 => new FireBlock(Identifier, 2, true, true, true, true, false),
            2472 => new FireBlock(Identifier, 2, true, true, true, false, true),
            2473 => new FireBlock(Identifier, 2, true, true, true, false, false),
            2474 => new FireBlock(Identifier, 2, true, true, false, true, true),
            2475 => new FireBlock(Identifier, 2, true, true, false, true, false),
            2476 => new FireBlock(Identifier, 2, true, true, false, false, true),
            2477 => new FireBlock(Identifier, 2, true, true, false, false, false),
            2478 => new FireBlock(Identifier, 2, true, false, true, true, true),
            2479 => new FireBlock(Identifier, 2, true, false, true, true, false),
            2480 => new FireBlock(Identifier, 2, true, false, true, false, true),
            2481 => new FireBlock(Identifier, 2, true, false, true, false, false),
            2482 => new FireBlock(Identifier, 2, true, false, false, true, true),
            2483 => new FireBlock(Identifier, 2, true, false, false, true, false),
            2484 => new FireBlock(Identifier, 2, true, false, false, false, true),
            2485 => new FireBlock(Identifier, 2, true, false, false, false, false),
            2486 => new FireBlock(Identifier, 2, false, true, true, true, true),
            2487 => new FireBlock(Identifier, 2, false, true, true, true, false),
            2488 => new FireBlock(Identifier, 2, false, true, true, false, true),
            2489 => new FireBlock(Identifier, 2, false, true, true, false, false),
            2490 => new FireBlock(Identifier, 2, false, true, false, true, true),
            2491 => new FireBlock(Identifier, 2, false, true, false, true, false),
            2492 => new FireBlock(Identifier, 2, false, true, false, false, true),
            2493 => new FireBlock(Identifier, 2, false, true, false, false, false),
            2494 => new FireBlock(Identifier, 2, false, false, true, true, true),
            2495 => new FireBlock(Identifier, 2, false, false, true, true, false),
            2496 => new FireBlock(Identifier, 2, false, false, true, false, true),
            2497 => new FireBlock(Identifier, 2, false, false, true, false, false),
            2498 => new FireBlock(Identifier, 2, false, false, false, true, true),
            2499 => new FireBlock(Identifier, 2, false, false, false, true, false),
            2500 => new FireBlock(Identifier, 2, false, false, false, false, true),
            2501 => new FireBlock(Identifier, 2, false, false, false, false, false),
            2502 => new FireBlock(Identifier, 3, true, true, true, true, true),
            2503 => new FireBlock(Identifier, 3, true, true, true, true, false),
            2504 => new FireBlock(Identifier, 3, true, true, true, false, true),
            2505 => new FireBlock(Identifier, 3, true, true, true, false, false),
            2506 => new FireBlock(Identifier, 3, true, true, false, true, true),
            2507 => new FireBlock(Identifier, 3, true, true, false, true, false),
            2508 => new FireBlock(Identifier, 3, true, true, false, false, true),
            2509 => new FireBlock(Identifier, 3, true, true, false, false, false),
            2510 => new FireBlock(Identifier, 3, true, false, true, true, true),
            2511 => new FireBlock(Identifier, 3, true, false, true, true, false),
            2512 => new FireBlock(Identifier, 3, true, false, true, false, true),
            2513 => new FireBlock(Identifier, 3, true, false, true, false, false),
            2514 => new FireBlock(Identifier, 3, true, false, false, true, true),
            2515 => new FireBlock(Identifier, 3, true, false, false, true, false),
            2516 => new FireBlock(Identifier, 3, true, false, false, false, true),
            2517 => new FireBlock(Identifier, 3, true, false, false, false, false),
            2518 => new FireBlock(Identifier, 3, false, true, true, true, true),
            2519 => new FireBlock(Identifier, 3, false, true, true, true, false),
            2520 => new FireBlock(Identifier, 3, false, true, true, false, true),
            2521 => new FireBlock(Identifier, 3, false, true, true, false, false),
            2522 => new FireBlock(Identifier, 3, false, true, false, true, true),
            2523 => new FireBlock(Identifier, 3, false, true, false, true, false),
            2524 => new FireBlock(Identifier, 3, false, true, false, false, true),
            2525 => new FireBlock(Identifier, 3, false, true, false, false, false),
            2526 => new FireBlock(Identifier, 3, false, false, true, true, true),
            2527 => new FireBlock(Identifier, 3, false, false, true, true, false),
            2528 => new FireBlock(Identifier, 3, false, false, true, false, true),
            2529 => new FireBlock(Identifier, 3, false, false, true, false, false),
            2530 => new FireBlock(Identifier, 3, false, false, false, true, true),
            2531 => new FireBlock(Identifier, 3, false, false, false, true, false),
            2532 => new FireBlock(Identifier, 3, false, false, false, false, true),
            2533 => new FireBlock(Identifier, 3, false, false, false, false, false),
            2534 => new FireBlock(Identifier, 4, true, true, true, true, true),
            2535 => new FireBlock(Identifier, 4, true, true, true, true, false),
            2536 => new FireBlock(Identifier, 4, true, true, true, false, true),
            2537 => new FireBlock(Identifier, 4, true, true, true, false, false),
            2538 => new FireBlock(Identifier, 4, true, true, false, true, true),
            2539 => new FireBlock(Identifier, 4, true, true, false, true, false),
            2540 => new FireBlock(Identifier, 4, true, true, false, false, true),
            2541 => new FireBlock(Identifier, 4, true, true, false, false, false),
            2542 => new FireBlock(Identifier, 4, true, false, true, true, true),
            2543 => new FireBlock(Identifier, 4, true, false, true, true, false),
            2544 => new FireBlock(Identifier, 4, true, false, true, false, true),
            2545 => new FireBlock(Identifier, 4, true, false, true, false, false),
            2546 => new FireBlock(Identifier, 4, true, false, false, true, true),
            2547 => new FireBlock(Identifier, 4, true, false, false, true, false),
            2548 => new FireBlock(Identifier, 4, true, false, false, false, true),
            2549 => new FireBlock(Identifier, 4, true, false, false, false, false),
            2550 => new FireBlock(Identifier, 4, false, true, true, true, true),
            2551 => new FireBlock(Identifier, 4, false, true, true, true, false),
            2552 => new FireBlock(Identifier, 4, false, true, true, false, true),
            2553 => new FireBlock(Identifier, 4, false, true, true, false, false),
            2554 => new FireBlock(Identifier, 4, false, true, false, true, true),
            2555 => new FireBlock(Identifier, 4, false, true, false, true, false),
            2556 => new FireBlock(Identifier, 4, false, true, false, false, true),
            2557 => new FireBlock(Identifier, 4, false, true, false, false, false),
            2558 => new FireBlock(Identifier, 4, false, false, true, true, true),
            2559 => new FireBlock(Identifier, 4, false, false, true, true, false),
            2560 => new FireBlock(Identifier, 4, false, false, true, false, true),
            2561 => new FireBlock(Identifier, 4, false, false, true, false, false),
            2562 => new FireBlock(Identifier, 4, false, false, false, true, true),
            2563 => new FireBlock(Identifier, 4, false, false, false, true, false),
            2564 => new FireBlock(Identifier, 4, false, false, false, false, true),
            2565 => new FireBlock(Identifier, 4, false, false, false, false, false),
            2566 => new FireBlock(Identifier, 5, true, true, true, true, true),
            2567 => new FireBlock(Identifier, 5, true, true, true, true, false),
            2568 => new FireBlock(Identifier, 5, true, true, true, false, true),
            2569 => new FireBlock(Identifier, 5, true, true, true, false, false),
            2570 => new FireBlock(Identifier, 5, true, true, false, true, true),
            2571 => new FireBlock(Identifier, 5, true, true, false, true, false),
            2572 => new FireBlock(Identifier, 5, true, true, false, false, true),
            2573 => new FireBlock(Identifier, 5, true, true, false, false, false),
            2574 => new FireBlock(Identifier, 5, true, false, true, true, true),
            2575 => new FireBlock(Identifier, 5, true, false, true, true, false),
            2576 => new FireBlock(Identifier, 5, true, false, true, false, true),
            2577 => new FireBlock(Identifier, 5, true, false, true, false, false),
            2578 => new FireBlock(Identifier, 5, true, false, false, true, true),
            2579 => new FireBlock(Identifier, 5, true, false, false, true, false),
            2580 => new FireBlock(Identifier, 5, true, false, false, false, true),
            2581 => new FireBlock(Identifier, 5, true, false, false, false, false),
            2582 => new FireBlock(Identifier, 5, false, true, true, true, true),
            2583 => new FireBlock(Identifier, 5, false, true, true, true, false),
            2584 => new FireBlock(Identifier, 5, false, true, true, false, true),
            2585 => new FireBlock(Identifier, 5, false, true, true, false, false),
            2586 => new FireBlock(Identifier, 5, false, true, false, true, true),
            2587 => new FireBlock(Identifier, 5, false, true, false, true, false),
            2588 => new FireBlock(Identifier, 5, false, true, false, false, true),
            2589 => new FireBlock(Identifier, 5, false, true, false, false, false),
            2590 => new FireBlock(Identifier, 5, false, false, true, true, true),
            2591 => new FireBlock(Identifier, 5, false, false, true, true, false),
            2592 => new FireBlock(Identifier, 5, false, false, true, false, true),
            2593 => new FireBlock(Identifier, 5, false, false, true, false, false),
            2594 => new FireBlock(Identifier, 5, false, false, false, true, true),
            2595 => new FireBlock(Identifier, 5, false, false, false, true, false),
            2596 => new FireBlock(Identifier, 5, false, false, false, false, true),
            2597 => new FireBlock(Identifier, 5, false, false, false, false, false),
            2598 => new FireBlock(Identifier, 6, true, true, true, true, true),
            2599 => new FireBlock(Identifier, 6, true, true, true, true, false),
            2600 => new FireBlock(Identifier, 6, true, true, true, false, true),
            2601 => new FireBlock(Identifier, 6, true, true, true, false, false),
            2602 => new FireBlock(Identifier, 6, true, true, false, true, true),
            2603 => new FireBlock(Identifier, 6, true, true, false, true, false),
            2604 => new FireBlock(Identifier, 6, true, true, false, false, true),
            2605 => new FireBlock(Identifier, 6, true, true, false, false, false),
            2606 => new FireBlock(Identifier, 6, true, false, true, true, true),
            2607 => new FireBlock(Identifier, 6, true, false, true, true, false),
            2608 => new FireBlock(Identifier, 6, true, false, true, false, true),
            2609 => new FireBlock(Identifier, 6, true, false, true, false, false),
            2610 => new FireBlock(Identifier, 6, true, false, false, true, true),
            2611 => new FireBlock(Identifier, 6, true, false, false, true, false),
            2612 => new FireBlock(Identifier, 6, true, false, false, false, true),
            2613 => new FireBlock(Identifier, 6, true, false, false, false, false),
            2614 => new FireBlock(Identifier, 6, false, true, true, true, true),
            2615 => new FireBlock(Identifier, 6, false, true, true, true, false),
            2616 => new FireBlock(Identifier, 6, false, true, true, false, true),
            2617 => new FireBlock(Identifier, 6, false, true, true, false, false),
            2618 => new FireBlock(Identifier, 6, false, true, false, true, true),
            2619 => new FireBlock(Identifier, 6, false, true, false, true, false),
            2620 => new FireBlock(Identifier, 6, false, true, false, false, true),
            2621 => new FireBlock(Identifier, 6, false, true, false, false, false),
            2622 => new FireBlock(Identifier, 6, false, false, true, true, true),
            2623 => new FireBlock(Identifier, 6, false, false, true, true, false),
            2624 => new FireBlock(Identifier, 6, false, false, true, false, true),
            2625 => new FireBlock(Identifier, 6, false, false, true, false, false),
            2626 => new FireBlock(Identifier, 6, false, false, false, true, true),
            2627 => new FireBlock(Identifier, 6, false, false, false, true, false),
            2628 => new FireBlock(Identifier, 6, false, false, false, false, true),
            2629 => new FireBlock(Identifier, 6, false, false, false, false, false),
            2630 => new FireBlock(Identifier, 7, true, true, true, true, true),
            2631 => new FireBlock(Identifier, 7, true, true, true, true, false),
            2632 => new FireBlock(Identifier, 7, true, true, true, false, true),
            2633 => new FireBlock(Identifier, 7, true, true, true, false, false),
            2634 => new FireBlock(Identifier, 7, true, true, false, true, true),
            2635 => new FireBlock(Identifier, 7, true, true, false, true, false),
            2636 => new FireBlock(Identifier, 7, true, true, false, false, true),
            2637 => new FireBlock(Identifier, 7, true, true, false, false, false),
            2638 => new FireBlock(Identifier, 7, true, false, true, true, true),
            2639 => new FireBlock(Identifier, 7, true, false, true, true, false),
            2640 => new FireBlock(Identifier, 7, true, false, true, false, true),
            2641 => new FireBlock(Identifier, 7, true, false, true, false, false),
            2642 => new FireBlock(Identifier, 7, true, false, false, true, true),
            2643 => new FireBlock(Identifier, 7, true, false, false, true, false),
            2644 => new FireBlock(Identifier, 7, true, false, false, false, true),
            2645 => new FireBlock(Identifier, 7, true, false, false, false, false),
            2646 => new FireBlock(Identifier, 7, false, true, true, true, true),
            2647 => new FireBlock(Identifier, 7, false, true, true, true, false),
            2648 => new FireBlock(Identifier, 7, false, true, true, false, true),
            2649 => new FireBlock(Identifier, 7, false, true, true, false, false),
            2650 => new FireBlock(Identifier, 7, false, true, false, true, true),
            2651 => new FireBlock(Identifier, 7, false, true, false, true, false),
            2652 => new FireBlock(Identifier, 7, false, true, false, false, true),
            2653 => new FireBlock(Identifier, 7, false, true, false, false, false),
            2654 => new FireBlock(Identifier, 7, false, false, true, true, true),
            2655 => new FireBlock(Identifier, 7, false, false, true, true, false),
            2656 => new FireBlock(Identifier, 7, false, false, true, false, true),
            2657 => new FireBlock(Identifier, 7, false, false, true, false, false),
            2658 => new FireBlock(Identifier, 7, false, false, false, true, true),
            2659 => new FireBlock(Identifier, 7, false, false, false, true, false),
            2660 => new FireBlock(Identifier, 7, false, false, false, false, true),
            2661 => new FireBlock(Identifier, 7, false, false, false, false, false),
            2662 => new FireBlock(Identifier, 8, true, true, true, true, true),
            2663 => new FireBlock(Identifier, 8, true, true, true, true, false),
            2664 => new FireBlock(Identifier, 8, true, true, true, false, true),
            2665 => new FireBlock(Identifier, 8, true, true, true, false, false),
            2666 => new FireBlock(Identifier, 8, true, true, false, true, true),
            2667 => new FireBlock(Identifier, 8, true, true, false, true, false),
            2668 => new FireBlock(Identifier, 8, true, true, false, false, true),
            2669 => new FireBlock(Identifier, 8, true, true, false, false, false),
            2670 => new FireBlock(Identifier, 8, true, false, true, true, true),
            2671 => new FireBlock(Identifier, 8, true, false, true, true, false),
            2672 => new FireBlock(Identifier, 8, true, false, true, false, true),
            2673 => new FireBlock(Identifier, 8, true, false, true, false, false),
            2674 => new FireBlock(Identifier, 8, true, false, false, true, true),
            2675 => new FireBlock(Identifier, 8, true, false, false, true, false),
            2676 => new FireBlock(Identifier, 8, true, false, false, false, true),
            2677 => new FireBlock(Identifier, 8, true, false, false, false, false),
            2678 => new FireBlock(Identifier, 8, false, true, true, true, true),
            2679 => new FireBlock(Identifier, 8, false, true, true, true, false),
            2680 => new FireBlock(Identifier, 8, false, true, true, false, true),
            2681 => new FireBlock(Identifier, 8, false, true, true, false, false),
            2682 => new FireBlock(Identifier, 8, false, true, false, true, true),
            2683 => new FireBlock(Identifier, 8, false, true, false, true, false),
            2684 => new FireBlock(Identifier, 8, false, true, false, false, true),
            2685 => new FireBlock(Identifier, 8, false, true, false, false, false),
            2686 => new FireBlock(Identifier, 8, false, false, true, true, true),
            2687 => new FireBlock(Identifier, 8, false, false, true, true, false),
            2688 => new FireBlock(Identifier, 8, false, false, true, false, true),
            2689 => new FireBlock(Identifier, 8, false, false, true, false, false),
            2690 => new FireBlock(Identifier, 8, false, false, false, true, true),
            2691 => new FireBlock(Identifier, 8, false, false, false, true, false),
            2692 => new FireBlock(Identifier, 8, false, false, false, false, true),
            2693 => new FireBlock(Identifier, 8, false, false, false, false, false),
            2694 => new FireBlock(Identifier, 9, true, true, true, true, true),
            2695 => new FireBlock(Identifier, 9, true, true, true, true, false),
            2696 => new FireBlock(Identifier, 9, true, true, true, false, true),
            2697 => new FireBlock(Identifier, 9, true, true, true, false, false),
            2698 => new FireBlock(Identifier, 9, true, true, false, true, true),
            2699 => new FireBlock(Identifier, 9, true, true, false, true, false),
            2700 => new FireBlock(Identifier, 9, true, true, false, false, true),
            2701 => new FireBlock(Identifier, 9, true, true, false, false, false),
            2702 => new FireBlock(Identifier, 9, true, false, true, true, true),
            2703 => new FireBlock(Identifier, 9, true, false, true, true, false),
            2704 => new FireBlock(Identifier, 9, true, false, true, false, true),
            2705 => new FireBlock(Identifier, 9, true, false, true, false, false),
            2706 => new FireBlock(Identifier, 9, true, false, false, true, true),
            2707 => new FireBlock(Identifier, 9, true, false, false, true, false),
            2708 => new FireBlock(Identifier, 9, true, false, false, false, true),
            2709 => new FireBlock(Identifier, 9, true, false, false, false, false),
            2710 => new FireBlock(Identifier, 9, false, true, true, true, true),
            2711 => new FireBlock(Identifier, 9, false, true, true, true, false),
            2712 => new FireBlock(Identifier, 9, false, true, true, false, true),
            2713 => new FireBlock(Identifier, 9, false, true, true, false, false),
            2714 => new FireBlock(Identifier, 9, false, true, false, true, true),
            2715 => new FireBlock(Identifier, 9, false, true, false, true, false),
            2716 => new FireBlock(Identifier, 9, false, true, false, false, true),
            2717 => new FireBlock(Identifier, 9, false, true, false, false, false),
            2718 => new FireBlock(Identifier, 9, false, false, true, true, true),
            2719 => new FireBlock(Identifier, 9, false, false, true, true, false),
            2720 => new FireBlock(Identifier, 9, false, false, true, false, true),
            2721 => new FireBlock(Identifier, 9, false, false, true, false, false),
            2722 => new FireBlock(Identifier, 9, false, false, false, true, true),
            2723 => new FireBlock(Identifier, 9, false, false, false, true, false),
            2724 => new FireBlock(Identifier, 9, false, false, false, false, true),
            2725 => new FireBlock(Identifier, 9, false, false, false, false, false),
            2726 => new FireBlock(Identifier, 10, true, true, true, true, true),
            2727 => new FireBlock(Identifier, 10, true, true, true, true, false),
            2728 => new FireBlock(Identifier, 10, true, true, true, false, true),
            2729 => new FireBlock(Identifier, 10, true, true, true, false, false),
            2730 => new FireBlock(Identifier, 10, true, true, false, true, true),
            2731 => new FireBlock(Identifier, 10, true, true, false, true, false),
            2732 => new FireBlock(Identifier, 10, true, true, false, false, true),
            2733 => new FireBlock(Identifier, 10, true, true, false, false, false),
            2734 => new FireBlock(Identifier, 10, true, false, true, true, true),
            2735 => new FireBlock(Identifier, 10, true, false, true, true, false),
            2736 => new FireBlock(Identifier, 10, true, false, true, false, true),
            2737 => new FireBlock(Identifier, 10, true, false, true, false, false),
            2738 => new FireBlock(Identifier, 10, true, false, false, true, true),
            2739 => new FireBlock(Identifier, 10, true, false, false, true, false),
            2740 => new FireBlock(Identifier, 10, true, false, false, false, true),
            2741 => new FireBlock(Identifier, 10, true, false, false, false, false),
            2742 => new FireBlock(Identifier, 10, false, true, true, true, true),
            2743 => new FireBlock(Identifier, 10, false, true, true, true, false),
            2744 => new FireBlock(Identifier, 10, false, true, true, false, true),
            2745 => new FireBlock(Identifier, 10, false, true, true, false, false),
            2746 => new FireBlock(Identifier, 10, false, true, false, true, true),
            2747 => new FireBlock(Identifier, 10, false, true, false, true, false),
            2748 => new FireBlock(Identifier, 10, false, true, false, false, true),
            2749 => new FireBlock(Identifier, 10, false, true, false, false, false),
            2750 => new FireBlock(Identifier, 10, false, false, true, true, true),
            2751 => new FireBlock(Identifier, 10, false, false, true, true, false),
            2752 => new FireBlock(Identifier, 10, false, false, true, false, true),
            2753 => new FireBlock(Identifier, 10, false, false, true, false, false),
            2754 => new FireBlock(Identifier, 10, false, false, false, true, true),
            2755 => new FireBlock(Identifier, 10, false, false, false, true, false),
            2756 => new FireBlock(Identifier, 10, false, false, false, false, true),
            2757 => new FireBlock(Identifier, 10, false, false, false, false, false),
            2758 => new FireBlock(Identifier, 11, true, true, true, true, true),
            2759 => new FireBlock(Identifier, 11, true, true, true, true, false),
            2760 => new FireBlock(Identifier, 11, true, true, true, false, true),
            2761 => new FireBlock(Identifier, 11, true, true, true, false, false),
            2762 => new FireBlock(Identifier, 11, true, true, false, true, true),
            2763 => new FireBlock(Identifier, 11, true, true, false, true, false),
            2764 => new FireBlock(Identifier, 11, true, true, false, false, true),
            2765 => new FireBlock(Identifier, 11, true, true, false, false, false),
            2766 => new FireBlock(Identifier, 11, true, false, true, true, true),
            2767 => new FireBlock(Identifier, 11, true, false, true, true, false),
            2768 => new FireBlock(Identifier, 11, true, false, true, false, true),
            2769 => new FireBlock(Identifier, 11, true, false, true, false, false),
            2770 => new FireBlock(Identifier, 11, true, false, false, true, true),
            2771 => new FireBlock(Identifier, 11, true, false, false, true, false),
            2772 => new FireBlock(Identifier, 11, true, false, false, false, true),
            2773 => new FireBlock(Identifier, 11, true, false, false, false, false),
            2774 => new FireBlock(Identifier, 11, false, true, true, true, true),
            2775 => new FireBlock(Identifier, 11, false, true, true, true, false),
            2776 => new FireBlock(Identifier, 11, false, true, true, false, true),
            2777 => new FireBlock(Identifier, 11, false, true, true, false, false),
            2778 => new FireBlock(Identifier, 11, false, true, false, true, true),
            2779 => new FireBlock(Identifier, 11, false, true, false, true, false),
            2780 => new FireBlock(Identifier, 11, false, true, false, false, true),
            2781 => new FireBlock(Identifier, 11, false, true, false, false, false),
            2782 => new FireBlock(Identifier, 11, false, false, true, true, true),
            2783 => new FireBlock(Identifier, 11, false, false, true, true, false),
            2784 => new FireBlock(Identifier, 11, false, false, true, false, true),
            2785 => new FireBlock(Identifier, 11, false, false, true, false, false),
            2786 => new FireBlock(Identifier, 11, false, false, false, true, true),
            2787 => new FireBlock(Identifier, 11, false, false, false, true, false),
            2788 => new FireBlock(Identifier, 11, false, false, false, false, true),
            2789 => new FireBlock(Identifier, 11, false, false, false, false, false),
            2790 => new FireBlock(Identifier, 12, true, true, true, true, true),
            2791 => new FireBlock(Identifier, 12, true, true, true, true, false),
            2792 => new FireBlock(Identifier, 12, true, true, true, false, true),
            2793 => new FireBlock(Identifier, 12, true, true, true, false, false),
            2794 => new FireBlock(Identifier, 12, true, true, false, true, true),
            2795 => new FireBlock(Identifier, 12, true, true, false, true, false),
            2796 => new FireBlock(Identifier, 12, true, true, false, false, true),
            2797 => new FireBlock(Identifier, 12, true, true, false, false, false),
            2798 => new FireBlock(Identifier, 12, true, false, true, true, true),
            2799 => new FireBlock(Identifier, 12, true, false, true, true, false),
            2800 => new FireBlock(Identifier, 12, true, false, true, false, true),
            2801 => new FireBlock(Identifier, 12, true, false, true, false, false),
            2802 => new FireBlock(Identifier, 12, true, false, false, true, true),
            2803 => new FireBlock(Identifier, 12, true, false, false, true, false),
            2804 => new FireBlock(Identifier, 12, true, false, false, false, true),
            2805 => new FireBlock(Identifier, 12, true, false, false, false, false),
            2806 => new FireBlock(Identifier, 12, false, true, true, true, true),
            2807 => new FireBlock(Identifier, 12, false, true, true, true, false),
            2808 => new FireBlock(Identifier, 12, false, true, true, false, true),
            2809 => new FireBlock(Identifier, 12, false, true, true, false, false),
            2810 => new FireBlock(Identifier, 12, false, true, false, true, true),
            2811 => new FireBlock(Identifier, 12, false, true, false, true, false),
            2812 => new FireBlock(Identifier, 12, false, true, false, false, true),
            2813 => new FireBlock(Identifier, 12, false, true, false, false, false),
            2814 => new FireBlock(Identifier, 12, false, false, true, true, true),
            2815 => new FireBlock(Identifier, 12, false, false, true, true, false),
            2816 => new FireBlock(Identifier, 12, false, false, true, false, true),
            2817 => new FireBlock(Identifier, 12, false, false, true, false, false),
            2818 => new FireBlock(Identifier, 12, false, false, false, true, true),
            2819 => new FireBlock(Identifier, 12, false, false, false, true, false),
            2820 => new FireBlock(Identifier, 12, false, false, false, false, true),
            2821 => new FireBlock(Identifier, 12, false, false, false, false, false),
            2822 => new FireBlock(Identifier, 13, true, true, true, true, true),
            2823 => new FireBlock(Identifier, 13, true, true, true, true, false),
            2824 => new FireBlock(Identifier, 13, true, true, true, false, true),
            2825 => new FireBlock(Identifier, 13, true, true, true, false, false),
            2826 => new FireBlock(Identifier, 13, true, true, false, true, true),
            2827 => new FireBlock(Identifier, 13, true, true, false, true, false),
            2828 => new FireBlock(Identifier, 13, true, true, false, false, true),
            2829 => new FireBlock(Identifier, 13, true, true, false, false, false),
            2830 => new FireBlock(Identifier, 13, true, false, true, true, true),
            2831 => new FireBlock(Identifier, 13, true, false, true, true, false),
            2832 => new FireBlock(Identifier, 13, true, false, true, false, true),
            2833 => new FireBlock(Identifier, 13, true, false, true, false, false),
            2834 => new FireBlock(Identifier, 13, true, false, false, true, true),
            2835 => new FireBlock(Identifier, 13, true, false, false, true, false),
            2836 => new FireBlock(Identifier, 13, true, false, false, false, true),
            2837 => new FireBlock(Identifier, 13, true, false, false, false, false),
            2838 => new FireBlock(Identifier, 13, false, true, true, true, true),
            2839 => new FireBlock(Identifier, 13, false, true, true, true, false),
            2840 => new FireBlock(Identifier, 13, false, true, true, false, true),
            2841 => new FireBlock(Identifier, 13, false, true, true, false, false),
            2842 => new FireBlock(Identifier, 13, false, true, false, true, true),
            2843 => new FireBlock(Identifier, 13, false, true, false, true, false),
            2844 => new FireBlock(Identifier, 13, false, true, false, false, true),
            2845 => new FireBlock(Identifier, 13, false, true, false, false, false),
            2846 => new FireBlock(Identifier, 13, false, false, true, true, true),
            2847 => new FireBlock(Identifier, 13, false, false, true, true, false),
            2848 => new FireBlock(Identifier, 13, false, false, true, false, true),
            2849 => new FireBlock(Identifier, 13, false, false, true, false, false),
            2850 => new FireBlock(Identifier, 13, false, false, false, true, true),
            2851 => new FireBlock(Identifier, 13, false, false, false, true, false),
            2852 => new FireBlock(Identifier, 13, false, false, false, false, true),
            2853 => new FireBlock(Identifier, 13, false, false, false, false, false),
            2854 => new FireBlock(Identifier, 14, true, true, true, true, true),
            2855 => new FireBlock(Identifier, 14, true, true, true, true, false),
            2856 => new FireBlock(Identifier, 14, true, true, true, false, true),
            2857 => new FireBlock(Identifier, 14, true, true, true, false, false),
            2858 => new FireBlock(Identifier, 14, true, true, false, true, true),
            2859 => new FireBlock(Identifier, 14, true, true, false, true, false),
            2860 => new FireBlock(Identifier, 14, true, true, false, false, true),
            2861 => new FireBlock(Identifier, 14, true, true, false, false, false),
            2862 => new FireBlock(Identifier, 14, true, false, true, true, true),
            2863 => new FireBlock(Identifier, 14, true, false, true, true, false),
            2864 => new FireBlock(Identifier, 14, true, false, true, false, true),
            2865 => new FireBlock(Identifier, 14, true, false, true, false, false),
            2866 => new FireBlock(Identifier, 14, true, false, false, true, true),
            2867 => new FireBlock(Identifier, 14, true, false, false, true, false),
            2868 => new FireBlock(Identifier, 14, true, false, false, false, true),
            2869 => new FireBlock(Identifier, 14, true, false, false, false, false),
            2870 => new FireBlock(Identifier, 14, false, true, true, true, true),
            2871 => new FireBlock(Identifier, 14, false, true, true, true, false),
            2872 => new FireBlock(Identifier, 14, false, true, true, false, true),
            2873 => new FireBlock(Identifier, 14, false, true, true, false, false),
            2874 => new FireBlock(Identifier, 14, false, true, false, true, true),
            2875 => new FireBlock(Identifier, 14, false, true, false, true, false),
            2876 => new FireBlock(Identifier, 14, false, true, false, false, true),
            2877 => new FireBlock(Identifier, 14, false, true, false, false, false),
            2878 => new FireBlock(Identifier, 14, false, false, true, true, true),
            2879 => new FireBlock(Identifier, 14, false, false, true, true, false),
            2880 => new FireBlock(Identifier, 14, false, false, true, false, true),
            2881 => new FireBlock(Identifier, 14, false, false, true, false, false),
            2882 => new FireBlock(Identifier, 14, false, false, false, true, true),
            2883 => new FireBlock(Identifier, 14, false, false, false, true, false),
            2884 => new FireBlock(Identifier, 14, false, false, false, false, true),
            2885 => new FireBlock(Identifier, 14, false, false, false, false, false),
            2886 => new FireBlock(Identifier, 15, true, true, true, true, true),
            2887 => new FireBlock(Identifier, 15, true, true, true, true, false),
            2888 => new FireBlock(Identifier, 15, true, true, true, false, true),
            2889 => new FireBlock(Identifier, 15, true, true, true, false, false),
            2890 => new FireBlock(Identifier, 15, true, true, false, true, true),
            2891 => new FireBlock(Identifier, 15, true, true, false, true, false),
            2892 => new FireBlock(Identifier, 15, true, true, false, false, true),
            2893 => new FireBlock(Identifier, 15, true, true, false, false, false),
            2894 => new FireBlock(Identifier, 15, true, false, true, true, true),
            2895 => new FireBlock(Identifier, 15, true, false, true, true, false),
            2896 => new FireBlock(Identifier, 15, true, false, true, false, true),
            2897 => new FireBlock(Identifier, 15, true, false, true, false, false),
            2898 => new FireBlock(Identifier, 15, true, false, false, true, true),
            2899 => new FireBlock(Identifier, 15, true, false, false, true, false),
            2900 => new FireBlock(Identifier, 15, true, false, false, false, true),
            2901 => new FireBlock(Identifier, 15, true, false, false, false, false),
            2902 => new FireBlock(Identifier, 15, false, true, true, true, true),
            2903 => new FireBlock(Identifier, 15, false, true, true, true, false),
            2904 => new FireBlock(Identifier, 15, false, true, true, false, true),
            2905 => new FireBlock(Identifier, 15, false, true, true, false, false),
            2906 => new FireBlock(Identifier, 15, false, true, false, true, true),
            2907 => new FireBlock(Identifier, 15, false, true, false, true, false),
            2908 => new FireBlock(Identifier, 15, false, true, false, false, true),
            2909 => new FireBlock(Identifier, 15, false, true, false, false, false),
            2910 => new FireBlock(Identifier, 15, false, false, true, true, true),
            2911 => new FireBlock(Identifier, 15, false, false, true, true, false),
            2912 => new FireBlock(Identifier, 15, false, false, true, false, true),
            2913 => new FireBlock(Identifier, 15, false, false, true, false, false),
            2914 => new FireBlock(Identifier, 15, false, false, false, true, true),
            2915 => new FireBlock(Identifier, 15, false, false, false, true, false),
            2916 => new FireBlock(Identifier, 15, false, false, false, false, true),
            2917 => new FireBlock(Identifier, 15, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Age = int.Parse(properties["age"].GetString()),
            East = properties["east"].GetString() == "true",
            North = properties["north"].GetString() == "true",
            South = properties["south"].GetString() == "true",
            Up = properties["up"].GetString() == "true",
            West = properties["west"].GetString() == "true",
        };
    }
    
}
