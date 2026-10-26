using ClientLib.Entities;
using ClientLib.Interaction;
using ClientLib.Maths;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Data.Particles;
using Minecraft.Data.Particles.Types;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Items;
using Attribute = Minecraft.Data.Generated.Attribute;
using Particle = Minecraft.Data.Generated.Particle;

namespace ClientLib.Particles;

/// <summary>The particles of each entity class's own client tick.</summary>
public sealed partial class EntityParticles {
    private static readonly EntityEffectParticle RavagerStun = Particle.EntityEffect with { Argb = Opaque(0.49803922F, 0.5137255F, 0.57254905F) };
    private static readonly EntityEffectParticle WitherPowered = Particle.EntityEffect with { Argb = Opaque(0.7F, 0.7F, 0.5F) };
    private static readonly EntityEffectParticle WitherInvulnerable = Particle.EntityEffect with { Argb = Opaque(0.7F, 0.7F, 0.9F) };
    private static readonly SpellParticle SpectralTrail = Particle.Effect with { Rgb = -1, Power = 1.0F };
    private static readonly DragonBreathParticle DragonBreath = Particle.DragonBreath with { Power = 1.0F };
    private static readonly EntityEffectParticle AreaEffectCloudDefault = Particle.EntityEffect with { Argb = -1 };

    /// <summary><c>SpellcasterIllager.IllagerSpell</c>'s colours, by id.</summary>
    private static readonly EntityEffectParticle[] SpellColours = [
        Particle.EntityEffect with { Argb = Opaque(0.0F, 0.0F, 0.0F) },
        Particle.EntityEffect with { Argb = Opaque(0.7F, 0.7F, 0.8F) },
        Particle.EntityEffect with { Argb = Opaque(0.4F, 0.3F, 0.35F) },
        Particle.EntityEffect with { Argb = Opaque(0.7F, 0.5F, 0.2F) },
        Particle.EntityEffect with { Argb = Opaque(0.3F, 0.3F, 0.8F) },
        Particle.EntityEffect with { Argb = Opaque(0.1F, 0.1F, 0.2F) }
    ];

    /// <summary><c>ColorParticleOption.create(type, r, g, b)</c>: <c>ARGB.colorFromFloat</c> at full alpha.</summary>
    private static int Opaque(float r, float g, float b) =>
        unchecked((int)0xFF000000) | (int)(r * 255.0F) << 16 | (int)(g * 255.0F) << 8 | (int)(b * 255.0F);

    private static EmitterKind Classify(ClientEntity entity) {
        bool Is(EntityClass vanillaClass) => entity.Is(vanillaClass);
        if (Is(EntityClass.Display) || Is(EntityClass.Marker) || Is(EntityClass.Interaction) || Is(EntityClass.BlockAttachedEntity)
            || Is(EntityClass.FallingBlockEntity)) {
            return EmitterKind.NoBaseTick;
        }
        return Is(EntityClass.Blaze) ? EmitterKind.Blaze
            : Is(EntityClass.Enderman) ? EmitterKind.EnderMan
            : Is(EntityClass.Endermite) ? EmitterKind.Endermite
            : Is(EntityClass.Guardian) ? EmitterKind.Guardian
            : Is(EntityClass.Phantom) ? EmitterKind.Phantom
            : Is(EntityClass.Ravager) ? EmitterKind.Ravager
            : Is(EntityClass.Breeze) ? EmitterKind.Breeze
            : Is(EntityClass.AbstractCubeMob) ? EmitterKind.CubeMob
            : Is(EntityClass.Illusioner) ? EmitterKind.Illusioner
            : Is(EntityClass.SpellcasterIllager) ? EmitterKind.Spellcaster
            : Is(EntityClass.Warden) ? EmitterKind.Warden
            : Is(EntityClass.EnderDragon) ? EmitterKind.EnderDragon
            : Is(EntityClass.WitherBoss) ? EmitterKind.Wither
            : Is(EntityClass.Bee) ? EmitterKind.Bee
            : Is(EntityClass.Dolphin) ? EmitterKind.Dolphin
            : Is(EntityClass.GlowSquid) ? EmitterKind.GlowSquid
            : Is(EntityClass.AbstractNautilus) ? EmitterKind.Nautilus
            : Is(EntityClass.Panda) ? EmitterKind.Panda
            : Is(EntityClass.Sniffer) ? EmitterKind.Sniffer
            : Is(EntityClass.Wolf) ? EmitterKind.Wolf
            : Is(EntityClass.IronGolem) ? EmitterKind.IronGolem
            : Is(EntityClass.Rabbit) ? EmitterKind.Rabbit
            : Is(EntityClass.Arrow) ? EmitterKind.Arrow
            : Is(EntityClass.SpectralArrow) ? EmitterKind.SpectralArrow
            : Is(EntityClass.AbstractArrow) ? EmitterKind.AbstractArrow
            : Is(EntityClass.DragonFireball) ? EmitterKind.DragonFireball
            : Is(EntityClass.AbstractWindCharge) ? EmitterKind.WindCharge
            : Is(EntityClass.AbstractHurtingProjectile) ? EmitterKind.SmokingProjectile
            : Is(EntityClass.ThrowableProjectile) ? EmitterKind.Throwable
            : Is(EntityClass.ShulkerBullet) ? EmitterKind.ShulkerBullet
            : Is(EntityClass.EyeOfEnder) ? EmitterKind.EyeOfEnder
            : Is(EntityClass.FireworkRocketEntity) ? EmitterKind.FireworkRocket
            : Is(EntityClass.PrimedTnt) ? EmitterKind.PrimedTnt
            : Is(EntityClass.MinecartTNT) ? EmitterKind.MinecartTnt
            : Is(EntityClass.MinecartFurnace) ? EmitterKind.MinecartFurnace
            : Is(EntityClass.AreaEffectCloud) ? EmitterKind.AreaEffectCloud
            : Is(EntityClass.OminousItemSpawner) ? EmitterKind.OminousItemSpawner
            : Is(EntityClass.EvokerFangs) ? EmitterKind.EvokerFangs
            : EmitterKind.Plain;
    }

