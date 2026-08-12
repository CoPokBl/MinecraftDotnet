using Minecraft.Schemas;

namespace Minecraft.Data.EnvironmentAttributes;

public record SimpleEnvironmentAttribute(
    Identifier Identifier,
    EnvironmentAttributeValueKind ValueKind,
    bool Syncable) : IEnvironmentAttribute;
