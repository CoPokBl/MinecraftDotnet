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
public record MagentaConcreteStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.magenta_concrete_stairs", 1.8f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:magenta_concrete_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/magenta_concrete_stairs");
    private static readonly BlockStateInfo I0 = new(1.8f, 0, 1, PushReaction.PushPull, 16, "stone", NoteBlockInstrument.Basedrum, false, true, true, false, false, false, false, true, false, false, false, false, false, true, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 17187];

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
                            true => 17187,
                            false => 17188,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 17189,
                            false => 17190,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 17191,
                            false => 17192,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 17193,
                            false => 17194,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 17195,
                            false => 17196,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 17197,
                            false => 17198,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 17199,
                            false => 17200,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 17201,
                            false => 17202,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 17203,
                            false => 17204,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 17205,
                            false => 17206,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 17207,
                            false => 17208,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 17209,
                            false => 17210,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 17211,
                            false => 17212,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 17213,
                            false => 17214,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 17215,
                            false => 17216,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 17217,
                            false => 17218,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 17219,
                            false => 17220,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 17221,
                            false => 17222,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 17223,
                            false => 17224,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 17225,
                            false => 17226,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 17227,
                            false => 17228,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 17229,
                            false => 17230,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 17231,
                            false => 17232,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 17233,
                            false => 17234,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 17235,
                            false => 17236,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 17237,
                            false => 17238,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 17239,
                            false => 17240,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 17241,
                            false => 17242,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 17243,
                            false => 17244,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 17245,
                            false => 17246,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 17247,
                            false => 17248,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 17249,
                            false => 17250,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 17251,
                            false => 17252,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 17253,
                            false => 17254,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 17255,
                            false => 17256,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 17257,
                            false => 17258,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 17259,
                            false => 17260,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 17261,
                            false => 17262,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 17263,
                            false => 17264,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 17265,
                            false => 17266,
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
            17187 => new MagentaConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            17188 => new MagentaConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            17189 => new MagentaConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            17190 => new MagentaConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            17191 => new MagentaConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            17192 => new MagentaConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            17193 => new MagentaConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            17194 => new MagentaConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            17195 => new MagentaConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            17196 => new MagentaConcreteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            17197 => new MagentaConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            17198 => new MagentaConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            17199 => new MagentaConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            17200 => new MagentaConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            17201 => new MagentaConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            17202 => new MagentaConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            17203 => new MagentaConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            17204 => new MagentaConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            17205 => new MagentaConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            17206 => new MagentaConcreteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            17207 => new MagentaConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            17208 => new MagentaConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            17209 => new MagentaConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            17210 => new MagentaConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            17211 => new MagentaConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            17212 => new MagentaConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            17213 => new MagentaConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            17214 => new MagentaConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            17215 => new MagentaConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            17216 => new MagentaConcreteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            17217 => new MagentaConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            17218 => new MagentaConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            17219 => new MagentaConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            17220 => new MagentaConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            17221 => new MagentaConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            17222 => new MagentaConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            17223 => new MagentaConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            17224 => new MagentaConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            17225 => new MagentaConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            17226 => new MagentaConcreteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            17227 => new MagentaConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            17228 => new MagentaConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            17229 => new MagentaConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            17230 => new MagentaConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            17231 => new MagentaConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            17232 => new MagentaConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            17233 => new MagentaConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            17234 => new MagentaConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            17235 => new MagentaConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            17236 => new MagentaConcreteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            17237 => new MagentaConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            17238 => new MagentaConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            17239 => new MagentaConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            17240 => new MagentaConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            17241 => new MagentaConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            17242 => new MagentaConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            17243 => new MagentaConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            17244 => new MagentaConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            17245 => new MagentaConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            17246 => new MagentaConcreteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            17247 => new MagentaConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            17248 => new MagentaConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            17249 => new MagentaConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            17250 => new MagentaConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            17251 => new MagentaConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            17252 => new MagentaConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            17253 => new MagentaConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            17254 => new MagentaConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            17255 => new MagentaConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            17256 => new MagentaConcreteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            17257 => new MagentaConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            17258 => new MagentaConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            17259 => new MagentaConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            17260 => new MagentaConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            17261 => new MagentaConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            17262 => new MagentaConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            17263 => new MagentaConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            17264 => new MagentaConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            17265 => new MagentaConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            17266 => new MagentaConcreteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
