namespace Minecraft.Data.EnvironmentAttributes;

/// <summary>
/// One property of the world the game reads at a position: sky colour, whether monsters burn,
/// which music plays. Biomes, dimensions and timelines all set these, and the game resolves them
/// in layers.
/// </summary>
public interface IEnvironmentAttribute : IProtocolType {
    /// <summary>The shape of this attribute's value, needed to read one out of NBT.</summary>
    public EnvironmentAttributeValueKind ValueKind { get; }

    /// <summary>
    /// Whether the client is told about this attribute. Server side ones are dropped from the
    /// registry data the client synchronises, so sending them is pointless rather than harmful.
    /// </summary>
    public bool Syncable { get; }
}
