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
public record SmoothQuartzStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:stair", "block.minecraft.smooth_quartz_stairs", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:smooth_quartz_stairs", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.Normal, 14, "stone", NoteBlockInstrument.Basedrum, false, true, true, true, false, false, false, false, true, false, false, false, false, false, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S91, CollisionShape = BlockShapes.S91, OcclusionShape = BlockShapes.S91, VisualShape = BlockShapes.S91, SupportShape = BlockShapes.S91 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S91, CollisionShape = BlockShapes.S91, OcclusionShape = BlockShapes.S91, VisualShape = BlockShapes.S91, SupportShape = BlockShapes.S91 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S92, CollisionShape = BlockShapes.S92, OcclusionShape = BlockShapes.S92, VisualShape = BlockShapes.S92, SupportShape = BlockShapes.S92 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S92, CollisionShape = BlockShapes.S92, OcclusionShape = BlockShapes.S92, VisualShape = BlockShapes.S92, SupportShape = BlockShapes.S92 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S93, CollisionShape = BlockShapes.S93, OcclusionShape = BlockShapes.S93, VisualShape = BlockShapes.S93, SupportShape = BlockShapes.S93 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S93, CollisionShape = BlockShapes.S93, OcclusionShape = BlockShapes.S93, VisualShape = BlockShapes.S93, SupportShape = BlockShapes.S93 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S94, CollisionShape = BlockShapes.S94, OcclusionShape = BlockShapes.S94, VisualShape = BlockShapes.S94, SupportShape = BlockShapes.S94 };
    private static readonly BlockStateInfo I9 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S94, CollisionShape = BlockShapes.S94, OcclusionShape = BlockShapes.S94, VisualShape = BlockShapes.S94, SupportShape = BlockShapes.S94 };
    private static readonly BlockStateInfo I10 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S95, CollisionShape = BlockShapes.S95, OcclusionShape = BlockShapes.S95, VisualShape = BlockShapes.S95, SupportShape = BlockShapes.S95 };
    private static readonly BlockStateInfo I11 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S95, CollisionShape = BlockShapes.S95, OcclusionShape = BlockShapes.S95, VisualShape = BlockShapes.S95, SupportShape = BlockShapes.S95 };
    private static readonly BlockStateInfo I12 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S96, CollisionShape = BlockShapes.S96, OcclusionShape = BlockShapes.S96, VisualShape = BlockShapes.S96, SupportShape = BlockShapes.S96 };
    private static readonly BlockStateInfo I13 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S96, CollisionShape = BlockShapes.S96, OcclusionShape = BlockShapes.S96, VisualShape = BlockShapes.S96, SupportShape = BlockShapes.S96 };
    private static readonly BlockStateInfo I14 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S97, CollisionShape = BlockShapes.S97, OcclusionShape = BlockShapes.S97, VisualShape = BlockShapes.S97, SupportShape = BlockShapes.S97 };
    private static readonly BlockStateInfo I15 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S97, CollisionShape = BlockShapes.S97, OcclusionShape = BlockShapes.S97, VisualShape = BlockShapes.S97, SupportShape = BlockShapes.S97 };
    private static readonly BlockStateInfo I16 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S98, CollisionShape = BlockShapes.S98, OcclusionShape = BlockShapes.S98, VisualShape = BlockShapes.S98, SupportShape = BlockShapes.S98 };
    private static readonly BlockStateInfo I17 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S98, CollisionShape = BlockShapes.S98, OcclusionShape = BlockShapes.S98, VisualShape = BlockShapes.S98, SupportShape = BlockShapes.S98 };
    private static readonly BlockStateInfo I18 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S99, CollisionShape = BlockShapes.S99, OcclusionShape = BlockShapes.S99, VisualShape = BlockShapes.S99, SupportShape = BlockShapes.S99 };
    private static readonly BlockStateInfo I19 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S99, CollisionShape = BlockShapes.S99, OcclusionShape = BlockShapes.S99, VisualShape = BlockShapes.S99, SupportShape = BlockShapes.S99 };
    private static readonly BlockStateInfo I20 = I0 with { BlockShape = BlockShapes.S100, CollisionShape = BlockShapes.S100, OcclusionShape = BlockShapes.S100, VisualShape = BlockShapes.S100, SupportShape = BlockShapes.S100 };
    private static readonly BlockStateInfo I21 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S100, CollisionShape = BlockShapes.S100, OcclusionShape = BlockShapes.S100, VisualShape = BlockShapes.S100, SupportShape = BlockShapes.S100 };
    private static readonly BlockStateInfo I22 = I0 with { BlockShape = BlockShapes.S101, CollisionShape = BlockShapes.S101, OcclusionShape = BlockShapes.S101, VisualShape = BlockShapes.S101, SupportShape = BlockShapes.S101 };
    private static readonly BlockStateInfo I23 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S101, CollisionShape = BlockShapes.S101, OcclusionShape = BlockShapes.S101, VisualShape = BlockShapes.S101, SupportShape = BlockShapes.S101 };
    private static readonly BlockStateInfo I24 = I0 with { BlockShape = BlockShapes.S102, CollisionShape = BlockShapes.S102, OcclusionShape = BlockShapes.S102, VisualShape = BlockShapes.S102, SupportShape = BlockShapes.S102 };
    private static readonly BlockStateInfo I25 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S102, CollisionShape = BlockShapes.S102, OcclusionShape = BlockShapes.S102, VisualShape = BlockShapes.S102, SupportShape = BlockShapes.S102 };
    private static readonly BlockStateInfo I26 = I0 with { BlockShape = BlockShapes.S103, CollisionShape = BlockShapes.S103, OcclusionShape = BlockShapes.S103, VisualShape = BlockShapes.S103, SupportShape = BlockShapes.S103 };
    private static readonly BlockStateInfo I27 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S103, CollisionShape = BlockShapes.S103, OcclusionShape = BlockShapes.S103, VisualShape = BlockShapes.S103, SupportShape = BlockShapes.S103 };
    private static readonly BlockStateInfo I28 = I0 with { BlockShape = BlockShapes.S104, CollisionShape = BlockShapes.S104, OcclusionShape = BlockShapes.S104, VisualShape = BlockShapes.S104, SupportShape = BlockShapes.S104 };
    private static readonly BlockStateInfo I29 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S104, CollisionShape = BlockShapes.S104, OcclusionShape = BlockShapes.S104, VisualShape = BlockShapes.S104, SupportShape = BlockShapes.S104 };
    private static readonly BlockStateInfo I30 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S105, CollisionShape = BlockShapes.S105, OcclusionShape = BlockShapes.S105, VisualShape = BlockShapes.S105, SupportShape = BlockShapes.S105 };
    private static readonly BlockStateInfo I31 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S105, CollisionShape = BlockShapes.S105, OcclusionShape = BlockShapes.S105, VisualShape = BlockShapes.S105, SupportShape = BlockShapes.S105 };
    private static readonly BlockStateInfo I32 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S106, CollisionShape = BlockShapes.S106, OcclusionShape = BlockShapes.S106, VisualShape = BlockShapes.S106, SupportShape = BlockShapes.S106 };
    private static readonly BlockStateInfo I33 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S106, CollisionShape = BlockShapes.S106, OcclusionShape = BlockShapes.S106, VisualShape = BlockShapes.S106, SupportShape = BlockShapes.S106 };
    private static readonly BlockStateInfo I34 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S107, CollisionShape = BlockShapes.S107, OcclusionShape = BlockShapes.S107, VisualShape = BlockShapes.S107, SupportShape = BlockShapes.S107 };
    private static readonly BlockStateInfo I35 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S107, CollisionShape = BlockShapes.S107, OcclusionShape = BlockShapes.S107, VisualShape = BlockShapes.S107, SupportShape = BlockShapes.S107 };
    private static readonly BlockStateInfo I36 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S108, CollisionShape = BlockShapes.S108, OcclusionShape = BlockShapes.S108, VisualShape = BlockShapes.S108, SupportShape = BlockShapes.S108 };
    private static readonly BlockStateInfo I37 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S108, CollisionShape = BlockShapes.S108, OcclusionShape = BlockShapes.S108, VisualShape = BlockShapes.S108, SupportShape = BlockShapes.S108 };
    private static readonly BlockStateInfo I38 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S109, CollisionShape = BlockShapes.S109, OcclusionShape = BlockShapes.S109, VisualShape = BlockShapes.S109, SupportShape = BlockShapes.S109 };
    private static readonly BlockStateInfo I39 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S109, CollisionShape = BlockShapes.S109, OcclusionShape = BlockShapes.S109, VisualShape = BlockShapes.S109, SupportShape = BlockShapes.S109 };
    private static readonly BlockStateInfo I40 = I0 with { BlockShape = BlockShapes.S110, CollisionShape = BlockShapes.S110, OcclusionShape = BlockShapes.S110, VisualShape = BlockShapes.S110, SupportShape = BlockShapes.S110 };
    private static readonly BlockStateInfo I41 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S110, CollisionShape = BlockShapes.S110, OcclusionShape = BlockShapes.S110, VisualShape = BlockShapes.S110, SupportShape = BlockShapes.S110 };
    private static readonly BlockStateInfo I42 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S111, CollisionShape = BlockShapes.S111, OcclusionShape = BlockShapes.S111, VisualShape = BlockShapes.S111, SupportShape = BlockShapes.S111 };
    private static readonly BlockStateInfo I43 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S111, CollisionShape = BlockShapes.S111, OcclusionShape = BlockShapes.S111, VisualShape = BlockShapes.S111, SupportShape = BlockShapes.S111 };
    private static readonly BlockStateInfo I44 = I0 with { BlockShape = BlockShapes.S112, CollisionShape = BlockShapes.S112, OcclusionShape = BlockShapes.S112, VisualShape = BlockShapes.S112, SupportShape = BlockShapes.S112 };
    private static readonly BlockStateInfo I45 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S112, CollisionShape = BlockShapes.S112, OcclusionShape = BlockShapes.S112, VisualShape = BlockShapes.S112, SupportShape = BlockShapes.S112 };
    private static readonly BlockStateInfo I46 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S113, CollisionShape = BlockShapes.S113, OcclusionShape = BlockShapes.S113, VisualShape = BlockShapes.S113, SupportShape = BlockShapes.S113 };
    private static readonly BlockStateInfo I47 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S113, CollisionShape = BlockShapes.S113, OcclusionShape = BlockShapes.S113, VisualShape = BlockShapes.S113, SupportShape = BlockShapes.S113 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I32, I33, I34, I35, I36, I37, I38, I39, I40, I41, I24, I25, I2, I3, I28, I29, I6, I7, I42, I43, I34, I35, I12, I13, I38, I39, I16, I17, I44, I45, I4, I5, I22, I23, I8, I9, I26, I27, I46, I47, I14, I15, I32, I33, I18, I19, I36, I37
    ];

    public BlockStateInfo StateInfo => States[StateId - 15936];

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

    public IBlock WithFacing(Direction facing) => this with { Facing = facing };

    public IBlock WithHalf(TopBottom half) => this with { Half = half };

    public IBlock WithShape(StairShape shape) => this with { Shape = shape };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15936,
                            false => 15937,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15938,
                            false => 15939,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15940,
                            false => 15941,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15942,
                            false => 15943,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15944,
                            false => 15945,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15946,
                            false => 15947,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15948,
                            false => 15949,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15950,
                            false => 15951,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15952,
                            false => 15953,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15954,
                            false => 15955,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15956,
                            false => 15957,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15958,
                            false => 15959,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15960,
                            false => 15961,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15962,
                            false => 15963,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15964,
                            false => 15965,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15966,
                            false => 15967,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15968,
                            false => 15969,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15970,
                            false => 15971,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15972,
                            false => 15973,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15974,
                            false => 15975,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15976,
                            false => 15977,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15978,
                            false => 15979,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15980,
                            false => 15981,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15982,
                            false => 15983,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15984,
                            false => 15985,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15986,
                            false => 15987,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15988,
                            false => 15989,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15990,
                            false => 15991,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15992,
                            false => 15993,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15994,
                            false => 15995,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15996,
                            false => 15997,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15998,
                            false => 15999,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16000,
                            false => 16001,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16002,
                            false => 16003,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16004,
                            false => 16005,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16006,
                            false => 16007,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16008,
                            false => 16009,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16010,
                            false => 16011,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16012,
                            false => 16013,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16014,
                            false => 16015,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            15936 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            15937 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            15938 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            15939 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            15940 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            15941 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            15942 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            15943 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            15944 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            15945 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            15946 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            15947 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            15948 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            15949 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            15950 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            15951 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            15952 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            15953 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            15954 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            15955 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            15956 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            15957 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            15958 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            15959 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            15960 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            15961 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            15962 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            15963 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            15964 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            15965 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            15966 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            15967 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            15968 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            15969 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            15970 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            15971 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            15972 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            15973 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            15974 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            15975 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            15976 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            15977 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            15978 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            15979 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            15980 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            15981 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            15982 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            15983 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            15984 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            15985 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            15986 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            15987 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            15988 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            15989 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            15990 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            15991 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            15992 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            15993 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            15994 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            15995 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            15996 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            15997 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            15998 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            15999 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            16000 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            16001 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            16002 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            16003 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            16004 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            16005 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            16006 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            16007 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            16008 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            16009 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            16010 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            16011 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            16012 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            16013 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            16014 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            16015 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Half = properties.Contains("half") ? TopBottomExtensions.FromString(properties["half"].GetString()) : Half,
            Shape = properties.Contains("shape") ? StairShapeExtensions.FromString(properties["shape"].GetString()) : Shape,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("half", new StringTag(Half.ToName())),
            ("shape", new StringTag(Shape.ToName())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
