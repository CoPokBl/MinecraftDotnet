using ClientLib.Entities;
using Minecraft.Data.Particles;
using Minecraft.Physics;
using Particle = Minecraft.Data.Generated.Particle;

namespace ClientLib.Particles;

public sealed partial class ParticleEngine {
    /// <summary>A drip's stage, in <see cref="ParticleState.Variant"/>.</summary>
    internal const byte DripPlain = 0, DripHang = 1, DripCoolingHang = 2, DripFalling = 3, DripFallAndLand = 4;

    private static IParticle ById(int id) => Minecraft.Data.Generated.VanillaRegistry.Data.Particles[id];

    private void TickParticle(ref ParticleState p, int index) {
        switch (p.Motion) {
            case ParticleMotion.Standard:
                Standard(ref p);
                break;
            case ParticleMotion.Crit:
                Standard(ref p);
                p.G *= 0.96F;
                p.B *= 0.9F;
                break;
            case ParticleMotion.DustColorTransition:
                if (Standard(ref p)) {
                    p.SetColour(LerpRgb(p.Age / (p.Lifetime + 1.0F), p.I0, p.I1));
                }
                break;
            case ParticleMotion.SimpleAnimated:
                SimpleAnimated(ref p);
                break;
            case ParticleMotion.SquidInk:
                SimpleAnimated(ref p);
                if (!p.Removed && IsAirAt(p.X, p.Y, p.Z)) {
                    p.Yd -= 0.0074F;
                }
                break;
            case ParticleMotion.FireworkSpark:
                FireworkSpark(ref p);
                break;
            case ParticleMotion.Firefly:
                Firefly(ref p);
                break;
            case ParticleMotion.PlayerCloud:
                if (Standard(ref p) && _client.Player is { } player && player.Position.DistanceToSqr(new Maths.Vec3d(p.X, p.Y, p.Z)) <= 4.0
                    && p.Y > player.Position.Y) {
                    p.Y += (player.Position.Y - p.Y) * 0.2;
                    p.Yd += (player.DeltaMovement.Y - p.Yd) * 0.2;
                }
                break;
            case ParticleMotion.DustPlume:
                p.Gravity *= 0.88F;
                p.Friction *= 0.92F;
                Standard(ref p);
                break;
            case ParticleMotion.NoxiousGas:
                Standard(ref p);
                float fadeStart = p.Lifetime / 2.0F;
                if (p.Age > fadeStart) {
                    p.A = (p.Lifetime - (p.Age - fadeStart)) / p.Lifetime;
                }
                break;
            case ParticleMotion.Lava:
                if (Standard(ref p) && Context.Random.NextFloat() > (float)p.Age / p.Lifetime) {
                    Spawn(Particle.Smoke, p.X, p.Y, p.Z, p.Xd, p.Yd, p.Zd);
                }
                break;
            case ParticleMotion.Snowflake:
                Standard(ref p);
                p.Xd *= 0.95F;
                p.Yd *= 0.9F;
                p.Zd *= 0.95F;
                break;
            case ParticleMotion.BubbleColumnUp:
                if (Standard(ref p) && !InWater(p.X, p.Y, p.Z)) {
                    p.Remove();
                }
                break;
            case ParticleMotion.GeyserPlume:
                GeyserPlume(ref p);
                break;
            case ParticleMotion.SulfurBubble:
                SulfurBubble(ref p);
                break;
            case ParticleMotion.Bubble:
                Bubble(ref p);
                break;
            case ParticleMotion.BubblePop:
                if (BeginTick(ref p)) {
                    p.Yd -= p.Gravity;
                    Move(ref p, p.Xd, p.Yd, p.Zd);
                }
                break;
            case ParticleMotion.CampfireSmoke:
                CampfireSmoke(ref p);
                break;
            case ParticleMotion.SuspendedTown:
                SaveOld(ref p);
                if (p.Lifetime-- <= 0) {
                    p.Remove();
                    break;
                }
                p.X += p.Xd;
                p.Y += p.Yd;
                p.Z += p.Zd;
                p.Xd *= 0.99;
                p.Yd *= 0.99;
                p.Zd *= 0.99;
                break;
            case ParticleMotion.WaterCurrentDown:
                if (!BeginTick(ref p)) {
                    break;
                }
                p.Xd = (p.Xd + 0.6F * MathF.Cos(p.F0)) * 0.07;
                p.Zd = (p.Zd + 0.6F * MathF.Sin(p.F0)) * 0.07;
                Move(ref p, p.Xd, p.Yd, p.Zd);
                if (!InWater(p.X, p.Y, p.Z) || p.OnGround) {
                    p.Remove();
                }
                p.F0 += 0.08F;
                break;
            case ParticleMotion.DragonBreath:
                DragonBreath(ref p);
                break;
            case ParticleMotion.Drip:
                Drip(ref p);
                break;
            case ParticleMotion.FallingDust:
                if (!BeginTick(ref p)) {
                    break;
                }
                p.RollO = p.Roll;
                p.Roll += MathF.PI * p.F0 * 2.0F;
                if (p.OnGround) {
                    p.RollO = p.Roll = 0.0F;
                }
                Move(ref p, p.Xd, p.Yd, p.Zd);
                p.Yd = Math.Max(p.Yd - 0.003F, -0.14F);
                break;
            case ParticleMotion.FallingLeaves:
                FallingLeaves(ref p);
                break;
            case ParticleMotion.FlyStraightTowards:
                FlyStraightTowards(ref p);
                break;
            case ParticleMotion.FlyTowardsPosition:
                if (BeginTick(ref p)) {
                    float pos = 1.0F - (float)p.Age / p.Lifetime;
                    float pp = 1.0F - pos;
                    pp *= pp;
                    pp *= pp;
                    p.X = p.Ax + p.Xd * pos;
                    p.Y = p.Ay + p.Yd * pos - pp * 1.2F;
                    p.Z = p.Az + p.Zd * pos;
                }
                break;
            case ParticleMotion.AgeOnly:
                BeginTick(ref p);
                break;
            case ParticleMotion.Portal:
                if (BeginTick(ref p)) {
                    float pos = (float)p.Age / p.Lifetime;
                    float along = 1.0F - (-pos + pos * pos * 2.0F);
                    p.X = p.Ax + p.Xd * along;
                    p.Y = p.Ay + p.Yd * along + (1.0F - pos);
                    p.Z = p.Az + p.Zd * along;
                }
                break;
            case ParticleMotion.ReversePortal:
                if (BeginTick(ref p)) {
                    float speed = (float)p.Age / p.Lifetime;
                    p.X += p.Xd * speed;
                    p.Y += p.Yd * speed;
                    p.Z += p.Zd * speed;
                }
                break;
            case ParticleMotion.Shriek:
                if (p.I0 > 0) {
                    p.I0--;
                    break;
                }
                p.Set(ParticleFlags.Hidden, false);
                Standard(ref p);
                break;
            case ParticleMotion.WaterDrop:
                WaterDrop(ref p);
                break;
            case ParticleMotion.Wake:
                Wake(ref p);
                break;
            case ParticleMotion.Trail:
                if (BeginTick(ref p)) {
                    double alpha = 1.0 / (p.Lifetime - p.Age);
                    p.X += (p.Ax - p.X) * alpha;
                    p.Y += (p.Ay - p.Y) * alpha;
                    p.Z += (p.Az - p.Z) * alpha;
                }
                break;
            case ParticleMotion.Vibration:
                Vibration(ref p);
                break;
            case ParticleMotion.TrackingEmitter:
                TickTrackingEmitter(ref p);
                break;
            case ParticleMotion.ExplosionSeed:
                for (int i = 0; i < 6; i++) {
                    double xx = p.X + (Context.Random.NextDouble() - Context.Random.NextDouble()) * 4.0;
                    double yy = p.Y + (Context.Random.NextDouble() - Context.Random.NextDouble()) * 4.0;
                    double zz = p.Z + (Context.Random.NextDouble() - Context.Random.NextDouble()) * 4.0;
                    Spawn(Particle.Explosion, xx, yy, zz, (float)p.Age / p.Lifetime, 0.0, 0.0);
                }
                if (++p.Age == p.Lifetime) {
                    p.Remove();
                }
                break;
            case ParticleMotion.GustSeed:
                if (p.Age % (p.I0 + 1) == 0) {
                    for (int i = 0; i < 3; i++) {
                        double xx = p.X + (Context.Random.NextDouble() - Context.Random.NextDouble()) * p.F0;
                        double yy = p.Y + (Context.Random.NextDouble() - Context.Random.NextDouble()) * p.F0;
                        double zz = p.Z + (Context.Random.NextDouble() - Context.Random.NextDouble()) * p.F0;
                        Spawn(Particle.Gust, xx, yy, zz, (float)p.Age / p.Lifetime, 0.0, 0.0);
                    }
                }
                if (p.Age++ == p.Lifetime) {
                    p.Remove();
                }
                break;
            case ParticleMotion.GeyserEruption:
                GeyserEruption(ref p);
                break;
            case ParticleMotion.NoxiousGasCloud:
                if (Standard(ref p) && p.Age % 2 == 0) {
                    double angle = Context.Random.NextDouble() * Math.PI * 2.0;
                    double distance = Context.Random.NextFloat() * 3.0F;
                    // PotentSulfurBlockEntity.canBeReachedByNoxiousGas is not checked: the gas may show through a wall.
                    Spawn(Particle.NoxiousGas, Math.Floor(p.X) + 0.5 + Math.Cos(angle) * distance, Math.Floor(p.Y) + 0.25,
                        Math.Floor(p.Z) + 0.5 + Math.Sin(angle) * distance, 0.0, 0.0, 0.0, true);
                }
                break;
        }
    }

