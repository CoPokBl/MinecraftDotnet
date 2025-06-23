using Minecraft.Implementations.Server.Worlds;

namespace Minecraft.Implementations.Server.Managed;

public interface IWorldFeature {
    void Register(World server);
    void Unregister();
    Type[] GetDependencies();
}