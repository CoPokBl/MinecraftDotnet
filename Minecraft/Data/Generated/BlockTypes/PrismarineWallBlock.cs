using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PrismarineWallBlock(Identifier Identifier, WallSide East, WallSide North, WallSide South, bool Up, bool Waterlogged, WallSide West) : IBlock {
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
    public string SoundType => "stone";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:prismarine_wall";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.0, 0.75]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.5, 0.75]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.0, 0.75]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.5, 0.75]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 23;
    public string TranslationKey => "block.minecraft.prismarine_wall";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                WallSide.None => North switch {
                    WallSide.None => South switch {
                        WallSide.None => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 16818,
                                    WallSide.Low => 16819,
                                    WallSide.Tall => 16820,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 16821,
                                    WallSide.Low => 16822,
                                    WallSide.Tall => 16823,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 16824,
                                    WallSide.Low => 16825,
                                    WallSide.Tall => 16826,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 16827,
                                    WallSide.Low => 16828,
                                    WallSide.Tall => 16829,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 16830,
                                    WallSide.Low => 16831,
                                    WallSide.Tall => 16832,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 16833,
                                    WallSide.Low => 16834,
                                    WallSide.Tall => 16835,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 16836,
                                    WallSide.Low => 16837,
                                    WallSide.Tall => 16838,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 16839,
                                    WallSide.Low => 16840,
                                    WallSide.Tall => 16841,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 16842,
                                    WallSide.Low => 16843,
                                    WallSide.Tall => 16844,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 16845,
                                    WallSide.Low => 16846,
                                    WallSide.Tall => 16847,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 16848,
                                    WallSide.Low => 16849,
                                    WallSide.Tall => 16850,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 16851,
                                    WallSide.Low => 16852,
                                    WallSide.Tall => 16853,
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
                                    WallSide.None => 16854,
                                    WallSide.Low => 16855,
                                    WallSide.Tall => 16856,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 16857,
                                    WallSide.Low => 16858,
                                    WallSide.Tall => 16859,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 16860,
                                    WallSide.Low => 16861,
                                    WallSide.Tall => 16862,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 16863,
                                    WallSide.Low => 16864,
                                    WallSide.Tall => 16865,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 16866,
                                    WallSide.Low => 16867,
                                    WallSide.Tall => 16868,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 16869,
                                    WallSide.Low => 16870,
                                    WallSide.Tall => 16871,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 16872,
                                    WallSide.Low => 16873,
                                    WallSide.Tall => 16874,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 16875,
                                    WallSide.Low => 16876,
                                    WallSide.Tall => 16877,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 16878,
                                    WallSide.Low => 16879,
                                    WallSide.Tall => 16880,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 16881,
                                    WallSide.Low => 16882,
                                    WallSide.Tall => 16883,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 16884,
                                    WallSide.Low => 16885,
                                    WallSide.Tall => 16886,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 16887,
                                    WallSide.Low => 16888,
                                    WallSide.Tall => 16889,
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
                                    WallSide.None => 16890,
                                    WallSide.Low => 16891,
                                    WallSide.Tall => 16892,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 16893,
                                    WallSide.Low => 16894,
                                    WallSide.Tall => 16895,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 16896,
                                    WallSide.Low => 16897,
                                    WallSide.Tall => 16898,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 16899,
                                    WallSide.Low => 16900,
                                    WallSide.Tall => 16901,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 16902,
                                    WallSide.Low => 16903,
                                    WallSide.Tall => 16904,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 16905,
                                    WallSide.Low => 16906,
                                    WallSide.Tall => 16907,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 16908,
                                    WallSide.Low => 16909,
                                    WallSide.Tall => 16910,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 16911,
                                    WallSide.Low => 16912,
                                    WallSide.Tall => 16913,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 16914,
                                    WallSide.Low => 16915,
                                    WallSide.Tall => 16916,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 16917,
                                    WallSide.Low => 16918,
                                    WallSide.Tall => 16919,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 16920,
                                    WallSide.Low => 16921,
                                    WallSide.Tall => 16922,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 16923,
                                    WallSide.Low => 16924,
                                    WallSide.Tall => 16925,
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
                                    WallSide.None => 16926,
                                    WallSide.Low => 16927,
                                    WallSide.Tall => 16928,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 16929,
                                    WallSide.Low => 16930,
                                    WallSide.Tall => 16931,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 16932,
                                    WallSide.Low => 16933,
                                    WallSide.Tall => 16934,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 16935,
                                    WallSide.Low => 16936,
                                    WallSide.Tall => 16937,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 16938,
                                    WallSide.Low => 16939,
                                    WallSide.Tall => 16940,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 16941,
                                    WallSide.Low => 16942,
                                    WallSide.Tall => 16943,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 16944,
                                    WallSide.Low => 16945,
                                    WallSide.Tall => 16946,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 16947,
                                    WallSide.Low => 16948,
                                    WallSide.Tall => 16949,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 16950,
                                    WallSide.Low => 16951,
                                    WallSide.Tall => 16952,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 16953,
                                    WallSide.Low => 16954,
                                    WallSide.Tall => 16955,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 16956,
                                    WallSide.Low => 16957,
                                    WallSide.Tall => 16958,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 16959,
                                    WallSide.Low => 16960,
                                    WallSide.Tall => 16961,
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
                                    WallSide.None => 16962,
                                    WallSide.Low => 16963,
                                    WallSide.Tall => 16964,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 16965,
                                    WallSide.Low => 16966,
                                    WallSide.Tall => 16967,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 16968,
                                    WallSide.Low => 16969,
                                    WallSide.Tall => 16970,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 16971,
                                    WallSide.Low => 16972,
                                    WallSide.Tall => 16973,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 16974,
                                    WallSide.Low => 16975,
                                    WallSide.Tall => 16976,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 16977,
                                    WallSide.Low => 16978,
                                    WallSide.Tall => 16979,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 16980,
                                    WallSide.Low => 16981,
                                    WallSide.Tall => 16982,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 16983,
                                    WallSide.Low => 16984,
                                    WallSide.Tall => 16985,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 16986,
                                    WallSide.Low => 16987,
                                    WallSide.Tall => 16988,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 16989,
                                    WallSide.Low => 16990,
                                    WallSide.Tall => 16991,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 16992,
                                    WallSide.Low => 16993,
                                    WallSide.Tall => 16994,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 16995,
                                    WallSide.Low => 16996,
                                    WallSide.Tall => 16997,
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
                                    WallSide.None => 16998,
                                    WallSide.Low => 16999,
                                    WallSide.Tall => 17000,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17001,
                                    WallSide.Low => 17002,
                                    WallSide.Tall => 17003,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17004,
                                    WallSide.Low => 17005,
                                    WallSide.Tall => 17006,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17007,
                                    WallSide.Low => 17008,
                                    WallSide.Tall => 17009,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17010,
                                    WallSide.Low => 17011,
                                    WallSide.Tall => 17012,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17013,
                                    WallSide.Low => 17014,
                                    WallSide.Tall => 17015,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17016,
                                    WallSide.Low => 17017,
                                    WallSide.Tall => 17018,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17019,
                                    WallSide.Low => 17020,
                                    WallSide.Tall => 17021,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17022,
                                    WallSide.Low => 17023,
                                    WallSide.Tall => 17024,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17025,
                                    WallSide.Low => 17026,
                                    WallSide.Tall => 17027,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17028,
                                    WallSide.Low => 17029,
                                    WallSide.Tall => 17030,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17031,
                                    WallSide.Low => 17032,
                                    WallSide.Tall => 17033,
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
                                    WallSide.None => 17034,
                                    WallSide.Low => 17035,
                                    WallSide.Tall => 17036,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17037,
                                    WallSide.Low => 17038,
                                    WallSide.Tall => 17039,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17040,
                                    WallSide.Low => 17041,
                                    WallSide.Tall => 17042,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17043,
                                    WallSide.Low => 17044,
                                    WallSide.Tall => 17045,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17046,
                                    WallSide.Low => 17047,
                                    WallSide.Tall => 17048,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17049,
                                    WallSide.Low => 17050,
                                    WallSide.Tall => 17051,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17052,
                                    WallSide.Low => 17053,
                                    WallSide.Tall => 17054,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17055,
                                    WallSide.Low => 17056,
                                    WallSide.Tall => 17057,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17058,
                                    WallSide.Low => 17059,
                                    WallSide.Tall => 17060,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17061,
                                    WallSide.Low => 17062,
                                    WallSide.Tall => 17063,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17064,
                                    WallSide.Low => 17065,
                                    WallSide.Tall => 17066,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17067,
                                    WallSide.Low => 17068,
                                    WallSide.Tall => 17069,
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
                                    WallSide.None => 17070,
                                    WallSide.Low => 17071,
                                    WallSide.Tall => 17072,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17073,
                                    WallSide.Low => 17074,
                                    WallSide.Tall => 17075,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17076,
                                    WallSide.Low => 17077,
                                    WallSide.Tall => 17078,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17079,
                                    WallSide.Low => 17080,
                                    WallSide.Tall => 17081,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17082,
                                    WallSide.Low => 17083,
                                    WallSide.Tall => 17084,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17085,
                                    WallSide.Low => 17086,
                                    WallSide.Tall => 17087,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17088,
                                    WallSide.Low => 17089,
                                    WallSide.Tall => 17090,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17091,
                                    WallSide.Low => 17092,
                                    WallSide.Tall => 17093,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17094,
                                    WallSide.Low => 17095,
                                    WallSide.Tall => 17096,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17097,
                                    WallSide.Low => 17098,
                                    WallSide.Tall => 17099,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17100,
                                    WallSide.Low => 17101,
                                    WallSide.Tall => 17102,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17103,
                                    WallSide.Low => 17104,
                                    WallSide.Tall => 17105,
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
                                    WallSide.None => 17106,
                                    WallSide.Low => 17107,
                                    WallSide.Tall => 17108,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17109,
                                    WallSide.Low => 17110,
                                    WallSide.Tall => 17111,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17112,
                                    WallSide.Low => 17113,
                                    WallSide.Tall => 17114,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17115,
                                    WallSide.Low => 17116,
                                    WallSide.Tall => 17117,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17118,
                                    WallSide.Low => 17119,
                                    WallSide.Tall => 17120,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17121,
                                    WallSide.Low => 17122,
                                    WallSide.Tall => 17123,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17124,
                                    WallSide.Low => 17125,
                                    WallSide.Tall => 17126,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17127,
                                    WallSide.Low => 17128,
                                    WallSide.Tall => 17129,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17130,
                                    WallSide.Low => 17131,
                                    WallSide.Tall => 17132,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17133,
                                    WallSide.Low => 17134,
                                    WallSide.Tall => 17135,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17136,
                                    WallSide.Low => 17137,
                                    WallSide.Tall => 17138,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17139,
                                    WallSide.Low => 17140,
                                    WallSide.Tall => 17141,
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
            16818 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.None),
            16819 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.Low),
            16820 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            16821 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.None),
            16822 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.Low),
            16823 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            16824 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.None),
            16825 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.Low),
            16826 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            16827 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.None),
            16828 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.Low),
            16829 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            16830 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.None),
            16831 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            16832 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            16833 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.None),
            16834 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            16835 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            16836 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.None),
            16837 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            16838 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            16839 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.None),
            16840 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            16841 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            16842 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            16843 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            16844 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            16845 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            16846 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            16847 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            16848 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            16849 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            16850 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            16851 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            16852 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            16853 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            16854 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.None),
            16855 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            16856 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            16857 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.None),
            16858 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            16859 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            16860 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.None),
            16861 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            16862 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            16863 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.None),
            16864 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            16865 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            16866 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            16867 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            16868 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            16869 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            16870 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            16871 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            16872 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            16873 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            16874 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            16875 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            16876 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            16877 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            16878 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            16879 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            16880 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            16881 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            16882 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            16883 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            16884 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            16885 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            16886 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            16887 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            16888 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            16889 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            16890 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            16891 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            16892 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            16893 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            16894 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            16895 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            16896 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            16897 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            16898 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            16899 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            16900 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            16901 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            16902 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            16903 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            16904 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            16905 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            16906 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            16907 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            16908 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            16909 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            16910 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            16911 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            16912 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            16913 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            16914 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            16915 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            16916 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            16917 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            16918 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            16919 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            16920 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            16921 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            16922 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            16923 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            16924 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            16925 => new PrismarineWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
            16926 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.None),
            16927 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.Low),
            16928 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            16929 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.None),
            16930 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.Low),
            16931 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            16932 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.None),
            16933 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.Low),
            16934 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            16935 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.None),
            16936 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.Low),
            16937 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            16938 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.None),
            16939 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            16940 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            16941 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.None),
            16942 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            16943 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            16944 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.None),
            16945 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            16946 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            16947 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.None),
            16948 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            16949 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            16950 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            16951 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            16952 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            16953 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            16954 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            16955 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            16956 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            16957 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            16958 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            16959 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            16960 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            16961 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            16962 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.None),
            16963 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            16964 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            16965 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.None),
            16966 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            16967 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            16968 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.None),
            16969 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            16970 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            16971 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.None),
            16972 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            16973 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            16974 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            16975 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            16976 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            16977 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            16978 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            16979 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            16980 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            16981 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            16982 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            16983 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            16984 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            16985 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            16986 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            16987 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            16988 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            16989 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            16990 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            16991 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            16992 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            16993 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            16994 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            16995 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            16996 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            16997 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            16998 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            16999 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            17000 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            17001 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            17002 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            17003 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            17004 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            17005 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            17006 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            17007 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            17008 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            17009 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            17010 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            17011 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            17012 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            17013 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            17014 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            17015 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            17016 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            17017 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            17018 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            17019 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            17020 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            17021 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            17022 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            17023 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            17024 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            17025 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            17026 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            17027 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            17028 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            17029 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            17030 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            17031 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            17032 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            17033 => new PrismarineWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
            17034 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.None),
            17035 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.Low),
            17036 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            17037 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.None),
            17038 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.Low),
            17039 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            17040 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.None),
            17041 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.Low),
            17042 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            17043 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.None),
            17044 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.Low),
            17045 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            17046 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.None),
            17047 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            17048 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            17049 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.None),
            17050 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            17051 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            17052 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.None),
            17053 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            17054 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            17055 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.None),
            17056 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            17057 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            17058 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            17059 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            17060 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            17061 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            17062 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            17063 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            17064 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            17065 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            17066 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            17067 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            17068 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            17069 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            17070 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.None),
            17071 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            17072 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            17073 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.None),
            17074 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            17075 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            17076 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.None),
            17077 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            17078 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            17079 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.None),
            17080 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            17081 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            17082 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            17083 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            17084 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            17085 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            17086 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            17087 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            17088 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            17089 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            17090 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            17091 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            17092 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            17093 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            17094 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            17095 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            17096 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            17097 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            17098 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            17099 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            17100 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            17101 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            17102 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            17103 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            17104 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            17105 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            17106 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            17107 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            17108 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            17109 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            17110 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            17111 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            17112 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            17113 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            17114 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            17115 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            17116 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            17117 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            17118 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            17119 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            17120 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            17121 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            17122 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            17123 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            17124 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            17125 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            17126 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            17127 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            17128 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            17129 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            17130 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            17131 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            17132 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            17133 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            17134 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            17135 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            17136 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            17137 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            17138 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            17139 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            17140 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            17141 => new PrismarineWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
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
