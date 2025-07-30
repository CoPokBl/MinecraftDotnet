using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedBlackstoneButtonBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock {

    public Identifier Category => "minecraft:button";
    public int ProtocolId => 899;
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
    public string SoundType => "stone";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:polished_blackstone_button";
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
    public string TranslationKey => "block.minecraft.polished_blackstone_button";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => Powered switch {
                        true => 21434,
                        false => 21435,
                    },
                    Direction.South => Powered switch {
                        true => 21436,
                        false => 21437,
                    },
                    Direction.West => Powered switch {
                        true => 21438,
                        false => 21439,
                    },
                    Direction.East => Powered switch {
                        true => 21440,
                        false => 21441,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 21442,
                        false => 21443,
                    },
                    Direction.South => Powered switch {
                        true => 21444,
                        false => 21445,
                    },
                    Direction.West => Powered switch {
                        true => 21446,
                        false => 21447,
                    },
                    Direction.East => Powered switch {
                        true => 21448,
                        false => 21449,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 21450,
                        false => 21451,
                    },
                    Direction.South => Powered switch {
                        true => 21452,
                        false => 21453,
                    },
                    Direction.West => Powered switch {
                        true => 21454,
                        false => 21455,
                    },
                    Direction.East => Powered switch {
                        true => 21456,
                        false => 21457,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21434 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            21435 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            21436 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            21437 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            21438 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            21439 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            21440 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            21441 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            21442 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            21443 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            21444 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            21445 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            21446 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            21447 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            21448 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            21449 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            21450 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            21451 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            21452 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            21453 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            21454 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            21455 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            21456 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            21457 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
