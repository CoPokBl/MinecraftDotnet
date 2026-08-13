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
public record MangroveTrapdoorBlock(Identifier Identifier, Direction Facing, TopBottom Half, bool Open, bool Powered, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IOpenable, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:trapdoor", "block.minecraft.mangrove_trapdoor", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:mangrove_trapdoor", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Normal, 28, "wood", NoteBlockInstrument.Bass, false, false, false, true, false, false, false, false, true, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18, BlockShapes.S18);
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

    public BlockStateInfo StateInfo => States[StateId - 7626];

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
                                true => 7626,
                                false => 7627,
                            },
                            false => Waterlogged switch {
                                true => 7628,
                                false => 7629,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7630,
                                false => 7631,
                            },
                            false => Waterlogged switch {
                                true => 7632,
                                false => 7633,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7634,
                                false => 7635,
                            },
                            false => Waterlogged switch {
                                true => 7636,
                                false => 7637,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7638,
                                false => 7639,
                            },
                            false => Waterlogged switch {
                                true => 7640,
                                false => 7641,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7642,
                                false => 7643,
                            },
                            false => Waterlogged switch {
                                true => 7644,
                                false => 7645,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7646,
                                false => 7647,
                            },
                            false => Waterlogged switch {
                                true => 7648,
                                false => 7649,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7650,
                                false => 7651,
                            },
                            false => Waterlogged switch {
                                true => 7652,
                                false => 7653,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7654,
                                false => 7655,
                            },
                            false => Waterlogged switch {
                                true => 7656,
                                false => 7657,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7658,
                                false => 7659,
                            },
                            false => Waterlogged switch {
                                true => 7660,
                                false => 7661,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7662,
                                false => 7663,
                            },
                            false => Waterlogged switch {
                                true => 7664,
                                false => 7665,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7666,
                                false => 7667,
                            },
                            false => Waterlogged switch {
                                true => 7668,
                                false => 7669,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7670,
                                false => 7671,
                            },
                            false => Waterlogged switch {
                                true => 7672,
                                false => 7673,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7674,
                                false => 7675,
                            },
                            false => Waterlogged switch {
                                true => 7676,
                                false => 7677,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7678,
                                false => 7679,
                            },
                            false => Waterlogged switch {
                                true => 7680,
                                false => 7681,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7682,
                                false => 7683,
                            },
                            false => Waterlogged switch {
                                true => 7684,
                                false => 7685,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7686,
                                false => 7687,
                            },
                            false => Waterlogged switch {
                                true => 7688,
                                false => 7689,
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
            7626 => new MangroveTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            7627 => new MangroveTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            7628 => new MangroveTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            7629 => new MangroveTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            7630 => new MangroveTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            7631 => new MangroveTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            7632 => new MangroveTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            7633 => new MangroveTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            7634 => new MangroveTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            7635 => new MangroveTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            7636 => new MangroveTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            7637 => new MangroveTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            7638 => new MangroveTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            7639 => new MangroveTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            7640 => new MangroveTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            7641 => new MangroveTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            7642 => new MangroveTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            7643 => new MangroveTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            7644 => new MangroveTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            7645 => new MangroveTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            7646 => new MangroveTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            7647 => new MangroveTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            7648 => new MangroveTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            7649 => new MangroveTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            7650 => new MangroveTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            7651 => new MangroveTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            7652 => new MangroveTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            7653 => new MangroveTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            7654 => new MangroveTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            7655 => new MangroveTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            7656 => new MangroveTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            7657 => new MangroveTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            7658 => new MangroveTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            7659 => new MangroveTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            7660 => new MangroveTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            7661 => new MangroveTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            7662 => new MangroveTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            7663 => new MangroveTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            7664 => new MangroveTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            7665 => new MangroveTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            7666 => new MangroveTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            7667 => new MangroveTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            7668 => new MangroveTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            7669 => new MangroveTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            7670 => new MangroveTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            7671 => new MangroveTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            7672 => new MangroveTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            7673 => new MangroveTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            7674 => new MangroveTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            7675 => new MangroveTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            7676 => new MangroveTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            7677 => new MangroveTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            7678 => new MangroveTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            7679 => new MangroveTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            7680 => new MangroveTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            7681 => new MangroveTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            7682 => new MangroveTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            7683 => new MangroveTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            7684 => new MangroveTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            7685 => new MangroveTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            7686 => new MangroveTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            7687 => new MangroveTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            7688 => new MangroveTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            7689 => new MangroveTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
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