    private void TickKind(ClientEntity e, EntityEmitter s) {
        switch (s.Kind) {
            case EmitterKind.Blaze: {
                // Blaze.aiStep.
                (float width, float height) = e.Dimensions;
                for (int i = 0; i < 2; i++) {
                    Add(Particle.LargeSmoke, RandomX(e, width, 0.5), RandomY(e, height), RandomZ(e, width, 0.5), 0.0, 0.0, 0.0);
                }
                break;
            }
            case EmitterKind.EnderMan:
            case EmitterKind.Endermite: {
                // EnderMan.aiStep and Endermite.aiStep, the enderman's a quarter block lower.
                (float width, float height) = e.Dimensions;
                double drop = s.Kind == EmitterKind.EnderMan ? 0.25 : 0.0;
                for (int i = 0; i < 2; i++) {
                    Add(Particle.Portal, RandomX(e, width, 0.5), RandomY(e, height) - drop, RandomZ(e, width, 0.5),
                        (R.NextDouble() - 0.5) * 2.0, -R.NextDouble(), (R.NextDouble() - 0.5) * 2.0);
                }
                break;
            }
            case EmitterKind.Guardian:
                TickGuardian(e, s);
                break;
            case EmitterKind.Phantom:
                TickPhantom(e);
                break;
            case EmitterKind.Ravager:
                // Ravager.aiStep's stunEffect, while the stun from event 39 runs.
                if (s.A > 0) {
                    s.A--;
                    if (R.NextInt(6) == 0) {
                        float width = e.Dimensions.Width;
                        double headX = e.Position.X - width * Math.Sin(e.YBodyRot * (MathF.PI / 180.0F)) + (R.NextDouble() * 0.6 - 0.3);
                        double headY = e.Position.Y + e.Dimensions.Height - 0.3;
                        double headZ = e.Position.Z + width * Math.Cos(e.YBodyRot * (MathF.PI / 180.0F)) + (R.NextDouble() * 0.6 - 0.3);
                        Add(RavagerStun, headX, headY, headZ, 0.0, 0.0, 0.0);
                    }
                }
                break;
            case EmitterKind.Breeze:
                TickBreeze(e, s);
                break;
            case EmitterKind.CubeMob:
                TickCubeMob(e, s);
                break;
            case EmitterKind.Illusioner:
                TickIllusioner(e);
                TickSpellcaster(e);
                break;
            case EmitterKind.Spellcaster:
                TickSpellcaster(e);
                break;
            case EmitterKind.Warden:
                TickWarden(e, s);
                break;
            case EmitterKind.EnderDragon:
                TickEnderDragon(e, s);
                break;
            case EmitterKind.Wither:
                TickWither(e);
                break;
            case EmitterKind.Bee:
                // Bee.tick: nectar dripping off a bee carrying it. Pollinated crops are the server's count, 0 here.
                if ((e.Get(EntityDataFields.Bee.Flags) & 8) != 0 && R.NextFloat() < 0.05F) {
                    double y = e.Position.Y + e.Dimensions.Height * 0.5;
                    for (int i = 0; i < R.NextInt(2) + 1; i++) {
                        Add(Particle.FallingNectar, Lerp(R.NextDouble(), e.Position.X - 0.3F, e.Position.X + 0.3F), y,
                            Lerp(R.NextDouble(), e.Position.Z - 0.3F, e.Position.Z + 0.3F), 0.0, 0.0, 0.0);
                    }
                }
                break;
            case EmitterKind.Dolphin:
                TickDolphin(e, s);
                break;
            case EmitterKind.GlowSquid: {
                // GlowSquid.aiStep, every tick.
                (float width, float height) = e.Dimensions;
                Add(Particle.Glow, RandomX(e, width, 0.6), RandomY(e, height), RandomZ(e, width, 0.6), 0.0, 0.0, 0.0);
                break;
            }
            case EmitterKind.Nautilus:
                if (s.InWater == 1) {
                    NautilusBubbles(e);
                }
                break;
            case EmitterKind.Panda:
                TickPanda(e, s);
                break;
            case EmitterKind.Sniffer:
                TickSniffer(e, s);
                break;
            case EmitterKind.Wolf:
                TickWolf(e, s);
                break;
            case EmitterKind.Arrow:
            case EmitterKind.SpectralArrow:
            case EmitterKind.AbstractArrow:
                TickArrow(e, s);
                break;
            case EmitterKind.SmokingProjectile:
            case EmitterKind.DragonFireball:
            case EmitterKind.WindCharge:
                // AbstractHurtingProjectile.tick: applyInertia's bubbles, then createParticleTrail after the move.
                if (s.InWater == 1) {
                    ProjectileBubbles(e.OldPosition, e.DeltaMovement);
                }
                if (s.Kind != EmitterKind.WindCharge) {
                    Add(s.Kind == EmitterKind.DragonFireball ? DragonBreath : Particle.Smoke, e.Position.X, e.Position.Y + 0.5, e.Position.Z, 0.0, 0.0, 0.0);
                }
                break;
            case EmitterKind.Throwable:
                // ThrowableProjectile.applyInertia.
                if (s.InWater == 1) {
                    ProjectileBubbles(e.OldPosition, e.DeltaMovement);
                }
                break;
            case EmitterKind.ShulkerBullet: {
                // ShulkerBullet.tick, behind where it moved to.
                Vec3d movement = e.DeltaMovement;
                Add(Particle.EndRod, e.Position.X - movement.X, e.Position.Y - movement.Y + 0.15, e.Position.Z - movement.Z, 0.0, 0.0, 0.0);
                break;
            }
            case EmitterKind.EyeOfEnder:
                TickEyeOfEnder(e, s);
                break;
            case EmitterKind.FireworkRocket:
                // FireworkRocketEntity.tick: a spark every tick, falling back along the rocket's climb.
                Add(Particle.Firework, e.Position.X, e.Position.Y, e.Position.Z, R.NextGaussian() * 0.05, -e.DeltaMovement.Y * 0.5, R.NextGaussian() * 0.05);
                break;
            case EmitterKind.PrimedTnt:
                // PrimedTnt.tick: a fuse that ran out discarded it before this.
                Add(Particle.Smoke, e.Position.X, e.Position.Y + 0.5, e.Position.Z, 0.0, 0.0, 0.0);
                break;
            case EmitterKind.MinecartTnt:
                // MinecartTNT.tick, the fuse from event 70.
                if (s.A > 0) {
                    s.A--;
                    Add(Particle.Smoke, e.Position.X, e.Position.Y + 0.5, e.Position.Z, 0.0, 0.0, 0.0);
                }
                break;
            case EmitterKind.MinecartFurnace:
                if (e.Get(EntityDataFields.MinecartFurnace.IdFuel) && R.NextInt(4) == 0) {
                    Add(Particle.LargeSmoke, e.Position.X, e.Position.Y + 0.8, e.Position.Z, 0.0, 0.0, 0.0);
                }
                break;
            case EmitterKind.AreaEffectCloud:
                TickAreaEffectCloud(e);
                break;
            case EmitterKind.OminousItemSpawner:
                TickOminousItemSpawner(e);
                break;
            case EmitterKind.EvokerFangs:
                TickEvokerFangs(e, s);
                break;
        }
    }

