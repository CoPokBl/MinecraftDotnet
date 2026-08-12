using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedBlackstoneWallBlock(Identifier Identifier, WallSide East, WallSide North, WallSide South, bool Up, bool Waterlogged, WallSide West) : IBlock {
    public Identifier Category => "minecraft:wall";
    public double Hardness => 2;
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
    public string SoundType => "stone";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:polished_blackstone_wall";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.0, 0.75]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.5, 0.75]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.0, 0.75]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.5, 0.75]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 29;
    public string TranslationKey => "block.minecraft.polished_blackstone_wall";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                WallSide.None => North switch {
                    WallSide.None => South switch {
                        WallSide.None => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 22769,
                                    WallSide.Low => 22770,
                                    WallSide.Tall => 22771,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22772,
                                    WallSide.Low => 22773,
                                    WallSide.Tall => 22774,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 22775,
                                    WallSide.Low => 22776,
                                    WallSide.Tall => 22777,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22778,
                                    WallSide.Low => 22779,
                                    WallSide.Tall => 22780,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 22781,
                                    WallSide.Low => 22782,
                                    WallSide.Tall => 22783,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22784,
                                    WallSide.Low => 22785,
                                    WallSide.Tall => 22786,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 22787,
                                    WallSide.Low => 22788,
                                    WallSide.Tall => 22789,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22790,
                                    WallSide.Low => 22791,
                                    WallSide.Tall => 22792,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 22793,
                                    WallSide.Low => 22794,
                                    WallSide.Tall => 22795,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22796,
                                    WallSide.Low => 22797,
                                    WallSide.Tall => 22798,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 22799,
                                    WallSide.Low => 22800,
                                    WallSide.Tall => 22801,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22802,
                                    WallSide.Low => 22803,
                                    WallSide.Tall => 22804,
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
                                    WallSide.None => 22805,
                                    WallSide.Low => 22806,
                                    WallSide.Tall => 22807,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22808,
                                    WallSide.Low => 22809,
                                    WallSide.Tall => 22810,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 22811,
                                    WallSide.Low => 22812,
                                    WallSide.Tall => 22813,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22814,
                                    WallSide.Low => 22815,
                                    WallSide.Tall => 22816,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 22817,
                                    WallSide.Low => 22818,
                                    WallSide.Tall => 22819,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22820,
                                    WallSide.Low => 22821,
                                    WallSide.Tall => 22822,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 22823,
                                    WallSide.Low => 22824,
                                    WallSide.Tall => 22825,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22826,
                                    WallSide.Low => 22827,
                                    WallSide.Tall => 22828,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 22829,
                                    WallSide.Low => 22830,
                                    WallSide.Tall => 22831,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22832,
                                    WallSide.Low => 22833,
                                    WallSide.Tall => 22834,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 22835,
                                    WallSide.Low => 22836,
                                    WallSide.Tall => 22837,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22838,
                                    WallSide.Low => 22839,
                                    WallSide.Tall => 22840,
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
                                    WallSide.None => 22841,
                                    WallSide.Low => 22842,
                                    WallSide.Tall => 22843,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22844,
                                    WallSide.Low => 22845,
                                    WallSide.Tall => 22846,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 22847,
                                    WallSide.Low => 22848,
                                    WallSide.Tall => 22849,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22850,
                                    WallSide.Low => 22851,
                                    WallSide.Tall => 22852,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 22853,
                                    WallSide.Low => 22854,
                                    WallSide.Tall => 22855,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22856,
                                    WallSide.Low => 22857,
                                    WallSide.Tall => 22858,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 22859,
                                    WallSide.Low => 22860,
                                    WallSide.Tall => 22861,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22862,
                                    WallSide.Low => 22863,
                                    WallSide.Tall => 22864,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 22865,
                                    WallSide.Low => 22866,
                                    WallSide.Tall => 22867,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22868,
                                    WallSide.Low => 22869,
                                    WallSide.Tall => 22870,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 22871,
                                    WallSide.Low => 22872,
                                    WallSide.Tall => 22873,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22874,
                                    WallSide.Low => 22875,
                                    WallSide.Tall => 22876,
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
                                    WallSide.None => 22877,
                                    WallSide.Low => 22878,
                                    WallSide.Tall => 22879,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22880,
                                    WallSide.Low => 22881,
                                    WallSide.Tall => 22882,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 22883,
                                    WallSide.Low => 22884,
                                    WallSide.Tall => 22885,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22886,
                                    WallSide.Low => 22887,
                                    WallSide.Tall => 22888,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 22889,
                                    WallSide.Low => 22890,
                                    WallSide.Tall => 22891,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22892,
                                    WallSide.Low => 22893,
                                    WallSide.Tall => 22894,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 22895,
                                    WallSide.Low => 22896,
                                    WallSide.Tall => 22897,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22898,
                                    WallSide.Low => 22899,
                                    WallSide.Tall => 22900,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 22901,
                                    WallSide.Low => 22902,
                                    WallSide.Tall => 22903,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22904,
                                    WallSide.Low => 22905,
                                    WallSide.Tall => 22906,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 22907,
                                    WallSide.Low => 22908,
                                    WallSide.Tall => 22909,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22910,
                                    WallSide.Low => 22911,
                                    WallSide.Tall => 22912,
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
                                    WallSide.None => 22913,
                                    WallSide.Low => 22914,
                                    WallSide.Tall => 22915,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22916,
                                    WallSide.Low => 22917,
                                    WallSide.Tall => 22918,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 22919,
                                    WallSide.Low => 22920,
                                    WallSide.Tall => 22921,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22922,
                                    WallSide.Low => 22923,
                                    WallSide.Tall => 22924,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 22925,
                                    WallSide.Low => 22926,
                                    WallSide.Tall => 22927,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22928,
                                    WallSide.Low => 22929,
                                    WallSide.Tall => 22930,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 22931,
                                    WallSide.Low => 22932,
                                    WallSide.Tall => 22933,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22934,
                                    WallSide.Low => 22935,
                                    WallSide.Tall => 22936,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 22937,
                                    WallSide.Low => 22938,
                                    WallSide.Tall => 22939,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22940,
                                    WallSide.Low => 22941,
                                    WallSide.Tall => 22942,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 22943,
                                    WallSide.Low => 22944,
                                    WallSide.Tall => 22945,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22946,
                                    WallSide.Low => 22947,
                                    WallSide.Tall => 22948,
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
                                    WallSide.None => 22949,
                                    WallSide.Low => 22950,
                                    WallSide.Tall => 22951,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22952,
                                    WallSide.Low => 22953,
                                    WallSide.Tall => 22954,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 22955,
                                    WallSide.Low => 22956,
                                    WallSide.Tall => 22957,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22958,
                                    WallSide.Low => 22959,
                                    WallSide.Tall => 22960,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 22961,
                                    WallSide.Low => 22962,
                                    WallSide.Tall => 22963,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22964,
                                    WallSide.Low => 22965,
                                    WallSide.Tall => 22966,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 22967,
                                    WallSide.Low => 22968,
                                    WallSide.Tall => 22969,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22970,
                                    WallSide.Low => 22971,
                                    WallSide.Tall => 22972,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 22973,
                                    WallSide.Low => 22974,
                                    WallSide.Tall => 22975,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22976,
                                    WallSide.Low => 22977,
                                    WallSide.Tall => 22978,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 22979,
                                    WallSide.Low => 22980,
                                    WallSide.Tall => 22981,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22982,
                                    WallSide.Low => 22983,
                                    WallSide.Tall => 22984,
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
                                    WallSide.None => 22985,
                                    WallSide.Low => 22986,
                                    WallSide.Tall => 22987,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22988,
                                    WallSide.Low => 22989,
                                    WallSide.Tall => 22990,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 22991,
                                    WallSide.Low => 22992,
                                    WallSide.Tall => 22993,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 22994,
                                    WallSide.Low => 22995,
                                    WallSide.Tall => 22996,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 22997,
                                    WallSide.Low => 22998,
                                    WallSide.Tall => 22999,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23000,
                                    WallSide.Low => 23001,
                                    WallSide.Tall => 23002,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23003,
                                    WallSide.Low => 23004,
                                    WallSide.Tall => 23005,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23006,
                                    WallSide.Low => 23007,
                                    WallSide.Tall => 23008,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23009,
                                    WallSide.Low => 23010,
                                    WallSide.Tall => 23011,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23012,
                                    WallSide.Low => 23013,
                                    WallSide.Tall => 23014,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23015,
                                    WallSide.Low => 23016,
                                    WallSide.Tall => 23017,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23018,
                                    WallSide.Low => 23019,
                                    WallSide.Tall => 23020,
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
                                    WallSide.None => 23021,
                                    WallSide.Low => 23022,
                                    WallSide.Tall => 23023,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23024,
                                    WallSide.Low => 23025,
                                    WallSide.Tall => 23026,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23027,
                                    WallSide.Low => 23028,
                                    WallSide.Tall => 23029,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23030,
                                    WallSide.Low => 23031,
                                    WallSide.Tall => 23032,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23033,
                                    WallSide.Low => 23034,
                                    WallSide.Tall => 23035,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23036,
                                    WallSide.Low => 23037,
                                    WallSide.Tall => 23038,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23039,
                                    WallSide.Low => 23040,
                                    WallSide.Tall => 23041,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23042,
                                    WallSide.Low => 23043,
                                    WallSide.Tall => 23044,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23045,
                                    WallSide.Low => 23046,
                                    WallSide.Tall => 23047,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23048,
                                    WallSide.Low => 23049,
                                    WallSide.Tall => 23050,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23051,
                                    WallSide.Low => 23052,
                                    WallSide.Tall => 23053,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23054,
                                    WallSide.Low => 23055,
                                    WallSide.Tall => 23056,
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
                                    WallSide.None => 23057,
                                    WallSide.Low => 23058,
                                    WallSide.Tall => 23059,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23060,
                                    WallSide.Low => 23061,
                                    WallSide.Tall => 23062,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23063,
                                    WallSide.Low => 23064,
                                    WallSide.Tall => 23065,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23066,
                                    WallSide.Low => 23067,
                                    WallSide.Tall => 23068,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23069,
                                    WallSide.Low => 23070,
                                    WallSide.Tall => 23071,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23072,
                                    WallSide.Low => 23073,
                                    WallSide.Tall => 23074,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23075,
                                    WallSide.Low => 23076,
                                    WallSide.Tall => 23077,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23078,
                                    WallSide.Low => 23079,
                                    WallSide.Tall => 23080,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23081,
                                    WallSide.Low => 23082,
                                    WallSide.Tall => 23083,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23084,
                                    WallSide.Low => 23085,
                                    WallSide.Tall => 23086,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 23087,
                                    WallSide.Low => 23088,
                                    WallSide.Tall => 23089,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 23090,
                                    WallSide.Low => 23091,
                                    WallSide.Tall => 23092,
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
            22769 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.None),
            22770 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.Low),
            22771 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            22772 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.None),
            22773 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.Low),
            22774 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            22775 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.None),
            22776 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.Low),
            22777 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            22778 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.None),
            22779 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.Low),
            22780 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            22781 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.None),
            22782 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            22783 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            22784 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.None),
            22785 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            22786 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            22787 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.None),
            22788 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            22789 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            22790 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.None),
            22791 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            22792 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            22793 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            22794 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            22795 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            22796 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            22797 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            22798 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            22799 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            22800 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            22801 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            22802 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            22803 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            22804 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            22805 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.None),
            22806 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            22807 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            22808 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.None),
            22809 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            22810 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            22811 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.None),
            22812 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            22813 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            22814 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.None),
            22815 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            22816 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            22817 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            22818 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            22819 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            22820 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            22821 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            22822 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            22823 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            22824 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            22825 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            22826 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            22827 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            22828 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            22829 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            22830 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            22831 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            22832 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            22833 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            22834 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            22835 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            22836 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            22837 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            22838 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            22839 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            22840 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            22841 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            22842 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            22843 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            22844 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            22845 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            22846 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            22847 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            22848 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            22849 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            22850 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            22851 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            22852 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            22853 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            22854 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            22855 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            22856 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            22857 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            22858 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            22859 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            22860 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            22861 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            22862 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            22863 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            22864 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            22865 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            22866 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            22867 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            22868 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            22869 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            22870 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            22871 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            22872 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            22873 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            22874 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            22875 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            22876 => new PolishedBlackstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
            22877 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.None),
            22878 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.Low),
            22879 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            22880 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.None),
            22881 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.Low),
            22882 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            22883 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.None),
            22884 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.Low),
            22885 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            22886 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.None),
            22887 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.Low),
            22888 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            22889 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.None),
            22890 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            22891 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            22892 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.None),
            22893 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            22894 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            22895 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.None),
            22896 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            22897 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            22898 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.None),
            22899 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            22900 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            22901 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            22902 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            22903 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            22904 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            22905 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            22906 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            22907 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            22908 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            22909 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            22910 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            22911 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            22912 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            22913 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.None),
            22914 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            22915 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            22916 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.None),
            22917 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            22918 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            22919 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.None),
            22920 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            22921 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            22922 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.None),
            22923 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            22924 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            22925 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            22926 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            22927 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            22928 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            22929 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            22930 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            22931 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            22932 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            22933 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            22934 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            22935 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            22936 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            22937 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            22938 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            22939 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            22940 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            22941 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            22942 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            22943 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            22944 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            22945 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            22946 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            22947 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            22948 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            22949 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            22950 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            22951 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            22952 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            22953 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            22954 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            22955 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            22956 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            22957 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            22958 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            22959 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            22960 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            22961 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            22962 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            22963 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            22964 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            22965 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            22966 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            22967 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            22968 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            22969 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            22970 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            22971 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            22972 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            22973 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            22974 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            22975 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            22976 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            22977 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            22978 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            22979 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            22980 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            22981 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            22982 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            22983 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            22984 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
            22985 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.None),
            22986 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.Low),
            22987 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            22988 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.None),
            22989 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.Low),
            22990 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            22991 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.None),
            22992 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.Low),
            22993 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            22994 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.None),
            22995 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.Low),
            22996 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            22997 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.None),
            22998 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            22999 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            23000 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.None),
            23001 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            23002 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            23003 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.None),
            23004 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            23005 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            23006 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.None),
            23007 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            23008 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            23009 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            23010 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            23011 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            23012 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            23013 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            23014 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            23015 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            23016 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            23017 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            23018 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            23019 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            23020 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            23021 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.None),
            23022 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            23023 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            23024 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.None),
            23025 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            23026 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            23027 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.None),
            23028 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            23029 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            23030 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.None),
            23031 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            23032 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            23033 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            23034 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            23035 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            23036 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            23037 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            23038 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            23039 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            23040 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            23041 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            23042 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            23043 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            23044 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            23045 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            23046 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            23047 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            23048 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            23049 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            23050 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            23051 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            23052 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            23053 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            23054 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            23055 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            23056 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            23057 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            23058 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            23059 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            23060 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            23061 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            23062 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            23063 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            23064 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            23065 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            23066 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            23067 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            23068 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            23069 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            23070 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            23071 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            23072 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            23073 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            23074 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            23075 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            23076 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            23077 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            23078 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            23079 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            23080 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            23081 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            23082 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            23083 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            23084 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            23085 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            23086 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            23087 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            23088 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            23089 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            23090 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            23091 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            23092 => new PolishedBlackstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
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
