using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record StoneButtonBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock {
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
    public string SoundType => "stone";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:stone_button";
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
    public string TranslationKey => "block.minecraft.stone_button";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => Powered switch {
                        true => 6895,
                        false => 6896,
                    },
                    Direction.South => Powered switch {
                        true => 6897,
                        false => 6898,
                    },
                    Direction.West => Powered switch {
                        true => 6899,
                        false => 6900,
                    },
                    Direction.East => Powered switch {
                        true => 6901,
                        false => 6902,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 6903,
                        false => 6904,
                    },
                    Direction.South => Powered switch {
                        true => 6905,
                        false => 6906,
                    },
                    Direction.West => Powered switch {
                        true => 6907,
                        false => 6908,
                    },
                    Direction.East => Powered switch {
                        true => 6909,
                        false => 6910,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 6911,
                        false => 6912,
                    },
                    Direction.South => Powered switch {
                        true => 6913,
                        false => 6914,
                    },
                    Direction.West => Powered switch {
                        true => 6915,
                        false => 6916,
                    },
                    Direction.East => Powered switch {
                        true => 6917,
                        false => 6918,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6895 => new StoneButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            6896 => new StoneButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            6897 => new StoneButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            6898 => new StoneButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            6899 => new StoneButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            6900 => new StoneButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            6901 => new StoneButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            6902 => new StoneButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            6903 => new StoneButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            6904 => new StoneButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            6905 => new StoneButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            6906 => new StoneButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            6907 => new StoneButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            6908 => new StoneButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            6909 => new StoneButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            6910 => new StoneButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            6911 => new StoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            6912 => new StoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            6913 => new StoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            6914 => new StoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            6915 => new StoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            6916 => new StoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            6917 => new StoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            6918 => new StoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
