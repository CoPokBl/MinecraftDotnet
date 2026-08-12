using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record AcaciaDoorBlock(Identifier Identifier, Direction Facing, BlockHalf Half, LeftRight Hinge, bool Open, bool Powered) : IBlock {
    public Identifier Category => "minecraft:door";
    public double Hardness => 3;
    public double ExplosionResistance => 3;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:acacia_door";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 15;
    public string TranslationKey => "block.minecraft.acacia_door";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 14252,
                                false => 14253,
                            },
                            false => Powered switch {
                                true => 14254,
                                false => 14255,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14256,
                                false => 14257,
                            },
                            false => Powered switch {
                                true => 14258,
                                false => 14259,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 14260,
                                false => 14261,
                            },
                            false => Powered switch {
                                true => 14262,
                                false => 14263,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14264,
                                false => 14265,
                            },
                            false => Powered switch {
                                true => 14266,
                                false => 14267,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 14268,
                                false => 14269,
                            },
                            false => Powered switch {
                                true => 14270,
                                false => 14271,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14272,
                                false => 14273,
                            },
                            false => Powered switch {
                                true => 14274,
                                false => 14275,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 14276,
                                false => 14277,
                            },
                            false => Powered switch {
                                true => 14278,
                                false => 14279,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14280,
                                false => 14281,
                            },
                            false => Powered switch {
                                true => 14282,
                                false => 14283,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 14284,
                                false => 14285,
                            },
                            false => Powered switch {
                                true => 14286,
                                false => 14287,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14288,
                                false => 14289,
                            },
                            false => Powered switch {
                                true => 14290,
                                false => 14291,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 14292,
                                false => 14293,
                            },
                            false => Powered switch {
                                true => 14294,
                                false => 14295,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14296,
                                false => 14297,
                            },
                            false => Powered switch {
                                true => 14298,
                                false => 14299,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 14300,
                                false => 14301,
                            },
                            false => Powered switch {
                                true => 14302,
                                false => 14303,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14304,
                                false => 14305,
                            },
                            false => Powered switch {
                                true => 14306,
                                false => 14307,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 14308,
                                false => 14309,
                            },
                            false => Powered switch {
                                true => 14310,
                                false => 14311,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14312,
                                false => 14313,
                            },
                            false => Powered switch {
                                true => 14314,
                                false => 14315,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            14252 => new AcaciaDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            14253 => new AcaciaDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            14254 => new AcaciaDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            14255 => new AcaciaDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            14256 => new AcaciaDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            14257 => new AcaciaDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            14258 => new AcaciaDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            14259 => new AcaciaDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            14260 => new AcaciaDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            14261 => new AcaciaDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            14262 => new AcaciaDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            14263 => new AcaciaDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            14264 => new AcaciaDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            14265 => new AcaciaDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            14266 => new AcaciaDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            14267 => new AcaciaDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            14268 => new AcaciaDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            14269 => new AcaciaDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            14270 => new AcaciaDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            14271 => new AcaciaDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            14272 => new AcaciaDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            14273 => new AcaciaDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            14274 => new AcaciaDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            14275 => new AcaciaDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            14276 => new AcaciaDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            14277 => new AcaciaDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            14278 => new AcaciaDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            14279 => new AcaciaDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            14280 => new AcaciaDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            14281 => new AcaciaDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            14282 => new AcaciaDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            14283 => new AcaciaDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            14284 => new AcaciaDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            14285 => new AcaciaDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            14286 => new AcaciaDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            14287 => new AcaciaDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            14288 => new AcaciaDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            14289 => new AcaciaDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            14290 => new AcaciaDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            14291 => new AcaciaDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            14292 => new AcaciaDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            14293 => new AcaciaDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            14294 => new AcaciaDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            14295 => new AcaciaDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            14296 => new AcaciaDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            14297 => new AcaciaDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            14298 => new AcaciaDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            14299 => new AcaciaDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            14300 => new AcaciaDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            14301 => new AcaciaDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            14302 => new AcaciaDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            14303 => new AcaciaDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            14304 => new AcaciaDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            14305 => new AcaciaDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            14306 => new AcaciaDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            14307 => new AcaciaDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            14308 => new AcaciaDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            14309 => new AcaciaDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            14310 => new AcaciaDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            14311 => new AcaciaDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            14312 => new AcaciaDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            14313 => new AcaciaDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            14314 => new AcaciaDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            14315 => new AcaciaDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Half = properties.Contains("half") ? BlockHalfExtensions.FromString(properties["half"].GetString()) : Half,
            Hinge = properties.Contains("hinge") ? LeftRightExtensions.FromString(properties["hinge"].GetString()) : Hinge,
            Open = properties.Contains("open") ? properties["open"].GetString() == "true" : Open,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("half", new StringTag(Half.ToName())),
            ("hinge", new StringTag(Hinge.ToName())),
            ("open", new StringTag(Open.ToString().ToLower())),
            ("powered", new StringTag(Powered.ToString().ToLower()))
        );
    }
    
}
