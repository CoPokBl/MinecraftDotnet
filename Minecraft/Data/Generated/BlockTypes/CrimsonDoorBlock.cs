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
                                true => 20171,
                                false => 20172,
                            },
                            false => Powered switch {
                                true => 20173,
                                false => 20174,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 20175,
                                false => 20176,
                            },
                            false => Powered switch {
                                true => 20177,
                                false => 20178,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 20179,
                                false => 20180,
                            },
                            false => Powered switch {
                                true => 20181,
                                false => 20182,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 20183,
                                false => 20184,
                            },
                            false => Powered switch {
                                true => 20185,
                                false => 20186,
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
                                true => 20187,
                                false => 20188,
                            },
                            false => Powered switch {
                                true => 20189,
                                false => 20190,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 20191,
                                false => 20192,
                            },
                            false => Powered switch {
                                true => 20193,
                                false => 20194,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 20195,
                                false => 20196,
                            },
                            false => Powered switch {
                                true => 20197,
                                false => 20198,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 20199,
                                false => 20200,
                            },
                            false => Powered switch {
                                true => 20201,
                                false => 20202,
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
                Direction.East => Half switch {
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
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20171 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            20172 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            20173 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            20174 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            20175 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            20176 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            20177 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            20178 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            20179 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            20180 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            20181 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            20182 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            20183 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            20184 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            20185 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            20186 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            20187 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            20188 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            20189 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            20190 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            20191 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            20192 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            20193 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            20194 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            20195 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            20196 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            20197 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            20198 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            20199 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            20200 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            20201 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            20202 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            20203 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            20204 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            20205 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            20206 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            20207 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            20208 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            20209 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            20210 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            20211 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            20212 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            20213 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            20214 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            20215 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            20216 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            20217 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            20218 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            20219 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            20220 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            20221 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            20222 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            20223 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            20224 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            20225 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            20226 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            20227 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            20228 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            20229 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            20230 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            20231 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            20232 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            20233 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            20234 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
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
