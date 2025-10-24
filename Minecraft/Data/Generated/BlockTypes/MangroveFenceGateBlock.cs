using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MangroveFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock {
    public Identifier Category => "minecraft:fence_gate";
    public int ProtocolId => 633;
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
    public Identifier? Item => "minecraft:mangrove_fence_gate";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.3125, 0.4375] -> [0.125, 1.0, 0.5625], AABB[0.875, 0.3125, 0.4375] -> [1.0, 1.0, 0.5625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 28;
    public string TranslationKey => "block.minecraft.mangrove_fence_gate";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13506,
                            false => 13507,
                        },
                        false => Powered switch {
                            true => 13508,
                            false => 13509,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13510,
                            false => 13511,
                        },
                        false => Powered switch {
                            true => 13512,
                            false => 13513,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13514,
                            false => 13515,
                        },
                        false => Powered switch {
                            true => 13516,
                            false => 13517,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13518,
                            false => 13519,
                        },
                        false => Powered switch {
                            true => 13520,
                            false => 13521,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13522,
                            false => 13523,
                        },
                        false => Powered switch {
                            true => 13524,
                            false => 13525,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13526,
                            false => 13527,
                        },
                        false => Powered switch {
                            true => 13528,
                            false => 13529,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13530,
                            false => 13531,
                        },
                        false => Powered switch {
                            true => 13532,
                            false => 13533,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13534,
                            false => 13535,
                        },
                        false => Powered switch {
                            true => 13536,
                            false => 13537,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13506 => new MangroveFenceGateBlock(Identifier, Direction.North, true, true, true),
            13507 => new MangroveFenceGateBlock(Identifier, Direction.North, true, true, false),
            13508 => new MangroveFenceGateBlock(Identifier, Direction.North, true, false, true),
            13509 => new MangroveFenceGateBlock(Identifier, Direction.North, true, false, false),
            13510 => new MangroveFenceGateBlock(Identifier, Direction.North, false, true, true),
            13511 => new MangroveFenceGateBlock(Identifier, Direction.North, false, true, false),
            13512 => new MangroveFenceGateBlock(Identifier, Direction.North, false, false, true),
            13513 => new MangroveFenceGateBlock(Identifier, Direction.North, false, false, false),
            13514 => new MangroveFenceGateBlock(Identifier, Direction.South, true, true, true),
            13515 => new MangroveFenceGateBlock(Identifier, Direction.South, true, true, false),
            13516 => new MangroveFenceGateBlock(Identifier, Direction.South, true, false, true),
            13517 => new MangroveFenceGateBlock(Identifier, Direction.South, true, false, false),
            13518 => new MangroveFenceGateBlock(Identifier, Direction.South, false, true, true),
            13519 => new MangroveFenceGateBlock(Identifier, Direction.South, false, true, false),
            13520 => new MangroveFenceGateBlock(Identifier, Direction.South, false, false, true),
            13521 => new MangroveFenceGateBlock(Identifier, Direction.South, false, false, false),
            13522 => new MangroveFenceGateBlock(Identifier, Direction.West, true, true, true),
            13523 => new MangroveFenceGateBlock(Identifier, Direction.West, true, true, false),
            13524 => new MangroveFenceGateBlock(Identifier, Direction.West, true, false, true),
            13525 => new MangroveFenceGateBlock(Identifier, Direction.West, true, false, false),
            13526 => new MangroveFenceGateBlock(Identifier, Direction.West, false, true, true),
            13527 => new MangroveFenceGateBlock(Identifier, Direction.West, false, true, false),
            13528 => new MangroveFenceGateBlock(Identifier, Direction.West, false, false, true),
            13529 => new MangroveFenceGateBlock(Identifier, Direction.West, false, false, false),
            13530 => new MangroveFenceGateBlock(Identifier, Direction.East, true, true, true),
            13531 => new MangroveFenceGateBlock(Identifier, Direction.East, true, true, false),
            13532 => new MangroveFenceGateBlock(Identifier, Direction.East, true, false, true),
            13533 => new MangroveFenceGateBlock(Identifier, Direction.East, true, false, false),
            13534 => new MangroveFenceGateBlock(Identifier, Direction.East, false, true, true),
            13535 => new MangroveFenceGateBlock(Identifier, Direction.East, false, true, false),
            13536 => new MangroveFenceGateBlock(Identifier, Direction.East, false, false, true),
            13537 => new MangroveFenceGateBlock(Identifier, Direction.East, false, false, false),
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
