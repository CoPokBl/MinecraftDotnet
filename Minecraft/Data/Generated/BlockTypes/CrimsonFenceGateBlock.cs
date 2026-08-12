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
                            true => 21242,
                            false => 21243,
                        },
                        false => Powered switch {
                            true => 21244,
                            false => 21245,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 21246,
                            false => 21247,
                        },
                        false => Powered switch {
                            true => 21248,
                            false => 21249,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 21250,
                            false => 21251,
                        },
                        false => Powered switch {
                            true => 21252,
                            false => 21253,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 21254,
                            false => 21255,
                        },
                        false => Powered switch {
                            true => 21256,
                            false => 21257,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 21258,
                            false => 21259,
                        },
                        false => Powered switch {
                            true => 21260,
                            false => 21261,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 21262,
                            false => 21263,
                        },
                        false => Powered switch {
                            true => 21264,
                            false => 21265,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 21266,
                            false => 21267,
                        },
                        false => Powered switch {
                            true => 21268,
                            false => 21269,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 21270,
                            false => 21271,
                        },
                        false => Powered switch {
                            true => 21272,
                            false => 21273,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21242 => new CrimsonFenceGateBlock(Identifier, Direction.North, true, true, true),
            21243 => new CrimsonFenceGateBlock(Identifier, Direction.North, true, true, false),
            21244 => new CrimsonFenceGateBlock(Identifier, Direction.North, true, false, true),
            21245 => new CrimsonFenceGateBlock(Identifier, Direction.North, true, false, false),
            21246 => new CrimsonFenceGateBlock(Identifier, Direction.North, false, true, true),
            21247 => new CrimsonFenceGateBlock(Identifier, Direction.North, false, true, false),
            21248 => new CrimsonFenceGateBlock(Identifier, Direction.North, false, false, true),
            21249 => new CrimsonFenceGateBlock(Identifier, Direction.North, false, false, false),
            21250 => new CrimsonFenceGateBlock(Identifier, Direction.South, true, true, true),
            21251 => new CrimsonFenceGateBlock(Identifier, Direction.South, true, true, false),
            21252 => new CrimsonFenceGateBlock(Identifier, Direction.South, true, false, true),
            21253 => new CrimsonFenceGateBlock(Identifier, Direction.South, true, false, false),
            21254 => new CrimsonFenceGateBlock(Identifier, Direction.South, false, true, true),
            21255 => new CrimsonFenceGateBlock(Identifier, Direction.South, false, true, false),
            21256 => new CrimsonFenceGateBlock(Identifier, Direction.South, false, false, true),
            21257 => new CrimsonFenceGateBlock(Identifier, Direction.South, false, false, false),
            21258 => new CrimsonFenceGateBlock(Identifier, Direction.West, true, true, true),
            21259 => new CrimsonFenceGateBlock(Identifier, Direction.West, true, true, false),
            21260 => new CrimsonFenceGateBlock(Identifier, Direction.West, true, false, true),
            21261 => new CrimsonFenceGateBlock(Identifier, Direction.West, true, false, false),
            21262 => new CrimsonFenceGateBlock(Identifier, Direction.West, false, true, true),
            21263 => new CrimsonFenceGateBlock(Identifier, Direction.West, false, true, false),
            21264 => new CrimsonFenceGateBlock(Identifier, Direction.West, false, false, true),
            21265 => new CrimsonFenceGateBlock(Identifier, Direction.West, false, false, false),
            21266 => new CrimsonFenceGateBlock(Identifier, Direction.East, true, true, true),
            21267 => new CrimsonFenceGateBlock(Identifier, Direction.East, true, true, false),
            21268 => new CrimsonFenceGateBlock(Identifier, Direction.East, true, false, true),
            21269 => new CrimsonFenceGateBlock(Identifier, Direction.East, true, false, false),
            21270 => new CrimsonFenceGateBlock(Identifier, Direction.East, false, true, true),
            21271 => new CrimsonFenceGateBlock(Identifier, Direction.East, false, true, false),
            21272 => new CrimsonFenceGateBlock(Identifier, Direction.East, false, false, true),
            21273 => new CrimsonFenceGateBlock(Identifier, Direction.East, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            InWall = properties.Contains("in_wall") ? properties["in_wall"].GetString() == "true" : InWall,
            Open = properties.Contains("open") ? properties["open"].GetString() == "true" : Open,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("in_wall", new StringTag(InWall.ToString().ToLower())),
            ("open", new StringTag(Open.ToString().ToLower())),
            ("powered", new StringTag(Powered.ToString().ToLower()))
        );
    }
    
}
