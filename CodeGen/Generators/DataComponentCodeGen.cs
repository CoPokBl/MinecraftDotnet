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
            StringBuilder typeBuilder = new();
            typeBuilder.Append(content, typeIndex + ComponentTypeSearch.Length, content.IndexOf('>', typeIndex) - (typeIndex + ComponentTypeSearch.Length));
            string type = typeBuilder.ToString();
            
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
            
            string varName = CodeGenUtils.NamespacedIdToPascalName(key);
            
            registryAdditions.Append($"{CodeGenUtils.GetIndentation(2)}Data.DataComponents.Add(DataComponent.{varName}, {protocolId});\n");
            fileContent.AppendLine($"{CodeGenUtils.GetIndentation(1)}public static readonly {ComponentClasses[key]} {varName} = new({protocolId});");
        }
        
        fileContent.Append(Footer);
        File.WriteAllText("DataComponent.cs", fileContent.ToString().Replace("{date}", DateTime.Now.ToString("yyyy-MM-dd")));
        
        return registryAdditions.ToString();
    }
}
