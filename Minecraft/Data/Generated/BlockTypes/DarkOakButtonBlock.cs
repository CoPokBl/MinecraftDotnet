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
    public int ProtocolId => 417;
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
                        true => 9540,
                        false => 9541,
                    },
                    Direction.South => Powered switch {
                        true => 9542,
                        false => 9543,
                    },
                    Direction.West => Powered switch {
                        true => 9544,
                        false => 9545,
                    },
                    Direction.East => Powered switch {
                        true => 9546,
                        false => 9547,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 9548,
                        false => 9549,
                    },
                    Direction.South => Powered switch {
                        true => 9550,
                        false => 9551,
                    },
                    Direction.West => Powered switch {
                        true => 9552,
                        false => 9553,
                    },
                    Direction.East => Powered switch {
                        true => 9554,
                        false => 9555,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 9556,
                        false => 9557,
                    },
                    Direction.South => Powered switch {
                        true => 9558,
                        false => 9559,
                    },
                    Direction.West => Powered switch {
                        true => 9560,
                        false => 9561,
                    },
                    Direction.East => Powered switch {
                        true => 9562,
                        false => 9563,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9540 => new DarkOakButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            9541 => new DarkOakButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            9542 => new DarkOakButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            9543 => new DarkOakButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            9544 => new DarkOakButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            9545 => new DarkOakButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            9546 => new DarkOakButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            9547 => new DarkOakButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            9548 => new DarkOakButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            9549 => new DarkOakButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            9550 => new DarkOakButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            9551 => new DarkOakButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            9552 => new DarkOakButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            9553 => new DarkOakButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            9554 => new DarkOakButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            9555 => new DarkOakButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            9556 => new DarkOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            9557 => new DarkOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            9558 => new DarkOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            9559 => new DarkOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            9560 => new DarkOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            9561 => new DarkOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            9562 => new DarkOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            9563 => new DarkOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Face = AttachDirectionExtensions.FromString(properties["face"].GetString()),
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            Powered = properties["powered"].GetString() == "true",
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
