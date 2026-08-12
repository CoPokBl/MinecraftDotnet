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
                            true => 8646,
                            false => 8647,
                        },
                        false => Powered switch {
                            true => 8648,
                            false => 8649,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 8650,
                            false => 8651,
                        },
                        false => Powered switch {
                            true => 8652,
                            false => 8653,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 8654,
                            false => 8655,
                        },
                        false => Powered switch {
                            true => 8656,
                            false => 8657,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 8658,
                            false => 8659,
                        },
                        false => Powered switch {
                            true => 8660,
                            false => 8661,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 8662,
                            false => 8663,
                        },
                        false => Powered switch {
                            true => 8664,
                            false => 8665,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 8666,
                            false => 8667,
                        },
                        false => Powered switch {
                            true => 8668,
                            false => 8669,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 8670,
                            false => 8671,
                        },
                        false => Powered switch {
                            true => 8672,
                            false => 8673,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 8674,
                            false => 8675,
                        },
                        false => Powered switch {
                            true => 8676,
                            false => 8677,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8646 => new OakFenceGateBlock(Identifier, Direction.North, true, true, true),
            8647 => new OakFenceGateBlock(Identifier, Direction.North, true, true, false),
            8648 => new OakFenceGateBlock(Identifier, Direction.North, true, false, true),
            8649 => new OakFenceGateBlock(Identifier, Direction.North, true, false, false),
            8650 => new OakFenceGateBlock(Identifier, Direction.North, false, true, true),
            8651 => new OakFenceGateBlock(Identifier, Direction.North, false, true, false),
            8652 => new OakFenceGateBlock(Identifier, Direction.North, false, false, true),
            8653 => new OakFenceGateBlock(Identifier, Direction.North, false, false, false),
            8654 => new OakFenceGateBlock(Identifier, Direction.South, true, true, true),
            8655 => new OakFenceGateBlock(Identifier, Direction.South, true, true, false),
            8656 => new OakFenceGateBlock(Identifier, Direction.South, true, false, true),
            8657 => new OakFenceGateBlock(Identifier, Direction.South, true, false, false),
            8658 => new OakFenceGateBlock(Identifier, Direction.South, false, true, true),
            8659 => new OakFenceGateBlock(Identifier, Direction.South, false, true, false),
            8660 => new OakFenceGateBlock(Identifier, Direction.South, false, false, true),
            8661 => new OakFenceGateBlock(Identifier, Direction.South, false, false, false),
            8662 => new OakFenceGateBlock(Identifier, Direction.West, true, true, true),
            8663 => new OakFenceGateBlock(Identifier, Direction.West, true, true, false),
            8664 => new OakFenceGateBlock(Identifier, Direction.West, true, false, true),
            8665 => new OakFenceGateBlock(Identifier, Direction.West, true, false, false),
            8666 => new OakFenceGateBlock(Identifier, Direction.West, false, true, true),
            8667 => new OakFenceGateBlock(Identifier, Direction.West, false, true, false),
            8668 => new OakFenceGateBlock(Identifier, Direction.West, false, false, true),
            8669 => new OakFenceGateBlock(Identifier, Direction.West, false, false, false),
            8670 => new OakFenceGateBlock(Identifier, Direction.East, true, true, true),
            8671 => new OakFenceGateBlock(Identifier, Direction.East, true, true, false),
            8672 => new OakFenceGateBlock(Identifier, Direction.East, true, false, true),
            8673 => new OakFenceGateBlock(Identifier, Direction.East, true, false, false),
            8674 => new OakFenceGateBlock(Identifier, Direction.East, false, true, true),
            8675 => new OakFenceGateBlock(Identifier, Direction.East, false, true, false),
            8676 => new OakFenceGateBlock(Identifier, Direction.East, false, false, true),
            8677 => new OakFenceGateBlock(Identifier, Direction.East, false, false, false),
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
