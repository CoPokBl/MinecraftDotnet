using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CrimsonFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock {
    public Identifier Category => "minecraft:fence_gate";
    public int ProtocolId => 891;
    public double Hardness => 2;
    public double ExplosionResistance => 3;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "nether_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:crimson_fence_gate";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.3125, 0.4375] -> [0.125, 1.0, 0.5625], AABB[0.875, 0.3125, 0.4375] -> [1.0, 1.0, 0.5625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 53;
    public string TranslationKey => "block.minecraft.crimson_fence_gate";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 21040,
                            false => 21041,
                        },
                        false => Powered switch {
                            true => 21042,
                            false => 21043,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 21044,
                            false => 21045,
                        },
                        false => Powered switch {
                            true => 21046,
                            false => 21047,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 21048,
                            false => 21049,
                        },
                        false => Powered switch {
                            true => 21050,
                            false => 21051,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 21052,
                            false => 21053,
                        },
                        false => Powered switch {
                            true => 21054,
                            false => 21055,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 21056,
                            false => 21057,
                        },
                        false => Powered switch {
                            true => 21058,
                            false => 21059,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 21060,
                            false => 21061,
                        },
                        false => Powered switch {
                            true => 21062,
                            false => 21063,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 21064,
                            false => 21065,
                        },
                        false => Powered switch {
                            true => 21066,
                            false => 21067,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 21068,
                            false => 21069,
                        },
                        false => Powered switch {
                            true => 21070,
                            false => 21071,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21040 => new CrimsonFenceGateBlock(Identifier, Direction.North, true, true, true),
            21041 => new CrimsonFenceGateBlock(Identifier, Direction.North, true, true, false),
            21042 => new CrimsonFenceGateBlock(Identifier, Direction.North, true, false, true),
            21043 => new CrimsonFenceGateBlock(Identifier, Direction.North, true, false, false),
            21044 => new CrimsonFenceGateBlock(Identifier, Direction.North, false, true, true),
            21045 => new CrimsonFenceGateBlock(Identifier, Direction.North, false, true, false),
            21046 => new CrimsonFenceGateBlock(Identifier, Direction.North, false, false, true),
            21047 => new CrimsonFenceGateBlock(Identifier, Direction.North, false, false, false),
            21048 => new CrimsonFenceGateBlock(Identifier, Direction.South, true, true, true),
            21049 => new CrimsonFenceGateBlock(Identifier, Direction.South, true, true, false),
            21050 => new CrimsonFenceGateBlock(Identifier, Direction.South, true, false, true),
            21051 => new CrimsonFenceGateBlock(Identifier, Direction.South, true, false, false),
            21052 => new CrimsonFenceGateBlock(Identifier, Direction.South, false, true, true),
            21053 => new CrimsonFenceGateBlock(Identifier, Direction.South, false, true, false),
            21054 => new CrimsonFenceGateBlock(Identifier, Direction.South, false, false, true),
            21055 => new CrimsonFenceGateBlock(Identifier, Direction.South, false, false, false),
            21056 => new CrimsonFenceGateBlock(Identifier, Direction.West, true, true, true),
            21057 => new CrimsonFenceGateBlock(Identifier, Direction.West, true, true, false),
            21058 => new CrimsonFenceGateBlock(Identifier, Direction.West, true, false, true),
            21059 => new CrimsonFenceGateBlock(Identifier, Direction.West, true, false, false),
            21060 => new CrimsonFenceGateBlock(Identifier, Direction.West, false, true, true),
            21061 => new CrimsonFenceGateBlock(Identifier, Direction.West, false, true, false),
            21062 => new CrimsonFenceGateBlock(Identifier, Direction.West, false, false, true),
            21063 => new CrimsonFenceGateBlock(Identifier, Direction.West, false, false, false),
            21064 => new CrimsonFenceGateBlock(Identifier, Direction.East, true, true, true),
            21065 => new CrimsonFenceGateBlock(Identifier, Direction.East, true, true, false),
            21066 => new CrimsonFenceGateBlock(Identifier, Direction.East, true, false, true),
            21067 => new CrimsonFenceGateBlock(Identifier, Direction.East, true, false, false),
            21068 => new CrimsonFenceGateBlock(Identifier, Direction.East, false, true, true),
            21069 => new CrimsonFenceGateBlock(Identifier, Direction.East, false, true, false),
            21070 => new CrimsonFenceGateBlock(Identifier, Direction.East, false, false, true),
            21071 => new CrimsonFenceGateBlock(Identifier, Direction.East, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            InWall = properties.ChildrenMap.ContainsKey("in_wall") ? properties["in_wall"].GetString() == "true" : InWall,
            Open = properties.ChildrenMap.ContainsKey("open") ? properties["open"].GetString() == "true" : Open,
            Powered = properties.ChildrenMap.ContainsKey("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("facing", Facing.ToName()),
            new StringTag("in_wall", InWall.ToString().ToLower()),
            new StringTag("open", Open.ToString().ToLower()),
            new StringTag("powered", Powered.ToString().ToLower())
        );
    }
    
}
