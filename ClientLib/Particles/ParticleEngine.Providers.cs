using Minecraft.Data.Blocks;
using Minecraft.Data.Particles;
using Minecraft.Data.Particles.Types;
using Minecraft.Physics;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Item = Minecraft.Data.Generated.Item;
using Particle = Minecraft.Data.Generated.Particle;

namespace ClientLib.Particles;

/// <summary>
/// <c>ParticleResources.registerProviders</c>: a provider for every particle type, each setting a particle up as
/// the vanilla class its provider makes, from size and colour to the sprite it starts on and how it moves.
/// </summary>
public sealed partial class ParticleEngine {
    /// <summary>Makes a particle from its options and returns its handle, or -1 for none.</summary>
    private delegate int Provider(ParticleEngine engine, IParticle options, double x, double y, double z, double xa, double ya, double za);

    private static readonly Dictionary<Identifier, Provider> Providers = new();

    /// <summary>The types registered with <c>overrideLimiter</c>, which skip the distance and Particles checks.</summary>
    private static readonly HashSet<Identifier> LimiterOverriding = [
        Particle.DamageIndicator.Identifier, Particle.ElderGuardian.Identifier, Particle.ExplosionEmitter.Identifier, Particle.Explosion.Identifier,
        Particle.Gust.Identifier, Particle.GustEmitterLarge.Identifier, Particle.GustEmitterSmall.Identifier, Particle.SonicBoom.Identifier,
        Particle.SculkChargePop.Identifier, Particle.Poof.Identifier, Particle.Spit.Identifier, Particle.SquidInk.Identifier, Particle.SweepAttack.Identifier,
        Particle.CampfireCosySmoke.Identifier, Particle.CampfireSignalSmoke.Identifier, Particle.GlowSquidInk.Identifier, Particle.Glow.Identifier,
        Particle.WaxOn.Identifier, Particle.WaxOff.Identifier, Particle.ElectricSpark.Identifier, Particle.Scrape.Identifier,
        Particle.TrialSpawnerDetection.Identifier, Particle.TrialSpawnerDetectionOminous.Identifier, Particle.VaultConnection.Identifier,
        Particle.OminousSpawning.Identifier, Particle.Geyser.Identifier
    ];

    /// <summary><c>ParticleType.getOverrideLimiter</c>.</summary>
    public static bool OverridesLimiter(IParticle options) => LimiterOverriding.Contains(options.Identifier);

    /// <summary>Whether this client makes anything for a particle type.</summary>
    public static bool HasProvider(IParticle type) => Providers.ContainsKey(type.Identifier);

    private static void Register(IParticle type, Provider provider) => Providers[type.Identifier] = provider;