    private static double Lerp(double delta, double from, double to) => from + delta * (to - from);

    /// <summary>The four bubbles a projectile in water leaves a quarter of its move behind where it started.</summary>
    private void ProjectileBubbles(Vec3d position, Vec3d movement) {
        for (int i = 0; i < 4; i++) {
            Add(Particle.Bubble, position.X - movement.X * 0.25, position.Y - movement.Y * 0.25, position.Z - movement.Z * 0.25, movement.X, movement.Y, movement.Z);
        }
    }

    /// <summary><c>Guardian.aiStep</c> on the client: bubbles off the tail while it swims, and along the beam while it charges.</summary>
    private void TickGuardian(ClientEntity e, EntityEmitter s) {
        int attackTarget = e.Get(EntityDataFields.Guardian.IdAttackTarget);
        // onSyncedDataUpdated restarts clientSideAttackTime whenever the target changes.
        if (attackTarget != s.B) {
            s.B = attackTarget;
            s.A = 0;
        }
        if (!IsAlive(e)) {
            return;
        }
        bool inWater = s.InWater == 1;
        if (e.Get(EntityDataFields.Guardian.IdMoving) && inWater) {
            Vec3d view = ViewVector(e.XRotO, e.YRotO);
            (float width, float height) = e.Dimensions;
            for (int i = 0; i < 2; i++) {
                Add(Particle.Bubble, RandomX(e, width, 0.5) - view.X * 1.5, RandomY(e, height) - view.Y * 1.5, RandomZ(e, width, 0.5) - view.Z * 1.5, 0.0, 0.0, 0.0);
            }
        }
        if (attackTarget == 0) {
            return;
        }
        int attackDuration = e.Is(EntityClass.ElderGuardian) ? 60 : 80;
        if (s.A < attackDuration) {
            s.A++;
        }
        if (!_client.Entities.TryGetValue(attackTarget, out ClientEntity? target) || !target.IsLiving) {
            return;
        }
        double at = (double)s.A / attackDuration;
        double eyeY = e.Position.Y + e.CurrentEyeHeight;
        double dx = target.Position.X - e.Position.X;
        double dy = target.Position.Y + target.Dimensions.Height * 0.5 - eyeY;
        double dz = target.Position.Z - e.Position.Z;
        double dd = Math.Sqrt(dx * dx + dy * dy + dz * dz);
        dx /= dd;
        dy /= dd;
        dz /= dd;
        double dist = R.NextDouble();
        while (dist < dd) {
            dist += 1.8 - at + R.NextDouble() * (1.7 - at);
            Add(Particle.Bubble, e.Position.X + dx * dist, eyeY + dy * dist, e.Position.Z + dz * dist, 0.0, 0.0, 0.0);
        }
    }

