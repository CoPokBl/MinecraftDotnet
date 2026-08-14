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
public record ResinClumpBlock(Identifier Identifier, bool Down, bool East, bool North, bool South, bool Up, bool Waterlogged, bool West) : IBlock, IWaterlogged, IFaceConnected {
    private static readonly BlockInfo Data = new("minecraft:multiface", "block.minecraft.resin_clump", 0f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:resin_clump", BlockInfo.VanillaOnly, "minecraft:blocks/resin_clump");
    private static readonly BlockStateInfo I0 = new(0f, 0, 1, PushReaction.Destroy, 37, "resin", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, false, true, [], "minecraft:water", BlockShapes.S561, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
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

    public BlockStateInfo StateInfo => States[StateId - 8518];

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
    public Identifier? LootTable => Data.LootTable;
    public (int Min, int Max)? Experience => Data.Experience;

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
                                        true => 8518,
                                        false => 8519,
                                    },
                                    false => West switch {
                                        true => 8520,
                                        false => 8521,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8522,
                                        false => 8523,
                                    },
                                    false => West switch {
                                        true => 8524,
                                        false => 8525,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8526,
                                        false => 8527,
                                    },
                                    false => West switch {
                                        true => 8528,
                                        false => 8529,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8530,
                                        false => 8531,
                                    },
                                    false => West switch {
                                        true => 8532,
                                        false => 8533,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8534,
                                        false => 8535,
                                    },
                                    false => West switch {
                                        true => 8536,
                                        false => 8537,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8538,
                                        false => 8539,
                                    },
                                    false => West switch {
                                        true => 8540,
                                        false => 8541,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8542,
                                        false => 8543,
                                    },
                                    false => West switch {
                                        true => 8544,
                                        false => 8545,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8546,
                                        false => 8547,
                                    },
                                    false => West switch {
                                        true => 8548,
                                        false => 8549,
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
                                        true => 8550,
                                        false => 8551,
                                    },
                                    false => West switch {
                                        true => 8552,
                                        false => 8553,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8554,
                                        false => 8555,
                                    },
                                    false => West switch {
                                        true => 8556,
                                        false => 8557,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8558,
                                        false => 8559,
                                    },
                                    false => West switch {
                                        true => 8560,
                                        false => 8561,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8562,
                                        false => 8563,
                                    },
                                    false => West switch {
                                        true => 8564,
                                        false => 8565,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8566,
                                        false => 8567,
                                    },
                                    false => West switch {
                                        true => 8568,
                                        false => 8569,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8570,
                                        false => 8571,
                                    },
                                    false => West switch {
                                        true => 8572,
                                        false => 8573,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8574,
                                        false => 8575,
                                    },
                                    false => West switch {
                                        true => 8576,
                                        false => 8577,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8578,
                                        false => 8579,
                                    },
                                    false => West switch {
                                        true => 8580,
                                        false => 8581,
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
                                        true => 8582,
                                        false => 8583,
                                    },
                                    false => West switch {
                                        true => 8584,
                                        false => 8585,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8586,
                                        false => 8587,
                                    },
                                    false => West switch {
                                        true => 8588,
                                        false => 8589,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8590,
                                        false => 8591,
                                    },
                                    false => West switch {
                                        true => 8592,
                                        false => 8593,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8594,
                                        false => 8595,
                                    },
                                    false => West switch {
                                        true => 8596,
                                        false => 8597,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8598,
                                        false => 8599,
                                    },
                                    false => West switch {
                                        true => 8600,
                                        false => 8601,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8602,
                                        false => 8603,
                                    },
                                    false => West switch {
                                        true => 8604,
                                        false => 8605,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8606,
                                        false => 8607,
                                    },
                                    false => West switch {
                                        true => 8608,
                                        false => 8609,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8610,
                                        false => 8611,
                                    },
                                    false => West switch {
                                        true => 8612,
                                        false => 8613,
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
                                        true => 8614,
                                        false => 8615,
                                    },
                                    false => West switch {
                                        true => 8616,
                                        false => 8617,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8618,
                                        false => 8619,
                                    },
                                    false => West switch {
                                        true => 8620,
                                        false => 8621,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8622,
                                        false => 8623,
                                    },
                                    false => West switch {
                                        true => 8624,
                                        false => 8625,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8626,
                                        false => 8627,
                                    },
                                    false => West switch {
                                        true => 8628,
                                        false => 8629,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8630,
                                        false => 8631,
                                    },
                                    false => West switch {
                                        true => 8632,
                                        false => 8633,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8634,
                                        false => 8635,
                                    },
                                    false => West switch {
                                        true => 8636,
                                        false => 8637,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8638,
                                        false => 8639,
                                    },
                                    false => West switch {
                                        true => 8640,
                                        false => 8641,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8642,
                                        false => 8643,
                                    },
                                    false => West switch {
                                        true => 8644,
                                        false => 8645,
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
            8518 => new ResinClumpBlock(Identifier, true, true, true, true, true, true, true),
            8519 => new ResinClumpBlock(Identifier, true, true, true, true, true, true, false),
            8520 => new ResinClumpBlock(Identifier, true, true, true, true, true, false, true),
            8521 => new ResinClumpBlock(Identifier, true, true, true, true, true, false, false),
            8522 => new ResinClumpBlock(Identifier, true, true, true, true, false, true, true),
            8523 => new ResinClumpBlock(Identifier, true, true, true, true, false, true, false),
            8524 => new ResinClumpBlock(Identifier, true, true, true, true, false, false, true),
            8525 => new ResinClumpBlock(Identifier, true, true, true, true, false, false, false),
            8526 => new ResinClumpBlock(Identifier, true, true, true, false, true, true, true),
            8527 => new ResinClumpBlock(Identifier, true, true, true, false, true, true, false),
            8528 => new ResinClumpBlock(Identifier, true, true, true, false, true, false, true),
            8529 => new ResinClumpBlock(Identifier, true, true, true, false, true, false, false),
            8530 => new ResinClumpBlock(Identifier, true, true, true, false, false, true, true),
            8531 => new ResinClumpBlock(Identifier, true, true, true, false, false, true, false),
            8532 => new ResinClumpBlock(Identifier, true, true, true, false, false, false, true),
            8533 => new ResinClumpBlock(Identifier, true, true, true, false, false, false, false),
            8534 => new ResinClumpBlock(Identifier, true, true, false, true, true, true, true),
            8535 => new ResinClumpBlock(Identifier, true, true, false, true, true, true, false),
            8536 => new ResinClumpBlock(Identifier, true, true, false, true, true, false, true),
            8537 => new ResinClumpBlock(Identifier, true, true, false, true, true, false, false),
            8538 => new ResinClumpBlock(Identifier, true, true, false, true, false, true, true),
            8539 => new ResinClumpBlock(Identifier, true, true, false, true, false, true, false),
            8540 => new ResinClumpBlock(Identifier, true, true, false, true, false, false, true),
            8541 => new ResinClumpBlock(Identifier, true, true, false, true, false, false, false),
            8542 => new ResinClumpBlock(Identifier, true, true, false, false, true, true, true),
            8543 => new ResinClumpBlock(Identifier, true, true, false, false, true, true, false),
            8544 => new ResinClumpBlock(Identifier, true, true, false, false, true, false, true),
            8545 => new ResinClumpBlock(Identifier, true, true, false, false, true, false, false),
            8546 => new ResinClumpBlock(Identifier, true, true, false, false, false, true, true),
            8547 => new ResinClumpBlock(Identifier, true, true, false, false, false, true, false),
            8548 => new ResinClumpBlock(Identifier, true, true, false, false, false, false, true),
            8549 => new ResinClumpBlock(Identifier, true, true, false, false, false, false, false),
            8550 => new ResinClumpBlock(Identifier, true, false, true, true, true, true, true),
            8551 => new ResinClumpBlock(Identifier, true, false, true, true, true, true, false),
            8552 => new ResinClumpBlock(Identifier, true, false, true, true, true, false, true),
            8553 => new ResinClumpBlock(Identifier, true, false, true, true, true, false, false),
            8554 => new ResinClumpBlock(Identifier, true, false, true, true, false, true, true),
            8555 => new ResinClumpBlock(Identifier, true, false, true, true, false, true, false),
            8556 => new ResinClumpBlock(Identifier, true, false, true, true, false, false, true),
            8557 => new ResinClumpBlock(Identifier, true, false, true, true, false, false, false),
            8558 => new ResinClumpBlock(Identifier, true, false, true, false, true, true, true),
            8559 => new ResinClumpBlock(Identifier, true, false, true, false, true, true, false),
            8560 => new ResinClumpBlock(Identifier, true, false, true, false, true, false, true),
            8561 => new ResinClumpBlock(Identifier, true, false, true, false, true, false, false),
            8562 => new ResinClumpBlock(Identifier, true, false, true, false, false, true, true),
            8563 => new ResinClumpBlock(Identifier, true, false, true, false, false, true, false),
            8564 => new ResinClumpBlock(Identifier, true, false, true, false, false, false, true),
            8565 => new ResinClumpBlock(Identifier, true, false, true, false, false, false, false),
            8566 => new ResinClumpBlock(Identifier, true, false, false, true, true, true, true),
            8567 => new ResinClumpBlock(Identifier, true, false, false, true, true, true, false),
            8568 => new ResinClumpBlock(Identifier, true, false, false, true, true, false, true),
            8569 => new ResinClumpBlock(Identifier, true, false, false, true, true, false, false),
            8570 => new ResinClumpBlock(Identifier, true, false, false, true, false, true, true),
            8571 => new ResinClumpBlock(Identifier, true, false, false, true, false, true, false),
            8572 => new ResinClumpBlock(Identifier, true, false, false, true, false, false, true),
            8573 => new ResinClumpBlock(Identifier, true, false, false, true, false, false, false),
            8574 => new ResinClumpBlock(Identifier, true, false, false, false, true, true, true),
            8575 => new ResinClumpBlock(Identifier, true, false, false, false, true, true, false),
            8576 => new ResinClumpBlock(Identifier, true, false, false, false, true, false, true),
            8577 => new ResinClumpBlock(Identifier, true, false, false, false, true, false, false),
            8578 => new ResinClumpBlock(Identifier, true, false, false, false, false, true, true),
            8579 => new ResinClumpBlock(Identifier, true, false, false, false, false, true, false),
            8580 => new ResinClumpBlock(Identifier, true, false, false, false, false, false, true),
            8581 => new ResinClumpBlock(Identifier, true, false, false, false, false, false, false),
            8582 => new ResinClumpBlock(Identifier, false, true, true, true, true, true, true),
            8583 => new ResinClumpBlock(Identifier, false, true, true, true, true, true, false),
            8584 => new ResinClumpBlock(Identifier, false, true, true, true, true, false, true),
            8585 => new ResinClumpBlock(Identifier, false, true, true, true, true, false, false),
            8586 => new ResinClumpBlock(Identifier, false, true, true, true, false, true, true),
            8587 => new ResinClumpBlock(Identifier, false, true, true, true, false, true, false),
            8588 => new ResinClumpBlock(Identifier, false, true, true, true, false, false, true),
            8589 => new ResinClumpBlock(Identifier, false, true, true, true, false, false, false),
            8590 => new ResinClumpBlock(Identifier, false, true, true, false, true, true, true),
            8591 => new ResinClumpBlock(Identifier, false, true, true, false, true, true, false),
            8592 => new ResinClumpBlock(Identifier, false, true, true, false, true, false, true),
            8593 => new ResinClumpBlock(Identifier, false, true, true, false, true, false, false),
            8594 => new ResinClumpBlock(Identifier, false, true, true, false, false, true, true),
            8595 => new ResinClumpBlock(Identifier, false, true, true, false, false, true, false),
            8596 => new ResinClumpBlock(Identifier, false, true, true, false, false, false, true),
            8597 => new ResinClumpBlock(Identifier, false, true, true, false, false, false, false),
            8598 => new ResinClumpBlock(Identifier, false, true, false, true, true, true, true),
            8599 => new ResinClumpBlock(Identifier, false, true, false, true, true, true, false),
            8600 => new ResinClumpBlock(Identifier, false, true, false, true, true, false, true),
            8601 => new ResinClumpBlock(Identifier, false, true, false, true, true, false, false),
            8602 => new ResinClumpBlock(Identifier, false, true, false, true, false, true, true),
            8603 => new ResinClumpBlock(Identifier, false, true, false, true, false, true, false),
            8604 => new ResinClumpBlock(Identifier, false, true, false, true, false, false, true),
            8605 => new ResinClumpBlock(Identifier, false, true, false, true, false, false, false),
            8606 => new ResinClumpBlock(Identifier, false, true, false, false, true, true, true),
            8607 => new ResinClumpBlock(Identifier, false, true, false, false, true, true, false),
            8608 => new ResinClumpBlock(Identifier, false, true, false, false, true, false, true),
            8609 => new ResinClumpBlock(Identifier, false, true, false, false, true, false, false),
            8610 => new ResinClumpBlock(Identifier, false, true, false, false, false, true, true),
            8611 => new ResinClumpBlock(Identifier, false, true, false, false, false, true, false),
            8612 => new ResinClumpBlock(Identifier, false, true, false, false, false, false, true),
            8613 => new ResinClumpBlock(Identifier, false, true, false, false, false, false, false),
            8614 => new ResinClumpBlock(Identifier, false, false, true, true, true, true, true),
            8615 => new ResinClumpBlock(Identifier, false, false, true, true, true, true, false),
            8616 => new ResinClumpBlock(Identifier, false, false, true, true, true, false, true),
            8617 => new ResinClumpBlock(Identifier, false, false, true, true, true, false, false),
            8618 => new ResinClumpBlock(Identifier, false, false, true, true, false, true, true),
            8619 => new ResinClumpBlock(Identifier, false, false, true, true, false, true, false),
            8620 => new ResinClumpBlock(Identifier, false, false, true, true, false, false, true),
            8621 => new ResinClumpBlock(Identifier, false, false, true, true, false, false, false),
            8622 => new ResinClumpBlock(Identifier, false, false, true, false, true, true, true),
            8623 => new ResinClumpBlock(Identifier, false, false, true, false, true, true, false),
            8624 => new ResinClumpBlock(Identifier, false, false, true, false, true, false, true),
            8625 => new ResinClumpBlock(Identifier, false, false, true, false, true, false, false),
            8626 => new ResinClumpBlock(Identifier, false, false, true, false, false, true, true),
            8627 => new ResinClumpBlock(Identifier, false, false, true, false, false, true, false),
            8628 => new ResinClumpBlock(Identifier, false, false, true, false, false, false, true),
            8629 => new ResinClumpBlock(Identifier, false, false, true, false, false, false, false),
            8630 => new ResinClumpBlock(Identifier, false, false, false, true, true, true, true),
            8631 => new ResinClumpBlock(Identifier, false, false, false, true, true, true, false),
            8632 => new ResinClumpBlock(Identifier, false, false, false, true, true, false, true),
            8633 => new ResinClumpBlock(Identifier, false, false, false, true, true, false, false),
            8634 => new ResinClumpBlock(Identifier, false, false, false, true, false, true, true),
            8635 => new ResinClumpBlock(Identifier, false, false, false, true, false, true, false),
            8636 => new ResinClumpBlock(Identifier, false, false, false, true, false, false, true),
            8637 => new ResinClumpBlock(Identifier, false, false, false, true, false, false, false),
            8638 => new ResinClumpBlock(Identifier, false, false, false, false, true, true, true),
            8639 => new ResinClumpBlock(Identifier, false, false, false, false, true, true, false),
            8640 => new ResinClumpBlock(Identifier, false, false, false, false, true, false, true),
            8641 => new ResinClumpBlock(Identifier, false, false, false, false, true, false, false),
            8642 => new ResinClumpBlock(Identifier, false, false, false, false, false, true, true),
            8643 => new ResinClumpBlock(Identifier, false, false, false, false, false, true, false),
            8644 => new ResinClumpBlock(Identifier, false, false, false, false, false, false, true),
            8645 => new ResinClumpBlock(Identifier, false, false, false, false, false, false, false),
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
