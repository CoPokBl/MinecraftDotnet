using Minecraft.Data.Components;
using Minecraft.Schemas;

namespace Minecraft.Data.Items;

public interface IItem : IProtocolType {
    public Identifier? CorrespondingBlock { get; }
    public string TranslationKey { get; }
    public Dictionary<IDataComponent, object> DefaultComponents { get; }
}