    /// <summary><c>Phantom.tick</c>: a wisp off each wing tip, riding the flap.</summary>
    private void TickPhantom(ClientEntity e) {
        int flapOffset = e.Id * 3;
        float anim = Mth.Cos((flapOffset + e.TickCount) * 7.448451F * (MathF.PI / 180.0F) + MathF.PI);
        (float bbWidth, float bbHeight) = e.Dimensions;
        float width = bbWidth * 1.48F;
        float c = Mth.Cos(e.YRot * (MathF.PI / 180.0F)) * width;
        float sn = Mth.Sin(e.YRot * (MathF.PI / 180.0F)) * width;
        float h = (0.3F + anim * 0.45F) * bbHeight * 2.5F;
        Add(Particle.Mycelium, e.Position.X + c, e.Position.Y + h, e.Position.Z + sn, 0.0, 0.0, 0.0);
        Add(Particle.Mycelium, e.Position.X - c, e.Position.Y + h, e.Position.Z - sn, 0.0, 0.0, 0.0);
    }

    /// <summary><c>Breeze.tick</c>: dust kicked off the ground it stands or slides on, and a short trail when it leaps.</summary>
    private void TickBreeze(ClientEntity e, EntityEmitter s) {
        switch (e.Get(EntityDataFields.Entity.Pose, EntityPose.Standing)) {
            case EntityPose.Shooting:
            case EntityPose.Inhaling:
            case EntityPose.Standing:
                s.A = 0;
                BreezeGroundParticles(e, 1);
                break;
            case EntityPose.Sliding:
                BreezeGroundParticles(e, 20);
                break;
            case EntityPose.LongJumping:
                if (++s.A <= 5) {
                    IBlock ground = BreezeGround(e);
                    IParticle particle = Particle.Block with { BlockState = ground };
                    Vec3d movement = e.DeltaMovement;
                    for (int i = 0; i < 3; i++) {
                        Add(particle, e.Position.X + movement.X, e.Position.Y + movement.Y + 0.1F, e.Position.Z + movement.Z, 0.0, 0.0, 0.0);
                    }
                }
                break;
        }
    }

    /// <summary><c>getInBlockState</c> unless that is air, then <c>getBlockStateOn</c>.</summary>
    private IBlock BreezeGround(ClientEntity e) {
        IBlock inBlock = BlockAt((int)Math.Floor(e.Position.X), (int)Math.Floor(e.Position.Y), (int)Math.Floor(e.Position.Z));
        return !inBlock.Air ? inBlock : BlockStateOn(e);
    }

    private void BreezeGroundParticles(ClientEntity e, int amount) {
        if (e.IsPassenger) {
            return;
        }
        IBlock ground = BreezeGround(e);
        if (!Visible(ground)) {
            return;
        }
        IParticle particle = Particle.Block with { BlockState = ground };
        for (int i = 0; i < amount; i++) {
            Add(particle, e.Position.X, e.Position.Y, e.Position.Z, 0.0, 0.0, 0.0);
        }
    }

    /// <summary><c>AbstractCubeMob.tick</c>: a splat of its particle round its feet as it lands.</summary>
    private void TickCubeMob(ClientEntity e, EntityEmitter s) {
        bool onGround = e.OnGround;
        // The first look only learns whether it stands.
        if (s.A == 0) {
            s.A = 1;
            s.Flag = onGround;
            return;
        }
        if (onGround && !s.Flag) {
            IParticle particle = e.Is(EntityClass.MagmaCube) ? Particle.Flame : e.Is(EntityClass.SulfurCube) ? Particle.SulfurCubeGoo : Particle.ItemSlime;
            float size = e.Dimensions.Width * 2.0F;
            float radius = size / 2.0F;
            for (int i = 0; i < size * 16.0F; i++) {
                float dir = R.NextFloat() * (MathF.PI * 2.0F);
                float d = R.NextFloat() * 0.5F + 0.5F;
                float xd = Mth.Sin(dir) * radius * d;
                float zd = Mth.Cos(dir) * radius * d;
                Add(particle, e.Position.X + xd, e.Position.Y, e.Position.Z + zd, 0.0, 0.0, 0.0);
            }
        }
        s.Flag = onGround;
    }

    /// <summary><c>Illusioner.aiStep</c> on the client: a puff of cloud as an invisible illusioner reshuffles its copies.</summary>
    private void TickIllusioner(ClientEntity e) {
        if (!e.IsInvisible || !(e.HurtTime == 1 || e.TickCount % 1200 == 0)) {
            return;
        }
        (float width, float height) = e.Dimensions;
        for (int i = 0; i < 16; i++) {
            // getZ(0.5), not getRandomZ: vanilla puts every puff on one line half a width south.
            Add(Particle.Cloud, RandomX(e, width, 0.5), RandomY(e, height), e.Position.Z + width * 0.5, 0.0, 0.0, 0.0);
        }
    }

    /// <summary><c>SpellcasterIllager.tick</c> on the client: the spell's colour off both raised hands.</summary>
    private void TickSpellcaster(ClientEntity e) {
        int spell = e.Get(EntityDataFields.SpellcasterIllager.SpellCasting);
        if (spell <= 0) {
            return;
        }
        EntityEffectParticle particle = SpellColours[spell < SpellColours.Length ? spell : 0];
        float bodyAngle = e.YBodyRot * (MathF.PI / 180.0F) + Mth.Cos(e.TickCount * 0.6662F) * 0.25F;
        float cos = Mth.Cos(bodyAngle), sin = Mth.Sin(bodyAngle);
        float scale = Scale(e);
        double handDistance = 0.6 * scale, handHeight = 1.8 * scale;
        Add(particle, e.Position.X + cos * handDistance, e.Position.Y + handHeight, e.Position.Z + sin * handDistance, 0.0, 0.0, 0.0);
        Add(particle, e.Position.X - cos * handDistance, e.Position.Y + handHeight, e.Position.Z - sin * handDistance, 0.0, 0.0, 0.0);
    }

