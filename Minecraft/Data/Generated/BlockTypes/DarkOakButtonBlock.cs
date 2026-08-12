using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DarkOakButtonBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock {
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
    public Identifier? Item => "minecraft:dark_oak_button";
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
    public string TranslationKey => "block.minecraft.dark_oak_button";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => Powered switch {
                        true => 10819,
                        false => 10820,
                    },
                    Direction.South => Powered switch {
                        true => 10821,
                        false => 10822,
                    },
                    Direction.West => Powered switch {
                        true => 10823,
                        false => 10824,
                    },
                    Direction.East => Powered switch {
                        true => 10825,
                        false => 10826,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 10827,
                        false => 10828,
                    },
                    Direction.South => Powered switch {
                        true => 10829,
                        false => 10830,
                    },
                    Direction.West => Powered switch {
                        true => 10831,
                        false => 10832,
                    },
                    Direction.East => Powered switch {
                        true => 10833,
                        false => 10834,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 10835,
                        false => 10836,
                    },
                    Direction.South => Powered switch {
                        true => 10837,
                        false => 10838,
                    },
                    Direction.West => Powered switch {
                        true => 10839,
                        false => 10840,
                    },
                    Direction.East => Powered switch {
                        true => 10841,
                        false => 10842,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10819 => new DarkOakButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            10820 => new DarkOakButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            10821 => new DarkOakButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            10822 => new DarkOakButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            10823 => new DarkOakButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            10824 => new DarkOakButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            10825 => new DarkOakButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            10826 => new DarkOakButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            10827 => new DarkOakButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            10828 => new DarkOakButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            10829 => new DarkOakButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            10830 => new DarkOakButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            10831 => new DarkOakButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            10832 => new DarkOakButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            10833 => new DarkOakButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            10834 => new DarkOakButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            10835 => new DarkOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            10836 => new DarkOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            10837 => new DarkOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            10838 => new DarkOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            10839 => new DarkOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            10840 => new DarkOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            10841 => new DarkOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            10842 => new DarkOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
