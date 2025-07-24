using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedOxidizedCopperTrapdoorBlock(Identifier Identifier, Direction Facing, WaxedOxidizedCopperTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:trapdoor";
    public int ProtocolId => 1023;
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
    public Identifier? Item => "minecraft:waxed_oxidized_copper_trapdoor";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 55;
    public string TranslationKey => "block.minecraft.waxed_oxidized_copper_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25608,
                                false => 25609,
                            },
                            false => Waterlogged switch {
                                true => 25610,
                                false => 25611,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25612,
                                false => 25613,
                            },
                            false => Waterlogged switch {
                                true => 25614,
                                false => 25615,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25616,
                                false => 25617,
                            },
                            false => Waterlogged switch {
                                true => 25618,
                                false => 25619,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25620,
                                false => 25621,
                            },
                            false => Waterlogged switch {
                                true => 25622,
                                false => 25623,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25624,
                                false => 25625,
                            },
                            false => Waterlogged switch {
                                true => 25626,
                                false => 25627,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25628,
                                false => 25629,
                            },
                            false => Waterlogged switch {
                                true => 25630,
                                false => 25631,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25632,
                                false => 25633,
                            },
                            false => Waterlogged switch {
                                true => 25634,
                                false => 25635,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25636,
                                false => 25637,
                            },
                            false => Waterlogged switch {
                                true => 25638,
                                false => 25639,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25640,
                                false => 25641,
                            },
                            false => Waterlogged switch {
                                true => 25642,
                                false => 25643,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25644,
                                false => 25645,
                            },
                            false => Waterlogged switch {
                                true => 25646,
                                false => 25647,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25648,
                                false => 25649,
                            },
                            false => Waterlogged switch {
                                true => 25650,
                                false => 25651,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25652,
                                false => 25653,
                            },
                            false => Waterlogged switch {
                                true => 25654,
                                false => 25655,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25656,
                                false => 25657,
                            },
                            false => Waterlogged switch {
                                true => 25658,
                                false => 25659,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25660,
                                false => 25661,
                            },
                            false => Waterlogged switch {
                                true => 25662,
                                false => 25663,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25664,
                                false => 25665,
                            },
                            false => Waterlogged switch {
                                true => 25666,
                                false => 25667,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25668,
                                false => 25669,
                            },
                            false => Waterlogged switch {
                                true => 25670,
                                false => 25671,
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
            25608 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            25609 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            25610 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            25611 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            25612 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            25613 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            25614 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            25615 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            25616 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            25617 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            25618 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            25619 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            25620 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            25621 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            25622 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            25623 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            25624 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            25625 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            25626 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            25627 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            25628 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            25629 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            25630 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            25631 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            25632 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            25633 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            25634 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            25635 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            25636 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            25637 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            25638 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            25639 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            25640 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            25641 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            25642 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            25643 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            25644 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            25645 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            25646 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            25647 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            25648 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            25649 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            25650 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            25651 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            25652 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            25653 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            25654 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            25655 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            25656 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            25657 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            25658 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            25659 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            25660 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            25661 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            25662 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            25663 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            25664 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            25665 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            25666 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            25667 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            25668 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            25669 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            25670 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            25671 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            HalfValue = HalfFromString(properties["half"].GetString()),
            Open = properties["open"].GetString() == "true",
            Powered = properties["powered"].GetString() == "true",
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
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
}
