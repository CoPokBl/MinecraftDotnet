namespace Minecraft.Implementations.Tags;

// The T is to store the type.
// ReSharper disable once UnusedTypeParameter
public class Tag<T>(string id) {
    public string Id { get; } = id;
}
