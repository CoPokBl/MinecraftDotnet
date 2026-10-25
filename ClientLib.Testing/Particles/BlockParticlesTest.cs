using ClientLib.Maths;
using ClientLib.Particles;
using ClientLib.Player;
using ClientLib.World;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Data.Particles;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;
using Particle = Minecraft.Data.Generated.Particle;

namespace ClientLib.Testing.Particles;

/// <summary>
/// Which blocks' <c>animateTick</c> make which particles, the note block's note, an explosion's block particles, and
/// the engine ticking on its own thread giving what it gives ticked in place.
/// </summary>
public class BlockParticlesTest {
    private const int Floor = 16;

    /// <summary>Stone below <see cref="Floor"/>, air above, the player standing on it at the origin.</summary>
    private static (MinecraftClient Client, ClientLevel Level, ParticleEngine Engine) World(ParticleStatus status = ParticleStatus.All) {
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
        return (client, level, client.Particles);
    }

    private static int Id(IParticle type) => VanillaRegistry.Data.Particles.GetProtocolId(type);

    /// <summary>The types of the particles made since the last tick, by how many of each.</summary>
    private static Dictionary<int, int> Made(ParticleEngine engine) =>
        engine.Pending.ToArray().GroupBy(p => p.Type).ToDictionary(group => group.Key, group => group.Count());

    private static Dictionary<int, int> Animate(MinecraftClient client, int x, int y, int z, int times = 1) {
        for (int i = 0; i < times; i++) {
            client.AnimateTicks.AnimateAt(x, y, z);
        }
        return Made(client.Particles);
    }

    [TestCaseSource(nameof(Torches))]
    public void TorchesSmokeAndBurnTheirOwnFlame(IBlock torch, IParticle flame) {
        (MinecraftClient client, ClientLevel level, _) = World();
        level.SetState(0, Floor, 3, (ushort)torch.StateId);
        Dictionary<int, int> made = Animate(client, 0, Floor, 3);
        Assert.That(made, Is.EquivalentTo(new Dictionary<int, int> { [Id(Particle.Smoke)] = 1, [Id(flame)] = 1 }));
    }

    private static IEnumerable<object[]> Torches() => [
        [Block.Torch, Particle.Flame],
        [Block.SoulTorch, Particle.SoulFireFlame],
        [Block.CopperTorch, Particle.CopperFireFlame],
        [Block.WallTorch, Particle.Flame],
        [Block.SoulWallTorch, Particle.SoulFireFlame],
        [Block.CopperWallTorch, Particle.CopperFireFlame]
    ];

    [Test]
    public void AWallTorchFlamesOutFromTheWall() {
        (MinecraftClient client, ClientLevel level, ParticleEngine engine) = World();
        // Facing north, the flame is put 0.27 to the south and 0.22 up; a rising particle then wanders 0.05 either way.
        level.SetState(0, Floor, 3, (ushort)Block.WallTorch.StateId);
        Animate(client, 0, Floor, 3);
        ParticleState flame = engine.Pending.ToArray().Single(p => p.Type == Id(Particle.Flame));
        Assert.That(flame.X, Is.EqualTo(0.5).Within(0.05));
        Assert.That(flame.Z, Is.EqualTo(3.5 + 0.27).Within(0.05));
        Assert.That(flame.Y, Is.EqualTo(Floor + 0.92).Within(0.05));
    }

    [Test]
    public void AFurnaceOnlySmokesWhileLit() {
        (MinecraftClient client, ClientLevel level, _) = World();
        level.SetState(0, Floor, 3, (ushort)Block.Furnace.StateId);
        Assert.That(Animate(client, 0, Floor, 3), Is.Empty);
        level.SetState(0, Floor, 3, (ushort)Block.Furnace.WithLit(true).StateId);
        Assert.That(Animate(client, 0, Floor, 3), Is.EquivalentTo(new Dictionary<int, int> { [Id(Particle.Smoke)] = 1, [Id(Particle.Flame)] = 1 }));
    }

    [Test]
    public void ARedstoneTorchOnlyGivesDustWhileLit() {
        (MinecraftClient client, ClientLevel level, _) = World();
        level.SetState(0, Floor, 3, (ushort)Block.RedstoneTorch.WithLit(false).StateId);
        Assert.That(Animate(client, 0, Floor, 3), Is.Empty);
        level.SetState(0, Floor, 3, (ushort)Block.RedstoneTorch.StateId);
        Assert.That(Animate(client, 0, Floor, 3).Keys, Is.EquivalentTo(new[] { Id(Particle.Dust) }));
    }

