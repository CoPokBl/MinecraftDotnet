namespace Minecraft.Schemas.Blocks.BlockEnums;

/// <summary>
/// Which half of its own cube a state fills, vanilla's <c>Half</c>. Only <c>half</c> takes these
/// two values, over the 85 stairs and trapdoors.
/// <p/>
/// Deliberately not <see cref="BlockHalf"/>, which is upper and lower and says which cell of a two
/// block tall block a state is. Vanilla keeps them apart as <c>Half</c> and <c>DoubleBlockHalf</c>
/// for the same reason: placement reads this one off the click point and that one off the partner
/// cell, so a block that mixed them up would place a door lying down.
/// </summary>
public enum TopBottom {
    Top,
    Bottom
}

public static class TopBottomExtensions {
    public static TopBottom FromString(string value) {
        return value switch {
            "top" => TopBottom.Top,
            "bottom" => TopBottom.Bottom,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for TopBottom.")
        };
    }

    public static string ToName(this TopBottom half) {
        return half switch {
            TopBottom.Top => "top",
            TopBottom.Bottom => "bottom",
            _ => throw new ArgumentOutOfRangeException(nameof(half), half, "Unknown TopBottom value.")
        };
    }
}
