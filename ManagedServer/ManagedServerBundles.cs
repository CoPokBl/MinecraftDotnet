using ManagedServer.Features;
using ManagedServer.Features.Basic;
using BlockBreakingFeature = ManagedServer.Features.Basic.BlockBreakingFeature;

namespace ManagedServer;

public partial class ManagedMinecraftServer {

    public static ManagedMinecraftServer NewBasic() {
        return New(
            new ArmSwingFeature(),
            new PongFeature(),
            new BasicChatFeature(),
            new BlockPlacingFeature(),
            new PlayerCrouchFeature(),
            new BlockBreakingFeature(),
            new InventoryClickFeature(),
            new DropItemsEventFeature(),
            new ConsumablesFeature(),
            new LoginProcedureFeature()
        );
    }

    public static ManagedMinecraftServer New(params ScopedFeature[] features) {
        ManagedMinecraftServer server = new();
        foreach (ScopedFeature feature in features) {
            server.AddFeature(feature);
        }
        return server;
    }
}
