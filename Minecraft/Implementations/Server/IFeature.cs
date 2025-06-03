namespace Minecraft.Implementations.Server;

public interface IFeature {
    void Register(MinecraftServer server);
    Type[] GetDependencies();
}