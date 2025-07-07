using System.Text;
using Newtonsoft.Json.Linq;

namespace CodeGen;

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

    public static string CreateComponentEntries(JObject registriesJson) {
        JObject entries = registriesJson["minecraft:data_component_type"]!["entries"]!.ToObject<JObject>()!;
        
        StringBuilder registryAdditions = new();
        StringBuilder fileContent = new(Header);
        
        string componentTypesFolder = Path.Combine(Directory.GetCurrentDirectory(), "..", "Components", "Types");
        string[] files = Directory.GetFiles(componentTypesFolder, "*.cs", SearchOption.AllDirectories);
        
        Dictionary<string, string> componentClasses = new();
        Dictionary<string, string> componentTypes = new();
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
            componentClasses.Add(ident, fileName);
            componentTypes.Add(ident, type);
        }

        foreach ((string key, JToken? value) in entries) {
            int protocolId = value!["protocol_id"]!.Value<int>();

            if (!componentClasses.ContainsKey(key)) {
                Console.WriteLine("Warning: Component class not found for key: " + key);
                continue;
            }
            
            registryAdditions.Append($"{CodeGenUtils.GetIndentation(2)}Data.DataComponents.Add({componentClasses[key]}.Default, {protocolId});\n");
            
            fileContent.AppendLine($"{CodeGenUtils.GetIndentation(1)}public static readonly {componentClasses[key]} {CodeGenUtils.NamespacedIdToPascalName(key)} = {componentClasses[key]}.Default;");
        }
        
        fileContent.Append(Footer);
        File.WriteAllText("DataComponent.cs", fileContent.ToString().Replace("{date}", DateTime.Now.ToString("yyyy-MM-dd")));
        
        return registryAdditions.ToString();
    }
}
