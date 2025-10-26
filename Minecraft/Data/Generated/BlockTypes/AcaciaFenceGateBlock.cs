using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record AcaciaFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock {
    public Identifier Category => "minecraft:fence_gate";
    public int ProtocolId => 629;
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
    public Identifier? Item => "minecraft:acacia_fence_gate";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.3125, 0.4375] -> [0.125, 1.0, 0.5625], AABB[0.875, 0.3125, 0.4375] -> [1.0, 1.0, 0.5625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 15;
    public string TranslationKey => "block.minecraft.acacia_fence_gate";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13378,
                            false => 13379,
                        },
                        false => Powered switch {
                            true => 13380,
                            false => 13381,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13382,
                            false => 13383,
                        },
                        false => Powered switch {
                            true => 13384,
                            false => 13385,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13386,
                            false => 13387,
                        },
                        false => Powered switch {
                            true => 13388,
                            false => 13389,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13390,
                            false => 13391,
                        },
                        false => Powered switch {
                            true => 13392,
                            false => 13393,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13394,
                            false => 13395,
                        },
                        false => Powered switch {
                            true => 13396,
                            false => 13397,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13398,
                            false => 13399,
                        },
                        false => Powered switch {
                            true => 13400,
                            false => 13401,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13402,
                            false => 13403,
                        },
                        false => Powered switch {
                            true => 13404,
                            false => 13405,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13406,
                            false => 13407,
                        },
                        false => Powered switch {
                            true => 13408,
                            false => 13409,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13378 => new AcaciaFenceGateBlock(Identifier, Direction.North, true, true, true),
            13379 => new AcaciaFenceGateBlock(Identifier, Direction.North, true, true, false),
            13380 => new AcaciaFenceGateBlock(Identifier, Direction.North, true, false, true),
            13381 => new AcaciaFenceGateBlock(Identifier, Direction.North, true, false, false),
            13382 => new AcaciaFenceGateBlock(Identifier, Direction.North, false, true, true),
            13383 => new AcaciaFenceGateBlock(Identifier, Direction.North, false, true, false),
            13384 => new AcaciaFenceGateBlock(Identifier, Direction.North, false, false, true),
            13385 => new AcaciaFenceGateBlock(Identifier, Direction.North, false, false, false),
            13386 => new AcaciaFenceGateBlock(Identifier, Direction.South, true, true, true),
            13387 => new AcaciaFenceGateBlock(Identifier, Direction.South, true, true, false),
            13388 => new AcaciaFenceGateBlock(Identifier, Direction.South, true, false, true),
            13389 => new AcaciaFenceGateBlock(Identifier, Direction.South, true, false, false),
            13390 => new AcaciaFenceGateBlock(Identifier, Direction.South, false, true, true),
            13391 => new AcaciaFenceGateBlock(Identifier, Direction.South, false, true, false),
            13392 => new AcaciaFenceGateBlock(Identifier, Direction.South, false, false, true),
            13393 => new AcaciaFenceGateBlock(Identifier, Direction.South, false, false, false),
            13394 => new AcaciaFenceGateBlock(Identifier, Direction.West, true, true, true),
            13395 => new AcaciaFenceGateBlock(Identifier, Direction.West, true, true, false),
            13396 => new AcaciaFenceGateBlock(Identifier, Direction.West, true, false, true),
            13397 => new AcaciaFenceGateBlock(Identifier, Direction.West, true, false, false),
            13398 => new AcaciaFenceGateBlock(Identifier, Direction.West, false, true, true),
            13399 => new AcaciaFenceGateBlock(Identifier, Direction.West, false, true, false),
            13400 => new AcaciaFenceGateBlock(Identifier, Direction.West, false, false, true),
            13401 => new AcaciaFenceGateBlock(Identifier, Direction.West, false, false, false),
            13402 => new AcaciaFenceGateBlock(Identifier, Direction.East, true, true, true),
            13403 => new AcaciaFenceGateBlock(Identifier, Direction.East, true, true, false),
            13404 => new AcaciaFenceGateBlock(Identifier, Direction.East, true, false, true),
            13405 => new AcaciaFenceGateBlock(Identifier, Direction.East, true, false, false),
            13406 => new AcaciaFenceGateBlock(Identifier, Direction.East, false, true, true),
            13407 => new AcaciaFenceGateBlock(Identifier, Direction.East, false, true, false),
            13408 => new AcaciaFenceGateBlock(Identifier, Direction.East, false, false, true),
            13409 => new AcaciaFenceGateBlock(Identifier, Direction.East, false, false, false),
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
