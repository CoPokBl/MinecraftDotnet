using ManagedServer.Features;
using ManagedServer.Features.Basic;
using ManagedServer.Features.Bundles;
using BlockBreakingFeature = ManagedServer.Features.Basic.BlockBreakingFeature;

namespace ManagedServer;

public partial class ManagedMinecraftServer {
    public static readonly FeatureBundle BasicsBundle = new(
        new ArmSwingFeature(),
        new PongFeature(),
        new BasicChatFeature(),
        new BlockPlacingFeature(),
        new PlayerCrouchFeature(),
        new BlockBreakingFeature(),
        new InventoryClickFeature(),
        new DropItemsEventFeature(),
        new ConsumablesFeature(),
        new LoginProcedureFeature(),
        new PhysicsFeature(),
        new SimpleTabListFeature(),
        new PlayerSkinLayersFeature()
    );

    public static ManagedMinecraftServer NewBasic() {
        return New(BasicsBundle);
    }
    
    public static ManagedMinecraftServer New(params FeatureBundle[] bundle) {
        ManagedMinecraftServer server = new();
        server.AddFeatures(bundle);
        return server;
    }
}
