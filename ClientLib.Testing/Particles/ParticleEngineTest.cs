using ClientLib.Maths;
using ClientLib.Particles;
using ClientLib.Player;
using ClientLib.World;
using Minecraft;
using Minecraft.Data.Generated;
using Minecraft.Data.Particles;
using Minecraft.Data.Particles.Types;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;
using Particle = Minecraft.Data.Generated.Particle;

namespace ClientLib.Testing.Particles;

/// <summary>
/// What of the particle engine is not only seen: the level particles packet decoded as vanilla writes it, spread
/// as <c>handleParticleEvent</c> spreads it, the distance and Particles option checks, and the group limits.
/// </summary>
public class ParticleEngineTest {
    private const int Floor = 16;

    /// <summary>Stone below <see cref="Floor"/>, air above, the player standing on it at the origin.</summary>
    private static (MinecraftClient Client, ParticleEngine Engine) World(ParticleStatus status = ParticleStatus.All) {
        MinecraftClient client = new(new ClientOptions { Username = "Test", Particles = status });
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
        LocalPlayer player = client.StartOffline(level);
        player.Position = new Vec3d(0.5, Floor, 0.5);
        client.Particles.Enabled = true;
        client.Particles.CameraPosition = new Vec3d(0.5, Floor + 1.62, 0.5);
        return (client, client.Particles);
    }

    private static ClientBoundParticlePacket Packet(IParticle particle, Vec3<double> position, Vec3<float> offset, float speed, int count,
        bool longDistance = false, bool alwaysVisible = false) => new() {
        LongDistance = longDistance, AlwaysVisible = alwaysVisible, Position = position, Offset = offset, MaxSpeed = new Vec3<float>(speed, speed, speed), ParticleCount = count,
        Particle = particle
    };

    /// <summary>The particle's type, which <c>ClientboundLevelParticlesPacket.write</c> puts first, before its options.</summary>
    private static DataWriter Header(IParticle type) => new DataWriter()
        .WriteVarInt(VanillaRegistry.Data.Particles.GetProtocolId(type));

    /// <summary>Ends the packet after the options with the rest of its fields, then reads it.</summary>
    private static IParticle Decode(DataWriter writer) {
        writer.WriteBoolean(false).WriteBoolean(false)
            .WriteDouble(1.0).WriteDouble(2.0).WriteDouble(3.0)
            .WriteFloat(0.0F).WriteFloat(0.0F).WriteFloat(0.0F)
            .WriteFloat(0.0F).WriteFloat(0.0F).WriteFloat(0.0F)
            .WriteVarInt(0).WriteVarInt(0);
        DataReader reader = new(writer.ToArray());
        ClientBoundParticlePacket packet = (ClientBoundParticlePacket)ClientBoundParticlePacket.Deserialiser(reader, VanillaRegistry.Data);
        Assert.That(reader.HasRemaining, Is.False, "the particle's options were not read to the end");
        return packet.Particle;
    }

    [Test]
    public void DustColourArrivesWithAnAlphaAboveIt() {
        // DustParticleOptions writes ARGB.colorFromFloat(1, r, g, b): opaque red.
        IParticle particle = Decode(Header(Particle.Dust).WriteInteger(unchecked((int)0xFFFF0000)).WriteFloat(2.0F));
        DustParticle dust = (DustParticle)particle;
        Assert.That(dust.Color.ToDecimal(), Is.EqualTo(0xFF0000));
        Assert.That(dust.Scale, Is.EqualTo(2.0F));
    }

    [Test]
    public void SpellOptionsAreAColourAndAPower() {
        SpellParticle spell = (SpellParticle)Decode(Header(Particle.Effect).WriteInteger(0x00FF00).WriteFloat(0.5F));
        Assert.That((spell.Rgb, spell.Power), Is.EqualTo((0x00FF00, 0.5F)));
        Assert.That(Decode(Header(Particle.InstantEffect).WriteInteger(-1).WriteFloat(1.0F)), Is.TypeOf<SpellParticle>());
    }

    [Test]
    public void FlashIsAnArgbColour() {
        ColorParticle flash = (ColorParticle)Decode(Header(Particle.Flash).WriteInteger(unchecked((int)0x80123456)));
        Assert.That(flash.Argb, Is.EqualTo(unchecked((int)0x80123456)));
    }

    [Test]
    public void ItemOptionsAreATemplateWithTheItemBeforeTheCount() {
        // ItemStackTemplate.STREAM_CODEC: item, count, then the component patch (none added, none removed).
        DataWriter writer = Header(Particle.Item).WriteVarInt(VanillaRegistry.Data.Items.GetProtocolId(Item.Diamond)).WriteVarInt(3).WriteVarInt(0).WriteVarInt(0);
        ItemParticle item = (ItemParticle)Decode(writer);
        Assert.That(item.Item!.Type.Identifier, Is.EqualTo(Item.Diamond.Identifier));
        Assert.That(item.Item.Count, Is.EqualTo(3));
    }

