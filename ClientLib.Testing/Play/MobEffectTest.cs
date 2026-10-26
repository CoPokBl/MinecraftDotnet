using ClientLib.Entities;
using ClientLib.Maths;
using ClientLib.Player;
using ClientLib.World;
using Minecraft.Data.Generated;
using Minecraft.Data.PotionEffectTypes;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Flags = Minecraft.Packets.Play.ClientBound.ClientBoundEntityEffectPacket.Flags;

namespace ClientLib.Testing.Play;

/// <summary>
/// The client's effect store against vanilla's <c>ClientPacketListener.handleUpdateMobEffect</c>,
/// <c>LivingEntity.forceAddEffect</c>, <c>addEffect</c> and <c>MobEffectInstance.tickClient</c>.
/// </summary>
public class MobEffectTest {
    private const int PlayerId = 1;
    private const int ZombieId = 10;

    private static (MinecraftClient Client, LocalPlayer Player) World() {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        ClientLevel level = new(VanillaRegistry.Data, "minecraft:overworld",
            VanillaRegistry.Data.DimensionTypes["minecraft:overworld"], 63, true, 0);
        for (int cx = -1; cx <= 1; cx++) {
            for (int cz = -1; cz <= 1; cz++) {
                ClientSection[] sections = new ClientSection[level.SectionCount];
                ushort[][] biomes = new ushort[level.SectionCount][];
                for (int i = 0; i < sections.Length; i++) {
                    biomes[i] = new ushort[64];
                    sections[i] = level.MinY + i * 16 < 16 ? new ClientSection((ushort)Block.Stone.StateId, false) : new ClientSection(0, true);
                }
                level.AddChunk(new ClientChunk(cx, cz, sections, biomes));
            }
        }
        LocalPlayer player = client.StartOffline(level, PlayerId);
        player.Position = new Vec3d(0.5, 16, 0.5);
        return (client, player);
    }

    private static ClientBoundEntityEffectPacket Effect(IPotionEffectType type, int amplifier, int duration, Flags flags = Flags.ShowParticles | Flags.ShowIcon,
        int entity = PlayerId) => new() {
        EntityId = entity, Effect = type, Amplifier = amplifier, Duration = duration, EffectFlags = flags
    };

    private static void Tick(MinecraftClient client, int ticks) {
        for (int i = 0; i < ticks; i++) {
            client.Tick();
        }
    }

    [Test]
    public void TestThePacketAddsTheEffectWithItsFlags() {
        (MinecraftClient client, LocalPlayer player) = World();
        client.Dispatch(Effect(PotionEffectType.Speed, 1, 600, Flags.IsAmbient | Flags.ShowIcon));

        MobEffectInstance speed = player.GetEffect(PotionEffectType.Speed)!;
        Assert.Multiple(() => {
            Assert.That(player.HasEffect(PotionEffectType.Speed));
            Assert.That(speed.Amplifier, Is.EqualTo(1));
            Assert.That(speed.Duration, Is.EqualTo(600));
            Assert.That(speed.IsAmbient);
            Assert.That(speed.IsVisible, Is.False);
            Assert.That(speed.ShowIcon);
        });
    }

    [Test]
    public void TestASecondPacketReplacesTheEffectOutright() {
        // forceAddEffect does not merge: the server has already decided, so a weaker one sent later wins.
        (MinecraftClient client, LocalPlayer player) = World();
        client.Dispatch(Effect(PotionEffectType.Strength, 2, 100));
        client.Dispatch(Effect(PotionEffectType.Strength, 0, 2400));

        MobEffectInstance strength = player.GetEffect(PotionEffectType.Strength)!;
        Assert.That((strength.Amplifier, strength.Duration, strength.HiddenEffect), Is.EqualTo((0, 2400, (MobEffectInstance?)null)));
        Assert.That(player.ActiveEffects, Has.Count.EqualTo(1));
    }

