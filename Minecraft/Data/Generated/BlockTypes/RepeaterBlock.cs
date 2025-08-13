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
    public int ProtocolId => 284;
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
                            true => 6060,
                            false => 6061,
                        },
                        false => Powered switch {
                            true => 6062,
                            false => 6063,
                        },
                    },
                    Direction.South => Locked switch {
                        true => Powered switch {
                            true => 6064,
                            false => 6065,
                        },
                        false => Powered switch {
                            true => 6066,
                            false => 6067,
                        },
                    },
                    Direction.West => Locked switch {
                        true => Powered switch {
                            true => 6068,
                            false => 6069,
                        },
                        false => Powered switch {
                            true => 6070,
                            false => 6071,
                        },
                    },
                    Direction.East => Locked switch {
                        true => Powered switch {
                            true => 6072,
                            false => 6073,
                        },
                        false => Powered switch {
                            true => 6074,
                            false => 6075,
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                2 => Facing switch {
                    Direction.North => Locked switch {
                        true => Powered switch {
                            true => 6076,
                            false => 6077,
                        },
                        false => Powered switch {
                            true => 6078,
                            false => 6079,
                        },
                    },
                    Direction.South => Locked switch {
                        true => Powered switch {
                            true => 6080,
                            false => 6081,
                        },
                        false => Powered switch {
                            true => 6082,
                            false => 6083,
                        },
                    },
                    Direction.West => Locked switch {
                        true => Powered switch {
                            true => 6084,
                            false => 6085,
                        },
                        false => Powered switch {
                            true => 6086,
                            false => 6087,
                        },
                    },
                    Direction.East => Locked switch {
                        true => Powered switch {
                            true => 6088,
                            false => 6089,
                        },
                        false => Powered switch {
                            true => 6090,
                            false => 6091,
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                3 => Facing switch {
                    Direction.North => Locked switch {
                        true => Powered switch {
                            true => 6092,
                            false => 6093,
                        },
                        false => Powered switch {
                            true => 6094,
                            false => 6095,
                        },
                    },
                    Direction.South => Locked switch {
                        true => Powered switch {
                            true => 6096,
                            false => 6097,
                        },
                        false => Powered switch {
                            true => 6098,
                            false => 6099,
                        },
                    },
                    Direction.West => Locked switch {
                        true => Powered switch {
                            true => 6100,
                            false => 6101,
                        },
                        false => Powered switch {
                            true => 6102,
                            false => 6103,
                        },
                    },
                    Direction.East => Locked switch {
                        true => Powered switch {
                            true => 6104,
                            false => 6105,
                        },
                        false => Powered switch {
                            true => 6106,
                            false => 6107,
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                4 => Facing switch {
                    Direction.North => Locked switch {
                        true => Powered switch {
                            true => 6108,
                            false => 6109,
                        },
                        false => Powered switch {
                            true => 6110,
                            false => 6111,
                        },
                    },
                    Direction.South => Locked switch {
                        true => Powered switch {
                            true => 6112,
                            false => 6113,
                        },
                        false => Powered switch {
                            true => 6114,
                            false => 6115,
                        },
                    },
                    Direction.West => Locked switch {
                        true => Powered switch {
                            true => 6116,
                            false => 6117,
                        },
                        false => Powered switch {
                            true => 6118,
                            false => 6119,
                        },
                    },
                    Direction.East => Locked switch {
                        true => Powered switch {
                            true => 6120,
                            false => 6121,
                        },
                        false => Powered switch {
                            true => 6122,
                            false => 6123,
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
            6060 => new RepeaterBlock(Identifier, 1, Direction.North, true, true),
            6061 => new RepeaterBlock(Identifier, 1, Direction.North, true, false),
            6062 => new RepeaterBlock(Identifier, 1, Direction.North, false, true),
            6063 => new RepeaterBlock(Identifier, 1, Direction.North, false, false),
            6064 => new RepeaterBlock(Identifier, 1, Direction.South, true, true),
            6065 => new RepeaterBlock(Identifier, 1, Direction.South, true, false),
            6066 => new RepeaterBlock(Identifier, 1, Direction.South, false, true),
            6067 => new RepeaterBlock(Identifier, 1, Direction.South, false, false),
            6068 => new RepeaterBlock(Identifier, 1, Direction.West, true, true),
            6069 => new RepeaterBlock(Identifier, 1, Direction.West, true, false),
            6070 => new RepeaterBlock(Identifier, 1, Direction.West, false, true),
            6071 => new RepeaterBlock(Identifier, 1, Direction.West, false, false),
            6072 => new RepeaterBlock(Identifier, 1, Direction.East, true, true),
            6073 => new RepeaterBlock(Identifier, 1, Direction.East, true, false),
            6074 => new RepeaterBlock(Identifier, 1, Direction.East, false, true),
            6075 => new RepeaterBlock(Identifier, 1, Direction.East, false, false),
            6076 => new RepeaterBlock(Identifier, 2, Direction.North, true, true),
            6077 => new RepeaterBlock(Identifier, 2, Direction.North, true, false),
            6078 => new RepeaterBlock(Identifier, 2, Direction.North, false, true),
            6079 => new RepeaterBlock(Identifier, 2, Direction.North, false, false),
            6080 => new RepeaterBlock(Identifier, 2, Direction.South, true, true),
            6081 => new RepeaterBlock(Identifier, 2, Direction.South, true, false),
            6082 => new RepeaterBlock(Identifier, 2, Direction.South, false, true),
            6083 => new RepeaterBlock(Identifier, 2, Direction.South, false, false),
            6084 => new RepeaterBlock(Identifier, 2, Direction.West, true, true),
            6085 => new RepeaterBlock(Identifier, 2, Direction.West, true, false),
            6086 => new RepeaterBlock(Identifier, 2, Direction.West, false, true),
            6087 => new RepeaterBlock(Identifier, 2, Direction.West, false, false),
            6088 => new RepeaterBlock(Identifier, 2, Direction.East, true, true),
            6089 => new RepeaterBlock(Identifier, 2, Direction.East, true, false),
            6090 => new RepeaterBlock(Identifier, 2, Direction.East, false, true),
            6091 => new RepeaterBlock(Identifier, 2, Direction.East, false, false),
            6092 => new RepeaterBlock(Identifier, 3, Direction.North, true, true),
            6093 => new RepeaterBlock(Identifier, 3, Direction.North, true, false),
            6094 => new RepeaterBlock(Identifier, 3, Direction.North, false, true),
            6095 => new RepeaterBlock(Identifier, 3, Direction.North, false, false),
            6096 => new RepeaterBlock(Identifier, 3, Direction.South, true, true),
            6097 => new RepeaterBlock(Identifier, 3, Direction.South, true, false),
            6098 => new RepeaterBlock(Identifier, 3, Direction.South, false, true),
            6099 => new RepeaterBlock(Identifier, 3, Direction.South, false, false),
            6100 => new RepeaterBlock(Identifier, 3, Direction.West, true, true),
            6101 => new RepeaterBlock(Identifier, 3, Direction.West, true, false),
            6102 => new RepeaterBlock(Identifier, 3, Direction.West, false, true),
            6103 => new RepeaterBlock(Identifier, 3, Direction.West, false, false),
            6104 => new RepeaterBlock(Identifier, 3, Direction.East, true, true),
            6105 => new RepeaterBlock(Identifier, 3, Direction.East, true, false),
            6106 => new RepeaterBlock(Identifier, 3, Direction.East, false, true),
            6107 => new RepeaterBlock(Identifier, 3, Direction.East, false, false),
            6108 => new RepeaterBlock(Identifier, 4, Direction.North, true, true),
            6109 => new RepeaterBlock(Identifier, 4, Direction.North, true, false),
            6110 => new RepeaterBlock(Identifier, 4, Direction.North, false, true),
            6111 => new RepeaterBlock(Identifier, 4, Direction.North, false, false),
            6112 => new RepeaterBlock(Identifier, 4, Direction.South, true, true),
            6113 => new RepeaterBlock(Identifier, 4, Direction.South, true, false),
            6114 => new RepeaterBlock(Identifier, 4, Direction.South, false, true),
            6115 => new RepeaterBlock(Identifier, 4, Direction.South, false, false),
            6116 => new RepeaterBlock(Identifier, 4, Direction.West, true, true),
            6117 => new RepeaterBlock(Identifier, 4, Direction.West, true, false),
            6118 => new RepeaterBlock(Identifier, 4, Direction.West, false, true),
            6119 => new RepeaterBlock(Identifier, 4, Direction.West, false, false),
            6120 => new RepeaterBlock(Identifier, 4, Direction.East, true, true),
            6121 => new RepeaterBlock(Identifier, 4, Direction.East, true, false),
            6122 => new RepeaterBlock(Identifier, 4, Direction.East, false, true),
            6123 => new RepeaterBlock(Identifier, 4, Direction.East, false, false),
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
