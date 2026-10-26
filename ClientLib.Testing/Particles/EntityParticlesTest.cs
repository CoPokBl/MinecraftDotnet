using ClientLib.Entities;
using ClientLib.Maths;
using ClientLib.Particles;
using ClientLib.World;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Entities;
using Minecraft.Data.Generated;
using Minecraft.Data.Particles;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Entities.Meta;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using EntityEvent = Minecraft.Packets.Play.ClientBound.ClientBoundEntityEventPacket.EntityEventType;
using Particle = Minecraft.Data.Generated.Particle;

namespace ClientLib.Testing.Particles;

/// <summary>Which entities make which particles on the client, and how often.</summary>
public class EntityParticlesTest {
    private const int Floor = 16;
    private int _nextId = 100;

    /// <summary>Stone below <see cref="Floor"/>, air above, the player standing on it at the origin.</summary>
    private static (MinecraftClient Client, ParticleEngine Engine) World() {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        ClientLevel level = new(VanillaRegistry.Data, "minecraft:overworld", VanillaRegistry.Data.DimensionTypes["minecraft:overworld"], 63, true, 0);
        for (int cx = -2; cx <= 2; cx++) {
            for (int cz = -2; cz <= 2; cz++) {
                ClientSection[] sections = new ClientSection[level.SectionCount];
                ushort[][] biomes = new ushort[level.SectionCount][];
                for (int i = 0; i < sections.Length; i++) {
                    int baseY = level.MinY + i * 16;
                    biomes[i] = new ushort[64];
                    uint[] states = new uint[ClientSection.Volume];
                    for (int y = 0; y < 16; y++) {
                        if (baseY + y < Floor) {
                            Array.Fill(states, Block.Stone.StateId, y << 8, 256);
                        }
                    }
                    sections[i] = new ClientSection(states, level.IsAir);
                }
                level.AddChunk(new ClientChunk(cx, cz, sections, biomes));
            }
        }
        client.StartOffline(level).Position = new Vec3d(0.5, Floor, 0.5);
        client.Particles.Enabled = true;
        client.Particles.CameraPosition = new Vec3d(0.5, Floor + 1.62, 0.5);
        // The engine takes the level on its first tick.
        client.Tick();
        return (client, client.Particles);
    }

    private ClientEntity Spawn(MinecraftClient client, IEntityType type, double x, double y, double z) {
        int id = _nextId++;
        Guid uuid = Guid.NewGuid();
        // A player is refused without its player info.
        client.PlayerList[uuid] = new PlayerListEntry(uuid, "Other");
        client.HandleSpawn(new ClientBoundSpawnEntityPacket {
            Id = id,
            Uuid = uuid,
            EntityType = type,
            Position = new Vec3<double>(x, y, z),
            Pitch = Angle.FromDegrees(0),
            Yaw = Angle.FromDegrees(0),
            HeadYaw = Angle.FromDegrees(0),
            Data = 0,
            Velocity = new Vec3<double>(0, 0, 0)
        });
        return client.Entities[id];
    }

    private static void Set<T>(ClientEntity entity, EntityDataField<T> field, MetaFieldType type, T value) =>
        entity.Metadata[field.Index] = new MetaField<T>(type, value);

    /// <summary>The entity pass alone, so what it makes waits in the queue to be counted.</summary>
    private static void TickEntities(MinecraftClient client, int ticks = 1) {
        for (int i = 0; i < ticks; i++) {
            client.Particles.Entities.Tick(client.Level!);
        }
    }

    private static int Count(ParticleEngine engine, IParticle type) => engine.Pending.ToArray().Count(p => p.Type == ParticleEngine.TypeId(type));

    private static void Event(MinecraftClient client, ClientEntity entity, int id) =>
        client.Dispatch(new ClientBoundEntityEventPacket { EntityId = entity.Id, Status = (EntityEvent)id });

    [Test]
    public void MobsWithAClientTickOfTheirOwnMakeItsParticles() {
        (MinecraftClient client, ParticleEngine engine) = World();
        Spawn(client, EntityType.Blaze, 2.5, Floor, 3.5);
        TickEntities(client);
        Assert.That(Count(engine, Particle.LargeSmoke), Is.EqualTo(2), "a blaze smokes twice a tick");
        Spawn(client, EntityType.GlowSquid, -2.5, Floor, 3.5);
        Spawn(client, EntityType.Endermite, 0.5, Floor, 4.5);
        TickEntities(client);
        Assert.That(Count(engine, Particle.Glow), Is.EqualTo(1));
        Assert.That(Count(engine, Particle.Portal), Is.EqualTo(2));
    }

