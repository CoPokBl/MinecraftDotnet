using Minecraft.Implementations.Events;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;

namespace Minecraft.Implementations.Server;

public class MinecraftServer {
    public List<IFeature> Features { get; }
    public List<PlayerConnection> Connections { get; } = [];
    public EventNode<ServerEvent> Events { get; } = new();
    
    public MinecraftServer(List<IFeature>? features = null) {
        Features = features ?? [];

        foreach (IFeature feature in Features) {
            foreach (Type dependency in feature.GetDependencies()) {
                if (Features.All(f => f.GetType() != dependency)) {
                    throw new Exception(
                        $"Dependency {dependency.FullName} of {feature.GetType().FullName} is not present.");
                }
            }

            feature.Register(this);
        }
    }

    public T? Feature<T>() where T : class, IFeature {
        foreach (IFeature f in Features) {
            if (f is T t) {
                return t;
            }
        }

        return null;
    }

    [Obsolete("Adding features after instantiation is not recommended and may cause issues with added features")]
    public void AddFeature(IFeature feature) {
        Features.Add(feature);
        feature.Register(this);
    }

    /// <summary>
    /// Add a player connection to our list of connections so that it will be handled
    /// by this instance.
    /// </summary>
    /// <param name="connection">The connection.</param>
    public void AddConnection(PlayerConnection connection) {
        Connections.Add(connection);
        connection.Events.AddParent(Events);
        connection.Disconnected += () => Connections.Remove(connection);
    }
}