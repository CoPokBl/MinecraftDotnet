using ClientLib.Entities;
using ClientLib.Interaction;
using ClientLib.Maths;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Items;
using Particle = Minecraft.Data.Generated.Particle;

namespace ClientLib.Particles;

/// <summary><c>ClientLevel.createFireworks</c> and the particle half of <c>FireworkParticles.Starter</c>.</summary>
public sealed partial class EntityParticles {
    /// <summary><c>DyeColor.BLACK.getFireworkColor</c>, for an explosion with no colours.</summary>
    private const int BlackFireworkColour = 0x1E1B1B;

    private static readonly double[][] CreeperParticleCoords = [
        [0.0, 0.2], [0.2, 0.2], [0.2, 0.6], [0.6, 0.6], [0.6, 0.2], [0.2, 0.2], [0.2, 0.0], [0.4, 0.0], [0.4, -0.6], [0.2, -0.6], [0.2, -0.4], [0.0, -0.4]
    ];

    private static readonly double[][] StarParticleCoords = [
        [0.0, 1.0], [0.3455, 0.309], [0.9511, 0.309], [0.3795918367346939, -0.12653061224489795], [0.6122448979591837, -0.8040816326530612],
        [0.0, -0.35918367346938773]
    ];

    private readonly List<FireworkStarter> _fireworks = [];

    /// <summary>
    /// A starter's burst in progress: one explosion every other tick from the tick after the rocket went off.
    /// Its sounds are whoever plays the client's sounds; this is only the sparks and the flash.
    /// </summary>
    private sealed class FireworkStarter(double x, double y, double z, double xd, double yd, double zd, FireworkExplosionComponent.Data[] explosions) {
        public readonly double X = x, Y = y, Z = z, Xd = xd, Yd = yd, Zd = zd;
        public readonly FireworkExplosionComponent.Data[] Explosions = explosions;
        public int Life;
    }

    /// <summary><c>FireworkRocketEntity.handleEntityEvent(17)</c> into <c>ClientLevel.createFireworks</c>; with no explosions, only a poof.</summary>
    private void CreateFireworks(ClientEntity rocket) {
        ItemStack item = rocket.Get(EntityDataFields.FireworkRocketEntity.IdFireworksItem) ?? ItemStack.Air;
        FireworkExplosionComponent.Data[] explosions = ItemComponents.Get(item, DataComponent.Fireworks)?.Explosions ?? [];
        Vec3d at = rocket.Position, movement = rocket.DeltaMovement;
        if (explosions.Length == 0) {
            for (int i = 0; i < R.NextInt(3) + 2; i++) {
                Add(Particle.Poof, at.X, at.Y, at.Z, R.NextGaussian() * 0.05, 0.005, R.NextGaussian() * 0.05);
            }
            return;
        }
        _fireworks.Add(new FireworkStarter(at.X, at.Y, at.Z, movement.X, movement.Y, movement.Z, explosions));
    }

    private void TickFireworks() {
        for (int i = _fireworks.Count - 1; i >= 0; i--) {
            FireworkStarter starter = _fireworks[i];
            if (starter.Life % 2 == 0 && starter.Life / 2 < starter.Explosions.Length) {
                Explode(starter, starter.Explosions[starter.Life / 2]);
            }
            starter.Life++;
            if (starter.Life / 2 >= starter.Explosions.Length) {
                _fireworks.RemoveAt(i);
            }
        }
    }

    /// <summary><c>FireworkParticles.Starter.tick</c>'s explosion: the shape's sparks, then a flash in its first colour.</summary>
    private void Explode(FireworkStarter starter, FireworkExplosionComponent.Data explosion) {
        int[] colours = explosion.Colors.Length > 0 ? explosion.Colors : [BlackFireworkColour];
        switch (explosion.Shape) {
            case FireworkShape.SmallBall:
                ParticleBall(starter, 0.25, 2, colours, explosion);
                break;
            case FireworkShape.LargeBall:
                ParticleBall(starter, 0.5, 4, colours, explosion);
                break;
            case FireworkShape.Star:
                ParticleShape(starter, 0.5, StarParticleCoords, colours, explosion, false);
                break;
            case FireworkShape.Creeper:
                ParticleShape(starter, 0.5, CreeperParticleCoords, colours, explosion, true);
                break;
            case FireworkShape.Burst:
                ParticleBurst(starter, colours, explosion);
                break;
        }
        _engine.CreateParticle(Particle.Flash with { Argb = colours[0] }, starter.X, starter.Y, starter.Z, 0.0, 0.0, 0.0);
    }