    /// <summary>Two RGB colours mixed channel by channel, as stored.</summary>
    private static int LerpRgb(float t, int from, int to) {
        int Channel(int shift) => (int)((from >> shift & 0xFF) + t * ((to >> shift & 0xFF) - (from >> shift & 0xFF)));
        return Channel(16) << 16 | Channel(8) << 8 | Channel(0);
    }

    private static void SaveOld(ref ParticleState p) {
        p.Xo = p.X;
        p.Yo = p.Y;
        p.Zo = p.Z;
    }

    /// <summary>The start every tick shares: the old position saved, then removal once the age passes the lifetime.</summary>
    private static bool BeginTick(ref ParticleState p) {
        SaveOld(ref p);
        if (p.Age++ >= p.Lifetime) {
            p.Remove();
            return false;
        }
        return true;
    }

    /// <summary><c>Particle.tick</c>. False once the particle is removed.</summary>
    private bool Standard(ref ParticleState p) {
        if (!BeginTick(ref p)) {
            return false;
        }
        p.Yd -= 0.04 * p.Gravity;
        Move(ref p, p.Xd, p.Yd, p.Zd);
        if (p.Has(ParticleFlags.SpeedUpWhenBlocked) && p.Y == p.Yo) {
            p.Xd *= 1.1;
            p.Zd *= 1.1;
        }
        p.Xd *= p.Friction;
        p.Yd *= p.Friction;
        p.Zd *= p.Friction;
        if (p.OnGround) {
            p.Xd *= 0.7F;
            p.Zd *= 0.7F;
        }
        return true;
    }

