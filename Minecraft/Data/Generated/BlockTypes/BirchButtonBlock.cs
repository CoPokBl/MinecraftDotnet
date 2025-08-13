using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BirchButtonBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock {
    public Identifier Category => "minecraft:button";
    public int ProtocolId => 413;
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
    public Identifier? Item => "minecraft:birch_button";
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
    public string TranslationKey => "block.minecraft.birch_button";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => Powered switch {
                        true => 9444,
                        false => 9445,
                    },
                    Direction.South => Powered switch {
                        true => 9446,
                        false => 9447,
                    },
                    Direction.West => Powered switch {
                        true => 9448,
                        false => 9449,
                    },
                    Direction.East => Powered switch {
                        true => 9450,
                        false => 9451,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 9452,
                        false => 9453,
                    },
                    Direction.South => Powered switch {
                        true => 9454,
                        false => 9455,
                    },
                    Direction.West => Powered switch {
                        true => 9456,
                        false => 9457,
                    },
                    Direction.East => Powered switch {
                        true => 9458,
                        false => 9459,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 9460,
                        false => 9461,
                    },
                    Direction.South => Powered switch {
                        true => 9462,
                        false => 9463,
                    },
                    Direction.West => Powered switch {
                        true => 9464,
                        false => 9465,
                    },
                    Direction.East => Powered switch {
                        true => 9466,
                        false => 9467,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9444 => new BirchButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            9445 => new BirchButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            9446 => new BirchButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            9447 => new BirchButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            9448 => new BirchButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            9449 => new BirchButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            9450 => new BirchButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            9451 => new BirchButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            9452 => new BirchButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            9453 => new BirchButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            9454 => new BirchButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            9455 => new BirchButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            9456 => new BirchButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            9457 => new BirchButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            9458 => new BirchButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            9459 => new BirchButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            9460 => new BirchButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            9461 => new BirchButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            9462 => new BirchButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            9463 => new BirchButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            9464 => new BirchButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            9465 => new BirchButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            9466 => new BirchButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            9467 => new BirchButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
