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
public record GlowLichenBlock(Identifier Identifier, bool Down, bool East, bool North, bool South, bool Up, bool Waterlogged, bool West) : IBlock, IWaterlogged, IFaceConnected {
    private static readonly BlockInfo Data = new("minecraft:glow_lichen", "block.minecraft.glow_lichen", 0.2f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:glow_lichen", BlockInfo.VanillaOnly, "minecraft:blocks/glow_lichen");
    private static readonly BlockStateInfo I0 = new(0.2f, 7, 1, PushReaction.Destroy, 61, "glow_lichen", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, false, true, [], "minecraft:water", BlockShapes.S561, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S562 };
    private static readonly BlockStateInfo I2 = I0 with { LightDampening = 0, Flammable = true, Fluid = null };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S562 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S563 };
    private static readonly BlockStateInfo I5 = I0 with { BlockShape = BlockShapes.S564 };
    private static readonly BlockStateInfo I6 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S563 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S564 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S565 };
    private static readonly BlockStateInfo I9 = I0 with { BlockShape = BlockShapes.S566 };
    private static readonly BlockStateInfo I10 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S565 };
    private static readonly BlockStateInfo I11 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S566 };
    private static readonly BlockStateInfo I12 = I0 with { BlockShape = BlockShapes.S567 };
    private static readonly BlockStateInfo I13 = I0 with { BlockShape = BlockShapes.S568 };
    private static readonly BlockStateInfo I14 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S567 };
    private static readonly BlockStateInfo I15 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S568 };
    private static readonly BlockStateInfo I16 = I0 with { BlockShape = BlockShapes.S569 };
    private static readonly BlockStateInfo I17 = I0 with { BlockShape = BlockShapes.S570 };
    private static readonly BlockStateInfo I18 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S569 };
    private static readonly BlockStateInfo I19 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S570 };
    private static readonly BlockStateInfo I20 = I0 with { BlockShape = BlockShapes.S571 };
    private static readonly BlockStateInfo I21 = I0 with { BlockShape = BlockShapes.S572 };
    private static readonly BlockStateInfo I22 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S571 };
    private static readonly BlockStateInfo I23 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S572 };
    private static readonly BlockStateInfo I24 = I0 with { BlockShape = BlockShapes.S573 };
    private static readonly BlockStateInfo I25 = I0 with { BlockShape = BlockShapes.S574 };
    private static readonly BlockStateInfo I26 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S573 };
    private static readonly BlockStateInfo I27 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S574 };
    private static readonly BlockStateInfo I28 = I0 with { BlockShape = BlockShapes.S575 };
    private static readonly BlockStateInfo I29 = I0 with { BlockShape = BlockShapes.S576 };
    private static readonly BlockStateInfo I30 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S575 };
    private static readonly BlockStateInfo I31 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S576 };
    private static readonly BlockStateInfo I32 = I0 with { BlockShape = BlockShapes.S577 };
    private static readonly BlockStateInfo I33 = I0 with { BlockShape = BlockShapes.S578 };
    private static readonly BlockStateInfo I34 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S577 };
    private static readonly BlockStateInfo I35 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S578 };
    private static readonly BlockStateInfo I36 = I0 with { BlockShape = BlockShapes.S579 };
    private static readonly BlockStateInfo I37 = I0 with { BlockShape = BlockShapes.S580 };
    private static readonly BlockStateInfo I38 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S579 };
    private static readonly BlockStateInfo I39 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S580 };
    private static readonly BlockStateInfo I40 = I0 with { BlockShape = BlockShapes.S581 };
    private static readonly BlockStateInfo I41 = I0 with { BlockShape = BlockShapes.S582 };
    private static readonly BlockStateInfo I42 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S581 };
    private static readonly BlockStateInfo I43 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S582 };
    private static readonly BlockStateInfo I44 = I0 with { BlockShape = BlockShapes.S583 };
    private static readonly BlockStateInfo I45 = I0 with { BlockShape = BlockShapes.S584 };
    private static readonly BlockStateInfo I46 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S583 };
    private static readonly BlockStateInfo I47 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S584 };
    private static readonly BlockStateInfo I48 = I0 with { BlockShape = BlockShapes.S585 };
    private static readonly BlockStateInfo I49 = I0 with { BlockShape = BlockShapes.S586 };
    private static readonly BlockStateInfo I50 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S585 };
    private static readonly BlockStateInfo I51 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S586 };
    private static readonly BlockStateInfo I52 = I0 with { BlockShape = BlockShapes.S587 };
    private static readonly BlockStateInfo I53 = I0 with { BlockShape = BlockShapes.S588 };
    private static readonly BlockStateInfo I54 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S587 };
    private static readonly BlockStateInfo I55 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S588 };
    private static readonly BlockStateInfo I56 = I0 with { BlockShape = BlockShapes.S589 };
    private static readonly BlockStateInfo I57 = I0 with { BlockShape = BlockShapes.S590 };
    private static readonly BlockStateInfo I58 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S589 };
    private static readonly BlockStateInfo I59 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S590 };
    private static readonly BlockStateInfo I60 = I0 with { BlockShape = BlockShapes.S591 };
    private static readonly BlockStateInfo I61 = I0 with { BlockShape = BlockShapes.S371 };
    private static readonly BlockStateInfo I62 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S591 };
    private static readonly BlockStateInfo I63 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S371 };
    private static readonly BlockStateInfo I64 = I0 with { BlockShape = BlockShapes.S529 };
    private static readonly BlockStateInfo I65 = I0 with { BlockShape = BlockShapes.S530 };
    private static readonly BlockStateInfo I66 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S529 };
    private static readonly BlockStateInfo I67 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S530 };
    private static readonly BlockStateInfo I68 = I0 with { BlockShape = BlockShapes.S531 };
    private static readonly BlockStateInfo I69 = I0 with { BlockShape = BlockShapes.S532 };
    private static readonly BlockStateInfo I70 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S531 };
    private static readonly BlockStateInfo I71 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S532 };
    private static readonly BlockStateInfo I72 = I0 with { BlockShape = BlockShapes.S533 };
    private static readonly BlockStateInfo I73 = I0 with { BlockShape = BlockShapes.S534 };
    private static readonly BlockStateInfo I74 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S533 };
    private static readonly BlockStateInfo I75 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S534 };
    private static readonly BlockStateInfo I76 = I0 with { BlockShape = BlockShapes.S535 };
    private static readonly BlockStateInfo I77 = I0 with { BlockShape = BlockShapes.S536 };
    private static readonly BlockStateInfo I78 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S535 };
    private static readonly BlockStateInfo I79 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S536 };
    private static readonly BlockStateInfo I80 = I0 with { BlockShape = BlockShapes.S537 };
    private static readonly BlockStateInfo I81 = I0 with { BlockShape = BlockShapes.S538 };
    private static readonly BlockStateInfo I82 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S537 };
    private static readonly BlockStateInfo I83 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S538 };
    private static readonly BlockStateInfo I84 = I0 with { BlockShape = BlockShapes.S539 };
    private static readonly BlockStateInfo I85 = I0 with { BlockShape = BlockShapes.S540 };
    private static readonly BlockStateInfo I86 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S539 };
    private static readonly BlockStateInfo I87 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S540 };
    private static readonly BlockStateInfo I88 = I0 with { BlockShape = BlockShapes.S541 };
    private static readonly BlockStateInfo I89 = I0 with { BlockShape = BlockShapes.S542 };
    private static readonly BlockStateInfo I90 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S541 };
    private static readonly BlockStateInfo I91 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S542 };
    private static readonly BlockStateInfo I92 = I0 with { BlockShape = BlockShapes.S543 };
    private static readonly BlockStateInfo I93 = I0 with { BlockShape = BlockShapes.S544 };
    private static readonly BlockStateInfo I94 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S543 };
    private static readonly BlockStateInfo I95 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S544 };
    private static readonly BlockStateInfo I96 = I0 with { BlockShape = BlockShapes.S545 };
    private static readonly BlockStateInfo I97 = I0 with { BlockShape = BlockShapes.S546 };
    private static readonly BlockStateInfo I98 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S545 };
    private static readonly BlockStateInfo I99 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S546 };
    private static readonly BlockStateInfo I100 = I0 with { BlockShape = BlockShapes.S547 };
    private static readonly BlockStateInfo I101 = I0 with { BlockShape = BlockShapes.S548 };
    private static readonly BlockStateInfo I102 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S547 };
    private static readonly BlockStateInfo I103 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S548 };
    private static readonly BlockStateInfo I104 = I0 with { BlockShape = BlockShapes.S549 };
    private static readonly BlockStateInfo I105 = I0 with { BlockShape = BlockShapes.S550 };
    private static readonly BlockStateInfo I106 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S549 };
    private static readonly BlockStateInfo I107 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S550 };
    private static readonly BlockStateInfo I108 = I0 with { BlockShape = BlockShapes.S551 };
    private static readonly BlockStateInfo I109 = I0 with { BlockShape = BlockShapes.S552 };
    private static readonly BlockStateInfo I110 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S551 };
    private static readonly BlockStateInfo I111 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S552 };
    private static readonly BlockStateInfo I112 = I0 with { BlockShape = BlockShapes.S553 };
    private static readonly BlockStateInfo I113 = I0 with { BlockShape = BlockShapes.S554 };
    private static readonly BlockStateInfo I114 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S553 };
    private static readonly BlockStateInfo I115 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S554 };
    private static readonly BlockStateInfo I116 = I0 with { BlockShape = BlockShapes.S555 };
    private static readonly BlockStateInfo I117 = I0 with { BlockShape = BlockShapes.S556 };
    private static readonly BlockStateInfo I118 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S555 };
    private static readonly BlockStateInfo I119 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S556 };
    private static readonly BlockStateInfo I120 = I0 with { BlockShape = BlockShapes.S557 };
    private static readonly BlockStateInfo I121 = I0 with { BlockShape = BlockShapes.S558 };
    private static readonly BlockStateInfo I122 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S557 };
    private static readonly BlockStateInfo I123 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S558 };
    private static readonly BlockStateInfo I124 = I0 with { BlockShape = BlockShapes.S559 };
    private static readonly BlockStateInfo I125 = I0 with { LightEmission = 0, BlockShape = BlockShapes.S79 };
    private static readonly BlockStateInfo I126 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S559 };
    private static readonly BlockStateInfo I127 = I0 with { LightEmission = 0, LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S79 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I32, I33, I34, I35, I36, I37, I38, I39, I40, I41, I42, I43, I44, I45, I46, I47, I48, I49, I50, I51, I52, I53, I54, I55, I56, I57, I58, I59, I60, I61, I62, I63, I64, I65, I66, I67, I68, I69, I70, I71, I72, I73, I74, I75, I76, I77, I78, I79, I80, I81, I82, I83, I84, I85, I86, I87, I88, I89, I90, I91, I92, I93, I94, I95, I96, I97, I98, I99, I100, I101, I102, I103, I104, I105, I106, I107, I108, I109, I110, I111, I112, I113, I114, I115, I116, I117, I118, I119, I120, I121, I122, I123, I124, I125, I126, I127
    ];

    public BlockStateInfo StateInfo => States[StateId - 8390];

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
                                        true => 8390,
                                        false => 8391,
                                    },
                                    false => West switch {
                                        true => 8392,
                                        false => 8393,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8394,
                                        false => 8395,
                                    },
                                    false => West switch {
                                        true => 8396,
                                        false => 8397,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8398,
                                        false => 8399,
                                    },
                                    false => West switch {
                                        true => 8400,
                                        false => 8401,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8402,
                                        false => 8403,
                                    },
                                    false => West switch {
                                        true => 8404,
                                        false => 8405,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8406,
                                        false => 8407,
                                    },
                                    false => West switch {
                                        true => 8408,
                                        false => 8409,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8410,
                                        false => 8411,
                                    },
                                    false => West switch {
                                        true => 8412,
                                        false => 8413,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8414,
                                        false => 8415,
                                    },
                                    false => West switch {
                                        true => 8416,
                                        false => 8417,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8418,
                                        false => 8419,
                                    },
                                    false => West switch {
                                        true => 8420,
                                        false => 8421,
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
                                        true => 8422,
                                        false => 8423,
                                    },
                                    false => West switch {
                                        true => 8424,
                                        false => 8425,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8426,
                                        false => 8427,
                                    },
                                    false => West switch {
                                        true => 8428,
                                        false => 8429,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8430,
                                        false => 8431,
                                    },
                                    false => West switch {
                                        true => 8432,
                                        false => 8433,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8434,
                                        false => 8435,
                                    },
                                    false => West switch {
                                        true => 8436,
                                        false => 8437,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8438,
                                        false => 8439,
                                    },
                                    false => West switch {
                                        true => 8440,
                                        false => 8441,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8442,
                                        false => 8443,
                                    },
                                    false => West switch {
                                        true => 8444,
                                        false => 8445,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8446,
                                        false => 8447,
                                    },
                                    false => West switch {
                                        true => 8448,
                                        false => 8449,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8450,
                                        false => 8451,
                                    },
                                    false => West switch {
                                        true => 8452,
                                        false => 8453,
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
                                        true => 8454,
                                        false => 8455,
                                    },
                                    false => West switch {
                                        true => 8456,
                                        false => 8457,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8458,
                                        false => 8459,
                                    },
                                    false => West switch {
                                        true => 8460,
                                        false => 8461,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8462,
                                        false => 8463,
                                    },
                                    false => West switch {
                                        true => 8464,
                                        false => 8465,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8466,
                                        false => 8467,
                                    },
                                    false => West switch {
                                        true => 8468,
                                        false => 8469,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8470,
                                        false => 8471,
                                    },
                                    false => West switch {
                                        true => 8472,
                                        false => 8473,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8474,
                                        false => 8475,
                                    },
                                    false => West switch {
                                        true => 8476,
                                        false => 8477,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8478,
                                        false => 8479,
                                    },
                                    false => West switch {
                                        true => 8480,
                                        false => 8481,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8482,
                                        false => 8483,
                                    },
                                    false => West switch {
                                        true => 8484,
                                        false => 8485,
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
                                        true => 8486,
                                        false => 8487,
                                    },
                                    false => West switch {
                                        true => 8488,
                                        false => 8489,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8490,
                                        false => 8491,
                                    },
                                    false => West switch {
                                        true => 8492,
                                        false => 8493,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8494,
                                        false => 8495,
                                    },
                                    false => West switch {
                                        true => 8496,
                                        false => 8497,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8498,
                                        false => 8499,
                                    },
                                    false => West switch {
                                        true => 8500,
                                        false => 8501,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8502,
                                        false => 8503,
                                    },
                                    false => West switch {
                                        true => 8504,
                                        false => 8505,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8506,
                                        false => 8507,
                                    },
                                    false => West switch {
                                        true => 8508,
                                        false => 8509,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8510,
                                        false => 8511,
                                    },
                                    false => West switch {
                                        true => 8512,
                                        false => 8513,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8514,
                                        false => 8515,
                                    },
                                    false => West switch {
                                        true => 8516,
                                        false => 8517,
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
            8390 => new GlowLichenBlock(Identifier, true, true, true, true, true, true, true),
            8391 => new GlowLichenBlock(Identifier, true, true, true, true, true, true, false),
            8392 => new GlowLichenBlock(Identifier, true, true, true, true, true, false, true),
            8393 => new GlowLichenBlock(Identifier, true, true, true, true, true, false, false),
            8394 => new GlowLichenBlock(Identifier, true, true, true, true, false, true, true),
            8395 => new GlowLichenBlock(Identifier, true, true, true, true, false, true, false),
            8396 => new GlowLichenBlock(Identifier, true, true, true, true, false, false, true),
            8397 => new GlowLichenBlock(Identifier, true, true, true, true, false, false, false),
            8398 => new GlowLichenBlock(Identifier, true, true, true, false, true, true, true),
            8399 => new GlowLichenBlock(Identifier, true, true, true, false, true, true, false),
            8400 => new GlowLichenBlock(Identifier, true, true, true, false, true, false, true),
            8401 => new GlowLichenBlock(Identifier, true, true, true, false, true, false, false),
            8402 => new GlowLichenBlock(Identifier, true, true, true, false, false, true, true),
            8403 => new GlowLichenBlock(Identifier, true, true, true, false, false, true, false),
            8404 => new GlowLichenBlock(Identifier, true, true, true, false, false, false, true),
            8405 => new GlowLichenBlock(Identifier, true, true, true, false, false, false, false),
            8406 => new GlowLichenBlock(Identifier, true, true, false, true, true, true, true),
            8407 => new GlowLichenBlock(Identifier, true, true, false, true, true, true, false),
            8408 => new GlowLichenBlock(Identifier, true, true, false, true, true, false, true),
            8409 => new GlowLichenBlock(Identifier, true, true, false, true, true, false, false),
            8410 => new GlowLichenBlock(Identifier, true, true, false, true, false, true, true),
            8411 => new GlowLichenBlock(Identifier, true, true, false, true, false, true, false),
            8412 => new GlowLichenBlock(Identifier, true, true, false, true, false, false, true),
            8413 => new GlowLichenBlock(Identifier, true, true, false, true, false, false, false),
            8414 => new GlowLichenBlock(Identifier, true, true, false, false, true, true, true),
            8415 => new GlowLichenBlock(Identifier, true, true, false, false, true, true, false),
            8416 => new GlowLichenBlock(Identifier, true, true, false, false, true, false, true),
            8417 => new GlowLichenBlock(Identifier, true, true, false, false, true, false, false),
            8418 => new GlowLichenBlock(Identifier, true, true, false, false, false, true, true),
            8419 => new GlowLichenBlock(Identifier, true, true, false, false, false, true, false),
            8420 => new GlowLichenBlock(Identifier, true, true, false, false, false, false, true),
            8421 => new GlowLichenBlock(Identifier, true, true, false, false, false, false, false),
            8422 => new GlowLichenBlock(Identifier, true, false, true, true, true, true, true),
            8423 => new GlowLichenBlock(Identifier, true, false, true, true, true, true, false),
            8424 => new GlowLichenBlock(Identifier, true, false, true, true, true, false, true),
            8425 => new GlowLichenBlock(Identifier, true, false, true, true, true, false, false),
            8426 => new GlowLichenBlock(Identifier, true, false, true, true, false, true, true),
            8427 => new GlowLichenBlock(Identifier, true, false, true, true, false, true, false),
            8428 => new GlowLichenBlock(Identifier, true, false, true, true, false, false, true),
            8429 => new GlowLichenBlock(Identifier, true, false, true, true, false, false, false),
            8430 => new GlowLichenBlock(Identifier, true, false, true, false, true, true, true),
            8431 => new GlowLichenBlock(Identifier, true, false, true, false, true, true, false),
            8432 => new GlowLichenBlock(Identifier, true, false, true, false, true, false, true),
            8433 => new GlowLichenBlock(Identifier, true, false, true, false, true, false, false),
            8434 => new GlowLichenBlock(Identifier, true, false, true, false, false, true, true),
            8435 => new GlowLichenBlock(Identifier, true, false, true, false, false, true, false),
            8436 => new GlowLichenBlock(Identifier, true, false, true, false, false, false, true),
            8437 => new GlowLichenBlock(Identifier, true, false, true, false, false, false, false),
            8438 => new GlowLichenBlock(Identifier, true, false, false, true, true, true, true),
            8439 => new GlowLichenBlock(Identifier, true, false, false, true, true, true, false),
            8440 => new GlowLichenBlock(Identifier, true, false, false, true, true, false, true),
            8441 => new GlowLichenBlock(Identifier, true, false, false, true, true, false, false),
            8442 => new GlowLichenBlock(Identifier, true, false, false, true, false, true, true),
            8443 => new GlowLichenBlock(Identifier, true, false, false, true, false, true, false),
            8444 => new GlowLichenBlock(Identifier, true, false, false, true, false, false, true),
            8445 => new GlowLichenBlock(Identifier, true, false, false, true, false, false, false),
            8446 => new GlowLichenBlock(Identifier, true, false, false, false, true, true, true),
            8447 => new GlowLichenBlock(Identifier, true, false, false, false, true, true, false),
            8448 => new GlowLichenBlock(Identifier, true, false, false, false, true, false, true),
            8449 => new GlowLichenBlock(Identifier, true, false, false, false, true, false, false),
            8450 => new GlowLichenBlock(Identifier, true, false, false, false, false, true, true),
            8451 => new GlowLichenBlock(Identifier, true, false, false, false, false, true, false),
            8452 => new GlowLichenBlock(Identifier, true, false, false, false, false, false, true),
            8453 => new GlowLichenBlock(Identifier, true, false, false, false, false, false, false),
            8454 => new GlowLichenBlock(Identifier, false, true, true, true, true, true, true),
            8455 => new GlowLichenBlock(Identifier, false, true, true, true, true, true, false),
            8456 => new GlowLichenBlock(Identifier, false, true, true, true, true, false, true),
            8457 => new GlowLichenBlock(Identifier, false, true, true, true, true, false, false),
            8458 => new GlowLichenBlock(Identifier, false, true, true, true, false, true, true),
            8459 => new GlowLichenBlock(Identifier, false, true, true, true, false, true, false),
            8460 => new GlowLichenBlock(Identifier, false, true, true, true, false, false, true),
            8461 => new GlowLichenBlock(Identifier, false, true, true, true, false, false, false),
            8462 => new GlowLichenBlock(Identifier, false, true, true, false, true, true, true),
            8463 => new GlowLichenBlock(Identifier, false, true, true, false, true, true, false),
            8464 => new GlowLichenBlock(Identifier, false, true, true, false, true, false, true),
            8465 => new GlowLichenBlock(Identifier, false, true, true, false, true, false, false),
            8466 => new GlowLichenBlock(Identifier, false, true, true, false, false, true, true),
            8467 => new GlowLichenBlock(Identifier, false, true, true, false, false, true, false),
            8468 => new GlowLichenBlock(Identifier, false, true, true, false, false, false, true),
            8469 => new GlowLichenBlock(Identifier, false, true, true, false, false, false, false),
            8470 => new GlowLichenBlock(Identifier, false, true, false, true, true, true, true),
            8471 => new GlowLichenBlock(Identifier, false, true, false, true, true, true, false),
            8472 => new GlowLichenBlock(Identifier, false, true, false, true, true, false, true),
            8473 => new GlowLichenBlock(Identifier, false, true, false, true, true, false, false),
            8474 => new GlowLichenBlock(Identifier, false, true, false, true, false, true, true),
            8475 => new GlowLichenBlock(Identifier, false, true, false, true, false, true, false),
            8476 => new GlowLichenBlock(Identifier, false, true, false, true, false, false, true),
            8477 => new GlowLichenBlock(Identifier, false, true, false, true, false, false, false),
            8478 => new GlowLichenBlock(Identifier, false, true, false, false, true, true, true),
            8479 => new GlowLichenBlock(Identifier, false, true, false, false, true, true, false),
            8480 => new GlowLichenBlock(Identifier, false, true, false, false, true, false, true),
            8481 => new GlowLichenBlock(Identifier, false, true, false, false, true, false, false),
            8482 => new GlowLichenBlock(Identifier, false, true, false, false, false, true, true),
            8483 => new GlowLichenBlock(Identifier, false, true, false, false, false, true, false),
            8484 => new GlowLichenBlock(Identifier, false, true, false, false, false, false, true),
            8485 => new GlowLichenBlock(Identifier, false, true, false, false, false, false, false),
            8486 => new GlowLichenBlock(Identifier, false, false, true, true, true, true, true),
            8487 => new GlowLichenBlock(Identifier, false, false, true, true, true, true, false),
            8488 => new GlowLichenBlock(Identifier, false, false, true, true, true, false, true),
            8489 => new GlowLichenBlock(Identifier, false, false, true, true, true, false, false),
            8490 => new GlowLichenBlock(Identifier, false, false, true, true, false, true, true),
            8491 => new GlowLichenBlock(Identifier, false, false, true, true, false, true, false),
            8492 => new GlowLichenBlock(Identifier, false, false, true, true, false, false, true),
            8493 => new GlowLichenBlock(Identifier, false, false, true, true, false, false, false),
            8494 => new GlowLichenBlock(Identifier, false, false, true, false, true, true, true),
            8495 => new GlowLichenBlock(Identifier, false, false, true, false, true, true, false),
            8496 => new GlowLichenBlock(Identifier, false, false, true, false, true, false, true),
            8497 => new GlowLichenBlock(Identifier, false, false, true, false, true, false, false),
            8498 => new GlowLichenBlock(Identifier, false, false, true, false, false, true, true),
            8499 => new GlowLichenBlock(Identifier, false, false, true, false, false, true, false),
            8500 => new GlowLichenBlock(Identifier, false, false, true, false, false, false, true),
            8501 => new GlowLichenBlock(Identifier, false, false, true, false, false, false, false),
            8502 => new GlowLichenBlock(Identifier, false, false, false, true, true, true, true),
            8503 => new GlowLichenBlock(Identifier, false, false, false, true, true, true, false),
            8504 => new GlowLichenBlock(Identifier, false, false, false, true, true, false, true),
            8505 => new GlowLichenBlock(Identifier, false, false, false, true, true, false, false),
            8506 => new GlowLichenBlock(Identifier, false, false, false, true, false, true, true),
            8507 => new GlowLichenBlock(Identifier, false, false, false, true, false, true, false),
            8508 => new GlowLichenBlock(Identifier, false, false, false, true, false, false, true),
            8509 => new GlowLichenBlock(Identifier, false, false, false, true, false, false, false),
            8510 => new GlowLichenBlock(Identifier, false, false, false, false, true, true, true),
            8511 => new GlowLichenBlock(Identifier, false, false, false, false, true, true, false),
            8512 => new GlowLichenBlock(Identifier, false, false, false, false, true, false, true),
            8513 => new GlowLichenBlock(Identifier, false, false, false, false, true, false, false),
            8514 => new GlowLichenBlock(Identifier, false, false, false, false, false, true, true),
            8515 => new GlowLichenBlock(Identifier, false, false, false, false, false, true, false),
            8516 => new GlowLichenBlock(Identifier, false, false, false, false, false, false, true),
            8517 => new GlowLichenBlock(Identifier, false, false, false, false, false, false, false),
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
