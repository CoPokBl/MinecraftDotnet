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
                            true => 13612,
                            false => 13613,
                        },
                        false => Powered switch {
                            true => 13614,
                            false => 13615,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13616,
                            false => 13617,
                        },
                        false => Powered switch {
                            true => 13618,
                            false => 13619,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13620,
                            false => 13621,
                        },
                        false => Powered switch {
                            true => 13622,
                            false => 13623,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13624,
                            false => 13625,
                        },
                        false => Powered switch {
                            true => 13626,
                            false => 13627,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13628,
                            false => 13629,
                        },
                        false => Powered switch {
                            true => 13630,
                            false => 13631,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13632,
                            false => 13633,
                        },
                        false => Powered switch {
                            true => 13634,
                            false => 13635,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13636,
                            false => 13637,
                        },
                        false => Powered switch {
                            true => 13638,
                            false => 13639,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13640,
                            false => 13641,
                        },
                        false => Powered switch {
                            true => 13642,
                            false => 13643,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13612 => new CherryFenceGateBlock(Identifier, Direction.North, true, true, true),
            13613 => new CherryFenceGateBlock(Identifier, Direction.North, true, true, false),
            13614 => new CherryFenceGateBlock(Identifier, Direction.North, true, false, true),
            13615 => new CherryFenceGateBlock(Identifier, Direction.North, true, false, false),
            13616 => new CherryFenceGateBlock(Identifier, Direction.North, false, true, true),
            13617 => new CherryFenceGateBlock(Identifier, Direction.North, false, true, false),
            13618 => new CherryFenceGateBlock(Identifier, Direction.North, false, false, true),
            13619 => new CherryFenceGateBlock(Identifier, Direction.North, false, false, false),
            13620 => new CherryFenceGateBlock(Identifier, Direction.South, true, true, true),
            13621 => new CherryFenceGateBlock(Identifier, Direction.South, true, true, false),
            13622 => new CherryFenceGateBlock(Identifier, Direction.South, true, false, true),
            13623 => new CherryFenceGateBlock(Identifier, Direction.South, true, false, false),
            13624 => new CherryFenceGateBlock(Identifier, Direction.South, false, true, true),
            13625 => new CherryFenceGateBlock(Identifier, Direction.South, false, true, false),
            13626 => new CherryFenceGateBlock(Identifier, Direction.South, false, false, true),
            13627 => new CherryFenceGateBlock(Identifier, Direction.South, false, false, false),
            13628 => new CherryFenceGateBlock(Identifier, Direction.West, true, true, true),
            13629 => new CherryFenceGateBlock(Identifier, Direction.West, true, true, false),
            13630 => new CherryFenceGateBlock(Identifier, Direction.West, true, false, true),
            13631 => new CherryFenceGateBlock(Identifier, Direction.West, true, false, false),
            13632 => new CherryFenceGateBlock(Identifier, Direction.West, false, true, true),
            13633 => new CherryFenceGateBlock(Identifier, Direction.West, false, true, false),
            13634 => new CherryFenceGateBlock(Identifier, Direction.West, false, false, true),
            13635 => new CherryFenceGateBlock(Identifier, Direction.West, false, false, false),
            13636 => new CherryFenceGateBlock(Identifier, Direction.East, true, true, true),
            13637 => new CherryFenceGateBlock(Identifier, Direction.East, true, true, false),
            13638 => new CherryFenceGateBlock(Identifier, Direction.East, true, false, true),
            13639 => new CherryFenceGateBlock(Identifier, Direction.East, true, false, false),
            13640 => new CherryFenceGateBlock(Identifier, Direction.East, false, true, true),
            13641 => new CherryFenceGateBlock(Identifier, Direction.East, false, true, false),
            13642 => new CherryFenceGateBlock(Identifier, Direction.East, false, false, true),
            13643 => new CherryFenceGateBlock(Identifier, Direction.East, false, false, false),
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
