using Minecraft.Implementations.Server.Connections;

namespace Minecraft.Implementations.Server;

public interface IViewable {
    PlayerConnection[] GetViewers();
}