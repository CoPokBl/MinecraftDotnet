using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record RedstoneWireBlock(Identifier Identifier, RedstoneWireConnection East, RedstoneWireConnection North, int Power, RedstoneWireConnection South, RedstoneWireConnection West) : IBlock {
    public Identifier Category => "minecraft:redstone_wire";
    public int ProtocolId => 201;
    public double Hardness => 0;
    public double ExplosionResistance => 0;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "stone";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:redstone";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.0625, 0.8125]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => true;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 0;
    public string TranslationKey => "block.minecraft.redstone_wire";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return East switch {
                RedstoneWireConnection.Up => North switch {
                    RedstoneWireConnection.Up => Power switch {
                        0 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3810,
                                RedstoneWireConnection.Side => 3811,
                                RedstoneWireConnection.None => 3812,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3813,
                                RedstoneWireConnection.Side => 3814,
                                RedstoneWireConnection.None => 3815,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3816,
                                RedstoneWireConnection.Side => 3817,
                                RedstoneWireConnection.None => 3818,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        1 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3819,
                                RedstoneWireConnection.Side => 3820,
                                RedstoneWireConnection.None => 3821,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3822,
                                RedstoneWireConnection.Side => 3823,
                                RedstoneWireConnection.None => 3824,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3825,
                                RedstoneWireConnection.Side => 3826,
                                RedstoneWireConnection.None => 3827,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        2 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3828,
                                RedstoneWireConnection.Side => 3829,
                                RedstoneWireConnection.None => 3830,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3831,
                                RedstoneWireConnection.Side => 3832,
                                RedstoneWireConnection.None => 3833,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3834,
                                RedstoneWireConnection.Side => 3835,
                                RedstoneWireConnection.None => 3836,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        3 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3837,
                                RedstoneWireConnection.Side => 3838,
                                RedstoneWireConnection.None => 3839,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3840,
                                RedstoneWireConnection.Side => 3841,
                                RedstoneWireConnection.None => 3842,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3843,
                                RedstoneWireConnection.Side => 3844,
                                RedstoneWireConnection.None => 3845,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        4 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3846,
                                RedstoneWireConnection.Side => 3847,
                                RedstoneWireConnection.None => 3848,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3849,
                                RedstoneWireConnection.Side => 3850,
                                RedstoneWireConnection.None => 3851,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3852,
                                RedstoneWireConnection.Side => 3853,
                                RedstoneWireConnection.None => 3854,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        5 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3855,
                                RedstoneWireConnection.Side => 3856,
                                RedstoneWireConnection.None => 3857,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3858,
                                RedstoneWireConnection.Side => 3859,
                                RedstoneWireConnection.None => 3860,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3861,
                                RedstoneWireConnection.Side => 3862,
                                RedstoneWireConnection.None => 3863,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        6 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3864,
                                RedstoneWireConnection.Side => 3865,
                                RedstoneWireConnection.None => 3866,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3867,
                                RedstoneWireConnection.Side => 3868,
                                RedstoneWireConnection.None => 3869,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3870,
                                RedstoneWireConnection.Side => 3871,
                                RedstoneWireConnection.None => 3872,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        7 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3873,
                                RedstoneWireConnection.Side => 3874,
                                RedstoneWireConnection.None => 3875,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3876,
                                RedstoneWireConnection.Side => 3877,
                                RedstoneWireConnection.None => 3878,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3879,
                                RedstoneWireConnection.Side => 3880,
                                RedstoneWireConnection.None => 3881,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        8 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3882,
                                RedstoneWireConnection.Side => 3883,
                                RedstoneWireConnection.None => 3884,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3885,
                                RedstoneWireConnection.Side => 3886,
                                RedstoneWireConnection.None => 3887,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3888,
                                RedstoneWireConnection.Side => 3889,
                                RedstoneWireConnection.None => 3890,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        9 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3891,
                                RedstoneWireConnection.Side => 3892,
                                RedstoneWireConnection.None => 3893,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3894,
                                RedstoneWireConnection.Side => 3895,
                                RedstoneWireConnection.None => 3896,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3897,
                                RedstoneWireConnection.Side => 3898,
                                RedstoneWireConnection.None => 3899,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        10 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3900,
                                RedstoneWireConnection.Side => 3901,
                                RedstoneWireConnection.None => 3902,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3903,
                                RedstoneWireConnection.Side => 3904,
                                RedstoneWireConnection.None => 3905,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3906,
                                RedstoneWireConnection.Side => 3907,
                                RedstoneWireConnection.None => 3908,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        11 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3909,
                                RedstoneWireConnection.Side => 3910,
                                RedstoneWireConnection.None => 3911,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3912,
                                RedstoneWireConnection.Side => 3913,
                                RedstoneWireConnection.None => 3914,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3915,
                                RedstoneWireConnection.Side => 3916,
                                RedstoneWireConnection.None => 3917,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        12 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3918,
                                RedstoneWireConnection.Side => 3919,
                                RedstoneWireConnection.None => 3920,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3921,
                                RedstoneWireConnection.Side => 3922,
                                RedstoneWireConnection.None => 3923,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3924,
                                RedstoneWireConnection.Side => 3925,
                                RedstoneWireConnection.None => 3926,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        13 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3927,
                                RedstoneWireConnection.Side => 3928,
                                RedstoneWireConnection.None => 3929,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3930,
                                RedstoneWireConnection.Side => 3931,
                                RedstoneWireConnection.None => 3932,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3933,
                                RedstoneWireConnection.Side => 3934,
                                RedstoneWireConnection.None => 3935,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        14 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3936,
                                RedstoneWireConnection.Side => 3937,
                                RedstoneWireConnection.None => 3938,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3939,
                                RedstoneWireConnection.Side => 3940,
                                RedstoneWireConnection.None => 3941,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3942,
                                RedstoneWireConnection.Side => 3943,
                                RedstoneWireConnection.None => 3944,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        15 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3945,
                                RedstoneWireConnection.Side => 3946,
                                RedstoneWireConnection.None => 3947,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3948,
                                RedstoneWireConnection.Side => 3949,
                                RedstoneWireConnection.None => 3950,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3951,
                                RedstoneWireConnection.Side => 3952,
                                RedstoneWireConnection.None => 3953,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                    },
                    RedstoneWireConnection.Side => Power switch {
                        0 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3954,
                                RedstoneWireConnection.Side => 3955,
                                RedstoneWireConnection.None => 3956,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3957,
                                RedstoneWireConnection.Side => 3958,
                                RedstoneWireConnection.None => 3959,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3960,
                                RedstoneWireConnection.Side => 3961,
                                RedstoneWireConnection.None => 3962,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        1 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3963,
                                RedstoneWireConnection.Side => 3964,
                                RedstoneWireConnection.None => 3965,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3966,
                                RedstoneWireConnection.Side => 3967,
                                RedstoneWireConnection.None => 3968,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3969,
                                RedstoneWireConnection.Side => 3970,
                                RedstoneWireConnection.None => 3971,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        2 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3972,
                                RedstoneWireConnection.Side => 3973,
                                RedstoneWireConnection.None => 3974,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3975,
                                RedstoneWireConnection.Side => 3976,
                                RedstoneWireConnection.None => 3977,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3978,
                                RedstoneWireConnection.Side => 3979,
                                RedstoneWireConnection.None => 3980,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        3 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3981,
                                RedstoneWireConnection.Side => 3982,
                                RedstoneWireConnection.None => 3983,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3984,
                                RedstoneWireConnection.Side => 3985,
                                RedstoneWireConnection.None => 3986,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3987,
                                RedstoneWireConnection.Side => 3988,
                                RedstoneWireConnection.None => 3989,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        4 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3990,
                                RedstoneWireConnection.Side => 3991,
                                RedstoneWireConnection.None => 3992,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3993,
                                RedstoneWireConnection.Side => 3994,
                                RedstoneWireConnection.None => 3995,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3996,
                                RedstoneWireConnection.Side => 3997,
                                RedstoneWireConnection.None => 3998,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        5 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3999,
                                RedstoneWireConnection.Side => 4000,
                                RedstoneWireConnection.None => 4001,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4002,
                                RedstoneWireConnection.Side => 4003,
                                RedstoneWireConnection.None => 4004,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4005,
                                RedstoneWireConnection.Side => 4006,
                                RedstoneWireConnection.None => 4007,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        6 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4008,
                                RedstoneWireConnection.Side => 4009,
                                RedstoneWireConnection.None => 4010,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4011,
                                RedstoneWireConnection.Side => 4012,
                                RedstoneWireConnection.None => 4013,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4014,
                                RedstoneWireConnection.Side => 4015,
                                RedstoneWireConnection.None => 4016,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        7 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4017,
                                RedstoneWireConnection.Side => 4018,
                                RedstoneWireConnection.None => 4019,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4020,
                                RedstoneWireConnection.Side => 4021,
                                RedstoneWireConnection.None => 4022,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4023,
                                RedstoneWireConnection.Side => 4024,
                                RedstoneWireConnection.None => 4025,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        8 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4026,
                                RedstoneWireConnection.Side => 4027,
                                RedstoneWireConnection.None => 4028,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4029,
                                RedstoneWireConnection.Side => 4030,
                                RedstoneWireConnection.None => 4031,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4032,
                                RedstoneWireConnection.Side => 4033,
                                RedstoneWireConnection.None => 4034,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        9 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4035,
                                RedstoneWireConnection.Side => 4036,
                                RedstoneWireConnection.None => 4037,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4038,
                                RedstoneWireConnection.Side => 4039,
                                RedstoneWireConnection.None => 4040,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4041,
                                RedstoneWireConnection.Side => 4042,
                                RedstoneWireConnection.None => 4043,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        10 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4044,
                                RedstoneWireConnection.Side => 4045,
                                RedstoneWireConnection.None => 4046,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4047,
                                RedstoneWireConnection.Side => 4048,
                                RedstoneWireConnection.None => 4049,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4050,
                                RedstoneWireConnection.Side => 4051,
                                RedstoneWireConnection.None => 4052,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        11 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4053,
                                RedstoneWireConnection.Side => 4054,
                                RedstoneWireConnection.None => 4055,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4056,
                                RedstoneWireConnection.Side => 4057,
                                RedstoneWireConnection.None => 4058,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4059,
                                RedstoneWireConnection.Side => 4060,
                                RedstoneWireConnection.None => 4061,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        12 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4062,
                                RedstoneWireConnection.Side => 4063,
                                RedstoneWireConnection.None => 4064,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4065,
                                RedstoneWireConnection.Side => 4066,
                                RedstoneWireConnection.None => 4067,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4068,
                                RedstoneWireConnection.Side => 4069,
                                RedstoneWireConnection.None => 4070,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        13 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4071,
                                RedstoneWireConnection.Side => 4072,
                                RedstoneWireConnection.None => 4073,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4074,
                                RedstoneWireConnection.Side => 4075,
                                RedstoneWireConnection.None => 4076,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4077,
                                RedstoneWireConnection.Side => 4078,
                                RedstoneWireConnection.None => 4079,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        14 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4080,
                                RedstoneWireConnection.Side => 4081,
                                RedstoneWireConnection.None => 4082,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4083,
                                RedstoneWireConnection.Side => 4084,
                                RedstoneWireConnection.None => 4085,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4086,
                                RedstoneWireConnection.Side => 4087,
                                RedstoneWireConnection.None => 4088,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        15 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4089,
                                RedstoneWireConnection.Side => 4090,
                                RedstoneWireConnection.None => 4091,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4092,
                                RedstoneWireConnection.Side => 4093,
                                RedstoneWireConnection.None => 4094,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4095,
                                RedstoneWireConnection.Side => 4096,
                                RedstoneWireConnection.None => 4097,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                    },
                    RedstoneWireConnection.None => Power switch {
                        0 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4098,
                                RedstoneWireConnection.Side => 4099,
                                RedstoneWireConnection.None => 4100,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4101,
                                RedstoneWireConnection.Side => 4102,
                                RedstoneWireConnection.None => 4103,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4104,
                                RedstoneWireConnection.Side => 4105,
                                RedstoneWireConnection.None => 4106,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        1 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4107,
                                RedstoneWireConnection.Side => 4108,
                                RedstoneWireConnection.None => 4109,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4110,
                                RedstoneWireConnection.Side => 4111,
                                RedstoneWireConnection.None => 4112,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4113,
                                RedstoneWireConnection.Side => 4114,
                                RedstoneWireConnection.None => 4115,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        2 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4116,
                                RedstoneWireConnection.Side => 4117,
                                RedstoneWireConnection.None => 4118,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4119,
                                RedstoneWireConnection.Side => 4120,
                                RedstoneWireConnection.None => 4121,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4122,
                                RedstoneWireConnection.Side => 4123,
                                RedstoneWireConnection.None => 4124,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        3 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4125,
                                RedstoneWireConnection.Side => 4126,
                                RedstoneWireConnection.None => 4127,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4128,
                                RedstoneWireConnection.Side => 4129,
                                RedstoneWireConnection.None => 4130,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4131,
                                RedstoneWireConnection.Side => 4132,
                                RedstoneWireConnection.None => 4133,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        4 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4134,
                                RedstoneWireConnection.Side => 4135,
                                RedstoneWireConnection.None => 4136,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4137,
                                RedstoneWireConnection.Side => 4138,
                                RedstoneWireConnection.None => 4139,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4140,
                                RedstoneWireConnection.Side => 4141,
                                RedstoneWireConnection.None => 4142,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        5 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4143,
                                RedstoneWireConnection.Side => 4144,
                                RedstoneWireConnection.None => 4145,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4146,
                                RedstoneWireConnection.Side => 4147,
                                RedstoneWireConnection.None => 4148,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4149,
                                RedstoneWireConnection.Side => 4150,
                                RedstoneWireConnection.None => 4151,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        6 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4152,
                                RedstoneWireConnection.Side => 4153,
                                RedstoneWireConnection.None => 4154,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4155,
                                RedstoneWireConnection.Side => 4156,
                                RedstoneWireConnection.None => 4157,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4158,
                                RedstoneWireConnection.Side => 4159,
                                RedstoneWireConnection.None => 4160,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        7 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4161,
                                RedstoneWireConnection.Side => 4162,
                                RedstoneWireConnection.None => 4163,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4164,
                                RedstoneWireConnection.Side => 4165,
                                RedstoneWireConnection.None => 4166,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4167,
                                RedstoneWireConnection.Side => 4168,
                                RedstoneWireConnection.None => 4169,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        8 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4170,
                                RedstoneWireConnection.Side => 4171,
                                RedstoneWireConnection.None => 4172,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4173,
                                RedstoneWireConnection.Side => 4174,
                                RedstoneWireConnection.None => 4175,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4176,
                                RedstoneWireConnection.Side => 4177,
                                RedstoneWireConnection.None => 4178,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        9 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4179,
                                RedstoneWireConnection.Side => 4180,
                                RedstoneWireConnection.None => 4181,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4182,
                                RedstoneWireConnection.Side => 4183,
                                RedstoneWireConnection.None => 4184,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4185,
                                RedstoneWireConnection.Side => 4186,
                                RedstoneWireConnection.None => 4187,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        10 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4188,
                                RedstoneWireConnection.Side => 4189,
                                RedstoneWireConnection.None => 4190,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4191,
                                RedstoneWireConnection.Side => 4192,
                                RedstoneWireConnection.None => 4193,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4194,
                                RedstoneWireConnection.Side => 4195,
                                RedstoneWireConnection.None => 4196,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        11 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4197,
                                RedstoneWireConnection.Side => 4198,
                                RedstoneWireConnection.None => 4199,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4200,
                                RedstoneWireConnection.Side => 4201,
                                RedstoneWireConnection.None => 4202,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4203,
                                RedstoneWireConnection.Side => 4204,
                                RedstoneWireConnection.None => 4205,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        12 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4206,
                                RedstoneWireConnection.Side => 4207,
                                RedstoneWireConnection.None => 4208,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4209,
                                RedstoneWireConnection.Side => 4210,
                                RedstoneWireConnection.None => 4211,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4212,
                                RedstoneWireConnection.Side => 4213,
                                RedstoneWireConnection.None => 4214,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        13 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4215,
                                RedstoneWireConnection.Side => 4216,
                                RedstoneWireConnection.None => 4217,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4218,
                                RedstoneWireConnection.Side => 4219,
                                RedstoneWireConnection.None => 4220,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4221,
                                RedstoneWireConnection.Side => 4222,
                                RedstoneWireConnection.None => 4223,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        14 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4224,
                                RedstoneWireConnection.Side => 4225,
                                RedstoneWireConnection.None => 4226,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4227,
                                RedstoneWireConnection.Side => 4228,
                                RedstoneWireConnection.None => 4229,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4230,
                                RedstoneWireConnection.Side => 4231,
                                RedstoneWireConnection.None => 4232,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        15 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4233,
                                RedstoneWireConnection.Side => 4234,
                                RedstoneWireConnection.None => 4235,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4236,
                                RedstoneWireConnection.Side => 4237,
                                RedstoneWireConnection.None => 4238,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4239,
                                RedstoneWireConnection.Side => 4240,
                                RedstoneWireConnection.None => 4241,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                },
                RedstoneWireConnection.Side => North switch {
                    RedstoneWireConnection.Up => Power switch {
                        0 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4242,
                                RedstoneWireConnection.Side => 4243,
                                RedstoneWireConnection.None => 4244,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4245,
                                RedstoneWireConnection.Side => 4246,
                                RedstoneWireConnection.None => 4247,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4248,
                                RedstoneWireConnection.Side => 4249,
                                RedstoneWireConnection.None => 4250,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        1 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4251,
                                RedstoneWireConnection.Side => 4252,
                                RedstoneWireConnection.None => 4253,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4254,
                                RedstoneWireConnection.Side => 4255,
                                RedstoneWireConnection.None => 4256,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4257,
                                RedstoneWireConnection.Side => 4258,
                                RedstoneWireConnection.None => 4259,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        2 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4260,
                                RedstoneWireConnection.Side => 4261,
                                RedstoneWireConnection.None => 4262,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4263,
                                RedstoneWireConnection.Side => 4264,
                                RedstoneWireConnection.None => 4265,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4266,
                                RedstoneWireConnection.Side => 4267,
                                RedstoneWireConnection.None => 4268,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        3 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4269,
                                RedstoneWireConnection.Side => 4270,
                                RedstoneWireConnection.None => 4271,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4272,
                                RedstoneWireConnection.Side => 4273,
                                RedstoneWireConnection.None => 4274,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4275,
                                RedstoneWireConnection.Side => 4276,
                                RedstoneWireConnection.None => 4277,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        4 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4278,
                                RedstoneWireConnection.Side => 4279,
                                RedstoneWireConnection.None => 4280,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4281,
                                RedstoneWireConnection.Side => 4282,
                                RedstoneWireConnection.None => 4283,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4284,
                                RedstoneWireConnection.Side => 4285,
                                RedstoneWireConnection.None => 4286,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        5 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4287,
                                RedstoneWireConnection.Side => 4288,
                                RedstoneWireConnection.None => 4289,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4290,
                                RedstoneWireConnection.Side => 4291,
                                RedstoneWireConnection.None => 4292,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4293,
                                RedstoneWireConnection.Side => 4294,
                                RedstoneWireConnection.None => 4295,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        6 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4296,
                                RedstoneWireConnection.Side => 4297,
                                RedstoneWireConnection.None => 4298,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4299,
                                RedstoneWireConnection.Side => 4300,
                                RedstoneWireConnection.None => 4301,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4302,
                                RedstoneWireConnection.Side => 4303,
                                RedstoneWireConnection.None => 4304,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        7 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4305,
                                RedstoneWireConnection.Side => 4306,
                                RedstoneWireConnection.None => 4307,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4308,
                                RedstoneWireConnection.Side => 4309,
                                RedstoneWireConnection.None => 4310,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4311,
                                RedstoneWireConnection.Side => 4312,
                                RedstoneWireConnection.None => 4313,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        8 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4314,
                                RedstoneWireConnection.Side => 4315,
                                RedstoneWireConnection.None => 4316,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4317,
                                RedstoneWireConnection.Side => 4318,
                                RedstoneWireConnection.None => 4319,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4320,
                                RedstoneWireConnection.Side => 4321,
                                RedstoneWireConnection.None => 4322,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        9 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4323,
                                RedstoneWireConnection.Side => 4324,
                                RedstoneWireConnection.None => 4325,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4326,
                                RedstoneWireConnection.Side => 4327,
                                RedstoneWireConnection.None => 4328,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4329,
                                RedstoneWireConnection.Side => 4330,
                                RedstoneWireConnection.None => 4331,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        10 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4332,
                                RedstoneWireConnection.Side => 4333,
                                RedstoneWireConnection.None => 4334,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4335,
                                RedstoneWireConnection.Side => 4336,
                                RedstoneWireConnection.None => 4337,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4338,
                                RedstoneWireConnection.Side => 4339,
                                RedstoneWireConnection.None => 4340,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        11 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4341,
                                RedstoneWireConnection.Side => 4342,
                                RedstoneWireConnection.None => 4343,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4344,
                                RedstoneWireConnection.Side => 4345,
                                RedstoneWireConnection.None => 4346,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4347,
                                RedstoneWireConnection.Side => 4348,
                                RedstoneWireConnection.None => 4349,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        12 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4350,
                                RedstoneWireConnection.Side => 4351,
                                RedstoneWireConnection.None => 4352,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4353,
                                RedstoneWireConnection.Side => 4354,
                                RedstoneWireConnection.None => 4355,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4356,
                                RedstoneWireConnection.Side => 4357,
                                RedstoneWireConnection.None => 4358,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        13 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4359,
                                RedstoneWireConnection.Side => 4360,
                                RedstoneWireConnection.None => 4361,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4362,
                                RedstoneWireConnection.Side => 4363,
                                RedstoneWireConnection.None => 4364,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4365,
                                RedstoneWireConnection.Side => 4366,
                                RedstoneWireConnection.None => 4367,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        14 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4368,
                                RedstoneWireConnection.Side => 4369,
                                RedstoneWireConnection.None => 4370,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4371,
                                RedstoneWireConnection.Side => 4372,
                                RedstoneWireConnection.None => 4373,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4374,
                                RedstoneWireConnection.Side => 4375,
                                RedstoneWireConnection.None => 4376,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        15 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4377,
                                RedstoneWireConnection.Side => 4378,
                                RedstoneWireConnection.None => 4379,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4380,
                                RedstoneWireConnection.Side => 4381,
                                RedstoneWireConnection.None => 4382,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4383,
                                RedstoneWireConnection.Side => 4384,
                                RedstoneWireConnection.None => 4385,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                    },
                    RedstoneWireConnection.Side => Power switch {
                        0 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4386,
                                RedstoneWireConnection.Side => 4387,
                                RedstoneWireConnection.None => 4388,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4389,
                                RedstoneWireConnection.Side => 4390,
                                RedstoneWireConnection.None => 4391,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4392,
                                RedstoneWireConnection.Side => 4393,
                                RedstoneWireConnection.None => 4394,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        1 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4395,
                                RedstoneWireConnection.Side => 4396,
                                RedstoneWireConnection.None => 4397,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4398,
                                RedstoneWireConnection.Side => 4399,
                                RedstoneWireConnection.None => 4400,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4401,
                                RedstoneWireConnection.Side => 4402,
                                RedstoneWireConnection.None => 4403,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        2 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4404,
                                RedstoneWireConnection.Side => 4405,
                                RedstoneWireConnection.None => 4406,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4407,
                                RedstoneWireConnection.Side => 4408,
                                RedstoneWireConnection.None => 4409,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4410,
                                RedstoneWireConnection.Side => 4411,
                                RedstoneWireConnection.None => 4412,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        3 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4413,
                                RedstoneWireConnection.Side => 4414,
                                RedstoneWireConnection.None => 4415,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4416,
                                RedstoneWireConnection.Side => 4417,
                                RedstoneWireConnection.None => 4418,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4419,
                                RedstoneWireConnection.Side => 4420,
                                RedstoneWireConnection.None => 4421,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        4 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4422,
                                RedstoneWireConnection.Side => 4423,
                                RedstoneWireConnection.None => 4424,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4425,
                                RedstoneWireConnection.Side => 4426,
                                RedstoneWireConnection.None => 4427,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4428,
                                RedstoneWireConnection.Side => 4429,
                                RedstoneWireConnection.None => 4430,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        5 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4431,
                                RedstoneWireConnection.Side => 4432,
                                RedstoneWireConnection.None => 4433,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4434,
                                RedstoneWireConnection.Side => 4435,
                                RedstoneWireConnection.None => 4436,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4437,
                                RedstoneWireConnection.Side => 4438,
                                RedstoneWireConnection.None => 4439,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        6 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4440,
                                RedstoneWireConnection.Side => 4441,
                                RedstoneWireConnection.None => 4442,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4443,
                                RedstoneWireConnection.Side => 4444,
                                RedstoneWireConnection.None => 4445,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4446,
                                RedstoneWireConnection.Side => 4447,
                                RedstoneWireConnection.None => 4448,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        7 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4449,
                                RedstoneWireConnection.Side => 4450,
                                RedstoneWireConnection.None => 4451,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4452,
                                RedstoneWireConnection.Side => 4453,
                                RedstoneWireConnection.None => 4454,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4455,
                                RedstoneWireConnection.Side => 4456,
                                RedstoneWireConnection.None => 4457,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        8 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4458,
                                RedstoneWireConnection.Side => 4459,
                                RedstoneWireConnection.None => 4460,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4461,
                                RedstoneWireConnection.Side => 4462,
                                RedstoneWireConnection.None => 4463,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4464,
                                RedstoneWireConnection.Side => 4465,
                                RedstoneWireConnection.None => 4466,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        9 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4467,
                                RedstoneWireConnection.Side => 4468,
                                RedstoneWireConnection.None => 4469,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4470,
                                RedstoneWireConnection.Side => 4471,
                                RedstoneWireConnection.None => 4472,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4473,
                                RedstoneWireConnection.Side => 4474,
                                RedstoneWireConnection.None => 4475,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        10 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4476,
                                RedstoneWireConnection.Side => 4477,
                                RedstoneWireConnection.None => 4478,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4479,
                                RedstoneWireConnection.Side => 4480,
                                RedstoneWireConnection.None => 4481,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4482,
                                RedstoneWireConnection.Side => 4483,
                                RedstoneWireConnection.None => 4484,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        11 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4485,
                                RedstoneWireConnection.Side => 4486,
                                RedstoneWireConnection.None => 4487,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4488,
                                RedstoneWireConnection.Side => 4489,
                                RedstoneWireConnection.None => 4490,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4491,
                                RedstoneWireConnection.Side => 4492,
                                RedstoneWireConnection.None => 4493,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        12 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4494,
                                RedstoneWireConnection.Side => 4495,
                                RedstoneWireConnection.None => 4496,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4497,
                                RedstoneWireConnection.Side => 4498,
                                RedstoneWireConnection.None => 4499,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4500,
                                RedstoneWireConnection.Side => 4501,
                                RedstoneWireConnection.None => 4502,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        13 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4503,
                                RedstoneWireConnection.Side => 4504,
                                RedstoneWireConnection.None => 4505,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4506,
                                RedstoneWireConnection.Side => 4507,
                                RedstoneWireConnection.None => 4508,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4509,
                                RedstoneWireConnection.Side => 4510,
                                RedstoneWireConnection.None => 4511,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        14 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4512,
                                RedstoneWireConnection.Side => 4513,
                                RedstoneWireConnection.None => 4514,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4515,
                                RedstoneWireConnection.Side => 4516,
                                RedstoneWireConnection.None => 4517,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4518,
                                RedstoneWireConnection.Side => 4519,
                                RedstoneWireConnection.None => 4520,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        15 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4521,
                                RedstoneWireConnection.Side => 4522,
                                RedstoneWireConnection.None => 4523,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4524,
                                RedstoneWireConnection.Side => 4525,
                                RedstoneWireConnection.None => 4526,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4527,
                                RedstoneWireConnection.Side => 4528,
                                RedstoneWireConnection.None => 4529,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                    },
                    RedstoneWireConnection.None => Power switch {
                        0 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4530,
                                RedstoneWireConnection.Side => 4531,
                                RedstoneWireConnection.None => 4532,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4533,
                                RedstoneWireConnection.Side => 4534,
                                RedstoneWireConnection.None => 4535,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4536,
                                RedstoneWireConnection.Side => 4537,
                                RedstoneWireConnection.None => 4538,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        1 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4539,
                                RedstoneWireConnection.Side => 4540,
                                RedstoneWireConnection.None => 4541,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4542,
                                RedstoneWireConnection.Side => 4543,
                                RedstoneWireConnection.None => 4544,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4545,
                                RedstoneWireConnection.Side => 4546,
                                RedstoneWireConnection.None => 4547,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        2 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4548,
                                RedstoneWireConnection.Side => 4549,
                                RedstoneWireConnection.None => 4550,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4551,
                                RedstoneWireConnection.Side => 4552,
                                RedstoneWireConnection.None => 4553,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4554,
                                RedstoneWireConnection.Side => 4555,
                                RedstoneWireConnection.None => 4556,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        3 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4557,
                                RedstoneWireConnection.Side => 4558,
                                RedstoneWireConnection.None => 4559,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4560,
                                RedstoneWireConnection.Side => 4561,
                                RedstoneWireConnection.None => 4562,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4563,
                                RedstoneWireConnection.Side => 4564,
                                RedstoneWireConnection.None => 4565,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        4 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4566,
                                RedstoneWireConnection.Side => 4567,
                                RedstoneWireConnection.None => 4568,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4569,
                                RedstoneWireConnection.Side => 4570,
                                RedstoneWireConnection.None => 4571,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4572,
                                RedstoneWireConnection.Side => 4573,
                                RedstoneWireConnection.None => 4574,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        5 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4575,
                                RedstoneWireConnection.Side => 4576,
                                RedstoneWireConnection.None => 4577,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4578,
                                RedstoneWireConnection.Side => 4579,
                                RedstoneWireConnection.None => 4580,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4581,
                                RedstoneWireConnection.Side => 4582,
                                RedstoneWireConnection.None => 4583,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        6 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4584,
                                RedstoneWireConnection.Side => 4585,
                                RedstoneWireConnection.None => 4586,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4587,
                                RedstoneWireConnection.Side => 4588,
                                RedstoneWireConnection.None => 4589,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4590,
                                RedstoneWireConnection.Side => 4591,
                                RedstoneWireConnection.None => 4592,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        7 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4593,
                                RedstoneWireConnection.Side => 4594,
                                RedstoneWireConnection.None => 4595,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4596,
                                RedstoneWireConnection.Side => 4597,
                                RedstoneWireConnection.None => 4598,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4599,
                                RedstoneWireConnection.Side => 4600,
                                RedstoneWireConnection.None => 4601,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        8 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4602,
                                RedstoneWireConnection.Side => 4603,
                                RedstoneWireConnection.None => 4604,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4605,
                                RedstoneWireConnection.Side => 4606,
                                RedstoneWireConnection.None => 4607,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4608,
                                RedstoneWireConnection.Side => 4609,
                                RedstoneWireConnection.None => 4610,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        9 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4611,
                                RedstoneWireConnection.Side => 4612,
                                RedstoneWireConnection.None => 4613,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4614,
                                RedstoneWireConnection.Side => 4615,
                                RedstoneWireConnection.None => 4616,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4617,
                                RedstoneWireConnection.Side => 4618,
                                RedstoneWireConnection.None => 4619,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        10 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4620,
                                RedstoneWireConnection.Side => 4621,
                                RedstoneWireConnection.None => 4622,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4623,
                                RedstoneWireConnection.Side => 4624,
                                RedstoneWireConnection.None => 4625,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4626,
                                RedstoneWireConnection.Side => 4627,
                                RedstoneWireConnection.None => 4628,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        11 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4629,
                                RedstoneWireConnection.Side => 4630,
                                RedstoneWireConnection.None => 4631,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4632,
                                RedstoneWireConnection.Side => 4633,
                                RedstoneWireConnection.None => 4634,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4635,
                                RedstoneWireConnection.Side => 4636,
                                RedstoneWireConnection.None => 4637,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        12 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4638,
                                RedstoneWireConnection.Side => 4639,
                                RedstoneWireConnection.None => 4640,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4641,
                                RedstoneWireConnection.Side => 4642,
                                RedstoneWireConnection.None => 4643,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4644,
                                RedstoneWireConnection.Side => 4645,
                                RedstoneWireConnection.None => 4646,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        13 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4647,
                                RedstoneWireConnection.Side => 4648,
                                RedstoneWireConnection.None => 4649,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4650,
                                RedstoneWireConnection.Side => 4651,
                                RedstoneWireConnection.None => 4652,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4653,
                                RedstoneWireConnection.Side => 4654,
                                RedstoneWireConnection.None => 4655,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        14 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4656,
                                RedstoneWireConnection.Side => 4657,
                                RedstoneWireConnection.None => 4658,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4659,
                                RedstoneWireConnection.Side => 4660,
                                RedstoneWireConnection.None => 4661,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4662,
                                RedstoneWireConnection.Side => 4663,
                                RedstoneWireConnection.None => 4664,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        15 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4665,
                                RedstoneWireConnection.Side => 4666,
                                RedstoneWireConnection.None => 4667,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4668,
                                RedstoneWireConnection.Side => 4669,
                                RedstoneWireConnection.None => 4670,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4671,
                                RedstoneWireConnection.Side => 4672,
                                RedstoneWireConnection.None => 4673,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                },
                RedstoneWireConnection.None => North switch {
                    RedstoneWireConnection.Up => Power switch {
                        0 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4674,
                                RedstoneWireConnection.Side => 4675,
                                RedstoneWireConnection.None => 4676,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4677,
                                RedstoneWireConnection.Side => 4678,
                                RedstoneWireConnection.None => 4679,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4680,
                                RedstoneWireConnection.Side => 4681,
                                RedstoneWireConnection.None => 4682,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        1 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4683,
                                RedstoneWireConnection.Side => 4684,
                                RedstoneWireConnection.None => 4685,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4686,
                                RedstoneWireConnection.Side => 4687,
                                RedstoneWireConnection.None => 4688,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4689,
                                RedstoneWireConnection.Side => 4690,
                                RedstoneWireConnection.None => 4691,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        2 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4692,
                                RedstoneWireConnection.Side => 4693,
                                RedstoneWireConnection.None => 4694,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4695,
                                RedstoneWireConnection.Side => 4696,
                                RedstoneWireConnection.None => 4697,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4698,
                                RedstoneWireConnection.Side => 4699,
                                RedstoneWireConnection.None => 4700,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        3 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4701,
                                RedstoneWireConnection.Side => 4702,
                                RedstoneWireConnection.None => 4703,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4704,
                                RedstoneWireConnection.Side => 4705,
                                RedstoneWireConnection.None => 4706,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4707,
                                RedstoneWireConnection.Side => 4708,
                                RedstoneWireConnection.None => 4709,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        4 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4710,
                                RedstoneWireConnection.Side => 4711,
                                RedstoneWireConnection.None => 4712,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4713,
                                RedstoneWireConnection.Side => 4714,
                                RedstoneWireConnection.None => 4715,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4716,
                                RedstoneWireConnection.Side => 4717,
                                RedstoneWireConnection.None => 4718,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        5 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4719,
                                RedstoneWireConnection.Side => 4720,
                                RedstoneWireConnection.None => 4721,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4722,
                                RedstoneWireConnection.Side => 4723,
                                RedstoneWireConnection.None => 4724,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4725,
                                RedstoneWireConnection.Side => 4726,
                                RedstoneWireConnection.None => 4727,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        6 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4728,
                                RedstoneWireConnection.Side => 4729,
                                RedstoneWireConnection.None => 4730,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4731,
                                RedstoneWireConnection.Side => 4732,
                                RedstoneWireConnection.None => 4733,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4734,
                                RedstoneWireConnection.Side => 4735,
                                RedstoneWireConnection.None => 4736,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        7 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4737,
                                RedstoneWireConnection.Side => 4738,
                                RedstoneWireConnection.None => 4739,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4740,
                                RedstoneWireConnection.Side => 4741,
                                RedstoneWireConnection.None => 4742,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4743,
                                RedstoneWireConnection.Side => 4744,
                                RedstoneWireConnection.None => 4745,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        8 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4746,
                                RedstoneWireConnection.Side => 4747,
                                RedstoneWireConnection.None => 4748,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4749,
                                RedstoneWireConnection.Side => 4750,
                                RedstoneWireConnection.None => 4751,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4752,
                                RedstoneWireConnection.Side => 4753,
                                RedstoneWireConnection.None => 4754,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        9 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4755,
                                RedstoneWireConnection.Side => 4756,
                                RedstoneWireConnection.None => 4757,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4758,
                                RedstoneWireConnection.Side => 4759,
                                RedstoneWireConnection.None => 4760,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4761,
                                RedstoneWireConnection.Side => 4762,
                                RedstoneWireConnection.None => 4763,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        10 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4764,
                                RedstoneWireConnection.Side => 4765,
                                RedstoneWireConnection.None => 4766,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4767,
                                RedstoneWireConnection.Side => 4768,
                                RedstoneWireConnection.None => 4769,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4770,
                                RedstoneWireConnection.Side => 4771,
                                RedstoneWireConnection.None => 4772,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        11 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4773,
                                RedstoneWireConnection.Side => 4774,
                                RedstoneWireConnection.None => 4775,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4776,
                                RedstoneWireConnection.Side => 4777,
                                RedstoneWireConnection.None => 4778,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4779,
                                RedstoneWireConnection.Side => 4780,
                                RedstoneWireConnection.None => 4781,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        12 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4782,
                                RedstoneWireConnection.Side => 4783,
                                RedstoneWireConnection.None => 4784,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4785,
                                RedstoneWireConnection.Side => 4786,
                                RedstoneWireConnection.None => 4787,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4788,
                                RedstoneWireConnection.Side => 4789,
                                RedstoneWireConnection.None => 4790,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        13 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4791,
                                RedstoneWireConnection.Side => 4792,
                                RedstoneWireConnection.None => 4793,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4794,
                                RedstoneWireConnection.Side => 4795,
                                RedstoneWireConnection.None => 4796,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4797,
                                RedstoneWireConnection.Side => 4798,
                                RedstoneWireConnection.None => 4799,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        14 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4800,
                                RedstoneWireConnection.Side => 4801,
                                RedstoneWireConnection.None => 4802,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4803,
                                RedstoneWireConnection.Side => 4804,
                                RedstoneWireConnection.None => 4805,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4806,
                                RedstoneWireConnection.Side => 4807,
                                RedstoneWireConnection.None => 4808,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        15 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4809,
                                RedstoneWireConnection.Side => 4810,
                                RedstoneWireConnection.None => 4811,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4812,
                                RedstoneWireConnection.Side => 4813,
                                RedstoneWireConnection.None => 4814,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4815,
                                RedstoneWireConnection.Side => 4816,
                                RedstoneWireConnection.None => 4817,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                    },
                    RedstoneWireConnection.Side => Power switch {
                        0 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4818,
                                RedstoneWireConnection.Side => 4819,
                                RedstoneWireConnection.None => 4820,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4821,
                                RedstoneWireConnection.Side => 4822,
                                RedstoneWireConnection.None => 4823,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4824,
                                RedstoneWireConnection.Side => 4825,
                                RedstoneWireConnection.None => 4826,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        1 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4827,
                                RedstoneWireConnection.Side => 4828,
                                RedstoneWireConnection.None => 4829,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4830,
                                RedstoneWireConnection.Side => 4831,
                                RedstoneWireConnection.None => 4832,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4833,
                                RedstoneWireConnection.Side => 4834,
                                RedstoneWireConnection.None => 4835,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        2 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4836,
                                RedstoneWireConnection.Side => 4837,
                                RedstoneWireConnection.None => 4838,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4839,
                                RedstoneWireConnection.Side => 4840,
                                RedstoneWireConnection.None => 4841,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4842,
                                RedstoneWireConnection.Side => 4843,
                                RedstoneWireConnection.None => 4844,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        3 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4845,
                                RedstoneWireConnection.Side => 4846,
                                RedstoneWireConnection.None => 4847,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4848,
                                RedstoneWireConnection.Side => 4849,
                                RedstoneWireConnection.None => 4850,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4851,
                                RedstoneWireConnection.Side => 4852,
                                RedstoneWireConnection.None => 4853,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        4 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4854,
                                RedstoneWireConnection.Side => 4855,
                                RedstoneWireConnection.None => 4856,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4857,
                                RedstoneWireConnection.Side => 4858,
                                RedstoneWireConnection.None => 4859,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4860,
                                RedstoneWireConnection.Side => 4861,
                                RedstoneWireConnection.None => 4862,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        5 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4863,
                                RedstoneWireConnection.Side => 4864,
                                RedstoneWireConnection.None => 4865,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4866,
                                RedstoneWireConnection.Side => 4867,
                                RedstoneWireConnection.None => 4868,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4869,
                                RedstoneWireConnection.Side => 4870,
                                RedstoneWireConnection.None => 4871,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        6 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4872,
                                RedstoneWireConnection.Side => 4873,
                                RedstoneWireConnection.None => 4874,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4875,
                                RedstoneWireConnection.Side => 4876,
                                RedstoneWireConnection.None => 4877,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4878,
                                RedstoneWireConnection.Side => 4879,
                                RedstoneWireConnection.None => 4880,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        7 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4881,
                                RedstoneWireConnection.Side => 4882,
                                RedstoneWireConnection.None => 4883,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4884,
                                RedstoneWireConnection.Side => 4885,
                                RedstoneWireConnection.None => 4886,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4887,
                                RedstoneWireConnection.Side => 4888,
                                RedstoneWireConnection.None => 4889,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        8 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4890,
                                RedstoneWireConnection.Side => 4891,
                                RedstoneWireConnection.None => 4892,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4893,
                                RedstoneWireConnection.Side => 4894,
                                RedstoneWireConnection.None => 4895,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4896,
                                RedstoneWireConnection.Side => 4897,
                                RedstoneWireConnection.None => 4898,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        9 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4899,
                                RedstoneWireConnection.Side => 4900,
                                RedstoneWireConnection.None => 4901,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4902,
                                RedstoneWireConnection.Side => 4903,
                                RedstoneWireConnection.None => 4904,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4905,
                                RedstoneWireConnection.Side => 4906,
                                RedstoneWireConnection.None => 4907,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        10 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4908,
                                RedstoneWireConnection.Side => 4909,
                                RedstoneWireConnection.None => 4910,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4911,
                                RedstoneWireConnection.Side => 4912,
                                RedstoneWireConnection.None => 4913,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4914,
                                RedstoneWireConnection.Side => 4915,
                                RedstoneWireConnection.None => 4916,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        11 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4917,
                                RedstoneWireConnection.Side => 4918,
                                RedstoneWireConnection.None => 4919,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4920,
                                RedstoneWireConnection.Side => 4921,
                                RedstoneWireConnection.None => 4922,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4923,
                                RedstoneWireConnection.Side => 4924,
                                RedstoneWireConnection.None => 4925,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        12 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4926,
                                RedstoneWireConnection.Side => 4927,
                                RedstoneWireConnection.None => 4928,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4929,
                                RedstoneWireConnection.Side => 4930,
                                RedstoneWireConnection.None => 4931,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4932,
                                RedstoneWireConnection.Side => 4933,
                                RedstoneWireConnection.None => 4934,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        13 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4935,
                                RedstoneWireConnection.Side => 4936,
                                RedstoneWireConnection.None => 4937,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4938,
                                RedstoneWireConnection.Side => 4939,
                                RedstoneWireConnection.None => 4940,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4941,
                                RedstoneWireConnection.Side => 4942,
                                RedstoneWireConnection.None => 4943,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        14 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4944,
                                RedstoneWireConnection.Side => 4945,
                                RedstoneWireConnection.None => 4946,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4947,
                                RedstoneWireConnection.Side => 4948,
                                RedstoneWireConnection.None => 4949,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4950,
                                RedstoneWireConnection.Side => 4951,
                                RedstoneWireConnection.None => 4952,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        15 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4953,
                                RedstoneWireConnection.Side => 4954,
                                RedstoneWireConnection.None => 4955,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4956,
                                RedstoneWireConnection.Side => 4957,
                                RedstoneWireConnection.None => 4958,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4959,
                                RedstoneWireConnection.Side => 4960,
                                RedstoneWireConnection.None => 4961,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                    },
                    RedstoneWireConnection.None => Power switch {
                        0 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4962,
                                RedstoneWireConnection.Side => 4963,
                                RedstoneWireConnection.None => 4964,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4965,
                                RedstoneWireConnection.Side => 4966,
                                RedstoneWireConnection.None => 4967,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4968,
                                RedstoneWireConnection.Side => 4969,
                                RedstoneWireConnection.None => 4970,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        1 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4971,
                                RedstoneWireConnection.Side => 4972,
                                RedstoneWireConnection.None => 4973,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4974,
                                RedstoneWireConnection.Side => 4975,
                                RedstoneWireConnection.None => 4976,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4977,
                                RedstoneWireConnection.Side => 4978,
                                RedstoneWireConnection.None => 4979,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        2 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4980,
                                RedstoneWireConnection.Side => 4981,
                                RedstoneWireConnection.None => 4982,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4983,
                                RedstoneWireConnection.Side => 4984,
                                RedstoneWireConnection.None => 4985,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4986,
                                RedstoneWireConnection.Side => 4987,
                                RedstoneWireConnection.None => 4988,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        3 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4989,
                                RedstoneWireConnection.Side => 4990,
                                RedstoneWireConnection.None => 4991,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4992,
                                RedstoneWireConnection.Side => 4993,
                                RedstoneWireConnection.None => 4994,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4995,
                                RedstoneWireConnection.Side => 4996,
                                RedstoneWireConnection.None => 4997,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        4 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4998,
                                RedstoneWireConnection.Side => 4999,
                                RedstoneWireConnection.None => 5000,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5001,
                                RedstoneWireConnection.Side => 5002,
                                RedstoneWireConnection.None => 5003,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5004,
                                RedstoneWireConnection.Side => 5005,
                                RedstoneWireConnection.None => 5006,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        5 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5007,
                                RedstoneWireConnection.Side => 5008,
                                RedstoneWireConnection.None => 5009,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5010,
                                RedstoneWireConnection.Side => 5011,
                                RedstoneWireConnection.None => 5012,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5013,
                                RedstoneWireConnection.Side => 5014,
                                RedstoneWireConnection.None => 5015,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        6 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5016,
                                RedstoneWireConnection.Side => 5017,
                                RedstoneWireConnection.None => 5018,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5019,
                                RedstoneWireConnection.Side => 5020,
                                RedstoneWireConnection.None => 5021,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5022,
                                RedstoneWireConnection.Side => 5023,
                                RedstoneWireConnection.None => 5024,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        7 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5025,
                                RedstoneWireConnection.Side => 5026,
                                RedstoneWireConnection.None => 5027,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5028,
                                RedstoneWireConnection.Side => 5029,
                                RedstoneWireConnection.None => 5030,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5031,
                                RedstoneWireConnection.Side => 5032,
                                RedstoneWireConnection.None => 5033,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        8 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5034,
                                RedstoneWireConnection.Side => 5035,
                                RedstoneWireConnection.None => 5036,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5037,
                                RedstoneWireConnection.Side => 5038,
                                RedstoneWireConnection.None => 5039,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5040,
                                RedstoneWireConnection.Side => 5041,
                                RedstoneWireConnection.None => 5042,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        9 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5043,
                                RedstoneWireConnection.Side => 5044,
                                RedstoneWireConnection.None => 5045,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5046,
                                RedstoneWireConnection.Side => 5047,
                                RedstoneWireConnection.None => 5048,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5049,
                                RedstoneWireConnection.Side => 5050,
                                RedstoneWireConnection.None => 5051,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        10 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5052,
                                RedstoneWireConnection.Side => 5053,
                                RedstoneWireConnection.None => 5054,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5055,
                                RedstoneWireConnection.Side => 5056,
                                RedstoneWireConnection.None => 5057,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5058,
                                RedstoneWireConnection.Side => 5059,
                                RedstoneWireConnection.None => 5060,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        11 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5061,
                                RedstoneWireConnection.Side => 5062,
                                RedstoneWireConnection.None => 5063,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5064,
                                RedstoneWireConnection.Side => 5065,
                                RedstoneWireConnection.None => 5066,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5067,
                                RedstoneWireConnection.Side => 5068,
                                RedstoneWireConnection.None => 5069,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        12 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5070,
                                RedstoneWireConnection.Side => 5071,
                                RedstoneWireConnection.None => 5072,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5073,
                                RedstoneWireConnection.Side => 5074,
                                RedstoneWireConnection.None => 5075,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5076,
                                RedstoneWireConnection.Side => 5077,
                                RedstoneWireConnection.None => 5078,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        13 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5079,
                                RedstoneWireConnection.Side => 5080,
                                RedstoneWireConnection.None => 5081,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5082,
                                RedstoneWireConnection.Side => 5083,
                                RedstoneWireConnection.None => 5084,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5085,
                                RedstoneWireConnection.Side => 5086,
                                RedstoneWireConnection.None => 5087,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        14 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5088,
                                RedstoneWireConnection.Side => 5089,
                                RedstoneWireConnection.None => 5090,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5091,
                                RedstoneWireConnection.Side => 5092,
                                RedstoneWireConnection.None => 5093,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5094,
                                RedstoneWireConnection.Side => 5095,
                                RedstoneWireConnection.None => 5096,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        15 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 5097,
                                RedstoneWireConnection.Side => 5098,
                                RedstoneWireConnection.None => 5099,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 5100,
                                RedstoneWireConnection.Side => 5101,
                                RedstoneWireConnection.None => 5102,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 5103,
                                RedstoneWireConnection.Side => 5104,
                                RedstoneWireConnection.None => 5105,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(East), East, "Unknown value for property east.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            3810 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3811 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3812 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3813 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3814 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3815 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3816 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 0, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3817 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 0, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3818 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 0, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3819 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3820 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3821 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3822 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3823 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3824 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3825 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 1, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3826 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 1, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3827 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 1, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3828 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3829 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3830 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3831 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3832 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3833 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3834 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 2, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3835 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 2, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3836 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 2, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3837 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3838 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3839 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3840 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3841 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3842 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3843 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 3, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3844 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 3, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3845 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 3, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3846 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3847 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3848 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3849 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3850 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3851 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3852 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 4, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3853 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 4, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3854 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 4, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3855 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3856 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3857 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3858 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3859 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3860 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3861 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 5, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3862 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 5, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3863 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 5, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3864 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3865 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3866 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3867 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3868 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3869 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3870 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 6, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3871 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 6, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3872 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 6, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3873 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3874 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3875 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3876 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3877 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3878 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3879 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 7, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3880 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 7, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3881 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 7, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3882 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3883 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3884 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3885 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3886 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3887 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3888 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 8, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3889 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 8, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3890 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 8, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3891 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3892 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3893 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3894 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3895 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3896 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3897 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 9, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3898 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 9, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3899 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 9, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3900 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3901 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3902 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3903 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3904 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3905 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3906 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 10, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3907 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 10, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3908 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 10, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3909 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3910 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3911 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3912 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3913 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3914 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3915 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 11, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3916 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 11, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3917 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 11, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3918 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3919 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3920 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3921 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3922 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3923 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3924 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 12, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3925 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 12, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3926 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 12, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3927 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3928 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3929 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3930 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3931 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3932 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3933 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 13, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3934 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 13, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3935 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 13, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3936 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3937 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3938 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3939 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3940 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3941 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3942 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 14, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3943 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 14, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3944 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 14, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3945 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3946 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3947 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3948 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3949 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3950 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3951 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 15, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3952 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 15, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3953 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 15, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3954 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3955 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3956 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3957 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3958 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3959 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3960 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 0, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3961 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 0, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3962 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 0, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3963 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3964 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3965 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3966 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3967 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3968 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3969 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 1, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3970 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 1, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3971 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 1, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3972 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3973 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3974 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3975 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3976 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3977 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3978 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 2, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3979 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 2, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3980 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 2, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3981 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3982 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3983 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3984 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3985 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3986 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3987 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 3, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3988 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 3, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3989 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 3, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3990 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3991 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3992 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3993 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3994 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3995 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3996 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 4, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3997 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 4, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3998 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 4, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3999 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4000 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4001 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4002 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4003 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4004 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4005 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 5, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4006 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 5, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4007 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 5, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4008 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4009 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4010 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4011 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4012 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4013 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4014 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 6, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4015 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 6, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4016 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 6, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4017 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4018 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4019 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4020 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4021 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4022 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4023 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 7, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4024 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 7, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4025 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 7, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4026 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4027 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4028 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4029 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4030 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4031 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4032 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 8, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4033 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 8, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4034 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 8, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4035 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4036 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4037 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4038 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4039 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4040 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4041 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 9, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4042 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 9, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4043 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 9, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4044 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4045 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4046 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4047 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4048 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4049 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4050 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 10, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4051 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 10, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4052 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 10, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4053 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4054 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4055 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4056 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4057 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4058 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4059 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 11, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4060 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 11, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4061 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 11, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4062 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4063 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4064 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4065 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4066 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4067 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4068 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 12, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4069 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 12, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4070 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 12, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4071 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4072 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4073 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4074 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4075 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4076 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4077 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 13, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4078 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 13, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4079 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 13, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4080 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4081 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4082 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4083 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4084 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4085 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4086 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 14, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4087 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 14, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4088 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 14, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4089 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4090 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4091 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4092 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4093 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4094 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4095 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 15, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4096 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 15, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4097 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 15, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4098 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4099 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4100 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 0, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4101 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4102 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4103 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 0, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4104 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 0, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4105 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 0, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4106 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 0, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4107 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4108 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4109 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 1, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4110 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4111 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4112 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 1, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4113 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 1, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4114 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 1, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4115 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 1, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4116 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4117 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4118 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 2, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4119 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4120 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4121 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 2, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4122 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 2, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4123 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 2, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4124 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 2, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4125 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4126 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4127 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 3, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4128 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4129 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4130 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 3, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4131 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 3, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4132 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 3, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4133 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 3, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4134 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4135 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4136 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 4, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4137 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4138 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4139 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 4, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4140 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 4, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4141 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 4, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4142 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 4, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4143 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4144 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4145 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 5, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4146 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4147 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4148 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 5, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4149 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 5, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4150 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 5, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4151 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 5, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4152 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4153 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4154 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 6, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4155 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4156 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4157 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 6, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4158 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 6, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4159 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 6, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4160 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 6, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4161 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4162 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4163 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 7, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4164 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4165 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4166 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 7, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4167 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 7, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4168 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 7, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4169 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 7, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4170 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4171 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4172 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 8, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4173 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4174 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4175 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 8, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4176 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 8, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4177 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 8, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4178 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 8, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4179 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4180 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4181 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 9, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4182 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4183 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4184 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 9, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4185 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 9, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4186 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 9, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4187 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 9, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4188 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4189 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4190 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 10, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4191 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4192 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4193 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 10, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4194 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 10, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4195 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 10, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4196 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 10, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4197 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4198 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4199 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 11, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4200 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4201 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4202 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 11, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4203 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 11, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4204 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 11, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4205 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 11, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4206 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4207 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4208 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 12, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4209 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4210 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4211 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 12, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4212 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 12, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4213 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 12, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4214 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 12, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4215 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4216 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4217 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 13, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4218 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4219 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4220 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 13, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4221 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 13, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4222 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 13, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4223 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 13, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4224 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4225 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4226 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 14, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4227 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4228 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4229 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 14, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4230 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 14, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4231 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 14, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4232 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 14, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4233 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4234 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4235 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 15, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4236 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4237 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4238 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 15, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4239 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 15, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4240 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 15, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4241 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 15, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4242 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4243 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4244 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4245 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4246 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4247 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4248 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 0, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4249 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 0, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4250 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 0, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4251 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4252 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4253 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4254 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4255 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4256 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4257 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 1, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4258 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 1, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4259 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 1, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4260 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4261 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4262 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4263 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4264 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4265 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4266 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 2, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4267 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 2, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4268 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 2, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4269 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4270 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4271 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4272 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4273 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4274 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4275 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 3, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4276 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 3, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4277 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 3, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4278 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4279 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4280 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4281 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4282 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4283 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4284 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 4, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4285 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 4, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4286 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 4, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4287 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4288 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4289 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4290 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4291 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4292 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4293 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 5, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4294 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 5, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4295 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 5, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4296 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4297 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4298 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4299 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4300 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4301 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4302 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 6, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4303 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 6, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4304 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 6, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4305 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4306 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4307 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4308 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4309 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4310 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4311 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 7, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4312 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 7, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4313 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 7, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4314 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4315 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4316 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4317 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4318 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4319 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4320 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 8, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4321 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 8, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4322 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 8, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4323 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4324 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4325 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4326 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4327 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4328 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4329 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 9, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4330 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 9, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4331 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 9, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4332 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4333 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4334 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4335 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4336 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4337 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4338 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 10, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4339 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 10, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4340 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 10, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4341 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4342 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4343 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4344 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4345 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4346 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4347 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 11, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4348 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 11, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4349 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 11, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4350 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4351 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4352 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4353 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4354 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4355 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4356 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 12, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4357 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 12, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4358 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 12, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4359 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4360 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4361 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4362 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4363 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4364 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4365 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 13, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4366 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 13, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4367 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 13, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4368 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4369 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4370 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4371 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4372 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4373 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4374 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 14, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4375 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 14, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4376 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 14, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4377 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4378 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4379 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4380 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4381 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4382 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4383 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 15, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4384 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 15, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4385 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 15, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4386 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4387 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4388 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4389 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4390 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4391 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4392 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 0, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4393 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 0, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4394 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 0, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4395 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4396 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4397 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4398 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4399 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4400 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4401 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 1, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4402 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 1, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4403 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 1, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4404 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4405 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4406 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4407 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4408 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4409 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4410 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 2, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4411 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 2, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4412 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 2, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4413 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4414 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4415 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4416 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4417 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4418 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4419 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 3, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4420 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 3, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4421 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 3, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4422 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4423 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4424 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4425 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4426 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4427 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4428 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 4, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4429 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 4, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4430 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 4, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4431 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4432 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4433 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4434 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4435 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4436 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4437 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 5, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4438 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 5, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4439 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 5, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4440 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4441 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4442 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4443 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4444 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4445 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4446 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 6, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4447 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 6, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4448 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 6, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4449 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4450 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4451 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4452 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4453 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4454 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4455 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 7, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4456 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 7, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4457 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 7, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4458 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4459 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4460 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4461 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4462 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4463 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4464 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 8, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4465 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 8, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4466 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 8, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4467 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4468 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4469 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4470 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4471 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4472 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4473 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 9, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4474 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 9, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4475 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 9, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4476 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4477 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4478 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4479 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4480 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4481 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4482 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 10, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4483 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 10, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4484 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 10, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4485 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4486 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4487 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4488 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4489 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4490 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4491 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 11, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4492 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 11, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4493 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 11, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4494 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4495 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4496 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4497 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4498 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4499 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4500 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 12, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4501 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 12, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4502 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 12, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4503 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4504 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4505 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4506 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4507 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4508 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4509 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 13, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4510 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 13, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4511 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 13, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4512 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4513 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4514 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4515 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4516 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4517 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4518 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 14, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4519 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 14, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4520 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 14, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4521 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4522 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4523 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4524 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4525 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4526 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4527 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 15, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4528 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 15, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4529 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 15, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4530 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4531 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4532 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 0, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4533 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4534 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4535 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 0, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4536 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 0, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4537 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 0, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4538 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 0, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4539 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4540 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4541 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 1, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4542 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4543 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4544 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 1, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4545 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 1, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4546 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 1, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4547 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 1, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4548 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4549 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4550 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 2, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4551 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4552 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4553 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 2, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4554 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 2, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4555 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 2, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4556 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 2, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4557 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4558 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4559 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 3, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4560 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4561 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4562 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 3, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4563 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 3, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4564 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 3, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4565 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 3, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4566 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4567 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4568 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 4, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4569 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4570 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4571 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 4, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4572 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 4, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4573 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 4, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4574 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 4, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4575 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4576 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4577 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 5, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4578 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4579 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4580 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 5, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4581 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 5, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4582 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 5, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4583 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 5, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4584 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4585 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4586 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 6, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4587 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4588 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4589 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 6, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4590 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 6, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4591 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 6, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4592 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 6, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4593 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4594 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4595 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 7, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4596 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4597 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4598 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 7, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4599 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 7, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4600 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 7, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4601 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 7, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4602 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4603 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4604 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 8, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4605 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4606 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4607 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 8, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4608 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 8, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4609 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 8, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4610 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 8, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4611 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4612 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4613 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 9, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4614 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4615 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4616 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 9, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4617 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 9, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4618 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 9, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4619 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 9, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4620 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4621 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4622 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 10, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4623 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4624 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4625 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 10, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4626 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 10, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4627 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 10, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4628 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 10, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4629 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4630 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4631 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 11, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4632 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4633 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4634 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 11, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4635 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 11, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4636 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 11, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4637 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 11, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4638 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4639 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4640 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 12, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4641 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4642 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4643 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 12, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4644 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 12, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4645 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 12, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4646 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 12, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4647 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4648 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4649 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 13, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4650 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4651 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4652 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 13, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4653 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 13, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4654 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 13, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4655 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 13, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4656 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4657 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4658 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 14, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4659 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4660 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4661 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 14, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4662 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 14, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4663 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 14, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4664 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 14, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4665 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4666 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4667 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 15, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4668 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4669 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4670 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 15, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4671 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 15, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4672 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 15, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4673 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 15, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4674 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4675 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4676 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4677 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4678 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4679 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4680 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 0, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4681 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 0, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4682 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 0, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4683 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4684 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4685 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4686 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4687 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4688 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4689 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 1, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4690 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 1, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4691 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 1, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4692 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4693 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4694 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4695 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4696 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4697 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4698 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 2, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4699 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 2, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4700 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 2, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4701 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4702 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4703 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4704 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4705 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4706 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4707 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 3, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4708 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 3, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4709 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 3, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4710 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4711 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4712 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4713 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4714 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4715 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4716 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 4, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4717 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 4, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4718 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 4, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4719 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4720 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4721 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4722 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4723 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4724 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4725 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 5, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4726 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 5, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4727 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 5, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4728 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4729 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4730 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4731 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4732 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4733 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4734 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 6, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4735 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 6, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4736 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 6, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4737 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4738 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4739 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4740 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4741 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4742 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4743 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 7, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4744 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 7, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4745 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 7, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4746 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4747 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4748 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4749 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4750 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4751 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4752 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 8, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4753 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 8, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4754 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 8, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4755 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4756 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4757 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4758 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4759 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4760 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4761 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 9, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4762 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 9, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4763 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 9, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4764 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4765 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4766 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4767 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4768 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4769 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4770 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 10, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4771 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 10, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4772 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 10, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4773 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4774 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4775 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4776 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4777 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4778 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4779 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 11, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4780 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 11, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4781 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 11, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4782 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4783 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4784 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4785 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4786 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4787 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4788 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 12, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4789 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 12, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4790 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 12, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4791 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4792 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4793 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4794 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4795 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4796 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4797 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 13, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4798 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 13, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4799 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 13, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4800 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4801 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4802 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4803 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4804 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4805 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4806 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 14, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4807 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 14, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4808 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 14, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4809 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4810 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4811 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4812 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4813 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4814 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4815 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 15, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4816 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 15, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4817 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 15, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4818 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4819 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4820 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4821 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4822 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4823 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4824 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 0, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4825 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 0, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4826 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 0, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4827 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4828 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4829 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4830 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4831 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4832 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4833 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 1, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4834 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 1, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4835 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 1, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4836 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4837 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4838 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4839 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4840 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4841 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4842 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 2, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4843 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 2, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4844 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 2, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4845 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4846 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4847 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4848 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4849 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4850 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4851 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 3, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4852 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 3, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4853 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 3, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4854 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4855 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4856 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4857 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4858 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4859 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4860 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 4, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4861 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 4, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4862 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 4, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4863 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4864 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4865 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4866 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4867 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4868 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4869 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 5, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4870 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 5, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4871 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 5, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4872 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4873 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4874 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4875 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4876 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4877 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4878 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 6, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4879 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 6, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4880 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 6, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4881 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4882 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4883 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4884 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4885 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4886 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4887 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 7, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4888 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 7, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4889 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 7, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4890 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4891 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4892 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4893 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4894 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4895 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4896 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 8, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4897 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 8, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4898 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 8, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4899 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4900 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4901 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4902 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4903 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4904 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4905 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 9, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4906 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 9, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4907 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 9, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4908 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4909 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4910 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4911 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4912 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4913 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4914 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 10, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4915 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 10, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4916 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 10, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4917 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4918 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4919 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4920 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4921 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4922 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4923 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 11, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4924 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 11, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4925 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 11, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4926 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4927 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4928 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4929 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4930 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4931 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4932 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 12, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4933 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 12, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4934 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 12, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4935 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4936 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4937 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4938 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4939 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4940 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4941 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 13, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4942 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 13, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4943 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 13, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4944 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4945 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4946 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4947 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4948 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4949 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4950 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 14, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4951 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 14, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4952 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 14, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4953 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4954 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4955 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4956 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4957 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4958 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4959 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 15, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4960 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 15, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4961 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 15, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4962 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4963 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4964 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 0, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4965 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4966 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4967 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 0, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4968 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 0, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4969 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 0, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4970 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 0, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4971 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4972 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4973 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 1, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4974 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4975 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4976 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 1, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4977 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 1, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4978 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 1, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4979 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 1, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4980 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4981 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4982 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 2, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4983 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4984 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4985 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 2, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4986 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 2, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4987 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 2, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4988 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 2, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4989 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4990 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4991 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 3, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4992 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4993 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4994 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 3, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4995 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 3, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4996 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 3, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4997 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 3, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4998 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4999 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5000 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 4, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5001 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5002 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5003 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 4, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5004 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 4, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5005 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 4, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5006 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 4, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5007 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5008 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5009 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 5, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5010 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5011 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5012 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 5, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5013 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 5, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5014 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 5, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5015 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 5, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5016 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5017 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5018 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 6, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5019 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5020 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5021 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 6, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5022 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 6, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5023 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 6, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5024 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 6, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5025 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5026 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5027 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 7, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5028 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5029 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5030 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 7, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5031 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 7, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5032 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 7, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5033 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 7, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5034 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5035 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5036 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 8, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5037 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5038 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5039 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 8, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5040 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 8, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5041 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 8, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5042 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 8, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5043 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5044 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5045 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 9, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5046 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5047 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5048 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 9, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5049 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 9, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5050 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 9, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5051 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 9, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5052 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5053 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5054 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 10, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5055 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5056 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5057 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 10, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5058 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 10, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5059 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 10, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5060 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 10, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5061 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5062 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5063 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 11, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5064 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5065 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5066 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 11, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5067 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 11, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5068 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 11, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5069 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 11, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5070 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5071 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5072 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 12, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5073 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5074 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5075 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 12, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5076 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 12, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5077 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 12, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5078 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 12, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5079 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5080 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5081 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 13, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5082 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5083 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5084 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 13, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5085 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 13, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5086 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 13, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5087 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 13, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5088 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5089 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5090 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 14, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5091 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5092 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5093 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 14, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5094 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 14, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5095 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 14, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5096 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 14, RedstoneWireConnection.None, RedstoneWireConnection.None),
            5097 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            5098 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            5099 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 15, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            5100 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            5101 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            5102 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 15, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            5103 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 15, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            5104 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 15, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            5105 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 15, RedstoneWireConnection.None, RedstoneWireConnection.None),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            East = properties.ChildrenMap.ContainsKey("east") ? RedstoneWireConnectionExtensions.FromString(properties["east"].GetString()) : East,
            North = properties.ChildrenMap.ContainsKey("north") ? RedstoneWireConnectionExtensions.FromString(properties["north"].GetString()) : North,
            Power = properties.ChildrenMap.ContainsKey("power") ? int.Parse(properties["power"].GetString()) : Power,
            South = properties.ChildrenMap.ContainsKey("south") ? RedstoneWireConnectionExtensions.FromString(properties["south"].GetString()) : South,
            West = properties.ChildrenMap.ContainsKey("west") ? RedstoneWireConnectionExtensions.FromString(properties["west"].GetString()) : West,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("east", East.ToName()),
            new StringTag("north", North.ToName()),
            new StringTag("power", Power.ToString()),
            new StringTag("south", South.ToName()),
            new StringTag("west", West.ToName())
        );
    }
    
}
