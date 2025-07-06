using Minecraft.Packets;

namespace ManagedServer.Viewables;

public record AudiencesList(IAudience[] Audiences) : IAudience {
    
    public void SendPacket(MinecraftPacket packet) {
        foreach (IAudience audience in Audiences) {
            audience.SendPacket(packet);
        }
    }
}
