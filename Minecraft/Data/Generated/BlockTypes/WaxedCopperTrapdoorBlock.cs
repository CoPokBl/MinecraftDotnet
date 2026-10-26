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
public record WaxedCopperTrapdoorBlock(Identifier Identifier, Direction Facing, TopBottom Half, bool Open, bool Powered, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IOpenable, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.waxed_copper_trapdoor", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:waxed_copper_trapdoor", BlockInfo.VanillaOnly, "minecraft:blocks/waxed_copper_trapdoor");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.PushPull, 15, "copper", NoteBlockInstrument.Harp, false, false, true, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18, BlockShapes.S18);
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

    public BlockStateInfo StateInfo => States[StateId - 32621];

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
                                true => 32621,
                                false => 32622,
                            },
                            false => Waterlogged switch {
                                true => 32623,
                                false => 32624,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32625,
                                false => 32626,
                            },
                            false => Waterlogged switch {
                                true => 32627,
                                false => 32628,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32629,
                                false => 32630,
                            },
                            false => Waterlogged switch {
                                true => 32631,
                                false => 32632,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32633,
                                false => 32634,
                            },
                            false => Waterlogged switch {
                                true => 32635,
                                false => 32636,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32637,
                                false => 32638,
                            },
                            false => Waterlogged switch {
                                true => 32639,
                                false => 32640,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32641,
                                false => 32642,
                            },
                            false => Waterlogged switch {
                                true => 32643,
                                false => 32644,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32645,
                                false => 32646,
                            },
                            false => Waterlogged switch {
                                true => 32647,
                                false => 32648,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32649,
                                false => 32650,
                            },
                            false => Waterlogged switch {
                                true => 32651,
                                false => 32652,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32653,
                                false => 32654,
                            },
                            false => Waterlogged switch {
                                true => 32655,
                                false => 32656,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32657,
                                false => 32658,
                            },
                            false => Waterlogged switch {
                                true => 32659,
                                false => 32660,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32661,
                                false => 32662,
                            },
                            false => Waterlogged switch {
                                true => 32663,
                                false => 32664,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32665,
                                false => 32666,
                            },
                            false => Waterlogged switch {
                                true => 32667,
                                false => 32668,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32669,
                                false => 32670,
                            },
                            false => Waterlogged switch {
                                true => 32671,
                                false => 32672,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32673,
                                false => 32674,
                            },
                            false => Waterlogged switch {
                                true => 32675,
                                false => 32676,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32677,
                                false => 32678,
                            },
                            false => Waterlogged switch {
                                true => 32679,
                                false => 32680,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32681,
                                false => 32682,
                            },
                            false => Waterlogged switch {
                                true => 32683,
                                false => 32684,
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
            32621 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            32622 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            32623 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            32624 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            32625 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            32626 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            32627 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            32628 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            32629 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            32630 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            32631 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            32632 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            32633 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            32634 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            32635 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            32636 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            32637 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            32638 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            32639 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            32640 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            32641 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            32642 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            32643 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            32644 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            32645 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            32646 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            32647 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            32648 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            32649 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            32650 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            32651 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            32652 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            32653 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            32654 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            32655 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            32656 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            32657 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            32658 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            32659 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            32660 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            32661 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            32662 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            32663 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            32664 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            32665 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            32666 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            32667 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            32668 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            32669 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            32670 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            32671 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            32672 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            32673 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            32674 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            32675 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            32676 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            32677 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            32678 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            32679 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            32680 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            32681 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            32682 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            32683 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            32684 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
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
