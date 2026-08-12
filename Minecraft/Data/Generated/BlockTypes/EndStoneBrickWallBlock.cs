using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record EndStoneBrickWallBlock(Identifier Identifier, WallSide East, WallSide North, WallSide South, bool Up, bool Waterlogged, WallSide West) : IBlock {
    public Identifier Category => "minecraft:wall";
    public double Hardness => 3;
    public double ExplosionResistance => 9;
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
    public Identifier? Item => "minecraft:end_stone_brick_wall";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.0, 0.75]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.5, 0.75]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.0, 0.75]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.5, 0.75]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 2;
    public string TranslationKey => "block.minecraft.end_stone_brick_wall";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                WallSide.None => North switch {
                    WallSide.None => South switch {
                        WallSide.None => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20058,
                                    WallSide.Low => 20059,
                                    WallSide.Tall => 20060,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20061,
                                    WallSide.Low => 20062,
                                    WallSide.Tall => 20063,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20064,
                                    WallSide.Low => 20065,
                                    WallSide.Tall => 20066,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20067,
                                    WallSide.Low => 20068,
                                    WallSide.Tall => 20069,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20070,
                                    WallSide.Low => 20071,
                                    WallSide.Tall => 20072,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20073,
                                    WallSide.Low => 20074,
                                    WallSide.Tall => 20075,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20076,
                                    WallSide.Low => 20077,
                                    WallSide.Tall => 20078,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20079,
                                    WallSide.Low => 20080,
                                    WallSide.Tall => 20081,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20082,
                                    WallSide.Low => 20083,
                                    WallSide.Tall => 20084,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20085,
                                    WallSide.Low => 20086,
                                    WallSide.Tall => 20087,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20088,
                                    WallSide.Low => 20089,
                                    WallSide.Tall => 20090,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20091,
                                    WallSide.Low => 20092,
                                    WallSide.Tall => 20093,
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
                                    WallSide.None => 20094,
                                    WallSide.Low => 20095,
                                    WallSide.Tall => 20096,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20097,
                                    WallSide.Low => 20098,
                                    WallSide.Tall => 20099,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20100,
                                    WallSide.Low => 20101,
                                    WallSide.Tall => 20102,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20103,
                                    WallSide.Low => 20104,
                                    WallSide.Tall => 20105,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20106,
                                    WallSide.Low => 20107,
                                    WallSide.Tall => 20108,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20109,
                                    WallSide.Low => 20110,
                                    WallSide.Tall => 20111,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20112,
                                    WallSide.Low => 20113,
                                    WallSide.Tall => 20114,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20115,
                                    WallSide.Low => 20116,
                                    WallSide.Tall => 20117,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20118,
                                    WallSide.Low => 20119,
                                    WallSide.Tall => 20120,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20121,
                                    WallSide.Low => 20122,
                                    WallSide.Tall => 20123,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20124,
                                    WallSide.Low => 20125,
                                    WallSide.Tall => 20126,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20127,
                                    WallSide.Low => 20128,
                                    WallSide.Tall => 20129,
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
                                    WallSide.None => 20130,
                                    WallSide.Low => 20131,
                                    WallSide.Tall => 20132,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20133,
                                    WallSide.Low => 20134,
                                    WallSide.Tall => 20135,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20136,
                                    WallSide.Low => 20137,
                                    WallSide.Tall => 20138,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20139,
                                    WallSide.Low => 20140,
                                    WallSide.Tall => 20141,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20142,
                                    WallSide.Low => 20143,
                                    WallSide.Tall => 20144,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20145,
                                    WallSide.Low => 20146,
                                    WallSide.Tall => 20147,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20148,
                                    WallSide.Low => 20149,
                                    WallSide.Tall => 20150,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20151,
                                    WallSide.Low => 20152,
                                    WallSide.Tall => 20153,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20154,
                                    WallSide.Low => 20155,
                                    WallSide.Tall => 20156,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20157,
                                    WallSide.Low => 20158,
                                    WallSide.Tall => 20159,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20160,
                                    WallSide.Low => 20161,
                                    WallSide.Tall => 20162,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20163,
                                    WallSide.Low => 20164,
                                    WallSide.Tall => 20165,
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
                                    WallSide.None => 20166,
                                    WallSide.Low => 20167,
                                    WallSide.Tall => 20168,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20169,
                                    WallSide.Low => 20170,
                                    WallSide.Tall => 20171,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20172,
                                    WallSide.Low => 20173,
                                    WallSide.Tall => 20174,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20175,
                                    WallSide.Low => 20176,
                                    WallSide.Tall => 20177,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20178,
                                    WallSide.Low => 20179,
                                    WallSide.Tall => 20180,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20181,
                                    WallSide.Low => 20182,
                                    WallSide.Tall => 20183,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20184,
                                    WallSide.Low => 20185,
                                    WallSide.Tall => 20186,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20187,
                                    WallSide.Low => 20188,
                                    WallSide.Tall => 20189,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20190,
                                    WallSide.Low => 20191,
                                    WallSide.Tall => 20192,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20193,
                                    WallSide.Low => 20194,
                                    WallSide.Tall => 20195,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20196,
                                    WallSide.Low => 20197,
                                    WallSide.Tall => 20198,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20199,
                                    WallSide.Low => 20200,
                                    WallSide.Tall => 20201,
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
                                    WallSide.None => 20202,
                                    WallSide.Low => 20203,
                                    WallSide.Tall => 20204,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20205,
                                    WallSide.Low => 20206,
                                    WallSide.Tall => 20207,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20208,
                                    WallSide.Low => 20209,
                                    WallSide.Tall => 20210,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20211,
                                    WallSide.Low => 20212,
                                    WallSide.Tall => 20213,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20214,
                                    WallSide.Low => 20215,
                                    WallSide.Tall => 20216,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20217,
                                    WallSide.Low => 20218,
                                    WallSide.Tall => 20219,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20220,
                                    WallSide.Low => 20221,
                                    WallSide.Tall => 20222,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20223,
                                    WallSide.Low => 20224,
                                    WallSide.Tall => 20225,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20226,
                                    WallSide.Low => 20227,
                                    WallSide.Tall => 20228,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20229,
                                    WallSide.Low => 20230,
                                    WallSide.Tall => 20231,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20232,
                                    WallSide.Low => 20233,
                                    WallSide.Tall => 20234,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20235,
                                    WallSide.Low => 20236,
                                    WallSide.Tall => 20237,
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
                                    WallSide.None => 20238,
                                    WallSide.Low => 20239,
                                    WallSide.Tall => 20240,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20241,
                                    WallSide.Low => 20242,
                                    WallSide.Tall => 20243,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20244,
                                    WallSide.Low => 20245,
                                    WallSide.Tall => 20246,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20247,
                                    WallSide.Low => 20248,
                                    WallSide.Tall => 20249,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20250,
                                    WallSide.Low => 20251,
                                    WallSide.Tall => 20252,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20253,
                                    WallSide.Low => 20254,
                                    WallSide.Tall => 20255,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20256,
                                    WallSide.Low => 20257,
                                    WallSide.Tall => 20258,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20259,
                                    WallSide.Low => 20260,
                                    WallSide.Tall => 20261,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20262,
                                    WallSide.Low => 20263,
                                    WallSide.Tall => 20264,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20265,
                                    WallSide.Low => 20266,
                                    WallSide.Tall => 20267,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20268,
                                    WallSide.Low => 20269,
                                    WallSide.Tall => 20270,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20271,
                                    WallSide.Low => 20272,
                                    WallSide.Tall => 20273,
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
                                    WallSide.None => 20274,
                                    WallSide.Low => 20275,
                                    WallSide.Tall => 20276,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20277,
                                    WallSide.Low => 20278,
                                    WallSide.Tall => 20279,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20280,
                                    WallSide.Low => 20281,
                                    WallSide.Tall => 20282,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20283,
                                    WallSide.Low => 20284,
                                    WallSide.Tall => 20285,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20286,
                                    WallSide.Low => 20287,
                                    WallSide.Tall => 20288,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20289,
                                    WallSide.Low => 20290,
                                    WallSide.Tall => 20291,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20292,
                                    WallSide.Low => 20293,
                                    WallSide.Tall => 20294,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20295,
                                    WallSide.Low => 20296,
                                    WallSide.Tall => 20297,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20298,
                                    WallSide.Low => 20299,
                                    WallSide.Tall => 20300,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20301,
                                    WallSide.Low => 20302,
                                    WallSide.Tall => 20303,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20304,
                                    WallSide.Low => 20305,
                                    WallSide.Tall => 20306,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20307,
                                    WallSide.Low => 20308,
                                    WallSide.Tall => 20309,
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
                                    WallSide.None => 20310,
                                    WallSide.Low => 20311,
                                    WallSide.Tall => 20312,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20313,
                                    WallSide.Low => 20314,
                                    WallSide.Tall => 20315,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20316,
                                    WallSide.Low => 20317,
                                    WallSide.Tall => 20318,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20319,
                                    WallSide.Low => 20320,
                                    WallSide.Tall => 20321,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20322,
                                    WallSide.Low => 20323,
                                    WallSide.Tall => 20324,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20325,
                                    WallSide.Low => 20326,
                                    WallSide.Tall => 20327,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20328,
                                    WallSide.Low => 20329,
                                    WallSide.Tall => 20330,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20331,
                                    WallSide.Low => 20332,
                                    WallSide.Tall => 20333,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20334,
                                    WallSide.Low => 20335,
                                    WallSide.Tall => 20336,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20337,
                                    WallSide.Low => 20338,
                                    WallSide.Tall => 20339,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20340,
                                    WallSide.Low => 20341,
                                    WallSide.Tall => 20342,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20343,
                                    WallSide.Low => 20344,
                                    WallSide.Tall => 20345,
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
                                    WallSide.None => 20346,
                                    WallSide.Low => 20347,
                                    WallSide.Tall => 20348,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20349,
                                    WallSide.Low => 20350,
                                    WallSide.Tall => 20351,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20352,
                                    WallSide.Low => 20353,
                                    WallSide.Tall => 20354,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20355,
                                    WallSide.Low => 20356,
                                    WallSide.Tall => 20357,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20358,
                                    WallSide.Low => 20359,
                                    WallSide.Tall => 20360,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20361,
                                    WallSide.Low => 20362,
                                    WallSide.Tall => 20363,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20364,
                                    WallSide.Low => 20365,
                                    WallSide.Tall => 20366,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20367,
                                    WallSide.Low => 20368,
                                    WallSide.Tall => 20369,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20370,
                                    WallSide.Low => 20371,
                                    WallSide.Tall => 20372,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20373,
                                    WallSide.Low => 20374,
                                    WallSide.Tall => 20375,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 20376,
                                    WallSide.Low => 20377,
                                    WallSide.Tall => 20378,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 20379,
                                    WallSide.Low => 20380,
                                    WallSide.Tall => 20381,
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
            20058 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.None),
            20059 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.Low),
            20060 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            20061 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.None),
            20062 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.Low),
            20063 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            20064 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.None),
            20065 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.Low),
            20066 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            20067 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.None),
            20068 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.Low),
            20069 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            20070 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.None),
            20071 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            20072 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            20073 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.None),
            20074 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            20075 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            20076 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.None),
            20077 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            20078 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            20079 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.None),
            20080 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            20081 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            20082 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            20083 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            20084 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            20085 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            20086 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            20087 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            20088 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            20089 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            20090 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            20091 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            20092 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            20093 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            20094 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.None),
            20095 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            20096 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            20097 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.None),
            20098 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            20099 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            20100 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.None),
            20101 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            20102 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            20103 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.None),
            20104 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            20105 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            20106 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            20107 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            20108 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            20109 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            20110 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            20111 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            20112 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            20113 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            20114 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            20115 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            20116 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            20117 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            20118 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            20119 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            20120 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            20121 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            20122 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            20123 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            20124 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            20125 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            20126 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            20127 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            20128 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            20129 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            20130 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            20131 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            20132 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            20133 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            20134 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            20135 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            20136 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            20137 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            20138 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            20139 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            20140 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            20141 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            20142 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            20143 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            20144 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            20145 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            20146 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            20147 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            20148 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            20149 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            20150 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            20151 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            20152 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            20153 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            20154 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            20155 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            20156 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            20157 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            20158 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            20159 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            20160 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            20161 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            20162 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            20163 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            20164 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            20165 => new EndStoneBrickWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
            20166 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.None),
            20167 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.Low),
            20168 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            20169 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.None),
            20170 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.Low),
            20171 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            20172 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.None),
            20173 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.Low),
            20174 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            20175 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.None),
            20176 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.Low),
            20177 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            20178 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.None),
            20179 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            20180 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            20181 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.None),
            20182 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            20183 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            20184 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.None),
            20185 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            20186 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            20187 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.None),
            20188 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            20189 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            20190 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            20191 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            20192 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            20193 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            20194 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            20195 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            20196 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            20197 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            20198 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            20199 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            20200 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            20201 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            20202 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.None),
            20203 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            20204 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            20205 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.None),
            20206 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            20207 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            20208 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.None),
            20209 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            20210 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            20211 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.None),
            20212 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            20213 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            20214 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            20215 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            20216 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            20217 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            20218 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            20219 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            20220 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            20221 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            20222 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            20223 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            20224 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            20225 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            20226 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            20227 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            20228 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            20229 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            20230 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            20231 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            20232 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            20233 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            20234 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            20235 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            20236 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            20237 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            20238 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            20239 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            20240 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            20241 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            20242 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            20243 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            20244 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            20245 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            20246 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            20247 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            20248 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            20249 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            20250 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            20251 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            20252 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            20253 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            20254 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            20255 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            20256 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            20257 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            20258 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            20259 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            20260 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            20261 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            20262 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            20263 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            20264 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            20265 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            20266 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            20267 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            20268 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            20269 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            20270 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            20271 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            20272 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            20273 => new EndStoneBrickWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
            20274 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.None),
            20275 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.Low),
            20276 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            20277 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.None),
            20278 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.Low),
            20279 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            20280 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.None),
            20281 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.Low),
            20282 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            20283 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.None),
            20284 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.Low),
            20285 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            20286 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.None),
            20287 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            20288 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            20289 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.None),
            20290 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            20291 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            20292 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.None),
            20293 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            20294 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            20295 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.None),
            20296 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            20297 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            20298 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            20299 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            20300 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            20301 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            20302 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            20303 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            20304 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            20305 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            20306 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            20307 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            20308 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            20309 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            20310 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.None),
            20311 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            20312 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            20313 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.None),
            20314 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            20315 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            20316 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.None),
            20317 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            20318 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            20319 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.None),
            20320 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            20321 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            20322 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            20323 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            20324 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            20325 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            20326 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            20327 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            20328 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            20329 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            20330 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            20331 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            20332 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            20333 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            20334 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            20335 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            20336 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            20337 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            20338 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            20339 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            20340 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            20341 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            20342 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            20343 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            20344 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            20345 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            20346 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            20347 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            20348 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            20349 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            20350 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            20351 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            20352 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            20353 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            20354 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            20355 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            20356 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            20357 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            20358 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            20359 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            20360 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            20361 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            20362 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            20363 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            20364 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            20365 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            20366 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            20367 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            20368 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            20369 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            20370 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            20371 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            20372 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            20373 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            20374 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            20375 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            20376 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            20377 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            20378 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            20379 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            20380 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            20381 => new EndStoneBrickWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
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
