using Minecraft.Schemas;

namespace Minecraft.Data.Items;

public record SimpleItem(Identifier Identifier, int ProtocolId) : IItem;
