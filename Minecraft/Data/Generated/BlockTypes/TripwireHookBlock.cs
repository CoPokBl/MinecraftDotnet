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
    public int ProtocolId => 400;
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
                        true => 9382,
                        false => 9383,
                    },
                    Direction.South => Powered switch {
                        true => 9384,
                        false => 9385,
                    },
                    Direction.West => Powered switch {
                        true => 9386,
                        false => 9387,
                    },
                    Direction.East => Powered switch {
                        true => 9388,
                        false => 9389,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                false => Facing switch {
                    Direction.North => Powered switch {
                        true => 9390,
                        false => 9391,
                    },
                    Direction.South => Powered switch {
                        true => 9392,
                        false => 9393,
                    },
                    Direction.West => Powered switch {
                        true => 9394,
                        false => 9395,
                    },
                    Direction.East => Powered switch {
                        true => 9396,
                        false => 9397,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9382 => new TripwireHookBlock(Identifier, true, Direction.North, true),
            9383 => new TripwireHookBlock(Identifier, true, Direction.North, false),
            9384 => new TripwireHookBlock(Identifier, true, Direction.South, true),
            9385 => new TripwireHookBlock(Identifier, true, Direction.South, false),
            9386 => new TripwireHookBlock(Identifier, true, Direction.West, true),
            9387 => new TripwireHookBlock(Identifier, true, Direction.West, false),
            9388 => new TripwireHookBlock(Identifier, true, Direction.East, true),
            9389 => new TripwireHookBlock(Identifier, true, Direction.East, false),
            9390 => new TripwireHookBlock(Identifier, false, Direction.North, true),
            9391 => new TripwireHookBlock(Identifier, false, Direction.North, false),
            9392 => new TripwireHookBlock(Identifier, false, Direction.South, true),
            9393 => new TripwireHookBlock(Identifier, false, Direction.South, false),
            9394 => new TripwireHookBlock(Identifier, false, Direction.West, true),
            9395 => new TripwireHookBlock(Identifier, false, Direction.West, false),
            9396 => new TripwireHookBlock(Identifier, false, Direction.East, true),
            9397 => new TripwireHookBlock(Identifier, false, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Attached = properties.ChildrenMap.ContainsKey("attached") ? properties["attached"].GetString() == "true" : Attached,
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Powered = properties.ChildrenMap.ContainsKey("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("attached", Attached.ToString().ToLower()),
            new StringTag("facing", Facing.ToName()),
            new StringTag("powered", Powered.ToString().ToLower())
        );
    }
    
}
