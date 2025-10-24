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
    public int ProtocolId => 1000;
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
                            true => 24584,
                            false => 24585,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24586,
                            false => 24587,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24588,
                            false => 24589,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    1 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24590,
                            false => 24591,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24592,
                            false => 24593,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24594,
                            false => 24595,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    2 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24596,
                            false => 24597,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24598,
                            false => 24599,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24600,
                            false => 24601,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    3 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24602,
                            false => 24603,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24604,
                            false => 24605,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24606,
                            false => 24607,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    4 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24608,
                            false => 24609,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24610,
                            false => 24611,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24612,
                            false => 24613,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    5 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24614,
                            false => 24615,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24616,
                            false => 24617,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24618,
                            false => 24619,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    6 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24620,
                            false => 24621,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24622,
                            false => 24623,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24624,
                            false => 24625,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    7 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24626,
                            false => 24627,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24628,
                            false => 24629,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24630,
                            false => 24631,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    8 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24632,
                            false => 24633,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24634,
                            false => 24635,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24636,
                            false => 24637,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    9 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24638,
                            false => 24639,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24640,
                            false => 24641,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24642,
                            false => 24643,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    10 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24644,
                            false => 24645,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24646,
                            false => 24647,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24648,
                            false => 24649,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    11 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24650,
                            false => 24651,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24652,
                            false => 24653,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24654,
                            false => 24655,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    12 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24656,
                            false => 24657,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24658,
                            false => 24659,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24660,
                            false => 24661,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    13 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24662,
                            false => 24663,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24664,
                            false => 24665,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24666,
                            false => 24667,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    14 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24668,
                            false => 24669,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24670,
                            false => 24671,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24672,
                            false => 24673,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    15 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24674,
                            false => 24675,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24676,
                            false => 24677,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24678,
                            false => 24679,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                },
                Direction.South => Power switch {
                    0 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24680,
                            false => 24681,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24682,
                            false => 24683,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24684,
                            false => 24685,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    1 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24686,
                            false => 24687,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24688,
                            false => 24689,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24690,
                            false => 24691,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    2 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24692,
                            false => 24693,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24694,
                            false => 24695,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24696,
                            false => 24697,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    3 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24698,
                            false => 24699,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24700,
                            false => 24701,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24702,
                            false => 24703,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    4 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24704,
                            false => 24705,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24706,
                            false => 24707,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24708,
                            false => 24709,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    5 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24710,
                            false => 24711,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24712,
                            false => 24713,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24714,
                            false => 24715,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    6 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24716,
                            false => 24717,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24718,
                            false => 24719,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24720,
                            false => 24721,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    7 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24722,
                            false => 24723,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24724,
                            false => 24725,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24726,
                            false => 24727,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    8 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24728,
                            false => 24729,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24730,
                            false => 24731,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24732,
                            false => 24733,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    9 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24734,
                            false => 24735,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24736,
                            false => 24737,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24738,
                            false => 24739,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    10 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24740,
                            false => 24741,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24742,
                            false => 24743,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24744,
                            false => 24745,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    11 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24746,
                            false => 24747,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24748,
                            false => 24749,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24750,
                            false => 24751,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    12 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24752,
                            false => 24753,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24754,
                            false => 24755,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24756,
                            false => 24757,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    13 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24758,
                            false => 24759,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24760,
                            false => 24761,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24762,
                            false => 24763,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    14 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24764,
                            false => 24765,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24766,
                            false => 24767,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24768,
                            false => 24769,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    15 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24770,
                            false => 24771,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24772,
                            false => 24773,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24774,
                            false => 24775,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                },
                Direction.West => Power switch {
                    0 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24776,
                            false => 24777,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24778,
                            false => 24779,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24780,
                            false => 24781,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    1 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24782,
                            false => 24783,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24784,
                            false => 24785,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24786,
                            false => 24787,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    2 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24788,
                            false => 24789,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24790,
                            false => 24791,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24792,
                            false => 24793,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    3 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24794,
                            false => 24795,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24796,
                            false => 24797,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24798,
                            false => 24799,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    4 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24800,
                            false => 24801,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24802,
                            false => 24803,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24804,
                            false => 24805,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    5 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24806,
                            false => 24807,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24808,
                            false => 24809,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24810,
                            false => 24811,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    6 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24812,
                            false => 24813,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24814,
                            false => 24815,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24816,
                            false => 24817,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    7 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24818,
                            false => 24819,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24820,
                            false => 24821,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24822,
                            false => 24823,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    8 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24824,
                            false => 24825,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24826,
                            false => 24827,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24828,
                            false => 24829,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    9 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24830,
                            false => 24831,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24832,
                            false => 24833,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24834,
                            false => 24835,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    10 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24836,
                            false => 24837,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24838,
                            false => 24839,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24840,
                            false => 24841,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    11 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24842,
                            false => 24843,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24844,
                            false => 24845,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24846,
                            false => 24847,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    12 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24848,
                            false => 24849,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24850,
                            false => 24851,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24852,
                            false => 24853,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    13 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24854,
                            false => 24855,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24856,
                            false => 24857,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24858,
                            false => 24859,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    14 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24860,
                            false => 24861,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24862,
                            false => 24863,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24864,
                            false => 24865,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    15 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24866,
                            false => 24867,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24868,
                            false => 24869,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24870,
                            false => 24871,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                },
                Direction.East => Power switch {
                    0 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24872,
                            false => 24873,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24874,
                            false => 24875,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24876,
                            false => 24877,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    1 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24878,
                            false => 24879,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24880,
                            false => 24881,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24882,
                            false => 24883,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    2 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24884,
                            false => 24885,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24886,
                            false => 24887,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24888,
                            false => 24889,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    3 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24890,
                            false => 24891,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24892,
                            false => 24893,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24894,
                            false => 24895,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    4 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24896,
                            false => 24897,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24898,
                            false => 24899,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24900,
                            false => 24901,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    5 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24902,
                            false => 24903,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24904,
                            false => 24905,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24906,
                            false => 24907,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    6 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24908,
                            false => 24909,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24910,
                            false => 24911,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24912,
                            false => 24913,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    7 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24914,
                            false => 24915,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24916,
                            false => 24917,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24918,
                            false => 24919,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    8 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24920,
                            false => 24921,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24922,
                            false => 24923,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24924,
                            false => 24925,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    9 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24926,
                            false => 24927,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24928,
                            false => 24929,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24930,
                            false => 24931,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    10 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24932,
                            false => 24933,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24934,
                            false => 24935,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24936,
                            false => 24937,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    11 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24938,
                            false => 24939,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24940,
                            false => 24941,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24942,
                            false => 24943,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    12 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24944,
                            false => 24945,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24946,
                            false => 24947,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24948,
                            false => 24949,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    13 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24950,
                            false => 24951,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24952,
                            false => 24953,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24954,
                            false => 24955,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    14 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24956,
                            false => 24957,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24958,
                            false => 24959,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24960,
                            false => 24961,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                    },
                    15 => SculkSensorPhase switch {
                        SculkSensorPhase.Inactive => Waterlogged switch {
                            true => 24962,
                            false => 24963,
                        },
                        SculkSensorPhase.Active => Waterlogged switch {
                            true => 24964,
                            false => 24965,
                        },
                        SculkSensorPhase.Cooldown => Waterlogged switch {
                            true => 24966,
                            false => 24967,
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
            24584 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 0, SculkSensorPhase.Inactive, true),
            24585 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 0, SculkSensorPhase.Inactive, false),
            24586 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 0, SculkSensorPhase.Active, true),
            24587 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 0, SculkSensorPhase.Active, false),
            24588 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 0, SculkSensorPhase.Cooldown, true),
            24589 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 0, SculkSensorPhase.Cooldown, false),
            24590 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 1, SculkSensorPhase.Inactive, true),
            24591 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 1, SculkSensorPhase.Inactive, false),
            24592 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 1, SculkSensorPhase.Active, true),
            24593 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 1, SculkSensorPhase.Active, false),
            24594 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 1, SculkSensorPhase.Cooldown, true),
            24595 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 1, SculkSensorPhase.Cooldown, false),
            24596 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 2, SculkSensorPhase.Inactive, true),
            24597 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 2, SculkSensorPhase.Inactive, false),
            24598 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 2, SculkSensorPhase.Active, true),
            24599 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 2, SculkSensorPhase.Active, false),
            24600 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 2, SculkSensorPhase.Cooldown, true),
            24601 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 2, SculkSensorPhase.Cooldown, false),
            24602 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 3, SculkSensorPhase.Inactive, true),
            24603 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 3, SculkSensorPhase.Inactive, false),
            24604 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 3, SculkSensorPhase.Active, true),
            24605 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 3, SculkSensorPhase.Active, false),
            24606 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 3, SculkSensorPhase.Cooldown, true),
            24607 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 3, SculkSensorPhase.Cooldown, false),
            24608 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 4, SculkSensorPhase.Inactive, true),
            24609 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 4, SculkSensorPhase.Inactive, false),
            24610 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 4, SculkSensorPhase.Active, true),
            24611 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 4, SculkSensorPhase.Active, false),
            24612 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 4, SculkSensorPhase.Cooldown, true),
            24613 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 4, SculkSensorPhase.Cooldown, false),
            24614 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 5, SculkSensorPhase.Inactive, true),
            24615 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 5, SculkSensorPhase.Inactive, false),
            24616 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 5, SculkSensorPhase.Active, true),
            24617 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 5, SculkSensorPhase.Active, false),
            24618 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 5, SculkSensorPhase.Cooldown, true),
            24619 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 5, SculkSensorPhase.Cooldown, false),
            24620 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 6, SculkSensorPhase.Inactive, true),
            24621 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 6, SculkSensorPhase.Inactive, false),
            24622 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 6, SculkSensorPhase.Active, true),
            24623 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 6, SculkSensorPhase.Active, false),
            24624 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 6, SculkSensorPhase.Cooldown, true),
            24625 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 6, SculkSensorPhase.Cooldown, false),
            24626 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 7, SculkSensorPhase.Inactive, true),
            24627 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 7, SculkSensorPhase.Inactive, false),
            24628 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 7, SculkSensorPhase.Active, true),
            24629 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 7, SculkSensorPhase.Active, false),
            24630 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 7, SculkSensorPhase.Cooldown, true),
            24631 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 7, SculkSensorPhase.Cooldown, false),
            24632 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 8, SculkSensorPhase.Inactive, true),
            24633 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 8, SculkSensorPhase.Inactive, false),
            24634 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 8, SculkSensorPhase.Active, true),
            24635 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 8, SculkSensorPhase.Active, false),
            24636 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 8, SculkSensorPhase.Cooldown, true),
            24637 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 8, SculkSensorPhase.Cooldown, false),
            24638 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 9, SculkSensorPhase.Inactive, true),
            24639 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 9, SculkSensorPhase.Inactive, false),
            24640 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 9, SculkSensorPhase.Active, true),
            24641 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 9, SculkSensorPhase.Active, false),
            24642 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 9, SculkSensorPhase.Cooldown, true),
            24643 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 9, SculkSensorPhase.Cooldown, false),
            24644 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 10, SculkSensorPhase.Inactive, true),
            24645 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 10, SculkSensorPhase.Inactive, false),
            24646 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 10, SculkSensorPhase.Active, true),
            24647 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 10, SculkSensorPhase.Active, false),
            24648 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 10, SculkSensorPhase.Cooldown, true),
            24649 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 10, SculkSensorPhase.Cooldown, false),
            24650 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 11, SculkSensorPhase.Inactive, true),
            24651 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 11, SculkSensorPhase.Inactive, false),
            24652 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 11, SculkSensorPhase.Active, true),
            24653 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 11, SculkSensorPhase.Active, false),
            24654 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 11, SculkSensorPhase.Cooldown, true),
            24655 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 11, SculkSensorPhase.Cooldown, false),
            24656 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 12, SculkSensorPhase.Inactive, true),
            24657 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 12, SculkSensorPhase.Inactive, false),
            24658 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 12, SculkSensorPhase.Active, true),
            24659 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 12, SculkSensorPhase.Active, false),
            24660 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 12, SculkSensorPhase.Cooldown, true),
            24661 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 12, SculkSensorPhase.Cooldown, false),
            24662 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 13, SculkSensorPhase.Inactive, true),
            24663 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 13, SculkSensorPhase.Inactive, false),
            24664 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 13, SculkSensorPhase.Active, true),
            24665 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 13, SculkSensorPhase.Active, false),
            24666 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 13, SculkSensorPhase.Cooldown, true),
            24667 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 13, SculkSensorPhase.Cooldown, false),
            24668 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 14, SculkSensorPhase.Inactive, true),
            24669 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 14, SculkSensorPhase.Inactive, false),
            24670 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 14, SculkSensorPhase.Active, true),
            24671 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 14, SculkSensorPhase.Active, false),
            24672 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 14, SculkSensorPhase.Cooldown, true),
            24673 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 14, SculkSensorPhase.Cooldown, false),
            24674 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 15, SculkSensorPhase.Inactive, true),
            24675 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 15, SculkSensorPhase.Inactive, false),
            24676 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 15, SculkSensorPhase.Active, true),
            24677 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 15, SculkSensorPhase.Active, false),
            24678 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 15, SculkSensorPhase.Cooldown, true),
            24679 => new CalibratedSculkSensorBlock(Identifier, Direction.North, 15, SculkSensorPhase.Cooldown, false),
            24680 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 0, SculkSensorPhase.Inactive, true),
            24681 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 0, SculkSensorPhase.Inactive, false),
            24682 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 0, SculkSensorPhase.Active, true),
            24683 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 0, SculkSensorPhase.Active, false),
            24684 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 0, SculkSensorPhase.Cooldown, true),
            24685 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 0, SculkSensorPhase.Cooldown, false),
            24686 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 1, SculkSensorPhase.Inactive, true),
            24687 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 1, SculkSensorPhase.Inactive, false),
            24688 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 1, SculkSensorPhase.Active, true),
            24689 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 1, SculkSensorPhase.Active, false),
            24690 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 1, SculkSensorPhase.Cooldown, true),
            24691 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 1, SculkSensorPhase.Cooldown, false),
            24692 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 2, SculkSensorPhase.Inactive, true),
            24693 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 2, SculkSensorPhase.Inactive, false),
            24694 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 2, SculkSensorPhase.Active, true),
            24695 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 2, SculkSensorPhase.Active, false),
            24696 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 2, SculkSensorPhase.Cooldown, true),
            24697 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 2, SculkSensorPhase.Cooldown, false),
            24698 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 3, SculkSensorPhase.Inactive, true),
            24699 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 3, SculkSensorPhase.Inactive, false),
            24700 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 3, SculkSensorPhase.Active, true),
            24701 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 3, SculkSensorPhase.Active, false),
            24702 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 3, SculkSensorPhase.Cooldown, true),
            24703 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 3, SculkSensorPhase.Cooldown, false),
            24704 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 4, SculkSensorPhase.Inactive, true),
            24705 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 4, SculkSensorPhase.Inactive, false),
            24706 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 4, SculkSensorPhase.Active, true),
            24707 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 4, SculkSensorPhase.Active, false),
            24708 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 4, SculkSensorPhase.Cooldown, true),
            24709 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 4, SculkSensorPhase.Cooldown, false),
            24710 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 5, SculkSensorPhase.Inactive, true),
            24711 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 5, SculkSensorPhase.Inactive, false),
            24712 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 5, SculkSensorPhase.Active, true),
            24713 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 5, SculkSensorPhase.Active, false),
            24714 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 5, SculkSensorPhase.Cooldown, true),
            24715 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 5, SculkSensorPhase.Cooldown, false),
            24716 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 6, SculkSensorPhase.Inactive, true),
            24717 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 6, SculkSensorPhase.Inactive, false),
            24718 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 6, SculkSensorPhase.Active, true),
            24719 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 6, SculkSensorPhase.Active, false),
            24720 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 6, SculkSensorPhase.Cooldown, true),
            24721 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 6, SculkSensorPhase.Cooldown, false),
            24722 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 7, SculkSensorPhase.Inactive, true),
            24723 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 7, SculkSensorPhase.Inactive, false),
            24724 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 7, SculkSensorPhase.Active, true),
            24725 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 7, SculkSensorPhase.Active, false),
            24726 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 7, SculkSensorPhase.Cooldown, true),
            24727 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 7, SculkSensorPhase.Cooldown, false),
            24728 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 8, SculkSensorPhase.Inactive, true),
            24729 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 8, SculkSensorPhase.Inactive, false),
            24730 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 8, SculkSensorPhase.Active, true),
            24731 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 8, SculkSensorPhase.Active, false),
            24732 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 8, SculkSensorPhase.Cooldown, true),
            24733 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 8, SculkSensorPhase.Cooldown, false),
            24734 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 9, SculkSensorPhase.Inactive, true),
            24735 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 9, SculkSensorPhase.Inactive, false),
            24736 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 9, SculkSensorPhase.Active, true),
            24737 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 9, SculkSensorPhase.Active, false),
            24738 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 9, SculkSensorPhase.Cooldown, true),
            24739 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 9, SculkSensorPhase.Cooldown, false),
            24740 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 10, SculkSensorPhase.Inactive, true),
            24741 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 10, SculkSensorPhase.Inactive, false),
            24742 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 10, SculkSensorPhase.Active, true),
            24743 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 10, SculkSensorPhase.Active, false),
            24744 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 10, SculkSensorPhase.Cooldown, true),
            24745 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 10, SculkSensorPhase.Cooldown, false),
            24746 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 11, SculkSensorPhase.Inactive, true),
            24747 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 11, SculkSensorPhase.Inactive, false),
            24748 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 11, SculkSensorPhase.Active, true),
            24749 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 11, SculkSensorPhase.Active, false),
            24750 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 11, SculkSensorPhase.Cooldown, true),
            24751 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 11, SculkSensorPhase.Cooldown, false),
            24752 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 12, SculkSensorPhase.Inactive, true),
            24753 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 12, SculkSensorPhase.Inactive, false),
            24754 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 12, SculkSensorPhase.Active, true),
            24755 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 12, SculkSensorPhase.Active, false),
            24756 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 12, SculkSensorPhase.Cooldown, true),
            24757 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 12, SculkSensorPhase.Cooldown, false),
            24758 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 13, SculkSensorPhase.Inactive, true),
            24759 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 13, SculkSensorPhase.Inactive, false),
            24760 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 13, SculkSensorPhase.Active, true),
            24761 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 13, SculkSensorPhase.Active, false),
            24762 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 13, SculkSensorPhase.Cooldown, true),
            24763 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 13, SculkSensorPhase.Cooldown, false),
            24764 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 14, SculkSensorPhase.Inactive, true),
            24765 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 14, SculkSensorPhase.Inactive, false),
            24766 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 14, SculkSensorPhase.Active, true),
            24767 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 14, SculkSensorPhase.Active, false),
            24768 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 14, SculkSensorPhase.Cooldown, true),
            24769 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 14, SculkSensorPhase.Cooldown, false),
            24770 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 15, SculkSensorPhase.Inactive, true),
            24771 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 15, SculkSensorPhase.Inactive, false),
            24772 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 15, SculkSensorPhase.Active, true),
            24773 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 15, SculkSensorPhase.Active, false),
            24774 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 15, SculkSensorPhase.Cooldown, true),
            24775 => new CalibratedSculkSensorBlock(Identifier, Direction.South, 15, SculkSensorPhase.Cooldown, false),
            24776 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 0, SculkSensorPhase.Inactive, true),
            24777 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 0, SculkSensorPhase.Inactive, false),
            24778 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 0, SculkSensorPhase.Active, true),
            24779 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 0, SculkSensorPhase.Active, false),
            24780 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 0, SculkSensorPhase.Cooldown, true),
            24781 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 0, SculkSensorPhase.Cooldown, false),
            24782 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 1, SculkSensorPhase.Inactive, true),
            24783 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 1, SculkSensorPhase.Inactive, false),
            24784 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 1, SculkSensorPhase.Active, true),
            24785 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 1, SculkSensorPhase.Active, false),
            24786 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 1, SculkSensorPhase.Cooldown, true),
            24787 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 1, SculkSensorPhase.Cooldown, false),
            24788 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 2, SculkSensorPhase.Inactive, true),
            24789 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 2, SculkSensorPhase.Inactive, false),
            24790 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 2, SculkSensorPhase.Active, true),
            24791 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 2, SculkSensorPhase.Active, false),
            24792 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 2, SculkSensorPhase.Cooldown, true),
            24793 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 2, SculkSensorPhase.Cooldown, false),
            24794 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 3, SculkSensorPhase.Inactive, true),
            24795 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 3, SculkSensorPhase.Inactive, false),
            24796 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 3, SculkSensorPhase.Active, true),
            24797 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 3, SculkSensorPhase.Active, false),
            24798 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 3, SculkSensorPhase.Cooldown, true),
            24799 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 3, SculkSensorPhase.Cooldown, false),
            24800 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 4, SculkSensorPhase.Inactive, true),
            24801 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 4, SculkSensorPhase.Inactive, false),
            24802 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 4, SculkSensorPhase.Active, true),
            24803 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 4, SculkSensorPhase.Active, false),
            24804 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 4, SculkSensorPhase.Cooldown, true),
            24805 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 4, SculkSensorPhase.Cooldown, false),
            24806 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 5, SculkSensorPhase.Inactive, true),
            24807 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 5, SculkSensorPhase.Inactive, false),
            24808 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 5, SculkSensorPhase.Active, true),
            24809 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 5, SculkSensorPhase.Active, false),
            24810 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 5, SculkSensorPhase.Cooldown, true),
            24811 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 5, SculkSensorPhase.Cooldown, false),
            24812 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 6, SculkSensorPhase.Inactive, true),
            24813 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 6, SculkSensorPhase.Inactive, false),
            24814 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 6, SculkSensorPhase.Active, true),
            24815 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 6, SculkSensorPhase.Active, false),
            24816 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 6, SculkSensorPhase.Cooldown, true),
            24817 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 6, SculkSensorPhase.Cooldown, false),
            24818 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 7, SculkSensorPhase.Inactive, true),
            24819 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 7, SculkSensorPhase.Inactive, false),
            24820 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 7, SculkSensorPhase.Active, true),
            24821 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 7, SculkSensorPhase.Active, false),
            24822 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 7, SculkSensorPhase.Cooldown, true),
            24823 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 7, SculkSensorPhase.Cooldown, false),
            24824 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 8, SculkSensorPhase.Inactive, true),
            24825 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 8, SculkSensorPhase.Inactive, false),
            24826 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 8, SculkSensorPhase.Active, true),
            24827 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 8, SculkSensorPhase.Active, false),
            24828 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 8, SculkSensorPhase.Cooldown, true),
            24829 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 8, SculkSensorPhase.Cooldown, false),
            24830 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 9, SculkSensorPhase.Inactive, true),
            24831 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 9, SculkSensorPhase.Inactive, false),
            24832 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 9, SculkSensorPhase.Active, true),
            24833 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 9, SculkSensorPhase.Active, false),
            24834 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 9, SculkSensorPhase.Cooldown, true),
            24835 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 9, SculkSensorPhase.Cooldown, false),
            24836 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 10, SculkSensorPhase.Inactive, true),
            24837 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 10, SculkSensorPhase.Inactive, false),
            24838 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 10, SculkSensorPhase.Active, true),
            24839 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 10, SculkSensorPhase.Active, false),
            24840 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 10, SculkSensorPhase.Cooldown, true),
            24841 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 10, SculkSensorPhase.Cooldown, false),
            24842 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 11, SculkSensorPhase.Inactive, true),
            24843 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 11, SculkSensorPhase.Inactive, false),
            24844 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 11, SculkSensorPhase.Active, true),
            24845 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 11, SculkSensorPhase.Active, false),
            24846 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 11, SculkSensorPhase.Cooldown, true),
            24847 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 11, SculkSensorPhase.Cooldown, false),
            24848 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 12, SculkSensorPhase.Inactive, true),
            24849 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 12, SculkSensorPhase.Inactive, false),
            24850 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 12, SculkSensorPhase.Active, true),
            24851 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 12, SculkSensorPhase.Active, false),
            24852 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 12, SculkSensorPhase.Cooldown, true),
            24853 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 12, SculkSensorPhase.Cooldown, false),
            24854 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 13, SculkSensorPhase.Inactive, true),
            24855 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 13, SculkSensorPhase.Inactive, false),
            24856 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 13, SculkSensorPhase.Active, true),
            24857 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 13, SculkSensorPhase.Active, false),
            24858 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 13, SculkSensorPhase.Cooldown, true),
            24859 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 13, SculkSensorPhase.Cooldown, false),
            24860 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 14, SculkSensorPhase.Inactive, true),
            24861 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 14, SculkSensorPhase.Inactive, false),
            24862 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 14, SculkSensorPhase.Active, true),
            24863 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 14, SculkSensorPhase.Active, false),
            24864 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 14, SculkSensorPhase.Cooldown, true),
            24865 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 14, SculkSensorPhase.Cooldown, false),
            24866 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 15, SculkSensorPhase.Inactive, true),
            24867 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 15, SculkSensorPhase.Inactive, false),
            24868 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 15, SculkSensorPhase.Active, true),
            24869 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 15, SculkSensorPhase.Active, false),
            24870 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 15, SculkSensorPhase.Cooldown, true),
            24871 => new CalibratedSculkSensorBlock(Identifier, Direction.West, 15, SculkSensorPhase.Cooldown, false),
            24872 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 0, SculkSensorPhase.Inactive, true),
            24873 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 0, SculkSensorPhase.Inactive, false),
            24874 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 0, SculkSensorPhase.Active, true),
            24875 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 0, SculkSensorPhase.Active, false),
            24876 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 0, SculkSensorPhase.Cooldown, true),
            24877 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 0, SculkSensorPhase.Cooldown, false),
            24878 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 1, SculkSensorPhase.Inactive, true),
            24879 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 1, SculkSensorPhase.Inactive, false),
            24880 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 1, SculkSensorPhase.Active, true),
            24881 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 1, SculkSensorPhase.Active, false),
            24882 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 1, SculkSensorPhase.Cooldown, true),
            24883 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 1, SculkSensorPhase.Cooldown, false),
            24884 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 2, SculkSensorPhase.Inactive, true),
            24885 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 2, SculkSensorPhase.Inactive, false),
            24886 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 2, SculkSensorPhase.Active, true),
            24887 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 2, SculkSensorPhase.Active, false),
            24888 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 2, SculkSensorPhase.Cooldown, true),
            24889 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 2, SculkSensorPhase.Cooldown, false),
            24890 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 3, SculkSensorPhase.Inactive, true),
            24891 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 3, SculkSensorPhase.Inactive, false),
            24892 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 3, SculkSensorPhase.Active, true),
            24893 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 3, SculkSensorPhase.Active, false),
            24894 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 3, SculkSensorPhase.Cooldown, true),
            24895 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 3, SculkSensorPhase.Cooldown, false),
            24896 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 4, SculkSensorPhase.Inactive, true),
            24897 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 4, SculkSensorPhase.Inactive, false),
            24898 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 4, SculkSensorPhase.Active, true),
            24899 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 4, SculkSensorPhase.Active, false),
            24900 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 4, SculkSensorPhase.Cooldown, true),
            24901 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 4, SculkSensorPhase.Cooldown, false),
            24902 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 5, SculkSensorPhase.Inactive, true),
            24903 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 5, SculkSensorPhase.Inactive, false),
            24904 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 5, SculkSensorPhase.Active, true),
            24905 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 5, SculkSensorPhase.Active, false),
            24906 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 5, SculkSensorPhase.Cooldown, true),
            24907 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 5, SculkSensorPhase.Cooldown, false),
            24908 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 6, SculkSensorPhase.Inactive, true),
            24909 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 6, SculkSensorPhase.Inactive, false),
            24910 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 6, SculkSensorPhase.Active, true),
            24911 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 6, SculkSensorPhase.Active, false),
            24912 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 6, SculkSensorPhase.Cooldown, true),
            24913 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 6, SculkSensorPhase.Cooldown, false),
            24914 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 7, SculkSensorPhase.Inactive, true),
            24915 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 7, SculkSensorPhase.Inactive, false),
            24916 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 7, SculkSensorPhase.Active, true),
            24917 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 7, SculkSensorPhase.Active, false),
            24918 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 7, SculkSensorPhase.Cooldown, true),
            24919 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 7, SculkSensorPhase.Cooldown, false),
            24920 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 8, SculkSensorPhase.Inactive, true),
            24921 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 8, SculkSensorPhase.Inactive, false),
            24922 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 8, SculkSensorPhase.Active, true),
            24923 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 8, SculkSensorPhase.Active, false),
            24924 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 8, SculkSensorPhase.Cooldown, true),
            24925 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 8, SculkSensorPhase.Cooldown, false),
            24926 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 9, SculkSensorPhase.Inactive, true),
            24927 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 9, SculkSensorPhase.Inactive, false),
            24928 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 9, SculkSensorPhase.Active, true),
            24929 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 9, SculkSensorPhase.Active, false),
            24930 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 9, SculkSensorPhase.Cooldown, true),
            24931 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 9, SculkSensorPhase.Cooldown, false),
            24932 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 10, SculkSensorPhase.Inactive, true),
            24933 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 10, SculkSensorPhase.Inactive, false),
            24934 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 10, SculkSensorPhase.Active, true),
            24935 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 10, SculkSensorPhase.Active, false),
            24936 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 10, SculkSensorPhase.Cooldown, true),
            24937 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 10, SculkSensorPhase.Cooldown, false),
            24938 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 11, SculkSensorPhase.Inactive, true),
            24939 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 11, SculkSensorPhase.Inactive, false),
            24940 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 11, SculkSensorPhase.Active, true),
            24941 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 11, SculkSensorPhase.Active, false),
            24942 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 11, SculkSensorPhase.Cooldown, true),
            24943 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 11, SculkSensorPhase.Cooldown, false),
            24944 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 12, SculkSensorPhase.Inactive, true),
            24945 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 12, SculkSensorPhase.Inactive, false),
            24946 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 12, SculkSensorPhase.Active, true),
            24947 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 12, SculkSensorPhase.Active, false),
            24948 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 12, SculkSensorPhase.Cooldown, true),
            24949 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 12, SculkSensorPhase.Cooldown, false),
            24950 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 13, SculkSensorPhase.Inactive, true),
            24951 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 13, SculkSensorPhase.Inactive, false),
            24952 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 13, SculkSensorPhase.Active, true),
            24953 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 13, SculkSensorPhase.Active, false),
            24954 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 13, SculkSensorPhase.Cooldown, true),
            24955 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 13, SculkSensorPhase.Cooldown, false),
            24956 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 14, SculkSensorPhase.Inactive, true),
            24957 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 14, SculkSensorPhase.Inactive, false),
            24958 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 14, SculkSensorPhase.Active, true),
            24959 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 14, SculkSensorPhase.Active, false),
            24960 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 14, SculkSensorPhase.Cooldown, true),
            24961 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 14, SculkSensorPhase.Cooldown, false),
            24962 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 15, SculkSensorPhase.Inactive, true),
            24963 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 15, SculkSensorPhase.Inactive, false),
            24964 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 15, SculkSensorPhase.Active, true),
            24965 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 15, SculkSensorPhase.Active, false),
            24966 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 15, SculkSensorPhase.Cooldown, true),
            24967 => new CalibratedSculkSensorBlock(Identifier, Direction.East, 15, SculkSensorPhase.Cooldown, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Power = properties.ChildrenMap.ContainsKey("power") ? int.Parse(properties["power"].GetString()) : Power,
            SculkSensorPhase = properties.ChildrenMap.ContainsKey("sculk_sensor_phase") ? SculkSensorPhaseExtensions.FromString(properties["sculk_sensor_phase"].GetString()) : SculkSensorPhase,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("facing", Facing.ToName()),
            new StringTag("power", Power.ToString()),
            new StringTag("sculk_sensor_phase", SculkSensorPhase.ToName()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
        );
    }
    
}