    /// <summary>
    /// <c>Warden.clientDiggingParticles</c>: earth thrown up for the first 4.5 seconds of emerging or digging,
    /// timed from when the pose arrived as the animation states are.
    /// </summary>
    private void TickWarden(ClientEntity e, EntityEmitter s) {
        EntityPose pose = e.Get(EntityDataFields.Entity.Pose, EntityPose.Standing);
        if ((int)pose != s.B) {
            s.B = (int)pose;
            s.A = e.TickCount;
        }
        if (pose is not (EntityPose.Emerging or EntityPose.Digging) || (e.TickCount - s.A) * 50.0F >= 4500.0F) {
            return;
        }
        IBlock below = BlockStateOn(e);
        if (!Visible(below)) {
            return;
        }
        IParticle particle = Particle.Block with { BlockState = below };
        for (int i = 0; i < 30; i++) {
            Add(particle, e.Position.X + R.Between(-0.7F, 0.7F), e.Position.Y, e.Position.Z + R.Between(-0.7F, 0.7F), 0.0, 0.0, 0.0);
        }
    }

    /// <summary><c>Sniffer.emitDiggingParticles</c>: earth from under its nose between 1.7 and 6 seconds into a dig.</summary>
    private void TickSniffer(ClientEntity e, EntityEmitter s) {
        SnifferState state = e.Get(EntityDataFields.Sniffer.State, SnifferState.Idling);
        if ((int)state != s.B) {
            s.B = (int)state;
            s.A = e.TickCount;
        }
        if (state != SnifferState.Digging) {
            return;
        }
        long millis = (long)((e.TickCount - s.A) * 50.0F);
        if (millis <= 1700L || millis >= 6000L) {
            return;
        }
        Vec3d forward = ViewVector(e.XRot, e.YRot);
        int hx = (int)Math.Floor(e.Position.X + forward.X * 2.25);
        int hy = (int)Math.Floor(e.Position.Y + 0.2F);
        int hz = (int)Math.Floor(e.Position.Z + forward.Z * 2.25);
        IBlock below = BlockAt(hx, hy - 1, hz);
        if (!Visible(below)) {
            return;
        }
        IParticle particle = Particle.Block with { BlockState = below };
        for (int i = 0; i < 30; i++) {
            Add(particle, hx + 0.5, hy + 0.5 - 0.65F, hz + 0.5, 0.0, 0.0, 0.0);
        }
    }

    /// <summary>
    /// The ender dragon's client particles: explosions while it dies, from <c>aiStep</c>, <c>tickDeath</c> and
    /// <c>DragonDeathPhase</c>, and the breath of the landing and sitting flaming phases. The head is placed as
    /// <c>tickPart</c> places it but without the flight history: no tilt, and a flying head's height offset taken
    /// from the last tick's climb instead of five ticks of it. The landing look aims at the world origin, where
    /// vanilla's end podium is.
    /// </summary>
    private void TickEnderDragon(ClientEntity e, EntityEmitter s) {
        int phase = e.Get(EntityDataFields.EnderDragon.Phase, 10);
        if (phase != s.B) {
            // Each phase's begin() resets its own counter.
            s.B = phase;
            s.C = 0;
        }
        if (e.CurrentHealth <= 0.0F) {
            float xo = (R.NextFloat() - 0.5F) * 8.0F, yo = (R.NextFloat() - 0.5F) * 4.0F, zo = (R.NextFloat() - 0.5F) * 8.0F;
            Add(Particle.Explosion, e.Position.X + xo, e.Position.Y + 2.0 + yo, e.Position.Z + zo, 0.0, 0.0, 0.0);
            // tickDeath's dragonDeathTime.
            s.A++;
            if (s.A is >= 180 and <= 200) {
                xo = (R.NextFloat() - 0.5F) * 8.0F;
                yo = (R.NextFloat() - 0.5F) * 4.0F;
                zo = (R.NextFloat() - 0.5F) * 8.0F;
                Add(Particle.ExplosionEmitter, e.Position.X + xo, e.Position.Y + 2.0 + yo, e.Position.Z + zo, 0.0, 0.0, 0.0);
            }
            return;
        }
        if ((e.Get(EntityDataFields.Mob.MobFlags) & 1) != 0) {
            return;
        }
        const int landing = 3, sittingFlaming = 5, dying = 9;
        switch (phase) {
            case dying:
                if (s.C++ % 10 == 0) {
                    float xo = (R.NextFloat() - 0.5F) * 8.0F, yo = (R.NextFloat() - 0.5F) * 4.0F, zo = (R.NextFloat() - 0.5F) * 8.0F;
                    Add(Particle.ExplosionEmitter, e.Position.X + xo, e.Position.Y + 2.0 + yo, e.Position.Z + zo, 0.0, 0.0, 0.0);
                }
                break;
            case landing: {
                float dist = Math.Max((float)Math.Sqrt(e.Position.X * e.Position.X + e.Position.Z * e.Position.Z) / 4.0F, 1.0F);
                Vec3d look = ViewVector(-(6.0F / dist) * 1.5F * 5.0F, e.YRot).Normalize();
                Vec3d head = DragonHead(e, false);
                Vec3d movement = e.DeltaMovement;
                // DragonLandingPhase drops look.yRot's result, so every puff takes the same look.
                for (int i = 0; i < 8; i++) {
                    Add(DragonBreath, head.X + R.NextGaussian() / 2.0, head.Y + R.NextGaussian() / 2.0, head.Z + R.NextGaussian() / 2.0,
                        -look.X * 0.08F + movement.X, -look.Y * 0.3F + movement.Y, -look.Z * 0.08F + movement.Z);
                }
                break;
            }
            case sittingFlaming: {
                s.C++;
                if (s.C % 2 != 0 || s.C >= 10) {
                    break;
                }
                Vec3d look = ViewVector(-45.0F, e.YRot).Normalize();
                Vec3d head = DragonHead(e, true);
                for (int i = 0; i < 8; i++) {
                    double px = head.X + R.NextGaussian() / 2.0, py = head.Y + R.NextGaussian() / 2.0, pz = head.Z + R.NextGaussian() / 2.0;
                    for (int j = 0; j < 6; j++) {
                        Add(DragonBreath, px, py, pz, -look.X * 0.08F * j, -look.Y * 0.6F, -look.Z * 0.08F * j);
                    }
                }
                break;
            }
        }
    }

