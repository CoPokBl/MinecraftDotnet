using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record RedSandstoneWallBlock(Identifier Identifier, WallSide East, WallSide North, WallSide South, bool Up, bool Waterlogged, WallSide West) : IBlock {
    public Identifier Category => "minecraft:wall";
    public double Hardness => 0.8;
    public double ExplosionResistance => 0.8;
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
    public Identifier? Item => "minecraft:red_sandstone_wall";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.0, 0.75]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.5, 0.75]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.0, 0.75]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.5, 0.75]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 15;
    public string TranslationKey => "block.minecraft.red_sandstone_wall";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                WallSide.None => North switch {
                    WallSide.None => South switch {
                        WallSide.None => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17142,
                                    WallSide.Low => 17143,
                                    WallSide.Tall => 17144,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17145,
                                    WallSide.Low => 17146,
                                    WallSide.Tall => 17147,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17148,
                                    WallSide.Low => 17149,
                                    WallSide.Tall => 17150,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17151,
                                    WallSide.Low => 17152,
                                    WallSide.Tall => 17153,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17154,
                                    WallSide.Low => 17155,
                                    WallSide.Tall => 17156,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17157,
                                    WallSide.Low => 17158,
                                    WallSide.Tall => 17159,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17160,
                                    WallSide.Low => 17161,
                                    WallSide.Tall => 17162,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17163,
                                    WallSide.Low => 17164,
                                    WallSide.Tall => 17165,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17166,
                                    WallSide.Low => 17167,
                                    WallSide.Tall => 17168,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17169,
                                    WallSide.Low => 17170,
                                    WallSide.Tall => 17171,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17172,
                                    WallSide.Low => 17173,
                                    WallSide.Tall => 17174,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17175,
                                    WallSide.Low => 17176,
                                    WallSide.Tall => 17177,
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
                                    WallSide.None => 17178,
                                    WallSide.Low => 17179,
                                    WallSide.Tall => 17180,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17181,
                                    WallSide.Low => 17182,
                                    WallSide.Tall => 17183,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17184,
                                    WallSide.Low => 17185,
                                    WallSide.Tall => 17186,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17187,
                                    WallSide.Low => 17188,
                                    WallSide.Tall => 17189,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17190,
                                    WallSide.Low => 17191,
                                    WallSide.Tall => 17192,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17193,
                                    WallSide.Low => 17194,
                                    WallSide.Tall => 17195,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17196,
                                    WallSide.Low => 17197,
                                    WallSide.Tall => 17198,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17199,
                                    WallSide.Low => 17200,
                                    WallSide.Tall => 17201,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17202,
                                    WallSide.Low => 17203,
                                    WallSide.Tall => 17204,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17205,
                                    WallSide.Low => 17206,
                                    WallSide.Tall => 17207,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17208,
                                    WallSide.Low => 17209,
                                    WallSide.Tall => 17210,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17211,
                                    WallSide.Low => 17212,
                                    WallSide.Tall => 17213,
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
                                    WallSide.None => 17214,
                                    WallSide.Low => 17215,
                                    WallSide.Tall => 17216,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17217,
                                    WallSide.Low => 17218,
                                    WallSide.Tall => 17219,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17220,
                                    WallSide.Low => 17221,
                                    WallSide.Tall => 17222,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17223,
                                    WallSide.Low => 17224,
                                    WallSide.Tall => 17225,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17226,
                                    WallSide.Low => 17227,
                                    WallSide.Tall => 17228,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17229,
                                    WallSide.Low => 17230,
                                    WallSide.Tall => 17231,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17232,
                                    WallSide.Low => 17233,
                                    WallSide.Tall => 17234,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17235,
                                    WallSide.Low => 17236,
                                    WallSide.Tall => 17237,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17238,
                                    WallSide.Low => 17239,
                                    WallSide.Tall => 17240,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17241,
                                    WallSide.Low => 17242,
                                    WallSide.Tall => 17243,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17244,
                                    WallSide.Low => 17245,
                                    WallSide.Tall => 17246,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17247,
                                    WallSide.Low => 17248,
                                    WallSide.Tall => 17249,
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
                                    WallSide.None => 17250,
                                    WallSide.Low => 17251,
                                    WallSide.Tall => 17252,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17253,
                                    WallSide.Low => 17254,
                                    WallSide.Tall => 17255,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17256,
                                    WallSide.Low => 17257,
                                    WallSide.Tall => 17258,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17259,
                                    WallSide.Low => 17260,
                                    WallSide.Tall => 17261,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17262,
                                    WallSide.Low => 17263,
                                    WallSide.Tall => 17264,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17265,
                                    WallSide.Low => 17266,
                                    WallSide.Tall => 17267,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17268,
                                    WallSide.Low => 17269,
                                    WallSide.Tall => 17270,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17271,
                                    WallSide.Low => 17272,
                                    WallSide.Tall => 17273,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17274,
                                    WallSide.Low => 17275,
                                    WallSide.Tall => 17276,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17277,
                                    WallSide.Low => 17278,
                                    WallSide.Tall => 17279,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17280,
                                    WallSide.Low => 17281,
                                    WallSide.Tall => 17282,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17283,
                                    WallSide.Low => 17284,
                                    WallSide.Tall => 17285,
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
                                    WallSide.None => 17286,
                                    WallSide.Low => 17287,
                                    WallSide.Tall => 17288,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17289,
                                    WallSide.Low => 17290,
                                    WallSide.Tall => 17291,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17292,
                                    WallSide.Low => 17293,
                                    WallSide.Tall => 17294,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17295,
                                    WallSide.Low => 17296,
                                    WallSide.Tall => 17297,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17298,
                                    WallSide.Low => 17299,
                                    WallSide.Tall => 17300,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17301,
                                    WallSide.Low => 17302,
                                    WallSide.Tall => 17303,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17304,
                                    WallSide.Low => 17305,
                                    WallSide.Tall => 17306,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17307,
                                    WallSide.Low => 17308,
                                    WallSide.Tall => 17309,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17310,
                                    WallSide.Low => 17311,
                                    WallSide.Tall => 17312,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17313,
                                    WallSide.Low => 17314,
                                    WallSide.Tall => 17315,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17316,
                                    WallSide.Low => 17317,
                                    WallSide.Tall => 17318,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17319,
                                    WallSide.Low => 17320,
                                    WallSide.Tall => 17321,
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
                                    WallSide.None => 17322,
                                    WallSide.Low => 17323,
                                    WallSide.Tall => 17324,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17325,
                                    WallSide.Low => 17326,
                                    WallSide.Tall => 17327,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17328,
                                    WallSide.Low => 17329,
                                    WallSide.Tall => 17330,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17331,
                                    WallSide.Low => 17332,
                                    WallSide.Tall => 17333,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17334,
                                    WallSide.Low => 17335,
                                    WallSide.Tall => 17336,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17337,
                                    WallSide.Low => 17338,
                                    WallSide.Tall => 17339,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17340,
                                    WallSide.Low => 17341,
                                    WallSide.Tall => 17342,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17343,
                                    WallSide.Low => 17344,
                                    WallSide.Tall => 17345,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17346,
                                    WallSide.Low => 17347,
                                    WallSide.Tall => 17348,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17349,
                                    WallSide.Low => 17350,
                                    WallSide.Tall => 17351,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17352,
                                    WallSide.Low => 17353,
                                    WallSide.Tall => 17354,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17355,
                                    WallSide.Low => 17356,
                                    WallSide.Tall => 17357,
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
                                    WallSide.None => 17358,
                                    WallSide.Low => 17359,
                                    WallSide.Tall => 17360,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17361,
                                    WallSide.Low => 17362,
                                    WallSide.Tall => 17363,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17364,
                                    WallSide.Low => 17365,
                                    WallSide.Tall => 17366,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17367,
                                    WallSide.Low => 17368,
                                    WallSide.Tall => 17369,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17370,
                                    WallSide.Low => 17371,
                                    WallSide.Tall => 17372,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17373,
                                    WallSide.Low => 17374,
                                    WallSide.Tall => 17375,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17376,
                                    WallSide.Low => 17377,
                                    WallSide.Tall => 17378,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17379,
                                    WallSide.Low => 17380,
                                    WallSide.Tall => 17381,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17382,
                                    WallSide.Low => 17383,
                                    WallSide.Tall => 17384,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17385,
                                    WallSide.Low => 17386,
                                    WallSide.Tall => 17387,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17388,
                                    WallSide.Low => 17389,
                                    WallSide.Tall => 17390,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17391,
                                    WallSide.Low => 17392,
                                    WallSide.Tall => 17393,
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
                                    WallSide.None => 17394,
                                    WallSide.Low => 17395,
                                    WallSide.Tall => 17396,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17397,
                                    WallSide.Low => 17398,
                                    WallSide.Tall => 17399,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17400,
                                    WallSide.Low => 17401,
                                    WallSide.Tall => 17402,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17403,
                                    WallSide.Low => 17404,
                                    WallSide.Tall => 17405,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17406,
                                    WallSide.Low => 17407,
                                    WallSide.Tall => 17408,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17409,
                                    WallSide.Low => 17410,
                                    WallSide.Tall => 17411,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17412,
                                    WallSide.Low => 17413,
                                    WallSide.Tall => 17414,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17415,
                                    WallSide.Low => 17416,
                                    WallSide.Tall => 17417,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17418,
                                    WallSide.Low => 17419,
                                    WallSide.Tall => 17420,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17421,
                                    WallSide.Low => 17422,
                                    WallSide.Tall => 17423,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17424,
                                    WallSide.Low => 17425,
                                    WallSide.Tall => 17426,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17427,
                                    WallSide.Low => 17428,
                                    WallSide.Tall => 17429,
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
                                    WallSide.None => 17430,
                                    WallSide.Low => 17431,
                                    WallSide.Tall => 17432,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17433,
                                    WallSide.Low => 17434,
                                    WallSide.Tall => 17435,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17436,
                                    WallSide.Low => 17437,
                                    WallSide.Tall => 17438,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17439,
                                    WallSide.Low => 17440,
                                    WallSide.Tall => 17441,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Low => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17442,
                                    WallSide.Low => 17443,
                                    WallSide.Tall => 17444,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17445,
                                    WallSide.Low => 17446,
                                    WallSide.Tall => 17447,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17448,
                                    WallSide.Low => 17449,
                                    WallSide.Tall => 17450,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17451,
                                    WallSide.Low => 17452,
                                    WallSide.Tall => 17453,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                        },
                        WallSide.Tall => Up switch {
                            true => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17454,
                                    WallSide.Low => 17455,
                                    WallSide.Tall => 17456,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17457,
                                    WallSide.Low => 17458,
                                    WallSide.Tall => 17459,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                            },
                            false => Waterlogged switch {
                                true => West switch {
                                    WallSide.None => 17460,
                                    WallSide.Low => 17461,
                                    WallSide.Tall => 17462,
                                    _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                                },
                                false => West switch {
                                    WallSide.None => 17463,
                                    WallSide.Low => 17464,
                                    WallSide.Tall => 17465,
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
            17142 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.None),
            17143 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.Low),
            17144 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            17145 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.None),
            17146 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.Low),
            17147 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            17148 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.None),
            17149 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.Low),
            17150 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            17151 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.None),
            17152 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.Low),
            17153 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            17154 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.None),
            17155 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            17156 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            17157 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.None),
            17158 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            17159 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            17160 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.None),
            17161 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            17162 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            17163 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.None),
            17164 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            17165 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            17166 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            17167 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            17168 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            17169 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            17170 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            17171 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            17172 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            17173 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            17174 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            17175 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            17176 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            17177 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            17178 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.None),
            17179 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            17180 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            17181 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.None),
            17182 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            17183 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            17184 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.None),
            17185 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            17186 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            17187 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.None),
            17188 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            17189 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            17190 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            17191 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            17192 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            17193 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            17194 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            17195 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            17196 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            17197 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            17198 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            17199 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            17200 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            17201 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            17202 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            17203 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            17204 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            17205 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            17206 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            17207 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            17208 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            17209 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            17210 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            17211 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            17212 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            17213 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            17214 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            17215 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            17216 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            17217 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            17218 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            17219 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            17220 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            17221 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            17222 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            17223 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            17224 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            17225 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            17226 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            17227 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            17228 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            17229 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            17230 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            17231 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            17232 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            17233 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            17234 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            17235 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            17236 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            17237 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            17238 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            17239 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            17240 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            17241 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            17242 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            17243 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            17244 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            17245 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            17246 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            17247 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            17248 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            17249 => new RedSandstoneWallBlock(Identifier, WallSide.None, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
            17250 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.None),
            17251 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.Low),
            17252 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            17253 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.None),
            17254 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.Low),
            17255 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            17256 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.None),
            17257 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.Low),
            17258 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            17259 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.None),
            17260 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.Low),
            17261 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            17262 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.None),
            17263 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            17264 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            17265 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.None),
            17266 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            17267 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            17268 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.None),
            17269 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            17270 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            17271 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.None),
            17272 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            17273 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            17274 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            17275 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            17276 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            17277 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            17278 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            17279 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            17280 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            17281 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            17282 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            17283 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            17284 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            17285 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            17286 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.None),
            17287 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            17288 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            17289 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.None),
            17290 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            17291 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            17292 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.None),
            17293 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            17294 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            17295 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.None),
            17296 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            17297 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            17298 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            17299 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            17300 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            17301 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            17302 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            17303 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            17304 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            17305 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            17306 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            17307 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            17308 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            17309 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            17310 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            17311 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            17312 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            17313 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            17314 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            17315 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            17316 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            17317 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            17318 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            17319 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            17320 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            17321 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            17322 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            17323 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            17324 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            17325 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            17326 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            17327 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            17328 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            17329 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            17330 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            17331 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            17332 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            17333 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            17334 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            17335 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            17336 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            17337 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            17338 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            17339 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            17340 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            17341 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            17342 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            17343 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            17344 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            17345 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            17346 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            17347 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            17348 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            17349 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            17350 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            17351 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            17352 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            17353 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            17354 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            17355 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            17356 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            17357 => new RedSandstoneWallBlock(Identifier, WallSide.Low, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
            17358 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.None),
            17359 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.Low),
            17360 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, true, WallSide.Tall),
            17361 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.None),
            17362 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.Low),
            17363 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, true, false, WallSide.Tall),
            17364 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.None),
            17365 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.Low),
            17366 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, true, WallSide.Tall),
            17367 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.None),
            17368 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.Low),
            17369 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.None, false, false, WallSide.Tall),
            17370 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.None),
            17371 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.Low),
            17372 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, true, WallSide.Tall),
            17373 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.None),
            17374 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.Low),
            17375 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, true, false, WallSide.Tall),
            17376 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.None),
            17377 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.Low),
            17378 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, true, WallSide.Tall),
            17379 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.None),
            17380 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.Low),
            17381 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Low, false, false, WallSide.Tall),
            17382 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.None),
            17383 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.Low),
            17384 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, true, WallSide.Tall),
            17385 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.None),
            17386 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.Low),
            17387 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, true, false, WallSide.Tall),
            17388 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.None),
            17389 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.Low),
            17390 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, true, WallSide.Tall),
            17391 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.None),
            17392 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.Low),
            17393 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.None, WallSide.Tall, false, false, WallSide.Tall),
            17394 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.None),
            17395 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.Low),
            17396 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, true, WallSide.Tall),
            17397 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.None),
            17398 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.Low),
            17399 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, true, false, WallSide.Tall),
            17400 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.None),
            17401 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.Low),
            17402 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, true, WallSide.Tall),
            17403 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.None),
            17404 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.Low),
            17405 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.None, false, false, WallSide.Tall),
            17406 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.None),
            17407 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.Low),
            17408 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, true, WallSide.Tall),
            17409 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.None),
            17410 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.Low),
            17411 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, true, false, WallSide.Tall),
            17412 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.None),
            17413 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.Low),
            17414 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, true, WallSide.Tall),
            17415 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.None),
            17416 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.Low),
            17417 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Low, false, false, WallSide.Tall),
            17418 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.None),
            17419 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.Low),
            17420 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, true, WallSide.Tall),
            17421 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.None),
            17422 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.Low),
            17423 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, true, false, WallSide.Tall),
            17424 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.None),
            17425 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.Low),
            17426 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, true, WallSide.Tall),
            17427 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.None),
            17428 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.Low),
            17429 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Low, WallSide.Tall, false, false, WallSide.Tall),
            17430 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.None),
            17431 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.Low),
            17432 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, true, WallSide.Tall),
            17433 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.None),
            17434 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.Low),
            17435 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, true, false, WallSide.Tall),
            17436 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.None),
            17437 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.Low),
            17438 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, true, WallSide.Tall),
            17439 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.None),
            17440 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.Low),
            17441 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.None, false, false, WallSide.Tall),
            17442 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.None),
            17443 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.Low),
            17444 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, true, WallSide.Tall),
            17445 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.None),
            17446 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.Low),
            17447 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, true, false, WallSide.Tall),
            17448 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.None),
            17449 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.Low),
            17450 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, true, WallSide.Tall),
            17451 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.None),
            17452 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.Low),
            17453 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Low, false, false, WallSide.Tall),
            17454 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.None),
            17455 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.Low),
            17456 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, true, WallSide.Tall),
            17457 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.None),
            17458 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.Low),
            17459 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, true, false, WallSide.Tall),
            17460 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.None),
            17461 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.Low),
            17462 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, true, WallSide.Tall),
            17463 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.None),
            17464 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.Low),
            17465 => new RedSandstoneWallBlock(Identifier, WallSide.Tall, WallSide.Tall, WallSide.Tall, false, false, WallSide.Tall),
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
