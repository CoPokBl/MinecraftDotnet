using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PaleOakButtonBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock {

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
    public Identifier? Item => "minecraft:pale_oak_button";
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
    public string TranslationKey => "block.minecraft.pale_oak_button";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => Powered switch {
                        true => 9564,
                        false => 9565,
                    },
                    Direction.South => Powered switch {
                        true => 9566,
                        false => 9567,
                    },
                    Direction.West => Powered switch {
                        true => 9568,
                        false => 9569,
                    },
                    Direction.East => Powered switch {
                        true => 9570,
                        false => 9571,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 9572,
                        false => 9573,
                    },
                    Direction.South => Powered switch {
                        true => 9574,
                        false => 9575,
                    },
                    Direction.West => Powered switch {
                        true => 9576,
                        false => 9577,
                    },
                    Direction.East => Powered switch {
                        true => 9578,
                        false => 9579,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 9580,
                        false => 9581,
                    },
                    Direction.South => Powered switch {
                        true => 9582,
                        false => 9583,
                    },
                    Direction.West => Powered switch {
                        true => 9584,
                        false => 9585,
                    },
                    Direction.East => Powered switch {
                        true => 9586,
                        false => 9587,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9564 => new PaleOakButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            9565 => new PaleOakButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            9566 => new PaleOakButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            9567 => new PaleOakButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            9568 => new PaleOakButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            9569 => new PaleOakButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            9570 => new PaleOakButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            9571 => new PaleOakButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            9572 => new PaleOakButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            9573 => new PaleOakButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            9574 => new PaleOakButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            9575 => new PaleOakButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            9576 => new PaleOakButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            9577 => new PaleOakButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            9578 => new PaleOakButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            9579 => new PaleOakButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            9580 => new PaleOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            9581 => new PaleOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            9582 => new PaleOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            9583 => new PaleOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            9584 => new PaleOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            9585 => new PaleOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            9586 => new PaleOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            9587 => new PaleOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
