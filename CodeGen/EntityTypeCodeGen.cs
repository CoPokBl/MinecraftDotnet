using Newtonsoft.Json.Linq;

namespace CodeGen;

public static class EntityTypeCodeGen {

    public static string CreateEntityTypeEntries(JObject registriesJson) {
        return CodeGenUtils.CreateSimpleRegistryEntries(
            registriesJson, 
            "minecraft:entity_type", 
            "EntityType.cs", 
            "SimpleEntityType", 
            "EntityType",
            "EntityTypes",
            "Entities");
    }
}