    static ParticleEngine() {
        Register(Particle.AngryVillager, (e, o, x, y, z, xa, ya, za) => e.Heart(o, x, y + 0.5, z));
        Register(Particle.BlockMarker, (e, o, x, y, z, xa, ya, za) => e.BlockMarker(((BlockMarkerParticle)o).BlockState, x, y, z));
        Register(Particle.Block, (e, o, x, y, z, xa, ya, za) => e.Terrain((uint)(((BlockParticle)o).BlockState?.StateId ?? 0), x, y, z, xa, ya, za));
        Register(Particle.Bubble, (e, o, x, y, z, xa, ya, za) => e.Bubble(o, x, y, z, xa, ya, za, false));
        Register(Particle.BubbleColumnUp, (e, o, x, y, z, xa, ya, za) => e.Bubble(o, x, y, z, xa, ya, za, true));
        Register(Particle.BubblePop, (e, o, x, y, z, xa, ya, za) => e.BubblePop(o, x, y, z, xa, ya, za));
        Register(Particle.SulfurBubbles, (e, o, x, y, z, xa, ya, za) => e.SulfurBubble(o, x, y, z, xa, ya));
        Register(Particle.NoxiousGas, (e, o, x, y, z, xa, ya, za) => e.NoxiousGas(o, x, y, z, xa, ya, za));
        Register(Particle.NoxiousGasCloud, (e, o, x, y, z, xa, ya, za) => e.Emitter(e.New(x, y, z), ParticleMotion.NoxiousGasCloud, 20));
        Register(Particle.Geyser, (e, o, x, y, z, xa, ya, za) => e.GeyserEruption(((GeyserParticle)o).WaterBlocks, x, y, z, xa, ya, za));
        Register(Particle.GeyserBase, (e, o, x, y, z, xa, ya, za) => e.GeyserBase(o, (GeyserBaseParticle)o, x, y, z, xa, ya, za));
        Register(Particle.GeyserPoof, (e, o, x, y, z, xa, ya, za) => e.GeyserBase(o, (GeyserBaseParticle)o, x, y, z, xa, ya, za));
        Register(Particle.GeyserPlume, (e, o, x, y, z, xa, ya, za) => e.GeyserPlume(o, ((GeyserParticle)o).WaterBlocks, x, y, z, xa, ya, za));
        Register(Particle.CampfireCosySmoke, (e, o, x, y, z, xa, ya, za) => e.CampfireSmoke(o, x, y, z, xa, ya, za, false));
        Register(Particle.CampfireSignalSmoke, (e, o, x, y, z, xa, ya, za) => e.CampfireSmoke(o, x, y, z, xa, ya, za, true));
        Register(Particle.Cloud, (e, o, x, y, z, xa, ya, za) => e.PlayerCloud(o, x, y, z, xa, ya, za));
        Register(Particle.Sneeze, (e, o, x, y, z, xa, ya, za) => e.Tweak(e.PlayerCloud(o, x, y, z, xa, ya, za), (ref ParticleState p) => {
            p.SetColour(0.22F, 1.0F, 0.53F);
            p.A = 0.4F;
        }));
        Register(Particle.Composter, (e, o, x, y, z, xa, ya, za) => e.Tweak(e.SuspendedTown(o, x, y, z, xa, ya, za), (ref ParticleState p) => {
            p.SetColour(1.0F, 1.0F, 1.0F);
            p.Lifetime = 3 + e.Random.NextInt(5);
        }));
        Register(Particle.Dolphin, (e, o, x, y, z, xa, ya, za) => e.Tweak(e.SuspendedTown(o, x, y, z, xa, ya, za), (ref ParticleState p) => {
            p.SetColour(0.3F, 0.5F, 1.0F);
            p.A = 1.0F - e.Random.NextFloat() * 0.7F;
            p.Lifetime /= 2;
        }));
        Register(Particle.EggCrack, (e, o, x, y, z, xa, ya, za) => e.Tweak(e.SuspendedTown(o, x, y, z, xa, ya, za), (ref ParticleState p) => p.SetColour(1.0F, 1.0F, 1.0F)));
        Register(Particle.HappyVillager, (e, o, x, y, z, xa, ya, za) => e.Tweak(e.SuspendedTown(o, x, y, z, xa, ya, za), (ref ParticleState p) => p.SetColour(1.0F, 1.0F, 1.0F)));
        Register(Particle.Mycelium, (e, o, x, y, z, xa, ya, za) => e.SuspendedTown(o, x, y, z, xa, ya, za));
        Register(Particle.CopperFireFlame, (e, o, x, y, z, xa, ya, za) => e.Flame(o, x, y, z, xa, ya, za, 1.0F));
        Register(Particle.Flame, (e, o, x, y, z, xa, ya, za) => e.Flame(o, x, y, z, xa, ya, za, 1.0F));
        Register(Particle.SoulFireFlame, (e, o, x, y, z, xa, ya, za) => e.Flame(o, x, y, z, xa, ya, za, 1.0F));
        Register(Particle.SmallFlame, (e, o, x, y, z, xa, ya, za) => e.Flame(o, x, y, z, xa, ya, za, 0.5F));
        Register(Particle.Crit, (e, o, x, y, z, xa, ya, za) => e.Crit(o, x, y, z, xa, ya, za));
        Register(Particle.DamageIndicator, (e, o, x, y, z, xa, ya, za) => e.Tweak(e.Crit(o, x, y, z, xa, ya + 1.0, za), (ref ParticleState p) => p.Lifetime = 20));
        Register(Particle.EnchantedHit, (e, o, x, y, z, xa, ya, za) => e.Tweak(e.Crit(o, x, y, z, xa, ya, za), (ref ParticleState p) => {
            p.R *= 0.3F;
            p.G *= 0.8F;
        }));
        Register(Particle.CurrentDown, (e, o, x, y, z, xa, ya, za) => e.WaterCurrentDown(o, x, y, z));
        Register(Particle.DragonBreath, (e, o, x, y, z, xa, ya, za) => e.DragonBreath(o, ((DragonBreathParticle)o).Power, x, y, z, xa, ya, za));
        RegisterDrips();
        Register(Particle.Dust, (e, o, x, y, z, xa, ya, za) => e.Dust(o, (DustParticle)o, x, y, z, xa, ya, za));
        Register(Particle.DustColorTransition, (e, o, x, y, z, xa, ya, za) => e.DustTransition(o, (DustColorTransitionParticle)o, x, y, z, xa, ya, za));
        Register(Particle.Effect, (e, o, x, y, z, xa, ya, za) => e.Tweak(e.Spell(o, x, y, z, xa, ya, za), (ref ParticleState p) => {
            p.SetColour(((SpellParticle)o).Rgb);
            p.SetPower(((SpellParticle)o).Power);
        }));
        Register(Particle.InstantEffect, (e, o, x, y, z, xa, ya, za) => e.Tweak(e.Spell(o, x, y, z, xa, ya, za), (ref ParticleState p) => {
            p.SetColour(((SpellParticle)o).Rgb);
            p.SetPower(((SpellParticle)o).Power);
        }));
        Register(Particle.EntityEffect, (e, o, x, y, z, xa, ya, za) => e.Tweak(e.Spell(o, x, y, z, xa, ya, za), (ref ParticleState p) => {
            int argb = ((EntityEffectParticle)o).Argb;
            p.SetColour(argb);
            p.A = (argb >> 24 & 0xFF) / 255.0F;
        }));
        Register(Particle.Infested, (e, o, x, y, z, xa, ya, za) => e.Spell(o, x, y, z, xa, ya, za));
        Register(Particle.RaidOmen, (e, o, x, y, z, xa, ya, za) => e.Spell(o, x, y, z, xa, ya, za));
        Register(Particle.TrialOmen, (e, o, x, y, z, xa, ya, za) => e.Spell(o, x, y, z, xa, ya, za));
        Register(Particle.Witch, (e, o, x, y, z, xa, ya, za) => e.Tweak(e.Spell(o, x, y, z, xa, ya, za), (ref ParticleState p) => {
            float brightness = e.Random.NextFloat() * 0.5F + 0.35F;
            p.SetColour(brightness, 0.0F, brightness);
        }));
        Register(Particle.ElderGuardian, (e, o, x, y, z, xa, ya, za) => e.ElderGuardian(x, y, z));
        Register(Particle.Enchant, (e, o, x, y, z, xa, ya, za) => e.FlyTowards(o, x, y, z, xa, ya, za, false));
        Register(Particle.Nautilus, (e, o, x, y, z, xa, ya, za) => e.FlyTowards(o, x, y, z, xa, ya, za, false));
        Register(Particle.VaultConnection, (e, o, x, y, z, xa, ya, za) => e.FlyTowards(o, x, y, z, xa, ya, za, true));
        Register(Particle.EndRod, (e, o, x, y, z, xa, ya, za) => e.EndRod(o, x, y, z, xa, ya, za));
        Register(Particle.ExplosionEmitter, (e, o, x, y, z, xa, ya, za) => e.Emitter(e.New(x, y, z, 0.0, 0.0, 0.0), ParticleMotion.ExplosionSeed, 8));
        Register(Particle.Explosion, (e, o, x, y, z, xa, ya, za) => e.HugeExplosion(o, x, y, z, xa, 6 + e.Random.NextInt(4), 2.0F * (1.0F - (float)xa * 0.5F)));
        Register(Particle.SonicBoom, (e, o, x, y, z, xa, ya, za) => e.HugeExplosion(o, x, y, z, xa, 16, 1.5F));
        Register(Particle.SweepAttack, (e, o, x, y, z, xa, ya, za) => e.HugeExplosion(o, x, y, z, xa, 4, 1.0F - (float)xa * 0.5F));
        Register(Particle.FallingDust, (e, o, x, y, z, xa, ya, za) => e.FallingDust(o, (uint)((FallingDustParticle)o).BlockState, x, y, z));
        Register(Particle.Gust, (e, o, x, y, z, xa, ya, za) => e.Gust(o, x, y, z, 1.0F));
        Register(Particle.SmallGust, (e, o, x, y, z, xa, ya, za) => e.Gust(o, x, y, z, 0.15F));
        Register(Particle.GustEmitterLarge, (e, o, x, y, z, xa, ya, za) => e.GustSeed(x, y, z, 3.0F, 7, 0));
        Register(Particle.GustEmitterSmall, (e, o, x, y, z, xa, ya, za) => e.GustSeed(x, y, z, 1.0F, 3, 2));
        Register(Particle.Firework, (e, o, x, y, z, xa, ya, za) => e.SpawnSpark(x, y, z, xa, ya, za));
        Register(Particle.Fishing, (e, o, x, y, z, xa, ya, za) => e.Wake(o, x, y, z, xa, ya, za));
        Register(Particle.SculkSoul, (e, o, x, y, z, xa, ya, za) => e.Soul(o, x, y, z, xa, ya, za, true));
        Register(Particle.Soul, (e, o, x, y, z, xa, ya, za) => e.Soul(o, x, y, z, xa, ya, za, false));
        Register(Particle.SculkCharge, (e, o, x, y, z, xa, ya, za) => e.SculkCharge(o, x, y, z, xa, ya, za, 1.5F, 12, 8, ((SculkChargeParticle)o).Roll));
        Register(Particle.SculkChargePop, (e, o, x, y, z, xa, ya, za) => e.SculkCharge(o, x, y, z, xa, ya, za, 1.0F, 4, 6, 0.0F));
        Register(Particle.Flash, (e, o, x, y, z, xa, ya, za) => e.Flash(o, ((ColorParticle)o).Argb, x, y, z));
        Register(Particle.Heart, (e, o, x, y, z, xa, ya, za) => e.Heart(o, x, y, z));
        Register(Particle.Item, (e, o, x, y, z, xa, ya, za) => e.BreakingItem(o, ((ItemParticle)o).Item ?? ItemStack.Air, x, y, z, xa, ya, za, true));
        Register(Particle.ItemSlime, (e, o, x, y, z, xa, ya, za) => e.BreakingItem(o, new ItemStack(Item.SlimeBall), x, y, z, 0, 0, 0, false));
        Register(Particle.ItemCobweb, (e, o, x, y, z, xa, ya, za) => e.BreakingItem(o, new ItemStack(Item.Cobweb), x, y, z, 0, 0, 0, false));
        Register(Particle.ItemSnowball, (e, o, x, y, z, xa, ya, za) => e.BreakingItem(o, new ItemStack(Item.Snowball), x, y, z, 0, 0, 0, false));
        Register(Particle.SulfurCubeGoo, (e, o, x, y, z, xa, ya, za) => e.BreakingItem(o, null, x, y, z, 0, 0, 0, false));
        Register(Particle.LargeSmoke, (e, o, x, y, z, xa, ya, za) => e.Smoke(o, x, y, z, xa, ya, za, 2.5F));
        Register(Particle.Smoke, (e, o, x, y, z, xa, ya, za) => e.Smoke(o, x, y, z, xa, ya, za, 1.0F));
        Register(Particle.WhiteSmoke, (e, o, x, y, z, xa, ya, za) => e.Tweak(e.Smoke(o, x, y, z, xa, ya, za, 1.0F), (ref ParticleState p) => p.SetColour(0.7294118F, 0.69411767F, 0.7607843F)));
        Register(Particle.Ash, (e, o, x, y, z, xa, ya, za) => e.AshSmoke(o, x, y, z, 0.1F, -0.1F, 0.1F, 0, 0, 0, 1.0F, 0.5F, 20, 0.1F, false));
        Register(Particle.WhiteAsh, (e, o, x, y, z, xa, ya, za) => {
            double wx = e.Random.NextFloat() * -1.9 * e.Random.NextFloat() * 0.1;
            double wy = e.Random.NextFloat() * -0.5 * e.Random.NextFloat() * 0.1 * 5.0;
            double wz = e.Random.NextFloat() * -1.9 * e.Random.NextFloat() * 0.1;
            return e.Tweak(e.AshSmoke(o, x, y, z, 0.1F, -0.1F, 0.1F, wx, wy, wz, 1.0F, 0.0F, 20, 0.0125F, false), (ref ParticleState p) => p.SetColour(12235202));
        });
        Register(Particle.DustPlume, (e, o, x, y, z, xa, ya, za) => e.DustPlume(o, x, y, z, xa, ya, za));
        Register(Particle.Lava, (e, o, x, y, z, xa, ya, za) => e.Lava(o, x, y, z));
        Register(Particle.Note, (e, o, x, y, z, xa, ya, za) => e.Note(o, x, y, z, xa));
        Register(Particle.Poof, (e, o, x, y, z, xa, ya, za) => e.Explode(o, x, y, z, xa, ya, za, -0.1F));
        Register(Particle.Spit, (e, o, x, y, z, xa, ya, za) => e.Explode(o, x, y, z, xa, ya, za, 0.5F));
        Register(Particle.Portal, (e, o, x, y, z, xa, ya, za) => e.Portal(o, x, y, z, xa, ya, za, false));
        Register(Particle.ReversePortal, (e, o, x, y, z, xa, ya, za) => e.Portal(o, x, y, z, xa, ya, za, true));
        Register(Particle.Rain, (e, o, x, y, z, xa, ya, za) => e.WaterDrop(o, x, y, z));
        Register(Particle.Splash, (e, o, x, y, z, xa, ya, za) => e.Tweak(e.WaterDrop(o, x, y, z), (ref ParticleState p) => {
            p.Gravity = 0.04F;
            if (ya == 0.0 && (xa != 0.0 || za != 0.0)) {
                p.SetSpeed(xa, 0.1, za);
            }
        }));
        Register(Particle.Snowflake, (e, o, x, y, z, xa, ya, za) => e.Snowflake(o, x, y, z, xa, ya, za));
        Register(Particle.TotemOfUndying, (e, o, x, y, z, xa, ya, za) => e.Totem(o, x, y, z, xa, ya, za));
        Register(Particle.SquidInk, (e, o, x, y, z, xa, ya, za) => e.SquidInk(o, x, y, z, xa, ya, za, 0.0F, 0.0F, 0.0F));
        Register(Particle.GlowSquidInk, (e, o, x, y, z, xa, ya, za) => e.SquidInk(o, x, y, z, xa, ya, za, 0.2F, 0.8F, 0.6F));
        Register(Particle.Underwater, (e, o, x, y, z, xa, ya, za) => e.Tweak(e.Suspended(o, x, y, z, null), (ref ParticleState p) => p.SetColour(0.4F, 0.4F, 0.7F)));
        Register(Particle.CrimsonSpore, (e, o, x, y, z, xa, ya, za) => {
            (double sx, double sy, double sz) = (e.Random.NextGaussian() * 1.0E-6F, e.Random.NextGaussian() * 1.0E-4F, e.Random.NextGaussian() * 1.0E-6F);
            return e.Tweak(e.Suspended(o, x, y, z, (sx, sy, sz)), (ref ParticleState p) => p.SetColour(0.9F, 0.4F, 0.5F));
        });
        Register(Particle.WarpedSpore, (e, o, x, y, z, xa, ya, za) => {
            double sy = e.Random.NextFloat() * -1.9 * e.Random.NextFloat() * 0.1;
            return e.Tweak(e.Suspended(o, x, y, z, (0.0, sy, 0.0)), (ref ParticleState p) => {
                p.SetColour(0.1F, 0.1F, 0.3F);
                p.Width = p.Height = 0.001F;
            });
        });
        Register(Particle.SporeBlossomAir, (e, o, x, y, z, xa, ya, za) => {
            if (!e.TakeSporeBlossom()) {
                return -1;
            }
            return e.Tweak(e.Suspended(o, x, y, z, (0.0, -0.8F, 0.0)), (ref ParticleState p) => {
                p.Lifetime = 500 + e.Random.NextInt(501);
                p.Gravity = 0.01F;
                p.SetColour(0.32F, 0.5F, 0.22F);
                p.Flags |= ParticleFlags.SporeLimited;
            });
        });
        Register(Particle.CherryLeaves, (e, o, x, y, z, xa, ya, za) => e.FallingLeaves(o, x, y, z, 0.25F, 2.0F, false, true, 1.0F, 0.0F));
        Register(Particle.PaleOakLeaves, (e, o, x, y, z, xa, ya, za) => e.FallingLeaves(o, x, y, z, 0.07F, 10.0F, true, false, 2.0F, 0.021F));
        Register(Particle.TintedLeaves, (e, o, x, y, z, xa, ya, za) => e.Tweak(e.FallingLeaves(o, x, y, z, 0.07F, 10.0F, true, false, 2.0F, 0.021F),
            (ref ParticleState p) => p.SetColour(((TintedLeavesParticle)o).Argb)));
        Register(Particle.Vibration, (e, o, x, y, z, xa, ya, za) => e.Vibration(o, (VibrationParticle)o, x, y, z));
        Register(Particle.Trail, (e, o, x, y, z, xa, ya, za) => e.Trail(o, (TrailParticle)o, x, y, z, xa, ya, za));
        Register(Particle.PauseMobGrowth, (e, o, x, y, z, xa, ya, za) => e.Vertical(o, x, y, z, xa, ya, za, false));
        Register(Particle.ResetMobGrowth, (e, o, x, y, z, xa, ya, za) => e.Vertical(o, x, y, z, xa, ya, za, true));
        Register(Particle.Glow, (e, o, x, y, z, xa, ya, za) => e.Tweak(e.Glow(o, x, y, z, 0.5 - e.Random.NextDouble(), ya, 0.5 - e.Random.NextDouble()), (ref ParticleState p) => {
            if (e.Random.NextBool()) {
                p.SetColour(0.6F, 1.0F, 0.8F);
            }
            else {
                p.SetColour(0.08F, 0.4F, 0.4F);
            }
            p.Yd *= 0.2F;
            if (xa == 0.0 && za == 0.0) {
                p.Xd *= 0.1F;
                p.Zd *= 0.1F;
            }
            p.Lifetime = (int)(8.0 / (e.Random.NextDouble() * 0.8 + 0.2));
        }));
        Register(Particle.WaxOn, (e, o, x, y, z, xa, ya, za) => e.Tweak(e.Glow(o, x, y, z, 0, 0, 0), (ref ParticleState p) => {
            p.SetColour(0.91F, 0.55F, 0.08F);
            p.SetSpeed(xa * 0.01 / 2.0, ya * 0.01, za * 0.01 / 2.0);
            p.Lifetime = e.Random.NextInt(30) + 10;
        }));
        Register(Particle.WaxOff, (e, o, x, y, z, xa, ya, za) => e.Tweak(e.Glow(o, x, y, z, 0, 0, 0), (ref ParticleState p) => {
            p.SetColour(1.0F, 0.9F, 1.0F);
            p.SetSpeed(xa * 0.01 / 2.0, ya * 0.01, za * 0.01 / 2.0);
            p.Lifetime = e.Random.NextInt(30) + 10;
        }));
        Register(Particle.ElectricSpark, (e, o, x, y, z, xa, ya, za) => e.Tweak(e.Glow(o, x, y, z, 0, 0, 0), (ref ParticleState p) => {
            p.SetColour(1.0F, 0.9F, 1.0F);
            p.SetSpeed(xa * 0.25, ya * 0.25, za * 0.25);
            p.Lifetime = e.Random.NextInt(2) + 2;
        }));
        Register(Particle.Scrape, (e, o, x, y, z, xa, ya, za) => e.Tweak(e.Glow(o, x, y, z, 0, 0, 0), (ref ParticleState p) => {
            if (e.Random.NextBool()) {
                p.SetColour(0.29F, 0.58F, 0.51F);
            }
            else {
                p.SetColour(0.43F, 0.77F, 0.62F);
            }
            p.SetSpeed(xa * 0.01, ya * 0.01, za * 0.01);
            p.Lifetime = e.Random.NextInt(30) + 10;
        }));
        Register(Particle.Shriek, (e, o, x, y, z, xa, ya, za) => e.Shriek(o, ((ShriekParticle)o).Delay, x, y, z));
        Register(Particle.TrialSpawnerDetection, (e, o, x, y, z, xa, ya, za) => e.TrialSpawnerDetection(o, x, y, z, xa, ya, za));
        Register(Particle.TrialSpawnerDetectionOminous, (e, o, x, y, z, xa, ya, za) => e.TrialSpawnerDetection(o, x, y, z, xa, ya, za));
        Register(Particle.DustPillar, (e, o, x, y, z, xa, ya, za) => e.Tweak(e.Terrain((uint)((DustPillarParticle)o).BlockState, x, y, z, xa, ya, za), (ref ParticleState p) => {
            p.SetSpeed(e.Random.NextGaussian() / 30.0, ya + e.Random.NextGaussian() / 2.0, e.Random.NextGaussian() / 30.0);
            p.Lifetime = e.Random.NextInt(20) + 20;
        }));
        Register(Particle.BlockCrumble, (e, o, x, y, z, xa, ya, za) => e.Tweak(e.Terrain((uint)((BlockCrumbleParticle)o).BlockState, x, y, z, xa, ya, za), (ref ParticleState p) => {
            p.SetSpeed(0.0, 0.0, 0.0);
            p.Lifetime = e.Random.NextInt(10) + 1;
        }));
        Register(Particle.OminousSpawning, (e, o, x, y, z, xa, ya, za) => e.FlyStraightTowards(o, x, y, z, xa, ya, za));
        Register(Particle.Firefly, (e, o, x, y, z, xa, ya, za) => e.Firefly(o, x, y, z, ya));
    }

