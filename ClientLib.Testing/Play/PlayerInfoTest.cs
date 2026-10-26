using ClientLib.Entities;
using Minecraft.Data.Generated;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ClientLib.Testing.Play;

/// <summary><c>createEntityFromPacket</c> and <c>AbstractClientPlayer.getPlayerInfo</c>: what a player entity knows of its profile.</summary>
public class PlayerInfoTest {
    private static void Spawn(MinecraftClient client, Guid uuid, int id) {
        client.HandleSpawn(new ClientBoundSpawnEntityPacket {
            Id = id,
            Uuid = uuid,
            EntityType = EntityType.Player,
            Position = new Vec3<double>(0, 0, 0),
            Pitch = Angle.FromDegrees(0),
            Yaw = Angle.FromDegrees(0),
            HeadYaw = Angle.FromDegrees(0),
            Data = 0,
            Velocity = new Vec3<double>(0, 0, 0)
        });
    }

    [Test]
    public void TestAPlayerWithoutPlayerInfoIsNotAdded() {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        Spawn(client, Guid.NewGuid(), 1);
        Assert.That(client.Entities.ContainsKey(1), Is.False);
    }

    /// <summary>Servers spawn players as NPCs and take them off the tab list straight after, which leaves the name.</summary>
    [Test]
    public void TestAPlayerKeepsItsNameOnceOffTheList() {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        Guid uuid = Guid.NewGuid();
        client.PlayerList[uuid] = new PlayerListEntry(uuid, "Npc");
        Spawn(client, uuid, 1);
        client.PlayerList.Remove(uuid);
        ClientEntity npc = client.Entities[1];
        Assert.Multiple(() => {
            Assert.That(client.ScoreboardName(npc), Is.EqualTo("Npc"));
            Assert.That(TextFlattener.Plain(client.DisplayNameOf(npc)), Is.EqualTo("Npc"));
        });
    }
}
