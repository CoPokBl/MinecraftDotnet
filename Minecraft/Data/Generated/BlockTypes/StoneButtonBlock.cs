using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record StoneButtonBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock {
    public Identifier Category => "minecraft:button";
    public int ProtocolId => 274;
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
    public Identifier? Item => "minecraft:stone_button";
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
    public string TranslationKey => "block.minecraft.stone_button";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => Powered switch {
                        true => 6694,
                        false => 6695,
                    },
                    Direction.South => Powered switch {
                        true => 6696,
                        false => 6697,
                    },
                    Direction.West => Powered switch {
                        true => 6698,
                        false => 6699,
                    },
                    Direction.East => Powered switch {
                        true => 6700,
                        false => 6701,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 6702,
                        false => 6703,
                    },
                    Direction.South => Powered switch {
                        true => 6704,
                        false => 6705,
                    },
                    Direction.West => Powered switch {
                        true => 6706,
                        false => 6707,
                    },
                    Direction.East => Powered switch {
                        true => 6708,
                        false => 6709,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 6710,
                        false => 6711,
                    },
                    Direction.South => Powered switch {
                        true => 6712,
                        false => 6713,
                    },
                    Direction.West => Powered switch {
                        true => 6714,
                        false => 6715,
                    },
                    Direction.East => Powered switch {
                        true => 6716,
                        false => 6717,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6694 => new StoneButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            6695 => new StoneButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            6696 => new StoneButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            6697 => new StoneButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            6698 => new StoneButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            6699 => new StoneButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            6700 => new StoneButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            6701 => new StoneButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            6702 => new StoneButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            6703 => new StoneButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            6704 => new StoneButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            6705 => new StoneButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            6706 => new StoneButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            6707 => new StoneButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            6708 => new StoneButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            6709 => new StoneButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            6710 => new StoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            6711 => new StoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            6712 => new StoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            6713 => new StoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            6714 => new StoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            6715 => new StoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            6716 => new StoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            6717 => new StoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
