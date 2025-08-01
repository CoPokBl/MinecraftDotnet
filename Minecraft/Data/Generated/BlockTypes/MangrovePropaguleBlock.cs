using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MangrovePropaguleBlock(Identifier Identifier, int Age, bool Hanging, int Stage, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:mangrove_propagule";
    public int ProtocolId => 33;
    public double Hardness => 0;
    public double ExplosionResistance => 0;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "grass";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:mangrove_propagule";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.3125, 1.0, 0.3125]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 7;
    public string TranslationKey => "block.minecraft.mangrove_propagule";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Age switch {
                0 => Hanging switch {
                    true => Stage switch {
                        0 => Waterlogged switch {
                            true => 45,
                            false => 46,
                        },
                        1 => Waterlogged switch {
                            true => 47,
                            false => 48,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    false => Stage switch {
                        0 => Waterlogged switch {
                            true => 49,
                            false => 50,
                        },
                        1 => Waterlogged switch {
                            true => 51,
                            false => 52,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                },
                1 => Hanging switch {
                    true => Stage switch {
                        0 => Waterlogged switch {
                            true => 53,
                            false => 54,
                        },
                        1 => Waterlogged switch {
                            true => 55,
                            false => 56,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    false => Stage switch {
                        0 => Waterlogged switch {
                            true => 57,
                            false => 58,
                        },
                        1 => Waterlogged switch {
                            true => 59,
                            false => 60,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                },
                2 => Hanging switch {
                    true => Stage switch {
                        0 => Waterlogged switch {
                            true => 61,
                            false => 62,
                        },
                        1 => Waterlogged switch {
                            true => 63,
                            false => 64,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    false => Stage switch {
                        0 => Waterlogged switch {
                            true => 65,
                            false => 66,
                        },
                        1 => Waterlogged switch {
                            true => 67,
                            false => 68,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                },
                3 => Hanging switch {
                    true => Stage switch {
                        0 => Waterlogged switch {
                            true => 69,
                            false => 70,
                        },
                        1 => Waterlogged switch {
                            true => 71,
                            false => 72,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    false => Stage switch {
                        0 => Waterlogged switch {
                            true => 73,
                            false => 74,
                        },
                        1 => Waterlogged switch {
                            true => 75,
                            false => 76,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                },
                4 => Hanging switch {
                    true => Stage switch {
                        0 => Waterlogged switch {
                            true => 77,
                            false => 78,
                        },
                        1 => Waterlogged switch {
                            true => 79,
                            false => 80,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    false => Stage switch {
                        0 => Waterlogged switch {
                            true => 81,
                            false => 82,
                        },
                        1 => Waterlogged switch {
                            true => 83,
                            false => 84,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            45 => new MangrovePropaguleBlock(Identifier, 0, true, 0, true),
            46 => new MangrovePropaguleBlock(Identifier, 0, true, 0, false),
            47 => new MangrovePropaguleBlock(Identifier, 0, true, 1, true),
            48 => new MangrovePropaguleBlock(Identifier, 0, true, 1, false),
            49 => new MangrovePropaguleBlock(Identifier, 0, false, 0, true),
            50 => new MangrovePropaguleBlock(Identifier, 0, false, 0, false),
            51 => new MangrovePropaguleBlock(Identifier, 0, false, 1, true),
            52 => new MangrovePropaguleBlock(Identifier, 0, false, 1, false),
            53 => new MangrovePropaguleBlock(Identifier, 1, true, 0, true),
            54 => new MangrovePropaguleBlock(Identifier, 1, true, 0, false),
            55 => new MangrovePropaguleBlock(Identifier, 1, true, 1, true),
            56 => new MangrovePropaguleBlock(Identifier, 1, true, 1, false),
            57 => new MangrovePropaguleBlock(Identifier, 1, false, 0, true),
            58 => new MangrovePropaguleBlock(Identifier, 1, false, 0, false),
            59 => new MangrovePropaguleBlock(Identifier, 1, false, 1, true),
            60 => new MangrovePropaguleBlock(Identifier, 1, false, 1, false),
            61 => new MangrovePropaguleBlock(Identifier, 2, true, 0, true),
            62 => new MangrovePropaguleBlock(Identifier, 2, true, 0, false),
            63 => new MangrovePropaguleBlock(Identifier, 2, true, 1, true),
            64 => new MangrovePropaguleBlock(Identifier, 2, true, 1, false),
            65 => new MangrovePropaguleBlock(Identifier, 2, false, 0, true),
            66 => new MangrovePropaguleBlock(Identifier, 2, false, 0, false),
            67 => new MangrovePropaguleBlock(Identifier, 2, false, 1, true),
            68 => new MangrovePropaguleBlock(Identifier, 2, false, 1, false),
            69 => new MangrovePropaguleBlock(Identifier, 3, true, 0, true),
            70 => new MangrovePropaguleBlock(Identifier, 3, true, 0, false),
            71 => new MangrovePropaguleBlock(Identifier, 3, true, 1, true),
            72 => new MangrovePropaguleBlock(Identifier, 3, true, 1, false),
            73 => new MangrovePropaguleBlock(Identifier, 3, false, 0, true),
            74 => new MangrovePropaguleBlock(Identifier, 3, false, 0, false),
            75 => new MangrovePropaguleBlock(Identifier, 3, false, 1, true),
            76 => new MangrovePropaguleBlock(Identifier, 3, false, 1, false),
            77 => new MangrovePropaguleBlock(Identifier, 4, true, 0, true),
            78 => new MangrovePropaguleBlock(Identifier, 4, true, 0, false),
            79 => new MangrovePropaguleBlock(Identifier, 4, true, 1, true),
            80 => new MangrovePropaguleBlock(Identifier, 4, true, 1, false),
            81 => new MangrovePropaguleBlock(Identifier, 4, false, 0, true),
            82 => new MangrovePropaguleBlock(Identifier, 4, false, 0, false),
            83 => new MangrovePropaguleBlock(Identifier, 4, false, 1, true),
            84 => new MangrovePropaguleBlock(Identifier, 4, false, 1, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Age = int.Parse(properties["age"].GetString()),
            Hanging = properties["hanging"].GetString() == "true",
            Stage = int.Parse(properties["stage"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("age", Age.ToString()),
            new StringTag("hanging", Hanging.ToString().ToLower()),
            new StringTag("stage", Stage.ToString()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
        );
    }
    
}
