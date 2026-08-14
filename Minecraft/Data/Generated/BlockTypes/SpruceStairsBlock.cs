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
public record SpruceStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:stair", "block.minecraft.spruce_stairs", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:spruce_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/spruce_stairs");
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.Normal, 34, "wood", NoteBlockInstrument.Bass, false, true, false, true, false, false, false, false, true, false, false, false, false, false, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 9728];

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
                            true => 9728,
                            false => 9729,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9730,
                            false => 9731,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9732,
                            false => 9733,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9734,
                            false => 9735,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9736,
                            false => 9737,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9738,
                            false => 9739,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9740,
                            false => 9741,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9742,
                            false => 9743,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9744,
                            false => 9745,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9746,
                            false => 9747,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9748,
                            false => 9749,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9750,
                            false => 9751,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9752,
                            false => 9753,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9754,
                            false => 9755,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9756,
                            false => 9757,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9758,
                            false => 9759,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9760,
                            false => 9761,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9762,
                            false => 9763,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9764,
                            false => 9765,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9766,
                            false => 9767,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9768,
                            false => 9769,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9770,
                            false => 9771,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9772,
                            false => 9773,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9774,
                            false => 9775,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9776,
                            false => 9777,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9778,
                            false => 9779,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9780,
                            false => 9781,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9782,
                            false => 9783,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9784,
                            false => 9785,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9786,
                            false => 9787,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9788,
                            false => 9789,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9790,
                            false => 9791,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9792,
                            false => 9793,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9794,
                            false => 9795,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9796,
                            false => 9797,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9798,
                            false => 9799,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9800,
                            false => 9801,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9802,
                            false => 9803,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9804,
                            false => 9805,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9806,
                            false => 9807,
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
            9728 => new SpruceStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            9729 => new SpruceStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            9730 => new SpruceStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            9731 => new SpruceStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            9732 => new SpruceStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            9733 => new SpruceStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            9734 => new SpruceStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            9735 => new SpruceStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            9736 => new SpruceStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            9737 => new SpruceStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            9738 => new SpruceStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            9739 => new SpruceStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            9740 => new SpruceStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            9741 => new SpruceStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            9742 => new SpruceStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            9743 => new SpruceStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            9744 => new SpruceStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            9745 => new SpruceStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            9746 => new SpruceStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            9747 => new SpruceStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            9748 => new SpruceStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            9749 => new SpruceStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            9750 => new SpruceStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            9751 => new SpruceStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            9752 => new SpruceStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            9753 => new SpruceStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            9754 => new SpruceStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            9755 => new SpruceStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            9756 => new SpruceStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            9757 => new SpruceStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            9758 => new SpruceStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            9759 => new SpruceStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            9760 => new SpruceStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            9761 => new SpruceStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            9762 => new SpruceStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            9763 => new SpruceStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            9764 => new SpruceStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            9765 => new SpruceStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            9766 => new SpruceStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            9767 => new SpruceStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            9768 => new SpruceStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            9769 => new SpruceStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            9770 => new SpruceStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            9771 => new SpruceStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            9772 => new SpruceStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            9773 => new SpruceStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            9774 => new SpruceStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            9775 => new SpruceStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            9776 => new SpruceStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            9777 => new SpruceStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            9778 => new SpruceStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            9779 => new SpruceStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            9780 => new SpruceStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            9781 => new SpruceStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            9782 => new SpruceStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            9783 => new SpruceStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            9784 => new SpruceStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            9785 => new SpruceStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            9786 => new SpruceStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            9787 => new SpruceStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            9788 => new SpruceStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            9789 => new SpruceStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            9790 => new SpruceStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            9791 => new SpruceStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            9792 => new SpruceStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            9793 => new SpruceStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            9794 => new SpruceStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            9795 => new SpruceStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            9796 => new SpruceStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            9797 => new SpruceStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            9798 => new SpruceStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            9799 => new SpruceStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            9800 => new SpruceStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            9801 => new SpruceStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            9802 => new SpruceStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            9803 => new SpruceStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            9804 => new SpruceStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            9805 => new SpruceStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            9806 => new SpruceStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            9807 => new SpruceStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
