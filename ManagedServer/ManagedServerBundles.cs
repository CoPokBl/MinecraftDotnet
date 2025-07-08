using ManagedServer.Features.Basic;

namespace ManagedServer;

public partial class ManagedMinecraftServer {

    public static ManagedMinecraftServer NewBasic() {
        return New(
            new ArmSwingFeature()
        );
    }

    public static ManagedMinecraftServer New(params ScopedFeature[] features) {
        ManagedMinecraftServer server = new();
        foreach (ScopedFeature feature in features) {
            server.RegisterFeature(feature);
        }
        return server;
    }
}