using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DarkOakButtonBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock {
    public Identifier Category => "minecraft:button";
    public int ProtocolId => 447;
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
    public Identifier? Item => "minecraft:dark_oak_button";
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
    public string TranslationKey => "block.minecraft.dark_oak_button";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => Powered switch {
                        true => 10617,
                        false => 10618,
                    },
                    Direction.South => Powered switch {
                        true => 10619,
                        false => 10620,
                    },
                    Direction.West => Powered switch {
                        true => 10621,
                        false => 10622,
                    },
                    Direction.East => Powered switch {
                        true => 10623,
                        false => 10624,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 10625,
                        false => 10626,
                    },
                    Direction.South => Powered switch {
                        true => 10627,
                        false => 10628,
                    },
                    Direction.West => Powered switch {
                        true => 10629,
                        false => 10630,
                    },
                    Direction.East => Powered switch {
                        true => 10631,
                        false => 10632,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 10633,
                        false => 10634,
                    },
                    Direction.South => Powered switch {
                        true => 10635,
                        false => 10636,
                    },
                    Direction.West => Powered switch {
                        true => 10637,
                        false => 10638,
                    },
                    Direction.East => Powered switch {
                        true => 10639,
                        false => 10640,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10617 => new DarkOakButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            10618 => new DarkOakButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            10619 => new DarkOakButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            10620 => new DarkOakButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            10621 => new DarkOakButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            10622 => new DarkOakButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            10623 => new DarkOakButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            10624 => new DarkOakButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            10625 => new DarkOakButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            10626 => new DarkOakButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            10627 => new DarkOakButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            10628 => new DarkOakButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            10629 => new DarkOakButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            10630 => new DarkOakButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            10631 => new DarkOakButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            10632 => new DarkOakButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            10633 => new DarkOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            10634 => new DarkOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            10635 => new DarkOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            10636 => new DarkOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            10637 => new DarkOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            10638 => new DarkOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            10639 => new DarkOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            10640 => new DarkOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
