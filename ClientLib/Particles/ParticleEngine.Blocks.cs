using Particle = Minecraft.Data.Generated.Particle;

namespace ClientLib.Particles;

public sealed partial class ParticleEngine {
    /// <summary>
    /// <c>CampfireBlock.makeParticles</c>: a column of smoke rising from the fire, always visible and past the
    /// distance limit, and a wisp of plain smoke too when the fire is being put out.
    /// </summary>
    public void CampfireSmoke(int x, int y, int z, bool signalFire, bool smoking) {
        ParticleRandom random = Random;
        AddAlwaysVisibleParticle(signalFire ? Particle.CampfireSignalSmoke : Particle.CampfireCosySmoke, true,
            x + 0.5 + random.NextDouble() / 3.0 * (random.NextBool() ? 1 : -1),
            y + random.NextDouble() + random.NextDouble(),
            z + 0.5 + random.NextDouble() / 3.0 * (random.NextBool() ? 1 : -1),
            0.0, 0.07, 0.0);
        if (smoking) {
            AddParticle(Particle.Smoke,
                x + 0.5 + random.NextDouble() / 4.0 * (random.NextBool() ? 1 : -1),
                y + 0.4,
                z + 0.5 + random.NextDouble() / 4.0 * (random.NextBool() ? 1 : -1),
                0.0, 0.005, 0.0);
        }
    }
}
