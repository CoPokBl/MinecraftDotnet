using System.Text;
using Newtonsoft.Json.Linq;

namespace CodeGen;

public static class EntityTypeCodeGen {
    private const string Header = 
        """
        using Minecraft.Data.Entities;

        namespace Minecraft.Data.Generated;

        // Generated using the CodeGen project. Do not edit manually.
        //
        // Last updated: {date}
        public static class EntityType {

        """;
    
    private const string Footer = "}\n";

    public static string CreateEntityTypeEntries(JObject registriesJson) {
        JObject entitiesJson = registriesJson["minecraft:entity_type"]!.ToObject<JObject>()!;
        JObject entityEntriesJson = entitiesJson["entries"]!.ToObject<JObject>()!;
        
        StringBuilder registryAdditions = new();
        StringBuilder file = new(Header);

        foreach (KeyValuePair<string, JToken?> entityEntry in entityEntriesJson) {
            string key = entityEntry.Key;
            int protocolId = entityEntry.Value!["protocol_id"]!.Value<int>();
            string pascalName = CodeGenUtils.NamespacedIdToPascalName(key);
            
            // Add to cs file
            file.Append($"{CodeGenUtils.GetIndentation(1)}public static SimpleEntityType {pascalName} => new(\"{key}\", {protocolId});\n");
            registryAdditions.AppendLine($"{CodeGenUtils.GetIndentation(2)}Data.EntityTypes.Add(EntityType.{pascalName});");
        }
        
        // Create the file content
        file.Append(Footer);
        File.WriteAllText("EntityType.cs", file.ToString().Replace("{date}", DateTime.Now.ToString("yyyy-MM-dd")));

        return registryAdditions.ToString();
    }
}