    [TestCaseSource(nameof(Leaves))]
    public void LeavesDropTheirOwnLeafAtTheirOwnRate(IBlock leaves, IParticle leaf, float chance) {
        (MinecraftClient client, ClientLevel level, _) = World();
        level.SetState(0, Floor + 3, 3, (ushort)leaves.StateId);
        const int Tries = 20000;
        Dictionary<int, int> made = Animate(client, 0, Floor + 3, 3, Tries);
        Assert.That(made.Keys, Is.EquivalentTo(new[] { Id(leaf) }));
        Assert.That(made[Id(leaf)], Is.EqualTo(Tries * chance).Within(Tries * chance * 0.25));
    }

    private static IEnumerable<object[]> Leaves() => [
        [Block.OakLeaves, Particle.TintedLeaves, 0.01F],
        [Block.CherryLeaves, Particle.CherryLeaves, 0.1F],
        [Block.PaleOakLeaves, Particle.PaleOakLeaves, 0.02F],
        [Block.AzaleaLeaves, Particle.TintedLeaves, 0.01F]
    ];

    [Test]
    public void LeavesOnAFullBlockDropNothing() {
        (MinecraftClient client, ClientLevel level, _) = World();
        level.SetState(0, Floor, 3, (ushort)Block.CherryLeaves.StateId);
        Assert.That(Animate(client, 0, Floor, 3, 2000), Is.Empty);
    }

    [Test]
    public void WaterSeepsThroughTheBlockUnderIt() {
        (MinecraftClient client, ClientLevel level, ParticleEngine engine) = World();
        level.SetState(0, Floor + 4, 3, (ushort)Block.Water.StateId);
        level.SetState(0, Floor + 3, 3, (ushort)Block.Stone.StateId);
        Dictionary<int, int> made = Animate(client, 0, Floor + 4, 3, 2000);
        Assert.That(made.GetValueOrDefault(Id(Particle.DrippingWater)), Is.GreaterThan(0));
        foreach (ParticleState drip in engine.Pending.ToArray().Where(p => p.Type == Id(Particle.DrippingWater))) {
            Assert.That(drip.Y, Is.EqualTo(Floor + 3 - 0.05).Within(1.0E-9), "under the stone");
        }
    }

    [Test]
    public void ANoteBlockEventShowsTheNoteItPlays() {
        (MinecraftClient client, ClientLevel level, ParticleEngine engine) = World();
        IBlock noteBlock = new Minecraft.Data.Generated.BlockTypes.NoteBlockBlock("minecraft:note_block", NoteBlockInstrument.Harp, 12, false);
        level.SetState(0, Floor, 3, (ushort)noteBlock.StateId);
        client.Dispatch(new ClientBoundBlockActionPacket { Location = new Vec3<int>(0, Floor, 3), ActionId = 0, ActionParameter = 0, Block = noteBlock });
        ParticleState note = engine.Pending.ToArray().Single();
        Assert.That(note.Type, Is.EqualTo(Id(Particle.Note)));
        Assert.That((note.X, note.Y, note.Z), Is.EqualTo((0.5, Floor + 1.2, 3.5)).Within(1.0E-9));
    }

    [Test]
    public void ASpawnerWithAMobSmokesAndFlamesWhileAPlayerIsNear() {
        (MinecraftClient client, ClientLevel level, ParticleEngine engine) = World();
        level.SetState(0, Floor, 3, (ushort)Block.Spawner.StateId);
        ClientBlockEntityTestHelper.Place(level, 0, Floor, 3, new NBT.Tags.CompoundTag(
            ("SpawnData", new NBT.Tags.CompoundTag(("entity", new NBT.Tags.CompoundTag(("id", new NBT.Tags.StringTag("minecraft:pig"))))))));
        client.Tick();
        Assert.That(engine.Particles.ToArray().Count(p => p.Type == Id(Particle.Flame)), Is.EqualTo(1));
    }

    [Test]
    public void ABellRungNearARaiderMarksItsWayOnceTheResonanceEnds() {
        (MinecraftClient client, ClientLevel level, ParticleEngine engine) = World();
        client.Tags["minecraft:entity_type"] = new Dictionary<Identifier, int[]> {
            ["minecraft:raiders"] = [VanillaRegistry.Data.EntityTypes.GetProtocolId(EntityType.Pillager)]
        };
        Entities.ClientEntity raider = new() { Id = 7, Type = EntityType.Pillager, Position = new Vec3d(0.5, Floor, 12.5) };
        client.Entities[raider.Id] = raider;
        level.SetState(0, Floor, 3, (ushort)Block.Bell.StateId);
        ClientBlockEntityTestHelper.Place(level, 0, Floor, 3, new NBT.Tags.CompoundTag());
        level.BlockEvent(0, Floor, 3, 1, 2);
        int first = -1;
        for (int tick = 1; tick <= 60 && first < 0; tick++) {
            client.Tick();
            if (engine.Particles.ToArray().Any(p => p.Type == Id(Particle.EntityEffect))) {
                first = tick;
            }
        }
        // Resonating from the fifth tick of the swing, for forty ticks.
        Assert.That(first, Is.InRange(44, 47));
        ParticleState[] marks = engine.Particles.ToArray().Where(p => p.Type == Id(Particle.EntityEffect)).ToArray();
        Assert.That(marks, Has.Length.InRange(3, 15));
        Assert.That(marks.All(p => p.A > 0.0F), "drawn opaque");
        Assert.That(marks[0].Z, Is.EqualTo(4.5).Within(0.5), "a block from the bell toward the raider");
    }

