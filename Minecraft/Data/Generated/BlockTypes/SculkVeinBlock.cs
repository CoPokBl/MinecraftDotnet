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
public record SculkVeinBlock(Identifier Identifier, bool Down, bool East, bool North, bool South, bool Up, bool Waterlogged, bool West) : IBlock, IWaterlogged, IFaceConnected {
    private static readonly BlockInfo Data = new("block.minecraft.sculk_vein", 0.2f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:sculk_vein", BlockInfo.VanillaOnly, "minecraft:blocks/sculk_vein");
    private static readonly BlockStateInfo I0 = new(0.2f, 0, 1, PushReaction.Popped, 29, "sculk_vein", NoteBlockInstrument.Harp, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S562, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S563 };
    private static readonly BlockStateInfo I2 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S563 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S564 };
    private static readonly BlockStateInfo I5 = I0 with { BlockShape = BlockShapes.S565 };
    private static readonly BlockStateInfo I6 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S564 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S565 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S566 };
    private static readonly BlockStateInfo I9 = I0 with { BlockShape = BlockShapes.S567 };
    private static readonly BlockStateInfo I10 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S566 };
    private static readonly BlockStateInfo I11 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S567 };
    private static readonly BlockStateInfo I12 = I0 with { BlockShape = BlockShapes.S568 };
    private static readonly BlockStateInfo I13 = I0 with { BlockShape = BlockShapes.S569 };
    private static readonly BlockStateInfo I14 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S568 };
    private static readonly BlockStateInfo I15 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S569 };
    private static readonly BlockStateInfo I16 = I0 with { BlockShape = BlockShapes.S570 };
    private static readonly BlockStateInfo I17 = I0 with { BlockShape = BlockShapes.S571 };
    private static readonly BlockStateInfo I18 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S570 };
    private static readonly BlockStateInfo I19 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S571 };
    private static readonly BlockStateInfo I20 = I0 with { BlockShape = BlockShapes.S572 };
    private static readonly BlockStateInfo I21 = I0 with { BlockShape = BlockShapes.S573 };
    private static readonly BlockStateInfo I22 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S572 };
    private static readonly BlockStateInfo I23 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S573 };
    private static readonly BlockStateInfo I24 = I0 with { BlockShape = BlockShapes.S574 };
    private static readonly BlockStateInfo I25 = I0 with { BlockShape = BlockShapes.S575 };
    private static readonly BlockStateInfo I26 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S574 };
    private static readonly BlockStateInfo I27 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S575 };
    private static readonly BlockStateInfo I28 = I0 with { BlockShape = BlockShapes.S576 };
    private static readonly BlockStateInfo I29 = I0 with { BlockShape = BlockShapes.S577 };
    private static readonly BlockStateInfo I30 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S576 };
    private static readonly BlockStateInfo I31 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S577 };
    private static readonly BlockStateInfo I32 = I0 with { BlockShape = BlockShapes.S578 };
    private static readonly BlockStateInfo I33 = I0 with { BlockShape = BlockShapes.S579 };
    private static readonly BlockStateInfo I34 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S578 };
    private static readonly BlockStateInfo I35 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S579 };
    private static readonly BlockStateInfo I36 = I0 with { BlockShape = BlockShapes.S580 };
    private static readonly BlockStateInfo I37 = I0 with { BlockShape = BlockShapes.S581 };
    private static readonly BlockStateInfo I38 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S580 };
    private static readonly BlockStateInfo I39 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S581 };
    private static readonly BlockStateInfo I40 = I0 with { BlockShape = BlockShapes.S582 };
    private static readonly BlockStateInfo I41 = I0 with { BlockShape = BlockShapes.S583 };
    private static readonly BlockStateInfo I42 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S582 };
    private static readonly BlockStateInfo I43 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S583 };
    private static readonly BlockStateInfo I44 = I0 with { BlockShape = BlockShapes.S584 };
    private static readonly BlockStateInfo I45 = I0 with { BlockShape = BlockShapes.S585 };
    private static readonly BlockStateInfo I46 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S584 };
    private static readonly BlockStateInfo I47 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S585 };
    private static readonly BlockStateInfo I48 = I0 with { BlockShape = BlockShapes.S586 };
    private static readonly BlockStateInfo I49 = I0 with { BlockShape = BlockShapes.S587 };
    private static readonly BlockStateInfo I50 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S586 };
    private static readonly BlockStateInfo I51 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S587 };
    private static readonly BlockStateInfo I52 = I0 with { BlockShape = BlockShapes.S588 };
    private static readonly BlockStateInfo I53 = I0 with { BlockShape = BlockShapes.S589 };
    private static readonly BlockStateInfo I54 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S588 };
    private static readonly BlockStateInfo I55 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S589 };
    private static readonly BlockStateInfo I56 = I0 with { BlockShape = BlockShapes.S590 };
    private static readonly BlockStateInfo I57 = I0 with { BlockShape = BlockShapes.S591 };
    private static readonly BlockStateInfo I58 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S590 };
    private static readonly BlockStateInfo I59 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S591 };
    private static readonly BlockStateInfo I60 = I0 with { BlockShape = BlockShapes.S592 };
    private static readonly BlockStateInfo I61 = I0 with { BlockShape = BlockShapes.S371 };
    private static readonly BlockStateInfo I62 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S592 };
    private static readonly BlockStateInfo I63 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S371 };
    private static readonly BlockStateInfo I64 = I0 with { BlockShape = BlockShapes.S530 };
    private static readonly BlockStateInfo I65 = I0 with { BlockShape = BlockShapes.S531 };
    private static readonly BlockStateInfo I66 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S530 };
    private static readonly BlockStateInfo I67 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S531 };
    private static readonly BlockStateInfo I68 = I0 with { BlockShape = BlockShapes.S532 };
    private static readonly BlockStateInfo I69 = I0 with { BlockShape = BlockShapes.S533 };
    private static readonly BlockStateInfo I70 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S532 };
    private static readonly BlockStateInfo I71 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S533 };
    private static readonly BlockStateInfo I72 = I0 with { BlockShape = BlockShapes.S534 };
    private static readonly BlockStateInfo I73 = I0 with { BlockShape = BlockShapes.S535 };
    private static readonly BlockStateInfo I74 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S534 };
    private static readonly BlockStateInfo I75 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S535 };
    private static readonly BlockStateInfo I76 = I0 with { BlockShape = BlockShapes.S536 };
    private static readonly BlockStateInfo I77 = I0 with { BlockShape = BlockShapes.S537 };
    private static readonly BlockStateInfo I78 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S536 };
    private static readonly BlockStateInfo I79 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S537 };
    private static readonly BlockStateInfo I80 = I0 with { BlockShape = BlockShapes.S538 };
    private static readonly BlockStateInfo I81 = I0 with { BlockShape = BlockShapes.S539 };
    private static readonly BlockStateInfo I82 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S538 };
    private static readonly BlockStateInfo I83 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S539 };
    private static readonly BlockStateInfo I84 = I0 with { BlockShape = BlockShapes.S540 };
    private static readonly BlockStateInfo I85 = I0 with { BlockShape = BlockShapes.S541 };
    private static readonly BlockStateInfo I86 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S540 };
    private static readonly BlockStateInfo I87 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S541 };
    private static readonly BlockStateInfo I88 = I0 with { BlockShape = BlockShapes.S542 };
    private static readonly BlockStateInfo I89 = I0 with { BlockShape = BlockShapes.S543 };
    private static readonly BlockStateInfo I90 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S542 };
    private static readonly BlockStateInfo I91 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S543 };
    private static readonly BlockStateInfo I92 = I0 with { BlockShape = BlockShapes.S544 };
    private static readonly BlockStateInfo I93 = I0 with { BlockShape = BlockShapes.S545 };
    private static readonly BlockStateInfo I94 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S544 };
    private static readonly BlockStateInfo I95 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S545 };
    private static readonly BlockStateInfo I96 = I0 with { BlockShape = BlockShapes.S546 };
    private static readonly BlockStateInfo I97 = I0 with { BlockShape = BlockShapes.S547 };
    private static readonly BlockStateInfo I98 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S546 };
    private static readonly BlockStateInfo I99 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S547 };
    private static readonly BlockStateInfo I100 = I0 with { BlockShape = BlockShapes.S548 };
    private static readonly BlockStateInfo I101 = I0 with { BlockShape = BlockShapes.S549 };
    private static readonly BlockStateInfo I102 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S548 };
    private static readonly BlockStateInfo I103 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S549 };
    private static readonly BlockStateInfo I104 = I0 with { BlockShape = BlockShapes.S550 };
    private static readonly BlockStateInfo I105 = I0 with { BlockShape = BlockShapes.S551 };
    private static readonly BlockStateInfo I106 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S550 };
    private static readonly BlockStateInfo I107 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S551 };
    private static readonly BlockStateInfo I108 = I0 with { BlockShape = BlockShapes.S552 };
    private static readonly BlockStateInfo I109 = I0 with { BlockShape = BlockShapes.S553 };
    private static readonly BlockStateInfo I110 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S552 };
    private static readonly BlockStateInfo I111 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S553 };
    private static readonly BlockStateInfo I112 = I0 with { BlockShape = BlockShapes.S554 };
    private static readonly BlockStateInfo I113 = I0 with { BlockShape = BlockShapes.S555 };
    private static readonly BlockStateInfo I114 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S554 };
    private static readonly BlockStateInfo I115 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S555 };
    private static readonly BlockStateInfo I116 = I0 with { BlockShape = BlockShapes.S556 };
    private static readonly BlockStateInfo I117 = I0 with { BlockShape = BlockShapes.S557 };
    private static readonly BlockStateInfo I118 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S556 };
    private static readonly BlockStateInfo I119 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S557 };
    private static readonly BlockStateInfo I120 = I0 with { BlockShape = BlockShapes.S558 };
    private static readonly BlockStateInfo I121 = I0 with { BlockShape = BlockShapes.S559 };
    private static readonly BlockStateInfo I122 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S558 };
    private static readonly BlockStateInfo I123 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S559 };
    private static readonly BlockStateInfo I124 = I0 with { BlockShape = BlockShapes.S560 };
    private static readonly BlockStateInfo I125 = I0 with { BlockShape = BlockShapes.S79 };
    private static readonly BlockStateInfo I126 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S560 };
    private static readonly BlockStateInfo I127 = I0 with { PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S79 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I32, I33, I34, I35, I36, I37, I38, I39, I40, I41, I42, I43, I44, I45, I46, I47, I48, I49, I50, I51, I52, I53, I54, I55, I56, I57, I58, I59, I60, I61, I62, I63, I64, I65, I66, I67, I68, I69, I70, I71, I72, I73, I74, I75, I76, I77, I78, I79, I80, I81, I82, I83, I84, I85, I86, I87, I88, I89, I90, I91, I92, I93, I94, I95, I96, I97, I98, I99, I100, I101, I102, I103, I104, I105, I106, I107, I108, I109, I110, I111, I112, I113, I114, I115, I116, I117, I118, I119, I120, I121, I122, I123, I124, I125, I126, I127
    ];

    public BlockStateInfo StateInfo => States[StateId - 31001];

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

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };

    public bool HasFace(BlockFace face) => face is BlockFace.NegY or BlockFace.PosY or BlockFace.NegZ or BlockFace.PosZ or BlockFace.NegX or BlockFace.PosX;

    public bool Connected(BlockFace face) => face switch {
        BlockFace.NegY => Down,
        BlockFace.PosY => Up,
        BlockFace.NegZ => North,
        BlockFace.PosZ => South,
        BlockFace.NegX => West,
        BlockFace.PosX => East,
        _ => false
    };

    public IBlock WithConnection(BlockFace face, bool connected) => face switch {
        BlockFace.NegY => this with { Down = connected },
        BlockFace.PosY => this with { Up = connected },
        BlockFace.NegZ => this with { North = connected },
        BlockFace.PosZ => this with { South = connected },
        BlockFace.NegX => this with { West = connected },
        BlockFace.PosX => this with { East = connected },
        _ => this
    };


    public uint StateId {
        get {
            return Down switch {
                true => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 31001,
                                        false => 31002,
                                    },
                                    false => West switch {
                                        true => 31003,
                                        false => 31004,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 31005,
                                        false => 31006,
                                    },
                                    false => West switch {
                                        true => 31007,
                                        false => 31008,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 31009,
                                        false => 31010,
                                    },
                                    false => West switch {
                                        true => 31011,
                                        false => 31012,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 31013,
                                        false => 31014,
                                    },
                                    false => West switch {
                                        true => 31015,
                                        false => 31016,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 31017,
                                        false => 31018,
                                    },
                                    false => West switch {
                                        true => 31019,
                                        false => 31020,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 31021,
                                        false => 31022,
                                    },
                                    false => West switch {
                                        true => 31023,
                                        false => 31024,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 31025,
                                        false => 31026,
                                    },
                                    false => West switch {
                                        true => 31027,
                                        false => 31028,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 31029,
                                        false => 31030,
                                    },
                                    false => West switch {
                                        true => 31031,
                                        false => 31032,
                                    },
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 31033,
                                        false => 31034,
                                    },
                                    false => West switch {
                                        true => 31035,
                                        false => 31036,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 31037,
                                        false => 31038,
                                    },
                                    false => West switch {
                                        true => 31039,
                                        false => 31040,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 31041,
                                        false => 31042,
                                    },
                                    false => West switch {
                                        true => 31043,
                                        false => 31044,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 31045,
                                        false => 31046,
                                    },
                                    false => West switch {
                                        true => 31047,
                                        false => 31048,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 31049,
                                        false => 31050,
                                    },
                                    false => West switch {
                                        true => 31051,
                                        false => 31052,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 31053,
                                        false => 31054,
                                    },
                                    false => West switch {
                                        true => 31055,
                                        false => 31056,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 31057,
                                        false => 31058,
                                    },
                                    false => West switch {
                                        true => 31059,
                                        false => 31060,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 31061,
                                        false => 31062,
                                    },
                                    false => West switch {
                                        true => 31063,
                                        false => 31064,
                                    },
                                },
                            },
                        },
                    },
                },
                false => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 31065,
                                        false => 31066,
                                    },
                                    false => West switch {
                                        true => 31067,
                                        false => 31068,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 31069,
                                        false => 31070,
                                    },
                                    false => West switch {
                                        true => 31071,
                                        false => 31072,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 31073,
                                        false => 31074,
                                    },
                                    false => West switch {
                                        true => 31075,
                                        false => 31076,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 31077,
                                        false => 31078,
                                    },
                                    false => West switch {
                                        true => 31079,
                                        false => 31080,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 31081,
                                        false => 31082,
                                    },
                                    false => West switch {
                                        true => 31083,
                                        false => 31084,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 31085,
                                        false => 31086,
                                    },
                                    false => West switch {
                                        true => 31087,
                                        false => 31088,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 31089,
                                        false => 31090,
                                    },
                                    false => West switch {
                                        true => 31091,
                                        false => 31092,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 31093,
                                        false => 31094,
                                    },
                                    false => West switch {
                                        true => 31095,
                                        false => 31096,
                                    },
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 31097,
                                        false => 31098,
                                    },
                                    false => West switch {
                                        true => 31099,
                                        false => 31100,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 31101,
                                        false => 31102,
                                    },
                                    false => West switch {
                                        true => 31103,
                                        false => 31104,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 31105,
                                        false => 31106,
                                    },
                                    false => West switch {
                                        true => 31107,
                                        false => 31108,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 31109,
                                        false => 31110,
                                    },
                                    false => West switch {
                                        true => 31111,
                                        false => 31112,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 31113,
                                        false => 31114,
                                    },
                                    false => West switch {
                                        true => 31115,
                                        false => 31116,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 31117,
                                        false => 31118,
                                    },
                                    false => West switch {
                                        true => 31119,
                                        false => 31120,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 31121,
                                        false => 31122,
                                    },
                                    false => West switch {
                                        true => 31123,
                                        false => 31124,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 31125,
                                        false => 31126,
                                    },
                                    false => West switch {
                                        true => 31127,
                                        false => 31128,
                                    },
                                },
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            31001 => new SculkVeinBlock(Identifier, true, true, true, true, true, true, true),
            31002 => new SculkVeinBlock(Identifier, true, true, true, true, true, true, false),
            31003 => new SculkVeinBlock(Identifier, true, true, true, true, true, false, true),
            31004 => new SculkVeinBlock(Identifier, true, true, true, true, true, false, false),
            31005 => new SculkVeinBlock(Identifier, true, true, true, true, false, true, true),
            31006 => new SculkVeinBlock(Identifier, true, true, true, true, false, true, false),
            31007 => new SculkVeinBlock(Identifier, true, true, true, true, false, false, true),
            31008 => new SculkVeinBlock(Identifier, true, true, true, true, false, false, false),
            31009 => new SculkVeinBlock(Identifier, true, true, true, false, true, true, true),
            31010 => new SculkVeinBlock(Identifier, true, true, true, false, true, true, false),
            31011 => new SculkVeinBlock(Identifier, true, true, true, false, true, false, true),
            31012 => new SculkVeinBlock(Identifier, true, true, true, false, true, false, false),
            31013 => new SculkVeinBlock(Identifier, true, true, true, false, false, true, true),
            31014 => new SculkVeinBlock(Identifier, true, true, true, false, false, true, false),
            31015 => new SculkVeinBlock(Identifier, true, true, true, false, false, false, true),
            31016 => new SculkVeinBlock(Identifier, true, true, true, false, false, false, false),
            31017 => new SculkVeinBlock(Identifier, true, true, false, true, true, true, true),
            31018 => new SculkVeinBlock(Identifier, true, true, false, true, true, true, false),
            31019 => new SculkVeinBlock(Identifier, true, true, false, true, true, false, true),
            31020 => new SculkVeinBlock(Identifier, true, true, false, true, true, false, false),
            31021 => new SculkVeinBlock(Identifier, true, true, false, true, false, true, true),
            31022 => new SculkVeinBlock(Identifier, true, true, false, true, false, true, false),
            31023 => new SculkVeinBlock(Identifier, true, true, false, true, false, false, true),
            31024 => new SculkVeinBlock(Identifier, true, true, false, true, false, false, false),
            31025 => new SculkVeinBlock(Identifier, true, true, false, false, true, true, true),
            31026 => new SculkVeinBlock(Identifier, true, true, false, false, true, true, false),
            31027 => new SculkVeinBlock(Identifier, true, true, false, false, true, false, true),
            31028 => new SculkVeinBlock(Identifier, true, true, false, false, true, false, false),
            31029 => new SculkVeinBlock(Identifier, true, true, false, false, false, true, true),
            31030 => new SculkVeinBlock(Identifier, true, true, false, false, false, true, false),
            31031 => new SculkVeinBlock(Identifier, true, true, false, false, false, false, true),
            31032 => new SculkVeinBlock(Identifier, true, true, false, false, false, false, false),
            31033 => new SculkVeinBlock(Identifier, true, false, true, true, true, true, true),
            31034 => new SculkVeinBlock(Identifier, true, false, true, true, true, true, false),
            31035 => new SculkVeinBlock(Identifier, true, false, true, true, true, false, true),
            31036 => new SculkVeinBlock(Identifier, true, false, true, true, true, false, false),
            31037 => new SculkVeinBlock(Identifier, true, false, true, true, false, true, true),
            31038 => new SculkVeinBlock(Identifier, true, false, true, true, false, true, false),
            31039 => new SculkVeinBlock(Identifier, true, false, true, true, false, false, true),
            31040 => new SculkVeinBlock(Identifier, true, false, true, true, false, false, false),
            31041 => new SculkVeinBlock(Identifier, true, false, true, false, true, true, true),
            31042 => new SculkVeinBlock(Identifier, true, false, true, false, true, true, false),
            31043 => new SculkVeinBlock(Identifier, true, false, true, false, true, false, true),
            31044 => new SculkVeinBlock(Identifier, true, false, true, false, true, false, false),
            31045 => new SculkVeinBlock(Identifier, true, false, true, false, false, true, true),
            31046 => new SculkVeinBlock(Identifier, true, false, true, false, false, true, false),
            31047 => new SculkVeinBlock(Identifier, true, false, true, false, false, false, true),
            31048 => new SculkVeinBlock(Identifier, true, false, true, false, false, false, false),
            31049 => new SculkVeinBlock(Identifier, true, false, false, true, true, true, true),
            31050 => new SculkVeinBlock(Identifier, true, false, false, true, true, true, false),
            31051 => new SculkVeinBlock(Identifier, true, false, false, true, true, false, true),
            31052 => new SculkVeinBlock(Identifier, true, false, false, true, true, false, false),
            31053 => new SculkVeinBlock(Identifier, true, false, false, true, false, true, true),
            31054 => new SculkVeinBlock(Identifier, true, false, false, true, false, true, false),
            31055 => new SculkVeinBlock(Identifier, true, false, false, true, false, false, true),
            31056 => new SculkVeinBlock(Identifier, true, false, false, true, false, false, false),
            31057 => new SculkVeinBlock(Identifier, true, false, false, false, true, true, true),
            31058 => new SculkVeinBlock(Identifier, true, false, false, false, true, true, false),
            31059 => new SculkVeinBlock(Identifier, true, false, false, false, true, false, true),
            31060 => new SculkVeinBlock(Identifier, true, false, false, false, true, false, false),
            31061 => new SculkVeinBlock(Identifier, true, false, false, false, false, true, true),
            31062 => new SculkVeinBlock(Identifier, true, false, false, false, false, true, false),
            31063 => new SculkVeinBlock(Identifier, true, false, false, false, false, false, true),
            31064 => new SculkVeinBlock(Identifier, true, false, false, false, false, false, false),
            31065 => new SculkVeinBlock(Identifier, false, true, true, true, true, true, true),
            31066 => new SculkVeinBlock(Identifier, false, true, true, true, true, true, false),
            31067 => new SculkVeinBlock(Identifier, false, true, true, true, true, false, true),
            31068 => new SculkVeinBlock(Identifier, false, true, true, true, true, false, false),
            31069 => new SculkVeinBlock(Identifier, false, true, true, true, false, true, true),
            31070 => new SculkVeinBlock(Identifier, false, true, true, true, false, true, false),
            31071 => new SculkVeinBlock(Identifier, false, true, true, true, false, false, true),
            31072 => new SculkVeinBlock(Identifier, false, true, true, true, false, false, false),
            31073 => new SculkVeinBlock(Identifier, false, true, true, false, true, true, true),
            31074 => new SculkVeinBlock(Identifier, false, true, true, false, true, true, false),
            31075 => new SculkVeinBlock(Identifier, false, true, true, false, true, false, true),
            31076 => new SculkVeinBlock(Identifier, false, true, true, false, true, false, false),
            31077 => new SculkVeinBlock(Identifier, false, true, true, false, false, true, true),
            31078 => new SculkVeinBlock(Identifier, false, true, true, false, false, true, false),
            31079 => new SculkVeinBlock(Identifier, false, true, true, false, false, false, true),
            31080 => new SculkVeinBlock(Identifier, false, true, true, false, false, false, false),
            31081 => new SculkVeinBlock(Identifier, false, true, false, true, true, true, true),
            31082 => new SculkVeinBlock(Identifier, false, true, false, true, true, true, false),
            31083 => new SculkVeinBlock(Identifier, false, true, false, true, true, false, true),
            31084 => new SculkVeinBlock(Identifier, false, true, false, true, true, false, false),
            31085 => new SculkVeinBlock(Identifier, false, true, false, true, false, true, true),
            31086 => new SculkVeinBlock(Identifier, false, true, false, true, false, true, false),
            31087 => new SculkVeinBlock(Identifier, false, true, false, true, false, false, true),
            31088 => new SculkVeinBlock(Identifier, false, true, false, true, false, false, false),
            31089 => new SculkVeinBlock(Identifier, false, true, false, false, true, true, true),
            31090 => new SculkVeinBlock(Identifier, false, true, false, false, true, true, false),
            31091 => new SculkVeinBlock(Identifier, false, true, false, false, true, false, true),
            31092 => new SculkVeinBlock(Identifier, false, true, false, false, true, false, false),
            31093 => new SculkVeinBlock(Identifier, false, true, false, false, false, true, true),
            31094 => new SculkVeinBlock(Identifier, false, true, false, false, false, true, false),
            31095 => new SculkVeinBlock(Identifier, false, true, false, false, false, false, true),
            31096 => new SculkVeinBlock(Identifier, false, true, false, false, false, false, false),
            31097 => new SculkVeinBlock(Identifier, false, false, true, true, true, true, true),
            31098 => new SculkVeinBlock(Identifier, false, false, true, true, true, true, false),
            31099 => new SculkVeinBlock(Identifier, false, false, true, true, true, false, true),
            31100 => new SculkVeinBlock(Identifier, false, false, true, true, true, false, false),
            31101 => new SculkVeinBlock(Identifier, false, false, true, true, false, true, true),
            31102 => new SculkVeinBlock(Identifier, false, false, true, true, false, true, false),
            31103 => new SculkVeinBlock(Identifier, false, false, true, true, false, false, true),
            31104 => new SculkVeinBlock(Identifier, false, false, true, true, false, false, false),
            31105 => new SculkVeinBlock(Identifier, false, false, true, false, true, true, true),
            31106 => new SculkVeinBlock(Identifier, false, false, true, false, true, true, false),
            31107 => new SculkVeinBlock(Identifier, false, false, true, false, true, false, true),
            31108 => new SculkVeinBlock(Identifier, false, false, true, false, true, false, false),
            31109 => new SculkVeinBlock(Identifier, false, false, true, false, false, true, true),
            31110 => new SculkVeinBlock(Identifier, false, false, true, false, false, true, false),
            31111 => new SculkVeinBlock(Identifier, false, false, true, false, false, false, true),
            31112 => new SculkVeinBlock(Identifier, false, false, true, false, false, false, false),
            31113 => new SculkVeinBlock(Identifier, false, false, false, true, true, true, true),
            31114 => new SculkVeinBlock(Identifier, false, false, false, true, true, true, false),
            31115 => new SculkVeinBlock(Identifier, false, false, false, true, true, false, true),
            31116 => new SculkVeinBlock(Identifier, false, false, false, true, true, false, false),
            31117 => new SculkVeinBlock(Identifier, false, false, false, true, false, true, true),
            31118 => new SculkVeinBlock(Identifier, false, false, false, true, false, true, false),
            31119 => new SculkVeinBlock(Identifier, false, false, false, true, false, false, true),
            31120 => new SculkVeinBlock(Identifier, false, false, false, true, false, false, false),
            31121 => new SculkVeinBlock(Identifier, false, false, false, false, true, true, true),
            31122 => new SculkVeinBlock(Identifier, false, false, false, false, true, true, false),
            31123 => new SculkVeinBlock(Identifier, false, false, false, false, true, false, true),
            31124 => new SculkVeinBlock(Identifier, false, false, false, false, true, false, false),
            31125 => new SculkVeinBlock(Identifier, false, false, false, false, false, true, true),
            31126 => new SculkVeinBlock(Identifier, false, false, false, false, false, true, false),
            31127 => new SculkVeinBlock(Identifier, false, false, false, false, false, false, true),
            31128 => new SculkVeinBlock(Identifier, false, false, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Down = properties.Contains("down") ? properties["down"].GetString() == "true" : Down,
            East = properties.Contains("east") ? properties["east"].GetString() == "true" : East,
            North = properties.Contains("north") ? properties["north"].GetString() == "true" : North,
            South = properties.Contains("south") ? properties["south"].GetString() == "true" : South,
            Up = properties.Contains("up") ? properties["up"].GetString() == "true" : Up,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
            West = properties.Contains("west") ? properties["west"].GetString() == "true" : West,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("down", new StringTag(Down.ToString().ToLower())),
            ("east", new StringTag(East.ToString().ToLower())),
            ("north", new StringTag(North.ToString().ToLower())),
            ("south", new StringTag(South.ToString().ToLower())),
            ("up", new StringTag(Up.ToString().ToLower())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower())),
            ("west", new StringTag(West.ToString().ToLower()))
        );
    }
    
}
