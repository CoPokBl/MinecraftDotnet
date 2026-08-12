using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CherryDoorBlock(Identifier Identifier, Direction Facing, BlockHalf Half, LeftRight Hinge, bool Open, bool Powered) : IBlock {
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
    public string SoundType => "cherry_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:cherry_door";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 36;
    public string TranslationKey => "block.minecraft.cherry_door";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 14316,
                                false => 14317,
                            },
                            false => Powered switch {
                                true => 14318,
                                false => 14319,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14320,
                                false => 14321,
                            },
                            false => Powered switch {
                                true => 14322,
                                false => 14323,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 14324,
                                false => 14325,
                            },
                            false => Powered switch {
                                true => 14326,
                                false => 14327,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14328,
                                false => 14329,
                            },
                            false => Powered switch {
                                true => 14330,
                                false => 14331,
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
                                true => 14332,
                                false => 14333,
                            },
                            false => Powered switch {
                                true => 14334,
                                false => 14335,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14336,
                                false => 14337,
                            },
                            false => Powered switch {
                                true => 14338,
                                false => 14339,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 14340,
                                false => 14341,
                            },
                            false => Powered switch {
                                true => 14342,
                                false => 14343,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14344,
                                false => 14345,
                            },
                            false => Powered switch {
                                true => 14346,
                                false => 14347,
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
                                true => 14348,
                                false => 14349,
                            },
                            false => Powered switch {
                                true => 14350,
                                false => 14351,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14352,
                                false => 14353,
                            },
                            false => Powered switch {
                                true => 14354,
                                false => 14355,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 14356,
                                false => 14357,
                            },
                            false => Powered switch {
                                true => 14358,
                                false => 14359,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14360,
                                false => 14361,
                            },
                            false => Powered switch {
                                true => 14362,
                                false => 14363,
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
                                true => 14364,
                                false => 14365,
                            },
                            false => Powered switch {
                                true => 14366,
                                false => 14367,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14368,
                                false => 14369,
                            },
                            false => Powered switch {
                                true => 14370,
                                false => 14371,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 14372,
                                false => 14373,
                            },
                            false => Powered switch {
                                true => 14374,
                                false => 14375,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14376,
                                false => 14377,
                            },
                            false => Powered switch {
                                true => 14378,
                                false => 14379,
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
            14316 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            14317 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            14318 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            14319 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            14320 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            14321 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            14322 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            14323 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            14324 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            14325 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            14326 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            14327 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            14328 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            14329 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            14330 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            14331 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            14332 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            14333 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            14334 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            14335 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            14336 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            14337 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            14338 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            14339 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            14340 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            14341 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            14342 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            14343 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            14344 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            14345 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            14346 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            14347 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            14348 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            14349 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            14350 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            14351 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            14352 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            14353 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            14354 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            14355 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            14356 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            14357 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            14358 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            14359 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            14360 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            14361 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            14362 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            14363 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            14364 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            14365 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            14366 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            14367 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            14368 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            14369 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            14370 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            14371 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            14372 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            14373 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            14374 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            14375 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            14376 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            14377 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            14378 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            14379 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
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
