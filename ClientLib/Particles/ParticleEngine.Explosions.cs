using Minecraft.Data.Particles;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;

namespace ClientLib.Particles;

public sealed partial class ParticleEngine {
    /// <summary><c>ClientExplosionTracker.MAX_PARTICLES_PER_TICK</c>.</summary>
    private const int MaxExplosionParticlesPerTick = 512;

    private readonly List<ClientBoundExplosionPacket> _explosions = [];

    /// <summary>
    /// The particles of <c>ClientPacketListener.handleExplosion</c>: the explosion's own at its centre now, and its
    /// block particles kept for <see cref="TickExplosions"/>.
    /// </summary>
    public void HandleExplosion(ClientBoundExplosionPacket explosion) {
        if (!Enabled) {
            return;
        }
        AddParticle(explosion.ExplosionParticle, explosion.Center.X, explosion.Center.Y, explosion.Center.Z, 1.0, 0.0, 0.0);
        if (explosion.BlockParticles.Length > 0) {
            _explosions.Add(explosion);
        }
    }

    /// <summary>
    /// <c>ClientExplosionTracker.tick</c>: up to 512 particles a tick thrown out from the explosions since the last,
    /// each from an explosion picked by its block count, at a point picked inside its radius that is open air.
    /// Only on All.
    /// </summary>
    public void TickExplosions() {
        if (_explosions.Count == 0) {
            return;
        }
        if (_client.Options.Particles != ParticleStatus.All || !Ready()) {
            _explosions.Clear();
            return;
        }
        int totalBlocks = 0;
        foreach (ClientBoundExplosionPacket explosion in _explosions) {
            totalBlocks += Math.Max(0, explosion.BlockCount);
        }
        int totalParticles = Math.Min(totalBlocks, MaxExplosionParticlesPerTick);
        for (int i = 0; i < totalParticles; i++) {
            // WeightedRandom.getRandomItem by block count.
            int pick = Random.NextInt(totalBlocks);
            foreach (ClientBoundExplosionPacket explosion in _explosions) {
                pick -= Math.Max(0, explosion.BlockCount);
                if (pick < 0) {
                    ExplosionParticle(explosion);
                    break;
                }
            }
        }
        _explosions.Clear();
    }

    /// <summary><c>ClientExplosionTracker.addParticle</c>.</summary>
    private void ExplosionParticle(ClientBoundExplosionPacket explosion) {
        double dx = Random.NextFloat() * 2.0F - 1.0F, dy = Random.NextFloat() * 2.0F - 1.0F, dz = Random.NextFloat() * 2.0F - 1.0F;
        double length = Math.Sqrt(dx * dx + dy * dy + dz * dz);
        if (length < 1.0E-5F) {
            (dx, dy, dz) = (0.0, 0.0, 0.0);
        }
        else {
            (dx, dy, dz) = (dx / length, dy / length, dz / length);
        }
        float radius = MathF.Cbrt(Random.NextFloat()) * explosion.Radius;
        double lx = dx * radius, ly = dy * radius, lz = dz * radius;
        double cx = explosion.Center.X, cy = explosion.Center.Y, cz = explosion.Center.Z;
        if (!_level!.IsAir(_level.GetState((int)Math.Floor(cx + lx), (int)Math.Floor(cy + ly), (int)Math.Floor(cz + lz)))) {
            return;
        }
        float speed = 0.5F / (radius / explosion.Radius + 0.1F) * Random.NextFloat() * Random.NextFloat() + 0.3F;
        ClientBoundExplosionPacket.BlockParticle info = PickBlockParticle(explosion.BlockParticles);
        AddParticle(info.Particle, cx + lx * info.Scaling, cy + ly * info.Scaling, cz + lz * info.Scaling,
            dx * speed * info.Speed, dy * speed * info.Speed, dz * speed * info.Speed);
    }

    /// <summary><c>WeightedList.getRandomOrThrow</c>.</summary>
    private ClientBoundExplosionPacket.BlockParticle PickBlockParticle(ClientBoundExplosionPacket.BlockParticle[] particles) {
        int total = 0;
        foreach (ClientBoundExplosionPacket.BlockParticle particle in particles) {
            total += Math.Max(0, particle.Weight);
        }
        if (total <= 0) {
            return particles[0];
        }
        int pick = Random.NextInt(total);
        foreach (ClientBoundExplosionPacket.BlockParticle particle in particles) {
            pick -= Math.Max(0, particle.Weight);
            if (pick < 0) {
                return particle;
            }
        }
        return particles[^1];
    }
}
