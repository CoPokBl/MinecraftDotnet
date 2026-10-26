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
    private static readonly BlockInfo Data = new("block.minecraft.pale_oak_trapdoor", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:pale_oak_trapdoor", BlockInfo.VanillaOnly, "minecraft:blocks/pale_oak_trapdoor");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.PushPull, 14, "wood", NoteBlockInstrument.Bass, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18, BlockShapes.S18);
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

    public BlockStateInfo StateInfo => States[StateId - 9232];

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
                                true => 9232,
                                false => 9233,
                            },
                            false => Waterlogged switch {
                                true => 9234,
                                false => 9235,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9236,
                                false => 9237,
                            },
                            false => Waterlogged switch {
                                true => 9238,
                                false => 9239,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9240,
                                false => 9241,
                            },
                            false => Waterlogged switch {
                                true => 9242,
                                false => 9243,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9244,
                                false => 9245,
                            },
                            false => Waterlogged switch {
                                true => 9246,
                                false => 9247,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9248,
                                false => 9249,
                            },
                            false => Waterlogged switch {
                                true => 9250,
                                false => 9251,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9252,
                                false => 9253,
                            },
                            false => Waterlogged switch {
                                true => 9254,
                                false => 9255,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9256,
                                false => 9257,
                            },
                            false => Waterlogged switch {
                                true => 9258,
                                false => 9259,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9260,
                                false => 9261,
                            },
                            false => Waterlogged switch {
                                true => 9262,
                                false => 9263,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9264,
                                false => 9265,
                            },
                            false => Waterlogged switch {
                                true => 9266,
                                false => 9267,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9268,
                                false => 9269,
                            },
                            false => Waterlogged switch {
                                true => 9270,
                                false => 9271,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9272,
                                false => 9273,
                            },
                            false => Waterlogged switch {
                                true => 9274,
                                false => 9275,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9276,
                                false => 9277,
                            },
                            false => Waterlogged switch {
                                true => 9278,
                                false => 9279,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9280,
                                false => 9281,
                            },
                            false => Waterlogged switch {
                                true => 9282,
                                false => 9283,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9284,
                                false => 9285,
                            },
                            false => Waterlogged switch {
                                true => 9286,
                                false => 9287,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9288,
                                false => 9289,
                            },
                            false => Waterlogged switch {
                                true => 9290,
                                false => 9291,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9292,
                                false => 9293,
                            },
                            false => Waterlogged switch {
                                true => 9294,
                                false => 9295,
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
            9232 => new PaleOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            9233 => new PaleOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            9234 => new PaleOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            9235 => new PaleOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            9236 => new PaleOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            9237 => new PaleOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            9238 => new PaleOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            9239 => new PaleOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            9240 => new PaleOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            9241 => new PaleOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            9242 => new PaleOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            9243 => new PaleOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            9244 => new PaleOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            9245 => new PaleOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            9246 => new PaleOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            9247 => new PaleOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            9248 => new PaleOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            9249 => new PaleOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            9250 => new PaleOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            9251 => new PaleOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            9252 => new PaleOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            9253 => new PaleOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            9254 => new PaleOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            9255 => new PaleOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            9256 => new PaleOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            9257 => new PaleOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            9258 => new PaleOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            9259 => new PaleOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            9260 => new PaleOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            9261 => new PaleOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            9262 => new PaleOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            9263 => new PaleOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            9264 => new PaleOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            9265 => new PaleOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            9266 => new PaleOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            9267 => new PaleOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            9268 => new PaleOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            9269 => new PaleOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            9270 => new PaleOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            9271 => new PaleOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            9272 => new PaleOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            9273 => new PaleOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            9274 => new PaleOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            9275 => new PaleOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            9276 => new PaleOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            9277 => new PaleOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            9278 => new PaleOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            9279 => new PaleOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            9280 => new PaleOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            9281 => new PaleOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            9282 => new PaleOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            9283 => new PaleOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            9284 => new PaleOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            9285 => new PaleOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            9286 => new PaleOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            9287 => new PaleOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            9288 => new PaleOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            9289 => new PaleOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            9290 => new PaleOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            9291 => new PaleOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            9292 => new PaleOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            9293 => new PaleOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            9294 => new PaleOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            9295 => new PaleOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
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
