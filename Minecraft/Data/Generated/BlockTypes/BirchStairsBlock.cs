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
public record BirchStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:stair", "block.minecraft.birch_stairs", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:birch_stairs", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.Normal, 2, "wood", NoteBlockInstrument.Bass, false, true, false, true, false, false, false, false, true, false, false, false, false, false, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Flammable = true, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S91, CollisionShape = BlockShapes.S91, OcclusionShape = BlockShapes.S91, VisualShape = BlockShapes.S91, SupportShape = BlockShapes.S91 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S91, CollisionShape = BlockShapes.S91, OcclusionShape = BlockShapes.S91, VisualShape = BlockShapes.S91, SupportShape = BlockShapes.S91 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S92, CollisionShape = BlockShapes.S92, OcclusionShape = BlockShapes.S92, VisualShape = BlockShapes.S92, SupportShape = BlockShapes.S92 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S92, CollisionShape = BlockShapes.S92, OcclusionShape = BlockShapes.S92, VisualShape = BlockShapes.S92, SupportShape = BlockShapes.S92 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S93, CollisionShape = BlockShapes.S93, OcclusionShape = BlockShapes.S93, VisualShape = BlockShapes.S93, SupportShape = BlockShapes.S93 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S93, CollisionShape = BlockShapes.S93, OcclusionShape = BlockShapes.S93, VisualShape = BlockShapes.S93, SupportShape = BlockShapes.S93 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S94, CollisionShape = BlockShapes.S94, OcclusionShape = BlockShapes.S94, VisualShape = BlockShapes.S94, SupportShape = BlockShapes.S94 };
    private static readonly BlockStateInfo I9 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S94, CollisionShape = BlockShapes.S94, OcclusionShape = BlockShapes.S94, VisualShape = BlockShapes.S94, SupportShape = BlockShapes.S94 };
    private static readonly BlockStateInfo I10 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S95, CollisionShape = BlockShapes.S95, OcclusionShape = BlockShapes.S95, VisualShape = BlockShapes.S95, SupportShape = BlockShapes.S95 };
    private static readonly BlockStateInfo I11 = I0 with { LightDampening = 0, Flammable = true, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S95, CollisionShape = BlockShapes.S95, OcclusionShape = BlockShapes.S95, VisualShape = BlockShapes.S95, SupportShape = BlockShapes.S95 };
    private static readonly BlockStateInfo I12 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S96, CollisionShape = BlockShapes.S96, OcclusionShape = BlockShapes.S96, VisualShape = BlockShapes.S96, SupportShape = BlockShapes.S96 };
    private static readonly BlockStateInfo I13 = I0 with { LightDampening = 0, Flammable = true, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S96, CollisionShape = BlockShapes.S96, OcclusionShape = BlockShapes.S96, VisualShape = BlockShapes.S96, SupportShape = BlockShapes.S96 };
    private static readonly BlockStateInfo I14 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S97, CollisionShape = BlockShapes.S97, OcclusionShape = BlockShapes.S97, VisualShape = BlockShapes.S97, SupportShape = BlockShapes.S97 };
    private static readonly BlockStateInfo I15 = I0 with { LightDampening = 0, Flammable = true, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S97, CollisionShape = BlockShapes.S97, OcclusionShape = BlockShapes.S97, VisualShape = BlockShapes.S97, SupportShape = BlockShapes.S97 };
    private static readonly BlockStateInfo I16 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S98, CollisionShape = BlockShapes.S98, OcclusionShape = BlockShapes.S98, VisualShape = BlockShapes.S98, SupportShape = BlockShapes.S98 };
    private static readonly BlockStateInfo I17 = I0 with { LightDampening = 0, Flammable = true, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S98, CollisionShape = BlockShapes.S98, OcclusionShape = BlockShapes.S98, VisualShape = BlockShapes.S98, SupportShape = BlockShapes.S98 };
    private static readonly BlockStateInfo I18 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S99, CollisionShape = BlockShapes.S99, OcclusionShape = BlockShapes.S99, VisualShape = BlockShapes.S99, SupportShape = BlockShapes.S99 };
    private static readonly BlockStateInfo I19 = I0 with { LightDampening = 0, Flammable = true, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S99, CollisionShape = BlockShapes.S99, OcclusionShape = BlockShapes.S99, VisualShape = BlockShapes.S99, SupportShape = BlockShapes.S99 };
    private static readonly BlockStateInfo I20 = I0 with { BlockShape = BlockShapes.S100, CollisionShape = BlockShapes.S100, OcclusionShape = BlockShapes.S100, VisualShape = BlockShapes.S100, SupportShape = BlockShapes.S100 };
    private static readonly BlockStateInfo I21 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S100, CollisionShape = BlockShapes.S100, OcclusionShape = BlockShapes.S100, VisualShape = BlockShapes.S100, SupportShape = BlockShapes.S100 };
    private static readonly BlockStateInfo I22 = I0 with { BlockShape = BlockShapes.S101, CollisionShape = BlockShapes.S101, OcclusionShape = BlockShapes.S101, VisualShape = BlockShapes.S101, SupportShape = BlockShapes.S101 };
    private static readonly BlockStateInfo I23 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S101, CollisionShape = BlockShapes.S101, OcclusionShape = BlockShapes.S101, VisualShape = BlockShapes.S101, SupportShape = BlockShapes.S101 };
    private static readonly BlockStateInfo I24 = I0 with { BlockShape = BlockShapes.S102, CollisionShape = BlockShapes.S102, OcclusionShape = BlockShapes.S102, VisualShape = BlockShapes.S102, SupportShape = BlockShapes.S102 };
    private static readonly BlockStateInfo I25 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S102, CollisionShape = BlockShapes.S102, OcclusionShape = BlockShapes.S102, VisualShape = BlockShapes.S102, SupportShape = BlockShapes.S102 };
    private static readonly BlockStateInfo I26 = I0 with { BlockShape = BlockShapes.S103, CollisionShape = BlockShapes.S103, OcclusionShape = BlockShapes.S103, VisualShape = BlockShapes.S103, SupportShape = BlockShapes.S103 };
    private static readonly BlockStateInfo I27 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S103, CollisionShape = BlockShapes.S103, OcclusionShape = BlockShapes.S103, VisualShape = BlockShapes.S103, SupportShape = BlockShapes.S103 };
    private static readonly BlockStateInfo I28 = I0 with { BlockShape = BlockShapes.S104, CollisionShape = BlockShapes.S104, OcclusionShape = BlockShapes.S104, VisualShape = BlockShapes.S104, SupportShape = BlockShapes.S104 };
    private static readonly BlockStateInfo I29 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S104, CollisionShape = BlockShapes.S104, OcclusionShape = BlockShapes.S104, VisualShape = BlockShapes.S104, SupportShape = BlockShapes.S104 };
    private static readonly BlockStateInfo I30 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S105, CollisionShape = BlockShapes.S105, OcclusionShape = BlockShapes.S105, VisualShape = BlockShapes.S105, SupportShape = BlockShapes.S105 };
    private static readonly BlockStateInfo I31 = I0 with { LightDampening = 0, Flammable = true, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S105, CollisionShape = BlockShapes.S105, OcclusionShape = BlockShapes.S105, VisualShape = BlockShapes.S105, SupportShape = BlockShapes.S105 };
    private static readonly BlockStateInfo I32 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S106, CollisionShape = BlockShapes.S106, OcclusionShape = BlockShapes.S106, VisualShape = BlockShapes.S106, SupportShape = BlockShapes.S106 };
    private static readonly BlockStateInfo I33 = I0 with { LightDampening = 0, Flammable = true, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S106, CollisionShape = BlockShapes.S106, OcclusionShape = BlockShapes.S106, VisualShape = BlockShapes.S106, SupportShape = BlockShapes.S106 };
    private static readonly BlockStateInfo I34 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S107, CollisionShape = BlockShapes.S107, OcclusionShape = BlockShapes.S107, VisualShape = BlockShapes.S107, SupportShape = BlockShapes.S107 };
    private static readonly BlockStateInfo I35 = I0 with { LightDampening = 0, Flammable = true, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S107, CollisionShape = BlockShapes.S107, OcclusionShape = BlockShapes.S107, VisualShape = BlockShapes.S107, SupportShape = BlockShapes.S107 };
    private static readonly BlockStateInfo I36 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S108, CollisionShape = BlockShapes.S108, OcclusionShape = BlockShapes.S108, VisualShape = BlockShapes.S108, SupportShape = BlockShapes.S108 };
    private static readonly BlockStateInfo I37 = I0 with { LightDampening = 0, Flammable = true, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S108, CollisionShape = BlockShapes.S108, OcclusionShape = BlockShapes.S108, VisualShape = BlockShapes.S108, SupportShape = BlockShapes.S108 };
    private static readonly BlockStateInfo I38 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S109, CollisionShape = BlockShapes.S109, OcclusionShape = BlockShapes.S109, VisualShape = BlockShapes.S109, SupportShape = BlockShapes.S109 };
    private static readonly BlockStateInfo I39 = I0 with { LightDampening = 0, Flammable = true, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S109, CollisionShape = BlockShapes.S109, OcclusionShape = BlockShapes.S109, VisualShape = BlockShapes.S109, SupportShape = BlockShapes.S109 };
    private static readonly BlockStateInfo I40 = I0 with { BlockShape = BlockShapes.S110, CollisionShape = BlockShapes.S110, OcclusionShape = BlockShapes.S110, VisualShape = BlockShapes.S110, SupportShape = BlockShapes.S110 };
    private static readonly BlockStateInfo I41 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S110, CollisionShape = BlockShapes.S110, OcclusionShape = BlockShapes.S110, VisualShape = BlockShapes.S110, SupportShape = BlockShapes.S110 };
    private static readonly BlockStateInfo I42 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S111, CollisionShape = BlockShapes.S111, OcclusionShape = BlockShapes.S111, VisualShape = BlockShapes.S111, SupportShape = BlockShapes.S111 };
    private static readonly BlockStateInfo I43 = I0 with { LightDampening = 0, Flammable = true, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S111, CollisionShape = BlockShapes.S111, OcclusionShape = BlockShapes.S111, VisualShape = BlockShapes.S111, SupportShape = BlockShapes.S111 };
    private static readonly BlockStateInfo I44 = I0 with { BlockShape = BlockShapes.S112, CollisionShape = BlockShapes.S112, OcclusionShape = BlockShapes.S112, VisualShape = BlockShapes.S112, SupportShape = BlockShapes.S112 };
    private static readonly BlockStateInfo I45 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S112, CollisionShape = BlockShapes.S112, OcclusionShape = BlockShapes.S112, VisualShape = BlockShapes.S112, SupportShape = BlockShapes.S112 };
    private static readonly BlockStateInfo I46 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S113, CollisionShape = BlockShapes.S113, OcclusionShape = BlockShapes.S113, VisualShape = BlockShapes.S113, SupportShape = BlockShapes.S113 };
    private static readonly BlockStateInfo I47 = I0 with { LightDampening = 0, Flammable = true, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S113, CollisionShape = BlockShapes.S113, OcclusionShape = BlockShapes.S113, VisualShape = BlockShapes.S113, SupportShape = BlockShapes.S113 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I32, I33, I34, I35, I36, I37, I38, I39, I40, I41, I24, I25, I2, I3, I28, I29, I6, I7, I42, I43, I34, I35, I12, I13, I38, I39, I16, I17, I44, I45, I4, I5, I22, I23, I8, I9, I26, I27, I46, I47, I14, I15, I32, I33, I18, I19, I36, I37
    ];

    public BlockStateInfo StateInfo => States[StateId - 9808];

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
                            true => 9808,
                            false => 9809,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9810,
                            false => 9811,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9812,
                            false => 9813,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9814,
                            false => 9815,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9816,
                            false => 9817,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9818,
                            false => 9819,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9820,
                            false => 9821,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9822,
                            false => 9823,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9824,
                            false => 9825,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9826,
                            false => 9827,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9828,
                            false => 9829,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9830,
                            false => 9831,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9832,
                            false => 9833,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9834,
                            false => 9835,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9836,
                            false => 9837,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9838,
                            false => 9839,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9840,
                            false => 9841,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9842,
                            false => 9843,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9844,
                            false => 9845,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9846,
                            false => 9847,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9848,
                            false => 9849,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9850,
                            false => 9851,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9852,
                            false => 9853,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9854,
                            false => 9855,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9856,
                            false => 9857,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9858,
                            false => 9859,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9860,
                            false => 9861,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9862,
                            false => 9863,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9864,
                            false => 9865,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9866,
                            false => 9867,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9868,
                            false => 9869,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9870,
                            false => 9871,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9872,
                            false => 9873,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9874,
                            false => 9875,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9876,
                            false => 9877,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9878,
                            false => 9879,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9880,
                            false => 9881,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9882,
                            false => 9883,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9884,
                            false => 9885,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9886,
                            false => 9887,
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
            9808 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            9809 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            9810 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            9811 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            9812 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            9813 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            9814 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            9815 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            9816 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            9817 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            9818 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            9819 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            9820 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            9821 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            9822 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            9823 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            9824 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            9825 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            9826 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            9827 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            9828 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            9829 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            9830 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            9831 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            9832 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            9833 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            9834 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            9835 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            9836 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            9837 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            9838 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            9839 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            9840 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            9841 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            9842 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            9843 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            9844 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            9845 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            9846 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            9847 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            9848 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            9849 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            9850 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            9851 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            9852 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            9853 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            9854 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            9855 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            9856 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            9857 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            9858 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            9859 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            9860 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            9861 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            9862 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            9863 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            9864 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            9865 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            9866 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            9867 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            9868 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            9869 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            9870 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            9871 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            9872 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            9873 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            9874 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            9875 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            9876 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            9877 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            9878 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            9879 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            9880 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            9881 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            9882 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            9883 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            9884 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            9885 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            9886 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            9887 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
