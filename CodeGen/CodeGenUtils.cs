using System.Reflection;
using System.Text;
using Newtonsoft.Json.Linq;

namespace CodeGen;

public static class CodeGenUtils {
    private const string IdentSearch = "Identifier Identifier => \"";

    public static string NamespacedIdToPascalName(string namespacedId) {
        if (namespacedId.Contains(':')) {
            namespacedId = namespacedId.Split(':')[1];
        }

        return string.Join("", namespacedId.Split('_').Select(CapitaliseFirstLetter));
    }
    
    public static string CapitaliseFirstLetter(string input) {
        if (string.IsNullOrEmpty(input)) return input;
        return char.ToUpper(input[0]) + input[1..];
    }

    public static string ReadEmbeddedFile(string fileName) {
        Assembly assembly = Assembly.GetExecutingAssembly();
        using Stream stream = assembly.GetManifestResourceStream($"CodeGen.Data.{fileName}")!;
        using StreamReader reader = new(stream);
        return reader.ReadToEnd();
    }
    
    public static string GetIndentation(int level) {
        return new string(' ', level * 4);
    }

    public static string? GetIdentifier(string fileContent) {
        int indexOfIdentifier = fileContent.IndexOf(IdentSearch, StringComparison.Ordinal);
        if (indexOfIdentifier == -1) {
            return null; // Identifier not found
        }
        StringBuilder identifierBuilder = new();

        int i = indexOfIdentifier + IdentSearch.Length;
        while (true) {
            if (fileContent[i] == '"') {
                break;
            }
            identifierBuilder.Append(fileContent[i]);
            i++;
        }
                
        return identifierBuilder.ToString();
    }
    
    private const string Header = 
        """
        using Minecraft.Data.{typenamespace};

        namespace Minecraft.Data.Generated;

        // Generated using the CodeGen project. Do not edit manually.
        public static class {classname} {

        """;
    
    private const string Footer = "}\n";
    
    public static string CreateSimpleRegistryEntries(JObject registriesJson, string registryName, string fileName, 
        string simpleClassName, string className, string regVar, string typeNamespace, Func<string, string>? variableNameGetter = null) {
        variableNameGetter ??= NamespacedIdToPascalName;
        
        JObject entitiesJson = registriesJson[registryName]!.ToObject<JObject>()!;
        JObject entityEntriesJson = entitiesJson["entries"]!.ToObject<JObject>()!;
        
        StringBuilder registryAdditions = new();
        StringBuilder file = new(Header.Replace("{classname}", className).Replace("{typenamespace}", typeNamespace));

        foreach (KeyValuePair<string, JToken?> entityEntry in entityEntriesJson) {
            string key = entityEntry.Key;
            if (key == "minecraft:intentionally_empty") {
                continue;  // for some reason, this is in the registry
            }
            
            int protocolId = entityEntry.Value!["protocol_id"]!.Value<int>();
            string pascalName = variableNameGetter(key);
            
            // Add to cs file
            file.Append($"{GetIndentation(1)}public static {simpleClassName} {pascalName} => new(\"{key}\", {protocolId});\n");
            registryAdditions.AppendLine($"{GetIndentation(2)}Data.{regVar}.Add({className}.{pascalName});");
        }
        
        // Create the file content
        file.Append(Footer);
        File.WriteAllText(fileName, file.ToString().Replace("{date}", DateTime.Now.ToString("yyyy-MM-dd")));

        return registryAdditions.ToString();
    }
}
