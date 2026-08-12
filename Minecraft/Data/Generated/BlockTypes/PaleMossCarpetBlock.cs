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
                                WallSide.None => 32197,
                                WallSide.Low => 32198,
                                WallSide.Tall => 32199,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 32200,
                                WallSide.Low => 32201,
                                WallSide.Tall => 32202,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 32203,
                                WallSide.Low => 32204,
                                WallSide.Tall => 32205,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Low => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 32206,
                                WallSide.Low => 32207,
                                WallSide.Tall => 32208,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 32209,
                                WallSide.Low => 32210,
                                WallSide.Tall => 32211,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 32212,
                                WallSide.Low => 32213,
                                WallSide.Tall => 32214,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Tall => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 32215,
                                WallSide.Low => 32216,
                                WallSide.Tall => 32217,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 32218,
                                WallSide.Low => 32219,
                                WallSide.Tall => 32220,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 32221,
                                WallSide.Low => 32222,
                                WallSide.Tall => 32223,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                    },
                    WallSide.Low => North switch {
                        WallSide.None => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 32224,
                                WallSide.Low => 32225,
                                WallSide.Tall => 32226,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 32227,
                                WallSide.Low => 32228,
                                WallSide.Tall => 32229,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 32230,
                                WallSide.Low => 32231,
                                WallSide.Tall => 32232,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Low => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 32233,
                                WallSide.Low => 32234,
                                WallSide.Tall => 32235,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 32236,
                                WallSide.Low => 32237,
                                WallSide.Tall => 32238,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 32239,
                                WallSide.Low => 32240,
                                WallSide.Tall => 32241,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Tall => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 32242,
                                WallSide.Low => 32243,
                                WallSide.Tall => 32244,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 32245,
                                WallSide.Low => 32246,
                                WallSide.Tall => 32247,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 32248,
                                WallSide.Low => 32249,
                                WallSide.Tall => 32250,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                    },
                    WallSide.Tall => North switch {
                        WallSide.None => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 32251,
                                WallSide.Low => 32252,
                                WallSide.Tall => 32253,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 32254,
                                WallSide.Low => 32255,
                                WallSide.Tall => 32256,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 32257,
                                WallSide.Low => 32258,
                                WallSide.Tall => 32259,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Low => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 32260,
                                WallSide.Low => 32261,
                                WallSide.Tall => 32262,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 32263,
                                WallSide.Low => 32264,
                                WallSide.Tall => 32265,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 32266,
                                WallSide.Low => 32267,
                                WallSide.Tall => 32268,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Tall => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 32269,
                                WallSide.Low => 32270,
                                WallSide.Tall => 32271,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 32272,
                                WallSide.Low => 32273,
                                WallSide.Tall => 32274,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 32275,
                                WallSide.Low => 32276,
                                WallSide.Tall => 32277,
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
                                WallSide.None => 32278,
                                WallSide.Low => 32279,
                                WallSide.Tall => 32280,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 32281,
                                WallSide.Low => 32282,
                                WallSide.Tall => 32283,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 32284,
                                WallSide.Low => 32285,
                                WallSide.Tall => 32286,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Low => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 32287,
                                WallSide.Low => 32288,
                                WallSide.Tall => 32289,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 32290,
                                WallSide.Low => 32291,
                                WallSide.Tall => 32292,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 32293,
                                WallSide.Low => 32294,
                                WallSide.Tall => 32295,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Tall => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 32296,
                                WallSide.Low => 32297,
                                WallSide.Tall => 32298,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 32299,
                                WallSide.Low => 32300,
                                WallSide.Tall => 32301,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 32302,
                                WallSide.Low => 32303,
                                WallSide.Tall => 32304,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                    },
                    WallSide.Low => North switch {
                        WallSide.None => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 32305,
                                WallSide.Low => 32306,
                                WallSide.Tall => 32307,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 32308,
                                WallSide.Low => 32309,
                                WallSide.Tall => 32310,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 32311,
                                WallSide.Low => 32312,
                                WallSide.Tall => 32313,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Low => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 32314,
                                WallSide.Low => 32315,
                                WallSide.Tall => 32316,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 32317,
                                WallSide.Low => 32318,
                                WallSide.Tall => 32319,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 32320,
                                WallSide.Low => 32321,
                                WallSide.Tall => 32322,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Tall => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 32323,
                                WallSide.Low => 32324,
                                WallSide.Tall => 32325,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 32326,
                                WallSide.Low => 32327,
                                WallSide.Tall => 32328,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 32329,
                                WallSide.Low => 32330,
                                WallSide.Tall => 32331,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                    },
                    WallSide.Tall => North switch {
                        WallSide.None => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 32332,
                                WallSide.Low => 32333,
                                WallSide.Tall => 32334,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 32335,
                                WallSide.Low => 32336,
                                WallSide.Tall => 32337,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 32338,
                                WallSide.Low => 32339,
                                WallSide.Tall => 32340,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Low => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 32341,
                                WallSide.Low => 32342,
                                WallSide.Tall => 32343,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 32344,
                                WallSide.Low => 32345,
                                WallSide.Tall => 32346,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 32347,
                                WallSide.Low => 32348,
                                WallSide.Tall => 32349,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        WallSide.Tall => South switch {
                            WallSide.None => West switch {
                                WallSide.None => 32350,
                                WallSide.Low => 32351,
                                WallSide.Tall => 32352,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Low => West switch {
                                WallSide.None => 32353,
                                WallSide.Low => 32354,
                                WallSide.Tall => 32355,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            WallSide.Tall => West switch {
                                WallSide.None => 32356,
                                WallSide.Low => 32357,
                                WallSide.Tall => 32358,
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
            32197 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.None, WallSide.None),
            32198 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.None, WallSide.Low),
            32199 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.None, WallSide.Tall),
            32200 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.Low, WallSide.None),
            32201 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.Low, WallSide.Low),
            32202 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.Low, WallSide.Tall),
            32203 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.Tall, WallSide.None),
            32204 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.Tall, WallSide.Low),
            32205 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.None, WallSide.Tall, WallSide.Tall),
            32206 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.None, WallSide.None),
            32207 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.None, WallSide.Low),
            32208 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.None, WallSide.Tall),
            32209 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.Low, WallSide.None),
            32210 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.Low, WallSide.Low),
            32211 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.Low, WallSide.Tall),
            32212 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.Tall, WallSide.None),
            32213 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.Tall, WallSide.Low),
            32214 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Low, WallSide.Tall, WallSide.Tall),
            32215 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.None, WallSide.None),
            32216 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.None, WallSide.Low),
            32217 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.None, WallSide.Tall),
            32218 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.Low, WallSide.None),
            32219 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.Low, WallSide.Low),
            32220 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.Low, WallSide.Tall),
            32221 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.Tall, WallSide.None),
            32222 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.Tall, WallSide.Low),
            32223 => new PaleMossCarpetBlock(Identifier, true, WallSide.None, WallSide.Tall, WallSide.Tall, WallSide.Tall),
            32224 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.None, WallSide.None),
            32225 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.None, WallSide.Low),
            32226 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.None, WallSide.Tall),
            32227 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.Low, WallSide.None),
            32228 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.Low, WallSide.Low),
            32229 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.Low, WallSide.Tall),
            32230 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.Tall, WallSide.None),
            32231 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.Tall, WallSide.Low),
            32232 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.None, WallSide.Tall, WallSide.Tall),
            32233 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.None, WallSide.None),
            32234 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.None, WallSide.Low),
            32235 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.None, WallSide.Tall),
            32236 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.Low, WallSide.None),
            32237 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.Low, WallSide.Low),
            32238 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.Low, WallSide.Tall),
            32239 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.Tall, WallSide.None),
            32240 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.Tall, WallSide.Low),
            32241 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Low, WallSide.Tall, WallSide.Tall),
            32242 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.None, WallSide.None),
            32243 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.None, WallSide.Low),
            32244 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.None, WallSide.Tall),
            32245 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.Low, WallSide.None),
            32246 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.Low, WallSide.Low),
            32247 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.Low, WallSide.Tall),
            32248 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.Tall, WallSide.None),
            32249 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.Tall, WallSide.Low),
            32250 => new PaleMossCarpetBlock(Identifier, true, WallSide.Low, WallSide.Tall, WallSide.Tall, WallSide.Tall),
            32251 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.None, WallSide.None),
            32252 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.None, WallSide.Low),
            32253 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.None, WallSide.Tall),
            32254 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.Low, WallSide.None),
            32255 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.Low, WallSide.Low),
            32256 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.Low, WallSide.Tall),
            32257 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.Tall, WallSide.None),
            32258 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.Tall, WallSide.Low),
            32259 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.None, WallSide.Tall, WallSide.Tall),
            32260 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.None, WallSide.None),
            32261 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.None, WallSide.Low),
            32262 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.None, WallSide.Tall),
            32263 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.Low, WallSide.None),
            32264 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.Low, WallSide.Low),
            32265 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.Low, WallSide.Tall),
            32266 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.Tall, WallSide.None),
            32267 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.Tall, WallSide.Low),
            32268 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Low, WallSide.Tall, WallSide.Tall),
            32269 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.None, WallSide.None),
            32270 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.None, WallSide.Low),
            32271 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.None, WallSide.Tall),
            32272 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.Low, WallSide.None),
            32273 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.Low, WallSide.Low),
            32274 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.Low, WallSide.Tall),
            32275 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.Tall, WallSide.None),
            32276 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.Tall, WallSide.Low),
            32277 => new PaleMossCarpetBlock(Identifier, true, WallSide.Tall, WallSide.Tall, WallSide.Tall, WallSide.Tall),
            32278 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.None, WallSide.None),
            32279 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.None, WallSide.Low),
            32280 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.None, WallSide.Tall),
            32281 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.Low, WallSide.None),
            32282 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.Low, WallSide.Low),
            32283 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.Low, WallSide.Tall),
            32284 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.Tall, WallSide.None),
            32285 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.Tall, WallSide.Low),
            32286 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.None, WallSide.Tall, WallSide.Tall),
            32287 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.None, WallSide.None),
            32288 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.None, WallSide.Low),
            32289 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.None, WallSide.Tall),
            32290 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.Low, WallSide.None),
            32291 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.Low, WallSide.Low),
            32292 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.Low, WallSide.Tall),
            32293 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.Tall, WallSide.None),
            32294 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.Tall, WallSide.Low),
            32295 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Low, WallSide.Tall, WallSide.Tall),
            32296 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.None, WallSide.None),
            32297 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.None, WallSide.Low),
            32298 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.None, WallSide.Tall),
            32299 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.Low, WallSide.None),
            32300 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.Low, WallSide.Low),
            32301 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.Low, WallSide.Tall),
            32302 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.Tall, WallSide.None),
            32303 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.Tall, WallSide.Low),
            32304 => new PaleMossCarpetBlock(Identifier, false, WallSide.None, WallSide.Tall, WallSide.Tall, WallSide.Tall),
            32305 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.None, WallSide.None),
            32306 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.None, WallSide.Low),
            32307 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.None, WallSide.Tall),
            32308 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.Low, WallSide.None),
            32309 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.Low, WallSide.Low),
            32310 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.Low, WallSide.Tall),
            32311 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.Tall, WallSide.None),
            32312 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.Tall, WallSide.Low),
            32313 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.None, WallSide.Tall, WallSide.Tall),
            32314 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.None, WallSide.None),
            32315 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.None, WallSide.Low),
            32316 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.None, WallSide.Tall),
            32317 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.Low, WallSide.None),
            32318 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.Low, WallSide.Low),
            32319 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.Low, WallSide.Tall),
            32320 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.Tall, WallSide.None),
            32321 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.Tall, WallSide.Low),
            32322 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Low, WallSide.Tall, WallSide.Tall),
            32323 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.None, WallSide.None),
            32324 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.None, WallSide.Low),
            32325 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.None, WallSide.Tall),
            32326 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.Low, WallSide.None),
            32327 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.Low, WallSide.Low),
            32328 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.Low, WallSide.Tall),
            32329 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.Tall, WallSide.None),
            32330 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.Tall, WallSide.Low),
            32331 => new PaleMossCarpetBlock(Identifier, false, WallSide.Low, WallSide.Tall, WallSide.Tall, WallSide.Tall),
            32332 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.None, WallSide.None),
            32333 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.None, WallSide.Low),
            32334 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.None, WallSide.Tall),
            32335 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.Low, WallSide.None),
            32336 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.Low, WallSide.Low),
            32337 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.Low, WallSide.Tall),
            32338 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.Tall, WallSide.None),
            32339 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.Tall, WallSide.Low),
            32340 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.None, WallSide.Tall, WallSide.Tall),
            32341 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.None, WallSide.None),
            32342 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.None, WallSide.Low),
            32343 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.None, WallSide.Tall),
            32344 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.Low, WallSide.None),
            32345 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.Low, WallSide.Low),
            32346 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.Low, WallSide.Tall),
            32347 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.Tall, WallSide.None),
            32348 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.Tall, WallSide.Low),
            32349 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Low, WallSide.Tall, WallSide.Tall),
            32350 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.None, WallSide.None),
            32351 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.None, WallSide.Low),
            32352 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.None, WallSide.Tall),
            32353 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.Low, WallSide.None),
            32354 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.Low, WallSide.Low),
            32355 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.Low, WallSide.Tall),
            32356 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.Tall, WallSide.None),
            32357 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.Tall, WallSide.Low),
            32358 => new PaleMossCarpetBlock(Identifier, false, WallSide.Tall, WallSide.Tall, WallSide.Tall, WallSide.Tall),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Bottom = properties.Contains("bottom") ? properties["bottom"].GetString() == "true" : Bottom,
            East = properties.Contains("east") ? WallSideExtensions.FromString(properties["east"].GetString()) : East,
            North = properties.Contains("north") ? WallSideExtensions.FromString(properties["north"].GetString()) : North,
            South = properties.Contains("south") ? WallSideExtensions.FromString(properties["south"].GetString()) : South,
            West = properties.Contains("west") ? WallSideExtensions.FromString(properties["west"].GetString()) : West,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("bottom", new StringTag(Bottom.ToString().ToLower())),
            ("east", new StringTag(East.ToName())),
            ("north", new StringTag(North.ToName())),
            ("south", new StringTag(South.ToName())),
            ("west", new StringTag(West.ToName()))
        );
    }
    
}
