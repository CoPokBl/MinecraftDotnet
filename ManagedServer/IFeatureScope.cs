using ManagedServer.Entities.Types;
using Minecraft.Implementations.Events;
using Minecraft.Implementations.Server.Events;

namespace ManagedServer;

public interface IFeatureScope {
    public EventNode<IServerEvent> Events { get; }
    public List<PlayerEntity> Players { get; }

    public void AddFeature(ScopedFeature feature);
}