    /// <summary><c>SimpleAnimatedParticle.tick</c>: fading out over the second half, toward the fade colour if it has one.</summary>
    private void SimpleAnimated(ref ParticleState p) {
        Standard(ref p);
        if (p.Age > p.Lifetime / 2) {
            p.A = 1.0F - ((float)p.Age - p.Lifetime / 2) / p.Lifetime;
            if (p.Has(ParticleFlags.Fade)) {
                p.R += (p.F1 - p.R) * 0.2F;
                p.G += (p.F2 - p.G) * 0.2F;
                p.B += (p.F3 - p.B) * 0.2F;
            }
        }
    }

    /// <summary><c>FireworkParticles.SparkParticle</c>: a trail of half aged sparks, and a twinkle that hides it every other three ticks late on.</summary>
    private void FireworkSpark(ref ParticleState p) {
        SimpleAnimated(ref p);
        if (p.Has(ParticleFlags.Trail) && p.Age < p.Lifetime / 2 && (p.Age + p.Lifetime) % 2 == 0) {
            SpawnTrail(in p);
        }
        p.Set(ParticleFlags.Hidden, p.Has(ParticleFlags.Twinkle) && !(p.Age < p.Lifetime / 3 || (p.Age + p.Lifetime) / 3 % 2 == 0));
    }

