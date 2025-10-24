using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SoulCampfireBlock(Identifier Identifier, Direction Facing, bool Lit, bool SignalFire, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:campfire";
    public int ProtocolId => 858;
    public double Hardness => 2;
    public double ExplosionResistance => 2;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 10;
    public bool Replaceable => false;
    public string SoundType => "wood";
    public Identifier? BlockEntity => "minecraft:campfire";
    public Identifier? Item => "minecraft:soul_campfire";
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
    public string TranslationKey => "block.minecraft.soul_campfire";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Lit switch {
                    true => SignalFire switch {
                        true => Waterlogged switch {
                            true => 20707,
                            false => 20708,
                        },
                        false => Waterlogged switch {
                            true => 20709,
                            false => 20710,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 20711,
                            false => 20712,
                        },
                        false => Waterlogged switch {
                            true => 20713,
                            false => 20714,
                        },
                    },
                },
                Direction.South => Lit switch {
                    true => SignalFire switch {
                        true => Waterlogged switch {
                            true => 20715,
                            false => 20716,
                        },
                        false => Waterlogged switch {
                            true => 20717,
                            false => 20718,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 20719,
                            false => 20720,
                        },
                        false => Waterlogged switch {
                            true => 20721,
                            false => 20722,
                        },
                    },
                },
                Direction.West => Lit switch {
                    true => SignalFire switch {
                        true => Waterlogged switch {
                            true => 20723,
                            false => 20724,
                        },
                        false => Waterlogged switch {
                            true => 20725,
                            false => 20726,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 20727,
                            false => 20728,
                        },
                        false => Waterlogged switch {
                            true => 20729,
                            false => 20730,
                        },
                    },
                },
                Direction.East => Lit switch {
                    true => SignalFire switch {
                        true => Waterlogged switch {
                            true => 20731,
                            false => 20732,
                        },
                        false => Waterlogged switch {
                            true => 20733,
                            false => 20734,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 20735,
                            false => 20736,
                        },
                        false => Waterlogged switch {
                            true => 20737,
                            false => 20738,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20707 => new SoulCampfireBlock(Identifier, Direction.North, true, true, true),
            20708 => new SoulCampfireBlock(Identifier, Direction.North, true, true, false),
            20709 => new SoulCampfireBlock(Identifier, Direction.North, true, false, true),
            20710 => new SoulCampfireBlock(Identifier, Direction.North, true, false, false),
            20711 => new SoulCampfireBlock(Identifier, Direction.North, false, true, true),
            20712 => new SoulCampfireBlock(Identifier, Direction.North, false, true, false),
            20713 => new SoulCampfireBlock(Identifier, Direction.North, false, false, true),
            20714 => new SoulCampfireBlock(Identifier, Direction.North, false, false, false),
            20715 => new SoulCampfireBlock(Identifier, Direction.South, true, true, true),
            20716 => new SoulCampfireBlock(Identifier, Direction.South, true, true, false),
            20717 => new SoulCampfireBlock(Identifier, Direction.South, true, false, true),
            20718 => new SoulCampfireBlock(Identifier, Direction.South, true, false, false),
            20719 => new SoulCampfireBlock(Identifier, Direction.South, false, true, true),
            20720 => new SoulCampfireBlock(Identifier, Direction.South, false, true, false),
            20721 => new SoulCampfireBlock(Identifier, Direction.South, false, false, true),
            20722 => new SoulCampfireBlock(Identifier, Direction.South, false, false, false),
            20723 => new SoulCampfireBlock(Identifier, Direction.West, true, true, true),
            20724 => new SoulCampfireBlock(Identifier, Direction.West, true, true, false),
            20725 => new SoulCampfireBlock(Identifier, Direction.West, true, false, true),
            20726 => new SoulCampfireBlock(Identifier, Direction.West, true, false, false),
            20727 => new SoulCampfireBlock(Identifier, Direction.West, false, true, true),
            20728 => new SoulCampfireBlock(Identifier, Direction.West, false, true, false),
            20729 => new SoulCampfireBlock(Identifier, Direction.West, false, false, true),
            20730 => new SoulCampfireBlock(Identifier, Direction.West, false, false, false),
            20731 => new SoulCampfireBlock(Identifier, Direction.East, true, true, true),
            20732 => new SoulCampfireBlock(Identifier, Direction.East, true, true, false),
            20733 => new SoulCampfireBlock(Identifier, Direction.East, true, false, true),
            20734 => new SoulCampfireBlock(Identifier, Direction.East, true, false, false),
            20735 => new SoulCampfireBlock(Identifier, Direction.East, false, true, true),
            20736 => new SoulCampfireBlock(Identifier, Direction.East, false, true, false),
            20737 => new SoulCampfireBlock(Identifier, Direction.East, false, false, true),
            20738 => new SoulCampfireBlock(Identifier, Direction.East, false, false, false),
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
