using ClientLib.Entities;
using ClientLib.Maths;
using Minecraft.Data.Entities;
using Minecraft.Data.Generated;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ClientLib.Testing.Play;

/// <summary><c>Leashable</c> on the client: the link packet, and where a lead ties on at either end.</summary>
public class LeashTest {
    private static ClientEntity Spawn(MinecraftClient client, IEntityType type, int id, double x = 0, double y = 0, double z = 0) {
        client.HandleSpawn(new ClientBoundSpawnEntityPacket {
            Id = id,
            Uuid = Guid.NewGuid(),
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

    private static void AssertNear(Vec3d actual, double x, double y, double z) {
        Assert.That(actual.X, Is.EqualTo(x).Within(1e-6));
        Assert.That(actual.Y, Is.EqualTo(y).Within(1e-6));
        Assert.That(actual.Z, Is.EqualTo(z).Within(1e-6));
    }

    [Test]
    public void TestTheLinkPacketSetsTheHolderOfALeashableEntityOnly() {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        ClientEntity wolf = Spawn(client, EntityType.Wolf, 1);
        ClientEntity knot = Spawn(client, EntityType.LeashKnot, 2);
        ClientEntity stand = Spawn(client, EntityType.ArmorStand, 3);
        client.HandleEntityPacket(new ClientBoundLinkEntitiesPacket { AttachedEntityId = 1, HoldingEntityId = 2 });
        client.HandleEntityPacket(new ClientBoundLinkEntitiesPacket { AttachedEntityId = 3, HoldingEntityId = 2 });
        Assert.That(Leashes.Holder(wolf, client), Is.SameAs(knot));
        // An armour stand is living but not a mob, so not Leashable.
        Assert.That(Leashes.Holder(stand, client), Is.Null);
        client.HandleEntityPacket(new ClientBoundLinkEntitiesPacket { AttachedEntityId = 1, HoldingEntityId = 0 });
        Assert.That(Leashes.Holder(wolf, client), Is.Null);
    }

    [Test]
    public void TestAWolfTiesOnAtSixTenthsOfItsEyeHeight() {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        ClientEntity wolf = Spawn(client, EntityType.Wolf, 1);
        // Wolf.getLeashOffset: (0, 0.6F * 0.68F, 0.6F * 0.4F), in floats.
        AssertNear(Leashes.LeashOffset(wolf, 1.0F), 0.0, 0.6F * 0.68F, 0.6F * 0.4F);
    }

    [Test]
    public void TestAZombieTiesOnAtItsEyes() {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        ClientEntity zombie = Spawn(client, EntityType.Zombie, 1);
        // Leashable.getLeashOffset: (0, getEyeHeight(), getBbWidth() * 0.4F).
        AssertNear(Leashes.LeashOffset(zombie, 1.0F), 0.0, 1.74F, 0.6F * 0.4F);
    }

    [Test]
    public void TestAHorseHasFourAttachmentPoints() {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        ClientEntity horse = Spawn(client, EntityType.Horse, 1);
        Assert.That(Leashes.SupportQuadLeash(horse), Is.True);
        Vec3d[] offsets = Leashes.QuadLeashOffsets(horse);
        // AbstractHorse: createQuadLeashOffsets(this, 0.04, 0.52, 0.23, 0.87) on a 1.3964844 by 1.6 box.
        double width = 1.3964844F, height = 1.6F;
        AssertNear(offsets[0], -0.23 * width, 0.87 * height, 0.52 * width + 0.04 * width);
        AssertNear(offsets[1], -0.23 * width, 0.87 * height, -0.52 * width + 0.04 * width);
        AssertNear(offsets[2], 0.23 * width, 0.87 * height, -0.52 * width + 0.04 * width);
        AssertNear(offsets[3], 0.23 * width, 0.87 * height, 0.52 * width + 0.04 * width);
    }

    [Test]
    public void TestALlamaTakesOneLeadAndOnlyAGhastHoldsFour() {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        Assert.That(Leashes.SupportQuadLeash(Spawn(client, EntityType.Llama, 1)), Is.False);
        Assert.That(Leashes.SupportQuadLeashAsHolder(Spawn(client, EntityType.HappyGhast, 2)), Is.True);
        Assert.That(Leashes.SupportQuadLeashAsHolder(Spawn(client, EntityType.Zombie, 3)), Is.False);
    }

    [Test]
    public void TestHoldersHoldTheLeadWhereVanillaDoes() {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        // Entity.getRopeHoldPosition: seven tenths of the eye height, a float widened then times a double.
        AssertNear(Leashes.RopeHoldPosition(Spawn(client, EntityType.Zombie, 1, 10, 64, 20), 1.0F), 10, 64 + 1.74F * 0.7, 20);
        // LeashFenceKnotEntity: 0.2 above its position.
        AssertNear(Leashes.RopeHoldPosition(Spawn(client, EntityType.LeashKnot, 2, 3.5, 70, -4.5), 1.0F), 3.5, 70.2, -4.5);
        // AbstractVillager: the box's height less one, 0.2 forward of a body facing south.
        AssertNear(Leashes.RopeHoldPosition(Spawn(client, EntityType.Villager, 3), 1.0F), 0.0, 1.95F - 1.0, 0.2);
    }
}
