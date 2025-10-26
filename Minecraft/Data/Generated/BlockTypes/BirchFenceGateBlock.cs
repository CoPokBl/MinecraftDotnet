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
    public int ProtocolId => 627;
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
                            true => 13314,
                            false => 13315,
                        },
                        false => Powered switch {
                            true => 13316,
                            false => 13317,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13318,
                            false => 13319,
                        },
                        false => Powered switch {
                            true => 13320,
                            false => 13321,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13322,
                            false => 13323,
                        },
                        false => Powered switch {
                            true => 13324,
                            false => 13325,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13326,
                            false => 13327,
                        },
                        false => Powered switch {
                            true => 13328,
                            false => 13329,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13330,
                            false => 13331,
                        },
                        false => Powered switch {
                            true => 13332,
                            false => 13333,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13334,
                            false => 13335,
                        },
                        false => Powered switch {
                            true => 13336,
                            false => 13337,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13338,
                            false => 13339,
                        },
                        false => Powered switch {
                            true => 13340,
                            false => 13341,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13342,
                            false => 13343,
                        },
                        false => Powered switch {
                            true => 13344,
                            false => 13345,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13314 => new BirchFenceGateBlock(Identifier, Direction.North, true, true, true),
            13315 => new BirchFenceGateBlock(Identifier, Direction.North, true, true, false),
            13316 => new BirchFenceGateBlock(Identifier, Direction.North, true, false, true),
            13317 => new BirchFenceGateBlock(Identifier, Direction.North, true, false, false),
            13318 => new BirchFenceGateBlock(Identifier, Direction.North, false, true, true),
            13319 => new BirchFenceGateBlock(Identifier, Direction.North, false, true, false),
            13320 => new BirchFenceGateBlock(Identifier, Direction.North, false, false, true),
            13321 => new BirchFenceGateBlock(Identifier, Direction.North, false, false, false),
            13322 => new BirchFenceGateBlock(Identifier, Direction.South, true, true, true),
            13323 => new BirchFenceGateBlock(Identifier, Direction.South, true, true, false),
            13324 => new BirchFenceGateBlock(Identifier, Direction.South, true, false, true),
            13325 => new BirchFenceGateBlock(Identifier, Direction.South, true, false, false),
            13326 => new BirchFenceGateBlock(Identifier, Direction.South, false, true, true),
            13327 => new BirchFenceGateBlock(Identifier, Direction.South, false, true, false),
            13328 => new BirchFenceGateBlock(Identifier, Direction.South, false, false, true),
            13329 => new BirchFenceGateBlock(Identifier, Direction.South, false, false, false),
            13330 => new BirchFenceGateBlock(Identifier, Direction.West, true, true, true),
            13331 => new BirchFenceGateBlock(Identifier, Direction.West, true, true, false),
            13332 => new BirchFenceGateBlock(Identifier, Direction.West, true, false, true),
            13333 => new BirchFenceGateBlock(Identifier, Direction.West, true, false, false),
            13334 => new BirchFenceGateBlock(Identifier, Direction.West, false, true, true),
            13335 => new BirchFenceGateBlock(Identifier, Direction.West, false, true, false),
            13336 => new BirchFenceGateBlock(Identifier, Direction.West, false, false, true),
            13337 => new BirchFenceGateBlock(Identifier, Direction.West, false, false, false),
            13338 => new BirchFenceGateBlock(Identifier, Direction.East, true, true, true),
            13339 => new BirchFenceGateBlock(Identifier, Direction.East, true, true, false),
            13340 => new BirchFenceGateBlock(Identifier, Direction.East, true, false, true),
            13341 => new BirchFenceGateBlock(Identifier, Direction.East, true, false, false),
            13342 => new BirchFenceGateBlock(Identifier, Direction.East, false, true, true),
            13343 => new BirchFenceGateBlock(Identifier, Direction.East, false, true, false),
            13344 => new BirchFenceGateBlock(Identifier, Direction.East, false, false, true),
            13345 => new BirchFenceGateBlock(Identifier, Direction.East, false, false, false),
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
