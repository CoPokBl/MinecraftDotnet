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
    public int ProtocolId => 820;
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
                            true => 19598,
                            false => 19599,
                        },
                        false => Waterlogged switch {
                            true => 19600,
                            false => 19601,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 19602,
                            false => 19603,
                        },
                        false => Waterlogged switch {
                            true => 19604,
                            false => 19605,
                        },
                    },
                },
                Direction.South => Lit switch {
                    true => SignalFire switch {
                        true => Waterlogged switch {
                            true => 19606,
                            false => 19607,
                        },
                        false => Waterlogged switch {
                            true => 19608,
                            false => 19609,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 19610,
                            false => 19611,
                        },
                        false => Waterlogged switch {
                            true => 19612,
                            false => 19613,
                        },
                    },
                },
                Direction.West => Lit switch {
                    true => SignalFire switch {
                        true => Waterlogged switch {
                            true => 19614,
                            false => 19615,
                        },
                        false => Waterlogged switch {
                            true => 19616,
                            false => 19617,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 19618,
                            false => 19619,
                        },
                        false => Waterlogged switch {
                            true => 19620,
                            false => 19621,
                        },
                    },
                },
                Direction.East => Lit switch {
                    true => SignalFire switch {
                        true => Waterlogged switch {
                            true => 19622,
                            false => 19623,
                        },
                        false => Waterlogged switch {
                            true => 19624,
                            false => 19625,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 19626,
                            false => 19627,
                        },
                        false => Waterlogged switch {
                            true => 19628,
                            false => 19629,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            19598 => new SoulCampfireBlock(Identifier, Direction.North, true, true, true),
            19599 => new SoulCampfireBlock(Identifier, Direction.North, true, true, false),
            19600 => new SoulCampfireBlock(Identifier, Direction.North, true, false, true),
            19601 => new SoulCampfireBlock(Identifier, Direction.North, true, false, false),
            19602 => new SoulCampfireBlock(Identifier, Direction.North, false, true, true),
            19603 => new SoulCampfireBlock(Identifier, Direction.North, false, true, false),
            19604 => new SoulCampfireBlock(Identifier, Direction.North, false, false, true),
            19605 => new SoulCampfireBlock(Identifier, Direction.North, false, false, false),
            19606 => new SoulCampfireBlock(Identifier, Direction.South, true, true, true),
            19607 => new SoulCampfireBlock(Identifier, Direction.South, true, true, false),
            19608 => new SoulCampfireBlock(Identifier, Direction.South, true, false, true),
            19609 => new SoulCampfireBlock(Identifier, Direction.South, true, false, false),
            19610 => new SoulCampfireBlock(Identifier, Direction.South, false, true, true),
            19611 => new SoulCampfireBlock(Identifier, Direction.South, false, true, false),
            19612 => new SoulCampfireBlock(Identifier, Direction.South, false, false, true),
            19613 => new SoulCampfireBlock(Identifier, Direction.South, false, false, false),
            19614 => new SoulCampfireBlock(Identifier, Direction.West, true, true, true),
            19615 => new SoulCampfireBlock(Identifier, Direction.West, true, true, false),
            19616 => new SoulCampfireBlock(Identifier, Direction.West, true, false, true),
            19617 => new SoulCampfireBlock(Identifier, Direction.West, true, false, false),
            19618 => new SoulCampfireBlock(Identifier, Direction.West, false, true, true),
            19619 => new SoulCampfireBlock(Identifier, Direction.West, false, true, false),
            19620 => new SoulCampfireBlock(Identifier, Direction.West, false, false, true),
            19621 => new SoulCampfireBlock(Identifier, Direction.West, false, false, false),
            19622 => new SoulCampfireBlock(Identifier, Direction.East, true, true, true),
            19623 => new SoulCampfireBlock(Identifier, Direction.East, true, true, false),
            19624 => new SoulCampfireBlock(Identifier, Direction.East, true, false, true),
            19625 => new SoulCampfireBlock(Identifier, Direction.East, true, false, false),
            19626 => new SoulCampfireBlock(Identifier, Direction.East, false, true, true),
            19627 => new SoulCampfireBlock(Identifier, Direction.East, false, true, false),
            19628 => new SoulCampfireBlock(Identifier, Direction.East, false, false, true),
            19629 => new SoulCampfireBlock(Identifier, Direction.East, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            Lit = properties["lit"].GetString() == "true",
            SignalFire = properties["signal_fire"].GetString() == "true",
            Waterlogged = properties["waterlogged"].GetString() == "true",
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
