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
    public int ProtocolId => 411;
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
                        true => 9396,
                        false => 9397,
                    },
                    Direction.South => Powered switch {
                        true => 9398,
                        false => 9399,
                    },
                    Direction.West => Powered switch {
                        true => 9400,
                        false => 9401,
                    },
                    Direction.East => Powered switch {
                        true => 9402,
                        false => 9403,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 9404,
                        false => 9405,
                    },
                    Direction.South => Powered switch {
                        true => 9406,
                        false => 9407,
                    },
                    Direction.West => Powered switch {
                        true => 9408,
                        false => 9409,
                    },
                    Direction.East => Powered switch {
                        true => 9410,
                        false => 9411,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 9412,
                        false => 9413,
                    },
                    Direction.South => Powered switch {
                        true => 9414,
                        false => 9415,
                    },
                    Direction.West => Powered switch {
                        true => 9416,
                        false => 9417,
                    },
                    Direction.East => Powered switch {
                        true => 9418,
                        false => 9419,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9396 => new OakButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            9397 => new OakButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            9398 => new OakButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            9399 => new OakButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            9400 => new OakButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            9401 => new OakButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            9402 => new OakButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            9403 => new OakButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            9404 => new OakButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            9405 => new OakButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            9406 => new OakButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            9407 => new OakButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            9408 => new OakButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            9409 => new OakButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            9410 => new OakButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            9411 => new OakButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            9412 => new OakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            9413 => new OakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            9414 => new OakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            9415 => new OakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            9416 => new OakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            9417 => new OakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            9418 => new OakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            9419 => new OakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
