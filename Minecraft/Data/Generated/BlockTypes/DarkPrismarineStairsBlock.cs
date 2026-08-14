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
public record DarkPrismarineStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:stair", "block.minecraft.dark_prismarine_stairs", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:dark_prismarine_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/dark_prismarine_stairs");
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 1, PushReaction.Normal, 31, "stone", NoteBlockInstrument.Basedrum, false, true, true, true, false, false, false, false, true, false, false, false, false, false, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 12794];

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
                            true => 12794,
                            false => 12795,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12796,
                            false => 12797,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12798,
                            false => 12799,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12800,
                            false => 12801,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12802,
                            false => 12803,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12804,
                            false => 12805,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12806,
                            false => 12807,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12808,
                            false => 12809,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12810,
                            false => 12811,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12812,
                            false => 12813,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12814,
                            false => 12815,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12816,
                            false => 12817,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12818,
                            false => 12819,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12820,
                            false => 12821,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12822,
                            false => 12823,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12824,
                            false => 12825,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12826,
                            false => 12827,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12828,
                            false => 12829,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12830,
                            false => 12831,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12832,
                            false => 12833,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12834,
                            false => 12835,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12836,
                            false => 12837,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12838,
                            false => 12839,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12840,
                            false => 12841,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12842,
                            false => 12843,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12844,
                            false => 12845,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12846,
                            false => 12847,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12848,
                            false => 12849,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12850,
                            false => 12851,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12852,
                            false => 12853,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12854,
                            false => 12855,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12856,
                            false => 12857,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12858,
                            false => 12859,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12860,
                            false => 12861,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12862,
                            false => 12863,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12864,
                            false => 12865,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12866,
                            false => 12867,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12868,
                            false => 12869,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12870,
                            false => 12871,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12872,
                            false => 12873,
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
            12794 => new DarkPrismarineStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            12795 => new DarkPrismarineStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            12796 => new DarkPrismarineStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            12797 => new DarkPrismarineStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            12798 => new DarkPrismarineStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            12799 => new DarkPrismarineStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            12800 => new DarkPrismarineStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            12801 => new DarkPrismarineStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            12802 => new DarkPrismarineStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            12803 => new DarkPrismarineStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            12804 => new DarkPrismarineStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            12805 => new DarkPrismarineStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            12806 => new DarkPrismarineStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            12807 => new DarkPrismarineStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            12808 => new DarkPrismarineStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            12809 => new DarkPrismarineStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            12810 => new DarkPrismarineStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            12811 => new DarkPrismarineStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            12812 => new DarkPrismarineStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            12813 => new DarkPrismarineStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            12814 => new DarkPrismarineStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            12815 => new DarkPrismarineStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            12816 => new DarkPrismarineStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            12817 => new DarkPrismarineStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            12818 => new DarkPrismarineStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            12819 => new DarkPrismarineStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            12820 => new DarkPrismarineStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            12821 => new DarkPrismarineStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            12822 => new DarkPrismarineStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            12823 => new DarkPrismarineStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            12824 => new DarkPrismarineStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            12825 => new DarkPrismarineStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            12826 => new DarkPrismarineStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            12827 => new DarkPrismarineStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            12828 => new DarkPrismarineStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            12829 => new DarkPrismarineStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            12830 => new DarkPrismarineStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            12831 => new DarkPrismarineStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            12832 => new DarkPrismarineStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            12833 => new DarkPrismarineStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            12834 => new DarkPrismarineStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            12835 => new DarkPrismarineStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            12836 => new DarkPrismarineStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            12837 => new DarkPrismarineStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            12838 => new DarkPrismarineStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            12839 => new DarkPrismarineStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            12840 => new DarkPrismarineStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            12841 => new DarkPrismarineStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            12842 => new DarkPrismarineStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            12843 => new DarkPrismarineStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            12844 => new DarkPrismarineStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            12845 => new DarkPrismarineStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            12846 => new DarkPrismarineStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            12847 => new DarkPrismarineStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            12848 => new DarkPrismarineStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            12849 => new DarkPrismarineStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            12850 => new DarkPrismarineStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            12851 => new DarkPrismarineStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            12852 => new DarkPrismarineStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            12853 => new DarkPrismarineStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            12854 => new DarkPrismarineStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            12855 => new DarkPrismarineStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            12856 => new DarkPrismarineStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            12857 => new DarkPrismarineStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            12858 => new DarkPrismarineStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            12859 => new DarkPrismarineStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            12860 => new DarkPrismarineStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            12861 => new DarkPrismarineStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            12862 => new DarkPrismarineStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            12863 => new DarkPrismarineStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            12864 => new DarkPrismarineStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            12865 => new DarkPrismarineStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            12866 => new DarkPrismarineStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            12867 => new DarkPrismarineStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            12868 => new DarkPrismarineStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            12869 => new DarkPrismarineStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            12870 => new DarkPrismarineStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            12871 => new DarkPrismarineStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            12872 => new DarkPrismarineStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            12873 => new DarkPrismarineStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
