using System.Text;
using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

public static class DataComponentCodeGen {
    private const string ComponentTypeSearch = ": IDataComponent<";
    private const string Header = 
        """
        using Minecraft.Data.Components.Types;
        using Minecraft.Data.Components;

        namespace Minecraft.Data.Generated;

        // Generated using the CodeGen project. Do not edit manually.
        public static class DataComponent {

        """;
    
    private const string Footer = "}\n";
    
    internal static readonly Dictionary<string, string> ComponentClasses = new();
    internal static readonly Dictionary<string, string> ComponentTypes = new();

    public static string CreateComponentEntries(JObject registriesJson) {
        JObject entries = registriesJson["minecraft:data_component_type"]!["entries"]!.ToObject<JObject>()!;
        
        StringBuilder registryAdditions = new();
        StringBuilder fileContent = new(Header);
        
        string componentTypesFolder = Path.Combine(Directory.GetCurrentDirectory(), "..", "Components", "Types");
        string[] files = Directory.GetFiles(componentTypesFolder, "*.cs", SearchOption.AllDirectories);
        
        foreach (string file in files) {
            string fileName = Path.GetFileNameWithoutExtension(file);

            string content = File.ReadAllText(file);
            
            int typeIndex = content.IndexOf(ComponentTypeSearch, StringComparison.Ordinal);
            if (typeIndex == -1) {
                Console.WriteLine($"Warning: IDataComponent type not found in {fileName}");
                continue;
            }
            int typeStart = typeIndex + ComponentTypeSearch.Length;
            string type = content[typeStart..MatchingAngleBracket(content, typeStart)];

            string? ident = CodeGenUtils.GetIdentifier(content);
            if (ident == null) {
                Console.WriteLine($"Warning: Identifier not found in {fileName}");
                continue;
            }
            ComponentClasses.Add(ident, fileName);
            ComponentTypes.Add(ident, type);
        }

        foreach ((string key, JToken? value) in entries) {
            int protocolId = value!["protocol_id"]!.Value<int>();

            if (!ComponentClasses.ContainsKey(key)) {
                Console.WriteLine("Warning: Component class not found for key: " + key);
                continue;
            }
            
            // The entity variant components are named "wolf/variant" and the like, and a slash is not
            // a member name.
            string varName = CodeGenUtils.NamespacedIdToPascalName(key.Replace('/', '_'));
            
            registryAdditions.Append($"{CodeGenUtils.GetIndentation(2)}Data.DataComponents.Add({protocolId}, DataComponent.{varName});\n");
            fileContent.AppendLine($"{CodeGenUtils.GetIndentation(1)}public static readonly {ComponentClasses[key]} {varName} = new();");
        }
        
        fileContent.Append(Footer);
        File.WriteAllText("DataComponent.cs", fileContent.ToString().Replace("{date}", DateTime.Now.ToString("yyyy-MM-dd")));
        
        return registryAdditions.ToString();
    }

    /// <summary>
    /// Index of the <c>&gt;</c> closing the <c>&lt;</c> just before <paramref name="start"/>. Nested
    /// generics are counted rather than stopping at the first one, so a component over a
    /// <c>Dictionary&lt;string, string&gt;</c> does not come out truncated and then miss its
    /// deserialiser.
    /// </summary>
    private static int MatchingAngleBracket(string content, int start) {
        int depth = 0;
        for (int i = start; i < content.Length; i++) {
            switch (content[i]) {
                case '<':
                    depth++;
                    break;
                case '>' when depth == 0:
                    return i;
                case '>':
                    depth--;
                    break;
            }
        }

        throw new FormatException("Unterminated component type at index " + start);
    }
}
