using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CherryButtonBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock {
    public Identifier Category => "minecraft:button";
    public int ProtocolId => 446;
    public double Hardness => 0.5;
    public double ExplosionResistance => 0.5;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "cherry_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:cherry_button";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.3125, 0.375, 0.875] -> [0.6875, 0.625, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => true;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 0;
    public string TranslationKey => "block.minecraft.cherry_button";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => Powered switch {
                        true => 10593,
                        false => 10594,
                    },
                    Direction.South => Powered switch {
                        true => 10595,
                        false => 10596,
                    },
                    Direction.West => Powered switch {
                        true => 10597,
                        false => 10598,
                    },
                    Direction.East => Powered switch {
                        true => 10599,
                        false => 10600,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 10601,
                        false => 10602,
                    },
                    Direction.South => Powered switch {
                        true => 10603,
                        false => 10604,
                    },
                    Direction.West => Powered switch {
                        true => 10605,
                        false => 10606,
                    },
                    Direction.East => Powered switch {
                        true => 10607,
                        false => 10608,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 10609,
                        false => 10610,
                    },
                    Direction.South => Powered switch {
                        true => 10611,
                        false => 10612,
                    },
                    Direction.West => Powered switch {
                        true => 10613,
                        false => 10614,
                    },
                    Direction.East => Powered switch {
                        true => 10615,
                        false => 10616,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10593 => new CherryButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            10594 => new CherryButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            10595 => new CherryButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            10596 => new CherryButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            10597 => new CherryButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            10598 => new CherryButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            10599 => new CherryButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            10600 => new CherryButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            10601 => new CherryButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            10602 => new CherryButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            10603 => new CherryButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            10604 => new CherryButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            10605 => new CherryButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            10606 => new CherryButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            10607 => new CherryButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            10608 => new CherryButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            10609 => new CherryButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            10610 => new CherryButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            10611 => new CherryButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            10612 => new CherryButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            10613 => new CherryButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            10614 => new CherryButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            10615 => new CherryButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            10616 => new CherryButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Face = properties.ChildrenMap.ContainsKey("face") ? AttachDirectionExtensions.FromString(properties["face"].GetString()) : Face,
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Powered = properties.ChildrenMap.ContainsKey("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("face", Face.ToName()),
            new StringTag("facing", Facing.ToName()),
            new StringTag("powered", Powered.ToString().ToLower())
        );
    }
    
}
