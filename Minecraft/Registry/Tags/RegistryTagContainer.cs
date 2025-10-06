using Minecraft.Data;
using Minecraft.Schemas;
using Minecraft.Schemas.Tags;

namespace Minecraft.Registry.Tags;

public abstract class RegistryTagContainer {
    public Dictionary<Identifier, IRegistryTag> Tags { get; } = [];
    
    public IRegistryTag this[Identifier id] => Tags[id];
    
    public void Add(IRegistryTag tag) {
        Tags.Add(tag.TagId, tag);
    }
    
    public bool Contains(Identifier id) => Tags.ContainsKey(id);
    
    public void Clear() => Tags.Clear();
}

public class RegistryTagContainer<T> : RegistryTagContainer where T : IProtocolType {
    public new IRegistryTag<T> this[Identifier id] => (IRegistryTag<T>)Tags[id];
    
    public void Add(IRegistryTag<T> tag) {
        Tags.Add(tag.TagId, tag);
    }
}
