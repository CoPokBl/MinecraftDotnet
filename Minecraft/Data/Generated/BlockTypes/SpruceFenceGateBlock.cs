using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SpruceFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock {
    public Identifier Category => "minecraft:fence_gate";
    public int ProtocolId => 626;
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
    public Identifier? Item => "minecraft:spruce_fence_gate";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.3125, 0.4375] -> [0.125, 1.0, 0.5625], AABB[0.875, 0.3125, 0.4375] -> [1.0, 1.0, 0.5625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 34;
    public string TranslationKey => "block.minecraft.spruce_fence_gate";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13282,
                            false => 13283,
                        },
                        false => Powered switch {
                            true => 13284,
                            false => 13285,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13286,
                            false => 13287,
                        },
                        false => Powered switch {
                            true => 13288,
                            false => 13289,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13290,
                            false => 13291,
                        },
                        false => Powered switch {
                            true => 13292,
                            false => 13293,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13294,
                            false => 13295,
                        },
                        false => Powered switch {
                            true => 13296,
                            false => 13297,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13298,
                            false => 13299,
                        },
                        false => Powered switch {
                            true => 13300,
                            false => 13301,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13302,
                            false => 13303,
                        },
                        false => Powered switch {
                            true => 13304,
                            false => 13305,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13306,
                            false => 13307,
                        },
                        false => Powered switch {
                            true => 13308,
                            false => 13309,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13310,
                            false => 13311,
                        },
                        false => Powered switch {
                            true => 13312,
                            false => 13313,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13282 => new SpruceFenceGateBlock(Identifier, Direction.North, true, true, true),
            13283 => new SpruceFenceGateBlock(Identifier, Direction.North, true, true, false),
            13284 => new SpruceFenceGateBlock(Identifier, Direction.North, true, false, true),
            13285 => new SpruceFenceGateBlock(Identifier, Direction.North, true, false, false),
            13286 => new SpruceFenceGateBlock(Identifier, Direction.North, false, true, true),
            13287 => new SpruceFenceGateBlock(Identifier, Direction.North, false, true, false),
            13288 => new SpruceFenceGateBlock(Identifier, Direction.North, false, false, true),
            13289 => new SpruceFenceGateBlock(Identifier, Direction.North, false, false, false),
            13290 => new SpruceFenceGateBlock(Identifier, Direction.South, true, true, true),
            13291 => new SpruceFenceGateBlock(Identifier, Direction.South, true, true, false),
            13292 => new SpruceFenceGateBlock(Identifier, Direction.South, true, false, true),
            13293 => new SpruceFenceGateBlock(Identifier, Direction.South, true, false, false),
            13294 => new SpruceFenceGateBlock(Identifier, Direction.South, false, true, true),
            13295 => new SpruceFenceGateBlock(Identifier, Direction.South, false, true, false),
            13296 => new SpruceFenceGateBlock(Identifier, Direction.South, false, false, true),
            13297 => new SpruceFenceGateBlock(Identifier, Direction.South, false, false, false),
            13298 => new SpruceFenceGateBlock(Identifier, Direction.West, true, true, true),
            13299 => new SpruceFenceGateBlock(Identifier, Direction.West, true, true, false),
            13300 => new SpruceFenceGateBlock(Identifier, Direction.West, true, false, true),
            13301 => new SpruceFenceGateBlock(Identifier, Direction.West, true, false, false),
            13302 => new SpruceFenceGateBlock(Identifier, Direction.West, false, true, true),
            13303 => new SpruceFenceGateBlock(Identifier, Direction.West, false, true, false),
            13304 => new SpruceFenceGateBlock(Identifier, Direction.West, false, false, true),
            13305 => new SpruceFenceGateBlock(Identifier, Direction.West, false, false, false),
            13306 => new SpruceFenceGateBlock(Identifier, Direction.East, true, true, true),
            13307 => new SpruceFenceGateBlock(Identifier, Direction.East, true, true, false),
            13308 => new SpruceFenceGateBlock(Identifier, Direction.East, true, false, true),
            13309 => new SpruceFenceGateBlock(Identifier, Direction.East, true, false, false),
            13310 => new SpruceFenceGateBlock(Identifier, Direction.East, false, true, true),
            13311 => new SpruceFenceGateBlock(Identifier, Direction.East, false, true, false),
            13312 => new SpruceFenceGateBlock(Identifier, Direction.East, false, false, true),
            13313 => new SpruceFenceGateBlock(Identifier, Direction.East, false, false, false),
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
