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
                            true => 13740,
                            false => 13741,
                        },
                        false => Powered switch {
                            true => 13742,
                            false => 13743,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13744,
                            false => 13745,
                        },
                        false => Powered switch {
                            true => 13746,
                            false => 13747,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13748,
                            false => 13749,
                        },
                        false => Powered switch {
                            true => 13750,
                            false => 13751,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13752,
                            false => 13753,
                        },
                        false => Powered switch {
                            true => 13754,
                            false => 13755,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13756,
                            false => 13757,
                        },
                        false => Powered switch {
                            true => 13758,
                            false => 13759,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13760,
                            false => 13761,
                        },
                        false => Powered switch {
                            true => 13762,
                            false => 13763,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13764,
                            false => 13765,
                        },
                        false => Powered switch {
                            true => 13766,
                            false => 13767,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13768,
                            false => 13769,
                        },
                        false => Powered switch {
                            true => 13770,
                            false => 13771,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13740 => new BambooFenceGateBlock(Identifier, Direction.North, true, true, true),
            13741 => new BambooFenceGateBlock(Identifier, Direction.North, true, true, false),
            13742 => new BambooFenceGateBlock(Identifier, Direction.North, true, false, true),
            13743 => new BambooFenceGateBlock(Identifier, Direction.North, true, false, false),
            13744 => new BambooFenceGateBlock(Identifier, Direction.North, false, true, true),
            13745 => new BambooFenceGateBlock(Identifier, Direction.North, false, true, false),
            13746 => new BambooFenceGateBlock(Identifier, Direction.North, false, false, true),
            13747 => new BambooFenceGateBlock(Identifier, Direction.North, false, false, false),
            13748 => new BambooFenceGateBlock(Identifier, Direction.South, true, true, true),
            13749 => new BambooFenceGateBlock(Identifier, Direction.South, true, true, false),
            13750 => new BambooFenceGateBlock(Identifier, Direction.South, true, false, true),
            13751 => new BambooFenceGateBlock(Identifier, Direction.South, true, false, false),
            13752 => new BambooFenceGateBlock(Identifier, Direction.South, false, true, true),
            13753 => new BambooFenceGateBlock(Identifier, Direction.South, false, true, false),
            13754 => new BambooFenceGateBlock(Identifier, Direction.South, false, false, true),
            13755 => new BambooFenceGateBlock(Identifier, Direction.South, false, false, false),
            13756 => new BambooFenceGateBlock(Identifier, Direction.West, true, true, true),
            13757 => new BambooFenceGateBlock(Identifier, Direction.West, true, true, false),
            13758 => new BambooFenceGateBlock(Identifier, Direction.West, true, false, true),
            13759 => new BambooFenceGateBlock(Identifier, Direction.West, true, false, false),
            13760 => new BambooFenceGateBlock(Identifier, Direction.West, false, true, true),
            13761 => new BambooFenceGateBlock(Identifier, Direction.West, false, true, false),
            13762 => new BambooFenceGateBlock(Identifier, Direction.West, false, false, true),
            13763 => new BambooFenceGateBlock(Identifier, Direction.West, false, false, false),
            13764 => new BambooFenceGateBlock(Identifier, Direction.East, true, true, true),
            13765 => new BambooFenceGateBlock(Identifier, Direction.East, true, true, false),
            13766 => new BambooFenceGateBlock(Identifier, Direction.East, true, false, true),
            13767 => new BambooFenceGateBlock(Identifier, Direction.East, true, false, false),
            13768 => new BambooFenceGateBlock(Identifier, Direction.East, false, true, true),
            13769 => new BambooFenceGateBlock(Identifier, Direction.East, false, true, false),
            13770 => new BambooFenceGateBlock(Identifier, Direction.East, false, false, true),
            13771 => new BambooFenceGateBlock(Identifier, Direction.East, false, false, false),
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
