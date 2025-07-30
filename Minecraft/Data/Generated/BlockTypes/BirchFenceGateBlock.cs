using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BirchFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock {

    public Identifier Category => "minecraft:fence_gate";
    public int ProtocolId => 597;
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
    public string SoundType => "wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:birch_fence_gate";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.3125, 0.4375] -> [0.125, 1.0, 0.5625], AABB[0.875, 0.3125, 0.4375] -> [1.0, 1.0, 0.5625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 2;
    public string TranslationKey => "block.minecraft.birch_fence_gate";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12237,
                            false => 12238,
                        },
                        false => Powered switch {
                            true => 12239,
                            false => 12240,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12241,
                            false => 12242,
                        },
                        false => Powered switch {
                            true => 12243,
                            false => 12244,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12245,
                            false => 12246,
                        },
                        false => Powered switch {
                            true => 12247,
                            false => 12248,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12249,
                            false => 12250,
                        },
                        false => Powered switch {
                            true => 12251,
                            false => 12252,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12253,
                            false => 12254,
                        },
                        false => Powered switch {
                            true => 12255,
                            false => 12256,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12257,
                            false => 12258,
                        },
                        false => Powered switch {
                            true => 12259,
                            false => 12260,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12261,
                            false => 12262,
                        },
                        false => Powered switch {
                            true => 12263,
                            false => 12264,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12265,
                            false => 12266,
                        },
                        false => Powered switch {
                            true => 12267,
                            false => 12268,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12237 => new BirchFenceGateBlock(Identifier, Direction.North, true, true, true),
            12238 => new BirchFenceGateBlock(Identifier, Direction.North, true, true, false),
            12239 => new BirchFenceGateBlock(Identifier, Direction.North, true, false, true),
            12240 => new BirchFenceGateBlock(Identifier, Direction.North, true, false, false),
            12241 => new BirchFenceGateBlock(Identifier, Direction.North, false, true, true),
            12242 => new BirchFenceGateBlock(Identifier, Direction.North, false, true, false),
            12243 => new BirchFenceGateBlock(Identifier, Direction.North, false, false, true),
            12244 => new BirchFenceGateBlock(Identifier, Direction.North, false, false, false),
            12245 => new BirchFenceGateBlock(Identifier, Direction.South, true, true, true),
            12246 => new BirchFenceGateBlock(Identifier, Direction.South, true, true, false),
            12247 => new BirchFenceGateBlock(Identifier, Direction.South, true, false, true),
            12248 => new BirchFenceGateBlock(Identifier, Direction.South, true, false, false),
            12249 => new BirchFenceGateBlock(Identifier, Direction.South, false, true, true),
            12250 => new BirchFenceGateBlock(Identifier, Direction.South, false, true, false),
            12251 => new BirchFenceGateBlock(Identifier, Direction.South, false, false, true),
            12252 => new BirchFenceGateBlock(Identifier, Direction.South, false, false, false),
            12253 => new BirchFenceGateBlock(Identifier, Direction.West, true, true, true),
            12254 => new BirchFenceGateBlock(Identifier, Direction.West, true, true, false),
            12255 => new BirchFenceGateBlock(Identifier, Direction.West, true, false, true),
            12256 => new BirchFenceGateBlock(Identifier, Direction.West, true, false, false),
            12257 => new BirchFenceGateBlock(Identifier, Direction.West, false, true, true),
            12258 => new BirchFenceGateBlock(Identifier, Direction.West, false, true, false),
            12259 => new BirchFenceGateBlock(Identifier, Direction.West, false, false, true),
            12260 => new BirchFenceGateBlock(Identifier, Direction.West, false, false, false),
            12261 => new BirchFenceGateBlock(Identifier, Direction.East, true, true, true),
            12262 => new BirchFenceGateBlock(Identifier, Direction.East, true, true, false),
            12263 => new BirchFenceGateBlock(Identifier, Direction.East, true, false, true),
            12264 => new BirchFenceGateBlock(Identifier, Direction.East, true, false, false),
            12265 => new BirchFenceGateBlock(Identifier, Direction.East, false, true, true),
            12266 => new BirchFenceGateBlock(Identifier, Direction.East, false, true, false),
            12267 => new BirchFenceGateBlock(Identifier, Direction.East, false, false, true),
            12268 => new BirchFenceGateBlock(Identifier, Direction.East, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            InWall = properties["in_wall"].GetString() == "true",
            Open = properties["open"].GetString() == "true",
            Powered = properties["powered"].GetString() == "true",
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
