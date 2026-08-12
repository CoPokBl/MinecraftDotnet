using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record JungleButtonBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock {
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
    public Identifier? Item => "minecraft:jungle_button";
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
    public string TranslationKey => "block.minecraft.jungle_button";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => Powered switch {
                        true => 10747,
                        false => 10748,
                    },
                    Direction.South => Powered switch {
                        true => 10749,
                        false => 10750,
                    },
                    Direction.West => Powered switch {
                        true => 10751,
                        false => 10752,
                    },
                    Direction.East => Powered switch {
                        true => 10753,
                        false => 10754,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 10755,
                        false => 10756,
                    },
                    Direction.South => Powered switch {
                        true => 10757,
                        false => 10758,
                    },
                    Direction.West => Powered switch {
                        true => 10759,
                        false => 10760,
                    },
                    Direction.East => Powered switch {
                        true => 10761,
                        false => 10762,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 10763,
                        false => 10764,
                    },
                    Direction.South => Powered switch {
                        true => 10765,
                        false => 10766,
                    },
                    Direction.West => Powered switch {
                        true => 10767,
                        false => 10768,
                    },
                    Direction.East => Powered switch {
                        true => 10769,
                        false => 10770,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10747 => new JungleButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            10748 => new JungleButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            10749 => new JungleButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            10750 => new JungleButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            10751 => new JungleButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            10752 => new JungleButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            10753 => new JungleButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            10754 => new JungleButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            10755 => new JungleButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            10756 => new JungleButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            10757 => new JungleButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            10758 => new JungleButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            10759 => new JungleButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            10760 => new JungleButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            10761 => new JungleButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            10762 => new JungleButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            10763 => new JungleButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            10764 => new JungleButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            10765 => new JungleButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            10766 => new JungleButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            10767 => new JungleButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            10768 => new JungleButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            10769 => new JungleButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            10770 => new JungleButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
