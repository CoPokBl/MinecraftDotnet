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
    public int ProtocolId => 962;
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
                            true => 23475,
                            false => 23476,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23477,
                            false => 23478,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23479,
                            false => 23480,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    1 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23481,
                            false => 23482,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23483,
                            false => 23484,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23485,
                            false => 23486,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    2 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23487,
                            false => 23488,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23489,
                            false => 23490,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23491,
                            false => 23492,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    3 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23493,
                            false => 23494,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23495,
                            false => 23496,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23497,
                            false => 23498,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    4 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23499,
                            false => 23500,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23501,
                            false => 23502,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23503,
                            false => 23504,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    5 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23505,
                            false => 23506,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23507,
                            false => 23508,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23509,
                            false => 23510,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    6 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23511,
                            false => 23512,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23513,
                            false => 23514,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23515,
                            false => 23516,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    7 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23517,
                            false => 23518,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23519,
                            false => 23520,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23521,
                            false => 23522,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    8 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23523,
                            false => 23524,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23525,
                            false => 23526,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23527,
                            false => 23528,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    9 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23529,
                            false => 23530,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23531,
                            false => 23532,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23533,
                            false => 23534,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    10 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23535,
                            false => 23536,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23537,
                            false => 23538,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23539,
                            false => 23540,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    11 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23541,
                            false => 23542,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23543,
                            false => 23544,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23545,
                            false => 23546,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    12 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23547,
                            false => 23548,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23549,
                            false => 23550,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23551,
                            false => 23552,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    13 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23553,
                            false => 23554,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23555,
                            false => 23556,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23557,
                            false => 23558,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    14 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23559,
                            false => 23560,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23561,
                            false => 23562,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23563,
                            false => 23564,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    15 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23565,
                            false => 23566,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23567,
                            false => 23568,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23569,
                            false => 23570,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                },
                Direction.South => Power switch {
                    0 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23571,
                            false => 23572,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23573,
                            false => 23574,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23575,
                            false => 23576,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    1 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23577,
                            false => 23578,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23579,
                            false => 23580,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23581,
                            false => 23582,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    2 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23583,
                            false => 23584,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23585,
                            false => 23586,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23587,
                            false => 23588,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    3 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23589,
                            false => 23590,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23591,
                            false => 23592,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23593,
                            false => 23594,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    4 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23595,
                            false => 23596,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23597,
                            false => 23598,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23599,
                            false => 23600,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    5 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23601,
                            false => 23602,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23603,
                            false => 23604,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23605,
                            false => 23606,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    6 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23607,
                            false => 23608,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23609,
                            false => 23610,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23611,
                            false => 23612,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    7 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23613,
                            false => 23614,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23615,
                            false => 23616,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23617,
                            false => 23618,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    8 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23619,
                            false => 23620,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23621,
                            false => 23622,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23623,
                            false => 23624,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    9 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23625,
                            false => 23626,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23627,
                            false => 23628,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23629,
                            false => 23630,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    10 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23631,
                            false => 23632,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23633,
                            false => 23634,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23635,
                            false => 23636,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    11 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23637,
                            false => 23638,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23639,
                            false => 23640,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23641,
                            false => 23642,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    12 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23643,
                            false => 23644,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23645,
                            false => 23646,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23647,
                            false => 23648,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    13 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23649,
                            false => 23650,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23651,
                            false => 23652,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23653,
                            false => 23654,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    14 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23655,
                            false => 23656,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23657,
                            false => 23658,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23659,
                            false => 23660,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    15 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23661,
                            false => 23662,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23663,
                            false => 23664,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23665,
                            false => 23666,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                },
                Direction.West => Power switch {
                    0 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23667,
                            false => 23668,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23669,
                            false => 23670,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23671,
                            false => 23672,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    1 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23673,
                            false => 23674,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23675,
                            false => 23676,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23677,
                            false => 23678,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    2 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23679,
                            false => 23680,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23681,
                            false => 23682,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23683,
                            false => 23684,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    3 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23685,
                            false => 23686,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23687,
                            false => 23688,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23689,
                            false => 23690,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    4 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23691,
                            false => 23692,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23693,
                            false => 23694,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23695,
                            false => 23696,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    5 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23697,
                            false => 23698,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23699,
                            false => 23700,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23701,
                            false => 23702,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    6 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23703,
                            false => 23704,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23705,
                            false => 23706,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23707,
                            false => 23708,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    7 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23709,
                            false => 23710,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23711,
                            false => 23712,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23713,
                            false => 23714,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    8 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23715,
                            false => 23716,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23717,
                            false => 23718,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23719,
                            false => 23720,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    9 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23721,
                            false => 23722,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23723,
                            false => 23724,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23725,
                            false => 23726,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    10 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23727,
                            false => 23728,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23729,
                            false => 23730,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23731,
                            false => 23732,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    11 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23733,
                            false => 23734,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23735,
                            false => 23736,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23737,
                            false => 23738,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    12 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23739,
                            false => 23740,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23741,
                            false => 23742,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23743,
                            false => 23744,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    13 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23745,
                            false => 23746,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23747,
                            false => 23748,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23749,
                            false => 23750,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    14 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23751,
                            false => 23752,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23753,
                            false => 23754,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23755,
                            false => 23756,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    15 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23757,
                            false => 23758,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23759,
                            false => 23760,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23761,
                            false => 23762,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                },
                Direction.East => Power switch {
                    0 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23763,
                            false => 23764,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23765,
                            false => 23766,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23767,
                            false => 23768,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    1 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23769,
                            false => 23770,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23771,
                            false => 23772,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23773,
                            false => 23774,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    2 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23775,
                            false => 23776,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23777,
                            false => 23778,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23779,
                            false => 23780,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    3 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23781,
                            false => 23782,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23783,
                            false => 23784,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23785,
                            false => 23786,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    4 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23787,
                            false => 23788,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23789,
                            false => 23790,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23791,
                            false => 23792,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    5 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23793,
                            false => 23794,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23795,
                            false => 23796,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23797,
                            false => 23798,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    6 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23799,
                            false => 23800,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23801,
                            false => 23802,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23803,
                            false => 23804,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    7 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23805,
                            false => 23806,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23807,
                            false => 23808,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23809,
                            false => 23810,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    8 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23811,
                            false => 23812,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23813,
                            false => 23814,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23815,
                            false => 23816,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    9 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23817,
                            false => 23818,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23819,
                            false => 23820,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23821,
                            false => 23822,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    10 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23823,
                            false => 23824,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23825,
                            false => 23826,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23827,
                            false => 23828,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    11 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23829,
                            false => 23830,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23831,
                            false => 23832,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23833,
                            false => 23834,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    12 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23835,
                            false => 23836,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23837,
                            false => 23838,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23839,
                            false => 23840,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    13 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23841,
                            false => 23842,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23843,
                            false => 23844,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23845,
                            false => 23846,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    14 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23847,
                            false => 23848,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23849,
                            false => 23850,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23851,
                            false => 23852,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    15 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 23853,
                            false => 23854,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 23855,
                            false => 23856,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 23857,
                            false => 23858,
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
            23475 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 0, SculkSensorPhase.Inactive, true),
            23476 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 0, SculkSensorPhase.Inactive, false),
            23477 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 0, SculkSensorPhase.Active, true),
            23478 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 0, SculkSensorPhase.Active, false),
            23479 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 0, SculkSensorPhase.Cooldown, true),
            23480 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 0, SculkSensorPhase.Cooldown, false),
            23481 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 1, SculkSensorPhase.Inactive, true),
            23482 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 1, SculkSensorPhase.Inactive, false),
            23483 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 1, SculkSensorPhase.Active, true),
            23484 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 1, SculkSensorPhase.Active, false),
            23485 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 1, SculkSensorPhase.Cooldown, true),
            23486 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 1, SculkSensorPhase.Cooldown, false),
            23487 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 2, SculkSensorPhase.Inactive, true),
            23488 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 2, SculkSensorPhase.Inactive, false),
            23489 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 2, SculkSensorPhase.Active, true),
            23490 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 2, SculkSensorPhase.Active, false),
            23491 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 2, SculkSensorPhase.Cooldown, true),
            23492 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 2, SculkSensorPhase.Cooldown, false),
            23493 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 3, SculkSensorPhase.Inactive, true),
            23494 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 3, SculkSensorPhase.Inactive, false),
            23495 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 3, SculkSensorPhase.Active, true),
            23496 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 3, SculkSensorPhase.Active, false),
            23497 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 3, SculkSensorPhase.Cooldown, true),
            23498 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 3, SculkSensorPhase.Cooldown, false),
            23499 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 4, SculkSensorPhase.Inactive, true),
            23500 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 4, SculkSensorPhase.Inactive, false),
            23501 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 4, SculkSensorPhase.Active, true),
            23502 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 4, SculkSensorPhase.Active, false),
            23503 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 4, SculkSensorPhase.Cooldown, true),
            23504 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 4, SculkSensorPhase.Cooldown, false),
            23505 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 5, SculkSensorPhase.Inactive, true),
            23506 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 5, SculkSensorPhase.Inactive, false),
            23507 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 5, SculkSensorPhase.Active, true),
            23508 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 5, SculkSensorPhase.Active, false),
            23509 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 5, SculkSensorPhase.Cooldown, true),
            23510 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 5, SculkSensorPhase.Cooldown, false),
            23511 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 6, SculkSensorPhase.Inactive, true),
            23512 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 6, SculkSensorPhase.Inactive, false),
            23513 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 6, SculkSensorPhase.Active, true),
            23514 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 6, SculkSensorPhase.Active, false),
            23515 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 6, SculkSensorPhase.Cooldown, true),
            23516 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 6, SculkSensorPhase.Cooldown, false),
            23517 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 7, SculkSensorPhase.Inactive, true),
            23518 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 7, SculkSensorPhase.Inactive, false),
            23519 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 7, SculkSensorPhase.Active, true),
            23520 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 7, SculkSensorPhase.Active, false),
            23521 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 7, SculkSensorPhase.Cooldown, true),
            23522 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 7, SculkSensorPhase.Cooldown, false),
            23523 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 8, SculkSensorPhase.Inactive, true),
            23524 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 8, SculkSensorPhase.Inactive, false),
            23525 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 8, SculkSensorPhase.Active, true),
            23526 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 8, SculkSensorPhase.Active, false),
            23527 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 8, SculkSensorPhase.Cooldown, true),
            23528 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 8, SculkSensorPhase.Cooldown, false),
            23529 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 9, SculkSensorPhase.Inactive, true),
            23530 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 9, SculkSensorPhase.Inactive, false),
            23531 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 9, SculkSensorPhase.Active, true),
            23532 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 9, SculkSensorPhase.Active, false),
            23533 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 9, SculkSensorPhase.Cooldown, true),
            23534 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 9, SculkSensorPhase.Cooldown, false),
            23535 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 10, SculkSensorPhase.Inactive, true),
            23536 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 10, SculkSensorPhase.Inactive, false),
            23537 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 10, SculkSensorPhase.Active, true),
            23538 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 10, SculkSensorPhase.Active, false),
            23539 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 10, SculkSensorPhase.Cooldown, true),
            23540 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 10, SculkSensorPhase.Cooldown, false),
            23541 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 11, SculkSensorPhase.Inactive, true),
            23542 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 11, SculkSensorPhase.Inactive, false),
            23543 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 11, SculkSensorPhase.Active, true),
            23544 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 11, SculkSensorPhase.Active, false),
            23545 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 11, SculkSensorPhase.Cooldown, true),
            23546 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 11, SculkSensorPhase.Cooldown, false),
            23547 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 12, SculkSensorPhase.Inactive, true),
            23548 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 12, SculkSensorPhase.Inactive, false),
            23549 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 12, SculkSensorPhase.Active, true),
            23550 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 12, SculkSensorPhase.Active, false),
            23551 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 12, SculkSensorPhase.Cooldown, true),
            23552 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 12, SculkSensorPhase.Cooldown, false),
            23553 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 13, SculkSensorPhase.Inactive, true),
            23554 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 13, SculkSensorPhase.Inactive, false),
            23555 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 13, SculkSensorPhase.Active, true),
            23556 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 13, SculkSensorPhase.Active, false),
            23557 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 13, SculkSensorPhase.Cooldown, true),
            23558 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 13, SculkSensorPhase.Cooldown, false),
            23559 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 14, SculkSensorPhase.Inactive, true),
            23560 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 14, SculkSensorPhase.Inactive, false),
            23561 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 14, SculkSensorPhase.Active, true),
            23562 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 14, SculkSensorPhase.Active, false),
            23563 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 14, SculkSensorPhase.Cooldown, true),
            23564 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 14, SculkSensorPhase.Cooldown, false),
            23565 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 15, SculkSensorPhase.Inactive, true),
            23566 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 15, SculkSensorPhase.Inactive, false),
            23567 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 15, SculkSensorPhase.Active, true),
            23568 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 15, SculkSensorPhase.Active, false),
            23569 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 15, SculkSensorPhase.Cooldown, true),
            23570 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 15, SculkSensorPhase.Cooldown, false),
            23571 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 0, SculkSensorPhase.Inactive, true),
            23572 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 0, SculkSensorPhase.Inactive, false),
            23573 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 0, SculkSensorPhase.Active, true),
            23574 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 0, SculkSensorPhase.Active, false),
            23575 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 0, SculkSensorPhase.Cooldown, true),
            23576 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 0, SculkSensorPhase.Cooldown, false),
            23577 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 1, SculkSensorPhase.Inactive, true),
            23578 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 1, SculkSensorPhase.Inactive, false),
            23579 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 1, SculkSensorPhase.Active, true),
            23580 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 1, SculkSensorPhase.Active, false),
            23581 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 1, SculkSensorPhase.Cooldown, true),
            23582 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 1, SculkSensorPhase.Cooldown, false),
            23583 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 2, SculkSensorPhase.Inactive, true),
            23584 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 2, SculkSensorPhase.Inactive, false),
            23585 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 2, SculkSensorPhase.Active, true),
            23586 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 2, SculkSensorPhase.Active, false),
            23587 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 2, SculkSensorPhase.Cooldown, true),
            23588 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 2, SculkSensorPhase.Cooldown, false),
            23589 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 3, SculkSensorPhase.Inactive, true),
            23590 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 3, SculkSensorPhase.Inactive, false),
            23591 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 3, SculkSensorPhase.Active, true),
            23592 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 3, SculkSensorPhase.Active, false),
            23593 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 3, SculkSensorPhase.Cooldown, true),
            23594 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 3, SculkSensorPhase.Cooldown, false),
            23595 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 4, SculkSensorPhase.Inactive, true),
            23596 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 4, SculkSensorPhase.Inactive, false),
            23597 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 4, SculkSensorPhase.Active, true),
            23598 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 4, SculkSensorPhase.Active, false),
            23599 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 4, SculkSensorPhase.Cooldown, true),
            23600 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 4, SculkSensorPhase.Cooldown, false),
            23601 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 5, SculkSensorPhase.Inactive, true),
            23602 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 5, SculkSensorPhase.Inactive, false),
            23603 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 5, SculkSensorPhase.Active, true),
            23604 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 5, SculkSensorPhase.Active, false),
            23605 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 5, SculkSensorPhase.Cooldown, true),
            23606 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 5, SculkSensorPhase.Cooldown, false),
            23607 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 6, SculkSensorPhase.Inactive, true),
            23608 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 6, SculkSensorPhase.Inactive, false),
            23609 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 6, SculkSensorPhase.Active, true),
            23610 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 6, SculkSensorPhase.Active, false),
            23611 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 6, SculkSensorPhase.Cooldown, true),
            23612 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 6, SculkSensorPhase.Cooldown, false),
            23613 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 7, SculkSensorPhase.Inactive, true),
            23614 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 7, SculkSensorPhase.Inactive, false),
            23615 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 7, SculkSensorPhase.Active, true),
            23616 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 7, SculkSensorPhase.Active, false),
            23617 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 7, SculkSensorPhase.Cooldown, true),
            23618 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 7, SculkSensorPhase.Cooldown, false),
            23619 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 8, SculkSensorPhase.Inactive, true),
            23620 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 8, SculkSensorPhase.Inactive, false),
            23621 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 8, SculkSensorPhase.Active, true),
            23622 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 8, SculkSensorPhase.Active, false),
            23623 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 8, SculkSensorPhase.Cooldown, true),
            23624 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 8, SculkSensorPhase.Cooldown, false),
            23625 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 9, SculkSensorPhase.Inactive, true),
            23626 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 9, SculkSensorPhase.Inactive, false),
            23627 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 9, SculkSensorPhase.Active, true),
            23628 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 9, SculkSensorPhase.Active, false),
            23629 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 9, SculkSensorPhase.Cooldown, true),
            23630 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 9, SculkSensorPhase.Cooldown, false),
            23631 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 10, SculkSensorPhase.Inactive, true),
            23632 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 10, SculkSensorPhase.Inactive, false),
            23633 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 10, SculkSensorPhase.Active, true),
            23634 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 10, SculkSensorPhase.Active, false),
            23635 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 10, SculkSensorPhase.Cooldown, true),
            23636 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 10, SculkSensorPhase.Cooldown, false),
            23637 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 11, SculkSensorPhase.Inactive, true),
            23638 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 11, SculkSensorPhase.Inactive, false),
            23639 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 11, SculkSensorPhase.Active, true),
            23640 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 11, SculkSensorPhase.Active, false),
            23641 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 11, SculkSensorPhase.Cooldown, true),
            23642 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 11, SculkSensorPhase.Cooldown, false),
            23643 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 12, SculkSensorPhase.Inactive, true),
            23644 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 12, SculkSensorPhase.Inactive, false),
            23645 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 12, SculkSensorPhase.Active, true),
            23646 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 12, SculkSensorPhase.Active, false),
            23647 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 12, SculkSensorPhase.Cooldown, true),
            23648 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 12, SculkSensorPhase.Cooldown, false),
            23649 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 13, SculkSensorPhase.Inactive, true),
            23650 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 13, SculkSensorPhase.Inactive, false),
            23651 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 13, SculkSensorPhase.Active, true),
            23652 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 13, SculkSensorPhase.Active, false),
            23653 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 13, SculkSensorPhase.Cooldown, true),
            23654 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 13, SculkSensorPhase.Cooldown, false),
            23655 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 14, SculkSensorPhase.Inactive, true),
            23656 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 14, SculkSensorPhase.Inactive, false),
            23657 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 14, SculkSensorPhase.Active, true),
            23658 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 14, SculkSensorPhase.Active, false),
            23659 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 14, SculkSensorPhase.Cooldown, true),
            23660 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 14, SculkSensorPhase.Cooldown, false),
            23661 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 15, SculkSensorPhase.Inactive, true),
            23662 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 15, SculkSensorPhase.Inactive, false),
            23663 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 15, SculkSensorPhase.Active, true),
            23664 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 15, SculkSensorPhase.Active, false),
            23665 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 15, SculkSensorPhase.Cooldown, true),
            23666 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 15, SculkSensorPhase.Cooldown, false),
            23667 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 0, SculkSensorPhase.Inactive, true),
            23668 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 0, SculkSensorPhase.Inactive, false),
            23669 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 0, SculkSensorPhase.Active, true),
            23670 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 0, SculkSensorPhase.Active, false),
            23671 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 0, SculkSensorPhase.Cooldown, true),
            23672 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 0, SculkSensorPhase.Cooldown, false),
            23673 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 1, SculkSensorPhase.Inactive, true),
            23674 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 1, SculkSensorPhase.Inactive, false),
            23675 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 1, SculkSensorPhase.Active, true),
            23676 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 1, SculkSensorPhase.Active, false),
            23677 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 1, SculkSensorPhase.Cooldown, true),
            23678 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 1, SculkSensorPhase.Cooldown, false),
            23679 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 2, SculkSensorPhase.Inactive, true),
            23680 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 2, SculkSensorPhase.Inactive, false),
            23681 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 2, SculkSensorPhase.Active, true),
            23682 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 2, SculkSensorPhase.Active, false),
            23683 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 2, SculkSensorPhase.Cooldown, true),
            23684 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 2, SculkSensorPhase.Cooldown, false),
            23685 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 3, SculkSensorPhase.Inactive, true),
            23686 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 3, SculkSensorPhase.Inactive, false),
            23687 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 3, SculkSensorPhase.Active, true),
            23688 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 3, SculkSensorPhase.Active, false),
            23689 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 3, SculkSensorPhase.Cooldown, true),
            23690 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 3, SculkSensorPhase.Cooldown, false),
            23691 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 4, SculkSensorPhase.Inactive, true),
            23692 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 4, SculkSensorPhase.Inactive, false),
            23693 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 4, SculkSensorPhase.Active, true),
            23694 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 4, SculkSensorPhase.Active, false),
            23695 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 4, SculkSensorPhase.Cooldown, true),
            23696 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 4, SculkSensorPhase.Cooldown, false),
            23697 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 5, SculkSensorPhase.Inactive, true),
            23698 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 5, SculkSensorPhase.Inactive, false),
            23699 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 5, SculkSensorPhase.Active, true),
            23700 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 5, SculkSensorPhase.Active, false),
            23701 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 5, SculkSensorPhase.Cooldown, true),
            23702 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 5, SculkSensorPhase.Cooldown, false),
            23703 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 6, SculkSensorPhase.Inactive, true),
            23704 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 6, SculkSensorPhase.Inactive, false),
            23705 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 6, SculkSensorPhase.Active, true),
            23706 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 6, SculkSensorPhase.Active, false),
            23707 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 6, SculkSensorPhase.Cooldown, true),
            23708 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 6, SculkSensorPhase.Cooldown, false),
            23709 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 7, SculkSensorPhase.Inactive, true),
            23710 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 7, SculkSensorPhase.Inactive, false),
            23711 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 7, SculkSensorPhase.Active, true),
            23712 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 7, SculkSensorPhase.Active, false),
            23713 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 7, SculkSensorPhase.Cooldown, true),
            23714 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 7, SculkSensorPhase.Cooldown, false),
            23715 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 8, SculkSensorPhase.Inactive, true),
            23716 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 8, SculkSensorPhase.Inactive, false),
            23717 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 8, SculkSensorPhase.Active, true),
            23718 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 8, SculkSensorPhase.Active, false),
            23719 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 8, SculkSensorPhase.Cooldown, true),
            23720 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 8, SculkSensorPhase.Cooldown, false),
            23721 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 9, SculkSensorPhase.Inactive, true),
            23722 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 9, SculkSensorPhase.Inactive, false),
            23723 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 9, SculkSensorPhase.Active, true),
            23724 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 9, SculkSensorPhase.Active, false),
            23725 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 9, SculkSensorPhase.Cooldown, true),
            23726 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 9, SculkSensorPhase.Cooldown, false),
            23727 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 10, SculkSensorPhase.Inactive, true),
            23728 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 10, SculkSensorPhase.Inactive, false),
            23729 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 10, SculkSensorPhase.Active, true),
            23730 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 10, SculkSensorPhase.Active, false),
            23731 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 10, SculkSensorPhase.Cooldown, true),
            23732 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 10, SculkSensorPhase.Cooldown, false),
            23733 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 11, SculkSensorPhase.Inactive, true),
            23734 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 11, SculkSensorPhase.Inactive, false),
            23735 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 11, SculkSensorPhase.Active, true),
            23736 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 11, SculkSensorPhase.Active, false),
            23737 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 11, SculkSensorPhase.Cooldown, true),
            23738 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 11, SculkSensorPhase.Cooldown, false),
            23739 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 12, SculkSensorPhase.Inactive, true),
            23740 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 12, SculkSensorPhase.Inactive, false),
            23741 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 12, SculkSensorPhase.Active, true),
            23742 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 12, SculkSensorPhase.Active, false),
            23743 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 12, SculkSensorPhase.Cooldown, true),
            23744 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 12, SculkSensorPhase.Cooldown, false),
            23745 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 13, SculkSensorPhase.Inactive, true),
            23746 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 13, SculkSensorPhase.Inactive, false),
            23747 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 13, SculkSensorPhase.Active, true),
            23748 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 13, SculkSensorPhase.Active, false),
            23749 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 13, SculkSensorPhase.Cooldown, true),
            23750 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 13, SculkSensorPhase.Cooldown, false),
            23751 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 14, SculkSensorPhase.Inactive, true),
            23752 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 14, SculkSensorPhase.Inactive, false),
            23753 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 14, SculkSensorPhase.Active, true),
            23754 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 14, SculkSensorPhase.Active, false),
            23755 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 14, SculkSensorPhase.Cooldown, true),
            23756 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 14, SculkSensorPhase.Cooldown, false),
            23757 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 15, SculkSensorPhase.Inactive, true),
            23758 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 15, SculkSensorPhase.Inactive, false),
            23759 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 15, SculkSensorPhase.Active, true),
            23760 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 15, SculkSensorPhase.Active, false),
            23761 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 15, SculkSensorPhase.Cooldown, true),
            23762 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 15, SculkSensorPhase.Cooldown, false),
            23763 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 0, SculkSensorPhase.Inactive, true),
            23764 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 0, SculkSensorPhase.Inactive, false),
            23765 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 0, SculkSensorPhase.Active, true),
            23766 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 0, SculkSensorPhase.Active, false),
            23767 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 0, SculkSensorPhase.Cooldown, true),
            23768 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 0, SculkSensorPhase.Cooldown, false),
            23769 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 1, SculkSensorPhase.Inactive, true),
            23770 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 1, SculkSensorPhase.Inactive, false),
            23771 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 1, SculkSensorPhase.Active, true),
            23772 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 1, SculkSensorPhase.Active, false),
            23773 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 1, SculkSensorPhase.Cooldown, true),
            23774 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 1, SculkSensorPhase.Cooldown, false),
            23775 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 2, SculkSensorPhase.Inactive, true),
            23776 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 2, SculkSensorPhase.Inactive, false),
            23777 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 2, SculkSensorPhase.Active, true),
            23778 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 2, SculkSensorPhase.Active, false),
            23779 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 2, SculkSensorPhase.Cooldown, true),
            23780 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 2, SculkSensorPhase.Cooldown, false),
            23781 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 3, SculkSensorPhase.Inactive, true),
            23782 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 3, SculkSensorPhase.Inactive, false),
            23783 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 3, SculkSensorPhase.Active, true),
            23784 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 3, SculkSensorPhase.Active, false),
            23785 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 3, SculkSensorPhase.Cooldown, true),
            23786 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 3, SculkSensorPhase.Cooldown, false),
            23787 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 4, SculkSensorPhase.Inactive, true),
            23788 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 4, SculkSensorPhase.Inactive, false),
            23789 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 4, SculkSensorPhase.Active, true),
            23790 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 4, SculkSensorPhase.Active, false),
            23791 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 4, SculkSensorPhase.Cooldown, true),
            23792 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 4, SculkSensorPhase.Cooldown, false),
            23793 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 5, SculkSensorPhase.Inactive, true),
            23794 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 5, SculkSensorPhase.Inactive, false),
            23795 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 5, SculkSensorPhase.Active, true),
            23796 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 5, SculkSensorPhase.Active, false),
            23797 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 5, SculkSensorPhase.Cooldown, true),
            23798 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 5, SculkSensorPhase.Cooldown, false),
            23799 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 6, SculkSensorPhase.Inactive, true),
            23800 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 6, SculkSensorPhase.Inactive, false),
            23801 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 6, SculkSensorPhase.Active, true),
            23802 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 6, SculkSensorPhase.Active, false),
            23803 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 6, SculkSensorPhase.Cooldown, true),
            23804 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 6, SculkSensorPhase.Cooldown, false),
            23805 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 7, SculkSensorPhase.Inactive, true),
            23806 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 7, SculkSensorPhase.Inactive, false),
            23807 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 7, SculkSensorPhase.Active, true),
            23808 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 7, SculkSensorPhase.Active, false),
            23809 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 7, SculkSensorPhase.Cooldown, true),
            23810 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 7, SculkSensorPhase.Cooldown, false),
            23811 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 8, SculkSensorPhase.Inactive, true),
            23812 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 8, SculkSensorPhase.Inactive, false),
            23813 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 8, SculkSensorPhase.Active, true),
            23814 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 8, SculkSensorPhase.Active, false),
            23815 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 8, SculkSensorPhase.Cooldown, true),
            23816 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 8, SculkSensorPhase.Cooldown, false),
            23817 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 9, SculkSensorPhase.Inactive, true),
            23818 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 9, SculkSensorPhase.Inactive, false),
            23819 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 9, SculkSensorPhase.Active, true),
            23820 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 9, SculkSensorPhase.Active, false),
            23821 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 9, SculkSensorPhase.Cooldown, true),
            23822 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 9, SculkSensorPhase.Cooldown, false),
            23823 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 10, SculkSensorPhase.Inactive, true),
            23824 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 10, SculkSensorPhase.Inactive, false),
            23825 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 10, SculkSensorPhase.Active, true),
            23826 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 10, SculkSensorPhase.Active, false),
            23827 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 10, SculkSensorPhase.Cooldown, true),
            23828 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 10, SculkSensorPhase.Cooldown, false),
            23829 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 11, SculkSensorPhase.Inactive, true),
            23830 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 11, SculkSensorPhase.Inactive, false),
            23831 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 11, SculkSensorPhase.Active, true),
            23832 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 11, SculkSensorPhase.Active, false),
            23833 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 11, SculkSensorPhase.Cooldown, true),
            23834 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 11, SculkSensorPhase.Cooldown, false),
            23835 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 12, SculkSensorPhase.Inactive, true),
            23836 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 12, SculkSensorPhase.Inactive, false),
            23837 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 12, SculkSensorPhase.Active, true),
            23838 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 12, SculkSensorPhase.Active, false),
            23839 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 12, SculkSensorPhase.Cooldown, true),
            23840 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 12, SculkSensorPhase.Cooldown, false),
            23841 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 13, SculkSensorPhase.Inactive, true),
            23842 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 13, SculkSensorPhase.Inactive, false),
            23843 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 13, SculkSensorPhase.Active, true),
            23844 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 13, SculkSensorPhase.Active, false),
            23845 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 13, SculkSensorPhase.Cooldown, true),
            23846 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 13, SculkSensorPhase.Cooldown, false),
            23847 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 14, SculkSensorPhase.Inactive, true),
            23848 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 14, SculkSensorPhase.Inactive, false),
            23849 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 14, SculkSensorPhase.Active, true),
            23850 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 14, SculkSensorPhase.Active, false),
            23851 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 14, SculkSensorPhase.Cooldown, true),
            23852 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 14, SculkSensorPhase.Cooldown, false),
            23853 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 15, SculkSensorPhase.Inactive, true),
            23854 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 15, SculkSensorPhase.Inactive, false),
            23855 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 15, SculkSensorPhase.Active, true),
            23856 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 15, SculkSensorPhase.Active, false),
            23857 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 15, SculkSensorPhase.Cooldown, true),
            23858 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 15, SculkSensorPhase.Cooldown, false),
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
