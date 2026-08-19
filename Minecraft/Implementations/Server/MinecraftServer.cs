using Minecraft.Implementations.Events;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations;
using Minecraft.Implementations.Server.Events;

namespace Minecraft.Implementations.Server;

public class MinecraftServer {
    public List<IServerFeature> Features { get; }
    public SnapshotList<PlayerConnection> Connections { get; } = new();
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

    public void AddFeatures(params IServerFeature[] features) {
        foreach (IServerFeature feature in features) {
            AddFeature(feature);
        }
    }

    /// <summary>
    /// Add a player connection to our list of connections so that it will be handled
    /// by this instance.
    /// </summary>
    /// <param name="connection">The connection.</param>
    public virtual void AddConnection(PlayerConnection connection) {
        Connections.Add(connection);
        Events.AddChild<IPacketEvent>(connection.Events, pe => pe.Connection == connection);

        // The node is detached again as well as the connection dropped. Every event the server
        // dispatches walks its children, so a node left behind by each connection that has ever
        // been made is both a leak and a growing cost on every event for the whole run.
        connection.Disconnected += () => {
            Connections.Remove(connection);
            Events.RemoveChild(connection.Events);
        };
    }
}