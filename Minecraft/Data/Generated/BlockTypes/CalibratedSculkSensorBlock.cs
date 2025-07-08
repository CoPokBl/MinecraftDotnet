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

    public Identifier Category => "minecraft:calibrated_sculk_sensor";
    public double Hardness => 1.5;
    public double ExplosionResistance => 1.5;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 1;
    public bool Replaceable => false;
    public string SoundType => "sculk_sensor";
    public Identifier? BlockEntity => "minecraft:calibrated_sculk_sensor";
    public Identifier? Item => "minecraft:calibrated_sculk_sensor";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => true;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 23;
    public string TranslationKey => "block.minecraft.calibrated_sculk_sensor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Power switch {
                    0 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23443,
                            false => 23444,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23445,
                            false => 23446,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23447,
                            false => 23448,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    1 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23449,
                            false => 23450,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23451,
                            false => 23452,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23453,
                            false => 23454,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    2 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23455,
                            false => 23456,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23457,
                            false => 23458,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23459,
                            false => 23460,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    3 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23461,
                            false => 23462,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23463,
                            false => 23464,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23465,
                            false => 23466,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    4 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23467,
                            false => 23468,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23469,
                            false => 23470,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23471,
                            false => 23472,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    5 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23473,
                            false => 23474,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23475,
                            false => 23476,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23477,
                            false => 23478,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    6 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23479,
                            false => 23480,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23481,
                            false => 23482,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23483,
                            false => 23484,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    7 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23485,
                            false => 23486,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23487,
                            false => 23488,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23489,
                            false => 23490,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    8 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23491,
                            false => 23492,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23493,
                            false => 23494,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23495,
                            false => 23496,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    9 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23497,
                            false => 23498,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23499,
                            false => 23500,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23501,
                            false => 23502,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    10 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23503,
                            false => 23504,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23505,
                            false => 23506,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23507,
                            false => 23508,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    11 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23509,
                            false => 23510,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23511,
                            false => 23512,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23513,
                            false => 23514,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    12 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23515,
                            false => 23516,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23517,
                            false => 23518,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23519,
                            false => 23520,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    13 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23521,
                            false => 23522,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23523,
                            false => 23524,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23525,
                            false => 23526,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    14 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23527,
                            false => 23528,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23529,
                            false => 23530,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23531,
                            false => 23532,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    15 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23533,
                            false => 23534,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23535,
                            false => 23536,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23537,
                            false => 23538,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                },
                Direction.South => Power switch {
                    0 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23539,
                            false => 23540,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23541,
                            false => 23542,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23543,
                            false => 23544,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    1 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23545,
                            false => 23546,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23547,
                            false => 23548,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23549,
                            false => 23550,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    2 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23551,
                            false => 23552,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23553,
                            false => 23554,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23555,
                            false => 23556,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    3 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23557,
                            false => 23558,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23559,
                            false => 23560,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23561,
                            false => 23562,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    4 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23563,
                            false => 23564,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23565,
                            false => 23566,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23567,
                            false => 23568,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    5 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23569,
                            false => 23570,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23571,
                            false => 23572,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23573,
                            false => 23574,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    6 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23575,
                            false => 23576,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23577,
                            false => 23578,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23579,
                            false => 23580,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    7 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23581,
                            false => 23582,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23583,
                            false => 23584,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23585,
                            false => 23586,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    8 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23587,
                            false => 23588,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23589,
                            false => 23590,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23591,
                            false => 23592,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    9 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23593,
                            false => 23594,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23595,
                            false => 23596,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23597,
                            false => 23598,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    10 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23599,
                            false => 23600,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23601,
                            false => 23602,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23603,
                            false => 23604,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    11 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23605,
                            false => 23606,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23607,
                            false => 23608,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23609,
                            false => 23610,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    12 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23611,
                            false => 23612,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23613,
                            false => 23614,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23615,
                            false => 23616,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    13 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23617,
                            false => 23618,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23619,
                            false => 23620,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23621,
                            false => 23622,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    14 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23623,
                            false => 23624,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23625,
                            false => 23626,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23627,
                            false => 23628,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    15 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23629,
                            false => 23630,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23631,
                            false => 23632,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23633,
                            false => 23634,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                },
                Direction.West => Power switch {
                    0 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23635,
                            false => 23636,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23637,
                            false => 23638,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23639,
                            false => 23640,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    1 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23641,
                            false => 23642,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23643,
                            false => 23644,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23645,
                            false => 23646,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    2 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23647,
                            false => 23648,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23649,
                            false => 23650,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23651,
                            false => 23652,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    3 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23653,
                            false => 23654,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23655,
                            false => 23656,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23657,
                            false => 23658,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    4 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23659,
                            false => 23660,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23661,
                            false => 23662,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23663,
                            false => 23664,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    5 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23665,
                            false => 23666,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23667,
                            false => 23668,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23669,
                            false => 23670,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    6 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23671,
                            false => 23672,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23673,
                            false => 23674,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23675,
                            false => 23676,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    7 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23677,
                            false => 23678,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23679,
                            false => 23680,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23681,
                            false => 23682,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    8 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23683,
                            false => 23684,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23685,
                            false => 23686,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23687,
                            false => 23688,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    9 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23689,
                            false => 23690,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23691,
                            false => 23692,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23693,
                            false => 23694,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    10 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23695,
                            false => 23696,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23697,
                            false => 23698,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23699,
                            false => 23700,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    11 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23701,
                            false => 23702,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23703,
                            false => 23704,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23705,
                            false => 23706,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    12 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23707,
                            false => 23708,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23709,
                            false => 23710,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23711,
                            false => 23712,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    13 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23713,
                            false => 23714,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23715,
                            false => 23716,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23717,
                            false => 23718,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    14 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23719,
                            false => 23720,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23721,
                            false => 23722,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23723,
                            false => 23724,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    15 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23725,
                            false => 23726,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23727,
                            false => 23728,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23729,
                            false => 23730,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                },
                Direction.East => Power switch {
                    0 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23731,
                            false => 23732,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23733,
                            false => 23734,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23735,
                            false => 23736,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    1 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23737,
                            false => 23738,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23739,
                            false => 23740,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23741,
                            false => 23742,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    2 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23743,
                            false => 23744,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23745,
                            false => 23746,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23747,
                            false => 23748,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    3 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23749,
                            false => 23750,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23751,
                            false => 23752,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23753,
                            false => 23754,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    4 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23755,
                            false => 23756,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23757,
                            false => 23758,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23759,
                            false => 23760,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    5 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23761,
                            false => 23762,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23763,
                            false => 23764,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23765,
                            false => 23766,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    6 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23767,
                            false => 23768,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23769,
                            false => 23770,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23771,
                            false => 23772,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    7 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23773,
                            false => 23774,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23775,
                            false => 23776,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23777,
                            false => 23778,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    8 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23779,
                            false => 23780,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23781,
                            false => 23782,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23783,
                            false => 23784,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    9 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23785,
                            false => 23786,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23787,
                            false => 23788,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23789,
                            false => 23790,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    10 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23791,
                            false => 23792,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23793,
                            false => 23794,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23795,
                            false => 23796,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    11 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23797,
                            false => 23798,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23799,
                            false => 23800,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23801,
                            false => 23802,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    12 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23803,
                            false => 23804,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23805,
                            false => 23806,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23807,
                            false => 23808,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    13 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23809,
                            false => 23810,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23811,
                            false => 23812,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23813,
                            false => 23814,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    14 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23815,
                            false => 23816,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23817,
                            false => 23818,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23819,
                            false => 23820,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    15 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23821,
                            false => 23822,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23823,
                            false => 23824,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23825,
                            false => 23826,
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
            23443 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 0, SculkSensorPhase.Inactive, true),
            23444 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 0, SculkSensorPhase.Inactive, false),
            23445 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 0, SculkSensorPhase.Active, true),
            23446 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 0, SculkSensorPhase.Active, false),
            23447 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 0, SculkSensorPhase.Cooldown, true),
            23448 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 0, SculkSensorPhase.Cooldown, false),
            23449 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 1, SculkSensorPhase.Inactive, true),
            23450 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 1, SculkSensorPhase.Inactive, false),
            23451 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 1, SculkSensorPhase.Active, true),
            23452 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 1, SculkSensorPhase.Active, false),
            23453 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 1, SculkSensorPhase.Cooldown, true),
            23454 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 1, SculkSensorPhase.Cooldown, false),
            23455 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 2, SculkSensorPhase.Inactive, true),
            23456 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 2, SculkSensorPhase.Inactive, false),
            23457 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 2, SculkSensorPhase.Active, true),
            23458 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 2, SculkSensorPhase.Active, false),
            23459 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 2, SculkSensorPhase.Cooldown, true),
            23460 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 2, SculkSensorPhase.Cooldown, false),
            23461 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 3, SculkSensorPhase.Inactive, true),
            23462 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 3, SculkSensorPhase.Inactive, false),
            23463 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 3, SculkSensorPhase.Active, true),
            23464 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 3, SculkSensorPhase.Active, false),
            23465 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 3, SculkSensorPhase.Cooldown, true),
            23466 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 3, SculkSensorPhase.Cooldown, false),
            23467 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 4, SculkSensorPhase.Inactive, true),
            23468 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 4, SculkSensorPhase.Inactive, false),
            23469 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 4, SculkSensorPhase.Active, true),
            23470 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 4, SculkSensorPhase.Active, false),
            23471 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 4, SculkSensorPhase.Cooldown, true),
            23472 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 4, SculkSensorPhase.Cooldown, false),
            23473 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 5, SculkSensorPhase.Inactive, true),
            23474 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 5, SculkSensorPhase.Inactive, false),
            23475 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 5, SculkSensorPhase.Active, true),
            23476 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 5, SculkSensorPhase.Active, false),
            23477 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 5, SculkSensorPhase.Cooldown, true),
            23478 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 5, SculkSensorPhase.Cooldown, false),
            23479 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 6, SculkSensorPhase.Inactive, true),
            23480 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 6, SculkSensorPhase.Inactive, false),
            23481 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 6, SculkSensorPhase.Active, true),
            23482 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 6, SculkSensorPhase.Active, false),
            23483 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 6, SculkSensorPhase.Cooldown, true),
            23484 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 6, SculkSensorPhase.Cooldown, false),
            23485 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 7, SculkSensorPhase.Inactive, true),
            23486 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 7, SculkSensorPhase.Inactive, false),
            23487 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 7, SculkSensorPhase.Active, true),
            23488 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 7, SculkSensorPhase.Active, false),
            23489 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 7, SculkSensorPhase.Cooldown, true),
            23490 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 7, SculkSensorPhase.Cooldown, false),
            23491 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 8, SculkSensorPhase.Inactive, true),
            23492 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 8, SculkSensorPhase.Inactive, false),
            23493 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 8, SculkSensorPhase.Active, true),
            23494 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 8, SculkSensorPhase.Active, false),
            23495 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 8, SculkSensorPhase.Cooldown, true),
            23496 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 8, SculkSensorPhase.Cooldown, false),
            23497 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 9, SculkSensorPhase.Inactive, true),
            23498 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 9, SculkSensorPhase.Inactive, false),
            23499 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 9, SculkSensorPhase.Active, true),
            23500 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 9, SculkSensorPhase.Active, false),
            23501 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 9, SculkSensorPhase.Cooldown, true),
            23502 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 9, SculkSensorPhase.Cooldown, false),
            23503 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 10, SculkSensorPhase.Inactive, true),
            23504 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 10, SculkSensorPhase.Inactive, false),
            23505 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 10, SculkSensorPhase.Active, true),
            23506 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 10, SculkSensorPhase.Active, false),
            23507 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 10, SculkSensorPhase.Cooldown, true),
            23508 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 10, SculkSensorPhase.Cooldown, false),
            23509 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 11, SculkSensorPhase.Inactive, true),
            23510 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 11, SculkSensorPhase.Inactive, false),
            23511 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 11, SculkSensorPhase.Active, true),
            23512 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 11, SculkSensorPhase.Active, false),
            23513 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 11, SculkSensorPhase.Cooldown, true),
            23514 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 11, SculkSensorPhase.Cooldown, false),
            23515 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 12, SculkSensorPhase.Inactive, true),
            23516 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 12, SculkSensorPhase.Inactive, false),
            23517 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 12, SculkSensorPhase.Active, true),
            23518 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 12, SculkSensorPhase.Active, false),
            23519 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 12, SculkSensorPhase.Cooldown, true),
            23520 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 12, SculkSensorPhase.Cooldown, false),
            23521 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 13, SculkSensorPhase.Inactive, true),
            23522 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 13, SculkSensorPhase.Inactive, false),
            23523 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 13, SculkSensorPhase.Active, true),
            23524 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 13, SculkSensorPhase.Active, false),
            23525 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 13, SculkSensorPhase.Cooldown, true),
            23526 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 13, SculkSensorPhase.Cooldown, false),
            23527 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 14, SculkSensorPhase.Inactive, true),
            23528 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 14, SculkSensorPhase.Inactive, false),
            23529 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 14, SculkSensorPhase.Active, true),
            23530 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 14, SculkSensorPhase.Active, false),
            23531 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 14, SculkSensorPhase.Cooldown, true),
            23532 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 14, SculkSensorPhase.Cooldown, false),
            23533 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 15, SculkSensorPhase.Inactive, true),
            23534 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 15, SculkSensorPhase.Inactive, false),
            23535 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 15, SculkSensorPhase.Active, true),
            23536 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 15, SculkSensorPhase.Active, false),
            23537 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 15, SculkSensorPhase.Cooldown, true),
            23538 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 15, SculkSensorPhase.Cooldown, false),
            23539 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 0, SculkSensorPhase.Inactive, true),
            23540 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 0, SculkSensorPhase.Inactive, false),
            23541 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 0, SculkSensorPhase.Active, true),
            23542 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 0, SculkSensorPhase.Active, false),
            23543 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 0, SculkSensorPhase.Cooldown, true),
            23544 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 0, SculkSensorPhase.Cooldown, false),
            23545 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 1, SculkSensorPhase.Inactive, true),
            23546 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 1, SculkSensorPhase.Inactive, false),
            23547 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 1, SculkSensorPhase.Active, true),
            23548 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 1, SculkSensorPhase.Active, false),
            23549 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 1, SculkSensorPhase.Cooldown, true),
            23550 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 1, SculkSensorPhase.Cooldown, false),
            23551 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 2, SculkSensorPhase.Inactive, true),
            23552 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 2, SculkSensorPhase.Inactive, false),
            23553 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 2, SculkSensorPhase.Active, true),
            23554 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 2, SculkSensorPhase.Active, false),
            23555 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 2, SculkSensorPhase.Cooldown, true),
            23556 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 2, SculkSensorPhase.Cooldown, false),
            23557 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 3, SculkSensorPhase.Inactive, true),
            23558 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 3, SculkSensorPhase.Inactive, false),
            23559 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 3, SculkSensorPhase.Active, true),
            23560 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 3, SculkSensorPhase.Active, false),
            23561 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 3, SculkSensorPhase.Cooldown, true),
            23562 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 3, SculkSensorPhase.Cooldown, false),
            23563 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 4, SculkSensorPhase.Inactive, true),
            23564 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 4, SculkSensorPhase.Inactive, false),
            23565 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 4, SculkSensorPhase.Active, true),
            23566 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 4, SculkSensorPhase.Active, false),
            23567 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 4, SculkSensorPhase.Cooldown, true),
            23568 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 4, SculkSensorPhase.Cooldown, false),
            23569 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 5, SculkSensorPhase.Inactive, true),
            23570 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 5, SculkSensorPhase.Inactive, false),
            23571 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 5, SculkSensorPhase.Active, true),
            23572 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 5, SculkSensorPhase.Active, false),
            23573 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 5, SculkSensorPhase.Cooldown, true),
            23574 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 5, SculkSensorPhase.Cooldown, false),
            23575 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 6, SculkSensorPhase.Inactive, true),
            23576 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 6, SculkSensorPhase.Inactive, false),
            23577 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 6, SculkSensorPhase.Active, true),
            23578 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 6, SculkSensorPhase.Active, false),
            23579 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 6, SculkSensorPhase.Cooldown, true),
            23580 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 6, SculkSensorPhase.Cooldown, false),
            23581 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 7, SculkSensorPhase.Inactive, true),
            23582 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 7, SculkSensorPhase.Inactive, false),
            23583 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 7, SculkSensorPhase.Active, true),
            23584 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 7, SculkSensorPhase.Active, false),
            23585 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 7, SculkSensorPhase.Cooldown, true),
            23586 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 7, SculkSensorPhase.Cooldown, false),
            23587 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 8, SculkSensorPhase.Inactive, true),
            23588 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 8, SculkSensorPhase.Inactive, false),
            23589 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 8, SculkSensorPhase.Active, true),
            23590 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 8, SculkSensorPhase.Active, false),
            23591 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 8, SculkSensorPhase.Cooldown, true),
            23592 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 8, SculkSensorPhase.Cooldown, false),
            23593 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 9, SculkSensorPhase.Inactive, true),
            23594 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 9, SculkSensorPhase.Inactive, false),
            23595 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 9, SculkSensorPhase.Active, true),
            23596 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 9, SculkSensorPhase.Active, false),
            23597 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 9, SculkSensorPhase.Cooldown, true),
            23598 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 9, SculkSensorPhase.Cooldown, false),
            23599 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 10, SculkSensorPhase.Inactive, true),
            23600 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 10, SculkSensorPhase.Inactive, false),
            23601 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 10, SculkSensorPhase.Active, true),
            23602 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 10, SculkSensorPhase.Active, false),
            23603 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 10, SculkSensorPhase.Cooldown, true),
            23604 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 10, SculkSensorPhase.Cooldown, false),
            23605 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 11, SculkSensorPhase.Inactive, true),
            23606 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 11, SculkSensorPhase.Inactive, false),
            23607 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 11, SculkSensorPhase.Active, true),
            23608 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 11, SculkSensorPhase.Active, false),
            23609 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 11, SculkSensorPhase.Cooldown, true),
            23610 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 11, SculkSensorPhase.Cooldown, false),
            23611 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 12, SculkSensorPhase.Inactive, true),
            23612 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 12, SculkSensorPhase.Inactive, false),
            23613 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 12, SculkSensorPhase.Active, true),
            23614 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 12, SculkSensorPhase.Active, false),
            23615 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 12, SculkSensorPhase.Cooldown, true),
            23616 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 12, SculkSensorPhase.Cooldown, false),
            23617 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 13, SculkSensorPhase.Inactive, true),
            23618 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 13, SculkSensorPhase.Inactive, false),
            23619 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 13, SculkSensorPhase.Active, true),
            23620 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 13, SculkSensorPhase.Active, false),
            23621 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 13, SculkSensorPhase.Cooldown, true),
            23622 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 13, SculkSensorPhase.Cooldown, false),
            23623 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 14, SculkSensorPhase.Inactive, true),
            23624 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 14, SculkSensorPhase.Inactive, false),
            23625 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 14, SculkSensorPhase.Active, true),
            23626 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 14, SculkSensorPhase.Active, false),
            23627 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 14, SculkSensorPhase.Cooldown, true),
            23628 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 14, SculkSensorPhase.Cooldown, false),
            23629 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 15, SculkSensorPhase.Inactive, true),
            23630 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 15, SculkSensorPhase.Inactive, false),
            23631 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 15, SculkSensorPhase.Active, true),
            23632 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 15, SculkSensorPhase.Active, false),
            23633 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 15, SculkSensorPhase.Cooldown, true),
            23634 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 15, SculkSensorPhase.Cooldown, false),
            23635 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 0, SculkSensorPhase.Inactive, true),
            23636 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 0, SculkSensorPhase.Inactive, false),
            23637 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 0, SculkSensorPhase.Active, true),
            23638 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 0, SculkSensorPhase.Active, false),
            23639 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 0, SculkSensorPhase.Cooldown, true),
            23640 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 0, SculkSensorPhase.Cooldown, false),
            23641 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 1, SculkSensorPhase.Inactive, true),
            23642 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 1, SculkSensorPhase.Inactive, false),
            23643 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 1, SculkSensorPhase.Active, true),
            23644 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 1, SculkSensorPhase.Active, false),
            23645 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 1, SculkSensorPhase.Cooldown, true),
            23646 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 1, SculkSensorPhase.Cooldown, false),
            23647 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 2, SculkSensorPhase.Inactive, true),
            23648 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 2, SculkSensorPhase.Inactive, false),
            23649 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 2, SculkSensorPhase.Active, true),
            23650 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 2, SculkSensorPhase.Active, false),
            23651 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 2, SculkSensorPhase.Cooldown, true),
            23652 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 2, SculkSensorPhase.Cooldown, false),
            23653 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 3, SculkSensorPhase.Inactive, true),
            23654 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 3, SculkSensorPhase.Inactive, false),
            23655 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 3, SculkSensorPhase.Active, true),
            23656 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 3, SculkSensorPhase.Active, false),
            23657 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 3, SculkSensorPhase.Cooldown, true),
            23658 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 3, SculkSensorPhase.Cooldown, false),
            23659 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 4, SculkSensorPhase.Inactive, true),
            23660 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 4, SculkSensorPhase.Inactive, false),
            23661 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 4, SculkSensorPhase.Active, true),
            23662 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 4, SculkSensorPhase.Active, false),
            23663 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 4, SculkSensorPhase.Cooldown, true),
            23664 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 4, SculkSensorPhase.Cooldown, false),
            23665 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 5, SculkSensorPhase.Inactive, true),
            23666 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 5, SculkSensorPhase.Inactive, false),
            23667 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 5, SculkSensorPhase.Active, true),
            23668 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 5, SculkSensorPhase.Active, false),
            23669 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 5, SculkSensorPhase.Cooldown, true),
            23670 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 5, SculkSensorPhase.Cooldown, false),
            23671 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 6, SculkSensorPhase.Inactive, true),
            23672 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 6, SculkSensorPhase.Inactive, false),
            23673 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 6, SculkSensorPhase.Active, true),
            23674 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 6, SculkSensorPhase.Active, false),
            23675 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 6, SculkSensorPhase.Cooldown, true),
            23676 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 6, SculkSensorPhase.Cooldown, false),
            23677 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 7, SculkSensorPhase.Inactive, true),
            23678 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 7, SculkSensorPhase.Inactive, false),
            23679 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 7, SculkSensorPhase.Active, true),
            23680 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 7, SculkSensorPhase.Active, false),
            23681 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 7, SculkSensorPhase.Cooldown, true),
            23682 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 7, SculkSensorPhase.Cooldown, false),
            23683 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 8, SculkSensorPhase.Inactive, true),
            23684 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 8, SculkSensorPhase.Inactive, false),
            23685 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 8, SculkSensorPhase.Active, true),
            23686 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 8, SculkSensorPhase.Active, false),
            23687 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 8, SculkSensorPhase.Cooldown, true),
            23688 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 8, SculkSensorPhase.Cooldown, false),
            23689 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 9, SculkSensorPhase.Inactive, true),
            23690 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 9, SculkSensorPhase.Inactive, false),
            23691 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 9, SculkSensorPhase.Active, true),
            23692 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 9, SculkSensorPhase.Active, false),
            23693 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 9, SculkSensorPhase.Cooldown, true),
            23694 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 9, SculkSensorPhase.Cooldown, false),
            23695 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 10, SculkSensorPhase.Inactive, true),
            23696 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 10, SculkSensorPhase.Inactive, false),
            23697 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 10, SculkSensorPhase.Active, true),
            23698 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 10, SculkSensorPhase.Active, false),
            23699 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 10, SculkSensorPhase.Cooldown, true),
            23700 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 10, SculkSensorPhase.Cooldown, false),
            23701 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 11, SculkSensorPhase.Inactive, true),
            23702 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 11, SculkSensorPhase.Inactive, false),
            23703 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 11, SculkSensorPhase.Active, true),
            23704 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 11, SculkSensorPhase.Active, false),
            23705 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 11, SculkSensorPhase.Cooldown, true),
            23706 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 11, SculkSensorPhase.Cooldown, false),
            23707 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 12, SculkSensorPhase.Inactive, true),
            23708 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 12, SculkSensorPhase.Inactive, false),
            23709 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 12, SculkSensorPhase.Active, true),
            23710 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 12, SculkSensorPhase.Active, false),
            23711 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 12, SculkSensorPhase.Cooldown, true),
            23712 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 12, SculkSensorPhase.Cooldown, false),
            23713 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 13, SculkSensorPhase.Inactive, true),
            23714 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 13, SculkSensorPhase.Inactive, false),
            23715 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 13, SculkSensorPhase.Active, true),
            23716 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 13, SculkSensorPhase.Active, false),
            23717 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 13, SculkSensorPhase.Cooldown, true),
            23718 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 13, SculkSensorPhase.Cooldown, false),
            23719 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 14, SculkSensorPhase.Inactive, true),
            23720 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 14, SculkSensorPhase.Inactive, false),
            23721 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 14, SculkSensorPhase.Active, true),
            23722 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 14, SculkSensorPhase.Active, false),
            23723 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 14, SculkSensorPhase.Cooldown, true),
            23724 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 14, SculkSensorPhase.Cooldown, false),
            23725 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 15, SculkSensorPhase.Inactive, true),
            23726 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 15, SculkSensorPhase.Inactive, false),
            23727 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 15, SculkSensorPhase.Active, true),
            23728 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 15, SculkSensorPhase.Active, false),
            23729 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 15, SculkSensorPhase.Cooldown, true),
            23730 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 15, SculkSensorPhase.Cooldown, false),
            23731 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 0, SculkSensorPhase.Inactive, true),
            23732 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 0, SculkSensorPhase.Inactive, false),
            23733 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 0, SculkSensorPhase.Active, true),
            23734 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 0, SculkSensorPhase.Active, false),
            23735 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 0, SculkSensorPhase.Cooldown, true),
            23736 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 0, SculkSensorPhase.Cooldown, false),
            23737 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 1, SculkSensorPhase.Inactive, true),
            23738 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 1, SculkSensorPhase.Inactive, false),
            23739 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 1, SculkSensorPhase.Active, true),
            23740 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 1, SculkSensorPhase.Active, false),
            23741 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 1, SculkSensorPhase.Cooldown, true),
            23742 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 1, SculkSensorPhase.Cooldown, false),
            23743 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 2, SculkSensorPhase.Inactive, true),
            23744 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 2, SculkSensorPhase.Inactive, false),
            23745 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 2, SculkSensorPhase.Active, true),
            23746 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 2, SculkSensorPhase.Active, false),
            23747 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 2, SculkSensorPhase.Cooldown, true),
            23748 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 2, SculkSensorPhase.Cooldown, false),
            23749 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 3, SculkSensorPhase.Inactive, true),
            23750 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 3, SculkSensorPhase.Inactive, false),
            23751 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 3, SculkSensorPhase.Active, true),
            23752 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 3, SculkSensorPhase.Active, false),
            23753 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 3, SculkSensorPhase.Cooldown, true),
            23754 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 3, SculkSensorPhase.Cooldown, false),
            23755 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 4, SculkSensorPhase.Inactive, true),
            23756 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 4, SculkSensorPhase.Inactive, false),
            23757 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 4, SculkSensorPhase.Active, true),
            23758 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 4, SculkSensorPhase.Active, false),
            23759 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 4, SculkSensorPhase.Cooldown, true),
            23760 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 4, SculkSensorPhase.Cooldown, false),
            23761 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 5, SculkSensorPhase.Inactive, true),
            23762 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 5, SculkSensorPhase.Inactive, false),
            23763 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 5, SculkSensorPhase.Active, true),
            23764 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 5, SculkSensorPhase.Active, false),
            23765 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 5, SculkSensorPhase.Cooldown, true),
            23766 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 5, SculkSensorPhase.Cooldown, false),
            23767 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 6, SculkSensorPhase.Inactive, true),
            23768 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 6, SculkSensorPhase.Inactive, false),
            23769 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 6, SculkSensorPhase.Active, true),
            23770 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 6, SculkSensorPhase.Active, false),
            23771 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 6, SculkSensorPhase.Cooldown, true),
            23772 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 6, SculkSensorPhase.Cooldown, false),
            23773 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 7, SculkSensorPhase.Inactive, true),
            23774 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 7, SculkSensorPhase.Inactive, false),
            23775 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 7, SculkSensorPhase.Active, true),
            23776 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 7, SculkSensorPhase.Active, false),
            23777 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 7, SculkSensorPhase.Cooldown, true),
            23778 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 7, SculkSensorPhase.Cooldown, false),
            23779 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 8, SculkSensorPhase.Inactive, true),
            23780 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 8, SculkSensorPhase.Inactive, false),
            23781 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 8, SculkSensorPhase.Active, true),
            23782 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 8, SculkSensorPhase.Active, false),
            23783 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 8, SculkSensorPhase.Cooldown, true),
            23784 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 8, SculkSensorPhase.Cooldown, false),
            23785 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 9, SculkSensorPhase.Inactive, true),
            23786 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 9, SculkSensorPhase.Inactive, false),
            23787 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 9, SculkSensorPhase.Active, true),
            23788 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 9, SculkSensorPhase.Active, false),
            23789 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 9, SculkSensorPhase.Cooldown, true),
            23790 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 9, SculkSensorPhase.Cooldown, false),
            23791 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 10, SculkSensorPhase.Inactive, true),
            23792 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 10, SculkSensorPhase.Inactive, false),
            23793 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 10, SculkSensorPhase.Active, true),
            23794 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 10, SculkSensorPhase.Active, false),
            23795 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 10, SculkSensorPhase.Cooldown, true),
            23796 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 10, SculkSensorPhase.Cooldown, false),
            23797 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 11, SculkSensorPhase.Inactive, true),
            23798 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 11, SculkSensorPhase.Inactive, false),
            23799 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 11, SculkSensorPhase.Active, true),
            23800 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 11, SculkSensorPhase.Active, false),
            23801 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 11, SculkSensorPhase.Cooldown, true),
            23802 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 11, SculkSensorPhase.Cooldown, false),
            23803 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 12, SculkSensorPhase.Inactive, true),
            23804 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 12, SculkSensorPhase.Inactive, false),
            23805 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 12, SculkSensorPhase.Active, true),
            23806 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 12, SculkSensorPhase.Active, false),
            23807 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 12, SculkSensorPhase.Cooldown, true),
            23808 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 12, SculkSensorPhase.Cooldown, false),
            23809 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 13, SculkSensorPhase.Inactive, true),
            23810 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 13, SculkSensorPhase.Inactive, false),
            23811 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 13, SculkSensorPhase.Active, true),
            23812 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 13, SculkSensorPhase.Active, false),
            23813 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 13, SculkSensorPhase.Cooldown, true),
            23814 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 13, SculkSensorPhase.Cooldown, false),
            23815 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 14, SculkSensorPhase.Inactive, true),
            23816 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 14, SculkSensorPhase.Inactive, false),
            23817 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 14, SculkSensorPhase.Active, true),
            23818 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 14, SculkSensorPhase.Active, false),
            23819 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 14, SculkSensorPhase.Cooldown, true),
            23820 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 14, SculkSensorPhase.Cooldown, false),
            23821 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 15, SculkSensorPhase.Inactive, true),
            23822 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 15, SculkSensorPhase.Inactive, false),
            23823 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 15, SculkSensorPhase.Active, true),
            23824 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 15, SculkSensorPhase.Active, false),
            23825 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 15, SculkSensorPhase.Cooldown, true),
            23826 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 15, SculkSensorPhase.Cooldown, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            Power = int.Parse(properties["power"].GetString()),
            SculkSensorPhase = SculkSensorPhaseExtensions.FromString(properties["sculk_sensor_phase"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
}