    private void Firefly(ref ParticleState p) {
        Standard(ref p);
        if (!IsAirAt(p.X, p.Y, p.Z)) {
            p.Remove();
            return;
        }
        p.A = FireflyFade(Math.Clamp((float)p.Age / p.Lifetime, 0.0F, 1.0F), 0.3F, 0.5F);
        if (Context.Random.NextFloat() > 0.95F || p.Age == 1) {
            p.SetSpeed(-0.05F + 0.1F * Context.Random.NextFloat(), -0.05F + 0.1F * Context.Random.NextFloat(), -0.05F + 0.1F * Context.Random.NextFloat());
        }
    }

    /// <summary><c>FireflyParticle.getFadeAmount</c>.</summary>
    public static float FireflyFade(float progress, float fadeInTime, float fadeOutTime) =>
        progress >= 1.0F - fadeInTime ? (1.0F - progress) / fadeInTime : progress <= fadeOutTime ? progress / fadeOutTime : 1.0F;

    /// <summary>
    /// <c>GeyserPlumeParticle.tick</c>: propelled up by a gravity that weakens as it climbs, spraying out and growing,
    /// then gone a few ticks after it stops. Ay and Az hold its start and top, Ax its largest size.
    /// </summary>
    private void GeyserPlume(ref ParticleState p) {
        Standard(ref p);
        if (!p.Has(ParticleFlags.Done) && (p.Yd < 0.0 || p.Y > p.Az || p.Y == p.Yo)) {
            p.Lifetime = Math.Min(p.Lifetime, p.Age + 5);
            p.Friction = 0.0F;
            p.Flags |= ParticleFlags.Done;
        }
        double progress = Math.Clamp((p.Y - p.Ay) / (p.Az - p.Ay), 0.0, 1.0);
        p.Gravity = p.F0 * (float)(progress * progress * progress) * 0.12F;
        p.Xd = progress * p.F1;
        p.Zd = progress * p.F2;
        p.Size = p.F3 + (float)(progress * (p.Ax - p.F3));
    }

    /// <summary><c>SulfurBubbleParticle.tick</c>: rising through a water source, swelling, for at most three blocks.</summary>
    private void SulfurBubble(ref ParticleState p) {
        Standard(ref p);
        Minecraft.Data.Blocks.IBlock block = BlockAt((int)Math.Floor(p.X), (int)Math.Floor(p.Y), (int)Math.Floor(p.Z));
        bool waterSource = block is Minecraft.Data.Generated.BlockTypes.WaterBlock water ? water.Level == 0 : block.Fluid?.Key == "water";
        if (!p.Removed && !waterSource) {
            p.Remove();
        }
        if (!p.Removed && p.Y >= p.Az) {
            p.Remove();
        }
        if (!p.Removed && p.Y <= p.Ax) {
            p.Remove();
        }
        p.Xd += Wiggle();
        p.Zd += Wiggle();
        Move(ref p, p.Xd, 0.0, p.Zd);
        float travel = (float)((p.Y - p.Ay) / (p.Az - p.Ay));
        p.Size = p.F0 + travel * (0.15F - p.F0);
        p.Ax = p.Y;

        double Wiggle() => Context.Random.NextFloat() * 0.003F * (Context.Random.NextBool() ? 1 : -1) * 0.5;
    }

