using Minecraft.Schemas.Particles.Types;
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
    
    /// <summary>
    /// Writes the data for this particle to the given writer.
    /// DOES NOT include the particle ID.
    /// </summary>
    /// <param name="writer">The object to write to.</param>
    /// <returns>The writer object.</returns>
    public DataWriter WriteData(DataWriter writer);
    public IParticle ReadData(DataReader reader);

    public static IParticle Simple(int id) {
        return new SimpleParticle(id);
    }

    public static IParticle Simple(string name) {
        return new SimpleParticle(IdOf(name));
    }

    private static int IdOf(string name) {
        return ParticleRegistry[name].ThrowIfNull();
    }
    
    private static string FromId(int id) {
        return ParticleRegistry[id].ThrowIfNull();
    }

    public static IParticle DefaultOfType(int id) {
        return DefaultOfType(FromId(id));
    }

    public static IParticle DefaultOfType(string name) {
        return name switch {
            "minecraft:block" => new BlockParticle(IdOf(name)),
            "minecraft:block_marker" => new BlockMarkerParticle(IdOf(name)),
            "minecraft:dust" => new DustParticle(IdOf(name)),
            "minecraft:dust_color_transition" => new DustColorTransitionParticle(IdOf(name)),
            "minecraft:entity_effect" => new EntityEffectParticle(IdOf(name)),
            "minecraft:falling_dust" => new FallingDustParticle(IdOf(name)),
            "minecraft:sculk_charge" => new SculkChargeParticle(IdOf(name)),
            "minecraft:item" => new ItemParticle(IdOf(name)),
            "minecraft:vibration" => new VibrationParticle(IdOf(name)),
            "minecraft:trail" => new TrailParticle(IdOf(name)),
            "minecraft:shriek" => new ShriekParticle(IdOf(name)),
            "minecraft:dust_pillar" => new DustPillarParticle(IdOf(name)),
            "minecraft:block_crumble" => new BlockCrumbleParticle(IdOf(name)),
            _ => Simple(name)
        };
    }
    
    public static IParticle ReadData(int id, DataReader reader) {
        return DefaultOfType(id).ReadData(reader);
    }
}
