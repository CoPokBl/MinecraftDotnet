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
public record GreenConcreteStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.green_concrete_stairs", 1.8f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:green_concrete_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/green_concrete_stairs");
    private static readonly BlockStateInfo I0 = new(1.8f, 0, 1, PushReaction.PushPull, 27, "stone", NoteBlockInstrument.Basedrum, false, true, true, false, false, false, false, true, false, false, false, false, false, true, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 18067];

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
                            true => 18067,
                            false => 18068,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 18069,
                            false => 18070,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 18071,
                            false => 18072,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 18073,
                            false => 18074,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 18075,
                            false => 18076,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 18077,
                            false => 18078,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 18079,
                            false => 18080,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 18081,
                            false => 18082,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 18083,
                            false => 18084,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 18085,
                            false => 18086,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 18087,
                            false => 18088,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 18089,
                            false => 18090,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 18091,
                            false => 18092,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 18093,
                            false => 18094,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 18095,
                            false => 18096,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 18097,
                            false => 18098,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 18099,
                            false => 18100,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 18101,
                            false => 18102,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 18103,
                            false => 18104,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 18105,
                            false => 18106,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 18107,
                            false => 18108,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 18109,
                            false => 18110,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 18111,
                            false => 18112,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 18113,
                            false => 18114,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 18115,
                            false => 18116,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 18117,
                            false => 18118,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 18119,
                            false => 18120,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 18121,
                            false => 18122,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 18123,
                            false => 18124,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 18125,
                            false => 18126,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 18127,
                            false => 18128,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 18129,
                            false => 18130,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 18131,
                            false => 18132,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 18133,
                            false => 18134,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 18135,
                            false => 18136,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 18137,
                            false => 18138,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 18139,
                            false => 18140,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 18141,
                            false => 18142,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 18143,
                            false => 18144,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 18145,
                            false => 18146,
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
            18067 => new GreenConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            18068 => new GreenConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            18069 => new GreenConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            18070 => new GreenConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            18071 => new GreenConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            18072 => new GreenConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            18073 => new GreenConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            18074 => new GreenConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            18075 => new GreenConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            18076 => new GreenConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            18077 => new GreenConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            18078 => new GreenConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            18079 => new GreenConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            18080 => new GreenConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            18081 => new GreenConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            18082 => new GreenConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            18083 => new GreenConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            18084 => new GreenConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            18085 => new GreenConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            18086 => new GreenConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            18087 => new GreenConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            18088 => new GreenConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            18089 => new GreenConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            18090 => new GreenConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            18091 => new GreenConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            18092 => new GreenConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            18093 => new GreenConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            18094 => new GreenConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            18095 => new GreenConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            18096 => new GreenConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            18097 => new GreenConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            18098 => new GreenConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            18099 => new GreenConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            18100 => new GreenConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            18101 => new GreenConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            18102 => new GreenConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            18103 => new GreenConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            18104 => new GreenConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            18105 => new GreenConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            18106 => new GreenConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            18107 => new GreenConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            18108 => new GreenConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            18109 => new GreenConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            18110 => new GreenConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            18111 => new GreenConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            18112 => new GreenConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            18113 => new GreenConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            18114 => new GreenConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            18115 => new GreenConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            18116 => new GreenConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            18117 => new GreenConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            18118 => new GreenConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            18119 => new GreenConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            18120 => new GreenConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            18121 => new GreenConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            18122 => new GreenConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            18123 => new GreenConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            18124 => new GreenConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            18125 => new GreenConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            18126 => new GreenConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            18127 => new GreenConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            18128 => new GreenConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            18129 => new GreenConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            18130 => new GreenConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            18131 => new GreenConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            18132 => new GreenConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            18133 => new GreenConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            18134 => new GreenConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            18135 => new GreenConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            18136 => new GreenConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            18137 => new GreenConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            18138 => new GreenConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            18139 => new GreenConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            18140 => new GreenConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            18141 => new GreenConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            18142 => new GreenConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            18143 => new GreenConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            18144 => new GreenConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            18145 => new GreenConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            18146 => new GreenConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
