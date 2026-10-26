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
public record LightGrayConcreteStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.light_gray_concrete_stairs", 1.8f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:light_gray_concrete_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/light_gray_concrete_stairs");
    private static readonly BlockStateInfo I0 = new(1.8f, 0, 1, PushReaction.PushPull, 22, "stone", NoteBlockInstrument.Basedrum, false, true, true, false, false, false, false, true, false, false, false, false, false, true, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 17667];

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
                            true => 17667,
                            false => 17668,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 17669,
                            false => 17670,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 17671,
                            false => 17672,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 17673,
                            false => 17674,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 17675,
                            false => 17676,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 17677,
                            false => 17678,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 17679,
                            false => 17680,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 17681,
                            false => 17682,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 17683,
                            false => 17684,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 17685,
                            false => 17686,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 17687,
                            false => 17688,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 17689,
                            false => 17690,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 17691,
                            false => 17692,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 17693,
                            false => 17694,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 17695,
                            false => 17696,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 17697,
                            false => 17698,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 17699,
                            false => 17700,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 17701,
                            false => 17702,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 17703,
                            false => 17704,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 17705,
                            false => 17706,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 17707,
                            false => 17708,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 17709,
                            false => 17710,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 17711,
                            false => 17712,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 17713,
                            false => 17714,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 17715,
                            false => 17716,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 17717,
                            false => 17718,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 17719,
                            false => 17720,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 17721,
                            false => 17722,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 17723,
                            false => 17724,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 17725,
                            false => 17726,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 17727,
                            false => 17728,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 17729,
                            false => 17730,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 17731,
                            false => 17732,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 17733,
                            false => 17734,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 17735,
                            false => 17736,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 17737,
                            false => 17738,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 17739,
                            false => 17740,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 17741,
                            false => 17742,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 17743,
                            false => 17744,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 17745,
                            false => 17746,
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
            17667 => new LightGrayConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            17668 => new LightGrayConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            17669 => new LightGrayConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            17670 => new LightGrayConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            17671 => new LightGrayConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            17672 => new LightGrayConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            17673 => new LightGrayConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            17674 => new LightGrayConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            17675 => new LightGrayConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            17676 => new LightGrayConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            17677 => new LightGrayConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            17678 => new LightGrayConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            17679 => new LightGrayConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            17680 => new LightGrayConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            17681 => new LightGrayConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            17682 => new LightGrayConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            17683 => new LightGrayConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            17684 => new LightGrayConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            17685 => new LightGrayConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            17686 => new LightGrayConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            17687 => new LightGrayConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            17688 => new LightGrayConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            17689 => new LightGrayConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            17690 => new LightGrayConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            17691 => new LightGrayConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            17692 => new LightGrayConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            17693 => new LightGrayConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            17694 => new LightGrayConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            17695 => new LightGrayConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            17696 => new LightGrayConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            17697 => new LightGrayConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            17698 => new LightGrayConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            17699 => new LightGrayConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            17700 => new LightGrayConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            17701 => new LightGrayConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            17702 => new LightGrayConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            17703 => new LightGrayConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            17704 => new LightGrayConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            17705 => new LightGrayConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            17706 => new LightGrayConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            17707 => new LightGrayConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            17708 => new LightGrayConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            17709 => new LightGrayConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            17710 => new LightGrayConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            17711 => new LightGrayConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            17712 => new LightGrayConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            17713 => new LightGrayConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            17714 => new LightGrayConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            17715 => new LightGrayConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            17716 => new LightGrayConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            17717 => new LightGrayConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            17718 => new LightGrayConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            17719 => new LightGrayConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            17720 => new LightGrayConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            17721 => new LightGrayConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            17722 => new LightGrayConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            17723 => new LightGrayConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            17724 => new LightGrayConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            17725 => new LightGrayConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            17726 => new LightGrayConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            17727 => new LightGrayConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            17728 => new LightGrayConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            17729 => new LightGrayConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            17730 => new LightGrayConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            17731 => new LightGrayConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            17732 => new LightGrayConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            17733 => new LightGrayConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            17734 => new LightGrayConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            17735 => new LightGrayConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            17736 => new LightGrayConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            17737 => new LightGrayConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            17738 => new LightGrayConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            17739 => new LightGrayConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            17740 => new LightGrayConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            17741 => new LightGrayConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            17742 => new LightGrayConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            17743 => new LightGrayConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            17744 => new LightGrayConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            17745 => new LightGrayConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            17746 => new LightGrayConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
