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
public record SpruceTrapdoorBlock(Identifier Identifier, Direction Facing, TopBottom Half, bool Open, bool Powered, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IOpenable, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:trapdoor", "block.minecraft.spruce_trapdoor", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:spruce_trapdoor", BlockInfo.VanillaOnly, "minecraft:blocks/spruce_trapdoor");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Normal, 34, "wood", NoteBlockInstrument.Bass, false, false, false, true, false, false, false, false, true, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18, BlockShapes.S18);
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

    public BlockStateInfo StateInfo => States[StateId - 7178];

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
                                true => 7178,
                                false => 7179,
                            },
                            false => Waterlogged switch {
                                true => 7180,
                                false => 7181,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7182,
                                false => 7183,
                            },
                            false => Waterlogged switch {
                                true => 7184,
                                false => 7185,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7186,
                                false => 7187,
                            },
                            false => Waterlogged switch {
                                true => 7188,
                                false => 7189,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7190,
                                false => 7191,
                            },
                            false => Waterlogged switch {
                                true => 7192,
                                false => 7193,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7194,
                                false => 7195,
                            },
                            false => Waterlogged switch {
                                true => 7196,
                                false => 7197,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7198,
                                false => 7199,
                            },
                            false => Waterlogged switch {
                                true => 7200,
                                false => 7201,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7202,
                                false => 7203,
                            },
                            false => Waterlogged switch {
                                true => 7204,
                                false => 7205,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7206,
                                false => 7207,
                            },
                            false => Waterlogged switch {
                                true => 7208,
                                false => 7209,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7210,
                                false => 7211,
                            },
                            false => Waterlogged switch {
                                true => 7212,
                                false => 7213,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7214,
                                false => 7215,
                            },
                            false => Waterlogged switch {
                                true => 7216,
                                false => 7217,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7218,
                                false => 7219,
                            },
                            false => Waterlogged switch {
                                true => 7220,
                                false => 7221,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7222,
                                false => 7223,
                            },
                            false => Waterlogged switch {
                                true => 7224,
                                false => 7225,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7226,
                                false => 7227,
                            },
                            false => Waterlogged switch {
                                true => 7228,
                                false => 7229,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7230,
                                false => 7231,
                            },
                            false => Waterlogged switch {
                                true => 7232,
                                false => 7233,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7234,
                                false => 7235,
                            },
                            false => Waterlogged switch {
                                true => 7236,
                                false => 7237,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7238,
                                false => 7239,
                            },
                            false => Waterlogged switch {
                                true => 7240,
                                false => 7241,
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
            7178 => new SpruceTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            7179 => new SpruceTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            7180 => new SpruceTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            7181 => new SpruceTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            7182 => new SpruceTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            7183 => new SpruceTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            7184 => new SpruceTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            7185 => new SpruceTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            7186 => new SpruceTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            7187 => new SpruceTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            7188 => new SpruceTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            7189 => new SpruceTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            7190 => new SpruceTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            7191 => new SpruceTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            7192 => new SpruceTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            7193 => new SpruceTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            7194 => new SpruceTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            7195 => new SpruceTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            7196 => new SpruceTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            7197 => new SpruceTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            7198 => new SpruceTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            7199 => new SpruceTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            7200 => new SpruceTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            7201 => new SpruceTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            7202 => new SpruceTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            7203 => new SpruceTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            7204 => new SpruceTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            7205 => new SpruceTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            7206 => new SpruceTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            7207 => new SpruceTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            7208 => new SpruceTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            7209 => new SpruceTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            7210 => new SpruceTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            7211 => new SpruceTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            7212 => new SpruceTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            7213 => new SpruceTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            7214 => new SpruceTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            7215 => new SpruceTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            7216 => new SpruceTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            7217 => new SpruceTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            7218 => new SpruceTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            7219 => new SpruceTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            7220 => new SpruceTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            7221 => new SpruceTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            7222 => new SpruceTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            7223 => new SpruceTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            7224 => new SpruceTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            7225 => new SpruceTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            7226 => new SpruceTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            7227 => new SpruceTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            7228 => new SpruceTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            7229 => new SpruceTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            7230 => new SpruceTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            7231 => new SpruceTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            7232 => new SpruceTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            7233 => new SpruceTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            7234 => new SpruceTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            7235 => new SpruceTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            7236 => new SpruceTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            7237 => new SpruceTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            7238 => new SpruceTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            7239 => new SpruceTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            7240 => new SpruceTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            7241 => new SpruceTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
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
