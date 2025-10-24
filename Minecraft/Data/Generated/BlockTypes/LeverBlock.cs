using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LeverBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock {
    public Identifier Category => "minecraft:lever";
    public int ProtocolId => 257;
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
    public Identifier? Item => "minecraft:lever";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.3125, 0.25, 0.625] -> [0.6875, 0.75, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => true;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 0;
    public string TranslationKey => "block.minecraft.lever";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => Powered switch {
                        true => 6570,
                        false => 6571,
                    },
                    Direction.South => Powered switch {
                        true => 6572,
                        false => 6573,
                    },
                    Direction.West => Powered switch {
                        true => 6574,
                        false => 6575,
                    },
                    Direction.East => Powered switch {
                        true => 6576,
                        false => 6577,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 6578,
                        false => 6579,
                    },
                    Direction.South => Powered switch {
                        true => 6580,
                        false => 6581,
                    },
                    Direction.West => Powered switch {
                        true => 6582,
                        false => 6583,
                    },
                    Direction.East => Powered switch {
                        true => 6584,
                        false => 6585,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 6586,
                        false => 6587,
                    },
                    Direction.South => Powered switch {
                        true => 6588,
                        false => 6589,
                    },
                    Direction.West => Powered switch {
                        true => 6590,
                        false => 6591,
                    },
                    Direction.East => Powered switch {
                        true => 6592,
                        false => 6593,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6570 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            6571 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            6572 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            6573 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            6574 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            6575 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            6576 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            6577 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            6578 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            6579 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            6580 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            6581 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            6582 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            6583 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            6584 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            6585 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            6586 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            6587 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            6588 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            6589 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            6590 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            6591 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            6592 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            6593 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Face = properties.ChildrenMap.ContainsKey("face") ? AttachDirectionExtensions.FromString(properties["face"].GetString()) : Face,
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Powered = properties.ChildrenMap.ContainsKey("powered") ? properties["powered"].GetString() == "true" : Powered,
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
