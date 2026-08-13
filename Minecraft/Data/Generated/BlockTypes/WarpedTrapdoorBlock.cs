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
    private static readonly BlockInfo Data = new("minecraft:trapdoor", "block.minecraft.warped_trapdoor", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:warped_trapdoor", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Normal, 56, "nether_wood", NoteBlockInstrument.Bass, false, false, false, true, false, false, false, false, true, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18, BlockShapes.S18);
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

    public BlockStateInfo StateInfo => States[StateId - 21178];

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
                                true => 21178,
                                false => 21179,
                            },
                            false => Waterlogged switch {
                                true => 21180,
                                false => 21181,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 21182,
                                false => 21183,
                            },
                            false => Waterlogged switch {
                                true => 21184,
                                false => 21185,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 21186,
                                false => 21187,
                            },
                            false => Waterlogged switch {
                                true => 21188,
                                false => 21189,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 21190,
                                false => 21191,
                            },
                            false => Waterlogged switch {
                                true => 21192,
                                false => 21193,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 21194,
                                false => 21195,
                            },
                            false => Waterlogged switch {
                                true => 21196,
                                false => 21197,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 21198,
                                false => 21199,
                            },
                            false => Waterlogged switch {
                                true => 21200,
                                false => 21201,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 21202,
                                false => 21203,
                            },
                            false => Waterlogged switch {
                                true => 21204,
                                false => 21205,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 21206,
                                false => 21207,
                            },
                            false => Waterlogged switch {
                                true => 21208,
                                false => 21209,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 21210,
                                false => 21211,
                            },
                            false => Waterlogged switch {
                                true => 21212,
                                false => 21213,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 21214,
                                false => 21215,
                            },
                            false => Waterlogged switch {
                                true => 21216,
                                false => 21217,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 21218,
                                false => 21219,
                            },
                            false => Waterlogged switch {
                                true => 21220,
                                false => 21221,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 21222,
                                false => 21223,
                            },
                            false => Waterlogged switch {
                                true => 21224,
                                false => 21225,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 21226,
                                false => 21227,
                            },
                            false => Waterlogged switch {
                                true => 21228,
                                false => 21229,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 21230,
                                false => 21231,
                            },
                            false => Waterlogged switch {
                                true => 21232,
                                false => 21233,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 21234,
                                false => 21235,
                            },
                            false => Waterlogged switch {
                                true => 21236,
                                false => 21237,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 21238,
                                false => 21239,
                            },
                            false => Waterlogged switch {
                                true => 21240,
                                false => 21241,
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
            21178 => new WarpedTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            21179 => new WarpedTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            21180 => new WarpedTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            21181 => new WarpedTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            21182 => new WarpedTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            21183 => new WarpedTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            21184 => new WarpedTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            21185 => new WarpedTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            21186 => new WarpedTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            21187 => new WarpedTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            21188 => new WarpedTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            21189 => new WarpedTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            21190 => new WarpedTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            21191 => new WarpedTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            21192 => new WarpedTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            21193 => new WarpedTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            21194 => new WarpedTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            21195 => new WarpedTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            21196 => new WarpedTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            21197 => new WarpedTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            21198 => new WarpedTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            21199 => new WarpedTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            21200 => new WarpedTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            21201 => new WarpedTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            21202 => new WarpedTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            21203 => new WarpedTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            21204 => new WarpedTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            21205 => new WarpedTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            21206 => new WarpedTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            21207 => new WarpedTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            21208 => new WarpedTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            21209 => new WarpedTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            21210 => new WarpedTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            21211 => new WarpedTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            21212 => new WarpedTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            21213 => new WarpedTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            21214 => new WarpedTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            21215 => new WarpedTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            21216 => new WarpedTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            21217 => new WarpedTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            21218 => new WarpedTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            21219 => new WarpedTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            21220 => new WarpedTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            21221 => new WarpedTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            21222 => new WarpedTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            21223 => new WarpedTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            21224 => new WarpedTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            21225 => new WarpedTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            21226 => new WarpedTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            21227 => new WarpedTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            21228 => new WarpedTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            21229 => new WarpedTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            21230 => new WarpedTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            21231 => new WarpedTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            21232 => new WarpedTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            21233 => new WarpedTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            21234 => new WarpedTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            21235 => new WarpedTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            21236 => new WarpedTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            21237 => new WarpedTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            21238 => new WarpedTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            21239 => new WarpedTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            21240 => new WarpedTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            21241 => new WarpedTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
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
