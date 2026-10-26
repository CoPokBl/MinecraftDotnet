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
public record CalibratedSculkSensorBlock(Identifier Identifier, Direction Facing, int Power, SculkSensorPhase SculkSensorPhase, bool Waterlogged) : IBlock, IHorizontalFacing, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.calibrated_sculk_sensor", 1.5f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:calibrated_sculk_sensor", "minecraft:calibrated_sculk_sensor", BlockInfo.VanillaOnly, "minecraft:blocks/calibrated_sculk_sensor");
    private static readonly BlockStateInfo I0 = new(1.5f, 1, 1, PushReaction.PushPull, 23, "sculk_sensor", NoteBlockInstrument.Harp, false, true, false, false, false, false, false, true, false, true, false, false, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S89, BlockShapes.S89, BlockShapes.S1, BlockShapes.S89, BlockShapes.S89, BlockShapes.S89);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 30616];

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

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Power switch {
                    0 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30616,
                            false => 30617,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30618,
                            false => 30619,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30620,
                            false => 30621,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    1 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30622,
                            false => 30623,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30624,
                            false => 30625,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30626,
                            false => 30627,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    2 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30628,
                            false => 30629,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30630,
                            false => 30631,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30632,
                            false => 30633,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    3 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30634,
                            false => 30635,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30636,
                            false => 30637,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30638,
                            false => 30639,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    4 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30640,
                            false => 30641,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30642,
                            false => 30643,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30644,
                            false => 30645,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    5 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30646,
                            false => 30647,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30648,
                            false => 30649,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30650,
                            false => 30651,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    6 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30652,
                            false => 30653,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30654,
                            false => 30655,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30656,
                            false => 30657,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    7 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30658,
                            false => 30659,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30660,
                            false => 30661,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30662,
                            false => 30663,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    8 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30664,
                            false => 30665,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30666,
                            false => 30667,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30668,
                            false => 30669,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    9 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30670,
                            false => 30671,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30672,
                            false => 30673,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30674,
                            false => 30675,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    10 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30676,
                            false => 30677,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30678,
                            false => 30679,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30680,
                            false => 30681,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    11 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30682,
                            false => 30683,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30684,
                            false => 30685,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30686,
                            false => 30687,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    12 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30688,
                            false => 30689,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30690,
                            false => 30691,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30692,
                            false => 30693,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    13 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30694,
                            false => 30695,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30696,
                            false => 30697,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30698,
                            false => 30699,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    14 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30700,
                            false => 30701,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30702,
                            false => 30703,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30704,
                            false => 30705,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    15 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30706,
                            false => 30707,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30708,
                            false => 30709,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30710,
                            false => 30711,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                },
                Direction.South => Power switch {
                    0 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30712,
                            false => 30713,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30714,
                            false => 30715,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30716,
                            false => 30717,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    1 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30718,
                            false => 30719,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30720,
                            false => 30721,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30722,
                            false => 30723,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    2 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30724,
                            false => 30725,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30726,
                            false => 30727,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30728,
                            false => 30729,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    3 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30730,
                            false => 30731,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30732,
                            false => 30733,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30734,
                            false => 30735,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    4 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30736,
                            false => 30737,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30738,
                            false => 30739,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30740,
                            false => 30741,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    5 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30742,
                            false => 30743,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30744,
                            false => 30745,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30746,
                            false => 30747,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    6 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30748,
                            false => 30749,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30750,
                            false => 30751,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30752,
                            false => 30753,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    7 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30754,
                            false => 30755,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30756,
                            false => 30757,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30758,
                            false => 30759,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    8 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30760,
                            false => 30761,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30762,
                            false => 30763,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30764,
                            false => 30765,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    9 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30766,
                            false => 30767,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30768,
                            false => 30769,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30770,
                            false => 30771,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    10 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30772,
                            false => 30773,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30774,
                            false => 30775,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30776,
                            false => 30777,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    11 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30778,
                            false => 30779,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30780,
                            false => 30781,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30782,
                            false => 30783,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    12 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30784,
                            false => 30785,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30786,
                            false => 30787,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30788,
                            false => 30789,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    13 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30790,
                            false => 30791,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30792,
                            false => 30793,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30794,
                            false => 30795,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    14 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30796,
                            false => 30797,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30798,
                            false => 30799,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30800,
                            false => 30801,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    15 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30802,
                            false => 30803,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30804,
                            false => 30805,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30806,
                            false => 30807,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                },
                Direction.West => Power switch {
                    0 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30808,
                            false => 30809,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30810,
                            false => 30811,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30812,
                            false => 30813,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    1 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30814,
                            false => 30815,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30816,
                            false => 30817,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30818,
                            false => 30819,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    2 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30820,
                            false => 30821,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30822,
                            false => 30823,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30824,
                            false => 30825,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    3 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30826,
                            false => 30827,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30828,
                            false => 30829,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30830,
                            false => 30831,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    4 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30832,
                            false => 30833,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30834,
                            false => 30835,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30836,
                            false => 30837,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    5 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30838,
                            false => 30839,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30840,
                            false => 30841,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30842,
                            false => 30843,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    6 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30844,
                            false => 30845,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30846,
                            false => 30847,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30848,
                            false => 30849,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    7 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30850,
                            false => 30851,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30852,
                            false => 30853,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30854,
                            false => 30855,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    8 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30856,
                            false => 30857,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30858,
                            false => 30859,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30860,
                            false => 30861,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    9 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30862,
                            false => 30863,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30864,
                            false => 30865,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30866,
                            false => 30867,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    10 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30868,
                            false => 30869,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30870,
                            false => 30871,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30872,
                            false => 30873,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    11 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30874,
                            false => 30875,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30876,
                            false => 30877,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30878,
                            false => 30879,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    12 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30880,
                            false => 30881,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30882,
                            false => 30883,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30884,
                            false => 30885,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    13 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30886,
                            false => 30887,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30888,
                            false => 30889,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30890,
                            false => 30891,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    14 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30892,
                            false => 30893,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30894,
                            false => 30895,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30896,
                            false => 30897,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    15 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30898,
                            false => 30899,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30900,
                            false => 30901,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30902,
                            false => 30903,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                },
                Direction.East => Power switch {
                    0 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30904,
                            false => 30905,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30906,
                            false => 30907,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30908,
                            false => 30909,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    1 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30910,
                            false => 30911,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30912,
                            false => 30913,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30914,
                            false => 30915,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    2 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30916,
                            false => 30917,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30918,
                            false => 30919,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30920,
                            false => 30921,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    3 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30922,
                            false => 30923,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30924,
                            false => 30925,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30926,
                            false => 30927,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    4 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30928,
                            false => 30929,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30930,
                            false => 30931,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30932,
                            false => 30933,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    5 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30934,
                            false => 30935,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30936,
                            false => 30937,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30938,
                            false => 30939,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    6 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30940,
                            false => 30941,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30942,
                            false => 30943,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30944,
                            false => 30945,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    7 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30946,
                            false => 30947,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30948,
                            false => 30949,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30950,
                            false => 30951,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    8 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30952,
                            false => 30953,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30954,
                            false => 30955,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30956,
                            false => 30957,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    9 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30958,
                            false => 30959,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30960,
                            false => 30961,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30962,
                            false => 30963,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    10 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30964,
                            false => 30965,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30966,
                            false => 30967,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30968,
                            false => 30969,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    11 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30970,
                            false => 30971,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30972,
                            false => 30973,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30974,
                            false => 30975,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    12 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30976,
                            false => 30977,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30978,
                            false => 30979,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30980,
                            false => 30981,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    13 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30982,
                            false => 30983,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30984,
                            false => 30985,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30986,
                            false => 30987,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    14 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30988,
                            false => 30989,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30990,
                            false => 30991,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30992,
                            false => 30993,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    15 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 30994,
                            false => 30995,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 30996,
                            false => 30997,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 30998,
                            false => 30999,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            30616 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 0, SculkSensorPhase.Inactive, true),
            30617 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 0, SculkSensorPhase.Inactive, false),
            30618 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 0, SculkSensorPhase.Active, true),
            30619 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 0, SculkSensorPhase.Active, false),
            30620 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 0, SculkSensorPhase.Cooldown, true),
            30621 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 0, SculkSensorPhase.Cooldown, false),
            30622 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 1, SculkSensorPhase.Inactive, true),
            30623 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 1, SculkSensorPhase.Inactive, false),
            30624 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 1, SculkSensorPhase.Active, true),
            30625 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 1, SculkSensorPhase.Active, false),
            30626 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 1, SculkSensorPhase.Cooldown, true),
            30627 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 1, SculkSensorPhase.Cooldown, false),
            30628 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 2, SculkSensorPhase.Inactive, true),
            30629 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 2, SculkSensorPhase.Inactive, false),
            30630 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 2, SculkSensorPhase.Active, true),
            30631 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 2, SculkSensorPhase.Active, false),
            30632 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 2, SculkSensorPhase.Cooldown, true),
            30633 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 2, SculkSensorPhase.Cooldown, false),
            30634 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 3, SculkSensorPhase.Inactive, true),
            30635 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 3, SculkSensorPhase.Inactive, false),
            30636 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 3, SculkSensorPhase.Active, true),
            30637 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 3, SculkSensorPhase.Active, false),
            30638 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 3, SculkSensorPhase.Cooldown, true),
            30639 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 3, SculkSensorPhase.Cooldown, false),
            30640 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 4, SculkSensorPhase.Inactive, true),
            30641 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 4, SculkSensorPhase.Inactive, false),
            30642 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 4, SculkSensorPhase.Active, true),
            30643 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 4, SculkSensorPhase.Active, false),
            30644 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 4, SculkSensorPhase.Cooldown, true),
            30645 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 4, SculkSensorPhase.Cooldown, false),
            30646 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 5, SculkSensorPhase.Inactive, true),
            30647 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 5, SculkSensorPhase.Inactive, false),
            30648 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 5, SculkSensorPhase.Active, true),
            30649 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 5, SculkSensorPhase.Active, false),
            30650 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 5, SculkSensorPhase.Cooldown, true),
            30651 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 5, SculkSensorPhase.Cooldown, false),
            30652 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 6, SculkSensorPhase.Inactive, true),
            30653 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 6, SculkSensorPhase.Inactive, false),
            30654 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 6, SculkSensorPhase.Active, true),
            30655 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 6, SculkSensorPhase.Active, false),
            30656 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 6, SculkSensorPhase.Cooldown, true),
            30657 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 6, SculkSensorPhase.Cooldown, false),
            30658 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 7, SculkSensorPhase.Inactive, true),
            30659 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 7, SculkSensorPhase.Inactive, false),
            30660 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 7, SculkSensorPhase.Active, true),
            30661 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 7, SculkSensorPhase.Active, false),
            30662 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 7, SculkSensorPhase.Cooldown, true),
            30663 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 7, SculkSensorPhase.Cooldown, false),
            30664 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 8, SculkSensorPhase.Inactive, true),
            30665 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 8, SculkSensorPhase.Inactive, false),
            30666 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 8, SculkSensorPhase.Active, true),
            30667 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 8, SculkSensorPhase.Active, false),
            30668 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 8, SculkSensorPhase.Cooldown, true),
            30669 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 8, SculkSensorPhase.Cooldown, false),
            30670 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 9, SculkSensorPhase.Inactive, true),
            30671 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 9, SculkSensorPhase.Inactive, false),
            30672 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 9, SculkSensorPhase.Active, true),
            30673 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 9, SculkSensorPhase.Active, false),
            30674 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 9, SculkSensorPhase.Cooldown, true),
            30675 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 9, SculkSensorPhase.Cooldown, false),
            30676 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 10, SculkSensorPhase.Inactive, true),
            30677 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 10, SculkSensorPhase.Inactive, false),
            30678 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 10, SculkSensorPhase.Active, true),
            30679 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 10, SculkSensorPhase.Active, false),
            30680 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 10, SculkSensorPhase.Cooldown, true),
            30681 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 10, SculkSensorPhase.Cooldown, false),
            30682 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 11, SculkSensorPhase.Inactive, true),
            30683 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 11, SculkSensorPhase.Inactive, false),
            30684 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 11, SculkSensorPhase.Active, true),
            30685 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 11, SculkSensorPhase.Active, false),
            30686 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 11, SculkSensorPhase.Cooldown, true),
            30687 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 11, SculkSensorPhase.Cooldown, false),
            30688 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 12, SculkSensorPhase.Inactive, true),
            30689 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 12, SculkSensorPhase.Inactive, false),
            30690 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 12, SculkSensorPhase.Active, true),
            30691 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 12, SculkSensorPhase.Active, false),
            30692 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 12, SculkSensorPhase.Cooldown, true),
            30693 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 12, SculkSensorPhase.Cooldown, false),
            30694 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 13, SculkSensorPhase.Inactive, true),
            30695 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 13, SculkSensorPhase.Inactive, false),
            30696 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 13, SculkSensorPhase.Active, true),
            30697 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 13, SculkSensorPhase.Active, false),
            30698 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 13, SculkSensorPhase.Cooldown, true),
            30699 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 13, SculkSensorPhase.Cooldown, false),
            30700 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 14, SculkSensorPhase.Inactive, true),
            30701 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 14, SculkSensorPhase.Inactive, false),
            30702 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 14, SculkSensorPhase.Active, true),
            30703 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 14, SculkSensorPhase.Active, false),
            30704 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 14, SculkSensorPhase.Cooldown, true),
            30705 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 14, SculkSensorPhase.Cooldown, false),
            30706 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 15, SculkSensorPhase.Inactive, true),
            30707 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 15, SculkSensorPhase.Inactive, false),
            30708 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 15, SculkSensorPhase.Active, true),
            30709 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 15, SculkSensorPhase.Active, false),
            30710 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 15, SculkSensorPhase.Cooldown, true),
            30711 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 15, SculkSensorPhase.Cooldown, false),
            30712 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 0, SculkSensorPhase.Inactive, true),
            30713 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 0, SculkSensorPhase.Inactive, false),
            30714 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 0, SculkSensorPhase.Active, true),
            30715 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 0, SculkSensorPhase.Active, false),
            30716 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 0, SculkSensorPhase.Cooldown, true),
            30717 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 0, SculkSensorPhase.Cooldown, false),
            30718 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 1, SculkSensorPhase.Inactive, true),
            30719 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 1, SculkSensorPhase.Inactive, false),
            30720 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 1, SculkSensorPhase.Active, true),
            30721 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 1, SculkSensorPhase.Active, false),
            30722 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 1, SculkSensorPhase.Cooldown, true),
            30723 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 1, SculkSensorPhase.Cooldown, false),
            30724 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 2, SculkSensorPhase.Inactive, true),
            30725 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 2, SculkSensorPhase.Inactive, false),
            30726 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 2, SculkSensorPhase.Active, true),
            30727 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 2, SculkSensorPhase.Active, false),
            30728 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 2, SculkSensorPhase.Cooldown, true),
            30729 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 2, SculkSensorPhase.Cooldown, false),
            30730 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 3, SculkSensorPhase.Inactive, true),
            30731 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 3, SculkSensorPhase.Inactive, false),
            30732 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 3, SculkSensorPhase.Active, true),
            30733 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 3, SculkSensorPhase.Active, false),
            30734 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 3, SculkSensorPhase.Cooldown, true),
            30735 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 3, SculkSensorPhase.Cooldown, false),
            30736 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 4, SculkSensorPhase.Inactive, true),
            30737 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 4, SculkSensorPhase.Inactive, false),
            30738 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 4, SculkSensorPhase.Active, true),
            30739 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 4, SculkSensorPhase.Active, false),
            30740 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 4, SculkSensorPhase.Cooldown, true),
            30741 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 4, SculkSensorPhase.Cooldown, false),
            30742 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 5, SculkSensorPhase.Inactive, true),
            30743 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 5, SculkSensorPhase.Inactive, false),
            30744 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 5, SculkSensorPhase.Active, true),
            30745 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 5, SculkSensorPhase.Active, false),
            30746 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 5, SculkSensorPhase.Cooldown, true),
            30747 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 5, SculkSensorPhase.Cooldown, false),
            30748 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 6, SculkSensorPhase.Inactive, true),
            30749 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 6, SculkSensorPhase.Inactive, false),
            30750 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 6, SculkSensorPhase.Active, true),
            30751 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 6, SculkSensorPhase.Active, false),
            30752 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 6, SculkSensorPhase.Cooldown, true),
            30753 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 6, SculkSensorPhase.Cooldown, false),
            30754 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 7, SculkSensorPhase.Inactive, true),
            30755 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 7, SculkSensorPhase.Inactive, false),
            30756 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 7, SculkSensorPhase.Active, true),
            30757 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 7, SculkSensorPhase.Active, false),
            30758 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 7, SculkSensorPhase.Cooldown, true),
            30759 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 7, SculkSensorPhase.Cooldown, false),
            30760 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 8, SculkSensorPhase.Inactive, true),
            30761 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 8, SculkSensorPhase.Inactive, false),
            30762 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 8, SculkSensorPhase.Active, true),
            30763 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 8, SculkSensorPhase.Active, false),
            30764 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 8, SculkSensorPhase.Cooldown, true),
            30765 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 8, SculkSensorPhase.Cooldown, false),
            30766 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 9, SculkSensorPhase.Inactive, true),
            30767 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 9, SculkSensorPhase.Inactive, false),
            30768 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 9, SculkSensorPhase.Active, true),
            30769 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 9, SculkSensorPhase.Active, false),
            30770 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 9, SculkSensorPhase.Cooldown, true),
            30771 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 9, SculkSensorPhase.Cooldown, false),
            30772 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 10, SculkSensorPhase.Inactive, true),
            30773 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 10, SculkSensorPhase.Inactive, false),
            30774 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 10, SculkSensorPhase.Active, true),
            30775 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 10, SculkSensorPhase.Active, false),
            30776 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 10, SculkSensorPhase.Cooldown, true),
            30777 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 10, SculkSensorPhase.Cooldown, false),
            30778 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 11, SculkSensorPhase.Inactive, true),
            30779 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 11, SculkSensorPhase.Inactive, false),
            30780 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 11, SculkSensorPhase.Active, true),
            30781 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 11, SculkSensorPhase.Active, false),
            30782 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 11, SculkSensorPhase.Cooldown, true),
            30783 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 11, SculkSensorPhase.Cooldown, false),
            30784 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 12, SculkSensorPhase.Inactive, true),
            30785 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 12, SculkSensorPhase.Inactive, false),
            30786 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 12, SculkSensorPhase.Active, true),
            30787 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 12, SculkSensorPhase.Active, false),
            30788 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 12, SculkSensorPhase.Cooldown, true),
            30789 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 12, SculkSensorPhase.Cooldown, false),
            30790 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 13, SculkSensorPhase.Inactive, true),
            30791 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 13, SculkSensorPhase.Inactive, false),
            30792 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 13, SculkSensorPhase.Active, true),
            30793 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 13, SculkSensorPhase.Active, false),
            30794 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 13, SculkSensorPhase.Cooldown, true),
            30795 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 13, SculkSensorPhase.Cooldown, false),
            30796 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 14, SculkSensorPhase.Inactive, true),
            30797 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 14, SculkSensorPhase.Inactive, false),
            30798 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 14, SculkSensorPhase.Active, true),
            30799 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 14, SculkSensorPhase.Active, false),
            30800 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 14, SculkSensorPhase.Cooldown, true),
            30801 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 14, SculkSensorPhase.Cooldown, false),
            30802 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 15, SculkSensorPhase.Inactive, true),
            30803 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 15, SculkSensorPhase.Inactive, false),
            30804 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 15, SculkSensorPhase.Active, true),
            30805 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 15, SculkSensorPhase.Active, false),
            30806 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 15, SculkSensorPhase.Cooldown, true),
            30807 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 15, SculkSensorPhase.Cooldown, false),
            30808 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 0, SculkSensorPhase.Inactive, true),
            30809 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 0, SculkSensorPhase.Inactive, false),
            30810 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 0, SculkSensorPhase.Active, true),
            30811 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 0, SculkSensorPhase.Active, false),
            30812 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 0, SculkSensorPhase.Cooldown, true),
            30813 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 0, SculkSensorPhase.Cooldown, false),
            30814 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 1, SculkSensorPhase.Inactive, true),
            30815 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 1, SculkSensorPhase.Inactive, false),
            30816 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 1, SculkSensorPhase.Active, true),
            30817 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 1, SculkSensorPhase.Active, false),
            30818 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 1, SculkSensorPhase.Cooldown, true),
            30819 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 1, SculkSensorPhase.Cooldown, false),
            30820 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 2, SculkSensorPhase.Inactive, true),
            30821 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 2, SculkSensorPhase.Inactive, false),
            30822 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 2, SculkSensorPhase.Active, true),
            30823 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 2, SculkSensorPhase.Active, false),
            30824 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 2, SculkSensorPhase.Cooldown, true),
            30825 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 2, SculkSensorPhase.Cooldown, false),
            30826 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 3, SculkSensorPhase.Inactive, true),
            30827 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 3, SculkSensorPhase.Inactive, false),
            30828 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 3, SculkSensorPhase.Active, true),
            30829 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 3, SculkSensorPhase.Active, false),
            30830 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 3, SculkSensorPhase.Cooldown, true),
            30831 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 3, SculkSensorPhase.Cooldown, false),
            30832 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 4, SculkSensorPhase.Inactive, true),
            30833 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 4, SculkSensorPhase.Inactive, false),
            30834 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 4, SculkSensorPhase.Active, true),
            30835 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 4, SculkSensorPhase.Active, false),
            30836 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 4, SculkSensorPhase.Cooldown, true),
            30837 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 4, SculkSensorPhase.Cooldown, false),
            30838 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 5, SculkSensorPhase.Inactive, true),
            30839 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 5, SculkSensorPhase.Inactive, false),
            30840 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 5, SculkSensorPhase.Active, true),
            30841 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 5, SculkSensorPhase.Active, false),
            30842 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 5, SculkSensorPhase.Cooldown, true),
            30843 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 5, SculkSensorPhase.Cooldown, false),
            30844 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 6, SculkSensorPhase.Inactive, true),
            30845 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 6, SculkSensorPhase.Inactive, false),
            30846 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 6, SculkSensorPhase.Active, true),
            30847 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 6, SculkSensorPhase.Active, false),
            30848 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 6, SculkSensorPhase.Cooldown, true),
            30849 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 6, SculkSensorPhase.Cooldown, false),
            30850 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 7, SculkSensorPhase.Inactive, true),
            30851 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 7, SculkSensorPhase.Inactive, false),
            30852 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 7, SculkSensorPhase.Active, true),
            30853 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 7, SculkSensorPhase.Active, false),
            30854 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 7, SculkSensorPhase.Cooldown, true),
            30855 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 7, SculkSensorPhase.Cooldown, false),
            30856 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 8, SculkSensorPhase.Inactive, true),
            30857 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 8, SculkSensorPhase.Inactive, false),
            30858 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 8, SculkSensorPhase.Active, true),
            30859 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 8, SculkSensorPhase.Active, false),
            30860 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 8, SculkSensorPhase.Cooldown, true),
            30861 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 8, SculkSensorPhase.Cooldown, false),
            30862 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 9, SculkSensorPhase.Inactive, true),
            30863 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 9, SculkSensorPhase.Inactive, false),
            30864 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 9, SculkSensorPhase.Active, true),
            30865 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 9, SculkSensorPhase.Active, false),
            30866 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 9, SculkSensorPhase.Cooldown, true),
            30867 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 9, SculkSensorPhase.Cooldown, false),
            30868 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 10, SculkSensorPhase.Inactive, true),
            30869 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 10, SculkSensorPhase.Inactive, false),
            30870 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 10, SculkSensorPhase.Active, true),
            30871 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 10, SculkSensorPhase.Active, false),
            30872 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 10, SculkSensorPhase.Cooldown, true),
            30873 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 10, SculkSensorPhase.Cooldown, false),
            30874 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 11, SculkSensorPhase.Inactive, true),
            30875 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 11, SculkSensorPhase.Inactive, false),
            30876 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 11, SculkSensorPhase.Active, true),
            30877 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 11, SculkSensorPhase.Active, false),
            30878 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 11, SculkSensorPhase.Cooldown, true),
            30879 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 11, SculkSensorPhase.Cooldown, false),
            30880 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 12, SculkSensorPhase.Inactive, true),
            30881 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 12, SculkSensorPhase.Inactive, false),
            30882 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 12, SculkSensorPhase.Active, true),
            30883 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 12, SculkSensorPhase.Active, false),
            30884 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 12, SculkSensorPhase.Cooldown, true),
            30885 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 12, SculkSensorPhase.Cooldown, false),
            30886 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 13, SculkSensorPhase.Inactive, true),
            30887 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 13, SculkSensorPhase.Inactive, false),
            30888 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 13, SculkSensorPhase.Active, true),
            30889 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 13, SculkSensorPhase.Active, false),
            30890 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 13, SculkSensorPhase.Cooldown, true),
            30891 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 13, SculkSensorPhase.Cooldown, false),
            30892 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 14, SculkSensorPhase.Inactive, true),
            30893 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 14, SculkSensorPhase.Inactive, false),
            30894 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 14, SculkSensorPhase.Active, true),
            30895 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 14, SculkSensorPhase.Active, false),
            30896 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 14, SculkSensorPhase.Cooldown, true),
            30897 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 14, SculkSensorPhase.Cooldown, false),
            30898 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 15, SculkSensorPhase.Inactive, true),
            30899 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 15, SculkSensorPhase.Inactive, false),
            30900 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 15, SculkSensorPhase.Active, true),
            30901 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 15, SculkSensorPhase.Active, false),
            30902 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 15, SculkSensorPhase.Cooldown, true),
            30903 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 15, SculkSensorPhase.Cooldown, false),
            30904 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 0, SculkSensorPhase.Inactive, true),
            30905 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 0, SculkSensorPhase.Inactive, false),
            30906 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 0, SculkSensorPhase.Active, true),
            30907 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 0, SculkSensorPhase.Active, false),
            30908 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 0, SculkSensorPhase.Cooldown, true),
            30909 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 0, SculkSensorPhase.Cooldown, false),
            30910 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 1, SculkSensorPhase.Inactive, true),
            30911 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 1, SculkSensorPhase.Inactive, false),
            30912 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 1, SculkSensorPhase.Active, true),
            30913 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 1, SculkSensorPhase.Active, false),
            30914 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 1, SculkSensorPhase.Cooldown, true),
            30915 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 1, SculkSensorPhase.Cooldown, false),
            30916 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 2, SculkSensorPhase.Inactive, true),
            30917 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 2, SculkSensorPhase.Inactive, false),
            30918 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 2, SculkSensorPhase.Active, true),
            30919 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 2, SculkSensorPhase.Active, false),
            30920 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 2, SculkSensorPhase.Cooldown, true),
            30921 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 2, SculkSensorPhase.Cooldown, false),
            30922 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 3, SculkSensorPhase.Inactive, true),
            30923 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 3, SculkSensorPhase.Inactive, false),
            30924 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 3, SculkSensorPhase.Active, true),
            30925 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 3, SculkSensorPhase.Active, false),
            30926 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 3, SculkSensorPhase.Cooldown, true),
            30927 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 3, SculkSensorPhase.Cooldown, false),
            30928 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 4, SculkSensorPhase.Inactive, true),
            30929 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 4, SculkSensorPhase.Inactive, false),
            30930 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 4, SculkSensorPhase.Active, true),
            30931 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 4, SculkSensorPhase.Active, false),
            30932 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 4, SculkSensorPhase.Cooldown, true),
            30933 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 4, SculkSensorPhase.Cooldown, false),
            30934 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 5, SculkSensorPhase.Inactive, true),
            30935 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 5, SculkSensorPhase.Inactive, false),
            30936 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 5, SculkSensorPhase.Active, true),
            30937 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 5, SculkSensorPhase.Active, false),
            30938 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 5, SculkSensorPhase.Cooldown, true),
            30939 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 5, SculkSensorPhase.Cooldown, false),
            30940 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 6, SculkSensorPhase.Inactive, true),
            30941 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 6, SculkSensorPhase.Inactive, false),
            30942 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 6, SculkSensorPhase.Active, true),
            30943 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 6, SculkSensorPhase.Active, false),
            30944 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 6, SculkSensorPhase.Cooldown, true),
            30945 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 6, SculkSensorPhase.Cooldown, false),
            30946 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 7, SculkSensorPhase.Inactive, true),
            30947 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 7, SculkSensorPhase.Inactive, false),
            30948 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 7, SculkSensorPhase.Active, true),
            30949 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 7, SculkSensorPhase.Active, false),
            30950 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 7, SculkSensorPhase.Cooldown, true),
            30951 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 7, SculkSensorPhase.Cooldown, false),
            30952 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 8, SculkSensorPhase.Inactive, true),
            30953 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 8, SculkSensorPhase.Inactive, false),
            30954 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 8, SculkSensorPhase.Active, true),
            30955 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 8, SculkSensorPhase.Active, false),
            30956 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 8, SculkSensorPhase.Cooldown, true),
            30957 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 8, SculkSensorPhase.Cooldown, false),
            30958 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 9, SculkSensorPhase.Inactive, true),
            30959 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 9, SculkSensorPhase.Inactive, false),
            30960 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 9, SculkSensorPhase.Active, true),
            30961 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 9, SculkSensorPhase.Active, false),
            30962 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 9, SculkSensorPhase.Cooldown, true),
            30963 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 9, SculkSensorPhase.Cooldown, false),
            30964 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 10, SculkSensorPhase.Inactive, true),
            30965 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 10, SculkSensorPhase.Inactive, false),
            30966 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 10, SculkSensorPhase.Active, true),
            30967 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 10, SculkSensorPhase.Active, false),
            30968 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 10, SculkSensorPhase.Cooldown, true),
            30969 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 10, SculkSensorPhase.Cooldown, false),
            30970 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 11, SculkSensorPhase.Inactive, true),
            30971 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 11, SculkSensorPhase.Inactive, false),
            30972 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 11, SculkSensorPhase.Active, true),
            30973 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 11, SculkSensorPhase.Active, false),
            30974 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 11, SculkSensorPhase.Cooldown, true),
            30975 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 11, SculkSensorPhase.Cooldown, false),
            30976 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 12, SculkSensorPhase.Inactive, true),
            30977 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 12, SculkSensorPhase.Inactive, false),
            30978 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 12, SculkSensorPhase.Active, true),
            30979 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 12, SculkSensorPhase.Active, false),
            30980 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 12, SculkSensorPhase.Cooldown, true),
            30981 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 12, SculkSensorPhase.Cooldown, false),
            30982 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 13, SculkSensorPhase.Inactive, true),
            30983 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 13, SculkSensorPhase.Inactive, false),
            30984 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 13, SculkSensorPhase.Active, true),
            30985 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 13, SculkSensorPhase.Active, false),
            30986 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 13, SculkSensorPhase.Cooldown, true),
            30987 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 13, SculkSensorPhase.Cooldown, false),
            30988 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 14, SculkSensorPhase.Inactive, true),
            30989 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 14, SculkSensorPhase.Inactive, false),
            30990 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 14, SculkSensorPhase.Active, true),
            30991 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 14, SculkSensorPhase.Active, false),
            30992 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 14, SculkSensorPhase.Cooldown, true),
            30993 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 14, SculkSensorPhase.Cooldown, false),
            30994 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 15, SculkSensorPhase.Inactive, true),
            30995 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 15, SculkSensorPhase.Inactive, false),
            30996 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 15, SculkSensorPhase.Active, true),
            30997 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 15, SculkSensorPhase.Active, false),
            30998 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 15, SculkSensorPhase.Cooldown, true),
            30999 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 15, SculkSensorPhase.Cooldown, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Power = properties.Contains("power") ? int.Parse(properties["power"].GetString()) : Power,
            SculkSensorPhase = properties.Contains("sculk_sensor_phase") ? SculkSensorPhaseExtensions.FromString(properties["sculk_sensor_phase"].GetString()) : SculkSensorPhase,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("power", new StringTag(Power.ToString())),
            ("sculk_sensor_phase", new StringTag(SculkSensorPhase.ToName())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
