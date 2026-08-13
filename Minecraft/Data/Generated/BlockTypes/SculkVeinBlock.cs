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
    private static readonly BlockInfo Data = new("minecraft:sculk_vein", "block.minecraft.sculk_vein", 0.2f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:sculk_vein", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0.2f, 0, 1, PushReaction.Destroy, 29, "sculk_vein", NoteBlockInstrument.Harp, false, false, false, true, false, false, false, false, true, false, false, false, false, false, true, true, false, true, [], "minecraft:water", BlockShapes.S561, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S562 };
    private static readonly BlockStateInfo I2 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S562 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S563 };
    private static readonly BlockStateInfo I5 = I0 with { BlockShape = BlockShapes.S564 };
    private static readonly BlockStateInfo I6 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S563 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S564 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S565 };
    private static readonly BlockStateInfo I9 = I0 with { BlockShape = BlockShapes.S566 };
    private static readonly BlockStateInfo I10 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S565 };
    private static readonly BlockStateInfo I11 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S566 };
    private static readonly BlockStateInfo I12 = I0 with { BlockShape = BlockShapes.S567 };
    private static readonly BlockStateInfo I13 = I0 with { BlockShape = BlockShapes.S568 };
    private static readonly BlockStateInfo I14 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S567 };
    private static readonly BlockStateInfo I15 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S568 };
    private static readonly BlockStateInfo I16 = I0 with { BlockShape = BlockShapes.S569 };
    private static readonly BlockStateInfo I17 = I0 with { BlockShape = BlockShapes.S570 };
    private static readonly BlockStateInfo I18 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S569 };
    private static readonly BlockStateInfo I19 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S570 };
    private static readonly BlockStateInfo I20 = I0 with { BlockShape = BlockShapes.S571 };
    private static readonly BlockStateInfo I21 = I0 with { BlockShape = BlockShapes.S572 };
    private static readonly BlockStateInfo I22 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S571 };
    private static readonly BlockStateInfo I23 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S572 };
    private static readonly BlockStateInfo I24 = I0 with { BlockShape = BlockShapes.S573 };
    private static readonly BlockStateInfo I25 = I0 with { BlockShape = BlockShapes.S574 };
    private static readonly BlockStateInfo I26 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S573 };
    private static readonly BlockStateInfo I27 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S574 };
    private static readonly BlockStateInfo I28 = I0 with { BlockShape = BlockShapes.S575 };
    private static readonly BlockStateInfo I29 = I0 with { BlockShape = BlockShapes.S576 };
    private static readonly BlockStateInfo I30 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S575 };
    private static readonly BlockStateInfo I31 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S576 };
    private static readonly BlockStateInfo I32 = I0 with { BlockShape = BlockShapes.S577 };
    private static readonly BlockStateInfo I33 = I0 with { BlockShape = BlockShapes.S578 };
    private static readonly BlockStateInfo I34 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S577 };
    private static readonly BlockStateInfo I35 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S578 };
    private static readonly BlockStateInfo I36 = I0 with { BlockShape = BlockShapes.S579 };
    private static readonly BlockStateInfo I37 = I0 with { BlockShape = BlockShapes.S580 };
    private static readonly BlockStateInfo I38 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S579 };
    private static readonly BlockStateInfo I39 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S580 };
    private static readonly BlockStateInfo I40 = I0 with { BlockShape = BlockShapes.S581 };
    private static readonly BlockStateInfo I41 = I0 with { BlockShape = BlockShapes.S582 };
    private static readonly BlockStateInfo I42 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S581 };
    private static readonly BlockStateInfo I43 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S582 };
    private static readonly BlockStateInfo I44 = I0 with { BlockShape = BlockShapes.S583 };
    private static readonly BlockStateInfo I45 = I0 with { BlockShape = BlockShapes.S584 };
    private static readonly BlockStateInfo I46 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S583 };
    private static readonly BlockStateInfo I47 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S584 };
    private static readonly BlockStateInfo I48 = I0 with { BlockShape = BlockShapes.S585 };
    private static readonly BlockStateInfo I49 = I0 with { BlockShape = BlockShapes.S586 };
    private static readonly BlockStateInfo I50 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S585 };
    private static readonly BlockStateInfo I51 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S586 };
    private static readonly BlockStateInfo I52 = I0 with { BlockShape = BlockShapes.S587 };
    private static readonly BlockStateInfo I53 = I0 with { BlockShape = BlockShapes.S588 };
    private static readonly BlockStateInfo I54 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S587 };
    private static readonly BlockStateInfo I55 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S588 };
    private static readonly BlockStateInfo I56 = I0 with { BlockShape = BlockShapes.S589 };
    private static readonly BlockStateInfo I57 = I0 with { BlockShape = BlockShapes.S590 };
    private static readonly BlockStateInfo I58 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S589 };
    private static readonly BlockStateInfo I59 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S590 };
    private static readonly BlockStateInfo I60 = I0 with { BlockShape = BlockShapes.S591 };
    private static readonly BlockStateInfo I61 = I0 with { BlockShape = BlockShapes.S371 };
    private static readonly BlockStateInfo I62 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S591 };
    private static readonly BlockStateInfo I63 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S371 };
    private static readonly BlockStateInfo I64 = I0 with { BlockShape = BlockShapes.S529 };
    private static readonly BlockStateInfo I65 = I0 with { BlockShape = BlockShapes.S530 };
    private static readonly BlockStateInfo I66 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S529 };
    private static readonly BlockStateInfo I67 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S530 };
    private static readonly BlockStateInfo I68 = I0 with { BlockShape = BlockShapes.S531 };
    private static readonly BlockStateInfo I69 = I0 with { BlockShape = BlockShapes.S532 };
    private static readonly BlockStateInfo I70 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S531 };
    private static readonly BlockStateInfo I71 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S532 };
    private static readonly BlockStateInfo I72 = I0 with { BlockShape = BlockShapes.S533 };
    private static readonly BlockStateInfo I73 = I0 with { BlockShape = BlockShapes.S534 };
    private static readonly BlockStateInfo I74 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S533 };
    private static readonly BlockStateInfo I75 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S534 };
    private static readonly BlockStateInfo I76 = I0 with { BlockShape = BlockShapes.S535 };
    private static readonly BlockStateInfo I77 = I0 with { BlockShape = BlockShapes.S536 };
    private static readonly BlockStateInfo I78 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S535 };
    private static readonly BlockStateInfo I79 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S536 };
    private static readonly BlockStateInfo I80 = I0 with { BlockShape = BlockShapes.S537 };
    private static readonly BlockStateInfo I81 = I0 with { BlockShape = BlockShapes.S538 };
    private static readonly BlockStateInfo I82 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S537 };
    private static readonly BlockStateInfo I83 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S538 };
    private static readonly BlockStateInfo I84 = I0 with { BlockShape = BlockShapes.S539 };
    private static readonly BlockStateInfo I85 = I0 with { BlockShape = BlockShapes.S540 };
    private static readonly BlockStateInfo I86 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S539 };
    private static readonly BlockStateInfo I87 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S540 };
    private static readonly BlockStateInfo I88 = I0 with { BlockShape = BlockShapes.S541 };
    private static readonly BlockStateInfo I89 = I0 with { BlockShape = BlockShapes.S542 };
    private static readonly BlockStateInfo I90 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S541 };
    private static readonly BlockStateInfo I91 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S542 };
    private static readonly BlockStateInfo I92 = I0 with { BlockShape = BlockShapes.S543 };
    private static readonly BlockStateInfo I93 = I0 with { BlockShape = BlockShapes.S544 };
    private static readonly BlockStateInfo I94 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S543 };
    private static readonly BlockStateInfo I95 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S544 };
    private static readonly BlockStateInfo I96 = I0 with { BlockShape = BlockShapes.S545 };
    private static readonly BlockStateInfo I97 = I0 with { BlockShape = BlockShapes.S546 };
    private static readonly BlockStateInfo I98 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S545 };
    private static readonly BlockStateInfo I99 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S546 };
    private static readonly BlockStateInfo I100 = I0 with { BlockShape = BlockShapes.S547 };
    private static readonly BlockStateInfo I101 = I0 with { BlockShape = BlockShapes.S548 };
    private static readonly BlockStateInfo I102 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S547 };
    private static readonly BlockStateInfo I103 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S548 };
    private static readonly BlockStateInfo I104 = I0 with { BlockShape = BlockShapes.S549 };
    private static readonly BlockStateInfo I105 = I0 with { BlockShape = BlockShapes.S550 };
    private static readonly BlockStateInfo I106 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S549 };
    private static readonly BlockStateInfo I107 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S550 };
    private static readonly BlockStateInfo I108 = I0 with { BlockShape = BlockShapes.S551 };
    private static readonly BlockStateInfo I109 = I0 with { BlockShape = BlockShapes.S552 };
    private static readonly BlockStateInfo I110 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S551 };
    private static readonly BlockStateInfo I111 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S552 };
    private static readonly BlockStateInfo I112 = I0 with { BlockShape = BlockShapes.S553 };
    private static readonly BlockStateInfo I113 = I0 with { BlockShape = BlockShapes.S554 };
    private static readonly BlockStateInfo I114 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S553 };
    private static readonly BlockStateInfo I115 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S554 };
    private static readonly BlockStateInfo I116 = I0 with { BlockShape = BlockShapes.S555 };
    private static readonly BlockStateInfo I117 = I0 with { BlockShape = BlockShapes.S556 };
    private static readonly BlockStateInfo I118 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S555 };
    private static readonly BlockStateInfo I119 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S556 };
    private static readonly BlockStateInfo I120 = I0 with { BlockShape = BlockShapes.S557 };
    private static readonly BlockStateInfo I121 = I0 with { BlockShape = BlockShapes.S558 };
    private static readonly BlockStateInfo I122 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S557 };
    private static readonly BlockStateInfo I123 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S558 };
    private static readonly BlockStateInfo I124 = I0 with { BlockShape = BlockShapes.S559 };
    private static readonly BlockStateInfo I125 = I0 with { BlockShape = BlockShapes.S79 };
    private static readonly BlockStateInfo I126 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S559 };
    private static readonly BlockStateInfo I127 = I0 with { Fluid = null, BlockShape = BlockShapes.S79 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I32, I33, I34, I35, I36, I37, I38, I39, I40, I41, I42, I43, I44, I45, I46, I47, I48, I49, I50, I51, I52, I53, I54, I55, I56, I57, I58, I59, I60, I61, I62, I63, I64, I65, I66, I67, I68, I69, I70, I71, I72, I73, I74, I75, I76, I77, I78, I79, I80, I81, I82, I83, I84, I85, I86, I87, I88, I89, I90, I91, I92, I93, I94, I95, I96, I97, I98, I99, I100, I101, I102, I103, I104, I105, I106, I107, I108, I109, I110, I111, I112, I113, I114, I115, I116, I117, I118, I119, I120, I121, I122, I123, I124, I125, I126, I127
    ];

    public BlockStateInfo StateInfo => States[StateId - 27644];

    public BlockInfo Info => Data;
    public Identifier Category => Data.Category;
    public float ExplosionResistance => Data.ExplosionResistance;
    public float Friction => Data.Friction;
    public float SpeedFactor => Data.SpeedFactor;
    public float JumpFactor => Data.JumpFactor;
    public float BounceRestitution => Data.BounceRestitution;
    public bool Gravity => Data.Gravity;
    public string TranslationKey => Data.TranslationKey;
    public Identifier? BlockEntity => Data.BlockEntity;
    public Identifier? Item => Data.Item;

    public float Hardness => StateInfo.Hardness;
    public bool Solid => StateInfo.Solid;
    public bool Liquid => StateInfo.Liquid;
    public bool Air => StateInfo.Air;
    public bool Occludes => StateInfo.Occludes;
    public bool RequiresTool => StateInfo.RequiresTool;
    public bool BlocksMotion => StateInfo.BlocksMotion;
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
                                        true => 27644,
                                        false => 27645,
                                    },
                                    false => West switch {
                                        true => 27646,
                                        false => 27647,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 27648,
                                        false => 27649,
                                    },
                                    false => West switch {
                                        true => 27650,
                                        false => 27651,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 27652,
                                        false => 27653,
                                    },
                                    false => West switch {
                                        true => 27654,
                                        false => 27655,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 27656,
                                        false => 27657,
                                    },
                                    false => West switch {
                                        true => 27658,
                                        false => 27659,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 27660,
                                        false => 27661,
                                    },
                                    false => West switch {
                                        true => 27662,
                                        false => 27663,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 27664,
                                        false => 27665,
                                    },
                                    false => West switch {
                                        true => 27666,
                                        false => 27667,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 27668,
                                        false => 27669,
                                    },
                                    false => West switch {
                                        true => 27670,
                                        false => 27671,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 27672,
                                        false => 27673,
                                    },
                                    false => West switch {
                                        true => 27674,
                                        false => 27675,
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
                                        true => 27676,
                                        false => 27677,
                                    },
                                    false => West switch {
                                        true => 27678,
                                        false => 27679,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 27680,
                                        false => 27681,
                                    },
                                    false => West switch {
                                        true => 27682,
                                        false => 27683,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 27684,
                                        false => 27685,
                                    },
                                    false => West switch {
                                        true => 27686,
                                        false => 27687,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 27688,
                                        false => 27689,
                                    },
                                    false => West switch {
                                        true => 27690,
                                        false => 27691,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 27692,
                                        false => 27693,
                                    },
                                    false => West switch {
                                        true => 27694,
                                        false => 27695,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 27696,
                                        false => 27697,
                                    },
                                    false => West switch {
                                        true => 27698,
                                        false => 27699,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 27700,
                                        false => 27701,
                                    },
                                    false => West switch {
                                        true => 27702,
                                        false => 27703,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 27704,
                                        false => 27705,
                                    },
                                    false => West switch {
                                        true => 27706,
                                        false => 27707,
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
                                        true => 27708,
                                        false => 27709,
                                    },
                                    false => West switch {
                                        true => 27710,
                                        false => 27711,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 27712,
                                        false => 27713,
                                    },
                                    false => West switch {
                                        true => 27714,
                                        false => 27715,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 27716,
                                        false => 27717,
                                    },
                                    false => West switch {
                                        true => 27718,
                                        false => 27719,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 27720,
                                        false => 27721,
                                    },
                                    false => West switch {
                                        true => 27722,
                                        false => 27723,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 27724,
                                        false => 27725,
                                    },
                                    false => West switch {
                                        true => 27726,
                                        false => 27727,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 27728,
                                        false => 27729,
                                    },
                                    false => West switch {
                                        true => 27730,
                                        false => 27731,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 27732,
                                        false => 27733,
                                    },
                                    false => West switch {
                                        true => 27734,
                                        false => 27735,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 27736,
                                        false => 27737,
                                    },
                                    false => West switch {
                                        true => 27738,
                                        false => 27739,
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
                                        true => 27740,
                                        false => 27741,
                                    },
                                    false => West switch {
                                        true => 27742,
                                        false => 27743,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 27744,
                                        false => 27745,
                                    },
                                    false => West switch {
                                        true => 27746,
                                        false => 27747,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 27748,
                                        false => 27749,
                                    },
                                    false => West switch {
                                        true => 27750,
                                        false => 27751,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 27752,
                                        false => 27753,
                                    },
                                    false => West switch {
                                        true => 27754,
                                        false => 27755,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 27756,
                                        false => 27757,
                                    },
                                    false => West switch {
                                        true => 27758,
                                        false => 27759,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 27760,
                                        false => 27761,
                                    },
                                    false => West switch {
                                        true => 27762,
                                        false => 27763,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 27764,
                                        false => 27765,
                                    },
                                    false => West switch {
                                        true => 27766,
                                        false => 27767,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 27768,
                                        false => 27769,
                                    },
                                    false => West switch {
                                        true => 27770,
                                        false => 27771,
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
            27644 => new SculkVeinBlock(Identifier, true, true, true, true, true, true, true),
            27645 => new SculkVeinBlock(Identifier, true, true, true, true, true, true, false),
            27646 => new SculkVeinBlock(Identifier, true, true, true, true, true, false, true),
            27647 => new SculkVeinBlock(Identifier, true, true, true, true, true, false, false),
            27648 => new SculkVeinBlock(Identifier, true, true, true, true, false, true, true),
            27649 => new SculkVeinBlock(Identifier, true, true, true, true, false, true, false),
            27650 => new SculkVeinBlock(Identifier, true, true, true, true, false, false, true),
            27651 => new SculkVeinBlock(Identifier, true, true, true, true, false, false, false),
            27652 => new SculkVeinBlock(Identifier, true, true, true, false, true, true, true),
            27653 => new SculkVeinBlock(Identifier, true, true, true, false, true, true, false),
            27654 => new SculkVeinBlock(Identifier, true, true, true, false, true, false, true),
            27655 => new SculkVeinBlock(Identifier, true, true, true, false, true, false, false),
            27656 => new SculkVeinBlock(Identifier, true, true, true, false, false, true, true),
            27657 => new SculkVeinBlock(Identifier, true, true, true, false, false, true, false),
            27658 => new SculkVeinBlock(Identifier, true, true, true, false, false, false, true),
            27659 => new SculkVeinBlock(Identifier, true, true, true, false, false, false, false),
            27660 => new SculkVeinBlock(Identifier, true, true, false, true, true, true, true),
            27661 => new SculkVeinBlock(Identifier, true, true, false, true, true, true, false),
            27662 => new SculkVeinBlock(Identifier, true, true, false, true, true, false, true),
            27663 => new SculkVeinBlock(Identifier, true, true, false, true, true, false, false),
            27664 => new SculkVeinBlock(Identifier, true, true, false, true, false, true, true),
            27665 => new SculkVeinBlock(Identifier, true, true, false, true, false, true, false),
            27666 => new SculkVeinBlock(Identifier, true, true, false, true, false, false, true),
            27667 => new SculkVeinBlock(Identifier, true, true, false, true, false, false, false),
            27668 => new SculkVeinBlock(Identifier, true, true, false, false, true, true, true),
            27669 => new SculkVeinBlock(Identifier, true, true, false, false, true, true, false),
            27670 => new SculkVeinBlock(Identifier, true, true, false, false, true, false, true),
            27671 => new SculkVeinBlock(Identifier, true, true, false, false, true, false, false),
            27672 => new SculkVeinBlock(Identifier, true, true, false, false, false, true, true),
            27673 => new SculkVeinBlock(Identifier, true, true, false, false, false, true, false),
            27674 => new SculkVeinBlock(Identifier, true, true, false, false, false, false, true),
            27675 => new SculkVeinBlock(Identifier, true, true, false, false, false, false, false),
            27676 => new SculkVeinBlock(Identifier, true, false, true, true, true, true, true),
            27677 => new SculkVeinBlock(Identifier, true, false, true, true, true, true, false),
            27678 => new SculkVeinBlock(Identifier, true, false, true, true, true, false, true),
            27679 => new SculkVeinBlock(Identifier, true, false, true, true, true, false, false),
            27680 => new SculkVeinBlock(Identifier, true, false, true, true, false, true, true),
            27681 => new SculkVeinBlock(Identifier, true, false, true, true, false, true, false),
            27682 => new SculkVeinBlock(Identifier, true, false, true, true, false, false, true),
            27683 => new SculkVeinBlock(Identifier, true, false, true, true, false, false, false),
            27684 => new SculkVeinBlock(Identifier, true, false, true, false, true, true, true),
            27685 => new SculkVeinBlock(Identifier, true, false, true, false, true, true, false),
            27686 => new SculkVeinBlock(Identifier, true, false, true, false, true, false, true),
            27687 => new SculkVeinBlock(Identifier, true, false, true, false, true, false, false),
            27688 => new SculkVeinBlock(Identifier, true, false, true, false, false, true, true),
            27689 => new SculkVeinBlock(Identifier, true, false, true, false, false, true, false),
            27690 => new SculkVeinBlock(Identifier, true, false, true, false, false, false, true),
            27691 => new SculkVeinBlock(Identifier, true, false, true, false, false, false, false),
            27692 => new SculkVeinBlock(Identifier, true, false, false, true, true, true, true),
            27693 => new SculkVeinBlock(Identifier, true, false, false, true, true, true, false),
            27694 => new SculkVeinBlock(Identifier, true, false, false, true, true, false, true),
            27695 => new SculkVeinBlock(Identifier, true, false, false, true, true, false, false),
            27696 => new SculkVeinBlock(Identifier, true, false, false, true, false, true, true),
            27697 => new SculkVeinBlock(Identifier, true, false, false, true, false, true, false),
            27698 => new SculkVeinBlock(Identifier, true, false, false, true, false, false, true),
            27699 => new SculkVeinBlock(Identifier, true, false, false, true, false, false, false),
            27700 => new SculkVeinBlock(Identifier, true, false, false, false, true, true, true),
            27701 => new SculkVeinBlock(Identifier, true, false, false, false, true, true, false),
            27702 => new SculkVeinBlock(Identifier, true, false, false, false, true, false, true),
            27703 => new SculkVeinBlock(Identifier, true, false, false, false, true, false, false),
            27704 => new SculkVeinBlock(Identifier, true, false, false, false, false, true, true),
            27705 => new SculkVeinBlock(Identifier, true, false, false, false, false, true, false),
            27706 => new SculkVeinBlock(Identifier, true, false, false, false, false, false, true),
            27707 => new SculkVeinBlock(Identifier, true, false, false, false, false, false, false),
            27708 => new SculkVeinBlock(Identifier, false, true, true, true, true, true, true),
            27709 => new SculkVeinBlock(Identifier, false, true, true, true, true, true, false),
            27710 => new SculkVeinBlock(Identifier, false, true, true, true, true, false, true),
            27711 => new SculkVeinBlock(Identifier, false, true, true, true, true, false, false),
            27712 => new SculkVeinBlock(Identifier, false, true, true, true, false, true, true),
            27713 => new SculkVeinBlock(Identifier, false, true, true, true, false, true, false),
            27714 => new SculkVeinBlock(Identifier, false, true, true, true, false, false, true),
            27715 => new SculkVeinBlock(Identifier, false, true, true, true, false, false, false),
            27716 => new SculkVeinBlock(Identifier, false, true, true, false, true, true, true),
            27717 => new SculkVeinBlock(Identifier, false, true, true, false, true, true, false),
            27718 => new SculkVeinBlock(Identifier, false, true, true, false, true, false, true),
            27719 => new SculkVeinBlock(Identifier, false, true, true, false, true, false, false),
            27720 => new SculkVeinBlock(Identifier, false, true, true, false, false, true, true),
            27721 => new SculkVeinBlock(Identifier, false, true, true, false, false, true, false),
            27722 => new SculkVeinBlock(Identifier, false, true, true, false, false, false, true),
            27723 => new SculkVeinBlock(Identifier, false, true, true, false, false, false, false),
            27724 => new SculkVeinBlock(Identifier, false, true, false, true, true, true, true),
            27725 => new SculkVeinBlock(Identifier, false, true, false, true, true, true, false),
            27726 => new SculkVeinBlock(Identifier, false, true, false, true, true, false, true),
            27727 => new SculkVeinBlock(Identifier, false, true, false, true, true, false, false),
            27728 => new SculkVeinBlock(Identifier, false, true, false, true, false, true, true),
            27729 => new SculkVeinBlock(Identifier, false, true, false, true, false, true, false),
            27730 => new SculkVeinBlock(Identifier, false, true, false, true, false, false, true),
            27731 => new SculkVeinBlock(Identifier, false, true, false, true, false, false, false),
            27732 => new SculkVeinBlock(Identifier, false, true, false, false, true, true, true),
            27733 => new SculkVeinBlock(Identifier, false, true, false, false, true, true, false),
            27734 => new SculkVeinBlock(Identifier, false, true, false, false, true, false, true),
            27735 => new SculkVeinBlock(Identifier, false, true, false, false, true, false, false),
            27736 => new SculkVeinBlock(Identifier, false, true, false, false, false, true, true),
            27737 => new SculkVeinBlock(Identifier, false, true, false, false, false, true, false),
            27738 => new SculkVeinBlock(Identifier, false, true, false, false, false, false, true),
            27739 => new SculkVeinBlock(Identifier, false, true, false, false, false, false, false),
            27740 => new SculkVeinBlock(Identifier, false, false, true, true, true, true, true),
            27741 => new SculkVeinBlock(Identifier, false, false, true, true, true, true, false),
            27742 => new SculkVeinBlock(Identifier, false, false, true, true, true, false, true),
            27743 => new SculkVeinBlock(Identifier, false, false, true, true, true, false, false),
            27744 => new SculkVeinBlock(Identifier, false, false, true, true, false, true, true),
            27745 => new SculkVeinBlock(Identifier, false, false, true, true, false, true, false),
            27746 => new SculkVeinBlock(Identifier, false, false, true, true, false, false, true),
            27747 => new SculkVeinBlock(Identifier, false, false, true, true, false, false, false),
            27748 => new SculkVeinBlock(Identifier, false, false, true, false, true, true, true),
            27749 => new SculkVeinBlock(Identifier, false, false, true, false, true, true, false),
            27750 => new SculkVeinBlock(Identifier, false, false, true, false, true, false, true),
            27751 => new SculkVeinBlock(Identifier, false, false, true, false, true, false, false),
            27752 => new SculkVeinBlock(Identifier, false, false, true, false, false, true, true),
            27753 => new SculkVeinBlock(Identifier, false, false, true, false, false, true, false),
            27754 => new SculkVeinBlock(Identifier, false, false, true, false, false, false, true),
            27755 => new SculkVeinBlock(Identifier, false, false, true, false, false, false, false),
            27756 => new SculkVeinBlock(Identifier, false, false, false, true, true, true, true),
            27757 => new SculkVeinBlock(Identifier, false, false, false, true, true, true, false),
            27758 => new SculkVeinBlock(Identifier, false, false, false, true, true, false, true),
            27759 => new SculkVeinBlock(Identifier, false, false, false, true, true, false, false),
            27760 => new SculkVeinBlock(Identifier, false, false, false, true, false, true, true),
            27761 => new SculkVeinBlock(Identifier, false, false, false, true, false, true, false),
            27762 => new SculkVeinBlock(Identifier, false, false, false, true, false, false, true),
            27763 => new SculkVeinBlock(Identifier, false, false, false, true, false, false, false),
            27764 => new SculkVeinBlock(Identifier, false, false, false, false, true, true, true),
            27765 => new SculkVeinBlock(Identifier, false, false, false, false, true, true, false),
            27766 => new SculkVeinBlock(Identifier, false, false, false, false, true, false, true),
            27767 => new SculkVeinBlock(Identifier, false, false, false, false, true, false, false),
            27768 => new SculkVeinBlock(Identifier, false, false, false, false, false, true, true),
            27769 => new SculkVeinBlock(Identifier, false, false, false, false, false, true, false),
            27770 => new SculkVeinBlock(Identifier, false, false, false, false, false, false, true),
            27771 => new SculkVeinBlock(Identifier, false, false, false, false, false, false, false),
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
