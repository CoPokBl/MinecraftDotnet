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
    public int ProtocolId => 449;
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
                        true => 10665,
                        false => 10666,
                    },
                    Direction.South => Powered switch {
                        true => 10667,
                        false => 10668,
                    },
                    Direction.West => Powered switch {
                        true => 10669,
                        false => 10670,
                    },
                    Direction.East => Powered switch {
                        true => 10671,
                        false => 10672,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 10673,
                        false => 10674,
                    },
                    Direction.South => Powered switch {
                        true => 10675,
                        false => 10676,
                    },
                    Direction.West => Powered switch {
                        true => 10677,
                        false => 10678,
                    },
                    Direction.East => Powered switch {
                        true => 10679,
                        false => 10680,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 10681,
                        false => 10682,
                    },
                    Direction.South => Powered switch {
                        true => 10683,
                        false => 10684,
                    },
                    Direction.West => Powered switch {
                        true => 10685,
                        false => 10686,
                    },
                    Direction.East => Powered switch {
                        true => 10687,
                        false => 10688,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10665 => new MangroveButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            10666 => new MangroveButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            10667 => new MangroveButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            10668 => new MangroveButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            10669 => new MangroveButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            10670 => new MangroveButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            10671 => new MangroveButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            10672 => new MangroveButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            10673 => new MangroveButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            10674 => new MangroveButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            10675 => new MangroveButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            10676 => new MangroveButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            10677 => new MangroveButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            10678 => new MangroveButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            10679 => new MangroveButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            10680 => new MangroveButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            10681 => new MangroveButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            10682 => new MangroveButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            10683 => new MangroveButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            10684 => new MangroveButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            10685 => new MangroveButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            10686 => new MangroveButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            10687 => new MangroveButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            10688 => new MangroveButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
