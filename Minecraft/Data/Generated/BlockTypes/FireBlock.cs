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
public record FireBlock(Identifier Identifier, int Age, bool East, bool North, bool South, bool Up, bool West) : IBlock, IAged, IFaceConnected {
    private static readonly BlockInfo Data = new("block.minecraft.fire", 0f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, null, BlockInfo.VanillaOnly, "minecraft:blocks/fire");
    private static readonly BlockStateInfo I0 = new(0f, 15, 0, PushReaction.Popped, 4, "wool", NoteBlockInstrument.Harp, true, false, false, false, false, false, true, false, false, false, false, false, false, false, true, true, false, true, [], null, BlockShapes.S530, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S531 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S532 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S533 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S534 };
    private static readonly BlockStateInfo I5 = I0 with { BlockShape = BlockShapes.S535 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S536 };
    private static readonly BlockStateInfo I7 = I0 with { BlockShape = BlockShapes.S537 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S538 };
    private static readonly BlockStateInfo I9 = I0 with { BlockShape = BlockShapes.S539 };
    private static readonly BlockStateInfo I10 = I0 with { BlockShape = BlockShapes.S540 };
    private static readonly BlockStateInfo I11 = I0 with { BlockShape = BlockShapes.S541 };
    private static readonly BlockStateInfo I12 = I0 with { BlockShape = BlockShapes.S542 };
    private static readonly BlockStateInfo I13 = I0 with { BlockShape = BlockShapes.S543 };
    private static readonly BlockStateInfo I14 = I0 with { BlockShape = BlockShapes.S544 };
    private static readonly BlockStateInfo I15 = I0 with { BlockShape = BlockShapes.S545 };
    private static readonly BlockStateInfo I16 = I0 with { BlockShape = BlockShapes.S546 };
    private static readonly BlockStateInfo I17 = I0 with { BlockShape = BlockShapes.S547 };
    private static readonly BlockStateInfo I18 = I0 with { BlockShape = BlockShapes.S548 };
    private static readonly BlockStateInfo I19 = I0 with { BlockShape = BlockShapes.S549 };
    private static readonly BlockStateInfo I20 = I0 with { BlockShape = BlockShapes.S550 };
    private static readonly BlockStateInfo I21 = I0 with { BlockShape = BlockShapes.S551 };
    private static readonly BlockStateInfo I22 = I0 with { BlockShape = BlockShapes.S552 };
    private static readonly BlockStateInfo I23 = I0 with { BlockShape = BlockShapes.S553 };
    private static readonly BlockStateInfo I24 = I0 with { BlockShape = BlockShapes.S554 };
    private static readonly BlockStateInfo I25 = I0 with { BlockShape = BlockShapes.S555 };
    private static readonly BlockStateInfo I26 = I0 with { BlockShape = BlockShapes.S556 };
    private static readonly BlockStateInfo I27 = I0 with { BlockShape = BlockShapes.S557 };
    private static readonly BlockStateInfo I28 = I0 with { BlockShape = BlockShapes.S558 };
    private static readonly BlockStateInfo I29 = I0 with { BlockShape = BlockShapes.S559 };
    private static readonly BlockStateInfo I30 = I0 with { BlockShape = BlockShapes.S560 };
    private static readonly BlockStateInfo I31 = I0 with { BlockShape = BlockShapes.S371 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31
    ];

    public BlockStateInfo StateInfo => States[StateId - 4931];

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

    public IBlock WithAge(int age) => this with { Age = age };

    public bool HasFace(BlockFace face) => face is BlockFace.PosY or BlockFace.NegZ or BlockFace.PosZ or BlockFace.NegX or BlockFace.PosX;

    public bool Connected(BlockFace face) => face switch {
        BlockFace.PosY => Up,
        BlockFace.NegZ => North,
        BlockFace.PosZ => South,
        BlockFace.NegX => West,
        BlockFace.PosX => East,
        _ => false
    };

    public IBlock WithConnection(BlockFace face, bool connected) => face switch {
        BlockFace.PosY => this with { Up = connected },
        BlockFace.NegZ => this with { North = connected },
        BlockFace.PosZ => this with { South = connected },
        BlockFace.NegX => this with { West = connected },
        BlockFace.PosX => this with { East = connected },
        _ => this
    };