    private static void RegisterDrips() {
        const float waterR = 0.2F, waterG = 0.3F, waterB = 1.0F;
        const float lavaR = 1.0F, lavaG = 0.2857143F, lavaB = 0.083333336F;
        const float tearR = 0.51171875F, tearG = 0.03125F, tearB = 0.890625F;
        Register(Particle.DrippingLava, (e, o, x, y, z, xa, ya, za) => e.Drip(o, x, y, z, FluidLava, DripCoolingHang, Particle.FallingLava, 1, 1, 1));
        Register(Particle.FallingLava, (e, o, x, y, z, xa, ya, za) => e.Drip(o, x, y, z, FluidLava, DripFallAndLand, Particle.LandingLava, lavaR, lavaG, lavaB));
        Register(Particle.LandingLava, (e, o, x, y, z, xa, ya, za) => e.Drip(o, x, y, z, FluidLava, DripPlain, null, lavaR, lavaG, lavaB, 16.0));
        Register(Particle.DrippingWater, (e, o, x, y, z, xa, ya, za) => e.Drip(o, x, y, z, FluidWater, DripHang, Particle.FallingWater, waterR, waterG, waterB));
        Register(Particle.FallingWater, (e, o, x, y, z, xa, ya, za) => e.Drip(o, x, y, z, FluidWater, DripFallAndLand, Particle.Splash, waterR, waterG, waterB));
        Register(Particle.DrippingDripstoneWater, (e, o, x, y, z, xa, ya, za) => e.Drip(o, x, y, z, FluidWater, DripHang, Particle.FallingDripstoneWater, waterR, waterG, waterB));
        Register(Particle.FallingDripstoneWater, (e, o, x, y, z, xa, ya, za) => e.Drip(o, x, y, z, FluidWater, DripFallAndLand, Particle.Splash, waterR, waterG, waterB));
        Register(Particle.DrippingDripstoneLava, (e, o, x, y, z, xa, ya, za) => e.Drip(o, x, y, z, FluidLava, DripCoolingHang, Particle.FallingDripstoneLava, 1, 1, 1));
        Register(Particle.FallingDripstoneLava, (e, o, x, y, z, xa, ya, za) => e.Drip(o, x, y, z, FluidLava, DripFallAndLand, Particle.LandingLava, lavaR, lavaG, lavaB));
        Register(Particle.DrippingHoney, (e, o, x, y, z, xa, ya, za) => e.Tweak(e.Drip(o, x, y, z, 0, DripHang, Particle.FallingHoney, 0.622F, 0.508F, 0.082F),
            (ref ParticleState p) => {
                p.Gravity *= 0.01F;
                p.Lifetime = 100;
            }));
        Register(Particle.FallingHoney, (e, o, x, y, z, xa, ya, za) => e.Tweak(e.Drip(o, x, y, z, 0, DripFallAndLand, Particle.LandingHoney, 0.582F, 0.448F, 0.082F),
            (ref ParticleState p) => p.Gravity = 0.01F));
        Register(Particle.LandingHoney, (e, o, x, y, z, xa, ya, za) => e.Drip(o, x, y, z, 0, DripPlain, null, 0.522F, 0.408F, 0.082F, 128.0));
        Register(Particle.FallingNectar, (e, o, x, y, z, xa, ya, za) => e.Tweak(e.Drip(o, x, y, z, 0, DripFalling, null, 0.92F, 0.782F, 0.72F, 16.0),
            (ref ParticleState p) => p.Gravity = 0.007F));
        Register(Particle.FallingSporeBlossom, (e, o, x, y, z, xa, ya, za) => e.Tweak(e.Drip(o, x, y, z, 0, DripFalling, null, 0.32F, 0.5F, 0.22F),
            (ref ParticleState p) => {
                p.Lifetime = (int)(64.0F / e.Random.Between(0.1F, 0.9F));
                p.Gravity = 0.005F;
            }));
        Register(Particle.DrippingObsidianTear, (e, o, x, y, z, xa, ya, za) => e.Tweak(e.Drip(o, x, y, z, 0, DripHang, Particle.FallingObsidianTear, tearR, tearG, tearB),
            (ref ParticleState p) => {
                p.LightMode = ParticleLightMode.BlockMax;
                p.Gravity *= 0.01F;
                p.Lifetime = 100;
            }));
        Register(Particle.FallingObsidianTear, (e, o, x, y, z, xa, ya, za) => e.Tweak(e.Drip(o, x, y, z, 0, DripFallAndLand, Particle.LandingObsidianTear, tearR, tearG, tearB),
            (ref ParticleState p) => {
                p.LightMode = ParticleLightMode.BlockMax;
                p.Gravity = 0.01F;
            }));
        Register(Particle.LandingObsidianTear, (e, o, x, y, z, xa, ya, za) => e.Tweak(e.Drip(o, x, y, z, 0, DripPlain, null, tearR, tearG, tearB, 28.0),
            (ref ParticleState p) => p.LightMode = ParticleLightMode.BlockMax));
    }

