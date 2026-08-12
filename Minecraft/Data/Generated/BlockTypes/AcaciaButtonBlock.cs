using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record AcaciaButtonBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock {
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
    public Identifier? Item => "minecraft:acacia_button";
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
    public string TranslationKey => "block.minecraft.acacia_button";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => Powered switch {
                        true => 10771,
                        false => 10772,
                    },
                    Direction.South => Powered switch {
                        true => 10773,
                        false => 10774,
                    },
                    Direction.West => Powered switch {
                        true => 10775,
                        false => 10776,
                    },
                    Direction.East => Powered switch {
                        true => 10777,
                        false => 10778,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 10779,
                        false => 10780,
                    },
                    Direction.South => Powered switch {
                        true => 10781,
                        false => 10782,
                    },
                    Direction.West => Powered switch {
                        true => 10783,
                        false => 10784,
                    },
                    Direction.East => Powered switch {
                        true => 10785,
                        false => 10786,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 10787,
                        false => 10788,
                    },
                    Direction.South => Powered switch {
                        true => 10789,
                        false => 10790,
                    },
                    Direction.West => Powered switch {
                        true => 10791,
                        false => 10792,
                    },
                    Direction.East => Powered switch {
                        true => 10793,
                        false => 10794,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10771 => new AcaciaButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            10772 => new AcaciaButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            10773 => new AcaciaButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            10774 => new AcaciaButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            10775 => new AcaciaButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            10776 => new AcaciaButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            10777 => new AcaciaButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            10778 => new AcaciaButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            10779 => new AcaciaButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            10780 => new AcaciaButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            10781 => new AcaciaButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            10782 => new AcaciaButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            10783 => new AcaciaButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            10784 => new AcaciaButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            10785 => new AcaciaButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            10786 => new AcaciaButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            10787 => new AcaciaButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            10788 => new AcaciaButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            10789 => new AcaciaButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            10790 => new AcaciaButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            10791 => new AcaciaButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            10792 => new AcaciaButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            10793 => new AcaciaButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            10794 => new AcaciaButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