    [Test]
    public void ADisplayMakesNothing() {
        (MinecraftClient client, ParticleEngine engine) = World();
        ClientEntity display = Spawn(client, EntityType.ItemDisplay, 2.5, Floor, 2.5);
        Set(display, EntityDataFields.Entity.SharedFlags, MetaFieldType.Byte, (sbyte)0x08);
        TickEntities(client, 20);
        Assert.That(engine.Pending.Length, Is.Zero);
    }

    [Test]
    public void FallingIntoWaterSplashesOnce() {
        (MinecraftClient client, ParticleEngine engine) = World();
        client.Level!.SetState(3, Floor, 3, (ushort)Block.Water.StateId);
        ClientEntity zombie = Spawn(client, EntityType.Zombie, 3.5, Floor + 2.0, 3.5);
        TickEntities(client);
        Assert.That(engine.Pending.Length, Is.Zero, "dry");
        zombie.Snap(new Vec3d(3.5, Floor + 0.5, 3.5), 0.0F, 0.0F);
        TickEntities(client);
        // 1 + width * 20 of each, the zombie being 0.6 wide.
        Assert.That(Count(engine, Particle.Bubble), Is.EqualTo(13));
        Assert.That(Count(engine, Particle.Splash), Is.EqualTo(13));
        int splashed = engine.Pending.Length;
        zombie.Snap(new Vec3d(3.6, Floor + 0.4, 3.5), 0.0F, 0.0F);
        TickEntities(client);
        Assert.That(engine.Pending.Length, Is.EqualTo(splashed), "still in, no new splash");
    }

    [Test]
    public void AnEntityFirstSeenInWaterDoesNotSplash() {
        (MinecraftClient client, ParticleEngine engine) = World();
        client.Level!.SetState(3, Floor, 3, (ushort)Block.Water.StateId);
        Spawn(client, EntityType.Zombie, 3.5, Floor + 0.2, 3.5);
        TickEntities(client, 3);
        Assert.That(engine.Pending.Length, Is.Zero);
    }

    [Test]
    public void SprintingKicksUpTheBlockUnderfoot() {
        (MinecraftClient client, ParticleEngine engine) = World();
        ClientEntity runner = Spawn(client, EntityType.Player, 2.5, Floor, 2.5);
        Set(runner, EntityDataFields.Entity.SharedFlags, MetaFieldType.Byte, (sbyte)0x08);
        TickEntities(client, 10);
        Assert.That(Count(engine, Particle.Block), Is.EqualTo(10));
        Set(runner, EntityDataFields.Entity.SharedFlags, MetaFieldType.Byte, (sbyte)(0x08 | 0x02));
        TickEntities(client, 10);
        Assert.That(Count(engine, Particle.Block), Is.EqualTo(10), "not while crouching");
    }

    [Test]
    public void EffectParticlesComeOneTickInFourAndRarerWhenAmbientOrInvisible() {
        (MinecraftClient client, ParticleEngine engine) = World();
        ClientEntity pig = Spawn(client, EntityType.Cow, 2.5, Floor, 2.5);
        Set<IParticle[]>(pig, EntityDataFields.LivingEntity.EffectParticles, MetaFieldType.Particles, [Particle.EntityEffect with { Argb = unchecked((int)0xFFFF0000) }]);
        TickEntities(client, 2000);
        Assert.That(Count(engine, Particle.EntityEffect), Is.EqualTo(500).Within(80));
        engine.Clear();
        client.Tick();
        Set(pig, EntityDataFields.LivingEntity.EffectAmbience, MetaFieldType.Boolean, true);
        Set(pig, EntityDataFields.Entity.SharedFlags, MetaFieldType.Byte, (sbyte)0x20);
        TickEntities(client, 3000);
        // One in fifteen for invisible, five times rarer again for ambient.
        Assert.That(Count(engine, Particle.EntityEffect), Is.EqualTo(40).Within(25));
    }

