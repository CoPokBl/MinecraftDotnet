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
public record PolishedBlackstoneStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.polished_blackstone_stairs", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:polished_blackstone_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/polished_blackstone_stairs");
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.PushPull, 29, "stone", NoteBlockInstrument.Basedrum, false, true, true, false, false, false, false, true, false, false, false, false, false, true, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 26014];

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
                            true => 26014,
                            false => 26015,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26016,
                            false => 26017,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26018,
                            false => 26019,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26020,
                            false => 26021,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26022,
                            false => 26023,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26024,
                            false => 26025,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26026,
                            false => 26027,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26028,
                            false => 26029,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26030,
                            false => 26031,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26032,
                            false => 26033,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26034,
                            false => 26035,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26036,
                            false => 26037,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26038,
                            false => 26039,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26040,
                            false => 26041,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26042,
                            false => 26043,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26044,
                            false => 26045,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26046,
                            false => 26047,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26048,
                            false => 26049,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26050,
                            false => 26051,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26052,
                            false => 26053,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26054,
                            false => 26055,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26056,
                            false => 26057,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26058,
                            false => 26059,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26060,
                            false => 26061,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26062,
                            false => 26063,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26064,
                            false => 26065,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26066,
                            false => 26067,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26068,
                            false => 26069,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26070,
                            false => 26071,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26072,
                            false => 26073,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26074,
                            false => 26075,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26076,
                            false => 26077,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26078,
                            false => 26079,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26080,
                            false => 26081,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26082,
                            false => 26083,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26084,
                            false => 26085,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26086,
                            false => 26087,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26088,
                            false => 26089,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26090,
                            false => 26091,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26092,
                            false => 26093,
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
            26014 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            26015 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            26016 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            26017 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            26018 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            26019 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            26020 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            26021 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            26022 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            26023 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            26024 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            26025 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            26026 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            26027 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            26028 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            26029 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            26030 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            26031 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            26032 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            26033 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            26034 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            26035 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            26036 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            26037 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            26038 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            26039 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            26040 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            26041 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            26042 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            26043 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            26044 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            26045 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            26046 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            26047 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            26048 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            26049 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            26050 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            26051 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            26052 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            26053 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            26054 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            26055 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            26056 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            26057 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            26058 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            26059 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            26060 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            26061 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            26062 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            26063 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            26064 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            26065 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            26066 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            26067 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            26068 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            26069 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            26070 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            26071 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            26072 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            26073 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            26074 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            26075 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            26076 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            26077 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            26078 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            26079 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            26080 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            26081 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            26082 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            26083 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            26084 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            26085 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            26086 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            26087 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            26088 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            26089 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            26090 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            26091 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            26092 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            26093 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
