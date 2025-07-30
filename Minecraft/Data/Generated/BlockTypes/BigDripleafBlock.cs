using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BigDripleafBlock(Identifier Identifier, Direction Facing, BigDripleafBlock.Tilt TiltValue, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:big_dripleaf";
    public int ProtocolId => 1054;
    public double Hardness => 0.1;
    public double ExplosionResistance => 0.1;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "big_dripleaf";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:big_dripleaf";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.3125, 0.0, 0.5625] -> [0.6875, 0.9375, 0.9375], AABB[0.0, 0.6875, 0.0] -> [0.3125, 0.9375, 1.0], AABB[0.3125, 0.6875, 0.0] -> [1.0, 0.9375, 0.5625], AABB[0.3125, 0.6875, 0.9375] -> [1.0, 0.9375, 1.0], AABB[0.6875, 0.6875, 0.5625] -> [1.0, 0.9375, 0.9375]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.6875, 0.0] -> [1.0, 0.9375, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.3125, 0.0, 0.5625] -> [0.6875, 0.9375, 0.9375], AABB[0.0, 0.6875, 0.0] -> [0.3125, 0.9375, 1.0], AABB[0.3125, 0.6875, 0.0] -> [1.0, 0.9375, 0.5625], AABB[0.3125, 0.6875, 0.9375] -> [1.0, 0.9375, 1.0], AABB[0.6875, 0.6875, 0.5625] -> [1.0, 0.9375, 0.9375]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.6875, 0.0] -> [1.0, 0.9375, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 7;
    public string TranslationKey => "block.minecraft.big_dripleaf";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => TiltValue switch {
                    Tilt.None => Waterlogged switch {
                        true => 25936,
                        false => 25937,
                    },
                    Tilt.Unstable => Waterlogged switch {
                        true => 25938,
                        false => 25939,
                    },
                    Tilt.Partial => Waterlogged switch {
                        true => 25940,
                        false => 25941,
                    },
                    Tilt.Full => Waterlogged switch {
                        true => 25942,
                        false => 25943,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(TiltValue), TiltValue, "Unknown value for property tilt.")
                },
                Direction.South => TiltValue switch {
                    Tilt.None => Waterlogged switch {
                        true => 25944,
                        false => 25945,
                    },
                    Tilt.Unstable => Waterlogged switch {
                        true => 25946,
                        false => 25947,
                    },
                    Tilt.Partial => Waterlogged switch {
                        true => 25948,
                        false => 25949,
                    },
                    Tilt.Full => Waterlogged switch {
                        true => 25950,
                        false => 25951,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(TiltValue), TiltValue, "Unknown value for property tilt.")
                },
                Direction.West => TiltValue switch {
                    Tilt.None => Waterlogged switch {
                        true => 25952,
                        false => 25953,
                    },
                    Tilt.Unstable => Waterlogged switch {
                        true => 25954,
                        false => 25955,
                    },
                    Tilt.Partial => Waterlogged switch {
                        true => 25956,
                        false => 25957,
                    },
                    Tilt.Full => Waterlogged switch {
                        true => 25958,
                        false => 25959,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(TiltValue), TiltValue, "Unknown value for property tilt.")
                },
                Direction.East => TiltValue switch {
                    Tilt.None => Waterlogged switch {
                        true => 25960,
                        false => 25961,
                    },
                    Tilt.Unstable => Waterlogged switch {
                        true => 25962,
                        false => 25963,
                    },
                    Tilt.Partial => Waterlogged switch {
                        true => 25964,
                        false => 25965,
                    },
                    Tilt.Full => Waterlogged switch {
                        true => 25966,
                        false => 25967,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(TiltValue), TiltValue, "Unknown value for property tilt.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            25936 => new BigDripleafBlock(Identifier, Direction.North, Tilt.None, true),
            25937 => new BigDripleafBlock(Identifier, Direction.North, Tilt.None, false),
            25938 => new BigDripleafBlock(Identifier, Direction.North, Tilt.Unstable, true),
            25939 => new BigDripleafBlock(Identifier, Direction.North, Tilt.Unstable, false),
            25940 => new BigDripleafBlock(Identifier, Direction.North, Tilt.Partial, true),
            25941 => new BigDripleafBlock(Identifier, Direction.North, Tilt.Partial, false),
            25942 => new BigDripleafBlock(Identifier, Direction.North, Tilt.Full, true),
            25943 => new BigDripleafBlock(Identifier, Direction.North, Tilt.Full, false),
            25944 => new BigDripleafBlock(Identifier, Direction.South, Tilt.None, true),
            25945 => new BigDripleafBlock(Identifier, Direction.South, Tilt.None, false),
            25946 => new BigDripleafBlock(Identifier, Direction.South, Tilt.Unstable, true),
            25947 => new BigDripleafBlock(Identifier, Direction.South, Tilt.Unstable, false),
            25948 => new BigDripleafBlock(Identifier, Direction.South, Tilt.Partial, true),
            25949 => new BigDripleafBlock(Identifier, Direction.South, Tilt.Partial, false),
            25950 => new BigDripleafBlock(Identifier, Direction.South, Tilt.Full, true),
            25951 => new BigDripleafBlock(Identifier, Direction.South, Tilt.Full, false),
            25952 => new BigDripleafBlock(Identifier, Direction.West, Tilt.None, true),
            25953 => new BigDripleafBlock(Identifier, Direction.West, Tilt.None, false),
            25954 => new BigDripleafBlock(Identifier, Direction.West, Tilt.Unstable, true),
            25955 => new BigDripleafBlock(Identifier, Direction.West, Tilt.Unstable, false),
            25956 => new BigDripleafBlock(Identifier, Direction.West, Tilt.Partial, true),
            25957 => new BigDripleafBlock(Identifier, Direction.West, Tilt.Partial, false),
            25958 => new BigDripleafBlock(Identifier, Direction.West, Tilt.Full, true),
            25959 => new BigDripleafBlock(Identifier, Direction.West, Tilt.Full, false),
            25960 => new BigDripleafBlock(Identifier, Direction.East, Tilt.None, true),
            25961 => new BigDripleafBlock(Identifier, Direction.East, Tilt.None, false),
            25962 => new BigDripleafBlock(Identifier, Direction.East, Tilt.Unstable, true),
            25963 => new BigDripleafBlock(Identifier, Direction.East, Tilt.Unstable, false),
            25964 => new BigDripleafBlock(Identifier, Direction.East, Tilt.Partial, true),
            25965 => new BigDripleafBlock(Identifier, Direction.East, Tilt.Partial, false),
            25966 => new BigDripleafBlock(Identifier, Direction.East, Tilt.Full, true),
            25967 => new BigDripleafBlock(Identifier, Direction.East, Tilt.Full, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            TiltValue = TiltFromString(properties["tilt"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
                        new StringTag("facing", Facing.ToName()),
            new StringTag("tilt", TiltToName(TiltValue)),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
        );
    }
    
    public enum Tilt {
        None,
        Unstable,
        Partial,
        Full,
    }

    public static Tilt TiltFromString(string value) {
        return value switch {
            "none" => Tilt.None,
            "unstable" => Tilt.Unstable,
            "partial" => Tilt.Partial,
            "full" => Tilt.Full,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Tilt.")
        };
    }

    public static string TiltToName(Tilt value) {
        return value switch {
            Tilt.None => "none",
            Tilt.Unstable => "unstable",
            Tilt.Partial => "partial",
            Tilt.Full => "full",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Tilt value.")
        };
    }
}
