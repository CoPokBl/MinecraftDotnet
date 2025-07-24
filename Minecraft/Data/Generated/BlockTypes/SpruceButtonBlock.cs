using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SpruceButtonBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock {

    public Identifier Category => "minecraft:button";
    public int ProtocolId => 412;
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
    public Identifier? Item => "minecraft:spruce_button";
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
    public string TranslationKey => "block.minecraft.spruce_button";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => Powered switch {
                        true => 9420,
                        false => 9421,
                    },
                    Direction.South => Powered switch {
                        true => 9422,
                        false => 9423,
                    },
                    Direction.West => Powered switch {
                        true => 9424,
                        false => 9425,
                    },
                    Direction.East => Powered switch {
                        true => 9426,
                        false => 9427,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 9428,
                        false => 9429,
                    },
                    Direction.South => Powered switch {
                        true => 9430,
                        false => 9431,
                    },
                    Direction.West => Powered switch {
                        true => 9432,
                        false => 9433,
                    },
                    Direction.East => Powered switch {
                        true => 9434,
                        false => 9435,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 9436,
                        false => 9437,
                    },
                    Direction.South => Powered switch {
                        true => 9438,
                        false => 9439,
                    },
                    Direction.West => Powered switch {
                        true => 9440,
                        false => 9441,
                    },
                    Direction.East => Powered switch {
                        true => 9442,
                        false => 9443,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9420 => new SpruceButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            9421 => new SpruceButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            9422 => new SpruceButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            9423 => new SpruceButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            9424 => new SpruceButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            9425 => new SpruceButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            9426 => new SpruceButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            9427 => new SpruceButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            9428 => new SpruceButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            9429 => new SpruceButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            9430 => new SpruceButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            9431 => new SpruceButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            9432 => new SpruceButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            9433 => new SpruceButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            9434 => new SpruceButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            9435 => new SpruceButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            9436 => new SpruceButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            9437 => new SpruceButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            9438 => new SpruceButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            9439 => new SpruceButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            9440 => new SpruceButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            9441 => new SpruceButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            9442 => new SpruceButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            9443 => new SpruceButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
    
}
