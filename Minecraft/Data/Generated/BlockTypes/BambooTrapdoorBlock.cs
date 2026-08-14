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
public record BambooTrapdoorBlock(Identifier Identifier, Direction Facing, TopBottom Half, bool Open, bool Powered, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IOpenable, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:trapdoor", "block.minecraft.bamboo_trapdoor", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:bamboo_trapdoor", BlockInfo.VanillaOnly, "minecraft:blocks/bamboo_trapdoor");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Normal, 18, "bamboo_wood", NoteBlockInstrument.Bass, false, false, false, true, false, false, false, false, true, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18, BlockShapes.S18);
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

    public BlockStateInfo StateInfo => States[StateId - 7690];

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
                                true => 7690,
                                false => 7691,
                            },
                            false => Waterlogged switch {
                                true => 7692,
                                false => 7693,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7694,
                                false => 7695,
                            },
                            false => Waterlogged switch {
                                true => 7696,
                                false => 7697,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7698,
                                false => 7699,
                            },
                            false => Waterlogged switch {
                                true => 7700,
                                false => 7701,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7702,
                                false => 7703,
                            },
                            false => Waterlogged switch {
                                true => 7704,
                                false => 7705,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7706,
                                false => 7707,
                            },
                            false => Waterlogged switch {
                                true => 7708,
                                false => 7709,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7710,
                                false => 7711,
                            },
                            false => Waterlogged switch {
                                true => 7712,
                                false => 7713,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7714,
                                false => 7715,
                            },
                            false => Waterlogged switch {
                                true => 7716,
                                false => 7717,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7718,
                                false => 7719,
                            },
                            false => Waterlogged switch {
                                true => 7720,
                                false => 7721,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7722,
                                false => 7723,
                            },
                            false => Waterlogged switch {
                                true => 7724,
                                false => 7725,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7726,
                                false => 7727,
                            },
                            false => Waterlogged switch {
                                true => 7728,
                                false => 7729,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7730,
                                false => 7731,
                            },
                            false => Waterlogged switch {
                                true => 7732,
                                false => 7733,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7734,
                                false => 7735,
                            },
                            false => Waterlogged switch {
                                true => 7736,
                                false => 7737,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7738,
                                false => 7739,
                            },
                            false => Waterlogged switch {
                                true => 7740,
                                false => 7741,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7742,
                                false => 7743,
                            },
                            false => Waterlogged switch {
                                true => 7744,
                                false => 7745,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7746,
                                false => 7747,
                            },
                            false => Waterlogged switch {
                                true => 7748,
                                false => 7749,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7750,
                                false => 7751,
                            },
                            false => Waterlogged switch {
                                true => 7752,
                                false => 7753,
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
            7690 => new BambooTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            7691 => new BambooTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            7692 => new BambooTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            7693 => new BambooTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            7694 => new BambooTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            7695 => new BambooTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            7696 => new BambooTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            7697 => new BambooTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            7698 => new BambooTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            7699 => new BambooTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            7700 => new BambooTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            7701 => new BambooTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            7702 => new BambooTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            7703 => new BambooTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            7704 => new BambooTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            7705 => new BambooTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            7706 => new BambooTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            7707 => new BambooTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            7708 => new BambooTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            7709 => new BambooTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            7710 => new BambooTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            7711 => new BambooTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            7712 => new BambooTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            7713 => new BambooTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            7714 => new BambooTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            7715 => new BambooTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            7716 => new BambooTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            7717 => new BambooTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            7718 => new BambooTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            7719 => new BambooTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            7720 => new BambooTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            7721 => new BambooTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            7722 => new BambooTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            7723 => new BambooTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            7724 => new BambooTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            7725 => new BambooTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            7726 => new BambooTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            7727 => new BambooTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            7728 => new BambooTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            7729 => new BambooTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            7730 => new BambooTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            7731 => new BambooTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            7732 => new BambooTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            7733 => new BambooTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            7734 => new BambooTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            7735 => new BambooTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            7736 => new BambooTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            7737 => new BambooTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            7738 => new BambooTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            7739 => new BambooTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            7740 => new BambooTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            7741 => new BambooTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            7742 => new BambooTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            7743 => new BambooTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            7744 => new BambooTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            7745 => new BambooTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            7746 => new BambooTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            7747 => new BambooTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            7748 => new BambooTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            7749 => new BambooTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            7750 => new BambooTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            7751 => new BambooTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            7752 => new BambooTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            7753 => new BambooTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
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
