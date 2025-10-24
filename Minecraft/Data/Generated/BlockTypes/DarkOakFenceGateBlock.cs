using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DarkOakFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock {
    public Identifier Category => "minecraft:fence_gate";
    public int ProtocolId => 631;
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
    public Identifier? Item => "minecraft:dark_oak_fence_gate";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.3125, 0.4375] -> [0.125, 1.0, 0.5625], AABB[0.875, 0.3125, 0.4375] -> [1.0, 1.0, 0.5625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 26;
    public string TranslationKey => "block.minecraft.dark_oak_fence_gate";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13442,
                            false => 13443,
                        },
                        false => Powered switch {
                            true => 13444,
                            false => 13445,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13446,
                            false => 13447,
                        },
                        false => Powered switch {
                            true => 13448,
                            false => 13449,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13450,
                            false => 13451,
                        },
                        false => Powered switch {
                            true => 13452,
                            false => 13453,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13454,
                            false => 13455,
                        },
                        false => Powered switch {
                            true => 13456,
                            false => 13457,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13458,
                            false => 13459,
                        },
                        false => Powered switch {
                            true => 13460,
                            false => 13461,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13462,
                            false => 13463,
                        },
                        false => Powered switch {
                            true => 13464,
                            false => 13465,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13466,
                            false => 13467,
                        },
                        false => Powered switch {
                            true => 13468,
                            false => 13469,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13470,
                            false => 13471,
                        },
                        false => Powered switch {
                            true => 13472,
                            false => 13473,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13442 => new DarkOakFenceGateBlock(Identifier, Direction.North, true, true, true),
            13443 => new DarkOakFenceGateBlock(Identifier, Direction.North, true, true, false),
            13444 => new DarkOakFenceGateBlock(Identifier, Direction.North, true, false, true),
            13445 => new DarkOakFenceGateBlock(Identifier, Direction.North, true, false, false),
            13446 => new DarkOakFenceGateBlock(Identifier, Direction.North, false, true, true),
            13447 => new DarkOakFenceGateBlock(Identifier, Direction.North, false, true, false),
            13448 => new DarkOakFenceGateBlock(Identifier, Direction.North, false, false, true),
            13449 => new DarkOakFenceGateBlock(Identifier, Direction.North, false, false, false),
            13450 => new DarkOakFenceGateBlock(Identifier, Direction.South, true, true, true),
            13451 => new DarkOakFenceGateBlock(Identifier, Direction.South, true, true, false),
            13452 => new DarkOakFenceGateBlock(Identifier, Direction.South, true, false, true),
            13453 => new DarkOakFenceGateBlock(Identifier, Direction.South, true, false, false),
            13454 => new DarkOakFenceGateBlock(Identifier, Direction.South, false, true, true),
            13455 => new DarkOakFenceGateBlock(Identifier, Direction.South, false, true, false),
            13456 => new DarkOakFenceGateBlock(Identifier, Direction.South, false, false, true),
            13457 => new DarkOakFenceGateBlock(Identifier, Direction.South, false, false, false),
            13458 => new DarkOakFenceGateBlock(Identifier, Direction.West, true, true, true),
            13459 => new DarkOakFenceGateBlock(Identifier, Direction.West, true, true, false),
            13460 => new DarkOakFenceGateBlock(Identifier, Direction.West, true, false, true),
            13461 => new DarkOakFenceGateBlock(Identifier, Direction.West, true, false, false),
            13462 => new DarkOakFenceGateBlock(Identifier, Direction.West, false, true, true),
            13463 => new DarkOakFenceGateBlock(Identifier, Direction.West, false, true, false),
            13464 => new DarkOakFenceGateBlock(Identifier, Direction.West, false, false, true),
            13465 => new DarkOakFenceGateBlock(Identifier, Direction.West, false, false, false),
            13466 => new DarkOakFenceGateBlock(Identifier, Direction.East, true, true, true),
            13467 => new DarkOakFenceGateBlock(Identifier, Direction.East, true, true, false),
            13468 => new DarkOakFenceGateBlock(Identifier, Direction.East, true, false, true),
            13469 => new DarkOakFenceGateBlock(Identifier, Direction.East, true, false, false),
            13470 => new DarkOakFenceGateBlock(Identifier, Direction.East, false, true, true),
            13471 => new DarkOakFenceGateBlock(Identifier, Direction.East, false, true, false),
            13472 => new DarkOakFenceGateBlock(Identifier, Direction.East, false, false, true),
            13473 => new DarkOakFenceGateBlock(Identifier, Direction.East, false, false, false),
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
