using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CherryFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock {
    public Identifier Category => "minecraft:fence_gate";
    public int ProtocolId => 630;
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
    public string SoundType => "cherry_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:cherry_fence_gate";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.3125, 0.4375] -> [0.125, 1.0, 0.5625], AABB[0.875, 0.3125, 0.4375] -> [1.0, 1.0, 0.5625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 36;
    public string TranslationKey => "block.minecraft.cherry_fence_gate";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13410,
                            false => 13411,
                        },
                        false => Powered switch {
                            true => 13412,
                            false => 13413,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13414,
                            false => 13415,
                        },
                        false => Powered switch {
                            true => 13416,
                            false => 13417,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13418,
                            false => 13419,
                        },
                        false => Powered switch {
                            true => 13420,
                            false => 13421,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13422,
                            false => 13423,
                        },
                        false => Powered switch {
                            true => 13424,
                            false => 13425,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13426,
                            false => 13427,
                        },
                        false => Powered switch {
                            true => 13428,
                            false => 13429,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13430,
                            false => 13431,
                        },
                        false => Powered switch {
                            true => 13432,
                            false => 13433,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13434,
                            false => 13435,
                        },
                        false => Powered switch {
                            true => 13436,
                            false => 13437,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13438,
                            false => 13439,
                        },
                        false => Powered switch {
                            true => 13440,
                            false => 13441,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13410 => new CherryFenceGateBlock(Identifier, Direction.North, true, true, true),
            13411 => new CherryFenceGateBlock(Identifier, Direction.North, true, true, false),
            13412 => new CherryFenceGateBlock(Identifier, Direction.North, true, false, true),
            13413 => new CherryFenceGateBlock(Identifier, Direction.North, true, false, false),
            13414 => new CherryFenceGateBlock(Identifier, Direction.North, false, true, true),
            13415 => new CherryFenceGateBlock(Identifier, Direction.North, false, true, false),
            13416 => new CherryFenceGateBlock(Identifier, Direction.North, false, false, true),
            13417 => new CherryFenceGateBlock(Identifier, Direction.North, false, false, false),
            13418 => new CherryFenceGateBlock(Identifier, Direction.South, true, true, true),
            13419 => new CherryFenceGateBlock(Identifier, Direction.South, true, true, false),
            13420 => new CherryFenceGateBlock(Identifier, Direction.South, true, false, true),
            13421 => new CherryFenceGateBlock(Identifier, Direction.South, true, false, false),
            13422 => new CherryFenceGateBlock(Identifier, Direction.South, false, true, true),
            13423 => new CherryFenceGateBlock(Identifier, Direction.South, false, true, false),
            13424 => new CherryFenceGateBlock(Identifier, Direction.South, false, false, true),
            13425 => new CherryFenceGateBlock(Identifier, Direction.South, false, false, false),
            13426 => new CherryFenceGateBlock(Identifier, Direction.West, true, true, true),
            13427 => new CherryFenceGateBlock(Identifier, Direction.West, true, true, false),
            13428 => new CherryFenceGateBlock(Identifier, Direction.West, true, false, true),
            13429 => new CherryFenceGateBlock(Identifier, Direction.West, true, false, false),
            13430 => new CherryFenceGateBlock(Identifier, Direction.West, false, true, true),
            13431 => new CherryFenceGateBlock(Identifier, Direction.West, false, true, false),
            13432 => new CherryFenceGateBlock(Identifier, Direction.West, false, false, true),
            13433 => new CherryFenceGateBlock(Identifier, Direction.West, false, false, false),
            13434 => new CherryFenceGateBlock(Identifier, Direction.East, true, true, true),
            13435 => new CherryFenceGateBlock(Identifier, Direction.East, true, true, false),
            13436 => new CherryFenceGateBlock(Identifier, Direction.East, true, false, true),
            13437 => new CherryFenceGateBlock(Identifier, Direction.East, true, false, false),
            13438 => new CherryFenceGateBlock(Identifier, Direction.East, false, true, true),
            13439 => new CherryFenceGateBlock(Identifier, Direction.East, false, true, false),
            13440 => new CherryFenceGateBlock(Identifier, Direction.East, false, false, true),
            13441 => new CherryFenceGateBlock(Identifier, Direction.East, false, false, false),
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
