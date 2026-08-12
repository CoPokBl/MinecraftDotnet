using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LeverBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock {
    public Identifier Category => "minecraft:lever";
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
    public string SoundType => "stone";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:lever";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.3125, 0.25, 0.625] -> [0.6875, 0.75, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => true;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 0;
    public string TranslationKey => "block.minecraft.lever";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => Powered switch {
                        true => 6771,
                        false => 6772,
                    },
                    Direction.South => Powered switch {
                        true => 6773,
                        false => 6774,
                    },
                    Direction.West => Powered switch {
                        true => 6775,
                        false => 6776,
                    },
                    Direction.East => Powered switch {
                        true => 6777,
                        false => 6778,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 6779,
                        false => 6780,
                    },
                    Direction.South => Powered switch {
                        true => 6781,
                        false => 6782,
                    },
                    Direction.West => Powered switch {
                        true => 6783,
                        false => 6784,
                    },
                    Direction.East => Powered switch {
                        true => 6785,
                        false => 6786,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 6787,
                        false => 6788,
                    },
                    Direction.South => Powered switch {
                        true => 6789,
                        false => 6790,
                    },
                    Direction.West => Powered switch {
                        true => 6791,
                        false => 6792,
                    },
                    Direction.East => Powered switch {
                        true => 6793,
                        false => 6794,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6771 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            6772 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            6773 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            6774 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            6775 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            6776 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            6777 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            6778 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            6779 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            6780 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            6781 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            6782 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            6783 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            6784 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            6785 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            6786 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            6787 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            6788 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            6789 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            6790 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            6791 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            6792 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            6793 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            6794 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
