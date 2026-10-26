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
public record PurpurStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.purpur_stairs", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:purpur_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/purpur_stairs");
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 1, PushReaction.PushPull, 16, "stone", NoteBlockInstrument.Basedrum, false, true, true, false, false, false, false, true, false, false, false, false, false, true, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 16697];

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
                            true => 16697,
                            false => 16698,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16699,
                            false => 16700,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16701,
                            false => 16702,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16703,
                            false => 16704,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16705,
                            false => 16706,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16707,
                            false => 16708,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16709,
                            false => 16710,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16711,
                            false => 16712,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16713,
                            false => 16714,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16715,
                            false => 16716,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16717,
                            false => 16718,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16719,
                            false => 16720,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16721,
                            false => 16722,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16723,
                            false => 16724,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16725,
                            false => 16726,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16727,
                            false => 16728,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16729,
                            false => 16730,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16731,
                            false => 16732,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16733,
                            false => 16734,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16735,
                            false => 16736,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16737,
                            false => 16738,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16739,
                            false => 16740,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16741,
                            false => 16742,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16743,
                            false => 16744,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16745,
                            false => 16746,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16747,
                            false => 16748,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16749,
                            false => 16750,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16751,
                            false => 16752,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16753,
                            false => 16754,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16755,
                            false => 16756,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16757,
                            false => 16758,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16759,
                            false => 16760,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16761,
                            false => 16762,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16763,
                            false => 16764,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16765,
                            false => 16766,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16767,
                            false => 16768,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16769,
                            false => 16770,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16771,
                            false => 16772,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16773,
                            false => 16774,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16775,
                            false => 16776,
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
            16697 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            16698 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            16699 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            16700 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            16701 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            16702 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            16703 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            16704 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            16705 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            16706 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            16707 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            16708 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            16709 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            16710 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            16711 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            16712 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            16713 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            16714 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            16715 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            16716 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            16717 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            16718 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            16719 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            16720 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            16721 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            16722 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            16723 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            16724 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            16725 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            16726 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            16727 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            16728 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            16729 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            16730 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            16731 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            16732 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            16733 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            16734 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            16735 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            16736 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            16737 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            16738 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            16739 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            16740 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            16741 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            16742 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            16743 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            16744 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            16745 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            16746 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            16747 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            16748 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            16749 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            16750 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            16751 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            16752 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            16753 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            16754 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            16755 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            16756 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            16757 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            16758 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            16759 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            16760 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            16761 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            16762 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            16763 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            16764 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            16765 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            16766 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            16767 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            16768 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            16769 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            16770 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            16771 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            16772 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            16773 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            16774 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            16775 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            16776 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
