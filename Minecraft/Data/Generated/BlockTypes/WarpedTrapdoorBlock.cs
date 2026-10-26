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
public record WarpedTrapdoorBlock(Identifier Identifier, Direction Facing, TopBottom Half, bool Open, bool Powered, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IOpenable, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.warped_trapdoor", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:warped_trapdoor", BlockInfo.VanillaOnly, "minecraft:blocks/warped_trapdoor");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.PushPull, 56, "nether_wood", NoteBlockInstrument.Bass, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18, BlockShapes.S18);
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

    public BlockStateInfo StateInfo => States[StateId - 24535];

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
                                true => 24535,
                                false => 24536,
                            },
                            false => Waterlogged switch {
                                true => 24537,
                                false => 24538,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 24539,
                                false => 24540,
                            },
                            false => Waterlogged switch {
                                true => 24541,
                                false => 24542,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 24543,
                                false => 24544,
                            },
                            false => Waterlogged switch {
                                true => 24545,
                                false => 24546,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 24547,
                                false => 24548,
                            },
                            false => Waterlogged switch {
                                true => 24549,
                                false => 24550,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 24551,
                                false => 24552,
                            },
                            false => Waterlogged switch {
                                true => 24553,
                                false => 24554,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 24555,
                                false => 24556,
                            },
                            false => Waterlogged switch {
                                true => 24557,
                                false => 24558,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 24559,
                                false => 24560,
                            },
                            false => Waterlogged switch {
                                true => 24561,
                                false => 24562,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 24563,
                                false => 24564,
                            },
                            false => Waterlogged switch {
                                true => 24565,
                                false => 24566,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 24567,
                                false => 24568,
                            },
                            false => Waterlogged switch {
                                true => 24569,
                                false => 24570,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 24571,
                                false => 24572,
                            },
                            false => Waterlogged switch {
                                true => 24573,
                                false => 24574,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 24575,
                                false => 24576,
                            },
                            false => Waterlogged switch {
                                true => 24577,
                                false => 24578,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 24579,
                                false => 24580,
                            },
                            false => Waterlogged switch {
                                true => 24581,
                                false => 24582,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 24583,
                                false => 24584,
                            },
                            false => Waterlogged switch {
                                true => 24585,
                                false => 24586,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 24587,
                                false => 24588,
                            },
                            false => Waterlogged switch {
                                true => 24589,
                                false => 24590,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 24591,
                                false => 24592,
                            },
                            false => Waterlogged switch {
                                true => 24593,
                                false => 24594,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 24595,
                                false => 24596,
                            },
                            false => Waterlogged switch {
                                true => 24597,
                                false => 24598,
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
            24535 => new WarpedTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            24536 => new WarpedTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            24537 => new WarpedTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            24538 => new WarpedTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            24539 => new WarpedTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            24540 => new WarpedTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            24541 => new WarpedTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            24542 => new WarpedTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            24543 => new WarpedTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            24544 => new WarpedTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            24545 => new WarpedTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            24546 => new WarpedTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            24547 => new WarpedTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            24548 => new WarpedTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            24549 => new WarpedTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            24550 => new WarpedTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            24551 => new WarpedTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            24552 => new WarpedTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            24553 => new WarpedTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            24554 => new WarpedTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            24555 => new WarpedTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            24556 => new WarpedTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            24557 => new WarpedTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            24558 => new WarpedTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            24559 => new WarpedTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            24560 => new WarpedTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            24561 => new WarpedTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            24562 => new WarpedTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            24563 => new WarpedTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            24564 => new WarpedTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            24565 => new WarpedTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            24566 => new WarpedTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            24567 => new WarpedTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            24568 => new WarpedTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            24569 => new WarpedTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            24570 => new WarpedTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            24571 => new WarpedTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            24572 => new WarpedTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            24573 => new WarpedTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            24574 => new WarpedTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            24575 => new WarpedTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            24576 => new WarpedTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            24577 => new WarpedTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            24578 => new WarpedTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            24579 => new WarpedTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            24580 => new WarpedTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            24581 => new WarpedTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            24582 => new WarpedTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            24583 => new WarpedTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            24584 => new WarpedTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            24585 => new WarpedTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            24586 => new WarpedTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            24587 => new WarpedTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            24588 => new WarpedTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            24589 => new WarpedTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            24590 => new WarpedTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            24591 => new WarpedTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            24592 => new WarpedTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            24593 => new WarpedTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            24594 => new WarpedTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            24595 => new WarpedTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            24596 => new WarpedTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            24597 => new WarpedTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            24598 => new WarpedTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
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