    private delegate void Adjust(ref ParticleState p);

    /// <summary>What a provider changes after the constructor, on a particle that was made.</summary>
    private int Tweak(int handle, Adjust adjust) {
        if (handle >= 0) {
            adjust(ref _pending[handle]);
        }
        return handle;
    }

    private ref ParticleState Sprite(int handle, IParticle type, ParticleSpriteMode mode = ParticleSpriteMode.Index) {
        ref ParticleState p = ref _pending[handle];
        p.Type = TypeId(type);
        p.SpriteMode = mode;
        p.SpriteNum = mode == ParticleSpriteMode.Index ? Random.NextInt(1 << 16) : 0;
        return ref p;
    }

    /// <summary><c>SpriteSet.first()</c>, kept until a tick moves it on by age.</summary>
    private ref ParticleState FirstSprite(int handle, IParticle type) {
        ref ParticleState p = ref Sprite(handle, type, ParticleSpriteMode.ByAge);
        return ref p;
    }

    /// <summary>The 8 to 40 tick lifetimes, <c>(int)(n / (random * 0.8 + 0.2))</c>, that most particles draw.</summary>
    private int Life(double n) => (int)(n / (Random.NextFloat() * 0.8 + 0.2));

    private int Emitter(int handle, ParticleMotion motion, int lifetime) {
        ref ParticleState p = ref _pending[handle];
        p.Flags |= ParticleFlags.NoRender;
        p.Motion = motion;
        p.Lifetime = lifetime;
        return handle;
    }

    /// <summary><c>BaseAshSmokeParticle</c>.</summary>
    private int AshSmoke(IParticle type, double x, double y, double z, float dirX, float dirY, float dirZ, double xa, double ya, double za, float scale,
        float colourRandom, int maxLifetime, float gravity, bool hasPhysics) {
        int handle = New(x, y, z, 0.0, 0.0, 0.0);
        ref ParticleState p = ref FirstSprite(handle, type);
        p.Friction = 0.96F;
        p.Gravity = gravity;
        p.Flags |= ParticleFlags.SpeedUpWhenBlocked;
        p.Xd = p.Xd * dirX + xa;
        p.Yd = p.Yd * dirY + ya;
        p.Zd = p.Zd * dirZ + za;
        float colour = Random.NextFloat() * colourRandom;
        p.SetColour(colour, colour, colour);
        p.Size *= 0.75F * scale;
        p.Lifetime = Math.Max((int)(maxLifetime / (Random.NextFloat() * 0.8 + 0.2) * scale), 1);
        p.HasPhysics = hasPhysics;
        p.SizeCurve = ParticleSizeCurve.GrowIn;
        return handle;
    }

    private int Smoke(IParticle type, double x, double y, double z, double xa, double ya, double za, float scale) =>
        AshSmoke(type, x, y, z, 0.1F, 0.1F, 0.1F, xa, ya, za, scale, 0.3F, 8, -0.1F, true);

    private int NoxiousGas(IParticle type, double x, double y, double z, double xa, double ya, double za) {
        int handle = AshSmoke(type, x, y, z, 0.1F, 0.1F, 0.1F, xa, ya, za, 3.0F, 0.3F, 5, -0.02F, true);
        ref ParticleState p = ref _pending[handle];
        p.SetColour(1.0F, 1.0F, 1.0F);
        p.Lifetime = (int)(6.0 / (Random.NextFloat() * 0.5 + 0.5) * 3.0F);
        p.Translucent = true;
        p.Motion = ParticleMotion.NoxiousGas;
        return handle;
    }

    private int DustPlume(IParticle type, double x, double y, double z, double xa, double ya, double za) {
        int handle = AshSmoke(type, x, y, z, 0.7F, 0.6F, 0.7F, xa, ya + 0.15F, za, 1.0F, 0.5F, 7, 0.5F, false);
        ref ParticleState p = ref _pending[handle];
        float shift = Random.NextFloat() * 0.2F;
        p.SetColour(0xBA / 255.0F - shift, 0xB1 / 255.0F - shift, 0xC2 / 255.0F - shift);
        p.Motion = ParticleMotion.DustPlume;
        return handle;
    }

    private int GeyserBase(IParticle type, GeyserBaseParticle options, double x, double y, double z, double xa, double ya, double za) {
        double rx = x + (Random.NextFloat() - 0.5F) * 0.5F;
        double ry = y + (Random.NextFloat() - 0.5F) * 0.5F + 0.2F;
        double rz = z + (Random.NextFloat() - 0.5F) * 0.5F;
        float burst = options.BurstImpulseBase + 0.25F * options.WaterBlocks;
        int handle = AshSmoke(type, rx, ry, rz, burst, burst, burst, xa, ya, za, 3.0F + 0.125F * options.WaterBlocks, 0.0F, 0, 0.0F, true);
        ref ParticleState p = ref _pending[handle];
        p.Friction = 0.725F;
        p.SetColour(1.0F, 1.0F, 1.0F);
        p.Yd = Math.Abs(p.Yd);
        p.Lifetime = (int)(25.0F * (0.8F + 0.2F * Random.NextFloat()));
        return handle;
    }

    private int GeyserPlume(IParticle type, int waterBlocks, double x, double y, double z, double xa, double ya, double za) {
        int handle = New(x + (Random.NextFloat() - 0.5F) * 0.2F, y + Random.NextFloat(), z + (Random.NextFloat() - 0.5F) * 0.2F, xa, ya, za);
        ref ParticleState p = ref FirstSprite(handle, type);
        int plumeHeight = 5 * Math.Max(1, waterBlocks);
        p.Flags |= ParticleFlags.SpeedUpWhenBlocked;
        p.Lifetime = plumeHeight * 5;
        p.Yd = 0.0;
        p.Ay = p.Y;
        p.Az = p.Ay + plumeHeight - 1.0;
        p.F1 = (Random.NextFloat() - 0.5F) * 0.2F;
        p.F2 = (Random.NextFloat() - 0.5F) * 0.2F;
        p.Friction = 1.0F;
        p.F0 = (waterBlocks == 1 ? 1.5F : 1.0F) * plumeHeight * 1.45F;
        p.Gravity = -p.F0;
        float size = p.Size * 0.75F;
        p.F3 = size * (2.0F + plumeHeight / 8.0F);
        p.Ax = size * (3.0F + plumeHeight / 8.0F);
        p.Size = p.F3;
        p.Motion = ParticleMotion.GeyserPlume;
        return handle;
    }

    private int GeyserEruption(int waterBlocks, double x, double y, double z, double xa, double ya, double za) {
        int handle = Emitter(New(x, y, z), ParticleMotion.GeyserEruption, 20);
        ref ParticleState p = ref _pending[handle];
        p.I0 = waterBlocks;
        (p.Ax, p.Ay, p.Az) = (xa, ya, za);
        return handle;
    }

    /// <summary><c>RisingParticle</c>.</summary>
    private int Rising(double x, double y, double z, double xd, double yd, double zd) {
        int handle = New(x, y, z, xd, yd, zd);
        ref ParticleState p = ref _pending[handle];
        p.Friction = 0.96F;
        p.Xd = p.Xd * 0.01F + xd;
        p.Yd = p.Yd * 0.01F + yd;
        p.Zd = p.Zd * 0.01F + zd;
        p.X += (Random.NextFloat() - Random.NextFloat()) * 0.05F;
        p.Y += (Random.NextFloat() - Random.NextFloat()) * 0.05F;
        p.Z += (Random.NextFloat() - Random.NextFloat()) * 0.05F;
        p.Lifetime = Life(8.0) + 4;
        return handle;
    }

    private int Flame(IParticle type, double x, double y, double z, double xa, double ya, double za, float scale) {
        int handle = Rising(x, y, z, xa, ya, za);
        ref ParticleState p = ref Sprite(handle, type);
        p.HasPhysics = false;
        p.SizeCurve = ParticleSizeCurve.Flame;
        p.LightMode = ParticleLightMode.EmissionByAge;
        p.Scale(scale);
        return handle;
    }

    private int Soul(IParticle type, double x, double y, double z, double xa, double ya, double za, bool glowing) {
        int handle = Rising(x, y, z, xa, ya, za);
        ref ParticleState p = ref FirstSprite(handle, type);
        p.Scale(1.5F);
        p.Translucent = true;
        if (glowing) {
            p.LightMode = ParticleLightMode.BlockMax;
        }
        return handle;
    }

    private int Crit(IParticle type, double x, double y, double z, double xa, double ya, double za) {
        int handle = New(x, y, z, 0.0, 0.0, 0.0);
        ref ParticleState p = ref Sprite(handle, type);
        p.Friction = 0.7F;
        p.Gravity = 0.5F;
        p.Xd = p.Xd * 0.1F + xa * 0.4;
        p.Yd = p.Yd * 0.1F + ya * 0.4;
        p.Zd = p.Zd * 0.1F + za * 0.4;
        float colour = Random.NextFloat() * 0.3F + 0.6F;
        p.SetColour(colour, colour, colour);
        p.Size *= 0.75F;
        p.Lifetime = Math.Max((int)(6.0 / (Random.NextFloat() * 0.8 + 0.6)), 1);
        p.HasPhysics = false;
        p.SizeCurve = ParticleSizeCurve.GrowIn;
        p.Motion = ParticleMotion.Crit;
        // The constructor ticks once.
        TickParticle(ref p, handle);
        return handle;
    }

    private int Heart(IParticle type, double x, double y, double z) {
        int handle = New(x, y, z, 0.0, 0.0, 0.0);
        ref ParticleState p = ref Sprite(handle, type);
        p.Flags |= ParticleFlags.SpeedUpWhenBlocked;
        p.Friction = 0.86F;
        p.Xd *= 0.01F;
        p.Yd = p.Yd * 0.01F + 0.1;
        p.Zd *= 0.01F;
        p.Size *= 1.5F;
        p.Lifetime = 16;
        p.HasPhysics = false;
        p.SizeCurve = ParticleSizeCurve.GrowIn;
        return handle;
    }

