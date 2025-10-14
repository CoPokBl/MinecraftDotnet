using NBT;

namespace Minecraft.Registry.Templates;

public interface INbtSerialisableRegistry : ISubRegistry {
    void LoadNbt(Dictionary<string, INbtTag> entries, MinecraftRegistry reg);
    Dictionary<string, INbtTag> ToNbt();
}
