using ManagedServer.Worlds;

namespace ManagedServer;

public interface IWorldFeature {
    void Register(World server);
    void Unregister();
    Type[] GetDependencies();
}