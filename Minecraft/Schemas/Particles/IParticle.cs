using Minecraft.Schemas.Registry;
using Newtonsoft.Json.Linq;

namespace Minecraft.Schemas.Particles;

public interface IParticle {
    private const string RegistryName = "minecraft:particle_type";
    public static OneToOneDictionary<string, int> ParticleRegistry { get; } = new();

    static IParticle() {
        JObject registry = MinecraftRegistryData.Registries[RegistryName];
        foreach (KeyValuePair<string, JToken?> kvp in registry) {
            if (kvp.Value is JObject entry) {
                ParticleRegistry.Add(kvp.Key, entry["protocol_id"]!.Value<int>());
            }
        }
    }
    
    public int Id { get; }
    
    public DataWriter WriteData(DataWriter writer);
    public IParticle ReadData(DataReader reader);

    public static IParticle Simple(int id) {
        return new SimpleParticle(id);
    }

    private static int IdOf(string name) {
        return ParticleRegistry[name];
    }
    
    private static string FromId(int id) {
        return ParticleRegistry[id];
    }

    public static IParticle DefaultOfType(int id) {
        return DefaultOfType(FromId(id));
    }

    public static IParticle DefaultOfType(string name) {
        return name switch {
            _ => Simple(IdOf(name))
        };
    }
}
