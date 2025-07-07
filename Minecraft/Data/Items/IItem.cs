using Minecraft.Schemas;

namespace Minecraft.Data.Items;

public interface IItem : IProtocolType {
    public Identifier? CorrespondingBlock { get; }
    public string TranslationKey { get; }
}
