using ManagedServer.Entities.Types;
using Minecraft.Packets;

namespace ManagedServer.Viewables;

public interface IViewable {
    PlayerEntity[] GetViewers();
}

public static class ViewableExtensions {

    public static IAudience GetAudience(this IViewable viewable) {
        return IAudience.Of(viewable.GetViewers().Cast<IAudience>().ToArray());
    }
    
    public static void SendPacketsToViewers(this IViewable viewable, params MinecraftPacket[] packets) {
        GetAudience(viewable).SendPackets(packets);
    }
}