    /// <summary><c>Starter.createParticle</c>: a spark, with no distance or Particles check, in one of the colours.</summary>
    private void Spark(FireworkStarter starter, double xa, double ya, double za, int[] colours, FireworkExplosionComponent.Data explosion) {
        int handle = _engine.SpawnSpark(starter.X, starter.Y, starter.Z, xa, ya, za);
        if (handle < 0) {
            return;
        }
        int colour = colours[R.NextInt(colours.Length)];
        int fade = explosion.FadeColors.Length > 0 ? explosion.FadeColors[R.NextInt(explosion.FadeColors.Length)] : 0;
        ref ParticleState p = ref _engine[handle];
        p.Trail = explosion.HasTrail;
        p.Twinkle = explosion.HasTwinkle;
        p.A = 0.99F;
        p.SetColour(colour);
        if (explosion.FadeColors.Length > 0) {
            p.SetFadeColour(fade);
        }
    }

    private void ParticleBall(FireworkStarter starter, double baseSpeed, int steps, int[] colours, FireworkExplosionComponent.Data explosion) {
        for (int yStep = -steps; yStep <= steps; yStep++) {
            for (int xStep = -steps; xStep <= steps; xStep++) {
                for (int zStep = -steps; zStep <= steps; zStep++) {
                    double xa = xStep + (R.NextDouble() - R.NextDouble()) * 0.5;
                    double ya = yStep + (R.NextDouble() - R.NextDouble()) * 0.5;
                    double za = zStep + (R.NextDouble() - R.NextDouble()) * 0.5;
                    double len = Math.Sqrt(xa * xa + ya * ya + za * za) / baseSpeed + R.NextGaussian() * 0.05;
                    Spark(starter, xa / len, ya / len, za / len, colours, explosion);
                    // Only the shell: inside the outer layers a row jumps straight to its far face.
                    if (yStep != -steps && yStep != steps && xStep != -steps && xStep != steps) {
                        zStep += steps * 2 - 1;
                    }
                }
            }
        }
    }

    private void ParticleShape(FireworkStarter starter, double baseSpeed, double[][] coords, int[] colours, FireworkExplosionComponent.Data explosion, bool flat) {
        double sx = coords[0][0], sy = coords[0][1];
        Spark(starter, sx * baseSpeed, sy * baseSpeed, 0.0, colours, explosion);
        float baseAngle = R.NextFloat() * MathF.PI;
        double angleMod = flat ? 0.034 : 0.34;
        for (int angleStep = 0; angleStep < 3; angleStep++) {
            double angle = baseAngle + angleStep * MathF.PI * angleMod;
            double ox = sx, oy = sy;
            for (int c = 1; c < coords.Length; c++) {
                double tx = coords[c][0], ty = coords[c][1];
                for (double subStep = 0.25; subStep <= 1.0; subStep += 0.25) {
                    double xa = Lerp(subStep, ox, tx) * baseSpeed;
                    double ya = Lerp(subStep, oy, ty) * baseSpeed;
                    double za = xa * Math.Sin(angle);
                    xa *= Math.Cos(angle);
                    for (double flip = -1.0; flip <= 1.0; flip += 2.0) {
                        Spark(starter, xa * flip, ya, za * flip, colours, explosion);
                    }
                }
                ox = tx;
                oy = ty;
            }
        }
    }

    private void ParticleBurst(FireworkStarter starter, int[] colours, FireworkExplosionComponent.Data explosion) {
        double baseOffX = R.NextGaussian() * 0.05, baseOffZ = R.NextGaussian() * 0.05;
        for (int i = 0; i < 70; i++) {
            double xa = starter.Xd * 0.5 + R.NextGaussian() * 0.15 + baseOffX;
            double za = starter.Zd * 0.5 + R.NextGaussian() * 0.15 + baseOffZ;
            double ya = starter.Yd * 0.5 + R.NextDouble() * 0.5;
            Spark(starter, xa, ya, za, colours, explosion);
        }
    }
}
