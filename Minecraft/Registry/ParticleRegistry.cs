using Minecraft.Data.Particles;
using Minecraft.Schemas;

namespace Minecraft.Registry;

public class ParticleRegistry {
    private readonly Dictionary<Identifier, IParticle> ByName = new();
    private readonly Dictionary<int, IParticle> ById = new();

    public IParticle this[Identifier name] => ByName[name];
    public IParticle this[int id] => ById[id];

    public void Add(Identifier identifier, int netId, IParticle particle) {
        ByName.Add(identifier, particle);
        ById.Add(netId, particle);
    }
}
