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
public record BambooMosaicStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:stair", "block.minecraft.bamboo_mosaic_stairs", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:bamboo_mosaic_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/bamboo_mosaic_stairs");
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.Normal, 18, "bamboo_wood", NoteBlockInstrument.Bass, false, true, false, true, false, false, false, false, true, false, false, false, false, false, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 12452];

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
    public Identifier? LootTable => Data.LootTable;
    public (int Min, int Max)? Experience => Data.Experience;

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
                            true => 12452,
                            false => 12453,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12454,
                            false => 12455,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12456,
                            false => 12457,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12458,
                            false => 12459,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12460,
                            false => 12461,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12462,
                            false => 12463,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12464,
                            false => 12465,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12466,
                            false => 12467,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12468,
                            false => 12469,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12470,
                            false => 12471,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12472,
                            false => 12473,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12474,
                            false => 12475,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12476,
                            false => 12477,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12478,
                            false => 12479,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12480,
                            false => 12481,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12482,
                            false => 12483,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12484,
                            false => 12485,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12486,
                            false => 12487,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12488,
                            false => 12489,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12490,
                            false => 12491,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12492,
                            false => 12493,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12494,
                            false => 12495,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12496,
                            false => 12497,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12498,
                            false => 12499,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12500,
                            false => 12501,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12502,
                            false => 12503,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12504,
                            false => 12505,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12506,
                            false => 12507,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12508,
                            false => 12509,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12510,
                            false => 12511,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12512,
                            false => 12513,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12514,
                            false => 12515,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12516,
                            false => 12517,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12518,
                            false => 12519,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12520,
                            false => 12521,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12522,
                            false => 12523,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12524,
                            false => 12525,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12526,
                            false => 12527,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12528,
                            false => 12529,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12530,
                            false => 12531,
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
            12452 => new BambooMosaicStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            12453 => new BambooMosaicStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            12454 => new BambooMosaicStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            12455 => new BambooMosaicStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            12456 => new BambooMosaicStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            12457 => new BambooMosaicStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            12458 => new BambooMosaicStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            12459 => new BambooMosaicStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            12460 => new BambooMosaicStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            12461 => new BambooMosaicStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            12462 => new BambooMosaicStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            12463 => new BambooMosaicStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            12464 => new BambooMosaicStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            12465 => new BambooMosaicStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            12466 => new BambooMosaicStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            12467 => new BambooMosaicStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            12468 => new BambooMosaicStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            12469 => new BambooMosaicStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            12470 => new BambooMosaicStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            12471 => new BambooMosaicStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            12472 => new BambooMosaicStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            12473 => new BambooMosaicStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            12474 => new BambooMosaicStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            12475 => new BambooMosaicStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            12476 => new BambooMosaicStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            12477 => new BambooMosaicStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            12478 => new BambooMosaicStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            12479 => new BambooMosaicStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            12480 => new BambooMosaicStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            12481 => new BambooMosaicStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            12482 => new BambooMosaicStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            12483 => new BambooMosaicStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            12484 => new BambooMosaicStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            12485 => new BambooMosaicStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            12486 => new BambooMosaicStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            12487 => new BambooMosaicStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            12488 => new BambooMosaicStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            12489 => new BambooMosaicStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            12490 => new BambooMosaicStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            12491 => new BambooMosaicStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            12492 => new BambooMosaicStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            12493 => new BambooMosaicStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            12494 => new BambooMosaicStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            12495 => new BambooMosaicStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            12496 => new BambooMosaicStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            12497 => new BambooMosaicStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            12498 => new BambooMosaicStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            12499 => new BambooMosaicStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            12500 => new BambooMosaicStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            12501 => new BambooMosaicStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            12502 => new BambooMosaicStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            12503 => new BambooMosaicStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            12504 => new BambooMosaicStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            12505 => new BambooMosaicStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            12506 => new BambooMosaicStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            12507 => new BambooMosaicStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            12508 => new BambooMosaicStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            12509 => new BambooMosaicStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            12510 => new BambooMosaicStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            12511 => new BambooMosaicStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            12512 => new BambooMosaicStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            12513 => new BambooMosaicStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            12514 => new BambooMosaicStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            12515 => new BambooMosaicStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            12516 => new BambooMosaicStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            12517 => new BambooMosaicStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            12518 => new BambooMosaicStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            12519 => new BambooMosaicStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            12520 => new BambooMosaicStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            12521 => new BambooMosaicStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            12522 => new BambooMosaicStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            12523 => new BambooMosaicStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            12524 => new BambooMosaicStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            12525 => new BambooMosaicStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            12526 => new BambooMosaicStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            12527 => new BambooMosaicStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            12528 => new BambooMosaicStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            12529 => new BambooMosaicStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            12530 => new BambooMosaicStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            12531 => new BambooMosaicStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
