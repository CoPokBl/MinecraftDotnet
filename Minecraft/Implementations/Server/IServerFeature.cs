namespace Minecraft.Implementations.Server;

public interface IServerFeature {
    void Register(MinecraftServer server);
    void Unregister();
    Type[] GetDependencies();
}