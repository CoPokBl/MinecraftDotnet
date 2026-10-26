using ClientLib.Entities;
using ClientLib.Maths;
using ClientLib.World;
using Minecraft.Data.Entities;
using Minecraft.Data.Generated;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities.Meta;
using Minecraft.Schemas.Vec;

namespace ClientLib.Testing.Play;

/// <summary>Remote entities against <c>LinearInterpolationHandler</c>, <c>SteppedInterpolationHandler</c> and the packets that drive them.</summary>
public class EntityInterpolationTest {
    private const int ZombieId = 7;

    private static MinecraftClient EmptyWorld() {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        ClientLevel level = new(VanillaRegistry.Data, "minecraft:overworld",
            VanillaRegistry.Data.DimensionTypes["minecraft:overworld"], 63, true, 0);
        for (int cx = -4; cx <= 4; cx++) {
            for (int cz = -4; cz <= 4; cz++) {
                ClientSection[] sections = new ClientSection[level.SectionCount];
                ushort[][] biomes = new ushort[level.SectionCount][];
                for (int i = 0; i < sections.Length; i++) {
                    biomes[i] = new ushort[64];
                    sections[i] = new ClientSection(0, true);
                }
                level.AddChunk(new ClientChunk(cx, cz, sections, biomes));
            }
        }
        client.StartOffline(level).Position = new Vec3d(-40.5, 100, -40.5);
        return client;
    }

    private static ClientEntity Spawn(MinecraftClient client, IEntityType type, double z) {
        client.HandleSpawn(new ClientBoundSpawnEntityPacket {
            Id = ZombieId,
            Uuid = Guid.NewGuid(),
            EntityType = type,
            Position = new Vec3<double>(0.5, 100, z),
            Pitch = Angle.FromDegrees(0),
            Yaw = Angle.FromDegrees(0),
            HeadYaw = Angle.FromDegrees(0),
            Data = 0,
            Velocity = new Vec3<double>(0, 0, 0)
        });
        return client.Entities[ZombieId];
    }

    private static void Sync(MinecraftClient client, double z, float yaw = 0, params (double Z, int Ticks)[] steps) {
        client.HandleEntityTeleport(new ClientBoundTeleportEntityPacket {
            EntityId = ZombieId,
            Position = new Vec3<double>(0.5, 100, steps.Length > 0 ? steps[^1].Z : z),
            Steps = steps.Length > 0 ? steps.Select(step => new ClientBoundTeleportEntityPacket.Step(new Vec3<double>(0.5, 100, step.Z), step.Ticks)).ToArray() : null,
            Yaw = Angle.FromDegrees(yaw),
            Pitch = Angle.FromDegrees(0),
            OnGround = false
        });
    }

    /// <summary>
    /// A zombie's <c>SteppedInterpolationHandler</c> takes a plain sync as one step of its type's update
    /// interval, 3 ticks, starting a tick in: 0.5 to 30.5 lands on a third and two thirds, by the float
    /// fraction <c>currentStepTicks / tickOffset</c>. The same sync arriving again mid-way does not restart it.
    /// </summary>
    [Test]
    public void ARepeatedSyncDoesNotRestartTheLerp() {
        MinecraftClient client = EmptyWorld();
        ClientEntity zombie = Spawn(client, EntityType.Zombie, 0.5);

        Sync(client, 30.5);
        client.Tick();
        Assert.That(zombie.Position.Z, Is.EqualTo(10.500000298023224));
        client.Tick();
        Assert.That(zombie.Position.Z, Is.EqualTo(20.500000596046448));

        Sync(client, 30.5);
        client.Tick();
        Assert.That(zombie.Position.Z, Is.EqualTo(30.5));
        Assert.That(zombie.IsInterpolating, Is.False);
    }

    /// <summary>
    /// A stepped path of 2 then 4 ticks totals 6, twice the update interval, so <c>advance</c> runs faster
    /// than a tick a tick and the six ticks are walked in five. The turn to 90 is spread over the steps by
    /// how far through the ticks each lands, a third at the first. Values from a float transcription of
    /// <c>SteppedInterpolationHandler</c>.
    /// </summary>
    [Test]
    public void ASteppedPathIsWalkedStepByStepAndCatchesUp() {
        MinecraftClient client = EmptyWorld();
        ClientEntity zombie = Spawn(client, EntityType.Zombie, 0.5);

        Sync(client, 0, 90, (10.5, 2), (30.5, 4));
        double[] z = [5.5, 12.166667461395264, 19.203704476356506, 25.70576238632202, 30.5];
        float[] yRot = [15.0F, 35.000003814697266F, 56.111114501953125F, 75.6172866821289F, 90.0F];
        for (int i = 0; i < z.Length; i++) {
            client.Tick();
            Assert.That(zombie.Position.Z, Is.EqualTo(z[i]), $"tick {i + 1}");
            Assert.That(zombie.YRot, Is.EqualTo(yRot[i]), $"tick {i + 1}");
        }
        Assert.That(zombie.IsInterpolating, Is.False);
    }

