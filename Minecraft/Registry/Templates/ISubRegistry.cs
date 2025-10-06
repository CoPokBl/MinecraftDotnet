using Minecraft.Data;
using Minecraft.Registry.Tags;
using Minecraft.Schemas;

namespace Minecraft.Registry.Templates;

public interface ISubRegistry<out TSelf, TType> : ISubRegistry where TType : IProtocolType {
    new TSelf Clone();
    new RegistryTagContainer<TType> Tags { get; }
}

public interface ISubRegistry {
    Identifier RegistryId { get; }
    
    RegistryTagContainer Tags { get; }
    ISubRegistry Clone();
    void Clear();
}