    private int Note(IParticle type, double x, double y, double z, double colour) {
        int handle = New(x, y, z, 0.0, 0.0, 0.0);
        ref ParticleState p = ref Sprite(handle, type);
        p.Friction = 0.66F;
        p.Flags |= ParticleFlags.SpeedUpWhenBlocked;
        p.Xd *= 0.01F;
        p.Yd = p.Yd * 0.01F + 0.2;
        p.Zd *= 0.01F;
        float c = (float)colour;
        p.SetColour(Math.Max(0.0F, MathF.Sin(c * MathF.Tau) * 0.65F + 0.35F), Math.Max(0.0F, MathF.Sin((c + 1.0F / 3.0F) * MathF.Tau) * 0.65F + 0.35F),
            Math.Max(0.0F, MathF.Sin((c + 2.0F / 3.0F) * MathF.Tau) * 0.65F + 0.35F));
        p.Size *= 1.5F;
        p.Lifetime = 6;
        p.SizeCurve = ParticleSizeCurve.GrowIn;
        return handle;
    }

    private int Bubble(IParticle type, double x, double y, double z, double xa, double ya, double za, bool column) {
        int handle = New(x, y, z);
        ref ParticleState p = ref Sprite(handle, type);
        p.Width = p.Height = 0.02F;
        p.Size *= Random.NextFloat() * 0.6F + 0.2F;
        p.Xd = xa * 0.2F + (Random.NextFloat() * 2.0F - 1.0F) * 0.02F;
        p.Yd = ya * 0.2F + (Random.NextFloat() * 2.0F - 1.0F) * 0.02F;
        p.Zd = za * 0.2F + (Random.NextFloat() * 2.0F - 1.0F) * 0.02F;
        if (column) {
            p.Gravity = -0.125F;
            p.Friction = 0.85F;
            p.Lifetime = Life(40.0);
            p.Motion = ParticleMotion.BubbleColumnUp;
        }
        else {
            p.Lifetime = Life(8.0);
            p.Motion = ParticleMotion.Bubble;
        }
        return handle;
    }

    private int BubblePop(IParticle type, double x, double y, double z, double xa, double ya, double za) {
        int handle = New(x, y, z);
        ref ParticleState p = ref FirstSprite(handle, type);
        p.Lifetime = 4;
        p.Gravity = 0.008F;
        p.SetSpeed(xa, ya, za);
        p.Motion = ParticleMotion.BubblePop;
        return handle;
    }

    private int SulfurBubble(IParticle type, double x, double y, double z, double xa, double za) {
        int handle = New(x, y, z);
        ref ParticleState p = ref Sprite(handle, type);
        p.Gravity = -0.04F;
        p.Friction = 0.85F;
        p.Width = p.Height = 0.02F;
        p.Xd = xa * 0.2F + (Random.NextFloat() * 2.0F - 1.0F) * 0.02F;
        p.Zd = za * 0.2F + (Random.NextFloat() * 2.0F - 1.0F) * 0.02F;
        p.F0 = 0.02F + 0.02F * Random.NextFloat();
        p.Size = p.F0;
        p.Lifetime = int.MaxValue;
        p.Ay = p.Yo;
        p.Az = p.Yo + 3.0;
        p.Ax = y;
        p.Motion = ParticleMotion.SulfurBubble;
        return handle;
    }

    private int CampfireSmoke(IParticle type, double x, double y, double z, double xa, double ya, double za, bool signal) {
        int handle = New(x, y, z);
        ref ParticleState p = ref Sprite(handle, type);
        p.Scale(3.0F);
        p.Width = p.Height = 0.25F;
        p.Lifetime = Random.NextInt(50) + (signal ? 280 : 80);
        p.Gravity = 3.0E-6F;
        p.SetSpeed(xa, ya + Random.NextFloat() / 500.0F, za);
        p.Translucent = true;
        p.A = signal ? 0.95F : 0.9F;
        p.Motion = ParticleMotion.CampfireSmoke;
        return handle;
    }

    private int PlayerCloud(IParticle type, double x, double y, double z, double xa, double ya, double za) {
        int handle = New(x, y, z, 0.0, 0.0, 0.0);
        ref ParticleState p = ref FirstSprite(handle, type);
        p.Friction = 0.96F;
        p.Xd = p.Xd * 0.1F + xa;
        p.Yd = p.Yd * 0.1F + ya;
        p.Zd = p.Zd * 0.1F + za;
        float colour = 1.0F - Random.NextFloat() * 0.3F;
        p.SetColour(colour, colour, colour);
        p.Size *= 1.875F;
        p.Lifetime = (int)Math.Max((int)(8.0 / (Random.NextFloat() * 0.8 + 0.3)) * 2.5F, 1.0F);
        p.HasPhysics = false;
        p.Translucent = true;
        p.SizeCurve = ParticleSizeCurve.GrowIn;
        p.Motion = ParticleMotion.PlayerCloud;
        return handle;
    }

    private int SuspendedTown(IParticle type, double x, double y, double z, double xa, double ya, double za) {
        int handle = New(x, y, z, xa, ya, za);
        ref ParticleState p = ref Sprite(handle, type);
        float brightness = Random.NextFloat() * 0.1F + 0.2F;
        p.SetColour(brightness, brightness, brightness);
        p.Width = p.Height = 0.02F;
        p.Size *= Random.NextFloat() * 0.6F + 0.5F;
        p.Xd *= 0.02F;
        p.Yd *= 0.02F;
        p.Zd *= 0.02F;
        p.Lifetime = Life(20.0);
        p.Motion = ParticleMotion.SuspendedTown;
        return handle;
    }

    private int WaterCurrentDown(IParticle type, double x, double y, double z) {
        int handle = New(x, y, z);
        ref ParticleState p = ref Sprite(handle, type);
        p.Lifetime = (int)(Random.NextFloat() * 60.0F) + 30;
        p.HasPhysics = false;
        p.SetSpeed(0.0, -0.05, 0.0);
        p.Width = p.Height = 0.02F;
        p.Size *= Random.NextFloat() * 0.6F + 0.2F;
        p.Gravity = 0.002F;
        p.Motion = ParticleMotion.WaterCurrentDown;
        return handle;
    }

    private int DragonBreath(IParticle type, float power, double x, double y, double z, double xa, double ya, double za) {
        int handle = New(x, y, z);
        ref ParticleState p = ref FirstSprite(handle, type);
        p.Friction = 0.96F;
        p.SetSpeed(xa, ya, za);
        p.SetColour(Random.Between(0.7176471F, 0.8745098F), 0.0F, Random.Between(0.8235294F, 0.9764706F));
        p.Size *= 0.75F;
        p.Lifetime = Life(20.0);
        p.HasPhysics = false;
        p.SizeCurve = ParticleSizeCurve.GrowIn;
        p.Motion = ParticleMotion.DragonBreath;
        p.SetPower(power);
        return handle;
    }

    /// <param name="fluid">The fluid it vanishes into: <see cref="FluidWater"/>, <see cref="FluidLava"/> or none.</param>
    /// <param name="next">What a hanging drip becomes, or a falling one makes when it lands.</param>
    /// <param name="life">The n of a landing drip's <c>(int)(n / (random * 0.8 + 0.2))</c> lifetime, or 0 for the stage's own.</param>
    private int Drip(IParticle type, double x, double y, double z, byte fluid, byte stage, IParticle? next, float r, float g, float b, double life = 0) {
        int handle = New(x, y, z);
        ref ParticleState p = ref Sprite(handle, type);
        p.Width = p.Height = 0.01F;
        p.Gravity = 0.06F;
        p.I1 = fluid;
        p.Variant = stage;
        p.I0 = next == null ? -1 : TypeId(next);
        switch (stage) {
            case DripHang or DripCoolingHang:
                p.Gravity *= 0.02F;
                p.Lifetime = 40;
                break;
            case DripFallAndLand:
                p.Lifetime = Life(64.0);
                break;
        }
        if (life > 0) {
            p.Lifetime = Life(life);
        }
        p.SetColour(r, g, b);
        p.Motion = ParticleMotion.Drip;
        return handle;
    }

    private int FallingDust(IParticle type, uint state, double x, double y, double z) {
        int colour = Colours?.DustColour(state, (int)Math.Floor(x), (int)Math.Floor(y), (int)Math.Floor(z)) ?? 0xFFFFFF;
        int handle = New(x, y, z);
        ref ParticleState p = ref FirstSprite(handle, type);
        p.SetColour(colour);
        p.Size *= 0.67499995F;
        p.Lifetime = (int)Math.Max(Life(32.0) * 0.9F, 1.0F);
        p.F0 = (Random.NextFloat() - 0.5F) * 0.1F;
        p.Roll = p.RollO = Random.NextFloat() * MathF.Tau;
        p.SizeCurve = ParticleSizeCurve.GrowIn;
        p.Motion = ParticleMotion.FallingDust;
        return handle;
    }

    private int FallingLeaves(IParticle type, double x, double y, double z, float fallAcceleration, float sideAcceleration, bool swirl, bool flowAway,
        float scale, float startVelocity) {
        int handle = New(x, y, z);
        ref ParticleState p = ref Sprite(handle, type);
        p.F0 = (Random.NextBool() ? -30.0F : 30.0F) * MathF.PI / 180.0F;
        p.F1 = (Random.NextBool() ? -5.0F : 5.0F) * MathF.PI / 180.0F;
        p.F2 = sideAcceleration;
        p.Variant = (byte)((swirl ? 1 : 0) | (flowAway ? 2 : 0));
        p.Lifetime = 300;
        p.Gravity = fallAcceleration * 1.2F * 0.0025F;
        float size = scale * (Random.NextBool() ? 0.05F : 0.075F);
        p.Size = size;
        p.Width = p.Height = size;
        p.Friction = 1.0F;
        p.Yd = -startVelocity;
        float random = Random.NextFloat();
        p.Ax = Math.Cos(random * 60.0 * Math.PI / 180.0) * sideAcceleration;
        p.Ay = Math.Sin(random * 60.0 * Math.PI / 180.0) * sideAcceleration;
        p.Az = (1000.0F + random * 3000.0F) * Math.PI / 180.0;
        p.Motion = ParticleMotion.FallingLeaves;
        return handle;
    }

