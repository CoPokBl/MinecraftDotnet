using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CrimsonButtonBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock {
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
    public string SoundType => "nether_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:crimson_button";
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
    public string TranslationKey => "block.minecraft.crimson_button";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => Powered switch {
                        true => 21466,
                        false => 21467,
                    },
                    Direction.South => Powered switch {
                        true => 21468,
                        false => 21469,
                    },
                    Direction.West => Powered switch {
                        true => 21470,
                        false => 21471,
                    },
                    Direction.East => Powered switch {
                        true => 21472,
                        false => 21473,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 21474,
                        false => 21475,
                    },
                    Direction.South => Powered switch {
                        true => 21476,
                        false => 21477,
                    },
                    Direction.West => Powered switch {
                        true => 21478,
                        false => 21479,
                    },
                    Direction.East => Powered switch {
                        true => 21480,
                        false => 21481,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 21482,
                        false => 21483,
                    },
                    Direction.South => Powered switch {
                        true => 21484,
                        false => 21485,
                    },
                    Direction.West => Powered switch {
                        true => 21486,
                        false => 21487,
                    },
                    Direction.East => Powered switch {
                        true => 21488,
                        false => 21489,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21466 => new CrimsonButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            21467 => new CrimsonButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            21468 => new CrimsonButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            21469 => new CrimsonButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            21470 => new CrimsonButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            21471 => new CrimsonButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            21472 => new CrimsonButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            21473 => new CrimsonButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            21474 => new CrimsonButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            21475 => new CrimsonButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            21476 => new CrimsonButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            21477 => new CrimsonButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            21478 => new CrimsonButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            21479 => new CrimsonButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            21480 => new CrimsonButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            21481 => new CrimsonButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            21482 => new CrimsonButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            21483 => new CrimsonButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            21484 => new CrimsonButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            21485 => new CrimsonButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            21486 => new CrimsonButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            21487 => new CrimsonButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            21488 => new CrimsonButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            21489 => new CrimsonButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