    [Test]
    public void AnotherPlayerEatingDropsCrumbsEveryFourTicksAfterAWait() {
        (MinecraftClient client, ParticleEngine engine) = World();
        ClientEntity eater = Spawn(client, EntityType.Player, 2.5, Floor, 2.5);
        eater.Equipment[EquipmentSlot.MainHand] = new ItemStack(Item.Bread);
        Set(eater, EntityDataFields.LivingEntity.LivingEntityFlags, MetaFieldType.Byte, (sbyte)1);
        // Bread takes 32 ticks; the crumbs come with 24, 20, 16, 12, 8 and 4 left.
        TickEntities(client, 32);
        Assert.That(Count(engine, Particle.Item), Is.EqualTo(30));
    }

    [Test]
    public void EntityEventsMakeTheirClassesParticles() {
        (MinecraftClient client, ParticleEngine engine) = World();
        ClientEntity villager = Spawn(client, EntityType.Villager, 2.5, Floor, 2.5);
        Event(client, villager, 13);
        Assert.That(Count(engine, Particle.AngryVillager), Is.EqualTo(5));

        ClientEntity cow = Spawn(client, EntityType.Cow, -2.5, Floor, 2.5);
        Event(client, cow, 18);
        Assert.That(Count(engine, Particle.Heart), Is.EqualTo(7), "an animal in love");

        ClientEntity wolf = Spawn(client, EntityType.Wolf, 2.5, Floor, -2.5);
        Event(client, wolf, 6);
        Assert.That(Count(engine, Particle.Smoke), Is.EqualTo(7), "a failed taming, through TamableAnimal");

        ClientEntity zombie = Spawn(client, EntityType.Zombie, -2.5, Floor, -2.5);
        int before = engine.Pending.Length;
        Event(client, zombie, 18);
        Assert.That(engine.Pending.Length, Is.EqualTo(before), "a zombie is not an animal");
        Event(client, zombie, 60);
        Assert.That(Count(engine, Particle.Poof), Is.EqualTo(20), "the death poof");

        ClientEntity snowball = Spawn(client, EntityType.Snowball, 0.5, Floor + 1.0, 2.5);
        Set(snowball, EntityDataFields.ThrowableItemProjectile.ItemStack, MetaFieldType.Slot, new ItemStack(Item.Snowball));
        Event(client, snowball, 3);
        Assert.That(Count(engine, Particle.Item), Is.EqualTo(8), "a snowball breaking");

        ClientEntity arrow = Spawn(client, EntityType.Arrow, 0.5, Floor + 1.0, 3.5);
        before = engine.Pending.Length;
        Event(client, arrow, 60);
        Assert.That(engine.Pending.Length, Is.EqualTo(before), "nothing living, nothing to poof");
    }

    [Test]
    public void ARocketBurstsAShellOfSparksAndAFlash() {
        (MinecraftClient client, ParticleEngine engine) = World();
        ClientEntity rocket = Spawn(client, EntityType.FireworkRocket, 0.5, Floor + 6.0, 4.5);
        FireworksComponent.Data fireworks = new(1, [new FireworkExplosionComponent.Data(FireworkShape.SmallBall, [0xFF0000])]);
        Set(rocket, EntityDataFields.FireworkRocketEntity.IdFireworksItem, MetaFieldType.Slot,
            new ItemStack(Item.FireworkRocket).With(DataComponent.Fireworks, fireworks));
        Event(client, rocket, 17);
        client.Discard(rocket);
        TickEntities(client);
        // The two-step ball's shell: every row on the outer layers, and the two ends of the rows inside.
        Assert.That(Count(engine, Particle.Firework), Is.EqualTo(16 * 5 + 9 * 2));
        Assert.That(Count(engine, Particle.Flash), Is.EqualTo(1));
    }

    [Test]
    public void ARocketWithNoExplosionsOnlyPoofs() {
        (MinecraftClient client, ParticleEngine engine) = World();
        ClientEntity rocket = Spawn(client, EntityType.FireworkRocket, 0.5, Floor + 6.0, 4.5);
        Event(client, rocket, 17);
        Assert.That(Count(engine, Particle.Poof), Is.InRange(2, 4));
        Assert.That(Count(engine, Particle.Firework), Is.Zero);
    }
}