    private int Firefly(IParticle type, double x, double y, double z, double ya) {
        int handle = New(x, y, z, 0.5 - Random.NextDouble(), Random.NextBool() ? ya : -ya, 0.5 - Random.NextDouble());
        ref ParticleState p = ref Sprite(handle, type);
        p.Flags |= ParticleFlags.SpeedUpWhenBlocked;
        p.Friction = 0.96F;
        p.Size *= 0.75F;
        p.Xd *= 0.8F;
        p.Yd *= 0.8F;
        p.Zd *= 0.8F;
        p.Lifetime = 200 + Random.NextInt(101);
        p.Scale(1.5F);
        p.A = 0.0F;
        p.Translucent = true;
        p.LightMode = ParticleLightMode.Firefly;
        p.Motion = ParticleMotion.Firefly;
        return handle;
    }

    /// <summary>
    /// <c>FireworkParticles.SparkParticle</c>, for the firework particle type and for a firework's explosion, which
    /// sets its colour, fade colour (F1 to F3 with <see cref="ParticleFlags.Fade"/>), trail and twinkle afterwards.
    /// </summary>
    public int SpawnSpark(double x, double y, double z, double xa, double ya, double za) {
        if (!Ready()) {
            return -1;
        }
        int handle = New(x, y, z);
        ref ParticleState p = ref FirstSprite(handle, Particle.Firework);
        p.Friction = 0.91F;
        p.Gravity = 0.1F;
        p.SetSpeed(xa, ya, za);
        p.Size *= 0.75F;
        p.Lifetime = 48 + Random.NextInt(12);
        p.A = 0.99F;
        p.Translucent = true;
        p.LightMode = ParticleLightMode.FullBright;
        p.Motion = ParticleMotion.FireworkSpark;
        return handle;
    }

    private int Flash(IParticle type, int argb, double x, double y, double z) {
        int handle = New(x, y, z);
        ref ParticleState p = ref Sprite(handle, type);
        p.Lifetime = 4;
        p.SetColour(argb);
        p.Size = 1.0F;
        p.Translucent = true;
        p.SizeCurve = ParticleSizeCurve.Flash;
        p.AlphaCurve = ParticleAlphaCurve.Flash;
        return handle;
    }

    private int FlyStraightTowards(IParticle type, double x, double y, double z, double xa, double ya, double za) {
        int handle = New(x, y, z);
        ref ParticleState p = ref Sprite(handle, type);
        p.SetSpeed(xa, ya, za);
        (p.Ax, p.Ay, p.Az) = (x, y, z);
        p.X = p.Xo = x + xa;
        p.Y = p.Yo = y + ya;
        p.Z = p.Zo = z + za;
        p.Size = 0.1F * (Random.NextFloat() * 0.5F + 0.2F);
        p.HasPhysics = false;
        p.Lifetime = (int)(Random.NextFloat() * 5.0F) + 25;
        p.I0 = -12210434;
        p.I1 = -1;
        p.Scale(Random.Between(3.0F, 5.0F));
        p.LightMode = ParticleLightMode.BlockMax;
        p.Motion = ParticleMotion.FlyStraightTowards;
        return handle;
    }

    private int FlyTowards(IParticle type, double x, double y, double z, double xa, double ya, double za, bool vault) {
        int handle = New(x, y, z);
        ref ParticleState p = ref Sprite(handle, type);
        p.SetSpeed(xa, ya, za);
        (p.Ax, p.Ay, p.Az) = (x, y, z);
        p.X = p.Xo = x + xa;
        p.Y = p.Yo = y + ya;
        p.Z = p.Zo = z + za;
        p.Size = 0.1F * (Random.NextFloat() * 0.5F + 0.2F);
        float brightness = Random.NextFloat() * 0.6F + 0.4F;
        p.SetColour(0.9F * brightness, 0.9F * brightness, brightness);
        p.HasPhysics = false;
        p.Lifetime = (int)(Random.NextFloat() * 10.0F) + 30;
        p.LightMode = ParticleLightMode.EmissionByAgeFourth;
        if (vault) {
            p.LightMode = ParticleLightMode.BlockMax;
            p.AlphaCurve = ParticleAlphaCurve.VaultConnection;
            p.A = 0.0F;
            p.Translucent = true;
            p.Scale(1.5F);
        }
        p.Motion = ParticleMotion.FlyTowardsPosition;
        return handle;
    }

    /// <summary><c>SimpleAnimatedParticle</c>: lit fully, translucent, fading over its second half.</summary>
    private int SimpleAnimated(IParticle type, double x, double y, double z, float gravity) {
        int handle = New(x, y, z);
        ref ParticleState p = ref FirstSprite(handle, type);
        p.Friction = 0.91F;
        p.Gravity = gravity;
        p.Translucent = true;
        p.LightMode = ParticleLightMode.FullBright;
        p.Motion = ParticleMotion.SimpleAnimated;
        return handle;
    }

    private int EndRod(IParticle type, double x, double y, double z, double xa, double ya, double za) {
        int handle = SimpleAnimated(type, x, y, z, 0.0125F);
        ref ParticleState p = ref _pending[handle];
        p.SetSpeed(xa, ya, za);
        p.Size *= 0.75F;
        p.Lifetime = 60 + Random.NextInt(12);
        p.Flags |= ParticleFlags.Fade;
        (p.F1, p.F2, p.F3) = (0xF2 / 255.0F, 0xDE / 255.0F, 0xC9 / 255.0F);
        p.HasPhysics = false;
        return handle;
    }

    private int Totem(IParticle type, double x, double y, double z, double xa, double ya, double za) {
        int handle = SimpleAnimated(type, x, y, z, 1.25F);
        ref ParticleState p = ref _pending[handle];
        p.Friction = 0.6F;
        p.SetSpeed(xa, ya, za);
        p.Size *= 0.75F;
        p.Lifetime = 60 + Random.NextInt(12);
        if (Random.NextInt(4) == 0) {
            p.SetColour(0.6F + Random.NextFloat() * 0.2F, 0.6F + Random.NextFloat() * 0.3F, Random.NextFloat() * 0.2F);
        }
        else {
            p.SetColour(0.1F + Random.NextFloat() * 0.2F, 0.4F + Random.NextFloat() * 0.3F, Random.NextFloat() * 0.2F);
        }
        return handle;
    }

    private int SquidInk(IParticle type, double x, double y, double z, double xa, double ya, double za, float r, float g, float b) {
        int handle = SimpleAnimated(type, x, y, z, 0.0F);
        ref ParticleState p = ref _pending[handle];
        p.Friction = 0.92F;
        p.Size = 0.5F;
        p.A = 1.0F;
        p.SetColour(r, g, b);
        p.Lifetime = (int)(p.Size * 12.0F / (Random.NextFloat() * 0.8F + 0.2F));
        p.HasPhysics = false;
        p.SetSpeed(xa, ya, za);
        p.Motion = ParticleMotion.SquidInk;
        return handle;
    }

    private int Glow(IParticle type, double x, double y, double z, double xa, double ya, double za) {
        int handle = New(x, y, z, xa, ya, za);
        ref ParticleState p = ref FirstSprite(handle, type);
        p.Friction = 0.96F;
        p.Flags |= ParticleFlags.SpeedUpWhenBlocked;
        p.Size *= 0.75F;
        p.HasPhysics = false;
        p.LightMode = ParticleLightMode.EmissionByAge;
        return handle;
    }

    private int Gust(IParticle type, double x, double y, double z, float scale) {
        int handle = New(x, y, z);
        ref ParticleState p = ref FirstSprite(handle, type);
        p.Lifetime = 12 + Random.NextInt(4);
        p.Size = 1.0F;
        p.Width = p.Height = 1.0F;
        p.LightMode = ParticleLightMode.FullBright;
        p.Motion = ParticleMotion.AgeOnly;
        p.Scale(scale);
        return handle;
    }

    private int GustSeed(double x, double y, double z, float scale, int lifetime, int delay) {
        int handle = Emitter(New(x, y, z, 0.0, 0.0, 0.0), ParticleMotion.GustSeed, lifetime);
        ref ParticleState p = ref _pending[handle];
        p.F0 = scale;
        p.I0 = delay;
        return handle;
    }

    /// <summary><c>HugeExplosionParticle</c>, and the sweep and sonic boom that only differ in size and life.</summary>
    private int HugeExplosion(IParticle type, double x, double y, double z, double size, int lifetime, float quadSize) {
        int handle = New(x, y, z, 0.0, 0.0, 0.0);
        ref ParticleState p = ref FirstSprite(handle, type);
        p.Lifetime = lifetime;
        float colour = Random.NextFloat() * 0.6F + 0.4F;
        p.SetColour(colour, colour, colour);
        p.Size = quadSize;
        p.LightMode = ParticleLightMode.FullBright;
        p.Motion = ParticleMotion.AgeOnly;
        return handle;
    }

    private int ElderGuardian(double x, double y, double z) {
        int handle = New(x, y, z);
        ref ParticleState p = ref _pending[handle];
        p.Lifetime = 30;
        p.Flags |= ParticleFlags.ElderGuardian;
        p.Motion = ParticleMotion.AgeOnly;
        return handle;
    }

    private int Wake(IParticle type, double x, double y, double z, double xa, double ya, double za) {
        int handle = New(x, y, z, 0.0, 0.0, 0.0);
        ref ParticleState p = ref Sprite(handle, type, ParticleSpriteMode.Fraction);
        p.Width = p.Height = 0.01F;
        p.Lifetime = Life(8.0);
        p.SpriteNum = (60 - p.Lifetime) % 4;
        p.SpriteDen = 4;
        p.SetSpeed(xa, ya, za);
        p.Motion = ParticleMotion.Wake;
        return handle;
    }

