using Minecraft.Data.Particles;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;

namespace Minecraft.Registry.SubRegistries;

public class ParticleRegistry : ProtocolTypeRegistry<ParticleRegistry, IParticle> {
    public override Identifier RegistryId => "minecraft:particle_type";
}
