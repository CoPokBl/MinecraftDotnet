using NBT;

namespace Minecraft.Registry.Templates;

public interface INbtSerialisableRegistry : ISubRegistry {
    void LoadNbt(Dictionary<string, INbtTag> entries);
    Dictionary<string, INbtTag> ToNbt();
}
