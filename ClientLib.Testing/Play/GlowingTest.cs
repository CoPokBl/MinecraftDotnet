using ClientLib.Entities;
using Minecraft.Data.Entities;
using Minecraft.Data.Generated;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities.Meta;
using Minecraft.Schemas.Vec;
using Minecraft.Text;

namespace ClientLib.Testing.Play;

/// <summary><c>Entity.isCurrentlyGlowing</c> and <c>Entity.getTeamColor</c> on the client, which colour a glowing entity's outline.</summary>
public class GlowingTest {
    private static ClientEntity Spawn(MinecraftClient client, IEntityType type, int id) {
        client.HandleSpawn(new ClientBoundSpawnEntityPacket {
            Id = id,
            Uuid = Guid.NewGuid(),
            EntityType = type,
            Position = new Vec3<double>(0, 0, 0),
            Pitch = Angle.FromDegrees(0),
            Yaw = Angle.FromDegrees(0),
            HeadYaw = Angle.FromDegrees(0),
            Data = 0,
            Velocity = new Vec3<double>(0, 0, 0)
        });
        return client.Entities[id];
    }

    private static void JoinTeam(MinecraftClient client, string team, ClientBoundUpdateTeamsPacket.TeamColor colour, string member) {
        client.Scoreboard.Handle(ClientBoundUpdateTeamsPacket.CreateTeam(team, TextComponent.Text(team), 0, ClientBoundUpdateTeamsPacket.NameTagVisibility.Always,
            ClientBoundUpdateTeamsPacket.CollisionRule.Always, colour, TextComponent.Empty(), TextComponent.Empty(), [member]));
    }

    [Test]
    public void TestGlowingIsSharedFlagSix() {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        ClientEntity zombie = Spawn(client, EntityType.Zombie, 1);
        Assert.That(zombie.IsCurrentlyGlowing, Is.False);
        // On fire and invisible, which are flags 0 and 5, are not glowing.
        zombie.Metadata[EntityDataFields.Entity.SharedFlags.Index] = new MetaField<sbyte>(MetaFieldType.Byte, 0x21);
        Assert.That(zombie.IsCurrentlyGlowing, Is.False);
        zombie.Metadata[EntityDataFields.Entity.SharedFlags.Index] = new MetaField<sbyte>(MetaFieldType.Byte, 0x60);
        Assert.That(zombie.IsCurrentlyGlowing, Is.True);
    }

    [Test]
    public void TestTeamColourIsWhiteWithoutATeam() {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        Assert.That(client.TeamColour(Spawn(client, EntityType.Zombie, 1)), Is.EqualTo(0xFFFFFF));
    }

    [Test]
    public void TestAMobsTeamIsFoundByItsUuid() {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        ClientEntity zombie = Spawn(client, EntityType.Zombie, 1);
        JoinTeam(client, "red", ClientBoundUpdateTeamsPacket.TeamColor.Red, zombie.Uuid.ToString());
        Assert.That(client.TeamColour(zombie), Is.EqualTo(0xFF5555));
    }

    [Test]
    public void TestAPlayersTeamIsFoundByItsProfileName() {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        ClientEntity player = Spawn(client, EntityType.Player, 1);
        client.PlayerList[player.Uuid] = new PlayerListEntry(player.Uuid, "Steve");
        JoinTeam(client, "blue", ClientBoundUpdateTeamsPacket.TeamColor.DarkBlue, "Steve");
        Assert.That(client.TeamColour(player), Is.EqualTo(0x0000AA));
    }

    [Test]
    public void TestADisplaysGlowColourOverridesItsTeam() {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        ClientEntity display = Spawn(client, EntityType.BlockDisplay, 1);
        JoinTeam(client, "red", ClientBoundUpdateTeamsPacket.TeamColor.Red, display.Uuid.ToString());
        display.Metadata[EntityDataFields.Display.GlowColorOverride.Index] = new MetaField<int>(MetaFieldType.VarInt, -1);
        Assert.That(client.TeamColour(display), Is.EqualTo(0xFF5555));
        display.Metadata[EntityDataFields.Display.GlowColorOverride.Index] = new MetaField<int>(MetaFieldType.VarInt, 0x123456);
        Assert.That(client.TeamColour(display), Is.EqualTo(0x123456));
    }
}
