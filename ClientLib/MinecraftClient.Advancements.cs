using ClientLib.Advancements;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;

namespace ClientLib;

public sealed partial class MinecraftClient {
    private ClientAdvancements? _advancements;

    /// <summary>The advancements of this play phase; a login starts them over, as vanilla's new packet listener does.</summary>
    public ClientAdvancements Advancements => _advancements ??= NewAdvancements();

    /// <summary>An advancement was completed and its toast is due.</summary>
    public event Action<AdvancementNode>? AdvancementToast;

    private ClientAdvancements NewAdvancements() {
        ClientAdvancements advancements = new(packet => {
            if (Connection != null) {
                Send(packet);
            }
        }, node => AdvancementToast?.Invoke(node));
        advancements.Log += Info;
        return advancements;
    }

    private void ResetAdvancements() => _advancements = null;

    private bool HandleAdvancementPacket(MinecraftPacket packet) {
        switch (packet) {
            case ClientBoundUpdateAdvancementsPacket update:
                Advancements.Update(update);
                return true;
            case ClientBoundSelectAdvancementsTabPacket select:
                Advancements.HandleSelectTab(select);
                return true;
            default:
                return false;
        }
    }
}
