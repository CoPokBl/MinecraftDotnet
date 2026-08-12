using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SulfurSpikeBlock(Identifier Identifier, SulfurSpikeBlock.Thickness ThicknessValue, SulfurSpikeBlock.VerticalDirection VerticalDirectionValue, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:sulfur_spike";
    public double Hardness => 1.5;
    public double ExplosionResistance => 3;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "sulfur_spike";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:sulfur_spike";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.5625, 0.6875, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.5625, 0.6875, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.5625, 0.6875, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 18;
    public string TranslationKey => "block.minecraft.sulfur_spike";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return ThicknessValue switch {
                Thickness.TipMerge => VerticalDirectionValue switch {
                    VerticalDirection.Up => Waterlogged switch {
                        true => 30229,
                        false => 30230,
                    },
                    VerticalDirection.Down => Waterlogged switch {
                        true => 30231,
                        false => 30232,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(VerticalDirectionValue), VerticalDirectionValue, "Unknown value for property vertical_direction.")
                },
                Thickness.Tip => VerticalDirectionValue switch {
                    VerticalDirection.Up => Waterlogged switch {
                        true => 30233,
                        false => 30234,
                    },
                    VerticalDirection.Down => Waterlogged switch {
                        true => 30235,
                        false => 30236,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(VerticalDirectionValue), VerticalDirectionValue, "Unknown value for property vertical_direction.")
                },
                Thickness.Frustum => VerticalDirectionValue switch {
                    VerticalDirection.Up => Waterlogged switch {
                        true => 30237,
                        false => 30238,
                    },
                    VerticalDirection.Down => Waterlogged switch {
                        true => 30239,
                        false => 30240,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(VerticalDirectionValue), VerticalDirectionValue, "Unknown value for property vertical_direction.")
                },
                Thickness.Middle => VerticalDirectionValue switch {
                    VerticalDirection.Up => Waterlogged switch {
                        true => 30241,
                        false => 30242,
                    },
                    VerticalDirection.Down => Waterlogged switch {
                        true => 30243,
                        false => 30244,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(VerticalDirectionValue), VerticalDirectionValue, "Unknown value for property vertical_direction.")
                },
                Thickness.Base => VerticalDirectionValue switch {
                    VerticalDirection.Up => Waterlogged switch {
                        true => 30245,
                        false => 30246,
                    },
                    VerticalDirection.Down => Waterlogged switch {
                        true => 30247,
                        false => 30248,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(VerticalDirectionValue), VerticalDirectionValue, "Unknown value for property vertical_direction.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(ThicknessValue), ThicknessValue, "Unknown value for property thickness.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            30229 => new SulfurSpikeBlock(Identifier, Thickness.TipMerge, VerticalDirection.Up, true),
            30230 => new SulfurSpikeBlock(Identifier, Thickness.TipMerge, VerticalDirection.Up, false),
            30231 => new SulfurSpikeBlock(Identifier, Thickness.TipMerge, VerticalDirection.Down, true),
            30232 => new SulfurSpikeBlock(Identifier, Thickness.TipMerge, VerticalDirection.Down, false),
            30233 => new SulfurSpikeBlock(Identifier, Thickness.Tip, VerticalDirection.Up, true),
            30234 => new SulfurSpikeBlock(Identifier, Thickness.Tip, VerticalDirection.Up, false),
            30235 => new SulfurSpikeBlock(Identifier, Thickness.Tip, VerticalDirection.Down, true),
            30236 => new SulfurSpikeBlock(Identifier, Thickness.Tip, VerticalDirection.Down, false),
            30237 => new SulfurSpikeBlock(Identifier, Thickness.Frustum, VerticalDirection.Up, true),
            30238 => new SulfurSpikeBlock(Identifier, Thickness.Frustum, VerticalDirection.Up, false),
            30239 => new SulfurSpikeBlock(Identifier, Thickness.Frustum, VerticalDirection.Down, true),
            30240 => new SulfurSpikeBlock(Identifier, Thickness.Frustum, VerticalDirection.Down, false),
            30241 => new SulfurSpikeBlock(Identifier, Thickness.Middle, VerticalDirection.Up, true),
            30242 => new SulfurSpikeBlock(Identifier, Thickness.Middle, VerticalDirection.Up, false),
            30243 => new SulfurSpikeBlock(Identifier, Thickness.Middle, VerticalDirection.Down, true),
            30244 => new SulfurSpikeBlock(Identifier, Thickness.Middle, VerticalDirection.Down, false),
            30245 => new SulfurSpikeBlock(Identifier, Thickness.Base, VerticalDirection.Up, true),
            30246 => new SulfurSpikeBlock(Identifier, Thickness.Base, VerticalDirection.Up, false),
            30247 => new SulfurSpikeBlock(Identifier, Thickness.Base, VerticalDirection.Down, true),
            30248 => new SulfurSpikeBlock(Identifier, Thickness.Base, VerticalDirection.Down, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            ThicknessValue = properties.Contains("thickness") ? ThicknessFromString(properties["thickness"].GetString()) : ThicknessValue,
            VerticalDirectionValue = properties.Contains("vertical_direction") ? VerticalDirectionFromString(properties["vertical_direction"].GetString()) : VerticalDirectionValue,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("thickness", new StringTag(ThicknessToName(ThicknessValue))),
            ("vertical_direction", new StringTag(VerticalDirectionToName(VerticalDirectionValue))),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
    public enum Thickness {
        TipMerge,
        Tip,
        Frustum,
        Middle,
        Base,
    }

    public static Thickness ThicknessFromString(string value) {
        return value switch {
            "tip_merge" => Thickness.TipMerge,
            "tip" => Thickness.Tip,
            "frustum" => Thickness.Frustum,
            "middle" => Thickness.Middle,
            "base" => Thickness.Base,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Thickness.")
        };
    }

    public static string ThicknessToName(Thickness value) {
        return value switch {
            Thickness.TipMerge => "tip_merge",
            Thickness.Tip => "tip",
            Thickness.Frustum => "frustum",
            Thickness.Middle => "middle",
            Thickness.Base => "base",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Thickness value.")
        };
    }
    public enum VerticalDirection {
        Up,
        Down,
    }

    public static VerticalDirection VerticalDirectionFromString(string value) {
        return value switch {
            "up" => VerticalDirection.Up,
            "down" => VerticalDirection.Down,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for VerticalDirection.")
        };
    }

    public static string VerticalDirectionToName(VerticalDirection value) {
        return value switch {
            VerticalDirection.Up => "up",
            VerticalDirection.Down => "down",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown VerticalDirection value.")
        };
    }
}
