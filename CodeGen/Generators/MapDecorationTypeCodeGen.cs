using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

public static class MapDecorationTypeCodeGen {
    public static string CreateMapDecorationTypes(JObject registriesJson) {
        return CodeGenUtils.CreateSimpleRegistryEntries(
            registriesJson,
            "minecraft:map_decoration_type",
            "SimpleMapDecorationType",
            "MapDecorationType",
            "MapDecorationTypes",
            "MapDecorationTypes");
    }
}
