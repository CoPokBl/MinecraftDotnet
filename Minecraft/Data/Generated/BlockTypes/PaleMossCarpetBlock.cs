using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PaleMossCarpetBlock(Identifier Identifier, bool Bottom, WallSide East, WallSide North, WallSide South, WallSide West) : IBlock {
    public Identifier Category => "minecraft:mossy_carpet";
    public int ProtocolId => 1159;
    public double Hardness => 0.1;
    public double ExplosionResistance => 0.1;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "moss_carpet";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:pale_moss_carpet";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.0625, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.0625, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.0625, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 22;
    public string TranslationKey => "block.minecraft.pale_moss_carpet";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Bottom switch {
                true => East switch {
                    WallSide.None => North switch {
                        WallSide.None => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 29502,
                                WallSide.Low => 29503,
                                WallSide.Tall => 29504,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 29505,
                                WallSide.Low => 29506,
                                WallSide.Tall => 29507,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 29508,
                                WallSide.Low => 29509,
                                WallSide.Tall => 29510,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Low => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 29511,
                                WallSide.Low => 29512,
                                WallSide.Tall => 29513,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 29514,
                                WallSide.Low => 29515,
                                WallSide.Tall => 29516,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 29517,
                                WallSide.Low => 29518,
                                WallSide.Tall => 29519,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Tall => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 29520,
                                WallSide.Low => 29521,
                                WallSide.Tall => 29522,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 29523,
                                WallSide.Low => 29524,
                                WallSide.Tall => 29525,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 29526,
                                WallSide.Low => 29527,
                                WallSide.Tall => 29528,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                    },
                    WallSide.Low => North switch {
                        WallSide.None => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 29529,
                                WallSide.Low => 29530,
                                WallSide.Tall => 29531,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 29532,
                                WallSide.Low => 29533,
                                WallSide.Tall => 29534,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 29535,
                                WallSide.Low => 29536,
                                WallSide.Tall => 29537,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Low => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 29538,
                                WallSide.Low => 29539,
                                WallSide.Tall => 29540,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 29541,
                                WallSide.Low => 29542,
                                WallSide.Tall => 29543,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 29544,
                                WallSide.Low => 29545,
                                WallSide.Tall => 29546,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Tall => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 29547,
                                WallSide.Low => 29548,
                                WallSide.Tall => 29549,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 29550,
                                WallSide.Low => 29551,
                                WallSide.Tall => 29552,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 29553,
                                WallSide.Low => 29554,
                                WallSide.Tall => 29555,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                    },
                    WallSide.Tall => North switch {
                        WallSide.None => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 29556,
                                WallSide.Low => 29557,
                                WallSide.Tall => 29558,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 29559,
                                WallSide.Low => 29560,
                                WallSide.Tall => 29561,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 29562,
                                WallSide.Low => 29563,
                                WallSide.Tall => 29564,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Low => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 29565,
                                WallSide.Low => 29566,
                                WallSide.Tall => 29567,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 29568,
                                WallSide.Low => 29569,
                                WallSide.Tall => 29570,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 29571,
                                WallSide.Low => 29572,
                                WallSide.Tall => 29573,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Tall => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 29574,
                                WallSide.Low => 29575,
                                WallSide.Tall => 29576,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 29577,
                                WallSide.Low => 29578,
                                WallSide.Tall => 29579,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 29580,
                                WallSide.Low => 29581,
                                WallSide.Tall => 29582,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(East), East, "Unknown value for property east.")
                },
                false => East switch {
                    WallSide.None => North switch {
                        WallSide.None => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 29583,
                                WallSide.Low => 29584,
                                WallSide.Tall => 29585,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 29586,
                                WallSide.Low => 29587,
                                WallSide.Tall => 29588,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 29589,
                                WallSide.Low => 29590,
                                WallSide.Tall => 29591,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Low => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 29592,
                                WallSide.Low => 29593,
                                WallSide.Tall => 29594,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 29595,
                                WallSide.Low => 29596,
                                WallSide.Tall => 29597,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 29598,
                                WallSide.Low => 29599,
                                WallSide.Tall => 29600,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Tall => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 29601,
                                WallSide.Low => 29602,
                                WallSide.Tall => 29603,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 29604,
                                WallSide.Low => 29605,
                                WallSide.Tall => 29606,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 29607,
                                WallSide.Low => 29608,
                                WallSide.Tall => 29609,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                    },
                    WallSide.Low => North switch {
                        WallSide.None => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 29610,
                                WallSide.Low => 29611,
                                WallSide.Tall => 29612,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 29613,
                                WallSide.Low => 29614,
                                WallSide.Tall => 29615,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 29616,
                                WallSide.Low => 29617,
                                WallSide.Tall => 29618,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Low => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 29619,
                                WallSide.Low => 29620,
                                WallSide.Tall => 29621,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 29622,
                                WallSide.Low => 29623,
                                WallSide.Tall => 29624,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 29625,
                                WallSide.Low => 29626,
                                WallSide.Tall => 29627,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Tall => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 29628,
                                WallSide.Low => 29629,
                                WallSide.Tall => 29630,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 29631,
                                WallSide.Low => 29632,
                                WallSide.Tall => 29633,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 29634,
                                WallSide.Low => 29635,
                                WallSide.Tall => 29636,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                    },
                    WallSide.Tall => North switch {
                        WallSide.None => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 29637,
                                WallSide.Low => 29638,
                                WallSide.Tall => 29639,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 29640,
                                WallSide.Low => 29641,
                                WallSide.Tall => 29642,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 29643,
                                WallSide.Low => 29644,
                                WallSide.Tall => 29645,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Low => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 29646,
                                WallSide.Low => 29647,
                                WallSide.Tall => 29648,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 29649,
                                WallSide.Low => 29650,
                                WallSide.Tall => 29651,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 29652,
                                WallSide.Low => 29653,
                                WallSide.Tall => 29654,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Tall => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 29655,
                                WallSide.Low => 29656,
                                WallSide.Tall => 29657,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 29658,
                                WallSide.Low => 29659,
                                WallSide.Tall => 29660,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 29661,
                                WallSide.Low => 29662,
                                WallSide.Tall => 29663,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(East), East, "Unknown value for property east.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            29502 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.None, WallSide.None),
            29503 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.None, WallSide.Low),
            29504 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.None, WallSide.Tall),
            29505 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.Low, WallSide.None),
            29506 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.Low, WallSide.Low),
            29507 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.Low, WallSide.Tall),
            29508 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.Tall, WallSide.None),
            29509 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.Tall, WallSide.Low),
            29510 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.Tall, WallSide.Tall),
            29511 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.None, WallSide.None),
            29512 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.None, WallSide.Low),
            29513 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.None, WallSide.Tall),
            29514 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.Low, WallSide.None),
            29515 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.Low, WallSide.Low),
            29516 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.Low, WallSide.Tall),
            29517 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.Tall, WallSide.None),
            29518 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.Tall, WallSide.Low),
            29519 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.Tall, WallSide.Tall),
            29520 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.None, WallSide.None),
            29521 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.None, WallSide.Low),
            29522 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.None, WallSide.Tall),
            29523 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.Low, WallSide.None),
            29524 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.Low, WallSide.Low),
            29525 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.Low, WallSide.Tall),
            29526 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.Tall, WallSide.None),
            29527 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.Tall, WallSide.Low),
            29528 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.Tall, WallSide.Tall),
            29529 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.None, WallSide.None),
            29530 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.None, WallSide.Low),
            29531 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.None, WallSide.Tall),
            29532 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.Low, WallSide.None),
            29533 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.Low, WallSide.Low),
            29534 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.Low, WallSide.Tall),
            29535 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.Tall, WallSide.None),
            29536 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.Tall, WallSide.Low),
            29537 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.Tall, WallSide.Tall),
            29538 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.None, WallSide.None),
            29539 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.None, WallSide.Low),
            29540 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.None, WallSide.Tall),
            29541 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.Low, WallSide.None),
            29542 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.Low, WallSide.Low),
            29543 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.Low, WallSide.Tall),
            29544 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.Tall, WallSide.None),
            29545 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.Tall, WallSide.Low),
            29546 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.Tall, WallSide.Tall),
            29547 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.None, WallSide.None),
            29548 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.None, WallSide.Low),
            29549 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.None, WallSide.Tall),
            29550 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.Low, WallSide.None),
            29551 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.Low, WallSide.Low),
            29552 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.Low, WallSide.Tall),
            29553 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.Tall, WallSide.None),
            29554 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.Tall, WallSide.Low),
            29555 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.Tall, WallSide.Tall),
            29556 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.None, WallSide.None),
            29557 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.None, WallSide.Low),
            29558 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.None, WallSide.Tall),
            29559 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.Low, WallSide.None),
            29560 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.Low, WallSide.Low),
            29561 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.Low, WallSide.Tall),
            29562 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.Tall, WallSide.None),
            29563 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.Tall, WallSide.Low),
            29564 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.Tall, WallSide.Tall),
            29565 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.None, WallSide.None),
            29566 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.None, WallSide.Low),
            29567 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.None, WallSide.Tall),
            29568 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.Low, WallSide.None),
            29569 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.Low, WallSide.Low),
            29570 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.Low, WallSide.Tall),
            29571 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.Tall, WallSide.None),
            29572 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.Tall, WallSide.Low),
            29573 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.Tall, WallSide.Tall),
            29574 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.None, WallSide.None),
            29575 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.None, WallSide.Low),
            29576 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.None, WallSide.Tall),
            29577 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.Low, WallSide.None),
            29578 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.Low, WallSide.Low),
            29579 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.Low, WallSide.Tall),
            29580 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.Tall, WallSide.None),
            29581 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.Tall, WallSide.Low),
            29582 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.Tall, WallSide.Tall),
            29583 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.None, WallSide.None),
            29584 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.None, WallSide.Low),
            29585 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.None, WallSide.Tall),
            29586 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.Low, WallSide.None),
            29587 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.Low, WallSide.Low),
            29588 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.Low, WallSide.Tall),
            29589 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.Tall, WallSide.None),
            29590 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.Tall, WallSide.Low),
            29591 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.Tall, WallSide.Tall),
            29592 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.None, WallSide.None),
            29593 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.None, WallSide.Low),
            29594 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.None, WallSide.Tall),
            29595 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.Low, WallSide.None),
            29596 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.Low, WallSide.Low),
            29597 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.Low, WallSide.Tall),
            29598 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.Tall, WallSide.None),
            29599 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.Tall, WallSide.Low),
            29600 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.Tall, WallSide.Tall),
            29601 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.None, WallSide.None),
            29602 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.None, WallSide.Low),
            29603 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.None, WallSide.Tall),
            29604 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.Low, WallSide.None),
            29605 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.Low, WallSide.Low),
            29606 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.Low, WallSide.Tall),
            29607 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.Tall, WallSide.None),
            29608 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.Tall, WallSide.Low),
            29609 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.Tall, WallSide.Tall),
            29610 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.None, WallSide.None),
            29611 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.None, WallSide.Low),
            29612 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.None, WallSide.Tall),
            29613 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.Low, WallSide.None),
            29614 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.Low, WallSide.Low),
            29615 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.Low, WallSide.Tall),
            29616 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.Tall, WallSide.None),
            29617 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.Tall, WallSide.Low),
            29618 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.Tall, WallSide.Tall),
            29619 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.None, WallSide.None),
            29620 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.None, WallSide.Low),
            29621 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.None, WallSide.Tall),
            29622 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.Low, WallSide.None),
            29623 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.Low, WallSide.Low),
            29624 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.Low, WallSide.Tall),
            29625 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.Tall, WallSide.None),
            29626 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.Tall, WallSide.Low),
            29627 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.Tall, WallSide.Tall),
            29628 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.None, WallSide.None),
            29629 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.None, WallSide.Low),
            29630 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.None, WallSide.Tall),
            29631 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.Low, WallSide.None),
            29632 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.Low, WallSide.Low),
            29633 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.Low, WallSide.Tall),
            29634 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.Tall, WallSide.None),
            29635 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.Tall, WallSide.Low),
            29636 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.Tall, WallSide.Tall),
            29637 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.None, WallSide.None),
            29638 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.None, WallSide.Low),
            29639 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.None, WallSide.Tall),
            29640 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.Low, WallSide.None),
            29641 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.Low, WallSide.Low),
            29642 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.Low, WallSide.Tall),
            29643 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.Tall, WallSide.None),
            29644 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.Tall, WallSide.Low),
            29645 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.Tall, WallSide.Tall),
            29646 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.None, WallSide.None),
            29647 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.None, WallSide.Low),
            29648 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.None, WallSide.Tall),
            29649 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.Low, WallSide.None),
            29650 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.Low, WallSide.Low),
            29651 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.Low, WallSide.Tall),
            29652 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.Tall, WallSide.None),
            29653 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.Tall, WallSide.Low),
            29654 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.Tall, WallSide.Tall),
            29655 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.None, WallSide.None),
            29656 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.None, WallSide.Low),
            29657 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.None, WallSide.Tall),
            29658 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.Low, WallSide.None),
            29659 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.Low, WallSide.Low),
            29660 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.Low, WallSide.Tall),
            29661 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.Tall, WallSide.None),
            29662 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.Tall, WallSide.Low),
            29663 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.Tall, WallSide.Tall),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Bottom = properties.ChildrenMap.ContainsKey("bottom") ? properties["bottom"].GetString() == "true" : Bottom,
            East = properties.ChildrenMap.ContainsKey("east") ? WallSideExtensions.FromString(properties["east"].GetString()) : East,
            North = properties.ChildrenMap.ContainsKey("north") ? WallSideExtensions.FromString(properties["north"].GetString()) : North,
            South = properties.ChildrenMap.ContainsKey("south") ? WallSideExtensions.FromString(properties["south"].GetString()) : South,
            West = properties.ChildrenMap.ContainsKey("west") ? WallSideExtensions.FromString(properties["west"].GetString()) : West,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("bottom", Bottom.ToString().ToLower()),
            new StringTag("east", East.ToName()),
            new StringTag("north", North.ToName()),
            new StringTag("south", South.ToName()),
            new StringTag("west", West.ToName())
        );
    }
    
}
