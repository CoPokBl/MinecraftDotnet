using System.Reflection;
using System.Text;
using Newtonsoft.Json.Linq;

namespace CodeGen;

public static class CodeGenUtils {
    private const string IdentSearch = "Identifier Identifier => \"";

    public static string VanillaDataDir = "";
    public static string DumpDir = "";

    /// <summary>The unpacked server jar, ie. the real one rather than the bundler.</summary>
    public static string ServerJarPath = "";

    public static string NamespacedIdToPascalName(string namespacedId) {
        if (namespacedId.Contains(':')) {
            namespacedId = namespacedId.Split(':')[1];
        }

        string name = string.Join("", namespacedId.Split('_').Select(CapitaliseFirstLetter));

        // Some ids are just numbers (the 11, 13 and 5 music discs), which don't make a member name
        return name.Length > 0 && char.IsDigit(name[0]) ? '_' + name : name;
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
    
    /// <summary>Reads one of the files <c>Data/Dumper.java</c> writes, see Program.cs.</summary>
    public static string ReadDumpFile(string fileName) {
        return File.ReadAllText(Path.Combine(DumpDir, fileName));
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
            int protocolId = value!["protocol_id"]!.Value<int>();
            entries.Add((key, protocolId));
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

            string pascalName = variableNameGetter(key);
            
            // Add to cs file
            string identParam = existingClassName == null ? $"\"{key}\", " : "";
            string extraParams = extraSimpleParams != null ? ", " + extraSimpleParams(key) : string.Empty;
            file.Append($"{GetIndentation(1)}public static readonly {existingClassName ?? simpleClassName} {pascalName} = " +
                        $"new({identParam}{extraParams});\n");
            registryAdditions.AppendLine($"{GetIndentation(2)}Data.{regVar}.Add({protocolId}, {className}.{pascalName});");
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

        List<string> entryStrings = [];
        foreach ((string key, int protocolId) in entries) {
            string pascalName = variableNameGetter(key);
            
            // Add to cs file
            string extraParams = extraSimpleParams != null ? ", " + extraSimpleParams(key) : string.Empty;
            entryStrings.Add($"public static readonly {simpleClassName} {pascalName} = new(\"{key}\"{extraParams});");
            registryAdditions.AppendLine($"{GetIndentation(2)}Data.{regVar}.Add({protocolId}, {className}.{pascalName});");
        }
        
        // Create the file content
        CreateVanillaEntriesFile(className, typeNamespace, entryStrings.ToArray());

        return registryAdditions.ToString();
    }

    public static void CreateVanillaEntriesFile(string className, string typeNamespace, string[] entries) {
        StringBuilder file = new(Header.Replace("{classname}", className).Replace("{typenamespace}", typeNamespace));
        foreach (string entry in entries) {
            file
                .Append(GetIndentation(1))
                .Append(entry)
                .Append('\n');
        }
        file.Append(Footer);
        File.WriteAllText(className + ".cs", file.ToString().Replace("{date}", DateTime.Now.ToString("yyyy-MM-dd")));
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
                file.Append($"{GetIndentation(1)}public static readonly {simpleClassName} {pascalName} = new(\"{key}\");\n");
            }
            else {
                file.Append($"{GetIndentation(1)}public static readonly {typeName} {pascalName} = new(\"{key}\");\n");
            }
            
            // Add to registry
            registryEntries.Append($"{GetIndentation(2)}Data.{regVar}.Add({protocolId}, {className}.{pascalName});\n");
        }
        
        file.Append(Footer);
        File.WriteAllText($"{className}.cs", file.ToString());

        return registryEntries.ToString();
    }
}
