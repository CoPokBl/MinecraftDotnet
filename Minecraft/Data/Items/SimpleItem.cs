using System.Collections.Frozen;
using Minecraft.Data.Components;
using Minecraft.Schemas;

namespace Minecraft.Data.Items;

public record SimpleItem(Identifier Identifier, Identifier? CorrespondingBlock, string TranslationKey,
    FrozenDictionary<IDataComponent, object> DefaultComponents) : IItem;
