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
                            true => 13516,
                            false => 13517,
                        },
                        false => Powered switch {
                            true => 13518,
                            false => 13519,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13520,
                            false => 13521,
                        },
                        false => Powered switch {
                            true => 13522,
                            false => 13523,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13524,
                            false => 13525,
                        },
                        false => Powered switch {
                            true => 13526,
                            false => 13527,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13528,
                            false => 13529,
                        },
                        false => Powered switch {
                            true => 13530,
                            false => 13531,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13532,
                            false => 13533,
                        },
                        false => Powered switch {
                            true => 13534,
                            false => 13535,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13536,
                            false => 13537,
                        },
                        false => Powered switch {
                            true => 13538,
                            false => 13539,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13540,
                            false => 13541,
                        },
                        false => Powered switch {
                            true => 13542,
                            false => 13543,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13544,
                            false => 13545,
                        },
                        false => Powered switch {
                            true => 13546,
                            false => 13547,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13516 => new BirchFenceGateBlock(Identifier, Direction.North, true, true, true),
            13517 => new BirchFenceGateBlock(Identifier, Direction.North, true, true, false),
            13518 => new BirchFenceGateBlock(Identifier, Direction.North, true, false, true),
            13519 => new BirchFenceGateBlock(Identifier, Direction.North, true, false, false),
            13520 => new BirchFenceGateBlock(Identifier, Direction.North, false, true, true),
            13521 => new BirchFenceGateBlock(Identifier, Direction.North, false, true, false),
            13522 => new BirchFenceGateBlock(Identifier, Direction.North, false, false, true),
            13523 => new BirchFenceGateBlock(Identifier, Direction.North, false, false, false),
            13524 => new BirchFenceGateBlock(Identifier, Direction.South, true, true, true),
            13525 => new BirchFenceGateBlock(Identifier, Direction.South, true, true, false),
            13526 => new BirchFenceGateBlock(Identifier, Direction.South, true, false, true),
            13527 => new BirchFenceGateBlock(Identifier, Direction.South, true, false, false),
            13528 => new BirchFenceGateBlock(Identifier, Direction.South, false, true, true),
            13529 => new BirchFenceGateBlock(Identifier, Direction.South, false, true, false),
            13530 => new BirchFenceGateBlock(Identifier, Direction.South, false, false, true),
            13531 => new BirchFenceGateBlock(Identifier, Direction.South, false, false, false),
            13532 => new BirchFenceGateBlock(Identifier, Direction.West, true, true, true),
            13533 => new BirchFenceGateBlock(Identifier, Direction.West, true, true, false),
            13534 => new BirchFenceGateBlock(Identifier, Direction.West, true, false, true),
            13535 => new BirchFenceGateBlock(Identifier, Direction.West, true, false, false),
            13536 => new BirchFenceGateBlock(Identifier, Direction.West, false, true, true),
            13537 => new BirchFenceGateBlock(Identifier, Direction.West, false, true, false),
            13538 => new BirchFenceGateBlock(Identifier, Direction.West, false, false, true),
            13539 => new BirchFenceGateBlock(Identifier, Direction.West, false, false, false),
            13540 => new BirchFenceGateBlock(Identifier, Direction.East, true, true, true),
            13541 => new BirchFenceGateBlock(Identifier, Direction.East, true, true, false),
            13542 => new BirchFenceGateBlock(Identifier, Direction.East, true, false, true),
            13543 => new BirchFenceGateBlock(Identifier, Direction.East, true, false, false),
            13544 => new BirchFenceGateBlock(Identifier, Direction.East, false, true, true),
            13545 => new BirchFenceGateBlock(Identifier, Direction.East, false, true, false),
            13546 => new BirchFenceGateBlock(Identifier, Direction.East, false, false, true),
            13547 => new BirchFenceGateBlock(Identifier, Direction.East, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            InWall = properties.Contains("in_wall") ? properties["in_wall"].GetString() == "true" : InWall,
            Open = properties.Contains("open") ? properties["open"].GetString() == "true" : Open,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("in_wall", new StringTag(InWall.ToString().ToLower())),
            ("open", new StringTag(Open.ToString().ToLower())),
            ("powered", new StringTag(Powered.ToString().ToLower()))
        );
    }
    
}
