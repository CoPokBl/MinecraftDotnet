using Minecraft.Schemas;

namespace Minecraft.Data.Inventories;

public record SimpleInventoryType(Identifier Identifier, int ProtocolId) : IInventoryType;
