using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

public static class VillagerTypeCodeGen {

    public static string CreateVillagerTypes(JObject registriesJson) {
        return CodeGenUtils.CreateSimpleRegistryEntries(
            registriesJson,
            "minecraft:villager_type",
            "SimpleVillagerType",
            "VillagerType",
            "VillagerTypes",
            "VillagerTypes");
    }
}
