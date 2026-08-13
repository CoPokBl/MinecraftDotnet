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
public record ExposedCopperTrapdoorBlock(Identifier Identifier, Direction Facing, TopBottom Half, bool Open, bool Powered, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IOpenable, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:weathering_copper_trapdoor", "block.minecraft.exposed_copper_trapdoor", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:exposed_copper_trapdoor", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Normal, 44, "copper", NoteBlockInstrument.Harp, false, false, true, true, false, false, false, false, true, false, false, true, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18, BlockShapes.S18);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { PathfindableLand = false, PathfindableAir = false, BlockShape = BlockShapes.S114, CollisionShape = BlockShapes.S114, VisualShape = BlockShapes.S114, SupportShape = BlockShapes.S114 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, PathfindableLand = false, PathfindableWater = false, PathfindableAir = false, Fluid = null, BlockShape = BlockShapes.S114, CollisionShape = BlockShapes.S114, VisualShape = BlockShapes.S114, SupportShape = BlockShapes.S114 };
    private static readonly BlockStateInfo I4 = I0 with { PathfindableLand = false, PathfindableAir = false, BlockShape = BlockShapes.S115, CollisionShape = BlockShapes.S115, VisualShape = BlockShapes.S115, SupportShape = BlockShapes.S115 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, PathfindableLand = false, PathfindableWater = false, PathfindableAir = false, Fluid = null, BlockShape = BlockShapes.S115, CollisionShape = BlockShapes.S115, VisualShape = BlockShapes.S115, SupportShape = BlockShapes.S115 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S20, CollisionShape = BlockShapes.S20, VisualShape = BlockShapes.S20, SupportShape = BlockShapes.S20 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S20, CollisionShape = BlockShapes.S20, VisualShape = BlockShapes.S20, SupportShape = BlockShapes.S20 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S19, CollisionShape = BlockShapes.S19, VisualShape = BlockShapes.S19, SupportShape = BlockShapes.S19 };
    private static readonly BlockStateInfo I9 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S19, CollisionShape = BlockShapes.S19, VisualShape = BlockShapes.S19, SupportShape = BlockShapes.S19 };
    private static readonly BlockStateInfo I10 = I0 with { BlockShape = BlockShapes.S17, CollisionShape = BlockShapes.S17, VisualShape = BlockShapes.S17, SupportShape = BlockShapes.S17 };
    private static readonly BlockStateInfo I11 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S17, CollisionShape = BlockShapes.S17, VisualShape = BlockShapes.S17, SupportShape = BlockShapes.S17 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I2, I3, I0, I1, I0, I1, I4, I5, I4, I5, I6, I7, I6, I7, I2, I3, I2, I3, I6, I7, I6, I7, I4, I5, I4, I5, I8, I9, I8, I9, I2, I3, I2, I3, I8, I9, I8, I9, I4, I5, I4, I5, I10, I11, I10, I11, I2, I3, I2, I3, I10, I11, I10, I11, I4, I5, I4, I5
    ];

    public BlockStateInfo StateInfo => States[StateId - 29072];

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

    public IBlock WithOpen(bool open) => this with { Open = open };

    public IBlock WithPowered(bool powered) => this with { Powered = powered };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29072,
                                false => 29073,
                            },
                            false => Waterlogged switch {
                                true => 29074,
                                false => 29075,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29076,
                                false => 29077,
                            },
                            false => Waterlogged switch {
                                true => 29078,
                                false => 29079,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29080,
                                false => 29081,
                            },
                            false => Waterlogged switch {
                                true => 29082,
                                false => 29083,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29084,
                                false => 29085,
                            },
                            false => Waterlogged switch {
                                true => 29086,
                                false => 29087,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29088,
                                false => 29089,
                            },
                            false => Waterlogged switch {
                                true => 29090,
                                false => 29091,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29092,
                                false => 29093,
                            },
                            false => Waterlogged switch {
                                true => 29094,
                                false => 29095,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29096,
                                false => 29097,
                            },
                            false => Waterlogged switch {
                                true => 29098,
                                false => 29099,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29100,
                                false => 29101,
                            },
                            false => Waterlogged switch {
                                true => 29102,
                                false => 29103,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29104,
                                false => 29105,
                            },
                            false => Waterlogged switch {
                                true => 29106,
                                false => 29107,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29108,
                                false => 29109,
                            },
                            false => Waterlogged switch {
                                true => 29110,
                                false => 29111,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29112,
                                false => 29113,
                            },
                            false => Waterlogged switch {
                                true => 29114,
                                false => 29115,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29116,
                                false => 29117,
                            },
                            false => Waterlogged switch {
                                true => 29118,
                                false => 29119,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29120,
                                false => 29121,
                            },
                            false => Waterlogged switch {
                                true => 29122,
                                false => 29123,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29124,
                                false => 29125,
                            },
                            false => Waterlogged switch {
                                true => 29126,
                                false => 29127,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29128,
                                false => 29129,
                            },
                            false => Waterlogged switch {
                                true => 29130,
                                false => 29131,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29132,
                                false => 29133,
                            },
                            false => Waterlogged switch {
                                true => 29134,
                                false => 29135,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            29072 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            29073 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            29074 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            29075 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            29076 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            29077 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            29078 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            29079 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            29080 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            29081 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            29082 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            29083 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            29084 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            29085 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            29086 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            29087 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            29088 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            29089 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            29090 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            29091 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            29092 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            29093 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            29094 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            29095 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            29096 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            29097 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            29098 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            29099 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            29100 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            29101 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            29102 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            29103 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            29104 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            29105 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            29106 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            29107 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            29108 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            29109 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            29110 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            29111 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            29112 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            29113 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            29114 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            29115 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            29116 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            29117 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            29118 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            29119 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            29120 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            29121 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            29122 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            29123 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            29124 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            29125 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            29126 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            29127 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            29128 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            29129 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            29130 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            29131 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            29132 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            29133 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            29134 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            29135 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Half = properties.Contains("half") ? TopBottomExtensions.FromString(properties["half"].GetString()) : Half,
            Open = properties.Contains("open") ? properties["open"].GetString() == "true" : Open,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("half", new StringTag(Half.ToName())),
            ("open", new StringTag(Open.ToString().ToLower())),
            ("powered", new StringTag(Powered.ToString().ToLower())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
