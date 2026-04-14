using Minecraft.Data.Components;
using Minecraft.Schemas;

namespace Minecraft.Data.Items;

public record SimpleItem(Identifier Identifier, Identifier? CorrespondingBlock, string TranslationKey, 
    Dictionary<IDataComponent, object> DefaultComponents) : IItem;
