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
public record BlueConcreteStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.blue_concrete_stairs", 1.8f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:blue_concrete_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/blue_concrete_stairs");
    private static readonly BlockStateInfo I0 = new(1.8f, 0, 1, PushReaction.PushPull, 25, "stone", NoteBlockInstrument.Basedrum, false, true, true, false, false, false, false, true, false, false, false, false, false, true, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 17907];

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
                            true => 17907,
                            false => 17908,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 17909,
                            false => 17910,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 17911,
                            false => 17912,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 17913,
                            false => 17914,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 17915,
                            false => 17916,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 17917,
                            false => 17918,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 17919,
                            false => 17920,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 17921,
                            false => 17922,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 17923,
                            false => 17924,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 17925,
                            false => 17926,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 17927,
                            false => 17928,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 17929,
                            false => 17930,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 17931,
                            false => 17932,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 17933,
                            false => 17934,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 17935,
                            false => 17936,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 17937,
                            false => 17938,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 17939,
                            false => 17940,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 17941,
                            false => 17942,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 17943,
                            false => 17944,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 17945,
                            false => 17946,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 17947,
                            false => 17948,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 17949,
                            false => 17950,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 17951,
                            false => 17952,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 17953,
                            false => 17954,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 17955,
                            false => 17956,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 17957,
                            false => 17958,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 17959,
                            false => 17960,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 17961,
                            false => 17962,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 17963,
                            false => 17964,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 17965,
                            false => 17966,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 17967,
                            false => 17968,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 17969,
                            false => 17970,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 17971,
                            false => 17972,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 17973,
                            false => 17974,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 17975,
                            false => 17976,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 17977,
                            false => 17978,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 17979,
                            false => 17980,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 17981,
                            false => 17982,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 17983,
                            false => 17984,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 17985,
                            false => 17986,
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
            17907 => new BlueConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            17908 => new BlueConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            17909 => new BlueConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            17910 => new BlueConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            17911 => new BlueConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            17912 => new BlueConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            17913 => new BlueConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            17914 => new BlueConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            17915 => new BlueConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            17916 => new BlueConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            17917 => new BlueConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            17918 => new BlueConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            17919 => new BlueConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            17920 => new BlueConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            17921 => new BlueConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            17922 => new BlueConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            17923 => new BlueConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            17924 => new BlueConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            17925 => new BlueConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            17926 => new BlueConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            17927 => new BlueConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            17928 => new BlueConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            17929 => new BlueConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            17930 => new BlueConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            17931 => new BlueConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            17932 => new BlueConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            17933 => new BlueConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            17934 => new BlueConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            17935 => new BlueConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            17936 => new BlueConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            17937 => new BlueConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            17938 => new BlueConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            17939 => new BlueConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            17940 => new BlueConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            17941 => new BlueConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            17942 => new BlueConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            17943 => new BlueConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            17944 => new BlueConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            17945 => new BlueConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            17946 => new BlueConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            17947 => new BlueConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            17948 => new BlueConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            17949 => new BlueConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            17950 => new BlueConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            17951 => new BlueConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            17952 => new BlueConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            17953 => new BlueConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            17954 => new BlueConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            17955 => new BlueConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            17956 => new BlueConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            17957 => new BlueConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            17958 => new BlueConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            17959 => new BlueConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            17960 => new BlueConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            17961 => new BlueConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            17962 => new BlueConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            17963 => new BlueConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            17964 => new BlueConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            17965 => new BlueConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            17966 => new BlueConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            17967 => new BlueConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            17968 => new BlueConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            17969 => new BlueConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            17970 => new BlueConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            17971 => new BlueConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            17972 => new BlueConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            17973 => new BlueConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            17974 => new BlueConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            17975 => new BlueConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            17976 => new BlueConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            17977 => new BlueConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            17978 => new BlueConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            17979 => new BlueConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            17980 => new BlueConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            17981 => new BlueConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            17982 => new BlueConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            17983 => new BlueConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            17984 => new BlueConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            17985 => new BlueConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            17986 => new BlueConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
