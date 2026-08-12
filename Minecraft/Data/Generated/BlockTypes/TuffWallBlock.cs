using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record TuffWallBlock(Identifier Identifier, WallSide East, WallSide North, WallSide South, bool Up, bool Waterlogged, WallSide West) : IBlock {
    public Identifier Category => "minecraft:wall";
    public double Hardness => 1.5;
    public double ExplosionResistance => 6;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => true;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "tuff";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:tuff_wall";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.0, 0.75]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.5, 0.75]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.0, 0.75]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.5, 0.75]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 43;
    public string TranslationKey => "block.minecraft.tuff_wall";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                WallSide.None => North switch {
                    WallSide.None => South switch {
                        WallSide.None => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23539,
                                    WallSide.Low => 23540,
                                    WallSide.Tall => 23541,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23542,
                                    WallSide.Low => 23543,
                                    WallSide.Tall => 23544,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23545,
                                    WallSide.Low => 23546,
                                    WallSide.Tall => 23547,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23548,
                                    WallSide.Low => 23549,
                                    WallSide.Tall => 23550,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23551,
                                    WallSide.Low => 23552,
                                    WallSide.Tall => 23553,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23554,
                                    WallSide.Low => 23555,
                                    WallSide.Tall => 23556,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23557,
                                    WallSide.Low => 23558,
                                    WallSide.Tall => 23559,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23560,
                                    WallSide.Low => 23561,
                                    WallSide.Tall => 23562,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23563,
                                    WallSide.Low => 23564,
                                    WallSide.Tall => 23565,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23566,
                                    WallSide.Low => 23567,
                                    WallSide.Tall => 23568,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23569,
                                    WallSide.Low => 23570,
                                    WallSide.Tall => 23571,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23572,
                                    WallSide.Low => 23573,
                                    WallSide.Tall => 23574,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                    },
                    WallSide.Low => South switch {
                        WallSide.None => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23575,
                                    WallSide.Low => 23576,
                                    WallSide.Tall => 23577,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23578,
                                    WallSide.Low => 23579,
                                    WallSide.Tall => 23580,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23581,
                                    WallSide.Low => 23582,
                                    WallSide.Tall => 23583,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23584,
                                    WallSide.Low => 23585,
                                    WallSide.Tall => 23586,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23587,
                                    WallSide.Low => 23588,
                                    WallSide.Tall => 23589,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23590,
                                    WallSide.Low => 23591,
                                    WallSide.Tall => 23592,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23593,
                                    WallSide.Low => 23594,
                                    WallSide.Tall => 23595,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23596,
                                    WallSide.Low => 23597,
                                    WallSide.Tall => 23598,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23599,
                                    WallSide.Low => 23600,
                                    WallSide.Tall => 23601,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23602,
                                    WallSide.Low => 23603,
                                    WallSide.Tall => 23604,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23605,
                                    WallSide.Low => 23606,
                                    WallSide.Tall => 23607,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23608,
                                    WallSide.Low => 23609,
                                    WallSide.Tall => 23610,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                    },
                    WallSide.Tall => South switch {
                        WallSide.None => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23611,
                                    WallSide.Low => 23612,
                                    WallSide.Tall => 23613,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23614,
                                    WallSide.Low => 23615,
                                    WallSide.Tall => 23616,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23617,
                                    WallSide.Low => 23618,
                                    WallSide.Tall => 23619,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23620,
                                    WallSide.Low => 23621,
                                    WallSide.Tall => 23622,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23623,
                                    WallSide.Low => 23624,
                                    WallSide.Tall => 23625,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23626,
                                    WallSide.Low => 23627,
                                    WallSide.Tall => 23628,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23629,
                                    WallSide.Low => 23630,
                                    WallSide.Tall => 23631,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23632,
                                    WallSide.Low => 23633,
                                    WallSide.Tall => 23634,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23635,
                                    WallSide.Low => 23636,
                                    WallSide.Tall => 23637,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23638,
                                    WallSide.Low => 23639,
                                    WallSide.Tall => 23640,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23641,
                                    WallSide.Low => 23642,
                                    WallSide.Tall => 23643,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23644,
                                    WallSide.Low => 23645,
                                    WallSide.Tall => 23646,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                },
                WallSide.Low => North switch {
                    WallSide.None => South switch {
                        WallSide.None => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23647,
                                    WallSide.Low => 23648,
                                    WallSide.Tall => 23649,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23650,
                                    WallSide.Low => 23651,
                                    WallSide.Tall => 23652,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23653,
                                    WallSide.Low => 23654,
                                    WallSide.Tall => 23655,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23656,
                                    WallSide.Low => 23657,
                                    WallSide.Tall => 23658,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23659,
                                    WallSide.Low => 23660,
                                    WallSide.Tall => 23661,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23662,
                                    WallSide.Low => 23663,
                                    WallSide.Tall => 23664,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23665,
                                    WallSide.Low => 23666,
                                    WallSide.Tall => 23667,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23668,
                                    WallSide.Low => 23669,
                                    WallSide.Tall => 23670,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23671,
                                    WallSide.Low => 23672,
                                    WallSide.Tall => 23673,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23674,
                                    WallSide.Low => 23675,
                                    WallSide.Tall => 23676,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23677,
                                    WallSide.Low => 23678,
                                    WallSide.Tall => 23679,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23680,
                                    WallSide.Low => 23681,
                                    WallSide.Tall => 23682,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                    },
                    WallSide.Low => South switch {
                        WallSide.None => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23683,
                                    WallSide.Low => 23684,
                                    WallSide.Tall => 23685,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23686,
                                    WallSide.Low => 23687,
                                    WallSide.Tall => 23688,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23689,
                                    WallSide.Low => 23690,
                                    WallSide.Tall => 23691,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23692,
                                    WallSide.Low => 23693,
                                    WallSide.Tall => 23694,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23695,
                                    WallSide.Low => 23696,
                                    WallSide.Tall => 23697,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23698,
                                    WallSide.Low => 23699,
                                    WallSide.Tall => 23700,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23701,
                                    WallSide.Low => 23702,
                                    WallSide.Tall => 23703,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23704,
                                    WallSide.Low => 23705,
                                    WallSide.Tall => 23706,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23707,
                                    WallSide.Low => 23708,
                                    WallSide.Tall => 23709,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23710,
                                    WallSide.Low => 23711,
                                    WallSide.Tall => 23712,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23713,
                                    WallSide.Low => 23714,
                                    WallSide.Tall => 23715,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23716,
                                    WallSide.Low => 23717,
                                    WallSide.Tall => 23718,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                    },
                    WallSide.Tall => South switch {
                        WallSide.None => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23719,
                                    WallSide.Low => 23720,
                                    WallSide.Tall => 23721,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23722,
                                    WallSide.Low => 23723,
                                    WallSide.Tall => 23724,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23725,
                                    WallSide.Low => 23726,
                                    WallSide.Tall => 23727,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23728,
                                    WallSide.Low => 23729,
                                    WallSide.Tall => 23730,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23731,
                                    WallSide.Low => 23732,
                                    WallSide.Tall => 23733,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23734,
                                    WallSide.Low => 23735,
                                    WallSide.Tall => 23736,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23737,
                                    WallSide.Low => 23738,
                                    WallSide.Tall => 23739,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23740,
                                    WallSide.Low => 23741,
                                    WallSide.Tall => 23742,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23743,
                                    WallSide.Low => 23744,
                                    WallSide.Tall => 23745,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23746,
                                    WallSide.Low => 23747,
                                    WallSide.Tall => 23748,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23749,
                                    WallSide.Low => 23750,
                                    WallSide.Tall => 23751,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23752,
                                    WallSide.Low => 23753,
                                    WallSide.Tall => 23754,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                },
                WallSide.Tall => North switch {
                    WallSide.None => South switch {
                        WallSide.None => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23755,
                                    WallSide.Low => 23756,
                                    WallSide.Tall => 23757,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23758,
                                    WallSide.Low => 23759,
                                    WallSide.Tall => 23760,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23761,
                                    WallSide.Low => 23762,
                                    WallSide.Tall => 23763,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23764,
                                    WallSide.Low => 23765,
                                    WallSide.Tall => 23766,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23767,
                                    WallSide.Low => 23768,
                                    WallSide.Tall => 23769,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23770,
                                    WallSide.Low => 23771,
                                    WallSide.Tall => 23772,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23773,
                                    WallSide.Low => 23774,
                                    WallSide.Tall => 23775,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23776,
                                    WallSide.Low => 23777,
                                    WallSide.Tall => 23778,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23779,
                                    WallSide.Low => 23780,
                                    WallSide.Tall => 23781,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23782,
                                    WallSide.Low => 23783,
                                    WallSide.Tall => 23784,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23785,
                                    WallSide.Low => 23786,
                                    WallSide.Tall => 23787,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23788,
                                    WallSide.Low => 23789,
                                    WallSide.Tall => 23790,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                    },
                    WallSide.Low => South switch {
                        WallSide.None => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23791,
                                    WallSide.Low => 23792,
                                    WallSide.Tall => 23793,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23794,
                                    WallSide.Low => 23795,
                                    WallSide.Tall => 23796,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23797,
                                    WallSide.Low => 23798,
                                    WallSide.Tall => 23799,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23800,
                                    WallSide.Low => 23801,
                                    WallSide.Tall => 23802,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23803,
                                    WallSide.Low => 23804,
                                    WallSide.Tall => 23805,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23806,
                                    WallSide.Low => 23807,
                                    WallSide.Tall => 23808,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23809,
                                    WallSide.Low => 23810,
                                    WallSide.Tall => 23811,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23812,
                                    WallSide.Low => 23813,
                                    WallSide.Tall => 23814,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23815,
                                    WallSide.Low => 23816,
                                    WallSide.Tall => 23817,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23818,
                                    WallSide.Low => 23819,
                                    WallSide.Tall => 23820,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23821,
                                    WallSide.Low => 23822,
                                    WallSide.Tall => 23823,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23824,
                                    WallSide.Low => 23825,
                                    WallSide.Tall => 23826,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                    },
                    WallSide.Tall => South switch {
                        WallSide.None => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23827,
                                    WallSide.Low => 23828,
                                    WallSide.Tall => 23829,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23830,
                                    WallSide.Low => 23831,
                                    WallSide.Tall => 23832,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23833,
                                    WallSide.Low => 23834,
                                    WallSide.Tall => 23835,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23836,
                                    WallSide.Low => 23837,
                                    WallSide.Tall => 23838,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23839,
                                    WallSide.Low => 23840,
                                    WallSide.Tall => 23841,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23842,
                                    WallSide.Low => 23843,
                                    WallSide.Tall => 23844,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23845,
                                    WallSide.Low => 23846,
                                    WallSide.Tall => 23847,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23848,
                                    WallSide.Low => 23849,
                                    WallSide.Tall => 23850,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23851,
                                    WallSide.Low => 23852,
                                    WallSide.Tall => 23853,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23854,
                                    WallSide.Low => 23855,
                                    WallSide.Tall => 23856,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23857,
                                    WallSide.Low => 23858,
                                    WallSide.Tall => 23859,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23860,
                                    WallSide.Low => 23861,
                                    WallSide.Tall => 23862,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(East), East, "Unknown value for property east.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23539 => new TuffWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.None),
            23540 => new TuffWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.Low),
            23541 => new TuffWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            23542 => new TuffWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.None),
            23543 => new TuffWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.Low),
            23544 => new TuffWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            23545 => new TuffWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.None),
            23546 => new TuffWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.Low),
            23547 => new TuffWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            23548 => new TuffWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.None),
            23549 => new TuffWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.Low),
            23550 => new TuffWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            23551 => new TuffWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.None),
            23552 => new TuffWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            23553 => new TuffWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            23554 => new TuffWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.None),
            23555 => new TuffWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            23556 => new TuffWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            23557 => new TuffWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.None),
            23558 => new TuffWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            23559 => new TuffWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            23560 => new TuffWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.None),
            23561 => new TuffWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            23562 => new TuffWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            23563 => new TuffWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            23564 => new TuffWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            23565 => new TuffWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            23566 => new TuffWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            23567 => new TuffWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            23568 => new TuffWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            23569 => new TuffWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            23570 => new TuffWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            23571 => new TuffWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            23572 => new TuffWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            23573 => new TuffWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            23574 => new TuffWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            23575 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.None),
            23576 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            23577 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            23578 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.None),
            23579 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            23580 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            23581 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.None),
            23582 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            23583 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            23584 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.None),
            23585 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            23586 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            23587 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            23588 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            23589 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            23590 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            23591 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            23592 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            23593 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            23594 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            23595 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            23596 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            23597 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            23598 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            23599 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            23600 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            23601 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            23602 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            23603 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            23604 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            23605 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            23606 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            23607 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            23608 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            23609 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            23610 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            23611 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            23612 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            23613 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            23614 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            23615 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            23616 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            23617 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            23618 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            23619 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            23620 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            23621 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            23622 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            23623 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            23624 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            23625 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            23626 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            23627 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            23628 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            23629 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            23630 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            23631 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            23632 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            23633 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            23634 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            23635 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            23636 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            23637 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            23638 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            23639 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            23640 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            23641 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            23642 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            23643 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            23644 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            23645 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            23646 => new TuffWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
            23647 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.None),
            23648 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.Low),
            23649 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            23650 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.None),
            23651 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.Low),
            23652 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            23653 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.None),
            23654 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.Low),
            23655 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            23656 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.None),
            23657 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.Low),
            23658 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            23659 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.None),
            23660 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            23661 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            23662 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.None),
            23663 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            23664 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            23665 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.None),
            23666 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            23667 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            23668 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.None),
            23669 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            23670 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            23671 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            23672 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            23673 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            23674 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            23675 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            23676 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            23677 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            23678 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            23679 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            23680 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            23681 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            23682 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            23683 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.None),
            23684 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            23685 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            23686 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.None),
            23687 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            23688 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            23689 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.None),
            23690 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            23691 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            23692 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.None),
            23693 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            23694 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            23695 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            23696 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            23697 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            23698 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            23699 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            23700 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            23701 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            23702 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            23703 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            23704 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            23705 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            23706 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            23707 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            23708 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            23709 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            23710 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            23711 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            23712 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            23713 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            23714 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            23715 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            23716 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            23717 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            23718 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            23719 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            23720 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            23721 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            23722 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            23723 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            23724 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            23725 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            23726 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            23727 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            23728 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            23729 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            23730 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            23731 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            23732 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            23733 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            23734 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            23735 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            23736 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            23737 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            23738 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            23739 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            23740 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            23741 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            23742 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            23743 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            23744 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            23745 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            23746 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            23747 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            23748 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            23749 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            23750 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            23751 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            23752 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            23753 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            23754 => new TuffWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
            23755 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.None),
            23756 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.Low),
            23757 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            23758 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.None),
            23759 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.Low),
            23760 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            23761 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.None),
            23762 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.Low),
            23763 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            23764 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.None),
            23765 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.Low),
            23766 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            23767 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.None),
            23768 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            23769 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            23770 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.None),
            23771 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            23772 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            23773 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.None),
            23774 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            23775 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            23776 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.None),
            23777 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            23778 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            23779 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            23780 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            23781 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            23782 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            23783 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            23784 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            23785 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            23786 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            23787 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            23788 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            23789 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            23790 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            23791 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.None),
            23792 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            23793 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            23794 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.None),
            23795 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            23796 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            23797 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.None),
            23798 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            23799 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            23800 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.None),
            23801 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            23802 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            23803 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            23804 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            23805 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            23806 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            23807 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            23808 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            23809 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            23810 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            23811 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            23812 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            23813 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            23814 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            23815 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            23816 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            23817 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            23818 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            23819 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            23820 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            23821 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            23822 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            23823 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            23824 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            23825 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            23826 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            23827 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            23828 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            23829 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            23830 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            23831 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            23832 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            23833 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            23834 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            23835 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            23836 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            23837 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            23838 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            23839 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            23840 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            23841 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            23842 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            23843 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            23844 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            23845 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            23846 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            23847 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            23848 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            23849 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            23850 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            23851 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            23852 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            23853 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            23854 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            23855 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            23856 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            23857 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            23858 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            23859 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            23860 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            23861 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            23862 => new TuffWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            East = properties.Contains("east") ? WallSideExtensions.FromString(properties["east"].GetString()) : East,
            North = properties.Contains("north") ? WallSideExtensions.FromString(properties["north"].GetString()) : North,
            South = properties.Contains("south") ? WallSideExtensions.FromString(properties["south"].GetString()) : South,
            Up = properties.Contains("up") ? properties["up"].GetString() == "true" : Up,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
            West = properties.Contains("west") ? WallSideExtensions.FromString(properties["west"].GetString()) : West,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("east", new StringTag(East.ToName())),
            ("north", new StringTag(North.ToName())),
            ("south", new StringTag(South.ToName())),
            ("up", new StringTag(Up.ToString().ToLower())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower())),
            ("west", new StringTag(West.ToName()))
        );
    }
    
}
