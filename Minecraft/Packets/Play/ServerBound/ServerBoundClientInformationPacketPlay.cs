using Minecraft.Packets.Config.ServerBound;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundClientInformationPacketPlay : ServerBoundClientInformationPacketConfig{

    public override int GetPacketId() {
        return 0x0C;
    }
}