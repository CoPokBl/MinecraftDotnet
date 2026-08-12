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
                            true => 13580,
                            false => 13581,
                        },
                        false => Powered switch {
                            true => 13582,
                            false => 13583,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13584,
                            false => 13585,
                        },
                        false => Powered switch {
                            true => 13586,
                            false => 13587,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13588,
                            false => 13589,
                        },
                        false => Powered switch {
                            true => 13590,
                            false => 13591,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13592,
                            false => 13593,
                        },
                        false => Powered switch {
                            true => 13594,
                            false => 13595,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13596,
                            false => 13597,
                        },
                        false => Powered switch {
                            true => 13598,
                            false => 13599,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13600,
                            false => 13601,
                        },
                        false => Powered switch {
                            true => 13602,
                            false => 13603,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13604,
                            false => 13605,
                        },
                        false => Powered switch {
                            true => 13606,
                            false => 13607,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13608,
                            false => 13609,
                        },
                        false => Powered switch {
                            true => 13610,
                            false => 13611,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13580 => new AcaciaFenceGateBlock(Identifier, Direction.North, true, true, true),
            13581 => new AcaciaFenceGateBlock(Identifier, Direction.North, true, true, false),
            13582 => new AcaciaFenceGateBlock(Identifier, Direction.North, true, false, true),
            13583 => new AcaciaFenceGateBlock(Identifier, Direction.North, true, false, false),
            13584 => new AcaciaFenceGateBlock(Identifier, Direction.North, false, true, true),
            13585 => new AcaciaFenceGateBlock(Identifier, Direction.North, false, true, false),
            13586 => new AcaciaFenceGateBlock(Identifier, Direction.North, false, false, true),
            13587 => new AcaciaFenceGateBlock(Identifier, Direction.North, false, false, false),
            13588 => new AcaciaFenceGateBlock(Identifier, Direction.South, true, true, true),
            13589 => new AcaciaFenceGateBlock(Identifier, Direction.South, true, true, false),
            13590 => new AcaciaFenceGateBlock(Identifier, Direction.South, true, false, true),
            13591 => new AcaciaFenceGateBlock(Identifier, Direction.South, true, false, false),
            13592 => new AcaciaFenceGateBlock(Identifier, Direction.South, false, true, true),
            13593 => new AcaciaFenceGateBlock(Identifier, Direction.South, false, true, false),
            13594 => new AcaciaFenceGateBlock(Identifier, Direction.South, false, false, true),
            13595 => new AcaciaFenceGateBlock(Identifier, Direction.South, false, false, false),
            13596 => new AcaciaFenceGateBlock(Identifier, Direction.West, true, true, true),
            13597 => new AcaciaFenceGateBlock(Identifier, Direction.West, true, true, false),
            13598 => new AcaciaFenceGateBlock(Identifier, Direction.West, true, false, true),
            13599 => new AcaciaFenceGateBlock(Identifier, Direction.West, true, false, false),
            13600 => new AcaciaFenceGateBlock(Identifier, Direction.West, false, true, true),
            13601 => new AcaciaFenceGateBlock(Identifier, Direction.West, false, true, false),
            13602 => new AcaciaFenceGateBlock(Identifier, Direction.West, false, false, true),
            13603 => new AcaciaFenceGateBlock(Identifier, Direction.West, false, false, false),
            13604 => new AcaciaFenceGateBlock(Identifier, Direction.East, true, true, true),
            13605 => new AcaciaFenceGateBlock(Identifier, Direction.East, true, true, false),
            13606 => new AcaciaFenceGateBlock(Identifier, Direction.East, true, false, true),
            13607 => new AcaciaFenceGateBlock(Identifier, Direction.East, true, false, false),
            13608 => new AcaciaFenceGateBlock(Identifier, Direction.East, false, true, true),
            13609 => new AcaciaFenceGateBlock(Identifier, Direction.East, false, true, false),
            13610 => new AcaciaFenceGateBlock(Identifier, Direction.East, false, false, true),
            13611 => new AcaciaFenceGateBlock(Identifier, Direction.East, false, false, false),
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