    [Test]
    public void AnExplosionThrowsAtMostFiveHundredAndTwelveBlockParticlesATickAndOnlyOnAll() {
        foreach (ParticleStatus status in new[] { ParticleStatus.All, ParticleStatus.Decreased }) {
            (_, _, ParticleEngine engine) = World(status);
            engine.HandleExplosion(new ClientBoundExplosionPacket {
                Center = new Vec3<double>(0.5, Floor + 4.5, 3.5), Radius = 4.0F, BlockCount = 2000, ExplosionParticle = Particle.ExplosionEmitter,
                BlockParticles = [new ClientBoundExplosionPacket.BlockParticle(Particle.Poof, 0.5F, 1.0F, 1)]
            });
            int before = engine.Pending.Length;
            engine.TickExplosions();
            int poofs = engine.Pending.ToArray().Skip(before).Count(p => p.Type == Id(Particle.Poof));
            if (status == ParticleStatus.All) {
                // Points in the stone below the floor are skipped, so somewhat fewer than the cap.
                Assert.That(poofs, Is.InRange(200, 512));
            }
            else {
                Assert.That(poofs, Is.Zero);
            }
        }
    }

    [Test]
    public void TickingOnTheWorkerGivesWhatTickingInPlaceGives() {
        (MinecraftClient syncClient, _, ParticleEngine sync) = World();
        (MinecraftClient asyncClient, _, ParticleEngine async) = World();
        async.Asynchronous = true;
        foreach (ParticleEngine engine in new[] { sync, async }) {
            // Neither falls nor draws randomly once made, so both engines must agree on them exactly.
            engine.AddParticle(Particle.BlockMarker with { BlockState = (int)Block.Stone.StateId }, 0.5, Floor + 1.5, 0.5, 0.0, 0.0, 0.0);
            int handle = engine.CreateParticle(Particle.Smoke, 0.5, Floor + 2.5, 0.5, 0.0, 0.0, 0.0);
            ref ParticleState smoke = ref engine[handle];
            smoke.Lifetime = 100;
            smoke.SetPosition(0.5, Floor + 2.5, 0.5);
            smoke.SetSpeed(0.03, -0.2, 0.01);
        }
        for (int i = 0; i < 5; i++) {
            using (syncClient.Particles.HoldLevel()) {
                sync.Tick();
            }
            using (asyncClient.Particles.HoldLevel()) {
                async.Tick();
            }
            async.Publish();
        }
        ParticleState[] expected = sync.Particles.ToArray(), actual = async.Particles.ToArray();
        Assert.That(actual.Select(p => (p.Type, p.X, p.Y, p.Z, p.Age)), Is.EqualTo(expected.Select(p => (p.Type, p.X, p.Y, p.Z, p.Age))));
    }

    [Test]
    public void ALavaParticleSmokesOnTheWorkerToo() {
        (MinecraftClient client, _, ParticleEngine engine) = World();
        engine.Asynchronous = true;
        engine.AddParticle(Particle.Lava, 0.5, Floor + 3.5, 0.5, 0.0, 0.0, 0.0);
        int smoke = 0;
        for (int i = 0; i < 6; i++) {
            using (client.Particles.HoldLevel()) {
                engine.Tick();
            }
            _ = engine.Particles;
            engine.Publish();
            smoke += engine.Pending.ToArray().Count(p => p.Type == Id(Particle.Smoke));
        }
        Assert.That(smoke, Is.GreaterThan(0));
    }
}

internal static class ClientBlockEntityTestHelper {
    public static void Place(ClientLevel level, int x, int y, int z, NBT.Tags.CompoundTag tag) {
        ClientLib.World.BlockEntities.ClientBlockEntity blockEntity = ClientLib.World.BlockEntities.ClientBlockEntity.Create(level.Registry, x, y, z, level.GetBlock(x, y, z))!;
        blockEntity.Load(tag, level.Registry);
        level.SetBlockEntity(blockEntity);
    }
}
