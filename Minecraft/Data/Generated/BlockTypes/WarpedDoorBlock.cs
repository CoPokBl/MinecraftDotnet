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
public record WarpedDoorBlock(Identifier Identifier, Direction Facing, BlockHalf Half, LeftRight Hinge, bool Open, bool Powered) : IBlock, IHorizontalFacing, IDoubleHalved, IHinged, IOpenable, IPowered {
    private static readonly BlockInfo Data = new("block.minecraft.warped_door", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:warped_door", BlockInfo.VanillaOnly, "minecraft:blocks/warped_door");
    private static readonly BlockStateInfo I0 = new(3f, 0, 0, PushReaction.Popped, 56, "nether_wood", NoteBlockInstrument.Bass, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, false, true, [], null, BlockShapes.S17, BlockShapes.S17, BlockShapes.S1, BlockShapes.S1, BlockShapes.S17, BlockShapes.S17);
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

    public BlockStateInfo StateInfo => States[StateId - 24935];

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
                                true => 24935,
                                false => 24936,
                            },
                            false => Powered switch {
                                true => 24937,
                                false => 24938,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 24939,
                                false => 24940,
                            },
                            false => Powered switch {
                                true => 24941,
                                false => 24942,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 24943,
                                false => 24944,
                            },
                            false => Powered switch {
                                true => 24945,
                                false => 24946,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 24947,
                                false => 24948,
                            },
                            false => Powered switch {
                                true => 24949,
                                false => 24950,
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
                                true => 24951,
                                false => 24952,
                            },
                            false => Powered switch {
                                true => 24953,
                                false => 24954,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 24955,
                                false => 24956,
                            },
                            false => Powered switch {
                                true => 24957,
                                false => 24958,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 24959,
                                false => 24960,
                            },
                            false => Powered switch {
                                true => 24961,
                                false => 24962,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 24963,
                                false => 24964,
                            },
                            false => Powered switch {
                                true => 24965,
                                false => 24966,
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
                                true => 24967,
                                false => 24968,
                            },
                            false => Powered switch {
                                true => 24969,
                                false => 24970,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 24971,
                                false => 24972,
                            },
                            false => Powered switch {
                                true => 24973,
                                false => 24974,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 24975,
                                false => 24976,
                            },
                            false => Powered switch {
                                true => 24977,
                                false => 24978,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 24979,
                                false => 24980,
                            },
                            false => Powered switch {
                                true => 24981,
                                false => 24982,
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
                                true => 24983,
                                false => 24984,
                            },
                            false => Powered switch {
                                true => 24985,
                                false => 24986,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 24987,
                                false => 24988,
                            },
                            false => Powered switch {
                                true => 24989,
                                false => 24990,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 24991,
                                false => 24992,
                            },
                            false => Powered switch {
                                true => 24993,
                                false => 24994,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 24995,
                                false => 24996,
                            },
                            false => Powered switch {
                                true => 24997,
                                false => 24998,
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
            24935 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            24936 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            24937 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            24938 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            24939 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            24940 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            24941 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            24942 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            24943 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            24944 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            24945 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            24946 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            24947 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            24948 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            24949 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            24950 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            24951 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            24952 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            24953 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            24954 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            24955 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            24956 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            24957 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            24958 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            24959 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            24960 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            24961 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            24962 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            24963 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            24964 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            24965 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            24966 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            24967 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            24968 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            24969 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            24970 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            24971 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            24972 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            24973 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            24974 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            24975 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            24976 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            24977 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            24978 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            24979 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            24980 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            24981 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            24982 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            24983 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            24984 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            24985 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            24986 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            24987 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            24988 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            24989 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            24990 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            24991 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            24992 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            24993 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            24994 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            24995 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            24996 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            24997 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            24998 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
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
