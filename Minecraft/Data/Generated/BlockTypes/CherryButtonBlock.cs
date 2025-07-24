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
    public int ProtocolId => 416;
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
                        true => 9516,
                        false => 9517,
                    },
                    Direction.South => Powered switch {
                        true => 9518,
                        false => 9519,
                    },
                    Direction.West => Powered switch {
                        true => 9520,
                        false => 9521,
                    },
                    Direction.East => Powered switch {
                        true => 9522,
                        false => 9523,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 9524,
                        false => 9525,
                    },
                    Direction.South => Powered switch {
                        true => 9526,
                        false => 9527,
                    },
                    Direction.West => Powered switch {
                        true => 9528,
                        false => 9529,
                    },
                    Direction.East => Powered switch {
                        true => 9530,
                        false => 9531,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 9532,
                        false => 9533,
                    },
                    Direction.South => Powered switch {
                        true => 9534,
                        false => 9535,
                    },
                    Direction.West => Powered switch {
                        true => 9536,
                        false => 9537,
                    },
                    Direction.East => Powered switch {
                        true => 9538,
                        false => 9539,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9516 => new CherryButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            9517 => new CherryButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            9518 => new CherryButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            9519 => new CherryButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            9520 => new CherryButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            9521 => new CherryButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            9522 => new CherryButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            9523 => new CherryButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            9524 => new CherryButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            9525 => new CherryButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            9526 => new CherryButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            9527 => new CherryButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            9528 => new CherryButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            9529 => new CherryButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            9530 => new CherryButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            9531 => new CherryButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            9532 => new CherryButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            9533 => new CherryButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            9534 => new CherryButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            9535 => new CherryButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            9536 => new CherryButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            9537 => new CherryButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            9538 => new CherryButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            9539 => new CherryButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
