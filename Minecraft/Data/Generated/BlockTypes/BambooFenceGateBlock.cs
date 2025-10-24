using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BambooFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock {
    public Identifier Category => "minecraft:fence_gate";
    public int ProtocolId => 634;
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
    public string SoundType => "bamboo_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:bamboo_fence_gate";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.3125, 0.4375] -> [0.125, 1.0, 0.5625], AABB[0.875, 0.3125, 0.4375] -> [1.0, 1.0, 0.5625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 18;
    public string TranslationKey => "block.minecraft.bamboo_fence_gate";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13538,
                            false => 13539,
                        },
                        false => Powered switch {
                            true => 13540,
                            false => 13541,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13542,
                            false => 13543,
                        },
                        false => Powered switch {
                            true => 13544,
                            false => 13545,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13546,
                            false => 13547,
                        },
                        false => Powered switch {
                            true => 13548,
                            false => 13549,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13550,
                            false => 13551,
                        },
                        false => Powered switch {
                            true => 13552,
                            false => 13553,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13554,
                            false => 13555,
                        },
                        false => Powered switch {
                            true => 13556,
                            false => 13557,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13558,
                            false => 13559,
                        },
                        false => Powered switch {
                            true => 13560,
                            false => 13561,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13562,
                            false => 13563,
                        },
                        false => Powered switch {
                            true => 13564,
                            false => 13565,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13566,
                            false => 13567,
                        },
                        false => Powered switch {
                            true => 13568,
                            false => 13569,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13538 => new BambooFenceGateBlock(Identifier, Direction.North, true, true, true),
            13539 => new BambooFenceGateBlock(Identifier, Direction.North, true, true, false),
            13540 => new BambooFenceGateBlock(Identifier, Direction.North, true, false, true),
            13541 => new BambooFenceGateBlock(Identifier, Direction.North, true, false, false),
            13542 => new BambooFenceGateBlock(Identifier, Direction.North, false, true, true),
            13543 => new BambooFenceGateBlock(Identifier, Direction.North, false, true, false),
            13544 => new BambooFenceGateBlock(Identifier, Direction.North, false, false, true),
            13545 => new BambooFenceGateBlock(Identifier, Direction.North, false, false, false),
            13546 => new BambooFenceGateBlock(Identifier, Direction.South, true, true, true),
            13547 => new BambooFenceGateBlock(Identifier, Direction.South, true, true, false),
            13548 => new BambooFenceGateBlock(Identifier, Direction.South, true, false, true),
            13549 => new BambooFenceGateBlock(Identifier, Direction.South, true, false, false),
            13550 => new BambooFenceGateBlock(Identifier, Direction.South, false, true, true),
            13551 => new BambooFenceGateBlock(Identifier, Direction.South, false, true, false),
            13552 => new BambooFenceGateBlock(Identifier, Direction.South, false, false, true),
            13553 => new BambooFenceGateBlock(Identifier, Direction.South, false, false, false),
            13554 => new BambooFenceGateBlock(Identifier, Direction.West, true, true, true),
            13555 => new BambooFenceGateBlock(Identifier, Direction.West, true, true, false),
            13556 => new BambooFenceGateBlock(Identifier, Direction.West, true, false, true),
            13557 => new BambooFenceGateBlock(Identifier, Direction.West, true, false, false),
            13558 => new BambooFenceGateBlock(Identifier, Direction.West, false, true, true),
            13559 => new BambooFenceGateBlock(Identifier, Direction.West, false, true, false),
            13560 => new BambooFenceGateBlock(Identifier, Direction.West, false, false, true),
            13561 => new BambooFenceGateBlock(Identifier, Direction.West, false, false, false),
            13562 => new BambooFenceGateBlock(Identifier, Direction.East, true, true, true),
            13563 => new BambooFenceGateBlock(Identifier, Direction.East, true, true, false),
            13564 => new BambooFenceGateBlock(Identifier, Direction.East, true, false, true),
            13565 => new BambooFenceGateBlock(Identifier, Direction.East, true, false, false),
            13566 => new BambooFenceGateBlock(Identifier, Direction.East, false, true, true),
            13567 => new BambooFenceGateBlock(Identifier, Direction.East, false, true, false),
            13568 => new BambooFenceGateBlock(Identifier, Direction.East, false, false, true),
            13569 => new BambooFenceGateBlock(Identifier, Direction.East, false, false, false),
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
