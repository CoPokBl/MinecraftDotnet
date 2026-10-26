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
public record OxidizedCopperTrapdoorBlock(Identifier Identifier, Direction Facing, TopBottom Half, bool Open, bool Powered, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IOpenable, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.oxidized_copper_trapdoor", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:oxidized_copper_trapdoor", BlockInfo.VanillaOnly, "minecraft:blocks/oxidized_copper_trapdoor");
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

    public BlockStateInfo StateInfo => States[StateId - 32557];

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
                                true => 32557,
                                false => 32558,
                            },
                            false => Waterlogged switch {
                                true => 32559,
                                false => 32560,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32561,
                                false => 32562,
                            },
                            false => Waterlogged switch {
                                true => 32563,
                                false => 32564,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32565,
                                false => 32566,
                            },
                            false => Waterlogged switch {
                                true => 32567,
                                false => 32568,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32569,
                                false => 32570,
                            },
                            false => Waterlogged switch {
                                true => 32571,
                                false => 32572,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32573,
                                false => 32574,
                            },
                            false => Waterlogged switch {
                                true => 32575,
                                false => 32576,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32577,
                                false => 32578,
                            },
                            false => Waterlogged switch {
                                true => 32579,
                                false => 32580,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32581,
                                false => 32582,
                            },
                            false => Waterlogged switch {
                                true => 32583,
                                false => 32584,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32585,
                                false => 32586,
                            },
                            false => Waterlogged switch {
                                true => 32587,
                                false => 32588,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32589,
                                false => 32590,
                            },
                            false => Waterlogged switch {
                                true => 32591,
                                false => 32592,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32593,
                                false => 32594,
                            },
                            false => Waterlogged switch {
                                true => 32595,
                                false => 32596,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32597,
                                false => 32598,
                            },
                            false => Waterlogged switch {
                                true => 32599,
                                false => 32600,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32601,
                                false => 32602,
                            },
                            false => Waterlogged switch {
                                true => 32603,
                                false => 32604,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32605,
                                false => 32606,
                            },
                            false => Waterlogged switch {
                                true => 32607,
                                false => 32608,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32609,
                                false => 32610,
                            },
                            false => Waterlogged switch {
                                true => 32611,
                                false => 32612,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32613,
                                false => 32614,
                            },
                            false => Waterlogged switch {
                                true => 32615,
                                false => 32616,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32617,
                                false => 32618,
                            },
                            false => Waterlogged switch {
                                true => 32619,
                                false => 32620,
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
            32557 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            32558 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            32559 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            32560 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            32561 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            32562 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            32563 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            32564 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            32565 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            32566 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            32567 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            32568 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            32569 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            32570 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            32571 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            32572 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            32573 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            32574 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            32575 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            32576 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            32577 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            32578 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            32579 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            32580 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            32581 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            32582 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            32583 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            32584 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            32585 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            32586 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            32587 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            32588 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            32589 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            32590 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            32591 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            32592 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            32593 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            32594 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            32595 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            32596 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            32597 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            32598 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            32599 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            32600 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            32601 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            32602 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            32603 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            32604 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            32605 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            32606 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            32607 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            32608 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            32609 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            32610 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            32611 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            32612 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            32613 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            32614 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            32615 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            32616 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            32617 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            32618 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            32619 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            32620 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
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
