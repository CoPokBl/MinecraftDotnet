using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PointedDripstoneBlock(Identifier Identifier, PointedDripstoneBlock.Thickness ThicknessValue, PointedDripstoneBlock.VerticalDirection VerticalDirectionValue, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return ThicknessValue switch {
                Thickness.TipMerge => VerticalDirectionValue switch {
                    VerticalDirection.Up => Waterlogged switch {
                        true => 25776,
                        false => 25777,
                    },
                    VerticalDirection.Down => Waterlogged switch {
                        true => 25778,
                        false => 25779,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(VerticalDirectionValue), VerticalDirectionValue, "Unknown value for property vertical_direction.")
                },
                Thickness.Tip => VerticalDirectionValue switch {
                    VerticalDirection.Up => Waterlogged switch {
                        true => 25780,
                        false => 25781,
                    },
                    VerticalDirection.Down => Waterlogged switch {
                        true => 25782,
                        false => 25783,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(VerticalDirectionValue), VerticalDirectionValue, "Unknown value for property vertical_direction.")
                },
                Thickness.Frustum => VerticalDirectionValue switch {
                    VerticalDirection.Up => Waterlogged switch {
                        true => 25784,
                        false => 25785,
                    },
                    VerticalDirection.Down => Waterlogged switch {
                        true => 25786,
                        false => 25787,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(VerticalDirectionValue), VerticalDirectionValue, "Unknown value for property vertical_direction.")
                },
                Thickness.Middle => VerticalDirectionValue switch {
                    VerticalDirection.Up => Waterlogged switch {
                        true => 25788,
                        false => 25789,
                    },
                    VerticalDirection.Down => Waterlogged switch {
                        true => 25790,
                        false => 25791,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(VerticalDirectionValue), VerticalDirectionValue, "Unknown value for property vertical_direction.")
                },
                Thickness.Base => VerticalDirectionValue switch {
                    VerticalDirection.Up => Waterlogged switch {
                        true => 25792,
                        false => 25793,
                    },
                    VerticalDirection.Down => Waterlogged switch {
                        true => 25794,
                        false => 25795,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(VerticalDirectionValue), VerticalDirectionValue, "Unknown value for property vertical_direction.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(ThicknessValue), ThicknessValue, "Unknown value for property thickness.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            25776 => new PointedDripstoneBlock(Identifier, Thickness.TipMerge, VerticalDirection.Up, true),
            25777 => new PointedDripstoneBlock(Identifier, Thickness.TipMerge, VerticalDirection.Up, false),
            25778 => new PointedDripstoneBlock(Identifier, Thickness.TipMerge, VerticalDirection.Down, true),
            25779 => new PointedDripstoneBlock(Identifier, Thickness.TipMerge, VerticalDirection.Down, false),
            25780 => new PointedDripstoneBlock(Identifier, Thickness.Tip, VerticalDirection.Up, true),
            25781 => new PointedDripstoneBlock(Identifier, Thickness.Tip, VerticalDirection.Up, false),
            25782 => new PointedDripstoneBlock(Identifier, Thickness.Tip, VerticalDirection.Down, true),
            25783 => new PointedDripstoneBlock(Identifier, Thickness.Tip, VerticalDirection.Down, false),
            25784 => new PointedDripstoneBlock(Identifier, Thickness.Frustum, VerticalDirection.Up, true),
            25785 => new PointedDripstoneBlock(Identifier, Thickness.Frustum, VerticalDirection.Up, false),
            25786 => new PointedDripstoneBlock(Identifier, Thickness.Frustum, VerticalDirection.Down, true),
            25787 => new PointedDripstoneBlock(Identifier, Thickness.Frustum, VerticalDirection.Down, false),
            25788 => new PointedDripstoneBlock(Identifier, Thickness.Middle, VerticalDirection.Up, true),
            25789 => new PointedDripstoneBlock(Identifier, Thickness.Middle, VerticalDirection.Up, false),
            25790 => new PointedDripstoneBlock(Identifier, Thickness.Middle, VerticalDirection.Down, true),
            25791 => new PointedDripstoneBlock(Identifier, Thickness.Middle, VerticalDirection.Down, false),
            25792 => new PointedDripstoneBlock(Identifier, Thickness.Base, VerticalDirection.Up, true),
            25793 => new PointedDripstoneBlock(Identifier, Thickness.Base, VerticalDirection.Up, false),
            25794 => new PointedDripstoneBlock(Identifier, Thickness.Base, VerticalDirection.Down, true),
            25795 => new PointedDripstoneBlock(Identifier, Thickness.Base, VerticalDirection.Down, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            ThicknessValue = ThicknessFromString(properties["thickness"].GetString()),
            VerticalDirectionValue = VerticalDirectionFromString(properties["vertical_direction"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
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
}