    [Test]
    public void TestTheRemovePacketRemovesOnlyThatEffect() {
        (MinecraftClient client, LocalPlayer player) = World();
        client.Dispatch(Effect(PotionEffectType.Poison, 0, 240));
        client.Dispatch(Effect(PotionEffectType.NightVision, 0, -1));
        client.Dispatch(new ClientBoundRemoveEntityEffectPacket { EntityId = PlayerId, Effect = PotionEffectType.Poison });

        Assert.That(player.HasEffect(PotionEffectType.Poison), Is.False);
        Assert.That(player.HasEffect(PotionEffectType.NightVision));
    }

    [Test]
    public void TestDurationCountsDownEachTickAndStopsAtZero() {
        (MinecraftClient client, LocalPlayer player) = World();
        client.Dispatch(Effect(PotionEffectType.Speed, 0, 30));
        Tick(client, 20);
        Assert.That(player.GetEffect(PotionEffectType.Speed)!.Duration, Is.EqualTo(10));

        // The client never removes an effect itself; it waits at zero for the server's remove_mob_effect.
        Tick(client, 20);
        Assert.That(player.GetEffect(PotionEffectType.Speed)!.Duration, Is.EqualTo(0));
    }

    [Test]
    public void TestAnotherEntitysEffectCountsDownToo() {
        (MinecraftClient client, _) = World();
        ClientEntity zombie = new() { Id = ZombieId, Type = EntityType.Zombie, Position = new Vec3d(4.5, 16, 4.5), OldPosition = new Vec3d(4.5, 16, 4.5) };
        client.Entities[ZombieId] = zombie;
        client.Dispatch(Effect(PotionEffectType.Slowness, 0, 100, entity: ZombieId));
        Tick(client, 5);

        Assert.That(zombie.GetEffect(PotionEffectType.Slowness)!.Duration, Is.EqualTo(95));
    }

    [Test]
    public void TestAnInfiniteEffectNeverCountsDown() {
        (MinecraftClient client, LocalPlayer player) = World();
        client.Dispatch(Effect(PotionEffectType.NightVision, 0, MobEffectInstance.InfiniteDuration));
        Tick(client, 50);

        MobEffectInstance nightVision = player.GetEffect(PotionEffectType.NightVision)!;
        Assert.Multiple(() => {
            Assert.That(nightVision.IsInfiniteDuration);
            Assert.That(nightVision.EndsWithin(200), Is.False);
            Assert.That(MobEffectUtil.FormatDuration(nightVision, 1.0F, 20.0F), Is.EqualTo("**:**"));
        });
    }

    [Test]
    public void TestAStrongerShorterEffectHidesTheWeakerOneUntilItRunsOut() {
        ClientEntity entity = new() { Id = ZombieId, Type = EntityType.Zombie };
        entity.AddEffect(new MobEffectInstance(PotionEffectType.Speed, 400));
        Assert.That(entity.AddEffect(new MobEffectInstance(PotionEffectType.Speed, 100, 2)), Is.True);

        MobEffectInstance speed = entity.GetEffect(PotionEffectType.Speed)!;
        Assert.That((speed.Amplifier, speed.Duration), Is.EqualTo((2, 100)));
        Assert.That(speed.HiddenEffect is { Amplifier: 0, Duration: 400 });

        for (int i = 0; i < 100; i++) {
            speed.TickClient();
        }
        Assert.That((speed.Amplifier, speed.Duration, speed.HiddenEffect), Is.EqualTo((0, 300, (MobEffectInstance?)null)));
    }

    [Test]
    public void TestAWeakerLongerEffectGoesIntoTheHiddenChain() {
        MobEffectInstance strong = new(PotionEffectType.Strength, 100, 2);
        Assert.That(strong.Update(new MobEffectInstance(PotionEffectType.Strength, 600, 1)), Is.False);
        Assert.That(strong.Update(new MobEffectInstance(PotionEffectType.Strength, 1200)), Is.False);

        // Each weaker one lands behind the last, so they surface strongest first.
        Assert.That(strong.HiddenEffect is { Amplifier: 1, Duration: 600, HiddenEffect: { Amplifier: 0, Duration: 1200 } });
        for (int i = 0; i < 100; i++) {
            strong.TickClient();
        }
        Assert.That((strong.Amplifier, strong.Duration), Is.EqualTo((1, 500)));
        for (int i = 0; i < 500; i++) {
            strong.TickClient();
        }
        Assert.That((strong.Amplifier, strong.Duration, strong.HiddenEffect), Is.EqualTo((0, 600, (MobEffectInstance?)null)));
    }

