using ClientLib.Entities;
using ClientLib.Maths;
using ClientLib.Player;
using ClientLib.World;
using Minecraft.Data.Entities;
using Minecraft.Data.Generated;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities.Meta;
using Minecraft.Schemas.Vec;
using Minecraft.Text;

namespace ClientLib.Testing.Player;

/// <summary>
/// The local player against the entities <c>Entity.collide</c> takes as colliders. The server runs the
/// same collisions for the player's moves, so a client that walks through a boat is put back on it.
/// </summary>
public class EntityCollisionTest {
    private const int Floor = 16;
    private const int OtherId = 20;

    private static (MinecraftClient Client, LocalPlayer Player) World() {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        ClientLevel level = new(VanillaRegistry.Data, "minecraft:overworld",
            VanillaRegistry.Data.DimensionTypes["minecraft:overworld"], 63, true, 0);
        for (int cx = -2; cx <= 2; cx++) {
            for (int cz = -2; cz <= 2; cz++) {
                ClientSection[] sections = new ClientSection[level.SectionCount];
                ushort[][] biomes = new ushort[level.SectionCount][];
                for (int i = 0; i < sections.Length; i++) {
                    biomes[i] = new ushort[64];
                    sections[i] = level.MinY + i * 16 < Floor ? new ClientSection((ushort)Block.Stone.StateId, false) : new ClientSection(0, true);
                }
                level.AddChunk(new ClientChunk(cx, cz, sections, biomes));
            }
        }
        return (client, client.StartOffline(level));
    }

    private static ClientEntity Spawn(MinecraftClient client, IEntityType type, Vec3d position) {
        client.HandleSpawn(new ClientBoundSpawnEntityPacket {
            Id = OtherId,
            Uuid = Guid.NewGuid(),
            EntityType = type,
            Position = new Vec3<double>(position.X, position.Y, position.Z),
            Pitch = Angle.FromDegrees(0),
            Yaw = Angle.FromDegrees(0),
            HeadYaw = Angle.FromDegrees(0),
            Data = 0,
            Velocity = new Vec3<double>(0, 0, 0)
        });
        return client.Entities[OtherId];
    }

    private static void Tick(MinecraftClient client, LocalPlayer player, PlayerInput input, int ticks) {
        for (int i = 0; i < ticks; i++) {
            player.Input = input;
            client.Tick();
        }
    }

    /// <summary>Drops the player onto whatever is below <paramref name="x"/>, <paramref name="z"/> from <paramref name="y"/>.</summary>
    private static void Drop(MinecraftClient client, LocalPlayer player, double x, double y, double z) {
        player.Position = new Vec3d(x, y, z);
        Tick(client, player, PlayerInput.None, 40);
    }

    [Test]
    public void StandsOnABoatsTop() {
        (MinecraftClient client, LocalPlayer player) = World();
        ClientEntity boat = Spawn(client, EntityType.OakBoat, new Vec3d(0.5, Floor, 0.5));
        Drop(client, player, 0.5, Floor + 2, 0.5);
        Assert.That(player.Position.Y, Is.EqualTo(boat.BoundingBox.MaxY).Within(1.0E-9));
        Assert.That(player.OnGround, Is.True);
    }

    [Test]
    public void WalksOffABoatOntoTheFloor() {
        (MinecraftClient client, LocalPlayer player) = World();
        ClientEntity boat = Spawn(client, EntityType.OakBoat, new Vec3d(0.5, Floor, 0.5));
        Drop(client, player, 0.5, Floor + 2, 0.5);
        Tick(client, player, new PlayerInput(Forward: true), 30);
        Assert.That(player.Position.Z, Is.GreaterThan(boat.BoundingBox.MaxZ + 0.3));
        Assert.That(player.Position.Y, Is.EqualTo(Floor));
        Assert.That(player.OnGround, Is.True);
    }

    [Test]
    public void SneakingStopsAtABoatsEdge() {
        (MinecraftClient client, LocalPlayer player) = World();
        ClientEntity boat = Spawn(client, EntityType.OakBoat, new Vec3d(0.5, Floor + 2, 0.5));
        Drop(client, player, 0.5, Floor + 4, 0.5);
        Tick(client, player, new PlayerInput(Forward: true, Shift: true), 60);
        Assert.That(player.Position.Y, Is.EqualTo(boat.BoundingBox.MaxY).Within(1.0E-9));
        Assert.That(player.Position.Z, Is.GreaterThan(boat.BoundingBox.MaxZ).And.LessThan(boat.BoundingBox.MaxZ + 0.3));
    }

