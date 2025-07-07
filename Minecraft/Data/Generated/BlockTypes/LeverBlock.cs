using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LeverBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock {

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
    public Identifier? Item => "minecraft:lever";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.3125, 0.25, 0.625] -> [0.6875, 0.75, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => true;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 0;
    public string TranslationKey => "block.minecraft.lever";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => Powered switch {
                        true => 5802,
                        false => 5803,
                    },
                    Direction.South => Powered switch {
                        true => 5804,
                        false => 5805,
                    },
                    Direction.West => Powered switch {
                        true => 5806,
                        false => 5807,
                    },
                    Direction.East => Powered switch {
                        true => 5808,
                        false => 5809,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 5810,
                        false => 5811,
                    },
                    Direction.South => Powered switch {
                        true => 5812,
                        false => 5813,
                    },
                    Direction.West => Powered switch {
                        true => 5814,
                        false => 5815,
                    },
                    Direction.East => Powered switch {
                        true => 5816,
                        false => 5817,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 5818,
                        false => 5819,
                    },
                    Direction.South => Powered switch {
                        true => 5820,
                        false => 5821,
                    },
                    Direction.West => Powered switch {
                        true => 5822,
                        false => 5823,
                    },
                    Direction.East => Powered switch {
                        true => 5824,
                        false => 5825,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5802 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            5803 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            5804 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            5805 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            5806 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            5807 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            5808 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            5809 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            5810 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            5811 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            5812 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            5813 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            5814 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            5815 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            5816 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            5817 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            5818 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            5819 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            5820 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            5821 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            5822 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            5823 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            5824 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            5825 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
    
}
