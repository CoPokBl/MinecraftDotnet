using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WeatheredCopperDoorBlock(Identifier Identifier, Direction Facing, BlockHalf Half, LeftRight Hinge, bool Open, bool Powered) : IBlock {
    public Identifier Category => "minecraft:weathering_copper_door";
    public double Hardness => 3;
    public double ExplosionResistance => 6;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "copper";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:weathered_copper_door";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 56;
    public string TranslationKey => "block.minecraft.weathered_copper_door";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 28624,
                                false => 28625,
                            },
                            false => Powered switch {
                                true => 28626,
                                false => 28627,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28628,
                                false => 28629,
                            },
                            false => Powered switch {
                                true => 28630,
                                false => 28631,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 28632,
                                false => 28633,
                            },
                            false => Powered switch {
                                true => 28634,
                                false => 28635,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28636,
                                false => 28637,
                            },
                            false => Powered switch {
                                true => 28638,
                                false => 28639,
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
                                true => 28640,
                                false => 28641,
                            },
                            false => Powered switch {
                                true => 28642,
                                false => 28643,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28644,
                                false => 28645,
                            },
                            false => Powered switch {
                                true => 28646,
                                false => 28647,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 28648,
                                false => 28649,
                            },
                            false => Powered switch {
                                true => 28650,
                                false => 28651,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28652,
                                false => 28653,
                            },
                            false => Powered switch {
                                true => 28654,
                                false => 28655,
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
                                true => 28656,
                                false => 28657,
                            },
                            false => Powered switch {
                                true => 28658,
                                false => 28659,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28660,
                                false => 28661,
                            },
                            false => Powered switch {
                                true => 28662,
                                false => 28663,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 28664,
                                false => 28665,
                            },
                            false => Powered switch {
                                true => 28666,
                                false => 28667,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28668,
                                false => 28669,
                            },
                            false => Powered switch {
                                true => 28670,
                                false => 28671,
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
                                true => 28672,
                                false => 28673,
                            },
                            false => Powered switch {
                                true => 28674,
                                false => 28675,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28676,
                                false => 28677,
                            },
                            false => Powered switch {
                                true => 28678,
                                false => 28679,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 28680,
                                false => 28681,
                            },
                            false => Powered switch {
                                true => 28682,
                                false => 28683,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28684,
                                false => 28685,
                            },
                            false => Powered switch {
                                true => 28686,
                                false => 28687,
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
            28624 => new WeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            28625 => new WeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            28626 => new WeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            28627 => new WeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            28628 => new WeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            28629 => new WeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            28630 => new WeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            28631 => new WeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            28632 => new WeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            28633 => new WeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            28634 => new WeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            28635 => new WeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            28636 => new WeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            28637 => new WeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            28638 => new WeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            28639 => new WeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            28640 => new WeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            28641 => new WeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            28642 => new WeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            28643 => new WeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            28644 => new WeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            28645 => new WeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            28646 => new WeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            28647 => new WeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            28648 => new WeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            28649 => new WeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            28650 => new WeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            28651 => new WeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            28652 => new WeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            28653 => new WeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            28654 => new WeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            28655 => new WeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            28656 => new WeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            28657 => new WeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            28658 => new WeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            28659 => new WeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            28660 => new WeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            28661 => new WeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            28662 => new WeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            28663 => new WeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            28664 => new WeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            28665 => new WeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            28666 => new WeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            28667 => new WeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            28668 => new WeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            28669 => new WeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            28670 => new WeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            28671 => new WeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            28672 => new WeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            28673 => new WeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            28674 => new WeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            28675 => new WeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            28676 => new WeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            28677 => new WeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            28678 => new WeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            28679 => new WeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            28680 => new WeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            28681 => new WeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            28682 => new WeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            28683 => new WeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            28684 => new WeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            28685 => new WeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            28686 => new WeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            28687 => new WeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
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
