using Minecraft.Data.Attributes;
using Minecraft.Schemas;

namespace Minecraft.Data.Entities;

public record SimpleEntityType(
    Identifier Identifier,
    bool FireImmune,
    double Width,
    double Height,
    double EyeHeight,
    double Acceleration,
    float AirDrag,
    int ClientTrackingRange,
    EntityAttachments Attachments,
    IReadOnlyDictionary<IAttribute, double> DefaultAttributes) : IEntityType {

    /// <summary>Shared by everything that carries no attributes, which is most entity types.</summary>
    public static readonly IReadOnlyDictionary<IAttribute, double> NoAttributes =
        new Dictionary<IAttribute, double>();
}
