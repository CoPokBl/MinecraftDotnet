using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MangroveButtonBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock {
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
    public Identifier? Item => "minecraft:mangrove_button";
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
    public string TranslationKey => "block.minecraft.mangrove_button";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => Powered switch {
                        true => 10867,
                        false => 10868,
                    },
                    Direction.South => Powered switch {
                        true => 10869,
                        false => 10870,
                    },
                    Direction.West => Powered switch {
                        true => 10871,
                        false => 10872,
                    },
                    Direction.East => Powered switch {
                        true => 10873,
                        false => 10874,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 10875,
                        false => 10876,
                    },
                    Direction.South => Powered switch {
                        true => 10877,
                        false => 10878,
                    },
                    Direction.West => Powered switch {
                        true => 10879,
                        false => 10880,
                    },
                    Direction.East => Powered switch {
                        true => 10881,
                        false => 10882,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 10883,
                        false => 10884,
                    },
                    Direction.South => Powered switch {
                        true => 10885,
                        false => 10886,
                    },
                    Direction.West => Powered switch {
                        true => 10887,
                        false => 10888,
                    },
                    Direction.East => Powered switch {
                        true => 10889,
                        false => 10890,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10867 => new MangroveButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            10868 => new MangroveButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            10869 => new MangroveButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            10870 => new MangroveButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            10871 => new MangroveButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            10872 => new MangroveButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            10873 => new MangroveButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            10874 => new MangroveButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            10875 => new MangroveButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            10876 => new MangroveButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            10877 => new MangroveButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            10878 => new MangroveButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            10879 => new MangroveButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            10880 => new MangroveButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            10881 => new MangroveButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            10882 => new MangroveButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            10883 => new MangroveButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            10884 => new MangroveButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            10885 => new MangroveButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            10886 => new MangroveButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            10887 => new MangroveButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            10888 => new MangroveButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            10889 => new MangroveButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            10890 => new MangroveButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
