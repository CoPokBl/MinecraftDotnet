namespace Minecraft.Schemas;

public enum AttributeOperation {
    Add = 0,
    AddMultipliedBase = 1,
    AddMultipliedTotal = 2
}

public static class AttributeOperationExtensions {
    public static string ToProtocolString(this AttributeOperation operation) => operation switch {
        AttributeOperation.Add => "add_value",
        AttributeOperation.AddMultipliedBase => "add_multiplied_base",
        AttributeOperation.AddMultipliedTotal => "add_multiplied_total",
        _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
    };

    public static AttributeOperation ParseAttributeOperation(string value) => value switch {
        "add_value" => AttributeOperation.Add,
        "add_multiplied_base" => AttributeOperation.AddMultipliedBase,
        "add_multiplied_total" => AttributeOperation.AddMultipliedTotal,
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown attribute operation")
    };
}
