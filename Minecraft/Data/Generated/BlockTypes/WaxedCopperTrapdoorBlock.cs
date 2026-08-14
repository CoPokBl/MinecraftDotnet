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
    private static readonly BlockInfo Data = new("minecraft:trapdoor", "block.minecraft.waxed_copper_trapdoor", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:waxed_copper_trapdoor", BlockInfo.VanillaOnly, "minecraft:blocks/waxed_copper_trapdoor");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Normal, 15, "copper", NoteBlockInstrument.Harp, false, false, true, true, false, false, false, false, true, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18, BlockShapes.S18);
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

    public BlockStateInfo StateInfo => States[StateId - 29264];

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
                                true => 29264,
                                false => 29265,
                            },
                            false => Waterlogged switch {
                                true => 29266,
                                false => 29267,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29268,
                                false => 29269,
                            },
                            false => Waterlogged switch {
                                true => 29270,
                                false => 29271,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29272,
                                false => 29273,
                            },
                            false => Waterlogged switch {
                                true => 29274,
                                false => 29275,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29276,
                                false => 29277,
                            },
                            false => Waterlogged switch {
                                true => 29278,
                                false => 29279,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29280,
                                false => 29281,
                            },
                            false => Waterlogged switch {
                                true => 29282,
                                false => 29283,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29284,
                                false => 29285,
                            },
                            false => Waterlogged switch {
                                true => 29286,
                                false => 29287,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29288,
                                false => 29289,
                            },
                            false => Waterlogged switch {
                                true => 29290,
                                false => 29291,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29292,
                                false => 29293,
                            },
                            false => Waterlogged switch {
                                true => 29294,
                                false => 29295,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29296,
                                false => 29297,
                            },
                            false => Waterlogged switch {
                                true => 29298,
                                false => 29299,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29300,
                                false => 29301,
                            },
                            false => Waterlogged switch {
                                true => 29302,
                                false => 29303,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29304,
                                false => 29305,
                            },
                            false => Waterlogged switch {
                                true => 29306,
                                false => 29307,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29308,
                                false => 29309,
                            },
                            false => Waterlogged switch {
                                true => 29310,
                                false => 29311,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29312,
                                false => 29313,
                            },
                            false => Waterlogged switch {
                                true => 29314,
                                false => 29315,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29316,
                                false => 29317,
                            },
                            false => Waterlogged switch {
                                true => 29318,
                                false => 29319,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29320,
                                false => 29321,
                            },
                            false => Waterlogged switch {
                                true => 29322,
                                false => 29323,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29324,
                                false => 29325,
                            },
                            false => Waterlogged switch {
                                true => 29326,
                                false => 29327,
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
            29264 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            29265 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            29266 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            29267 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            29268 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            29269 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            29270 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            29271 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            29272 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            29273 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            29274 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            29275 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            29276 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            29277 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            29278 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            29279 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            29280 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            29281 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            29282 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            29283 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            29284 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            29285 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            29286 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            29287 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            29288 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            29289 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            29290 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            29291 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            29292 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            29293 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            29294 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            29295 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            29296 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            29297 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            29298 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            29299 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            29300 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            29301 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            29302 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            29303 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            29304 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            29305 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            29306 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            29307 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            29308 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            29309 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            29310 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            29311 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            29312 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            29313 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            29314 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            29315 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            29316 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            29317 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            29318 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            29319 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            29320 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            29321 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            29322 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            29323 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            29324 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            29325 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            29326 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            29327 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
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
