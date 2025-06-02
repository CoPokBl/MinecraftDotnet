using Minecraft.Packets.Play.ClientBound;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundKeepAlivePacketPlay : ClientBoundKeepAlivePacketPlay {
    
    public override int GetPacketId() {
        return 0x1A;
    }
}