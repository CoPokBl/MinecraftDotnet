using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BirchButtonBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock {
    public Identifier Category => "minecraft:button";
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
    public string SoundType => "wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:birch_button";
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
    public string TranslationKey => "block.minecraft.birch_button";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => Powered switch {
                        true => 10723,
                        false => 10724,
                    },
                    Direction.South => Powered switch {
                        true => 10725,
                        false => 10726,
                    },
                    Direction.West => Powered switch {
                        true => 10727,
                        false => 10728,
                    },
                    Direction.East => Powered switch {
                        true => 10729,
                        false => 10730,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 10731,
                        false => 10732,
                    },
                    Direction.South => Powered switch {
                        true => 10733,
                        false => 10734,
                    },
                    Direction.West => Powered switch {
                        true => 10735,
                        false => 10736,
                    },
                    Direction.East => Powered switch {
                        true => 10737,
                        false => 10738,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 10739,
                        false => 10740,
                    },
                    Direction.South => Powered switch {
                        true => 10741,
                        false => 10742,
                    },
                    Direction.West => Powered switch {
                        true => 10743,
                        false => 10744,
                    },
                    Direction.East => Powered switch {
                        true => 10745,
                        false => 10746,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10723 => new BirchButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            10724 => new BirchButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            10725 => new BirchButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            10726 => new BirchButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            10727 => new BirchButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            10728 => new BirchButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            10729 => new BirchButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            10730 => new BirchButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            10731 => new BirchButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            10732 => new BirchButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            10733 => new BirchButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            10734 => new BirchButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            10735 => new BirchButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            10736 => new BirchButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            10737 => new BirchButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            10738 => new BirchButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            10739 => new BirchButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            10740 => new BirchButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            10741 => new BirchButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            10742 => new BirchButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            10743 => new BirchButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            10744 => new BirchButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            10745 => new BirchButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            10746 => new BirchButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Face = properties.Contains("face") ? AttachDirectionExtensions.FromString(properties["face"].GetString()) : Face,
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("face", new StringTag(Face.ToName())),
            ("facing", new StringTag(Facing.ToName())),
            ("powered", new StringTag(Powered.ToString().ToLower()))
        );
    }
    
}
