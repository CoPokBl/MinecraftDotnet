using ClientLib.Events;
using Minecraft.Packets.Config.ServerBound;

namespace ClientLib.Features.Basic;

public class ClientInformationFeature(ServerBoundClientInformationPacket packet) : ScopedFeature {
    public override void Register() {
        AddEventListener<LoginEvent>(_ => {
            Scope.Client.SendPacket(packet);
        });
    }
}
