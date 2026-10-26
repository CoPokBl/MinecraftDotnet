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
public record CrimsonStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.crimson_stairs", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:crimson_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/crimson_stairs");
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.PushPull, 53, "nether_wood", NoteBlockInstrument.Bass, false, true, false, false, false, false, false, true, false, false, false, false, false, true, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 24663];

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
                            true => 24663,
                            false => 24664,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24665,
                            false => 24666,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24667,
                            false => 24668,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24669,
                            false => 24670,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24671,
                            false => 24672,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24673,
                            false => 24674,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24675,
                            false => 24676,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24677,
                            false => 24678,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24679,
                            false => 24680,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24681,
                            false => 24682,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24683,
                            false => 24684,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24685,
                            false => 24686,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24687,
                            false => 24688,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24689,
                            false => 24690,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24691,
                            false => 24692,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24693,
                            false => 24694,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24695,
                            false => 24696,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24697,
                            false => 24698,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24699,
                            false => 24700,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24701,
                            false => 24702,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24703,
                            false => 24704,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24705,
                            false => 24706,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24707,
                            false => 24708,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24709,
                            false => 24710,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24711,
                            false => 24712,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24713,
                            false => 24714,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24715,
                            false => 24716,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24717,
                            false => 24718,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24719,
                            false => 24720,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24721,
                            false => 24722,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24723,
                            false => 24724,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24725,
                            false => 24726,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24727,
                            false => 24728,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24729,
                            false => 24730,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24731,
                            false => 24732,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24733,
                            false => 24734,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24735,
                            false => 24736,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24737,
                            false => 24738,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24739,
                            false => 24740,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24741,
                            false => 24742,
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
            24663 => new CrimsonStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            24664 => new CrimsonStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            24665 => new CrimsonStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            24666 => new CrimsonStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            24667 => new CrimsonStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            24668 => new CrimsonStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            24669 => new CrimsonStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            24670 => new CrimsonStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            24671 => new CrimsonStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            24672 => new CrimsonStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            24673 => new CrimsonStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            24674 => new CrimsonStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            24675 => new CrimsonStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            24676 => new CrimsonStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            24677 => new CrimsonStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            24678 => new CrimsonStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            24679 => new CrimsonStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            24680 => new CrimsonStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            24681 => new CrimsonStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            24682 => new CrimsonStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            24683 => new CrimsonStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            24684 => new CrimsonStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            24685 => new CrimsonStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            24686 => new CrimsonStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            24687 => new CrimsonStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            24688 => new CrimsonStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            24689 => new CrimsonStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            24690 => new CrimsonStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            24691 => new CrimsonStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            24692 => new CrimsonStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            24693 => new CrimsonStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            24694 => new CrimsonStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            24695 => new CrimsonStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            24696 => new CrimsonStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            24697 => new CrimsonStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            24698 => new CrimsonStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            24699 => new CrimsonStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            24700 => new CrimsonStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            24701 => new CrimsonStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            24702 => new CrimsonStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            24703 => new CrimsonStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            24704 => new CrimsonStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            24705 => new CrimsonStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            24706 => new CrimsonStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            24707 => new CrimsonStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            24708 => new CrimsonStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            24709 => new CrimsonStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            24710 => new CrimsonStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            24711 => new CrimsonStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            24712 => new CrimsonStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            24713 => new CrimsonStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            24714 => new CrimsonStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            24715 => new CrimsonStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            24716 => new CrimsonStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            24717 => new CrimsonStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            24718 => new CrimsonStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            24719 => new CrimsonStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            24720 => new CrimsonStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            24721 => new CrimsonStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            24722 => new CrimsonStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            24723 => new CrimsonStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            24724 => new CrimsonStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            24725 => new CrimsonStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            24726 => new CrimsonStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            24727 => new CrimsonStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            24728 => new CrimsonStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            24729 => new CrimsonStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            24730 => new CrimsonStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            24731 => new CrimsonStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            24732 => new CrimsonStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            24733 => new CrimsonStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            24734 => new CrimsonStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            24735 => new CrimsonStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            24736 => new CrimsonStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            24737 => new CrimsonStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            24738 => new CrimsonStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            24739 => new CrimsonStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            24740 => new CrimsonStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            24741 => new CrimsonStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            24742 => new CrimsonStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
