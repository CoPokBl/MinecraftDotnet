using System.Collections.Frozen;
using Minecraft.Data.Components;
using Minecraft.Schemas;

namespace Minecraft.Data.Items;

public interface IItem : IProtocolType {
    public Identifier? CorrespondingBlock { get; }
    public string TranslationKey { get; }
    public FrozenDictionary<IDataComponent, object> DefaultComponents { get; }
}
