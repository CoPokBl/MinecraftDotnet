namespace Minecraft.Schemas;

/// <summary>
/// Empty struct representing a "None" type.
/// Used in Data Components to indicate the absence of a value.
/// </summary>
public struct None {
    public static readonly None Value = new();
}
