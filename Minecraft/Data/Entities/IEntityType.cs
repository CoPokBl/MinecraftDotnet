using Minecraft.Data.Attributes;

namespace Minecraft.Data.Entities;

public interface IEntityType : IProtocolType {
    public bool FireImmune { get; }
    public double Width { get; }
    public double Height { get; }
    public double EyeHeight { get; }
    public double Acceleration { get; }

    /// <summary>
    /// <c>Entity.getAirDrag()</c>: what a tick leaves of the velocity, not what it takes away. A
    /// float because vanilla's is, and because it is multiplied in float before it widens.
    /// </summary>
    public float AirDrag { get; }
    public int ClientTrackingRange { get; }
    public EntityAttachments Attachments { get; }

    /// <summary>
    /// What this entity starts its attributes on, for the ones it disagrees with the attribute's own
    /// default about. Empty for anything that is not a living entity, since only those carry
    /// attributes at all.
    /// </summary>
    public IReadOnlyDictionary<IAttribute, double> DefaultAttributes { get; }

    /// <summary>The base value this entity starts <paramref name="attribute"/> on.</summary>
    public double DefaultAttributeValue(IAttribute attribute) {
        return DefaultAttributes.TryGetValue(attribute, out double value) ? value : attribute.Default;
    }
}
