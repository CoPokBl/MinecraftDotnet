using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CrimsonDoorBlock(Identifier Identifier, Direction Facing, BlockHalf Half, LeftRight Hinge, bool Open, bool Powered) : IBlock {

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
    public string SoundType => "nether_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:crimson_door";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 53;
    public string TranslationKey => "block.minecraft.crimson_door";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 20203,
                                false => 20204,
                            },
                            false => Powered switch {
                                true => 20205,
                                false => 20206,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 20207,
                                false => 20208,
                            },
                            false => Powered switch {
                                true => 20209,
                                false => 20210,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 20211,
                                false => 20212,
                            },
                            false => Powered switch {
                                true => 20213,
                                false => 20214,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 20215,
                                false => 20216,
                            },
                            false => Powered switch {
                                true => 20217,
                                false => 20218,
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
                                true => 20219,
                                false => 20220,
                            },
                            false => Powered switch {
                                true => 20221,
                                false => 20222,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 20223,
                                false => 20224,
                            },
                            false => Powered switch {
                                true => 20225,
                                false => 20226,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 20227,
                                false => 20228,
                            },
                            false => Powered switch {
                                true => 20229,
                                false => 20230,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 20231,
                                false => 20232,
                            },
                            false => Powered switch {
                                true => 20233,
                                false => 20234,
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
                                true => 20235,
                                false => 20236,
                            },
                            false => Powered switch {
                                true => 20237,
                                false => 20238,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 20239,
                                false => 20240,
                            },
                            false => Powered switch {
                                true => 20241,
                                false => 20242,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 20243,
                                false => 20244,
                            },
                            false => Powered switch {
                                true => 20245,
                                false => 20246,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 20247,
                                false => 20248,
                            },
                            false => Powered switch {
                                true => 20249,
                                false => 20250,
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
                                true => 20251,
                                false => 20252,
                            },
                            false => Powered switch {
                                true => 20253,
                                false => 20254,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 20255,
                                false => 20256,
                            },
                            false => Powered switch {
                                true => 20257,
                                false => 20258,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 20259,
                                false => 20260,
                            },
                            false => Powered switch {
                                true => 20261,
                                false => 20262,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 20263,
                                false => 20264,
                            },
                            false => Powered switch {
                                true => 20265,
                                false => 20266,
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
            20203 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            20204 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            20205 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            20206 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            20207 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            20208 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            20209 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            20210 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            20211 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            20212 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            20213 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            20214 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            20215 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            20216 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            20217 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            20218 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            20219 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            20220 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            20221 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            20222 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            20223 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            20224 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            20225 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            20226 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            20227 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            20228 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            20229 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            20230 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            20231 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            20232 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            20233 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            20234 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            20235 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            20236 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            20237 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            20238 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            20239 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            20240 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            20241 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            20242 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            20243 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            20244 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            20245 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            20246 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            20247 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            20248 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            20249 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            20250 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            20251 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            20252 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            20253 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            20254 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            20255 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            20256 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            20257 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            20258 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            20259 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            20260 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            20261 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            20262 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            20263 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            20264 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            20265 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            20266 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            Half = BlockHalfExtensions.FromString(properties["half"].GetString()),
            Hinge = LeftRightExtensions.FromString(properties["hinge"].GetString()),
            Open = properties["open"].GetString() == "true",
            Powered = properties["powered"].GetString() == "true",
        };
    }
    
}
