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
    public int ProtocolId => 419;
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
                        true => 9588,
                        false => 9589,
                    },
                    Direction.South => Powered switch {
                        true => 9590,
                        false => 9591,
                    },
                    Direction.West => Powered switch {
                        true => 9592,
                        false => 9593,
                    },
                    Direction.East => Powered switch {
                        true => 9594,
                        false => 9595,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 9596,
                        false => 9597,
                    },
                    Direction.South => Powered switch {
                        true => 9598,
                        false => 9599,
                    },
                    Direction.West => Powered switch {
                        true => 9600,
                        false => 9601,
                    },
                    Direction.East => Powered switch {
                        true => 9602,
                        false => 9603,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 9604,
                        false => 9605,
                    },
                    Direction.South => Powered switch {
                        true => 9606,
                        false => 9607,
                    },
                    Direction.West => Powered switch {
                        true => 9608,
                        false => 9609,
                    },
                    Direction.East => Powered switch {
                        true => 9610,
                        false => 9611,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9588 => new MangroveButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            9589 => new MangroveButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            9590 => new MangroveButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            9591 => new MangroveButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            9592 => new MangroveButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            9593 => new MangroveButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            9594 => new MangroveButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            9595 => new MangroveButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            9596 => new MangroveButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            9597 => new MangroveButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            9598 => new MangroveButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            9599 => new MangroveButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            9600 => new MangroveButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            9601 => new MangroveButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            9602 => new MangroveButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            9603 => new MangroveButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            9604 => new MangroveButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            9605 => new MangroveButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            9606 => new MangroveButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            9607 => new MangroveButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            9608 => new MangroveButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            9609 => new MangroveButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            9610 => new MangroveButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            9611 => new MangroveButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
