using System.Reflection;
using Newtonsoft.Json.Linq;

namespace Minecraft.Schemas.Registry;

public static class MinecraftRegistryData {
    private const string RegistriesFileName = "registries.json";
    
    public static Dictionary<string, JObject> Registries { get; } = new();

    // Load the registries from the embedded JSON file
    static MinecraftRegistryData() {
        Assembly assembly = Assembly.GetExecutingAssembly();
        string namespaceName = MethodBase.GetCurrentMethod()!.DeclaringType!.Namespace!;
        using Stream stream = assembly.GetManifestResourceStream($"{namespaceName}.{RegistriesFileName}")!;
        using StreamReader reader = new(stream);
        
        string result = reader.ReadToEnd();
        JObject root = JObject.Parse(result);
        foreach (KeyValuePair<string, JToken?> kvp in root) {
            Registries.Add(kvp.Key, kvp.Value!["entries"]!.ToObject<JObject>()!);
        }
    }
}
