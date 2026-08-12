using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WeatheredCopperTrapdoorBlock(Identifier Identifier, Direction Facing, WeatheredCopperTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:weathering_copper_trapdoor", "block.minecraft.weathered_copper_trapdoor", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:weathered_copper_trapdoor", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Normal, 56, "copper", NoteBlockInstrument.Harp, false, false, true, true, false, false, false, false, true, false, false, true, false, false, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S112, CollisionShape = BlockShapes.S112, VisualShape = BlockShapes.S112 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S112, CollisionShape = BlockShapes.S112, VisualShape = BlockShapes.S112 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S113, CollisionShape = BlockShapes.S113, VisualShape = BlockShapes.S113 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S113, CollisionShape = BlockShapes.S113, VisualShape = BlockShapes.S113 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S20, CollisionShape = BlockShapes.S20, VisualShape = BlockShapes.S20 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S20, CollisionShape = BlockShapes.S20, VisualShape = BlockShapes.S20 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S19, CollisionShape = BlockShapes.S19, VisualShape = BlockShapes.S19 };
    private static readonly BlockStateInfo I9 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S19, CollisionShape = BlockShapes.S19, VisualShape = BlockShapes.S19 };
    private static readonly BlockStateInfo I10 = I0 with { BlockShape = BlockShapes.S17, CollisionShape = BlockShapes.S17, VisualShape = BlockShapes.S17 };
    private static readonly BlockStateInfo I11 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S17, CollisionShape = BlockShapes.S17, VisualShape = BlockShapes.S17 };
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
    public NoteBlockInstrument Instrument => StateInfo.Instrument;
    public Identifier? Fluid => StateInfo.Fluid;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
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
                    Half.Bottom => Open switch {
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
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
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
                    Half.Bottom => Open switch {
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
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
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
                    Half.Bottom => Open switch {
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
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
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
                    Half.Bottom => Open switch {
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
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            29136 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            29137 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            29138 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            29139 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            29140 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            29141 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            29142 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            29143 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            29144 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            29145 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            29146 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            29147 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            29148 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            29149 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            29150 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            29151 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            29152 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            29153 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            29154 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            29155 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            29156 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            29157 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            29158 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            29159 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            29160 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            29161 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            29162 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            29163 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            29164 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            29165 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            29166 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            29167 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            29168 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            29169 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            29170 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            29171 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            29172 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            29173 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            29174 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            29175 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            29176 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            29177 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            29178 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            29179 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            29180 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            29181 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            29182 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            29183 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            29184 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            29185 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            29186 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            29187 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            29188 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            29189 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            29190 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            29191 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            29192 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            29193 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            29194 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            29195 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            29196 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            29197 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            29198 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            29199 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            HalfValue = properties.Contains("half") ? HalfFromString(properties["half"].GetString()) : HalfValue,
            Open = properties.Contains("open") ? properties["open"].GetString() == "true" : Open,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("half", new StringTag(HalfToName(HalfValue))),
            ("open", new StringTag(Open.ToString().ToLower())),
            ("powered", new StringTag(Powered.ToString().ToLower())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
    public enum Half {
        Top,
        Bottom,
    }

    public static Half HalfFromString(string value) {
        return value switch {
            "top" => Half.Top,
            "bottom" => Half.Bottom,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Half.")
        };
    }

    public static string HalfToName(Half value) {
        return value switch {
            Half.Top => "top",
            Half.Bottom => "bottom",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Half value.")
        };
    }
}
