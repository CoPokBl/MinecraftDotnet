using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SulfurBrickStairsBlock(Identifier Identifier, Direction Facing, SulfurBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:stair", "block.minecraft.sulfur_brick_stairs", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:sulfur_brick_stairs", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 1, PushReaction.Normal, 18, "sulfur", NoteBlockInstrument.Basedrum, false, true, true, true, false, false, false, false, true, false, false, false, false, false, true, null, "minecraft:water", BlockShapes.S88, BlockShapes.S88, BlockShapes.S1, BlockShapes.S88, BlockShapes.S88);
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

    public BlockStateInfo StateInfo => States[StateId - 25521];

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
                            true => 25521,
                            false => 25522,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25523,
                            false => 25524,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25525,
                            false => 25526,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25527,
                            false => 25528,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25529,
                            false => 25530,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25531,
                            false => 25532,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25533,
                            false => 25534,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25535,
                            false => 25536,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25537,
                            false => 25538,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25539,
                            false => 25540,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25541,
                            false => 25542,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25543,
                            false => 25544,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25545,
                            false => 25546,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25547,
                            false => 25548,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25549,
                            false => 25550,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25551,
                            false => 25552,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25553,
                            false => 25554,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25555,
                            false => 25556,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25557,
                            false => 25558,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25559,
                            false => 25560,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25561,
                            false => 25562,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25563,
                            false => 25564,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25565,
                            false => 25566,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25567,
                            false => 25568,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25569,
                            false => 25570,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25571,
                            false => 25572,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25573,
                            false => 25574,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25575,
                            false => 25576,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25577,
                            false => 25578,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25579,
                            false => 25580,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25581,
                            false => 25582,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25583,
                            false => 25584,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25585,
                            false => 25586,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25587,
                            false => 25588,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25589,
                            false => 25590,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25591,
                            false => 25592,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25593,
                            false => 25594,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25595,
                            false => 25596,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25597,
                            false => 25598,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25599,
                            false => 25600,
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
            25521 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            25522 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            25523 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            25524 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            25525 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            25526 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            25527 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            25528 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            25529 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            25530 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            25531 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            25532 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            25533 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            25534 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            25535 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            25536 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            25537 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            25538 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            25539 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            25540 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            25541 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            25542 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            25543 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            25544 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            25545 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            25546 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            25547 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            25548 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            25549 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            25550 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            25551 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            25552 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            25553 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            25554 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            25555 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            25556 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            25557 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            25558 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            25559 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            25560 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            25561 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            25562 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            25563 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            25564 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            25565 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            25566 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            25567 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            25568 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            25569 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            25570 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            25571 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            25572 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            25573 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            25574 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            25575 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            25576 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            25577 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            25578 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            25579 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            25580 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            25581 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            25582 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            25583 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            25584 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            25585 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            25586 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            25587 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            25588 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            25589 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            25590 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            25591 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            25592 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            25593 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            25594 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            25595 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            25596 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            25597 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            25598 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            25599 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            25600 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
