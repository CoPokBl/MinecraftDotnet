using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

public static class DebugSubscriptionCodeGen {
    public static string CreateDebugSubscriptions(JObject registriesJson) {
        return CodeGenUtils.CreateSimpleRegistryEntries(
            registriesJson,
            "minecraft:debug_subscription",
            "SimpleDebugSubscription",
            "DebugSubscription",
            "DebugSubscriptions",
            "DebugSubscriptions");
    }
}
