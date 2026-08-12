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
                            true => 13708,
                            false => 13709,
                        },
                        false => Powered switch {
                            true => 13710,
                            false => 13711,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13712,
                            false => 13713,
                        },
                        false => Powered switch {
                            true => 13714,
                            false => 13715,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13716,
                            false => 13717,
                        },
                        false => Powered switch {
                            true => 13718,
                            false => 13719,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13720,
                            false => 13721,
                        },
                        false => Powered switch {
                            true => 13722,
                            false => 13723,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13724,
                            false => 13725,
                        },
                        false => Powered switch {
                            true => 13726,
                            false => 13727,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13728,
                            false => 13729,
                        },
                        false => Powered switch {
                            true => 13730,
                            false => 13731,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13732,
                            false => 13733,
                        },
                        false => Powered switch {
                            true => 13734,
                            false => 13735,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13736,
                            false => 13737,
                        },
                        false => Powered switch {
                            true => 13738,
                            false => 13739,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13708 => new MangroveFenceGateBlock(Identifier, Direction.North, true, true, true),
            13709 => new MangroveFenceGateBlock(Identifier, Direction.North, true, true, false),
            13710 => new MangroveFenceGateBlock(Identifier, Direction.North, true, false, true),
            13711 => new MangroveFenceGateBlock(Identifier, Direction.North, true, false, false),
            13712 => new MangroveFenceGateBlock(Identifier, Direction.North, false, true, true),
            13713 => new MangroveFenceGateBlock(Identifier, Direction.North, false, true, false),
            13714 => new MangroveFenceGateBlock(Identifier, Direction.North, false, false, true),
            13715 => new MangroveFenceGateBlock(Identifier, Direction.North, false, false, false),
            13716 => new MangroveFenceGateBlock(Identifier, Direction.South, true, true, true),
            13717 => new MangroveFenceGateBlock(Identifier, Direction.South, true, true, false),
            13718 => new MangroveFenceGateBlock(Identifier, Direction.South, true, false, true),
            13719 => new MangroveFenceGateBlock(Identifier, Direction.South, true, false, false),
            13720 => new MangroveFenceGateBlock(Identifier, Direction.South, false, true, true),
            13721 => new MangroveFenceGateBlock(Identifier, Direction.South, false, true, false),
            13722 => new MangroveFenceGateBlock(Identifier, Direction.South, false, false, true),
            13723 => new MangroveFenceGateBlock(Identifier, Direction.South, false, false, false),
            13724 => new MangroveFenceGateBlock(Identifier, Direction.West, true, true, true),
            13725 => new MangroveFenceGateBlock(Identifier, Direction.West, true, true, false),
            13726 => new MangroveFenceGateBlock(Identifier, Direction.West, true, false, true),
            13727 => new MangroveFenceGateBlock(Identifier, Direction.West, true, false, false),
            13728 => new MangroveFenceGateBlock(Identifier, Direction.West, false, true, true),
            13729 => new MangroveFenceGateBlock(Identifier, Direction.West, false, true, false),
            13730 => new MangroveFenceGateBlock(Identifier, Direction.West, false, false, true),
            13731 => new MangroveFenceGateBlock(Identifier, Direction.West, false, false, false),
            13732 => new MangroveFenceGateBlock(Identifier, Direction.East, true, true, true),
            13733 => new MangroveFenceGateBlock(Identifier, Direction.East, true, true, false),
            13734 => new MangroveFenceGateBlock(Identifier, Direction.East, true, false, true),
            13735 => new MangroveFenceGateBlock(Identifier, Direction.East, true, false, false),
            13736 => new MangroveFenceGateBlock(Identifier, Direction.East, false, true, true),
            13737 => new MangroveFenceGateBlock(Identifier, Direction.East, false, true, false),
            13738 => new MangroveFenceGateBlock(Identifier, Direction.East, false, false, true),
            13739 => new MangroveFenceGateBlock(Identifier, Direction.East, false, false, false),
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
