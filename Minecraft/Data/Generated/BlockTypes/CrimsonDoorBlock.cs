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
public record CrimsonDoorBlock(Identifier Identifier, Direction Facing, BlockHalf Half, LeftRight Hinge, bool Open, bool Powered) : IBlock, IHorizontalFacing, IDoubleHalved, IHinged, IOpenable, IPowered {
    private static readonly BlockInfo Data = new("block.minecraft.crimson_door", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:crimson_door", BlockInfo.VanillaOnly, "minecraft:blocks/crimson_door");
    private static readonly BlockStateInfo I0 = new(3f, 0, 0, PushReaction.Popped, 53, "nether_wood", NoteBlockInstrument.Bass, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, false, true, [], null, BlockShapes.S17, BlockShapes.S17, BlockShapes.S1, BlockShapes.S1, BlockShapes.S17, BlockShapes.S17);
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

    public BlockStateInfo StateInfo => States[StateId - 24871];

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
                                true => 24871,
                                false => 24872,
                            },
                            false => Powered switch {
                                true => 24873,
                                false => 24874,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 24875,
                                false => 24876,
                            },
                            false => Powered switch {
                                true => 24877,
                                false => 24878,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 24879,
                                false => 24880,
                            },
                            false => Powered switch {
                                true => 24881,
                                false => 24882,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 24883,
                                false => 24884,
                            },
                            false => Powered switch {
                                true => 24885,
                                false => 24886,
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
                                true => 24887,
                                false => 24888,
                            },
                            false => Powered switch {
                                true => 24889,
                                false => 24890,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 24891,
                                false => 24892,
                            },
                            false => Powered switch {
                                true => 24893,
                                false => 24894,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 24895,
                                false => 24896,
                            },
                            false => Powered switch {
                                true => 24897,
                                false => 24898,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 24899,
                                false => 24900,
                            },
                            false => Powered switch {
                                true => 24901,
                                false => 24902,
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
                                true => 24903,
                                false => 24904,
                            },
                            false => Powered switch {
                                true => 24905,
                                false => 24906,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 24907,
                                false => 24908,
                            },
                            false => Powered switch {
                                true => 24909,
                                false => 24910,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 24911,
                                false => 24912,
                            },
                            false => Powered switch {
                                true => 24913,
                                false => 24914,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 24915,
                                false => 24916,
                            },
                            false => Powered switch {
                                true => 24917,
                                false => 24918,
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
                                true => 24919,
                                false => 24920,
                            },
                            false => Powered switch {
                                true => 24921,
                                false => 24922,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 24923,
                                false => 24924,
                            },
                            false => Powered switch {
                                true => 24925,
                                false => 24926,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 24927,
                                false => 24928,
                            },
                            false => Powered switch {
                                true => 24929,
                                false => 24930,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 24931,
                                false => 24932,
                            },
                            false => Powered switch {
                                true => 24933,
                                false => 24934,
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
            24871 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            24872 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            24873 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            24874 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            24875 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            24876 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            24877 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            24878 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            24879 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            24880 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            24881 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            24882 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            24883 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            24884 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            24885 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            24886 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            24887 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            24888 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            24889 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            24890 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            24891 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            24892 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            24893 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            24894 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            24895 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            24896 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            24897 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            24898 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            24899 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            24900 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            24901 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            24902 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            24903 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            24904 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            24905 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            24906 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            24907 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            24908 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            24909 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            24910 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            24911 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            24912 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            24913 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            24914 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            24915 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            24916 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            24917 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            24918 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            24919 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            24920 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            24921 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            24922 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            24923 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            24924 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            24925 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            24926 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            24927 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            24928 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            24929 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            24930 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            24931 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            24932 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            24933 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            24934 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
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
