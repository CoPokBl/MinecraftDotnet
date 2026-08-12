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
                        true => 10891,
                        false => 10892,
                    },
                    Direction.South => Powered switch {
                        true => 10893,
                        false => 10894,
                    },
                    Direction.West => Powered switch {
                        true => 10895,
                        false => 10896,
                    },
                    Direction.East => Powered switch {
                        true => 10897,
                        false => 10898,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 10899,
                        false => 10900,
                    },
                    Direction.South => Powered switch {
                        true => 10901,
                        false => 10902,
                    },
                    Direction.West => Powered switch {
                        true => 10903,
                        false => 10904,
                    },
                    Direction.East => Powered switch {
                        true => 10905,
                        false => 10906,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 10907,
                        false => 10908,
                    },
                    Direction.South => Powered switch {
                        true => 10909,
                        false => 10910,
                    },
                    Direction.West => Powered switch {
                        true => 10911,
                        false => 10912,
                    },
                    Direction.East => Powered switch {
                        true => 10913,
                        false => 10914,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10891 => new BambooButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            10892 => new BambooButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            10893 => new BambooButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            10894 => new BambooButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            10895 => new BambooButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            10896 => new BambooButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            10897 => new BambooButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            10898 => new BambooButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            10899 => new BambooButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            10900 => new BambooButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            10901 => new BambooButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            10902 => new BambooButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            10903 => new BambooButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            10904 => new BambooButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            10905 => new BambooButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            10906 => new BambooButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            10907 => new BambooButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            10908 => new BambooButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            10909 => new BambooButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            10910 => new BambooButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            10911 => new BambooButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            10912 => new BambooButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            10913 => new BambooButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            10914 => new BambooButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