    /// <summary>A sync arriving before the last one is reached is queued behind it, and the speed picks up to catch up.</summary>
    [Test]
    public void SyncsInARowQueueUp() {
        MinecraftClient client = EmptyWorld();
        ClientEntity zombie = Spawn(client, EntityType.Zombie, 0.5);

        double[] z = [3.833333432674408, 7.166666865348816, 11.24074111878872, 16.467078804969788, 21.880887031555176, 26.818142414093018, 30.5];
        for (int i = 0; i < z.Length; i++) {
            if (i < 3) {
                Sync(client, 10.5 + 10 * i);
            }
            client.Tick();
            Assert.That(zombie.Position.Z, Is.EqualTo(z[i]), $"tick {i + 1}");
        }
        Assert.That(zombie.IsInterpolating, Is.False);
    }

    /// <summary><c>handleEntityPositionSync</c> snaps an entity the level is not ticking, here one outside every loaded chunk.</summary>
    [Test]
    public void AnEntityOutsideTheLoadedChunksSnaps() {
        MinecraftClient client = EmptyWorld();
        ClientEntity zombie = Spawn(client, EntityType.Zombie, 100.5);
        Sync(client, 110.5);
        Assert.That(zombie.Position.Z, Is.EqualTo(110.5));
        Assert.That(zombie.IsInterpolating, Is.False);
    }

    /// <summary>
    /// <c>VecDelta.Stepped.decode</c>: each step is relative to the step before, and an axis no step moves
    /// stays exactly where the spawn put it rather than at its 1/4096 quantisation.
    /// </summary>
    [Test]
    public void ASteppedMoveDecodesEachStepFromTheLast() {
        MinecraftClient client = EmptyWorld();
        client.HandleSpawn(new ClientBoundSpawnEntityPacket {
            Id = ZombieId,
            Uuid = Guid.NewGuid(),
            EntityType = EntityType.Zombie,
            Position = new Vec3<double>(0.123456789, 100, 0.5),
            Pitch = Angle.FromDegrees(0),
            Yaw = Angle.FromDegrees(0),
            HeadYaw = Angle.FromDegrees(0),
            Data = 0,
            Velocity = new Vec3<double>(0, 0, 0)
        });
        ClientEntity zombie = client.Entities[ZombieId];

        client.HandleMove(ZombieId, (new Vec3<float>(0, 0, 3.0F), [
            new MovementDelta.Step(3, new Vec3<float>(0, 0, 1.0F)),
            new MovementDelta.Step(3, new Vec3<float>(0, 0, 2.0F))
        ]), null, null, false);
        Assert.That(zombie.CodecBase, Is.EqualTo(new Vec3d(0.123456789, 100, 3.5)));

        double[] z = [0.8333333432674408, 1.2777778506278992, 1.9938271939754486, 2.86076819896698, 3.5];
        for (int i = 0; i < z.Length; i++) {
            client.Tick();
            Assert.That(zombie.Position.X, Is.EqualTo(0.123456789));
            Assert.That(zombie.Position.Z, Is.EqualTo(z[i]), $"tick {i + 1}");
        }
    }

    /// <summary>
    /// A display's <c>LinearInterpolationHandler</c> takes no steps until <c>teleport_duration</c> gives it
    /// some, and then a move is that many even steps.
    /// </summary>
    [Test]
    public void ADisplayFollowsItsTeleportDuration() {
        MinecraftClient client = EmptyWorld();
        ClientEntity display = Spawn(client, EntityType.BlockDisplay, 0.5);
        Sync(client, 2.5);
        Assert.That(display.Position.Z, Is.EqualTo(2.5));

        display.Metadata[EntityDataFields.Display.PosRotInterpolationDuration.Index] = new MetaField<int>(MetaFieldType.VarInt, 2);
        display.OnSyncedDataUpdated(EntityDataFields.Display.PosRotInterpolationDuration.Index);
        Sync(client, 4.5);
        Assert.That(display.Position.Z, Is.EqualTo(2.5));
        client.Tick();
        Assert.That(display.Position.Z, Is.EqualTo(3.5));
        client.Tick();
        Assert.That(display.Position.Z, Is.EqualTo(4.5));
    }
}
