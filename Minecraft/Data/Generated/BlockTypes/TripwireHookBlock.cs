using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record TripwireHookBlock(Identifier Identifier, bool Attached, Direction Facing, bool Powered) : IBlock {
    public Identifier Category => "minecraft:trip_wire_hook";
    public double Hardness => 0;
    public double ExplosionResistance => 0;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:tripwire_hook";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.3125, 0.0, 0.625] -> [0.6875, 0.625, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => true;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 0;
    public string TranslationKey => "block.minecraft.tripwire_hook";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Attached switch {
                true => Facing switch {
                    Direction.North => Powered switch {
                        true => 9583,
                        false => 9584,
                    },
                    Direction.South => Powered switch {
                        true => 9585,
                        false => 9586,
                    },
                    Direction.West => Powered switch {
                        true => 9587,
                        false => 9588,
                    },
                    Direction.East => Powered switch {
                        true => 9589,
                        false => 9590,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                false => Facing switch {
                    Direction.North => Powered switch {
                        true => 9591,
                        false => 9592,
                    },
                    Direction.South => Powered switch {
                        true => 9593,
                        false => 9594,
                    },
                    Direction.West => Powered switch {
                        true => 9595,
                        false => 9596,
                    },
                    Direction.East => Powered switch {
                        true => 9597,
                        false => 9598,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9583 => new TripwireHookBlock(Identifier, true, Direction.North, true),
            9584 => new TripwireHookBlock(Identifier, true, Direction.North, false),
            9585 => new TripwireHookBlock(Identifier, true, Direction.South, true),
            9586 => new TripwireHookBlock(Identifier, true, Direction.South, false),
            9587 => new TripwireHookBlock(Identifier, true, Direction.West, true),
            9588 => new TripwireHookBlock(Identifier, true, Direction.West, false),
            9589 => new TripwireHookBlock(Identifier, true, Direction.East, true),
            9590 => new TripwireHookBlock(Identifier, true, Direction.East, false),
            9591 => new TripwireHookBlock(Identifier, false, Direction.North, true),
            9592 => new TripwireHookBlock(Identifier, false, Direction.North, false),
            9593 => new TripwireHookBlock(Identifier, false, Direction.South, true),
            9594 => new TripwireHookBlock(Identifier, false, Direction.South, false),
            9595 => new TripwireHookBlock(Identifier, false, Direction.West, true),
            9596 => new TripwireHookBlock(Identifier, false, Direction.West, false),
            9597 => new TripwireHookBlock(Identifier, false, Direction.East, true),
            9598 => new TripwireHookBlock(Identifier, false, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Attached = properties.Contains("attached") ? properties["attached"].GetString() == "true" : Attached,
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("attached", new StringTag(Attached.ToString().ToLower())),
            ("facing", new StringTag(Facing.ToName())),
            ("powered", new StringTag(Powered.ToString().ToLower()))
        );
    }
    
}
