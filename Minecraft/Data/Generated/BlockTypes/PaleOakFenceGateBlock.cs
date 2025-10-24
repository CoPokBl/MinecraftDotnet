using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PaleOakFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock {
    public Identifier Category => "minecraft:fence_gate";
    public int ProtocolId => 632;
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
    public Identifier? Item => "minecraft:pale_oak_fence_gate";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.3125, 0.4375] -> [0.125, 1.0, 0.5625], AABB[0.875, 0.3125, 0.4375] -> [1.0, 1.0, 0.5625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 14;
    public string TranslationKey => "block.minecraft.pale_oak_fence_gate";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13474,
                            false => 13475,
                        },
                        false => Powered switch {
                            true => 13476,
                            false => 13477,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13478,
                            false => 13479,
                        },
                        false => Powered switch {
                            true => 13480,
                            false => 13481,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13482,
                            false => 13483,
                        },
                        false => Powered switch {
                            true => 13484,
                            false => 13485,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13486,
                            false => 13487,
                        },
                        false => Powered switch {
                            true => 13488,
                            false => 13489,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13490,
                            false => 13491,
                        },
                        false => Powered switch {
                            true => 13492,
                            false => 13493,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13494,
                            false => 13495,
                        },
                        false => Powered switch {
                            true => 13496,
                            false => 13497,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13498,
                            false => 13499,
                        },
                        false => Powered switch {
                            true => 13500,
                            false => 13501,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13502,
                            false => 13503,
                        },
                        false => Powered switch {
                            true => 13504,
                            false => 13505,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13474 => new PaleOakFenceGateBlock(Identifier, Direction.North, true, true, true),
            13475 => new PaleOakFenceGateBlock(Identifier, Direction.North, true, true, false),
            13476 => new PaleOakFenceGateBlock(Identifier, Direction.North, true, false, true),
            13477 => new PaleOakFenceGateBlock(Identifier, Direction.North, true, false, false),
            13478 => new PaleOakFenceGateBlock(Identifier, Direction.North, false, true, true),
            13479 => new PaleOakFenceGateBlock(Identifier, Direction.North, false, true, false),
            13480 => new PaleOakFenceGateBlock(Identifier, Direction.North, false, false, true),
            13481 => new PaleOakFenceGateBlock(Identifier, Direction.North, false, false, false),
            13482 => new PaleOakFenceGateBlock(Identifier, Direction.South, true, true, true),
            13483 => new PaleOakFenceGateBlock(Identifier, Direction.South, true, true, false),
            13484 => new PaleOakFenceGateBlock(Identifier, Direction.South, true, false, true),
            13485 => new PaleOakFenceGateBlock(Identifier, Direction.South, true, false, false),
            13486 => new PaleOakFenceGateBlock(Identifier, Direction.South, false, true, true),
            13487 => new PaleOakFenceGateBlock(Identifier, Direction.South, false, true, false),
            13488 => new PaleOakFenceGateBlock(Identifier, Direction.South, false, false, true),
            13489 => new PaleOakFenceGateBlock(Identifier, Direction.South, false, false, false),
            13490 => new PaleOakFenceGateBlock(Identifier, Direction.West, true, true, true),
            13491 => new PaleOakFenceGateBlock(Identifier, Direction.West, true, true, false),
            13492 => new PaleOakFenceGateBlock(Identifier, Direction.West, true, false, true),
            13493 => new PaleOakFenceGateBlock(Identifier, Direction.West, true, false, false),
            13494 => new PaleOakFenceGateBlock(Identifier, Direction.West, false, true, true),
            13495 => new PaleOakFenceGateBlock(Identifier, Direction.West, false, true, false),
            13496 => new PaleOakFenceGateBlock(Identifier, Direction.West, false, false, true),
            13497 => new PaleOakFenceGateBlock(Identifier, Direction.West, false, false, false),
            13498 => new PaleOakFenceGateBlock(Identifier, Direction.East, true, true, true),
            13499 => new PaleOakFenceGateBlock(Identifier, Direction.East, true, true, false),
            13500 => new PaleOakFenceGateBlock(Identifier, Direction.East, true, false, true),
            13501 => new PaleOakFenceGateBlock(Identifier, Direction.East, true, false, false),
            13502 => new PaleOakFenceGateBlock(Identifier, Direction.East, false, true, true),
            13503 => new PaleOakFenceGateBlock(Identifier, Direction.East, false, true, false),
            13504 => new PaleOakFenceGateBlock(Identifier, Direction.East, false, false, true),
            13505 => new PaleOakFenceGateBlock(Identifier, Direction.East, false, false, false),
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