    private void Bubble(ref ParticleState p) {
        SaveOld(ref p);
        if (p.Lifetime-- <= 0) {
            p.Remove();
            return;
        }
        p.Yd += 0.002;
        Move(ref p, p.Xd, p.Yd, p.Zd);
        p.Xd *= 0.85F;
        p.Yd *= 0.85F;
        p.Zd *= 0.85F;
        if (!InWater(p.X, p.Y, p.Z)) {
            p.Remove();
        }
    }

    private void CampfireSmoke(ref ParticleState p) {
        SaveOld(ref p);
        if (p.Age++ >= p.Lifetime || p.A <= 0.0F) {
            p.Remove();
            return;
        }
        p.Xd += Context.Random.NextFloat() / 5000.0F * (Context.Random.NextBool() ? 1 : -1);
        p.Zd += Context.Random.NextFloat() / 5000.0F * (Context.Random.NextBool() ? 1 : -1);
        p.Yd -= p.Gravity;
        Move(ref p, p.Xd, p.Yd, p.Zd);
        if (p.Age >= p.Lifetime - 60 && p.A > 0.01F) {
            p.A -= 0.015F;
        }
    }

    private void DragonBreath(ref ParticleState p) {
        if (!BeginTick(ref p)) {
            return;
        }
        if (p.OnGround) {
            p.Yd = 0.0;
            p.Flags |= ParticleFlags.Done;
        }
        bool landed = p.Has(ParticleFlags.Done);
        if (landed) {
            p.Yd += 0.002;
        }
        Move(ref p, p.Xd, p.Yd, p.Zd);
        if (p.Y == p.Yo) {
            p.Xd *= 1.1;
            p.Zd *= 1.1;
        }
        p.Xd *= p.Friction;
        p.Zd *= p.Friction;
        if (landed) {
            p.Yd *= p.Friction;
        }
    }

    /// <summary>
    /// <c>DripParticle</c> and its stages: hanging under the block, then falling, then gone into a fluid of its own
    /// kind or onto the ground, where a falling drip that lands makes its landing particle (<see cref="ParticleState.I0"/>).
    /// </summary>
    private void Drip(ref ParticleState p) {
        SaveOld(ref p);
        if (p.Variant == DripCoolingHang) {
            p.R = 1.0F;
            p.G = 16.0F / (40 - p.Lifetime + 16);
            p.B = 4.0F / (40 - p.Lifetime + 8);
        }
        if (p.Lifetime-- <= 0) {
            p.Remove();
            if (p.Variant is DripHang or DripCoolingHang) {
                Spawn(ById(p.I0), p.X, p.Y, p.Z, p.Xd, p.Yd, p.Zd);
            }
            return;
        }
        p.Yd -= p.Gravity;
        Move(ref p, p.Xd, p.Yd, p.Zd);
        switch (p.Variant) {
            case DripHang or DripCoolingHang:
                p.Xd *= 0.02;
                p.Yd *= 0.02;
                p.Zd *= 0.02;
                break;
            case DripFalling when p.OnGround:
                p.Remove();
                return;
            case DripFallAndLand when p.OnGround:
                p.Remove();
                Spawn(ById(p.I0), p.X, p.Y, p.Z, 0.0, 0.0, 0.0);
                return;
        }
        p.Xd *= 0.98F;
        p.Yd *= 0.98F;
        p.Zd *= 0.98F;
        if (p.I1 != 0) {
            int x = (int)Math.Floor(p.X), y = (int)Math.Floor(p.Y), z = (int)Math.Floor(p.Z);
            (byte fluid, float height) = FluidAt(x, y, z);
            if (fluid == p.I1 && p.Y < y + height) {
                p.Remove();
            }
        }
    }

