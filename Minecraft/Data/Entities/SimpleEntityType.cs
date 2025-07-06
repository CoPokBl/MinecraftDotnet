using Minecraft.Schemas;

namespace Minecraft.Data.Entities;

public record SimpleEntityType(Identifier Identifier, int ProtocolId) : IEntityType;
