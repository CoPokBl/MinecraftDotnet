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
public record WeatheredCopperTrapdoorBlock(Identifier Identifier, Direction Facing, TopBottom Half, bool Open, bool Powered, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IOpenable, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:weathering_copper_trapdoor", "block.minecraft.weathered_copper_trapdoor", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:weathered_copper_trapdoor", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Normal, 56, "copper", NoteBlockInstrument.Harp, false, false, true, true, false, false, false, false, true, false, false, true, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18, BlockShapes.S18);
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

    public BlockStateInfo StateInfo => States[StateId - 29136];

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
                                true => 29136,
                                false => 29137,
                            },
                            false => Waterlogged switch {
                                true => 29138,
                                false => 29139,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29140,
                                false => 29141,
                            },
                            false => Waterlogged switch {
                                true => 29142,
                                false => 29143,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29144,
                                false => 29145,
                            },
                            false => Waterlogged switch {
                                true => 29146,
                                false => 29147,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29148,
                                false => 29149,
                            },
                            false => Waterlogged switch {
                                true => 29150,
                                false => 29151,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29152,
                                false => 29153,
                            },
                            false => Waterlogged switch {
                                true => 29154,
                                false => 29155,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29156,
                                false => 29157,
                            },
                            false => Waterlogged switch {
                                true => 29158,
                                false => 29159,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29160,
                                false => 29161,
                            },
                            false => Waterlogged switch {
                                true => 29162,
                                false => 29163,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29164,
                                false => 29165,
                            },
                            false => Waterlogged switch {
                                true => 29166,
                                false => 29167,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29168,
                                false => 29169,
                            },
                            false => Waterlogged switch {
                                true => 29170,
                                false => 29171,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29172,
                                false => 29173,
                            },
                            false => Waterlogged switch {
                                true => 29174,
                                false => 29175,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29176,
                                false => 29177,
                            },
                            false => Waterlogged switch {
                                true => 29178,
                                false => 29179,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29180,
                                false => 29181,
                            },
                            false => Waterlogged switch {
                                true => 29182,
                                false => 29183,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29184,
                                false => 29185,
                            },
                            false => Waterlogged switch {
                                true => 29186,
                                false => 29187,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29188,
                                false => 29189,
                            },
                            false => Waterlogged switch {
                                true => 29190,
                                false => 29191,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29192,
                                false => 29193,
                            },
                            false => Waterlogged switch {
                                true => 29194,
                                false => 29195,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29196,
                                false => 29197,
                            },
                            false => Waterlogged switch {
                                true => 29198,
                                false => 29199,
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
            29136 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            29137 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            29138 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            29139 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            29140 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            29141 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            29142 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            29143 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            29144 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            29145 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            29146 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            29147 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            29148 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            29149 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            29150 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            29151 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            29152 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            29153 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            29154 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            29155 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            29156 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            29157 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            29158 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            29159 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            29160 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            29161 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            29162 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            29163 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            29164 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            29165 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            29166 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            29167 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            29168 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            29169 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            29170 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            29171 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            29172 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            29173 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            29174 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            29175 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            29176 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            29177 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            29178 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            29179 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            29180 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            29181 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            29182 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            29183 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            29184 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            29185 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            29186 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            29187 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            29188 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            29189 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            29190 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            29191 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            29192 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            29193 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            29194 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            29195 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            29196 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            29197 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            29198 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            29199 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
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
