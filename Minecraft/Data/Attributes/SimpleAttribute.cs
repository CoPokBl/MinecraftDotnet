using Minecraft.Schemas;

namespace Minecraft.Data.Attributes;

public record SimpleAttribute(Identifier Identifier, double Default, double Min, double Max) : IAttribute;
