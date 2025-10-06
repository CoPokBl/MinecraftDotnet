using System.Text;
using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

public static class TagsCodeGen {
    private const string Header = 
"""
using Minecraft.Schemas;

namespace Minecraft.Data.Generated;

// Generated using the CodeGen project. Do not edit manually.
public static class VanillaTags {

""";
    
    private const string Footer = "}\n";
    
    private static readonly Dictionary<string, string> RegistryTypeMap = new() {
        { "block", "IBlock" },
        { "item", "IItem" },
        { "entity_type", "IEntityType" },
        { "enchantment", "IEnchantment" },
    };
    
    public static string CreateTagEntries(JObject registriesJson) {
        string tagsFolder = Path.Combine(CodeGenUtils.VanillaDataDir, "data", "minecraft", "tags");
        
        StringBuilder tagEntries = new("\n");

        void SearchDirectory(string regName, string dir) {
            if (!RegistryTypeMap.ContainsKey(regName)) {
                Console.WriteLine("Tags cannot be saved for registry: " + regName);
                return;  // Not a registry we have set up
            }
            
            foreach (string subDir in Directory.EnumerateDirectories(dir)) {
                SearchDirectory(regName, subDir);
            }
            
            string regId = $"minecraft:{regName}";
            foreach (string file in Directory.EnumerateFiles(dir)) {
                // get a list of all directories taken from the 'tags' folder
                // for example /some/path/to/data/minecraft/tags/blocks/mineable/wood.json
                // would give ["blocks","mineable"]
                string[] pathParts = file.Split(Path.DirectorySeparatorChar);
                int tagsIndex = Array.IndexOf(pathParts, regName);
                if (tagsIndex == -1 || pathParts.Length <= tagsIndex + 1) {
                    Console.WriteLine($"Invalid tag file path ({pathParts.Length} <= {tagsIndex} + 1): " + file);
                    continue; // Not a valid tag file
                }
                
                string[] tagPath = pathParts[(tagsIndex + 1)..^1]; // Get the path after the reg name

                // The tag ID will look like minecraft:path/to/sometag
                string tagId = tagPath.Aggregate("", (current, part) => current + part + "/");
                tagId += Path.GetFileNameWithoutExtension(file);
                
                JObject tagData = JObject.Parse(File.ReadAllText(file));
                JArray values = tagData["values"]?.ToObject<JArray>() ?? [];

                string[] valueEntries = values
                    .Select(v => v.ToObject<string>()![0] == '#'
                        ? $"RegistryTagValue.Tag(\"{v.ToObject<string>()![1..]}\")"
                        : $"RegistryTagValue.Direct(\"{v}\")")
                    .ToArray();
                string valuesString = $"[{string.Join(", ", valueEntries)}]";
                
                string entry = $"{CodeGenUtils.GetIndentation(2)}Data[\"{regId}\"].Tags.Add(" +
                        $"new RegistryTag<{RegistryTypeMap[regName]}>(\"{regId}\", \"{tagId}\", {valuesString}));";
                tagEntries.AppendLine(entry);
            }
        }

        // each of these is a directory containing tag files for
        // the registry that the subfolder is called
        foreach (string regDir in Directory.EnumerateDirectories(tagsFolder)) {
            SearchDirectory(regDir.Split(Path.DirectorySeparatorChar)[^1], regDir);
        }
        
        // Create the file content
        // StringBuilder file = new(Header);
        // file.Append(tagEntries);
        // file.Append(Footer);
        // File.WriteAllText("VanillaTags.cs", file.ToString().Replace("{date}", DateTime.Now.ToString("yyyy-MM-dd")));
        return tagEntries.ToString();
    }
}