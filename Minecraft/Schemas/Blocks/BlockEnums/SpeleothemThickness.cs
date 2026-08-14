namespace Minecraft.Schemas.Blocks.BlockEnums;

/// <summary>
/// <c>thickness</c> on pointed dripstone and the sulfur spike, vanilla's <c>SpeleothemThickness</c>.
/// Positions in a column rather than sizes, and <c>TipMerge</c> is the one state where two tips
/// growing towards each other have met.
/// </summary>
public enum SpeleothemThickness {
    TipMerge,
    Tip,
    Frustum,
    Middle,
    Base
}

public static class SpeleothemThicknessExtensions {
    public static SpeleothemThickness FromString(string value) {
        return value switch {
            "tip_merge" => SpeleothemThickness.TipMerge,
            "tip" => SpeleothemThickness.Tip,
            "frustum" => SpeleothemThickness.Frustum,
            "middle" => SpeleothemThickness.Middle,
            "base" => SpeleothemThickness.Base,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for SpeleothemThickness.")
        };
    }
    
    public static string ToName(this SpeleothemThickness thickness) {
        return thickness switch {
            SpeleothemThickness.TipMerge => "tip_merge",
            SpeleothemThickness.Tip => "tip",
            SpeleothemThickness.Frustum => "frustum",
            SpeleothemThickness.Middle => "middle",
            SpeleothemThickness.Base => "base",
            _ => throw new ArgumentOutOfRangeException(nameof(thickness), thickness, "Unknown SpeleothemThickness value.")
        };
    }
}
