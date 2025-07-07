using Minecraft.Schemas;

namespace Minecraft.Data.Items;

public record SimpleItem(Identifier Identifier, int ProtocolId, Identifier? CorrespondingBlock, string TranslationKey) : IItem;