    /// <summary>The middle of the dragon's head part, <c>head.getY(0.5)</c> of its one block box.</summary>
    private static Vec3d DragonHead(ClientEntity e, bool sitting) {
        float rot = e.YRot * (MathF.PI / 180.0F);
        double yOffset = sitting ? -1.0 : (e.OldPosition.Y - e.Position.Y) * 5.0;
        return new Vec3d(e.Position.X + Mth.Sin(rot) * 6.5F, e.Position.Y + yOffset + 0.5, e.Position.Z - Mth.Cos(rot) * 6.5F);
    }

    /// <summary><c>WitherBoss.aiStep</c>: smoke off all three heads, a glint once it is powered, and a shimmer while it charges.</summary>
    private void TickWither(ClientEntity e) {
        float maxHealth = (float)e.Attributes.Value(Attribute.MaxHealth);
        bool powered = e.CurrentHealth <= maxHealth / 2.0F;
        float scale = Scale(e);
        float radius = 0.3F * scale;
        for (int i = 0; i < 3; i++) {
            double hx = e.Position.X, hz = e.Position.Z;
            if (i > 0) {
                float headAngle = (e.YBodyRot + 180 * (i - 1)) * (MathF.PI / 180.0F);
                hx += Mth.Cos(headAngle) * 1.3 * scale;
                hz += Mth.Sin(headAngle) * 1.3 * scale;
            }
            double hy = e.Position.Y + (i <= 0 ? 3.0F : 2.2F) * scale;
            Add(Particle.Smoke, hx + R.NextGaussian() * radius, hy + R.NextGaussian() * radius, hz + R.NextGaussian() * radius, 0.0, 0.0, 0.0);
            if (powered && R.NextInt(4) == 0) {
                Add(WitherPowered, hx + R.NextGaussian() * radius, hy + R.NextGaussian() * radius, hz + R.NextGaussian() * radius, 0.0, 0.0, 0.0);
            }
        }
        if (e.Get(EntityDataFields.WitherBoss.IdInv) > 0) {
            float height = 3.3F * scale;
            for (int i = 0; i < 3; i++) {
                Add(WitherInvulnerable, e.Position.X + R.NextGaussian(), e.Position.Y + R.NextFloat() * height, e.Position.Z + R.NextGaussian(), 0.0, 0.0, 0.0);
            }
        }
    }

    /// <summary><c>Dolphin.tick</c>: a wake off both sides while it swims fast enough.</summary>
    private void TickDolphin(ClientEntity e, EntityEmitter s) {
        if ((e.Get(EntityDataFields.Mob.MobFlags) & 1) != 0 || s.InWater != 1 || !(e.DeltaMovement.LengthSqr() > 0.03)) {
            return;
        }
        Vec3d view = ViewVector(e.XRotO, e.YRotO);
        float c = Mth.Cos(e.YRot * (MathF.PI / 180.0F)) * 0.3F;
        float sn = Mth.Sin(e.YRot * (MathF.PI / 180.0F)) * 0.3F;
        float multiplier = 1.2F - R.NextFloat() * 0.7F;
        for (int i = 0; i < 2; i++) {
            Add(Particle.Dolphin, e.Position.X - view.X * multiplier + c, e.Position.Y - view.Y, e.Position.Z - view.Z * multiplier + sn, 0.0, 0.0, 0.0);
            Add(Particle.Dolphin, e.Position.X - view.X * multiplier - c, e.Position.Y - view.Y, e.Position.Z - view.Z * multiplier - sn, 0.0, 0.0, 0.0);
        }
    }

    /// <summary><c>AbstractNautilus.spawnBubbles</c>: from behind the shell, more often the faster it goes.</summary>
    private void NautilusBubbles(ClientEntity e) {
        double speed = e.DeltaMovement.Length();
        double bubbleProbability = Math.Clamp(speed * 2.0, 0.15F, 1.0);
        if (!(R.NextFloat() < bubbleProbability)) {
            return;
        }
        Vec3d mouth = ViewVector(Math.Clamp(e.XRot, -10.0F, 10.0F), e.YRot);
        double spread = R.NextDouble() * 0.8 * (1.0 + speed);
        double dx = (R.NextFloat() - 0.5) * spread, dy = (R.NextFloat() - 0.5) * spread, dz = (R.NextFloat() - 0.5) * spread;
        Add(Particle.Bubble, e.Position.X - mouth.X * 1.1, e.Position.Y - mouth.Y + 0.25, e.Position.Z - mouth.Z * 1.1, dx, dy, dz);
    }

