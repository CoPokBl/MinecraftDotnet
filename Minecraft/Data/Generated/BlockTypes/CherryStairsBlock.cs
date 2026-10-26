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
public record CherryStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.cherry_stairs", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:cherry_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/cherry_stairs");
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.PushPull, 36, "cherry_wood", NoteBlockInstrument.Bass, false, true, false, false, false, false, false, true, false, false, false, false, false, true, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 13819];

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
                            true => 13819,
                            false => 13820,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13821,
                            false => 13822,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13823,
                            false => 13824,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13825,
                            false => 13826,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13827,
                            false => 13828,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13829,
                            false => 13830,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13831,
                            false => 13832,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13833,
                            false => 13834,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13835,
                            false => 13836,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13837,
                            false => 13838,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13839,
                            false => 13840,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13841,
                            false => 13842,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13843,
                            false => 13844,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13845,
                            false => 13846,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13847,
                            false => 13848,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13849,
                            false => 13850,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13851,
                            false => 13852,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13853,
                            false => 13854,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13855,
                            false => 13856,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13857,
                            false => 13858,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13859,
                            false => 13860,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13861,
                            false => 13862,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13863,
                            false => 13864,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13865,
                            false => 13866,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13867,
                            false => 13868,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13869,
                            false => 13870,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13871,
                            false => 13872,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13873,
                            false => 13874,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13875,
                            false => 13876,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13877,
                            false => 13878,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13879,
                            false => 13880,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13881,
                            false => 13882,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13883,
                            false => 13884,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13885,
                            false => 13886,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13887,
                            false => 13888,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13889,
                            false => 13890,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13891,
                            false => 13892,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13893,
                            false => 13894,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13895,
                            false => 13896,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13897,
                            false => 13898,
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
            13819 => new CherryStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            13820 => new CherryStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            13821 => new CherryStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            13822 => new CherryStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            13823 => new CherryStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            13824 => new CherryStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            13825 => new CherryStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            13826 => new CherryStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            13827 => new CherryStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            13828 => new CherryStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            13829 => new CherryStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            13830 => new CherryStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            13831 => new CherryStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            13832 => new CherryStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            13833 => new CherryStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            13834 => new CherryStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            13835 => new CherryStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            13836 => new CherryStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            13837 => new CherryStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            13838 => new CherryStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            13839 => new CherryStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            13840 => new CherryStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            13841 => new CherryStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            13842 => new CherryStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            13843 => new CherryStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            13844 => new CherryStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            13845 => new CherryStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            13846 => new CherryStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            13847 => new CherryStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            13848 => new CherryStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            13849 => new CherryStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            13850 => new CherryStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            13851 => new CherryStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            13852 => new CherryStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            13853 => new CherryStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            13854 => new CherryStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            13855 => new CherryStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            13856 => new CherryStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            13857 => new CherryStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            13858 => new CherryStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            13859 => new CherryStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            13860 => new CherryStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            13861 => new CherryStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            13862 => new CherryStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            13863 => new CherryStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            13864 => new CherryStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            13865 => new CherryStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            13866 => new CherryStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            13867 => new CherryStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            13868 => new CherryStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            13869 => new CherryStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            13870 => new CherryStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            13871 => new CherryStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            13872 => new CherryStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            13873 => new CherryStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            13874 => new CherryStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            13875 => new CherryStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            13876 => new CherryStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            13877 => new CherryStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            13878 => new CherryStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            13879 => new CherryStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            13880 => new CherryStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            13881 => new CherryStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            13882 => new CherryStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            13883 => new CherryStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            13884 => new CherryStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            13885 => new CherryStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            13886 => new CherryStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            13887 => new CherryStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            13888 => new CherryStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            13889 => new CherryStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            13890 => new CherryStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            13891 => new CherryStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            13892 => new CherryStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            13893 => new CherryStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            13894 => new CherryStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            13895 => new CherryStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            13896 => new CherryStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            13897 => new CherryStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            13898 => new CherryStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
