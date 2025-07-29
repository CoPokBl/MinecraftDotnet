using Minecraft.Schemas;

namespace Minecraft.Data.Attributes;

public record SimpleAttribute(Identifier Identifier, int ProtocolId, double Default, double Min, double Max) : IAttribute;
