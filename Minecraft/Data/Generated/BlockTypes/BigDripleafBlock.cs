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
    public int ProtocolId => 1115;
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
                        true => 27661,
                        false => 27662,
                    },
                    Tilt.Unstable => Waterlogged switch {
                        true => 27663,
                        false => 27664,
                    },
                    Tilt.Partial => Waterlogged switch {
                        true => 27665,
                        false => 27666,
                    },
                    Tilt.Full => Waterlogged switch {
                        true => 27667,
                        false => 27668,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(TiltValue), TiltValue, "Unknown value for property tilt.")
                },
                Direction.South => TiltValue switch {
                    Tilt.None => Waterlogged switch {
                        true => 27669,
                        false => 27670,
                    },
                    Tilt.Unstable => Waterlogged switch {
                        true => 27671,
                        false => 27672,
                    },
                    Tilt.Partial => Waterlogged switch {
                        true => 27673,
                        false => 27674,
                    },
                    Tilt.Full => Waterlogged switch {
                        true => 27675,
                        false => 27676,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(TiltValue), TiltValue, "Unknown value for property tilt.")
                },
                Direction.West => TiltValue switch {
                    Tilt.None => Waterlogged switch {
                        true => 27677,
                        false => 27678,
                    },
                    Tilt.Unstable => Waterlogged switch {
                        true => 27679,
                        false => 27680,
                    },
                    Tilt.Partial => Waterlogged switch {
                        true => 27681,
                        false => 27682,
                    },
                    Tilt.Full => Waterlogged switch {
                        true => 27683,
                        false => 27684,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(TiltValue), TiltValue, "Unknown value for property tilt.")
                },
                Direction.East => TiltValue switch {
                    Tilt.None => Waterlogged switch {
                        true => 27685,
                        false => 27686,
                    },
                    Tilt.Unstable => Waterlogged switch {
                        true => 27687,
                        false => 27688,
                    },
                    Tilt.Partial => Waterlogged switch {
                        true => 27689,
                        false => 27690,
                    },
                    Tilt.Full => Waterlogged switch {
                        true => 27691,
                        false => 27692,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(TiltValue), TiltValue, "Unknown value for property tilt.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27661 => new BigDripleafBlock(Identifier, Direction.North, Tilt.None, true),
            27662 => new BigDripleafBlock(Identifier, Direction.North, Tilt.None, false),
            27663 => new BigDripleafBlock(Identifier, Direction.North, Tilt.Unstable, true),
            27664 => new BigDripleafBlock(Identifier, Direction.North, Tilt.Unstable, false),
            27665 => new BigDripleafBlock(Identifier, Direction.North, Tilt.Partial, true),
            27666 => new BigDripleafBlock(Identifier, Direction.North, Tilt.Partial, false),
            27667 => new BigDripleafBlock(Identifier, Direction.North, Tilt.Full, true),
            27668 => new BigDripleafBlock(Identifier, Direction.North, Tilt.Full, false),
            27669 => new BigDripleafBlock(Identifier, Direction.South, Tilt.None, true),
            27670 => new BigDripleafBlock(Identifier, Direction.South, Tilt.None, false),
            27671 => new BigDripleafBlock(Identifier, Direction.South, Tilt.Unstable, true),
            27672 => new BigDripleafBlock(Identifier, Direction.South, Tilt.Unstable, false),
            27673 => new BigDripleafBlock(Identifier, Direction.South, Tilt.Partial, true),
            27674 => new BigDripleafBlock(Identifier, Direction.South, Tilt.Partial, false),
            27675 => new BigDripleafBlock(Identifier, Direction.South, Tilt.Full, true),
            27676 => new BigDripleafBlock(Identifier, Direction.South, Tilt.Full, false),
            27677 => new BigDripleafBlock(Identifier, Direction.West, Tilt.None, true),
            27678 => new BigDripleafBlock(Identifier, Direction.West, Tilt.None, false),
            27679 => new BigDripleafBlock(Identifier, Direction.West, Tilt.Unstable, true),
            27680 => new BigDripleafBlock(Identifier, Direction.West, Tilt.Unstable, false),
            27681 => new BigDripleafBlock(Identifier, Direction.West, Tilt.Partial, true),
            27682 => new BigDripleafBlock(Identifier, Direction.West, Tilt.Partial, false),
            27683 => new BigDripleafBlock(Identifier, Direction.West, Tilt.Full, true),
            27684 => new BigDripleafBlock(Identifier, Direction.West, Tilt.Full, false),
            27685 => new BigDripleafBlock(Identifier, Direction.East, Tilt.None, true),
            27686 => new BigDripleafBlock(Identifier, Direction.East, Tilt.None, false),
            27687 => new BigDripleafBlock(Identifier, Direction.East, Tilt.Unstable, true),
            27688 => new BigDripleafBlock(Identifier, Direction.East, Tilt.Unstable, false),
            27689 => new BigDripleafBlock(Identifier, Direction.East, Tilt.Partial, true),
            27690 => new BigDripleafBlock(Identifier, Direction.East, Tilt.Partial, false),
            27691 => new BigDripleafBlock(Identifier, Direction.East, Tilt.Full, true),
            27692 => new BigDripleafBlock(Identifier, Direction.East, Tilt.Full, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            TiltValue = properties.ChildrenMap.ContainsKey("tilt") ? TiltFromString(properties["tilt"].GetString()) : TiltValue,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
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
