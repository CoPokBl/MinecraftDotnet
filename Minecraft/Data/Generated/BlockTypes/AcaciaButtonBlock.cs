using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record AcaciaButtonBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock {
    public Identifier Category => "minecraft:button";
    public int ProtocolId => 415;
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
    public Identifier? Item => "minecraft:acacia_button";
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
    public string TranslationKey => "block.minecraft.acacia_button";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => Powered switch {
                        true => 9492,
                        false => 9493,
                    },
                    Direction.South => Powered switch {
                        true => 9494,
                        false => 9495,
                    },
                    Direction.West => Powered switch {
                        true => 9496,
                        false => 9497,
                    },
                    Direction.East => Powered switch {
                        true => 9498,
                        false => 9499,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 9500,
                        false => 9501,
                    },
                    Direction.South => Powered switch {
                        true => 9502,
                        false => 9503,
                    },
                    Direction.West => Powered switch {
                        true => 9504,
                        false => 9505,
                    },
                    Direction.East => Powered switch {
                        true => 9506,
                        false => 9507,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 9508,
                        false => 9509,
                    },
                    Direction.South => Powered switch {
                        true => 9510,
                        false => 9511,
                    },
                    Direction.West => Powered switch {
                        true => 9512,
                        false => 9513,
                    },
                    Direction.East => Powered switch {
                        true => 9514,
                        false => 9515,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9492 => new AcaciaButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            9493 => new AcaciaButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            9494 => new AcaciaButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            9495 => new AcaciaButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            9496 => new AcaciaButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            9497 => new AcaciaButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            9498 => new AcaciaButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            9499 => new AcaciaButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            9500 => new AcaciaButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            9501 => new AcaciaButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            9502 => new AcaciaButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            9503 => new AcaciaButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            9504 => new AcaciaButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            9505 => new AcaciaButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            9506 => new AcaciaButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            9507 => new AcaciaButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            9508 => new AcaciaButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            9509 => new AcaciaButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            9510 => new AcaciaButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            9511 => new AcaciaButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            9512 => new AcaciaButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            9513 => new AcaciaButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            9514 => new AcaciaButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            9515 => new AcaciaButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
