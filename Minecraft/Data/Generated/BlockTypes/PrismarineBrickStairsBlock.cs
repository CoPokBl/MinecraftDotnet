using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PrismarineBrickStairsBlock(Identifier Identifier, Direction Facing, PrismarineBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:stair", "block.minecraft.prismarine_brick_stairs", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:prismarine_brick_stairs", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 1, PushReaction.Normal, 31, "stone", NoteBlockInstrument.Basedrum, false, true, true, true, false, false, false, false, true, false, false, false, false, false, true, null, "minecraft:water", BlockShapes.S88, BlockShapes.S88, BlockShapes.S1, BlockShapes.S88, BlockShapes.S88);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S89, CollisionShape = BlockShapes.S89, OcclusionShape = BlockShapes.S89, VisualShape = BlockShapes.S89 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S89, CollisionShape = BlockShapes.S89, OcclusionShape = BlockShapes.S89, VisualShape = BlockShapes.S89 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S90, CollisionShape = BlockShapes.S90, OcclusionShape = BlockShapes.S90, VisualShape = BlockShapes.S90 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S90, CollisionShape = BlockShapes.S90, OcclusionShape = BlockShapes.S90, VisualShape = BlockShapes.S90 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S91, CollisionShape = BlockShapes.S91, OcclusionShape = BlockShapes.S91, VisualShape = BlockShapes.S91 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S91, CollisionShape = BlockShapes.S91, OcclusionShape = BlockShapes.S91, VisualShape = BlockShapes.S91 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S92, CollisionShape = BlockShapes.S92, OcclusionShape = BlockShapes.S92, VisualShape = BlockShapes.S92 };
    private static readonly BlockStateInfo I9 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S92, CollisionShape = BlockShapes.S92, OcclusionShape = BlockShapes.S92, VisualShape = BlockShapes.S92 };
    private static readonly BlockStateInfo I10 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S93, CollisionShape = BlockShapes.S93, OcclusionShape = BlockShapes.S93, VisualShape = BlockShapes.S93 };
    private static readonly BlockStateInfo I11 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S93, CollisionShape = BlockShapes.S93, OcclusionShape = BlockShapes.S93, VisualShape = BlockShapes.S93 };
    private static readonly BlockStateInfo I12 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S94, CollisionShape = BlockShapes.S94, OcclusionShape = BlockShapes.S94, VisualShape = BlockShapes.S94 };
    private static readonly BlockStateInfo I13 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S94, CollisionShape = BlockShapes.S94, OcclusionShape = BlockShapes.S94, VisualShape = BlockShapes.S94 };
    private static readonly BlockStateInfo I14 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S95, CollisionShape = BlockShapes.S95, OcclusionShape = BlockShapes.S95, VisualShape = BlockShapes.S95 };
    private static readonly BlockStateInfo I15 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S95, CollisionShape = BlockShapes.S95, OcclusionShape = BlockShapes.S95, VisualShape = BlockShapes.S95 };
    private static readonly BlockStateInfo I16 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S96, CollisionShape = BlockShapes.S96, OcclusionShape = BlockShapes.S96, VisualShape = BlockShapes.S96 };
    private static readonly BlockStateInfo I17 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S96, CollisionShape = BlockShapes.S96, OcclusionShape = BlockShapes.S96, VisualShape = BlockShapes.S96 };
    private static readonly BlockStateInfo I18 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S97, CollisionShape = BlockShapes.S97, OcclusionShape = BlockShapes.S97, VisualShape = BlockShapes.S97 };
    private static readonly BlockStateInfo I19 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S97, CollisionShape = BlockShapes.S97, OcclusionShape = BlockShapes.S97, VisualShape = BlockShapes.S97 };
    private static readonly BlockStateInfo I20 = I0 with { BlockShape = BlockShapes.S98, CollisionShape = BlockShapes.S98, OcclusionShape = BlockShapes.S98, VisualShape = BlockShapes.S98 };
    private static readonly BlockStateInfo I21 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S98, CollisionShape = BlockShapes.S98, OcclusionShape = BlockShapes.S98, VisualShape = BlockShapes.S98 };
    private static readonly BlockStateInfo I22 = I0 with { BlockShape = BlockShapes.S99, CollisionShape = BlockShapes.S99, OcclusionShape = BlockShapes.S99, VisualShape = BlockShapes.S99 };
    private static readonly BlockStateInfo I23 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S99, CollisionShape = BlockShapes.S99, OcclusionShape = BlockShapes.S99, VisualShape = BlockShapes.S99 };
    private static readonly BlockStateInfo I24 = I0 with { BlockShape = BlockShapes.S100, CollisionShape = BlockShapes.S100, OcclusionShape = BlockShapes.S100, VisualShape = BlockShapes.S100 };
    private static readonly BlockStateInfo I25 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S100, CollisionShape = BlockShapes.S100, OcclusionShape = BlockShapes.S100, VisualShape = BlockShapes.S100 };
    private static readonly BlockStateInfo I26 = I0 with { BlockShape = BlockShapes.S101, CollisionShape = BlockShapes.S101, OcclusionShape = BlockShapes.S101, VisualShape = BlockShapes.S101 };
    private static readonly BlockStateInfo I27 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S101, CollisionShape = BlockShapes.S101, OcclusionShape = BlockShapes.S101, VisualShape = BlockShapes.S101 };
    private static readonly BlockStateInfo I28 = I0 with { BlockShape = BlockShapes.S102, CollisionShape = BlockShapes.S102, OcclusionShape = BlockShapes.S102, VisualShape = BlockShapes.S102 };
    private static readonly BlockStateInfo I29 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S102, CollisionShape = BlockShapes.S102, OcclusionShape = BlockShapes.S102, VisualShape = BlockShapes.S102 };
    private static readonly BlockStateInfo I30 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S103, CollisionShape = BlockShapes.S103, OcclusionShape = BlockShapes.S103, VisualShape = BlockShapes.S103 };
    private static readonly BlockStateInfo I31 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S103, CollisionShape = BlockShapes.S103, OcclusionShape = BlockShapes.S103, VisualShape = BlockShapes.S103 };
    private static readonly BlockStateInfo I32 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S104, CollisionShape = BlockShapes.S104, OcclusionShape = BlockShapes.S104, VisualShape = BlockShapes.S104 };
    private static readonly BlockStateInfo I33 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S104, CollisionShape = BlockShapes.S104, OcclusionShape = BlockShapes.S104, VisualShape = BlockShapes.S104 };
    private static readonly BlockStateInfo I34 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S105, CollisionShape = BlockShapes.S105, OcclusionShape = BlockShapes.S105, VisualShape = BlockShapes.S105 };
    private static readonly BlockStateInfo I35 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S105, CollisionShape = BlockShapes.S105, OcclusionShape = BlockShapes.S105, VisualShape = BlockShapes.S105 };
    private static readonly BlockStateInfo I36 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S106, CollisionShape = BlockShapes.S106, OcclusionShape = BlockShapes.S106, VisualShape = BlockShapes.S106 };
    private static readonly BlockStateInfo I37 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S106, CollisionShape = BlockShapes.S106, OcclusionShape = BlockShapes.S106, VisualShape = BlockShapes.S106 };
    private static readonly BlockStateInfo I38 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S107, CollisionShape = BlockShapes.S107, OcclusionShape = BlockShapes.S107, VisualShape = BlockShapes.S107 };
    private static readonly BlockStateInfo I39 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S107, CollisionShape = BlockShapes.S107, OcclusionShape = BlockShapes.S107, VisualShape = BlockShapes.S107 };
    private static readonly BlockStateInfo I40 = I0 with { BlockShape = BlockShapes.S108, CollisionShape = BlockShapes.S108, OcclusionShape = BlockShapes.S108, VisualShape = BlockShapes.S108 };
    private static readonly BlockStateInfo I41 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S108, CollisionShape = BlockShapes.S108, OcclusionShape = BlockShapes.S108, VisualShape = BlockShapes.S108 };
    private static readonly BlockStateInfo I42 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S109, CollisionShape = BlockShapes.S109, OcclusionShape = BlockShapes.S109, VisualShape = BlockShapes.S109 };
    private static readonly BlockStateInfo I43 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S109, CollisionShape = BlockShapes.S109, OcclusionShape = BlockShapes.S109, VisualShape = BlockShapes.S109 };
    private static readonly BlockStateInfo I44 = I0 with { BlockShape = BlockShapes.S110, CollisionShape = BlockShapes.S110, OcclusionShape = BlockShapes.S110, VisualShape = BlockShapes.S110 };
    private static readonly BlockStateInfo I45 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S110, CollisionShape = BlockShapes.S110, OcclusionShape = BlockShapes.S110, VisualShape = BlockShapes.S110 };
    private static readonly BlockStateInfo I46 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S111, CollisionShape = BlockShapes.S111, OcclusionShape = BlockShapes.S111, VisualShape = BlockShapes.S111 };
    private static readonly BlockStateInfo I47 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S111, CollisionShape = BlockShapes.S111, OcclusionShape = BlockShapes.S111, VisualShape = BlockShapes.S111 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I32, I33, I34, I35, I36, I37, I38, I39, I40, I41, I24, I25, I2, I3, I28, I29, I6, I7, I42, I43, I34, I35, I12, I13, I38, I39, I16, I17, I44, I45, I4, I5, I22, I23, I8, I9, I26, I27, I46, I47, I14, I15, I32, I33, I18, I19, I36, I37
    ];

    public BlockStateInfo StateInfo => States[StateId - 12714];

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
    public NoteBlockInstrument Instrument => StateInfo.Instrument;
    public Identifier? Fluid => StateInfo.Fluid;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12714,
                            false => 12715,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12716,
                            false => 12717,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12718,
                            false => 12719,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12720,
                            false => 12721,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12722,
                            false => 12723,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12724,
                            false => 12725,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12726,
                            false => 12727,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12728,
                            false => 12729,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12730,
                            false => 12731,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12732,
                            false => 12733,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12734,
                            false => 12735,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12736,
                            false => 12737,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12738,
                            false => 12739,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12740,
                            false => 12741,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12742,
                            false => 12743,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12744,
                            false => 12745,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12746,
                            false => 12747,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12748,
                            false => 12749,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12750,
                            false => 12751,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12752,
                            false => 12753,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12754,
                            false => 12755,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12756,
                            false => 12757,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12758,
                            false => 12759,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12760,
                            false => 12761,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12762,
                            false => 12763,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12764,
                            false => 12765,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12766,
                            false => 12767,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12768,
                            false => 12769,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12770,
                            false => 12771,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12772,
                            false => 12773,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12774,
                            false => 12775,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12776,
                            false => 12777,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12778,
                            false => 12779,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12780,
                            false => 12781,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12782,
                            false => 12783,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12784,
                            false => 12785,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12786,
                            false => 12787,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12788,
                            false => 12789,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12790,
                            false => 12791,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12792,
                            false => 12793,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12714 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            12715 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            12716 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            12717 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            12718 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            12719 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            12720 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            12721 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            12722 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            12723 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            12724 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            12725 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            12726 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            12727 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            12728 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            12729 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            12730 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            12731 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            12732 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            12733 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            12734 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            12735 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            12736 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            12737 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            12738 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            12739 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            12740 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            12741 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            12742 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            12743 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            12744 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            12745 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            12746 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            12747 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            12748 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            12749 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            12750 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            12751 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            12752 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            12753 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            12754 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            12755 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            12756 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            12757 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            12758 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            12759 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            12760 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            12761 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            12762 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            12763 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            12764 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            12765 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            12766 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            12767 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            12768 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            12769 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            12770 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            12771 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            12772 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            12773 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            12774 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            12775 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            12776 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            12777 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            12778 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            12779 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            12780 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            12781 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            12782 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            12783 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            12784 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            12785 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            12786 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            12787 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            12788 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            12789 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            12790 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            12791 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            12792 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            12793 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            HalfValue = properties.Contains("half") ? HalfFromString(properties["half"].GetString()) : HalfValue,
            Shape = properties.Contains("shape") ? StairShapeExtensions.FromString(properties["shape"].GetString()) : Shape,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("half", new StringTag(HalfToName(HalfValue))),
            ("shape", new StringTag(Shape.ToName())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
    public enum Half {
        Top,
        Bottom,
    }

    public static Half HalfFromString(string value) {
        return value switch {
            "top" => Half.Top,
            "bottom" => Half.Bottom,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Half.")
        };
    }

    public static string HalfToName(Half value) {
        return value switch {
            Half.Top => "top",
            Half.Bottom => "bottom",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Half value.")
        };
    }
}
