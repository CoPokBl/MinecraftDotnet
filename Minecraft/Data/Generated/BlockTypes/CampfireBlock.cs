using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CampfireBlock(Identifier Identifier, Direction Facing, bool Lit, bool SignalFire, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:campfire";
    public int ProtocolId => 857;
    public double Hardness => 2;
    public double ExplosionResistance => 2;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 15;
    public bool Replaceable => false;
    public string SoundType => "wood";
    public Identifier? BlockEntity => "minecraft:campfire";
    public Identifier? Item => "minecraft:campfire";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.4375, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.4375, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.4375, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 34;
    public string TranslationKey => "block.minecraft.campfire";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Lit switch {
                    true => SignalFire switch {
                        true => Waterlogged switch {
                            true => 20675,
                            false => 20676,
                        },
                        false => Waterlogged switch {
                            true => 20677,
                            false => 20678,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 20679,
                            false => 20680,
                        },
                        false => Waterlogged switch {
                            true => 20681,
                            false => 20682,
                        },
                    },
                },
                Direction.South => Lit switch {
                    true => SignalFire switch {
                        true => Waterlogged switch {
                            true => 20683,
                            false => 20684,
                        },
                        false => Waterlogged switch {
                            true => 20685,
                            false => 20686,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 20687,
                            false => 20688,
                        },
                        false => Waterlogged switch {
                            true => 20689,
                            false => 20690,
                        },
                    },
                },
                Direction.West => Lit switch {
                    true => SignalFire switch {
                        true => Waterlogged switch {
                            true => 20691,
                            false => 20692,
                        },
                        false => Waterlogged switch {
                            true => 20693,
                            false => 20694,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 20695,
                            false => 20696,
                        },
                        false => Waterlogged switch {
                            true => 20697,
                            false => 20698,
                        },
                    },
                },
                Direction.East => Lit switch {
                    true => SignalFire switch {
                        true => Waterlogged switch {
                            true => 20699,
                            false => 20700,
                        },
                        false => Waterlogged switch {
                            true => 20701,
                            false => 20702,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 20703,
                            false => 20704,
                        },
                        false => Waterlogged switch {
                            true => 20705,
                            false => 20706,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20675 => new CampfireBlock(Identifier, Direction.North, true, true, true),
            20676 => new CampfireBlock(Identifier, Direction.North, true, true, false),
            20677 => new CampfireBlock(Identifier, Direction.North, true, false, true),
            20678 => new CampfireBlock(Identifier, Direction.North, true, false, false),
            20679 => new CampfireBlock(Identifier, Direction.North, false, true, true),
            20680 => new CampfireBlock(Identifier, Direction.North, false, true, false),
            20681 => new CampfireBlock(Identifier, Direction.North, false, false, true),
            20682 => new CampfireBlock(Identifier, Direction.North, false, false, false),
            20683 => new CampfireBlock(Identifier, Direction.South, true, true, true),
            20684 => new CampfireBlock(Identifier, Direction.South, true, true, false),
            20685 => new CampfireBlock(Identifier, Direction.South, true, false, true),
            20686 => new CampfireBlock(Identifier, Direction.South, true, false, false),
            20687 => new CampfireBlock(Identifier, Direction.South, false, true, true),
            20688 => new CampfireBlock(Identifier, Direction.South, false, true, false),
            20689 => new CampfireBlock(Identifier, Direction.South, false, false, true),
            20690 => new CampfireBlock(Identifier, Direction.South, false, false, false),
            20691 => new CampfireBlock(Identifier, Direction.West, true, true, true),
            20692 => new CampfireBlock(Identifier, Direction.West, true, true, false),
            20693 => new CampfireBlock(Identifier, Direction.West, true, false, true),
            20694 => new CampfireBlock(Identifier, Direction.West, true, false, false),
            20695 => new CampfireBlock(Identifier, Direction.West, false, true, true),
            20696 => new CampfireBlock(Identifier, Direction.West, false, true, false),
            20697 => new CampfireBlock(Identifier, Direction.West, false, false, true),
            20698 => new CampfireBlock(Identifier, Direction.West, false, false, false),
            20699 => new CampfireBlock(Identifier, Direction.East, true, true, true),
            20700 => new CampfireBlock(Identifier, Direction.East, true, true, false),
            20701 => new CampfireBlock(Identifier, Direction.East, true, false, true),
            20702 => new CampfireBlock(Identifier, Direction.East, true, false, false),
            20703 => new CampfireBlock(Identifier, Direction.East, false, true, true),
            20704 => new CampfireBlock(Identifier, Direction.East, false, true, false),
            20705 => new CampfireBlock(Identifier, Direction.East, false, false, true),
            20706 => new CampfireBlock(Identifier, Direction.East, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Lit = properties.ChildrenMap.ContainsKey("lit") ? properties["lit"].GetString() == "true" : Lit,
            SignalFire = properties.ChildrenMap.ContainsKey("signal_fire") ? properties["signal_fire"].GetString() == "true" : SignalFire,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("facing", Facing.ToName()),
            new StringTag("lit", Lit.ToString().ToLower()),
            new StringTag("signal_fire", SignalFire.ToString().ToLower()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
        );
    }
    
}
