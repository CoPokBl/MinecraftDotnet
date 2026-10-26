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
public record OakStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.oak_stairs", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:oak_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/oak_stairs");
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.PushPull, 13, "wood", NoteBlockInstrument.Bass, false, true, false, false, false, false, false, true, false, false, false, false, false, true, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 5463];

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
                            true => 5463,
                            false => 5464,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 5465,
                            false => 5466,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 5467,
                            false => 5468,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 5469,
                            false => 5470,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 5471,
                            false => 5472,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 5473,
                            false => 5474,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 5475,
                            false => 5476,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 5477,
                            false => 5478,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 5479,
                            false => 5480,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 5481,
                            false => 5482,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 5483,
                            false => 5484,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 5485,
                            false => 5486,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 5487,
                            false => 5488,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 5489,
                            false => 5490,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 5491,
                            false => 5492,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 5493,
                            false => 5494,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 5495,
                            false => 5496,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 5497,
                            false => 5498,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 5499,
                            false => 5500,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 5501,
                            false => 5502,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 5503,
                            false => 5504,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 5505,
                            false => 5506,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 5507,
                            false => 5508,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 5509,
                            false => 5510,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 5511,
                            false => 5512,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 5513,
                            false => 5514,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 5515,
                            false => 5516,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 5517,
                            false => 5518,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 5519,
                            false => 5520,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 5521,
                            false => 5522,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 5523,
                            false => 5524,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 5525,
                            false => 5526,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 5527,
                            false => 5528,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 5529,
                            false => 5530,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 5531,
                            false => 5532,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 5533,
                            false => 5534,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 5535,
                            false => 5536,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 5537,
                            false => 5538,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 5539,
                            false => 5540,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 5541,
                            false => 5542,
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
            5463 => new OakStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            5464 => new OakStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            5465 => new OakStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            5466 => new OakStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            5467 => new OakStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            5468 => new OakStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            5469 => new OakStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            5470 => new OakStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            5471 => new OakStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            5472 => new OakStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            5473 => new OakStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            5474 => new OakStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            5475 => new OakStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            5476 => new OakStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            5477 => new OakStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            5478 => new OakStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            5479 => new OakStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            5480 => new OakStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            5481 => new OakStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            5482 => new OakStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            5483 => new OakStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            5484 => new OakStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            5485 => new OakStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            5486 => new OakStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            5487 => new OakStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            5488 => new OakStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            5489 => new OakStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            5490 => new OakStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            5491 => new OakStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            5492 => new OakStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            5493 => new OakStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            5494 => new OakStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            5495 => new OakStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            5496 => new OakStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            5497 => new OakStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            5498 => new OakStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            5499 => new OakStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            5500 => new OakStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            5501 => new OakStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            5502 => new OakStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            5503 => new OakStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            5504 => new OakStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            5505 => new OakStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            5506 => new OakStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            5507 => new OakStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            5508 => new OakStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            5509 => new OakStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            5510 => new OakStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            5511 => new OakStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            5512 => new OakStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            5513 => new OakStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            5514 => new OakStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            5515 => new OakStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            5516 => new OakStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            5517 => new OakStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            5518 => new OakStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            5519 => new OakStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            5520 => new OakStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            5521 => new OakStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            5522 => new OakStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            5523 => new OakStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            5524 => new OakStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            5525 => new OakStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            5526 => new OakStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            5527 => new OakStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            5528 => new OakStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            5529 => new OakStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            5530 => new OakStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            5531 => new OakStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            5532 => new OakStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            5533 => new OakStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            5534 => new OakStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            5535 => new OakStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            5536 => new OakStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            5537 => new OakStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            5538 => new OakStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            5539 => new OakStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            5540 => new OakStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            5541 => new OakStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            5542 => new OakStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
