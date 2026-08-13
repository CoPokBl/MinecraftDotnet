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
public record PolishedDeepslateStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:stair", "block.minecraft.polished_deepslate_stairs", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:polished_deepslate_stairs", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(3.5f, 0, 1, PushReaction.Normal, 59, "polished_deepslate", NoteBlockInstrument.Basedrum, false, true, true, true, false, false, false, false, true, false, false, false, false, false, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 30831];

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
                            true => 30831,
                            false => 30832,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 30833,
                            false => 30834,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 30835,
                            false => 30836,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 30837,
                            false => 30838,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 30839,
                            false => 30840,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 30841,
                            false => 30842,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 30843,
                            false => 30844,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 30845,
                            false => 30846,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 30847,
                            false => 30848,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 30849,
                            false => 30850,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 30851,
                            false => 30852,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 30853,
                            false => 30854,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 30855,
                            false => 30856,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 30857,
                            false => 30858,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 30859,
                            false => 30860,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 30861,
                            false => 30862,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 30863,
                            false => 30864,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 30865,
                            false => 30866,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 30867,
                            false => 30868,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 30869,
                            false => 30870,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 30871,
                            false => 30872,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 30873,
                            false => 30874,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 30875,
                            false => 30876,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 30877,
                            false => 30878,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 30879,
                            false => 30880,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 30881,
                            false => 30882,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 30883,
                            false => 30884,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 30885,
                            false => 30886,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 30887,
                            false => 30888,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 30889,
                            false => 30890,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 30891,
                            false => 30892,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 30893,
                            false => 30894,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 30895,
                            false => 30896,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 30897,
                            false => 30898,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 30899,
                            false => 30900,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 30901,
                            false => 30902,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 30903,
                            false => 30904,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 30905,
                            false => 30906,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 30907,
                            false => 30908,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 30909,
                            false => 30910,
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
            30831 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            30832 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            30833 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            30834 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            30835 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            30836 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            30837 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            30838 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            30839 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            30840 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            30841 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            30842 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            30843 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            30844 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            30845 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            30846 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            30847 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            30848 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            30849 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            30850 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            30851 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            30852 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            30853 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            30854 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            30855 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            30856 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            30857 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            30858 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            30859 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            30860 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            30861 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            30862 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            30863 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            30864 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            30865 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            30866 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            30867 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            30868 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            30869 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            30870 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            30871 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            30872 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            30873 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            30874 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            30875 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            30876 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            30877 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            30878 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            30879 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            30880 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            30881 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            30882 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            30883 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            30884 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            30885 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            30886 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            30887 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            30888 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            30889 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            30890 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            30891 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            30892 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            30893 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            30894 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            30895 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            30896 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            30897 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            30898 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            30899 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            30900 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            30901 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            30902 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            30903 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            30904 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            30905 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            30906 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            30907 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            30908 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            30909 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            30910 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
