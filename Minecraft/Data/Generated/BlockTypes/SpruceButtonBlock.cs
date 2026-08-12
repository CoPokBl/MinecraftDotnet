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
                        true => 10699,
                        false => 10700,
                    },
                    Direction.South => Powered switch {
                        true => 10701,
                        false => 10702,
                    },
                    Direction.West => Powered switch {
                        true => 10703,
                        false => 10704,
                    },
                    Direction.East => Powered switch {
                        true => 10705,
                        false => 10706,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 10707,
                        false => 10708,
                    },
                    Direction.South => Powered switch {
                        true => 10709,
                        false => 10710,
                    },
                    Direction.West => Powered switch {
                        true => 10711,
                        false => 10712,
                    },
                    Direction.East => Powered switch {
                        true => 10713,
                        false => 10714,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 10715,
                        false => 10716,
                    },
                    Direction.South => Powered switch {
                        true => 10717,
                        false => 10718,
                    },
                    Direction.West => Powered switch {
                        true => 10719,
                        false => 10720,
                    },
                    Direction.East => Powered switch {
                        true => 10721,
                        false => 10722,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10699 => new SpruceButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            10700 => new SpruceButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            10701 => new SpruceButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            10702 => new SpruceButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            10703 => new SpruceButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            10704 => new SpruceButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            10705 => new SpruceButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            10706 => new SpruceButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            10707 => new SpruceButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            10708 => new SpruceButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            10709 => new SpruceButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            10710 => new SpruceButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            10711 => new SpruceButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            10712 => new SpruceButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            10713 => new SpruceButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            10714 => new SpruceButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            10715 => new SpruceButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            10716 => new SpruceButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            10717 => new SpruceButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            10718 => new SpruceButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            10719 => new SpruceButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            10720 => new SpruceButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            10721 => new SpruceButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            10722 => new SpruceButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Face = properties.Contains("face") ? AttachDirectionExtensions.FromString(properties["face"].GetString()) : Face,
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("face", new StringTag(Face.ToName())),
            ("facing", new StringTag(Facing.ToName())),
            ("powered", new StringTag(Powered.ToString().ToLower()))
        );
    }
    
}
