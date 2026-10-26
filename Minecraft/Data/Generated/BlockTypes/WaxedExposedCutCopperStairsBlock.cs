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
public record WaxedExposedCutCopperStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.waxed_exposed_cut_copper_stairs", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:waxed_exposed_cut_copper_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/waxed_exposed_cut_copper_stairs");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.PushPull, 44, "copper", NoteBlockInstrument.TrumpetExposed, false, true, true, false, false, false, false, true, false, false, false, false, false, true, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 31565];

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
                            true => 31565,
                            false => 31566,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31567,
                            false => 31568,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31569,
                            false => 31570,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31571,
                            false => 31572,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31573,
                            false => 31574,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 31575,
                            false => 31576,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31577,
                            false => 31578,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31579,
                            false => 31580,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31581,
                            false => 31582,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31583,
                            false => 31584,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 31585,
                            false => 31586,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31587,
                            false => 31588,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31589,
                            false => 31590,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31591,
                            false => 31592,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31593,
                            false => 31594,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 31595,
                            false => 31596,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31597,
                            false => 31598,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31599,
                            false => 31600,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31601,
                            false => 31602,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31603,
                            false => 31604,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 31605,
                            false => 31606,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31607,
                            false => 31608,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31609,
                            false => 31610,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31611,
                            false => 31612,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31613,
                            false => 31614,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 31615,
                            false => 31616,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31617,
                            false => 31618,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31619,
                            false => 31620,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31621,
                            false => 31622,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31623,
                            false => 31624,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 31625,
                            false => 31626,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31627,
                            false => 31628,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31629,
                            false => 31630,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31631,
                            false => 31632,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31633,
                            false => 31634,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 31635,
                            false => 31636,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31637,
                            false => 31638,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31639,
                            false => 31640,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31641,
                            false => 31642,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31643,
                            false => 31644,
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
            31565 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            31566 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            31567 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            31568 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            31569 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            31570 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            31571 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            31572 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            31573 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            31574 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            31575 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            31576 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            31577 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            31578 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            31579 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            31580 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            31581 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            31582 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            31583 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            31584 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            31585 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            31586 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            31587 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            31588 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            31589 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            31590 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            31591 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            31592 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            31593 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            31594 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            31595 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            31596 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            31597 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            31598 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            31599 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            31600 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            31601 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            31602 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            31603 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            31604 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            31605 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            31606 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            31607 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            31608 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            31609 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            31610 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            31611 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            31612 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            31613 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            31614 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            31615 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            31616 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            31617 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            31618 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            31619 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            31620 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            31621 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            31622 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            31623 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            31624 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            31625 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            31626 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            31627 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            31628 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            31629 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            31630 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            31631 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            31632 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            31633 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            31634 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            31635 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            31636 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            31637 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            31638 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            31639 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            31640 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            31641 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            31642 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            31643 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            31644 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
