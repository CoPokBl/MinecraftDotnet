using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PointedDripstoneBlock(Identifier Identifier, PointedDripstoneBlock.Thickness ThicknessValue, PointedDripstoneBlock.VerticalDirection VerticalDirectionValue, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:pointed_dripstone";
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
    public string SoundType => "pointed_dripstone";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:pointed_dripstone";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.5625, 0.6875, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.5625, 0.6875, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.5625, 0.6875, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 48;
    public string TranslationKey => "block.minecraft.pointed_dripstone";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return ThicknessValue switch {
                Thickness.TipMerge => VerticalDirectionValue switch {
                    VerticalDirection.Up => Waterlogged switch {
                        true => 30209,
                        false => 30210,
                    },
                    VerticalDirection.Down => Waterlogged switch {
                        true => 30211,
                        false => 30212,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(VerticalDirectionValue), VerticalDirectionValue, "Unknown value for property vertical_direction.")
                },
                Thickness.Tip => VerticalDirectionValue switch {
                    VerticalDirection.Up => Waterlogged switch {
                        true => 30213,
                        false => 30214,
                    },
                    VerticalDirection.Down => Waterlogged switch {
                        true => 30215,
                        false => 30216,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(VerticalDirectionValue), VerticalDirectionValue, "Unknown value for property vertical_direction.")
                },
                Thickness.Frustum => VerticalDirectionValue switch {
                    VerticalDirection.Up => Waterlogged switch {
                        true => 30217,
                        false => 30218,
                    },
                    VerticalDirection.Down => Waterlogged switch {
                        true => 30219,
                        false => 30220,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(VerticalDirectionValue), VerticalDirectionValue, "Unknown value for property vertical_direction.")
                },
                Thickness.Middle => VerticalDirectionValue switch {
                    VerticalDirection.Up => Waterlogged switch {
                        true => 30221,
                        false => 30222,
                    },
                    VerticalDirection.Down => Waterlogged switch {
                        true => 30223,
                        false => 30224,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(VerticalDirectionValue), VerticalDirectionValue, "Unknown value for property vertical_direction.")
                },
                Thickness.Base => VerticalDirectionValue switch {
                    VerticalDirection.Up => Waterlogged switch {
                        true => 30225,
                        false => 30226,
                    },
                    VerticalDirection.Down => Waterlogged switch {
                        true => 30227,
                        false => 30228,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(VerticalDirectionValue), VerticalDirectionValue, "Unknown value for property vertical_direction.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(ThicknessValue), ThicknessValue, "Unknown value for property thickness.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            30209 => new PointedDripstoneBlock(Identifier, Thickness.TipMerge, VerticalDirection.Up, true),
            30210 => new PointedDripstoneBlock(Identifier, Thickness.TipMerge, VerticalDirection.Up, false),
            30211 => new PointedDripstoneBlock(Identifier, Thickness.TipMerge, VerticalDirection.Down, true),
            30212 => new PointedDripstoneBlock(Identifier, Thickness.TipMerge, VerticalDirection.Down, false),
            30213 => new PointedDripstoneBlock(Identifier, Thickness.Tip, VerticalDirection.Up, true),
            30214 => new PointedDripstoneBlock(Identifier, Thickness.Tip, VerticalDirection.Up, false),
            30215 => new PointedDripstoneBlock(Identifier, Thickness.Tip, VerticalDirection.Down, true),
            30216 => new PointedDripstoneBlock(Identifier, Thickness.Tip, VerticalDirection.Down, false),
            30217 => new PointedDripstoneBlock(Identifier, Thickness.Frustum, VerticalDirection.Up, true),
            30218 => new PointedDripstoneBlock(Identifier, Thickness.Frustum, VerticalDirection.Up, false),
            30219 => new PointedDripstoneBlock(Identifier, Thickness.Frustum, VerticalDirection.Down, true),
            30220 => new PointedDripstoneBlock(Identifier, Thickness.Frustum, VerticalDirection.Down, false),
            30221 => new PointedDripstoneBlock(Identifier, Thickness.Middle, VerticalDirection.Up, true),
            30222 => new PointedDripstoneBlock(Identifier, Thickness.Middle, VerticalDirection.Up, false),
            30223 => new PointedDripstoneBlock(Identifier, Thickness.Middle, VerticalDirection.Down, true),
            30224 => new PointedDripstoneBlock(Identifier, Thickness.Middle, VerticalDirection.Down, false),
            30225 => new PointedDripstoneBlock(Identifier, Thickness.Base, VerticalDirection.Up, true),
            30226 => new PointedDripstoneBlock(Identifier, Thickness.Base, VerticalDirection.Up, false),
            30227 => new PointedDripstoneBlock(Identifier, Thickness.Base, VerticalDirection.Down, true),
            30228 => new PointedDripstoneBlock(Identifier, Thickness.Base, VerticalDirection.Down, false),
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
