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
    public int ProtocolId => 338;
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
                            true => 7368,
                            false => 7369,
                        },
                        false => Powered switch {
                            true => 7370,
                            false => 7371,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 7372,
                            false => 7373,
                        },
                        false => Powered switch {
                            true => 7374,
                            false => 7375,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 7376,
                            false => 7377,
                        },
                        false => Powered switch {
                            true => 7378,
                            false => 7379,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 7380,
                            false => 7381,
                        },
                        false => Powered switch {
                            true => 7382,
                            false => 7383,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 7384,
                            false => 7385,
                        },
                        false => Powered switch {
                            true => 7386,
                            false => 7387,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 7388,
                            false => 7389,
                        },
                        false => Powered switch {
                            true => 7390,
                            false => 7391,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 7392,
                            false => 7393,
                        },
                        false => Powered switch {
                            true => 7394,
                            false => 7395,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 7396,
                            false => 7397,
                        },
                        false => Powered switch {
                            true => 7398,
                            false => 7399,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7368 => new OakFenceGateBlock(Identifier, Direction.North, true, true, true),
            7369 => new OakFenceGateBlock(Identifier, Direction.North, true, true, false),
            7370 => new OakFenceGateBlock(Identifier, Direction.North, true, false, true),
            7371 => new OakFenceGateBlock(Identifier, Direction.North, true, false, false),
            7372 => new OakFenceGateBlock(Identifier, Direction.North, false, true, true),
            7373 => new OakFenceGateBlock(Identifier, Direction.North, false, true, false),
            7374 => new OakFenceGateBlock(Identifier, Direction.North, false, false, true),
            7375 => new OakFenceGateBlock(Identifier, Direction.North, false, false, false),
            7376 => new OakFenceGateBlock(Identifier, Direction.South, true, true, true),
            7377 => new OakFenceGateBlock(Identifier, Direction.South, true, true, false),
            7378 => new OakFenceGateBlock(Identifier, Direction.South, true, false, true),
            7379 => new OakFenceGateBlock(Identifier, Direction.South, true, false, false),
            7380 => new OakFenceGateBlock(Identifier, Direction.South, false, true, true),
            7381 => new OakFenceGateBlock(Identifier, Direction.South, false, true, false),
            7382 => new OakFenceGateBlock(Identifier, Direction.South, false, false, true),
            7383 => new OakFenceGateBlock(Identifier, Direction.South, false, false, false),
            7384 => new OakFenceGateBlock(Identifier, Direction.West, true, true, true),
            7385 => new OakFenceGateBlock(Identifier, Direction.West, true, true, false),
            7386 => new OakFenceGateBlock(Identifier, Direction.West, true, false, true),
            7387 => new OakFenceGateBlock(Identifier, Direction.West, true, false, false),
            7388 => new OakFenceGateBlock(Identifier, Direction.West, false, true, true),
            7389 => new OakFenceGateBlock(Identifier, Direction.West, false, true, false),
            7390 => new OakFenceGateBlock(Identifier, Direction.West, false, false, true),
            7391 => new OakFenceGateBlock(Identifier, Direction.West, false, false, false),
            7392 => new OakFenceGateBlock(Identifier, Direction.East, true, true, true),
            7393 => new OakFenceGateBlock(Identifier, Direction.East, true, true, false),
            7394 => new OakFenceGateBlock(Identifier, Direction.East, true, false, true),
            7395 => new OakFenceGateBlock(Identifier, Direction.East, true, false, false),
            7396 => new OakFenceGateBlock(Identifier, Direction.East, false, true, true),
            7397 => new OakFenceGateBlock(Identifier, Direction.East, false, true, false),
            7398 => new OakFenceGateBlock(Identifier, Direction.East, false, false, true),
            7399 => new OakFenceGateBlock(Identifier, Direction.East, false, false, false),
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
