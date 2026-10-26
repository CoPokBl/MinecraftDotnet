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
public record WaxedExposedCopperTrapdoorBlock(Identifier Identifier, Direction Facing, TopBottom Half, bool Open, bool Powered, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IOpenable, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.waxed_exposed_copper_trapdoor", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:waxed_exposed_copper_trapdoor", BlockInfo.VanillaOnly, "minecraft:blocks/waxed_exposed_copper_trapdoor");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.PushPull, 44, "copper", NoteBlockInstrument.Harp, false, false, true, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18, BlockShapes.S18);
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

    public BlockStateInfo StateInfo => States[StateId - 32685];

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
                                true => 32685,
                                false => 32686,
                            },
                            false => Waterlogged switch {
                                true => 32687,
                                false => 32688,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32689,
                                false => 32690,
                            },
                            false => Waterlogged switch {
                                true => 32691,
                                false => 32692,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32693,
                                false => 32694,
                            },
                            false => Waterlogged switch {
                                true => 32695,
                                false => 32696,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32697,
                                false => 32698,
                            },
                            false => Waterlogged switch {
                                true => 32699,
                                false => 32700,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32701,
                                false => 32702,
                            },
                            false => Waterlogged switch {
                                true => 32703,
                                false => 32704,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32705,
                                false => 32706,
                            },
                            false => Waterlogged switch {
                                true => 32707,
                                false => 32708,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32709,
                                false => 32710,
                            },
                            false => Waterlogged switch {
                                true => 32711,
                                false => 32712,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32713,
                                false => 32714,
                            },
                            false => Waterlogged switch {
                                true => 32715,
                                false => 32716,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32717,
                                false => 32718,
                            },
                            false => Waterlogged switch {
                                true => 32719,
                                false => 32720,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32721,
                                false => 32722,
                            },
                            false => Waterlogged switch {
                                true => 32723,
                                false => 32724,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32725,
                                false => 32726,
                            },
                            false => Waterlogged switch {
                                true => 32727,
                                false => 32728,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32729,
                                false => 32730,
                            },
                            false => Waterlogged switch {
                                true => 32731,
                                false => 32732,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32733,
                                false => 32734,
                            },
                            false => Waterlogged switch {
                                true => 32735,
                                false => 32736,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32737,
                                false => 32738,
                            },
                            false => Waterlogged switch {
                                true => 32739,
                                false => 32740,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32741,
                                false => 32742,
                            },
                            false => Waterlogged switch {
                                true => 32743,
                                false => 32744,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32745,
                                false => 32746,
                            },
                            false => Waterlogged switch {
                                true => 32747,
                                false => 32748,
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
            32685 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            32686 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            32687 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            32688 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            32689 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            32690 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            32691 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            32692 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            32693 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            32694 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            32695 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            32696 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            32697 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            32698 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            32699 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            32700 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            32701 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            32702 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            32703 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            32704 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            32705 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            32706 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            32707 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            32708 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            32709 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            32710 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            32711 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            32712 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            32713 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            32714 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            32715 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            32716 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            32717 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            32718 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            32719 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            32720 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            32721 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            32722 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            32723 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            32724 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            32725 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            32726 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            32727 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            32728 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            32729 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            32730 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            32731 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            32732 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            32733 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            32734 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            32735 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            32736 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            32737 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            32738 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            32739 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            32740 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            32741 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            32742 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            32743 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            32744 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            32745 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            32746 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            32747 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            32748 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
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
