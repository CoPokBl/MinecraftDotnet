using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ChiseledBookshelfBlock(Identifier Identifier, Direction Facing, bool Slot0Occupied, bool Slot1Occupied, bool Slot2Occupied, bool Slot3Occupied, bool Slot4Occupied, bool Slot5Occupied) : IBlock, IHorizontalFacing {
    private static readonly BlockInfo Data = new("block.minecraft.chiseled_bookshelf", 1.5f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:chiseled_bookshelf", "minecraft:chiseled_bookshelf", BlockInfo.VanillaOnly, "minecraft:blocks/chiseled_bookshelf");
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 15, PushReaction.PushPull, 13, "chiseled_bookshelf", NoteBlockInstrument.Bass, false, true, false, false, false, false, false, true, true, false, false, true, true, false, true, false, false, false, null, null, BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S79, BlockShapes.S79, BlockShapes.S79);

    public BlockStateInfo StateInfo => I0;

    public BlockInfo Info => Data;
    public float ExplosionResistance => Data.ExplosionResistance;
    public float Friction => Data.Friction;
    public float SpeedFactor => Data.SpeedFactor;
    public float JumpFactor => Data.JumpFactor;
    public float BounceRestitution => Data.BounceRestitution;
    public float FallDistanceReduction => Data.FallDistanceReduction;
    public bool Gravity => Data.Gravity;
    public string TranslationKey => Data.TranslationKey;
    public Identifier? BlockEntity => Data.BlockEntity;
    public Identifier? Item => Data.Item;
    public Identifier? LootTable => Data.LootTable;
    public (int Min, int Max)? Experience => Data.Experience;

    public float Hardness => StateInfo.Hardness;
    public bool Solid => StateInfo.Solid;
    public bool Liquid => StateInfo.Liquid;
    public bool Air => StateInfo.Air;
    public bool Occludes => StateInfo.Occludes;
    public bool RequiresTool => StateInfo.RequiresTool;
    public int LightEmission => StateInfo.LightEmission;
    public int LightDampening => StateInfo.LightDampening;
    public bool Replaceable => StateInfo.Replaceable;
    public string SoundType => StateInfo.SoundType;
    public ICollisionBox BlockShape => StateInfo.BlockShape;
    public ICollisionBox CollisionShape => StateInfo.CollisionShape;
    public ICollisionBox OcclusionShape => StateInfo.OcclusionShape;
    public ICollisionBox InteractionShape => StateInfo.InteractionShape;
    public ICollisionBox VisualShape => StateInfo.VisualShape;
    public ICollisionBox SupportShape => StateInfo.SupportShape;
    public bool RedstoneConductor => StateInfo.RedstoneConductor;
    public bool SignalSource => StateInfo.SignalSource;
    public bool Flammable => StateInfo.Flammable;
    public PushReaction PushReaction => StateInfo.PushReaction;
    public int MapColorId => StateInfo.MapColorId;
    public bool CanRespawnIn => StateInfo.CanRespawnIn;
    public bool RandomlyTicking => StateInfo.RandomlyTicking;
    public bool Suffocating => StateInfo.Suffocating;
    public bool ViewBlocking => StateInfo.ViewBlocking;
    public bool ViewBlockingNearPlane => StateInfo.ViewBlockingNearPlane;
    public bool SpawnTerrainParticles => StateInfo.SpawnTerrainParticles;
    public bool PathfindableLand => StateInfo.PathfindableLand;
    public bool PathfindableWater => StateInfo.PathfindableWater;
    public bool PathfindableAir => StateInfo.PathfindableAir;
    public NoteBlockInstrument Instrument => StateInfo.Instrument;
    public Identifier? Fluid => StateInfo.Fluid;

    public IBlock WithFacing(Direction facing) => this with { Facing = facing };


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Slot0Occupied switch {
                    true => Slot1Occupied switch {
                        true => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 3836,
                                        false => 3837,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3838,
                                        false => 3839,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 3840,
                                        false => 3841,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3842,
                                        false => 3843,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 3844,
                                        false => 3845,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3846,
                                        false => 3847,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 3848,
                                        false => 3849,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3850,
                                        false => 3851,
                                    },
                                },
                            },
                        },
                        false => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 3852,
                                        false => 3853,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3854,
                                        false => 3855,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 3856,
                                        false => 3857,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3858,
                                        false => 3859,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 3860,
                                        false => 3861,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3862,
                                        false => 3863,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 3864,
                                        false => 3865,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3866,
                                        false => 3867,
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
                                        true => 3868,
                                        false => 3869,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3870,
                                        false => 3871,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 3872,
                                        false => 3873,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3874,
                                        false => 3875,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 3876,
                                        false => 3877,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3878,
                                        false => 3879,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 3880,
                                        false => 3881,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3882,
                                        false => 3883,
                                    },
                                },
                            },
                        },
                        false => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 3884,
                                        false => 3885,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3886,
                                        false => 3887,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 3888,
                                        false => 3889,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3890,
                                        false => 3891,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 3892,
                                        false => 3893,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3894,
                                        false => 3895,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 3896,
                                        false => 3897,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3898,
                                        false => 3899,
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
                                        true => 3900,
                                        false => 3901,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3902,
                                        false => 3903,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 3904,
                                        false => 3905,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3906,
                                        false => 3907,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 3908,
                                        false => 3909,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3910,
                                        false => 3911,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 3912,
                                        false => 3913,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3914,
                                        false => 3915,
                                    },
                                },
                            },
                        },
                        false => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 3916,
                                        false => 3917,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3918,
                                        false => 3919,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 3920,
                                        false => 3921,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3922,
                                        false => 3923,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 3924,
                                        false => 3925,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3926,
                                        false => 3927,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 3928,
                                        false => 3929,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3930,
                                        false => 3931,
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
                                        true => 3932,
                                        false => 3933,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3934,
                                        false => 3935,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 3936,
                                        false => 3937,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3938,
                                        false => 3939,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 3940,
                                        false => 3941,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3942,
                                        false => 3943,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 3944,
                                        false => 3945,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3946,
                                        false => 3947,
                                    },
                                },
                            },
                        },
                        false => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 3948,
                                        false => 3949,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3950,
                                        false => 3951,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 3952,
                                        false => 3953,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3954,
                                        false => 3955,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 3956,
                                        false => 3957,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3958,
                                        false => 3959,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 3960,
                                        false => 3961,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3962,
                                        false => 3963,
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
                                        true => 3964,
                                        false => 3965,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3966,
                                        false => 3967,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 3968,
                                        false => 3969,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3970,
                                        false => 3971,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 3972,
                                        false => 3973,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3974,
                                        false => 3975,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 3976,
                                        false => 3977,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3978,
                                        false => 3979,
                                    },
                                },
                            },
                        },
                        false => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 3980,
                                        false => 3981,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3982,
                                        false => 3983,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 3984,
                                        false => 3985,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3986,
                                        false => 3987,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 3988,
                                        false => 3989,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3990,
                                        false => 3991,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 3992,
                                        false => 3993,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3994,
                                        false => 3995,
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
                                        true => 3996,
                                        false => 3997,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 3998,
                                        false => 3999,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 4000,
                                        false => 4001,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 4002,
                                        false => 4003,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 4004,
                                        false => 4005,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 4006,
                                        false => 4007,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 4008,
                                        false => 4009,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 4010,
                                        false => 4011,
                                    },
                                },
                            },
                        },
                        false => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 4012,
                                        false => 4013,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 4014,
                                        false => 4015,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 4016,
                                        false => 4017,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 4018,
                                        false => 4019,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 4020,
                                        false => 4021,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 4022,
                                        false => 4023,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 4024,
                                        false => 4025,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 4026,
                                        false => 4027,
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
                                        true => 4028,
                                        false => 4029,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 4030,
                                        false => 4031,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 4032,
                                        false => 4033,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 4034,
                                        false => 4035,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 4036,
                                        false => 4037,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 4038,
                                        false => 4039,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 4040,
                                        false => 4041,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 4042,
                                        false => 4043,
                                    },
                                },
                            },
                        },
                        false => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 4044,
                                        false => 4045,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 4046,
                                        false => 4047,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 4048,
                                        false => 4049,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 4050,
                                        false => 4051,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 4052,
                                        false => 4053,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 4054,
                                        false => 4055,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 4056,
                                        false => 4057,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 4058,
                                        false => 4059,
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
                                        true => 4060,
                                        false => 4061,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 4062,
                                        false => 4063,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 4064,
                                        false => 4065,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 4066,
                                        false => 4067,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 4068,
                                        false => 4069,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 4070,
                                        false => 4071,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 4072,
                                        false => 4073,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 4074,
                                        false => 4075,
                                    },
                                },
                            },
                        },
                        false => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 4076,
                                        false => 4077,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 4078,
                                        false => 4079,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 4080,
                                        false => 4081,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 4082,
                                        false => 4083,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 4084,
                                        false => 4085,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 4086,
                                        false => 4087,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 4088,
                                        false => 4089,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 4090,
                                        false => 4091,
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
            3836 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, true, true, true, true),
            3837 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, true, true, true, false),
            3838 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, true, true, false, true),
            3839 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, true, true, false, false),
            3840 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, true, false, true, true),
            3841 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, true, false, true, false),
            3842 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, true, false, false, true),
            3843 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, true, false, false, false),
            3844 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, false, true, true, true),
            3845 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, false, true, true, false),
            3846 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, false, true, false, true),
            3847 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, false, true, false, false),
            3848 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, false, false, true, true),
            3849 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, false, false, true, false),
            3850 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, false, false, false, true),
            3851 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, false, false, false, false),
            3852 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, true, true, true, true),
            3853 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, true, true, true, false),
            3854 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, true, true, false, true),
            3855 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, true, true, false, false),
            3856 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, true, false, true, true),
            3857 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, true, false, true, false),
            3858 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, true, false, false, true),
            3859 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, true, false, false, false),
            3860 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, false, true, true, true),
            3861 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, false, true, true, false),
            3862 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, false, true, false, true),
            3863 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, false, true, false, false),
            3864 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, false, false, true, true),
            3865 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, false, false, true, false),
            3866 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, false, false, false, true),
            3867 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, false, false, false, false),
            3868 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, true, true, true, true),
            3869 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, true, true, true, false),
            3870 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, true, true, false, true),
            3871 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, true, true, false, false),
            3872 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, true, false, true, true),
            3873 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, true, false, true, false),
            3874 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, true, false, false, true),
            3875 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, true, false, false, false),
            3876 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, false, true, true, true),
            3877 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, false, true, true, false),
            3878 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, false, true, false, true),
            3879 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, false, true, false, false),
            3880 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, false, false, true, true),
            3881 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, false, false, true, false),
            3882 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, false, false, false, true),
            3883 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, false, false, false, false),
            3884 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, true, true, true, true),
            3885 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, true, true, true, false),
            3886 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, true, true, false, true),
            3887 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, true, true, false, false),
            3888 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, true, false, true, true),
            3889 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, true, false, true, false),
            3890 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, true, false, false, true),
            3891 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, true, false, false, false),
            3892 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, false, true, true, true),
            3893 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, false, true, true, false),
            3894 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, false, true, false, true),
            3895 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, false, true, false, false),
            3896 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, false, false, true, true),
            3897 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, false, false, true, false),
            3898 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, false, false, false, true),
            3899 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, false, false, false, false),
            3900 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, true, true, true, true),
            3901 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, true, true, true, false),
            3902 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, true, true, false, true),
            3903 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, true, true, false, false),
            3904 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, true, false, true, true),
            3905 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, true, false, true, false),
            3906 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, true, false, false, true),
            3907 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, true, false, false, false),
            3908 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, false, true, true, true),
            3909 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, false, true, true, false),
            3910 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, false, true, false, true),
            3911 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, false, true, false, false),
            3912 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, false, false, true, true),
            3913 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, false, false, true, false),
            3914 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, false, false, false, true),
            3915 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, false, false, false, false),
            3916 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, true, true, true, true),
            3917 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, true, true, true, false),
            3918 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, true, true, false, true),
            3919 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, true, true, false, false),
            3920 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, true, false, true, true),
            3921 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, true, false, true, false),
            3922 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, true, false, false, true),
            3923 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, true, false, false, false),
            3924 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, false, true, true, true),
            3925 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, false, true, true, false),
            3926 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, false, true, false, true),
            3927 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, false, true, false, false),
            3928 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, false, false, true, true),
            3929 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, false, false, true, false),
            3930 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, false, false, false, true),
            3931 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, false, false, false, false),
            3932 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, true, true, true, true),
            3933 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, true, true, true, false),
            3934 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, true, true, false, true),
            3935 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, true, true, false, false),
            3936 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, true, false, true, true),
            3937 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, true, false, true, false),
            3938 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, true, false, false, true),
            3939 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, true, false, false, false),
            3940 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, false, true, true, true),
            3941 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, false, true, true, false),
            3942 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, false, true, false, true),
            3943 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, false, true, false, false),
            3944 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, false, false, true, true),
            3945 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, false, false, true, false),
            3946 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, false, false, false, true),
            3947 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, false, false, false, false),
            3948 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, true, true, true, true),
            3949 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, true, true, true, false),
            3950 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, true, true, false, true),
            3951 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, true, true, false, false),
            3952 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, true, false, true, true),
            3953 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, true, false, true, false),
            3954 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, true, false, false, true),
            3955 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, true, false, false, false),
            3956 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, false, true, true, true),
            3957 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, false, true, true, false),
            3958 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, false, true, false, true),
            3959 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, false, true, false, false),
            3960 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, false, false, true, true),
            3961 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, false, false, true, false),
            3962 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, false, false, false, true),
            3963 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, false, false, false, false),
            3964 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, true, true, true, true),
            3965 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, true, true, true, false),
            3966 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, true, true, false, true),
            3967 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, true, true, false, false),
            3968 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, true, false, true, true),
            3969 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, true, false, true, false),
            3970 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, true, false, false, true),
            3971 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, true, false, false, false),
            3972 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, false, true, true, true),
            3973 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, false, true, true, false),
            3974 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, false, true, false, true),
            3975 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, false, true, false, false),
            3976 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, false, false, true, true),
            3977 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, false, false, true, false),
            3978 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, false, false, false, true),
            3979 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, false, false, false, false),
            3980 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, true, true, true, true),
            3981 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, true, true, true, false),
            3982 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, true, true, false, true),
            3983 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, true, true, false, false),
            3984 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, true, false, true, true),
            3985 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, true, false, true, false),
            3986 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, true, false, false, true),
            3987 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, true, false, false, false),
            3988 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, false, true, true, true),
            3989 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, false, true, true, false),
            3990 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, false, true, false, true),
            3991 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, false, true, false, false),
            3992 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, false, false, true, true),
            3993 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, false, false, true, false),
            3994 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, false, false, false, true),
            3995 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, false, false, false, false),
            3996 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, true, true, true, true),
            3997 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, true, true, true, false),
            3998 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, true, true, false, true),
            3999 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, true, true, false, false),
            4000 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, true, false, true, true),
            4001 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, true, false, true, false),
            4002 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, true, false, false, true),
            4003 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, true, false, false, false),
            4004 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, false, true, true, true),
            4005 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, false, true, true, false),
            4006 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, false, true, false, true),
            4007 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, false, true, false, false),
            4008 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, false, false, true, true),
            4009 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, false, false, true, false),
            4010 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, false, false, false, true),
            4011 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, false, false, false, false),
            4012 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, true, true, true, true),
            4013 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, true, true, true, false),
            4014 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, true, true, false, true),
            4015 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, true, true, false, false),
            4016 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, true, false, true, true),
            4017 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, true, false, true, false),
            4018 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, true, false, false, true),
            4019 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, true, false, false, false),
            4020 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, false, true, true, true),
            4021 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, false, true, true, false),
            4022 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, false, true, false, true),
            4023 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, false, true, false, false),
            4024 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, false, false, true, true),
            4025 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, false, false, true, false),
            4026 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, false, false, false, true),
            4027 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, false, false, false, false),
            4028 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, true, true, true, true),
            4029 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, true, true, true, false),
            4030 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, true, true, false, true),
            4031 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, true, true, false, false),
            4032 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, true, false, true, true),
            4033 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, true, false, true, false),
            4034 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, true, false, false, true),
            4035 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, true, false, false, false),
            4036 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, false, true, true, true),
            4037 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, false, true, true, false),
            4038 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, false, true, false, true),
            4039 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, false, true, false, false),
            4040 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, false, false, true, true),
            4041 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, false, false, true, false),
            4042 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, false, false, false, true),
            4043 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, false, false, false, false),
            4044 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, true, true, true, true),
            4045 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, true, true, true, false),
            4046 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, true, true, false, true),
            4047 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, true, true, false, false),
            4048 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, true, false, true, true),
            4049 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, true, false, true, false),
            4050 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, true, false, false, true),
            4051 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, true, false, false, false),
            4052 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, false, true, true, true),
            4053 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, false, true, true, false),
            4054 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, false, true, false, true),
            4055 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, false, true, false, false),
            4056 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, false, false, true, true),
            4057 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, false, false, true, false),
            4058 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, false, false, false, true),
            4059 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, false, false, false, false),
            4060 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, true, true, true, true),
            4061 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, true, true, true, false),
            4062 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, true, true, false, true),
            4063 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, true, true, false, false),
            4064 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, true, false, true, true),
            4065 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, true, false, true, false),
            4066 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, true, false, false, true),
            4067 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, true, false, false, false),
            4068 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, false, true, true, true),
            4069 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, false, true, true, false),
            4070 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, false, true, false, true),
            4071 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, false, true, false, false),
            4072 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, false, false, true, true),
            4073 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, false, false, true, false),
            4074 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, false, false, false, true),
            4075 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, false, false, false, false),
            4076 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, true, true, true, true),
            4077 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, true, true, true, false),
            4078 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, true, true, false, true),
            4079 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, true, true, false, false),
            4080 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, true, false, true, true),
            4081 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, true, false, true, false),
            4082 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, true, false, false, true),
            4083 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, true, false, false, false),
            4084 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, false, true, true, true),
            4085 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, false, true, true, false),
            4086 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, false, true, false, true),
            4087 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, false, true, false, false),
            4088 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, false, false, true, true),
            4089 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, false, false, true, false),
            4090 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, false, false, false, true),
            4091 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, false, false, false, false),
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