    /// <summary><c>FallingLeavesParticle.tick</c>: drifting and spinning down, gone on landing or when stopped sideways.</summary>
    private void FallingLeaves(ref ParticleState p) {
        SaveOld(ref p);
        if (p.Lifetime-- <= 0) {
            p.Remove();
            return;
        }
        float relativeAge = Math.Min((300 - p.Lifetime) / 300.0F, 1.0F);
        double xa = 0.0, za = 0.0;
        if ((p.Variant & 2) != 0) {
            xa += p.Ax * Math.Pow(relativeAge, 1.25);
            za += p.Ay * Math.Pow(relativeAge, 1.25);
        }
        if ((p.Variant & 1) != 0) {
            xa += relativeAge * Math.Cos(relativeAge * p.Az) * p.F2;
            za += relativeAge * Math.Sin(relativeAge * p.Az) * p.F2;
        }
        p.Xd += xa * 0.0025F;
        p.Zd += za * 0.0025F;
        p.Yd -= p.Gravity;
        p.F0 += p.F1 / 20.0F;
        p.RollO = p.Roll;
        p.Roll += p.F0 / 20.0F;
        Move(ref p, p.Xd, p.Yd, p.Zd);
        if (p.OnGround || p.Lifetime < 299 && (p.Xd == 0.0 || p.Zd == 0.0)) {
            p.Remove();
        }
    }

    /// <summary><c>FlyStraightTowardsParticle.tick</c>: from the offset back to the start, the colour going from I0 to I1.</summary>
    private static void FlyStraightTowards(ref ParticleState p) {
        if (!BeginTick(ref p)) {
            return;
        }
        float age = (float)p.Age / p.Lifetime;
        float left = 1.0F - age;
        p.X = p.Ax + p.Xd * left;
        p.Y = p.Ay + p.Yd * left;
        p.Z = p.Az + p.Zd * left;
        // ARGB.srgbLerp: each channel lerped as stored.
        int from = p.I0, to = p.I1;
        float Channel(int shift) => ((from >> shift & 0xFF) + age * ((to >> shift & 0xFF) - (from >> shift & 0xFF))) / 255.0F;
        p.SetColour(Channel(16), Channel(8), Channel(0));
        p.A = Channel(24);
    }

    private void WaterDrop(ref ParticleState p) {
        SaveOld(ref p);
        if (p.Lifetime-- <= 0) {
            p.Remove();
            return;
        }
        p.Yd -= p.Gravity;
        Move(ref p, p.Xd, p.Yd, p.Zd);
        p.Xd *= 0.98F;
        p.Yd *= 0.98F;
        p.Zd *= 0.98F;
        if (p.OnGround) {
            if (Context.Random.NextFloat() < 0.5F) {
                p.Remove();
            }
            p.Xd *= 0.7F;
            p.Zd *= 0.7F;
        }
        int x = (int)Math.Floor(p.X), y = (int)Math.Floor(p.Y), z = (int)Math.Floor(p.Z);
        double top = 0.0;
        foreach (Box box in CollisionOf(StateAt(x, y, z))) {
            double rx = p.X - x, rz = p.Z - z;
            if (rx >= box.MinX && rx <= box.MaxX && rz >= box.MinZ && rz <= box.MaxZ) {
                top = Math.Max(top, box.MaxY);
            }
        }
        double offset = Math.Max(top, FluidAt(x, y, z).Height);
        if (offset > 0.0 && p.Y < y + offset) {
            p.Remove();
        }
    }

    private void Wake(ref ParticleState p) {
        SaveOld(ref p);
        int life = 60 - p.Lifetime;
        if (p.Lifetime-- <= 0) {
            p.Remove();
            return;
        }
        p.Yd -= p.Gravity;
        Move(ref p, p.Xd, p.Yd, p.Zd);
        p.Xd *= 0.98F;
        p.Yd *= 0.98F;
        p.Zd *= 0.98F;
        float size = life * 0.001F;
        p.Width = p.Height = size;
        p.SpriteNum = life % 4;
        p.SpriteDen = 4;
    }

