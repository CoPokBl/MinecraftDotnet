using ManagedServer.Entities.Types;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Packets;

namespace ManagedServer;

public interface IViewable {
    PlayerEntity[] GetViewers();
}

public static class ViewableExtensions {

    public static Task SendPacketsToViewers(this IViewable viewable, params MinecraftPacket[] packets) {
        PlayerConnection[] viewers = viewable.GetViewers().Select(v => v.Connection).ToArray();
        Task[] tasks = new Task[viewers.Length];
        for (int i = 0; i < viewers.Length; i++) {
            tasks[i] = viewers[i].SendPackets(packets);
        }
        return Task.WhenAll(tasks);
    }
}
