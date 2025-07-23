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
    
    public static string CreateTagEntries(JObject registriesJson) {
        string tagsFolder = Path.Combine(CodeGenUtils.VanillaDataDir, "data", "minecraft", "tags");
        
        StringBuilder tagEntries = new();

        void SearchDirectory(string dir) {
            foreach (string subDir in Directory.EnumerateDirectories(dir)) {
                SearchDirectory(subDir);
            }

            foreach (string file in Directory.EnumerateFiles(dir)) {
                string fileName = Path.GetFileName(file);
                
                // get a list of all directories taken from the 'tags' folder
                // for example /some/path/to/data/minecraft/tags/blocks/mineable/wood.json
                // would give ["blocks","mineable"]
                string[] pathParts = file.Split(Path.DirectorySeparatorChar);
                int tagsIndex = Array.IndexOf(pathParts, "tags");
                if (tagsIndex == -1 || pathParts.Length <= tagsIndex + 2) {
                    continue; // Not a valid tag file
                }
                
                string[] tagPath = pathParts[(tagsIndex + 1)..^1]; // Get the path after 'tags'

                string pascalName = "";
                foreach (string part in tagPath) {
                    pascalName += CodeGenUtils.NamespacedIdToPascalName(part);
                }
                pascalName += CodeGenUtils.NamespacedIdToPascalName(Path.GetFileNameWithoutExtension(file));
                
                JObject tagData = JObject.Parse(File.ReadAllText(file));
                JArray values = tagData["values"]?.ToObject<JArray>() ?? [];

                string entry = $"{CodeGenUtils.GetIndentation(1)}public static Identifier[] {pascalName} => [" +
                               $"{string.Join(", ", values.Select(v => $"\"{v.ToObject<string>()}\""))}];";
                tagEntries.AppendLine(entry);
            }
        }
        
        SearchDirectory(tagsFolder);
        
        // Create the file content
        StringBuilder file = new(Header);
        file.Append(tagEntries);
        file.Append(Footer);
        File.WriteAllText("VanillaTags.cs", file.ToString().Replace("{date}", DateTime.Now.ToString("yyyy-MM-dd")));
        return "";
    }
}