    private int SculkCharge(IParticle type, double x, double y, double z, double xa, double ya, double za, float scale, int lifeRange, int lifeBase, float roll) {
        int handle = New(x, y, z, xa, ya, za);
        ref ParticleState p = ref FirstSprite(handle, type);
        p.Friction = 0.96F;
        p.Scale(scale);
        p.HasPhysics = false;
        p.Translucent = true;
        p.LightMode = ParticleLightMode.BlockMax;
        p.SetSpeed(xa, ya, za);
        p.Roll = p.RollO = roll;
        p.Lifetime = Random.NextInt(lifeRange) + lifeBase;
        return handle;
    }

    private int Lava(IParticle type, double x, double y, double z) {
        int handle = New(x, y, z, 0.0, 0.0, 0.0);
        ref ParticleState p = ref Sprite(handle, type);
        p.Gravity = 0.75F;
        p.Friction = 0.999F;
        p.Xd *= 0.8F;
        p.Zd *= 0.8F;
        p.Yd = Random.NextFloat() * 0.4F + 0.05F;
        p.Size *= Random.NextFloat() * 2.0F + 0.2F;
        p.Lifetime = Life(16.0);
        p.LightMode = ParticleLightMode.BlockMax;
        p.SizeCurve = ParticleSizeCurve.Lava;
        p.Motion = ParticleMotion.Lava;
        return handle;
    }

    private int Explode(IParticle type, double x, double y, double z, double xa, double ya, double za, float gravity) {
        int handle = New(x, y, z);
        ref ParticleState p = ref FirstSprite(handle, type);
        p.Gravity = gravity;
        p.Friction = 0.9F;
        p.Xd = xa + (Random.NextFloat() * 2.0F - 1.0F) * 0.05F;
        p.Yd = ya + (Random.NextFloat() * 2.0F - 1.0F) * 0.05F;
        p.Zd = za + (Random.NextFloat() * 2.0F - 1.0F) * 0.05F;
        float colour = Random.NextFloat() * 0.3F + 0.7F;
        p.SetColour(colour, colour, colour);
        p.Size = 0.1F * (Random.NextFloat() * Random.NextFloat() * 6.0F + 1.0F);
        p.Lifetime = Life(16.0) + 2;
        return handle;
    }

    private int Portal(IParticle type, double x, double y, double z, double xa, double ya, double za, bool reverse) {
        int handle = New(x, y, z);
        ref ParticleState p = ref Sprite(handle, type);
        p.SetSpeed(xa, ya, za);
        (p.Ax, p.Ay, p.Az) = (x, y, z);
        p.Size = 0.1F * (Random.NextFloat() * 0.2F + 0.5F);
        float brightness = Random.NextFloat() * 0.6F + 0.4F;
        p.SetColour(brightness * 0.9F, brightness * 0.3F, brightness);
        p.Lifetime = (int)(Random.NextFloat() * 10.0F) + 40;
        p.LightMode = ParticleLightMode.EmissionByAgeFourth;
        p.SizeCurve = ParticleSizeCurve.Portal;
        p.Motion = ParticleMotion.Portal;
        if (reverse) {
            p.Size *= 1.5F;
            p.Lifetime = (int)(Random.NextFloat() * 2.0F) + 60;
            p.SizeCurve = ParticleSizeCurve.ReversePortal;
            p.Motion = ParticleMotion.ReversePortal;
        }
        return handle;
    }

    private int WaterDrop(IParticle type, double x, double y, double z) {
        int handle = New(x, y, z, 0.0, 0.0, 0.0);
        ref ParticleState p = ref Sprite(handle, type);
        p.Xd *= 0.3F;
        p.Yd = Random.NextFloat() * 0.2F + 0.1F;
        p.Zd *= 0.3F;
        p.Width = p.Height = 0.01F;
        p.Gravity = 0.06F;
        p.Lifetime = Life(8.0);
        p.Motion = ParticleMotion.WaterDrop;
        return handle;
    }

    private int Snowflake(IParticle type, double x, double y, double z, double xa, double ya, double za) {
        int handle = New(x, y, z);
        ref ParticleState p = ref FirstSprite(handle, type);
        p.Gravity = 0.225F;
        p.Friction = 1.0F;
        p.Xd = xa + (Random.NextFloat() * 2.0F - 1.0F) * 0.05F;
        p.Yd = ya + (Random.NextFloat() * 2.0F - 1.0F) * 0.05F;
        p.Zd = za + (Random.NextFloat() * 2.0F - 1.0F) * 0.05F;
        p.Size = 0.1F * (Random.NextFloat() * Random.NextFloat() + 1.0F);
        p.Lifetime = Life(16.0) + 2;
        p.SetColour(0.923F, 0.964F, 0.999F);
        p.Motion = ParticleMotion.Snowflake;
        return handle;
    }

    /// <summary><c>SpellParticle</c>: thrown out at random sideways and up whatever it is given, rising and fading in.</summary>
    private int Spell(IParticle type, double x, double y, double z, double xa, double ya, double za) {
        int handle = New(x, y, z, 0.5 - Random.NextDouble(), ya, 0.5 - Random.NextDouble());
        ref ParticleState p = ref FirstSprite(handle, type);
        p.Friction = 0.96F;
        p.Gravity = -0.1F;
        p.Flags |= ParticleFlags.SpeedUpWhenBlocked;
        p.Yd *= 0.2F;
        if (xa == 0.0 && za == 0.0) {
            p.Xd *= 0.1F;
            p.Zd *= 0.1F;
        }
        p.Size *= 0.75F;
        p.Lifetime = Life(8.0);
        p.HasPhysics = false;
        p.Translucent = true;
        return handle;
    }

    /// <param name="speed">The motion for the constructor that takes one; null for the one that does not.</param>
    private int Suspended(IParticle type, double x, double y, double z, (double X, double Y, double Z)? speed) {
        int handle = speed is var (sx, sy, sz) ? New(x, y - 0.125, z, sx, sy, sz) : New(x, y - 0.125, z);
        ref ParticleState p = ref Sprite(handle, type);
        p.Width = p.Height = 0.01F;
        p.Size *= Random.NextFloat() * 0.6F + (speed == null ? 0.2F : 0.6F);
        p.Lifetime = Life(16.0);
        p.HasPhysics = false;
        p.Friction = 1.0F;
        p.Gravity = 0.0F;
        return handle;
    }

    private int Vibration(IParticle type, VibrationParticle options, double x, double y, double z) {
        int handle = New(x, y, z, 0.0, 0.0, 0.0);
        ref ParticleState p = ref Sprite(handle, type);
        p.Size = 0.3F;
        p.Lifetime = options.Ticks;
        switch (options.PositionSource) {
            case VibrationParticle.BlockPositionSource block:
                (p.Ax, p.Ay, p.Az) = (block.Position.X + 0.5, block.Position.Y + 0.5, block.Position.Z + 0.5);
                break;
            case VibrationParticle.EntityPositionSource entity:
                p.I0 = entity.EntityId;
                p.I1 = 1;
                p.Ay = entity.EntityEyeHeight;
                break;
        }
        if (VibrationTarget(ref p, out double tx, out double ty, out double tz)) {
            double dx = x - tx, dy = y - ty, dz = z - tz;
            p.F0 = p.F1 = (float)Math.Atan2(dx, dz);
            p.F2 = p.F3 = (float)Math.Atan2(dy, Math.Sqrt(dx * dx + dz * dz));
        }
        p.Translucent = true;
        p.LightMode = ParticleLightMode.BlockMax;
        p.Facing = ParticleFacing.Vibration;
        p.Motion = ParticleMotion.Vibration;
        return handle;
    }

    private int Trail(IParticle type, TrailParticle options, double x, double y, double z, double xa, double ya, double za) {
        int handle = New(x, y, z, xa, ya, za);
        ref ParticleState p = ref Sprite(handle, type);
        int colour = options.Color.ToDecimal();
        p.SetColour((colour >> 16 & 0xFF) / 255.0F * (0.875F + Random.NextFloat() * 0.25F), (colour >> 8 & 0xFF) / 255.0F * (0.875F + Random.NextFloat() * 0.25F),
            (colour & 0xFF) / 255.0F * (0.875F + Random.NextFloat() * 0.25F));
        p.Size = 0.26F;
        (p.Ax, p.Ay, p.Az) = (options.Target.X, options.Target.Y, options.Target.Z);
        p.Lifetime = options.Duration;
        p.LightMode = ParticleLightMode.FullBright;
        p.Motion = ParticleMotion.Trail;
        return handle;
    }

    private int Vertical(IParticle type, double x, double y, double z, double xa, double ya, double za, bool upwards) {
        int handle = New(x, y, z, xa, ya, za);
        ref ParticleState p = ref Sprite(handle, type);
        p.SetSpeed(xa, ya + (upwards ? 0.03 : -0.03), za);
        p.Gravity = 0.0F;
        p.Size *= Random.NextFloat() * 0.6F + 0.5F;
        p.Lifetime = 8;
        return handle;
    }

    private int Shriek(IParticle type, int delay, double x, double y, double z) {
        int handle = New(x, y, z, 0.0, 0.0, 0.0);
        ref ParticleState p = ref Sprite(handle, type);
        p.Size = 0.85F;
        p.I0 = delay;
        p.Lifetime = 30;
        p.Gravity = 0.0F;
        p.SetSpeed(0.0, 0.1, 0.0);
        p.Translucent = true;
        p.LightMode = ParticleLightMode.BlockMax;
        p.SizeCurve = ParticleSizeCurve.Shriek;
        p.AlphaCurve = ParticleAlphaCurve.Shriek;
        p.Facing = ParticleFacing.Shriek;
        p.Set(ParticleFlags.Hidden, delay > 0);
        p.Motion = ParticleMotion.Shriek;
        return handle;
    }

    private int TrialSpawnerDetection(IParticle type, double x, double y, double z, double xa, double ya, double za) {
        const float scale = 1.5F;
        int handle = New(x, y, z, 0.0, 0.0, 0.0);
        ref ParticleState p = ref FirstSprite(handle, type);
        p.Friction = 0.96F;
        p.Gravity = -0.1F;
        p.Flags |= ParticleFlags.SpeedUpWhenBlocked;
        p.SetSpeed(xa, p.Yd * 0.9 + ya, za);
        p.Size *= 0.75F * scale;
        p.Lifetime = Math.Max((int)(8.0F / Random.Between(0.5F, 1.0F) * scale), 1);
        p.LightMode = ParticleLightMode.BlockMax;
        p.Facing = ParticleFacing.CameraY;
        p.SizeCurve = ParticleSizeCurve.GrowIn;
        return handle;
    }

