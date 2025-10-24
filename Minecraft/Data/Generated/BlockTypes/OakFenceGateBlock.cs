using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OakFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock {
    public Identifier Category => "minecraft:fence_gate";
    public int ProtocolId => 368;
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
    public Identifier? Item => "minecraft:oak_fence_gate";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.3125, 0.4375] -> [0.125, 1.0, 0.5625], AABB[0.875, 0.3125, 0.4375] -> [1.0, 1.0, 0.5625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 13;
    public string TranslationKey => "block.minecraft.oak_fence_gate";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 8445,
                            false => 8446,
                        },
                        false => Powered switch {
                            true => 8447,
                            false => 8448,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 8449,
                            false => 8450,
                        },
                        false => Powered switch {
                            true => 8451,
                            false => 8452,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 8453,
                            false => 8454,
                        },
                        false => Powered switch {
                            true => 8455,
                            false => 8456,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 8457,
                            false => 8458,
                        },
                        false => Powered switch {
                            true => 8459,
                            false => 8460,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 8461,
                            false => 8462,
                        },
                        false => Powered switch {
                            true => 8463,
                            false => 8464,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 8465,
                            false => 8466,
                        },
                        false => Powered switch {
                            true => 8467,
                            false => 8468,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 8469,
                            false => 8470,
                        },
                        false => Powered switch {
                            true => 8471,
                            false => 8472,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 8473,
                            false => 8474,
                        },
                        false => Powered switch {
                            true => 8475,
                            false => 8476,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8445 => new OakFenceGateBlock(Identifier, Direction.North, true, true, true),
            8446 => new OakFenceGateBlock(Identifier, Direction.North, true, true, false),
            8447 => new OakFenceGateBlock(Identifier, Direction.North, true, false, true),
            8448 => new OakFenceGateBlock(Identifier, Direction.North, true, false, false),
            8449 => new OakFenceGateBlock(Identifier, Direction.North, false, true, true),
            8450 => new OakFenceGateBlock(Identifier, Direction.North, false, true, false),
            8451 => new OakFenceGateBlock(Identifier, Direction.North, false, false, true),
            8452 => new OakFenceGateBlock(Identifier, Direction.North, false, false, false),
            8453 => new OakFenceGateBlock(Identifier, Direction.South, true, true, true),
            8454 => new OakFenceGateBlock(Identifier, Direction.South, true, true, false),
            8455 => new OakFenceGateBlock(Identifier, Direction.South, true, false, true),
            8456 => new OakFenceGateBlock(Identifier, Direction.South, true, false, false),
            8457 => new OakFenceGateBlock(Identifier, Direction.South, false, true, true),
            8458 => new OakFenceGateBlock(Identifier, Direction.South, false, true, false),
            8459 => new OakFenceGateBlock(Identifier, Direction.South, false, false, true),
            8460 => new OakFenceGateBlock(Identifier, Direction.South, false, false, false),
            8461 => new OakFenceGateBlock(Identifier, Direction.West, true, true, true),
            8462 => new OakFenceGateBlock(Identifier, Direction.West, true, true, false),
            8463 => new OakFenceGateBlock(Identifier, Direction.West, true, false, true),
            8464 => new OakFenceGateBlock(Identifier, Direction.West, true, false, false),
            8465 => new OakFenceGateBlock(Identifier, Direction.West, false, true, true),
            8466 => new OakFenceGateBlock(Identifier, Direction.West, false, true, false),
            8467 => new OakFenceGateBlock(Identifier, Direction.West, false, false, true),
            8468 => new OakFenceGateBlock(Identifier, Direction.West, false, false, false),
            8469 => new OakFenceGateBlock(Identifier, Direction.East, true, true, true),
            8470 => new OakFenceGateBlock(Identifier, Direction.East, true, true, false),
            8471 => new OakFenceGateBlock(Identifier, Direction.East, true, false, true),
            8472 => new OakFenceGateBlock(Identifier, Direction.East, true, false, false),
            8473 => new OakFenceGateBlock(Identifier, Direction.East, false, true, true),
            8474 => new OakFenceGateBlock(Identifier, Direction.East, false, true, false),
            8475 => new OakFenceGateBlock(Identifier, Direction.East, false, false, true),
            8476 => new OakFenceGateBlock(Identifier, Direction.East, false, false, false),
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