    [Test]
    public void EveryParticleTypeHasAProvider() {
        List<Identifier> missing = VanillaRegistry.Data.Particles.All.Where(type => !ParticleEngine.HasProvider(type)).Select(type => type.Identifier).ToList();
        Assert.That(missing, Is.Empty);
    }

    [Test]
    public void EveryParticleTypeCanBeMadeAndTicked() {
        (MinecraftClient client, ParticleEngine engine) = World();
        foreach (IParticle type in VanillaRegistry.Data.Particles.All) {
            IParticle options = type switch {
                BlockParticle block => block with { BlockState = Block.Stone },
                BlockMarkerParticle marker => marker with { BlockState = (int)Block.Stone.StateId },
                BlockCrumbleParticle crumble => crumble with { BlockState = (int)Block.Stone.StateId },
                DustPillarParticle pillar => pillar with { BlockState = (int)Block.Stone.StateId },
                FallingDustParticle dust => dust with { BlockState = (int)Block.Sand.StateId },
                ItemParticle item => item with { Item = new Minecraft.Schemas.Items.ItemStack(Item.Diamond) },
                VibrationParticle vibration => vibration with { PositionSource = new VibrationParticle.BlockPositionSource(new Vec3<int>(3, Floor, 3)), Ticks = 10 },
                TrailParticle trail => trail with { Target = new Vec3<double>(3, Floor + 2, 3), Duration = 10 },
                _ => type
            };
            engine.CreateParticle(options, 0.5, Floor + 1.0, 2.5, 0.0, 0.05, 0.0);
        }
        // Every type makes one, bar the elder guardian's and the emitters' none drawn as quads.
        Assert.That(engine.Pending.ToArray().Count(p => p.Visible), Is.GreaterThan(110));
        Assert.DoesNotThrow(() => {
            for (int i = 0; i < 40; i++) {
                client.Tick();
            }
        });
    }

    [Test]
    public void CountZeroThrowsOneParticleAlongTheOffset() {
        (_, ParticleEngine engine) = World();
        engine.HandlePacket(Packet(Particle.BubblePop, new Vec3<double>(1.25, Floor + 1.5, 2.75), new Vec3<float>(0.5F, 1.0F, -2.0F), 0.25F, 0));
        Assert.That(engine.Pending.Length, Is.EqualTo(1));
        ParticleState p = engine.Pending[0];
        // BubblePopParticle keeps the position and motion it is given.
        Assert.That((p.X, p.Y, p.Z), Is.EqualTo((1.25, Floor + 1.5, 2.75)));
        Assert.That((p.Xd, p.Yd, p.Zd), Is.EqualTo((0.125, 0.25, -0.5)));
    }

    [Test]
    public void CountSpreadsAGaussianCloudAndSpeed() {
        (_, ParticleEngine engine) = World();
        const int count = 4000;
        engine.HandlePacket(Packet(Particle.BubblePop, new Vec3<double>(0.5, Floor + 4.0, 0.5), new Vec3<float>(1.0F, 0.5F, 0.0F), 0.0F, count));
        Assert.That(engine.Pending.Length, Is.EqualTo(count));
        double meanX = 0, meanY = 0, varianceX = 0, varianceY = 0;
        foreach (ParticleState p in engine.Pending) {
            meanX += p.X;
            meanY += p.Y;
            Assert.That(p.Z, Is.EqualTo(0.5));
            Assert.That((p.Xd, p.Yd, p.Zd), Is.EqualTo((0.0, 0.0, 0.0)));
        }
        meanX /= count;
        meanY /= count;
        foreach (ParticleState p in engine.Pending) {
            varianceX += (p.X - meanX) * (p.X - meanX);
            varianceY += (p.Y - meanY) * (p.Y - meanY);
        }
        // Standard deviations of 1 and 0.5 about the position; 4000 samples put these well inside 10%.
        Assert.That(meanX, Is.EqualTo(0.5).Within(0.1));
        Assert.That(meanY, Is.EqualTo(Floor + 4.0).Within(0.05));
        Assert.That(Math.Sqrt(varianceX / count), Is.EqualTo(1.0).Within(0.1));
        Assert.That(Math.Sqrt(varianceY / count), Is.EqualTo(0.5).Within(0.05));
    }

    [Test]
    public void FarParticlesNeedTheLongDistanceFlag() {
        (_, ParticleEngine engine) = World();
        Vec3<double> far = new(0.5, Floor + 1.62, 33.0);
        engine.HandlePacket(Packet(Particle.BubblePop, far, default, 0.0F, 0));
        Assert.That(engine.Pending.Length, Is.Zero, "past 32 blocks");
        engine.HandlePacket(Packet(Particle.BubblePop, new Vec3<double>(0.5, Floor + 1.62, 32.0), default, 0.0F, 0));
        Assert.That(engine.Pending.Length, Is.EqualTo(1), "at 31.5 blocks");
        engine.HandlePacket(Packet(Particle.BubblePop, far, default, 0.0F, 0, longDistance: true));
        Assert.That(engine.Pending.Length, Is.EqualTo(2), "overriding the limiter");
        engine.HandlePacket(Packet(Particle.Explosion, far, default, 0.0F, 0));
        Assert.That(engine.Pending.Length, Is.EqualTo(3), "a type that always overrides it");
    }

