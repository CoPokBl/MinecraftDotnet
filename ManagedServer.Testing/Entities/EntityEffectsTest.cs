using ManagedServer.Entities;
using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Features;
using ManagedServer.Features.Basic;
using ManagedServer.Worlds;
using ManagedServer.Worlds.Lighting;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain.Providers;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Testing.Entities;

/// <summary>
/// <see cref="EntityEffects"/> and the <see cref="EffectsFeature"/> that counts it down: the merge
/// rules from <c>MobEffectInstance.update</c> and the expiry that ends an effect.
/// </summary>
[TestFixture]
public class EntityEffectsTest {
    private ManagedMinecraftServer _server = null!;
    private World _world = null!;

    [SetUp]
    public void Setup() {
        _server = new ManagedMinecraftServer();
        _server.LogAction = _ => { };
        _server.AddFeature(new EffectsFeature());

        _world = _server.CreateWorld(new VoidProvider(), "minecraft:overworld", new FullBrightLightingProvider());
        _world.LoadChunk(new Vec2<int>(0, 0)).Wait();
    }

    [TearDown]
    public void TearDown() {
        _server.Stop();
    }

    private LivingEntity Spawn() {
        LivingEntity entity = new(EntityType.Zombie) {
            Position = new Vec3<double>(8.5, 64, 8.5)
        };
        entity.SetWorld(_world);
        return entity;
    }

    private void AdvanceTicks(int count) {
        for (int i = 0; i < count; i++) {
            _server.Events.CallEvent(new ServerTickEvent {
                Delta = TimeSpan.FromMilliseconds(50),
                TargetDelta = TimeSpan.FromMilliseconds(50),
                Server = _server
            });
        }
    }

    [Test]
    public void TestAddingAnEffectPutsItOnTheEntity() {
        LivingEntity zombie = Spawn();

        Assert.That(zombie.Effects.Add(PotionEffectType.Resistance, 1, 100), Is.True);

        Assert.That(zombie.Effects.Has(PotionEffectType.Resistance), Is.True);
        Assert.That(zombie.Effects.AmplifierOf(PotionEffectType.Resistance), Is.EqualTo(1));
        Assert.That(zombie.Effects.AmplifierOf(PotionEffectType.FireResistance), Is.Null);
    }

    [Test]
    public void TestStrongerEffectReplacesWeakerOne() {
        LivingEntity zombie = Spawn();
        zombie.Effects.Add(PotionEffectType.Resistance, 0, 500);

        Assert.That(zombie.Effects.Add(PotionEffectType.Resistance, 2, 20), Is.True);

        PotionEffect effect = zombie.Effects.Get(PotionEffectType.Resistance)!;
        Assert.That(effect.Amplifier, Is.EqualTo(2));
        Assert.That(effect.Duration, Is.EqualTo(20));
    }

    [Test]
    public void TestWeakerEffectIsIgnored() {
        LivingEntity zombie = Spawn();
        zombie.Effects.Add(PotionEffectType.Resistance, 2, 20);

        Assert.That(zombie.Effects.Add(PotionEffectType.Resistance, 0, 500), Is.False);
        Assert.That(zombie.Effects.AmplifierOf(PotionEffectType.Resistance), Is.EqualTo(2));
    }

    [Test]
    public void TestEqualEffectOnlyExtendsTheDuration() {
        LivingEntity zombie = Spawn();
        zombie.Effects.Add(PotionEffectType.Resistance, 1, 100);

        Assert.That(zombie.Effects.Add(PotionEffectType.Resistance, 1, 50), Is.False);
        Assert.That(zombie.Effects.Add(PotionEffectType.Resistance, 1, 200), Is.True);
        Assert.That(zombie.Effects.Get(PotionEffectType.Resistance)!.Duration, Is.EqualTo(200));
    }

    [Test]
    public void TestInfiniteDurationBeatsAnyFiniteOne() {
        LivingEntity zombie = Spawn();
        zombie.Effects.Add(PotionEffectType.Resistance, 1, int.MaxValue);

        Assert.That(zombie.Effects.Add(PotionEffectType.Resistance, 1, EntityEffects.InfiniteDuration), Is.True);
        Assert.That(zombie.Effects.Add(PotionEffectType.Resistance, 1, int.MaxValue), Is.False);
    }

    [Test]
    public void TestDurationCountsDownAndExpires() {
        LivingEntity zombie = Spawn();
        List<EntityEffectExpireEvent> expired = [];
        _world.Events.AddListener<EntityEffectExpireEvent>(e => expired.Add(e));

        zombie.Effects.Add(PotionEffectType.Resistance, 0, 3);

        AdvanceTicks(2);
        Assert.That(zombie.Effects.Get(PotionEffectType.Resistance)!.Duration, Is.EqualTo(1));
        Assert.That(expired, Is.Empty);

        AdvanceTicks(1);
        Assert.That(zombie.Effects.Has(PotionEffectType.Resistance), Is.False);
        Assert.That(expired, Has.Count.EqualTo(1));
        Assert.That(expired[0].Effect.Amplifier, Is.EqualTo(0));
    }

    [Test]
    public void TestInfiniteDurationNeverExpires() {
        LivingEntity zombie = Spawn();
        zombie.Effects.Add(PotionEffectType.Resistance, 0, EntityEffects.InfiniteDuration);

        AdvanceTicks(100);

        Assert.That(zombie.Effects.Has(PotionEffectType.Resistance), Is.True);
        Assert.That(zombie.Effects.Get(PotionEffectType.Resistance)!.Duration,
            Is.EqualTo(EntityEffects.InfiniteDuration));
    }

    [Test]
    public void TestRemovingAndClearing() {
        LivingEntity zombie = Spawn();
        zombie.Effects.Add(PotionEffectType.Resistance, 0, 100);
        zombie.Effects.Add(PotionEffectType.FireResistance, 0, 100);

        Assert.That(zombie.Effects.Remove(PotionEffectType.Resistance), Is.True);
        Assert.That(zombie.Effects.Remove(PotionEffectType.Resistance), Is.False);
        Assert.That(zombie.Effects.All, Has.Length.EqualTo(1));

        zombie.Effects.Clear();
        Assert.That(zombie.Effects.All, Is.Empty);
    }

    /// <summary>Without the feature registered nothing counts a duration down.</summary>
    [Test]
    public void TestEffectsArePermanentWithoutTheFeature() {
        _server.Feature<EffectsFeature>().Unregister();
        LivingEntity zombie = Spawn();
        zombie.Effects.Add(PotionEffectType.Resistance, 0, 2);

        AdvanceTicks(10);

        Assert.That(zombie.Effects.Get(PotionEffectType.Resistance)!.Duration, Is.EqualTo(2));
    }
}
