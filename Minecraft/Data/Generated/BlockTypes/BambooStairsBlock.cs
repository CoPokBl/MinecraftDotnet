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
public record BambooStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.bamboo_stairs", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:bamboo_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/bamboo_stairs");
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.PushPull, 18, "bamboo_wood", NoteBlockInstrument.Bass, false, true, false, false, false, false, false, true, false, false, false, false, false, true, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 14219];

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
                            true => 14219,
                            false => 14220,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14221,
                            false => 14222,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14223,
                            false => 14224,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14225,
                            false => 14226,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14227,
                            false => 14228,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14229,
                            false => 14230,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14231,
                            false => 14232,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14233,
                            false => 14234,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14235,
                            false => 14236,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14237,
                            false => 14238,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14239,
                            false => 14240,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14241,
                            false => 14242,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14243,
                            false => 14244,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14245,
                            false => 14246,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14247,
                            false => 14248,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14249,
                            false => 14250,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14251,
                            false => 14252,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14253,
                            false => 14254,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14255,
                            false => 14256,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14257,
                            false => 14258,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14259,
                            false => 14260,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14261,
                            false => 14262,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14263,
                            false => 14264,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14265,
                            false => 14266,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14267,
                            false => 14268,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14269,
                            false => 14270,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14271,
                            false => 14272,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14273,
                            false => 14274,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14275,
                            false => 14276,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14277,
                            false => 14278,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14279,
                            false => 14280,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14281,
                            false => 14282,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14283,
                            false => 14284,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14285,
                            false => 14286,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14287,
                            false => 14288,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14289,
                            false => 14290,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14291,
                            false => 14292,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14293,
                            false => 14294,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14295,
                            false => 14296,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14297,
                            false => 14298,
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
            14219 => new BambooStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            14220 => new BambooStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            14221 => new BambooStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            14222 => new BambooStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            14223 => new BambooStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            14224 => new BambooStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            14225 => new BambooStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            14226 => new BambooStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            14227 => new BambooStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            14228 => new BambooStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            14229 => new BambooStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            14230 => new BambooStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            14231 => new BambooStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            14232 => new BambooStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            14233 => new BambooStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            14234 => new BambooStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            14235 => new BambooStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            14236 => new BambooStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            14237 => new BambooStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            14238 => new BambooStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            14239 => new BambooStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            14240 => new BambooStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            14241 => new BambooStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            14242 => new BambooStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            14243 => new BambooStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            14244 => new BambooStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            14245 => new BambooStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            14246 => new BambooStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            14247 => new BambooStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            14248 => new BambooStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            14249 => new BambooStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            14250 => new BambooStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            14251 => new BambooStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            14252 => new BambooStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            14253 => new BambooStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            14254 => new BambooStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            14255 => new BambooStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            14256 => new BambooStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            14257 => new BambooStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            14258 => new BambooStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            14259 => new BambooStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            14260 => new BambooStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            14261 => new BambooStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            14262 => new BambooStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            14263 => new BambooStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            14264 => new BambooStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            14265 => new BambooStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            14266 => new BambooStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            14267 => new BambooStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            14268 => new BambooStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            14269 => new BambooStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            14270 => new BambooStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            14271 => new BambooStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            14272 => new BambooStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            14273 => new BambooStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            14274 => new BambooStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            14275 => new BambooStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            14276 => new BambooStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            14277 => new BambooStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            14278 => new BambooStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            14279 => new BambooStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            14280 => new BambooStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            14281 => new BambooStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            14282 => new BambooStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            14283 => new BambooStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            14284 => new BambooStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            14285 => new BambooStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            14286 => new BambooStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            14287 => new BambooStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            14288 => new BambooStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            14289 => new BambooStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            14290 => new BambooStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            14291 => new BambooStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            14292 => new BambooStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            14293 => new BambooStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            14294 => new BambooStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            14295 => new BambooStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            14296 => new BambooStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            14297 => new BambooStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            14298 => new BambooStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
