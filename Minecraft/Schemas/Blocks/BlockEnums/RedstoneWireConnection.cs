namespace Minecraft.Schemas.Blocks.BlockEnums;

public enum RedstoneWireConnection {
    Up,
    Side,
    None
}

public static class RedstoneWireConnectionExtensions {
    public static RedstoneWireConnection FromString(string value) {
        return value switch {
            "up" => RedstoneWireConnection.Up,
            "side" => RedstoneWireConnection.Side,
            "none" => RedstoneWireConnection.None,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for RedstoneWireConnection.")
        };
    }
    
    public static string ToName(this RedstoneWireConnection connection) {
        return connection switch {
            RedstoneWireConnection.Up => "up",
            RedstoneWireConnection.Side => "side",
            RedstoneWireConnection.None => "none",
            _ => throw new ArgumentOutOfRangeException(nameof(connection), connection, "Unknown RedstoneWireConnection value.")
        };
    }
}
