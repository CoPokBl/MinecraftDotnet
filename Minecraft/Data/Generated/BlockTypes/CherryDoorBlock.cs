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
public record CherryDoorBlock(Identifier Identifier, Direction Facing, BlockHalf Half, LeftRight Hinge, bool Open, bool Powered) : IBlock, IHorizontalFacing, IDoubleHalved, IHinged, IOpenable, IPowered {
    private static readonly BlockInfo Data = new("block.minecraft.cherry_door", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:cherry_door", BlockInfo.VanillaOnly, "minecraft:blocks/cherry_door");
    private static readonly BlockStateInfo I0 = new(3f, 0, 0, PushReaction.Popped, 36, "cherry_wood", NoteBlockInstrument.Bass, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, false, true, [], null, BlockShapes.S17, BlockShapes.S17, BlockShapes.S1, BlockShapes.S1, BlockShapes.S17, BlockShapes.S17);
    private static readonly BlockStateInfo I1 = I0 with { PathfindableLand = false, PathfindableAir = false, BlockShape = BlockShapes.S18, CollisionShape = BlockShapes.S18, VisualShape = BlockShapes.S18, SupportShape = BlockShapes.S18 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S19, CollisionShape = BlockShapes.S19, VisualShape = BlockShapes.S19, SupportShape = BlockShapes.S19 };
    private static readonly BlockStateInfo I3 = I0 with { PathfindableLand = false, PathfindableAir = false, BlockShape = BlockShapes.S20, CollisionShape = BlockShapes.S20, VisualShape = BlockShapes.S20, SupportShape = BlockShapes.S20 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S18, CollisionShape = BlockShapes.S18, VisualShape = BlockShapes.S18, SupportShape = BlockShapes.S18 };
    private static readonly BlockStateInfo I5 = I0 with { PathfindableLand = false, PathfindableAir = false, BlockShape = BlockShapes.S19, CollisionShape = BlockShapes.S19, VisualShape = BlockShapes.S19, SupportShape = BlockShapes.S19 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S20, CollisionShape = BlockShapes.S20, VisualShape = BlockShapes.S20, SupportShape = BlockShapes.S20 };
    private static readonly BlockStateInfo I7 = I0 with { PathfindableLand = false, PathfindableAir = false };
    private static readonly BlockStateInfo[] States = [
        I0, I0, I1, I1, I2, I2, I1, I1, I0, I0, I1, I1, I2, I2, I1, I1, I2, I2, I3, I3, I0, I0, I3, I3, I2, I2, I3, I3, I0, I0, I3, I3, I4, I4, I5, I5, I6, I6, I5, I5, I4, I4, I5, I5, I6, I6, I5, I5, I6, I6, I7, I7, I4, I4, I7, I7, I6, I6, I7, I7, I4, I4, I7, I7
    ];

    public BlockStateInfo StateInfo => States[StateId - 16227];

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

    public IBlock WithHalf(BlockHalf half) => this with { Half = half };

    public IBlock WithHinge(LeftRight hinge) => this with { Hinge = hinge };

    public IBlock WithOpen(bool open) => this with { Open = open };

    public IBlock WithPowered(bool powered) => this with { Powered = powered };


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 16227,
                                false => 16228,
                            },
                            false => Powered switch {
                                true => 16229,
                                false => 16230,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16231,
                                false => 16232,
                            },
                            false => Powered switch {
                                true => 16233,
                                false => 16234,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 16235,
                                false => 16236,
                            },
                            false => Powered switch {
                                true => 16237,
                                false => 16238,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16239,
                                false => 16240,
                            },
                            false => Powered switch {
                                true => 16241,
                                false => 16242,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 16243,
                                false => 16244,
                            },
                            false => Powered switch {
                                true => 16245,
                                false => 16246,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16247,
                                false => 16248,
                            },
                            false => Powered switch {
                                true => 16249,
                                false => 16250,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 16251,
                                false => 16252,
                            },
                            false => Powered switch {
                                true => 16253,
                                false => 16254,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16255,
                                false => 16256,
                            },
                            false => Powered switch {
                                true => 16257,
                                false => 16258,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 16259,
                                false => 16260,
                            },
                            false => Powered switch {
                                true => 16261,
                                false => 16262,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16263,
                                false => 16264,
                            },
                            false => Powered switch {
                                true => 16265,
                                false => 16266,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 16267,
                                false => 16268,
                            },
                            false => Powered switch {
                                true => 16269,
                                false => 16270,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16271,
                                false => 16272,
                            },
                            false => Powered switch {
                                true => 16273,
                                false => 16274,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 16275,
                                false => 16276,
                            },
                            false => Powered switch {
                                true => 16277,
                                false => 16278,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16279,
                                false => 16280,
                            },
                            false => Powered switch {
                                true => 16281,
                                false => 16282,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 16283,
                                false => 16284,
                            },
                            false => Powered switch {
                                true => 16285,
                                false => 16286,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16287,
                                false => 16288,
                            },
                            false => Powered switch {
                                true => 16289,
                                false => 16290,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            16227 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            16228 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            16229 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            16230 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            16231 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            16232 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            16233 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            16234 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            16235 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            16236 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            16237 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            16238 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            16239 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            16240 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            16241 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            16242 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            16243 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            16244 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            16245 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            16246 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            16247 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            16248 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            16249 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            16250 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            16251 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            16252 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            16253 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            16254 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            16255 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            16256 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            16257 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            16258 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            16259 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            16260 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            16261 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            16262 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            16263 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            16264 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            16265 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            16266 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            16267 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            16268 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            16269 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            16270 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            16271 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            16272 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            16273 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            16274 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            16275 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            16276 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            16277 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            16278 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            16279 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            16280 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            16281 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            16282 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            16283 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            16284 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            16285 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            16286 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            16287 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            16288 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            16289 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            16290 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Half = properties.Contains("half") ? BlockHalfExtensions.FromString(properties["half"].GetString()) : Half,
            Hinge = properties.Contains("hinge") ? LeftRightExtensions.FromString(properties["hinge"].GetString()) : Hinge,
            Open = properties.Contains("open") ? properties["open"].GetString() == "true" : Open,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("half", new StringTag(Half.ToName())),
            ("hinge", new StringTag(Hinge.ToName())),
            ("open", new StringTag(Open.ToString().ToLower())),
            ("powered", new StringTag(Powered.ToString().ToLower()))
        );
    }
    
}
