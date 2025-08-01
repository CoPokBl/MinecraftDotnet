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
    public int ProtocolId => 262;
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
                        true => 5926,
                        false => 5927,
                    },
                    Direction.South => Powered switch {
                        true => 5928,
                        false => 5929,
                    },
                    Direction.West => Powered switch {
                        true => 5930,
                        false => 5931,
                    },
                    Direction.East => Powered switch {
                        true => 5932,
                        false => 5933,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 5934,
                        false => 5935,
                    },
                    Direction.South => Powered switch {
                        true => 5936,
                        false => 5937,
                    },
                    Direction.West => Powered switch {
                        true => 5938,
                        false => 5939,
                    },
                    Direction.East => Powered switch {
                        true => 5940,
                        false => 5941,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 5942,
                        false => 5943,
                    },
                    Direction.South => Powered switch {
                        true => 5944,
                        false => 5945,
                    },
                    Direction.West => Powered switch {
                        true => 5946,
                        false => 5947,
                    },
                    Direction.East => Powered switch {
                        true => 5948,
                        false => 5949,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5926 => new StoneButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            5927 => new StoneButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            5928 => new StoneButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            5929 => new StoneButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            5930 => new StoneButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            5931 => new StoneButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            5932 => new StoneButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            5933 => new StoneButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            5934 => new StoneButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            5935 => new StoneButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            5936 => new StoneButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            5937 => new StoneButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            5938 => new StoneButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            5939 => new StoneButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            5940 => new StoneButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            5941 => new StoneButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            5942 => new StoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            5943 => new StoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            5944 => new StoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            5945 => new StoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            5946 => new StoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            5947 => new StoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            5948 => new StoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            5949 => new StoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
