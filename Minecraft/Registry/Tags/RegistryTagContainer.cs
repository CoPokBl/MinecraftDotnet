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

    /// <summary>
    /// Whether <paramref name="value"/> is in the tag <paramref name="tag"/>, walking any tag
    /// references inside it. A tag the registry does not have reads as empty rather than throwing,
    /// which is what makes a lookup against a datapack that never defined it deny instead of crash.
    /// <p/>
    /// This resolves the tag on every call, so anything asking on a hot path should cache the answer
    /// the way <c>BlockPhysicsData</c> does rather than call it per tick.
    /// </summary>
    public bool Contains(MinecraftRegistry registry, Identifier tag, Identifier value) {
        if (!Tags.TryGetValue(tag, out IRegistryTag? contents)) {
            return false;
        }

        foreach (Identifier id in contents.GetValueIds(registry)) {
            if (id.Equals(value)) {
                return true;
            }
        }

        return false;
    }


    public void Clear() => Tags.Clear();
}

public class RegistryTagContainer<T> : RegistryTagContainer where T : IProtocolType {
    public new IRegistryTag<T> this[Identifier id] => (IRegistryTag<T>)Tags[id];
    
    public void Add(IRegistryTag<T> tag) {
        Tags.Add(tag.TagId, tag);
    }
}
