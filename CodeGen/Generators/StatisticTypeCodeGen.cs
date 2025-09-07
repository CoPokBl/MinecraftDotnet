using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

public static class StatisticTypeCodeGen {
    public static string CreateStatisticTypes(JObject registriesJson) {
        return CodeGenUtils.CreateSimpleRegistryEntries(
            registriesJson, 
            "minecraft:stat_type", 
            "SimpleStatisticType", 
            "StatisticType",
            "StatisticTypes",
            "StatisticTypes");
    }
}
