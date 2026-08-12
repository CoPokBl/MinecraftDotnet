using Minecraft.Data.DebugSubscriptions;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;

namespace Minecraft.Registry.SubRegistries;

public class DebugSubscriptionRegistry : MappedRegistry<DebugSubscriptionRegistry, IDebugSubscription> {
    public override Identifier RegistryId => "minecraft:debug_subscription";
}
