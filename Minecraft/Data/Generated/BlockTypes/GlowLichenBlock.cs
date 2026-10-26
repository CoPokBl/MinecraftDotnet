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
    private static readonly BlockInfo Data = new("block.minecraft.glow_lichen", 0.2f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:glow_lichen", BlockInfo.VanillaOnly, "minecraft:blocks/glow_lichen");
    private static readonly BlockStateInfo I0 = new(0.2f, 7, 1, PushReaction.Popped, 61, "glow_lichen", NoteBlockInstrument.Harp, true, false, false, false, false, false, true, false, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S562, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S563 };
    private static readonly BlockStateInfo I2 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S563 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S564 };
    private static readonly BlockStateInfo I5 = I0 with { BlockShape = BlockShapes.S565 };
    private static readonly BlockStateInfo I6 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S564 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S565 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S566 };
    private static readonly BlockStateInfo I9 = I0 with { BlockShape = BlockShapes.S567 };
    private static readonly BlockStateInfo I10 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S566 };
    private static readonly BlockStateInfo I11 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S567 };
    private static readonly BlockStateInfo I12 = I0 with { BlockShape = BlockShapes.S568 };
    private static readonly BlockStateInfo I13 = I0 with { BlockShape = BlockShapes.S569 };
    private static readonly BlockStateInfo I14 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S568 };
    private static readonly BlockStateInfo I15 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S569 };
    private static readonly BlockStateInfo I16 = I0 with { BlockShape = BlockShapes.S570 };
    private static readonly BlockStateInfo I17 = I0 with { BlockShape = BlockShapes.S571 };
    private static readonly BlockStateInfo I18 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S570 };
    private static readonly BlockStateInfo I19 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S571 };
    private static readonly BlockStateInfo I20 = I0 with { BlockShape = BlockShapes.S572 };
    private static readonly BlockStateInfo I21 = I0 with { BlockShape = BlockShapes.S573 };
    private static readonly BlockStateInfo I22 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S572 };
    private static readonly BlockStateInfo I23 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S573 };
    private static readonly BlockStateInfo I24 = I0 with { BlockShape = BlockShapes.S574 };
    private static readonly BlockStateInfo I25 = I0 with { BlockShape = BlockShapes.S575 };
    private static readonly BlockStateInfo I26 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S574 };
    private static readonly BlockStateInfo I27 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S575 };
    private static readonly BlockStateInfo I28 = I0 with { BlockShape = BlockShapes.S576 };
    private static readonly BlockStateInfo I29 = I0 with { BlockShape = BlockShapes.S577 };
    private static readonly BlockStateInfo I30 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S576 };
    private static readonly BlockStateInfo I31 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S577 };
    private static readonly BlockStateInfo I32 = I0 with { BlockShape = BlockShapes.S578 };
    private static readonly BlockStateInfo I33 = I0 with { BlockShape = BlockShapes.S579 };
    private static readonly BlockStateInfo I34 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S578 };
    private static readonly BlockStateInfo I35 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S579 };
    private static readonly BlockStateInfo I36 = I0 with { BlockShape = BlockShapes.S580 };
    private static readonly BlockStateInfo I37 = I0 with { BlockShape = BlockShapes.S581 };
    private static readonly BlockStateInfo I38 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S580 };
    private static readonly BlockStateInfo I39 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S581 };
    private static readonly BlockStateInfo I40 = I0 with { BlockShape = BlockShapes.S582 };
    private static readonly BlockStateInfo I41 = I0 with { BlockShape = BlockShapes.S583 };
    private static readonly BlockStateInfo I42 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S582 };
    private static readonly BlockStateInfo I43 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S583 };
    private static readonly BlockStateInfo I44 = I0 with { BlockShape = BlockShapes.S584 };
    private static readonly BlockStateInfo I45 = I0 with { BlockShape = BlockShapes.S585 };
    private static readonly BlockStateInfo I46 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S584 };
    private static readonly BlockStateInfo I47 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S585 };
    private static readonly BlockStateInfo I48 = I0 with { BlockShape = BlockShapes.S586 };
    private static readonly BlockStateInfo I49 = I0 with { BlockShape = BlockShapes.S587 };
    private static readonly BlockStateInfo I50 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S586 };
    private static readonly BlockStateInfo I51 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S587 };
    private static readonly BlockStateInfo I52 = I0 with { BlockShape = BlockShapes.S588 };
    private static readonly BlockStateInfo I53 = I0 with { BlockShape = BlockShapes.S589 };
    private static readonly BlockStateInfo I54 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S588 };
    private static readonly BlockStateInfo I55 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S589 };
    private static readonly BlockStateInfo I56 = I0 with { BlockShape = BlockShapes.S590 };
    private static readonly BlockStateInfo I57 = I0 with { BlockShape = BlockShapes.S591 };
    private static readonly BlockStateInfo I58 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S590 };
    private static readonly BlockStateInfo I59 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S591 };
    private static readonly BlockStateInfo I60 = I0 with { BlockShape = BlockShapes.S592 };
    private static readonly BlockStateInfo I61 = I0 with { BlockShape = BlockShapes.S371 };
    private static readonly BlockStateInfo I62 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S592 };
    private static readonly BlockStateInfo I63 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S371 };
    private static readonly BlockStateInfo I64 = I0 with { BlockShape = BlockShapes.S530 };
    private static readonly BlockStateInfo I65 = I0 with { BlockShape = BlockShapes.S531 };
    private static readonly BlockStateInfo I66 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S530 };
    private static readonly BlockStateInfo I67 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S531 };
    private static readonly BlockStateInfo I68 = I0 with { BlockShape = BlockShapes.S532 };
    private static readonly BlockStateInfo I69 = I0 with { BlockShape = BlockShapes.S533 };
    private static readonly BlockStateInfo I70 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S532 };
    private static readonly BlockStateInfo I71 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S533 };
    private static readonly BlockStateInfo I72 = I0 with { BlockShape = BlockShapes.S534 };
    private static readonly BlockStateInfo I73 = I0 with { BlockShape = BlockShapes.S535 };
    private static readonly BlockStateInfo I74 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S534 };
    private static readonly BlockStateInfo I75 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S535 };
    private static readonly BlockStateInfo I76 = I0 with { BlockShape = BlockShapes.S536 };
    private static readonly BlockStateInfo I77 = I0 with { BlockShape = BlockShapes.S537 };
    private static readonly BlockStateInfo I78 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S536 };
    private static readonly BlockStateInfo I79 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S537 };
    private static readonly BlockStateInfo I80 = I0 with { BlockShape = BlockShapes.S538 };
    private static readonly BlockStateInfo I81 = I0 with { BlockShape = BlockShapes.S539 };
    private static readonly BlockStateInfo I82 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S538 };
    private static readonly BlockStateInfo I83 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S539 };
    private static readonly BlockStateInfo I84 = I0 with { BlockShape = BlockShapes.S540 };
    private static readonly BlockStateInfo I85 = I0 with { BlockShape = BlockShapes.S541 };
    private static readonly BlockStateInfo I86 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S540 };
    private static readonly BlockStateInfo I87 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S541 };
    private static readonly BlockStateInfo I88 = I0 with { BlockShape = BlockShapes.S542 };
    private static readonly BlockStateInfo I89 = I0 with { BlockShape = BlockShapes.S543 };
    private static readonly BlockStateInfo I90 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S542 };
    private static readonly BlockStateInfo I91 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S543 };
    private static readonly BlockStateInfo I92 = I0 with { BlockShape = BlockShapes.S544 };
    private static readonly BlockStateInfo I93 = I0 with { BlockShape = BlockShapes.S545 };
    private static readonly BlockStateInfo I94 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S544 };
    private static readonly BlockStateInfo I95 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S545 };
    private static readonly BlockStateInfo I96 = I0 with { BlockShape = BlockShapes.S546 };
    private static readonly BlockStateInfo I97 = I0 with { BlockShape = BlockShapes.S547 };
    private static readonly BlockStateInfo I98 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S546 };
    private static readonly BlockStateInfo I99 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S547 };
    private static readonly BlockStateInfo I100 = I0 with { BlockShape = BlockShapes.S548 };
    private static readonly BlockStateInfo I101 = I0 with { BlockShape = BlockShapes.S549 };
    private static readonly BlockStateInfo I102 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S548 };
    private static readonly BlockStateInfo I103 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S549 };
    private static readonly BlockStateInfo I104 = I0 with { BlockShape = BlockShapes.S550 };
    private static readonly BlockStateInfo I105 = I0 with { BlockShape = BlockShapes.S551 };
    private static readonly BlockStateInfo I106 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S550 };
    private static readonly BlockStateInfo I107 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S551 };
    private static readonly BlockStateInfo I108 = I0 with { BlockShape = BlockShapes.S552 };
    private static readonly BlockStateInfo I109 = I0 with { BlockShape = BlockShapes.S553 };
    private static readonly BlockStateInfo I110 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S552 };
    private static readonly BlockStateInfo I111 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S553 };
    private static readonly BlockStateInfo I112 = I0 with { BlockShape = BlockShapes.S554 };
    private static readonly BlockStateInfo I113 = I0 with { BlockShape = BlockShapes.S555 };
    private static readonly BlockStateInfo I114 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S554 };
    private static readonly BlockStateInfo I115 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S555 };
    private static readonly BlockStateInfo I116 = I0 with { BlockShape = BlockShapes.S556 };
    private static readonly BlockStateInfo I117 = I0 with { BlockShape = BlockShapes.S557 };
    private static readonly BlockStateInfo I118 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S556 };
    private static readonly BlockStateInfo I119 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S557 };
    private static readonly BlockStateInfo I120 = I0 with { BlockShape = BlockShapes.S558 };
    private static readonly BlockStateInfo I121 = I0 with { BlockShape = BlockShapes.S559 };
    private static readonly BlockStateInfo I122 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S558 };
    private static readonly BlockStateInfo I123 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S559 };
    private static readonly BlockStateInfo I124 = I0 with { BlockShape = BlockShapes.S560 };
    private static readonly BlockStateInfo I125 = I0 with { LightEmission = 0, BlockShape = BlockShapes.S79 };
    private static readonly BlockStateInfo I126 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S560 };
    private static readonly BlockStateInfo I127 = I0 with { LightEmission = 0, LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S79 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I32, I33, I34, I35, I36, I37, I38, I39, I40, I41, I42, I43, I44, I45, I46, I47, I48, I49, I50, I51, I52, I53, I54, I55, I56, I57, I58, I59, I60, I61, I62, I63, I64, I65, I66, I67, I68, I69, I70, I71, I72, I73, I74, I75, I76, I77, I78, I79, I80, I81, I82, I83, I84, I85, I86, I87, I88, I89, I90, I91, I92, I93, I94, I95, I96, I97, I98, I99, I100, I101, I102, I103, I104, I105, I106, I107, I108, I109, I110, I111, I112, I113, I114, I115, I116, I117, I118, I119, I120, I121, I122, I123, I124, I125, I126, I127
    ];

    public BlockStateInfo StateInfo => States[StateId - 10124];

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
                                        true => 10124,
                                        false => 10125,
                                    },
                                    false => West switch {
                                        true => 10126,
                                        false => 10127,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 10128,
                                        false => 10129,
                                    },
                                    false => West switch {
                                        true => 10130,
                                        false => 10131,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 10132,
                                        false => 10133,
                                    },
                                    false => West switch {
                                        true => 10134,
                                        false => 10135,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 10136,
                                        false => 10137,
                                    },
                                    false => West switch {
                                        true => 10138,
                                        false => 10139,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 10140,
                                        false => 10141,
                                    },
                                    false => West switch {
                                        true => 10142,
                                        false => 10143,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 10144,
                                        false => 10145,
                                    },
                                    false => West switch {
                                        true => 10146,
                                        false => 10147,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 10148,
                                        false => 10149,
                                    },
                                    false => West switch {
                                        true => 10150,
                                        false => 10151,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 10152,
                                        false => 10153,
                                    },
                                    false => West switch {
                                        true => 10154,
                                        false => 10155,
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
                                        true => 10156,
                                        false => 10157,
                                    },
                                    false => West switch {
                                        true => 10158,
                                        false => 10159,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 10160,
                                        false => 10161,
                                    },
                                    false => West switch {
                                        true => 10162,
                                        false => 10163,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 10164,
                                        false => 10165,
                                    },
                                    false => West switch {
                                        true => 10166,
                                        false => 10167,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 10168,
                                        false => 10169,
                                    },
                                    false => West switch {
                                        true => 10170,
                                        false => 10171,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 10172,
                                        false => 10173,
                                    },
                                    false => West switch {
                                        true => 10174,
                                        false => 10175,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 10176,
                                        false => 10177,
                                    },
                                    false => West switch {
                                        true => 10178,
                                        false => 10179,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 10180,
                                        false => 10181,
                                    },
                                    false => West switch {
                                        true => 10182,
                                        false => 10183,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 10184,
                                        false => 10185,
                                    },
                                    false => West switch {
                                        true => 10186,
                                        false => 10187,
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
                                        true => 10188,
                                        false => 10189,
                                    },
                                    false => West switch {
                                        true => 10190,
                                        false => 10191,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 10192,
                                        false => 10193,
                                    },
                                    false => West switch {
                                        true => 10194,
                                        false => 10195,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 10196,
                                        false => 10197,
                                    },
                                    false => West switch {
                                        true => 10198,
                                        false => 10199,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 10200,
                                        false => 10201,
                                    },
                                    false => West switch {
                                        true => 10202,
                                        false => 10203,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 10204,
                                        false => 10205,
                                    },
                                    false => West switch {
                                        true => 10206,
                                        false => 10207,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 10208,
                                        false => 10209,
                                    },
                                    false => West switch {
                                        true => 10210,
                                        false => 10211,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 10212,
                                        false => 10213,
                                    },
                                    false => West switch {
                                        true => 10214,
                                        false => 10215,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 10216,
                                        false => 10217,
                                    },
                                    false => West switch {
                                        true => 10218,
                                        false => 10219,
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
                                        true => 10220,
                                        false => 10221,
                                    },
                                    false => West switch {
                                        true => 10222,
                                        false => 10223,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 10224,
                                        false => 10225,
                                    },
                                    false => West switch {
                                        true => 10226,
                                        false => 10227,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 10228,
                                        false => 10229,
                                    },
                                    false => West switch {
                                        true => 10230,
                                        false => 10231,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 10232,
                                        false => 10233,
                                    },
                                    false => West switch {
                                        true => 10234,
                                        false => 10235,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 10236,
                                        false => 10237,
                                    },
                                    false => West switch {
                                        true => 10238,
                                        false => 10239,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 10240,
                                        false => 10241,
                                    },
                                    false => West switch {
                                        true => 10242,
                                        false => 10243,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 10244,
                                        false => 10245,
                                    },
                                    false => West switch {
                                        true => 10246,
                                        false => 10247,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 10248,
                                        false => 10249,
                                    },
                                    false => West switch {
                                        true => 10250,
                                        false => 10251,
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
            10124 => new GlowLichenBlock(Identifier, true, true, true, true, true, true, true),
            10125 => new GlowLichenBlock(Identifier, true, true, true, true, true, true, false),
            10126 => new GlowLichenBlock(Identifier, true, true, true, true, true, false, true),
            10127 => new GlowLichenBlock(Identifier, true, true, true, true, true, false, false),
            10128 => new GlowLichenBlock(Identifier, true, true, true, true, false, true, true),
            10129 => new GlowLichenBlock(Identifier, true, true, true, true, false, true, false),
            10130 => new GlowLichenBlock(Identifier, true, true, true, true, false, false, true),
            10131 => new GlowLichenBlock(Identifier, true, true, true, true, false, false, false),
            10132 => new GlowLichenBlock(Identifier, true, true, true, false, true, true, true),
            10133 => new GlowLichenBlock(Identifier, true, true, true, false, true, true, false),
            10134 => new GlowLichenBlock(Identifier, true, true, true, false, true, false, true),
            10135 => new GlowLichenBlock(Identifier, true, true, true, false, true, false, false),
            10136 => new GlowLichenBlock(Identifier, true, true, true, false, false, true, true),
            10137 => new GlowLichenBlock(Identifier, true, true, true, false, false, true, false),
            10138 => new GlowLichenBlock(Identifier, true, true, true, false, false, false, true),
            10139 => new GlowLichenBlock(Identifier, true, true, true, false, false, false, false),
            10140 => new GlowLichenBlock(Identifier, true, true, false, true, true, true, true),
            10141 => new GlowLichenBlock(Identifier, true, true, false, true, true, true, false),
            10142 => new GlowLichenBlock(Identifier, true, true, false, true, true, false, true),
            10143 => new GlowLichenBlock(Identifier, true, true, false, true, true, false, false),
            10144 => new GlowLichenBlock(Identifier, true, true, false, true, false, true, true),
            10145 => new GlowLichenBlock(Identifier, true, true, false, true, false, true, false),
            10146 => new GlowLichenBlock(Identifier, true, true, false, true, false, false, true),
            10147 => new GlowLichenBlock(Identifier, true, true, false, true, false, false, false),
            10148 => new GlowLichenBlock(Identifier, true, true, false, false, true, true, true),
            10149 => new GlowLichenBlock(Identifier, true, true, false, false, true, true, false),
            10150 => new GlowLichenBlock(Identifier, true, true, false, false, true, false, true),
            10151 => new GlowLichenBlock(Identifier, true, true, false, false, true, false, false),
            10152 => new GlowLichenBlock(Identifier, true, true, false, false, false, true, true),
            10153 => new GlowLichenBlock(Identifier, true, true, false, false, false, true, false),
            10154 => new GlowLichenBlock(Identifier, true, true, false, false, false, false, true),
            10155 => new GlowLichenBlock(Identifier, true, true, false, false, false, false, false),
            10156 => new GlowLichenBlock(Identifier, true, false, true, true, true, true, true),
            10157 => new GlowLichenBlock(Identifier, true, false, true, true, true, true, false),
            10158 => new GlowLichenBlock(Identifier, true, false, true, true, true, false, true),
            10159 => new GlowLichenBlock(Identifier, true, false, true, true, true, false, false),
            10160 => new GlowLichenBlock(Identifier, true, false, true, true, false, true, true),
            10161 => new GlowLichenBlock(Identifier, true, false, true, true, false, true, false),
            10162 => new GlowLichenBlock(Identifier, true, false, true, true, false, false, true),
            10163 => new GlowLichenBlock(Identifier, true, false, true, true, false, false, false),
            10164 => new GlowLichenBlock(Identifier, true, false, true, false, true, true, true),
            10165 => new GlowLichenBlock(Identifier, true, false, true, false, true, true, false),
            10166 => new GlowLichenBlock(Identifier, true, false, true, false, true, false, true),
            10167 => new GlowLichenBlock(Identifier, true, false, true, false, true, false, false),
            10168 => new GlowLichenBlock(Identifier, true, false, true, false, false, true, true),
            10169 => new GlowLichenBlock(Identifier, true, false, true, false, false, true, false),
            10170 => new GlowLichenBlock(Identifier, true, false, true, false, false, false, true),
            10171 => new GlowLichenBlock(Identifier, true, false, true, false, false, false, false),
            10172 => new GlowLichenBlock(Identifier, true, false, false, true, true, true, true),
            10173 => new GlowLichenBlock(Identifier, true, false, false, true, true, true, false),
            10174 => new GlowLichenBlock(Identifier, true, false, false, true, true, false, true),
            10175 => new GlowLichenBlock(Identifier, true, false, false, true, true, false, false),
            10176 => new GlowLichenBlock(Identifier, true, false, false, true, false, true, true),
            10177 => new GlowLichenBlock(Identifier, true, false, false, true, false, true, false),
            10178 => new GlowLichenBlock(Identifier, true, false, false, true, false, false, true),
            10179 => new GlowLichenBlock(Identifier, true, false, false, true, false, false, false),
            10180 => new GlowLichenBlock(Identifier, true, false, false, false, true, true, true),
            10181 => new GlowLichenBlock(Identifier, true, false, false, false, true, true, false),
            10182 => new GlowLichenBlock(Identifier, true, false, false, false, true, false, true),
            10183 => new GlowLichenBlock(Identifier, true, false, false, false, true, false, false),
            10184 => new GlowLichenBlock(Identifier, true, false, false, false, false, true, true),
            10185 => new GlowLichenBlock(Identifier, true, false, false, false, false, true, false),
            10186 => new GlowLichenBlock(Identifier, true, false, false, false, false, false, true),
            10187 => new GlowLichenBlock(Identifier, true, false, false, false, false, false, false),
            10188 => new GlowLichenBlock(Identifier, false, true, true, true, true, true, true),
            10189 => new GlowLichenBlock(Identifier, false, true, true, true, true, true, false),
            10190 => new GlowLichenBlock(Identifier, false, true, true, true, true, false, true),
            10191 => new GlowLichenBlock(Identifier, false, true, true, true, true, false, false),
            10192 => new GlowLichenBlock(Identifier, false, true, true, true, false, true, true),
            10193 => new GlowLichenBlock(Identifier, false, true, true, true, false, true, false),
            10194 => new GlowLichenBlock(Identifier, false, true, true, true, false, false, true),
            10195 => new GlowLichenBlock(Identifier, false, true, true, true, false, false, false),
            10196 => new GlowLichenBlock(Identifier, false, true, true, false, true, true, true),
            10197 => new GlowLichenBlock(Identifier, false, true, true, false, true, true, false),
            10198 => new GlowLichenBlock(Identifier, false, true, true, false, true, false, true),
            10199 => new GlowLichenBlock(Identifier, false, true, true, false, true, false, false),
            10200 => new GlowLichenBlock(Identifier, false, true, true, false, false, true, true),
            10201 => new GlowLichenBlock(Identifier, false, true, true, false, false, true, false),
            10202 => new GlowLichenBlock(Identifier, false, true, true, false, false, false, true),
            10203 => new GlowLichenBlock(Identifier, false, true, true, false, false, false, false),
            10204 => new GlowLichenBlock(Identifier, false, true, false, true, true, true, true),
            10205 => new GlowLichenBlock(Identifier, false, true, false, true, true, true, false),
            10206 => new GlowLichenBlock(Identifier, false, true, false, true, true, false, true),
            10207 => new GlowLichenBlock(Identifier, false, true, false, true, true, false, false),
            10208 => new GlowLichenBlock(Identifier, false, true, false, true, false, true, true),
            10209 => new GlowLichenBlock(Identifier, false, true, false, true, false, true, false),
            10210 => new GlowLichenBlock(Identifier, false, true, false, true, false, false, true),
            10211 => new GlowLichenBlock(Identifier, false, true, false, true, false, false, false),
            10212 => new GlowLichenBlock(Identifier, false, true, false, false, true, true, true),
            10213 => new GlowLichenBlock(Identifier, false, true, false, false, true, true, false),
            10214 => new GlowLichenBlock(Identifier, false, true, false, false, true, false, true),
            10215 => new GlowLichenBlock(Identifier, false, true, false, false, true, false, false),
            10216 => new GlowLichenBlock(Identifier, false, true, false, false, false, true, true),
            10217 => new GlowLichenBlock(Identifier, false, true, false, false, false, true, false),
            10218 => new GlowLichenBlock(Identifier, false, true, false, false, false, false, true),
            10219 => new GlowLichenBlock(Identifier, false, true, false, false, false, false, false),
            10220 => new GlowLichenBlock(Identifier, false, false, true, true, true, true, true),
            10221 => new GlowLichenBlock(Identifier, false, false, true, true, true, true, false),
            10222 => new GlowLichenBlock(Identifier, false, false, true, true, true, false, true),
            10223 => new GlowLichenBlock(Identifier, false, false, true, true, true, false, false),
            10224 => new GlowLichenBlock(Identifier, false, false, true, true, false, true, true),
            10225 => new GlowLichenBlock(Identifier, false, false, true, true, false, true, false),
            10226 => new GlowLichenBlock(Identifier, false, false, true, true, false, false, true),
            10227 => new GlowLichenBlock(Identifier, false, false, true, true, false, false, false),
            10228 => new GlowLichenBlock(Identifier, false, false, true, false, true, true, true),
            10229 => new GlowLichenBlock(Identifier, false, false, true, false, true, true, false),
            10230 => new GlowLichenBlock(Identifier, false, false, true, false, true, false, true),
            10231 => new GlowLichenBlock(Identifier, false, false, true, false, true, false, false),
            10232 => new GlowLichenBlock(Identifier, false, false, true, false, false, true, true),
            10233 => new GlowLichenBlock(Identifier, false, false, true, false, false, true, false),
            10234 => new GlowLichenBlock(Identifier, false, false, true, false, false, false, true),
            10235 => new GlowLichenBlock(Identifier, false, false, true, false, false, false, false),
            10236 => new GlowLichenBlock(Identifier, false, false, false, true, true, true, true),
            10237 => new GlowLichenBlock(Identifier, false, false, false, true, true, true, false),
            10238 => new GlowLichenBlock(Identifier, false, false, false, true, true, false, true),
            10239 => new GlowLichenBlock(Identifier, false, false, false, true, true, false, false),
            10240 => new GlowLichenBlock(Identifier, false, false, false, true, false, true, true),
            10241 => new GlowLichenBlock(Identifier, false, false, false, true, false, true, false),
            10242 => new GlowLichenBlock(Identifier, false, false, false, true, false, false, true),
            10243 => new GlowLichenBlock(Identifier, false, false, false, true, false, false, false),
            10244 => new GlowLichenBlock(Identifier, false, false, false, false, true, true, true),
            10245 => new GlowLichenBlock(Identifier, false, false, false, false, true, true, false),
            10246 => new GlowLichenBlock(Identifier, false, false, false, false, true, false, true),
            10247 => new GlowLichenBlock(Identifier, false, false, false, false, true, false, false),
            10248 => new GlowLichenBlock(Identifier, false, false, false, false, false, true, true),
            10249 => new GlowLichenBlock(Identifier, false, false, false, false, false, true, false),
            10250 => new GlowLichenBlock(Identifier, false, false, false, false, false, false, true),
            10251 => new GlowLichenBlock(Identifier, false, false, false, false, false, false, false),
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