    /// <summary>
    /// <c>Panda.tick</c>'s sneeze and <c>addEatingParticles</c>. The client counts the sneeze itself, as vanilla's
    /// copy of the counter does, and sneezes once when it passes 20. The eat counter is the server's, which moves
    /// every tick it eats, so a value is only taken once.
    /// </summary>
    private void TickPanda(ClientEntity e, EntityEmitter s) {
        if ((e.Get(EntityDataFields.Panda.IdFlags) & 2) != 0) {
            if (++s.A > 20 && !s.Flag) {
                s.Flag = true;
                Vec3d movement = e.DeltaMovement;
                float width = e.Dimensions.Width;
                float bodyRot = e.YBodyRot * (MathF.PI / 180.0F);
                Add(Particle.Sneeze, e.Position.X - (width + 1.0F) * 0.5 * Mth.Sin(bodyRot), e.Position.Y + e.CurrentEyeHeight - 0.1F,
                    e.Position.Z + (width + 1.0F) * 0.5 * Mth.Cos(bodyRot), movement.X, 0.0, movement.Z);
            }
        }
        else {
            s.A = 0;
            s.Flag = false;
        }
        int eatCounter = e.Get(EntityDataFields.Panda.EatCounter);
        if (eatCounter <= 0 || eatCounter % 5 != 0 || eatCounter == s.B) {
            return;
        }
        s.B = eatCounter;
        ItemStack held = e.GetItemBySlot(EquipmentSlot.MainHand);
        if (ItemComponents.IsEmpty(held)) {
            return;
        }
        IParticle particle = Particle.Item with { Item = held };
        float xRot = -e.XRot * (MathF.PI / 180.0F), yRot = -e.YRot * (MathF.PI / 180.0F), bodyYRot = -e.YBodyRot * (MathF.PI / 180.0F);
        double eyeY = e.Position.Y + e.CurrentEyeHeight + 1.0;
        for (int i = 0; i < 6; i++) {
            Vec3d velocity = new((R.NextFloat() - 0.5) * 0.1, R.NextFloat() * 0.1 + 0.1, (R.NextFloat() - 0.5) * 0.1);
            velocity = ClientEntity.YRotate(ClientEntity.XRotate(velocity, xRot), yRot);
            Vec3d position = ClientEntity.YRotate(new Vec3d((R.NextFloat() - 0.5) * 0.8, -R.NextFloat() * 0.6 - 0.3, 1.0 + (R.NextFloat() - 0.5) * 0.4), bodyYRot);
            Add(particle, position.X + e.Position.X, position.Y + eyeY, position.Z + e.Position.Z, velocity.X, velocity.Y + 0.05, velocity.Z);
        }
    }

    /// <summary>
    /// <c>Wolf.tick</c>'s shake, from event 8: once the shake is under way, drops flung off as it runs. A wolf
    /// in water or rain holds still, as only the server ends the shake there.
    /// </summary>
    private void TickWolf(ClientEntity e, EntityEmitter s) {
        if (!s.Flag || !IsAlive(e)) {
            return;
        }
        int x = (int)Math.Floor(e.Position.X), z = (int)Math.Floor(e.Position.Z);
        if (s.InWater == 1 || _level!.IsRainingAt(x, (int)Math.Floor(e.Position.Y), z) || _level!.IsRainingAt(x, (int)Math.Floor(e.BoundingBox.MaxY), z)) {
            return;
        }
        // F is shakeAnim, G shakeAnimO.
        s.G = s.F;
        s.F += 0.05F;
        if (s.G >= 2.0F) {
            s.Flag = false;
            s.F = s.G = 0.0F;
        }
        if (s.F > 0.4F) {
            float yt = (float)e.Position.Y;
            int shakeCount = (int)(Mth.Sin((s.F - 0.4F) * MathF.PI) * 7.0F);
            Vec3d movement = e.DeltaMovement;
            float width = e.Dimensions.Width;
            for (int i = 0; i < shakeCount; i++) {
                float xo = (R.NextFloat() * 2.0F - 1.0F) * width * 0.5F;
                float zo = (R.NextFloat() * 2.0F - 1.0F) * width * 0.5F;
                Add(Particle.Splash, e.Position.X + xo, yt + 0.8F, e.Position.Z + zo, movement.X, movement.Y, movement.Z);
            }
        }
    }

    /// <summary>
    /// <c>AbstractArrow.tick</c> in flight (bubbles in water, the crit trail) and <c>Arrow.tick</c>'s potion
    /// colour and <c>SpectralArrow.tick</c>'s glint. Vanilla's start of tick position is the old one here.
    /// </summary>
    private void TickArrow(ClientEntity e, EntityEmitter s) {
        bool inGround = e.Get(EntityDataFields.AbstractArrow.InGround);
        // A counts inGroundTime.
        s.A = inGround ? s.A + 1 : 0;
        if (!inGround) {
            Vec3d origin = e.OldPosition, movement = e.DeltaMovement;
            if (s.InWater == 1) {
                ProjectileBubbles(origin, movement);
            }
            if ((e.Get(EntityDataFields.AbstractArrow.IdFlags) & 1) != 0) {
                for (int i = 0; i < 4; i++) {
                    Add(Particle.Crit, origin.X + movement.X * i / 4.0, origin.Y + movement.Y * i / 4.0, origin.Z + movement.Z * i / 4.0,
                        -movement.X, -movement.Y + 0.2, -movement.Z);
                }
            }
        }
        if (s.Kind == EmitterKind.SpectralArrow) {
            if (!inGround) {
                Add(SpectralTrail, e.Position.X, e.Position.Y, e.Position.Z, 0.0, 0.0, 0.0);
            }
            return;
        }
        if (s.Kind != EmitterKind.Arrow) {
            return;
        }
        int amount = inGround ? s.A % 5 == 0 ? 1 : 0 : 2;
        int colour = e.Get(EntityDataFields.Arrow.IdEffectColor, -1);
        if (colour == -1 || amount <= 0) {
            return;
        }
        IParticle particle = Particle.EntityEffect with { Argb = colour };
        (float width, float height) = e.Dimensions;
        for (int i = 0; i < amount; i++) {
            Add(particle, RandomX(e, width, 0.5), RandomY(e, height), RandomZ(e, width, 0.5), 0.0, 0.0, 0.0);
        }
    }

