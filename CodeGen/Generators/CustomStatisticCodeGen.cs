using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

public static class CustomStatisticCodeGen {
    public static string CreateCustomStatistics(JObject registriesJson) {
        return CodeGenUtils.CreateSimpleRegistryEntries(
            registriesJson, 
            "minecraft:custom_stat", 
            "SimpleCustomStatistic",
            "CustomStatistic",
            "CustomStatistics",
            "CustomStatistics");
    }
}
