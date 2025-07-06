using Minecraft.Packets;

namespace ManagedServer.Viewables;

public interface IAudience {
    void SendPacket(MinecraftPacket packet);

    public static IAudience Of(params IAudience[] audiences) {
        return new AudiencesList(audiences);
    }
}
