using Newtonsoft.Json.Linq;

namespace CodeGen;

public static class ParticleCodeGen {
    private const string Header = 
"""
using Minecraft.Data.Particles;
using Minecraft.Data.Particles.Types;

namespace Minecraft.Data.Generated;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: {date}
public static class Particle {

""";

    private const string Footer = "}\n";
    

    public static string CreateParticleEntries(JObject registriesJson) {
        JObject complexParticles = JObject.Parse(CodeGenUtils.ReadEmbeddedFile("complex_particles.json"));
        Dictionary<string, string> complexParticleTypes = complexParticles.ToObject<Dictionary<string, string>>()!;

        string file = Header.Replace("{date}", DateTime.Now.ToString("yyyy-MM-dd"));
        string registryEntries = "";

        JObject entries = registriesJson["minecraft:particle_type"]!["entries"]!.ToObject<JObject>()!;

        foreach (KeyValuePair<string, JToken?> kvp in entries) {
            int protocolId = kvp.Value!["protocol_id"]!.Value<int>();
            string pascalName = CodeGenUtils.NamespacedIdToPascalName(kvp.Key);
            string key = kvp.Key;
            
            // Add to cs file
            if (!complexParticleTypes.TryGetValue(kvp.Key, out string? typeName)) {
                file += $"   public static SimpleParticle {pascalName} => new(\"{key}\", {protocolId});\n";
            }
            else {
                file += $"   public static {typeName} {pascalName} => new(\"{key}\", {protocolId});\n";
            }
            
            // Add to ParticleRegistry
            registryEntries += $"        Data.Particles.Add(\"{key}\", {protocolId}, Particle.{pascalName});\n";
        }
        
        file += Footer;
        File.WriteAllText("Particle.cs", file);

        return registryEntries;
    }
}
