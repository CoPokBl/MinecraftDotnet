namespace Minecraft.Schemas.Blocks.BlockEnums;

/// <summary>
/// <c>type</c> on the ten chests, vanilla's <c>ChestType</c>. Which half of a double chest this is,
/// and <c>Single</c> for one on its own. It is not a size: the left and right are relative to the
/// chest's facing, which is why pairing reads the neighbour's facing as well as its type.
/// </summary>
public enum ChestType {
    Single,
    Left,
    Right
}

public static class ChestTypeExtensions {
    public static ChestType FromString(string value) {
        return value switch {
            "single" => ChestType.Single,
            "left" => ChestType.Left,
            "right" => ChestType.Right,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for ChestType.")
        };
    }
    
    public static string ToName(this ChestType chestType) {
        return chestType switch {
            ChestType.Single => "single",
            ChestType.Left => "left",
            ChestType.Right => "right",
            _ => throw new ArgumentOutOfRangeException(nameof(chestType), chestType, "Unknown ChestType value.")
        };
    }
}