    /// <summary><c>EyeOfEnder.tick</c>: portal motes trailing it, or bubbles under water.</summary>
    private void TickEyeOfEnder(ClientEntity e, EntityEmitter s) {
        Vec3d movement = e.DeltaMovement;
        Vec3d origin = e.Position - movement * 0.25;
        if (s.InWater == 1) {
            for (int i = 0; i < 4; i++) {
                Add(Particle.Bubble, origin.X, origin.Y, origin.Z, movement.X, movement.Y, movement.Z);
            }
            return;
        }
        Add(Particle.Portal, origin.X + R.NextDouble() * 0.6 - 0.3, origin.Y - 0.5, origin.Z + R.NextDouble() * 0.6 - 0.3, movement.X, movement.Y, movement.Z);
    }

    /// <summary><c>AreaEffectCloud.clientTick</c>: always visible motes over the cloud's disc, or a few at its middle while it waits.</summary>
    private void TickAreaEffectCloud(ClientEntity e) {
        bool isWaiting = e.Get(EntityDataFields.AreaEffectCloud.Waiting);
        float radius = e.Get(EntityDataFields.AreaEffectCloud.Radius, 3.0F);
        if (isWaiting && R.NextBool()) {
            return;
        }
        IParticle particle = e.Get(EntityDataFields.AreaEffectCloud.Particle) ?? AreaEffectCloudDefault;
        int particleCount;
        float particleRadius;
        if (isWaiting) {
            particleCount = 2;
            particleRadius = 0.2F;
        }
        else {
            particleCount = Mth.Ceil(MathF.PI * radius * radius);
            particleRadius = radius;
        }
        bool entityEffect = particle.Identifier == Particle.EntityEffect.Identifier;
        for (int i = 0; i < particleCount; i++) {
            float angle = R.NextFloat() * (MathF.PI * 2.0F);
            float distance = MathF.Sqrt(R.NextFloat()) * particleRadius;
            double x = e.Position.X + Mth.Cos(angle) * distance;
            double y = e.Position.Y;
            double z = e.Position.Z + Mth.Sin(angle) * distance;
            if (entityEffect) {
                _engine.AddAlwaysVisibleParticle(isWaiting && R.NextBool() ? AreaEffectCloudDefault : particle, x, y, z, 0.0, 0.0, 0.0);
            }
            else if (isWaiting) {
                _engine.AddAlwaysVisibleParticle(particle, x, y, z, 0.0, 0.0, 0.0);
            }
            else {
                _engine.AddAlwaysVisibleParticle(particle, x, y, z, (0.5 - R.NextDouble()) * 0.15, 0.01F, (0.5 - R.NextDouble()) * 0.15);
            }
        }
    }

    /// <summary><c>OminousItemSpawner.tickClient</c>: every five game ticks, motes drawn in to where the item will drop.</summary>
    private void TickOminousItemSpawner(ClientEntity e) {
        if (_level!.GameTime % 5L != 0L) {
            return;
        }
        int particleCount = 1 + R.NextInt(3);
        for (int i = 0; i < particleCount; i++) {
            double fromX = e.Position.X + 0.4 * (R.NextGaussian() - R.NextGaussian());
            double fromY = e.Position.Y + 0.4 * (R.NextGaussian() - R.NextGaussian());
            double fromZ = e.Position.Z + 0.4 * (R.NextGaussian() - R.NextGaussian());
            Add(Particle.OminousSpawning, e.Position.X, e.Position.Y, e.Position.Z, fromX - e.Position.X, fromY - e.Position.Y, fromZ - e.Position.Z);
        }
    }

    /// <summary><c>EvokerFangs.tick</c> on the client: a spray of crits as the jaws close, eight ticks after event 4.</summary>
    private void TickEvokerFangs(ClientEntity e, EntityEmitter s) {
        if (!s.Flag) {
            return;
        }
        // A is lifeTicks, counted down from 22.
        if (--s.A != 14) {
            return;
        }
        float width = e.Dimensions.Width;
        for (int i = 0; i < 12; i++) {
            double x = e.Position.X + (R.NextDouble() * 2.0 - 1.0) * width * 0.5;
            double y = e.Position.Y + 0.05 + R.NextDouble();
            double z = e.Position.Z + (R.NextDouble() * 2.0 - 1.0) * width * 0.5;
            double xd = (R.NextDouble() * 2.0 - 1.0) * 0.3;
            double yd = 0.3 + R.NextDouble() * 0.3;
            double zd = (R.NextDouble() * 2.0 - 1.0) * 0.3;
            Add(Particle.Crit, x, y + 1.0, z, xd, yd, zd);
        }
    }
}
