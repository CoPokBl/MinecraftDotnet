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

        foreach ((string key, JToken? value) in itemEntriesJson) {
            int protocolId = value!["protocol_id"]!.Value<int>();
            string pascalName = CodeGenUtils.NamespacedIdToPascalName(key);
            
            JObject itemDataEntry = itemData[key]!.ToObject<JObject>()!;
            Func<string?, string> toCsStr = str => str == null ? "null" : $"\"{str}\"";
            
            string? block = itemDataEntry["correspondingBlock"]?.Value<string>();
            string translationKey = itemDataEntry["translationKey"]!.Value<string>()!;
            
            // Get default components
            JObject defaultComponents = itemDataEntry["components"]!.ToObject<JObject>()!;
            List<string> defaultComponentConstructors = [];
            foreach ((string componentId, JToken? componentToken) in defaultComponents) {
                if (!DataComponentCodeGen.ComponentClasses.ContainsKey(componentId)) {
                    Console.WriteLine("WARNING: Component class not found for " + componentId + ", to create item default component.");
                    continue;
                }
                
                // This is the type of the generic (the actual type that has been serialized)
                // eg. IDataComponent<THIS_THING>
                string componentType = DataComponentCodeGen.ComponentTypes[componentId];

                if (!Deserialisers.TryGetValue(componentType, out Func<JToken, string>? deserialiser)) {
                    Console.WriteLine("WARNING: No deserializer found for component type " + componentType + ", to create item default component.");
                    continue;
                }
                string inlineDefinition = deserialiser(componentToken!);
                
                // Remove the "Component" suffix from the class name
                int suffixLength = "Component".Length;
                string componentVarName = DataComponentCodeGen.ComponentClasses[componentId][..^suffixLength];
                defaultComponentConstructors.Add($"{{ DataComponent.{componentVarName}, {inlineDefinition} }}");
            }
            
            // Add to cs file
            file.Append($"{CodeGenUtils.GetIndentation(1)}public static SimpleItem {pascalName} => new(\"{key}\", {protocolId}, " +
                        $"{toCsStr(block)}, {toCsStr(translationKey)}, " +
                        $"new Dictionary<IDataComponent, object>() {{ {string.Join(", ", defaultComponentConstructors)} }});\n");
            registryAdditions.AppendLine($"{CodeGenUtils.GetIndentation(2)}Data.Items.Add(Item.{pascalName});");
        }
        
        // Create the file content
        file.Append(Footer);
        File.WriteAllText("Item.cs", file.ToString().Replace("{date}", DateTime.Now.ToString("yyyy-MM-dd")));

        return registryAdditions.ToString();
    }

    private static readonly Dictionary<string, Func<JToken, string>> Deserialisers = new() {
        { "int", token => token.ToObject<int>().ToString() },
        { "ConsumableComponent.Data", token => {
            JObject obj = token.ToObject<JObject>()!;
            float consumeSeconds = obj["consume_seconds"]?.Value<float>() ?? 1.6f;
            string animationStr = obj["animation"]?.Value<string>() ?? "Eat";
            if (animationStr != "Eat") {
                throw new Exception("Unsupported consume animation: " + animationStr);
            }
            
            string sound = obj["sound"]?.ToObject<string>() ?? "minecraft:generic_eat";
            if (sound != "minecraft:generic_eat") {
                throw new Exception("Unsupported consume sound: " + sound);
            }
            
            bool hasParticles = obj["has_consume_particles"]?.Value<bool>() ?? true;
            JArray consumeEffects = obj["on_consume_effects"]?.ToObject<JArray>() ?? [];
        } }
    };
}
