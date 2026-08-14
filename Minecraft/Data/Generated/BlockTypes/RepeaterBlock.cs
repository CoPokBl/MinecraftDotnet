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
public record RepeaterBlock(Identifier Identifier, int Delay, Direction Facing, bool Locked, bool Powered) : IBlock, IHorizontalFacing, ILocked, IPowered {
    private static readonly BlockInfo Data = new("minecraft:repeater", "block.minecraft.repeater", 0f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:repeater", BlockInfo.VanillaOnly, "minecraft:blocks/repeater");
    private static readonly BlockStateInfo I0 = new(0f, 0, 0, PushReaction.Destroy, 0, "stone", NoteBlockInstrument.Harp, true, true, false, false, false, false, false, false, false, false, true, false, false, false, true, true, false, true, [], null, BlockShapes.S124, BlockShapes.S124, BlockShapes.S1, BlockShapes.S124, BlockShapes.S124, BlockShapes.S124);

    public BlockStateInfo StateInfo => I0;

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

    public IBlock WithLocked(bool locked) => this with { Locked = locked };

    public IBlock WithPowered(bool powered) => this with { Powered = powered };


    public uint StateId {
        get {
            return Delay switch {
                1 => Facing switch {
                    Direction.North => Locked switch {
                        true => Powered switch {
                            true => 7034,
                            false => 7035,
                        },
                        false => Powered switch {
                            true => 7036,
                            false => 7037,
                        },
                    },
                    Direction.South => Locked switch {
                        true => Powered switch {
                            true => 7038,
                            false => 7039,
                        },
                        false => Powered switch {
                            true => 7040,
                            false => 7041,
                        },
                    },
                    Direction.West => Locked switch {
                        true => Powered switch {
                            true => 7042,
                            false => 7043,
                        },
                        false => Powered switch {
                            true => 7044,
                            false => 7045,
                        },
                    },
                    Direction.East => Locked switch {
                        true => Powered switch {
                            true => 7046,
                            false => 7047,
                        },
                        false => Powered switch {
                            true => 7048,
                            false => 7049,
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                2 => Facing switch {
                    Direction.North => Locked switch {
                        true => Powered switch {
                            true => 7050,
                            false => 7051,
                        },
                        false => Powered switch {
                            true => 7052,
                            false => 7053,
                        },
                    },
                    Direction.South => Locked switch {
                        true => Powered switch {
                            true => 7054,
                            false => 7055,
                        },
                        false => Powered switch {
                            true => 7056,
                            false => 7057,
                        },
                    },
                    Direction.West => Locked switch {
                        true => Powered switch {
                            true => 7058,
                            false => 7059,
                        },
                        false => Powered switch {
                            true => 7060,
                            false => 7061,
                        },
                    },
                    Direction.East => Locked switch {
                        true => Powered switch {
                            true => 7062,
                            false => 7063,
                        },
                        false => Powered switch {
                            true => 7064,
                            false => 7065,
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                3 => Facing switch {
                    Direction.North => Locked switch {
                        true => Powered switch {
                            true => 7066,
                            false => 7067,
                        },
                        false => Powered switch {
                            true => 7068,
                            false => 7069,
                        },
                    },
                    Direction.South => Locked switch {
                        true => Powered switch {
                            true => 7070,
                            false => 7071,
                        },
                        false => Powered switch {
                            true => 7072,
                            false => 7073,
                        },
                    },
                    Direction.West => Locked switch {
                        true => Powered switch {
                            true => 7074,
                            false => 7075,
                        },
                        false => Powered switch {
                            true => 7076,
                            false => 7077,
                        },
                    },
                    Direction.East => Locked switch {
                        true => Powered switch {
                            true => 7078,
                            false => 7079,
                        },
                        false => Powered switch {
                            true => 7080,
                            false => 7081,
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                4 => Facing switch {
                    Direction.North => Locked switch {
                        true => Powered switch {
                            true => 7082,
                            false => 7083,
                        },
                        false => Powered switch {
                            true => 7084,
                            false => 7085,
                        },
                    },
                    Direction.South => Locked switch {
                        true => Powered switch {
                            true => 7086,
                            false => 7087,
                        },
                        false => Powered switch {
                            true => 7088,
                            false => 7089,
                        },
                    },
                    Direction.West => Locked switch {
                        true => Powered switch {
                            true => 7090,
                            false => 7091,
                        },
                        false => Powered switch {
                            true => 7092,
                            false => 7093,
                        },
                    },
                    Direction.East => Locked switch {
                        true => Powered switch {
                            true => 7094,
                            false => 7095,
                        },
                        false => Powered switch {
                            true => 7096,
                            false => 7097,
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Delay), Delay, "Unknown value for property delay.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7034 => new RepeaterBlock(Identifier, 1, Direction.North, true, true),
            7035 => new RepeaterBlock(Identifier, 1, Direction.North, true, false),
            7036 => new RepeaterBlock(Identifier, 1, Direction.North, false, true),
            7037 => new RepeaterBlock(Identifier, 1, Direction.North, false, false),
            7038 => new RepeaterBlock(Identifier, 1, Direction.South, true, true),
            7039 => new RepeaterBlock(Identifier, 1, Direction.South, true, false),
            7040 => new RepeaterBlock(Identifier, 1, Direction.South, false, true),
            7041 => new RepeaterBlock(Identifier, 1, Direction.South, false, false),
            7042 => new RepeaterBlock(Identifier, 1, Direction.West, true, true),
            7043 => new RepeaterBlock(Identifier, 1, Direction.West, true, false),
            7044 => new RepeaterBlock(Identifier, 1, Direction.West, false, true),
            7045 => new RepeaterBlock(Identifier, 1, Direction.West, false, false),
            7046 => new RepeaterBlock(Identifier, 1, Direction.East, true, true),
            7047 => new RepeaterBlock(Identifier, 1, Direction.East, true, false),
            7048 => new RepeaterBlock(Identifier, 1, Direction.East, false, true),
            7049 => new RepeaterBlock(Identifier, 1, Direction.East, false, false),
            7050 => new RepeaterBlock(Identifier, 2, Direction.North, true, true),
            7051 => new RepeaterBlock(Identifier, 2, Direction.North, true, false),
            7052 => new RepeaterBlock(Identifier, 2, Direction.North, false, true),
            7053 => new RepeaterBlock(Identifier, 2, Direction.North, false, false),
            7054 => new RepeaterBlock(Identifier, 2, Direction.South, true, true),
            7055 => new RepeaterBlock(Identifier, 2, Direction.South, true, false),
            7056 => new RepeaterBlock(Identifier, 2, Direction.South, false, true),
            7057 => new RepeaterBlock(Identifier, 2, Direction.South, false, false),
            7058 => new RepeaterBlock(Identifier, 2, Direction.West, true, true),
            7059 => new RepeaterBlock(Identifier, 2, Direction.West, true, false),
            7060 => new RepeaterBlock(Identifier, 2, Direction.West, false, true),
            7061 => new RepeaterBlock(Identifier, 2, Direction.West, false, false),
            7062 => new RepeaterBlock(Identifier, 2, Direction.East, true, true),
            7063 => new RepeaterBlock(Identifier, 2, Direction.East, true, false),
            7064 => new RepeaterBlock(Identifier, 2, Direction.East, false, true),
            7065 => new RepeaterBlock(Identifier, 2, Direction.East, false, false),
            7066 => new RepeaterBlock(Identifier, 3, Direction.North, true, true),
            7067 => new RepeaterBlock(Identifier, 3, Direction.North, true, false),
            7068 => new RepeaterBlock(Identifier, 3, Direction.North, false, true),
            7069 => new RepeaterBlock(Identifier, 3, Direction.North, false, false),
            7070 => new RepeaterBlock(Identifier, 3, Direction.South, true, true),
            7071 => new RepeaterBlock(Identifier, 3, Direction.South, true, false),
            7072 => new RepeaterBlock(Identifier, 3, Direction.South, false, true),
            7073 => new RepeaterBlock(Identifier, 3, Direction.South, false, false),
            7074 => new RepeaterBlock(Identifier, 3, Direction.West, true, true),
            7075 => new RepeaterBlock(Identifier, 3, Direction.West, true, false),
            7076 => new RepeaterBlock(Identifier, 3, Direction.West, false, true),
            7077 => new RepeaterBlock(Identifier, 3, Direction.West, false, false),
            7078 => new RepeaterBlock(Identifier, 3, Direction.East, true, true),
            7079 => new RepeaterBlock(Identifier, 3, Direction.East, true, false),
            7080 => new RepeaterBlock(Identifier, 3, Direction.East, false, true),
            7081 => new RepeaterBlock(Identifier, 3, Direction.East, false, false),
            7082 => new RepeaterBlock(Identifier, 4, Direction.North, true, true),
            7083 => new RepeaterBlock(Identifier, 4, Direction.North, true, false),
            7084 => new RepeaterBlock(Identifier, 4, Direction.North, false, true),
            7085 => new RepeaterBlock(Identifier, 4, Direction.North, false, false),
            7086 => new RepeaterBlock(Identifier, 4, Direction.South, true, true),
            7087 => new RepeaterBlock(Identifier, 4, Direction.South, true, false),
            7088 => new RepeaterBlock(Identifier, 4, Direction.South, false, true),
            7089 => new RepeaterBlock(Identifier, 4, Direction.South, false, false),
            7090 => new RepeaterBlock(Identifier, 4, Direction.West, true, true),
            7091 => new RepeaterBlock(Identifier, 4, Direction.West, true, false),
            7092 => new RepeaterBlock(Identifier, 4, Direction.West, false, true),
            7093 => new RepeaterBlock(Identifier, 4, Direction.West, false, false),
            7094 => new RepeaterBlock(Identifier, 4, Direction.East, true, true),
            7095 => new RepeaterBlock(Identifier, 4, Direction.East, true, false),
            7096 => new RepeaterBlock(Identifier, 4, Direction.East, false, true),
            7097 => new RepeaterBlock(Identifier, 4, Direction.East, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Delay = properties.Contains("delay") ? int.Parse(properties["delay"].GetString()) : Delay,
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Locked = properties.Contains("locked") ? properties["locked"].GetString() == "true" : Locked,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("delay", new StringTag(Delay.ToString())),
            ("facing", new StringTag(Facing.ToName())),
            ("locked", new StringTag(Locked.ToString().ToLower())),
            ("powered", new StringTag(Powered.ToString().ToLower()))
        );
    }
    
}
