using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

public static class ParticleCodeGen {

    public static string CreateParticleEntries(JObject registriesJson) {
        return CodeGenUtils.CreateSimpleAndComplexRegistryEntries(
            CodeGenUtils.BuildRegularRegistryEntries(registriesJson, "minecraft:particle_type"),
            "SimpleParticle",
            JObject.Parse(CodeGenUtils.ReadEmbeddedFile("complex_particles.json")),
            "Particle",
            "Particles",
            "Particles");
    }
}
