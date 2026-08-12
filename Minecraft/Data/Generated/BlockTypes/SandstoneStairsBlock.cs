using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SandstoneStairsBlock(Identifier Identifier, Direction Facing, SandstoneStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:stair", "block.minecraft.sandstone_stairs", 0.8f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:sandstone_stairs", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0.8f, 0, 1, PushReaction.Normal, 2, "stone", NoteBlockInstrument.Basedrum, false, true, true, true, false, false, false, false, true, false, false, false, false, false, true, null, "minecraft:water", BlockShapes.S88, BlockShapes.S88, BlockShapes.S1, BlockShapes.S88, BlockShapes.S88);
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

    public BlockStateInfo StateInfo => States[StateId - 9493];

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
                            true => 9493,
                            false => 9494,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9495,
                            false => 9496,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9497,
                            false => 9498,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9499,
                            false => 9500,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9501,
                            false => 9502,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9503,
                            false => 9504,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9505,
                            false => 9506,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9507,
                            false => 9508,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9509,
                            false => 9510,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9511,
                            false => 9512,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9513,
                            false => 9514,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9515,
                            false => 9516,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9517,
                            false => 9518,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9519,
                            false => 9520,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9521,
                            false => 9522,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9523,
                            false => 9524,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9525,
                            false => 9526,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9527,
                            false => 9528,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9529,
                            false => 9530,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9531,
                            false => 9532,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9533,
                            false => 9534,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9535,
                            false => 9536,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9537,
                            false => 9538,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9539,
                            false => 9540,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9541,
                            false => 9542,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9543,
                            false => 9544,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9545,
                            false => 9546,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9547,
                            false => 9548,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9549,
                            false => 9550,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9551,
                            false => 9552,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9553,
                            false => 9554,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9555,
                            false => 9556,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9557,
                            false => 9558,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9559,
                            false => 9560,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9561,
                            false => 9562,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9563,
                            false => 9564,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9565,
                            false => 9566,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9567,
                            false => 9568,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9569,
                            false => 9570,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9571,
                            false => 9572,
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
            9493 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            9494 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            9495 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            9496 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            9497 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            9498 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            9499 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            9500 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            9501 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            9502 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            9503 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            9504 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            9505 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            9506 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            9507 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            9508 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            9509 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            9510 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            9511 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            9512 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            9513 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            9514 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            9515 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            9516 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            9517 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            9518 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            9519 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            9520 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            9521 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            9522 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            9523 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            9524 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            9525 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            9526 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            9527 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            9528 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            9529 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            9530 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            9531 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            9532 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            9533 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            9534 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            9535 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            9536 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            9537 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            9538 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            9539 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            9540 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            9541 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            9542 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            9543 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            9544 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            9545 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            9546 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            9547 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            9548 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            9549 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            9550 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            9551 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            9552 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            9553 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            9554 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            9555 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            9556 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            9557 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            9558 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            9559 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            9560 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            9561 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            9562 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            9563 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            9564 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            9565 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            9566 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            9567 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            9568 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            9569 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            9570 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            9571 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            9572 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
