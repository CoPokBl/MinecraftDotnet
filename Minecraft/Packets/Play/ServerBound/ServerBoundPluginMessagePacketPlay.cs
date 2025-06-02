using Minecraft.Packets.Config.ServerBound;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundPluginMessagePacketPlay : ServerBoundPluginMessagePacketConfig {
    
    public override int GetPacketId() {
        return 0x14;
    }
}