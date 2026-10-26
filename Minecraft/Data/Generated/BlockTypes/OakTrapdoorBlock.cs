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
public record OakTrapdoorBlock(Identifier Identifier, Direction Facing, TopBottom Half, bool Open, bool Powered, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IOpenable, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.oak_trapdoor", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:oak_trapdoor", BlockInfo.VanillaOnly, "minecraft:blocks/oak_trapdoor");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.PushPull, 13, "wood", NoteBlockInstrument.Bass, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18, BlockShapes.S18);
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

    public BlockStateInfo StateInfo => States[StateId - 8784];

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
                                true => 8784,
                                false => 8785,
                            },
                            false => Waterlogged switch {
                                true => 8786,
                                false => 8787,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 8788,
                                false => 8789,
                            },
                            false => Waterlogged switch {
                                true => 8790,
                                false => 8791,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 8792,
                                false => 8793,
                            },
                            false => Waterlogged switch {
                                true => 8794,
                                false => 8795,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 8796,
                                false => 8797,
                            },
                            false => Waterlogged switch {
                                true => 8798,
                                false => 8799,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 8800,
                                false => 8801,
                            },
                            false => Waterlogged switch {
                                true => 8802,
                                false => 8803,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 8804,
                                false => 8805,
                            },
                            false => Waterlogged switch {
                                true => 8806,
                                false => 8807,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 8808,
                                false => 8809,
                            },
                            false => Waterlogged switch {
                                true => 8810,
                                false => 8811,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 8812,
                                false => 8813,
                            },
                            false => Waterlogged switch {
                                true => 8814,
                                false => 8815,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 8816,
                                false => 8817,
                            },
                            false => Waterlogged switch {
                                true => 8818,
                                false => 8819,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 8820,
                                false => 8821,
                            },
                            false => Waterlogged switch {
                                true => 8822,
                                false => 8823,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 8824,
                                false => 8825,
                            },
                            false => Waterlogged switch {
                                true => 8826,
                                false => 8827,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 8828,
                                false => 8829,
                            },
                            false => Waterlogged switch {
                                true => 8830,
                                false => 8831,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 8832,
                                false => 8833,
                            },
                            false => Waterlogged switch {
                                true => 8834,
                                false => 8835,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 8836,
                                false => 8837,
                            },
                            false => Waterlogged switch {
                                true => 8838,
                                false => 8839,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 8840,
                                false => 8841,
                            },
                            false => Waterlogged switch {
                                true => 8842,
                                false => 8843,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 8844,
                                false => 8845,
                            },
                            false => Waterlogged switch {
                                true => 8846,
                                false => 8847,
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
            8784 => new OakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            8785 => new OakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            8786 => new OakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            8787 => new OakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            8788 => new OakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            8789 => new OakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            8790 => new OakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            8791 => new OakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            8792 => new OakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            8793 => new OakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            8794 => new OakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            8795 => new OakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            8796 => new OakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            8797 => new OakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            8798 => new OakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            8799 => new OakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            8800 => new OakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            8801 => new OakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            8802 => new OakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            8803 => new OakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            8804 => new OakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            8805 => new OakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            8806 => new OakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            8807 => new OakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            8808 => new OakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            8809 => new OakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            8810 => new OakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            8811 => new OakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            8812 => new OakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            8813 => new OakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            8814 => new OakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            8815 => new OakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            8816 => new OakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            8817 => new OakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            8818 => new OakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            8819 => new OakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            8820 => new OakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            8821 => new OakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            8822 => new OakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            8823 => new OakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            8824 => new OakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            8825 => new OakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            8826 => new OakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            8827 => new OakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            8828 => new OakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            8829 => new OakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            8830 => new OakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            8831 => new OakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            8832 => new OakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            8833 => new OakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            8834 => new OakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            8835 => new OakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            8836 => new OakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            8837 => new OakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            8838 => new OakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            8839 => new OakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            8840 => new OakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            8841 => new OakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            8842 => new OakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            8843 => new OakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            8844 => new OakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            8845 => new OakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            8846 => new OakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            8847 => new OakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
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
