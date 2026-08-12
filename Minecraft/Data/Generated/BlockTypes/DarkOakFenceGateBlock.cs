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
                            true => 13644,
                            false => 13645,
                        },
                        false => Powered switch {
                            true => 13646,
                            false => 13647,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13648,
                            false => 13649,
                        },
                        false => Powered switch {
                            true => 13650,
                            false => 13651,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13652,
                            false => 13653,
                        },
                        false => Powered switch {
                            true => 13654,
                            false => 13655,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13656,
                            false => 13657,
                        },
                        false => Powered switch {
                            true => 13658,
                            false => 13659,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13660,
                            false => 13661,
                        },
                        false => Powered switch {
                            true => 13662,
                            false => 13663,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13664,
                            false => 13665,
                        },
                        false => Powered switch {
                            true => 13666,
                            false => 13667,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13668,
                            false => 13669,
                        },
                        false => Powered switch {
                            true => 13670,
                            false => 13671,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13672,
                            false => 13673,
                        },
                        false => Powered switch {
                            true => 13674,
                            false => 13675,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13644 => new DarkOakFenceGateBlock(Identifier, Direction.North, true, true, true),
            13645 => new DarkOakFenceGateBlock(Identifier, Direction.North, true, true, false),
            13646 => new DarkOakFenceGateBlock(Identifier, Direction.North, true, false, true),
            13647 => new DarkOakFenceGateBlock(Identifier, Direction.North, true, false, false),
            13648 => new DarkOakFenceGateBlock(Identifier, Direction.North, false, true, true),
            13649 => new DarkOakFenceGateBlock(Identifier, Direction.North, false, true, false),
            13650 => new DarkOakFenceGateBlock(Identifier, Direction.North, false, false, true),
            13651 => new DarkOakFenceGateBlock(Identifier, Direction.North, false, false, false),
            13652 => new DarkOakFenceGateBlock(Identifier, Direction.South, true, true, true),
            13653 => new DarkOakFenceGateBlock(Identifier, Direction.South, true, true, false),
            13654 => new DarkOakFenceGateBlock(Identifier, Direction.South, true, false, true),
            13655 => new DarkOakFenceGateBlock(Identifier, Direction.South, true, false, false),
            13656 => new DarkOakFenceGateBlock(Identifier, Direction.South, false, true, true),
            13657 => new DarkOakFenceGateBlock(Identifier, Direction.South, false, true, false),
            13658 => new DarkOakFenceGateBlock(Identifier, Direction.South, false, false, true),
            13659 => new DarkOakFenceGateBlock(Identifier, Direction.South, false, false, false),
            13660 => new DarkOakFenceGateBlock(Identifier, Direction.West, true, true, true),
            13661 => new DarkOakFenceGateBlock(Identifier, Direction.West, true, true, false),
            13662 => new DarkOakFenceGateBlock(Identifier, Direction.West, true, false, true),
            13663 => new DarkOakFenceGateBlock(Identifier, Direction.West, true, false, false),
            13664 => new DarkOakFenceGateBlock(Identifier, Direction.West, false, true, true),
            13665 => new DarkOakFenceGateBlock(Identifier, Direction.West, false, true, false),
            13666 => new DarkOakFenceGateBlock(Identifier, Direction.West, false, false, true),
            13667 => new DarkOakFenceGateBlock(Identifier, Direction.West, false, false, false),
            13668 => new DarkOakFenceGateBlock(Identifier, Direction.East, true, true, true),
            13669 => new DarkOakFenceGateBlock(Identifier, Direction.East, true, true, false),
            13670 => new DarkOakFenceGateBlock(Identifier, Direction.East, true, false, true),
            13671 => new DarkOakFenceGateBlock(Identifier, Direction.East, true, false, false),
            13672 => new DarkOakFenceGateBlock(Identifier, Direction.East, false, true, true),
            13673 => new DarkOakFenceGateBlock(Identifier, Direction.East, false, true, false),
            13674 => new DarkOakFenceGateBlock(Identifier, Direction.East, false, false, true),
            13675 => new DarkOakFenceGateBlock(Identifier, Direction.East, false, false, false),
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
