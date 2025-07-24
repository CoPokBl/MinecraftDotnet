using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PaleMossCarpetBlock(Identifier Identifier, bool Bottom, WallSide East, WallSide North, WallSide South, WallSide West) : IBlock {

    public Identifier Category => "minecraft:mossy_carpet";
    public int ProtocolId => 1098;
    public double Hardness => 0.1;
    public double ExplosionResistance => 0.1;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "moss_carpet";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:pale_moss_carpet";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.0625, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.0625, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.0625, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 22;
    public string TranslationKey => "block.minecraft.pale_moss_carpet";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Bottom switch {
                true => East switch {
                    WallSide.None => North switch {
                        WallSide.None => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 27777,
                                WallSide.Low => 27778,
                                WallSide.Tall => 27779,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 27780,
                                WallSide.Low => 27781,
                                WallSide.Tall => 27782,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 27783,
                                WallSide.Low => 27784,
                                WallSide.Tall => 27785,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Low => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 27786,
                                WallSide.Low => 27787,
                                WallSide.Tall => 27788,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 27789,
                                WallSide.Low => 27790,
                                WallSide.Tall => 27791,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 27792,
                                WallSide.Low => 27793,
                                WallSide.Tall => 27794,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Tall => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 27795,
                                WallSide.Low => 27796,
                                WallSide.Tall => 27797,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 27798,
                                WallSide.Low => 27799,
                                WallSide.Tall => 27800,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 27801,
                                WallSide.Low => 27802,
                                WallSide.Tall => 27803,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                    },
                    WallSide.Low => North switch {
                        WallSide.None => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 27804,
                                WallSide.Low => 27805,
                                WallSide.Tall => 27806,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 27807,
                                WallSide.Low => 27808,
                                WallSide.Tall => 27809,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 27810,
                                WallSide.Low => 27811,
                                WallSide.Tall => 27812,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Low => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 27813,
                                WallSide.Low => 27814,
                                WallSide.Tall => 27815,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 27816,
                                WallSide.Low => 27817,
                                WallSide.Tall => 27818,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 27819,
                                WallSide.Low => 27820,
                                WallSide.Tall => 27821,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Tall => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 27822,
                                WallSide.Low => 27823,
                                WallSide.Tall => 27824,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 27825,
                                WallSide.Low => 27826,
                                WallSide.Tall => 27827,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 27828,
                                WallSide.Low => 27829,
                                WallSide.Tall => 27830,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                    },
                    WallSide.Tall => North switch {
                        WallSide.None => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 27831,
                                WallSide.Low => 27832,
                                WallSide.Tall => 27833,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 27834,
                                WallSide.Low => 27835,
                                WallSide.Tall => 27836,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 27837,
                                WallSide.Low => 27838,
                                WallSide.Tall => 27839,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Low => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 27840,
                                WallSide.Low => 27841,
                                WallSide.Tall => 27842,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 27843,
                                WallSide.Low => 27844,
                                WallSide.Tall => 27845,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 27846,
                                WallSide.Low => 27847,
                                WallSide.Tall => 27848,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Tall => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 27849,
                                WallSide.Low => 27850,
                                WallSide.Tall => 27851,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 27852,
                                WallSide.Low => 27853,
                                WallSide.Tall => 27854,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 27855,
                                WallSide.Low => 27856,
                                WallSide.Tall => 27857,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(East), East, "Unknown value for property east.")
                },
                false => East switch {
                    WallSide.None => North switch {
                        WallSide.None => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 27858,
                                WallSide.Low => 27859,
                                WallSide.Tall => 27860,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 27861,
                                WallSide.Low => 27862,
                                WallSide.Tall => 27863,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 27864,
                                WallSide.Low => 27865,
                                WallSide.Tall => 27866,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Low => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 27867,
                                WallSide.Low => 27868,
                                WallSide.Tall => 27869,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 27870,
                                WallSide.Low => 27871,
                                WallSide.Tall => 27872,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 27873,
                                WallSide.Low => 27874,
                                WallSide.Tall => 27875,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Tall => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 27876,
                                WallSide.Low => 27877,
                                WallSide.Tall => 27878,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 27879,
                                WallSide.Low => 27880,
                                WallSide.Tall => 27881,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 27882,
                                WallSide.Low => 27883,
                                WallSide.Tall => 27884,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                    },
                    WallSide.Low => North switch {
                        WallSide.None => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 27885,
                                WallSide.Low => 27886,
                                WallSide.Tall => 27887,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 27888,
                                WallSide.Low => 27889,
                                WallSide.Tall => 27890,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 27891,
                                WallSide.Low => 27892,
                                WallSide.Tall => 27893,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Low => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 27894,
                                WallSide.Low => 27895,
                                WallSide.Tall => 27896,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 27897,
                                WallSide.Low => 27898,
                                WallSide.Tall => 27899,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 27900,
                                WallSide.Low => 27901,
                                WallSide.Tall => 27902,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Tall => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 27903,
                                WallSide.Low => 27904,
                                WallSide.Tall => 27905,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 27906,
                                WallSide.Low => 27907,
                                WallSide.Tall => 27908,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 27909,
                                WallSide.Low => 27910,
                                WallSide.Tall => 27911,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                    },
                    WallSide.Tall => North switch {
                        WallSide.None => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 27912,
                                WallSide.Low => 27913,
                                WallSide.Tall => 27914,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 27915,
                                WallSide.Low => 27916,
                                WallSide.Tall => 27917,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 27918,
                                WallSide.Low => 27919,
                                WallSide.Tall => 27920,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Low => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 27921,
                                WallSide.Low => 27922,
                                WallSide.Tall => 27923,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 27924,
                                WallSide.Low => 27925,
                                WallSide.Tall => 27926,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 27927,
                                WallSide.Low => 27928,
                                WallSide.Tall => 27929,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Tall => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 27930,
                                WallSide.Low => 27931,
                                WallSide.Tall => 27932,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 27933,
                                WallSide.Low => 27934,
                                WallSide.Tall => 27935,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 27936,
                                WallSide.Low => 27937,
                                WallSide.Tall => 27938,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(East), East, "Unknown value for property east.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27777 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.None, WallSide.None),
            27778 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.None, WallSide.Low),
            27779 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.None, WallSide.Tall),
            27780 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.Low, WallSide.None),
            27781 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.Low, WallSide.Low),
            27782 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.Low, WallSide.Tall),
            27783 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.Tall, WallSide.None),
            27784 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.Tall, WallSide.Low),
            27785 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.Tall, WallSide.Tall),
            27786 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.None, WallSide.None),
            27787 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.None, WallSide.Low),
            27788 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.None, WallSide.Tall),
            27789 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.Low, WallSide.None),
            27790 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.Low, WallSide.Low),
            27791 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.Low, WallSide.Tall),
            27792 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.Tall, WallSide.None),
            27793 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.Tall, WallSide.Low),
            27794 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.Tall, WallSide.Tall),
            27795 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.None, WallSide.None),
            27796 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.None, WallSide.Low),
            27797 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.None, WallSide.Tall),
            27798 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.Low, WallSide.None),
            27799 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.Low, WallSide.Low),
            27800 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.Low, WallSide.Tall),
            27801 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.Tall, WallSide.None),
            27802 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.Tall, WallSide.Low),
            27803 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.Tall, WallSide.Tall),
            27804 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.None, WallSide.None),
            27805 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.None, WallSide.Low),
            27806 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.None, WallSide.Tall),
            27807 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.Low, WallSide.None),
            27808 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.Low, WallSide.Low),
            27809 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.Low, WallSide.Tall),
            27810 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.Tall, WallSide.None),
            27811 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.Tall, WallSide.Low),
            27812 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.Tall, WallSide.Tall),
            27813 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.None, WallSide.None),
            27814 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.None, WallSide.Low),
            27815 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.None, WallSide.Tall),
            27816 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.Low, WallSide.None),
            27817 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.Low, WallSide.Low),
            27818 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.Low, WallSide.Tall),
            27819 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.Tall, WallSide.None),
            27820 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.Tall, WallSide.Low),
            27821 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.Tall, WallSide.Tall),
            27822 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.None, WallSide.None),
            27823 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.None, WallSide.Low),
            27824 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.None, WallSide.Tall),
            27825 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.Low, WallSide.None),
            27826 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.Low, WallSide.Low),
            27827 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.Low, WallSide.Tall),
            27828 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.Tall, WallSide.None),
            27829 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.Tall, WallSide.Low),
            27830 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.Tall, WallSide.Tall),
            27831 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.None, WallSide.None),
            27832 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.None, WallSide.Low),
            27833 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.None, WallSide.Tall),
            27834 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.Low, WallSide.None),
            27835 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.Low, WallSide.Low),
            27836 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.Low, WallSide.Tall),
            27837 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.Tall, WallSide.None),
            27838 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.Tall, WallSide.Low),
            27839 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.Tall, WallSide.Tall),
            27840 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.None, WallSide.None),
            27841 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.None, WallSide.Low),
            27842 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.None, WallSide.Tall),
            27843 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.Low, WallSide.None),
            27844 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.Low, WallSide.Low),
            27845 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.Low, WallSide.Tall),
            27846 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.Tall, WallSide.None),
            27847 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.Tall, WallSide.Low),
            27848 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.Tall, WallSide.Tall),
            27849 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.None, WallSide.None),
            27850 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.None, WallSide.Low),
            27851 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.None, WallSide.Tall),
            27852 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.Low, WallSide.None),
            27853 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.Low, WallSide.Low),
            27854 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.Low, WallSide.Tall),
            27855 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.Tall, WallSide.None),
            27856 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.Tall, WallSide.Low),
            27857 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.Tall, WallSide.Tall),
            27858 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.None, WallSide.None),
            27859 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.None, WallSide.Low),
            27860 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.None, WallSide.Tall),
            27861 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.Low, WallSide.None),
            27862 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.Low, WallSide.Low),
            27863 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.Low, WallSide.Tall),
            27864 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.Tall, WallSide.None),
            27865 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.Tall, WallSide.Low),
            27866 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.Tall, WallSide.Tall),
            27867 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.None, WallSide.None),
            27868 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.None, WallSide.Low),
            27869 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.None, WallSide.Tall),
            27870 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.Low, WallSide.None),
            27871 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.Low, WallSide.Low),
            27872 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.Low, WallSide.Tall),
            27873 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.Tall, WallSide.None),
            27874 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.Tall, WallSide.Low),
            27875 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.Tall, WallSide.Tall),
            27876 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.None, WallSide.None),
            27877 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.None, WallSide.Low),
            27878 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.None, WallSide.Tall),
            27879 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.Low, WallSide.None),
            27880 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.Low, WallSide.Low),
            27881 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.Low, WallSide.Tall),
            27882 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.Tall, WallSide.None),
            27883 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.Tall, WallSide.Low),
            27884 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.Tall, WallSide.Tall),
            27885 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.None, WallSide.None),
            27886 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.None, WallSide.Low),
            27887 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.None, WallSide.Tall),
            27888 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.Low, WallSide.None),
            27889 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.Low, WallSide.Low),
            27890 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.Low, WallSide.Tall),
            27891 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.Tall, WallSide.None),
            27892 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.Tall, WallSide.Low),
            27893 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.Tall, WallSide.Tall),
            27894 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.None, WallSide.None),
            27895 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.None, WallSide.Low),
            27896 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.None, WallSide.Tall),
            27897 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.Low, WallSide.None),
            27898 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.Low, WallSide.Low),
            27899 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.Low, WallSide.Tall),
            27900 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.Tall, WallSide.None),
            27901 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.Tall, WallSide.Low),
            27902 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.Tall, WallSide.Tall),
            27903 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.None, WallSide.None),
            27904 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.None, WallSide.Low),
            27905 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.None, WallSide.Tall),
            27906 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.Low, WallSide.None),
            27907 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.Low, WallSide.Low),
            27908 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.Low, WallSide.Tall),
            27909 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.Tall, WallSide.None),
            27910 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.Tall, WallSide.Low),
            27911 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.Tall, WallSide.Tall),
            27912 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.None, WallSide.None),
            27913 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.None, WallSide.Low),
            27914 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.None, WallSide.Tall),
            27915 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.Low, WallSide.None),
            27916 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.Low, WallSide.Low),
            27917 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.Low, WallSide.Tall),
            27918 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.Tall, WallSide.None),
            27919 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.Tall, WallSide.Low),
            27920 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.Tall, WallSide.Tall),
            27921 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.None, WallSide.None),
            27922 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.None, WallSide.Low),
            27923 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.None, WallSide.Tall),
            27924 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.Low, WallSide.None),
            27925 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.Low, WallSide.Low),
            27926 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.Low, WallSide.Tall),
            27927 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.Tall, WallSide.None),
            27928 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.Tall, WallSide.Low),
            27929 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.Tall, WallSide.Tall),
            27930 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.None, WallSide.None),
            27931 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.None, WallSide.Low),
            27932 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.None, WallSide.Tall),
            27933 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.Low, WallSide.None),
            27934 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.Low, WallSide.Low),
            27935 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.Low, WallSide.Tall),
            27936 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.Tall, WallSide.None),
            27937 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.Tall, WallSide.Low),
            27938 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.Tall, WallSide.Tall),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Bottom = properties["bottom"].GetString() == "true",
            East = WallSideExtensions.FromString(properties["east"].GetString()),
            North = WallSideExtensions.FromString(properties["north"].GetString()),
            South = WallSideExtensions.FromString(properties["south"].GetString()),
            West = WallSideExtensions.FromString(properties["west"].GetString()),
        };
    }
    
}
