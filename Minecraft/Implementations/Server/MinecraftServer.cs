using Minecraft.Implementations.Events;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;

namespace Minecraft.Implementations.Server;

public class MinecraftServer {
    public List<IServerFeature> Features { get; }
    public List<PlayerConnection> Connections { get; } = [];
    public EventNode<IServerEvent> Events { get; } = new();
    
    public MinecraftServer(List<IServerFeature>? features) {
        Features = features ?? [];

        foreach (IServerFeature feature in Features) {
            foreach (Type dependency in feature.GetDependencies()) {
                if (Features.All(f => f.GetType() != dependency)) {
                    throw new Exception(
                        $"Dependency {dependency.FullName} of {feature.GetType().FullName} is not present.");
                }
            }

            feature.Register(this);
        }
    }

    public MinecraftServer(params IServerFeature[] feats) : this(feats.ToList()) { }

    public T? Feature<T>() where T : class, IServerFeature {
        foreach (IServerFeature f in Features) {
            if (f is T t) {
                return t;
            }
        }

        return null;
    }

    public IServerFeature? Feature(Type type) {
        foreach (IServerFeature f in Features) {
            if (f.GetType() == type) {
                return f;
            }
        }

        return null;
    }

    public void AddFeature(IServerFeature feature) {
        foreach (Type dependency in feature.GetDependencies()) {
            if (Features.All(f => f.GetType() != dependency)) {
                throw new Exception(
                    $"Dependency {dependency.FullName} of {feature.GetType().FullName} is not present.");
            }
        }
        
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
        Events.AddChild<IPacketEvent>(connection.Events, pe => pe.Connection == connection);
        connection.Disconnected += () => Connections.Remove(connection);
    }
}