    public uint StateId {
        get {
            return Age switch {
                0 => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 4931,
                                    false => 4932,
                                },
                                false => West switch {
                                    true => 4933,
                                    false => 4934,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 4935,
                                    false => 4936,
                                },
                                false => West switch {
                                    true => 4937,
                                    false => 4938,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 4939,
                                    false => 4940,
                                },
                                false => West switch {
                                    true => 4941,
                                    false => 4942,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 4943,
                                    false => 4944,
                                },
                                false => West switch {
                                    true => 4945,
                                    false => 4946,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 4947,
                                    false => 4948,
                                },
                                false => West switch {
                                    true => 4949,
                                    false => 4950,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 4951,
                                    false => 4952,
                                },
                                false => West switch {
                                    true => 4953,
                                    false => 4954,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 4955,
                                    false => 4956,
                                },
                                false => West switch {
                                    true => 4957,
                                    false => 4958,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 4959,
                                    false => 4960,
                                },
                                false => West switch {
                                    true => 4961,
                                    false => 4962,
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
                                    true => 4963,
                                    false => 4964,
                                },
                                false => West switch {
                                    true => 4965,
                                    false => 4966,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 4967,
                                    false => 4968,
                                },
                                false => West switch {
                                    true => 4969,
                                    false => 4970,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 4971,
                                    false => 4972,
                                },
                                false => West switch {
                                    true => 4973,
                                    false => 4974,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 4975,
                                    false => 4976,
                                },
                                false => West switch {
                                    true => 4977,
                                    false => 4978,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 4979,
                                    false => 4980,
                                },
                                false => West switch {
                                    true => 4981,
                                    false => 4982,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 4983,
                                    false => 4984,
                                },
                                false => West switch {
                                    true => 4985,
                                    false => 4986,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 4987,
                                    false => 4988,
                                },
                                false => West switch {
                                    true => 4989,
                                    false => 4990,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 4991,
                                    false => 4992,
                                },
                                false => West switch {
                                    true => 4993,
                                    false => 4994,
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
                                    true => 4995,
                                    false => 4996,
                                },
                                false => West switch {
                                    true => 4997,
                                    false => 4998,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 4999,
                                    false => 5000,
                                },
                                false => West switch {
                                    true => 5001,
                                    false => 5002,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5003,
                                    false => 5004,
                                },
                                false => West switch {
                                    true => 5005,
                                    false => 5006,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5007,
                                    false => 5008,
                                },
                                false => West switch {
                                    true => 5009,
                                    false => 5010,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5011,
                                    false => 5012,
                                },
                                false => West switch {
                                    true => 5013,
                                    false => 5014,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5015,
                                    false => 5016,
                                },
                                false => West switch {
                                    true => 5017,
                                    false => 5018,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5019,
                                    false => 5020,
                                },
                                false => West switch {
                                    true => 5021,
                                    false => 5022,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5023,
                                    false => 5024,
                                },
                                false => West switch {
                                    true => 5025,
                                    false => 5026,
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
                                    true => 5027,
                                    false => 5028,
                                },
                                false => West switch {
                                    true => 5029,
                                    false => 5030,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5031,
                                    false => 5032,
                                },
                                false => West switch {
                                    true => 5033,
                                    false => 5034,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5035,
                                    false => 5036,
                                },
                                false => West switch {
                                    true => 5037,
                                    false => 5038,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5039,
                                    false => 5040,
                                },
                                false => West switch {
                                    true => 5041,
                                    false => 5042,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5043,
                                    false => 5044,
                                },
                                false => West switch {
                                    true => 5045,
                                    false => 5046,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5047,
                                    false => 5048,
                                },
                                false => West switch {
                                    true => 5049,
                                    false => 5050,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5051,
                                    false => 5052,
                                },
                                false => West switch {
                                    true => 5053,
                                    false => 5054,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5055,
                                    false => 5056,
                                },
                                false => West switch {
                                    true => 5057,
                                    false => 5058,
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
                                    true => 5059,
                                    false => 5060,
                                },
                                false => West switch {
                                    true => 5061,
                                    false => 5062,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5063,
                                    false => 5064,
                                },
                                false => West switch {
                                    true => 5065,
                                    false => 5066,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5067,
                                    false => 5068,
                                },
                                false => West switch {
                                    true => 5069,
                                    false => 5070,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5071,
                                    false => 5072,
                                },
                                false => West switch {
                                    true => 5073,
                                    false => 5074,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5075,
                                    false => 5076,
                                },
                                false => West switch {
                                    true => 5077,
                                    false => 5078,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5079,
                                    false => 5080,
                                },
                                false => West switch {
                                    true => 5081,
                                    false => 5082,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5083,
                                    false => 5084,
                                },
                                false => West switch {
                                    true => 5085,
                                    false => 5086,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5087,
                                    false => 5088,
                                },
                                false => West switch {
                                    true => 5089,
                                    false => 5090,
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
                                    true => 5091,
                                    false => 5092,
                                },
                                false => West switch {
                                    true => 5093,
                                    false => 5094,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5095,
                                    false => 5096,
                                },
                                false => West switch {
                                    true => 5097,
                                    false => 5098,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5099,
                                    false => 5100,
                                },
                                false => West switch {
                                    true => 5101,
                                    false => 5102,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5103,
                                    false => 5104,
                                },
                                false => West switch {
                                    true => 5105,
                                    false => 5106,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5107,
                                    false => 5108,
                                },
                                false => West switch {
                                    true => 5109,
                                    false => 5110,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5111,
                                    false => 5112,
                                },
                                false => West switch {
                                    true => 5113,
                                    false => 5114,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5115,
                                    false => 5116,
                                },
                                false => West switch {
                                    true => 5117,
                                    false => 5118,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5119,
                                    false => 5120,
                                },
                                false => West switch {
                                    true => 5121,
                                    false => 5122,
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
                                    true => 5123,
                                    false => 5124,
                                },
                                false => West switch {
                                    true => 5125,
                                    false => 5126,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5127,
                                    false => 5128,
                                },
                                false => West switch {
                                    true => 5129,
                                    false => 5130,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5131,
                                    false => 5132,
                                },
                                false => West switch {
                                    true => 5133,
                                    false => 5134,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5135,
                                    false => 5136,
                                },
                                false => West switch {
                                    true => 5137,
                                    false => 5138,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5139,
                                    false => 5140,
                                },
                                false => West switch {
                                    true => 5141,
                                    false => 5142,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5143,
                                    false => 5144,
                                },
                                false => West switch {
                                    true => 5145,
                                    false => 5146,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5147,
                                    false => 5148,
                                },
                                false => West switch {
                                    true => 5149,
                                    false => 5150,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5151,
                                    false => 5152,
                                },
                                false => West switch {
                                    true => 5153,
                                    false => 5154,
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
                                    true => 5155,
                                    false => 5156,
                                },
                                false => West switch {
                                    true => 5157,
                                    false => 5158,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5159,
                                    false => 5160,
                                },
                                false => West switch {
                                    true => 5161,
                                    false => 5162,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5163,
                                    false => 5164,
                                },
                                false => West switch {
                                    true => 5165,
                                    false => 5166,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5167,
                                    false => 5168,
                                },
                                false => West switch {
                                    true => 5169,
                                    false => 5170,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5171,
                                    false => 5172,
                                },
                                false => West switch {
                                    true => 5173,
                                    false => 5174,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5175,
                                    false => 5176,
                                },
                                false => West switch {
                                    true => 5177,
                                    false => 5178,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5179,
                                    false => 5180,
                                },
                                false => West switch {
                                    true => 5181,
                                    false => 5182,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5183,
                                    false => 5184,
                                },
                                false => West switch {
                                    true => 5185,
                                    false => 5186,
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
                                    true => 5187,
                                    false => 5188,
                                },
                                false => West switch {
                                    true => 5189,
                                    false => 5190,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5191,
                                    false => 5192,
                                },
                                false => West switch {
                                    true => 5193,
                                    false => 5194,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5195,
                                    false => 5196,
                                },
                                false => West switch {
                                    true => 5197,
                                    false => 5198,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5199,
                                    false => 5200,
                                },
                                false => West switch {
                                    true => 5201,
                                    false => 5202,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5203,
                                    false => 5204,
                                },
                                false => West switch {
                                    true => 5205,
                                    false => 5206,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5207,
                                    false => 5208,
                                },
                                false => West switch {
                                    true => 5209,
                                    false => 5210,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5211,
                                    false => 5212,
                                },
                                false => West switch {
                                    true => 5213,
                                    false => 5214,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5215,
                                    false => 5216,
                                },
                                false => West switch {
                                    true => 5217,
                                    false => 5218,
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
                                    true => 5219,
                                    false => 5220,
                                },
                                false => West switch {
                                    true => 5221,
                                    false => 5222,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5223,
                                    false => 5224,
                                },
                                false => West switch {
                                    true => 5225,
                                    false => 5226,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5227,
                                    false => 5228,
                                },
                                false => West switch {
                                    true => 5229,
                                    false => 5230,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5231,
                                    false => 5232,
                                },
                                false => West switch {
                                    true => 5233,
                                    false => 5234,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5235,
                                    false => 5236,
                                },
                                false => West switch {
                                    true => 5237,
                                    false => 5238,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5239,
                                    false => 5240,
                                },
                                false => West switch {
                                    true => 5241,
                                    false => 5242,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5243,
                                    false => 5244,
                                },
                                false => West switch {
                                    true => 5245,
                                    false => 5246,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5247,
                                    false => 5248,
                                },
                                false => West switch {
                                    true => 5249,
                                    false => 5250,
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
                                    true => 5251,
                                    false => 5252,
                                },
                                false => West switch {
                                    true => 5253,
                                    false => 5254,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5255,
                                    false => 5256,
                                },
                                false => West switch {
                                    true => 5257,
                                    false => 5258,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5259,
                                    false => 5260,
                                },
                                false => West switch {
                                    true => 5261,
                                    false => 5262,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5263,
                                    false => 5264,
                                },
                                false => West switch {
                                    true => 5265,
                                    false => 5266,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5267,
                                    false => 5268,
                                },
                                false => West switch {
                                    true => 5269,
                                    false => 5270,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5271,
                                    false => 5272,
                                },
                                false => West switch {
                                    true => 5273,
                                    false => 5274,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5275,
                                    false => 5276,
                                },
                                false => West switch {
                                    true => 5277,
                                    false => 5278,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5279,
                                    false => 5280,
                                },
                                false => West switch {
                                    true => 5281,
                                    false => 5282,
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
                                    true => 5283,
                                    false => 5284,
                                },
                                false => West switch {
                                    true => 5285,
                                    false => 5286,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5287,
                                    false => 5288,
                                },
                                false => West switch {
                                    true => 5289,
                                    false => 5290,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5291,
                                    false => 5292,
                                },
                                false => West switch {
                                    true => 5293,
                                    false => 5294,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5295,
                                    false => 5296,
                                },
                                false => West switch {
                                    true => 5297,
                                    false => 5298,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5299,
                                    false => 5300,
                                },
                                false => West switch {
                                    true => 5301,
                                    false => 5302,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5303,
                                    false => 5304,
                                },
                                false => West switch {
                                    true => 5305,
                                    false => 5306,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5307,
                                    false => 5308,
                                },
                                false => West switch {
                                    true => 5309,
                                    false => 5310,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5311,
                                    false => 5312,
                                },
                                false => West switch {
                                    true => 5313,
                                    false => 5314,
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
                                    true => 5315,
                                    false => 5316,
                                },
                                false => West switch {
                                    true => 5317,
                                    false => 5318,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5319,
                                    false => 5320,
                                },
                                false => West switch {
                                    true => 5321,
                                    false => 5322,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5323,
                                    false => 5324,
                                },
                                false => West switch {
                                    true => 5325,
                                    false => 5326,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5327,
                                    false => 5328,
                                },
                                false => West switch {
                                    true => 5329,
                                    false => 5330,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5331,
                                    false => 5332,
                                },
                                false => West switch {
                                    true => 5333,
                                    false => 5334,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5335,
                                    false => 5336,
                                },
                                false => West switch {
                                    true => 5337,
                                    false => 5338,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5339,
                                    false => 5340,
                                },
                                false => West switch {
                                    true => 5341,
                                    false => 5342,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5343,
                                    false => 5344,
                                },
                                false => West switch {
                                    true => 5345,
                                    false => 5346,
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
                                    true => 5347,
                                    false => 5348,
                                },
                                false => West switch {
                                    true => 5349,
                                    false => 5350,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5351,
                                    false => 5352,
                                },
                                false => West switch {
                                    true => 5353,
                                    false => 5354,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5355,
                                    false => 5356,
                                },
                                false => West switch {
                                    true => 5357,
                                    false => 5358,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5359,
                                    false => 5360,
                                },
                                false => West switch {
                                    true => 5361,
                                    false => 5362,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5363,
                                    false => 5364,
                                },
                                false => West switch {
                                    true => 5365,
                                    false => 5366,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5367,
                                    false => 5368,
                                },
                                false => West switch {
                                    true => 5369,
                                    false => 5370,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5371,
                                    false => 5372,
                                },
                                false => West switch {
                                    true => 5373,
                                    false => 5374,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5375,
                                    false => 5376,
                                },
                                false => West switch {
                                    true => 5377,
                                    false => 5378,
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
                                    true => 5379,
                                    false => 5380,
                                },
                                false => West switch {
                                    true => 5381,
                                    false => 5382,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5383,
                                    false => 5384,
                                },
                                false => West switch {
                                    true => 5385,
                                    false => 5386,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5387,
                                    false => 5388,
                                },
                                false => West switch {
                                    true => 5389,
                                    false => 5390,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5391,
                                    false => 5392,
                                },
                                false => West switch {
                                    true => 5393,
                                    false => 5394,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5395,
                                    false => 5396,
                                },
                                false => West switch {
                                    true => 5397,
                                    false => 5398,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5399,
                                    false => 5400,
                                },
                                false => West switch {
                                    true => 5401,
                                    false => 5402,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5403,
                                    false => 5404,
                                },
                                false => West switch {
                                    true => 5405,
                                    false => 5406,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5407,
                                    false => 5408,
                                },
                                false => West switch {
                                    true => 5409,
                                    false => 5410,
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
                                    true => 5411,
                                    false => 5412,
                                },
                                false => West switch {
                                    true => 5413,
                                    false => 5414,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5415,
                                    false => 5416,
                                },
                                false => West switch {
                                    true => 5417,
                                    false => 5418,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5419,
                                    false => 5420,
                                },
                                false => West switch {
                                    true => 5421,
                                    false => 5422,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5423,
                                    false => 5424,
                                },
                                false => West switch {
                                    true => 5425,
                                    false => 5426,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5427,
                                    false => 5428,
                                },
                                false => West switch {
                                    true => 5429,
                                    false => 5430,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5431,
                                    false => 5432,
                                },
                                false => West switch {
                                    true => 5433,
                                    false => 5434,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 5435,
                                    false => 5436,
                                },
                                false => West switch {
                                    true => 5437,
                                    false => 5438,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 5439,
                                    false => 5440,
                                },
                                false => West switch {
                                    true => 5441,
                                    false => 5442,
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
            4931 => new FireBlock(Identifier, 0, true, true, true, true, true),
            4932 => new FireBlock(Identifier, 0, true, true, true, true, false),
            4933 => new FireBlock(Identifier, 0, true, true, true, false, true),
            4934 => new FireBlock(Identifier, 0, true, true, true, false, false),
            4935 => new FireBlock(Identifier, 0, true, true, false, true, true),
            4936 => new FireBlock(Identifier, 0, true, true, false, true, false),
            4937 => new FireBlock(Identifier, 0, true, true, false, false, true),
            4938 => new FireBlock(Identifier, 0, true, true, false, false, false),
            4939 => new FireBlock(Identifier, 0, true, false, true, true, true),
            4940 => new FireBlock(Identifier, 0, true, false, true, true, false),
            4941 => new FireBlock(Identifier, 0, true, false, true, false, true),
            4942 => new FireBlock(Identifier, 0, true, false, true, false, false),
            4943 => new FireBlock(Identifier, 0, true, false, false, true, true),
            4944 => new FireBlock(Identifier, 0, true, false, false, true, false),
            4945 => new FireBlock(Identifier, 0, true, false, false, false, true),
            4946 => new FireBlock(Identifier, 0, true, false, false, false, false),
            4947 => new FireBlock(Identifier, 0, false, true, true, true, true),
            4948 => new FireBlock(Identifier, 0, false, true, true, true, false),
            4949 => new FireBlock(Identifier, 0, false, true, true, false, true),
            4950 => new FireBlock(Identifier, 0, false, true, true, false, false),
            4951 => new FireBlock(Identifier, 0, false, true, false, true, true),
            4952 => new FireBlock(Identifier, 0, false, true, false, true, false),
            4953 => new FireBlock(Identifier, 0, false, true, false, false, true),
            4954 => new FireBlock(Identifier, 0, false, true, false, false, false),
            4955 => new FireBlock(Identifier, 0, false, false, true, true, true),
            4956 => new FireBlock(Identifier, 0, false, false, true, true, false),
            4957 => new FireBlock(Identifier, 0, false, false, true, false, true),
            4958 => new FireBlock(Identifier, 0, false, false, true, false, false),
            4959 => new FireBlock(Identifier, 0, false, false, false, true, true),
            4960 => new FireBlock(Identifier, 0, false, false, false, true, false),
            4961 => new FireBlock(Identifier, 0, false, false, false, false, true),
            4962 => new FireBlock(Identifier, 0, false, false, false, false, false),
            4963 => new FireBlock(Identifier, 1, true, true, true, true, true),
            4964 => new FireBlock(Identifier, 1, true, true, true, true, false),
            4965 => new FireBlock(Identifier, 1, true, true, true, false, true),
            4966 => new FireBlock(Identifier, 1, true, true, true, false, false),
            4967 => new FireBlock(Identifier, 1, true, true, false, true, true),
            4968 => new FireBlock(Identifier, 1, true, true, false, true, false),
            4969 => new FireBlock(Identifier, 1, true, true, false, false, true),
            4970 => new FireBlock(Identifier, 1, true, true, false, false, false),
            4971 => new FireBlock(Identifier, 1, true, false, true, true, true),
            4972 => new FireBlock(Identifier, 1, true, false, true, true, false),
            4973 => new FireBlock(Identifier, 1, true, false, true, false, true),
            4974 => new FireBlock(Identifier, 1, true, false, true, false, false),
            4975 => new FireBlock(Identifier, 1, true, false, false, true, true),
            4976 => new FireBlock(Identifier, 1, true, false, false, true, false),
            4977 => new FireBlock(Identifier, 1, true, false, false, false, true),
            4978 => new FireBlock(Identifier, 1, true, false, false, false, false),
            4979 => new FireBlock(Identifier, 1, false, true, true, true, true),
            4980 => new FireBlock(Identifier, 1, false, true, true, true, false),
            4981 => new FireBlock(Identifier, 1, false, true, true, false, true),
            4982 => new FireBlock(Identifier, 1, false, true, true, false, false),
            4983 => new FireBlock(Identifier, 1, false, true, false, true, true),
            4984 => new FireBlock(Identifier, 1, false, true, false, true, false),
            4985 => new FireBlock(Identifier, 1, false, true, false, false, true),
            4986 => new FireBlock(Identifier, 1, false, true, false, false, false),
            4987 => new FireBlock(Identifier, 1, false, false, true, true, true),
            4988 => new FireBlock(Identifier, 1, false, false, true, true, false),
            4989 => new FireBlock(Identifier, 1, false, false, true, false, true),
            4990 => new FireBlock(Identifier, 1, false, false, true, false, false),
            4991 => new FireBlock(Identifier, 1, false, false, false, true, true),
            4992 => new FireBlock(Identifier, 1, false, false, false, true, false),
            4993 => new FireBlock(Identifier, 1, false, false, false, false, true),
            4994 => new FireBlock(Identifier, 1, false, false, false, false, false),
            4995 => new FireBlock(Identifier, 2, true, true, true, true, true),
            4996 => new FireBlock(Identifier, 2, true, true, true, true, false),
            4997 => new FireBlock(Identifier, 2, true, true, true, false, true),
            4998 => new FireBlock(Identifier, 2, true, true, true, false, false),
            4999 => new FireBlock(Identifier, 2, true, true, false, true, true),
            5000 => new FireBlock(Identifier, 2, true, true, false, true, false),
            5001 => new FireBlock(Identifier, 2, true, true, false, false, true),
            5002 => new FireBlock(Identifier, 2, true, true, false, false, false),
            5003 => new FireBlock(Identifier, 2, true, false, true, true, true),
            5004 => new FireBlock(Identifier, 2, true, false, true, true, false),
            5005 => new FireBlock(Identifier, 2, true, false, true, false, true),
            5006 => new FireBlock(Identifier, 2, true, false, true, false, false),
            5007 => new FireBlock(Identifier, 2, true, false, false, true, true),
            5008 => new FireBlock(Identifier, 2, true, false, false, true, false),
            5009 => new FireBlock(Identifier, 2, true, false, false, false, true),
            5010 => new FireBlock(Identifier, 2, true, false, false, false, false),
            5011 => new FireBlock(Identifier, 2, false, true, true, true, true),
            5012 => new FireBlock(Identifier, 2, false, true, true, true, false),
            5013 => new FireBlock(Identifier, 2, false, true, true, false, true),
            5014 => new FireBlock(Identifier, 2, false, true, true, false, false),
            5015 => new FireBlock(Identifier, 2, false, true, false, true, true),
            5016 => new FireBlock(Identifier, 2, false, true, false, true, false),
            5017 => new FireBlock(Identifier, 2, false, true, false, false, true),
            5018 => new FireBlock(Identifier, 2, false, true, false, false, false),
            5019 => new FireBlock(Identifier, 2, false, false, true, true, true),
            5020 => new FireBlock(Identifier, 2, false, false, true, true, false),
            5021 => new FireBlock(Identifier, 2, false, false, true, false, true),
            5022 => new FireBlock(Identifier, 2, false, false, true, false, false),
            5023 => new FireBlock(Identifier, 2, false, false, false, true, true),
            5024 => new FireBlock(Identifier, 2, false, false, false, true, false),
            5025 => new FireBlock(Identifier, 2, false, false, false, false, true),
            5026 => new FireBlock(Identifier, 2, false, false, false, false, false),
            5027 => new FireBlock(Identifier, 3, true, true, true, true, true),
            5028 => new FireBlock(Identifier, 3, true, true, true, true, false),
            5029 => new FireBlock(Identifier, 3, true, true, true, false, true),
            5030 => new FireBlock(Identifier, 3, true, true, true, false, false),
            5031 => new FireBlock(Identifier, 3, true, true, false, true, true),
            5032 => new FireBlock(Identifier, 3, true, true, false, true, false),
            5033 => new FireBlock(Identifier, 3, true, true, false, false, true),
            5034 => new FireBlock(Identifier, 3, true, true, false, false, false),
            5035 => new FireBlock(Identifier, 3, true, false, true, true, true),
            5036 => new FireBlock(Identifier, 3, true, false, true, true, false),
            5037 => new FireBlock(Identifier, 3, true, false, true, false, true),
            5038 => new FireBlock(Identifier, 3, true, false, true, false, false),
            5039 => new FireBlock(Identifier, 3, true, false, false, true, true),
            5040 => new FireBlock(Identifier, 3, true, false, false, true, false),
            5041 => new FireBlock(Identifier, 3, true, false, false, false, true),
            5042 => new FireBlock(Identifier, 3, true, false, false, false, false),
            5043 => new FireBlock(Identifier, 3, false, true, true, true, true),
            5044 => new FireBlock(Identifier, 3, false, true, true, true, false),
            5045 => new FireBlock(Identifier, 3, false, true, true, false, true),
            5046 => new FireBlock(Identifier, 3, false, true, true, false, false),
            5047 => new FireBlock(Identifier, 3, false, true, false, true, true),
            5048 => new FireBlock(Identifier, 3, false, true, false, true, false),
            5049 => new FireBlock(Identifier, 3, false, true, false, false, true),
            5050 => new FireBlock(Identifier, 3, false, true, false, false, false),
            5051 => new FireBlock(Identifier, 3, false, false, true, true, true),
            5052 => new FireBlock(Identifier, 3, false, false, true, true, false),
            5053 => new FireBlock(Identifier, 3, false, false, true, false, true),
            5054 => new FireBlock(Identifier, 3, false, false, true, false, false),
            5055 => new FireBlock(Identifier, 3, false, false, false, true, true),
            5056 => new FireBlock(Identifier, 3, false, false, false, true, false),
            5057 => new FireBlock(Identifier, 3, false, false, false, false, true),
            5058 => new FireBlock(Identifier, 3, false, false, false, false, false),
            5059 => new FireBlock(Identifier, 4, true, true, true, true, true),
            5060 => new FireBlock(Identifier, 4, true, true, true, true, false),
            5061 => new FireBlock(Identifier, 4, true, true, true, false, true),
            5062 => new FireBlock(Identifier, 4, true, true, true, false, false),
            5063 => new FireBlock(Identifier, 4, true, true, false, true, true),
            5064 => new FireBlock(Identifier, 4, true, true, false, true, false),
            5065 => new FireBlock(Identifier, 4, true, true, false, false, true),
            5066 => new FireBlock(Identifier, 4, true, true, false, false, false),
            5067 => new FireBlock(Identifier, 4, true, false, true, true, true),
            5068 => new FireBlock(Identifier, 4, true, false, true, true, false),
            5069 => new FireBlock(Identifier, 4, true, false, true, false, true),
            5070 => new FireBlock(Identifier, 4, true, false, true, false, false),
            5071 => new FireBlock(Identifier, 4, true, false, false, true, true),
            5072 => new FireBlock(Identifier, 4, true, false, false, true, false),
            5073 => new FireBlock(Identifier, 4, true, false, false, false, true),
            5074 => new FireBlock(Identifier, 4, true, false, false, false, false),
            5075 => new FireBlock(Identifier, 4, false, true, true, true, true),
            5076 => new FireBlock(Identifier, 4, false, true, true, true, false),
            5077 => new FireBlock(Identifier, 4, false, true, true, false, true),
            5078 => new FireBlock(Identifier, 4, false, true, true, false, false),
            5079 => new FireBlock(Identifier, 4, false, true, false, true, true),
            5080 => new FireBlock(Identifier, 4, false, true, false, true, false),
            5081 => new FireBlock(Identifier, 4, false, true, false, false, true),
            5082 => new FireBlock(Identifier, 4, false, true, false, false, false),
            5083 => new FireBlock(Identifier, 4, false, false, true, true, true),
            5084 => new FireBlock(Identifier, 4, false, false, true, true, false),
            5085 => new FireBlock(Identifier, 4, false, false, true, false, true),
            5086 => new FireBlock(Identifier, 4, false, false, true, false, false),
            5087 => new FireBlock(Identifier, 4, false, false, false, true, true),
            5088 => new FireBlock(Identifier, 4, false, false, false, true, false),
            5089 => new FireBlock(Identifier, 4, false, false, false, false, true),
            5090 => new FireBlock(Identifier, 4, false, false, false, false, false),
            5091 => new FireBlock(Identifier, 5, true, true, true, true, true),
            5092 => new FireBlock(Identifier, 5, true, true, true, true, false),
            5093 => new FireBlock(Identifier, 5, true, true, true, false, true),
            5094 => new FireBlock(Identifier, 5, true, true, true, false, false),
            5095 => new FireBlock(Identifier, 5, true, true, false, true, true),
            5096 => new FireBlock(Identifier, 5, true, true, false, true, false),
            5097 => new FireBlock(Identifier, 5, true, true, false, false, true),
            5098 => new FireBlock(Identifier, 5, true, true, false, false, false),
            5099 => new FireBlock(Identifier, 5, true, false, true, true, true),
            5100 => new FireBlock(Identifier, 5, true, false, true, true, false),
            5101 => new FireBlock(Identifier, 5, true, false, true, false, true),
            5102 => new FireBlock(Identifier, 5, true, false, true, false, false),
            5103 => new FireBlock(Identifier, 5, true, false, false, true, true),
            5104 => new FireBlock(Identifier, 5, true, false, false, true, false),
            5105 => new FireBlock(Identifier, 5, true, false, false, false, true),
            5106 => new FireBlock(Identifier, 5, true, false, false, false, false),
            5107 => new FireBlock(Identifier, 5, false, true, true, true, true),
            5108 => new FireBlock(Identifier, 5, false, true, true, true, false),
            5109 => new FireBlock(Identifier, 5, false, true, true, false, true),
            5110 => new FireBlock(Identifier, 5, false, true, true, false, false),
            5111 => new FireBlock(Identifier, 5, false, true, false, true, true),
            5112 => new FireBlock(Identifier, 5, false, true, false, true, false),
            5113 => new FireBlock(Identifier, 5, false, true, false, false, true),
            5114 => new FireBlock(Identifier, 5, false, true, false, false, false),
            5115 => new FireBlock(Identifier, 5, false, false, true, true, true),
            5116 => new FireBlock(Identifier, 5, false, false, true, true, false),
            5117 => new FireBlock(Identifier, 5, false, false, true, false, true),
            5118 => new FireBlock(Identifier, 5, false, false, true, false, false),
            5119 => new FireBlock(Identifier, 5, false, false, false, true, true),
            5120 => new FireBlock(Identifier, 5, false, false, false, true, false),
            5121 => new FireBlock(Identifier, 5, false, false, false, false, true),
            5122 => new FireBlock(Identifier, 5, false, false, false, false, false),
            5123 => new FireBlock(Identifier, 6, true, true, true, true, true),
            5124 => new FireBlock(Identifier, 6, true, true, true, true, false),
            5125 => new FireBlock(Identifier, 6, true, true, true, false, true),
            5126 => new FireBlock(Identifier, 6, true, true, true, false, false),
            5127 => new FireBlock(Identifier, 6, true, true, false, true, true),
            5128 => new FireBlock(Identifier, 6, true, true, false, true, false),
            5129 => new FireBlock(Identifier, 6, true, true, false, false, true),
            5130 => new FireBlock(Identifier, 6, true, true, false, false, false),
            5131 => new FireBlock(Identifier, 6, true, false, true, true, true),
            5132 => new FireBlock(Identifier, 6, true, false, true, true, false),
            5133 => new FireBlock(Identifier, 6, true, false, true, false, true),
            5134 => new FireBlock(Identifier, 6, true, false, true, false, false),
            5135 => new FireBlock(Identifier, 6, true, false, false, true, true),
            5136 => new FireBlock(Identifier, 6, true, false, false, true, false),
            5137 => new FireBlock(Identifier, 6, true, false, false, false, true),
            5138 => new FireBlock(Identifier, 6, true, false, false, false, false),
            5139 => new FireBlock(Identifier, 6, false, true, true, true, true),
            5140 => new FireBlock(Identifier, 6, false, true, true, true, false),
            5141 => new FireBlock(Identifier, 6, false, true, true, false, true),
            5142 => new FireBlock(Identifier, 6, false, true, true, false, false),
            5143 => new FireBlock(Identifier, 6, false, true, false, true, true),
            5144 => new FireBlock(Identifier, 6, false, true, false, true, false),
            5145 => new FireBlock(Identifier, 6, false, true, false, false, true),
            5146 => new FireBlock(Identifier, 6, false, true, false, false, false),
            5147 => new FireBlock(Identifier, 6, false, false, true, true, true),
            5148 => new FireBlock(Identifier, 6, false, false, true, true, false),
            5149 => new FireBlock(Identifier, 6, false, false, true, false, true),
            5150 => new FireBlock(Identifier, 6, false, false, true, false, false),
            5151 => new FireBlock(Identifier, 6, false, false, false, true, true),
            5152 => new FireBlock(Identifier, 6, false, false, false, true, false),
            5153 => new FireBlock(Identifier, 6, false, false, false, false, true),
            5154 => new FireBlock(Identifier, 6, false, false, false, false, false),
            5155 => new FireBlock(Identifier, 7, true, true, true, true, true),
            5156 => new FireBlock(Identifier, 7, true, true, true, true, false),
            5157 => new FireBlock(Identifier, 7, true, true, true, false, true),
            5158 => new FireBlock(Identifier, 7, true, true, true, false, false),
            5159 => new FireBlock(Identifier, 7, true, true, false, true, true),
            5160 => new FireBlock(Identifier, 7, true, true, false, true, false),
            5161 => new FireBlock(Identifier, 7, true, true, false, false, true),
            5162 => new FireBlock(Identifier, 7, true, true, false, false, false),
            5163 => new FireBlock(Identifier, 7, true, false, true, true, true),
            5164 => new FireBlock(Identifier, 7, true, false, true, true, false),
            5165 => new FireBlock(Identifier, 7, true, false, true, false, true),
            5166 => new FireBlock(Identifier, 7, true, false, true, false, false),
            5167 => new FireBlock(Identifier, 7, true, false, false, true, true),
            5168 => new FireBlock(Identifier, 7, true, false, false, true, false),
            5169 => new FireBlock(Identifier, 7, true, false, false, false, true),
            5170 => new FireBlock(Identifier, 7, true, false, false, false, false),
            5171 => new FireBlock(Identifier, 7, false, true, true, true, true),
            5172 => new FireBlock(Identifier, 7, false, true, true, true, false),
            5173 => new FireBlock(Identifier, 7, false, true, true, false, true),
            5174 => new FireBlock(Identifier, 7, false, true, true, false, false),
            5175 => new FireBlock(Identifier, 7, false, true, false, true, true),
            5176 => new FireBlock(Identifier, 7, false, true, false, true, false),
            5177 => new FireBlock(Identifier, 7, false, true, false, false, true),
            5178 => new FireBlock(Identifier, 7, false, true, false, false, false),
            5179 => new FireBlock(Identifier, 7, false, false, true, true, true),
            5180 => new FireBlock(Identifier, 7, false, false, true, true, false),
            5181 => new FireBlock(Identifier, 7, false, false, true, false, true),
            5182 => new FireBlock(Identifier, 7, false, false, true, false, false),
            5183 => new FireBlock(Identifier, 7, false, false, false, true, true),
            5184 => new FireBlock(Identifier, 7, false, false, false, true, false),
            5185 => new FireBlock(Identifier, 7, false, false, false, false, true),
            5186 => new FireBlock(Identifier, 7, false, false, false, false, false),
            5187 => new FireBlock(Identifier, 8, true, true, true, true, true),
            5188 => new FireBlock(Identifier, 8, true, true, true, true, false),
            5189 => new FireBlock(Identifier, 8, true, true, true, false, true),
            5190 => new FireBlock(Identifier, 8, true, true, true, false, false),
            5191 => new FireBlock(Identifier, 8, true, true, false, true, true),
            5192 => new FireBlock(Identifier, 8, true, true, false, true, false),
            5193 => new FireBlock(Identifier, 8, true, true, false, false, true),
            5194 => new FireBlock(Identifier, 8, true, true, false, false, false),
            5195 => new FireBlock(Identifier, 8, true, false, true, true, true),
            5196 => new FireBlock(Identifier, 8, true, false, true, true, false),
            5197 => new FireBlock(Identifier, 8, true, false, true, false, true),
            5198 => new FireBlock(Identifier, 8, true, false, true, false, false),
            5199 => new FireBlock(Identifier, 8, true, false, false, true, true),
            5200 => new FireBlock(Identifier, 8, true, false, false, true, false),
            5201 => new FireBlock(Identifier, 8, true, false, false, false, true),
            5202 => new FireBlock(Identifier, 8, true, false, false, false, false),
            5203 => new FireBlock(Identifier, 8, false, true, true, true, true),
            5204 => new FireBlock(Identifier, 8, false, true, true, true, false),
            5205 => new FireBlock(Identifier, 8, false, true, true, false, true),
            5206 => new FireBlock(Identifier, 8, false, true, true, false, false),
            5207 => new FireBlock(Identifier, 8, false, true, false, true, true),
            5208 => new FireBlock(Identifier, 8, false, true, false, true, false),
            5209 => new FireBlock(Identifier, 8, false, true, false, false, true),
            5210 => new FireBlock(Identifier, 8, false, true, false, false, false),
            5211 => new FireBlock(Identifier, 8, false, false, true, true, true),
            5212 => new FireBlock(Identifier, 8, false, false, true, true, false),
            5213 => new FireBlock(Identifier, 8, false, false, true, false, true),
            5214 => new FireBlock(Identifier, 8, false, false, true, false, false),
            5215 => new FireBlock(Identifier, 8, false, false, false, true, true),
            5216 => new FireBlock(Identifier, 8, false, false, false, true, false),
            5217 => new FireBlock(Identifier, 8, false, false, false, false, true),
            5218 => new FireBlock(Identifier, 8, false, false, false, false, false),
            5219 => new FireBlock(Identifier, 9, true, true, true, true, true),
            5220 => new FireBlock(Identifier, 9, true, true, true, true, false),
            5221 => new FireBlock(Identifier, 9, true, true, true, false, true),
            5222 => new FireBlock(Identifier, 9, true, true, true, false, false),
            5223 => new FireBlock(Identifier, 9, true, true, false, true, true),
            5224 => new FireBlock(Identifier, 9, true, true, false, true, false),
            5225 => new FireBlock(Identifier, 9, true, true, false, false, true),
            5226 => new FireBlock(Identifier, 9, true, true, false, false, false),
            5227 => new FireBlock(Identifier, 9, true, false, true, true, true),
            5228 => new FireBlock(Identifier, 9, true, false, true, true, false),
            5229 => new FireBlock(Identifier, 9, true, false, true, false, true),
            5230 => new FireBlock(Identifier, 9, true, false, true, false, false),
            5231 => new FireBlock(Identifier, 9, true, false, false, true, true),
            5232 => new FireBlock(Identifier, 9, true, false, false, true, false),
            5233 => new FireBlock(Identifier, 9, true, false, false, false, true),
            5234 => new FireBlock(Identifier, 9, true, false, false, false, false),
            5235 => new FireBlock(Identifier, 9, false, true, true, true, true),
            5236 => new FireBlock(Identifier, 9, false, true, true, true, false),
            5237 => new FireBlock(Identifier, 9, false, true, true, false, true),
            5238 => new FireBlock(Identifier, 9, false, true, true, false, false),
            5239 => new FireBlock(Identifier, 9, false, true, false, true, true),
            5240 => new FireBlock(Identifier, 9, false, true, false, true, false),
            5241 => new FireBlock(Identifier, 9, false, true, false, false, true),
            5242 => new FireBlock(Identifier, 9, false, true, false, false, false),
            5243 => new FireBlock(Identifier, 9, false, false, true, true, true),
            5244 => new FireBlock(Identifier, 9, false, false, true, true, false),
            5245 => new FireBlock(Identifier, 9, false, false, true, false, true),
            5246 => new FireBlock(Identifier, 9, false, false, true, false, false),
            5247 => new FireBlock(Identifier, 9, false, false, false, true, true),
            5248 => new FireBlock(Identifier, 9, false, false, false, true, false),
            5249 => new FireBlock(Identifier, 9, false, false, false, false, true),
            5250 => new FireBlock(Identifier, 9, false, false, false, false, false),
            5251 => new FireBlock(Identifier, 10, true, true, true, true, true),
            5252 => new FireBlock(Identifier, 10, true, true, true, true, false),
            5253 => new FireBlock(Identifier, 10, true, true, true, false, true),
            5254 => new FireBlock(Identifier, 10, true, true, true, false, false),
            5255 => new FireBlock(Identifier, 10, true, true, false, true, true),
            5256 => new FireBlock(Identifier, 10, true, true, false, true, false),
            5257 => new FireBlock(Identifier, 10, true, true, false, false, true),
            5258 => new FireBlock(Identifier, 10, true, true, false, false, false),
            5259 => new FireBlock(Identifier, 10, true, false, true, true, true),
            5260 => new FireBlock(Identifier, 10, true, false, true, true, false),
            5261 => new FireBlock(Identifier, 10, true, false, true, false, true),
            5262 => new FireBlock(Identifier, 10, true, false, true, false, false),
            5263 => new FireBlock(Identifier, 10, true, false, false, true, true),
            5264 => new FireBlock(Identifier, 10, true, false, false, true, false),
            5265 => new FireBlock(Identifier, 10, true, false, false, false, true),
            5266 => new FireBlock(Identifier, 10, true, false, false, false, false),
            5267 => new FireBlock(Identifier, 10, false, true, true, true, true),
            5268 => new FireBlock(Identifier, 10, false, true, true, true, false),
            5269 => new FireBlock(Identifier, 10, false, true, true, false, true),
            5270 => new FireBlock(Identifier, 10, false, true, true, false, false),
            5271 => new FireBlock(Identifier, 10, false, true, false, true, true),
            5272 => new FireBlock(Identifier, 10, false, true, false, true, false),
            5273 => new FireBlock(Identifier, 10, false, true, false, false, true),
            5274 => new FireBlock(Identifier, 10, false, true, false, false, false),
            5275 => new FireBlock(Identifier, 10, false, false, true, true, true),
            5276 => new FireBlock(Identifier, 10, false, false, true, true, false),
            5277 => new FireBlock(Identifier, 10, false, false, true, false, true),
            5278 => new FireBlock(Identifier, 10, false, false, true, false, false),
            5279 => new FireBlock(Identifier, 10, false, false, false, true, true),
            5280 => new FireBlock(Identifier, 10, false, false, false, true, false),
            5281 => new FireBlock(Identifier, 10, false, false, false, false, true),
            5282 => new FireBlock(Identifier, 10, false, false, false, false, false),
            5283 => new FireBlock(Identifier, 11, true, true, true, true, true),
            5284 => new FireBlock(Identifier, 11, true, true, true, true, false),
            5285 => new FireBlock(Identifier, 11, true, true, true, false, true),
            5286 => new FireBlock(Identifier, 11, true, true, true, false, false),
            5287 => new FireBlock(Identifier, 11, true, true, false, true, true),
            5288 => new FireBlock(Identifier, 11, true, true, false, true, false),
            5289 => new FireBlock(Identifier, 11, true, true, false, false, true),
            5290 => new FireBlock(Identifier, 11, true, true, false, false, false),
            5291 => new FireBlock(Identifier, 11, true, false, true, true, true),
            5292 => new FireBlock(Identifier, 11, true, false, true, true, false),
            5293 => new FireBlock(Identifier, 11, true, false, true, false, true),
            5294 => new FireBlock(Identifier, 11, true, false, true, false, false),
            5295 => new FireBlock(Identifier, 11, true, false, false, true, true),
            5296 => new FireBlock(Identifier, 11, true, false, false, true, false),
            5297 => new FireBlock(Identifier, 11, true, false, false, false, true),
            5298 => new FireBlock(Identifier, 11, true, false, false, false, false),
            5299 => new FireBlock(Identifier, 11, false, true, true, true, true),
            5300 => new FireBlock(Identifier, 11, false, true, true, true, false),
            5301 => new FireBlock(Identifier, 11, false, true, true, false, true),
            5302 => new FireBlock(Identifier, 11, false, true, true, false, false),
            5303 => new FireBlock(Identifier, 11, false, true, false, true, true),
            5304 => new FireBlock(Identifier, 11, false, true, false, true, false),
            5305 => new FireBlock(Identifier, 11, false, true, false, false, true),
            5306 => new FireBlock(Identifier, 11, false, true, false, false, false),
            5307 => new FireBlock(Identifier, 11, false, false, true, true, true),
            5308 => new FireBlock(Identifier, 11, false, false, true, true, false),
            5309 => new FireBlock(Identifier, 11, false, false, true, false, true),
            5310 => new FireBlock(Identifier, 11, false, false, true, false, false),
            5311 => new FireBlock(Identifier, 11, false, false, false, true, true),
            5312 => new FireBlock(Identifier, 11, false, false, false, true, false),
            5313 => new FireBlock(Identifier, 11, false, false, false, false, true),
            5314 => new FireBlock(Identifier, 11, false, false, false, false, false),
            5315 => new FireBlock(Identifier, 12, true, true, true, true, true),
            5316 => new FireBlock(Identifier, 12, true, true, true, true, false),
            5317 => new FireBlock(Identifier, 12, true, true, true, false, true),
            5318 => new FireBlock(Identifier, 12, true, true, true, false, false),
            5319 => new FireBlock(Identifier, 12, true, true, false, true, true),
            5320 => new FireBlock(Identifier, 12, true, true, false, true, false),
            5321 => new FireBlock(Identifier, 12, true, true, false, false, true),
            5322 => new FireBlock(Identifier, 12, true, true, false, false, false),
            5323 => new FireBlock(Identifier, 12, true, false, true, true, true),
            5324 => new FireBlock(Identifier, 12, true, false, true, true, false),
            5325 => new FireBlock(Identifier, 12, true, false, true, false, true),
            5326 => new FireBlock(Identifier, 12, true, false, true, false, false),
            5327 => new FireBlock(Identifier, 12, true, false, false, true, true),
            5328 => new FireBlock(Identifier, 12, true, false, false, true, false),
            5329 => new FireBlock(Identifier, 12, true, false, false, false, true),
            5330 => new FireBlock(Identifier, 12, true, false, false, false, false),
            5331 => new FireBlock(Identifier, 12, false, true, true, true, true),
            5332 => new FireBlock(Identifier, 12, false, true, true, true, false),
            5333 => new FireBlock(Identifier, 12, false, true, true, false, true),
            5334 => new FireBlock(Identifier, 12, false, true, true, false, false),
            5335 => new FireBlock(Identifier, 12, false, true, false, true, true),
            5336 => new FireBlock(Identifier, 12, false, true, false, true, false),
            5337 => new FireBlock(Identifier, 12, false, true, false, false, true),
            5338 => new FireBlock(Identifier, 12, false, true, false, false, false),
            5339 => new FireBlock(Identifier, 12, false, false, true, true, true),
            5340 => new FireBlock(Identifier, 12, false, false, true, true, false),
            5341 => new FireBlock(Identifier, 12, false, false, true, false, true),
            5342 => new FireBlock(Identifier, 12, false, false, true, false, false),
            5343 => new FireBlock(Identifier, 12, false, false, false, true, true),
            5344 => new FireBlock(Identifier, 12, false, false, false, true, false),
            5345 => new FireBlock(Identifier, 12, false, false, false, false, true),
            5346 => new FireBlock(Identifier, 12, false, false, false, false, false),
            5347 => new FireBlock(Identifier, 13, true, true, true, true, true),
            5348 => new FireBlock(Identifier, 13, true, true, true, true, false),
            5349 => new FireBlock(Identifier, 13, true, true, true, false, true),
            5350 => new FireBlock(Identifier, 13, true, true, true, false, false),
            5351 => new FireBlock(Identifier, 13, true, true, false, true, true),
            5352 => new FireBlock(Identifier, 13, true, true, false, true, false),
            5353 => new FireBlock(Identifier, 13, true, true, false, false, true),
            5354 => new FireBlock(Identifier, 13, true, true, false, false, false),
            5355 => new FireBlock(Identifier, 13, true, false, true, true, true),
            5356 => new FireBlock(Identifier, 13, true, false, true, true, false),
            5357 => new FireBlock(Identifier, 13, true, false, true, false, true),
            5358 => new FireBlock(Identifier, 13, true, false, true, false, false),
            5359 => new FireBlock(Identifier, 13, true, false, false, true, true),
            5360 => new FireBlock(Identifier, 13, true, false, false, true, false),
            5361 => new FireBlock(Identifier, 13, true, false, false, false, true),
            5362 => new FireBlock(Identifier, 13, true, false, false, false, false),
            5363 => new FireBlock(Identifier, 13, false, true, true, true, true),
            5364 => new FireBlock(Identifier, 13, false, true, true, true, false),
            5365 => new FireBlock(Identifier, 13, false, true, true, false, true),
            5366 => new FireBlock(Identifier, 13, false, true, true, false, false),
            5367 => new FireBlock(Identifier, 13, false, true, false, true, true),
            5368 => new FireBlock(Identifier, 13, false, true, false, true, false),
            5369 => new FireBlock(Identifier, 13, false, true, false, false, true),
            5370 => new FireBlock(Identifier, 13, false, true, false, false, false),
            5371 => new FireBlock(Identifier, 13, false, false, true, true, true),
            5372 => new FireBlock(Identifier, 13, false, false, true, true, false),
            5373 => new FireBlock(Identifier, 13, false, false, true, false, true),
            5374 => new FireBlock(Identifier, 13, false, false, true, false, false),
            5375 => new FireBlock(Identifier, 13, false, false, false, true, true),
            5376 => new FireBlock(Identifier, 13, false, false, false, true, false),
            5377 => new FireBlock(Identifier, 13, false, false, false, false, true),
            5378 => new FireBlock(Identifier, 13, false, false, false, false, false),
            5379 => new FireBlock(Identifier, 14, true, true, true, true, true),
            5380 => new FireBlock(Identifier, 14, true, true, true, true, false),
            5381 => new FireBlock(Identifier, 14, true, true, true, false, true),
            5382 => new FireBlock(Identifier, 14, true, true, true, false, false),
            5383 => new FireBlock(Identifier, 14, true, true, false, true, true),
            5384 => new FireBlock(Identifier, 14, true, true, false, true, false),
            5385 => new FireBlock(Identifier, 14, true, true, false, false, true),
            5386 => new FireBlock(Identifier, 14, true, true, false, false, false),
            5387 => new FireBlock(Identifier, 14, true, false, true, true, true),
            5388 => new FireBlock(Identifier, 14, true, false, true, true, false),
            5389 => new FireBlock(Identifier, 14, true, false, true, false, true),
            5390 => new FireBlock(Identifier, 14, true, false, true, false, false),
            5391 => new FireBlock(Identifier, 14, true, false, false, true, true),
            5392 => new FireBlock(Identifier, 14, true, false, false, true, false),
            5393 => new FireBlock(Identifier, 14, true, false, false, false, true),
            5394 => new FireBlock(Identifier, 14, true, false, false, false, false),
            5395 => new FireBlock(Identifier, 14, false, true, true, true, true),
            5396 => new FireBlock(Identifier, 14, false, true, true, true, false),
            5397 => new FireBlock(Identifier, 14, false, true, true, false, true),
            5398 => new FireBlock(Identifier, 14, false, true, true, false, false),
            5399 => new FireBlock(Identifier, 14, false, true, false, true, true),
            5400 => new FireBlock(Identifier, 14, false, true, false, true, false),
            5401 => new FireBlock(Identifier, 14, false, true, false, false, true),
            5402 => new FireBlock(Identifier, 14, false, true, false, false, false),
            5403 => new FireBlock(Identifier, 14, false, false, true, true, true),
            5404 => new FireBlock(Identifier, 14, false, false, true, true, false),
            5405 => new FireBlock(Identifier, 14, false, false, true, false, true),
            5406 => new FireBlock(Identifier, 14, false, false, true, false, false),
            5407 => new FireBlock(Identifier, 14, false, false, false, true, true),
            5408 => new FireBlock(Identifier, 14, false, false, false, true, false),
            5409 => new FireBlock(Identifier, 14, false, false, false, false, true),
            5410 => new FireBlock(Identifier, 14, false, false, false, false, false),
            5411 => new FireBlock(Identifier, 15, true, true, true, true, true),
            5412 => new FireBlock(Identifier, 15, true, true, true, true, false),
            5413 => new FireBlock(Identifier, 15, true, true, true, false, true),
            5414 => new FireBlock(Identifier, 15, true, true, true, false, false),
            5415 => new FireBlock(Identifier, 15, true, true, false, true, true),
            5416 => new FireBlock(Identifier, 15, true, true, false, true, false),
            5417 => new FireBlock(Identifier, 15, true, true, false, false, true),
            5418 => new FireBlock(Identifier, 15, true, true, false, false, false),
            5419 => new FireBlock(Identifier, 15, true, false, true, true, true),
            5420 => new FireBlock(Identifier, 15, true, false, true, true, false),
            5421 => new FireBlock(Identifier, 15, true, false, true, false, true),
            5422 => new FireBlock(Identifier, 15, true, false, true, false, false),
            5423 => new FireBlock(Identifier, 15, true, false, false, true, true),
            5424 => new FireBlock(Identifier, 15, true, false, false, true, false),
            5425 => new FireBlock(Identifier, 15, true, false, false, false, true),
            5426 => new FireBlock(Identifier, 15, true, false, false, false, false),
            5427 => new FireBlock(Identifier, 15, false, true, true, true, true),
            5428 => new FireBlock(Identifier, 15, false, true, true, true, false),
            5429 => new FireBlock(Identifier, 15, false, true, true, false, true),
            5430 => new FireBlock(Identifier, 15, false, true, true, false, false),
            5431 => new FireBlock(Identifier, 15, false, true, false, true, true),
            5432 => new FireBlock(Identifier, 15, false, true, false, true, false),
            5433 => new FireBlock(Identifier, 15, false, true, false, false, true),
            5434 => new FireBlock(Identifier, 15, false, true, false, false, false),
            5435 => new FireBlock(Identifier, 15, false, false, true, true, true),
            5436 => new FireBlock(Identifier, 15, false, false, true, true, false),
            5437 => new FireBlock(Identifier, 15, false, false, true, false, true),
            5438 => new FireBlock(Identifier, 15, false, false, true, false, false),
            5439 => new FireBlock(Identifier, 15, false, false, false, true, true),
            5440 => new FireBlock(Identifier, 15, false, false, false, true, false),
            5441 => new FireBlock(Identifier, 15, false, false, false, false, true),
            5442 => new FireBlock(Identifier, 15, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Age = properties.Contains("age") ? int.Parse(properties["age"].GetString()) : Age,
            East = properties.Contains("east") ? properties["east"].GetString() == "true" : East,
            North = properties.Contains("north") ? properties["north"].GetString() == "true" : North,
            South = properties.Contains("south") ? properties["south"].GetString() == "true" : South,
            Up = properties.Contains("up") ? properties["up"].GetString() == "true" : Up,
            West = properties.Contains("west") ? properties["west"].GetString() == "true" : West,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("age", new StringTag(Age.ToString())),
            ("east", new StringTag(East.ToString().ToLower())),
            ("north", new StringTag(North.ToString().ToLower())),
            ("south", new StringTag(South.ToString().ToLower())),
            ("up", new StringTag(Up.ToString().ToLower())),
            ("west", new StringTag(West.ToString().ToLower()))
        );
    }
    
}
