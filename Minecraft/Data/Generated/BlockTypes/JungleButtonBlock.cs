using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record JungleButtonBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock {
    public Identifier Category => "minecraft:button";
    public int ProtocolId => 444;
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
    public Identifier? Item => "minecraft:jungle_button";
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
    public string TranslationKey => "block.minecraft.jungle_button";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => Powered switch {
                        true => 10545,
                        false => 10546,
                    },
                    Direction.South => Powered switch {
                        true => 10547,
                        false => 10548,
                    },
                    Direction.West => Powered switch {
                        true => 10549,
                        false => 10550,
                    },
                    Direction.East => Powered switch {
                        true => 10551,
                        false => 10552,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 10553,
                        false => 10554,
                    },
                    Direction.South => Powered switch {
                        true => 10555,
                        false => 10556,
                    },
                    Direction.West => Powered switch {
                        true => 10557,
                        false => 10558,
                    },
                    Direction.East => Powered switch {
                        true => 10559,
                        false => 10560,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 10561,
                        false => 10562,
                    },
                    Direction.South => Powered switch {
                        true => 10563,
                        false => 10564,
                    },
                    Direction.West => Powered switch {
                        true => 10565,
                        false => 10566,
                    },
                    Direction.East => Powered switch {
                        true => 10567,
                        false => 10568,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10545 => new JungleButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            10546 => new JungleButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            10547 => new JungleButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            10548 => new JungleButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            10549 => new JungleButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            10550 => new JungleButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            10551 => new JungleButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            10552 => new JungleButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            10553 => new JungleButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            10554 => new JungleButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            10555 => new JungleButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            10556 => new JungleButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            10557 => new JungleButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            10558 => new JungleButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            10559 => new JungleButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            10560 => new JungleButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            10561 => new JungleButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            10562 => new JungleButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            10563 => new JungleButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            10564 => new JungleButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            10565 => new JungleButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            10566 => new JungleButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            10567 => new JungleButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            10568 => new JungleButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