    /// <summary><c>DustParticleBase</c>.</summary>
    private int DustBase(IParticle type, float scale, double x, double y, double z, double xa, double ya, double za) {
        int handle = New(x, y, z, xa, ya, za);
        ref ParticleState p = ref FirstSprite(handle, type);
        p.Friction = 0.96F;
        p.Flags |= ParticleFlags.SpeedUpWhenBlocked;
        p.Xd *= 0.1F;
        p.Yd *= 0.1F;
        p.Zd *= 0.1F;
        p.Size *= 0.75F * scale;
        p.Lifetime = (int)Math.Max((int)(8.0 / (Random.NextDouble() * 0.8 + 0.2)) * scale, 1.0F);
        p.SizeCurve = ParticleSizeCurve.GrowIn;
        return handle;
    }

    private int Dust(IParticle type, DustParticle options, double x, double y, double z, double xa, double ya, double za) {
        int handle = DustBase(type, options.Scale, x, y, z, xa, ya, za);
        ref ParticleState p = ref _pending[handle];
        float factor = Random.NextFloat() * 0.4F + 0.6F;
        int colour = options.Color.ToDecimal();
        p.SetColour(Randomise(colour >> 16), Randomise(colour >> 8), Randomise(colour));
        return handle;

        float Randomise(int channel) => (Random.NextFloat() * 0.2F + 0.8F) * ((channel & 0xFF) / 255.0F) * factor;
    }

    /// <summary>The colours to go from and to are packed in I0 and I1, and set at each tick from the age.</summary>
    private int DustTransition(IParticle type, DustColorTransitionParticle options, double x, double y, double z, double xa, double ya, double za) {
        int handle = DustBase(type, options.Scale, x, y, z, xa, ya, za);
        ref ParticleState p = ref _pending[handle];
        float factor = Random.NextFloat() * 0.4F + 0.6F;
        p.I0 = Randomise(options.FromColor.ToDecimal());
        p.I1 = Randomise(options.ToColor.ToDecimal());
        p.SetColour(p.I0);
        p.Motion = ParticleMotion.DustColorTransition;
        return handle;

        int Randomise(int rgb) {
            int Channel(int shift) => Math.Clamp((int)((Random.NextFloat() * 0.2F + 0.8F) * ((rgb >> shift & 0xFF) / 255.0F) * factor * 255.0F + 0.5F), 0, 255);
            return Channel(16) << 16 | Channel(8) << 8 | Channel(0);
        }
    }

    /// <summary><c>TerrainParticle.createTerrainParticle</c>: not for air, a moving piston, or a block that makes no terrain particles.</summary>
    private int Terrain(uint state, double x, double y, double z, double xa, double ya, double za) {
        IBlock block = _level!.Registry.Blocks.GetByStateId(state);
        if (block.Air || block is Minecraft.Data.Generated.BlockTypes.MovingPistonBlock || !block.SpawnTerrainParticles) {
            return -1;
        }
        return TerrainParticle(state, x, y, z, xa, ya, za, (int)Math.Floor(x), (int)Math.Floor(y), (int)Math.Floor(z));
    }

    /// <summary><c>TerrainParticle</c>: a quarter of the block's particle sprite, greyed and tinted as the block is where it was.</summary>
    private int TerrainParticle(uint state, double x, double y, double z, double xa, double ya, double za, int bx, int by, int bz) {
        int handle = New(x, y, z, xa, ya, za);
        ref ParticleState p = ref _pending[handle];
        p.Type = TypeId(Particle.Block);
        p.Gravity = 1.0F;
        p.SetColour(0.6F, 0.6F, 0.6F);
        int tint = Colours?.TerrainTint(state, bx, by, bz) ?? -1;
        if (tint != -1) {
            p.R *= (tint >> 16 & 0xFF) / 255.0F;
            p.G *= (tint >> 8 & 0xFF) / 255.0F;
            p.B *= (tint & 0xFF) / 255.0F;
        }
        p.Size /= 2.0F;
        p.Uo = Random.NextFloat() * 3.0F;
        p.Vo = Random.NextFloat() * 3.0F;
        p.Texture = ParticleTexture.BlockQuarter;
        p.TextureArg = (int)state;
        return handle;
    }

    private int BlockMarker(int state, double x, double y, double z) {
        int handle = New(x, y, z);
        ref ParticleState p = ref _pending[handle];
        p.Type = TypeId(Particle.BlockMarker);
        p.Lifetime = 80;
        p.HasPhysics = false;
        p.Size = 0.5F;
        p.Texture = ParticleTexture.Block;
        p.TextureArg = state;
        return handle;
    }

    /// <param name="stack">The item whose particle sprite it shows; null for the sprite set's own first frame.</param>
    /// <param name="moving">The constructor that takes a motion, which only the item particle type uses.</param>
    private int BreakingItem(IParticle type, ItemStack? stack, double x, double y, double z, double xa, double ya, double za, bool moving) {
        if (stack != null && stack.Count == 0) {
            return -1;
        }
        int handle = New(x, y, z, 0.0, 0.0, 0.0);
        ref ParticleState p = ref Sprite(handle, type);
        p.Gravity = 1.0F;
        p.Size /= 2.0F;
        p.Uo = Random.NextFloat() * 3.0F;
        p.Vo = Random.NextFloat() * 3.0F;
        p.SpriteNum = 0;
        if (stack != null) {
            p.Texture = ParticleTexture.ItemQuarter;
            p.TextureArg = InternItem(stack);
        }
        else {
            p.Texture = ParticleTexture.SpriteQuarter;
        }
        if (moving) {
            p.Xd = p.Xd * 0.1F + xa;
            p.Yd = p.Yd * 0.1F + ya;
            p.Zd = p.Zd * 0.1F + za;
        }
        return handle;
    }

    #region Block effects

    /// <summary>
    /// <c>ClientLevel.addDestroyBlockEffect</c>, for level event 2001: a grid of terrain particles through each box
    /// of the block's shape, a quarter block apart, thrown outward from the middle. They skip the distance check.
    /// </summary>
    public void Destroy(int x, int y, int z, uint state) {
        if (!Ready()) {
            return;
        }
        IBlock block = _level!.Registry.Blocks.GetByStateId(state);
        if (block.Air || !block.SpawnTerrainParticles) {
            return;
        }
        foreach (Box box in ShapeOf(block, x, y, z)) {
            double widthX = Math.Min(1.0, box.MaxX - box.MinX);
            double widthY = Math.Min(1.0, box.MaxY - box.MinY);
            double widthZ = Math.Min(1.0, box.MaxZ - box.MinZ);
            int countX = Math.Max(2, (int)Math.Ceiling(widthX / 0.25));
            int countY = Math.Max(2, (int)Math.Ceiling(widthY / 0.25));
            int countZ = Math.Max(2, (int)Math.Ceiling(widthZ / 0.25));
            for (int xx = 0; xx < countX; xx++) {
                for (int yy = 0; yy < countY; yy++) {
                    for (int zz = 0; zz < countZ; zz++) {
                        double relX = (xx + 0.5) / countX;
                        double relY = (yy + 0.5) / countY;
                        double relZ = (zz + 0.5) / countZ;
                        TerrainParticle(state, x + relX * widthX + box.MinX, y + relY * widthY + box.MinY, z + relZ * widthZ + box.MinZ,
                            relX - 0.5, relY - 0.5, relZ - 0.5, x, y, z);
                    }
                }
            }
        }
    }

    /// <summary>
    /// <c>ClientLevel.addBreakingBlockEffect</c>, each tick the player digs: one slow, small terrain particle just off
    /// the face being hit, somewhere across it.
    /// </summary>
    public void Crack(int x, int y, int z, BlockFace face) {
        if (!Ready()) {
            return;
        }
        ushort state = StateAt(x, y, z);
        IBlock block = _level!.Registry.Blocks.GetByStateId(state);
        if (block.Air || !block.SpawnTerrainParticles) {
            return;
        }
        Box[] shape = ShapeOf(block, x, y, z);
        if (shape.Length == 0) {
            return;
        }
        double minX = shape.Min(b => b.MinX), minY = shape.Min(b => b.MinY), minZ = shape.Min(b => b.MinZ);
        double maxX = shape.Max(b => b.MaxX), maxY = shape.Max(b => b.MaxY), maxZ = shape.Max(b => b.MaxZ);
        double xp = x + Random.NextDouble() * (maxX - minX - 0.2F) + 0.1F + minX;
        double yp = y + Random.NextDouble() * (maxY - minY - 0.2F) + 0.1F + minY;
        double zp = z + Random.NextDouble() * (maxZ - minZ - 0.2F) + 0.1F + minZ;
        switch (face) {
            case BlockFace.NegY: yp = y + minY - 0.1F; break;
            case BlockFace.PosY: yp = y + maxY + 0.1F; break;
            case BlockFace.NegZ: zp = z + minZ - 0.1F; break;
            case BlockFace.PosZ: zp = z + maxZ + 0.1F; break;
            case BlockFace.NegX: xp = x + minX - 0.1F; break;
            case BlockFace.PosX: xp = x + maxX + 0.1F; break;
        }
        int handle = TerrainParticle(state, xp, yp, zp, 0.0, 0.0, 0.0, x, y, z);
        ref ParticleState p = ref _pending[handle];
        p.SetPower(0.2F);
        p.Scale(0.6F);
    }

    /// <summary><c>BlockState.getShape</c>, moved by the block's offset where it has one.</summary>
    private static Box[] ShapeOf(IBlock block, int x, int y, int z) {
        Box[] boxes = BlockPhysicsData.CollisionBoxesOf(block.BlockShape);
        if (block.Info.OffsetType == BlockOffsetType.None || boxes.Length == 0) {
            return boxes;
        }
        Minecraft.Schemas.Vec.Vec3<double> offset = block.ShapeOffset(new Minecraft.Schemas.Vec.Vec3<int>(x, y, z));
        return boxes.Select(b => b.Translate(offset.X, offset.Y, offset.Z)).ToArray();
    }

    #endregion
}
