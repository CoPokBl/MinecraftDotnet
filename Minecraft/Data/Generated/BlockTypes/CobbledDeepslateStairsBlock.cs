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
public record CobbledDeepslateStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:stair", "block.minecraft.cobbled_deepslate_stairs", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:cobbled_deepslate_stairs", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(3.5f, 0, 1, PushReaction.Normal, 59, "deepslate", NoteBlockInstrument.Basedrum, false, true, true, true, false, false, false, false, true, false, false, false, false, false, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 30420];

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
                            true => 30420,
                            false => 30421,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 30422,
                            false => 30423,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 30424,
                            false => 30425,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 30426,
                            false => 30427,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 30428,
                            false => 30429,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 30430,
                            false => 30431,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 30432,
                            false => 30433,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 30434,
                            false => 30435,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 30436,
                            false => 30437,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 30438,
                            false => 30439,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 30440,
                            false => 30441,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 30442,
                            false => 30443,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 30444,
                            false => 30445,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 30446,
                            false => 30447,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 30448,
                            false => 30449,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 30450,
                            false => 30451,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 30452,
                            false => 30453,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 30454,
                            false => 30455,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 30456,
                            false => 30457,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 30458,
                            false => 30459,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 30460,
                            false => 30461,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 30462,
                            false => 30463,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 30464,
                            false => 30465,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 30466,
                            false => 30467,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 30468,
                            false => 30469,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 30470,
                            false => 30471,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 30472,
                            false => 30473,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 30474,
                            false => 30475,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 30476,
                            false => 30477,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 30478,
                            false => 30479,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 30480,
                            false => 30481,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 30482,
                            false => 30483,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 30484,
                            false => 30485,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 30486,
                            false => 30487,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 30488,
                            false => 30489,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 30490,
                            false => 30491,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 30492,
                            false => 30493,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 30494,
                            false => 30495,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 30496,
                            false => 30497,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 30498,
                            false => 30499,
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
            30420 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            30421 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            30422 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            30423 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            30424 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            30425 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            30426 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            30427 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            30428 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            30429 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            30430 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            30431 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            30432 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            30433 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            30434 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            30435 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            30436 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            30437 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            30438 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            30439 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            30440 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            30441 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            30442 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            30443 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            30444 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            30445 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            30446 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            30447 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            30448 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            30449 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            30450 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            30451 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            30452 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            30453 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            30454 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            30455 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            30456 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            30457 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            30458 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            30459 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            30460 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            30461 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            30462 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            30463 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            30464 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            30465 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            30466 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            30467 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            30468 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            30469 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            30470 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            30471 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            30472 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            30473 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            30474 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            30475 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            30476 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            30477 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            30478 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            30479 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            30480 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            30481 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            30482 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            30483 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            30484 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            30485 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            30486 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            30487 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            30488 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            30489 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            30490 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            30491 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            30492 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            30493 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            30494 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            30495 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            30496 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            30497 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            30498 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            30499 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
