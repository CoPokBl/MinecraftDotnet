using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

public static class AttributeCodeGen {
    
    public static string CreateAttributeEntries(JObject registriesJson) {
        JObject attributeDataJson = JObject.Parse(CodeGenUtils.ReadMinestomDataFile("attribute.json"));
        
        return CodeGenUtils.CreateSimpleRegistryEntries(
            registriesJson, 
            "minecraft:attribute", 
            "SimpleAttribute", 
            "Attribute",
            "Attributes",
            "Attributes",
            extraSimpleParams: key => {
                JObject entry = attributeDataJson[key]!.ToObject<JObject>()!;
                double defaultValue = entry["defaultValue"]!.ToObject<double>();
                double minValue = entry["minValue"]!.ToObject<double>();
                double maxValue = entry["maxValue"]!.ToObject<double>();
                
                return $"{defaultValue}, {minValue}, {maxValue}";
            });
    }
}
