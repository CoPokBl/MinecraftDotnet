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
                            true => 13676,
                            false => 13677,
                        },
                        false => Powered switch {
                            true => 13678,
                            false => 13679,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13680,
                            false => 13681,
                        },
                        false => Powered switch {
                            true => 13682,
                            false => 13683,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13684,
                            false => 13685,
                        },
                        false => Powered switch {
                            true => 13686,
                            false => 13687,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13688,
                            false => 13689,
                        },
                        false => Powered switch {
                            true => 13690,
                            false => 13691,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13692,
                            false => 13693,
                        },
                        false => Powered switch {
                            true => 13694,
                            false => 13695,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13696,
                            false => 13697,
                        },
                        false => Powered switch {
                            true => 13698,
                            false => 13699,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13700,
                            false => 13701,
                        },
                        false => Powered switch {
                            true => 13702,
                            false => 13703,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13704,
                            false => 13705,
                        },
                        false => Powered switch {
                            true => 13706,
                            false => 13707,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13676 => new PaleOakFenceGateBlock(Identifier, Direction.North, true, true, true),
            13677 => new PaleOakFenceGateBlock(Identifier, Direction.North, true, true, false),
            13678 => new PaleOakFenceGateBlock(Identifier, Direction.North, true, false, true),
            13679 => new PaleOakFenceGateBlock(Identifier, Direction.North, true, false, false),
            13680 => new PaleOakFenceGateBlock(Identifier, Direction.North, false, true, true),
            13681 => new PaleOakFenceGateBlock(Identifier, Direction.North, false, true, false),
            13682 => new PaleOakFenceGateBlock(Identifier, Direction.North, false, false, true),
            13683 => new PaleOakFenceGateBlock(Identifier, Direction.North, false, false, false),
            13684 => new PaleOakFenceGateBlock(Identifier, Direction.South, true, true, true),
            13685 => new PaleOakFenceGateBlock(Identifier, Direction.South, true, true, false),
            13686 => new PaleOakFenceGateBlock(Identifier, Direction.South, true, false, true),
            13687 => new PaleOakFenceGateBlock(Identifier, Direction.South, true, false, false),
            13688 => new PaleOakFenceGateBlock(Identifier, Direction.South, false, true, true),
            13689 => new PaleOakFenceGateBlock(Identifier, Direction.South, false, true, false),
            13690 => new PaleOakFenceGateBlock(Identifier, Direction.South, false, false, true),
            13691 => new PaleOakFenceGateBlock(Identifier, Direction.South, false, false, false),
            13692 => new PaleOakFenceGateBlock(Identifier, Direction.West, true, true, true),
            13693 => new PaleOakFenceGateBlock(Identifier, Direction.West, true, true, false),
            13694 => new PaleOakFenceGateBlock(Identifier, Direction.West, true, false, true),
            13695 => new PaleOakFenceGateBlock(Identifier, Direction.West, true, false, false),
            13696 => new PaleOakFenceGateBlock(Identifier, Direction.West, false, true, true),
            13697 => new PaleOakFenceGateBlock(Identifier, Direction.West, false, true, false),
            13698 => new PaleOakFenceGateBlock(Identifier, Direction.West, false, false, true),
            13699 => new PaleOakFenceGateBlock(Identifier, Direction.West, false, false, false),
            13700 => new PaleOakFenceGateBlock(Identifier, Direction.East, true, true, true),
            13701 => new PaleOakFenceGateBlock(Identifier, Direction.East, true, true, false),
            13702 => new PaleOakFenceGateBlock(Identifier, Direction.East, true, false, true),
            13703 => new PaleOakFenceGateBlock(Identifier, Direction.East, true, false, false),
            13704 => new PaleOakFenceGateBlock(Identifier, Direction.East, false, true, true),
            13705 => new PaleOakFenceGateBlock(Identifier, Direction.East, false, true, false),
            13706 => new PaleOakFenceGateBlock(Identifier, Direction.East, false, false, true),
            13707 => new PaleOakFenceGateBlock(Identifier, Direction.East, false, false, false),
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
