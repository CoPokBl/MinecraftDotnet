using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record RepeaterBlock(Identifier Identifier, int Delay, Direction Facing, bool Locked, bool Powered) : IBlock {
    public Identifier Category => "minecraft:repeater";
    public int ProtocolId => 298;
    public double Hardness => 0;
    public double ExplosionResistance => 0;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "stone";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:repeater";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.125, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.125, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.125, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.125, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => true;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 0;
    public string TranslationKey => "block.minecraft.repeater";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Delay switch {
                1 => Facing switch {
                    Direction.North => Locked switch {
                        true => Powered switch {
                            true => 6833,
                            false => 6834,
                        },
                        false => Powered switch {
                            true => 6835,
                            false => 6836,
                        },
                    },
                    Direction.South => Locked switch {
                        true => Powered switch {
                            true => 6837,
                            false => 6838,
                        },
                        false => Powered switch {
                            true => 6839,
                            false => 6840,
                        },
                    },
                    Direction.West => Locked switch {
                        true => Powered switch {
                            true => 6841,
                            false => 6842,
                        },
                        false => Powered switch {
                            true => 6843,
                            false => 6844,
                        },
                    },
                    Direction.East => Locked switch {
                        true => Powered switch {
                            true => 6845,
                            false => 6846,
                        },
                        false => Powered switch {
                            true => 6847,
                            false => 6848,
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                2 => Facing switch {
                    Direction.North => Locked switch {
                        true => Powered switch {
                            true => 6849,
                            false => 6850,
                        },
                        false => Powered switch {
                            true => 6851,
                            false => 6852,
                        },
                    },
                    Direction.South => Locked switch {
                        true => Powered switch {
                            true => 6853,
                            false => 6854,
                        },
                        false => Powered switch {
                            true => 6855,
                            false => 6856,
                        },
                    },
                    Direction.West => Locked switch {
                        true => Powered switch {
                            true => 6857,
                            false => 6858,
                        },
                        false => Powered switch {
                            true => 6859,
                            false => 6860,
                        },
                    },
                    Direction.East => Locked switch {
                        true => Powered switch {
                            true => 6861,
                            false => 6862,
                        },
                        false => Powered switch {
                            true => 6863,
                            false => 6864,
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                3 => Facing switch {
                    Direction.North => Locked switch {
                        true => Powered switch {
                            true => 6865,
                            false => 6866,
                        },
                        false => Powered switch {
                            true => 6867,
                            false => 6868,
                        },
                    },
                    Direction.South => Locked switch {
                        true => Powered switch {
                            true => 6869,
                            false => 6870,
                        },
                        false => Powered switch {
                            true => 6871,
                            false => 6872,
                        },
                    },
                    Direction.West => Locked switch {
                        true => Powered switch {
                            true => 6873,
                            false => 6874,
                        },
                        false => Powered switch {
                            true => 6875,
                            false => 6876,
                        },
                    },
                    Direction.East => Locked switch {
                        true => Powered switch {
                            true => 6877,
                            false => 6878,
                        },
                        false => Powered switch {
                            true => 6879,
                            false => 6880,
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                4 => Facing switch {
                    Direction.North => Locked switch {
                        true => Powered switch {
                            true => 6881,
                            false => 6882,
                        },
                        false => Powered switch {
                            true => 6883,
                            false => 6884,
                        },
                    },
                    Direction.South => Locked switch {
                        true => Powered switch {
                            true => 6885,
                            false => 6886,
                        },
                        false => Powered switch {
                            true => 6887,
                            false => 6888,
                        },
                    },
                    Direction.West => Locked switch {
                        true => Powered switch {
                            true => 6889,
                            false => 6890,
                        },
                        false => Powered switch {
                            true => 6891,
                            false => 6892,
                        },
                    },
                    Direction.East => Locked switch {
                        true => Powered switch {
                            true => 6893,
                            false => 6894,
                        },
                        false => Powered switch {
                            true => 6895,
                            false => 6896,
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Delay), Delay, "Unknown value for property delay.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6833 => new RepeaterBlock(Identifier, 1, Direction.North, true, true),
            6834 => new RepeaterBlock(Identifier, 1, Direction.North, true, false),
            6835 => new RepeaterBlock(Identifier, 1, Direction.North, false, true),
            6836 => new RepeaterBlock(Identifier, 1, Direction.North, false, false),
            6837 => new RepeaterBlock(Identifier, 1, Direction.South, true, true),
            6838 => new RepeaterBlock(Identifier, 1, Direction.South, true, false),
            6839 => new RepeaterBlock(Identifier, 1, Direction.South, false, true),
            6840 => new RepeaterBlock(Identifier, 1, Direction.South, false, false),
            6841 => new RepeaterBlock(Identifier, 1, Direction.West, true, true),
            6842 => new RepeaterBlock(Identifier, 1, Direction.West, true, false),
            6843 => new RepeaterBlock(Identifier, 1, Direction.West, false, true),
            6844 => new RepeaterBlock(Identifier, 1, Direction.West, false, false),
            6845 => new RepeaterBlock(Identifier, 1, Direction.East, true, true),
            6846 => new RepeaterBlock(Identifier, 1, Direction.East, true, false),
            6847 => new RepeaterBlock(Identifier, 1, Direction.East, false, true),
            6848 => new RepeaterBlock(Identifier, 1, Direction.East, false, false),
            6849 => new RepeaterBlock(Identifier, 2, Direction.North, true, true),
            6850 => new RepeaterBlock(Identifier, 2, Direction.North, true, false),
            6851 => new RepeaterBlock(Identifier, 2, Direction.North, false, true),
            6852 => new RepeaterBlock(Identifier, 2, Direction.North, false, false),
            6853 => new RepeaterBlock(Identifier, 2, Direction.South, true, true),
            6854 => new RepeaterBlock(Identifier, 2, Direction.South, true, false),
            6855 => new RepeaterBlock(Identifier, 2, Direction.South, false, true),
            6856 => new RepeaterBlock(Identifier, 2, Direction.South, false, false),
            6857 => new RepeaterBlock(Identifier, 2, Direction.West, true, true),
            6858 => new RepeaterBlock(Identifier, 2, Direction.West, true, false),
            6859 => new RepeaterBlock(Identifier, 2, Direction.West, false, true),
            6860 => new RepeaterBlock(Identifier, 2, Direction.West, false, false),
            6861 => new RepeaterBlock(Identifier, 2, Direction.East, true, true),
            6862 => new RepeaterBlock(Identifier, 2, Direction.East, true, false),
            6863 => new RepeaterBlock(Identifier, 2, Direction.East, false, true),
            6864 => new RepeaterBlock(Identifier, 2, Direction.East, false, false),
            6865 => new RepeaterBlock(Identifier, 3, Direction.North, true, true),
            6866 => new RepeaterBlock(Identifier, 3, Direction.North, true, false),
            6867 => new RepeaterBlock(Identifier, 3, Direction.North, false, true),
            6868 => new RepeaterBlock(Identifier, 3, Direction.North, false, false),
            6869 => new RepeaterBlock(Identifier, 3, Direction.South, true, true),
            6870 => new RepeaterBlock(Identifier, 3, Direction.South, true, false),
            6871 => new RepeaterBlock(Identifier, 3, Direction.South, false, true),
            6872 => new RepeaterBlock(Identifier, 3, Direction.South, false, false),
            6873 => new RepeaterBlock(Identifier, 3, Direction.West, true, true),
            6874 => new RepeaterBlock(Identifier, 3, Direction.West, true, false),
            6875 => new RepeaterBlock(Identifier, 3, Direction.West, false, true),
            6876 => new RepeaterBlock(Identifier, 3, Direction.West, false, false),
            6877 => new RepeaterBlock(Identifier, 3, Direction.East, true, true),
            6878 => new RepeaterBlock(Identifier, 3, Direction.East, true, false),
            6879 => new RepeaterBlock(Identifier, 3, Direction.East, false, true),
            6880 => new RepeaterBlock(Identifier, 3, Direction.East, false, false),
            6881 => new RepeaterBlock(Identifier, 4, Direction.North, true, true),
            6882 => new RepeaterBlock(Identifier, 4, Direction.North, true, false),
            6883 => new RepeaterBlock(Identifier, 4, Direction.North, false, true),
            6884 => new RepeaterBlock(Identifier, 4, Direction.North, false, false),
            6885 => new RepeaterBlock(Identifier, 4, Direction.South, true, true),
            6886 => new RepeaterBlock(Identifier, 4, Direction.South, true, false),
            6887 => new RepeaterBlock(Identifier, 4, Direction.South, false, true),
            6888 => new RepeaterBlock(Identifier, 4, Direction.South, false, false),
            6889 => new RepeaterBlock(Identifier, 4, Direction.West, true, true),
            6890 => new RepeaterBlock(Identifier, 4, Direction.West, true, false),
            6891 => new RepeaterBlock(Identifier, 4, Direction.West, false, true),
            6892 => new RepeaterBlock(Identifier, 4, Direction.West, false, false),
            6893 => new RepeaterBlock(Identifier, 4, Direction.East, true, true),
            6894 => new RepeaterBlock(Identifier, 4, Direction.East, true, false),
            6895 => new RepeaterBlock(Identifier, 4, Direction.East, false, true),
            6896 => new RepeaterBlock(Identifier, 4, Direction.East, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Delay = properties.ChildrenMap.ContainsKey("delay") ? int.Parse(properties["delay"].GetString()) : Delay,
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Locked = properties.ChildrenMap.ContainsKey("locked") ? properties["locked"].GetString() == "true" : Locked,
            Powered = properties.ChildrenMap.ContainsKey("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("delay", Delay.ToString()),
            new StringTag("facing", Facing.ToName()),
            new StringTag("locked", Locked.ToString().ToLower()),
            new StringTag("powered", Powered.ToString().ToLower())
        );
    }
    
}
