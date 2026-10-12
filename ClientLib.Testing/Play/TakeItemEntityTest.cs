using ClientLib.Entities;
using ClientLib.World;
using Minecraft.Data.Entities;
using Minecraft.Data.Generated;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas.Entities.Meta;
using Minecraft.Schemas.Items;

namespace ClientLib.Testing.Play;

/// <summary><c>ClientPacketListener.handleTakeItemEntity</c>'s effect on the taken entity.</summary>
public class TakeItemEntityTest {
    private const int PlayerId = 1;

    private static MinecraftClient Client() {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        ClientLevel level = new(VanillaRegistry.Data, "minecraft:overworld",
            VanillaRegistry.Data.DimensionTypes["minecraft:overworld"], 63, true, 0);
        client.StartOffline(level, PlayerId);
        return client;
    }

    private static ClientEntity Spawn(MinecraftClient client, int id, IEntityType type, int count = 0) {
        ClientEntity entity = new() { Id = id, Type = type };
        if (count > 0) {
            entity.Metadata[EntityDataFields.ItemEntity.Item.Index] = new MetaField<ItemStack>(MetaFieldType.Slot, new ItemStack(Item.Stone, count));
        }
        client.Entities[id] = entity;
        return entity;
    }

    private static void Take(MinecraftClient client, int id, int collector, int amount) =>
        client.HandleTakeItemEntity(new ClientBoundPickupItemPacket { CollectedEntityId = id, CollectorEntityId = collector, PickupItemCount = amount });

    [Test]
    public void TestPartialPickupShrinksAfterTheEventAndKeepsTheEntity() {
        MinecraftClient client = Client();
        ClientEntity item = Spawn(client, 10, EntityType.Item, 5);
        List<(ClientEntity From, ClientEntity To, int Count)> taken = [];
        client.EntityTaken += (from, to) => taken.Add((from, to, from.Get(EntityDataFields.ItemEntity.Item)!.Count));

        Take(client, 10, PlayerId, 2);

        Assert.That(taken, Has.Count.EqualTo(1));
        Assert.That(taken[0].From, Is.SameAs(item));
        Assert.That(taken[0].To, Is.SameAs(client.Player));
        Assert.That(taken[0].Count, Is.EqualTo(5));
        Assert.That(client.Entities.ContainsKey(10), Is.True);
        Assert.That(item.Get(EntityDataFields.ItemEntity.Item)!.Count, Is.EqualTo(3));

        Take(client, 10, PlayerId, 3);
        Assert.That(client.Entities.ContainsKey(10), Is.False);
    }

    [Test]
    public void TestOverlargePickupRemovesTheItem() {
        MinecraftClient client = Client();
        Spawn(client, 10, EntityType.Item, 1);
        Take(client, 10, PlayerId, 4);
        Assert.That(client.Entities.ContainsKey(10), Is.False);
    }

    [Test]
    public void TestUnknownCollectorFallsBackToThePlayer() {
        MinecraftClient client = Client();
        Spawn(client, 10, EntityType.Item, 1);
        ClientEntity? to = null;
        client.EntityTaken += (_, collector) => to = collector;
        Take(client, 10, 99, 1);
        Assert.That(to, Is.SameAs(client.Player));
    }

    [Test]
    public void TestOrbStaysAndArrowGoes() {
        MinecraftClient client = Client();
        Spawn(client, 10, EntityType.ExperienceOrb);
        Spawn(client, 11, EntityType.Arrow);
        int events = 0;
        client.EntityTaken += (_, _) => events++;

        Take(client, 10, PlayerId, 1);
        Take(client, 11, PlayerId, 1);

        Assert.That(events, Is.EqualTo(2));
        Assert.That(client.Entities.ContainsKey(10), Is.True);
        Assert.That(client.Entities.ContainsKey(11), Is.False);
    }

    [Test]
    public void TestUnknownEntityDoesNothing() {
        MinecraftClient client = Client();
        int events = 0;
        client.EntityTaken += (_, _) => events++;
        Take(client, 10, PlayerId, 1);
        Assert.That(events, Is.EqualTo(0));
    }
}
