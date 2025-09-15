using System.Reflection;
using System.Text;
using Newtonsoft.Json.Linq;

namespace CodeGen;

public static class CodeGenUtils {
    private const string IdentSearch = "Identifier Identifier => \"";

    public static string VanillaDataDir = "";
    public static string MinestomDataDir = "";

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
    
    public static string ReadMinestomDataFile(string fileName) {
        return File.ReadAllText(Path.Combine(MinestomDataDir, fileName));
    }
    
    public static string ReadVanillaDataFile(params string[] path) {
        string fileName = Path.Combine(path);
        string filePath = Path.Combine(VanillaDataDir, fileName);
        if (!File.Exists(filePath)) {
            throw new FileNotFoundException($"Vanilla data file '{fileName}' not found in directory '{VanillaDataDir}'.");
        }
        return File.ReadAllText(filePath);
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

    public static string CreateSimpleRegistryEntries(JObject registriesJson, string registryName,
        string simpleClassName, string className, string regVar, string typeNamespace,
        Func<string, string>? variableNameGetter = null, Func<string, string>? extraSimpleParams = null) {
        return CreateSimpleRegistryEntries(BuildRegularRegistryEntries(registriesJson, registryName), simpleClassName, 
            className, regVar, typeNamespace, variableNameGetter, extraSimpleParams);
    }

    public static (string, int)[] BuildRegularRegistryEntries(JObject registriesJson, string registryName) {
        JObject entitiesJson = registriesJson[registryName]!.ToObject<JObject>()!;
        JObject entityEntriesJson = entitiesJson["entries"]!.ToObject<JObject>()!;
        
        List<(string, int)> entries = [];
        foreach ((string key, JToken? value) in entityEntriesJson) {
            if (key == "minecraft:intentionally_empty") {
                continue;  // for some reason, this is in the registry
            }
            
            int protocolId = value!["protocol_id"]!.Value<int>();
            entries.Add((key, protocolId));
        }

        return entries.ToArray();
    }

    public static (string, int)[] GetFileRegEntries(string resFile) {
        JObject obj = JObject.Parse(ReadMinestomDataFile(resFile));
        List<(string, int)> entries = [];
        foreach (KeyValuePair<string, JToken?> entry in obj) {
            if (entry.Key == "minecraft:intentionally_empty") {
                continue;  // for some reason, this is in the registry
            }
            if (entry.Value is JObject entryObj) {
                int protocolId = entryObj["id"]!.Value<int>();
                entries.Add((entry.Key, protocolId));
            } else {
                throw new InvalidOperationException($"Expected a JObject for entry '{entry.Key}' in {resFile}.");
            }
        }
        return entries.ToArray();
    }

    // maps Identifiers to class names
    public static Dictionary<string, string> SearchForFilesWithIdentifiers(string path) {
        Dictionary<string, string> data = [];
        string[] files = Directory.GetFiles(path, "*.cs", SearchOption.AllDirectories);

        foreach (string file in files) {
            string fileContent = File.ReadAllText(file);
            string className = Path.GetFileNameWithoutExtension(file);

            string? identifier = GetIdentifier(fileContent);
            if (identifier == null) {
                Console.WriteLine("Skipping file without Identifier: " + file);
                continue;
            }

            data.TryAdd(identifier, className);
        }
        
        return data;
    }

    public static string CreateIdentifiedFilesRegistryEntries((string, int)[] entries, string className,
        string regVar, string typeNamespace, Func<string, string>? variableNameGetter = null,
        Func<string, string>? extraSimpleParams = null, string? simpleClassName = null) {
        
        variableNameGetter ??= NamespacedIdToPascalName;
        
        Dictionary<string, string> files = SearchForFilesWithIdentifiers(Path.Combine(
            Directory.GetCurrentDirectory(), "..", "..", "Data", "ArgumentParsers"));

        StringBuilder registryAdditions = new();
        StringBuilder file = new(Header.Replace("{classname}", className).Replace("{typenamespace}", typeNamespace));
        
        foreach ((string key, int protocolId) in entries) {
            if (!files.TryGetValue(key, out string? existingClassName) && simpleClassName == null) {
                Console.WriteLine("WARNING: Argument type file not found for identifier: " + key);
                continue;
            }

            if (key == "minecraft:intentionally_empty") {
                continue;  // for some reason, this is in the registry
            }

            string pascalName = variableNameGetter(key);
            
            // Add to cs file
            string identParam = existingClassName == null ? $"\"{key}\", " : "";
            string extraParams = extraSimpleParams != null ? ", " + extraSimpleParams(key) : string.Empty;
            file.Append($"{GetIndentation(1)}public static {existingClassName ?? simpleClassName} {pascalName} => " +
                        $"new({identParam}{protocolId}{extraParams});\n");
            registryAdditions.AppendLine($"{GetIndentation(2)}Data.{regVar}.Add({className}.{pascalName});");
        }
        
        // Create the file content
        file.Append(Footer);
        File.WriteAllText(className + ".cs", file.ToString().Replace("{date}", DateTime.Now.ToString("yyyy-MM-dd")));

        return registryAdditions.ToString();
    }
    
    public static string CreateSimpleRegistryEntries((string, int)[] entries, string simpleClassName, string className, 
        string regVar, string typeNamespace, Func<string, string>? variableNameGetter = null, Func<string, string>? extraSimpleParams = null) {
        variableNameGetter ??= NamespacedIdToPascalName;
        
        StringBuilder registryAdditions = new();
        StringBuilder file = new(Header.Replace("{classname}", className).Replace("{typenamespace}", typeNamespace));

        foreach ((string key, int protocolId) in entries) {
            if (key == "minecraft:intentionally_empty") {
                continue;  // for some reason, this is in the registry
            }

            string pascalName = variableNameGetter(key);
            
            // Add to cs file
            string extraParams = extraSimpleParams != null ? ", " + extraSimpleParams(key) : string.Empty;
            file.Append($"{GetIndentation(1)}public static {simpleClassName} {pascalName} => new(\"{key}\", {protocolId}{extraParams});\n");
            registryAdditions.AppendLine($"{GetIndentation(2)}Data.{regVar}.Add({className}.{pascalName});");
        }
        
        // Create the file content
        file.Append(Footer);
        File.WriteAllText(className + ".cs", file.ToString().Replace("{date}", DateTime.Now.ToString("yyyy-MM-dd")));

        return registryAdditions.ToString();
    }

    public static string CreateSimpleAndComplexRegistryEntries((string, int)[] entries, string simpleClassName, 
        JObject complexTypes, string className, string regVar, string typeNamespace, 
        Func<string, string>? variableNameGetter = null) {
        variableNameGetter ??= NamespacedIdToPascalName;
        
        Dictionary<string, string> complexTypesDict = complexTypes.ToObject<Dictionary<string, string>>()!;

        StringBuilder file = new(Header.Replace("{classname}", className).Replace("{typenamespace}", typeNamespace + 
            $";\nusing Minecraft.Data.{typeNamespace}.Types"));
        StringBuilder registryEntries = new();

        foreach ((string key, int protocolId) in entries) {
            string pascalName = variableNameGetter(key);

            // Add to cs file
            if (!complexTypesDict.TryGetValue(key, out string? typeName)) {
                file.Append($"{GetIndentation(1)}public static readonly {simpleClassName} {pascalName} = new(\"{key}\", {protocolId});\n");
            }
            else {
                file.Append($"{GetIndentation(1)}public static readonly {typeName} {pascalName} = new(\"{key}\", {protocolId});\n");
            }
            
            // Add to ParticleRegistry
            registryEntries.Append($"{GetIndentation(2)}Data.{regVar}.Add({className}.{pascalName});\n");
        }
        
        file.Append(Footer);
        File.WriteAllText($"{className}.cs", file.ToString());

        return registryEntries.ToString();
    }
}
