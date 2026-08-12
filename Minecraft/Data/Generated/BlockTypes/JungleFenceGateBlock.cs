using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record JungleFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock {
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
    public Identifier? Item => "minecraft:jungle_fence_gate";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.3125, 0.4375] -> [0.125, 1.0, 0.5625], AABB[0.875, 0.3125, 0.4375] -> [1.0, 1.0, 0.5625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 10;
    public string TranslationKey => "block.minecraft.jungle_fence_gate";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13548,
                            false => 13549,
                        },
                        false => Powered switch {
                            true => 13550,
                            false => 13551,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13552,
                            false => 13553,
                        },
                        false => Powered switch {
                            true => 13554,
                            false => 13555,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13556,
                            false => 13557,
                        },
                        false => Powered switch {
                            true => 13558,
                            false => 13559,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13560,
                            false => 13561,
                        },
                        false => Powered switch {
                            true => 13562,
                            false => 13563,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13564,
                            false => 13565,
                        },
                        false => Powered switch {
                            true => 13566,
                            false => 13567,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13568,
                            false => 13569,
                        },
                        false => Powered switch {
                            true => 13570,
                            false => 13571,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13572,
                            false => 13573,
                        },
                        false => Powered switch {
                            true => 13574,
                            false => 13575,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13576,
                            false => 13577,
                        },
                        false => Powered switch {
                            true => 13578,
                            false => 13579,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13548 => new JungleFenceGateBlock(Identifier, Direction.North, true, true, true),
            13549 => new JungleFenceGateBlock(Identifier, Direction.North, true, true, false),
            13550 => new JungleFenceGateBlock(Identifier, Direction.North, true, false, true),
            13551 => new JungleFenceGateBlock(Identifier, Direction.North, true, false, false),
            13552 => new JungleFenceGateBlock(Identifier, Direction.North, false, true, true),
            13553 => new JungleFenceGateBlock(Identifier, Direction.North, false, true, false),
            13554 => new JungleFenceGateBlock(Identifier, Direction.North, false, false, true),
            13555 => new JungleFenceGateBlock(Identifier, Direction.North, false, false, false),
            13556 => new JungleFenceGateBlock(Identifier, Direction.South, true, true, true),
            13557 => new JungleFenceGateBlock(Identifier, Direction.South, true, true, false),
            13558 => new JungleFenceGateBlock(Identifier, Direction.South, true, false, true),
            13559 => new JungleFenceGateBlock(Identifier, Direction.South, true, false, false),
            13560 => new JungleFenceGateBlock(Identifier, Direction.South, false, true, true),
            13561 => new JungleFenceGateBlock(Identifier, Direction.South, false, true, false),
            13562 => new JungleFenceGateBlock(Identifier, Direction.South, false, false, true),
            13563 => new JungleFenceGateBlock(Identifier, Direction.South, false, false, false),
            13564 => new JungleFenceGateBlock(Identifier, Direction.West, true, true, true),
            13565 => new JungleFenceGateBlock(Identifier, Direction.West, true, true, false),
            13566 => new JungleFenceGateBlock(Identifier, Direction.West, true, false, true),
            13567 => new JungleFenceGateBlock(Identifier, Direction.West, true, false, false),
            13568 => new JungleFenceGateBlock(Identifier, Direction.West, false, true, true),
            13569 => new JungleFenceGateBlock(Identifier, Direction.West, false, true, false),
            13570 => new JungleFenceGateBlock(Identifier, Direction.West, false, false, true),
            13571 => new JungleFenceGateBlock(Identifier, Direction.West, false, false, false),
            13572 => new JungleFenceGateBlock(Identifier, Direction.East, true, true, true),
            13573 => new JungleFenceGateBlock(Identifier, Direction.East, true, true, false),
            13574 => new JungleFenceGateBlock(Identifier, Direction.East, true, false, true),
            13575 => new JungleFenceGateBlock(Identifier, Direction.East, true, false, false),
            13576 => new JungleFenceGateBlock(Identifier, Direction.East, false, true, true),
            13577 => new JungleFenceGateBlock(Identifier, Direction.East, false, true, false),
            13578 => new JungleFenceGateBlock(Identifier, Direction.East, false, false, true),
            13579 => new JungleFenceGateBlock(Identifier, Direction.East, false, false, false),
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
