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
public record PaleOakTrapdoorBlock(Identifier Identifier, Direction Facing, TopBottom Half, bool Open, bool Powered, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IOpenable, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:trapdoor", "block.minecraft.pale_oak_trapdoor", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:pale_oak_trapdoor", BlockInfo.VanillaOnly, "minecraft:blocks/pale_oak_trapdoor");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Normal, 14, "wood", NoteBlockInstrument.Bass, false, false, false, true, false, false, false, false, true, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18, BlockShapes.S18);
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

    public BlockStateInfo StateInfo => States[StateId - 7562];

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
                                true => 7562,
                                false => 7563,
                            },
                            false => Waterlogged switch {
                                true => 7564,
                                false => 7565,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7566,
                                false => 7567,
                            },
                            false => Waterlogged switch {
                                true => 7568,
                                false => 7569,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7570,
                                false => 7571,
                            },
                            false => Waterlogged switch {
                                true => 7572,
                                false => 7573,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7574,
                                false => 7575,
                            },
                            false => Waterlogged switch {
                                true => 7576,
                                false => 7577,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7578,
                                false => 7579,
                            },
                            false => Waterlogged switch {
                                true => 7580,
                                false => 7581,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7582,
                                false => 7583,
                            },
                            false => Waterlogged switch {
                                true => 7584,
                                false => 7585,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7586,
                                false => 7587,
                            },
                            false => Waterlogged switch {
                                true => 7588,
                                false => 7589,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7590,
                                false => 7591,
                            },
                            false => Waterlogged switch {
                                true => 7592,
                                false => 7593,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7594,
                                false => 7595,
                            },
                            false => Waterlogged switch {
                                true => 7596,
                                false => 7597,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7598,
                                false => 7599,
                            },
                            false => Waterlogged switch {
                                true => 7600,
                                false => 7601,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7602,
                                false => 7603,
                            },
                            false => Waterlogged switch {
                                true => 7604,
                                false => 7605,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7606,
                                false => 7607,
                            },
                            false => Waterlogged switch {
                                true => 7608,
                                false => 7609,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7610,
                                false => 7611,
                            },
                            false => Waterlogged switch {
                                true => 7612,
                                false => 7613,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7614,
                                false => 7615,
                            },
                            false => Waterlogged switch {
                                true => 7616,
                                false => 7617,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7618,
                                false => 7619,
                            },
                            false => Waterlogged switch {
                                true => 7620,
                                false => 7621,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7622,
                                false => 7623,
                            },
                            false => Waterlogged switch {
                                true => 7624,
                                false => 7625,
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
            7562 => new PaleOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            7563 => new PaleOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            7564 => new PaleOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            7565 => new PaleOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            7566 => new PaleOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            7567 => new PaleOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            7568 => new PaleOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            7569 => new PaleOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            7570 => new PaleOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            7571 => new PaleOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            7572 => new PaleOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            7573 => new PaleOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            7574 => new PaleOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            7575 => new PaleOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            7576 => new PaleOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            7577 => new PaleOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            7578 => new PaleOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            7579 => new PaleOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            7580 => new PaleOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            7581 => new PaleOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            7582 => new PaleOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            7583 => new PaleOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            7584 => new PaleOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            7585 => new PaleOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            7586 => new PaleOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            7587 => new PaleOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            7588 => new PaleOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            7589 => new PaleOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            7590 => new PaleOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            7591 => new PaleOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            7592 => new PaleOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            7593 => new PaleOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            7594 => new PaleOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            7595 => new PaleOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            7596 => new PaleOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            7597 => new PaleOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            7598 => new PaleOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            7599 => new PaleOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            7600 => new PaleOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            7601 => new PaleOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            7602 => new PaleOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            7603 => new PaleOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            7604 => new PaleOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            7605 => new PaleOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            7606 => new PaleOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            7607 => new PaleOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            7608 => new PaleOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            7609 => new PaleOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            7610 => new PaleOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            7611 => new PaleOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            7612 => new PaleOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            7613 => new PaleOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            7614 => new PaleOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            7615 => new PaleOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            7616 => new PaleOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            7617 => new PaleOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            7618 => new PaleOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            7619 => new PaleOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            7620 => new PaleOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            7621 => new PaleOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            7622 => new PaleOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            7623 => new PaleOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            7624 => new PaleOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            7625 => new PaleOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
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