    [Test]
    public void MinimalShowsOnlyAlwaysVisibleOnesOneInTen() {
        (_, ParticleEngine engine) = World(ParticleStatus.Minimal);
        Vec3<double> here = new(0.5, Floor + 2.0, 2.5);
        engine.HandlePacket(Packet(Particle.BubblePop, here, default, 0.0F, 1000));
        Assert.That(engine.Pending.Length, Is.Zero);
        engine.HandlePacket(Packet(Particle.BubblePop, here, default, 0.0F, 3000, alwaysVisible: true));
        // Lifted to Decreased one time in ten, which keeps two thirds of those.
        Assert.That(engine.Pending.Length, Is.EqualTo(200).Within(60));
        int before = engine.Pending.Length;
        engine.HandlePacket(Packet(Particle.BubblePop, here, default, 0.0F, 0, longDistance: true));
        Assert.That(engine.Pending.Length, Is.EqualTo(before + 1), "overriding the limiter ignores the option too");
    }

    [Test]
    public void DecreasedDropsAThird() {
        (_, ParticleEngine engine) = World(ParticleStatus.Decreased);
        engine.HandlePacket(Packet(Particle.BubblePop, new Vec3<double>(0.5, Floor + 2.0, 2.5), default, 0.0F, 3000));
        Assert.That(engine.Pending.Length, Is.EqualTo(2000).Within(150));
    }

    [Test]
    public void TheGroupFillsToItsLimitThroughTheReservoir() {
        (MinecraftClient client, ParticleEngine engine) = World();
        for (int i = 0; i < 20000; i++) {
            // Mycelium lives 20 ticks or more, so none dies in the one tick the group fills.
            engine.CreateParticle(Particle.Mycelium, 0.5, Floor + 2.0, 0.5, 0, 0, 0);
        }
        client.Tick();
        int joined = engine.Counts.Quads;
        // Every one up to the reservoir joins, then ever fewer: the expected total from 7712 more is about 15400.
        Assert.That(joined, Is.GreaterThan(ParticleEngine.MaxParticles - 4096));
        Assert.That(joined, Is.LessThanOrEqualTo(ParticleEngine.MaxParticles));
    }

    [Test]
    public void SporeBlossomAirStopsAtItsLimit() {
        (MinecraftClient client, ParticleEngine engine) = World();
        for (int i = 0; i < 1500; i++) {
            engine.CreateParticle(Particle.SporeBlossomAir, 0.5, Floor + 4.0, 0.5, 0, 0, 0);
        }
        Assert.That(engine.Pending.Length, Is.EqualTo(ParticleEngine.SporeBlossomLimit));
        client.Tick();
        Assert.That(engine.Counts.Quads, Is.EqualTo(ParticleEngine.SporeBlossomLimit));
    }

    [Test]
    public void AFallingFragmentComesToRestOnTheFloor() {
        (MinecraftClient client, ParticleEngine engine) = World();
        client.Level!.SetState(0, Floor - 1, 3, 0);
        engine.Destroy(0, Floor - 1, 3, Block.Stone.StateId);
        Assert.That(engine.Pending.Length, Is.EqualTo(64), "four by four by four");
        for (int i = 0; i < 10; i++) {
            client.Tick();
        }
        foreach (ParticleState p in engine.Particles) {
            Assert.That(p.Y, Is.GreaterThanOrEqualTo(Floor - 1.0), "nothing falls through the block below");
        }
        // Fragments come to rest on the floor round the hole or the stone at its bottom.
        Assert.That(engine.Particles.ToArray().Count(p => p.OnGround && (p.Y == Floor || p.Y == Floor - 1)), Is.GreaterThan(0));
    }

    [Test]
    public void ATrackingEmitterThrowsParticlesFromTheEntityForThreeTicks() {
        (MinecraftClient client, ParticleEngine engine) = World();
        LocalPlayer player = client.Player!;
        client.Entities[player.Id] = player;
        engine.CreateTrackingEmitter(player, Particle.Crit);
        // The constructor's own tick: most of 16 tries land inside the unit sphere.
        int first = engine.Pending.ToArray().Count(p => p.Visible);
        Assert.That(first, Is.InRange(4, 16));
        client.Tick();
        client.Tick();
        client.Tick();
        Assert.That(engine.Counts.NoRender, Is.Zero, "gone after its three ticks");
        Assert.That(engine.Counts.Quads, Is.GreaterThan(first));
    }
}
