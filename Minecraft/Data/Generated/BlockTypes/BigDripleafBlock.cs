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
                        true => 30356,
                        false => 30357,
                    },
                    Tilt.Unstable => Waterlogged switch {
                        true => 30358,
                        false => 30359,
                    },
                    Tilt.Partial => Waterlogged switch {
                        true => 30360,
                        false => 30361,
                    },
                    Tilt.Full => Waterlogged switch {
                        true => 30362,
                        false => 30363,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(TiltValue), TiltValue, "Unknown value for property tilt.")
                },
                Direction.South => TiltValue switch {
                    Tilt.None => Waterlogged switch {
                        true => 30364,
                        false => 30365,
                    },
                    Tilt.Unstable => Waterlogged switch {
                        true => 30366,
                        false => 30367,
                    },
                    Tilt.Partial => Waterlogged switch {
                        true => 30368,
                        false => 30369,
                    },
                    Tilt.Full => Waterlogged switch {
                        true => 30370,
                        false => 30371,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(TiltValue), TiltValue, "Unknown value for property tilt.")
                },
                Direction.West => TiltValue switch {
                    Tilt.None => Waterlogged switch {
                        true => 30372,
                        false => 30373,
                    },
                    Tilt.Unstable => Waterlogged switch {
                        true => 30374,
                        false => 30375,
                    },
                    Tilt.Partial => Waterlogged switch {
                        true => 30376,
                        false => 30377,
                    },
                    Tilt.Full => Waterlogged switch {
                        true => 30378,
                        false => 30379,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(TiltValue), TiltValue, "Unknown value for property tilt.")
                },
                Direction.East => TiltValue switch {
                    Tilt.None => Waterlogged switch {
                        true => 30380,
                        false => 30381,
                    },
                    Tilt.Unstable => Waterlogged switch {
                        true => 30382,
                        false => 30383,
                    },
                    Tilt.Partial => Waterlogged switch {
                        true => 30384,
                        false => 30385,
                    },
                    Tilt.Full => Waterlogged switch {
                        true => 30386,
                        false => 30387,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(TiltValue), TiltValue, "Unknown value for property tilt.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            30356 => new BigDripleafBlock(Identifier, Direction.North, Tilt.None, true),
            30357 => new BigDripleafBlock(Identifier, Direction.North, Tilt.None, false),
            30358 => new BigDripleafBlock(Identifier, Direction.North, Tilt.Unstable, true),
            30359 => new BigDripleafBlock(Identifier, Direction.North, Tilt.Unstable, false),
            30360 => new BigDripleafBlock(Identifier, Direction.North, Tilt.Partial, true),
            30361 => new BigDripleafBlock(Identifier, Direction.North, Tilt.Partial, false),
            30362 => new BigDripleafBlock(Identifier, Direction.North, Tilt.Full, true),
            30363 => new BigDripleafBlock(Identifier, Direction.North, Tilt.Full, false),
            30364 => new BigDripleafBlock(Identifier, Direction.South, Tilt.None, true),
            30365 => new BigDripleafBlock(Identifier, Direction.South, Tilt.None, false),
            30366 => new BigDripleafBlock(Identifier, Direction.South, Tilt.Unstable, true),
            30367 => new BigDripleafBlock(Identifier, Direction.South, Tilt.Unstable, false),
            30368 => new BigDripleafBlock(Identifier, Direction.South, Tilt.Partial, true),
            30369 => new BigDripleafBlock(Identifier, Direction.South, Tilt.Partial, false),
            30370 => new BigDripleafBlock(Identifier, Direction.South, Tilt.Full, true),
            30371 => new BigDripleafBlock(Identifier, Direction.South, Tilt.Full, false),
            30372 => new BigDripleafBlock(Identifier, Direction.West, Tilt.None, true),
            30373 => new BigDripleafBlock(Identifier, Direction.West, Tilt.None, false),
            30374 => new BigDripleafBlock(Identifier, Direction.West, Tilt.Unstable, true),
            30375 => new BigDripleafBlock(Identifier, Direction.West, Tilt.Unstable, false),
            30376 => new BigDripleafBlock(Identifier, Direction.West, Tilt.Partial, true),
            30377 => new BigDripleafBlock(Identifier, Direction.West, Tilt.Partial, false),
            30378 => new BigDripleafBlock(Identifier, Direction.West, Tilt.Full, true),
            30379 => new BigDripleafBlock(Identifier, Direction.West, Tilt.Full, false),
            30380 => new BigDripleafBlock(Identifier, Direction.East, Tilt.None, true),
            30381 => new BigDripleafBlock(Identifier, Direction.East, Tilt.None, false),
            30382 => new BigDripleafBlock(Identifier, Direction.East, Tilt.Unstable, true),
            30383 => new BigDripleafBlock(Identifier, Direction.East, Tilt.Unstable, false),
            30384 => new BigDripleafBlock(Identifier, Direction.East, Tilt.Partial, true),
            30385 => new BigDripleafBlock(Identifier, Direction.East, Tilt.Partial, false),
            30386 => new BigDripleafBlock(Identifier, Direction.East, Tilt.Full, true),
            30387 => new BigDripleafBlock(Identifier, Direction.East, Tilt.Full, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            TiltValue = properties.Contains("tilt") ? TiltFromString(properties["tilt"].GetString()) : TiltValue,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("tilt", new StringTag(TiltToName(TiltValue))),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
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
