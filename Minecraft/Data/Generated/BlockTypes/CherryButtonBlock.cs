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
                        true => 10795,
                        false => 10796,
                    },
                    Direction.South => Powered switch {
                        true => 10797,
                        false => 10798,
                    },
                    Direction.West => Powered switch {
                        true => 10799,
                        false => 10800,
                    },
                    Direction.East => Powered switch {
                        true => 10801,
                        false => 10802,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 10803,
                        false => 10804,
                    },
                    Direction.South => Powered switch {
                        true => 10805,
                        false => 10806,
                    },
                    Direction.West => Powered switch {
                        true => 10807,
                        false => 10808,
                    },
                    Direction.East => Powered switch {
                        true => 10809,
                        false => 10810,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 10811,
                        false => 10812,
                    },
                    Direction.South => Powered switch {
                        true => 10813,
                        false => 10814,
                    },
                    Direction.West => Powered switch {
                        true => 10815,
                        false => 10816,
                    },
                    Direction.East => Powered switch {
                        true => 10817,
                        false => 10818,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10795 => new CherryButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            10796 => new CherryButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            10797 => new CherryButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            10798 => new CherryButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            10799 => new CherryButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            10800 => new CherryButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            10801 => new CherryButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            10802 => new CherryButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            10803 => new CherryButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            10804 => new CherryButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            10805 => new CherryButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            10806 => new CherryButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            10807 => new CherryButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            10808 => new CherryButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            10809 => new CherryButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            10810 => new CherryButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            10811 => new CherryButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            10812 => new CherryButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            10813 => new CherryButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            10814 => new CherryButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            10815 => new CherryButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            10816 => new CherryButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            10817 => new CherryButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            10818 => new CherryButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
