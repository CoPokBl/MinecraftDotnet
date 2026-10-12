using ClientLib.Entities;
using ClientLib.Maths;
using ClientLib.World;
using Minecraft.Data.Generated;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ClientLib.Testing.Play;

/// <summary>Remote entities against <c>InterpolationHandler.interpolateTo</c> and <c>interpolate</c>.</summary>
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

    private static void Sync(MinecraftClient client, double z) {
        client.HandleEntityTeleport(new ClientBoundTeleportEntityPacket {
            EntityId = ZombieId,
            Position = new Vec3<double>(0.5, 100, z),
            Velocity = new Vec3<double>(0, 0, 0),
            Yaw = Angle.FromDegrees(0),
            Pitch = Angle.FromDegrees(0),
            OnGround = false
        });
    }

    /// <summary>
    /// A sync to z 30.5 from z 0.5 lerps over three ticks, by a third, a half, then all of what is left:
    /// 10.5, 20.5, 30.5. The same sync arriving again mid-way does not restart it, so the third tick still
    /// lands on the target rather than at 20.5 + 10 / 3.
    /// </summary>
    [Test]
    public void ARepeatedSyncDoesNotRestartTheLerp() {
        MinecraftClient client = EmptyWorld();
        client.HandleSpawn(new ClientBoundSpawnEntityPacket {
            Id = ZombieId,
            Uuid = Guid.NewGuid(),
            EntityType = EntityType.Zombie,
            Position = new Vec3<double>(0.5, 100, 0.5),
            Pitch = Angle.FromDegrees(0),
            Yaw = Angle.FromDegrees(0),
            HeadYaw = Angle.FromDegrees(0),
            Data = 0,
            Velocity = new Vec3<double>(0, 0, 0)
        });
        ClientEntity zombie = client.Entities[ZombieId];

        Sync(client, 30.5);
        client.Tick();
        Assert.That(zombie.Position.Z, Is.EqualTo(10.5).Within(1e-12));
        client.Tick();
        Assert.That(zombie.Position.Z, Is.EqualTo(20.5).Within(1e-12));

        Sync(client, 30.5);
        client.Tick();
        Assert.That(zombie.Position.Z, Is.EqualTo(30.5));
        Assert.That(zombie.IsInterpolating, Is.False);
    }
}
