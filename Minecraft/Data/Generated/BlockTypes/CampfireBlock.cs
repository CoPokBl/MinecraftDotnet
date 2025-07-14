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
                            true => 19566,
                            false => 19567,
                        },
                        false => Waterlogged switch {
                            true => 19568,
                            false => 19569,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 19570,
                            false => 19571,
                        },
                        false => Waterlogged switch {
                            true => 19572,
                            false => 19573,
                        },
                    },
                },
                Direction.South => Lit switch {
                    true => SignalFire switch {
                        true => Waterlogged switch {
                            true => 19574,
                            false => 19575,
                        },
                        false => Waterlogged switch {
                            true => 19576,
                            false => 19577,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 19578,
                            false => 19579,
                        },
                        false => Waterlogged switch {
                            true => 19580,
                            false => 19581,
                        },
                    },
                },
                Direction.West => Lit switch {
                    true => SignalFire switch {
                        true => Waterlogged switch {
                            true => 19582,
                            false => 19583,
                        },
                        false => Waterlogged switch {
                            true => 19584,
                            false => 19585,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 19586,
                            false => 19587,
                        },
                        false => Waterlogged switch {
                            true => 19588,
                            false => 19589,
                        },
                    },
                },
                Direction.East => Lit switch {
                    true => SignalFire switch {
                        true => Waterlogged switch {
                            true => 19590,
                            false => 19591,
                        },
                        false => Waterlogged switch {
                            true => 19592,
                            false => 19593,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 19594,
                            false => 19595,
                        },
                        false => Waterlogged switch {
                            true => 19596,
                            false => 19597,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            19566 => new CampfireBlock(Identifier, Direction.North, true, true, true),
            19567 => new CampfireBlock(Identifier, Direction.North, true, true, false),
            19568 => new CampfireBlock(Identifier, Direction.North, true, false, true),
            19569 => new CampfireBlock(Identifier, Direction.North, true, false, false),
            19570 => new CampfireBlock(Identifier, Direction.North, false, true, true),
            19571 => new CampfireBlock(Identifier, Direction.North, false, true, false),
            19572 => new CampfireBlock(Identifier, Direction.North, false, false, true),
            19573 => new CampfireBlock(Identifier, Direction.North, false, false, false),
            19574 => new CampfireBlock(Identifier, Direction.South, true, true, true),
            19575 => new CampfireBlock(Identifier, Direction.South, true, true, false),
            19576 => new CampfireBlock(Identifier, Direction.South, true, false, true),
            19577 => new CampfireBlock(Identifier, Direction.South, true, false, false),
            19578 => new CampfireBlock(Identifier, Direction.South, false, true, true),
            19579 => new CampfireBlock(Identifier, Direction.South, false, true, false),
            19580 => new CampfireBlock(Identifier, Direction.South, false, false, true),
            19581 => new CampfireBlock(Identifier, Direction.South, false, false, false),
            19582 => new CampfireBlock(Identifier, Direction.West, true, true, true),
            19583 => new CampfireBlock(Identifier, Direction.West, true, true, false),
            19584 => new CampfireBlock(Identifier, Direction.West, true, false, true),
            19585 => new CampfireBlock(Identifier, Direction.West, true, false, false),
            19586 => new CampfireBlock(Identifier, Direction.West, false, true, true),
            19587 => new CampfireBlock(Identifier, Direction.West, false, true, false),
            19588 => new CampfireBlock(Identifier, Direction.West, false, false, true),
            19589 => new CampfireBlock(Identifier, Direction.West, false, false, false),
            19590 => new CampfireBlock(Identifier, Direction.East, true, true, true),
            19591 => new CampfireBlock(Identifier, Direction.East, true, true, false),
            19592 => new CampfireBlock(Identifier, Direction.East, true, false, true),
            19593 => new CampfireBlock(Identifier, Direction.East, true, false, false),
            19594 => new CampfireBlock(Identifier, Direction.East, false, true, true),
            19595 => new CampfireBlock(Identifier, Direction.East, false, true, false),
            19596 => new CampfireBlock(Identifier, Direction.East, false, false, true),
            19597 => new CampfireBlock(Identifier, Direction.East, false, false, false),
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
    
}
