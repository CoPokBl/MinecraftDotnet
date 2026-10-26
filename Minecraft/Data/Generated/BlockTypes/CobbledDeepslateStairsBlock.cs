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
    private static readonly BlockInfo Data = new("block.minecraft.cobbled_deepslate_stairs", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:cobbled_deepslate_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/cobbled_deepslate_stairs");
    private static readonly BlockStateInfo I0 = new(3.5f, 0, 1, PushReaction.PushPull, 59, "deepslate", NoteBlockInstrument.Basedrum, false, true, true, false, false, false, false, true, false, false, false, false, false, true, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 33777];

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
                            true => 33777,
                            false => 33778,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 33779,
                            false => 33780,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 33781,
                            false => 33782,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 33783,
                            false => 33784,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 33785,
                            false => 33786,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 33787,
                            false => 33788,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 33789,
                            false => 33790,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 33791,
                            false => 33792,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 33793,
                            false => 33794,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 33795,
                            false => 33796,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 33797,
                            false => 33798,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 33799,
                            false => 33800,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 33801,
                            false => 33802,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 33803,
                            false => 33804,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 33805,
                            false => 33806,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 33807,
                            false => 33808,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 33809,
                            false => 33810,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 33811,
                            false => 33812,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 33813,
                            false => 33814,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 33815,
                            false => 33816,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 33817,
                            false => 33818,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 33819,
                            false => 33820,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 33821,
                            false => 33822,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 33823,
                            false => 33824,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 33825,
                            false => 33826,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 33827,
                            false => 33828,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 33829,
                            false => 33830,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 33831,
                            false => 33832,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 33833,
                            false => 33834,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 33835,
                            false => 33836,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 33837,
                            false => 33838,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 33839,
                            false => 33840,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 33841,
                            false => 33842,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 33843,
                            false => 33844,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 33845,
                            false => 33846,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 33847,
                            false => 33848,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 33849,
                            false => 33850,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 33851,
                            false => 33852,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 33853,
                            false => 33854,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 33855,
                            false => 33856,
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
            33777 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            33778 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            33779 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            33780 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            33781 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            33782 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            33783 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            33784 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            33785 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            33786 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            33787 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            33788 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            33789 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            33790 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            33791 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            33792 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            33793 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            33794 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            33795 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            33796 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            33797 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            33798 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            33799 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            33800 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            33801 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            33802 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            33803 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            33804 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            33805 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            33806 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            33807 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            33808 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            33809 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            33810 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            33811 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            33812 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            33813 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            33814 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            33815 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            33816 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            33817 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            33818 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            33819 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            33820 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            33821 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            33822 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            33823 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            33824 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            33825 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            33826 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            33827 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            33828 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            33829 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            33830 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            33831 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            33832 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            33833 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            33834 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            33835 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            33836 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            33837 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            33838 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            33839 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            33840 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            33841 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            33842 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            33843 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            33844 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            33845 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            33846 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            33847 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            33848 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            33849 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            33850 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            33851 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            33852 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            33853 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            33854 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            33855 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            33856 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
