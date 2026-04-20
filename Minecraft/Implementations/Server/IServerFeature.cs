namespace Minecraft.Implementations.Server;

[Obsolete("Use ManagedServer for constructs like this.")]
public interface IServerFeature {
    void Register(MinecraftServer server);
    void Unregister();
    Type[] GetDependencies();
}