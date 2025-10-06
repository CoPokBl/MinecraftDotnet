using Minecraft.Data;
using Minecraft.Registry;

namespace Minecraft.Schemas.Tags;

public interface IRegistryTag<out T> : IRegistryTag where T : IProtocolType {
    T[] GetValues(MinecraftRegistry registry);
}

public interface IRegistryTag {
    Identifier TagId { get; }
    Identifier RegistryId { get; }
    Identifier[] GetValueIds(MinecraftRegistry registry);
    int[] GetValueRegistryIds(MinecraftRegistry registry);
}