    [Test]
    public void ShulkerIsAFloorAndItsLidLiftsThePlayer() {
        (MinecraftClient client, LocalPlayer player) = World();
        ClientShulker shulker = (ClientShulker)Spawn(client, EntityType.Shulker, new Vec3d(0.5, Floor, 0.5));
        Drop(client, player, 0.5, Floor + 2, 0.5);
        Assert.That(player.Position.Y, Is.EqualTo(Floor + 1.0).Within(1.0E-9));

        shulker.Metadata[EntityDataFields.Shulker.Peek.Index] = new MetaField<sbyte>(MetaFieldType.Byte, 100);
        Tick(client, player, PlayerInput.None, 30);
        Assert.That(shulker.BoundingBox.MaxY, Is.EqualTo(Floor + 2.0).Within(1.0E-6));
        Assert.That(player.Position.Y, Is.EqualTo(shulker.BoundingBox.MaxY).Within(1.0E-6));
        Assert.That(player.OnGround, Is.True);
    }

    [Test]
    public void APlayerAboveAHappyGhastStandsOnIt() {
        (MinecraftClient client, LocalPlayer player) = World();
        ClientEntity ghast = Spawn(client, EntityType.HappyGhast, new Vec3d(0.5, Floor + 2, 0.5));
        Drop(client, player, 0.5, Floor + 8, 0.5);
        Assert.That(player.Position.Y, Is.EqualTo(ghast.BoundingBox.MaxY).Within(1.0E-9));
    }

    /// <summary>
    /// The cow's <c>pushEntities</c> runs after the player has moved, so the push lands in the velocity and moves
    /// the player a tick later. 0.3 apart: <c>sqrt(0.3)</c> after <c>dd = sqrt(absMax)</c>, the power capped at 1.
    /// </summary>
    [Test]
    public void ACowStandingInThePlayerPushesItAway() {
        (MinecraftClient client, LocalPlayer player) = World();
        Drop(client, player, 0.5, Floor, 0.5);
        Spawn(client, EntityType.Cow, new Vec3d(0.8, Floor, 0.5));
        double push = Math.Sqrt(0.3) * 0.05F;
        Tick(client, player, PlayerInput.None, 1);
        Assert.That(player.Position.X, Is.EqualTo(0.5));
        Assert.That(player.DeltaMovement.X, Is.EqualTo(-push).Within(1.0E-12));
        Assert.That(player.DeltaMovement.Z, Is.EqualTo(0.0));
        Tick(client, player, PlayerInput.None, 1);
        Assert.That(player.Position.X, Is.EqualTo(0.5 - push).Within(1.0E-12));
    }

    [Test]
    public void ATeamThatNeverCollidesDoesNotPush() {
        (MinecraftClient client, LocalPlayer player) = World();
        Drop(client, player, 0.5, Floor, 0.5);
        ClientEntity cow = Spawn(client, EntityType.Cow, new Vec3d(0.8, Floor, 0.5));
        client.Scoreboard.Handle(ClientBoundUpdateTeamsPacket.CreateTeam("ghosts", TextComponent.Text("ghosts"), 0,
            ClientBoundUpdateTeamsPacket.NameTagVisibility.Always, ClientBoundUpdateTeamsPacket.CollisionRule.Never,
            ClientBoundUpdateTeamsPacket.TeamColor.White, TextComponent.Empty(), TextComponent.Empty(), [cow.Uuid.ToString()]));
        Tick(client, player, PlayerInput.None, 5);
        Assert.That(player.Position.X, Is.EqualTo(0.5));
    }

    /// <summary>
    /// <c>AbstractBoat.tick</c> pushes what its box, widened by 0.2, reaches and stands no higher than it, away
    /// from itself: 1 apart, the push is the whole 0.05F.
    /// </summary>
    [Test]
    public void ABoatAlongsidePushesThePlayerAway() {
        (MinecraftClient client, LocalPlayer player) = World();
        Drop(client, player, 0.5, Floor, 0.5);
        Spawn(client, EntityType.OakBoat, new Vec3d(1.5, Floor, 0.5));
        Tick(client, player, PlayerInput.None, 1);
        Assert.That(player.DeltaMovement.X, Is.EqualTo(-(double)0.05F).Within(1.0E-12));
    }

    /// <summary><c>AbstractCubeMob.getDefaultDimensions</c>: the type's 0.52 scaled by the size.</summary>
    [Test]
    public void AMagmaCubesBoxGrowsWithItsSize() {
        (MinecraftClient client, _) = World();
        ClientEntity cube = Spawn(client, EntityType.MagmaCube, new Vec3d(0.5, Floor, 0.5));
        cube.Metadata[EntityDataFields.AbstractCubeMob.IdSize.Index] = new MetaField<int>(MetaFieldType.VarInt, 4);
        Assert.That(cube.BoundingBox.MaxX - cube.BoundingBox.MinX, Is.EqualTo(0.52F * 4).Within(1.0E-6));
        Assert.That(cube.BoundingBox.MaxY, Is.EqualTo(Floor + 0.52F * 4).Within(1.0E-6));
    }

    [Test]
    public void APigIsNoFloor() {
        (MinecraftClient client, LocalPlayer player) = World();
        Spawn(client, EntityType.Pig, new Vec3d(0.5, Floor, 0.5));
        Drop(client, player, 0.5, Floor + 2, 0.5);
        Assert.That(player.Position.Y, Is.EqualTo(Floor));
    }
}
