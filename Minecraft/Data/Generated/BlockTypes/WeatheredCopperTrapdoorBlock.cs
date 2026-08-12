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
    public Identifier Category => "minecraft:weathering_copper_trapdoor";
    public double Hardness => 3;
    public double ExplosionResistance => 6;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => true;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "copper";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:weathered_copper_trapdoor";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 56;
    public string TranslationKey => "block.minecraft.weathered_copper_trapdoor";
    public bool CanRespawnIn => false;


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
