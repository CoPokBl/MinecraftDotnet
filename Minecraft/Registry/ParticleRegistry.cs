using Minecraft.Data.Particles;
using Minecraft.Schemas;

namespace Minecraft.Registry;

public class ParticleRegistry {
    private readonly Dictionary<Identifier, IParticle> _byName = new();
    private readonly Dictionary<int, IParticle> _byId = new();

    public IParticle this[Identifier name] => _byName[name];
    public IParticle this[int id] => _byId[id];

    public void Add(Identifier identifier, int netId, IParticle particle) {
        _byName.Add(identifier, particle);
        _byId.Add(netId, particle);
    }
}
