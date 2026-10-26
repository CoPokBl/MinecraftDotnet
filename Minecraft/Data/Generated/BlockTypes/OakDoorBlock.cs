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
public record OakDoorBlock(Identifier Identifier, Direction Facing, BlockHalf Half, LeftRight Hinge, bool Open, bool Powered) : IBlock, IHorizontalFacing, IDoubleHalved, IHinged, IOpenable, IPowered {
    private static readonly BlockInfo Data = new("block.minecraft.oak_door", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:oak_door", BlockInfo.VanillaOnly, "minecraft:blocks/oak_door");
    private static readonly BlockStateInfo I0 = new(3f, 0, 0, PushReaction.Popped, 13, "wood", NoteBlockInstrument.Bass, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, false, true, [], null, BlockShapes.S17, BlockShapes.S17, BlockShapes.S1, BlockShapes.S1, BlockShapes.S17, BlockShapes.S17);
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

    public BlockStateInfo StateInfo => States[StateId - 7243];

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
                                true => 7243,
                                false => 7244,
                            },
                            false => Powered switch {
                                true => 7245,
                                false => 7246,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 7247,
                                false => 7248,
                            },
                            false => Powered switch {
                                true => 7249,
                                false => 7250,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 7251,
                                false => 7252,
                            },
                            false => Powered switch {
                                true => 7253,
                                false => 7254,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 7255,
                                false => 7256,
                            },
                            false => Powered switch {
                                true => 7257,
                                false => 7258,
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
                                true => 7259,
                                false => 7260,
                            },
                            false => Powered switch {
                                true => 7261,
                                false => 7262,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 7263,
                                false => 7264,
                            },
                            false => Powered switch {
                                true => 7265,
                                false => 7266,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 7267,
                                false => 7268,
                            },
                            false => Powered switch {
                                true => 7269,
                                false => 7270,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 7271,
                                false => 7272,
                            },
                            false => Powered switch {
                                true => 7273,
                                false => 7274,
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
                                true => 7275,
                                false => 7276,
                            },
                            false => Powered switch {
                                true => 7277,
                                false => 7278,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 7279,
                                false => 7280,
                            },
                            false => Powered switch {
                                true => 7281,
                                false => 7282,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 7283,
                                false => 7284,
                            },
                            false => Powered switch {
                                true => 7285,
                                false => 7286,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 7287,
                                false => 7288,
                            },
                            false => Powered switch {
                                true => 7289,
                                false => 7290,
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
                                true => 7291,
                                false => 7292,
                            },
                            false => Powered switch {
                                true => 7293,
                                false => 7294,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 7295,
                                false => 7296,
                            },
                            false => Powered switch {
                                true => 7297,
                                false => 7298,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 7299,
                                false => 7300,
                            },
                            false => Powered switch {
                                true => 7301,
                                false => 7302,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 7303,
                                false => 7304,
                            },
                            false => Powered switch {
                                true => 7305,
                                false => 7306,
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
            7243 => new OakDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            7244 => new OakDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            7245 => new OakDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            7246 => new OakDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            7247 => new OakDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            7248 => new OakDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            7249 => new OakDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            7250 => new OakDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            7251 => new OakDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            7252 => new OakDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            7253 => new OakDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            7254 => new OakDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            7255 => new OakDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            7256 => new OakDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            7257 => new OakDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            7258 => new OakDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            7259 => new OakDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            7260 => new OakDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            7261 => new OakDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            7262 => new OakDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            7263 => new OakDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            7264 => new OakDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            7265 => new OakDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            7266 => new OakDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            7267 => new OakDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            7268 => new OakDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            7269 => new OakDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            7270 => new OakDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            7271 => new OakDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            7272 => new OakDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            7273 => new OakDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            7274 => new OakDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            7275 => new OakDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            7276 => new OakDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            7277 => new OakDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            7278 => new OakDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            7279 => new OakDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            7280 => new OakDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            7281 => new OakDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            7282 => new OakDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            7283 => new OakDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            7284 => new OakDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            7285 => new OakDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            7286 => new OakDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            7287 => new OakDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            7288 => new OakDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            7289 => new OakDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            7290 => new OakDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            7291 => new OakDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            7292 => new OakDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            7293 => new OakDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            7294 => new OakDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            7295 => new OakDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            7296 => new OakDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            7297 => new OakDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            7298 => new OakDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            7299 => new OakDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            7300 => new OakDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            7301 => new OakDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            7302 => new OakDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            7303 => new OakDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            7304 => new OakDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            7305 => new OakDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            7306 => new OakDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
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
