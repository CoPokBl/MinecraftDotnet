using Minecraft.Data;

namespace Minecraft.Schemas.Tags;

public record RegistryTagValue(Identifier Id, bool IsTagReference) {
    
    public static RegistryTagValue Direct(Identifier id) => new(id, false);
    public static RegistryTagValue Direct(IProtocolType v) => new(v.Identifier, false);
    public static RegistryTagValue Tag(Identifier id) => new(id, true);
}
