using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OakButtonBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock {
    public Identifier Category => "minecraft:button";
    public int ProtocolId => 441;
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
    public Identifier? Item => "minecraft:oak_button";
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
    public string TranslationKey => "block.minecraft.oak_button";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => Powered switch {
                        true => 10473,
                        false => 10474,
                    },
                    Direction.South => Powered switch {
                        true => 10475,
                        false => 10476,
                    },
                    Direction.West => Powered switch {
                        true => 10477,
                        false => 10478,
                    },
                    Direction.East => Powered switch {
                        true => 10479,
                        false => 10480,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 10481,
                        false => 10482,
                    },
                    Direction.South => Powered switch {
                        true => 10483,
                        false => 10484,
                    },
                    Direction.West => Powered switch {
                        true => 10485,
                        false => 10486,
                    },
                    Direction.East => Powered switch {
                        true => 10487,
                        false => 10488,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 10489,
                        false => 10490,
                    },
                    Direction.South => Powered switch {
                        true => 10491,
                        false => 10492,
                    },
                    Direction.West => Powered switch {
                        true => 10493,
                        false => 10494,
                    },
                    Direction.East => Powered switch {
                        true => 10495,
                        false => 10496,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10473 => new OakButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            10474 => new OakButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            10475 => new OakButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            10476 => new OakButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            10477 => new OakButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            10478 => new OakButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            10479 => new OakButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            10480 => new OakButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            10481 => new OakButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            10482 => new OakButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            10483 => new OakButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            10484 => new OakButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            10485 => new OakButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            10486 => new OakButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            10487 => new OakButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            10488 => new OakButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            10489 => new OakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            10490 => new OakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            10491 => new OakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            10492 => new OakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            10493 => new OakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            10494 => new OakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            10495 => new OakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            10496 => new OakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
