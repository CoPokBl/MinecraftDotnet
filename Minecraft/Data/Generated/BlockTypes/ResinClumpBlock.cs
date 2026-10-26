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
    private static readonly BlockInfo Data = new("block.minecraft.resin_clump", 0f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:resin_clump", BlockInfo.VanillaOnly, "minecraft:blocks/resin_clump");
    private static readonly BlockStateInfo I0 = new(0f, 0, 1, PushReaction.Popped, 37, "resin", NoteBlockInstrument.Harp, true, false, false, false, false, false, true, false, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S562, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
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

    public BlockStateInfo StateInfo => States[StateId - 10252];

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
                                        true => 10252,
                                        false => 10253,
                                    },
                                    false => West switch {
                                        true => 10254,
                                        false => 10255,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 10256,
                                        false => 10257,
                                    },
                                    false => West switch {
                                        true => 10258,
                                        false => 10259,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 10260,
                                        false => 10261,
                                    },
                                    false => West switch {
                                        true => 10262,
                                        false => 10263,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 10264,
                                        false => 10265,
                                    },
                                    false => West switch {
                                        true => 10266,
                                        false => 10267,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 10268,
                                        false => 10269,
                                    },
                                    false => West switch {
                                        true => 10270,
                                        false => 10271,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 10272,
                                        false => 10273,
                                    },
                                    false => West switch {
                                        true => 10274,
                                        false => 10275,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 10276,
                                        false => 10277,
                                    },
                                    false => West switch {
                                        true => 10278,
                                        false => 10279,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 10280,
                                        false => 10281,
                                    },
                                    false => West switch {
                                        true => 10282,
                                        false => 10283,
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
                                        true => 10284,
                                        false => 10285,
                                    },
                                    false => West switch {
                                        true => 10286,
                                        false => 10287,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 10288,
                                        false => 10289,
                                    },
                                    false => West switch {
                                        true => 10290,
                                        false => 10291,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 10292,
                                        false => 10293,
                                    },
                                    false => West switch {
                                        true => 10294,
                                        false => 10295,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 10296,
                                        false => 10297,
                                    },
                                    false => West switch {
                                        true => 10298,
                                        false => 10299,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 10300,
                                        false => 10301,
                                    },
                                    false => West switch {
                                        true => 10302,
                                        false => 10303,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 10304,
                                        false => 10305,
                                    },
                                    false => West switch {
                                        true => 10306,
                                        false => 10307,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 10308,
                                        false => 10309,
                                    },
                                    false => West switch {
                                        true => 10310,
                                        false => 10311,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 10312,
                                        false => 10313,
                                    },
                                    false => West switch {
                                        true => 10314,
                                        false => 10315,
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
                                        true => 10316,
                                        false => 10317,
                                    },
                                    false => West switch {
                                        true => 10318,
                                        false => 10319,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 10320,
                                        false => 10321,
                                    },
                                    false => West switch {
                                        true => 10322,
                                        false => 10323,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 10324,
                                        false => 10325,
                                    },
                                    false => West switch {
                                        true => 10326,
                                        false => 10327,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 10328,
                                        false => 10329,
                                    },
                                    false => West switch {
                                        true => 10330,
                                        false => 10331,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 10332,
                                        false => 10333,
                                    },
                                    false => West switch {
                                        true => 10334,
                                        false => 10335,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 10336,
                                        false => 10337,
                                    },
                                    false => West switch {
                                        true => 10338,
                                        false => 10339,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 10340,
                                        false => 10341,
                                    },
                                    false => West switch {
                                        true => 10342,
                                        false => 10343,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 10344,
                                        false => 10345,
                                    },
                                    false => West switch {
                                        true => 10346,
                                        false => 10347,
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
                                        true => 10348,
                                        false => 10349,
                                    },
                                    false => West switch {
                                        true => 10350,
                                        false => 10351,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 10352,
                                        false => 10353,
                                    },
                                    false => West switch {
                                        true => 10354,
                                        false => 10355,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 10356,
                                        false => 10357,
                                    },
                                    false => West switch {
                                        true => 10358,
                                        false => 10359,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 10360,
                                        false => 10361,
                                    },
                                    false => West switch {
                                        true => 10362,
                                        false => 10363,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 10364,
                                        false => 10365,
                                    },
                                    false => West switch {
                                        true => 10366,
                                        false => 10367,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 10368,
                                        false => 10369,
                                    },
                                    false => West switch {
                                        true => 10370,
                                        false => 10371,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 10372,
                                        false => 10373,
                                    },
                                    false => West switch {
                                        true => 10374,
                                        false => 10375,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 10376,
                                        false => 10377,
                                    },
                                    false => West switch {
                                        true => 10378,
                                        false => 10379,
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
            10252 => new ResinClumpBlock(Identifier, true, true, true, true, true, true, true),
            10253 => new ResinClumpBlock(Identifier, true, true, true, true, true, true, false),
            10254 => new ResinClumpBlock(Identifier, true, true, true, true, true, false, true),
            10255 => new ResinClumpBlock(Identifier, true, true, true, true, true, false, false),
            10256 => new ResinClumpBlock(Identifier, true, true, true, true, false, true, true),
            10257 => new ResinClumpBlock(Identifier, true, true, true, true, false, true, false),
            10258 => new ResinClumpBlock(Identifier, true, true, true, true, false, false, true),
            10259 => new ResinClumpBlock(Identifier, true, true, true, true, false, false, false),
            10260 => new ResinClumpBlock(Identifier, true, true, true, false, true, true, true),
            10261 => new ResinClumpBlock(Identifier, true, true, true, false, true, true, false),
            10262 => new ResinClumpBlock(Identifier, true, true, true, false, true, false, true),
            10263 => new ResinClumpBlock(Identifier, true, true, true, false, true, false, false),
            10264 => new ResinClumpBlock(Identifier, true, true, true, false, false, true, true),
            10265 => new ResinClumpBlock(Identifier, true, true, true, false, false, true, false),
            10266 => new ResinClumpBlock(Identifier, true, true, true, false, false, false, true),
            10267 => new ResinClumpBlock(Identifier, true, true, true, false, false, false, false),
            10268 => new ResinClumpBlock(Identifier, true, true, false, true, true, true, true),
            10269 => new ResinClumpBlock(Identifier, true, true, false, true, true, true, false),
            10270 => new ResinClumpBlock(Identifier, true, true, false, true, true, false, true),
            10271 => new ResinClumpBlock(Identifier, true, true, false, true, true, false, false),
            10272 => new ResinClumpBlock(Identifier, true, true, false, true, false, true, true),
            10273 => new ResinClumpBlock(Identifier, true, true, false, true, false, true, false),
            10274 => new ResinClumpBlock(Identifier, true, true, false, true, false, false, true),
            10275 => new ResinClumpBlock(Identifier, true, true, false, true, false, false, false),
            10276 => new ResinClumpBlock(Identifier, true, true, false, false, true, true, true),
            10277 => new ResinClumpBlock(Identifier, true, true, false, false, true, true, false),
            10278 => new ResinClumpBlock(Identifier, true, true, false, false, true, false, true),
            10279 => new ResinClumpBlock(Identifier, true, true, false, false, true, false, false),
            10280 => new ResinClumpBlock(Identifier, true, true, false, false, false, true, true),
            10281 => new ResinClumpBlock(Identifier, true, true, false, false, false, true, false),
            10282 => new ResinClumpBlock(Identifier, true, true, false, false, false, false, true),
            10283 => new ResinClumpBlock(Identifier, true, true, false, false, false, false, false),
            10284 => new ResinClumpBlock(Identifier, true, false, true, true, true, true, true),
            10285 => new ResinClumpBlock(Identifier, true, false, true, true, true, true, false),
            10286 => new ResinClumpBlock(Identifier, true, false, true, true, true, false, true),
            10287 => new ResinClumpBlock(Identifier, true, false, true, true, true, false, false),
            10288 => new ResinClumpBlock(Identifier, true, false, true, true, false, true, true),
            10289 => new ResinClumpBlock(Identifier, true, false, true, true, false, true, false),
            10290 => new ResinClumpBlock(Identifier, true, false, true, true, false, false, true),
            10291 => new ResinClumpBlock(Identifier, true, false, true, true, false, false, false),
            10292 => new ResinClumpBlock(Identifier, true, false, true, false, true, true, true),
            10293 => new ResinClumpBlock(Identifier, true, false, true, false, true, true, false),
            10294 => new ResinClumpBlock(Identifier, true, false, true, false, true, false, true),
            10295 => new ResinClumpBlock(Identifier, true, false, true, false, true, false, false),
            10296 => new ResinClumpBlock(Identifier, true, false, true, false, false, true, true),
            10297 => new ResinClumpBlock(Identifier, true, false, true, false, false, true, false),
            10298 => new ResinClumpBlock(Identifier, true, false, true, false, false, false, true),
            10299 => new ResinClumpBlock(Identifier, true, false, true, false, false, false, false),
            10300 => new ResinClumpBlock(Identifier, true, false, false, true, true, true, true),
            10301 => new ResinClumpBlock(Identifier, true, false, false, true, true, true, false),
            10302 => new ResinClumpBlock(Identifier, true, false, false, true, true, false, true),
            10303 => new ResinClumpBlock(Identifier, true, false, false, true, true, false, false),
            10304 => new ResinClumpBlock(Identifier, true, false, false, true, false, true, true),
            10305 => new ResinClumpBlock(Identifier, true, false, false, true, false, true, false),
            10306 => new ResinClumpBlock(Identifier, true, false, false, true, false, false, true),
            10307 => new ResinClumpBlock(Identifier, true, false, false, true, false, false, false),
            10308 => new ResinClumpBlock(Identifier, true, false, false, false, true, true, true),
            10309 => new ResinClumpBlock(Identifier, true, false, false, false, true, true, false),
            10310 => new ResinClumpBlock(Identifier, true, false, false, false, true, false, true),
            10311 => new ResinClumpBlock(Identifier, true, false, false, false, true, false, false),
            10312 => new ResinClumpBlock(Identifier, true, false, false, false, false, true, true),
            10313 => new ResinClumpBlock(Identifier, true, false, false, false, false, true, false),
            10314 => new ResinClumpBlock(Identifier, true, false, false, false, false, false, true),
            10315 => new ResinClumpBlock(Identifier, true, false, false, false, false, false, false),
            10316 => new ResinClumpBlock(Identifier, false, true, true, true, true, true, true),
            10317 => new ResinClumpBlock(Identifier, false, true, true, true, true, true, false),
            10318 => new ResinClumpBlock(Identifier, false, true, true, true, true, false, true),
            10319 => new ResinClumpBlock(Identifier, false, true, true, true, true, false, false),
            10320 => new ResinClumpBlock(Identifier, false, true, true, true, false, true, true),
            10321 => new ResinClumpBlock(Identifier, false, true, true, true, false, true, false),
            10322 => new ResinClumpBlock(Identifier, false, true, true, true, false, false, true),
            10323 => new ResinClumpBlock(Identifier, false, true, true, true, false, false, false),
            10324 => new ResinClumpBlock(Identifier, false, true, true, false, true, true, true),
            10325 => new ResinClumpBlock(Identifier, false, true, true, false, true, true, false),
            10326 => new ResinClumpBlock(Identifier, false, true, true, false, true, false, true),
            10327 => new ResinClumpBlock(Identifier, false, true, true, false, true, false, false),
            10328 => new ResinClumpBlock(Identifier, false, true, true, false, false, true, true),
            10329 => new ResinClumpBlock(Identifier, false, true, true, false, false, true, false),
            10330 => new ResinClumpBlock(Identifier, false, true, true, false, false, false, true),
            10331 => new ResinClumpBlock(Identifier, false, true, true, false, false, false, false),
            10332 => new ResinClumpBlock(Identifier, false, true, false, true, true, true, true),
            10333 => new ResinClumpBlock(Identifier, false, true, false, true, true, true, false),
            10334 => new ResinClumpBlock(Identifier, false, true, false, true, true, false, true),
            10335 => new ResinClumpBlock(Identifier, false, true, false, true, true, false, false),
            10336 => new ResinClumpBlock(Identifier, false, true, false, true, false, true, true),
            10337 => new ResinClumpBlock(Identifier, false, true, false, true, false, true, false),
            10338 => new ResinClumpBlock(Identifier, false, true, false, true, false, false, true),
            10339 => new ResinClumpBlock(Identifier, false, true, false, true, false, false, false),
            10340 => new ResinClumpBlock(Identifier, false, true, false, false, true, true, true),
            10341 => new ResinClumpBlock(Identifier, false, true, false, false, true, true, false),
            10342 => new ResinClumpBlock(Identifier, false, true, false, false, true, false, true),
            10343 => new ResinClumpBlock(Identifier, false, true, false, false, true, false, false),
            10344 => new ResinClumpBlock(Identifier, false, true, false, false, false, true, true),
            10345 => new ResinClumpBlock(Identifier, false, true, false, false, false, true, false),
            10346 => new ResinClumpBlock(Identifier, false, true, false, false, false, false, true),
            10347 => new ResinClumpBlock(Identifier, false, true, false, false, false, false, false),
            10348 => new ResinClumpBlock(Identifier, false, false, true, true, true, true, true),
            10349 => new ResinClumpBlock(Identifier, false, false, true, true, true, true, false),
            10350 => new ResinClumpBlock(Identifier, false, false, true, true, true, false, true),
            10351 => new ResinClumpBlock(Identifier, false, false, true, true, true, false, false),
            10352 => new ResinClumpBlock(Identifier, false, false, true, true, false, true, true),
            10353 => new ResinClumpBlock(Identifier, false, false, true, true, false, true, false),
            10354 => new ResinClumpBlock(Identifier, false, false, true, true, false, false, true),
            10355 => new ResinClumpBlock(Identifier, false, false, true, true, false, false, false),
            10356 => new ResinClumpBlock(Identifier, false, false, true, false, true, true, true),
            10357 => new ResinClumpBlock(Identifier, false, false, true, false, true, true, false),
            10358 => new ResinClumpBlock(Identifier, false, false, true, false, true, false, true),
            10359 => new ResinClumpBlock(Identifier, false, false, true, false, true, false, false),
            10360 => new ResinClumpBlock(Identifier, false, false, true, false, false, true, true),
            10361 => new ResinClumpBlock(Identifier, false, false, true, false, false, true, false),
            10362 => new ResinClumpBlock(Identifier, false, false, true, false, false, false, true),
            10363 => new ResinClumpBlock(Identifier, false, false, true, false, false, false, false),
            10364 => new ResinClumpBlock(Identifier, false, false, false, true, true, true, true),
            10365 => new ResinClumpBlock(Identifier, false, false, false, true, true, true, false),
            10366 => new ResinClumpBlock(Identifier, false, false, false, true, true, false, true),
            10367 => new ResinClumpBlock(Identifier, false, false, false, true, true, false, false),
            10368 => new ResinClumpBlock(Identifier, false, false, false, true, false, true, true),
            10369 => new ResinClumpBlock(Identifier, false, false, false, true, false, true, false),
            10370 => new ResinClumpBlock(Identifier, false, false, false, true, false, false, true),
            10371 => new ResinClumpBlock(Identifier, false, false, false, true, false, false, false),
            10372 => new ResinClumpBlock(Identifier, false, false, false, false, true, true, true),
            10373 => new ResinClumpBlock(Identifier, false, false, false, false, true, true, false),
            10374 => new ResinClumpBlock(Identifier, false, false, false, false, true, false, true),
            10375 => new ResinClumpBlock(Identifier, false, false, false, false, true, false, false),
            10376 => new ResinClumpBlock(Identifier, false, false, false, false, false, true, true),
            10377 => new ResinClumpBlock(Identifier, false, false, false, false, false, true, false),
            10378 => new ResinClumpBlock(Identifier, false, false, false, false, false, false, true),
            10379 => new ResinClumpBlock(Identifier, false, false, false, false, false, false, false),
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