    [Test]
    public void TestTheHiddenChainComesAcrossFromACodec() {
        PotionEffect effect = new(PotionEffectType.Haste, 2, 60, false, true, true,
            new PotionEffect.HiddenEffect(0, 600, true, false, false));
        MobEffectInstance haste = MobEffectInstance.From(effect);
        Assert.That(haste.HiddenEffect is { Amplifier: 0, Duration: 600, IsAmbient: true, IsVisible: false, ShowIcon: false });

        for (int i = 0; i < 60; i++) {
            haste.TickClient();
        }
        Assert.That((haste.Amplifier, haste.Duration, haste.IsAmbient, haste.ShowIcon), Is.EqualTo((0, 540, true, false)));
    }

    [Test]
    public void TestDurationsFormatAsMinutesAndHoursAtTheTickRate() {
        Assert.Multiple(() => {
            Assert.That(MobEffectUtil.FormatDuration(new MobEffectInstance(PotionEffectType.Speed, 1239), 1.0F, 20.0F), Is.EqualTo("01:01"));
            Assert.That(MobEffectUtil.FormatDuration(new MobEffectInstance(PotionEffectType.Speed, 72100), 1.0F, 20.0F), Is.EqualTo("01:00:05"));
            Assert.That(MobEffectUtil.FormatDuration(new MobEffectInstance(PotionEffectType.Speed, 600), 1.0F, 10.0F), Is.EqualTo("01:00"));
            Assert.That(MobEffectUtil.FormatDuration(new MobEffectInstance(PotionEffectType.Speed, 19), 1.0F, 20.0F), Is.EqualTo("00:00"));
        });
    }

    [Test]
    public void TestEffectsSortShortestFirstWithAmbientLast() {
        MobEffectInstance infinite = new(PotionEffectType.NightVision, MobEffectInstance.InfiniteDuration);
        MobEffectInstance ambient = new(PotionEffectType.Haste, 50, ambient: true);
        MobEffectInstance shortOne = new(PotionEffectType.Speed, 100);
        MobEffectInstance longOne = new(PotionEffectType.Poison, 2000);
        // An equal duration falls back to the colour, and speed's is the lower.
        MobEffectInstance sameDuration = new(PotionEffectType.Slowness, 100);

        List<MobEffectInstance> sorted = new[] { ambient, longOne, infinite, sameDuration, shortOne }.Order().ToList();
        Assert.That(sorted, Is.EqualTo(new[] { shortOne, sameDuration, longOne, infinite, ambient }));
    }

    [Test]
    public void TestABlendedEffectFadesInAndAReplacementKeepsTheFade() {
        (MinecraftClient client, LocalPlayer player) = World();
        client.Dispatch(Effect(PotionEffectType.Darkness, 0, 200));
        Assert.That(player.GetEffectBlendFactor(PotionEffectType.Darkness, 1.0F), Is.EqualTo(1.0F));

        client.Dispatch(Effect(PotionEffectType.Nausea, 0, 400, Flags.ShowParticles | Flags.ShowIcon | Flags.Blend));
        Tick(client, 15);
        Assert.That(player.GetEffectBlendFactor(PotionEffectType.Nausea, 1.0F), Is.EqualTo(0.1F).Within(1e-5F));

        // forceAddEffect copies the old instance's fade over the one skipBlending just set.
        client.Dispatch(Effect(PotionEffectType.Nausea, 0, 400));
        Assert.That(player.GetEffectBlendFactor(PotionEffectType.Nausea, 1.0F), Is.EqualTo(0.1F).Within(1e-5F));
    }
}