    /// <summary>
    /// <c>VibrationSignalParticle.tick</c>: closing a share of the way to the target each tick so it arrives on
    /// time, facing along the way. The target is the entity <see cref="ParticleState.I0"/> raised by Ay when
    /// <see cref="ParticleState.I1"/> is set, otherwise the block centre at Ax to Az.
    /// </summary>
    private void Vibration(ref ParticleState p) {
        if (!BeginTick(ref p)) {
            return;
        }
        if (!VibrationTarget(ref p, out double tx, out double ty, out double tz)) {
            p.Remove();
            return;
        }
        double alpha = 1.0 / (p.Lifetime - p.Age);
        p.X += (tx - p.X) * alpha;
        p.Y += (ty - p.Y) * alpha;
        p.Z += (tz - p.Z) * alpha;
        double dx = p.X - tx, dy = p.Y - ty, dz = p.Z - tz;
        p.F1 = p.F0;
        p.F0 = (float)Math.Atan2(dx, dz);
        p.F3 = p.F2;
        p.F2 = (float)Math.Atan2(dy, Math.Sqrt(dx * dx + dz * dz));
    }

    internal bool VibrationTarget(ref ParticleState p, out double x, out double y, out double z) {
        if (p.I1 == 0) {
            (x, y, z) = (p.Ax, p.Ay, p.Az);
            return true;
        }
        if (_client.Entities.TryGetValue(p.I0, out ClientEntity? entity)) {
            (x, y, z) = (entity.Position.X, entity.Position.Y + p.Ay, entity.Position.Z);
            return true;
        }
        (x, y, z) = (0, 0, 0);
        return false;
    }

    /// <summary><c>TrackingEmitter.tick</c>: up to sixteen particles from inside the entity's box, thrown outward and up.</summary>
    private void TickTrackingEmitter(ref ParticleState p) {
        if (!_client.Entities.TryGetValue(p.I0, out ClientEntity? entity)) {
            p.Remove();
            return;
        }
        IParticle options = _emitted[p.TextureArg];
        Box box = entity.BoundingBox;
        double width = box.MaxX - box.MinX, height = box.MaxY - box.MinY;
        for (int i = 0; i < 16; i++) {
            double xa = Context.Random.NextFloat() * 2.0F - 1.0F;
            double ya = Context.Random.NextFloat() * 2.0F - 1.0F;
            double za = Context.Random.NextFloat() * 2.0F - 1.0F;
            if (xa * xa + ya * ya + za * za > 1.0) {
                continue;
            }
            Spawn(options, entity.Position.X + width * (xa / 4.0), entity.Position.Y + height * (0.5 + ya / 4.0), entity.Position.Z + width * (za / 4.0),
                xa, ya + 0.2, za);
        }
        if (++p.Age >= p.Lifetime) {
            p.Remove();
        }
    }

    /// <summary>
    /// <c>GeyserEruptionParticle.tick</c>: a base of foam every other tick, a plume each tick and a burst every ten.
    /// I0 is the water above it; Ax to Az the motion it was made with.
    /// </summary>
    private void GeyserEruption(ref ParticleState p) {
        if (!Standard(ref p)) {
            return;
        }
        Minecraft.Data.Particles.Types.GeyserParticle plume = Particle.GeyserPlume with { WaterBlocks = p.I0 };
        Minecraft.Data.Particles.Types.GeyserBaseParticle foam = Particle.GeyserBase with { WaterBlocks = p.I0, BurstImpulseBase = 1.5F };
        Minecraft.Data.Particles.Types.GeyserBaseParticle poof = Particle.GeyserPoof with { WaterBlocks = p.I0, BurstImpulseBase = 2.0F };
        if (p.Age % 2 == 0) {
            for (int i = 0; i < 2; i++) {
                Spawn(foam, p.X, p.Y, p.Z, p.Ax, p.Ay, p.Az);
            }
        }
        for (int i = 0; i < p.I0 + 2; i++) {
            Spawn(plume, p.X, p.Y, p.Z, p.Ax, p.Ay, p.Az);
        }
        if (p.Age % 10 == 0) {
            for (int i = 0; i < 20; i++) {
                Spawn(poof, p.X, p.Y, p.Z, p.Ax, p.Ay, p.Az);
            }
        }
    }
}
