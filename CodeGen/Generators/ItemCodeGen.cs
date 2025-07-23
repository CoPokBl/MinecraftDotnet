using System.Text;
using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

public static class ItemCodeGen {
    private const string Header = 
"""
using Minecraft.Data.Items;

namespace Minecraft.Data.Generated;

// Generated using the CodeGen project. Do not edit manually.
public static class Item {

""";
    
    private const string Footer = "}\n";

    public static string CreateItemEntries(JObject registriesJson) {
        JObject itemsJson = registriesJson["minecraft:item"]!.ToObject<JObject>()!;
        JObject itemEntriesJson = itemsJson["entries"]!.ToObject<JObject>()!;

        JObject itemData = JObject.Parse(CodeGenUtils.ReadEmbeddedFile("item_data.json"));
        
        StringBuilder registryAdditions = new();
        StringBuilder file = new(Header);

        foreach (KeyValuePair<string, JToken?> itemEntry in itemEntriesJson) {
            string key = itemEntry.Key;
            int protocolId = itemEntry.Value!["protocol_id"]!.Value<int>();
            string pascalName = CodeGenUtils.NamespacedIdToPascalName(key);
            
            JObject itemDataEntry = itemData[key]!.ToObject<JObject>()!;
            Func<string?, string> toCsStr = str => str == null ? "null" : $"\"{str}\"";
            
            string? block = itemDataEntry["correspondingBlock"]?.Value<string>();
            string translationKey = itemDataEntry["translationKey"]!.Value<string>()!;
            
            // Add to cs file
            file.Append($"{CodeGenUtils.GetIndentation(1)}public static SimpleItem {pascalName} => new(\"{key}\", {protocolId}, " +
                        $"{toCsStr(block)}, {toCsStr(translationKey)});\n");
            registryAdditions.AppendLine($"{CodeGenUtils.GetIndentation(2)}Data.Items.Add(Item.{pascalName});");
        }
        
        // Create the file content
        file.Append(Footer);
        File.WriteAllText("Item.cs", file.ToString().Replace("{date}", DateTime.Now.ToString("yyyy-MM-dd")));

        return registryAdditions.ToString();
    }
}
