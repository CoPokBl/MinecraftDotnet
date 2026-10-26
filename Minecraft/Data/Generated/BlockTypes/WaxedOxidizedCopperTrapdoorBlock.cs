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
public record WaxedOxidizedCopperTrapdoorBlock(Identifier Identifier, Direction Facing, TopBottom Half, bool Open, bool Powered, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IOpenable, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.waxed_oxidized_copper_trapdoor", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:waxed_oxidized_copper_trapdoor", BlockInfo.VanillaOnly, "minecraft:blocks/waxed_oxidized_copper_trapdoor");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.PushPull, 55, "copper", NoteBlockInstrument.Harp, false, false, true, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18, BlockShapes.S18);
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

    public BlockStateInfo StateInfo => States[StateId - 32813];

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
                                true => 32813,
                                false => 32814,
                            },
                            false => Waterlogged switch {
                                true => 32815,
                                false => 32816,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32817,
                                false => 32818,
                            },
                            false => Waterlogged switch {
                                true => 32819,
                                false => 32820,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32821,
                                false => 32822,
                            },
                            false => Waterlogged switch {
                                true => 32823,
                                false => 32824,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32825,
                                false => 32826,
                            },
                            false => Waterlogged switch {
                                true => 32827,
                                false => 32828,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32829,
                                false => 32830,
                            },
                            false => Waterlogged switch {
                                true => 32831,
                                false => 32832,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32833,
                                false => 32834,
                            },
                            false => Waterlogged switch {
                                true => 32835,
                                false => 32836,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32837,
                                false => 32838,
                            },
                            false => Waterlogged switch {
                                true => 32839,
                                false => 32840,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32841,
                                false => 32842,
                            },
                            false => Waterlogged switch {
                                true => 32843,
                                false => 32844,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32845,
                                false => 32846,
                            },
                            false => Waterlogged switch {
                                true => 32847,
                                false => 32848,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32849,
                                false => 32850,
                            },
                            false => Waterlogged switch {
                                true => 32851,
                                false => 32852,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32853,
                                false => 32854,
                            },
                            false => Waterlogged switch {
                                true => 32855,
                                false => 32856,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32857,
                                false => 32858,
                            },
                            false => Waterlogged switch {
                                true => 32859,
                                false => 32860,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32861,
                                false => 32862,
                            },
                            false => Waterlogged switch {
                                true => 32863,
                                false => 32864,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32865,
                                false => 32866,
                            },
                            false => Waterlogged switch {
                                true => 32867,
                                false => 32868,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32869,
                                false => 32870,
                            },
                            false => Waterlogged switch {
                                true => 32871,
                                false => 32872,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32873,
                                false => 32874,
                            },
                            false => Waterlogged switch {
                                true => 32875,
                                false => 32876,
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
            32813 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            32814 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            32815 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            32816 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            32817 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            32818 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            32819 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            32820 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            32821 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            32822 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            32823 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            32824 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            32825 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            32826 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            32827 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            32828 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            32829 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            32830 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            32831 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            32832 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            32833 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            32834 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            32835 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            32836 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            32837 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            32838 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            32839 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            32840 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            32841 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            32842 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            32843 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            32844 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            32845 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            32846 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            32847 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            32848 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            32849 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            32850 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            32851 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            32852 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            32853 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            32854 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            32855 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            32856 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            32857 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            32858 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            32859 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            32860 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            32861 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            32862 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            32863 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            32864 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            32865 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            32866 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            32867 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            32868 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            32869 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            32870 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            32871 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            32872 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            32873 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            32874 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            32875 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            32876 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
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
