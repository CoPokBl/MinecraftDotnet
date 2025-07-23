using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

public static class InventoryTypeCodeGen {
    
    public static string CreateInventoryTypeEntries(JObject registriesJson) {
        return CodeGenUtils.CreateSimpleRegistryEntries(
            registriesJson, 
            "minecraft:menu", 
            "SimpleInventoryType", 
            "InventoryType",
            "InventoryTypes",
            "Inventories");
    }
}
