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
                        true => 10843,
                        false => 10844,
                    },
                    Direction.South => Powered switch {
                        true => 10845,
                        false => 10846,
                    },
                    Direction.West => Powered switch {
                        true => 10847,
                        false => 10848,
                    },
                    Direction.East => Powered switch {
                        true => 10849,
                        false => 10850,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 10851,
                        false => 10852,
                    },
                    Direction.South => Powered switch {
                        true => 10853,
                        false => 10854,
                    },
                    Direction.West => Powered switch {
                        true => 10855,
                        false => 10856,
                    },
                    Direction.East => Powered switch {
                        true => 10857,
                        false => 10858,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 10859,
                        false => 10860,
                    },
                    Direction.South => Powered switch {
                        true => 10861,
                        false => 10862,
                    },
                    Direction.West => Powered switch {
                        true => 10863,
                        false => 10864,
                    },
                    Direction.East => Powered switch {
                        true => 10865,
                        false => 10866,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10843 => new PaleOakButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            10844 => new PaleOakButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            10845 => new PaleOakButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            10846 => new PaleOakButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            10847 => new PaleOakButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            10848 => new PaleOakButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            10849 => new PaleOakButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            10850 => new PaleOakButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            10851 => new PaleOakButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            10852 => new PaleOakButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            10853 => new PaleOakButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            10854 => new PaleOakButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            10855 => new PaleOakButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            10856 => new PaleOakButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            10857 => new PaleOakButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            10858 => new PaleOakButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            10859 => new PaleOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            10860 => new PaleOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            10861 => new PaleOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            10862 => new PaleOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            10863 => new PaleOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            10864 => new PaleOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            10865 => new PaleOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            10866 => new PaleOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
