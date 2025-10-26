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
    public int ProtocolId => 443;
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
                        true => 10521,
                        false => 10522,
                    },
                    Direction.South => Powered switch {
                        true => 10523,
                        false => 10524,
                    },
                    Direction.West => Powered switch {
                        true => 10525,
                        false => 10526,
                    },
                    Direction.East => Powered switch {
                        true => 10527,
                        false => 10528,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 10529,
                        false => 10530,
                    },
                    Direction.South => Powered switch {
                        true => 10531,
                        false => 10532,
                    },
                    Direction.West => Powered switch {
                        true => 10533,
                        false => 10534,
                    },
                    Direction.East => Powered switch {
                        true => 10535,
                        false => 10536,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 10537,
                        false => 10538,
                    },
                    Direction.South => Powered switch {
                        true => 10539,
                        false => 10540,
                    },
                    Direction.West => Powered switch {
                        true => 10541,
                        false => 10542,
                    },
                    Direction.East => Powered switch {
                        true => 10543,
                        false => 10544,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10521 => new BirchButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            10522 => new BirchButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            10523 => new BirchButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            10524 => new BirchButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            10525 => new BirchButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            10526 => new BirchButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            10527 => new BirchButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            10528 => new BirchButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            10529 => new BirchButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            10530 => new BirchButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            10531 => new BirchButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            10532 => new BirchButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            10533 => new BirchButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            10534 => new BirchButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            10535 => new BirchButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            10536 => new BirchButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            10537 => new BirchButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            10538 => new BirchButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            10539 => new BirchButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            10540 => new BirchButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            10541 => new BirchButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            10542 => new BirchButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            10543 => new BirchButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            10544 => new BirchButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
