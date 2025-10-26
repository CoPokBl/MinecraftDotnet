using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PaleOakButtonBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock {
    public Identifier Category => "minecraft:button";
    public int ProtocolId => 448;
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
    public Identifier? Item => "minecraft:pale_oak_button";
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
    public string TranslationKey => "block.minecraft.pale_oak_button";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => Powered switch {
                        true => 10641,
                        false => 10642,
                    },
                    Direction.South => Powered switch {
                        true => 10643,
                        false => 10644,
                    },
                    Direction.West => Powered switch {
                        true => 10645,
                        false => 10646,
                    },
                    Direction.East => Powered switch {
                        true => 10647,
                        false => 10648,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 10649,
                        false => 10650,
                    },
                    Direction.South => Powered switch {
                        true => 10651,
                        false => 10652,
                    },
                    Direction.West => Powered switch {
                        true => 10653,
                        false => 10654,
                    },
                    Direction.East => Powered switch {
                        true => 10655,
                        false => 10656,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 10657,
                        false => 10658,
                    },
                    Direction.South => Powered switch {
                        true => 10659,
                        false => 10660,
                    },
                    Direction.West => Powered switch {
                        true => 10661,
                        false => 10662,
                    },
                    Direction.East => Powered switch {
                        true => 10663,
                        false => 10664,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10641 => new PaleOakButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            10642 => new PaleOakButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            10643 => new PaleOakButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            10644 => new PaleOakButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            10645 => new PaleOakButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            10646 => new PaleOakButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            10647 => new PaleOakButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            10648 => new PaleOakButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            10649 => new PaleOakButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            10650 => new PaleOakButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            10651 => new PaleOakButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            10652 => new PaleOakButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            10653 => new PaleOakButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            10654 => new PaleOakButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            10655 => new PaleOakButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            10656 => new PaleOakButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            10657 => new PaleOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            10658 => new PaleOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            10659 => new PaleOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            10660 => new PaleOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            10661 => new PaleOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            10662 => new PaleOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            10663 => new PaleOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            10664 => new PaleOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
