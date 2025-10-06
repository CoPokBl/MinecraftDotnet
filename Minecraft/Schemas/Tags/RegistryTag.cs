using Minecraft.Data;
using Minecraft.Registry;
using Minecraft.Registry.Templates;

namespace Minecraft.Schemas.Tags;

public record RegistryTag<T>(Identifier RegistryId, Identifier TagId, RegistryTagValue[] Values) : IRegistryTag<T> where T : IProtocolType {
    
    public T[] GetValues(MinecraftRegistry registry) {
        List<T> values = [];
        foreach (RegistryTagValue val in Values) {
            if (val.IsTagReference) {
                values.AddRange(((IRegistryTag<T>)registry[RegistryId].Tags[val.Id]).GetValues(registry));
            }
            else {
                values.Add(((ProtocolTypeRegistry<T>)registry[RegistryId])[val.Id]);
            }
        }
        return values.ToArray();
    }

    public Identifier[] GetValueIds(MinecraftRegistry registry) {
        List<Identifier> values = [];
        foreach (RegistryTagValue val in Values) {
            if (val.IsTagReference) {
                values.AddRange(registry[RegistryId].Tags[val.Id].GetValueIds(registry));
            }
            else {
                values.Add(val.Id);
            }
        }
        return values.ToArray();
    }

    public int[] GetValueRegistryIds(MinecraftRegistry registry) {
        return GetValues(registry)
            .Select(v => v.ProtocolId)
            .ToArray();
    }
}
