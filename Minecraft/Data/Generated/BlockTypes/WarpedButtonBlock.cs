using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WarpedButtonBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock {

    public Identifier Category => "minecraft:button";
    public int ProtocolId => 858;
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
    public string SoundType => "nether_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:warped_button";
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
    public string TranslationKey => "block.minecraft.warped_button";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => Powered switch {
                        true => 20179,
                        false => 20180,
                    },
                    Direction.South => Powered switch {
                        true => 20181,
                        false => 20182,
                    },
                    Direction.West => Powered switch {
                        true => 20183,
                        false => 20184,
                    },
                    Direction.East => Powered switch {
                        true => 20185,
                        false => 20186,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 20187,
                        false => 20188,
                    },
                    Direction.South => Powered switch {
                        true => 20189,
                        false => 20190,
                    },
                    Direction.West => Powered switch {
                        true => 20191,
                        false => 20192,
                    },
                    Direction.East => Powered switch {
                        true => 20193,
                        false => 20194,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 20195,
                        false => 20196,
                    },
                    Direction.South => Powered switch {
                        true => 20197,
                        false => 20198,
                    },
                    Direction.West => Powered switch {
                        true => 20199,
                        false => 20200,
                    },
                    Direction.East => Powered switch {
                        true => 20201,
                        false => 20202,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20179 => new WarpedButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            20180 => new WarpedButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            20181 => new WarpedButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            20182 => new WarpedButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            20183 => new WarpedButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            20184 => new WarpedButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            20185 => new WarpedButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            20186 => new WarpedButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            20187 => new WarpedButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            20188 => new WarpedButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            20189 => new WarpedButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            20190 => new WarpedButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            20191 => new WarpedButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            20192 => new WarpedButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            20193 => new WarpedButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            20194 => new WarpedButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            20195 => new WarpedButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            20196 => new WarpedButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            20197 => new WarpedButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            20198 => new WarpedButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            20199 => new WarpedButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            20200 => new WarpedButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            20201 => new WarpedButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            20202 => new WarpedButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
