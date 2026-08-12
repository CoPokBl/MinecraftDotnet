using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CalibratedSculkSensorBlock(Identifier Identifier, Direction Facing, int Power, SculkSensorPhase SculkSensorPhase, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:calibrated_sculk_sensor", "block.minecraft.calibrated_sculk_sensor", 1.5f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:calibrated_sculk_sensor", "minecraft:calibrated_sculk_sensor", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1.5f, 1, 1, PushReaction.Normal, 23, "sculk_sensor", NoteBlockInstrument.Harp, false, true, false, true, false, false, false, false, true, false, true, false, false, false, true, [], "minecraft:water", BlockShapes.S87, BlockShapes.S87, BlockShapes.S1, BlockShapes.S87, BlockShapes.S87);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 27259];

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
    public NoteBlockInstrument Instrument => StateInfo.Instrument;
    public Identifier? Fluid => StateInfo.Fluid;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Power switch {
                    0 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27259,
                            false => 27260,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27261,
                            false => 27262,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27263,
                            false => 27264,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    1 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27265,
                            false => 27266,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27267,
                            false => 27268,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27269,
                            false => 27270,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    2 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27271,
                            false => 27272,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27273,
                            false => 27274,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27275,
                            false => 27276,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    3 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27277,
                            false => 27278,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27279,
                            false => 27280,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27281,
                            false => 27282,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    4 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27283,
                            false => 27284,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27285,
                            false => 27286,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27287,
                            false => 27288,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    5 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27289,
                            false => 27290,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27291,
                            false => 27292,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27293,
                            false => 27294,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    6 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27295,
                            false => 27296,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27297,
                            false => 27298,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27299,
                            false => 27300,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    7 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27301,
                            false => 27302,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27303,
                            false => 27304,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27305,
                            false => 27306,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    8 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27307,
                            false => 27308,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27309,
                            false => 27310,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27311,
                            false => 27312,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    9 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27313,
                            false => 27314,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27315,
                            false => 27316,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27317,
                            false => 27318,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    10 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27319,
                            false => 27320,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27321,
                            false => 27322,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27323,
                            false => 27324,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    11 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27325,
                            false => 27326,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27327,
                            false => 27328,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27329,
                            false => 27330,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    12 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27331,
                            false => 27332,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27333,
                            false => 27334,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27335,
                            false => 27336,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    13 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27337,
                            false => 27338,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27339,
                            false => 27340,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27341,
                            false => 27342,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    14 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27343,
                            false => 27344,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27345,
                            false => 27346,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27347,
                            false => 27348,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    15 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27349,
                            false => 27350,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27351,
                            false => 27352,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27353,
                            false => 27354,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                },
                Direction.South => Power switch {
                    0 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27355,
                            false => 27356,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27357,
                            false => 27358,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27359,
                            false => 27360,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    1 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27361,
                            false => 27362,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27363,
                            false => 27364,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27365,
                            false => 27366,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    2 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27367,
                            false => 27368,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27369,
                            false => 27370,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27371,
                            false => 27372,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    3 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27373,
                            false => 27374,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27375,
                            false => 27376,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27377,
                            false => 27378,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    4 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27379,
                            false => 27380,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27381,
                            false => 27382,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27383,
                            false => 27384,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    5 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27385,
                            false => 27386,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27387,
                            false => 27388,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27389,
                            false => 27390,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    6 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27391,
                            false => 27392,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27393,
                            false => 27394,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27395,
                            false => 27396,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    7 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27397,
                            false => 27398,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27399,
                            false => 27400,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27401,
                            false => 27402,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    8 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27403,
                            false => 27404,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27405,
                            false => 27406,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27407,
                            false => 27408,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    9 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27409,
                            false => 27410,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27411,
                            false => 27412,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27413,
                            false => 27414,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    10 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27415,
                            false => 27416,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27417,
                            false => 27418,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27419,
                            false => 27420,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    11 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27421,
                            false => 27422,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27423,
                            false => 27424,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27425,
                            false => 27426,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    12 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27427,
                            false => 27428,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27429,
                            false => 27430,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27431,
                            false => 27432,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    13 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27433,
                            false => 27434,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27435,
                            false => 27436,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27437,
                            false => 27438,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    14 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27439,
                            false => 27440,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27441,
                            false => 27442,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27443,
                            false => 27444,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    15 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27445,
                            false => 27446,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27447,
                            false => 27448,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27449,
                            false => 27450,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                },
                Direction.West => Power switch {
                    0 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27451,
                            false => 27452,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27453,
                            false => 27454,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27455,
                            false => 27456,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    1 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27457,
                            false => 27458,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27459,
                            false => 27460,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27461,
                            false => 27462,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    2 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27463,
                            false => 27464,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27465,
                            false => 27466,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27467,
                            false => 27468,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    3 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27469,
                            false => 27470,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27471,
                            false => 27472,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27473,
                            false => 27474,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    4 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27475,
                            false => 27476,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27477,
                            false => 27478,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27479,
                            false => 27480,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    5 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27481,
                            false => 27482,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27483,
                            false => 27484,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27485,
                            false => 27486,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    6 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27487,
                            false => 27488,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27489,
                            false => 27490,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27491,
                            false => 27492,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    7 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27493,
                            false => 27494,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27495,
                            false => 27496,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27497,
                            false => 27498,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    8 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27499,
                            false => 27500,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27501,
                            false => 27502,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27503,
                            false => 27504,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    9 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27505,
                            false => 27506,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27507,
                            false => 27508,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27509,
                            false => 27510,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    10 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27511,
                            false => 27512,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27513,
                            false => 27514,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27515,
                            false => 27516,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    11 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27517,
                            false => 27518,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27519,
                            false => 27520,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27521,
                            false => 27522,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    12 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27523,
                            false => 27524,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27525,
                            false => 27526,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27527,
                            false => 27528,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    13 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27529,
                            false => 27530,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27531,
                            false => 27532,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27533,
                            false => 27534,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    14 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27535,
                            false => 27536,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27537,
                            false => 27538,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27539,
                            false => 27540,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    15 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27541,
                            false => 27542,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27543,
                            false => 27544,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27545,
                            false => 27546,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                },
                Direction.East => Power switch {
                    0 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27547,
                            false => 27548,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27549,
                            false => 27550,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27551,
                            false => 27552,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    1 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27553,
                            false => 27554,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27555,
                            false => 27556,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27557,
                            false => 27558,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    2 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27559,
                            false => 27560,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27561,
                            false => 27562,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27563,
                            false => 27564,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    3 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27565,
                            false => 27566,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27567,
                            false => 27568,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27569,
                            false => 27570,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    4 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27571,
                            false => 27572,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27573,
                            false => 27574,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27575,
                            false => 27576,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    5 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27577,
                            false => 27578,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27579,
                            false => 27580,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27581,
                            false => 27582,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    6 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27583,
                            false => 27584,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27585,
                            false => 27586,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27587,
                            false => 27588,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    7 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27589,
                            false => 27590,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27591,
                            false => 27592,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27593,
                            false => 27594,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    8 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27595,
                            false => 27596,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27597,
                            false => 27598,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27599,
                            false => 27600,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    9 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27601,
                            false => 27602,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27603,
                            false => 27604,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27605,
                            false => 27606,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    10 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27607,
                            false => 27608,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27609,
                            false => 27610,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27611,
                            false => 27612,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    11 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27613,
                            false => 27614,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27615,
                            false => 27616,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27617,
                            false => 27618,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    12 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27619,
                            false => 27620,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27621,
                            false => 27622,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27623,
                            false => 27624,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    13 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27625,
                            false => 27626,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27627,
                            false => 27628,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27629,
                            false => 27630,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    14 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27631,
                            false => 27632,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27633,
                            false => 27634,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27635,
                            false => 27636,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    15 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 27637,
                            false => 27638,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 27639,
                            false => 27640,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 27641,
                            false => 27642,
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
            27259 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 0, SculkSensorPhase.Inactive, true),
            27260 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 0, SculkSensorPhase.Inactive, false),
            27261 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 0, SculkSensorPhase.Active, true),
            27262 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 0, SculkSensorPhase.Active, false),
            27263 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 0, SculkSensorPhase.Cooldown, true),
            27264 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 0, SculkSensorPhase.Cooldown, false),
            27265 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 1, SculkSensorPhase.Inactive, true),
            27266 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 1, SculkSensorPhase.Inactive, false),
            27267 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 1, SculkSensorPhase.Active, true),
            27268 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 1, SculkSensorPhase.Active, false),
            27269 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 1, SculkSensorPhase.Cooldown, true),
            27270 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 1, SculkSensorPhase.Cooldown, false),
            27271 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 2, SculkSensorPhase.Inactive, true),
            27272 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 2, SculkSensorPhase.Inactive, false),
            27273 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 2, SculkSensorPhase.Active, true),
            27274 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 2, SculkSensorPhase.Active, false),
            27275 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 2, SculkSensorPhase.Cooldown, true),
            27276 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 2, SculkSensorPhase.Cooldown, false),
            27277 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 3, SculkSensorPhase.Inactive, true),
            27278 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 3, SculkSensorPhase.Inactive, false),
            27279 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 3, SculkSensorPhase.Active, true),
            27280 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 3, SculkSensorPhase.Active, false),
            27281 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 3, SculkSensorPhase.Cooldown, true),
            27282 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 3, SculkSensorPhase.Cooldown, false),
            27283 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 4, SculkSensorPhase.Inactive, true),
            27284 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 4, SculkSensorPhase.Inactive, false),
            27285 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 4, SculkSensorPhase.Active, true),
            27286 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 4, SculkSensorPhase.Active, false),
            27287 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 4, SculkSensorPhase.Cooldown, true),
            27288 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 4, SculkSensorPhase.Cooldown, false),
            27289 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 5, SculkSensorPhase.Inactive, true),
            27290 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 5, SculkSensorPhase.Inactive, false),
            27291 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 5, SculkSensorPhase.Active, true),
            27292 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 5, SculkSensorPhase.Active, false),
            27293 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 5, SculkSensorPhase.Cooldown, true),
            27294 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 5, SculkSensorPhase.Cooldown, false),
            27295 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 6, SculkSensorPhase.Inactive, true),
            27296 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 6, SculkSensorPhase.Inactive, false),
            27297 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 6, SculkSensorPhase.Active, true),
            27298 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 6, SculkSensorPhase.Active, false),
            27299 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 6, SculkSensorPhase.Cooldown, true),
            27300 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 6, SculkSensorPhase.Cooldown, false),
            27301 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 7, SculkSensorPhase.Inactive, true),
            27302 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 7, SculkSensorPhase.Inactive, false),
            27303 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 7, SculkSensorPhase.Active, true),
            27304 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 7, SculkSensorPhase.Active, false),
            27305 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 7, SculkSensorPhase.Cooldown, true),
            27306 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 7, SculkSensorPhase.Cooldown, false),
            27307 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 8, SculkSensorPhase.Inactive, true),
            27308 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 8, SculkSensorPhase.Inactive, false),
            27309 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 8, SculkSensorPhase.Active, true),
            27310 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 8, SculkSensorPhase.Active, false),
            27311 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 8, SculkSensorPhase.Cooldown, true),
            27312 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 8, SculkSensorPhase.Cooldown, false),
            27313 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 9, SculkSensorPhase.Inactive, true),
            27314 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 9, SculkSensorPhase.Inactive, false),
            27315 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 9, SculkSensorPhase.Active, true),
            27316 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 9, SculkSensorPhase.Active, false),
            27317 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 9, SculkSensorPhase.Cooldown, true),
            27318 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 9, SculkSensorPhase.Cooldown, false),
            27319 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 10, SculkSensorPhase.Inactive, true),
            27320 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 10, SculkSensorPhase.Inactive, false),
            27321 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 10, SculkSensorPhase.Active, true),
            27322 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 10, SculkSensorPhase.Active, false),
            27323 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 10, SculkSensorPhase.Cooldown, true),
            27324 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 10, SculkSensorPhase.Cooldown, false),
            27325 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 11, SculkSensorPhase.Inactive, true),
            27326 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 11, SculkSensorPhase.Inactive, false),
            27327 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 11, SculkSensorPhase.Active, true),
            27328 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 11, SculkSensorPhase.Active, false),
            27329 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 11, SculkSensorPhase.Cooldown, true),
            27330 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 11, SculkSensorPhase.Cooldown, false),
            27331 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 12, SculkSensorPhase.Inactive, true),
            27332 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 12, SculkSensorPhase.Inactive, false),
            27333 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 12, SculkSensorPhase.Active, true),
            27334 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 12, SculkSensorPhase.Active, false),
            27335 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 12, SculkSensorPhase.Cooldown, true),
            27336 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 12, SculkSensorPhase.Cooldown, false),
            27337 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 13, SculkSensorPhase.Inactive, true),
            27338 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 13, SculkSensorPhase.Inactive, false),
            27339 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 13, SculkSensorPhase.Active, true),
            27340 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 13, SculkSensorPhase.Active, false),
            27341 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 13, SculkSensorPhase.Cooldown, true),
            27342 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 13, SculkSensorPhase.Cooldown, false),
            27343 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 14, SculkSensorPhase.Inactive, true),
            27344 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 14, SculkSensorPhase.Inactive, false),
            27345 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 14, SculkSensorPhase.Active, true),
            27346 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 14, SculkSensorPhase.Active, false),
            27347 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 14, SculkSensorPhase.Cooldown, true),
            27348 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 14, SculkSensorPhase.Cooldown, false),
            27349 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 15, SculkSensorPhase.Inactive, true),
            27350 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 15, SculkSensorPhase.Inactive, false),
            27351 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 15, SculkSensorPhase.Active, true),
            27352 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 15, SculkSensorPhase.Active, false),
            27353 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 15, SculkSensorPhase.Cooldown, true),
            27354 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 15, SculkSensorPhase.Cooldown, false),
            27355 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 0, SculkSensorPhase.Inactive, true),
            27356 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 0, SculkSensorPhase.Inactive, false),
            27357 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 0, SculkSensorPhase.Active, true),
            27358 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 0, SculkSensorPhase.Active, false),
            27359 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 0, SculkSensorPhase.Cooldown, true),
            27360 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 0, SculkSensorPhase.Cooldown, false),
            27361 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 1, SculkSensorPhase.Inactive, true),
            27362 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 1, SculkSensorPhase.Inactive, false),
            27363 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 1, SculkSensorPhase.Active, true),
            27364 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 1, SculkSensorPhase.Active, false),
            27365 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 1, SculkSensorPhase.Cooldown, true),
            27366 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 1, SculkSensorPhase.Cooldown, false),
            27367 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 2, SculkSensorPhase.Inactive, true),
            27368 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 2, SculkSensorPhase.Inactive, false),
            27369 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 2, SculkSensorPhase.Active, true),
            27370 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 2, SculkSensorPhase.Active, false),
            27371 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 2, SculkSensorPhase.Cooldown, true),
            27372 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 2, SculkSensorPhase.Cooldown, false),
            27373 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 3, SculkSensorPhase.Inactive, true),
            27374 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 3, SculkSensorPhase.Inactive, false),
            27375 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 3, SculkSensorPhase.Active, true),
            27376 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 3, SculkSensorPhase.Active, false),
            27377 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 3, SculkSensorPhase.Cooldown, true),
            27378 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 3, SculkSensorPhase.Cooldown, false),
            27379 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 4, SculkSensorPhase.Inactive, true),
            27380 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 4, SculkSensorPhase.Inactive, false),
            27381 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 4, SculkSensorPhase.Active, true),
            27382 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 4, SculkSensorPhase.Active, false),
            27383 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 4, SculkSensorPhase.Cooldown, true),
            27384 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 4, SculkSensorPhase.Cooldown, false),
            27385 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 5, SculkSensorPhase.Inactive, true),
            27386 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 5, SculkSensorPhase.Inactive, false),
            27387 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 5, SculkSensorPhase.Active, true),
            27388 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 5, SculkSensorPhase.Active, false),
            27389 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 5, SculkSensorPhase.Cooldown, true),
            27390 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 5, SculkSensorPhase.Cooldown, false),
            27391 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 6, SculkSensorPhase.Inactive, true),
            27392 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 6, SculkSensorPhase.Inactive, false),
            27393 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 6, SculkSensorPhase.Active, true),
            27394 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 6, SculkSensorPhase.Active, false),
            27395 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 6, SculkSensorPhase.Cooldown, true),
            27396 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 6, SculkSensorPhase.Cooldown, false),
            27397 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 7, SculkSensorPhase.Inactive, true),
            27398 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 7, SculkSensorPhase.Inactive, false),
            27399 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 7, SculkSensorPhase.Active, true),
            27400 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 7, SculkSensorPhase.Active, false),
            27401 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 7, SculkSensorPhase.Cooldown, true),
            27402 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 7, SculkSensorPhase.Cooldown, false),
            27403 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 8, SculkSensorPhase.Inactive, true),
            27404 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 8, SculkSensorPhase.Inactive, false),
            27405 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 8, SculkSensorPhase.Active, true),
            27406 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 8, SculkSensorPhase.Active, false),
            27407 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 8, SculkSensorPhase.Cooldown, true),
            27408 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 8, SculkSensorPhase.Cooldown, false),
            27409 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 9, SculkSensorPhase.Inactive, true),
            27410 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 9, SculkSensorPhase.Inactive, false),
            27411 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 9, SculkSensorPhase.Active, true),
            27412 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 9, SculkSensorPhase.Active, false),
            27413 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 9, SculkSensorPhase.Cooldown, true),
            27414 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 9, SculkSensorPhase.Cooldown, false),
            27415 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 10, SculkSensorPhase.Inactive, true),
            27416 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 10, SculkSensorPhase.Inactive, false),
            27417 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 10, SculkSensorPhase.Active, true),
            27418 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 10, SculkSensorPhase.Active, false),
            27419 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 10, SculkSensorPhase.Cooldown, true),
            27420 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 10, SculkSensorPhase.Cooldown, false),
            27421 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 11, SculkSensorPhase.Inactive, true),
            27422 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 11, SculkSensorPhase.Inactive, false),
            27423 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 11, SculkSensorPhase.Active, true),
            27424 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 11, SculkSensorPhase.Active, false),
            27425 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 11, SculkSensorPhase.Cooldown, true),
            27426 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 11, SculkSensorPhase.Cooldown, false),
            27427 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 12, SculkSensorPhase.Inactive, true),
            27428 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 12, SculkSensorPhase.Inactive, false),
            27429 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 12, SculkSensorPhase.Active, true),
            27430 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 12, SculkSensorPhase.Active, false),
            27431 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 12, SculkSensorPhase.Cooldown, true),
            27432 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 12, SculkSensorPhase.Cooldown, false),
            27433 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 13, SculkSensorPhase.Inactive, true),
            27434 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 13, SculkSensorPhase.Inactive, false),
            27435 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 13, SculkSensorPhase.Active, true),
            27436 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 13, SculkSensorPhase.Active, false),
            27437 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 13, SculkSensorPhase.Cooldown, true),
            27438 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 13, SculkSensorPhase.Cooldown, false),
            27439 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 14, SculkSensorPhase.Inactive, true),
            27440 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 14, SculkSensorPhase.Inactive, false),
            27441 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 14, SculkSensorPhase.Active, true),
            27442 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 14, SculkSensorPhase.Active, false),
            27443 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 14, SculkSensorPhase.Cooldown, true),
            27444 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 14, SculkSensorPhase.Cooldown, false),
            27445 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 15, SculkSensorPhase.Inactive, true),
            27446 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 15, SculkSensorPhase.Inactive, false),
            27447 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 15, SculkSensorPhase.Active, true),
            27448 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 15, SculkSensorPhase.Active, false),
            27449 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 15, SculkSensorPhase.Cooldown, true),
            27450 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 15, SculkSensorPhase.Cooldown, false),
            27451 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 0, SculkSensorPhase.Inactive, true),
            27452 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 0, SculkSensorPhase.Inactive, false),
            27453 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 0, SculkSensorPhase.Active, true),
            27454 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 0, SculkSensorPhase.Active, false),
            27455 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 0, SculkSensorPhase.Cooldown, true),
            27456 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 0, SculkSensorPhase.Cooldown, false),
            27457 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 1, SculkSensorPhase.Inactive, true),
            27458 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 1, SculkSensorPhase.Inactive, false),
            27459 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 1, SculkSensorPhase.Active, true),
            27460 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 1, SculkSensorPhase.Active, false),
            27461 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 1, SculkSensorPhase.Cooldown, true),
            27462 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 1, SculkSensorPhase.Cooldown, false),
            27463 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 2, SculkSensorPhase.Inactive, true),
            27464 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 2, SculkSensorPhase.Inactive, false),
            27465 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 2, SculkSensorPhase.Active, true),
            27466 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 2, SculkSensorPhase.Active, false),
            27467 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 2, SculkSensorPhase.Cooldown, true),
            27468 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 2, SculkSensorPhase.Cooldown, false),
            27469 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 3, SculkSensorPhase.Inactive, true),
            27470 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 3, SculkSensorPhase.Inactive, false),
            27471 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 3, SculkSensorPhase.Active, true),
            27472 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 3, SculkSensorPhase.Active, false),
            27473 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 3, SculkSensorPhase.Cooldown, true),
            27474 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 3, SculkSensorPhase.Cooldown, false),
            27475 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 4, SculkSensorPhase.Inactive, true),
            27476 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 4, SculkSensorPhase.Inactive, false),
            27477 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 4, SculkSensorPhase.Active, true),
            27478 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 4, SculkSensorPhase.Active, false),
            27479 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 4, SculkSensorPhase.Cooldown, true),
            27480 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 4, SculkSensorPhase.Cooldown, false),
            27481 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 5, SculkSensorPhase.Inactive, true),
            27482 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 5, SculkSensorPhase.Inactive, false),
            27483 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 5, SculkSensorPhase.Active, true),
            27484 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 5, SculkSensorPhase.Active, false),
            27485 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 5, SculkSensorPhase.Cooldown, true),
            27486 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 5, SculkSensorPhase.Cooldown, false),
            27487 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 6, SculkSensorPhase.Inactive, true),
            27488 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 6, SculkSensorPhase.Inactive, false),
            27489 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 6, SculkSensorPhase.Active, true),
            27490 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 6, SculkSensorPhase.Active, false),
            27491 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 6, SculkSensorPhase.Cooldown, true),
            27492 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 6, SculkSensorPhase.Cooldown, false),
            27493 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 7, SculkSensorPhase.Inactive, true),
            27494 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 7, SculkSensorPhase.Inactive, false),
            27495 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 7, SculkSensorPhase.Active, true),
            27496 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 7, SculkSensorPhase.Active, false),
            27497 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 7, SculkSensorPhase.Cooldown, true),
            27498 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 7, SculkSensorPhase.Cooldown, false),
            27499 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 8, SculkSensorPhase.Inactive, true),
            27500 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 8, SculkSensorPhase.Inactive, false),
            27501 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 8, SculkSensorPhase.Active, true),
            27502 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 8, SculkSensorPhase.Active, false),
            27503 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 8, SculkSensorPhase.Cooldown, true),
            27504 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 8, SculkSensorPhase.Cooldown, false),
            27505 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 9, SculkSensorPhase.Inactive, true),
            27506 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 9, SculkSensorPhase.Inactive, false),
            27507 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 9, SculkSensorPhase.Active, true),
            27508 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 9, SculkSensorPhase.Active, false),
            27509 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 9, SculkSensorPhase.Cooldown, true),
            27510 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 9, SculkSensorPhase.Cooldown, false),
            27511 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 10, SculkSensorPhase.Inactive, true),
            27512 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 10, SculkSensorPhase.Inactive, false),
            27513 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 10, SculkSensorPhase.Active, true),
            27514 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 10, SculkSensorPhase.Active, false),
            27515 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 10, SculkSensorPhase.Cooldown, true),
            27516 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 10, SculkSensorPhase.Cooldown, false),
            27517 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 11, SculkSensorPhase.Inactive, true),
            27518 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 11, SculkSensorPhase.Inactive, false),
            27519 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 11, SculkSensorPhase.Active, true),
            27520 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 11, SculkSensorPhase.Active, false),
            27521 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 11, SculkSensorPhase.Cooldown, true),
            27522 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 11, SculkSensorPhase.Cooldown, false),
            27523 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 12, SculkSensorPhase.Inactive, true),
            27524 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 12, SculkSensorPhase.Inactive, false),
            27525 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 12, SculkSensorPhase.Active, true),
            27526 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 12, SculkSensorPhase.Active, false),
            27527 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 12, SculkSensorPhase.Cooldown, true),
            27528 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 12, SculkSensorPhase.Cooldown, false),
            27529 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 13, SculkSensorPhase.Inactive, true),
            27530 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 13, SculkSensorPhase.Inactive, false),
            27531 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 13, SculkSensorPhase.Active, true),
            27532 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 13, SculkSensorPhase.Active, false),
            27533 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 13, SculkSensorPhase.Cooldown, true),
            27534 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 13, SculkSensorPhase.Cooldown, false),
            27535 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 14, SculkSensorPhase.Inactive, true),
            27536 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 14, SculkSensorPhase.Inactive, false),
            27537 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 14, SculkSensorPhase.Active, true),
            27538 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 14, SculkSensorPhase.Active, false),
            27539 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 14, SculkSensorPhase.Cooldown, true),
            27540 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 14, SculkSensorPhase.Cooldown, false),
            27541 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 15, SculkSensorPhase.Inactive, true),
            27542 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 15, SculkSensorPhase.Inactive, false),
            27543 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 15, SculkSensorPhase.Active, true),
            27544 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 15, SculkSensorPhase.Active, false),
            27545 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 15, SculkSensorPhase.Cooldown, true),
            27546 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 15, SculkSensorPhase.Cooldown, false),
            27547 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 0, SculkSensorPhase.Inactive, true),
            27548 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 0, SculkSensorPhase.Inactive, false),
            27549 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 0, SculkSensorPhase.Active, true),
            27550 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 0, SculkSensorPhase.Active, false),
            27551 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 0, SculkSensorPhase.Cooldown, true),
            27552 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 0, SculkSensorPhase.Cooldown, false),
            27553 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 1, SculkSensorPhase.Inactive, true),
            27554 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 1, SculkSensorPhase.Inactive, false),
            27555 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 1, SculkSensorPhase.Active, true),
            27556 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 1, SculkSensorPhase.Active, false),
            27557 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 1, SculkSensorPhase.Cooldown, true),
            27558 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 1, SculkSensorPhase.Cooldown, false),
            27559 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 2, SculkSensorPhase.Inactive, true),
            27560 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 2, SculkSensorPhase.Inactive, false),
            27561 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 2, SculkSensorPhase.Active, true),
            27562 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 2, SculkSensorPhase.Active, false),
            27563 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 2, SculkSensorPhase.Cooldown, true),
            27564 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 2, SculkSensorPhase.Cooldown, false),
            27565 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 3, SculkSensorPhase.Inactive, true),
            27566 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 3, SculkSensorPhase.Inactive, false),
            27567 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 3, SculkSensorPhase.Active, true),
            27568 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 3, SculkSensorPhase.Active, false),
            27569 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 3, SculkSensorPhase.Cooldown, true),
            27570 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 3, SculkSensorPhase.Cooldown, false),
            27571 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 4, SculkSensorPhase.Inactive, true),
            27572 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 4, SculkSensorPhase.Inactive, false),
            27573 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 4, SculkSensorPhase.Active, true),
            27574 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 4, SculkSensorPhase.Active, false),
            27575 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 4, SculkSensorPhase.Cooldown, true),
            27576 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 4, SculkSensorPhase.Cooldown, false),
            27577 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 5, SculkSensorPhase.Inactive, true),
            27578 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 5, SculkSensorPhase.Inactive, false),
            27579 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 5, SculkSensorPhase.Active, true),
            27580 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 5, SculkSensorPhase.Active, false),
            27581 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 5, SculkSensorPhase.Cooldown, true),
            27582 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 5, SculkSensorPhase.Cooldown, false),
            27583 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 6, SculkSensorPhase.Inactive, true),
            27584 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 6, SculkSensorPhase.Inactive, false),
            27585 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 6, SculkSensorPhase.Active, true),
            27586 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 6, SculkSensorPhase.Active, false),
            27587 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 6, SculkSensorPhase.Cooldown, true),
            27588 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 6, SculkSensorPhase.Cooldown, false),
            27589 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 7, SculkSensorPhase.Inactive, true),
            27590 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 7, SculkSensorPhase.Inactive, false),
            27591 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 7, SculkSensorPhase.Active, true),
            27592 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 7, SculkSensorPhase.Active, false),
            27593 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 7, SculkSensorPhase.Cooldown, true),
            27594 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 7, SculkSensorPhase.Cooldown, false),
            27595 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 8, SculkSensorPhase.Inactive, true),
            27596 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 8, SculkSensorPhase.Inactive, false),
            27597 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 8, SculkSensorPhase.Active, true),
            27598 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 8, SculkSensorPhase.Active, false),
            27599 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 8, SculkSensorPhase.Cooldown, true),
            27600 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 8, SculkSensorPhase.Cooldown, false),
            27601 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 9, SculkSensorPhase.Inactive, true),
            27602 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 9, SculkSensorPhase.Inactive, false),
            27603 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 9, SculkSensorPhase.Active, true),
            27604 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 9, SculkSensorPhase.Active, false),
            27605 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 9, SculkSensorPhase.Cooldown, true),
            27606 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 9, SculkSensorPhase.Cooldown, false),
            27607 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 10, SculkSensorPhase.Inactive, true),
            27608 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 10, SculkSensorPhase.Inactive, false),
            27609 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 10, SculkSensorPhase.Active, true),
            27610 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 10, SculkSensorPhase.Active, false),
            27611 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 10, SculkSensorPhase.Cooldown, true),
            27612 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 10, SculkSensorPhase.Cooldown, false),
            27613 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 11, SculkSensorPhase.Inactive, true),
            27614 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 11, SculkSensorPhase.Inactive, false),
            27615 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 11, SculkSensorPhase.Active, true),
            27616 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 11, SculkSensorPhase.Active, false),
            27617 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 11, SculkSensorPhase.Cooldown, true),
            27618 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 11, SculkSensorPhase.Cooldown, false),
            27619 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 12, SculkSensorPhase.Inactive, true),
            27620 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 12, SculkSensorPhase.Inactive, false),
            27621 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 12, SculkSensorPhase.Active, true),
            27622 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 12, SculkSensorPhase.Active, false),
            27623 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 12, SculkSensorPhase.Cooldown, true),
            27624 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 12, SculkSensorPhase.Cooldown, false),
            27625 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 13, SculkSensorPhase.Inactive, true),
            27626 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 13, SculkSensorPhase.Inactive, false),
            27627 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 13, SculkSensorPhase.Active, true),
            27628 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 13, SculkSensorPhase.Active, false),
            27629 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 13, SculkSensorPhase.Cooldown, true),
            27630 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 13, SculkSensorPhase.Cooldown, false),
            27631 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 14, SculkSensorPhase.Inactive, true),
            27632 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 14, SculkSensorPhase.Inactive, false),
            27633 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 14, SculkSensorPhase.Active, true),
            27634 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 14, SculkSensorPhase.Active, false),
            27635 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 14, SculkSensorPhase.Cooldown, true),
            27636 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 14, SculkSensorPhase.Cooldown, false),
            27637 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 15, SculkSensorPhase.Inactive, true),
            27638 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 15, SculkSensorPhase.Inactive, false),
            27639 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 15, SculkSensorPhase.Active, true),
            27640 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 15, SculkSensorPhase.Active, false),
            27641 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 15, SculkSensorPhase.Cooldown, true),
            27642 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 15, SculkSensorPhase.Cooldown, false),
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
