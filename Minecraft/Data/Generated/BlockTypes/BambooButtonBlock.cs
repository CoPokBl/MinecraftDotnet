using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BambooButtonBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock {

    public Identifier Category => "minecraft:button";
    public int ProtocolId => 420;
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
    public string SoundType => "bamboo_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:bamboo_button";
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
    public string TranslationKey => "block.minecraft.bamboo_button";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => Powered switch {
                        true => 9612,
                        false => 9613,
                    },
                    Direction.South => Powered switch {
                        true => 9614,
                        false => 9615,
                    },
                    Direction.West => Powered switch {
                        true => 9616,
                        false => 9617,
                    },
                    Direction.East => Powered switch {
                        true => 9618,
                        false => 9619,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 9620,
                        false => 9621,
                    },
                    Direction.South => Powered switch {
                        true => 9622,
                        false => 9623,
                    },
                    Direction.West => Powered switch {
                        true => 9624,
                        false => 9625,
                    },
                    Direction.East => Powered switch {
                        true => 9626,
                        false => 9627,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 9628,
                        false => 9629,
                    },
                    Direction.South => Powered switch {
                        true => 9630,
                        false => 9631,
                    },
                    Direction.West => Powered switch {
                        true => 9632,
                        false => 9633,
                    },
                    Direction.East => Powered switch {
                        true => 9634,
                        false => 9635,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9612 => new BambooButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            9613 => new BambooButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            9614 => new BambooButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            9615 => new BambooButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            9616 => new BambooButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            9617 => new BambooButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            9618 => new BambooButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            9619 => new BambooButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            9620 => new BambooButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            9621 => new BambooButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            9622 => new BambooButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            9623 => new BambooButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            9624 => new BambooButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            9625 => new BambooButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            9626 => new BambooButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            9627 => new BambooButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            9628 => new BambooButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            9629 => new BambooButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            9630 => new BambooButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            9631 => new BambooButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            9632 => new BambooButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            9633 => new BambooButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            9634 => new BambooButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            9635 => new BambooButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
