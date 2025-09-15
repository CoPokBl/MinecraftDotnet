using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

public static class EntityTypeCodeGen {

    public static string CreateEntityTypeEntries(JObject registriesJson) {
        JObject entityDataJson = JObject.Parse(CodeGenUtils.ReadMinestomDataFile("entity_type.json"));
        
        return CodeGenUtils.CreateSimpleRegistryEntries(
            registriesJson, 
            "minecraft:entity_type", 
            "SimpleEntityType", 
            "EntityType",
            "EntityTypes",
            "Entities",
            extraSimpleParams: key => {
                JObject entry = entityDataJson[key]!.ToObject<JObject>()!;
                bool fireImmune = entry["fireImmune"]?.ToObject<bool>() ?? false;
                double width = entry["width"]!.ToObject<double>();
                double height = entry["height"]!.ToObject<double>();
                double eyeHeight = entry["eyeHeight"]?.ToObject<double>() ?? height * 0.85;
                double acceleration = entry["acceleration"]?.ToObject<double>() ?? 0.08;
                double drag = entry["drag"]?.ToObject<double>() ?? 0.02;
                int clientTrackingRange = entry["clientTrackingRange"]!.ToObject<int>();
                
                return $"{fireImmune.ToString().ToLower()}, {width}, {height}, {eyeHeight}, {acceleration}, {drag}, {clientTrackingRange}";
            });
    }
}
