using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SmoothRedSandstoneStairsBlock(Identifier Identifier, Direction Facing, SmoothRedSandstoneStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:stair", "block.minecraft.smooth_red_sandstone_stairs", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:smooth_red_sandstone_stairs", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.Normal, 15, "stone", NoteBlockInstrument.Basedrum, false, true, true, true, false, false, false, false, true, false, false, false, false, false, true, null, "minecraft:water", BlockShapes.S88, BlockShapes.S88, BlockShapes.S1, BlockShapes.S88, BlockShapes.S88);
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

    public BlockStateInfo StateInfo => States[StateId - 15376];

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
                            true => 15376,
                            false => 15377,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15378,
                            false => 15379,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15380,
                            false => 15381,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15382,
                            false => 15383,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15384,
                            false => 15385,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15386,
                            false => 15387,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15388,
                            false => 15389,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15390,
                            false => 15391,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15392,
                            false => 15393,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15394,
                            false => 15395,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15396,
                            false => 15397,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15398,
                            false => 15399,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15400,
                            false => 15401,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15402,
                            false => 15403,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15404,
                            false => 15405,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15406,
                            false => 15407,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15408,
                            false => 15409,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15410,
                            false => 15411,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15412,
                            false => 15413,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15414,
                            false => 15415,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15416,
                            false => 15417,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15418,
                            false => 15419,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15420,
                            false => 15421,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15422,
                            false => 15423,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15424,
                            false => 15425,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15426,
                            false => 15427,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15428,
                            false => 15429,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15430,
                            false => 15431,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15432,
                            false => 15433,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15434,
                            false => 15435,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15436,
                            false => 15437,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15438,
                            false => 15439,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15440,
                            false => 15441,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15442,
                            false => 15443,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15444,
                            false => 15445,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15446,
                            false => 15447,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15448,
                            false => 15449,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15450,
                            false => 15451,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15452,
                            false => 15453,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15454,
                            false => 15455,
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
            15376 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            15377 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            15378 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            15379 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            15380 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            15381 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            15382 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            15383 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            15384 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            15385 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            15386 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            15387 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            15388 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            15389 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            15390 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            15391 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            15392 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            15393 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            15394 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            15395 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            15396 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            15397 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            15398 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            15399 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            15400 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            15401 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            15402 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            15403 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            15404 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            15405 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            15406 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            15407 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            15408 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            15409 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            15410 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            15411 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            15412 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            15413 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            15414 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            15415 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            15416 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            15417 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            15418 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            15419 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            15420 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            15421 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            15422 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            15423 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            15424 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            15425 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            15426 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            15427 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            15428 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            15429 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            15430 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            15431 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            15432 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            15433 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            15434 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            15435 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            15436 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            15437 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            15438 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            15439 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            15440 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            15441 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            15442 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            15443 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            15444 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            15445 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            15446 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            15447 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            15448 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            15449 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            15450 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            15451 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            15452 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            15453 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            15454 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            15455 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
