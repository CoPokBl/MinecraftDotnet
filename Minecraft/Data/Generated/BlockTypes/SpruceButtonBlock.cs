using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SpruceButtonBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock {
    public Identifier Category => "minecraft:button";
    public int ProtocolId => 442;
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
    public Identifier? Item => "minecraft:spruce_button";
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
    public string TranslationKey => "block.minecraft.spruce_button";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => Powered switch {
                        true => 10497,
                        false => 10498,
                    },
                    Direction.South => Powered switch {
                        true => 10499,
                        false => 10500,
                    },
                    Direction.West => Powered switch {
                        true => 10501,
                        false => 10502,
                    },
                    Direction.East => Powered switch {
                        true => 10503,
                        false => 10504,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 10505,
                        false => 10506,
                    },
                    Direction.South => Powered switch {
                        true => 10507,
                        false => 10508,
                    },
                    Direction.West => Powered switch {
                        true => 10509,
                        false => 10510,
                    },
                    Direction.East => Powered switch {
                        true => 10511,
                        false => 10512,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 10513,
                        false => 10514,
                    },
                    Direction.South => Powered switch {
                        true => 10515,
                        false => 10516,
                    },
                    Direction.West => Powered switch {
                        true => 10517,
                        false => 10518,
                    },
                    Direction.East => Powered switch {
                        true => 10519,
                        false => 10520,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10497 => new SpruceButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            10498 => new SpruceButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            10499 => new SpruceButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            10500 => new SpruceButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            10501 => new SpruceButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            10502 => new SpruceButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            10503 => new SpruceButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            10504 => new SpruceButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            10505 => new SpruceButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            10506 => new SpruceButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            10507 => new SpruceButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            10508 => new SpruceButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            10509 => new SpruceButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            10510 => new SpruceButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            10511 => new SpruceButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            10512 => new SpruceButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            10513 => new SpruceButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            10514 => new SpruceButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            10515 => new SpruceButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            10516 => new SpruceButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            10517 => new SpruceButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            10518 => new SpruceButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            10519 => new SpruceButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            10520 => new SpruceButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
